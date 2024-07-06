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
    public class OffsetFetchResponse : Message
    {
        public OffsetFetchResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"OffsetFetchResponse does not support version {version}. Valid versions are: 0-9");
            Version = version;
            IsFlexibleVersion = version >= 6;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(9);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(9);
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
            return new Tags.TagSection();
        }

        internal override int GetSize() => (Version >= 3 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 7 ? _topicsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 && Version <= 7 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _groupsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<OffsetFetchResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new OffsetFetchResponse(version);
            if (instance.Version >= 3)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 7)
                instance.TopicsCollection = await Array<OffsetFetchResponseTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetFetchResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2 && instance.Version <= 7)
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 8)
                instance.GroupsCollection = await Array<OffsetFetchResponseGroup>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetFetchResponseGroup.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetFetchResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 3)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 7)
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 2 && Version <= 7)
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 8)
                await _groupsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 3+</para>
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
        /// <para>Versions: 3+</para>
        /// </summary>
        public OffsetFetchResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Array<OffsetFetchResponseTopic> _topicsCollection = Array.Empty<OffsetFetchResponseTopic>();
        /// <summary>
        /// <para>The responses per topic.</para>
        /// <para>Versions: 0-7</para>
        /// </summary>
        public Array<OffsetFetchResponseTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                if (Version >= 0 && Version <= 7 == false)
                    throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-7");
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The responses per topic.</para>
        /// <para>Versions: 0-7</para>
        /// </summary>
        public OffsetFetchResponse WithTopicsCollection(params Func<OffsetFetchResponseTopic, OffsetFetchResponseTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetFetchResponseTopic(Version))).ToArray();
            return this;
        }

        public delegate OffsetFetchResponseTopic CreateOffsetFetchResponseTopic(OffsetFetchResponseTopic field);
        /// <summary>
        /// <para>The responses per topic.</para>
        /// <para>Versions: 0-7</para>
        /// </summary>
        public OffsetFetchResponse WithTopicsCollection(IEnumerable<CreateOffsetFetchResponseTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetFetchResponseTopic(Version))).ToArray();
            return this;
        }

        public class OffsetFetchResponseTopic : ISerialize
        {
            internal OffsetFetchResponseTopic(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 0 && Version <= 7 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 7 ? _partitionsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<OffsetFetchResponseTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new OffsetFetchResponseTopic(version);
                if (instance.Version >= 0 && instance.Version <= 7)
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 0 && instance.Version <= 7)
                    instance.PartitionsCollection = await Array<OffsetFetchResponsePartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetFetchResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetFetchResponseTopic is unknown");
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
                    await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public OffsetFetchResponseTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<OffsetFetchResponsePartition> _partitionsCollection = Array.Empty<OffsetFetchResponsePartition>();
            /// <summary>
            /// <para>The responses per partition</para>
            /// <para>Versions: 0-7</para>
            /// </summary>
            public Array<OffsetFetchResponsePartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    if (Version >= 0 && Version <= 7 == false)
                        throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-7");
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The responses per partition</para>
            /// <para>Versions: 0-7</para>
            /// </summary>
            public OffsetFetchResponseTopic WithPartitionsCollection(params Func<OffsetFetchResponsePartition, OffsetFetchResponsePartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new OffsetFetchResponsePartition(Version))).ToArray();
                return this;
            }

            public delegate OffsetFetchResponsePartition CreateOffsetFetchResponsePartition(OffsetFetchResponsePartition field);
            /// <summary>
            /// <para>The responses per partition</para>
            /// <para>Versions: 0-7</para>
            /// </summary>
            public OffsetFetchResponseTopic WithPartitionsCollection(IEnumerable<CreateOffsetFetchResponsePartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new OffsetFetchResponsePartition(Version))).ToArray();
                return this;
            }

            public class OffsetFetchResponsePartition : ISerialize
            {
                internal OffsetFetchResponsePartition(Int16 version)
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
                internal int GetSize(bool _) => (Version >= 0 && Version <= 7 ? _partitionIndex.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 7 ? _committedOffset.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 && Version <= 7 ? _committedLeaderEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 7 ? _metadata.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 7 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<OffsetFetchResponsePartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new OffsetFetchResponsePartition(version);
                    if (instance.Version >= 0 && instance.Version <= 7)
                        instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 0 && instance.Version <= 7)
                        instance.CommittedOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 5 && instance.Version <= 7)
                        instance.CommittedLeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 0 && instance.Version <= 7)
                        instance.Metadata = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 0 && instance.Version <= 7)
                        instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetFetchResponsePartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    if (Version >= 0 && Version <= 7)
                        await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 0 && Version <= 7)
                        await _committedOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 5 && Version <= 7)
                        await _committedLeaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 0 && Version <= 7)
                        await _metadata.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 0 && Version <= 7)
                        await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _partitionIndex = Int32.Default;
                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 0-7</para>
                /// </summary>
                public Int32 PartitionIndex
                {
                    get => _partitionIndex;
                    private set
                    {
                        if (Version >= 0 && Version <= 7 == false)
                            throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0-7");
                        _partitionIndex = value;
                    }
                }

                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 0-7</para>
                /// </summary>
                public OffsetFetchResponsePartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int64 _committedOffset = Int64.Default;
                /// <summary>
                /// <para>The committed message offset.</para>
                /// <para>Versions: 0-7</para>
                /// </summary>
                public Int64 CommittedOffset
                {
                    get => _committedOffset;
                    private set
                    {
                        if (Version >= 0 && Version <= 7 == false)
                            throw new UnsupportedVersionException($"CommittedOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 0-7");
                        _committedOffset = value;
                    }
                }

                /// <summary>
                /// <para>The committed message offset.</para>
                /// <para>Versions: 0-7</para>
                /// </summary>
                public OffsetFetchResponsePartition WithCommittedOffset(Int64 committedOffset)
                {
                    CommittedOffset = committedOffset;
                    return this;
                }

                private Int32 _committedLeaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>The leader epoch.</para>
                /// <para>Versions: 5-7</para>
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
                /// <para>The leader epoch.</para>
                /// <para>Versions: 5-7</para>
                /// <para>Default: -1</para>
                /// </summary>
                public OffsetFetchResponsePartition WithCommittedLeaderEpoch(Int32 committedLeaderEpoch)
                {
                    CommittedLeaderEpoch = committedLeaderEpoch;
                    return this;
                }

                private NullableString _metadata = NullableString.Default;
                /// <summary>
                /// <para>The partition metadata.</para>
                /// <para>Versions: 0-7</para>
                /// </summary>
                public String? Metadata
                {
                    get => _metadata;
                    private set
                    {
                        if (Version >= 0 && Version <= 7 == false)
                            throw new UnsupportedVersionException($"Metadata does not support version {Version} and has been defined as not ignorable. Supported versions: 0-7");
                        if (Version >= 0 && Version <= 7 == false && value == null)
                            throw new UnsupportedVersionException($"Metadata does not support null for version {Version}. Supported versions for null value: 0-7");
                        _metadata = value;
                    }
                }

                /// <summary>
                /// <para>The partition metadata.</para>
                /// <para>Versions: 0-7</para>
                /// </summary>
                public OffsetFetchResponsePartition WithMetadata(String? metadata)
                {
                    Metadata = metadata;
                    return this;
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The error code, or 0 if there was no error.</para>
                /// <para>Versions: 0-7</para>
                /// </summary>
                public Int16 ErrorCode
                {
                    get => _errorCode;
                    private set
                    {
                        if (Version >= 0 && Version <= 7 == false)
                            throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0-7");
                        _errorCode = value;
                    }
                }

                /// <summary>
                /// <para>The error code, or 0 if there was no error.</para>
                /// <para>Versions: 0-7</para>
                /// </summary>
                public OffsetFetchResponsePartition WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }
            }
        }

        private Int16 _errorCode = new Int16(0);
        /// <summary>
        /// <para>The top-level error code, or 0 if there was no error.</para>
        /// <para>Versions: 2-7</para>
        /// <para>Default: 0</para>
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
        /// <para>The top-level error code, or 0 if there was no error.</para>
        /// <para>Versions: 2-7</para>
        /// <para>Default: 0</para>
        /// </summary>
        public OffsetFetchResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<OffsetFetchResponseGroup> _groupsCollection = Array.Empty<OffsetFetchResponseGroup>();
        /// <summary>
        /// <para>The responses per group id.</para>
        /// <para>Versions: 8+</para>
        /// </summary>
        public Array<OffsetFetchResponseGroup> GroupsCollection
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
        /// <para>The responses per group id.</para>
        /// <para>Versions: 8+</para>
        /// </summary>
        public OffsetFetchResponse WithGroupsCollection(params Func<OffsetFetchResponseGroup, OffsetFetchResponseGroup>[] createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new OffsetFetchResponseGroup(Version))).ToArray();
            return this;
        }

        public delegate OffsetFetchResponseGroup CreateOffsetFetchResponseGroup(OffsetFetchResponseGroup field);
        /// <summary>
        /// <para>The responses per group id.</para>
        /// <para>Versions: 8+</para>
        /// </summary>
        public OffsetFetchResponse WithGroupsCollection(IEnumerable<CreateOffsetFetchResponseGroup> createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new OffsetFetchResponseGroup(Version))).ToArray();
            return this;
        }

        public class OffsetFetchResponseGroup : ISerialize
        {
            internal OffsetFetchResponseGroup(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 8 ? _groupId.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _topicsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<OffsetFetchResponseGroup> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new OffsetFetchResponseGroup(version);
                if (instance.Version >= 8)
                    instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 8)
                    instance.TopicsCollection = await Array<OffsetFetchResponseTopics>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetFetchResponseTopics.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 8)
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetFetchResponseGroup is unknown");
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
                if (Version >= 8)
                    await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 8)
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public OffsetFetchResponseGroup WithGroupId(String groupId)
            {
                GroupId = groupId;
                return this;
            }

            private Array<OffsetFetchResponseTopics> _topicsCollection = Array.Empty<OffsetFetchResponseTopics>();
            /// <summary>
            /// <para>The responses per topic.</para>
            /// <para>Versions: 8+</para>
            /// </summary>
            public Array<OffsetFetchResponseTopics> TopicsCollection
            {
                get => _topicsCollection;
                private set
                {
                    if (Version >= 8 == false)
                        throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                    _topicsCollection = value;
                }
            }

            /// <summary>
            /// <para>The responses per topic.</para>
            /// <para>Versions: 8+</para>
            /// </summary>
            public OffsetFetchResponseGroup WithTopicsCollection(params Func<OffsetFetchResponseTopics, OffsetFetchResponseTopics>[] createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new OffsetFetchResponseTopics(Version))).ToArray();
                return this;
            }

            public delegate OffsetFetchResponseTopics CreateOffsetFetchResponseTopics(OffsetFetchResponseTopics field);
            /// <summary>
            /// <para>The responses per topic.</para>
            /// <para>Versions: 8+</para>
            /// </summary>
            public OffsetFetchResponseGroup WithTopicsCollection(IEnumerable<CreateOffsetFetchResponseTopics> createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new OffsetFetchResponseTopics(Version))).ToArray();
                return this;
            }

            public class OffsetFetchResponseTopics : ISerialize
            {
                internal OffsetFetchResponseTopics(Int16 version)
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
                internal int GetSize(bool _) => (Version >= 8 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _partitionsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<OffsetFetchResponseTopics> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new OffsetFetchResponseTopics(version);
                    if (instance.Version >= 8)
                        instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 8)
                        instance.PartitionsCollection = await Array<OffsetFetchResponsePartitions>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetFetchResponsePartitions.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetFetchResponseTopics is unknown");
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
                        await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public OffsetFetchResponseTopics WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private Array<OffsetFetchResponsePartitions> _partitionsCollection = Array.Empty<OffsetFetchResponsePartitions>();
                /// <summary>
                /// <para>The responses per partition</para>
                /// <para>Versions: 8+</para>
                /// </summary>
                public Array<OffsetFetchResponsePartitions> PartitionsCollection
                {
                    get => _partitionsCollection;
                    private set
                    {
                        if (Version >= 8 == false)
                            throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                        _partitionsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The responses per partition</para>
                /// <para>Versions: 8+</para>
                /// </summary>
                public OffsetFetchResponseTopics WithPartitionsCollection(params Func<OffsetFetchResponsePartitions, OffsetFetchResponsePartitions>[] createFields)
                {
                    PartitionsCollection = createFields.Select(createField => createField(new OffsetFetchResponsePartitions(Version))).ToArray();
                    return this;
                }

                public delegate OffsetFetchResponsePartitions CreateOffsetFetchResponsePartitions(OffsetFetchResponsePartitions field);
                /// <summary>
                /// <para>The responses per partition</para>
                /// <para>Versions: 8+</para>
                /// </summary>
                public OffsetFetchResponseTopics WithPartitionsCollection(IEnumerable<CreateOffsetFetchResponsePartitions> createFields)
                {
                    PartitionsCollection = createFields.Select(createField => createField(new OffsetFetchResponsePartitions(Version))).ToArray();
                    return this;
                }

                public class OffsetFetchResponsePartitions : ISerialize
                {
                    internal OffsetFetchResponsePartitions(Int16 version)
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
                    internal int GetSize(bool _) => (Version >= 8 ? _partitionIndex.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _committedOffset.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _committedLeaderEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _metadata.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<OffsetFetchResponsePartitions> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new OffsetFetchResponsePartitions(version);
                        if (instance.Version >= 8)
                            instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 8)
                            instance.CommittedOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 8)
                            instance.CommittedLeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 8)
                            instance.Metadata = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 8)
                            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetFetchResponsePartitions is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        if (Version >= 8)
                            await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 8)
                            await _committedOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 8)
                            await _committedLeaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 8)
                            await _metadata.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 8)
                            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int32 _partitionIndex = Int32.Default;
                    /// <summary>
                    /// <para>The partition index.</para>
                    /// <para>Versions: 8+</para>
                    /// </summary>
                    public Int32 PartitionIndex
                    {
                        get => _partitionIndex;
                        private set
                        {
                            if (Version >= 8 == false)
                                throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                            _partitionIndex = value;
                        }
                    }

                    /// <summary>
                    /// <para>The partition index.</para>
                    /// <para>Versions: 8+</para>
                    /// </summary>
                    public OffsetFetchResponsePartitions WithPartitionIndex(Int32 partitionIndex)
                    {
                        PartitionIndex = partitionIndex;
                        return this;
                    }

                    private Int64 _committedOffset = Int64.Default;
                    /// <summary>
                    /// <para>The committed message offset.</para>
                    /// <para>Versions: 8+</para>
                    /// </summary>
                    public Int64 CommittedOffset
                    {
                        get => _committedOffset;
                        private set
                        {
                            if (Version >= 8 == false)
                                throw new UnsupportedVersionException($"CommittedOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                            _committedOffset = value;
                        }
                    }

                    /// <summary>
                    /// <para>The committed message offset.</para>
                    /// <para>Versions: 8+</para>
                    /// </summary>
                    public OffsetFetchResponsePartitions WithCommittedOffset(Int64 committedOffset)
                    {
                        CommittedOffset = committedOffset;
                        return this;
                    }

                    private Int32 _committedLeaderEpoch = new Int32(-1);
                    /// <summary>
                    /// <para>The leader epoch.</para>
                    /// <para>Versions: 8+</para>
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
                    /// <para>The leader epoch.</para>
                    /// <para>Versions: 8+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public OffsetFetchResponsePartitions WithCommittedLeaderEpoch(Int32 committedLeaderEpoch)
                    {
                        CommittedLeaderEpoch = committedLeaderEpoch;
                        return this;
                    }

                    private NullableString _metadata = NullableString.Default;
                    /// <summary>
                    /// <para>The partition metadata.</para>
                    /// <para>Versions: 8+</para>
                    /// </summary>
                    public String? Metadata
                    {
                        get => _metadata;
                        private set
                        {
                            if (Version >= 8 == false)
                                throw new UnsupportedVersionException($"Metadata does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                            if (Version >= 8 == false && value == null)
                                throw new UnsupportedVersionException($"Metadata does not support null for version {Version}. Supported versions for null value: 8+");
                            _metadata = value;
                        }
                    }

                    /// <summary>
                    /// <para>The partition metadata.</para>
                    /// <para>Versions: 8+</para>
                    /// </summary>
                    public OffsetFetchResponsePartitions WithMetadata(String? metadata)
                    {
                        Metadata = metadata;
                        return this;
                    }

                    private Int16 _errorCode = Int16.Default;
                    /// <summary>
                    /// <para>The partition-level error code, or 0 if there was no error.</para>
                    /// <para>Versions: 8+</para>
                    /// </summary>
                    public Int16 ErrorCode
                    {
                        get => _errorCode;
                        private set
                        {
                            if (Version >= 8 == false)
                                throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                            _errorCode = value;
                        }
                    }

                    /// <summary>
                    /// <para>The partition-level error code, or 0 if there was no error.</para>
                    /// <para>Versions: 8+</para>
                    /// </summary>
                    public OffsetFetchResponsePartitions WithErrorCode(Int16 errorCode)
                    {
                        ErrorCode = errorCode;
                        return this;
                    }
                }
            }

            private Int16 _errorCode = new Int16(0);
            /// <summary>
            /// <para>The group-level error code, or 0 if there was no error.</para>
            /// <para>Versions: 8+</para>
            /// <para>Default: 0</para>
            /// </summary>
            public Int16 ErrorCode
            {
                get => _errorCode;
                private set
                {
                    if (Version >= 8 == false)
                        throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                    _errorCode = value;
                }
            }

            /// <summary>
            /// <para>The group-level error code, or 0 if there was no error.</para>
            /// <para>Versions: 8+</para>
            /// <para>Default: 0</para>
            /// </summary>
            public OffsetFetchResponseGroup WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }
        }
    }
}
