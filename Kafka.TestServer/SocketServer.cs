using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Kafka.TestServer
{
    internal class SocketServer : IAsyncDisposable
    {
        private readonly ConcurrentQueue<Socket> _clients = new ConcurrentQueue<Socket>();
        private readonly BufferBlock<Socket> _waitingClients = new BufferBlock<Socket>();
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        private Task _acceptingClientsBackgroundTask = default!;
        private Socket _clientAcceptingSocket = default!;

        internal int Port { get; private set; }

        internal async Task<Socket> WaitForConnectedClientAsync(CancellationToken cancellationToken)
        {
            var client = await _waitingClients.ReceiveAsync(cancellationToken);
            _clients.Enqueue(client);
            return client;
        }

        internal static SocketServer Start(string hostname)
        {
            var server = new SocketServer();
            server.Connect(hostname);
            server.StartAcceptingClients();
            return server;
        }

        private void StartAcceptingClients()
        {
            _acceptingClientsBackgroundTask = Task.Run(async () =>
                {
                    while (_cancellationSource.IsCancellationRequested == false)
                    {
                        try
                        {
                            var clientSocket = await _clientAcceptingSocket.AcceptAsync()
                                .ConfigureAwait(false);
                            await _waitingClients.SendAsync(clientSocket, _cancellationSource.Token)
                                .ConfigureAwait(false);
                        }
                        catch when (_cancellationSource.IsCancellationRequested)
                        {
                            // Shutdown in progress
                            return;
                        }
                    }
                });
        }

        private void Connect(string hostname)
        {
            var host = Dns.GetHostEntry(hostname);
            var address = host.AddressList[0];
            var endPoint = new IPEndPoint(address, 0);
            Port = endPoint.Port;

            _clientAcceptingSocket = new Socket(
                address.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            _clientAcceptingSocket.Bind(endPoint);
            Port = ((IPEndPoint)_clientAcceptingSocket.LocalEndPoint).Port;
            _clientAcceptingSocket.Listen(100);
        }

        public async ValueTask DisposeAsync()
        {
            _cancellationSource.Cancel();
            try
            {
                _clientAcceptingSocket.Shutdown(SocketShutdown.Both);
            }
            catch 
            {
                // Try shutting down
            }

            await _acceptingClientsBackgroundTask;
            while (_clients.TryDequeue(out var client))
            {
                try
                {
                    client.Shutdown(SocketShutdown.Both);
                }
                catch
                {
                    // Try shutting down
                }

                client.Close();
                client.Dispose();
            }
        }
    }
}