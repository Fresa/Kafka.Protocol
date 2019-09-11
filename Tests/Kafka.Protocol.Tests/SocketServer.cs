using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Kafka.Protocol.Tests
{
    internal class SocketServer : IDisposable
    {
        private readonly ConcurrentQueue<Socket> _clients = new ConcurrentQueue<Socket>();
        private readonly BufferBlock<Socket> _waitingClients = new BufferBlock<Socket>();
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        private Task _acceptingClientsBackgroundTask;
        private static Socket _clientAcceptingSocket;

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
            _clientAcceptingSocket = server.Connect(hostname);
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
                        catch (Exception) when (_cancellationSource.IsCancellationRequested)
                        {
                            // Shutdown in progress
                            return;
                        }
                    }
                });
        }

        private Socket Connect(string hostname)
        {
            var host = Dns.GetHostEntry(hostname);
            var address = host.AddressList[0];
            var endPoint = new IPEndPoint(address, 0);
            Port = endPoint.Port;

            var listener = new Socket(
                address.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            listener.Bind(endPoint);
            Port = ((IPEndPoint)listener.LocalEndPoint).Port;
            listener.Listen(100);

            return listener;
        }

        public void Dispose()
        {
            _cancellationSource.Cancel();
            _clientAcceptingSocket.Shutdown(SocketShutdown.Both);
            _acceptingClientsBackgroundTask.Wait(TimeSpan.FromSeconds(10));
            while (_clients.TryDequeue(out var client))
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client.Dispose();
            }
        }
    }
}