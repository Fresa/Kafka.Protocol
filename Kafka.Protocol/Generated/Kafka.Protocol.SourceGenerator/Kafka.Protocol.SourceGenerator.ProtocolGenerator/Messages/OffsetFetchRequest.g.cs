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
    public class OffsetFetchRequest : Message, IRespond<OffsetFetchResponse>
    {
        public OffsetFetchRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"OffsetFetchRequest does not support version {version}. Valid versions are: 1-9");
            Version = version;
            IsFlexibleVersion = version >= 6;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(9);
        public static readonly Int16 MinVersion = Int16.From(1);
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

        internal override int GetSize() => (Version >= 0 && Version <= 7 ? _groupId.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 7 ? _topicsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _groupsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 7 ? _requireStable.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<OffsetFetchRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new OffsetFetchRequest(version);
            if (instance.Version >= 0 && instance.Version <= 7)
                instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 7)
                instance.TopicsCollection = await NullableArray<OffsetFetchRequestTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetFetchRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 8)
                instance.GroupsCollection = await Array<OffsetFetchRequestGroup>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetFetchRequestGroup.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 7)
                instance.RequireStable = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetFetchRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 0 && Version <= 7)
                await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 7)
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 8)
                await _groupsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 7)
                await _requireStable.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _groupId = String.Default;
        /// <summary>
        /// <para>The group to fetch offsets for.</para>
        /// <para>Versions: 0-7</para>
        /// </summary>
        public String GroupId
        {
            get => _groupId;
            private set
            {
                if (Version >= 0 && Version <= 7 == false)
                    throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0-7");
                _groupId = value;
            }
        }

        /// <summary>
        /// <para>The group to fetch offsets for.</para>
        /// <para>Versions: 0-7</para>
        /// </summary>
        public OffsetFetchRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private NullableArray<OffsetFetchRequestTopic> _topicsCollection = Array.Empty<OffsetFetchRequestTopic>();
        /// <summary>
        /// <para>Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.</para>
        /// <para>Versions: 0-7</para>
        /// </summary>
        public Array<OffsetFetchRequestTopic>? TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                if (Version >= 0 && Version <= 7 == false)
                    throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-7");
                if (Version >= 2 && Version <= 7 == false && value == null)
                    throw new UnsupportedVersionException($"TopicsCollection does not support null for version {Version}. Supported versions for null value: 2-7");
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.</para>
        /// <para>Versions: 0-7</para>
        /// </summary>
        public OffsetFetchRequest WithTopicsCollection(params Func<OffsetFetchRequestTopic, OffsetFetchRequestTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetFetchRequestTopic(Version))).ToArray();
            return this;
        }

        public delegate OffsetFetchRequestTopic CreateOffsetFetchRequestTopic(OffsetFetchRequestTopic field);
        /// <summary>
        /// <para>Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.</para>
        /// <para>Versions: 0-7</para>
        /// </summary>
        public OffsetFetchRequest WithTopicsCollection(IEnumerable<CreateOffsetFetchRequestTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetFetchRequestTopic(Version))).ToArray();
            return this;
        }

        public class OffsetFetchRequestTopic : ISerialize
        {
            internal OffsetFetchRequestTopic(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 6;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 0 && Version <= 7 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 7 ? _partitionIndexesCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<OffsetFetchRequestTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new OffsetFetchRequestTopic(version);
                if (instance.Version >= 0 && instance.Version <= 7)
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 0 && instance.Version <= 7)
                    instance.PartitionIndexesCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetFetchRequestTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 0 && Version <= 7)
                    await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 0 && Version <= 7)
                    await _partitionIndexesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0-7</para>
            /// </summary>
            public String Name
            {
                get => _name;
                private set
                {
                    if (Version >= 0 && Version <= 7 == false)
                        throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0-7");
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0-7</para>
            /// </summary>
            public OffsetFetchRequestTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<Int32> _partitionIndexesCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partition indexes we would like to fetch offsets for.</para>
            /// <para>Versions: 0-7</para>
            /// </summary>
            public Array<Int32> PartitionIndexesCollection
            {
                get => _partitionIndexesCollection;
                private set
                {
                    if (Version >= 0 && Version <= 7 == false)
                        throw new UnsupportedVersionException($"PartitionIndexesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-7");
                    _partitionIndexesCollection = value;
                }
            }

            /// <summary>
            /// <para>The partition indexes we would like to fetch offsets for.</para>
            /// <para>Versions: 0-7</para>
            /// </summary>
            public OffsetFetchRequestTopic WithPartitionIndexesCollection(Array<Int32> partitionIndexesCollection)
            {
                PartitionIndexesCollection = partitionIndexesCollection;
                return this;
            }
        }

        private Array<OffsetFetchRequestGroup> _groupsCollection = Array.Empty<OffsetFetchRequestGroup>();
        /// <summary>
        /// <para>Each group we would like to fetch offsets for.</para>
        /// <para>Versions: 8+</para>
        /// </summary>
        public Array<OffsetFetchRequestGroup> GroupsCollection
        {
            get => _groupsCollection;
            private set
            {
                if (Version >= 8 == false)
                    throw new UnsupportedVersionException($"GroupsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                _groupsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each group we would like to fetch offsets for.</para>
        /// <para>Versions: 8+</para>
        /// </summary>
        public OffsetFetchRequest WithGroupsCollection(params Func<OffsetFetchRequestGroup, OffsetFetchRequestGroup>[] createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new OffsetFetchRequestGroup(Version))).ToArray();
            return this;
        }

        public delegate OffsetFetchRequestGroup CreateOffsetFetchRequestGroup(OffsetFetchRequestGroup field);
        /// <summary>
        /// <para>Each group we would like to fetch offsets for.</para>
        /// <para>Versions: 8+</para>
        /// </summary>
        public OffsetFetchRequest WithGroupsCollection(IEnumerable<CreateOffsetFetchRequestGroup> createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new OffsetFetchRequestGroup(Version))).ToArray();
            return this;
        }

        public class OffsetFetchRequestGroup : ISerialize
        {
            internal OffsetFetchRequestGroup(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 6;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 8 ? _groupId.GetSize(IsFlexibleVersion) : 0) + (Version >= 9 ? _memberId.GetSize(IsFlexibleVersion) : 0) + (Version >= 9 ? _memberEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _topicsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<OffsetFetchRequestGroup> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new OffsetFetchRequestGroup(version);
                if (instance.Version >= 8)
                    instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 9)
                    instance.MemberId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 9)
                    instance.MemberEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 8)
                    instance.TopicsCollection = await NullableArray<OffsetFetchRequestTopics>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetFetchRequestTopics.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetFetchRequestGroup is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 8)
                    await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 9)
                    await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 9)
                    await _memberEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 8)
                    await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _groupId = String.Default;
            /// <summary>
            /// <para>The group ID.</para>
            /// <para>Versions: 8+</para>
            /// </summary>
            public String GroupId
            {
                get => _groupId;
                private set
                {
                    if (Version >= 8 == false)
                        throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                    _groupId = value;
                }
            }

            /// <summary>
            /// <para>The group ID.</para>
            /// <para>Versions: 8+</para>
            /// </summary>
            public OffsetFetchRequestGroup WithGroupId(String groupId)
            {
                GroupId = groupId;
                return this;
            }

            private NullableString _memberId = new NullableString(null);
            /// <summary>
            /// <para>The member id.</para>
            /// <para>Versions: 9+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? MemberId
            {
                get => _memberId;
                private set
                {
                    if (Version >= 9 == false && value == null)
                        throw new UnsupportedVersionException($"MemberId does not support null for version {Version}. Supported versions for null value: 9+");
                    _memberId = value;
                }
            }

            /// <summary>
            /// <para>The member id.</para>
            /// <para>Versions: 9+</para>
            /// <para>Default: null</para>
            /// </summary>
            public OffsetFetchRequestGroup WithMemberId(String? memberId)
            {
                MemberId = memberId;
                return this;
            }

            private Int32 _memberEpoch = new Int32(-1);
            /// <summary>
            /// <para>The member epoch if using the new consumer protocol (KIP-848).</para>
            /// <para>Versions: 9+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public Int32 MemberEpoch
            {
                get => _memberEpoch;
                private set
                {
                    _memberEpoch = value;
                }
            }

            /// <summary>
            /// <para>The member epoch if using the new consumer protocol (KIP-848).</para>
            /// <para>Versions: 9+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public OffsetFetchRequestGroup WithMemberEpoch(Int32 memberEpoch)
            {
                MemberEpoch = memberEpoch;
                return this;
            }

            private NullableArray<OffsetFetchRequestTopics> _topicsCollection = Array.Empty<OffsetFetchRequestTopics>();
            /// <summary>
            /// <para>Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.</para>
            /// <para>Versions: 8+</para>
            /// </summary>
            public Array<OffsetFetchRequestTopics>? TopicsCollection
            {
                get => _topicsCollection;
                private set
                {
                    if (Version >= 8 == false)
                        throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                    if (Version >= 8 == false && value == null)
                        throw new UnsupportedVersionException($"TopicsCollection does not support null for version {Version}. Supported versions for null value: 8+");
                    _topicsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.</para>
            /// <para>Versions: 8+</para>
            /// </summary>
            public OffsetFetchRequestGroup WithTopicsCollection(params Func<OffsetFetchRequestTopics, OffsetFetchRequestTopics>[] createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new OffsetFetchRequestTopics(Version))).ToArray();
                return this;
            }

            public delegate OffsetFetchRequestTopics CreateOffsetFetchRequestTopics(OffsetFetchRequestTopics field);
            /// <summary>
            /// <para>Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.</para>
            /// <para>Versions: 8+</para>
            /// </summary>
            public OffsetFetchRequestGroup WithTopicsCollection(IEnumerable<CreateOffsetFetchRequestTopics> createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new OffsetFetchRequestTopics(Version))).ToArray();
                return this;
            }

            public class OffsetFetchRequestTopics : ISerialize
            {
                internal OffsetFetchRequestTopics(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 6;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => (Version >= 8 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _partitionIndexesCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<OffsetFetchRequestTopics> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new OffsetFetchRequestTopics(version);
                    if (instance.Version >= 8)
                        instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 8)
                        instance.PartitionIndexesCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetFetchRequestTopics is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    if (Version >= 8)
                        await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 8)
                        await _partitionIndexesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private String _name = String.Default;
                /// <summary>
                /// <para>The topic name.</para>
                /// <para>Versions: 8+</para>
                /// </summary>
                public String Name
                {
                    get => _name;
                    private set
                    {
                        if (Version >= 8 == false)
                            throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                        _name = value;
                    }
                }

                /// <summary>
                /// <para>The topic name.</para>
                /// <para>Versions: 8+</para>
                /// </summary>
                public OffsetFetchRequestTopics WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private Array<Int32> _partitionIndexesCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The partition indexes we would like to fetch offsets for.</para>
                /// <para>Versions: 8+</para>
                /// </summary>
                public Array<Int32> PartitionIndexesCollection
                {
                    get => _partitionIndexesCollection;
                    private set
                    {
                        if (Version >= 8 == false)
                            throw new UnsupportedVersionException($"PartitionIndexesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                        _partitionIndexesCollection = value;
                    }
                }

                /// <summary>
                /// <para>The partition indexes we would like to fetch offsets for.</para>
                /// <para>Versions: 8+</para>
                /// </summary>
                public OffsetFetchRequestTopics WithPartitionIndexesCollection(Array<Int32> partitionIndexesCollection)
                {
                    PartitionIndexesCollection = partitionIndexesCollection;
                    return this;
                }
            }
        }

        private Boolean _requireStable = new Boolean(false);
        /// <summary>
        /// <para>Whether broker should hold on returning unstable offsets but set a retriable error code for the partitions.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean RequireStable
        {
            get => _requireStable;
            private set
            {
                if (Version >= 7 == false)
                    throw new UnsupportedVersionException($"RequireStable does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
                _requireStable = value;
            }
        }

        /// <summary>
        /// <para>Whether broker should hold on returning unstable offsets but set a retriable error code for the partitions.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: false</para>
        /// </summary>
        public OffsetFetchRequest WithRequireStable(Boolean requireStable)
        {
            RequireStable = requireStable;
            return this;
        }

        public OffsetFetchResponse Respond() => new OffsetFetchResponse(Version);
    }
}
