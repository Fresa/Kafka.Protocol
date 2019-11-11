using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol;
using Int32 = Kafka.Protocol.Int32;

namespace Kafka.TestServer
{
    internal class Client : IAsyncDisposable
    {
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        private readonly Pipe _pipe = new Pipe();

        private readonly IKafkaReader _reader;
        private readonly INetworkClient _networkClient;
        private Task _sendAndReceiveBackgroundTask = default!;

        private Client(INetworkClient networkClient)
        {
            _networkClient = networkClient;
            _reader = new KafkaReader(_pipe.Reader);
        }

        internal async Task<RequestPayload> ReadAsync(
            CancellationToken cancellationToken = default)
        {
            return await RequestPayload.ReadFrom(0, _reader, cancellationToken);
        }

        internal async Task SendAsync(
            ResponsePayload payload,
            CancellationToken cancellationToken)
        {
            await using var buffer = new MemoryStream();
            await using var writer = new KafkaWriter(buffer);
            {
                await payload.WriteToAsync(writer, cancellationToken);
                await buffer.FlushAsync(cancellationToken);
                buffer.Position = 0;
                await writer.WriteInt32Async(Int32.From((int)buffer.Length), cancellationToken);
            }

            await _networkClient.SendAsync(
                buffer.GetBuffer(),
                cancellationToken);
        }

        internal static Client Start(INetworkClient networkClient)
        {
            var client = new Client(networkClient);
            client.StartReceiving();
            return client;
        }

        private void StartReceiving()
        {
            _sendAndReceiveBackgroundTask = Task.Run(
                async () =>
                {
                    var cancellationToken = _cancellationSource.Token;
                    try
                    {
                        var dataReceiver = new DataReceiver(_networkClient);
                        while (cancellationToken.IsCancellationRequested == false)
                        {
                            await dataReceiver
                                .ReceiveAsync(_pipe.Writer, cancellationToken);
                        }
                    }
                    catch when (_cancellationSource.IsCancellationRequested)
                    {
                        // Shutdown in progress
                    }
                });
        }

        public async ValueTask DisposeAsync()
        {
            _cancellationSource.Cancel();

            await _sendAndReceiveBackgroundTask;
        }
    }
}