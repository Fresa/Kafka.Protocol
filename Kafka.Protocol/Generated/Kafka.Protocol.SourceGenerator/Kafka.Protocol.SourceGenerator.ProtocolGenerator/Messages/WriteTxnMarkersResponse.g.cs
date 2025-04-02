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
    public class WriteTxnMarkersResponse : Message
    {
        public WriteTxnMarkersResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"WriteTxnMarkersResponse does not support version {version}. Valid versions are: 1");
            Version = version;
            IsFlexibleVersion = version >= 1;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(27);
        public static readonly Int16 MinVersion = Int16.From(1);
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

        internal override int GetSize() => _markersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<WriteTxnMarkersResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new WriteTxnMarkersResponse(version);
            instance.MarkersCollection = await Array<WritableTxnMarkerResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => WritableTxnMarkerResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for WriteTxnMarkersResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _markersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<WritableTxnMarkerResult> _markersCollection = Array.Empty<WritableTxnMarkerResult>();
        /// <summary>
        /// <para>The results for writing makers.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<WritableTxnMarkerResult> MarkersCollection
        {
            get => _markersCollection;
            private set
            {
                _markersCollection = value;
            }
        }

        /// <summary>
        /// <para>The results for writing makers.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public WriteTxnMarkersResponse WithMarkersCollection(params Func<WritableTxnMarkerResult, WritableTxnMarkerResult>[] createFields)
        {
            MarkersCollection = createFields.Select(createField => createField(new WritableTxnMarkerResult(Version))).ToArray();
            return this;
        }

        public delegate WritableTxnMarkerResult CreateWritableTxnMarkerResult(WritableTxnMarkerResult field);
        /// <summary>
        /// <para>The results for writing makers.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public WriteTxnMarkersResponse WithMarkersCollection(IEnumerable<CreateWritableTxnMarkerResult> createFields)
        {
            MarkersCollection = createFields.Select(createField => createField(new WritableTxnMarkerResult(Version))).ToArray();
            return this;
        }

        public class WritableTxnMarkerResult : ISerialize
        {
            internal WritableTxnMarkerResult(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 1;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _producerId.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<WritableTxnMarkerResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new WritableTxnMarkerResult(version);
                instance.ProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicsCollection = await Array<WritableTxnMarkerTopicResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => WritableTxnMarkerTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for WritableTxnMarkerResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _producerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int64 _producerId = Int64.Default;
            /// <summary>
            /// <para>The current producer ID in use by the transactional ID.</para>
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
            /// <para>The current producer ID in use by the transactional ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WritableTxnMarkerResult WithProducerId(Int64 producerId)
            {
                ProducerId = producerId;
                return this;
            }

            private Array<WritableTxnMarkerTopicResult> _topicsCollection = Array.Empty<WritableTxnMarkerTopicResult>();
            /// <summary>
            /// <para>The results by topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<WritableTxnMarkerTopicResult> TopicsCollection
            {
                get => _topicsCollection;
                private set
                {
                    _topicsCollection = value;
                }
            }

            /// <summary>
            /// <para>The results by topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WritableTxnMarkerResult WithTopicsCollection(params Func<WritableTxnMarkerTopicResult, WritableTxnMarkerTopicResult>[] createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new WritableTxnMarkerTopicResult(Version))).ToArray();
                return this;
            }

            public delegate WritableTxnMarkerTopicResult CreateWritableTxnMarkerTopicResult(WritableTxnMarkerTopicResult field);
            /// <summary>
            /// <para>The results by topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WritableTxnMarkerResult WithTopicsCollection(IEnumerable<CreateWritableTxnMarkerTopicResult> createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new WritableTxnMarkerTopicResult(Version))).ToArray();
                return this;
            }

            public class WritableTxnMarkerTopicResult : ISerialize
            {
                internal WritableTxnMarkerTopicResult(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 1;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<WritableTxnMarkerTopicResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new WritableTxnMarkerTopicResult(version);
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionsCollection = await Array<WritableTxnMarkerPartitionResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => WritableTxnMarkerPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for WritableTxnMarkerTopicResult is unknown");
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
                /// <para>The topic name.</para>
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
                /// <para>The topic name.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public WritableTxnMarkerTopicResult WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private Array<WritableTxnMarkerPartitionResult> _partitionsCollection = Array.Empty<WritableTxnMarkerPartitionResult>();
                /// <summary>
                /// <para>The results by partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<WritableTxnMarkerPartitionResult> PartitionsCollection
                {
                    get => _partitionsCollection;
                    private set
                    {
                        _partitionsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The results by partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public WritableTxnMarkerTopicResult WithPartitionsCollection(params Func<WritableTxnMarkerPartitionResult, WritableTxnMarkerPartitionResult>[] createFields)
                {
                    PartitionsCollection = createFields.Select(createField => createField(new WritableTxnMarkerPartitionResult(Version))).ToArray();
                    return this;
                }

                public delegate WritableTxnMarkerPartitionResult CreateWritableTxnMarkerPartitionResult(WritableTxnMarkerPartitionResult field);
                /// <summary>
                /// <para>The results by partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public WritableTxnMarkerTopicResult WithPartitionsCollection(IEnumerable<CreateWritableTxnMarkerPartitionResult> createFields)
                {
                    PartitionsCollection = createFields.Select(createField => createField(new WritableTxnMarkerPartitionResult(Version))).ToArray();
                    return this;
                }

                public class WritableTxnMarkerPartitionResult : ISerialize
                {
                    internal WritableTxnMarkerPartitionResult(Int16 version)
                    {
                        Version = version;
                        IsFlexibleVersion = version >= 1;
                    }

                    internal Int16 Version { get; }
                    internal bool IsFlexibleVersion { get; }

                    private Tags.TagSection CreateTagSection()
                    {
                        return new Tags.TagSection();
                    }

                    int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                    internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<WritableTxnMarkerPartitionResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new WritableTxnMarkerPartitionResult(version);
                        instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for WritableTxnMarkerPartitionResult is unknown");
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
                    public WritableTxnMarkerPartitionResult WithPartitionIndex(Int32 partitionIndex)
                    {
                        PartitionIndex = partitionIndex;
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
                    public WritableTxnMarkerPartitionResult WithErrorCode(Int16 errorCode)
                    {
                        ErrorCode = errorCode;
                        return this;
                    }
                }
            }
        }
    }
}
