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
    public class DescribeShareGroupOffsetsRequest : Message, IRespond<DescribeShareGroupOffsetsResponse>
    {
        public DescribeShareGroupOffsetsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeShareGroupOffsetsRequest does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(90);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(1);
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

        internal override int GetSize() => _groupsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeShareGroupOffsetsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeShareGroupOffsetsRequest(version);
            instance.GroupsCollection = await Array<DescribeShareGroupOffsetsRequestGroup>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeShareGroupOffsetsRequestGroup.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeShareGroupOffsetsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<DescribeShareGroupOffsetsRequestGroup> _groupsCollection = Array.Empty<DescribeShareGroupOffsetsRequestGroup>();
        /// <summary>
        /// <para>The groups to describe offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DescribeShareGroupOffsetsRequestGroup> GroupsCollection
        {
            get => _groupsCollection;
            private set
            {
                _groupsCollection = value;
            }
        }

        /// <summary>
        /// <para>The groups to describe offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeShareGroupOffsetsRequest WithGroupsCollection(params Func<DescribeShareGroupOffsetsRequestGroup, DescribeShareGroupOffsetsRequestGroup>[] createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new DescribeShareGroupOffsetsRequestGroup(Version))).ToArray();
            return this;
        }

        public delegate DescribeShareGroupOffsetsRequestGroup CreateDescribeShareGroupOffsetsRequestGroup(DescribeShareGroupOffsetsRequestGroup field);
        /// <summary>
        /// <para>The groups to describe offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeShareGroupOffsetsRequest WithGroupsCollection(IEnumerable<CreateDescribeShareGroupOffsetsRequestGroup> createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new DescribeShareGroupOffsetsRequestGroup(Version))).ToArray();
            return this;
        }

        public class DescribeShareGroupOffsetsRequestGroup : ISerialize
        {
            internal DescribeShareGroupOffsetsRequestGroup(Int16 version)
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
            internal int GetSize(bool _) => _groupId.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribeShareGroupOffsetsRequestGroup> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribeShareGroupOffsetsRequestGroup(version);
                instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicsCollection = await NullableArray<DescribeShareGroupOffsetsRequestTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeShareGroupOffsetsRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeShareGroupOffsetsRequestGroup is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
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
            public DescribeShareGroupOffsetsRequestGroup WithGroupId(String groupId)
            {
                GroupId = groupId;
                return this;
            }

            private NullableArray<DescribeShareGroupOffsetsRequestTopic> _topicsCollection = Array.Empty<DescribeShareGroupOffsetsRequestTopic>();
            /// <summary>
            /// <para>The topics to describe offsets for, or null for all topic-partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<DescribeShareGroupOffsetsRequestTopic>? TopicsCollection
            {
                get => _topicsCollection;
                private set
                {
                    _topicsCollection = value;
                }
            }

            /// <summary>
            /// <para>The topics to describe offsets for, or null for all topic-partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeShareGroupOffsetsRequestGroup WithTopicsCollection(params Func<DescribeShareGroupOffsetsRequestTopic, DescribeShareGroupOffsetsRequestTopic>[] createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new DescribeShareGroupOffsetsRequestTopic(Version))).ToArray();
                return this;
            }

            public delegate DescribeShareGroupOffsetsRequestTopic CreateDescribeShareGroupOffsetsRequestTopic(DescribeShareGroupOffsetsRequestTopic field);
            /// <summary>
            /// <para>The topics to describe offsets for, or null for all topic-partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeShareGroupOffsetsRequestGroup WithTopicsCollection(IEnumerable<CreateDescribeShareGroupOffsetsRequestTopic> createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new DescribeShareGroupOffsetsRequestTopic(Version))).ToArray();
                return this;
            }

            public class DescribeShareGroupOffsetsRequestTopic : ISerialize
            {
                internal DescribeShareGroupOffsetsRequestTopic(Int16 version)
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
                internal static async ValueTask<DescribeShareGroupOffsetsRequestTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new DescribeShareGroupOffsetsRequestTopic(version);
                    instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeShareGroupOffsetsRequestTopic is unknown");
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
                public DescribeShareGroupOffsetsRequestTopic WithTopicName(String topicName)
                {
                    TopicName = topicName;
                    return this;
                }

                private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The partitions.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> PartitionsCollection
                {
                    get => _partitionsCollection;
                    private set
                    {
                        _partitionsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The partitions.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeShareGroupOffsetsRequestTopic WithPartitionsCollection(Array<Int32> partitionsCollection)
                {
                    PartitionsCollection = partitionsCollection;
                    return this;
                }
            }
        }

        public DescribeShareGroupOffsetsResponse Respond() => new DescribeShareGroupOffsetsResponse(Version);
    }
}
