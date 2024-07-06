#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

namespace Kafka.Protocol
{
    public class ConsumerGroupHeartbeatRequest : Message, IRespond<ConsumerGroupHeartbeatResponse>
    {
        public ConsumerGroupHeartbeatRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ConsumerGroupHeartbeatRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(68);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
        public override Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        // https://github.com/apache/kafka/blob/99b9b3e84f4e98c3f07714e1de6a139a004cbc5b/generator/src/main/java/org/apache/kafka/message/ApiMessageTypeGenerator.java#L324
        public Int16 HeaderVersion
        {
            get
            {
                return (short)(IsFlexibleVersion ? 2 : 1);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + _memberId.GetSize(IsFlexibleVersion) + _memberEpoch.GetSize(IsFlexibleVersion) + _instanceId.GetSize(IsFlexibleVersion) + _rackId.GetSize(IsFlexibleVersion) + _rebalanceTimeoutMs.GetSize(IsFlexibleVersion) + _subscribedTopicNamesCollection.GetSize(IsFlexibleVersion) + _serverAssignor.GetSize(IsFlexibleVersion) + _topicPartitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ConsumerGroupHeartbeatRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ConsumerGroupHeartbeatRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.InstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.RackId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.RebalanceTimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.SubscribedTopicNamesCollection = await NullableArray<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ServerAssignor = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicPartitionsCollection = await NullableArray<TopicPartitions>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicPartitions.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ConsumerGroupHeartbeatRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _instanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _rackId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _rebalanceTimeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _subscribedTopicNamesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _serverAssignor.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicPartitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _groupId = String.Default;
        /// <summary>
        /// <para>The group identifier.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String GroupId
        {
            get => _groupId;
            private set
            {
                _groupId = value;
            }
        }

        /// <summary>
        /// <para>The group identifier.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ConsumerGroupHeartbeatRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The member id generated by the coordinator. The member id must be kept during the entire lifetime of the member.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String MemberId
        {
            get => _memberId;
            private set
            {
                _memberId = value;
            }
        }

        /// <summary>
        /// <para>The member id generated by the coordinator. The member id must be kept during the entire lifetime of the member.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ConsumerGroupHeartbeatRequest WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private Int32 _memberEpoch = Int32.Default;
        /// <summary>
        /// <para>The current member epoch; 0 to join the group; -1 to leave the group; -2 to indicate that the static member will rejoin.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 MemberEpoch
        {
            get => _memberEpoch;
            private set
            {
                _memberEpoch = value;
            }
        }

        /// <summary>
        /// <para>The current member epoch; 0 to join the group; -1 to leave the group; -2 to indicate that the static member will rejoin.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ConsumerGroupHeartbeatRequest WithMemberEpoch(Int32 memberEpoch)
        {
            MemberEpoch = memberEpoch;
            return this;
        }

        private NullableString _instanceId = new NullableString(null);
        /// <summary>
        /// <para>null if not provided or if it didn't change since the last heartbeat; the instance Id otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? InstanceId
        {
            get => _instanceId;
            private set
            {
                _instanceId = value;
            }
        }

        /// <summary>
        /// <para>null if not provided or if it didn't change since the last heartbeat; the instance Id otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ConsumerGroupHeartbeatRequest WithInstanceId(String? instanceId)
        {
            InstanceId = instanceId;
            return this;
        }

        private NullableString _rackId = new NullableString(null);
        /// <summary>
        /// <para>null if not provided or if it didn't change since the last heartbeat; the rack ID of consumer otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? RackId
        {
            get => _rackId;
            private set
            {
                _rackId = value;
            }
        }

        /// <summary>
        /// <para>null if not provided or if it didn't change since the last heartbeat; the rack ID of consumer otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ConsumerGroupHeartbeatRequest WithRackId(String? rackId)
        {
            RackId = rackId;
            return this;
        }

        private Int32 _rebalanceTimeoutMs = new Int32(-1);
        /// <summary>
        /// <para>-1 if it didn't change since the last heartbeat; the maximum time in milliseconds that the coordinator will wait on the member to revoke its partitions otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int32 RebalanceTimeoutMs
        {
            get => _rebalanceTimeoutMs;
            private set
            {
                _rebalanceTimeoutMs = value;
            }
        }

        /// <summary>
        /// <para>-1 if it didn't change since the last heartbeat; the maximum time in milliseconds that the coordinator will wait on the member to revoke its partitions otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public ConsumerGroupHeartbeatRequest WithRebalanceTimeoutMs(Int32 rebalanceTimeoutMs)
        {
            RebalanceTimeoutMs = rebalanceTimeoutMs;
            return this;
        }

        private NullableArray<String> _subscribedTopicNamesCollection = new NullableArray<String>(null);
        /// <summary>
        /// <para>null if it didn't change since the last heartbeat; the subscribed topic names otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<String>? SubscribedTopicNamesCollection
        {
            get => _subscribedTopicNamesCollection;
            private set
            {
                _subscribedTopicNamesCollection = value;
            }
        }

        /// <summary>
        /// <para>null if it didn't change since the last heartbeat; the subscribed topic names otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ConsumerGroupHeartbeatRequest WithSubscribedTopicNamesCollection(Array<String>? subscribedTopicNamesCollection)
        {
            SubscribedTopicNamesCollection = subscribedTopicNamesCollection;
            return this;
        }

        private NullableString _serverAssignor = new NullableString(null);
        /// <summary>
        /// <para>null if not used or if it didn't change since the last heartbeat; the server side assignor to use otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ServerAssignor
        {
            get => _serverAssignor;
            private set
            {
                _serverAssignor = value;
            }
        }

        /// <summary>
        /// <para>null if not used or if it didn't change since the last heartbeat; the server side assignor to use otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ConsumerGroupHeartbeatRequest WithServerAssignor(String? serverAssignor)
        {
            ServerAssignor = serverAssignor;
            return this;
        }

        private NullableArray<TopicPartitions> _topicPartitionsCollection = new NullableArray<TopicPartitions>(null);
        /// <summary>
        /// <para>null if it didn't change since the last heartbeat; the partitions owned by the member.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<TopicPartitions>? TopicPartitionsCollection
        {
            get => _topicPartitionsCollection;
            private set
            {
                _topicPartitionsCollection = value;
            }
        }

        /// <summary>
        /// <para>null if it didn't change since the last heartbeat; the partitions owned by the member.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ConsumerGroupHeartbeatRequest WithTopicPartitionsCollection(params Func<TopicPartitions, TopicPartitions>[] createFields)
        {
            TopicPartitionsCollection = createFields.Select(createField => createField(new TopicPartitions(Version))).ToArray();
            return this;
        }

        public delegate TopicPartitions CreateTopicPartitions(TopicPartitions field);
        /// <summary>
        /// <para>null if it didn't change since the last heartbeat; the partitions owned by the member.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ConsumerGroupHeartbeatRequest WithTopicPartitionsCollection(IEnumerable<CreateTopicPartitions> createFields)
        {
            TopicPartitionsCollection = createFields.Select(createField => createField(new TopicPartitions(Version))).ToArray();
            return this;
        }

        public class TopicPartitions : ISerialize
        {
            internal TopicPartitions(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = true;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _topicId.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicPartitions> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicPartitions(version);
                instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicPartitions is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The topic ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Uuid TopicId
            {
                get => _topicId;
                private set
                {
                    _topicId = value;
                }
            }

            /// <summary>
            /// <para>The topic ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartitions WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<Int32> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartitions WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        public ConsumerGroupHeartbeatResponse Respond() => new ConsumerGroupHeartbeatResponse(Version);
    }
}
