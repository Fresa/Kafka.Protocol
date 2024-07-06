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
    public class OffsetForLeaderEpochResponse : Message
    {
        public OffsetForLeaderEpochResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"OffsetForLeaderEpochResponse does not support version {version}. Valid versions are: 0-4");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(23);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(4);
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

        internal override int GetSize() => (Version >= 2 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<OffsetForLeaderEpochResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new OffsetForLeaderEpochResponse(version);
            if (instance.Version >= 2)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Map<String, OffsetForLeaderTopicResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OffsetForLeaderTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Topic, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetForLeaderEpochResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 2)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 2+</para>
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
        /// <para>Versions: 2+</para>
        /// </summary>
        public OffsetForLeaderEpochResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Map<String, OffsetForLeaderTopicResult> _topicsCollection = Map<String, OffsetForLeaderTopicResult>.Default;
        /// <summary>
        /// <para>Each topic we fetched offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, OffsetForLeaderTopicResult> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic we fetched offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public OffsetForLeaderEpochResponse WithTopicsCollection(params Func<OffsetForLeaderTopicResult, OffsetForLeaderTopicResult>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetForLeaderTopicResult(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public delegate OffsetForLeaderTopicResult CreateOffsetForLeaderTopicResult(OffsetForLeaderTopicResult field);
        /// <summary>
        /// <para>Each topic we fetched offsets for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public OffsetForLeaderEpochResponse WithTopicsCollection(IEnumerable<CreateOffsetForLeaderTopicResult> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OffsetForLeaderTopicResult(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public class OffsetForLeaderTopicResult : ISerialize
        {
            internal OffsetForLeaderTopicResult(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 4;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _topic.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<OffsetForLeaderTopicResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new OffsetForLeaderTopicResult(version);
                instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<EpochEndOffset>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => EpochEndOffset.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for OffsetForLeaderTopicResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topic = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Topic
            {
                get => _topic;
                private set
                {
                    _topic = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetForLeaderTopicResult WithTopic(String topic)
            {
                Topic = topic;
                return this;
            }

            private Array<EpochEndOffset> _partitionsCollection = Array.Empty<EpochEndOffset>();
            /// <summary>
            /// <para>Each partition in the topic we fetched offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<EpochEndOffset> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition in the topic we fetched offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetForLeaderTopicResult WithPartitionsCollection(params Func<EpochEndOffset, EpochEndOffset>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new EpochEndOffset(Version))).ToArray();
                return this;
            }

            public delegate EpochEndOffset CreateEpochEndOffset(EpochEndOffset field);
            /// <summary>
            /// <para>Each partition in the topic we fetched offsets for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OffsetForLeaderTopicResult WithPartitionsCollection(IEnumerable<CreateEpochEndOffset> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new EpochEndOffset(Version))).ToArray();
                return this;
            }

            public class EpochEndOffset : ISerialize
            {
                internal EpochEndOffset(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 4;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _partition.GetSize(IsFlexibleVersion) + (Version >= 1 ? _leaderEpoch.GetSize(IsFlexibleVersion) : 0) + _endOffset.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<EpochEndOffset> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new EpochEndOffset(version);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Partition = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.EndOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for EpochEndOffset is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _partition.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _endOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The error code 0, or if there was no error.</para>
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
                /// <para>The error code 0, or if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public EpochEndOffset WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
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
                public EpochEndOffset WithPartition(Int32 partition)
                {
                    Partition = partition;
                    return this;
                }

                private Int32 _leaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>The leader epoch of the partition.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: -1</para>
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
                /// <para>Versions: 1+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public EpochEndOffset WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }

                private Int64 _endOffset = new Int64(-1);
                /// <summary>
                /// <para>The end offset of the epoch.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int64 EndOffset
                {
                    get => _endOffset;
                    private set
                    {
                        _endOffset = value;
                    }
                }

                /// <summary>
                /// <para>The end offset of the epoch.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public EpochEndOffset WithEndOffset(Int64 endOffset)
                {
                    EndOffset = endOffset;
                    return this;
                }
            }
        }
    }
}
