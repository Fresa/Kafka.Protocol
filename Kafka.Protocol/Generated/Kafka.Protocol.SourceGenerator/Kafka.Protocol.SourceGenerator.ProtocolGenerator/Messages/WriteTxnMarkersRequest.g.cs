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
    public class WriteTxnMarkersRequest : Message, IRespond<WriteTxnMarkersResponse>
    {
        public WriteTxnMarkersRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"WriteTxnMarkersRequest does not support version {version}. Valid versions are: 1");
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
                return (short)(IsFlexibleVersion ? 2 : 1);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _markersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<WriteTxnMarkersRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new WriteTxnMarkersRequest(version);
            instance.MarkersCollection = await Array<WritableTxnMarker>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => WritableTxnMarker.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for WriteTxnMarkersRequest is unknown");
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

        private Array<WritableTxnMarker> _markersCollection = Array.Empty<WritableTxnMarker>();
        /// <summary>
        /// <para>The transaction markers to be written.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<WritableTxnMarker> MarkersCollection
        {
            get => _markersCollection;
            private set
            {
                _markersCollection = value;
            }
        }

        /// <summary>
        /// <para>The transaction markers to be written.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public WriteTxnMarkersRequest WithMarkersCollection(params Func<WritableTxnMarker, WritableTxnMarker>[] createFields)
        {
            MarkersCollection = createFields.Select(createField => createField(new WritableTxnMarker(Version))).ToArray();
            return this;
        }

        public delegate WritableTxnMarker CreateWritableTxnMarker(WritableTxnMarker field);
        /// <summary>
        /// <para>The transaction markers to be written.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public WriteTxnMarkersRequest WithMarkersCollection(IEnumerable<CreateWritableTxnMarker> createFields)
        {
            MarkersCollection = createFields.Select(createField => createField(new WritableTxnMarker(Version))).ToArray();
            return this;
        }

        public class WritableTxnMarker : ISerialize
        {
            internal WritableTxnMarker(Int16 version)
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
            internal int GetSize(bool _) => _producerId.GetSize(IsFlexibleVersion) + _producerEpoch.GetSize(IsFlexibleVersion) + _transactionResult.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + _coordinatorEpoch.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<WritableTxnMarker> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new WritableTxnMarker(version);
                instance.ProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ProducerEpoch = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TransactionResult = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicsCollection = await Array<WritableTxnMarkerTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => WritableTxnMarkerTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.CoordinatorEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for WritableTxnMarker is unknown");
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
                await _transactionResult.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _coordinatorEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int64 _producerId = Int64.Default;
            /// <summary>
            /// <para>The current producer ID.</para>
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
            /// <para>The current producer ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WritableTxnMarker WithProducerId(Int64 producerId)
            {
                ProducerId = producerId;
                return this;
            }

            private Int16 _producerEpoch = Int16.Default;
            /// <summary>
            /// <para>The current epoch associated with the producer ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 ProducerEpoch
            {
                get => _producerEpoch;
                private set
                {
                    _producerEpoch = value;
                }
            }

            /// <summary>
            /// <para>The current epoch associated with the producer ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WritableTxnMarker WithProducerEpoch(Int16 producerEpoch)
            {
                ProducerEpoch = producerEpoch;
                return this;
            }

            private Boolean _transactionResult = Boolean.Default;
            /// <summary>
            /// <para>The result of the transaction to write to the partitions (false = ABORT, true = COMMIT).</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Boolean TransactionResult
            {
                get => _transactionResult;
                private set
                {
                    _transactionResult = value;
                }
            }

            /// <summary>
            /// <para>The result of the transaction to write to the partitions (false = ABORT, true = COMMIT).</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WritableTxnMarker WithTransactionResult(Boolean transactionResult)
            {
                TransactionResult = transactionResult;
                return this;
            }

            private Array<WritableTxnMarkerTopic> _topicsCollection = Array.Empty<WritableTxnMarkerTopic>();
            /// <summary>
            /// <para>Each topic that we want to write transaction marker(s) for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<WritableTxnMarkerTopic> TopicsCollection
            {
                get => _topicsCollection;
                private set
                {
                    _topicsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each topic that we want to write transaction marker(s) for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WritableTxnMarker WithTopicsCollection(params Func<WritableTxnMarkerTopic, WritableTxnMarkerTopic>[] createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new WritableTxnMarkerTopic(Version))).ToArray();
                return this;
            }

            public delegate WritableTxnMarkerTopic CreateWritableTxnMarkerTopic(WritableTxnMarkerTopic field);
            /// <summary>
            /// <para>Each topic that we want to write transaction marker(s) for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WritableTxnMarker WithTopicsCollection(IEnumerable<CreateWritableTxnMarkerTopic> createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new WritableTxnMarkerTopic(Version))).ToArray();
                return this;
            }

            public class WritableTxnMarkerTopic : ISerialize
            {
                internal WritableTxnMarkerTopic(Int16 version)
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
                internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionIndexesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<WritableTxnMarkerTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new WritableTxnMarkerTopic(version);
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionIndexesCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for WritableTxnMarkerTopic is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _partitionIndexesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public WritableTxnMarkerTopic WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private Array<Int32> _partitionIndexesCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The indexes of the partitions to write transaction markers for.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> PartitionIndexesCollection
                {
                    get => _partitionIndexesCollection;
                    private set
                    {
                        _partitionIndexesCollection = value;
                    }
                }

                /// <summary>
                /// <para>The indexes of the partitions to write transaction markers for.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public WritableTxnMarkerTopic WithPartitionIndexesCollection(Array<Int32> partitionIndexesCollection)
                {
                    PartitionIndexesCollection = partitionIndexesCollection;
                    return this;
                }
            }

            private Int32 _coordinatorEpoch = Int32.Default;
            /// <summary>
            /// <para>Epoch associated with the transaction state partition hosted by this transaction coordinator.</para>
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
            /// <para>Epoch associated with the transaction state partition hosted by this transaction coordinator.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public WritableTxnMarker WithCoordinatorEpoch(Int32 coordinatorEpoch)
            {
                CoordinatorEpoch = coordinatorEpoch;
                return this;
            }
        }

        public WriteTxnMarkersResponse Respond() => new WriteTxnMarkersResponse(Version);
    }
}
