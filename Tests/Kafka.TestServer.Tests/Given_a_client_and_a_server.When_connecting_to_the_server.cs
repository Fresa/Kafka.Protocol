using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Kafka.Protocol;
using Xunit;
using Xunit.Abstractions;
using Int32 = Kafka.Protocol.Int32;

namespace Kafka.TestServer.Tests
{
    public partial class Given_a_client_and_a_server
    {
        public class When_connecting_to_the_server : TestSpecificationAsync
        {
            private SocketBasedKafkaTestFramework _testServer;

            public When_connecting_to_the_server(
                ITestOutputHelper testOutputHelper)
                : base(testOutputHelper)
            {
            }

            protected override Task GivenAsync()
            {
                _testServer = KafkaTestFramework.WithSocket();

                _testServer.On<ApiVersionsRequest, ApiVersionsResponse>(
                    request => request.Respond()
                        .WithThrottleTimeMs(Int32.From(100))
                        .WithAllApiKeys());

                _testServer.On<MetadataRequest, MetadataResponse>(
                    request => request.Respond().WithTopicsCollection(
                        request.TopicsCollection.Select(
                                topic =>
                                    new Func<
                                        MetadataResponse.MetadataResponseTopic,
                                        MetadataResponse.MetadataResponseTopic>(
                                        responseTopic =>
                                            responseTopic.WithName(
                                                topic.Name)))
                            .ToArray()));

                return Task.CompletedTask;
            }

            protected override async Task WhenAsync()
            {
                await using (_testServer.Start()
                    .ConfigureAwait(false))
                {
                    ProduceMessageFromClientAsync("localhost",
                        _testServer.Port);
                    Thread.Sleep(5000);
                }
            }

            [Fact]
            public void It_should_connect()
            {
            }

            private static async Task ProduceMessageFromClientAsync(string host,
                int port)
            {
                var producerConfig = new ProducerConfig(new Dictionary<string, string>
                {
                    { "log_level", "7"}
                })
                {
                    BootstrapServers = $"{host}:{port}",
                    ApiVersionRequestTimeoutMs = 10000,
                    MessageTimeoutMs = 45000,
                    MetadataRequestTimeoutMs = 25000,
                    RequestTimeoutMs = 5000,
                    SocketTimeoutMs = 30000,
                    Debug = "broker,topic,msg",
                    LogConnectionClose = true
                };

                using var producer =
                    new ProducerBuilder<Null, string>(producerConfig)
                        .SetLogHandler(LogExtensions.UseLogIt)
                        .Build();
                await producer
                    .ProduceAsync("my-topic",
                        new Message<Null, string> {Value = "test"})
                    .ConfigureAwait(false);
                producer.Flush();
            }
        }
    }
}