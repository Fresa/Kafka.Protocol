#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public static partial class Messages
    {
        public static Int16 GetRequestHeaderVersionFor(Int16 apiKey, Int16 version)
        {
            if (AddOffsetsToTxnRequest.ApiKey == apiKey)
                return new AddOffsetsToTxnRequest(version).HeaderVersion;
            if (AddPartitionsToTxnRequest.ApiKey == apiKey)
                return new AddPartitionsToTxnRequest(version).HeaderVersion;
            if (AddRaftVoterRequest.ApiKey == apiKey)
                return new AddRaftVoterRequest(version).HeaderVersion;
            if (AllocateProducerIdsRequest.ApiKey == apiKey)
                return new AllocateProducerIdsRequest(version).HeaderVersion;
            if (AlterClientQuotasRequest.ApiKey == apiKey)
                return new AlterClientQuotasRequest(version).HeaderVersion;
            if (AlterConfigsRequest.ApiKey == apiKey)
                return new AlterConfigsRequest(version).HeaderVersion;
            if (AlterPartitionReassignmentsRequest.ApiKey == apiKey)
                return new AlterPartitionReassignmentsRequest(version).HeaderVersion;
            if (AlterPartitionRequest.ApiKey == apiKey)
                return new AlterPartitionRequest(version).HeaderVersion;
            if (AlterReplicaLogDirsRequest.ApiKey == apiKey)
                return new AlterReplicaLogDirsRequest(version).HeaderVersion;
            if (AlterUserScramCredentialsRequest.ApiKey == apiKey)
                return new AlterUserScramCredentialsRequest(version).HeaderVersion;
            if (ApiVersionsRequest.ApiKey == apiKey)
                return new ApiVersionsRequest(version).HeaderVersion;
            if (AssignReplicasToDirsRequest.ApiKey == apiKey)
                return new AssignReplicasToDirsRequest(version).HeaderVersion;
            if (BeginQuorumEpochRequest.ApiKey == apiKey)
                return new BeginQuorumEpochRequest(version).HeaderVersion;
            if (BrokerHeartbeatRequest.ApiKey == apiKey)
                return new BrokerHeartbeatRequest(version).HeaderVersion;
            if (BrokerRegistrationRequest.ApiKey == apiKey)
                return new BrokerRegistrationRequest(version).HeaderVersion;
            if (ConsumerGroupDescribeRequest.ApiKey == apiKey)
                return new ConsumerGroupDescribeRequest(version).HeaderVersion;
            if (ConsumerGroupHeartbeatRequest.ApiKey == apiKey)
                return new ConsumerGroupHeartbeatRequest(version).HeaderVersion;
            if (ControlledShutdownRequest.ApiKey == apiKey)
                return new ControlledShutdownRequest(version).HeaderVersion;
            if (ControllerRegistrationRequest.ApiKey == apiKey)
                return new ControllerRegistrationRequest(version).HeaderVersion;
            if (CreateAclsRequest.ApiKey == apiKey)
                return new CreateAclsRequest(version).HeaderVersion;
            if (CreateDelegationTokenRequest.ApiKey == apiKey)
                return new CreateDelegationTokenRequest(version).HeaderVersion;
            if (CreatePartitionsRequest.ApiKey == apiKey)
                return new CreatePartitionsRequest(version).HeaderVersion;
            if (CreateTopicsRequest.ApiKey == apiKey)
                return new CreateTopicsRequest(version).HeaderVersion;
            if (DeleteAclsRequest.ApiKey == apiKey)
                return new DeleteAclsRequest(version).HeaderVersion;
            if (DeleteGroupsRequest.ApiKey == apiKey)
                return new DeleteGroupsRequest(version).HeaderVersion;
            if (DeleteRecordsRequest.ApiKey == apiKey)
                return new DeleteRecordsRequest(version).HeaderVersion;
            if (DeleteShareGroupStateRequest.ApiKey == apiKey)
                return new DeleteShareGroupStateRequest(version).HeaderVersion;
            if (DeleteTopicsRequest.ApiKey == apiKey)
                return new DeleteTopicsRequest(version).HeaderVersion;
            if (DescribeAclsRequest.ApiKey == apiKey)
                return new DescribeAclsRequest(version).HeaderVersion;
            if (DescribeClientQuotasRequest.ApiKey == apiKey)
                return new DescribeClientQuotasRequest(version).HeaderVersion;
            if (DescribeClusterRequest.ApiKey == apiKey)
                return new DescribeClusterRequest(version).HeaderVersion;
            if (DescribeConfigsRequest.ApiKey == apiKey)
                return new DescribeConfigsRequest(version).HeaderVersion;
            if (DescribeDelegationTokenRequest.ApiKey == apiKey)
                return new DescribeDelegationTokenRequest(version).HeaderVersion;
            if (DescribeGroupsRequest.ApiKey == apiKey)
                return new DescribeGroupsRequest(version).HeaderVersion;
            if (DescribeLogDirsRequest.ApiKey == apiKey)
                return new DescribeLogDirsRequest(version).HeaderVersion;
            if (DescribeProducersRequest.ApiKey == apiKey)
                return new DescribeProducersRequest(version).HeaderVersion;
            if (DescribeQuorumRequest.ApiKey == apiKey)
                return new DescribeQuorumRequest(version).HeaderVersion;
            if (DescribeTopicPartitionsRequest.ApiKey == apiKey)
                return new DescribeTopicPartitionsRequest(version).HeaderVersion;
            if (DescribeTransactionsRequest.ApiKey == apiKey)
                return new DescribeTransactionsRequest(version).HeaderVersion;
            if (DescribeUserScramCredentialsRequest.ApiKey == apiKey)
                return new DescribeUserScramCredentialsRequest(version).HeaderVersion;
            if (ElectLeadersRequest.ApiKey == apiKey)
                return new ElectLeadersRequest(version).HeaderVersion;
            if (EndQuorumEpochRequest.ApiKey == apiKey)
                return new EndQuorumEpochRequest(version).HeaderVersion;
            if (EndTxnRequest.ApiKey == apiKey)
                return new EndTxnRequest(version).HeaderVersion;
            if (EnvelopeRequest.ApiKey == apiKey)
                return new EnvelopeRequest(version).HeaderVersion;
            if (ExpireDelegationTokenRequest.ApiKey == apiKey)
                return new ExpireDelegationTokenRequest(version).HeaderVersion;
            if (FetchRequest.ApiKey == apiKey)
                return new FetchRequest(version).HeaderVersion;
            if (FetchSnapshotRequest.ApiKey == apiKey)
                return new FetchSnapshotRequest(version).HeaderVersion;
            if (FindCoordinatorRequest.ApiKey == apiKey)
                return new FindCoordinatorRequest(version).HeaderVersion;
            if (GetTelemetrySubscriptionsRequest.ApiKey == apiKey)
                return new GetTelemetrySubscriptionsRequest(version).HeaderVersion;
            if (HeartbeatRequest.ApiKey == apiKey)
                return new HeartbeatRequest(version).HeaderVersion;
            if (IncrementalAlterConfigsRequest.ApiKey == apiKey)
                return new IncrementalAlterConfigsRequest(version).HeaderVersion;
            if (InitializeShareGroupStateRequest.ApiKey == apiKey)
                return new InitializeShareGroupStateRequest(version).HeaderVersion;
            if (InitProducerIdRequest.ApiKey == apiKey)
                return new InitProducerIdRequest(version).HeaderVersion;
            if (JoinGroupRequest.ApiKey == apiKey)
                return new JoinGroupRequest(version).HeaderVersion;
            if (LeaderAndIsrRequest.ApiKey == apiKey)
                return new LeaderAndIsrRequest(version).HeaderVersion;
            if (LeaveGroupRequest.ApiKey == apiKey)
                return new LeaveGroupRequest(version).HeaderVersion;
            if (ListClientMetricsResourcesRequest.ApiKey == apiKey)
                return new ListClientMetricsResourcesRequest(version).HeaderVersion;
            if (ListGroupsRequest.ApiKey == apiKey)
                return new ListGroupsRequest(version).HeaderVersion;
            if (ListOffsetsRequest.ApiKey == apiKey)
                return new ListOffsetsRequest(version).HeaderVersion;
            if (ListPartitionReassignmentsRequest.ApiKey == apiKey)
                return new ListPartitionReassignmentsRequest(version).HeaderVersion;
            if (ListTransactionsRequest.ApiKey == apiKey)
                return new ListTransactionsRequest(version).HeaderVersion;
            if (MetadataRequest.ApiKey == apiKey)
                return new MetadataRequest(version).HeaderVersion;
            if (OffsetCommitRequest.ApiKey == apiKey)
                return new OffsetCommitRequest(version).HeaderVersion;
            if (OffsetDeleteRequest.ApiKey == apiKey)
                return new OffsetDeleteRequest(version).HeaderVersion;
            if (OffsetFetchRequest.ApiKey == apiKey)
                return new OffsetFetchRequest(version).HeaderVersion;
            if (OffsetForLeaderEpochRequest.ApiKey == apiKey)
                return new OffsetForLeaderEpochRequest(version).HeaderVersion;
            if (ProduceRequest.ApiKey == apiKey)
                return new ProduceRequest(version).HeaderVersion;
            if (PushTelemetryRequest.ApiKey == apiKey)
                return new PushTelemetryRequest(version).HeaderVersion;
            if (ReadShareGroupStateRequest.ApiKey == apiKey)
                return new ReadShareGroupStateRequest(version).HeaderVersion;
            if (ReadShareGroupStateSummaryRequest.ApiKey == apiKey)
                return new ReadShareGroupStateSummaryRequest(version).HeaderVersion;
            if (RemoveRaftVoterRequest.ApiKey == apiKey)
                return new RemoveRaftVoterRequest(version).HeaderVersion;
            if (RenewDelegationTokenRequest.ApiKey == apiKey)
                return new RenewDelegationTokenRequest(version).HeaderVersion;
            if (SaslAuthenticateRequest.ApiKey == apiKey)
                return new SaslAuthenticateRequest(version).HeaderVersion;
            if (SaslHandshakeRequest.ApiKey == apiKey)
                return new SaslHandshakeRequest(version).HeaderVersion;
            if (ShareAcknowledgeRequest.ApiKey == apiKey)
                return new ShareAcknowledgeRequest(version).HeaderVersion;
            if (ShareFetchRequest.ApiKey == apiKey)
                return new ShareFetchRequest(version).HeaderVersion;
            if (ShareGroupDescribeRequest.ApiKey == apiKey)
                return new ShareGroupDescribeRequest(version).HeaderVersion;
            if (ShareGroupHeartbeatRequest.ApiKey == apiKey)
                return new ShareGroupHeartbeatRequest(version).HeaderVersion;
            if (StopReplicaRequest.ApiKey == apiKey)
                return new StopReplicaRequest(version).HeaderVersion;
            if (SyncGroupRequest.ApiKey == apiKey)
                return new SyncGroupRequest(version).HeaderVersion;
            if (TxnOffsetCommitRequest.ApiKey == apiKey)
                return new TxnOffsetCommitRequest(version).HeaderVersion;
            if (UnregisterBrokerRequest.ApiKey == apiKey)
                return new UnregisterBrokerRequest(version).HeaderVersion;
            if (UpdateFeaturesRequest.ApiKey == apiKey)
                return new UpdateFeaturesRequest(version).HeaderVersion;
            if (UpdateMetadataRequest.ApiKey == apiKey)
                return new UpdateMetadataRequest(version).HeaderVersion;
            if (UpdateRaftVoterRequest.ApiKey == apiKey)
                return new UpdateRaftVoterRequest(version).HeaderVersion;
            if (VoteRequest.ApiKey == apiKey)
                return new VoteRequest(version).HeaderVersion;
            if (WriteShareGroupStateRequest.ApiKey == apiKey)
                return new WriteShareGroupStateRequest(version).HeaderVersion;
            if (WriteTxnMarkersRequest.ApiKey == apiKey)
                return new WriteTxnMarkersRequest(version).HeaderVersion;
            throw new ArgumentException($"There is no request message with api key {apiKey}");
        }
    }
}
