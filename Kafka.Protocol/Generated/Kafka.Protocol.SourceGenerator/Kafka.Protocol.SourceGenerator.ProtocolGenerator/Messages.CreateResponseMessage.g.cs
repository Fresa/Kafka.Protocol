#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public static partial class Messages
    {
        public static async ValueTask<Message> CreateResponseMessageFromReaderAsync(Int16 apiKey, Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            if (AddOffsetsToTxnResponse.ApiKey == apiKey)
                return await AddOffsetsToTxnResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AddPartitionsToTxnResponse.ApiKey == apiKey)
                return await AddPartitionsToTxnResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AddRaftVoterResponse.ApiKey == apiKey)
                return await AddRaftVoterResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AllocateProducerIdsResponse.ApiKey == apiKey)
                return await AllocateProducerIdsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterClientQuotasResponse.ApiKey == apiKey)
                return await AlterClientQuotasResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterConfigsResponse.ApiKey == apiKey)
                return await AlterConfigsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterPartitionReassignmentsResponse.ApiKey == apiKey)
                return await AlterPartitionReassignmentsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterPartitionResponse.ApiKey == apiKey)
                return await AlterPartitionResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterReplicaLogDirsResponse.ApiKey == apiKey)
                return await AlterReplicaLogDirsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterUserScramCredentialsResponse.ApiKey == apiKey)
                return await AlterUserScramCredentialsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ApiVersionsResponse.ApiKey == apiKey)
                return await ApiVersionsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AssignReplicasToDirsResponse.ApiKey == apiKey)
                return await AssignReplicasToDirsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (BeginQuorumEpochResponse.ApiKey == apiKey)
                return await BeginQuorumEpochResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (BrokerHeartbeatResponse.ApiKey == apiKey)
                return await BrokerHeartbeatResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (BrokerRegistrationResponse.ApiKey == apiKey)
                return await BrokerRegistrationResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ConsumerGroupDescribeResponse.ApiKey == apiKey)
                return await ConsumerGroupDescribeResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ConsumerGroupHeartbeatResponse.ApiKey == apiKey)
                return await ConsumerGroupHeartbeatResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ControllerRegistrationResponse.ApiKey == apiKey)
                return await ControllerRegistrationResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (CreateAclsResponse.ApiKey == apiKey)
                return await CreateAclsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (CreateDelegationTokenResponse.ApiKey == apiKey)
                return await CreateDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (CreatePartitionsResponse.ApiKey == apiKey)
                return await CreatePartitionsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (CreateTopicsResponse.ApiKey == apiKey)
                return await CreateTopicsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DeleteAclsResponse.ApiKey == apiKey)
                return await DeleteAclsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DeleteGroupsResponse.ApiKey == apiKey)
                return await DeleteGroupsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DeleteRecordsResponse.ApiKey == apiKey)
                return await DeleteRecordsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DeleteShareGroupStateResponse.ApiKey == apiKey)
                return await DeleteShareGroupStateResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DeleteTopicsResponse.ApiKey == apiKey)
                return await DeleteTopicsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeAclsResponse.ApiKey == apiKey)
                return await DescribeAclsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeClientQuotasResponse.ApiKey == apiKey)
                return await DescribeClientQuotasResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeClusterResponse.ApiKey == apiKey)
                return await DescribeClusterResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeConfigsResponse.ApiKey == apiKey)
                return await DescribeConfigsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeDelegationTokenResponse.ApiKey == apiKey)
                return await DescribeDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeGroupsResponse.ApiKey == apiKey)
                return await DescribeGroupsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeLogDirsResponse.ApiKey == apiKey)
                return await DescribeLogDirsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeProducersResponse.ApiKey == apiKey)
                return await DescribeProducersResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeQuorumResponse.ApiKey == apiKey)
                return await DescribeQuorumResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeTopicPartitionsResponse.ApiKey == apiKey)
                return await DescribeTopicPartitionsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeTransactionsResponse.ApiKey == apiKey)
                return await DescribeTransactionsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeUserScramCredentialsResponse.ApiKey == apiKey)
                return await DescribeUserScramCredentialsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ElectLeadersResponse.ApiKey == apiKey)
                return await ElectLeadersResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (EndQuorumEpochResponse.ApiKey == apiKey)
                return await EndQuorumEpochResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (EndTxnResponse.ApiKey == apiKey)
                return await EndTxnResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (EnvelopeResponse.ApiKey == apiKey)
                return await EnvelopeResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ExpireDelegationTokenResponse.ApiKey == apiKey)
                return await ExpireDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (FetchResponse.ApiKey == apiKey)
                return await FetchResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (FetchSnapshotResponse.ApiKey == apiKey)
                return await FetchSnapshotResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (FindCoordinatorResponse.ApiKey == apiKey)
                return await FindCoordinatorResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (GetTelemetrySubscriptionsResponse.ApiKey == apiKey)
                return await GetTelemetrySubscriptionsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (HeartbeatResponse.ApiKey == apiKey)
                return await HeartbeatResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (IncrementalAlterConfigsResponse.ApiKey == apiKey)
                return await IncrementalAlterConfigsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (InitializeShareGroupStateResponse.ApiKey == apiKey)
                return await InitializeShareGroupStateResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (InitProducerIdResponse.ApiKey == apiKey)
                return await InitProducerIdResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (JoinGroupResponse.ApiKey == apiKey)
                return await JoinGroupResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (LeaveGroupResponse.ApiKey == apiKey)
                return await LeaveGroupResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ListClientMetricsResourcesResponse.ApiKey == apiKey)
                return await ListClientMetricsResourcesResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ListGroupsResponse.ApiKey == apiKey)
                return await ListGroupsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ListOffsetsResponse.ApiKey == apiKey)
                return await ListOffsetsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ListPartitionReassignmentsResponse.ApiKey == apiKey)
                return await ListPartitionReassignmentsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ListTransactionsResponse.ApiKey == apiKey)
                return await ListTransactionsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (MetadataResponse.ApiKey == apiKey)
                return await MetadataResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (OffsetCommitResponse.ApiKey == apiKey)
                return await OffsetCommitResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (OffsetDeleteResponse.ApiKey == apiKey)
                return await OffsetDeleteResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (OffsetFetchResponse.ApiKey == apiKey)
                return await OffsetFetchResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (OffsetForLeaderEpochResponse.ApiKey == apiKey)
                return await OffsetForLeaderEpochResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ProduceResponse.ApiKey == apiKey)
                return await ProduceResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (PushTelemetryResponse.ApiKey == apiKey)
                return await PushTelemetryResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ReadShareGroupStateResponse.ApiKey == apiKey)
                return await ReadShareGroupStateResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ReadShareGroupStateSummaryResponse.ApiKey == apiKey)
                return await ReadShareGroupStateSummaryResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (RemoveRaftVoterResponse.ApiKey == apiKey)
                return await RemoveRaftVoterResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (RenewDelegationTokenResponse.ApiKey == apiKey)
                return await RenewDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (SaslAuthenticateResponse.ApiKey == apiKey)
                return await SaslAuthenticateResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (SaslHandshakeResponse.ApiKey == apiKey)
                return await SaslHandshakeResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ShareAcknowledgeResponse.ApiKey == apiKey)
                return await ShareAcknowledgeResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ShareFetchResponse.ApiKey == apiKey)
                return await ShareFetchResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ShareGroupDescribeResponse.ApiKey == apiKey)
                return await ShareGroupDescribeResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ShareGroupHeartbeatResponse.ApiKey == apiKey)
                return await ShareGroupHeartbeatResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (SyncGroupResponse.ApiKey == apiKey)
                return await SyncGroupResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (TxnOffsetCommitResponse.ApiKey == apiKey)
                return await TxnOffsetCommitResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (UnregisterBrokerResponse.ApiKey == apiKey)
                return await UnregisterBrokerResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (UpdateFeaturesResponse.ApiKey == apiKey)
                return await UpdateFeaturesResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (UpdateRaftVoterResponse.ApiKey == apiKey)
                return await UpdateRaftVoterResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (VoteResponse.ApiKey == apiKey)
                return await VoteResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (WriteShareGroupStateResponse.ApiKey == apiKey)
                return await WriteShareGroupStateResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (WriteTxnMarkersResponse.ApiKey == apiKey)
                return await WriteTxnMarkersResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            throw new ArgumentException($"There is no response message with api key {apiKey}");
        }
    }
}
