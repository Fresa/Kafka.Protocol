#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

namespace Kafka.Protocol
{
    public class ProduceRequest : Message, IRespond<ProduceResponse>
    {
        public ProduceRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ProduceRequest does not support version {version}. Valid versions are: 0-11");
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
                return (short)(IsFlexibleVersion ? 2 : 1);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => (Version >= 3 ? _transactionalId.GetSize(IsFlexibleVersion) : 0) + _acks.GetSize(IsFlexibleVersion) + _timeoutMs.GetSize(IsFlexibleVersion) + _topicDataCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ProduceRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ProduceRequest(version);
            if (instance.Version >= 3)
                instance.TransactionalId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.Acks = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicDataCollection = await Map<String, TopicProduceData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicProduceData.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ProduceRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 3)
                await _transactionalId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _acks.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _timeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicDataCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private NullableString _transactionalId = new NullableString(null);
        /// <summary>
        /// <para>The transactional ID, or null if the producer is not transactional.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? TransactionalId
        {
            get => _transactionalId;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"TransactionalId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                if (Version >= 3 == false && value == null)
                    throw new UnsupportedVersionException($"TransactionalId does not support null for version {Version}. Supported versions for null value: 3+");
                _transactionalId = value;
            }
        }

        /// <summary>
        /// <para>The transactional ID, or null if the producer is not transactional.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ProduceRequest WithTransactionalId(String? transactionalId)
        {
            TransactionalId = transactionalId;
            return this;
        }

        private Int16 _acks = Int16.Default;
        /// <summary>
        /// <para>The number of acknowledgments the producer requires the leader to have received before considering a request complete. Allowed values: 0 for no acknowledgments, 1 for only the leader and -1 for the full ISR.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int16 Acks
        {
            get => _acks;
            private set
            {
                _acks = value;
            }
        }

        /// <summary>
        /// <para>The number of acknowledgments the producer requires the leader to have received before considering a request complete. Allowed values: 0 for no acknowledgments, 1 for only the leader and -1 for the full ISR.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ProduceRequest WithAcks(Int16 acks)
        {
            Acks = acks;
            return this;
        }

        private Int32 _timeoutMs = Int32.Default;
        /// <summary>
        /// <para>The timeout to await a response in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 TimeoutMs
        {
            get => _timeoutMs;
            private set
            {
                _timeoutMs = value;
            }
        }

        /// <summary>
        /// <para>The timeout to await a response in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ProduceRequest WithTimeoutMs(Int32 timeoutMs)
        {
            TimeoutMs = timeoutMs;
            return this;
        }

        private Map<String, TopicProduceData> _topicDataCollection = Map<String, TopicProduceData>.Default;
        /// <summary>
        /// <para>Each topic to produce to.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, TopicProduceData> TopicDataCollection
        {
            get => _topicDataCollection;
            private set
            {
                _topicDataCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic to produce to.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ProduceRequest WithTopicDataCollection(params Func<TopicProduceData, TopicProduceData>[] createFields)
        {
            TopicDataCollection = createFields.Select(createField => createField(new TopicProduceData(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate TopicProduceData CreateTopicProduceData(TopicProduceData field);
        /// <summary>
        /// <para>Each topic to produce to.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ProduceRequest WithTopicDataCollection(IEnumerable<CreateTopicProduceData> createFields)
        {
            TopicDataCollection = createFields.Select(createField => createField(new TopicProduceData(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class TopicProduceData : ISerialize
        {
            internal TopicProduceData(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionDataCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicProduceData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicProduceData(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionDataCollection = await Array<PartitionProduceData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => PartitionProduceData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicProduceData is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionDataCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public TopicProduceData WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<PartitionProduceData> _partitionDataCollection = Array.Empty<PartitionProduceData>();
            /// <summary>
            /// <para>Each partition to produce to.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<PartitionProduceData> PartitionDataCollection
            {
                get => _partitionDataCollection;
                private set
                {
                    _partitionDataCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition to produce to.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicProduceData WithPartitionDataCollection(params Func<PartitionProduceData, PartitionProduceData>[] createFields)
            {
                PartitionDataCollection = createFields.Select(createField => createField(new PartitionProduceData(Version))).ToArray();
                return this;
            }

            public delegate PartitionProduceData CreatePartitionProduceData(PartitionProduceData field);
            /// <summary>
            /// <para>Each partition to produce to.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicProduceData WithPartitionDataCollection(IEnumerable<CreatePartitionProduceData> createFields)
            {
                PartitionDataCollection = createFields.Select(createField => createField(new PartitionProduceData(Version))).ToArray();
                return this;
            }

            public class PartitionProduceData : ISerialize
            {
                internal PartitionProduceData(Int16 version)
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
                internal int GetSize(bool _) => _index.GetSize(IsFlexibleVersion) + _records.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionProduceData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionProduceData(version);
                    instance.Index = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Records = await NullableRecordBatch.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for PartitionProduceData is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _index.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _records.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public PartitionProduceData WithIndex(Int32 index)
                {
                    Index = index;
                    return this;
                }

                private NullableRecordBatch _records = NullableRecordBatch.Default;
                /// <summary>
                /// <para>The record data to be produced.</para>
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
                /// <para>The record data to be produced.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionProduceData WithRecords(RecordBatch? records)
                {
                    Records = records;
                    return this;
                }
            }
        }

        public ProduceResponse Respond() => new ProduceResponse(Version);
    }
}
