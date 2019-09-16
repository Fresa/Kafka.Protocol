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
        }

        private readonly BufferBlock<RequestPayload> _requestPayloads = new BufferBlock<RequestPayload>();
        private readonly BufferBlock<ResponsePayload> _responsePayloads = new BufferBlock<ResponsePayload>();

        private readonly Pipe _pipe = new Pipe();
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        private Task _readAndWriteBackgroundTask;
        private Task _sendAndReceiveBackgroundTask;

        internal async Task<RequestPayload> ReadAsync(CancellationToken cancellationToken)
        {
            return await _requestPayloads.ReceiveAsync(cancellationToken);
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
            client.StartReadingAndWriting();
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

        private void StartReadingAndWriting()
        {
            _readAndWriteBackgroundTask = Task.Run(
                async () =>
                {
                    var cancellationToken = _cancellationSource.Token;
                    try
                    {
                        var reader = new RequestReader(_pipe.Reader);
                        while (cancellationToken.IsCancellationRequested == false)
                        {
                            var requestPayload = await reader
                                .ReadAsync(cancellationToken)
                                .ConfigureAwait(false);

                            await _requestPayloads
                                .SendAsync(requestPayload, cancellationToken)
                                .ConfigureAwait(false);
                            // todo: alternate write
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

            _readAndWriteBackgroundTask.Wait(TimeSpan.FromSeconds(3));
            _sendAndReceiveBackgroundTask.Wait(TimeSpan.FromSeconds(3));
        }
    }
}