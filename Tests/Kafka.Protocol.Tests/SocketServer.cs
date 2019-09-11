using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tests
{
    internal class SocketServer : IDisposable
    {
        private readonly List<Socket> _clients = new List<Socket>();
        private readonly SemaphoreSlim _clientAvailableSemaphore = new SemaphoreSlim(0);
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        private Task _acceptingClientsBackgroundTask;
        private static Socket _socket;

        internal int Port { get; private set; }

        internal async Task<Socket> WaitForConnectedClientAsync(CancellationToken cancellationToken)
        {
            await _clientAvailableSemaphore.WaitAsync(cancellationToken);
            return _clients.Last();
        }

        internal static SocketServer Start(string hostname)
        {
            var server = new SocketServer();
            _socket = server.Connect(hostname);
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
                            var clientSocket = await _socket.AcceptAsync()
                                .ConfigureAwait(false);
                            _clients.Add(clientSocket);
                            _clientAvailableSemaphore.Release();
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
            _socket.Shutdown(SocketShutdown.Both);
            _acceptingClientsBackgroundTask.Wait(TimeSpan.FromSeconds(10));
            foreach (var client in _clients)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client.Dispose();
            }

            _clientAvailableSemaphore.Dispose();
        }
    }
}