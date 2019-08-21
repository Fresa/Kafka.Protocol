using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Xunit;
using Xunit.Abstractions;

namespace Kafka.Protocol.Tests
{
    public class Test
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Test(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task Testar()
        {
            var hostName = Dns.GetHostName();

            using (var server = SocketServer.Start(hostName))
            {
                var clientAcceptedSocket = server.WaitConnectedClientAsync(CancellationToken.None);

                var clientTask = RunClient(hostName, server.Port);
                var connectedClientSocket = await clientAcceptedSocket;

                using (var client = Client.Start(connectedClientSocket))
                {
                    var message = await client.ReadAsync(CancellationToken.None);
                    await clientTask;
                }
            }
        }

        private static async Task RunClient(string host, int port)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = $"{host}:{port}",
                ApiVersionRequestTimeoutMs = 10000,
                MessageTimeoutMs = 45000,
                MetadataRequestTimeoutMs = 25000,
                RequestTimeoutMs = 5000,
                SocketTimeoutMs = 30000
            };

            using (var producer = new ProducerBuilder<Null, string>(producerConfig)
                .SetLogHandler((_, message) => Debug.WriteLine(message.Message))
                .Build())
            {
                await producer.ProduceAsync("my-topic", new Message<Null, string> { Value = "test" });
                producer.Flush();
            }
        }

        private async Task RunClient2(string host, int port)
        {
            var ipHostInfo = Dns.GetHostEntry(host);
            var ipAddress = ipHostInfo.AddressList[0];
            var remoteEP = new IPEndPoint(ipAddress, port);

            var client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            await client.ConnectAsync(remoteEP);

            client.Send(Encoding.ASCII.GetBytes("This is a test"));

            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }

    internal class SocketListener
    {
        internal Socket Connect(string hostname, out int port)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var address = host.AddressList[0];
            var endPoint = new IPEndPoint(address, GetPort());
            port = endPoint.Port;

            var listener = new Socket(
                address.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(endPoint);
            listener.Listen(1);

            return listener;
        }

        private static int GetPort()
        {
            const int min = 11000;
            const int max = 12000;
            var random = new Random();
            return random.Next(min, max);
        }
    }

    internal class SocketServer : IDisposable
    {
        private readonly List<Socket> _clients = new List<Socket>();
        private readonly SemaphoreSlim _clientAvailableSemaphore = new SemaphoreSlim(0);
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        private readonly SemaphoreSlim _acceptBackgroundTaskCancelled = new SemaphoreSlim(0);

        internal int Port { get; } = AssignPort();

        internal async Task<Socket> WaitConnectedClientAsync(CancellationToken cancellationToken)
        {
            await _clientAvailableSemaphore.WaitAsync(cancellationToken);
            return _clients.Last();
        }

        internal static SocketServer Start(string hostname)
        {
            var server = new SocketServer();
            var socket = server.Connect(hostname);
            server.StartAcceptingClients(socket, server._cancellationSource.Token)
                .DoNotAwait();
            return server;
        }

        private async Task StartAcceptingClients(Socket socket, CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                var clientSocket = await socket.AcceptAsync();
                _clients.Add(clientSocket);
                _clientAvailableSemaphore.Release();
            }

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket.Dispose();

            _acceptBackgroundTaskCancelled.Release();
        }

        private Socket Connect(string hostname)
        {
            var host = Dns.GetHostEntry(hostname);
            var address = host.AddressList[0];
            var endPoint = new IPEndPoint(address, Port);

            var listener = new Socket(
            address.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(endPoint);
            listener.Listen(100);

            return listener;
        }

        private static int AssignPort()
        {
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


    internal class DataReceiver
    {
        private readonly Socket _socket;
        private const int MinimumBufferSize = 512;

        internal DataReceiver(Socket socket)
        {
            _socket = socket;
        }

        internal async Task ReceiveAsync(PipeWriter writer, CancellationToken cancellationToken)
        {
            try
            {
                FlushResult result;
                do
                {
                    var memory = writer.GetMemory(MinimumBufferSize);
                    var bytesRead = await _socket.ReceiveAsync(memory, SocketFlags.None, cancellationToken);
                    if (bytesRead == 0)
                    {
                        return;
                    }

                    Debug.WriteLine($"Wrote {bytesRead} bytes");
                    writer.Advance(bytesRead);

                    result = await writer.FlushAsync(cancellationToken);
                } while (result.IsCanceled == false &&
                         result.IsCompleted == false);
            }
            catch (Exception ex)
            {
                writer.Complete(ex);
                throw;
            }

            writer.Complete();
        }
    }

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
        private readonly SemaphoreSlim _readWriteCancelled = new SemaphoreSlim(0);
        private readonly SemaphoreSlim _sendReceiveCancelled = new SemaphoreSlim(0);

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
            client.SendReceive()
                .DoNotAwait();
            client.ReadWrite()
                .DoNotAwait();
            return client;
        }

        private async Task SendReceive()
        {
            var cancellationToken = _cancellationSource.Token;
            var dataReceiver = new DataReceiver(_socket);
            while (cancellationToken.IsCancellationRequested == false)
            {
                // todo: alternate send
                await dataReceiver.ReceiveAsync(_pipe.Writer, cancellationToken);
            }

            _sendReceiveCancelled.Release();
        }

        private async Task ReadWrite()
        {
            var cancellationToken = _cancellationSource.Token;
            var reader = new RequestReader(_pipe.Reader);
            while (cancellationToken.IsCancellationRequested == false)
            {
                var requestPayload = await reader.ReadAsync(cancellationToken);
                _requestPayloads.Add(requestPayload, cancellationToken);
                _requestPayloadAvailableSemaphore.Release();
                // todo: alternate write
            }

            _readWriteCancelled.Release();
        }

        public void Dispose()
        {
            _cancellationSource.Cancel();

            _readWriteCancelled.Wait(TimeSpan.FromSeconds(3));
            _requestPayloads.Dispose();
            _requestPayloadAvailableSemaphore.Dispose();

            _sendReceiveCancelled.Wait(TimeSpan.FromSeconds(3));
            _responsePayloads.Dispose();
            _responsePayloadAvailableSemaphore.Dispose();
        }
    }

    internal class RequestReader
    {
        private readonly PipeReader _reader;

        public RequestReader(PipeReader reader)
        {
            _reader = reader;
        }

        internal async Task<RequestPayload> ReadAsync(CancellationToken cancellationToken)
        {
            int? size = null;
            ReadResult result;
            do
            {
                result = await _reader.ReadAsync(cancellationToken);
                if (result.Buffer.Length > 4)
                {
                    var reader = new KafkaReader(result.Buffer.ToArray());
                    size = reader.ReadInt32();
                    _reader.AdvanceTo(result.Buffer.GetPosition(4));
                    break;
                }

            } while (result.IsCanceled == false &&
                     result.IsCompleted == false);

            if (size == null)
            {
                throw new InvalidOperationException("Expected to read a size");
            }

            do
            {
                result = await _reader.ReadAsync(cancellationToken);
            } while (result.Buffer.Length < size &&
                     result.IsCanceled == false &&
                     result.IsCompleted == false);

            if (result.Buffer.Length != size)
            {
                throw new InvalidOperationException($"Expected {size} bytes, got {result.Buffer.Length}");
            }

            return RequestPayload.ReadFrom(0, result.Buffer.ToArray());
        }
    }

    internal static class TaskExtensions
    {
        internal static void DoNotAwait(this Task _) { }
    }
}