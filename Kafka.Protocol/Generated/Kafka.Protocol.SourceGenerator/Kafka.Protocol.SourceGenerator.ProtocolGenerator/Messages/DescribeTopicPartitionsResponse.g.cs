#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

// ReSharper disable MemberHidesStaticFromOuterClass FromReaderAsync will cause a lot of these warnings
namespace Kafka.Protocol
{
    public class DescribeTopicPartitionsResponse : Message
    {
        public DescribeTopicPartitionsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeTopicPartitionsResponse does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(75);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
        public override Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        // https://github.com/apache/kafka/blob/99b9b3e84f4e98c3f07714e1de6a139a004cbc5b/generator/src/main/java/org/apache/kafka/message/ApiMessageTypeGenerator.java#L324
        public Int16 HeaderVersion
        {
            get
            {
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + _nextCursor.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeTopicPartitionsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeTopicPartitionsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Map<NullableString, DescribeTopicPartitionsResponseTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeTopicPartitionsResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            instance.NextCursor = await Nullable<Cursor>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Cursor.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeTopicPartitionsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _nextCursor.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 ThrottleTimeMs
        {
            get => _throttleTimeMs;
            private set
            {
                _throttleTimeMs = value;
            }
        }

        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeTopicPartitionsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Map<NullableString, DescribeTopicPartitionsResponseTopic> _topicsCollection = Map<NullableString, DescribeTopicPartitionsResponseTopic>.Default;
        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<NullableString, DescribeTopicPartitionsResponseTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeTopicPartitionsResponse WithTopicsCollection(params Func<DescribeTopicPartitionsResponseTopic, DescribeTopicPartitionsResponseTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new DescribeTopicPartitionsResponseTopic(Version))).ToDictionary(field => (NullableString)field.Name);
            return this;
        }

        public delegate DescribeTopicPartitionsResponseTopic CreateDescribeTopicPartitionsResponseTopic(DescribeTopicPartitionsResponseTopic field);
        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeTopicPartitionsResponse WithTopicsCollection(IEnumerable<CreateDescribeTopicPartitionsResponseTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new DescribeTopicPartitionsResponseTopic(Version))).ToDictionary(field => (NullableString)field.Name);
            return this;
        }

        public class DescribeTopicPartitionsResponseTopic : ISerialize
        {
            internal DescribeTopicPartitionsResponseTopic(Int16 version)
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
            internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _name.GetSize(IsFlexibleVersion) + _topicId.GetSize(IsFlexibleVersion) + _isInternal.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + _topicAuthorizedOperations.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribeTopicPartitionsResponseTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribeTopicPartitionsResponseTopic(version);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Name = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.IsInternal = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<DescribeTopicPartitionsResponsePartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeTopicPartitionsResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.TopicAuthorizedOperations = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeTopicPartitionsResponseTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _isInternal.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _topicAuthorizedOperations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The topic error, or 0 if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 ErrorCode
            {
                get => _errorCode;
                private set
                {
                    _errorCode = value;
                }
            }

            /// <summary>
            /// <para>The topic error, or 0 if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeTopicPartitionsResponseTopic WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _name = NullableString.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String? Name
            {
                get => _name;
                private set
                {
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeTopicPartitionsResponseTopic WithName(String? name)
            {
                Name = name;
                return this;
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The topic id.</para>
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
            /// <para>The topic id.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeTopicPartitionsResponseTopic WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Boolean _isInternal = new Boolean(false);
            /// <summary>
            /// <para>True if the topic is internal.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: false</para>
            /// </summary>
            public Boolean IsInternal
            {
                get => _isInternal;
                private set
                {
                    _isInternal = value;
                }
            }

            /// <summary>
            /// <para>True if the topic is internal.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: false</para>
            /// </summary>
            public DescribeTopicPartitionsResponseTopic WithIsInternal(Boolean isInternal)
            {
                IsInternal = isInternal;
                return this;
            }

            private Array<DescribeTopicPartitionsResponsePartition> _partitionsCollection = Array.Empty<DescribeTopicPartitionsResponsePartition>();
            /// <summary>
            /// <para>Each partition in the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<DescribeTopicPartitionsResponsePartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition in the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeTopicPartitionsResponseTopic WithPartitionsCollection(params Func<DescribeTopicPartitionsResponsePartition, DescribeTopicPartitionsResponsePartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new DescribeTopicPartitionsResponsePartition(Version))).ToArray();
                return this;
            }

            public delegate DescribeTopicPartitionsResponsePartition CreateDescribeTopicPartitionsResponsePartition(DescribeTopicPartitionsResponsePartition field);
            /// <summary>
            /// <para>Each partition in the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeTopicPartitionsResponseTopic WithPartitionsCollection(IEnumerable<CreateDescribeTopicPartitionsResponsePartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new DescribeTopicPartitionsResponsePartition(Version))).ToArray();
                return this;
            }

            public class DescribeTopicPartitionsResponsePartition : ISerialize
            {
                internal DescribeTopicPartitionsResponsePartition(Int16 version)
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
                internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _partitionIndex.GetSize(IsFlexibleVersion) + _leaderId.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + _replicaNodesCollection.GetSize(IsFlexibleVersion) + _isrNodesCollection.GetSize(IsFlexibleVersion) + _eligibleLeaderReplicasCollection.GetSize(IsFlexibleVersion) + _lastKnownElrCollection.GetSize(IsFlexibleVersion) + _offlineReplicasCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<DescribeTopicPartitionsResponsePartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new DescribeTopicPartitionsResponsePartition(version);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ReplicaNodesCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.IsrNodesCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.EligibleLeaderReplicasCollection = await NullableArray<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.LastKnownElrCollection = await NullableArray<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.OfflineReplicasCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeTopicPartitionsResponsePartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _replicaNodesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _isrNodesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _eligibleLeaderReplicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _lastKnownElrCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _offlineReplicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The partition error, or 0 if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int16 ErrorCode
                {
                    get => _errorCode;
                    private set
                    {
                        _errorCode = value;
                    }
                }

                /// <summary>
                /// <para>The partition error, or 0 if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeTopicPartitionsResponsePartition WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private Int32 _partitionIndex = Int32.Default;
                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 PartitionIndex
                {
                    get => _partitionIndex;
                    private set
                    {
                        _partitionIndex = value;
                    }
                }

                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeTopicPartitionsResponsePartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int32 _leaderId = Int32.Default;
                /// <summary>
                /// <para>The ID of the leader broker.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 LeaderId
                {
                    get => _leaderId;
                    private set
                    {
                        _leaderId = value;
                    }
                }

                /// <summary>
                /// <para>The ID of the leader broker.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeTopicPartitionsResponsePartition WithLeaderId(Int32 leaderId)
                {
                    LeaderId = leaderId;
                    return this;
                }

                private Int32 _leaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>The leader epoch of this partition.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int32 LeaderEpoch
                {
                    get => _leaderEpoch;
                    private set
                    {
                        _leaderEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The leader epoch of this partition.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public DescribeTopicPartitionsResponsePartition WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }

                private Array<Int32> _replicaNodesCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The set of all nodes that host this partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> ReplicaNodesCollection
                {
                    get => _replicaNodesCollection;
                    private set
                    {
                        _replicaNodesCollection = value;
                    }
                }

                /// <summary>
                /// <para>The set of all nodes that host this partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeTopicPartitionsResponsePartition WithReplicaNodesCollection(Array<Int32> replicaNodesCollection)
                {
                    ReplicaNodesCollection = replicaNodesCollection;
                    return this;
                }

                private Array<Int32> _isrNodesCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The set of nodes that are in sync with the leader for this partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> IsrNodesCollection
                {
                    get => _isrNodesCollection;
                    private set
                    {
                        _isrNodesCollection = value;
                    }
                }

                /// <summary>
                /// <para>The set of nodes that are in sync with the leader for this partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeTopicPartitionsResponsePartition WithIsrNodesCollection(Array<Int32> isrNodesCollection)
                {
                    IsrNodesCollection = isrNodesCollection;
                    return this;
                }

                private NullableArray<Int32> _eligibleLeaderReplicasCollection = new NullableArray<Int32>(null);
                /// <summary>
                /// <para>The new eligible leader replicas otherwise.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Array<Int32>? EligibleLeaderReplicasCollection
                {
                    get => _eligibleLeaderReplicasCollection;
                    private set
                    {
                        _eligibleLeaderReplicasCollection = value;
                    }
                }

                /// <summary>
                /// <para>The new eligible leader replicas otherwise.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public DescribeTopicPartitionsResponsePartition WithEligibleLeaderReplicasCollection(Array<Int32>? eligibleLeaderReplicasCollection)
                {
                    EligibleLeaderReplicasCollection = eligibleLeaderReplicasCollection;
                    return this;
                }

                private NullableArray<Int32> _lastKnownElrCollection = new NullableArray<Int32>(null);
                /// <summary>
                /// <para>The last known ELR.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Array<Int32>? LastKnownElrCollection
                {
                    get => _lastKnownElrCollection;
                    private set
                    {
                        _lastKnownElrCollection = value;
                    }
                }

                /// <summary>
                /// <para>The last known ELR.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public DescribeTopicPartitionsResponsePartition WithLastKnownElrCollection(Array<Int32>? lastKnownElrCollection)
                {
                    LastKnownElrCollection = lastKnownElrCollection;
                    return this;
                }

                private Array<Int32> _offlineReplicasCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The set of offline replicas of this partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> OfflineReplicasCollection
                {
                    get => _offlineReplicasCollection;
                    private set
                    {
                        _offlineReplicasCollection = value;
                    }
                }

                /// <summary>
                /// <para>The set of offline replicas of this partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeTopicPartitionsResponsePartition WithOfflineReplicasCollection(Array<Int32> offlineReplicasCollection)
                {
                    OfflineReplicasCollection = offlineReplicasCollection;
                    return this;
                }
            }

            private Int32 _topicAuthorizedOperations = new Int32(-2147483648);
            /// <summary>
            /// <para>32-bit bitfield to represent authorized operations for this topic.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: -2147483648</para>
            /// </summary>
            public Int32 TopicAuthorizedOperations
            {
                get => _topicAuthorizedOperations;
                private set
                {
                    _topicAuthorizedOperations = value;
                }
            }

            /// <summary>
            /// <para>32-bit bitfield to represent authorized operations for this topic.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: -2147483648</para>
            /// </summary>
            public DescribeTopicPartitionsResponseTopic WithTopicAuthorizedOperations(Int32 topicAuthorizedOperations)
            {
                TopicAuthorizedOperations = topicAuthorizedOperations;
                return this;
            }
        }

        private Nullable<Cursor> _nextCursor = new Nullable<Cursor>(null);
        /// <summary>
        /// <para>The next topic and partition index to fetch details for.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Cursor? NextCursor
        {
            get => _nextCursor;
            private set
            {
                _nextCursor = value;
            }
        }

        /// <summary>
        /// <para>The next topic and partition index to fetch details for.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public DescribeTopicPartitionsResponse WithNextCursor(Func<Cursor?, Cursor?> createField)
        {
            NextCursor = createField(new Cursor(Version));
            return this;
        }

        public class Cursor : ISerialize
        {
            internal Cursor(Int16 version)
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
            internal int GetSize(bool _) => _topicName.GetSize(IsFlexibleVersion) + _partitionIndex.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Cursor> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Cursor(version);
                instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Cursor is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The name for the first topic to process.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String TopicName
            {
                get => _topicName;
                private set
                {
                    _topicName = value;
                }
            }

            /// <summary>
            /// <para>The name for the first topic to process.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Cursor WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Int32 _partitionIndex = Int32.Default;
            /// <summary>
            /// <para>The partition index to start with.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 PartitionIndex
            {
                get => _partitionIndex;
                private set
                {
                    _partitionIndex = value;
                }
            }

            /// <summary>
            /// <para>The partition index to start with.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Cursor WithPartitionIndex(Int32 partitionIndex)
            {
                PartitionIndex = partitionIndex;
                return this;
            }
        }
    }
}
