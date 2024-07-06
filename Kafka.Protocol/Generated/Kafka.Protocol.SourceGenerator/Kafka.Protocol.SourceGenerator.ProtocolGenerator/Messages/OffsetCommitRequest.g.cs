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
    public class OffsetCommitRequest : Message, IRespond<OffsetCommitResponse>
    {
        public OffsetCommitRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"OffsetCommitRequest does not support version {version}. Valid versions are: 0-9");
            Version = version;
            IsFlexibleVersion = version >= 8;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(8);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(9);
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

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + (Version >= 1 ? _generationIdOrMemberEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _memberId.GetSize(IsFlexibleVersion) : 0) + (Version >= 7 ? _groupInstanceId.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 && Version <= 4 ? _retentionTimeMs.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<OffsetCommitRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new OffsetCommitRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.GenerationIdOrMemberEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 7)
                instance.GroupInstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2 && instance.Version <= 4)
                instance.RetentionTimeMs = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<OffsetCommitRequestTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetCommitRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetCommitRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _generationIdOrMemberEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 7)
                await _groupInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 2 && Version <= 4)
                await _retentionTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _groupId = String.Default;
        /// <summary>
        /// <para>The unique group identifier.</para>
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
        /// <para>The unique group identifier.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public OffsetCommitRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private Int32 _generationIdOrMemberEpoch = new Int32(-1);
        /// <summary>
        /// <para>The generation of the group if using the classic group protocol or the member epoch if using the consumer protocol.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int32 GenerationIdOrMemberEpoch
        {
            get => _generationIdOrMemberEpoch;
            private set
            {
                _generationIdOrMemberEpoch = value;
            }
        }

        /// <summary>
        /// <para>The generation of the group if using the classic group protocol or the member epoch if using the consumer protocol.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public OffsetCommitRequest WithGenerationIdOrMemberEpoch(Int32 generationIdOrMemberEpoch)
        {
            GenerationIdOrMemberEpoch = generationIdOrMemberEpoch;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The member ID assigned by the group coordinator.</para>
        /// <para>Versions: 1+</para>
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
        /// <para>The member ID assigned by the group coordinator.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public OffsetCommitRequest WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private NullableString _groupInstanceId = new NullableString(null);
        /// <summary>
        /// <para>The unique identifier of the consumer instance provided by end user.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? GroupInstanceId
        {
            get => _groupInstanceId;
            private set
            {
                if (Version >= 7 == false)
                    throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
                if (Version >= 7 == false && value == null)
                    throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 7+");
                _groupInstanceId = value;
            }
        }

        /// <summary>
        /// <para>The unique identifier of the consumer instance provided by end user.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: null</para>
        /// </summary>
        public OffsetCommitRequest WithGroupInstanceId(String? groupInstanceId)
        {
            GroupInstanceId = groupInstanceId;
            return this;
        }

        private Int64 _retentionTimeMs = new Int64(-1);
        /// <summary>
        /// <para>The time period in ms to retain the offset.</para>
        /// <para>Versions: 2-4</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int64 RetentionTimeMs
        {
            get => _retentionTimeMs;
            private set
            {
                _retentionTimeMs = value;
            }
        }

        /// <summary>
        /// <para>The time period in ms to retain the offset.</para>
        /// <para>Versions: 2-4</para>
        /// <para>Default: -1</para>
        /// </summary>
        public OffsetCommitRequest WithRetentionTimeMs(Int64 retentionTimeMs)
        {
            RetentionTimeMs = retentionTimeMs;
            return this;
        }

        private Array<OffsetCommitRequestTopic> _topicsCollection = Array.Empty<OffsetCommitRequestTopic>();
        /// <summary>
        /// <para>The topics to commit offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<OffsetCommitRequestTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to commit offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public OffsetCommitRequest WithTopicsCollection(params Func<OffsetCommitRequestTopic, OffsetCommitRequestTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetCommitRequestTopic(Version))).ToArray();
            return this;
        }

        public delegate OffsetCommitRequestTopic CreateOffsetCommitRequestTopic(OffsetCommitRequestTopic field);
        /// <summary>
        /// <para>The topics to commit offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public OffsetCommitRequest WithTopicsCollection(IEnumerable<CreateOffsetCommitRequestTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetCommitRequestTopic(Version))).ToArray();
            return this;
        }

        public class OffsetCommitRequestTopic : ISerialize
        {
            internal OffsetCommitRequestTopic(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 8;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<OffsetCommitRequestTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new OffsetCommitRequestTopic(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<OffsetCommitRequestPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetCommitRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetCommitRequestTopic is unknown");
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
            /// <para>The topic name.</para>
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
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetCommitRequestTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<OffsetCommitRequestPartition> _partitionsCollection = Array.Empty<OffsetCommitRequestPartition>();
            /// <summary>
            /// <para>Each partition to commit offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<OffsetCommitRequestPartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition to commit offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetCommitRequestTopic WithPartitionsCollection(params Func<OffsetCommitRequestPartition, OffsetCommitRequestPartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new OffsetCommitRequestPartition(Version))).ToArray();
                return this;
            }

            public delegate OffsetCommitRequestPartition CreateOffsetCommitRequestPartition(OffsetCommitRequestPartition field);
            /// <summary>
            /// <para>Each partition to commit offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetCommitRequestTopic WithPartitionsCollection(IEnumerable<CreateOffsetCommitRequestPartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new OffsetCommitRequestPartition(Version))).ToArray();
                return this;
            }

            public class OffsetCommitRequestPartition : ISerialize
            {
                internal OffsetCommitRequestPartition(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 8;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _committedOffset.GetSize(IsFlexibleVersion) + (Version >= 6 ? _committedLeaderEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 && Version <= 1 ? _commitTimestamp.GetSize(IsFlexibleVersion) : 0) + _committedMetadata.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<OffsetCommitRequestPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new OffsetCommitRequestPartition(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.CommittedOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 6)
                        instance.CommittedLeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1 && instance.Version <= 1)
                        instance.CommitTimestamp = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.CommittedMetadata = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetCommitRequestPartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _committedOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 6)
                        await _committedLeaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1 && Version <= 1)
                        await _commitTimestamp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _committedMetadata.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public OffsetCommitRequestPartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int64 _committedOffset = Int64.Default;
                /// <summary>
                /// <para>The message offset to be committed.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 CommittedOffset
                {
                    get => _committedOffset;
                    private set
                    {
                        _committedOffset = value;
                    }
                }

                /// <summary>
                /// <para>The message offset to be committed.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public OffsetCommitRequestPartition WithCommittedOffset(Int64 committedOffset)
                {
                    CommittedOffset = committedOffset;
                    return this;
                }

                private Int32 _committedLeaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>The leader epoch of this partition.</para>
                /// <para>Versions: 6+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int32 CommittedLeaderEpoch
                {
                    get => _committedLeaderEpoch;
                    private set
                    {
                        _committedLeaderEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The leader epoch of this partition.</para>
                /// <para>Versions: 6+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public OffsetCommitRequestPartition WithCommittedLeaderEpoch(Int32 committedLeaderEpoch)
                {
                    CommittedLeaderEpoch = committedLeaderEpoch;
                    return this;
                }

                private Int64 _commitTimestamp = new Int64(-1);
                /// <summary>
                /// <para>The timestamp of the commit.</para>
                /// <para>Versions: 1</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int64 CommitTimestamp
                {
                    get => _commitTimestamp;
                    private set
                    {
                        if (Version >= 1 && Version <= 1 == false)
                            throw new UnsupportedVersionException($"CommitTimestamp does not support version {Version} and has been defined as not ignorable. Supported versions: 1");
                        _commitTimestamp = value;
                    }
                }

                /// <summary>
                /// <para>The timestamp of the commit.</para>
                /// <para>Versions: 1</para>
                /// <para>Default: -1</para>
                /// </summary>
                public OffsetCommitRequestPartition WithCommitTimestamp(Int64 commitTimestamp)
                {
                    CommitTimestamp = commitTimestamp;
                    return this;
                }

                private NullableString _committedMetadata = NullableString.Default;
                /// <summary>
                /// <para>Any associated metadata the client wants to keep.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public String? CommittedMetadata
                {
                    get => _committedMetadata;
                    private set
                    {
                        _committedMetadata = value;
                    }
                }

                /// <summary>
                /// <para>Any associated metadata the client wants to keep.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public OffsetCommitRequestPartition WithCommittedMetadata(String? committedMetadata)
                {
                    CommittedMetadata = committedMetadata;
                    return this;
                }
            }
        }

        public OffsetCommitResponse Respond() => new OffsetCommitResponse(Version);
    }
}
