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
    public class OffsetDeleteRequest : Message, IRespond<OffsetDeleteResponse>
    {
        public OffsetDeleteRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"OffsetDeleteRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = false;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(47);
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
        internal static async ValueTask<OffsetDeleteRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new OffsetDeleteRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Map<String, OffsetDeleteRequestTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetDeleteRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetDeleteRequest is unknown");
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
        public OffsetDeleteRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private Map<String, OffsetDeleteRequestTopic> _topicsCollection = Map<String, OffsetDeleteRequestTopic>.Default;
        /// <summary>
        /// <para>The topics to delete offsets for</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, OffsetDeleteRequestTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to delete offsets for</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public OffsetDeleteRequest WithTopicsCollection(params Func<OffsetDeleteRequestTopic, OffsetDeleteRequestTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetDeleteRequestTopic(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate OffsetDeleteRequestTopic CreateOffsetDeleteRequestTopic(OffsetDeleteRequestTopic field);
        /// <summary>
        /// <para>The topics to delete offsets for</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public OffsetDeleteRequest WithTopicsCollection(IEnumerable<CreateOffsetDeleteRequestTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetDeleteRequestTopic(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class OffsetDeleteRequestTopic : ISerialize
        {
            internal OffsetDeleteRequestTopic(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = false;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<OffsetDeleteRequestTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new OffsetDeleteRequestTopic(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<OffsetDeleteRequestPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetDeleteRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetDeleteRequestTopic is unknown");
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
            public OffsetDeleteRequestTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<OffsetDeleteRequestPartition> _partitionsCollection = Array.Empty<OffsetDeleteRequestPartition>();
            /// <summary>
            /// <para>Each partition to delete offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<OffsetDeleteRequestPartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition to delete offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetDeleteRequestTopic WithPartitionsCollection(params Func<OffsetDeleteRequestPartition, OffsetDeleteRequestPartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new OffsetDeleteRequestPartition(Version))).ToArray();
                return this;
            }

            public delegate OffsetDeleteRequestPartition CreateOffsetDeleteRequestPartition(OffsetDeleteRequestPartition field);
            /// <summary>
            /// <para>Each partition to delete offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetDeleteRequestTopic WithPartitionsCollection(IEnumerable<CreateOffsetDeleteRequestPartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new OffsetDeleteRequestPartition(Version))).ToArray();
                return this;
            }

            public class OffsetDeleteRequestPartition : ISerialize
            {
                internal OffsetDeleteRequestPartition(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = false;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<OffsetDeleteRequestPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new OffsetDeleteRequestPartition(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetDeleteRequestPartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public OffsetDeleteRequestPartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }
            }
        }

        public OffsetDeleteResponse Respond() => new OffsetDeleteResponse(Version);
    }
}
