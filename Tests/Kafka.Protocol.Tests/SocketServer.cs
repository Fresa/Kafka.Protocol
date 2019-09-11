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
        private readonly SemaphoreSlim _acceptBackgroundTaskCancelled = new SemaphoreSlim(0);

        internal int Port { get; private set; } = AssignPort();

        internal async Task<Socket> WaitConnectedClientAsync(CancellationToken cancellationToken)
        {
            await _clientAvailableSemaphore.WaitAsync(cancellationToken);
            return _clients.Last();
        }

        internal static SocketServer Start(string hostname)
        {
            var server = new SocketServer();
            var socket = server.Connect(hostname);
            server.StartAcceptingClients(socket, server._cancellationSource.Token);
            return server;
        }

        private void StartAcceptingClients(Socket socket, CancellationToken cancellationToken)
        {
            Task.Factory.StartNew(
                async () =>
                {
                    try
                    {
                        while (cancellationToken.IsCancellationRequested == false)
                        {
                            var clientSocket = await socket.AcceptAsync().ConfigureAwait(false);
                            _clients.Add(clientSocket);
                            _clientAvailableSemaphore.Release();
                        }
                    }
                    finally
                    {
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                        socket.Dispose();

                        _acceptBackgroundTaskCancelled.Release();
                    }
                },
                cancellationToken,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
        }

        private Socket Connect(string hostname)
        {
            var host = Dns.GetHostEntry(hostname);
            var address = host.AddressList[0];
            var endPoint = new IPEndPoint(address, Port);
            Port = endPoint.Port;

            var listener = new Socket(
                address.AddressFamily,
                SocketType.Stream, 
                ProtocolType.Tcp);

            listener.Bind(endPoint);
            Port = ((IPEndPoint) listener.LocalEndPoint).Port;
            listener.Listen(100);

            return listener;
        }

        private static int AssignPort()
        {
            return 0;
            const int min = 11000;
            const int max = 12000;
            var random = new Random();
            return random.Next(min, max);
        }

        public void Dispose()
        {
            _cancellationSource.Cancel();
            _acceptBackgroundTaskCancelled.Wait(TimeSpan.FromSeconds(10));
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