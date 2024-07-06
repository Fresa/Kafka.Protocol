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
    public class ProduceResponse : Message
    {
        public ProduceResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ProduceResponse does not support version {version}. Valid versions are: 0-11");
            Version = version;
            IsFlexibleVersion = version >= 9;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(0);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(11);
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
            if (Version >= 10 && _nodeEndpointsCollectionIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 0, Field = _nodeEndpointsCollection });
            }

            return new Tags.TagSection(tags.ToArray());
        }

        internal override int GetSize() => +(IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ProduceResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ProduceResponse(version);
            instance.ResponsesCollection = await Map<String, TopicProduceResponse>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicProduceResponse.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        case 0:
                            if (instance.Version >= 10)
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
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ProduceResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _responsesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Map<String, TopicProduceResponse> _responsesCollection = Map<String, TopicProduceResponse>.Default;
        /// <summary>
        /// <para>Each produce response</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, TopicProduceResponse> ResponsesCollection
        {
            get => _responsesCollection;
            private set
            {
                _responsesCollection = value;
            }
        }

        /// <summary>
        /// <para>Each produce response</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ProduceResponse WithResponsesCollection(params Func<TopicProduceResponse, TopicProduceResponse>[] createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new TopicProduceResponse(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate TopicProduceResponse CreateTopicProduceResponse(TopicProduceResponse field);
        /// <summary>
        /// <para>Each produce response</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ProduceResponse WithResponsesCollection(IEnumerable<CreateTopicProduceResponse> createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new TopicProduceResponse(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class TopicProduceResponse : ISerialize
        {
            internal TopicProduceResponse(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 9;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionResponsesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicProduceResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicProduceResponse(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionResponsesCollection = await Array<PartitionProduceResponse>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => PartitionProduceResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicProduceResponse is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionResponsesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The topic name</para>
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
            /// <para>The topic name</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicProduceResponse WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<PartitionProduceResponse> _partitionResponsesCollection = Array.Empty<PartitionProduceResponse>();
            /// <summary>
            /// <para>Each partition that we produced to within the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<PartitionProduceResponse> PartitionResponsesCollection
            {
                get => _partitionResponsesCollection;
                private set
                {
                    _partitionResponsesCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition that we produced to within the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicProduceResponse WithPartitionResponsesCollection(params Func<PartitionProduceResponse, PartitionProduceResponse>[] createFields)
            {
                PartitionResponsesCollection = createFields.Select(createField => createField(new PartitionProduceResponse(Version))).ToArray();
                return this;
            }

            public delegate PartitionProduceResponse CreatePartitionProduceResponse(PartitionProduceResponse field);
            /// <summary>
            /// <para>Each partition that we produced to within the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicProduceResponse WithPartitionResponsesCollection(IEnumerable<CreatePartitionProduceResponse> createFields)
            {
                PartitionResponsesCollection = createFields.Select(createField => createField(new PartitionProduceResponse(Version))).ToArray();
                return this;
            }

            public class PartitionProduceResponse : ISerialize
            {
                internal PartitionProduceResponse(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 9;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    if (Version >= 10 && _currentLeaderIsSet)
                    {
                        tags.Add(new Tags.TaggedField { Tag = 0, Field = _currentLeader });
                    }

                    return new Tags.TagSection(tags.ToArray());
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => +(IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionProduceResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionProduceResponse(version);
                    instance.Index = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.BaseOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 2)
                        instance.LogAppendTimeMs = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 5)
                        instance.LogStartOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 8)
                        instance.RecordErrorsCollection = await Array<BatchIndexAndErrorMessage>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => BatchIndexAndErrorMessage.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 8)
                        instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                case 0:
                                    if (instance.Version >= 10)
                                        instance.CurrentLeader = await LeaderIdAndEpoch.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                                    else
                                        throw new InvalidOperationException($"Field CurrentLeader is not supported for version {instance.Version}");
                                {
                                    var size = instance._currentLeader.GetSize(true);
                                    if (size != tag.Length)
                                        throw new CorruptMessageException($"Tagged field CurrentLeader read length {tag.Length} but had actual length of {size}");
                                }

                                    break;
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for PartitionProduceResponse is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _index.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _baseOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 2)
                        await _logAppendTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 5)
                        await _logStartOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 8)
                        await _recordErrorsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 8)
                        await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _index = Int32.Default;
                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 Index
                {
                    get => _index;
                    private set
                    {
                        _index = value;
                    }
                }

                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionProduceResponse WithIndex(Int32 index)
                {
                    Index = index;
                    return this;
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The error code, or 0 if there was no error.</para>
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
                /// <para>The error code, or 0 if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionProduceResponse WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private Int64 _baseOffset = Int64.Default;
                /// <summary>
                /// <para>The base offset.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 BaseOffset
                {
                    get => _baseOffset;
                    private set
                    {
                        _baseOffset = value;
                    }
                }

                /// <summary>
                /// <para>The base offset.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionProduceResponse WithBaseOffset(Int64 baseOffset)
                {
                    BaseOffset = baseOffset;
                    return this;
                }

                private Int64 _logAppendTimeMs = new Int64(-1);
                /// <summary>
                /// <para>The timestamp returned by broker after appending the messages. If CreateTime is used for the topic, the timestamp will be -1.  If LogAppendTime is used for the topic, the timestamp will be the broker local time when the messages are appended.</para>
                /// <para>Versions: 2+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int64 LogAppendTimeMs
                {
                    get => _logAppendTimeMs;
                    private set
                    {
                        _logAppendTimeMs = value;
                    }
                }

                /// <summary>
                /// <para>The timestamp returned by broker after appending the messages. If CreateTime is used for the topic, the timestamp will be -1.  If LogAppendTime is used for the topic, the timestamp will be the broker local time when the messages are appended.</para>
                /// <para>Versions: 2+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public PartitionProduceResponse WithLogAppendTimeMs(Int64 logAppendTimeMs)
                {
                    LogAppendTimeMs = logAppendTimeMs;
                    return this;
                }

                private Int64 _logStartOffset = new Int64(-1);
                /// <summary>
                /// <para>The log start offset.</para>
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
                /// <para>The log start offset.</para>
                /// <para>Versions: 5+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public PartitionProduceResponse WithLogStartOffset(Int64 logStartOffset)
                {
                    LogStartOffset = logStartOffset;
                    return this;
                }

                private Array<BatchIndexAndErrorMessage> _recordErrorsCollection = Array.Empty<BatchIndexAndErrorMessage>();
                /// <summary>
                /// <para>The batch indices of records that caused the batch to be dropped</para>
                /// <para>Versions: 8+</para>
                /// </summary>
                public Array<BatchIndexAndErrorMessage> RecordErrorsCollection
                {
                    get => _recordErrorsCollection;
                    private set
                    {
                        _recordErrorsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The batch indices of records that caused the batch to be dropped</para>
                /// <para>Versions: 8+</para>
                /// </summary>
                public PartitionProduceResponse WithRecordErrorsCollection(params Func<BatchIndexAndErrorMessage, BatchIndexAndErrorMessage>[] createFields)
                {
                    RecordErrorsCollection = createFields.Select(createField => createField(new BatchIndexAndErrorMessage(Version))).ToArray();
                    return this;
                }

                public delegate BatchIndexAndErrorMessage CreateBatchIndexAndErrorMessage(BatchIndexAndErrorMessage field);
                /// <summary>
                /// <para>The batch indices of records that caused the batch to be dropped</para>
                /// <para>Versions: 8+</para>
                /// </summary>
                public PartitionProduceResponse WithRecordErrorsCollection(IEnumerable<CreateBatchIndexAndErrorMessage> createFields)
                {
                    RecordErrorsCollection = createFields.Select(createField => createField(new BatchIndexAndErrorMessage(Version))).ToArray();
                    return this;
                }

                public class BatchIndexAndErrorMessage : ISerialize
                {
                    internal BatchIndexAndErrorMessage(Int16 version)
                    {
                        Version = version;
                        IsFlexibleVersion = version >= 9;
                    }

                    internal Int16 Version { get; }
                    internal bool IsFlexibleVersion { get; }

                    private Tags.TagSection CreateTagSection()
                    {
                        return new Tags.TagSection();
                    }

                    int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                    internal int GetSize(bool _) => (Version >= 8 ? _batchIndex.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _batchIndexErrorMessage.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<BatchIndexAndErrorMessage> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new BatchIndexAndErrorMessage(version);
                        if (instance.Version >= 8)
                            instance.BatchIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 8)
                            instance.BatchIndexErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for BatchIndexAndErrorMessage is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        if (Version >= 8)
                            await _batchIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 8)
                            await _batchIndexErrorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int32 _batchIndex = Int32.Default;
                    /// <summary>
                    /// <para>The batch index of the record that cause the batch to be dropped</para>
                    /// <para>Versions: 8+</para>
                    /// </summary>
                    public Int32 BatchIndex
                    {
                        get => _batchIndex;
                        private set
                        {
                            if (Version >= 8 == false)
                                throw new UnsupportedVersionException($"BatchIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                            _batchIndex = value;
                        }
                    }

                    /// <summary>
                    /// <para>The batch index of the record that cause the batch to be dropped</para>
                    /// <para>Versions: 8+</para>
                    /// </summary>
                    public BatchIndexAndErrorMessage WithBatchIndex(Int32 batchIndex)
                    {
                        BatchIndex = batchIndex;
                        return this;
                    }

                    private NullableString _batchIndexErrorMessage = new NullableString(null);
                    /// <summary>
                    /// <para>The error message of the record that caused the batch to be dropped</para>
                    /// <para>Versions: 8+</para>
                    /// <para>Default: null</para>
                    /// </summary>
                    public String? BatchIndexErrorMessage
                    {
                        get => _batchIndexErrorMessage;
                        private set
                        {
                            if (Version >= 8 == false)
                                throw new UnsupportedVersionException($"BatchIndexErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                            if (Version >= 8 == false && value == null)
                                throw new UnsupportedVersionException($"BatchIndexErrorMessage does not support null for version {Version}. Supported versions for null value: 8+");
                            _batchIndexErrorMessage = value;
                        }
                    }

                    /// <summary>
                    /// <para>The error message of the record that caused the batch to be dropped</para>
                    /// <para>Versions: 8+</para>
                    /// <para>Default: null</para>
                    /// </summary>
                    public BatchIndexAndErrorMessage WithBatchIndexErrorMessage(String? batchIndexErrorMessage)
                    {
                        BatchIndexErrorMessage = batchIndexErrorMessage;
                        return this;
                    }
                }

                private NullableString _errorMessage = new NullableString(null);
                /// <summary>
                /// <para>The global error message summarizing the common root cause of the records that caused the batch to be dropped</para>
                /// <para>Versions: 8+</para>
                /// <para>Default: null</para>
                /// </summary>
                public String? ErrorMessage
                {
                    get => _errorMessage;
                    private set
                    {
                        if (Version >= 8 == false && value == null)
                            throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 8+");
                        _errorMessage = value;
                    }
                }

                /// <summary>
                /// <para>The global error message summarizing the common root cause of the records that caused the batch to be dropped</para>
                /// <para>Versions: 8+</para>
                /// <para>Default: null</para>
                /// </summary>
                public PartitionProduceResponse WithErrorMessage(String? errorMessage)
                {
                    ErrorMessage = errorMessage;
                    return this;
                }

                private bool _currentLeaderIsSet;
                private LeaderIdAndEpoch _currentLeader = default !;
                /// <summary>
                /// <para>Versions: 10+</para>
                /// </summary>
                public LeaderIdAndEpoch CurrentLeader
                {
                    get => _currentLeader;
                    private set
                    {
                        if (Version >= 10 == false)
                            throw new UnsupportedVersionException($"CurrentLeader does not support version {Version} and has been defined as not ignorable. Supported versions: 10+");
                        _currentLeader = value;
                        _currentLeaderIsSet = true;
                    }
                }

                /// <summary>
                /// <para>Versions: 10+</para>
                /// </summary>
                public PartitionProduceResponse WithCurrentLeader(Func<LeaderIdAndEpoch, LeaderIdAndEpoch> createField)
                {
                    CurrentLeader = createField(new LeaderIdAndEpoch(Version));
                    return this;
                }

                public class LeaderIdAndEpoch : ISerialize
                {
                    internal LeaderIdAndEpoch(Int16 version)
                    {
                        Version = version;
                        IsFlexibleVersion = version >= 9;
                    }

                    internal Int16 Version { get; }
                    internal bool IsFlexibleVersion { get; }

                    private Tags.TagSection CreateTagSection()
                    {
                        return new Tags.TagSection();
                    }

                    int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                    internal int GetSize(bool _) => (Version >= 10 ? _leaderId.GetSize(IsFlexibleVersion) : 0) + (Version >= 10 ? _leaderEpoch.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<LeaderIdAndEpoch> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new LeaderIdAndEpoch(version);
                        if (instance.Version >= 10)
                            instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 10)
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
                        if (Version >= 10)
                            await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 10)
                            await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int32 _leaderId = new Int32(-1);
                    /// <summary>
                    /// <para>The ID of the current leader or -1 if the leader is unknown.</para>
                    /// <para>Versions: 10+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int32 LeaderId
                    {
                        get => _leaderId;
                        private set
                        {
                            if (Version >= 10 == false)
                                throw new UnsupportedVersionException($"LeaderId does not support version {Version} and has been defined as not ignorable. Supported versions: 10+");
                            _leaderId = value;
                        }
                    }

                    /// <summary>
                    /// <para>The ID of the current leader or -1 if the leader is unknown.</para>
                    /// <para>Versions: 10+</para>
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
                    /// <para>Versions: 10+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int32 LeaderEpoch
                    {
                        get => _leaderEpoch;
                        private set
                        {
                            if (Version >= 10 == false)
                                throw new UnsupportedVersionException($"LeaderEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 10+");
                            _leaderEpoch = value;
                        }
                    }

                    /// <summary>
                    /// <para>The latest known leader epoch</para>
                    /// <para>Versions: 10+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public LeaderIdAndEpoch WithLeaderEpoch(Int32 leaderEpoch)
                    {
                        LeaderEpoch = leaderEpoch;
                        return this;
                    }
                }
            }
        }

        private Int32 _throttleTimeMs = new Int32(0);
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: 0</para>
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
        /// <para>Default: 0</para>
        /// </summary>
        public ProduceResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private bool _nodeEndpointsCollectionIsSet;
        private Map<Int32, NodeEndpoint> _nodeEndpointsCollection = Map<Int32, NodeEndpoint>.Default;
        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionProduceResponses, with errors NOT_LEADER_OR_FOLLOWER.</para>
        /// <para>Versions: 10+</para>
        /// </summary>
        public Map<Int32, NodeEndpoint> NodeEndpointsCollection
        {
            get => _nodeEndpointsCollection;
            private set
            {
                if (Version >= 10 == false)
                    throw new UnsupportedVersionException($"NodeEndpointsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 10+");
                _nodeEndpointsCollection = value;
                _nodeEndpointsCollectionIsSet = true;
            }
        }

        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionProduceResponses, with errors NOT_LEADER_OR_FOLLOWER.</para>
        /// <para>Versions: 10+</para>
        /// </summary>
        public ProduceResponse WithNodeEndpointsCollection(params Func<NodeEndpoint, NodeEndpoint>[] createFields)
        {
            NodeEndpointsCollection = createFields.Select(createField => createField(new NodeEndpoint(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public delegate NodeEndpoint CreateNodeEndpoint(NodeEndpoint field);
        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionProduceResponses, with errors NOT_LEADER_OR_FOLLOWER.</para>
        /// <para>Versions: 10+</para>
        /// </summary>
        public ProduceResponse WithNodeEndpointsCollection(IEnumerable<CreateNodeEndpoint> createFields)
        {
            NodeEndpointsCollection = createFields.Select(createField => createField(new NodeEndpoint(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public class NodeEndpoint : ISerialize
        {
            internal NodeEndpoint(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 9;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 10 ? _nodeId.GetSize(IsFlexibleVersion) : 0) + (Version >= 10 ? _host.GetSize(IsFlexibleVersion) : 0) + (Version >= 10 ? _port.GetSize(IsFlexibleVersion) : 0) + (Version >= 10 ? _rack.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<NodeEndpoint> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new NodeEndpoint(version);
                if (instance.Version >= 10)
                    instance.NodeId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 10)
                    instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 10)
                    instance.Port = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 10)
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
                if (Version >= 10)
                    await _nodeId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 10)
                    await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 10)
                    await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 10)
                    await _rack.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _nodeId = Int32.Default;
            /// <summary>
            /// <para>The ID of the associated node.</para>
            /// <para>Versions: 10+</para>
            /// </summary>
            public Int32 NodeId
            {
                get => _nodeId;
                private set
                {
                    if (Version >= 10 == false)
                        throw new UnsupportedVersionException($"NodeId does not support version {Version} and has been defined as not ignorable. Supported versions: 10+");
                    _nodeId = value;
                }
            }

            /// <summary>
            /// <para>The ID of the associated node.</para>
            /// <para>Versions: 10+</para>
            /// </summary>
            public NodeEndpoint WithNodeId(Int32 nodeId)
            {
                NodeId = nodeId;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The node's hostname.</para>
            /// <para>Versions: 10+</para>
            /// </summary>
            public String Host
            {
                get => _host;
                private set
                {
                    if (Version >= 10 == false)
                        throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 10+");
                    _host = value;
                }
            }

            /// <summary>
            /// <para>The node's hostname.</para>
            /// <para>Versions: 10+</para>
            /// </summary>
            public NodeEndpoint WithHost(String host)
            {
                Host = host;
                return this;
            }

            private Int32 _port = Int32.Default;
            /// <summary>
            /// <para>The node's port.</para>
            /// <para>Versions: 10+</para>
            /// </summary>
            public Int32 Port
            {
                get => _port;
                private set
                {
                    if (Version >= 10 == false)
                        throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 10+");
                    _port = value;
                }
            }

            /// <summary>
            /// <para>The node's port.</para>
            /// <para>Versions: 10+</para>
            /// </summary>
            public NodeEndpoint WithPort(Int32 port)
            {
                Port = port;
                return this;
            }

            private NullableString _rack = new NullableString(null);
            /// <summary>
            /// <para>The rack of the node, or null if it has not been assigned to a rack.</para>
            /// <para>Versions: 10+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? Rack
            {
                get => _rack;
                private set
                {
                    if (Version >= 10 == false)
                        throw new UnsupportedVersionException($"Rack does not support version {Version} and has been defined as not ignorable. Supported versions: 10+");
                    if (Version >= 10 == false && value == null)
                        throw new UnsupportedVersionException($"Rack does not support null for version {Version}. Supported versions for null value: 10+");
                    _rack = value;
                }
            }

            /// <summary>
            /// <para>The rack of the node, or null if it has not been assigned to a rack.</para>
            /// <para>Versions: 10+</para>
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
