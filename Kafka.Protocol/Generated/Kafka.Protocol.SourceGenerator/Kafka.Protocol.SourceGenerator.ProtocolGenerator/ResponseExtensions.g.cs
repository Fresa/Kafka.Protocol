  #nullable enable
  #pragma warning disable 1591
  // WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
                    
  namespace Kafka.Protocol
  {
      public static class ResponseExtensions
      {
          public static ApiVersionsResponse WithAllApiKeys(this ApiVersionsResponse response) =>
              response.WithApiKeysCollection(
               key => key
                   .WithApiKey(AddOffsetsToTxnRequest.ApiKey)
                   .WithMinVersion(AddOffsetsToTxnRequest.MinVersion)
                   .WithMaxVersion(AddOffsetsToTxnRequest.MaxVersion),
               key => key
                   .WithApiKey(AddPartitionsToTxnRequest.ApiKey)
                   .WithMinVersion(AddPartitionsToTxnRequest.MinVersion)
                   .WithMaxVersion(AddPartitionsToTxnRequest.MaxVersion),
               key => key
                   .WithApiKey(AddRaftVoterRequest.ApiKey)
                   .WithMinVersion(AddRaftVoterRequest.MinVersion)
                   .WithMaxVersion(AddRaftVoterRequest.MaxVersion),
               key => key
                   .WithApiKey(AllocateProducerIdsRequest.ApiKey)
                   .WithMinVersion(AllocateProducerIdsRequest.MinVersion)
                   .WithMaxVersion(AllocateProducerIdsRequest.MaxVersion),
               key => key
                   .WithApiKey(AlterClientQuotasRequest.ApiKey)
                   .WithMinVersion(AlterClientQuotasRequest.MinVersion)
                   .WithMaxVersion(AlterClientQuotasRequest.MaxVersion),
               key => key
                   .WithApiKey(AlterConfigsRequest.ApiKey)
                   .WithMinVersion(AlterConfigsRequest.MinVersion)
                   .WithMaxVersion(AlterConfigsRequest.MaxVersion),
               key => key
                   .WithApiKey(AlterPartitionReassignmentsRequest.ApiKey)
                   .WithMinVersion(AlterPartitionReassignmentsRequest.MinVersion)
                   .WithMaxVersion(AlterPartitionReassignmentsRequest.MaxVersion),
               key => key
                   .WithApiKey(AlterPartitionRequest.ApiKey)
                   .WithMinVersion(AlterPartitionRequest.MinVersion)
                   .WithMaxVersion(AlterPartitionRequest.MaxVersion),
               key => key
                   .WithApiKey(AlterReplicaLogDirsRequest.ApiKey)
                   .WithMinVersion(AlterReplicaLogDirsRequest.MinVersion)
                   .WithMaxVersion(AlterReplicaLogDirsRequest.MaxVersion),
               key => key
                   .WithApiKey(AlterUserScramCredentialsRequest.ApiKey)
                   .WithMinVersion(AlterUserScramCredentialsRequest.MinVersion)
                   .WithMaxVersion(AlterUserScramCredentialsRequest.MaxVersion),
               key => key
                   .WithApiKey(ApiVersionsRequest.ApiKey)
                   .WithMinVersion(ApiVersionsRequest.MinVersion)
                   .WithMaxVersion(ApiVersionsRequest.MaxVersion),
               key => key
                   .WithApiKey(AssignReplicasToDirsRequest.ApiKey)
                   .WithMinVersion(AssignReplicasToDirsRequest.MinVersion)
                   .WithMaxVersion(AssignReplicasToDirsRequest.MaxVersion),
               key => key
                   .WithApiKey(BeginQuorumEpochRequest.ApiKey)
                   .WithMinVersion(BeginQuorumEpochRequest.MinVersion)
                   .WithMaxVersion(BeginQuorumEpochRequest.MaxVersion),
               key => key
                   .WithApiKey(BrokerHeartbeatRequest.ApiKey)
                   .WithMinVersion(BrokerHeartbeatRequest.MinVersion)
                   .WithMaxVersion(BrokerHeartbeatRequest.MaxVersion),
               key => key
                   .WithApiKey(BrokerRegistrationRequest.ApiKey)
                   .WithMinVersion(BrokerRegistrationRequest.MinVersion)
                   .WithMaxVersion(BrokerRegistrationRequest.MaxVersion),
               key => key
                   .WithApiKey(ConsumerGroupDescribeRequest.ApiKey)
                   .WithMinVersion(ConsumerGroupDescribeRequest.MinVersion)
                   .WithMaxVersion(ConsumerGroupDescribeRequest.MaxVersion),
               key => key
                   .WithApiKey(ConsumerGroupHeartbeatRequest.ApiKey)
                   .WithMinVersion(ConsumerGroupHeartbeatRequest.MinVersion)
                   .WithMaxVersion(ConsumerGroupHeartbeatRequest.MaxVersion),
               key => key
                   .WithApiKey(ControllerRegistrationRequest.ApiKey)
                   .WithMinVersion(ControllerRegistrationRequest.MinVersion)
                   .WithMaxVersion(ControllerRegistrationRequest.MaxVersion),
               key => key
                   .WithApiKey(CreateAclsRequest.ApiKey)
                   .WithMinVersion(CreateAclsRequest.MinVersion)
                   .WithMaxVersion(CreateAclsRequest.MaxVersion),
               key => key
                   .WithApiKey(CreateDelegationTokenRequest.ApiKey)
                   .WithMinVersion(CreateDelegationTokenRequest.MinVersion)
                   .WithMaxVersion(CreateDelegationTokenRequest.MaxVersion),
               key => key
                   .WithApiKey(CreatePartitionsRequest.ApiKey)
                   .WithMinVersion(CreatePartitionsRequest.MinVersion)
                   .WithMaxVersion(CreatePartitionsRequest.MaxVersion),
               key => key
                   .WithApiKey(CreateTopicsRequest.ApiKey)
                   .WithMinVersion(CreateTopicsRequest.MinVersion)
                   .WithMaxVersion(CreateTopicsRequest.MaxVersion),
               key => key
                   .WithApiKey(DeleteAclsRequest.ApiKey)
                   .WithMinVersion(DeleteAclsRequest.MinVersion)
                   .WithMaxVersion(DeleteAclsRequest.MaxVersion),
               key => key
                   .WithApiKey(DeleteGroupsRequest.ApiKey)
                   .WithMinVersion(DeleteGroupsRequest.MinVersion)
                   .WithMaxVersion(DeleteGroupsRequest.MaxVersion),
               key => key
                   .WithApiKey(DeleteRecordsRequest.ApiKey)
                   .WithMinVersion(DeleteRecordsRequest.MinVersion)
                   .WithMaxVersion(DeleteRecordsRequest.MaxVersion),
               key => key
                   .WithApiKey(DeleteShareGroupStateRequest.ApiKey)
                   .WithMinVersion(DeleteShareGroupStateRequest.MinVersion)
                   .WithMaxVersion(DeleteShareGroupStateRequest.MaxVersion),
               key => key
                   .WithApiKey(DeleteTopicsRequest.ApiKey)
                   .WithMinVersion(DeleteTopicsRequest.MinVersion)
                   .WithMaxVersion(DeleteTopicsRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeAclsRequest.ApiKey)
                   .WithMinVersion(DescribeAclsRequest.MinVersion)
                   .WithMaxVersion(DescribeAclsRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeClientQuotasRequest.ApiKey)
                   .WithMinVersion(DescribeClientQuotasRequest.MinVersion)
                   .WithMaxVersion(DescribeClientQuotasRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeClusterRequest.ApiKey)
                   .WithMinVersion(DescribeClusterRequest.MinVersion)
                   .WithMaxVersion(DescribeClusterRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeConfigsRequest.ApiKey)
                   .WithMinVersion(DescribeConfigsRequest.MinVersion)
                   .WithMaxVersion(DescribeConfigsRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeDelegationTokenRequest.ApiKey)
                   .WithMinVersion(DescribeDelegationTokenRequest.MinVersion)
                   .WithMaxVersion(DescribeDelegationTokenRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeGroupsRequest.ApiKey)
                   .WithMinVersion(DescribeGroupsRequest.MinVersion)
                   .WithMaxVersion(DescribeGroupsRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeLogDirsRequest.ApiKey)
                   .WithMinVersion(DescribeLogDirsRequest.MinVersion)
                   .WithMaxVersion(DescribeLogDirsRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeProducersRequest.ApiKey)
                   .WithMinVersion(DescribeProducersRequest.MinVersion)
                   .WithMaxVersion(DescribeProducersRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeQuorumRequest.ApiKey)
                   .WithMinVersion(DescribeQuorumRequest.MinVersion)
                   .WithMaxVersion(DescribeQuorumRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeTopicPartitionsRequest.ApiKey)
                   .WithMinVersion(DescribeTopicPartitionsRequest.MinVersion)
                   .WithMaxVersion(DescribeTopicPartitionsRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeTransactionsRequest.ApiKey)
                   .WithMinVersion(DescribeTransactionsRequest.MinVersion)
                   .WithMaxVersion(DescribeTransactionsRequest.MaxVersion),
               key => key
                   .WithApiKey(DescribeUserScramCredentialsRequest.ApiKey)
                   .WithMinVersion(DescribeUserScramCredentialsRequest.MinVersion)
                   .WithMaxVersion(DescribeUserScramCredentialsRequest.MaxVersion),
               key => key
                   .WithApiKey(ElectLeadersRequest.ApiKey)
                   .WithMinVersion(ElectLeadersRequest.MinVersion)
                   .WithMaxVersion(ElectLeadersRequest.MaxVersion),
               key => key
                   .WithApiKey(EndQuorumEpochRequest.ApiKey)
                   .WithMinVersion(EndQuorumEpochRequest.MinVersion)
                   .WithMaxVersion(EndQuorumEpochRequest.MaxVersion),
               key => key
                   .WithApiKey(EndTxnRequest.ApiKey)
                   .WithMinVersion(EndTxnRequest.MinVersion)
                   .WithMaxVersion(EndTxnRequest.MaxVersion),
               key => key
                   .WithApiKey(EnvelopeRequest.ApiKey)
                   .WithMinVersion(EnvelopeRequest.MinVersion)
                   .WithMaxVersion(EnvelopeRequest.MaxVersion),
               key => key
                   .WithApiKey(ExpireDelegationTokenRequest.ApiKey)
                   .WithMinVersion(ExpireDelegationTokenRequest.MinVersion)
                   .WithMaxVersion(ExpireDelegationTokenRequest.MaxVersion),
               key => key
                   .WithApiKey(FetchRequest.ApiKey)
                   .WithMinVersion(FetchRequest.MinVersion)
                   .WithMaxVersion(FetchRequest.MaxVersion),
               key => key
                   .WithApiKey(FetchSnapshotRequest.ApiKey)
                   .WithMinVersion(FetchSnapshotRequest.MinVersion)
                   .WithMaxVersion(FetchSnapshotRequest.MaxVersion),
               key => key
                   .WithApiKey(FindCoordinatorRequest.ApiKey)
                   .WithMinVersion(FindCoordinatorRequest.MinVersion)
                   .WithMaxVersion(FindCoordinatorRequest.MaxVersion),
               key => key
                   .WithApiKey(GetTelemetrySubscriptionsRequest.ApiKey)
                   .WithMinVersion(GetTelemetrySubscriptionsRequest.MinVersion)
                   .WithMaxVersion(GetTelemetrySubscriptionsRequest.MaxVersion),
               key => key
                   .WithApiKey(HeartbeatRequest.ApiKey)
                   .WithMinVersion(HeartbeatRequest.MinVersion)
                   .WithMaxVersion(HeartbeatRequest.MaxVersion),
               key => key
                   .WithApiKey(IncrementalAlterConfigsRequest.ApiKey)
                   .WithMinVersion(IncrementalAlterConfigsRequest.MinVersion)
                   .WithMaxVersion(IncrementalAlterConfigsRequest.MaxVersion),
               key => key
                   .WithApiKey(InitializeShareGroupStateRequest.ApiKey)
                   .WithMinVersion(InitializeShareGroupStateRequest.MinVersion)
                   .WithMaxVersion(InitializeShareGroupStateRequest.MaxVersion),
               key => key
                   .WithApiKey(InitProducerIdRequest.ApiKey)
                   .WithMinVersion(InitProducerIdRequest.MinVersion)
                   .WithMaxVersion(InitProducerIdRequest.MaxVersion),
               key => key
                   .WithApiKey(JoinGroupRequest.ApiKey)
                   .WithMinVersion(JoinGroupRequest.MinVersion)
                   .WithMaxVersion(JoinGroupRequest.MaxVersion),
               key => key
                   .WithApiKey(LeaveGroupRequest.ApiKey)
                   .WithMinVersion(LeaveGroupRequest.MinVersion)
                   .WithMaxVersion(LeaveGroupRequest.MaxVersion),
               key => key
                   .WithApiKey(ListClientMetricsResourcesRequest.ApiKey)
                   .WithMinVersion(ListClientMetricsResourcesRequest.MinVersion)
                   .WithMaxVersion(ListClientMetricsResourcesRequest.MaxVersion),
               key => key
                   .WithApiKey(ListGroupsRequest.ApiKey)
                   .WithMinVersion(ListGroupsRequest.MinVersion)
                   .WithMaxVersion(ListGroupsRequest.MaxVersion),
               key => key
                   .WithApiKey(ListOffsetsRequest.ApiKey)
                   .WithMinVersion(ListOffsetsRequest.MinVersion)
                   .WithMaxVersion(ListOffsetsRequest.MaxVersion),
               key => key
                   .WithApiKey(ListPartitionReassignmentsRequest.ApiKey)
                   .WithMinVersion(ListPartitionReassignmentsRequest.MinVersion)
                   .WithMaxVersion(ListPartitionReassignmentsRequest.MaxVersion),
               key => key
                   .WithApiKey(ListTransactionsRequest.ApiKey)
                   .WithMinVersion(ListTransactionsRequest.MinVersion)
                   .WithMaxVersion(ListTransactionsRequest.MaxVersion),
               key => key
                   .WithApiKey(MetadataRequest.ApiKey)
                   .WithMinVersion(MetadataRequest.MinVersion)
                   .WithMaxVersion(MetadataRequest.MaxVersion),
               key => key
                   .WithApiKey(OffsetCommitRequest.ApiKey)
                   .WithMinVersion(OffsetCommitRequest.MinVersion)
                   .WithMaxVersion(OffsetCommitRequest.MaxVersion),
               key => key
                   .WithApiKey(OffsetDeleteRequest.ApiKey)
                   .WithMinVersion(OffsetDeleteRequest.MinVersion)
                   .WithMaxVersion(OffsetDeleteRequest.MaxVersion),
               key => key
                   .WithApiKey(OffsetFetchRequest.ApiKey)
                   .WithMinVersion(OffsetFetchRequest.MinVersion)
                   .WithMaxVersion(OffsetFetchRequest.MaxVersion),
               key => key
                   .WithApiKey(OffsetForLeaderEpochRequest.ApiKey)
                   .WithMinVersion(OffsetForLeaderEpochRequest.MinVersion)
                   .WithMaxVersion(OffsetForLeaderEpochRequest.MaxVersion),
               key => key
                   .WithApiKey(ProduceRequest.ApiKey)
                   .WithMinVersion(ProduceRequest.MinVersion)
                   .WithMaxVersion(ProduceRequest.MaxVersion),
               key => key
                   .WithApiKey(PushTelemetryRequest.ApiKey)
                   .WithMinVersion(PushTelemetryRequest.MinVersion)
                   .WithMaxVersion(PushTelemetryRequest.MaxVersion),
               key => key
                   .WithApiKey(ReadShareGroupStateRequest.ApiKey)
                   .WithMinVersion(ReadShareGroupStateRequest.MinVersion)
                   .WithMaxVersion(ReadShareGroupStateRequest.MaxVersion),
               key => key
                   .WithApiKey(ReadShareGroupStateSummaryRequest.ApiKey)
                   .WithMinVersion(ReadShareGroupStateSummaryRequest.MinVersion)
                   .WithMaxVersion(ReadShareGroupStateSummaryRequest.MaxVersion),
               key => key
                   .WithApiKey(RemoveRaftVoterRequest.ApiKey)
                   .WithMinVersion(RemoveRaftVoterRequest.MinVersion)
                   .WithMaxVersion(RemoveRaftVoterRequest.MaxVersion),
               key => key
                   .WithApiKey(RenewDelegationTokenRequest.ApiKey)
                   .WithMinVersion(RenewDelegationTokenRequest.MinVersion)
                   .WithMaxVersion(RenewDelegationTokenRequest.MaxVersion),
               key => key
                   .WithApiKey(SaslAuthenticateRequest.ApiKey)
                   .WithMinVersion(SaslAuthenticateRequest.MinVersion)
                   .WithMaxVersion(SaslAuthenticateRequest.MaxVersion),
               key => key
                   .WithApiKey(SaslHandshakeRequest.ApiKey)
                   .WithMinVersion(SaslHandshakeRequest.MinVersion)
                   .WithMaxVersion(SaslHandshakeRequest.MaxVersion),
               key => key
                   .WithApiKey(ShareAcknowledgeRequest.ApiKey)
                   .WithMinVersion(ShareAcknowledgeRequest.MinVersion)
                   .WithMaxVersion(ShareAcknowledgeRequest.MaxVersion),
               key => key
                   .WithApiKey(ShareFetchRequest.ApiKey)
                   .WithMinVersion(ShareFetchRequest.MinVersion)
                   .WithMaxVersion(ShareFetchRequest.MaxVersion),
               key => key
                   .WithApiKey(ShareGroupDescribeRequest.ApiKey)
                   .WithMinVersion(ShareGroupDescribeRequest.MinVersion)
                   .WithMaxVersion(ShareGroupDescribeRequest.MaxVersion),
               key => key
                   .WithApiKey(ShareGroupHeartbeatRequest.ApiKey)
                   .WithMinVersion(ShareGroupHeartbeatRequest.MinVersion)
                   .WithMaxVersion(ShareGroupHeartbeatRequest.MaxVersion),
               key => key
                   .WithApiKey(SyncGroupRequest.ApiKey)
                   .WithMinVersion(SyncGroupRequest.MinVersion)
                   .WithMaxVersion(SyncGroupRequest.MaxVersion),
               key => key
                   .WithApiKey(TxnOffsetCommitRequest.ApiKey)
                   .WithMinVersion(TxnOffsetCommitRequest.MinVersion)
                   .WithMaxVersion(TxnOffsetCommitRequest.MaxVersion),
               key => key
                   .WithApiKey(UnregisterBrokerRequest.ApiKey)
                   .WithMinVersion(UnregisterBrokerRequest.MinVersion)
                   .WithMaxVersion(UnregisterBrokerRequest.MaxVersion),
               key => key
                   .WithApiKey(UpdateFeaturesRequest.ApiKey)
                   .WithMinVersion(UpdateFeaturesRequest.MinVersion)
                   .WithMaxVersion(UpdateFeaturesRequest.MaxVersion),
               key => key
                   .WithApiKey(UpdateRaftVoterRequest.ApiKey)
                   .WithMinVersion(UpdateRaftVoterRequest.MinVersion)
                   .WithMaxVersion(UpdateRaftVoterRequest.MaxVersion),
               key => key
                   .WithApiKey(VoteRequest.ApiKey)
                   .WithMinVersion(VoteRequest.MinVersion)
                   .WithMaxVersion(VoteRequest.MaxVersion),
               key => key
                   .WithApiKey(WriteShareGroupStateRequest.ApiKey)
                   .WithMinVersion(WriteShareGroupStateRequest.MinVersion)
                   .WithMaxVersion(WriteShareGroupStateRequest.MaxVersion),
               key => key
                   .WithApiKey(WriteTxnMarkersRequest.ApiKey)
                   .WithMinVersion(WriteTxnMarkersRequest.MinVersion)
                   .WithMaxVersion(WriteTxnMarkersRequest.MaxVersion));
   }
}
