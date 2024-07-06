#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

namespace Kafka.Protocol
{
    public class FetchSnapshotRequest : Message, IRespond<FetchSnapshotResponse>
    {
        public FetchSnapshotRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"FetchSnapshotRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(59);
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
            if (_clusterIdIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 0, Field = _clusterId });
            }

            return new Tags.TagSection(tags.ToArray());
        }

        internal override int GetSize() => _replicaId.GetSize(IsFlexibleVersion) + _maxBytes.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<FetchSnapshotRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new FetchSnapshotRequest(version);
            instance.ReplicaId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MaxBytes = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<TopicSnapshot>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicSnapshot.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        case 0:
                            instance.ClusterId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        {
                            var size = instance._clusterId.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field ClusterId read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for FetchSnapshotRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _replicaId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _maxBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private bool _clusterIdIsSet;
        private NullableString _clusterId = new NullableString(null);
        /// <summary>
        /// <para>The clusterId if known, this is used to validate metadata fetches prior to broker registration</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ClusterId
        {
            get => _clusterId;
            private set
            {
                _clusterId = value;
                _clusterIdIsSet = true;
            }
        }

        /// <summary>
        /// <para>The clusterId if known, this is used to validate metadata fetches prior to broker registration</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public FetchSnapshotRequest WithClusterId(String? clusterId)
        {
            ClusterId = clusterId;
            return this;
        }

        private Int32 _replicaId = new Int32(-1);
        /// <summary>
        /// <para>The broker ID of the follower</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
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
        /// <para>The broker ID of the follower</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public FetchSnapshotRequest WithReplicaId(Int32 replicaId)
        {
            ReplicaId = replicaId;
            return this;
        }

        private Int32 _maxBytes = new Int32(0x7fffffff);
        /// <summary>
        /// <para>The maximum bytes to fetch from all of the snapshots</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 0x7fffffff</para>
        /// </summary>
        public Int32 MaxBytes
        {
            get => _maxBytes;
            private set
            {
                _maxBytes = value;
            }
        }

        /// <summary>
        /// <para>The maximum bytes to fetch from all of the snapshots</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 0x7fffffff</para>
        /// </summary>
        public FetchSnapshotRequest WithMaxBytes(Int32 maxBytes)
        {
            MaxBytes = maxBytes;
            return this;
        }

        private Array<TopicSnapshot> _topicsCollection = Array.Empty<TopicSnapshot>();
        /// <summary>
        /// <para>The topics to fetch</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<TopicSnapshot> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to fetch</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchSnapshotRequest WithTopicsCollection(params Func<TopicSnapshot, TopicSnapshot>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicSnapshot(Version))).ToArray();
            return this;
        }

        public delegate TopicSnapshot CreateTopicSnapshot(TopicSnapshot field);
        /// <summary>
        /// <para>The topics to fetch</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchSnapshotRequest WithTopicsCollection(IEnumerable<CreateTopicSnapshot> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicSnapshot(Version))).ToArray();
            return this;
        }

        public class TopicSnapshot : ISerialize
        {
            internal TopicSnapshot(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicSnapshot> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicSnapshot(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<PartitionSnapshot>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => PartitionSnapshot.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicSnapshot is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The name of the topic to fetch</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Name
            {
                get => _name;
                private set
                {
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The name of the topic to fetch</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicSnapshot WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<PartitionSnapshot> _partitionsCollection = Array.Empty<PartitionSnapshot>();
            /// <summary>
            /// <para>The partitions to fetch</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<PartitionSnapshot> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions to fetch</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicSnapshot WithPartitionsCollection(params Func<PartitionSnapshot, PartitionSnapshot>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionSnapshot(Version))).ToArray();
                return this;
            }

            public delegate PartitionSnapshot CreatePartitionSnapshot(PartitionSnapshot field);
            /// <summary>
            /// <para>The partitions to fetch</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicSnapshot WithPartitionsCollection(IEnumerable<CreatePartitionSnapshot> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionSnapshot(Version))).ToArray();
                return this;
            }

            public class PartitionSnapshot : ISerialize
            {
                internal PartitionSnapshot(Int16 version)
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
                internal int GetSize(bool _) => _partition.GetSize(IsFlexibleVersion) + _currentLeaderEpoch.GetSize(IsFlexibleVersion) + _snapshotId.GetSize(IsFlexibleVersion) + _position.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionSnapshot> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionSnapshot(version);
                    instance.Partition = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.CurrentLeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.SnapshotId_ = await SnapshotId.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                    instance.Position = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for PartitionSnapshot is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partition.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _currentLeaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _snapshotId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _position.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _partition = Int32.Default;
                /// <summary>
                /// <para>The partition index</para>
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
                /// <para>The partition index</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionSnapshot WithPartition(Int32 partition)
                {
                    Partition = partition;
                    return this;
                }

                private Int32 _currentLeaderEpoch = Int32.Default;
                /// <summary>
                /// <para>The current leader epoch of the partition, -1 for unknown leader epoch</para>
                /// <para>Versions: 0+</para>
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
                /// <para>The current leader epoch of the partition, -1 for unknown leader epoch</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionSnapshot WithCurrentLeaderEpoch(Int32 currentLeaderEpoch)
                {
                    CurrentLeaderEpoch = currentLeaderEpoch;
                    return this;
                }

                private SnapshotId _snapshotId = default !;
                /// <summary>
                /// <para>The snapshot endOffset and epoch to fetch</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public SnapshotId SnapshotId_
                {
                    get => _snapshotId;
                    private set
                    {
                        _snapshotId = value;
                    }
                }

                /// <summary>
                /// <para>The snapshot endOffset and epoch to fetch</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionSnapshot WithSnapshotId_(Func<SnapshotId, SnapshotId> createField)
                {
                    SnapshotId_ = createField(new SnapshotId(Version));
                    return this;
                }

                public class SnapshotId : ISerialize
                {
                    internal SnapshotId(Int16 version)
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
                    internal int GetSize(bool _) => _endOffset.GetSize(IsFlexibleVersion) + _epoch.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<SnapshotId> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new SnapshotId(version);
                        instance.EndOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.Epoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for SnapshotId is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        await _endOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _epoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int64 _endOffset = Int64.Default;
                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int64 EndOffset
                    {
                        get => _endOffset;
                        private set
                        {
                            _endOffset = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public SnapshotId WithEndOffset(Int64 endOffset)
                    {
                        EndOffset = endOffset;
                        return this;
                    }

                    private Int32 _epoch = Int32.Default;
                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int32 Epoch
                    {
                        get => _epoch;
                        private set
                        {
                            _epoch = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public SnapshotId WithEpoch(Int32 epoch)
                    {
                        Epoch = epoch;
                        return this;
                    }
                }

                private Int64 _position = Int64.Default;
                /// <summary>
                /// <para>The byte position within the snapshot to start fetching from</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 Position
                {
                    get => _position;
                    private set
                    {
                        _position = value;
                    }
                }

                /// <summary>
                /// <para>The byte position within the snapshot to start fetching from</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionSnapshot WithPosition(Int64 position)
                {
                    Position = position;
                    return this;
                }
            }
        }

        public FetchSnapshotResponse Respond() => new FetchSnapshotResponse(Version);
    }
}
