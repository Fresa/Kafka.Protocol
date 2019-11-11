using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Kafka.TestServer
{
    internal class SocketServer : INetworkServer, IAsyncDisposable
    {
        private readonly ConcurrentQueue<INetworkClient> _clients = new ConcurrentQueue<INetworkClient>();
        private readonly BufferBlock<INetworkClient> _waitingClients = new BufferBlock<INetworkClient>();
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        private Task _acceptingClientsBackgroundTask = default!;
        private Socket _clientAcceptingSocket = default!;

        internal int Port { get; private set; }

        public async Task<INetworkClient> WaitForConnectedClientAsync(CancellationToken cancellationToken = default)
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
                            await _waitingClients.SendAsync(
                                    new SocketNetworkClient(clientSocket), 
                                    _cancellationSource.Token)
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
                _clientAcceptingSocket.Close();
            }
            finally
            {
                _clientAcceptingSocket.Dispose();
            }

            await _acceptingClientsBackgroundTask;
            while (_clients.TryDequeue(out var client))
            {
                await client.DisposeAsync();
            }
        }
    }

    internal interface INetworkServer
    {
        Task<INetworkClient> WaitForConnectedClientAsync
            (CancellationToken cancellationToken = default);
    }
}