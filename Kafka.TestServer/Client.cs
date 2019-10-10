using System;
using System.IO;
using System.IO.Pipelines;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol;

namespace Kafka.TestServer
{
    internal class Client : IAsyncDisposable
    {
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        private readonly Pipe _pipe = new Pipe();

        private readonly RequestReader _reader;
        private readonly Socket _socket;
        private Task _sendAndReceiveBackgroundTask = default!;

        private Client(Socket socket)
        {
            _socket = socket;
            _reader = new RequestReader(_pipe.Reader);
        }

        internal async Task<RequestPayload> ReadAsync(CancellationToken cancellationToken)
        {
            return await _reader.ReadAsync(cancellationToken);
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
                await writer.WriteInt32Async((int)buffer.Length, cancellationToken);
            }

            await _socket.SendAsync(
                buffer.GetBuffer(),
                SocketFlags.None,
                cancellationToken);
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