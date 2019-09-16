using System;
using System.Collections.Concurrent;
using System.IO.Pipelines;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
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

        private readonly BlockingCollection<RequestPayload> _requestPayloads = new BlockingCollection<RequestPayload>();
        private readonly SemaphoreSlim _requestPayloadAvailableSemaphore = new SemaphoreSlim(0);

        private readonly BlockingCollection<ResponsePayload> _responsePayloads = new BlockingCollection<ResponsePayload>();
        private readonly SemaphoreSlim _responsePayloadAvailableSemaphore = new SemaphoreSlim(0);

        private readonly Pipe _pipe = new Pipe();
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        private Task _readAndWriteBackgroundTask;
        private Task _sendAndReceiveBackgroundTask;

        internal async Task<RequestPayload> ReadAsync(CancellationToken cancellationToken)
        {
            await _requestPayloadAvailableSemaphore.WaitAsync(cancellationToken);
            return _requestPayloads.Take(cancellationToken);
        }

        internal void Send(ResponsePayload payload)
        {
            _responsePayloads.Add(payload);
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
                            await dataReceiver.ReceiveAsync(_pipe.Writer, cancellationToken).ConfigureAwait(false);
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
                            _requestPayloads.Add(requestPayload, cancellationToken);
                            _requestPayloadAvailableSemaphore.Release();
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
            _requestPayloads.Dispose();
            _requestPayloadAvailableSemaphore.Dispose();

            _sendAndReceiveBackgroundTask.Wait(TimeSpan.FromSeconds(3));
            _responsePayloads.Dispose();
            _responsePayloadAvailableSemaphore.Dispose();
        }
    }
}