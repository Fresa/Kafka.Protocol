using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using FluentAssertions;
using Kafka.Protocol;
using Kafka.Protocol.Records;
using Log.It;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;
using Int16 = Kafka.Protocol.Int16;
using Int32 = Kafka.Protocol.Int32;
using Int64 = Kafka.Protocol.Int64;
using Record = Kafka.Protocol.Records.Record;
using String = Kafka.Protocol.String;

namespace Kafka.TestServer.Tests
{
    public partial class Given_a_socket_based_test_server
    {
        public class When_connecting_to_the_server_and_producing_a_message : TestSpecificationAsync
        {
            private SocketBasedKafkaTestFramework _testServer;
            private List<Record> _records;

            private async Task SetProduceRequest(ProduceRequest request,
                CancellationToken cancellationToken)
            {
                var records = new List<Record>();
                await foreach (var batch in request
                    .ExtractRecordBatchesAsync(cancellationToken)
                    .ConfigureAwait(false))
                {
                    if (batch.Records == null)
                        continue;

                    records.AddRange(batch.Records);
                }

                _records = records;
            }

            public When_connecting_to_the_server_and_producing_a_message(
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

                 _testServer.On<ProduceRequest, ProduceResponse>(async request => (await request
                    .WithActionAsync(produceRequest =>  SetProduceRequest(produceRequest, CancellationToken.None))
                    .ConfigureAwait(false))
                    .Respond()
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
            public void It_should_have_read_one_record()
            {
                _records.Should().HaveCount(1);
            }

            [Fact]
            public void It_should_have_read_the_message_sent()
            {
                _records.First().Value.EncodeToString(Encoding.UTF8).Should().Be("test");
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

    internal static class ProduceRequestExtensions
    {
        internal static async IAsyncEnumerable<RecordBatch> ExtractRecordBatchesAsync(
            this ProduceRequest produceRequest,
            CancellationToken cancellationToken = default)
        {
            var records = produceRequest.TopicsCollection.SelectMany(data =>
                data.PartitionsCollection.Select(produceData =>
                    produceData.Records))
                .Where(record => record.HasValue);

            var pipe = new Pipe();
            var reader = new KafkaReader(pipe.Reader);
            foreach (var record in records)
            {
                await pipe.Writer.WriteAsync(
                    record.Value.Value.AsMemory(),
                    cancellationToken);

                yield return await RecordBatch.ReadFromAsync(Int16.Default, reader,
                    cancellationToken);
            }
        }
    }
}