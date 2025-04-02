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
    public class OffsetForLeaderEpochRequest : Message, IRespond<OffsetForLeaderEpochResponse>
    {
        public OffsetForLeaderEpochRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"OffsetForLeaderEpochRequest does not support version {version}. Valid versions are: 2-4");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(23);
        public static readonly Int16 MinVersion = Int16.From(2);
        public static readonly Int16 MaxVersion = Int16.From(4);
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

        internal override int GetSize() => (Version >= 3 ? _replicaId.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<OffsetForLeaderEpochRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new OffsetForLeaderEpochRequest(version);
            if (instance.Version >= 3)
                instance.ReplicaId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Map<String, OffsetForLeaderTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetForLeaderTopic.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Topic, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetForLeaderEpochRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 3)
                await _replicaId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _replicaId = new Int32(-2);
        /// <summary>
        /// <para>The broker ID of the follower, of -1 if this request is from a consumer.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -2</para>
        /// </summary>
        public Int32 ReplicaId
        {
            get => _replicaId;
            private set
            {
                _replicaId = value;
            }
        }

        /// <summary>
        /// <para>The broker ID of the follower, of -1 if this request is from a consumer.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -2</para>
        /// </summary>
        public OffsetForLeaderEpochRequest WithReplicaId(Int32 replicaId)
        {
            ReplicaId = replicaId;
            return this;
        }

        private Map<String, OffsetForLeaderTopic> _topicsCollection = Map<String, OffsetForLeaderTopic>.Default;
        /// <summary>
        /// <para>Each topic to get offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, OffsetForLeaderTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic to get offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public OffsetForLeaderEpochRequest WithTopicsCollection(params Func<OffsetForLeaderTopic, OffsetForLeaderTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetForLeaderTopic(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public delegate OffsetForLeaderTopic CreateOffsetForLeaderTopic(OffsetForLeaderTopic field);
        /// <summary>
        /// <para>Each topic to get offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public OffsetForLeaderEpochRequest WithTopicsCollection(IEnumerable<CreateOffsetForLeaderTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetForLeaderTopic(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public class OffsetForLeaderTopic : ISerialize
        {
            internal OffsetForLeaderTopic(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 4;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _topic.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<OffsetForLeaderTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new OffsetForLeaderTopic(version);
                instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<OffsetForLeaderPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetForLeaderPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetForLeaderTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topic = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Topic
            {
                get => _topic;
                private set
                {
                    _topic = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetForLeaderTopic WithTopic(String topic)
            {
                Topic = topic;
                return this;
            }

            private Array<OffsetForLeaderPartition> _partitionsCollection = Array.Empty<OffsetForLeaderPartition>();
            /// <summary>
            /// <para>Each partition to get offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<OffsetForLeaderPartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition to get offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetForLeaderTopic WithPartitionsCollection(params Func<OffsetForLeaderPartition, OffsetForLeaderPartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new OffsetForLeaderPartition(Version))).ToArray();
                return this;
            }

            public delegate OffsetForLeaderPartition CreateOffsetForLeaderPartition(OffsetForLeaderPartition field);
            /// <summary>
            /// <para>Each partition to get offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetForLeaderTopic WithPartitionsCollection(IEnumerable<CreateOffsetForLeaderPartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new OffsetForLeaderPartition(Version))).ToArray();
                return this;
            }

            public class OffsetForLeaderPartition : ISerialize
            {
                internal OffsetForLeaderPartition(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 4;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _partition.GetSize(IsFlexibleVersion) + (Version >= 2 ? _currentLeaderEpoch.GetSize(IsFlexibleVersion) : 0) + _leaderEpoch.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<OffsetForLeaderPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new OffsetForLeaderPartition(version);
                    instance.Partition = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 2)
                        instance.CurrentLeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetForLeaderPartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partition.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 2)
                        await _currentLeaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _partition = Int32.Default;
                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 Partition
                {
                    get => _partition;
                    private set
                    {
                        _partition = value;
                    }
                }

                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public OffsetForLeaderPartition WithPartition(Int32 partition)
                {
                    Partition = partition;
                    return this;
                }

                private Int32 _currentLeaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>An epoch used to fence consumers/replicas with old metadata. If the epoch provided by the client is larger than the current epoch known to the broker, then the UNKNOWN_LEADER_EPOCH error code will be returned. If the provided epoch is smaller, then the FENCED_LEADER_EPOCH error code will be returned.</para>
                /// <para>Versions: 2+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int32 CurrentLeaderEpoch
                {
                    get => _currentLeaderEpoch;
                    private set
                    {
                        _currentLeaderEpoch = value;
                    }
                }

                /// <summary>
                /// <para>An epoch used to fence consumers/replicas with old metadata. If the epoch provided by the client is larger than the current epoch known to the broker, then the UNKNOWN_LEADER_EPOCH error code will be returned. If the provided epoch is smaller, then the FENCED_LEADER_EPOCH error code will be returned.</para>
                /// <para>Versions: 2+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public OffsetForLeaderPartition WithCurrentLeaderEpoch(Int32 currentLeaderEpoch)
                {
                    CurrentLeaderEpoch = currentLeaderEpoch;
                    return this;
                }

                private Int32 _leaderEpoch = Int32.Default;
                /// <summary>
                /// <para>The epoch to look up an offset for.</para>
                /// <para>Versions: 0+</para>
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
                /// <para>The epoch to look up an offset for.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public OffsetForLeaderPartition WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }
            }
        }

        public OffsetForLeaderEpochResponse Respond() => new OffsetForLeaderEpochResponse(Version);
    }
}
