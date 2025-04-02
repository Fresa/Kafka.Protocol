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
        public static async ValueTask<Message> CreateRequestMessageFromReaderAsync(Int16 apiKey, Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            if (AddOffsetsToTxnRequest.ApiKey == apiKey)
                return await AddOffsetsToTxnRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AddPartitionsToTxnRequest.ApiKey == apiKey)
                return await AddPartitionsToTxnRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AddRaftVoterRequest.ApiKey == apiKey)
                return await AddRaftVoterRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AllocateProducerIdsRequest.ApiKey == apiKey)
                return await AllocateProducerIdsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterClientQuotasRequest.ApiKey == apiKey)
                return await AlterClientQuotasRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterConfigsRequest.ApiKey == apiKey)
                return await AlterConfigsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterPartitionReassignmentsRequest.ApiKey == apiKey)
                return await AlterPartitionReassignmentsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterPartitionRequest.ApiKey == apiKey)
                return await AlterPartitionRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterReplicaLogDirsRequest.ApiKey == apiKey)
                return await AlterReplicaLogDirsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AlterUserScramCredentialsRequest.ApiKey == apiKey)
                return await AlterUserScramCredentialsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ApiVersionsRequest.ApiKey == apiKey)
                return await ApiVersionsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (AssignReplicasToDirsRequest.ApiKey == apiKey)
                return await AssignReplicasToDirsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (BeginQuorumEpochRequest.ApiKey == apiKey)
                return await BeginQuorumEpochRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (BrokerHeartbeatRequest.ApiKey == apiKey)
                return await BrokerHeartbeatRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (BrokerRegistrationRequest.ApiKey == apiKey)
                return await BrokerRegistrationRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ConsumerGroupDescribeRequest.ApiKey == apiKey)
                return await ConsumerGroupDescribeRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ConsumerGroupHeartbeatRequest.ApiKey == apiKey)
                return await ConsumerGroupHeartbeatRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ControllerRegistrationRequest.ApiKey == apiKey)
                return await ControllerRegistrationRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (CreateAclsRequest.ApiKey == apiKey)
                return await CreateAclsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (CreateDelegationTokenRequest.ApiKey == apiKey)
                return await CreateDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (CreatePartitionsRequest.ApiKey == apiKey)
                return await CreatePartitionsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (CreateTopicsRequest.ApiKey == apiKey)
                return await CreateTopicsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DeleteAclsRequest.ApiKey == apiKey)
                return await DeleteAclsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DeleteGroupsRequest.ApiKey == apiKey)
                return await DeleteGroupsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DeleteRecordsRequest.ApiKey == apiKey)
                return await DeleteRecordsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DeleteShareGroupStateRequest.ApiKey == apiKey)
                return await DeleteShareGroupStateRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DeleteTopicsRequest.ApiKey == apiKey)
                return await DeleteTopicsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeAclsRequest.ApiKey == apiKey)
                return await DescribeAclsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeClientQuotasRequest.ApiKey == apiKey)
                return await DescribeClientQuotasRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeClusterRequest.ApiKey == apiKey)
                return await DescribeClusterRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeConfigsRequest.ApiKey == apiKey)
                return await DescribeConfigsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeDelegationTokenRequest.ApiKey == apiKey)
                return await DescribeDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeGroupsRequest.ApiKey == apiKey)
                return await DescribeGroupsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeLogDirsRequest.ApiKey == apiKey)
                return await DescribeLogDirsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeProducersRequest.ApiKey == apiKey)
                return await DescribeProducersRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeQuorumRequest.ApiKey == apiKey)
                return await DescribeQuorumRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeTopicPartitionsRequest.ApiKey == apiKey)
                return await DescribeTopicPartitionsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeTransactionsRequest.ApiKey == apiKey)
                return await DescribeTransactionsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (DescribeUserScramCredentialsRequest.ApiKey == apiKey)
                return await DescribeUserScramCredentialsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ElectLeadersRequest.ApiKey == apiKey)
                return await ElectLeadersRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (EndQuorumEpochRequest.ApiKey == apiKey)
                return await EndQuorumEpochRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (EndTxnRequest.ApiKey == apiKey)
                return await EndTxnRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (EnvelopeRequest.ApiKey == apiKey)
                return await EnvelopeRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ExpireDelegationTokenRequest.ApiKey == apiKey)
                return await ExpireDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (FetchRequest.ApiKey == apiKey)
                return await FetchRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (FetchSnapshotRequest.ApiKey == apiKey)
                return await FetchSnapshotRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (FindCoordinatorRequest.ApiKey == apiKey)
                return await FindCoordinatorRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (GetTelemetrySubscriptionsRequest.ApiKey == apiKey)
                return await GetTelemetrySubscriptionsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (HeartbeatRequest.ApiKey == apiKey)
                return await HeartbeatRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (IncrementalAlterConfigsRequest.ApiKey == apiKey)
                return await IncrementalAlterConfigsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (InitializeShareGroupStateRequest.ApiKey == apiKey)
                return await InitializeShareGroupStateRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (InitProducerIdRequest.ApiKey == apiKey)
                return await InitProducerIdRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (JoinGroupRequest.ApiKey == apiKey)
                return await JoinGroupRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (LeaveGroupRequest.ApiKey == apiKey)
                return await LeaveGroupRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ListClientMetricsResourcesRequest.ApiKey == apiKey)
                return await ListClientMetricsResourcesRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ListGroupsRequest.ApiKey == apiKey)
                return await ListGroupsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ListOffsetsRequest.ApiKey == apiKey)
                return await ListOffsetsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ListPartitionReassignmentsRequest.ApiKey == apiKey)
                return await ListPartitionReassignmentsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ListTransactionsRequest.ApiKey == apiKey)
                return await ListTransactionsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (MetadataRequest.ApiKey == apiKey)
                return await MetadataRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (OffsetCommitRequest.ApiKey == apiKey)
                return await OffsetCommitRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (OffsetDeleteRequest.ApiKey == apiKey)
                return await OffsetDeleteRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (OffsetFetchRequest.ApiKey == apiKey)
                return await OffsetFetchRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (OffsetForLeaderEpochRequest.ApiKey == apiKey)
                return await OffsetForLeaderEpochRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ProduceRequest.ApiKey == apiKey)
                return await ProduceRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (PushTelemetryRequest.ApiKey == apiKey)
                return await PushTelemetryRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ReadShareGroupStateRequest.ApiKey == apiKey)
                return await ReadShareGroupStateRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ReadShareGroupStateSummaryRequest.ApiKey == apiKey)
                return await ReadShareGroupStateSummaryRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (RemoveRaftVoterRequest.ApiKey == apiKey)
                return await RemoveRaftVoterRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (RenewDelegationTokenRequest.ApiKey == apiKey)
                return await RenewDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (SaslAuthenticateRequest.ApiKey == apiKey)
                return await SaslAuthenticateRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (SaslHandshakeRequest.ApiKey == apiKey)
                return await SaslHandshakeRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ShareAcknowledgeRequest.ApiKey == apiKey)
                return await ShareAcknowledgeRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ShareFetchRequest.ApiKey == apiKey)
                return await ShareFetchRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ShareGroupDescribeRequest.ApiKey == apiKey)
                return await ShareGroupDescribeRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (ShareGroupHeartbeatRequest.ApiKey == apiKey)
                return await ShareGroupHeartbeatRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (SyncGroupRequest.ApiKey == apiKey)
                return await SyncGroupRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (TxnOffsetCommitRequest.ApiKey == apiKey)
                return await TxnOffsetCommitRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (UnregisterBrokerRequest.ApiKey == apiKey)
                return await UnregisterBrokerRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (UpdateFeaturesRequest.ApiKey == apiKey)
                return await UpdateFeaturesRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (UpdateRaftVoterRequest.ApiKey == apiKey)
                return await UpdateRaftVoterRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (VoteRequest.ApiKey == apiKey)
                return await VoteRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (WriteShareGroupStateRequest.ApiKey == apiKey)
                return await WriteShareGroupStateRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            if (WriteTxnMarkersRequest.ApiKey == apiKey)
                return await WriteTxnMarkersRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
            throw new ArgumentException($"There is no request message with api key {apiKey}");
        }
    }
}
