using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Net;
using System.Net.Sockets;
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
            var pipe = new Pipe();
            var socketListener = new SocketListener();
            var host = Dns.GetHostName();
            var server = socketListener.Connect(host, out var port);

            var clientAcceptedSocket = server.AcceptAsync();

            var clientTask = RunClient(host, port);
            var clientSocket = await clientAcceptedSocket;

            using (var receiver = new DataReceiver(clientSocket))
            {
                var receivingTask = receiver.ReceiveAsync(pipe.Writer, CancellationToken.None);
                await Task.WhenAll(clientTask, receivingTask);
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

    internal class DataReceiver : IDisposable
    {
        private readonly Socket _socket;
        private const int MinimumBufferSize = 512;

        internal DataReceiver(Socket socket)
        {
            _socket = socket;
        }

        internal async Task ReceiveAsync(PipeWriter writer, CancellationToken cancellationToken)
        {
            FlushResult? result = null;
            var retry = 100;
            do
            {
                var memory = writer.GetMemory(MinimumBufferSize);
                var bytesRead = await _socket.ReceiveAsync(memory, SocketFlags.None, cancellationToken);
                if (bytesRead == 0)
                {
                    if (retry == 0)
                    {
                        break;
                    }

                    await Task.Delay(10, cancellationToken);
                    retry--;
                    continue;
                }

                Debug.WriteLine($"Wrote {bytesRead} bytes");
                writer.Advance(bytesRead);

                result = await writer.FlushAsync(cancellationToken);
            } while (result == null ||
                     (result.Value.IsCanceled == false &&
                     result.Value.IsCompleted == false));

            writer.Complete();
        }

        public void Dispose()
        {
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
            _socket.Dispose();
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

            while (result.Buffer.Length < size &&
                   result.IsCanceled == false &&
                   result.IsCompleted == false)
            {
                result = await _reader.ReadAsync(cancellationToken);
            }

            if (result.Buffer.Length != size)
            {
                throw new InvalidOperationException($"Expected {size} bytes, got {result.Buffer.Length}");
            }

            return RequestPayload.ReadFrom(0, result.Buffer.ToArray());
        }
    }
}