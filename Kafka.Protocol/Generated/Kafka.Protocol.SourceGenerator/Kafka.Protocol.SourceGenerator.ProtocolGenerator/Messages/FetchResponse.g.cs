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
    public class FetchResponse : Message
    {
        public FetchResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"FetchResponse does not support version {version}. Valid versions are: 0-17");
            Version = version;
            IsFlexibleVersion = version >= 12;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(1);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(17);
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
            var tags = new List<Tags.TaggedField>();
            if (Version >= 16 && _nodeEndpointsCollectionIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 0, Field = _nodeEndpointsCollection });
            }

            return new Tags.TagSection(tags.ToArray());
        }

        internal override int GetSize() => (Version >= 1 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + (Version >= 7 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + (Version >= 7 ? _sessionId.GetSize(IsFlexibleVersion) : 0) + _responsesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<FetchResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new FetchResponse(version);
            if (instance.Version >= 1)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 7)
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 7)
                instance.SessionId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ResponsesCollection = await Array<FetchableTopicResponse>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => FetchableTopicResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        case 0:
                            if (instance.Version >= 16)
                                instance.NodeEndpointsCollection = await Map<Int32, NodeEndpoint>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => NodeEndpoint.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.NodeId, cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field NodeEndpointsCollection is not supported for version {instance.Version}");
                        {
                            var size = instance._nodeEndpointsCollection.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field NodeEndpointsCollection read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for FetchResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 1)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 7)
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 7)
                await _sessionId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _responsesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 1+</para>
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
        /// <para>Versions: 1+</para>
        /// </summary>
        public FetchResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The top level response error code.</para>
        /// <para>Versions: 7+</para>
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
        /// <para>The top level response error code.</para>
        /// <para>Versions: 7+</para>
        /// </summary>
        public FetchResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Int32 _sessionId = new Int32(0);
        /// <summary>
        /// <para>The fetch session ID, or 0 if this is not part of a fetch session.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public Int32 SessionId
        {
            get => _sessionId;
            private set
            {
                if (Version >= 7 == false)
                    throw new UnsupportedVersionException($"SessionId does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
                _sessionId = value;
            }
        }

        /// <summary>
        /// <para>The fetch session ID, or 0 if this is not part of a fetch session.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public FetchResponse WithSessionId(Int32 sessionId)
        {
            SessionId = sessionId;
            return this;
        }

        private Array<FetchableTopicResponse> _responsesCollection = Array.Empty<FetchableTopicResponse>();
        /// <summary>
        /// <para>The response topics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<FetchableTopicResponse> ResponsesCollection
        {
            get => _responsesCollection;
            private set
            {
                _responsesCollection = value;
            }
        }

        /// <summary>
        /// <para>The response topics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchResponse WithResponsesCollection(params Func<FetchableTopicResponse, FetchableTopicResponse>[] createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new FetchableTopicResponse(Version))).ToArray();
            return this;
        }

        public delegate FetchableTopicResponse CreateFetchableTopicResponse(FetchableTopicResponse field);
        /// <summary>
        /// <para>The response topics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchResponse WithResponsesCollection(IEnumerable<CreateFetchableTopicResponse> createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new FetchableTopicResponse(Version))).ToArray();
            return this;
        }

        public class FetchableTopicResponse : ISerialize
        {
            internal FetchableTopicResponse(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 12;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 0 && Version <= 12 ? _topic.GetSize(IsFlexibleVersion) : 0) + (Version >= 13 ? _topicId.GetSize(IsFlexibleVersion) : 0) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<FetchableTopicResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new FetchableTopicResponse(version);
                if (instance.Version >= 0 && instance.Version <= 12)
                    instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 13)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<PartitionData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => PartitionData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for FetchableTopicResponse is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 0 && Version <= 12)
                    await _topic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 13)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topic = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0-12</para>
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
            /// <para>Versions: 0-12</para>
            /// </summary>
            public FetchableTopicResponse WithTopic(String topic)
            {
                Topic = topic;
                return this;
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The unique topic ID</para>
            /// <para>Versions: 13+</para>
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
            /// <para>The unique topic ID</para>
            /// <para>Versions: 13+</para>
            /// </summary>
            public FetchableTopicResponse WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<PartitionData> _partitionsCollection = Array.Empty<PartitionData>();
            /// <summary>
            /// <para>The topic partitions.</para>
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
            /// <para>The topic partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public FetchableTopicResponse WithPartitionsCollection(params Func<PartitionData, PartitionData>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionData(Version))).ToArray();
                return this;
            }

            public delegate PartitionData CreatePartitionData(PartitionData field);
            /// <summary>
            /// <para>The topic partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public FetchableTopicResponse WithPartitionsCollection(IEnumerable<CreatePartitionData> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionData(Version))).ToArray();
                return this;
            }

            public class PartitionData : ISerialize
            {
                internal PartitionData(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 12;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    var tags = new List<Tags.TaggedField>();
                    if (Version >= 12 && _divergingEpochIsSet)
                    {
                        tags.Add(new Tags.TaggedField { Tag = 0, Field = _divergingEpoch });
                    }

                    if (Version >= 12 && _currentLeaderIsSet)
                    {
                        tags.Add(new Tags.TaggedField { Tag = 1, Field = _currentLeader });
                    }

                    if (Version >= 12 && _snapshotIdIsSet)
                    {
                        tags.Add(new Tags.TaggedField { Tag = 2, Field = _snapshotId });
                    }

                    return new Tags.TagSection(tags.ToArray());
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _highWatermark.GetSize(IsFlexibleVersion) + (Version >= 4 ? _lastStableOffset.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _logStartOffset.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _abortedTransactionsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 11 ? _preferredReadReplica.GetSize(IsFlexibleVersion) : 0) + _records.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionData(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.HighWatermark = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 4)
                        instance.LastStableOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 5)
                        instance.LogStartOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 4)
                        instance.AbortedTransactionsCollection = await NullableArray<AbortedTransaction>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AbortedTransaction.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 11)
                        instance.PreferredReadReplica = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Records = await NullableRecordBatch.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                case 0:
                                    if (instance.Version >= 12)
                                        instance.DivergingEpoch = await EpochEndOffset.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                                    else
                                        throw new InvalidOperationException($"Field DivergingEpoch is not supported for version {instance.Version}");
                                {
                                    var size = instance._divergingEpoch.GetSize(true);
                                    if (size != tag.Length)
                                        throw new CorruptMessageException($"Tagged field DivergingEpoch read length {tag.Length} but had actual length of {size}");
                                }

                                    break;
                                case 1:
                                    if (instance.Version >= 12)
                                        instance.CurrentLeader = await LeaderIdAndEpoch.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                                    else
                                        throw new InvalidOperationException($"Field CurrentLeader is not supported for version {instance.Version}");
                                {
                                    var size = instance._currentLeader.GetSize(true);
                                    if (size != tag.Length)
                                        throw new CorruptMessageException($"Tagged field CurrentLeader read length {tag.Length} but had actual length of {size}");
                                }

                                    break;
                                case 2:
                                    if (instance.Version >= 12)
                                        instance.SnapshotId_ = await SnapshotId.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                                    else
                                        throw new InvalidOperationException($"Field SnapshotId_ is not supported for version {instance.Version}");
                                {
                                    var size = instance._snapshotId.GetSize(true);
                                    if (size != tag.Length)
                                        throw new CorruptMessageException($"Tagged field SnapshotId_ read length {tag.Length} but had actual length of {size}");
                                }

                                    break;
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
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _highWatermark.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 4)
                        await _lastStableOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 5)
                        await _logStartOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 4)
                        await _abortedTransactionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 11)
                        await _preferredReadReplica.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _records.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The error code, or 0 if there was no fetch error.</para>
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
                /// <para>The error code, or 0 if there was no fetch error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private Int64 _highWatermark = Int64.Default;
                /// <summary>
                /// <para>The current high water mark.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 HighWatermark
                {
                    get => _highWatermark;
                    private set
                    {
                        _highWatermark = value;
                    }
                }

                /// <summary>
                /// <para>The current high water mark.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithHighWatermark(Int64 highWatermark)
                {
                    HighWatermark = highWatermark;
                    return this;
                }

                private Int64 _lastStableOffset = new Int64(-1);
                /// <summary>
                /// <para>The last stable offset (or LSO) of the partition. This is the last offset such that the state of all transactional records prior to this offset have been decided (ABORTED or COMMITTED)</para>
                /// <para>Versions: 4+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int64 LastStableOffset
                {
                    get => _lastStableOffset;
                    private set
                    {
                        _lastStableOffset = value;
                    }
                }

                /// <summary>
                /// <para>The last stable offset (or LSO) of the partition. This is the last offset such that the state of all transactional records prior to this offset have been decided (ABORTED or COMMITTED)</para>
                /// <para>Versions: 4+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public PartitionData WithLastStableOffset(Int64 lastStableOffset)
                {
                    LastStableOffset = lastStableOffset;
                    return this;
                }

                private Int64 _logStartOffset = new Int64(-1);
                /// <summary>
                /// <para>The current log start offset.</para>
                /// <para>Versions: 5+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int64 LogStartOffset
                {
                    get => _logStartOffset;
                    private set
                    {
                        _logStartOffset = value;
                    }
                }

                /// <summary>
                /// <para>The current log start offset.</para>
                /// <para>Versions: 5+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public PartitionData WithLogStartOffset(Int64 logStartOffset)
                {
                    LogStartOffset = logStartOffset;
                    return this;
                }

                private bool _divergingEpochIsSet;
                private EpochEndOffset _divergingEpoch = default !;
                /// <summary>
                /// <para>In case divergence is detected based on the `LastFetchedEpoch` and `FetchOffset` in the request, this field indicates the largest epoch and its end offset such that subsequent records are known to diverge</para>
                /// <para>Versions: 12+</para>
                /// </summary>
                public EpochEndOffset DivergingEpoch
                {
                    get => _divergingEpoch;
                    private set
                    {
                        if (Version >= 12 == false)
                            throw new UnsupportedVersionException($"DivergingEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 12+");
                        _divergingEpoch = value;
                        _divergingEpochIsSet = true;
                    }
                }

                /// <summary>
                /// <para>In case divergence is detected based on the `LastFetchedEpoch` and `FetchOffset` in the request, this field indicates the largest epoch and its end offset such that subsequent records are known to diverge</para>
                /// <para>Versions: 12+</para>
                /// </summary>
                public PartitionData WithDivergingEpoch(Func<EpochEndOffset, EpochEndOffset> createField)
                {
                    DivergingEpoch = createField(new EpochEndOffset(Version));
                    return this;
                }

                public class EpochEndOffset : ISerialize
                {
                    internal EpochEndOffset(Int16 version)
                    {
                        Version = version;
                        IsFlexibleVersion = version >= 12;
                    }

                    internal Int16 Version { get; }
                    internal bool IsFlexibleVersion { get; }

                    private Tags.TagSection CreateTagSection()
                    {
                        return new Tags.TagSection();
                    }

                    int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                    internal int GetSize(bool _) => (Version >= 12 ? _epoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 12 ? _endOffset.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<EpochEndOffset> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new EpochEndOffset(version);
                        if (instance.Version >= 12)
                            instance.Epoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 12)
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
                        if (Version >= 12)
                            await _epoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 12)
                            await _endOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int32 _epoch = new Int32(-1);
                    /// <summary>
                    /// <para>Versions: 12+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int32 Epoch
                    {
                        get => _epoch;
                        private set
                        {
                            if (Version >= 12 == false)
                                throw new UnsupportedVersionException($"Epoch does not support version {Version} and has been defined as not ignorable. Supported versions: 12+");
                            _epoch = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 12+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public EpochEndOffset WithEpoch(Int32 epoch)
                    {
                        Epoch = epoch;
                        return this;
                    }

                    private Int64 _endOffset = new Int64(-1);
                    /// <summary>
                    /// <para>Versions: 12+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int64 EndOffset
                    {
                        get => _endOffset;
                        private set
                        {
                            if (Version >= 12 == false)
                                throw new UnsupportedVersionException($"EndOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 12+");
                            _endOffset = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 12+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public EpochEndOffset WithEndOffset(Int64 endOffset)
                    {
                        EndOffset = endOffset;
                        return this;
                    }
                }

                private bool _currentLeaderIsSet;
                private LeaderIdAndEpoch _currentLeader = default !;
                /// <summary>
                /// <para>Versions: 12+</para>
                /// </summary>
                public LeaderIdAndEpoch CurrentLeader
                {
                    get => _currentLeader;
                    private set
                    {
                        if (Version >= 12 == false)
                            throw new UnsupportedVersionException($"CurrentLeader does not support version {Version} and has been defined as not ignorable. Supported versions: 12+");
                        _currentLeader = value;
                        _currentLeaderIsSet = true;
                    }
                }

                /// <summary>
                /// <para>Versions: 12+</para>
                /// </summary>
                public PartitionData WithCurrentLeader(Func<LeaderIdAndEpoch, LeaderIdAndEpoch> createField)
                {
                    CurrentLeader = createField(new LeaderIdAndEpoch(Version));
                    return this;
                }

                public class LeaderIdAndEpoch : ISerialize
                {
                    internal LeaderIdAndEpoch(Int16 version)
                    {
                        Version = version;
                        IsFlexibleVersion = version >= 12;
                    }

                    internal Int16 Version { get; }
                    internal bool IsFlexibleVersion { get; }

                    private Tags.TagSection CreateTagSection()
                    {
                        return new Tags.TagSection();
                    }

                    int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                    internal int GetSize(bool _) => (Version >= 12 ? _leaderId.GetSize(IsFlexibleVersion) : 0) + (Version >= 12 ? _leaderEpoch.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<LeaderIdAndEpoch> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new LeaderIdAndEpoch(version);
                        if (instance.Version >= 12)
                            instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 12)
                            instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderIdAndEpoch is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        if (Version >= 12)
                            await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 12)
                            await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int32 _leaderId = new Int32(-1);
                    /// <summary>
                    /// <para>The ID of the current leader or -1 if the leader is unknown.</para>
                    /// <para>Versions: 12+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int32 LeaderId
                    {
                        get => _leaderId;
                        private set
                        {
                            if (Version >= 12 == false)
                                throw new UnsupportedVersionException($"LeaderId does not support version {Version} and has been defined as not ignorable. Supported versions: 12+");
                            _leaderId = value;
                        }
                    }

                    /// <summary>
                    /// <para>The ID of the current leader or -1 if the leader is unknown.</para>
                    /// <para>Versions: 12+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public LeaderIdAndEpoch WithLeaderId(Int32 leaderId)
                    {
                        LeaderId = leaderId;
                        return this;
                    }

                    private Int32 _leaderEpoch = new Int32(-1);
                    /// <summary>
                    /// <para>The latest known leader epoch</para>
                    /// <para>Versions: 12+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int32 LeaderEpoch
                    {
                        get => _leaderEpoch;
                        private set
                        {
                            if (Version >= 12 == false)
                                throw new UnsupportedVersionException($"LeaderEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 12+");
                            _leaderEpoch = value;
                        }
                    }

                    /// <summary>
                    /// <para>The latest known leader epoch</para>
                    /// <para>Versions: 12+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public LeaderIdAndEpoch WithLeaderEpoch(Int32 leaderEpoch)
                    {
                        LeaderEpoch = leaderEpoch;
                        return this;
                    }
                }

                private bool _snapshotIdIsSet;
                private SnapshotId _snapshotId = default !;
                /// <summary>
                /// <para>In the case of fetching an offset less than the LogStartOffset, this is the end offset and epoch that should be used in the FetchSnapshot request.</para>
                /// <para>Versions: 12+</para>
                /// </summary>
                public SnapshotId SnapshotId_
                {
                    get => _snapshotId;
                    private set
                    {
                        if (Version >= 12 == false)
                            throw new UnsupportedVersionException($"SnapshotId_ does not support version {Version} and has been defined as not ignorable. Supported versions: 12+");
                        _snapshotId = value;
                        _snapshotIdIsSet = true;
                    }
                }

                /// <summary>
                /// <para>In the case of fetching an offset less than the LogStartOffset, this is the end offset and epoch that should be used in the FetchSnapshot request.</para>
                /// <para>Versions: 12+</para>
                /// </summary>
                public PartitionData WithSnapshotId_(Func<SnapshotId, SnapshotId> createField)
                {
                    SnapshotId_ = createField(new SnapshotId(Version));
                    return this;
                }

                public class SnapshotId : ISerialize
                {
                    internal SnapshotId(Int16 version)
                    {
                        Version = version;
                        IsFlexibleVersion = version >= 12;
                    }

                    internal Int16 Version { get; }
                    internal bool IsFlexibleVersion { get; }

                    private Tags.TagSection CreateTagSection()
                    {
                        return new Tags.TagSection();
                    }

                    int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                    internal int GetSize(bool _) => _endOffset.GetSize(IsFlexibleVersion) + _epoch.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<SnapshotId> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new SnapshotId(version);
                        instance.EndOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.Epoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for SnapshotId is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        await _endOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _epoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int64 _endOffset = new Int64(-1);
                    /// <summary>
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
                    /// <para>Versions: 0+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public SnapshotId WithEndOffset(Int64 endOffset)
                    {
                        EndOffset = endOffset;
                        return this;
                    }

                    private Int32 _epoch = new Int32(-1);
                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int32 Epoch
                    {
                        get => _epoch;
                        private set
                        {
                            _epoch = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public SnapshotId WithEpoch(Int32 epoch)
                    {
                        Epoch = epoch;
                        return this;
                    }
                }

                private NullableArray<AbortedTransaction> _abortedTransactionsCollection = Array.Empty<AbortedTransaction>();
                /// <summary>
                /// <para>The aborted transactions.</para>
                /// <para>Versions: 4+</para>
                /// </summary>
                public Array<AbortedTransaction>? AbortedTransactionsCollection
                {
                    get => _abortedTransactionsCollection;
                    private set
                    {
                        if (Version >= 4 == false && value == null)
                            throw new UnsupportedVersionException($"AbortedTransactionsCollection does not support null for version {Version}. Supported versions for null value: 4+");
                        _abortedTransactionsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The aborted transactions.</para>
                /// <para>Versions: 4+</para>
                /// </summary>
                public PartitionData WithAbortedTransactionsCollection(params Func<AbortedTransaction, AbortedTransaction>[] createFields)
                {
                    AbortedTransactionsCollection = createFields.Select(createField => createField(new AbortedTransaction(Version))).ToArray();
                    return this;
                }

                public delegate AbortedTransaction CreateAbortedTransaction(AbortedTransaction field);
                /// <summary>
                /// <para>The aborted transactions.</para>
                /// <para>Versions: 4+</para>
                /// </summary>
                public PartitionData WithAbortedTransactionsCollection(IEnumerable<CreateAbortedTransaction> createFields)
                {
                    AbortedTransactionsCollection = createFields.Select(createField => createField(new AbortedTransaction(Version))).ToArray();
                    return this;
                }

                public class AbortedTransaction : ISerialize
                {
                    internal AbortedTransaction(Int16 version)
                    {
                        Version = version;
                        IsFlexibleVersion = version >= 12;
                    }

                    internal Int16 Version { get; }
                    internal bool IsFlexibleVersion { get; }

                    private Tags.TagSection CreateTagSection()
                    {
                        return new Tags.TagSection();
                    }

                    int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                    internal int GetSize(bool _) => (Version >= 4 ? _producerId.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _firstOffset.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<AbortedTransaction> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new AbortedTransaction(version);
                        if (instance.Version >= 4)
                            instance.ProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 4)
                            instance.FirstOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for AbortedTransaction is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        if (Version >= 4)
                            await _producerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 4)
                            await _firstOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int64 _producerId = Int64.Default;
                    /// <summary>
                    /// <para>The producer id associated with the aborted transaction.</para>
                    /// <para>Versions: 4+</para>
                    /// </summary>
                    public Int64 ProducerId
                    {
                        get => _producerId;
                        private set
                        {
                            if (Version >= 4 == false)
                                throw new UnsupportedVersionException($"ProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                            _producerId = value;
                        }
                    }

                    /// <summary>
                    /// <para>The producer id associated with the aborted transaction.</para>
                    /// <para>Versions: 4+</para>
                    /// </summary>
                    public AbortedTransaction WithProducerId(Int64 producerId)
                    {
                        ProducerId = producerId;
                        return this;
                    }

                    private Int64 _firstOffset = Int64.Default;
                    /// <summary>
                    /// <para>The first offset in the aborted transaction.</para>
                    /// <para>Versions: 4+</para>
                    /// </summary>
                    public Int64 FirstOffset
                    {
                        get => _firstOffset;
                        private set
                        {
                            if (Version >= 4 == false)
                                throw new UnsupportedVersionException($"FirstOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                            _firstOffset = value;
                        }
                    }

                    /// <summary>
                    /// <para>The first offset in the aborted transaction.</para>
                    /// <para>Versions: 4+</para>
                    /// </summary>
                    public AbortedTransaction WithFirstOffset(Int64 firstOffset)
                    {
                        FirstOffset = firstOffset;
                        return this;
                    }
                }

                private Int32 _preferredReadReplica = new Int32(-1);
                /// <summary>
                /// <para>The preferred read replica for the consumer to use on its next fetch request</para>
                /// <para>Versions: 11+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int32 PreferredReadReplica
                {
                    get => _preferredReadReplica;
                    private set
                    {
                        if (Version >= 11 == false)
                            throw new UnsupportedVersionException($"PreferredReadReplica does not support version {Version} and has been defined as not ignorable. Supported versions: 11+");
                        _preferredReadReplica = value;
                    }
                }

                /// <summary>
                /// <para>The preferred read replica for the consumer to use on its next fetch request</para>
                /// <para>Versions: 11+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public PartitionData WithPreferredReadReplica(Int32 preferredReadReplica)
                {
                    PreferredReadReplica = preferredReadReplica;
                    return this;
                }

                private NullableRecordBatch _records = NullableRecordBatch.Default;
                /// <summary>
                /// <para>The record data.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public RecordBatch? Records
                {
                    get => _records;
                    private set
                    {
                        _records = value;
                    }
                }

                /// <summary>
                /// <para>The record data.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithRecords(RecordBatch? records)
                {
                    Records = records;
                    return this;
                }
            }
        }

        private bool _nodeEndpointsCollectionIsSet;
        private Map<Int32, NodeEndpoint> _nodeEndpointsCollection = Map<Int32, NodeEndpoint>.Default;
        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionData, with errors NOT_LEADER_OR_FOLLOWER & FENCED_LEADER_EPOCH.</para>
        /// <para>Versions: 16+</para>
        /// </summary>
        public Map<Int32, NodeEndpoint> NodeEndpointsCollection
        {
            get => _nodeEndpointsCollection;
            private set
            {
                if (Version >= 16 == false)
                    throw new UnsupportedVersionException($"NodeEndpointsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 16+");
                _nodeEndpointsCollection = value;
                _nodeEndpointsCollectionIsSet = true;
            }
        }

        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionData, with errors NOT_LEADER_OR_FOLLOWER & FENCED_LEADER_EPOCH.</para>
        /// <para>Versions: 16+</para>
        /// </summary>
        public FetchResponse WithNodeEndpointsCollection(params Func<NodeEndpoint, NodeEndpoint>[] createFields)
        {
            NodeEndpointsCollection = createFields.Select(createField => createField(new NodeEndpoint(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public delegate NodeEndpoint CreateNodeEndpoint(NodeEndpoint field);
        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionData, with errors NOT_LEADER_OR_FOLLOWER & FENCED_LEADER_EPOCH.</para>
        /// <para>Versions: 16+</para>
        /// </summary>
        public FetchResponse WithNodeEndpointsCollection(IEnumerable<CreateNodeEndpoint> createFields)
        {
            NodeEndpointsCollection = createFields.Select(createField => createField(new NodeEndpoint(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public class NodeEndpoint : ISerialize
        {
            internal NodeEndpoint(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 12;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 16 ? _nodeId.GetSize(IsFlexibleVersion) : 0) + (Version >= 16 ? _host.GetSize(IsFlexibleVersion) : 0) + (Version >= 16 ? _port.GetSize(IsFlexibleVersion) : 0) + (Version >= 16 ? _rack.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<NodeEndpoint> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new NodeEndpoint(version);
                if (instance.Version >= 16)
                    instance.NodeId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 16)
                    instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 16)
                    instance.Port = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 16)
                    instance.Rack = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for NodeEndpoint is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 16)
                    await _nodeId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 16)
                    await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 16)
                    await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 16)
                    await _rack.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _nodeId = Int32.Default;
            /// <summary>
            /// <para>The ID of the associated node.</para>
            /// <para>Versions: 16+</para>
            /// </summary>
            public Int32 NodeId
            {
                get => _nodeId;
                private set
                {
                    if (Version >= 16 == false)
                        throw new UnsupportedVersionException($"NodeId does not support version {Version} and has been defined as not ignorable. Supported versions: 16+");
                    _nodeId = value;
                }
            }

            /// <summary>
            /// <para>The ID of the associated node.</para>
            /// <para>Versions: 16+</para>
            /// </summary>
            public NodeEndpoint WithNodeId(Int32 nodeId)
            {
                NodeId = nodeId;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The node's hostname.</para>
            /// <para>Versions: 16+</para>
            /// </summary>
            public String Host
            {
                get => _host;
                private set
                {
                    if (Version >= 16 == false)
                        throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 16+");
                    _host = value;
                }
            }

            /// <summary>
            /// <para>The node's hostname.</para>
            /// <para>Versions: 16+</para>
            /// </summary>
            public NodeEndpoint WithHost(String host)
            {
                Host = host;
                return this;
            }

            private Int32 _port = Int32.Default;
            /// <summary>
            /// <para>The node's port.</para>
            /// <para>Versions: 16+</para>
            /// </summary>
            public Int32 Port
            {
                get => _port;
                private set
                {
                    if (Version >= 16 == false)
                        throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 16+");
                    _port = value;
                }
            }

            /// <summary>
            /// <para>The node's port.</para>
            /// <para>Versions: 16+</para>
            /// </summary>
            public NodeEndpoint WithPort(Int32 port)
            {
                Port = port;
                return this;
            }

            private NullableString _rack = new NullableString(null);
            /// <summary>
            /// <para>The rack of the node, or null if it has not been assigned to a rack.</para>
            /// <para>Versions: 16+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? Rack
            {
                get => _rack;
                private set
                {
                    if (Version >= 16 == false)
                        throw new UnsupportedVersionException($"Rack does not support version {Version} and has been defined as not ignorable. Supported versions: 16+");
                    if (Version >= 16 == false && value == null)
                        throw new UnsupportedVersionException($"Rack does not support null for version {Version}. Supported versions for null value: 16+");
                    _rack = value;
                }
            }

            /// <summary>
            /// <para>The rack of the node, or null if it has not been assigned to a rack.</para>
            /// <para>Versions: 16+</para>
            /// <para>Default: null</para>
            /// </summary>
            public NodeEndpoint WithRack(String? rack)
            {
                Rack = rack;
                return this;
            }
        }
    }
}
