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
    public class WriteShareGroupStateRequest : Message, IRespond<WriteShareGroupStateResponse>
    {
        public WriteShareGroupStateRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"WriteShareGroupStateRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(85);
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

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<WriteShareGroupStateRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new WriteShareGroupStateRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<WriteStateData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => WriteStateData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for WriteShareGroupStateRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public WriteShareGroupStateRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private Array<WriteStateData> _topicsCollection = Array.Empty<WriteStateData>();
        /// <summary>
        /// <para>The data for the topics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<WriteStateData> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The data for the topics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public WriteShareGroupStateRequest WithTopicsCollection(params Func<WriteStateData, WriteStateData>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new WriteStateData(Version))).ToArray();
            return this;
        }

        public delegate WriteStateData CreateWriteStateData(WriteStateData field);
        /// <summary>
        /// <para>The data for the topics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public WriteShareGroupStateRequest WithTopicsCollection(IEnumerable<CreateWriteStateData> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new WriteStateData(Version))).ToArray();
            return this;
        }

        public class WriteStateData : ISerialize
        {
            internal WriteStateData(Int16 version)
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
            internal static async ValueTask<WriteStateData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new WriteStateData(version);
                instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<PartitionData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => PartitionData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for WriteStateData is unknown");
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
            /// <para>The topic identifier.</para>
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
            /// <para>The topic identifier.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WriteStateData WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<PartitionData> _partitionsCollection = Array.Empty<PartitionData>();
            /// <summary>
            /// <para>The data for the partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<PartitionData> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The data for the partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WriteStateData WithPartitionsCollection(params Func<PartitionData, PartitionData>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionData(Version))).ToArray();
                return this;
            }

            public delegate PartitionData CreatePartitionData(PartitionData field);
            /// <summary>
            /// <para>The data for the partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WriteStateData WithPartitionsCollection(IEnumerable<CreatePartitionData> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionData(Version))).ToArray();
                return this;
            }

            public class PartitionData : ISerialize
            {
                internal PartitionData(Int16 version)
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
                internal int GetSize(bool _) => _partition.GetSize(IsFlexibleVersion) + _stateEpoch.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + _startOffset.GetSize(IsFlexibleVersion) + _stateBatchesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionData(version);
                    instance.Partition = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.StateEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.StartOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.StateBatchesCollection = await Array<StateBatch>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => StateBatch.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for PartitionData is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partition.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _stateEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _startOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _stateBatchesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public PartitionData WithPartition(Int32 partition)
                {
                    Partition = partition;
                    return this;
                }

                private Int32 _stateEpoch = Int32.Default;
                /// <summary>
                /// <para>The state epoch for this share-partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 StateEpoch
                {
                    get => _stateEpoch;
                    private set
                    {
                        _stateEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The state epoch for this share-partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithStateEpoch(Int32 stateEpoch)
                {
                    StateEpoch = stateEpoch;
                    return this;
                }

                private Int32 _leaderEpoch = Int32.Default;
                /// <summary>
                /// <para>The leader epoch of the share-partition.</para>
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
                /// <para>The leader epoch of the share-partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }

                private Int64 _startOffset = Int64.Default;
                /// <summary>
                /// <para>The share-partition start offset, or -1 if the start offset is not being written.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 StartOffset
                {
                    get => _startOffset;
                    private set
                    {
                        _startOffset = value;
                    }
                }

                /// <summary>
                /// <para>The share-partition start offset, or -1 if the start offset is not being written.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithStartOffset(Int64 startOffset)
                {
                    StartOffset = startOffset;
                    return this;
                }

                private Array<StateBatch> _stateBatchesCollection = Array.Empty<StateBatch>();
                /// <summary>
                /// <para>The state batches for the share-partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<StateBatch> StateBatchesCollection
                {
                    get => _stateBatchesCollection;
                    private set
                    {
                        _stateBatchesCollection = value;
                    }
                }

                /// <summary>
                /// <para>The state batches for the share-partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithStateBatchesCollection(params Func<StateBatch, StateBatch>[] createFields)
                {
                    StateBatchesCollection = createFields.Select(createField => createField(new StateBatch(Version))).ToArray();
                    return this;
                }

                public delegate StateBatch CreateStateBatch(StateBatch field);
                /// <summary>
                /// <para>The state batches for the share-partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithStateBatchesCollection(IEnumerable<CreateStateBatch> createFields)
                {
                    StateBatchesCollection = createFields.Select(createField => createField(new StateBatch(Version))).ToArray();
                    return this;
                }

                public class StateBatch : ISerialize
                {
                    internal StateBatch(Int16 version)
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
                    internal int GetSize(bool _) => _firstOffset.GetSize(IsFlexibleVersion) + _lastOffset.GetSize(IsFlexibleVersion) + _deliveryState.GetSize(IsFlexibleVersion) + _deliveryCount.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<StateBatch> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new StateBatch(version);
                        instance.FirstOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.LastOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.DeliveryState = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.DeliveryCount = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for StateBatch is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        await _firstOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _lastOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _deliveryState.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _deliveryCount.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int64 _firstOffset = Int64.Default;
                    /// <summary>
                    /// <para>The base offset of this state batch.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int64 FirstOffset
                    {
                        get => _firstOffset;
                        private set
                        {
                            _firstOffset = value;
                        }
                    }

                    /// <summary>
                    /// <para>The base offset of this state batch.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public StateBatch WithFirstOffset(Int64 firstOffset)
                    {
                        FirstOffset = firstOffset;
                        return this;
                    }

                    private Int64 _lastOffset = Int64.Default;
                    /// <summary>
                    /// <para>The last offset of this state batch.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int64 LastOffset
                    {
                        get => _lastOffset;
                        private set
                        {
                            _lastOffset = value;
                        }
                    }

                    /// <summary>
                    /// <para>The last offset of this state batch.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public StateBatch WithLastOffset(Int64 lastOffset)
                    {
                        LastOffset = lastOffset;
                        return this;
                    }

                    private Int8 _deliveryState = Int8.Default;
                    /// <summary>
                    /// <para>The state - 0:Available,2:Acked,4:Archived.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int8 DeliveryState
                    {
                        get => _deliveryState;
                        private set
                        {
                            _deliveryState = value;
                        }
                    }

                    /// <summary>
                    /// <para>The state - 0:Available,2:Acked,4:Archived.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public StateBatch WithDeliveryState(Int8 deliveryState)
                    {
                        DeliveryState = deliveryState;
                        return this;
                    }

                    private Int16 _deliveryCount = Int16.Default;
                    /// <summary>
                    /// <para>The delivery count.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int16 DeliveryCount
                    {
                        get => _deliveryCount;
                        private set
                        {
                            _deliveryCount = value;
                        }
                    }

                    /// <summary>
                    /// <para>The delivery count.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public StateBatch WithDeliveryCount(Int16 deliveryCount)
                    {
                        DeliveryCount = deliveryCount;
                        return this;
                    }
                }
            }
        }

        public WriteShareGroupStateResponse Respond() => new WriteShareGroupStateResponse(Version);
    }
}
