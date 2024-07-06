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
    public class FetchRequest : Message, IRespond<FetchResponse>
    {
        public FetchRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"FetchRequest does not support version {version}. Valid versions are: 0-16");
            Version = version;
            IsFlexibleVersion = version >= 12;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(1);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(16);
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
            var tags = new List<Tags.TaggedField>();
            if (Version >= 12 && _clusterIdIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 0, Field = _clusterId });
            }

            if (Version >= 15 && _replicaStateIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 1, Field = _replicaState });
            }

            return new Tags.TagSection(tags.ToArray());
        }

        internal override int GetSize() => _maxWaitMs.GetSize(IsFlexibleVersion) + _minBytes.GetSize(IsFlexibleVersion) + (Version >= 3 ? _maxBytes.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _isolationLevel.GetSize(IsFlexibleVersion) : 0) + (Version >= 7 ? _sessionId.GetSize(IsFlexibleVersion) : 0) + (Version >= 7 ? _sessionEpoch.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (Version >= 7 ? _forgottenTopicsDataCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 11 ? _rackId.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<FetchRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new FetchRequest(version);
            if (instance.Version >= 0 && instance.Version <= 14)
                instance.ReplicaId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MaxWaitMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MinBytes = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.MaxBytes = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 4)
                instance.IsolationLevel = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 7)
                instance.SessionId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 7)
                instance.SessionEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<FetchTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => FetchTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 7)
                instance.ForgottenTopicsDataCollection = await Array<ForgottenTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ForgottenTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 11)
                instance.RackId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        case 0:
                            if (instance.Version >= 12)
                                instance.ClusterId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field ClusterId is not supported for version {instance.Version}");
                        {
                            var size = instance._clusterId.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field ClusterId read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        case 1:
                            if (instance.Version >= 15)
                                instance.ReplicaState_ = await ReplicaState.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field ReplicaState_ is not supported for version {instance.Version}");
                        {
                            var size = instance._replicaState.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field ReplicaState_ read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for FetchRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 0 && Version <= 14)
                await _replicaId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _maxWaitMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _minBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _maxBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 4)
                await _isolationLevel.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 7)
                await _sessionId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 7)
                await _sessionEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 7)
                await _forgottenTopicsDataCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 11)
                await _rackId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private bool _clusterIdIsSet;
        private NullableString _clusterId = new NullableString(null);
        /// <summary>
        /// <para>The clusterId if known. This is used to validate metadata fetches prior to broker registration.</para>
        /// <para>Versions: 12+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ClusterId
        {
            get => _clusterId;
            private set
            {
                if (Version >= 12 == false && value == null)
                    throw new UnsupportedVersionException($"ClusterId does not support null for version {Version}. Supported versions for null value: 12+");
                _clusterId = value;
                _clusterIdIsSet = true;
            }
        }

        /// <summary>
        /// <para>The clusterId if known. This is used to validate metadata fetches prior to broker registration.</para>
        /// <para>Versions: 12+</para>
        /// <para>Default: null</para>
        /// </summary>
        public FetchRequest WithClusterId(String? clusterId)
        {
            ClusterId = clusterId;
            return this;
        }

        private Int32 _replicaId = new Int32(-1);
        /// <summary>
        /// <para>The broker ID of the follower, of -1 if this request is from a consumer.</para>
        /// <para>Versions: 0-14</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int32 ReplicaId
        {
            get => _replicaId;
            private set
            {
                if (Version >= 0 && Version <= 14 == false)
                    throw new UnsupportedVersionException($"ReplicaId does not support version {Version} and has been defined as not ignorable. Supported versions: 0-14");
                _replicaId = value;
            }
        }

        /// <summary>
        /// <para>The broker ID of the follower, of -1 if this request is from a consumer.</para>
        /// <para>Versions: 0-14</para>
        /// <para>Default: -1</para>
        /// </summary>
        public FetchRequest WithReplicaId(Int32 replicaId)
        {
            ReplicaId = replicaId;
            return this;
        }

        private bool _replicaStateIsSet;
        private ReplicaState _replicaState = default !;
        /// <summary>
        /// <para>Versions: 15+</para>
        /// </summary>
        public ReplicaState ReplicaState_
        {
            get => _replicaState;
            private set
            {
                if (Version >= 15 == false)
                    throw new UnsupportedVersionException($"ReplicaState_ does not support version {Version} and has been defined as not ignorable. Supported versions: 15+");
                _replicaState = value;
                _replicaStateIsSet = true;
            }
        }

        /// <summary>
        /// <para>Versions: 15+</para>
        /// </summary>
        public FetchRequest WithReplicaState_(Func<ReplicaState, ReplicaState> createField)
        {
            ReplicaState_ = createField(new ReplicaState(Version));
            return this;
        }

        public class ReplicaState : ISerialize
        {
            internal ReplicaState(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 15 ? _replicaId.GetSize(IsFlexibleVersion) : 0) + (Version >= 15 ? _replicaEpoch.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ReplicaState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ReplicaState(version);
                if (instance.Version >= 15)
                    instance.ReplicaId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 15)
                    instance.ReplicaEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ReplicaState is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 15)
                    await _replicaId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 15)
                    await _replicaEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _replicaId = new Int32(-1);
            /// <summary>
            /// <para>The replica ID of the follower, or -1 if this request is from a consumer.</para>
            /// <para>Versions: 15+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public Int32 ReplicaId
            {
                get => _replicaId;
                private set
                {
                    if (Version >= 15 == false)
                        throw new UnsupportedVersionException($"ReplicaId does not support version {Version} and has been defined as not ignorable. Supported versions: 15+");
                    _replicaId = value;
                }
            }

            /// <summary>
            /// <para>The replica ID of the follower, or -1 if this request is from a consumer.</para>
            /// <para>Versions: 15+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public ReplicaState WithReplicaId(Int32 replicaId)
            {
                ReplicaId = replicaId;
                return this;
            }

            private Int64 _replicaEpoch = new Int64(-1);
            /// <summary>
            /// <para>The epoch of this follower, or -1 if not available.</para>
            /// <para>Versions: 15+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public Int64 ReplicaEpoch
            {
                get => _replicaEpoch;
                private set
                {
                    if (Version >= 15 == false)
                        throw new UnsupportedVersionException($"ReplicaEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 15+");
                    _replicaEpoch = value;
                }
            }

            /// <summary>
            /// <para>The epoch of this follower, or -1 if not available.</para>
            /// <para>Versions: 15+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public ReplicaState WithReplicaEpoch(Int64 replicaEpoch)
            {
                ReplicaEpoch = replicaEpoch;
                return this;
            }
        }

        private Int32 _maxWaitMs = Int32.Default;
        /// <summary>
        /// <para>The maximum time in milliseconds to wait for the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 MaxWaitMs
        {
            get => _maxWaitMs;
            private set
            {
                _maxWaitMs = value;
            }
        }

        /// <summary>
        /// <para>The maximum time in milliseconds to wait for the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchRequest WithMaxWaitMs(Int32 maxWaitMs)
        {
            MaxWaitMs = maxWaitMs;
            return this;
        }

        private Int32 _minBytes = Int32.Default;
        /// <summary>
        /// <para>The minimum bytes to accumulate in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 MinBytes
        {
            get => _minBytes;
            private set
            {
                _minBytes = value;
            }
        }

        /// <summary>
        /// <para>The minimum bytes to accumulate in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchRequest WithMinBytes(Int32 minBytes)
        {
            MinBytes = minBytes;
            return this;
        }

        private Int32 _maxBytes = new Int32(0x7fffffff);
        /// <summary>
        /// <para>The maximum bytes to fetch.  See KIP-74 for cases where this limit may not be honored.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: 0x7fffffff</para>
        /// </summary>
        public Int32 MaxBytes
        {
            get => _maxBytes;
            private set
            {
                _maxBytes = value;
            }
        }

        /// <summary>
        /// <para>The maximum bytes to fetch.  See KIP-74 for cases where this limit may not be honored.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: 0x7fffffff</para>
        /// </summary>
        public FetchRequest WithMaxBytes(Int32 maxBytes)
        {
            MaxBytes = maxBytes;
            return this;
        }

        private Int8 _isolationLevel = new Int8(0);
        /// <summary>
        /// <para>This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records</para>
        /// <para>Versions: 4+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public Int8 IsolationLevel
        {
            get => _isolationLevel;
            private set
            {
                _isolationLevel = value;
            }
        }

        /// <summary>
        /// <para>This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records</para>
        /// <para>Versions: 4+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public FetchRequest WithIsolationLevel(Int8 isolationLevel)
        {
            IsolationLevel = isolationLevel;
            return this;
        }

        private Int32 _sessionId = new Int32(0);
        /// <summary>
        /// <para>The fetch session ID.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public Int32 SessionId
        {
            get => _sessionId;
            private set
            {
                _sessionId = value;
            }
        }

        /// <summary>
        /// <para>The fetch session ID.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public FetchRequest WithSessionId(Int32 sessionId)
        {
            SessionId = sessionId;
            return this;
        }

        private Int32 _sessionEpoch = new Int32(-1);
        /// <summary>
        /// <para>The fetch session epoch, which is used for ordering requests in a session.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int32 SessionEpoch
        {
            get => _sessionEpoch;
            private set
            {
                _sessionEpoch = value;
            }
        }

        /// <summary>
        /// <para>The fetch session epoch, which is used for ordering requests in a session.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public FetchRequest WithSessionEpoch(Int32 sessionEpoch)
        {
            SessionEpoch = sessionEpoch;
            return this;
        }

        private Array<FetchTopic> _topicsCollection = Array.Empty<FetchTopic>();
        /// <summary>
        /// <para>The topics to fetch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<FetchTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to fetch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchRequest WithTopicsCollection(params Func<FetchTopic, FetchTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new FetchTopic(Version))).ToArray();
            return this;
        }

        public delegate FetchTopic CreateFetchTopic(FetchTopic field);
        /// <summary>
        /// <para>The topics to fetch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public FetchRequest WithTopicsCollection(IEnumerable<CreateFetchTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new FetchTopic(Version))).ToArray();
            return this;
        }

        public class FetchTopic : ISerialize
        {
            internal FetchTopic(Int16 version)
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
            internal static async ValueTask<FetchTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new FetchTopic(version);
                if (instance.Version >= 0 && instance.Version <= 12)
                    instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 13)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<FetchPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => FetchPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for FetchTopic is unknown");
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
            /// <para>The name of the topic to fetch.</para>
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
            /// <para>The name of the topic to fetch.</para>
            /// <para>Versions: 0-12</para>
            /// </summary>
            public FetchTopic WithTopic(String topic)
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
            public FetchTopic WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<FetchPartition> _partitionsCollection = Array.Empty<FetchPartition>();
            /// <summary>
            /// <para>The partitions to fetch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<FetchPartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions to fetch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public FetchTopic WithPartitionsCollection(params Func<FetchPartition, FetchPartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new FetchPartition(Version))).ToArray();
                return this;
            }

            public delegate FetchPartition CreateFetchPartition(FetchPartition field);
            /// <summary>
            /// <para>The partitions to fetch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public FetchTopic WithPartitionsCollection(IEnumerable<CreateFetchPartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new FetchPartition(Version))).ToArray();
                return this;
            }

            public class FetchPartition : ISerialize
            {
                internal FetchPartition(Int16 version)
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
                internal int GetSize(bool _) => _partition.GetSize(IsFlexibleVersion) + (Version >= 9 ? _currentLeaderEpoch.GetSize(IsFlexibleVersion) : 0) + _fetchOffset.GetSize(IsFlexibleVersion) + (Version >= 12 ? _lastFetchedEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _logStartOffset.GetSize(IsFlexibleVersion) : 0) + _partitionMaxBytes.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<FetchPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new FetchPartition(version);
                    instance.Partition = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 9)
                        instance.CurrentLeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.FetchOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 12)
                        instance.LastFetchedEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 5)
                        instance.LogStartOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionMaxBytes = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for FetchPartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partition.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 9)
                        await _currentLeaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _fetchOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 12)
                        await _lastFetchedEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 5)
                        await _logStartOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _partitionMaxBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
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
                public FetchPartition WithPartition(Int32 partition)
                {
                    Partition = partition;
                    return this;
                }

                private Int32 _currentLeaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>The current leader epoch of the partition.</para>
                /// <para>Versions: 9+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int32 CurrentLeaderEpoch
                {
                    get => _currentLeaderEpoch;
                    private set
                    {
                        _currentLeaderEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The current leader epoch of the partition.</para>
                /// <para>Versions: 9+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public FetchPartition WithCurrentLeaderEpoch(Int32 currentLeaderEpoch)
                {
                    CurrentLeaderEpoch = currentLeaderEpoch;
                    return this;
                }

                private Int64 _fetchOffset = Int64.Default;
                /// <summary>
                /// <para>The message offset.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 FetchOffset
                {
                    get => _fetchOffset;
                    private set
                    {
                        _fetchOffset = value;
                    }
                }

                /// <summary>
                /// <para>The message offset.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public FetchPartition WithFetchOffset(Int64 fetchOffset)
                {
                    FetchOffset = fetchOffset;
                    return this;
                }

                private Int32 _lastFetchedEpoch = new Int32(-1);
                /// <summary>
                /// <para>The epoch of the last fetched record or -1 if there is none</para>
                /// <para>Versions: 12+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int32 LastFetchedEpoch
                {
                    get => _lastFetchedEpoch;
                    private set
                    {
                        if (Version >= 12 == false)
                            throw new UnsupportedVersionException($"LastFetchedEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 12+");
                        _lastFetchedEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The epoch of the last fetched record or -1 if there is none</para>
                /// <para>Versions: 12+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public FetchPartition WithLastFetchedEpoch(Int32 lastFetchedEpoch)
                {
                    LastFetchedEpoch = lastFetchedEpoch;
                    return this;
                }

                private Int64 _logStartOffset = new Int64(-1);
                /// <summary>
                /// <para>The earliest available offset of the follower replica.  The field is only used when the request is sent by the follower.</para>
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
                /// <para>The earliest available offset of the follower replica.  The field is only used when the request is sent by the follower.</para>
                /// <para>Versions: 5+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public FetchPartition WithLogStartOffset(Int64 logStartOffset)
                {
                    LogStartOffset = logStartOffset;
                    return this;
                }

                private Int32 _partitionMaxBytes = Int32.Default;
                /// <summary>
                /// <para>The maximum bytes to fetch from this partition.  See KIP-74 for cases where this limit may not be honored.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 PartitionMaxBytes
                {
                    get => _partitionMaxBytes;
                    private set
                    {
                        _partitionMaxBytes = value;
                    }
                }

                /// <summary>
                /// <para>The maximum bytes to fetch from this partition.  See KIP-74 for cases where this limit may not be honored.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public FetchPartition WithPartitionMaxBytes(Int32 partitionMaxBytes)
                {
                    PartitionMaxBytes = partitionMaxBytes;
                    return this;
                }
            }
        }

        private Array<ForgottenTopic> _forgottenTopicsDataCollection = Array.Empty<ForgottenTopic>();
        /// <summary>
        /// <para>In an incremental fetch request, the partitions to remove.</para>
        /// <para>Versions: 7+</para>
        /// </summary>
        public Array<ForgottenTopic> ForgottenTopicsDataCollection
        {
            get => _forgottenTopicsDataCollection;
            private set
            {
                if (Version >= 7 == false)
                    throw new UnsupportedVersionException($"ForgottenTopicsDataCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
                _forgottenTopicsDataCollection = value;
            }
        }

        /// <summary>
        /// <para>In an incremental fetch request, the partitions to remove.</para>
        /// <para>Versions: 7+</para>
        /// </summary>
        public FetchRequest WithForgottenTopicsDataCollection(params Func<ForgottenTopic, ForgottenTopic>[] createFields)
        {
            ForgottenTopicsDataCollection = createFields.Select(createField => createField(new ForgottenTopic(Version))).ToArray();
            return this;
        }

        public delegate ForgottenTopic CreateForgottenTopic(ForgottenTopic field);
        /// <summary>
        /// <para>In an incremental fetch request, the partitions to remove.</para>
        /// <para>Versions: 7+</para>
        /// </summary>
        public FetchRequest WithForgottenTopicsDataCollection(IEnumerable<CreateForgottenTopic> createFields)
        {
            ForgottenTopicsDataCollection = createFields.Select(createField => createField(new ForgottenTopic(Version))).ToArray();
            return this;
        }

        public class ForgottenTopic : ISerialize
        {
            internal ForgottenTopic(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 7 && Version <= 12 ? _topic.GetSize(IsFlexibleVersion) : 0) + (Version >= 13 ? _topicId.GetSize(IsFlexibleVersion) : 0) + (Version >= 7 ? _partitionsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ForgottenTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ForgottenTopic(version);
                if (instance.Version >= 7 && instance.Version <= 12)
                    instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 13)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 7)
                    instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ForgottenTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 7 && Version <= 12)
                    await _topic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 13)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 7)
                    await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topic = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 7-12</para>
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
            /// <para>Versions: 7-12</para>
            /// </summary>
            public ForgottenTopic WithTopic(String topic)
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
            public ForgottenTopic WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partitions indexes to forget.</para>
            /// <para>Versions: 7+</para>
            /// </summary>
            public Array<Int32> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    if (Version >= 7 == false)
                        throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions indexes to forget.</para>
            /// <para>Versions: 7+</para>
            /// </summary>
            public ForgottenTopic WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        private String _rackId = new String(string.Empty);
        /// <summary>
        /// <para>Rack ID of the consumer making this request</para>
        /// <para>Versions: 11+</para>
        /// <para>Default: Empty string</para>
        /// </summary>
        public String RackId
        {
            get => _rackId;
            private set
            {
                _rackId = value;
            }
        }

        /// <summary>
        /// <para>Rack ID of the consumer making this request</para>
        /// <para>Versions: 11+</para>
        /// <para>Default: Empty string</para>
        /// </summary>
        public FetchRequest WithRackId(String rackId)
        {
            RackId = rackId;
            return this;
        }

        public FetchResponse Respond() => new FetchResponse(Version);
    }
}
