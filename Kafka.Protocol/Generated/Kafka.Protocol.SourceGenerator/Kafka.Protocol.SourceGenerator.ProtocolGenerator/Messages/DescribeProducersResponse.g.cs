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
    public class DescribeProducersResponse : Message
    {
        public DescribeProducersResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeProducersResponse does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(61);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeProducersResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeProducersResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<TopicResponse>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeProducersResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
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
        public DescribeProducersResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Array<TopicResponse> _topicsCollection = Array.Empty<TopicResponse>();
        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<TopicResponse> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeProducersResponse WithTopicsCollection(params Func<TopicResponse, TopicResponse>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicResponse(Version))).ToArray();
            return this;
        }

        public delegate TopicResponse CreateTopicResponse(TopicResponse field);
        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeProducersResponse WithTopicsCollection(IEnumerable<CreateTopicResponse> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicResponse(Version))).ToArray();
            return this;
        }

        public class TopicResponse : ISerialize
        {
            internal TopicResponse(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicResponse(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<PartitionResponse>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => PartitionResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicResponse is unknown");
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
            public TopicResponse WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<PartitionResponse> _partitionsCollection = Array.Empty<PartitionResponse>();
            /// <summary>
            /// <para>Each partition in the response.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<PartitionResponse> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition in the response.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicResponse WithPartitionsCollection(params Func<PartitionResponse, PartitionResponse>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionResponse(Version))).ToArray();
                return this;
            }

            public delegate PartitionResponse CreatePartitionResponse(PartitionResponse field);
            /// <summary>
            /// <para>Each partition in the response.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicResponse WithPartitionsCollection(IEnumerable<CreatePartitionResponse> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionResponse(Version))).ToArray();
                return this;
            }

            public class PartitionResponse : ISerialize
            {
                internal PartitionResponse(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _activeProducersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionResponse(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ActiveProducersCollection = await Array<ProducerState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ProducerState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for PartitionResponse is unknown");
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
                    await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _activeProducersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public PartitionResponse WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The partition error code, or 0 if there was no error.</para>
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
                /// <para>The partition error code, or 0 if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionResponse WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private NullableString _errorMessage = new NullableString(null);
                /// <summary>
                /// <para>The partition error message, which may be null if no additional details are available</para>
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
                /// <para>The partition error message, which may be null if no additional details are available</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public PartitionResponse WithErrorMessage(String? errorMessage)
                {
                    ErrorMessage = errorMessage;
                    return this;
                }

                private Array<ProducerState> _activeProducersCollection = Array.Empty<ProducerState>();
                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<ProducerState> ActiveProducersCollection
                {
                    get => _activeProducersCollection;
                    private set
                    {
                        _activeProducersCollection = value;
                    }
                }

                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionResponse WithActiveProducersCollection(params Func<ProducerState, ProducerState>[] createFields)
                {
                    ActiveProducersCollection = createFields.Select(createField => createField(new ProducerState(Version))).ToArray();
                    return this;
                }

                public delegate ProducerState CreateProducerState(ProducerState field);
                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionResponse WithActiveProducersCollection(IEnumerable<CreateProducerState> createFields)
                {
                    ActiveProducersCollection = createFields.Select(createField => createField(new ProducerState(Version))).ToArray();
                    return this;
                }

                public class ProducerState : ISerialize
                {
                    internal ProducerState(Int16 version)
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
                    internal int GetSize(bool _) => _producerId.GetSize(IsFlexibleVersion) + _producerEpoch.GetSize(IsFlexibleVersion) + _lastSequence.GetSize(IsFlexibleVersion) + _lastTimestamp.GetSize(IsFlexibleVersion) + _coordinatorEpoch.GetSize(IsFlexibleVersion) + _currentTxnStartOffset.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<ProducerState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new ProducerState(version);
                        instance.ProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.ProducerEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.LastSequence = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.LastTimestamp = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.CoordinatorEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.CurrentTxnStartOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for ProducerState is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        await _producerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _producerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _lastSequence.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _lastTimestamp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _coordinatorEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _currentTxnStartOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int64 _producerId = Int64.Default;
                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int64 ProducerId
                    {
                        get => _producerId;
                        private set
                        {
                            _producerId = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public ProducerState WithProducerId(Int64 producerId)
                    {
                        ProducerId = producerId;
                        return this;
                    }

                    private Int32 _producerEpoch = Int32.Default;
                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int32 ProducerEpoch
                    {
                        get => _producerEpoch;
                        private set
                        {
                            _producerEpoch = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public ProducerState WithProducerEpoch(Int32 producerEpoch)
                    {
                        ProducerEpoch = producerEpoch;
                        return this;
                    }

                    private Int32 _lastSequence = new Int32(-1);
                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int32 LastSequence
                    {
                        get => _lastSequence;
                        private set
                        {
                            _lastSequence = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public ProducerState WithLastSequence(Int32 lastSequence)
                    {
                        LastSequence = lastSequence;
                        return this;
                    }

                    private Int64 _lastTimestamp = new Int64(-1);
                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int64 LastTimestamp
                    {
                        get => _lastTimestamp;
                        private set
                        {
                            _lastTimestamp = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public ProducerState WithLastTimestamp(Int64 lastTimestamp)
                    {
                        LastTimestamp = lastTimestamp;
                        return this;
                    }

                    private Int32 _coordinatorEpoch = Int32.Default;
                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int32 CoordinatorEpoch
                    {
                        get => _coordinatorEpoch;
                        private set
                        {
                            _coordinatorEpoch = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public ProducerState WithCoordinatorEpoch(Int32 coordinatorEpoch)
                    {
                        CoordinatorEpoch = coordinatorEpoch;
                        return this;
                    }

                    private Int64 _currentTxnStartOffset = new Int64(-1);
                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int64 CurrentTxnStartOffset
                    {
                        get => _currentTxnStartOffset;
                        private set
                        {
                            _currentTxnStartOffset = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 0+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public ProducerState WithCurrentTxnStartOffset(Int64 currentTxnStartOffset)
                    {
                        CurrentTxnStartOffset = currentTxnStartOffset;
                        return this;
                    }
                }
            }
        }
    }
}
