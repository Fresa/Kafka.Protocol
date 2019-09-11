using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Xunit;
using Xunit.Abstractions;

namespace Kafka.Protocol.Tests
{
    public partial class Given_a_client_and_a_server
    {
        public class When_connecting_to_the_server
        {
            private readonly ITestOutputHelper _testOutputHelper;

            public When_connecting_to_the_server(ITestOutputHelper testOutputHelper)
            {
                _testOutputHelper = testOutputHelper;
            }

            [Fact]
            public async Task It_should_connect()
            {
                var hostName = Dns.GetHostName();

                using (var server = SocketServer.Start(hostName))
                {
                    var clientAcceptedSocket = server.WaitConnectedClientAsync(CancellationToken.None);

                    var clientTask = ProduceMessageFromClientAsync(hostName, server.Port);
                    var connectedClientSocket = await clientAcceptedSocket;

                    using (var client = Client.Start(connectedClientSocket))
                    {
                        var message = await client.ReadAsync(CancellationToken.None);
                        await clientTask;
                    }
                }
            }

            private static async Task ProduceMessageFromClientAsync(string host, int port)
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
                    await producer.ProduceAsync("my-topic", new Message<Null, string> {Value = "test"});
                    producer.Flush();
                }
            }

            private async Task RunClient2(string host, int port)
            {
                var ipHostInfo = Dns.GetHostEntry(host);
                var ipAddress = ipHostInfo.AddressList[0];
                var remoteEP = new IPEndPoint(ipAddress, port);

                var client = new Socket(
                    ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                await client.ConnectAsync(remoteEP);

                client.Send(Encoding.ASCII.GetBytes("This is a test"));

                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }
    }
}