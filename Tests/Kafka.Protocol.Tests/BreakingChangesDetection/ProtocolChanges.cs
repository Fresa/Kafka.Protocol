using System;
using System.Linq;

namespace Kafka.Protocol.Tests.BreakingChangesDetection
{
    public partial class ProtocolChanges
    {
        public void MetadataRequest()
        {
            new MetadataRequest(1).Respond()
                        .WithTopicsCollection(
                            new MetadataRequest(1).TopicsCollection?.Select(topic =>
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
                                .ToArray() ?? new Func<MetadataResponse.MetadataResponseTopic, MetadataResponse.MetadataResponseTopic>[0])
                        .WithControllerId(Int32.From(0))
                        .WithClusterId(String.From("test"))
                        .WithBrokersCollection(broker => broker
                            .WithRack("testrack")
                            .WithNodeId(Int32.From(0))
                            .WithHost(String.From("localhost"))
                            .WithPort(Int32.From(1000))
                        );
        }

        public void ProduceRequest()
        {
            new ProduceRequest(1)
               .Respond()
               .WithResponsesCollection(new ProduceRequest(1).TopicDataCollection.Select(topicProduceData =>
                   new Func<ProduceResponse.TopicProduceResponse,
                       ProduceResponse.TopicProduceResponse>(
                       topicProduceResponse =>
                           topicProduceResponse
                               .WithName("test")
                               .WithPartitionResponsesCollection(topicProduceData.Value.PartitionDataCollection.Select(partitionProduceData =>
                                   new Func<ProduceResponse.TopicProduceResponse.PartitionProduceResponse,
                                       ProduceResponse.TopicProduceResponse.PartitionProduceResponse>(
                                       partitionProduceResponse =>
                                           partitionProduceResponse
                                               .WithIndex(partitionProduceData.Index)
                                               .WithLogAppendTimeMs(Int64.From(-1))))
                                   .ToArray())))
                   .ToArray());
        }
    }
}