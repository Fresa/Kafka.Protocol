// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
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
                return AddOffsetsToTxnRequest(version).HeaderVersion;
            if (AddPartitionsToTxnRequest.ApiKey == apiKey)
                return AddPartitionsToTxnRequest(version).HeaderVersion;
            if (AddRaftVoterRequest.ApiKey == apiKey)
                return AddRaftVoterRequest(version).HeaderVersion;
            if (AllocateProducerIdsRequest.ApiKey == apiKey)
                return AllocateProducerIdsRequest(version).HeaderVersion;
            if (AlterClientQuotasRequest.ApiKey == apiKey)
                return AlterClientQuotasRequest(version).HeaderVersion;
            if (AlterConfigsRequest.ApiKey == apiKey)
                return AlterConfigsRequest(version).HeaderVersion;
            if (AlterPartitionReassignmentsRequest.ApiKey == apiKey)
                return AlterPartitionReassignmentsRequest(version).HeaderVersion;
            if (AlterPartitionRequest.ApiKey == apiKey)
                return AlterPartitionRequest(version).HeaderVersion;
            if (AlterReplicaLogDirsRequest.ApiKey == apiKey)
                return AlterReplicaLogDirsRequest(version).HeaderVersion;
            if (AlterUserScramCredentialsRequest.ApiKey == apiKey)
                return AlterUserScramCredentialsRequest(version).HeaderVersion;
            if (ApiVersionsRequest.ApiKey == apiKey)
                return ApiVersionsRequest(version).HeaderVersion;
            if (AssignReplicasToDirsRequest.ApiKey == apiKey)
                return AssignReplicasToDirsRequest(version).HeaderVersion;
            if (BeginQuorumEpochRequest.ApiKey == apiKey)
                return BeginQuorumEpochRequest(version).HeaderVersion;
            if (BrokerHeartbeatRequest.ApiKey == apiKey)
                return BrokerHeartbeatRequest(version).HeaderVersion;
            if (BrokerRegistrationRequest.ApiKey == apiKey)
                return BrokerRegistrationRequest(version).HeaderVersion;
            if (ConsumerGroupDescribeRequest.ApiKey == apiKey)
                return ConsumerGroupDescribeRequest(version).HeaderVersion;
            if (ConsumerGroupHeartbeatRequest.ApiKey == apiKey)
                return ConsumerGroupHeartbeatRequest(version).HeaderVersion;
            if (ControlledShutdownRequest.ApiKey == apiKey)
                return ControlledShutdownRequest(version).HeaderVersion;
            if (ControllerRegistrationRequest.ApiKey == apiKey)
                return ControllerRegistrationRequest(version).HeaderVersion;
            if (CreateAclsRequest.ApiKey == apiKey)
                return CreateAclsRequest(version).HeaderVersion;
            if (CreateDelegationTokenRequest.ApiKey == apiKey)
                return CreateDelegationTokenRequest(version).HeaderVersion;
            if (CreatePartitionsRequest.ApiKey == apiKey)
                return CreatePartitionsRequest(version).HeaderVersion;
            if (CreateTopicsRequest.ApiKey == apiKey)
                return CreateTopicsRequest(version).HeaderVersion;
            if (DeleteAclsRequest.ApiKey == apiKey)
                return DeleteAclsRequest(version).HeaderVersion;
            if (DeleteGroupsRequest.ApiKey == apiKey)
                return DeleteGroupsRequest(version).HeaderVersion;
            if (DeleteRecordsRequest.ApiKey == apiKey)
                return DeleteRecordsRequest(version).HeaderVersion;
            if (DeleteShareGroupStateRequest.ApiKey == apiKey)
                return DeleteShareGroupStateRequest(version).HeaderVersion;
            if (DeleteTopicsRequest.ApiKey == apiKey)
                return DeleteTopicsRequest(version).HeaderVersion;
            if (DescribeAclsRequest.ApiKey == apiKey)
                return DescribeAclsRequest(version).HeaderVersion;
            if (DescribeClientQuotasRequest.ApiKey == apiKey)
                return DescribeClientQuotasRequest(version).HeaderVersion;
            if (DescribeClusterRequest.ApiKey == apiKey)
                return DescribeClusterRequest(version).HeaderVersion;
            if (DescribeConfigsRequest.ApiKey == apiKey)
                return DescribeConfigsRequest(version).HeaderVersion;
            if (DescribeDelegationTokenRequest.ApiKey == apiKey)
                return DescribeDelegationTokenRequest(version).HeaderVersion;
            if (DescribeGroupsRequest.ApiKey == apiKey)
                return DescribeGroupsRequest(version).HeaderVersion;
            if (DescribeLogDirsRequest.ApiKey == apiKey)
                return DescribeLogDirsRequest(version).HeaderVersion;
            if (DescribeProducersRequest.ApiKey == apiKey)
                return DescribeProducersRequest(version).HeaderVersion;
            if (DescribeQuorumRequest.ApiKey == apiKey)
                return DescribeQuorumRequest(version).HeaderVersion;
            if (DescribeTopicPartitionsRequest.ApiKey == apiKey)
                return DescribeTopicPartitionsRequest(version).HeaderVersion;
            if (DescribeTransactionsRequest.ApiKey == apiKey)
                return DescribeTransactionsRequest(version).HeaderVersion;
            if (DescribeUserScramCredentialsRequest.ApiKey == apiKey)
                return DescribeUserScramCredentialsRequest(version).HeaderVersion;
            if (ElectLeadersRequest.ApiKey == apiKey)
                return ElectLeadersRequest(version).HeaderVersion;
            if (EndQuorumEpochRequest.ApiKey == apiKey)
                return EndQuorumEpochRequest(version).HeaderVersion;
            if (EndTxnRequest.ApiKey == apiKey)
                return EndTxnRequest(version).HeaderVersion;
            if (EnvelopeRequest.ApiKey == apiKey)
                return EnvelopeRequest(version).HeaderVersion;
            if (ExpireDelegationTokenRequest.ApiKey == apiKey)
                return ExpireDelegationTokenRequest(version).HeaderVersion;
            if (FetchRequest.ApiKey == apiKey)
                return FetchRequest(version).HeaderVersion;
            if (FetchSnapshotRequest.ApiKey == apiKey)
                return FetchSnapshotRequest(version).HeaderVersion;
            if (FindCoordinatorRequest.ApiKey == apiKey)
                return FindCoordinatorRequest(version).HeaderVersion;
            if (GetTelemetrySubscriptionsRequest.ApiKey == apiKey)
                return GetTelemetrySubscriptionsRequest(version).HeaderVersion;
            if (HeartbeatRequest.ApiKey == apiKey)
                return HeartbeatRequest(version).HeaderVersion;
            if (IncrementalAlterConfigsRequest.ApiKey == apiKey)
                return IncrementalAlterConfigsRequest(version).HeaderVersion;
            if (InitializeShareGroupStateRequest.ApiKey == apiKey)
                return InitializeShareGroupStateRequest(version).HeaderVersion;
            if (InitProducerIdRequest.ApiKey == apiKey)
                return InitProducerIdRequest(version).HeaderVersion;
            if (JoinGroupRequest.ApiKey == apiKey)
                return JoinGroupRequest(version).HeaderVersion;
            if (LeaderAndIsrRequest.ApiKey == apiKey)
                return LeaderAndIsrRequest(version).HeaderVersion;
            if (LeaveGroupRequest.ApiKey == apiKey)
                return LeaveGroupRequest(version).HeaderVersion;
            if (ListClientMetricsResourcesRequest.ApiKey == apiKey)
                return ListClientMetricsResourcesRequest(version).HeaderVersion;
            if (ListGroupsRequest.ApiKey == apiKey)
                return ListGroupsRequest(version).HeaderVersion;
            if (ListOffsetsRequest.ApiKey == apiKey)
                return ListOffsetsRequest(version).HeaderVersion;
            if (ListPartitionReassignmentsRequest.ApiKey == apiKey)
                return ListPartitionReassignmentsRequest(version).HeaderVersion;
            if (ListTransactionsRequest.ApiKey == apiKey)
                return ListTransactionsRequest(version).HeaderVersion;
            if (MetadataRequest.ApiKey == apiKey)
                return MetadataRequest(version).HeaderVersion;
            if (OffsetCommitRequest.ApiKey == apiKey)
                return OffsetCommitRequest(version).HeaderVersion;
            if (OffsetDeleteRequest.ApiKey == apiKey)
                return OffsetDeleteRequest(version).HeaderVersion;
            if (OffsetFetchRequest.ApiKey == apiKey)
                return OffsetFetchRequest(version).HeaderVersion;
            if (OffsetForLeaderEpochRequest.ApiKey == apiKey)
                return OffsetForLeaderEpochRequest(version).HeaderVersion;
            if (ProduceRequest.ApiKey == apiKey)
                return ProduceRequest(version).HeaderVersion;
            if (PushTelemetryRequest.ApiKey == apiKey)
                return PushTelemetryRequest(version).HeaderVersion;
            if (ReadShareGroupStateRequest.ApiKey == apiKey)
                return ReadShareGroupStateRequest(version).HeaderVersion;
            if (ReadShareGroupStateSummaryRequest.ApiKey == apiKey)
                return ReadShareGroupStateSummaryRequest(version).HeaderVersion;
            if (RemoveRaftVoterRequest.ApiKey == apiKey)
                return RemoveRaftVoterRequest(version).HeaderVersion;
            if (RenewDelegationTokenRequest.ApiKey == apiKey)
                return RenewDelegationTokenRequest(version).HeaderVersion;
            if (SaslAuthenticateRequest.ApiKey == apiKey)
                return SaslAuthenticateRequest(version).HeaderVersion;
            if (SaslHandshakeRequest.ApiKey == apiKey)
                return SaslHandshakeRequest(version).HeaderVersion;
            if (ShareAcknowledgeRequest.ApiKey == apiKey)
                return ShareAcknowledgeRequest(version).HeaderVersion;
            if (ShareFetchRequest.ApiKey == apiKey)
                return ShareFetchRequest(version).HeaderVersion;
            if (ShareGroupDescribeRequest.ApiKey == apiKey)
                return ShareGroupDescribeRequest(version).HeaderVersion;
            if (ShareGroupHeartbeatRequest.ApiKey == apiKey)
                return ShareGroupHeartbeatRequest(version).HeaderVersion;
            if (StopReplicaRequest.ApiKey == apiKey)
                return StopReplicaRequest(version).HeaderVersion;
            if (SyncGroupRequest.ApiKey == apiKey)
                return SyncGroupRequest(version).HeaderVersion;
            if (TxnOffsetCommitRequest.ApiKey == apiKey)
                return TxnOffsetCommitRequest(version).HeaderVersion;
            if (UnregisterBrokerRequest.ApiKey == apiKey)
                return UnregisterBrokerRequest(version).HeaderVersion;
            if (UpdateFeaturesRequest.ApiKey == apiKey)
                return UpdateFeaturesRequest(version).HeaderVersion;
            if (UpdateMetadataRequest.ApiKey == apiKey)
                return UpdateMetadataRequest(version).HeaderVersion;
            if (UpdateRaftVoterRequest.ApiKey == apiKey)
                return UpdateRaftVoterRequest(version).HeaderVersion;
            if (VoteRequest.ApiKey == apiKey)
                return VoteRequest(version).HeaderVersion;
            if (WriteShareGroupStateRequest.ApiKey == apiKey)
                return WriteShareGroupStateRequest(version).HeaderVersion;
            if (WriteTxnMarkersRequest.ApiKey == apiKey)
                return WriteTxnMarkersRequest(version).HeaderVersion;
            throw new ArgumentException($"There is no request message with api key {apiKey}");
        }
    }
}
