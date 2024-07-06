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
    public class TxnOffsetCommitRequest : Message, IRespond<TxnOffsetCommitResponse>
    {
        public TxnOffsetCommitRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"TxnOffsetCommitRequest does not support version {version}. Valid versions are: 0-4");
            Version = version;
            IsFlexibleVersion = version >= 3;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(28);
        public static readonly Int16 MinVersion = Int16.From(0);
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

        internal override int GetSize() => _transactionalId.GetSize(IsFlexibleVersion) + _groupId.GetSize(IsFlexibleVersion) + _producerId.GetSize(IsFlexibleVersion) + _producerEpoch.GetSize(IsFlexibleVersion) + (Version >= 3 ? _generationId.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _memberId.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _groupInstanceId.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<TxnOffsetCommitRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new TxnOffsetCommitRequest(version);
            instance.TransactionalId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ProducerEpoch = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.GenerationId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.GroupInstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<TxnOffsetCommitRequestTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TxnOffsetCommitRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for TxnOffsetCommitRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _transactionalId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _producerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _producerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _generationId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _groupInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _transactionalId = String.Default;
        /// <summary>
        /// <para>The ID of the transaction.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String TransactionalId
        {
            get => _transactionalId;
            private set
            {
                _transactionalId = value;
            }
        }

        /// <summary>
        /// <para>The ID of the transaction.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public TxnOffsetCommitRequest WithTransactionalId(String transactionalId)
        {
            TransactionalId = transactionalId;
            return this;
        }

        private String _groupId = String.Default;
        /// <summary>
        /// <para>The ID of the group.</para>
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
        /// <para>The ID of the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public TxnOffsetCommitRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private Int64 _producerId = Int64.Default;
        /// <summary>
        /// <para>The current producer ID in use by the transactional ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 ProducerId
        {
            get => _producerId;
            private set
            {
                _producerId = value;
            }
        }

        /// <summary>
        /// <para>The current producer ID in use by the transactional ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public TxnOffsetCommitRequest WithProducerId(Int64 producerId)
        {
            ProducerId = producerId;
            return this;
        }

        private Int16 _producerEpoch = Int16.Default;
        /// <summary>
        /// <para>The current epoch associated with the producer ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int16 ProducerEpoch
        {
            get => _producerEpoch;
            private set
            {
                _producerEpoch = value;
            }
        }

        /// <summary>
        /// <para>The current epoch associated with the producer ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public TxnOffsetCommitRequest WithProducerEpoch(Int16 producerEpoch)
        {
            ProducerEpoch = producerEpoch;
            return this;
        }

        private Int32 _generationId = new Int32(-1);
        /// <summary>
        /// <para>The generation of the consumer.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int32 GenerationId
        {
            get => _generationId;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"GenerationId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                _generationId = value;
            }
        }

        /// <summary>
        /// <para>The generation of the consumer.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public TxnOffsetCommitRequest WithGenerationId(Int32 generationId)
        {
            GenerationId = generationId;
            return this;
        }

        private String _memberId = new String(string.Empty);
        /// <summary>
        /// <para>The member ID assigned by the group coordinator.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: Empty string</para>
        /// </summary>
        public String MemberId
        {
            get => _memberId;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                _memberId = value;
            }
        }

        /// <summary>
        /// <para>The member ID assigned by the group coordinator.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: Empty string</para>
        /// </summary>
        public TxnOffsetCommitRequest WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private NullableString _groupInstanceId = new NullableString(null);
        /// <summary>
        /// <para>The unique identifier of the consumer instance provided by end user.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? GroupInstanceId
        {
            get => _groupInstanceId;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                if (Version >= 3 == false && value == null)
                    throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 3+");
                _groupInstanceId = value;
            }
        }

        /// <summary>
        /// <para>The unique identifier of the consumer instance provided by end user.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: null</para>
        /// </summary>
        public TxnOffsetCommitRequest WithGroupInstanceId(String? groupInstanceId)
        {
            GroupInstanceId = groupInstanceId;
            return this;
        }

        private Array<TxnOffsetCommitRequestTopic> _topicsCollection = Array.Empty<TxnOffsetCommitRequestTopic>();
        /// <summary>
        /// <para>Each topic that we want to commit offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<TxnOffsetCommitRequestTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic that we want to commit offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public TxnOffsetCommitRequest WithTopicsCollection(params Func<TxnOffsetCommitRequestTopic, TxnOffsetCommitRequestTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TxnOffsetCommitRequestTopic(Version))).ToArray();
            return this;
        }

        public delegate TxnOffsetCommitRequestTopic CreateTxnOffsetCommitRequestTopic(TxnOffsetCommitRequestTopic field);
        /// <summary>
        /// <para>Each topic that we want to commit offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public TxnOffsetCommitRequest WithTopicsCollection(IEnumerable<CreateTxnOffsetCommitRequestTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TxnOffsetCommitRequestTopic(Version))).ToArray();
            return this;
        }

        public class TxnOffsetCommitRequestTopic : ISerialize
        {
            internal TxnOffsetCommitRequestTopic(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TxnOffsetCommitRequestTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TxnOffsetCommitRequestTopic(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<TxnOffsetCommitRequestPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TxnOffsetCommitRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TxnOffsetCommitRequestTopic is unknown");
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
            public TxnOffsetCommitRequestTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<TxnOffsetCommitRequestPartition> _partitionsCollection = Array.Empty<TxnOffsetCommitRequestPartition>();
            /// <summary>
            /// <para>The partitions inside the topic that we want to commit offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TxnOffsetCommitRequestPartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions inside the topic that we want to commit offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TxnOffsetCommitRequestTopic WithPartitionsCollection(params Func<TxnOffsetCommitRequestPartition, TxnOffsetCommitRequestPartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new TxnOffsetCommitRequestPartition(Version))).ToArray();
                return this;
            }

            public delegate TxnOffsetCommitRequestPartition CreateTxnOffsetCommitRequestPartition(TxnOffsetCommitRequestPartition field);
            /// <summary>
            /// <para>The partitions inside the topic that we want to commit offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TxnOffsetCommitRequestTopic WithPartitionsCollection(IEnumerable<CreateTxnOffsetCommitRequestPartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new TxnOffsetCommitRequestPartition(Version))).ToArray();
                return this;
            }

            public class TxnOffsetCommitRequestPartition : ISerialize
            {
                internal TxnOffsetCommitRequestPartition(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 3;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _committedOffset.GetSize(IsFlexibleVersion) + (Version >= 2 ? _committedLeaderEpoch.GetSize(IsFlexibleVersion) : 0) + _committedMetadata.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<TxnOffsetCommitRequestPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new TxnOffsetCommitRequestPartition(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.CommittedOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 2)
                        instance.CommittedLeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.CommittedMetadata = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for TxnOffsetCommitRequestPartition is unknown");
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
                    if (Version >= 2)
                        await _committedLeaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _committedMetadata.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _partitionIndex = Int32.Default;
                /// <summary>
                /// <para>The index of the partition within the topic.</para>
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
                /// <para>The index of the partition within the topic.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public TxnOffsetCommitRequestPartition WithPartitionIndex(Int32 partitionIndex)
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
                public TxnOffsetCommitRequestPartition WithCommittedOffset(Int64 committedOffset)
                {
                    CommittedOffset = committedOffset;
                    return this;
                }

                private Int32 _committedLeaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>The leader epoch of the last consumed record.</para>
                /// <para>Versions: 2+</para>
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
                /// <para>The leader epoch of the last consumed record.</para>
                /// <para>Versions: 2+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public TxnOffsetCommitRequestPartition WithCommittedLeaderEpoch(Int32 committedLeaderEpoch)
                {
                    CommittedLeaderEpoch = committedLeaderEpoch;
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
                public TxnOffsetCommitRequestPartition WithCommittedMetadata(String? committedMetadata)
                {
                    CommittedMetadata = committedMetadata;
                    return this;
                }
            }
        }

        public TxnOffsetCommitResponse Respond() => new TxnOffsetCommitResponse(Version);
    }
}
