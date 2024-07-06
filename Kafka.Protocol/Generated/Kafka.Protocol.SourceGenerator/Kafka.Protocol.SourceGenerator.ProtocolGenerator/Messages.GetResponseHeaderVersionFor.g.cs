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
        public static Int16 GetResponseHeaderVersionFor(RequestPayload payload)
        {
            var apiKey = payload.Message.ApiMessageKey;
            var version = payload.Message.Version;
            if (AddOffsetsToTxnResponse.ApiKey == apiKey)
                return new AddOffsetsToTxnResponse(version).HeaderVersion;
            if (AddPartitionsToTxnResponse.ApiKey == apiKey)
                return new AddPartitionsToTxnResponse(version).HeaderVersion;
            if (AddRaftVoterResponse.ApiKey == apiKey)
                return new AddRaftVoterResponse(version).HeaderVersion;
            if (AllocateProducerIdsResponse.ApiKey == apiKey)
                return new AllocateProducerIdsResponse(version).HeaderVersion;
            if (AlterClientQuotasResponse.ApiKey == apiKey)
                return new AlterClientQuotasResponse(version).HeaderVersion;
            if (AlterConfigsResponse.ApiKey == apiKey)
                return new AlterConfigsResponse(version).HeaderVersion;
            if (AlterPartitionReassignmentsResponse.ApiKey == apiKey)
                return new AlterPartitionReassignmentsResponse(version).HeaderVersion;
            if (AlterPartitionResponse.ApiKey == apiKey)
                return new AlterPartitionResponse(version).HeaderVersion;
            if (AlterReplicaLogDirsResponse.ApiKey == apiKey)
                return new AlterReplicaLogDirsResponse(version).HeaderVersion;
            if (AlterUserScramCredentialsResponse.ApiKey == apiKey)
                return new AlterUserScramCredentialsResponse(version).HeaderVersion;
            if (ApiVersionsResponse.ApiKey == apiKey)
                return new ApiVersionsResponse(version).HeaderVersion;
            if (AssignReplicasToDirsResponse.ApiKey == apiKey)
                return new AssignReplicasToDirsResponse(version).HeaderVersion;
            if (BeginQuorumEpochResponse.ApiKey == apiKey)
                return new BeginQuorumEpochResponse(version).HeaderVersion;
            if (BrokerHeartbeatResponse.ApiKey == apiKey)
                return new BrokerHeartbeatResponse(version).HeaderVersion;
            if (BrokerRegistrationResponse.ApiKey == apiKey)
                return new BrokerRegistrationResponse(version).HeaderVersion;
            if (ConsumerGroupDescribeResponse.ApiKey == apiKey)
                return new ConsumerGroupDescribeResponse(version).HeaderVersion;
            if (ConsumerGroupHeartbeatResponse.ApiKey == apiKey)
                return new ConsumerGroupHeartbeatResponse(version).HeaderVersion;
            if (ControlledShutdownResponse.ApiKey == apiKey)
                return new ControlledShutdownResponse(version).HeaderVersion;
            if (ControllerRegistrationResponse.ApiKey == apiKey)
                return new ControllerRegistrationResponse(version).HeaderVersion;
            if (CreateAclsResponse.ApiKey == apiKey)
                return new CreateAclsResponse(version).HeaderVersion;
            if (CreateDelegationTokenResponse.ApiKey == apiKey)
                return new CreateDelegationTokenResponse(version).HeaderVersion;
            if (CreatePartitionsResponse.ApiKey == apiKey)
                return new CreatePartitionsResponse(version).HeaderVersion;
            if (CreateTopicsResponse.ApiKey == apiKey)
                return new CreateTopicsResponse(version).HeaderVersion;
            if (DeleteAclsResponse.ApiKey == apiKey)
                return new DeleteAclsResponse(version).HeaderVersion;
            if (DeleteGroupsResponse.ApiKey == apiKey)
                return new DeleteGroupsResponse(version).HeaderVersion;
            if (DeleteRecordsResponse.ApiKey == apiKey)
                return new DeleteRecordsResponse(version).HeaderVersion;
            if (DeleteShareGroupStateResponse.ApiKey == apiKey)
                return new DeleteShareGroupStateResponse(version).HeaderVersion;
            if (DeleteTopicsResponse.ApiKey == apiKey)
                return new DeleteTopicsResponse(version).HeaderVersion;
            if (DescribeAclsResponse.ApiKey == apiKey)
                return new DescribeAclsResponse(version).HeaderVersion;
            if (DescribeClientQuotasResponse.ApiKey == apiKey)
                return new DescribeClientQuotasResponse(version).HeaderVersion;
            if (DescribeClusterResponse.ApiKey == apiKey)
                return new DescribeClusterResponse(version).HeaderVersion;
            if (DescribeConfigsResponse.ApiKey == apiKey)
                return new DescribeConfigsResponse(version).HeaderVersion;
            if (DescribeDelegationTokenResponse.ApiKey == apiKey)
                return new DescribeDelegationTokenResponse(version).HeaderVersion;
            if (DescribeGroupsResponse.ApiKey == apiKey)
                return new DescribeGroupsResponse(version).HeaderVersion;
            if (DescribeLogDirsResponse.ApiKey == apiKey)
                return new DescribeLogDirsResponse(version).HeaderVersion;
            if (DescribeProducersResponse.ApiKey == apiKey)
                return new DescribeProducersResponse(version).HeaderVersion;
            if (DescribeQuorumResponse.ApiKey == apiKey)
                return new DescribeQuorumResponse(version).HeaderVersion;
            if (DescribeTopicPartitionsResponse.ApiKey == apiKey)
                return new DescribeTopicPartitionsResponse(version).HeaderVersion;
            if (DescribeTransactionsResponse.ApiKey == apiKey)
                return new DescribeTransactionsResponse(version).HeaderVersion;
            if (DescribeUserScramCredentialsResponse.ApiKey == apiKey)
                return new DescribeUserScramCredentialsResponse(version).HeaderVersion;
            if (ElectLeadersResponse.ApiKey == apiKey)
                return new ElectLeadersResponse(version).HeaderVersion;
            if (EndQuorumEpochResponse.ApiKey == apiKey)
                return new EndQuorumEpochResponse(version).HeaderVersion;
            if (EndTxnResponse.ApiKey == apiKey)
                return new EndTxnResponse(version).HeaderVersion;
            if (EnvelopeResponse.ApiKey == apiKey)
                return new EnvelopeResponse(version).HeaderVersion;
            if (ExpireDelegationTokenResponse.ApiKey == apiKey)
                return new ExpireDelegationTokenResponse(version).HeaderVersion;
            if (FetchResponse.ApiKey == apiKey)
                return new FetchResponse(version).HeaderVersion;
            if (FetchSnapshotResponse.ApiKey == apiKey)
                return new FetchSnapshotResponse(version).HeaderVersion;
            if (FindCoordinatorResponse.ApiKey == apiKey)
                return new FindCoordinatorResponse(version).HeaderVersion;
            if (GetTelemetrySubscriptionsResponse.ApiKey == apiKey)
                return new GetTelemetrySubscriptionsResponse(version).HeaderVersion;
            if (HeartbeatResponse.ApiKey == apiKey)
                return new HeartbeatResponse(version).HeaderVersion;
            if (IncrementalAlterConfigsResponse.ApiKey == apiKey)
                return new IncrementalAlterConfigsResponse(version).HeaderVersion;
            if (InitializeShareGroupStateResponse.ApiKey == apiKey)
                return new InitializeShareGroupStateResponse(version).HeaderVersion;
            if (InitProducerIdResponse.ApiKey == apiKey)
                return new InitProducerIdResponse(version).HeaderVersion;
            if (JoinGroupResponse.ApiKey == apiKey)
                return new JoinGroupResponse(version).HeaderVersion;
            if (LeaderAndIsrResponse.ApiKey == apiKey)
                return new LeaderAndIsrResponse(version).HeaderVersion;
            if (LeaveGroupResponse.ApiKey == apiKey)
                return new LeaveGroupResponse(version).HeaderVersion;
            if (ListClientMetricsResourcesResponse.ApiKey == apiKey)
                return new ListClientMetricsResourcesResponse(version).HeaderVersion;
            if (ListGroupsResponse.ApiKey == apiKey)
                return new ListGroupsResponse(version).HeaderVersion;
            if (ListOffsetsResponse.ApiKey == apiKey)
                return new ListOffsetsResponse(version).HeaderVersion;
            if (ListPartitionReassignmentsResponse.ApiKey == apiKey)
                return new ListPartitionReassignmentsResponse(version).HeaderVersion;
            if (ListTransactionsResponse.ApiKey == apiKey)
                return new ListTransactionsResponse(version).HeaderVersion;
            if (MetadataResponse.ApiKey == apiKey)
                return new MetadataResponse(version).HeaderVersion;
            if (OffsetCommitResponse.ApiKey == apiKey)
                return new OffsetCommitResponse(version).HeaderVersion;
            if (OffsetDeleteResponse.ApiKey == apiKey)
                return new OffsetDeleteResponse(version).HeaderVersion;
            if (OffsetFetchResponse.ApiKey == apiKey)
                return new OffsetFetchResponse(version).HeaderVersion;
            if (OffsetForLeaderEpochResponse.ApiKey == apiKey)
                return new OffsetForLeaderEpochResponse(version).HeaderVersion;
            if (ProduceResponse.ApiKey == apiKey)
                return new ProduceResponse(version).HeaderVersion;
            if (PushTelemetryResponse.ApiKey == apiKey)
                return new PushTelemetryResponse(version).HeaderVersion;
            if (ReadShareGroupStateResponse.ApiKey == apiKey)
                return new ReadShareGroupStateResponse(version).HeaderVersion;
            if (ReadShareGroupStateSummaryResponse.ApiKey == apiKey)
                return new ReadShareGroupStateSummaryResponse(version).HeaderVersion;
            if (RemoveRaftVoterResponse.ApiKey == apiKey)
                return new RemoveRaftVoterResponse(version).HeaderVersion;
            if (RenewDelegationTokenResponse.ApiKey == apiKey)
                return new RenewDelegationTokenResponse(version).HeaderVersion;
            if (SaslAuthenticateResponse.ApiKey == apiKey)
                return new SaslAuthenticateResponse(version).HeaderVersion;
            if (SaslHandshakeResponse.ApiKey == apiKey)
                return new SaslHandshakeResponse(version).HeaderVersion;
            if (ShareAcknowledgeResponse.ApiKey == apiKey)
                return new ShareAcknowledgeResponse(version).HeaderVersion;
            if (ShareFetchResponse.ApiKey == apiKey)
                return new ShareFetchResponse(version).HeaderVersion;
            if (ShareGroupDescribeResponse.ApiKey == apiKey)
                return new ShareGroupDescribeResponse(version).HeaderVersion;
            if (ShareGroupHeartbeatResponse.ApiKey == apiKey)
                return new ShareGroupHeartbeatResponse(version).HeaderVersion;
            if (StopReplicaResponse.ApiKey == apiKey)
                return new StopReplicaResponse(version).HeaderVersion;
            if (SyncGroupResponse.ApiKey == apiKey)
                return new SyncGroupResponse(version).HeaderVersion;
            if (TxnOffsetCommitResponse.ApiKey == apiKey)
                return new TxnOffsetCommitResponse(version).HeaderVersion;
            if (UnregisterBrokerResponse.ApiKey == apiKey)
                return new UnregisterBrokerResponse(version).HeaderVersion;
            if (UpdateFeaturesResponse.ApiKey == apiKey)
                return new UpdateFeaturesResponse(version).HeaderVersion;
            if (UpdateMetadataResponse.ApiKey == apiKey)
                return new UpdateMetadataResponse(version).HeaderVersion;
            if (UpdateRaftVoterResponse.ApiKey == apiKey)
                return new UpdateRaftVoterResponse(version).HeaderVersion;
            if (VoteResponse.ApiKey == apiKey)
                return new VoteResponse(version).HeaderVersion;
            if (WriteShareGroupStateResponse.ApiKey == apiKey)
                return new WriteShareGroupStateResponse(version).HeaderVersion;
            if (WriteTxnMarkersResponse.ApiKey == apiKey)
                return new WriteTxnMarkersResponse(version).HeaderVersion;
            throw new ArgumentException($"There is no response message with api key {apiKey}");
        }
    }
}
