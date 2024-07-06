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
    public class ReadShareGroupStateSummaryResponse : Message
    {
        public ReadShareGroupStateSummaryResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ReadShareGroupStateSummaryResponse does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(87);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
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

        internal override int GetSize() => _resultsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ReadShareGroupStateSummaryResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ReadShareGroupStateSummaryResponse(version);
            instance.ResultsCollection = await Array<ReadStateSummaryResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ReadStateSummaryResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ReadShareGroupStateSummaryResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _resultsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<ReadStateSummaryResult> _resultsCollection = Array.Empty<ReadStateSummaryResult>();
        /// <summary>
        /// <para>The read results</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ReadStateSummaryResult> ResultsCollection
        {
            get => _resultsCollection;
            private set
            {
                _resultsCollection = value;
            }
        }

        /// <summary>
        /// <para>The read results</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ReadShareGroupStateSummaryResponse WithResultsCollection(params Func<ReadStateSummaryResult, ReadStateSummaryResult>[] createFields)
        {
            ResultsCollection = createFields.Select(createField => createField(new ReadStateSummaryResult(Version))).ToArray();
            return this;
        }

        public delegate ReadStateSummaryResult CreateReadStateSummaryResult(ReadStateSummaryResult field);
        /// <summary>
        /// <para>The read results</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ReadShareGroupStateSummaryResponse WithResultsCollection(IEnumerable<CreateReadStateSummaryResult> createFields)
        {
            ResultsCollection = createFields.Select(createField => createField(new ReadStateSummaryResult(Version))).ToArray();
            return this;
        }

        public class ReadStateSummaryResult : ISerialize
        {
            internal ReadStateSummaryResult(Int16 version)
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
            internal int GetSize(bool _) => _topicId.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ReadStateSummaryResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ReadStateSummaryResult(version);
                instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<PartitionResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => PartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ReadStateSummaryResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The topic identifier</para>
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
            /// <para>The topic identifier</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ReadStateSummaryResult WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<PartitionResult> _partitionsCollection = Array.Empty<PartitionResult>();
            /// <summary>
            /// <para>The results for the partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<PartitionResult> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The results for the partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ReadStateSummaryResult WithPartitionsCollection(params Func<PartitionResult, PartitionResult>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionResult(Version))).ToArray();
                return this;
            }

            public delegate PartitionResult CreatePartitionResult(PartitionResult field);
            /// <summary>
            /// <para>The results for the partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ReadStateSummaryResult WithPartitionsCollection(IEnumerable<CreatePartitionResult> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionResult(Version))).ToArray();
                return this;
            }

            public class PartitionResult : ISerialize
            {
                internal PartitionResult(Int16 version)
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
                internal int GetSize(bool _) => _partition.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _stateEpoch.GetSize(IsFlexibleVersion) + _startOffset.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionResult(version);
                    instance.Partition = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.StateEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.StartOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for PartitionResult is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partition.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _stateEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _startOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public PartitionResult WithPartition(Int32 partition)
                {
                    Partition = partition;
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
                public PartitionResult WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private NullableString _errorMessage = new NullableString(null);
                /// <summary>
                /// <para>The error message, or null if there was no error.</para>
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
                /// <para>The error message, or null if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public PartitionResult WithErrorMessage(String? errorMessage)
                {
                    ErrorMessage = errorMessage;
                    return this;
                }

                private Int32 _stateEpoch = Int32.Default;
                /// <summary>
                /// <para>The state epoch of the share-partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 StateEpoch
                {
                    get => _stateEpoch;
                    private set
                    {
                        _stateEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The state epoch of the share-partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionResult WithStateEpoch(Int32 stateEpoch)
                {
                    StateEpoch = stateEpoch;
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
                public PartitionResult WithStartOffset(Int64 startOffset)
                {
                    StartOffset = startOffset;
                    return this;
                }
            }
        }
    }
}
