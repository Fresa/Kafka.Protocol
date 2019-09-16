using System;
using System.IO.Pipelines;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Kafka.Protocol;

namespace Kafka.TestServer
{
    internal class Client : IDisposable
    {
        private readonly Socket _socket;

        private Client(Socket socket)
        {
            _socket = socket;
            _reader = new RequestReader(_pipe.Reader);
        }

        private readonly BufferBlock<ResponsePayload> _responsePayloads = new BufferBlock<ResponsePayload>();

        private readonly Pipe _pipe = new Pipe();
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        private Task _sendAndReceiveBackgroundTask;
        private readonly RequestReader _reader;

        internal async Task<RequestPayload> ReadAsync(CancellationToken cancellationToken)
        {
            return await _reader.ReadAsync(cancellationToken);
        }

        internal async Task SendAsync(
            ResponsePayload payload, 
            CancellationToken cancellationToken)
        {
            await _responsePayloads.SendAsync(payload, cancellationToken);
        }

        internal static Client Start(Socket clientSocket)
        {
            var client = new Client(clientSocket);
            client.StartSendingAndReceiving();
            return client;
        }

        private void StartSendingAndReceiving()
        {
            _sendAndReceiveBackgroundTask = Task.Run(
                async () =>
                {
                    var cancellationToken = _cancellationSource.Token;
                    try
                    {
                        var dataReceiver = new DataReceiver(_socket);
                        while (cancellationToken.IsCancellationRequested == false)
                        {
                            // todo: alternate send
                            await dataReceiver
                                .ReceiveAsync(_pipe.Writer, cancellationToken)
                                .ConfigureAwait(false);
                        }
                    }
                    catch (Exception) when (_cancellationSource.IsCancellationRequested)
                    {
                        // Shutdown in progress
                    }
                });
        }

        public void Dispose()
        {
            _cancellationSource.Cancel();

            _sendAndReceiveBackgroundTask.Wait(TimeSpan.FromSeconds(3));
        }
    }
}