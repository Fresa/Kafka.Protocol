using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Kafka.Protocol;
using Log.It;
using Xunit;
using Xunit.Abstractions;
using Int32 = Kafka.Protocol.Int32;
using Int64 = Kafka.Protocol.Int64;
using String = Kafka.Protocol.String;

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
                        .WithAllApiKeys());

                _testServer.On<MetadataRequest, MetadataResponse>(
                    request => request.Respond()
                        .WithTopicsCollection(
                            request.TopicsCollection?.Select(topic =>
                                new Func<MetadataResponse.MetadataResponseTopic,
                                    MetadataResponse.MetadataResponseTopic>(
                                    responseTopic =>
                                        responseTopic
                                            .WithName(topic.Name)
                                            .WithPartitionsCollection(partition =>
                                                partition
                                                    .WithLeaderId(Int32.From(0))
                                                    .WithPartitionIndex(Int32.From(0))
                                                    .WithReplicaNodesCollection(new[] { Int32.From(0) }))))
                                .ToArray())
                        .WithControllerId(Int32.From(0))
                        .WithClusterId(String.From("test"))
                        .WithBrokersCollection(broker => broker
                            .WithRack(String.From("testrack"))
                            .WithNodeId(Int32.From(0))
                            .WithHost(String.From("localhost"))
                            .WithPort(Int32.From(_testServer.Port)))
                        );

                _testServer.On<ProduceRequest, ProduceResponse>(request => request.Respond()
                    .WithResponsesCollection(request.TopicsCollection.Select(topicProduceData =>
                        new Func<ProduceResponse.TopicProduceResponse,
                            ProduceResponse.TopicProduceResponse>(
                            topicProduceResponse =>
                                topicProduceResponse
                                    .WithName(topicProduceData.Name)
                                    .WithPartitionsCollection(topicProduceData.PartitionsCollection.Select(partitionProduceData =>
                                        new Func<ProduceResponse.TopicProduceResponse.PartitionProduceResponse,
                                            ProduceResponse.TopicProduceResponse.PartitionProduceResponse>(
                                            partitionProduceResponse =>
                                                partitionProduceResponse
                                                    .WithPartitionIndex(partitionProduceData.PartitionIndex)
                                                    .WithLogAppendTimeMs(Int64.From(-1))))
                                        .ToArray())))
                        .ToArray()));

                return Task.CompletedTask;
            }

            protected override async Task WhenAsync()
            {
                await using (_testServer.Start()
                    .ConfigureAwait(false))
                {
                    await ProduceMessageFromClientAsync("localhost", _testServer.Port)
                        .ConfigureAwait(false);
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
                    MessageTimeoutMs = 5000,
                    MetadataRequestTimeoutMs = 5000,
                    SocketTimeoutMs = 30000,
                    Debug = "all"
                };

                using var producer =
                    new ProducerBuilder<Null, string>(producerConfig)
                        .SetLogHandler(LogExtensions.UseLogIt)
                        .Build();

                var report = await producer
                    .ProduceAsync("my-topic",
                        new Message<Null, string> { Value = "test" })
                    .ConfigureAwait(false);
                LogFactory.Create("producer").Info("Produce report {@report}", report);

                producer.Flush();
            }
        }
    }
}