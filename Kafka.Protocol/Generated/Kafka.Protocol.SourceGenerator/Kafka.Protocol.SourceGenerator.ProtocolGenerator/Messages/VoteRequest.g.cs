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
    public class VoteRequest : Message, IRespond<VoteResponse>
    {
        public VoteRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"VoteRequest does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(52);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(2);
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

        internal override int GetSize() => _clusterId.GetSize(IsFlexibleVersion) + (Version >= 1 ? _voterId.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<VoteRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new VoteRequest(version);
            instance.ClusterId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.VoterId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<TopicData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for VoteRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _clusterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _voterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private NullableString _clusterId = new NullableString(null);
        /// <summary>
        /// <para>The cluster id.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ClusterId
        {
            get => _clusterId;
            private set
            {
                _clusterId = value;
            }
        }

        /// <summary>
        /// <para>The cluster id.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public VoteRequest WithClusterId(String? clusterId)
        {
            ClusterId = clusterId;
            return this;
        }

        private Int32 _voterId = new Int32(-1);
        /// <summary>
        /// <para>The replica id of the voter receiving the request.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int32 VoterId
        {
            get => _voterId;
            private set
            {
                _voterId = value;
            }
        }

        /// <summary>
        /// <para>The replica id of the voter receiving the request.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public VoteRequest WithVoterId(Int32 voterId)
        {
            VoterId = voterId;
            return this;
        }

        private Array<TopicData> _topicsCollection = Array.Empty<TopicData>();
        /// <summary>
        /// <para>The topic data.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<TopicData> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topic data.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public VoteRequest WithTopicsCollection(params Func<TopicData, TopicData>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicData(Version))).ToArray();
            return this;
        }

        public delegate TopicData CreateTopicData(TopicData field);
        /// <summary>
        /// <para>The topic data.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public VoteRequest WithTopicsCollection(IEnumerable<CreateTopicData> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicData(Version))).ToArray();
            return this;
        }

        public class TopicData : ISerialize
        {
            internal TopicData(Int16 version)
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
            internal int GetSize(bool _) => _topicName.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicData(version);
                instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<PartitionData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => PartitionData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicData is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
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
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicData WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Array<PartitionData> _partitionsCollection = Array.Empty<PartitionData>();
            /// <summary>
            /// <para>The partition data.</para>
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
            /// <para>The partition data.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicData WithPartitionsCollection(params Func<PartitionData, PartitionData>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionData(Version))).ToArray();
                return this;
            }

            public delegate PartitionData CreatePartitionData(PartitionData field);
            /// <summary>
            /// <para>The partition data.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicData WithPartitionsCollection(IEnumerable<CreatePartitionData> createFields)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _replicaEpoch.GetSize(IsFlexibleVersion) + _replicaId.GetSize(IsFlexibleVersion) + (Version >= 1 ? _replicaDirectoryId.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _voterDirectoryId.GetSize(IsFlexibleVersion) : 0) + _lastOffsetEpoch.GetSize(IsFlexibleVersion) + _lastOffset.GetSize(IsFlexibleVersion) + (Version >= 2 ? _preVote.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionData(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ReplicaEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ReplicaId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.ReplicaDirectoryId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.VoterDirectoryId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LastOffsetEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LastOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 2)
                        instance.PreVote = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _replicaEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _replicaId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _replicaDirectoryId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _voterDirectoryId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _lastOffsetEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _lastOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 2)
                        await _preVote.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
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
                public PartitionData WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int32 _replicaEpoch = Int32.Default;
                /// <summary>
                /// <para>The epoch of the voter sending the request</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 ReplicaEpoch
                {
                    get => _replicaEpoch;
                    private set
                    {
                        _replicaEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The epoch of the voter sending the request</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithReplicaEpoch(Int32 replicaEpoch)
                {
                    ReplicaEpoch = replicaEpoch;
                    return this;
                }

                private Int32 _replicaId = Int32.Default;
                /// <summary>
                /// <para>The replica id of the voter sending the request</para>
                /// <para>Versions: 0+</para>
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
                /// <para>The replica id of the voter sending the request</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithReplicaId(Int32 replicaId)
                {
                    ReplicaId = replicaId;
                    return this;
                }

                private Uuid _replicaDirectoryId = Uuid.Default;
                /// <summary>
                /// <para>The directory id of the voter sending the request</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public Uuid ReplicaDirectoryId
                {
                    get => _replicaDirectoryId;
                    private set
                    {
                        _replicaDirectoryId = value;
                    }
                }

                /// <summary>
                /// <para>The directory id of the voter sending the request</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public PartitionData WithReplicaDirectoryId(Uuid replicaDirectoryId)
                {
                    ReplicaDirectoryId = replicaDirectoryId;
                    return this;
                }

                private Uuid _voterDirectoryId = Uuid.Default;
                /// <summary>
                /// <para>The directory id of the voter receiving the request</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public Uuid VoterDirectoryId
                {
                    get => _voterDirectoryId;
                    private set
                    {
                        _voterDirectoryId = value;
                    }
                }

                /// <summary>
                /// <para>The directory id of the voter receiving the request</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public PartitionData WithVoterDirectoryId(Uuid voterDirectoryId)
                {
                    VoterDirectoryId = voterDirectoryId;
                    return this;
                }

                private Int32 _lastOffsetEpoch = Int32.Default;
                /// <summary>
                /// <para>The epoch of the last record written to the metadata log.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 LastOffsetEpoch
                {
                    get => _lastOffsetEpoch;
                    private set
                    {
                        _lastOffsetEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The epoch of the last record written to the metadata log.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithLastOffsetEpoch(Int32 lastOffsetEpoch)
                {
                    LastOffsetEpoch = lastOffsetEpoch;
                    return this;
                }

                private Int64 _lastOffset = Int64.Default;
                /// <summary>
                /// <para>The log end offset of the metadata log of the voter sending the request.</para>
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
                /// <para>The log end offset of the metadata log of the voter sending the request.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithLastOffset(Int64 lastOffset)
                {
                    LastOffset = lastOffset;
                    return this;
                }

                private Boolean _preVote = Boolean.Default;
                /// <summary>
                /// <para>Whether the request is a PreVote request (not persisted) or not.</para>
                /// <para>Versions: 2+</para>
                /// </summary>
                public Boolean PreVote
                {
                    get => _preVote;
                    private set
                    {
                        if (Version >= 2 == false)
                            throw new UnsupportedVersionException($"PreVote does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                        _preVote = value;
                    }
                }

                /// <summary>
                /// <para>Whether the request is a PreVote request (not persisted) or not.</para>
                /// <para>Versions: 2+</para>
                /// </summary>
                public PartitionData WithPreVote(Boolean preVote)
                {
                    PreVote = preVote;
                    return this;
                }
            }
        }

        public VoteResponse Respond() => new VoteResponse(Version);
    }
}
