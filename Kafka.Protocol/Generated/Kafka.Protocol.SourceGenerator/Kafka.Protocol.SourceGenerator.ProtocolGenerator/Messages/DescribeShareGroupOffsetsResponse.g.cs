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
    public class DescribeShareGroupOffsetsResponse : Message
    {
        public DescribeShareGroupOffsetsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeShareGroupOffsetsResponse does not support version {version}. Valid versions are: 0-1");
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
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _groupsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeShareGroupOffsetsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeShareGroupOffsetsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.GroupsCollection = await Array<DescribeShareGroupOffsetsResponseGroup>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeShareGroupOffsetsResponseGroup.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeShareGroupOffsetsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _groupsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public DescribeShareGroupOffsetsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Array<DescribeShareGroupOffsetsResponseGroup> _groupsCollection = Array.Empty<DescribeShareGroupOffsetsResponseGroup>();
        /// <summary>
        /// <para>The results for each group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DescribeShareGroupOffsetsResponseGroup> GroupsCollection
        {
            get => _groupsCollection;
            private set
            {
                _groupsCollection = value;
            }
        }

        /// <summary>
        /// <para>The results for each group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeShareGroupOffsetsResponse WithGroupsCollection(params Func<DescribeShareGroupOffsetsResponseGroup, DescribeShareGroupOffsetsResponseGroup>[] createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new DescribeShareGroupOffsetsResponseGroup(Version))).ToArray();
            return this;
        }

        public delegate DescribeShareGroupOffsetsResponseGroup CreateDescribeShareGroupOffsetsResponseGroup(DescribeShareGroupOffsetsResponseGroup field);
        /// <summary>
        /// <para>The results for each group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeShareGroupOffsetsResponse WithGroupsCollection(IEnumerable<CreateDescribeShareGroupOffsetsResponseGroup> createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new DescribeShareGroupOffsetsResponseGroup(Version))).ToArray();
            return this;
        }

        public class DescribeShareGroupOffsetsResponseGroup : ISerialize
        {
            internal DescribeShareGroupOffsetsResponseGroup(Int16 version)
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
            internal int GetSize(bool _) => _groupId.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribeShareGroupOffsetsResponseGroup> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribeShareGroupOffsetsResponseGroup(version);
                instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicsCollection = await Array<DescribeShareGroupOffsetsResponseTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeShareGroupOffsetsResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeShareGroupOffsetsResponseGroup is unknown");
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
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public DescribeShareGroupOffsetsResponseGroup WithGroupId(String groupId)
            {
                GroupId = groupId;
                return this;
            }

            private Array<DescribeShareGroupOffsetsResponseTopic> _topicsCollection = Array.Empty<DescribeShareGroupOffsetsResponseTopic>();
            /// <summary>
            /// <para>The results for each topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<DescribeShareGroupOffsetsResponseTopic> TopicsCollection
            {
                get => _topicsCollection;
                private set
                {
                    _topicsCollection = value;
                }
            }

            /// <summary>
            /// <para>The results for each topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeShareGroupOffsetsResponseGroup WithTopicsCollection(params Func<DescribeShareGroupOffsetsResponseTopic, DescribeShareGroupOffsetsResponseTopic>[] createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new DescribeShareGroupOffsetsResponseTopic(Version))).ToArray();
                return this;
            }

            public delegate DescribeShareGroupOffsetsResponseTopic CreateDescribeShareGroupOffsetsResponseTopic(DescribeShareGroupOffsetsResponseTopic field);
            /// <summary>
            /// <para>The results for each topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeShareGroupOffsetsResponseGroup WithTopicsCollection(IEnumerable<CreateDescribeShareGroupOffsetsResponseTopic> createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new DescribeShareGroupOffsetsResponseTopic(Version))).ToArray();
                return this;
            }

            public class DescribeShareGroupOffsetsResponseTopic : ISerialize
            {
                internal DescribeShareGroupOffsetsResponseTopic(Int16 version)
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
                internal int GetSize(bool _) => _topicName.GetSize(IsFlexibleVersion) + _topicId.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<DescribeShareGroupOffsetsResponseTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new DescribeShareGroupOffsetsResponseTopic(version);
                    instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionsCollection = await Array<DescribeShareGroupOffsetsResponsePartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeShareGroupOffsetsResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeShareGroupOffsetsResponseTopic is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public DescribeShareGroupOffsetsResponseTopic WithTopicName(String topicName)
                {
                    TopicName = topicName;
                    return this;
                }

                private Uuid _topicId = Uuid.Default;
                /// <summary>
                /// <para>The unique topic ID.</para>
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
                /// <para>The unique topic ID.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeShareGroupOffsetsResponseTopic WithTopicId(Uuid topicId)
                {
                    TopicId = topicId;
                    return this;
                }

                private Array<DescribeShareGroupOffsetsResponsePartition> _partitionsCollection = Array.Empty<DescribeShareGroupOffsetsResponsePartition>();
                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<DescribeShareGroupOffsetsResponsePartition> PartitionsCollection
                {
                    get => _partitionsCollection;
                    private set
                    {
                        _partitionsCollection = value;
                    }
                }

                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeShareGroupOffsetsResponseTopic WithPartitionsCollection(params Func<DescribeShareGroupOffsetsResponsePartition, DescribeShareGroupOffsetsResponsePartition>[] createFields)
                {
                    PartitionsCollection = createFields.Select(createField => createField(new DescribeShareGroupOffsetsResponsePartition(Version))).ToArray();
                    return this;
                }

                public delegate DescribeShareGroupOffsetsResponsePartition CreateDescribeShareGroupOffsetsResponsePartition(DescribeShareGroupOffsetsResponsePartition field);
                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeShareGroupOffsetsResponseTopic WithPartitionsCollection(IEnumerable<CreateDescribeShareGroupOffsetsResponsePartition> createFields)
                {
                    PartitionsCollection = createFields.Select(createField => createField(new DescribeShareGroupOffsetsResponsePartition(Version))).ToArray();
                    return this;
                }

                public class DescribeShareGroupOffsetsResponsePartition : ISerialize
                {
                    internal DescribeShareGroupOffsetsResponsePartition(Int16 version)
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
                    internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _startOffset.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + (Version >= 1 ? _lag.GetSize(IsFlexibleVersion) : 0) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<DescribeShareGroupOffsetsResponsePartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new DescribeShareGroupOffsetsResponsePartition(version);
                        instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.StartOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 1)
                            instance.Lag = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeShareGroupOffsetsResponsePartition is unknown");
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
                        await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 1)
                            await _lag.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                    public DescribeShareGroupOffsetsResponsePartition WithPartitionIndex(Int32 partitionIndex)
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
                    public DescribeShareGroupOffsetsResponsePartition WithStartOffset(Int64 startOffset)
                    {
                        StartOffset = startOffset;
                        return this;
                    }

                    private Int32 _leaderEpoch = Int32.Default;
                    /// <summary>
                    /// <para>The leader epoch of the partition.</para>
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
                    /// <para>The leader epoch of the partition.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public DescribeShareGroupOffsetsResponsePartition WithLeaderEpoch(Int32 leaderEpoch)
                    {
                        LeaderEpoch = leaderEpoch;
                        return this;
                    }

                    private Int64 _lag = new Int64(-1);
                    /// <summary>
                    /// <para>The share-partition lag.</para>
                    /// <para>Versions: 1+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int64 Lag
                    {
                        get => _lag;
                        private set
                        {
                            _lag = value;
                        }
                    }

                    /// <summary>
                    /// <para>The share-partition lag.</para>
                    /// <para>Versions: 1+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public DescribeShareGroupOffsetsResponsePartition WithLag(Int64 lag)
                    {
                        Lag = lag;
                        return this;
                    }

                    private Int16 _errorCode = Int16.Default;
                    /// <summary>
                    /// <para>The partition-level error code, or 0 if there was no error.</para>
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
                    /// <para>The partition-level error code, or 0 if there was no error.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public DescribeShareGroupOffsetsResponsePartition WithErrorCode(Int16 errorCode)
                    {
                        ErrorCode = errorCode;
                        return this;
                    }

                    private NullableString _errorMessage = new NullableString(null);
                    /// <summary>
                    /// <para>The partition-level error message, or null if there was no error.</para>
                    /// <para>Versions: 0+</para>
                    /// <para>Default: null</para>
                    /// </summary>
                    public String? ErrorMessage
                    {
                        get => _errorMessage;
                        private set
                        {
                            _errorMessage = value;
                        }
                    }

                    /// <summary>
                    /// <para>The partition-level error message, or null if there was no error.</para>
                    /// <para>Versions: 0+</para>
                    /// <para>Default: null</para>
                    /// </summary>
                    public DescribeShareGroupOffsetsResponsePartition WithErrorMessage(String? errorMessage)
                    {
                        ErrorMessage = errorMessage;
                        return this;
                    }
                }
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The group-level error code, or 0 if there was no error.</para>
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
            /// <para>The group-level error code, or 0 if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeShareGroupOffsetsResponseGroup WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _errorMessage = new NullableString(null);
            /// <summary>
            /// <para>The group-level error message, or null if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? ErrorMessage
            {
                get => _errorMessage;
                private set
                {
                    _errorMessage = value;
                }
            }

            /// <summary>
            /// <para>The group-level error message, or null if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public DescribeShareGroupOffsetsResponseGroup WithErrorMessage(String? errorMessage)
            {
                ErrorMessage = errorMessage;
                return this;
            }
        }
    }
}
