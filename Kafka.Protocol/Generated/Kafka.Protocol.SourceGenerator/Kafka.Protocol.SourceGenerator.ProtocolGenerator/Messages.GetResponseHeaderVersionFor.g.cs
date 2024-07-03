// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public static partial class Messages
    {
        public static Int16 GetResponseHeaderVersionFor(Int16 apiKey, Int16 version)
        {
            if (AddOffsetsToTxnResponse.ApiKey == apiKey)
                return AddOffsetsToTxnResponse(version).HeaderVersion;
            if (AddPartitionsToTxnResponse.ApiKey == apiKey)
                return AddPartitionsToTxnResponse(version).HeaderVersion;
            if (AddRaftVoterResponse.ApiKey == apiKey)
                return AddRaftVoterResponse(version).HeaderVersion;
            if (AllocateProducerIdsResponse.ApiKey == apiKey)
                return AllocateProducerIdsResponse(version).HeaderVersion;
            if (AlterClientQuotasResponse.ApiKey == apiKey)
                return AlterClientQuotasResponse(version).HeaderVersion;
            if (AlterConfigsResponse.ApiKey == apiKey)
                return AlterConfigsResponse(version).HeaderVersion;
            if (AlterPartitionReassignmentsResponse.ApiKey == apiKey)
                return AlterPartitionReassignmentsResponse(version).HeaderVersion;
            if (AlterPartitionResponse.ApiKey == apiKey)
                return AlterPartitionResponse(version).HeaderVersion;
            if (AlterReplicaLogDirsResponse.ApiKey == apiKey)
                return AlterReplicaLogDirsResponse(version).HeaderVersion;
            if (AlterUserScramCredentialsResponse.ApiKey == apiKey)
                return AlterUserScramCredentialsResponse(version).HeaderVersion;
            if (ApiVersionsResponse.ApiKey == apiKey)
                return ApiVersionsResponse(version).HeaderVersion;
            if (AssignReplicasToDirsResponse.ApiKey == apiKey)
                return AssignReplicasToDirsResponse(version).HeaderVersion;
            if (BeginQuorumEpochResponse.ApiKey == apiKey)
                return BeginQuorumEpochResponse(version).HeaderVersion;
            if (BrokerHeartbeatResponse.ApiKey == apiKey)
                return BrokerHeartbeatResponse(version).HeaderVersion;
            if (BrokerRegistrationResponse.ApiKey == apiKey)
                return BrokerRegistrationResponse(version).HeaderVersion;
            if (ConsumerGroupDescribeResponse.ApiKey == apiKey)
                return ConsumerGroupDescribeResponse(version).HeaderVersion;
            if (ConsumerGroupHeartbeatResponse.ApiKey == apiKey)
                return ConsumerGroupHeartbeatResponse(version).HeaderVersion;
            if (ControlledShutdownResponse.ApiKey == apiKey)
                return ControlledShutdownResponse(version).HeaderVersion;
            if (ControllerRegistrationResponse.ApiKey == apiKey)
                return ControllerRegistrationResponse(version).HeaderVersion;
            if (CreateAclsResponse.ApiKey == apiKey)
                return CreateAclsResponse(version).HeaderVersion;
            if (CreateDelegationTokenResponse.ApiKey == apiKey)
                return CreateDelegationTokenResponse(version).HeaderVersion;
            if (CreatePartitionsResponse.ApiKey == apiKey)
                return CreatePartitionsResponse(version).HeaderVersion;
            if (CreateTopicsResponse.ApiKey == apiKey)
                return CreateTopicsResponse(version).HeaderVersion;
            if (DeleteAclsResponse.ApiKey == apiKey)
                return DeleteAclsResponse(version).HeaderVersion;
            if (DeleteGroupsResponse.ApiKey == apiKey)
                return DeleteGroupsResponse(version).HeaderVersion;
            if (DeleteRecordsResponse.ApiKey == apiKey)
                return DeleteRecordsResponse(version).HeaderVersion;
            if (DeleteShareGroupStateResponse.ApiKey == apiKey)
                return DeleteShareGroupStateResponse(version).HeaderVersion;
            if (DeleteTopicsResponse.ApiKey == apiKey)
                return DeleteTopicsResponse(version).HeaderVersion;
            if (DescribeAclsResponse.ApiKey == apiKey)
                return DescribeAclsResponse(version).HeaderVersion;
            if (DescribeClientQuotasResponse.ApiKey == apiKey)
                return DescribeClientQuotasResponse(version).HeaderVersion;
            if (DescribeClusterResponse.ApiKey == apiKey)
                return DescribeClusterResponse(version).HeaderVersion;
            if (DescribeConfigsResponse.ApiKey == apiKey)
                return DescribeConfigsResponse(version).HeaderVersion;
            if (DescribeDelegationTokenResponse.ApiKey == apiKey)
                return DescribeDelegationTokenResponse(version).HeaderVersion;
            if (DescribeGroupsResponse.ApiKey == apiKey)
                return DescribeGroupsResponse(version).HeaderVersion;
            if (DescribeLogDirsResponse.ApiKey == apiKey)
                return DescribeLogDirsResponse(version).HeaderVersion;
            if (DescribeProducersResponse.ApiKey == apiKey)
                return DescribeProducersResponse(version).HeaderVersion;
            if (DescribeQuorumResponse.ApiKey == apiKey)
                return DescribeQuorumResponse(version).HeaderVersion;
            if (DescribeTopicPartitionsResponse.ApiKey == apiKey)
                return DescribeTopicPartitionsResponse(version).HeaderVersion;
            if (DescribeTransactionsResponse.ApiKey == apiKey)
                return DescribeTransactionsResponse(version).HeaderVersion;
            if (DescribeUserScramCredentialsResponse.ApiKey == apiKey)
                return DescribeUserScramCredentialsResponse(version).HeaderVersion;
            if (ElectLeadersResponse.ApiKey == apiKey)
                return ElectLeadersResponse(version).HeaderVersion;
            if (EndQuorumEpochResponse.ApiKey == apiKey)
                return EndQuorumEpochResponse(version).HeaderVersion;
            if (EndTxnResponse.ApiKey == apiKey)
                return EndTxnResponse(version).HeaderVersion;
            if (EnvelopeResponse.ApiKey == apiKey)
                return EnvelopeResponse(version).HeaderVersion;
            if (ExpireDelegationTokenResponse.ApiKey == apiKey)
                return ExpireDelegationTokenResponse(version).HeaderVersion;
            if (FetchResponse.ApiKey == apiKey)
                return FetchResponse(version).HeaderVersion;
            if (FetchSnapshotResponse.ApiKey == apiKey)
                return FetchSnapshotResponse(version).HeaderVersion;
            if (FindCoordinatorResponse.ApiKey == apiKey)
                return FindCoordinatorResponse(version).HeaderVersion;
            if (GetTelemetrySubscriptionsResponse.ApiKey == apiKey)
                return GetTelemetrySubscriptionsResponse(version).HeaderVersion;
            if (HeartbeatResponse.ApiKey == apiKey)
                return HeartbeatResponse(version).HeaderVersion;
            if (IncrementalAlterConfigsResponse.ApiKey == apiKey)
                return IncrementalAlterConfigsResponse(version).HeaderVersion;
            if (InitializeShareGroupStateResponse.ApiKey == apiKey)
                return InitializeShareGroupStateResponse(version).HeaderVersion;
            if (InitProducerIdResponse.ApiKey == apiKey)
                return InitProducerIdResponse(version).HeaderVersion;
            if (JoinGroupResponse.ApiKey == apiKey)
                return JoinGroupResponse(version).HeaderVersion;
            if (LeaderAndIsrResponse.ApiKey == apiKey)
                return LeaderAndIsrResponse(version).HeaderVersion;
            if (LeaveGroupResponse.ApiKey == apiKey)
                return LeaveGroupResponse(version).HeaderVersion;
            if (ListClientMetricsResourcesResponse.ApiKey == apiKey)
                return ListClientMetricsResourcesResponse(version).HeaderVersion;
            if (ListGroupsResponse.ApiKey == apiKey)
                return ListGroupsResponse(version).HeaderVersion;
            if (ListOffsetsResponse.ApiKey == apiKey)
                return ListOffsetsResponse(version).HeaderVersion;
            if (ListPartitionReassignmentsResponse.ApiKey == apiKey)
                return ListPartitionReassignmentsResponse(version).HeaderVersion;
            if (ListTransactionsResponse.ApiKey == apiKey)
                return ListTransactionsResponse(version).HeaderVersion;
            if (MetadataResponse.ApiKey == apiKey)
                return MetadataResponse(version).HeaderVersion;
            if (OffsetCommitResponse.ApiKey == apiKey)
                return OffsetCommitResponse(version).HeaderVersion;
            if (OffsetDeleteResponse.ApiKey == apiKey)
                return OffsetDeleteResponse(version).HeaderVersion;
            if (OffsetFetchResponse.ApiKey == apiKey)
                return OffsetFetchResponse(version).HeaderVersion;
            if (OffsetForLeaderEpochResponse.ApiKey == apiKey)
                return OffsetForLeaderEpochResponse(version).HeaderVersion;
            if (ProduceResponse.ApiKey == apiKey)
                return ProduceResponse(version).HeaderVersion;
            if (PushTelemetryResponse.ApiKey == apiKey)
                return PushTelemetryResponse(version).HeaderVersion;
            if (ReadShareGroupStateResponse.ApiKey == apiKey)
                return ReadShareGroupStateResponse(version).HeaderVersion;
            if (ReadShareGroupStateSummaryResponse.ApiKey == apiKey)
                return ReadShareGroupStateSummaryResponse(version).HeaderVersion;
            if (RemoveRaftVoterResponse.ApiKey == apiKey)
                return RemoveRaftVoterResponse(version).HeaderVersion;
            if (RenewDelegationTokenResponse.ApiKey == apiKey)
                return RenewDelegationTokenResponse(version).HeaderVersion;
            if (SaslAuthenticateResponse.ApiKey == apiKey)
                return SaslAuthenticateResponse(version).HeaderVersion;
            if (SaslHandshakeResponse.ApiKey == apiKey)
                return SaslHandshakeResponse(version).HeaderVersion;
            if (ShareAcknowledgeResponse.ApiKey == apiKey)
                return ShareAcknowledgeResponse(version).HeaderVersion;
            if (ShareFetchResponse.ApiKey == apiKey)
                return ShareFetchResponse(version).HeaderVersion;
            if (ShareGroupDescribeResponse.ApiKey == apiKey)
                return ShareGroupDescribeResponse(version).HeaderVersion;
            if (ShareGroupHeartbeatResponse.ApiKey == apiKey)
                return ShareGroupHeartbeatResponse(version).HeaderVersion;
            if (StopReplicaResponse.ApiKey == apiKey)
                return StopReplicaResponse(version).HeaderVersion;
            if (SyncGroupResponse.ApiKey == apiKey)
                return SyncGroupResponse(version).HeaderVersion;
            if (TxnOffsetCommitResponse.ApiKey == apiKey)
                return TxnOffsetCommitResponse(version).HeaderVersion;
            if (UnregisterBrokerResponse.ApiKey == apiKey)
                return UnregisterBrokerResponse(version).HeaderVersion;
            if (UpdateFeaturesResponse.ApiKey == apiKey)
                return UpdateFeaturesResponse(version).HeaderVersion;
            if (UpdateMetadataResponse.ApiKey == apiKey)
                return UpdateMetadataResponse(version).HeaderVersion;
            if (UpdateRaftVoterResponse.ApiKey == apiKey)
                return UpdateRaftVoterResponse(version).HeaderVersion;
            if (VoteResponse.ApiKey == apiKey)
                return VoteResponse(version).HeaderVersion;
            if (WriteShareGroupStateResponse.ApiKey == apiKey)
                return WriteShareGroupStateResponse(version).HeaderVersion;
            if (WriteTxnMarkersResponse.ApiKey == apiKey)
                return WriteTxnMarkersResponse(version).HeaderVersion;
            throw new ArgumentException($"There is no response message with api key {apiKey}");
        }
    }
}
