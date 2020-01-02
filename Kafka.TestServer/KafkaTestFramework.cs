using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Kafka.Protocol;

namespace Kafka.TestServer
{
    public abstract class KafkaTestFramework : IAsyncDisposable
    {
        private readonly INetworkServer _networkServer;

        private readonly CancellationTokenSource _cancellationTokenSource =
            new CancellationTokenSource();
        private readonly List<Task> _backgroundTasks = new List<Task>();

        private const int Stopped = 0;
        private const int Started = 1;
        private int _status = Stopped;

        public static InMemoryKafkaTestFramework InMemory()
        {
            return new InMemoryKafkaTestFramework(
                new BufferBlock<INetworkClient>());
        }

        public static SocketBasedKafkaTestFramework WithSocket()
        {
            var server = SocketServer.Start();
            return new SocketBasedKafkaTestFramework(server);
        }

        public static SocketBasedKafkaTestFramework WithSocket(
            IPAddress localIpAddress,
            int port = 0)
        {
            var server = SocketServer.Start(localIpAddress, port);
            return new SocketBasedKafkaTestFramework(server);
        }

        internal KafkaTestFramework(INetworkServer networkServer)
        {
            _networkServer = networkServer;
        }

        public IAsyncDisposable Start()
        {
            var previousStatus = Interlocked.Exchange(ref _status, Started);
            if (previousStatus == Started)
            {
                return this;
            }

            var task = Task.Run(
                async () =>
                {
                    while (_cancellationTokenSource.IsCancellationRequested == false)
                    {
                        try
                        {
                            var client = await _networkServer
                                .WaitForConnectedClientAsync(_cancellationTokenSource.Token)
                                .ConfigureAwait(false);
                            ReceiveMessagesFor(client);
                        }
                        catch when (_cancellationTokenSource.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                });
            _backgroundTasks.Add(task);
            return this;
        }

        private void ReceiveMessagesFor(INetworkClient networkClient)
        {
            var task = Task.Run(
                async () =>
                {
                    var client = ResponseClient.Start(networkClient);
                    await using var _ = client.ConfigureAwait(false);
                    while (_cancellationTokenSource.IsCancellationRequested == false)
                    {
                        try
                        {
                            var requestPayload = await client
                                .ReadAsync(_cancellationTokenSource.Token)
                                .ConfigureAwait(false);
                            if (_subscriptions.TryGetValue(requestPayload.Message.GetType(), out var subscription))
                            {
                                var response = subscription(requestPayload.Message);
                                await client
                                    .SendAsync(
                                        new ResponsePayload(
                                            requestPayload,
                                            new ResponseHeader(requestPayload.Header.Version)
                                                .WithCorrelationId(requestPayload.Header.CorrelationId),
                                            response),
                                        _cancellationTokenSource.Token)
                                    .ConfigureAwait(false);
                            }
                        }
                        catch when (_cancellationTokenSource.IsCancellationRequested)
                        {
                            return;
                        }
                    }

                });
            _backgroundTasks.Add(task);
        }

        private readonly Dictionary<Type, Func<Message, Message>> _subscriptions =
            new Dictionary<Type, Func<Message, Message>>();

        public KafkaTestFramework On<TRequestMessage, TResponseMessage>(
            Func<TRequestMessage, TResponseMessage> subscription)
            where TRequestMessage : Message, IRespond<TResponseMessage>
            where TResponseMessage : Message
        {
            _subscriptions.Add(
                typeof(TRequestMessage),
                message => subscription.Invoke((TRequestMessage)message));
            return this;
        }

        public async ValueTask DisposeAsync()
        {
            _cancellationTokenSource.Cancel();

            await Task.WhenAll(_backgroundTasks);
        }
    }
}