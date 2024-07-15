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
    public class FetchSnapshotResponse : Message
    {
        public FetchSnapshotResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"FetchSnapshotResponse does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(59);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(1);
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
            var tags = new List<Tags.TaggedField>();
            if (Version >= 1 && _nodeEndpointsCollectionIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 0, Field = _nodeEndpointsCollection });
            }

            return new Tags.TagSection(tags.ToArray());
        }

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<FetchSnapshotResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new FetchSnapshotResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<TopicSnapshot>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicSnapshot.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        case 0:
                            if (instance.Version >= 1)
                                instance.NodeEndpointsCollection = await Map<Int32, NodeEndpoint>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => NodeEndpoint.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.NodeId, cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field NodeEndpointsCollection is not supported for version {instance.Version}");
                        {
                            var size = instance._nodeEndpointsCollection.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field NodeEndpointsCollection read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for FetchSnapshotResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public FetchSnapshotResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The top level response error code.</para>
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
        /// <para>The top level response error code.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchSnapshotResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<TopicSnapshot> _topicsCollection = Array.Empty<TopicSnapshot>();
        /// <summary>
        /// <para>The topics to fetch.</para>
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
        /// <para>The topics to fetch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchSnapshotResponse WithTopicsCollection(params Func<TopicSnapshot, TopicSnapshot>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicSnapshot(Version))).ToArray();
            return this;
        }

        public delegate TopicSnapshot CreateTopicSnapshot(TopicSnapshot field);
        /// <summary>
        /// <para>The topics to fetch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchSnapshotResponse WithTopicsCollection(IEnumerable<CreateTopicSnapshot> createFields)
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
            /// <para>The name of the topic to fetch.</para>
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
            /// <para>The name of the topic to fetch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicSnapshot WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<PartitionSnapshot> _partitionsCollection = Array.Empty<PartitionSnapshot>();
            /// <summary>
            /// <para>The partitions to fetch.</para>
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
            /// <para>The partitions to fetch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicSnapshot WithPartitionsCollection(params Func<PartitionSnapshot, PartitionSnapshot>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionSnapshot(Version))).ToArray();
                return this;
            }

            public delegate PartitionSnapshot CreatePartitionSnapshot(PartitionSnapshot field);
            /// <summary>
            /// <para>The partitions to fetch.</para>
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
                    var tags = new List<Tags.TaggedField>();
                    if (_currentLeaderIsSet)
                    {
                        tags.Add(new Tags.TaggedField { Tag = 0, Field = _currentLeader });
                    }

                    return new Tags.TagSection(tags.ToArray());
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _index.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _snapshotId.GetSize(IsFlexibleVersion) + _size.GetSize(IsFlexibleVersion) + _position.GetSize(IsFlexibleVersion) + _unalignedRecords.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionSnapshot> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionSnapshot(version);
                    instance.Index = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.SnapshotId_ = await SnapshotId.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                    instance.Size = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Position = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.UnalignedRecords = await RecordBatch.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                case 0:
                                    instance.CurrentLeader = await LeaderIdAndEpoch.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                                {
                                    var size = instance._currentLeader.GetSize(true);
                                    if (size != tag.Length)
                                        throw new CorruptMessageException($"Tagged field CurrentLeader read length {tag.Length} but had actual length of {size}");
                                }

                                    break;
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
                    await _index.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _snapshotId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _size.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _position.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _unalignedRecords.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _index = Int32.Default;
                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 Index
                {
                    get => _index;
                    private set
                    {
                        _index = value;
                    }
                }

                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionSnapshot WithIndex(Int32 index)
                {
                    Index = index;
                    return this;
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The error code, or 0 if there was no fetch error.</para>
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
                /// <para>The error code, or 0 if there was no fetch error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionSnapshot WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private SnapshotId _snapshotId = default !;
                /// <summary>
                /// <para>The snapshot endOffset and epoch fetched</para>
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
                /// <para>The snapshot endOffset and epoch fetched</para>
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

                private bool _currentLeaderIsSet;
                private LeaderIdAndEpoch _currentLeader = default !;
                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public LeaderIdAndEpoch CurrentLeader
                {
                    get => _currentLeader;
                    private set
                    {
                        _currentLeader = value;
                        _currentLeaderIsSet = true;
                    }
                }

                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionSnapshot WithCurrentLeader(Func<LeaderIdAndEpoch, LeaderIdAndEpoch> createField)
                {
                    CurrentLeader = createField(new LeaderIdAndEpoch(Version));
                    return this;
                }

                public class LeaderIdAndEpoch : ISerialize
                {
                    internal LeaderIdAndEpoch(Int16 version)
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
                    internal int GetSize(bool _) => _leaderId.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<LeaderIdAndEpoch> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new LeaderIdAndEpoch(version);
                        instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderIdAndEpoch is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int32 _leaderId = Int32.Default;
                    /// <summary>
                    /// <para>The ID of the current leader or -1 if the leader is unknown.</para>
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
                    /// <para>The ID of the current leader or -1 if the leader is unknown.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public LeaderIdAndEpoch WithLeaderId(Int32 leaderId)
                    {
                        LeaderId = leaderId;
                        return this;
                    }

                    private Int32 _leaderEpoch = Int32.Default;
                    /// <summary>
                    /// <para>The latest known leader epoch</para>
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
                    /// <para>The latest known leader epoch</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public LeaderIdAndEpoch WithLeaderEpoch(Int32 leaderEpoch)
                    {
                        LeaderEpoch = leaderEpoch;
                        return this;
                    }
                }

                private Int64 _size = Int64.Default;
                /// <summary>
                /// <para>The total size of the snapshot.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 Size
                {
                    get => _size;
                    private set
                    {
                        _size = value;
                    }
                }

                /// <summary>
                /// <para>The total size of the snapshot.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionSnapshot WithSize(Int64 size)
                {
                    Size = size;
                    return this;
                }

                private Int64 _position = Int64.Default;
                /// <summary>
                /// <para>The starting byte position within the snapshot included in the Bytes field.</para>
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
                /// <para>The starting byte position within the snapshot included in the Bytes field.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionSnapshot WithPosition(Int64 position)
                {
                    Position = position;
                    return this;
                }

                private RecordBatch _unalignedRecords = RecordBatch.Default;
                /// <summary>
                /// <para>Snapshot data in records format which may not be aligned on an offset boundary</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public RecordBatch UnalignedRecords
                {
                    get => _unalignedRecords;
                    private set
                    {
                        _unalignedRecords = value;
                    }
                }

                /// <summary>
                /// <para>Snapshot data in records format which may not be aligned on an offset boundary</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionSnapshot WithUnalignedRecords(RecordBatch unalignedRecords)
                {
                    UnalignedRecords = unalignedRecords;
                    return this;
                }
            }
        }

        private bool _nodeEndpointsCollectionIsSet;
        private Map<Int32, NodeEndpoint> _nodeEndpointsCollection = Map<Int32, NodeEndpoint>.Default;
        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionSnapshot</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public Map<Int32, NodeEndpoint> NodeEndpointsCollection
        {
            get => _nodeEndpointsCollection;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"NodeEndpointsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _nodeEndpointsCollection = value;
                _nodeEndpointsCollectionIsSet = true;
            }
        }

        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionSnapshot</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public FetchSnapshotResponse WithNodeEndpointsCollection(params Func<NodeEndpoint, NodeEndpoint>[] createFields)
        {
            NodeEndpointsCollection = createFields.Select(createField => createField(new NodeEndpoint(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public delegate NodeEndpoint CreateNodeEndpoint(NodeEndpoint field);
        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionSnapshot</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public FetchSnapshotResponse WithNodeEndpointsCollection(IEnumerable<CreateNodeEndpoint> createFields)
        {
            NodeEndpointsCollection = createFields.Select(createField => createField(new NodeEndpoint(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public class NodeEndpoint : ISerialize
        {
            internal NodeEndpoint(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 1 ? _nodeId.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _host.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _port.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<NodeEndpoint> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new NodeEndpoint(version);
                if (instance.Version >= 1)
                    instance.NodeId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.Port = await UInt16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for NodeEndpoint is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 1)
                    await _nodeId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _nodeId = Int32.Default;
            /// <summary>
            /// <para>The ID of the associated node</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public Int32 NodeId
            {
                get => _nodeId;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"NodeId does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _nodeId = value;
                }
            }

            /// <summary>
            /// <para>The ID of the associated node</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public NodeEndpoint WithNodeId(Int32 nodeId)
            {
                NodeId = nodeId;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The node's hostname</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public String Host
            {
                get => _host;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _host = value;
                }
            }

            /// <summary>
            /// <para>The node's hostname</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public NodeEndpoint WithHost(String host)
            {
                Host = host;
                return this;
            }

            private UInt16 _port = UInt16.Default;
            /// <summary>
            /// <para>The node's port</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public UInt16 Port
            {
                get => _port;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _port = value;
                }
            }

            /// <summary>
            /// <para>The node's port</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public NodeEndpoint WithPort(UInt16 port)
            {
                Port = port;
                return this;
            }
        }
    }
}
