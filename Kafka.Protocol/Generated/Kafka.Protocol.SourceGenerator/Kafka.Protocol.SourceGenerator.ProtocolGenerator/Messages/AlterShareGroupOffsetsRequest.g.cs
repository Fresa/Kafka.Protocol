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
    public class AlterShareGroupOffsetsRequest : Message, IRespond<AlterShareGroupOffsetsResponse>
    {
        public AlterShareGroupOffsetsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AlterShareGroupOffsetsRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(91);
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
        internal static async ValueTask<AlterShareGroupOffsetsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AlterShareGroupOffsetsRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Map<String, AlterShareGroupOffsetsRequestTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterShareGroupOffsetsRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.TopicName, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterShareGroupOffsetsRequest is unknown");
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
        public AlterShareGroupOffsetsRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private Map<String, AlterShareGroupOffsetsRequestTopic> _topicsCollection = Map<String, AlterShareGroupOffsetsRequestTopic>.Default;
        /// <summary>
        /// <para>The topics to alter offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, AlterShareGroupOffsetsRequestTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to alter offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterShareGroupOffsetsRequest WithTopicsCollection(params Func<AlterShareGroupOffsetsRequestTopic, AlterShareGroupOffsetsRequestTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new AlterShareGroupOffsetsRequestTopic(Version))).ToDictionary(field => field.TopicName);
            return this;
        }

        public delegate AlterShareGroupOffsetsRequestTopic CreateAlterShareGroupOffsetsRequestTopic(AlterShareGroupOffsetsRequestTopic field);
        /// <summary>
        /// <para>The topics to alter offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterShareGroupOffsetsRequest WithTopicsCollection(IEnumerable<CreateAlterShareGroupOffsetsRequestTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new AlterShareGroupOffsetsRequestTopic(Version))).ToDictionary(field => field.TopicName);
            return this;
        }

        public class AlterShareGroupOffsetsRequestTopic : ISerialize
        {
            internal AlterShareGroupOffsetsRequestTopic(Int16 version)
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
            internal static async ValueTask<AlterShareGroupOffsetsRequestTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AlterShareGroupOffsetsRequestTopic(version);
                instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<AlterShareGroupOffsetsRequestPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterShareGroupOffsetsRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterShareGroupOffsetsRequestTopic is unknown");
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
            public AlterShareGroupOffsetsRequestTopic WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Array<AlterShareGroupOffsetsRequestPartition> _partitionsCollection = Array.Empty<AlterShareGroupOffsetsRequestPartition>();
            /// <summary>
            /// <para>Each partition to alter offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<AlterShareGroupOffsetsRequestPartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition to alter offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterShareGroupOffsetsRequestTopic WithPartitionsCollection(params Func<AlterShareGroupOffsetsRequestPartition, AlterShareGroupOffsetsRequestPartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new AlterShareGroupOffsetsRequestPartition(Version))).ToArray();
                return this;
            }

            public delegate AlterShareGroupOffsetsRequestPartition CreateAlterShareGroupOffsetsRequestPartition(AlterShareGroupOffsetsRequestPartition field);
            /// <summary>
            /// <para>Each partition to alter offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterShareGroupOffsetsRequestTopic WithPartitionsCollection(IEnumerable<CreateAlterShareGroupOffsetsRequestPartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new AlterShareGroupOffsetsRequestPartition(Version))).ToArray();
                return this;
            }

            public class AlterShareGroupOffsetsRequestPartition : ISerialize
            {
                internal AlterShareGroupOffsetsRequestPartition(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _startOffset.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<AlterShareGroupOffsetsRequestPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new AlterShareGroupOffsetsRequestPartition(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.StartOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterShareGroupOffsetsRequestPartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _startOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public AlterShareGroupOffsetsRequestPartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int64 _startOffset = Int64.Default;
                /// <summary>
                /// <para>The share-partition start offset.</para>
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
                /// <para>The share-partition start offset.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public AlterShareGroupOffsetsRequestPartition WithStartOffset(Int64 startOffset)
                {
                    StartOffset = startOffset;
                    return this;
                }
            }
        }

        public AlterShareGroupOffsetsResponse Respond() => new AlterShareGroupOffsetsResponse(Version);
    }
}
