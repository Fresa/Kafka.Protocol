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
    public class AddPartitionsToTxnRequest : Message, IRespond<AddPartitionsToTxnResponse>
    {
        public AddPartitionsToTxnRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AddPartitionsToTxnRequest does not support version {version}. Valid versions are: 0-5");
            Version = version;
            IsFlexibleVersion = version >= 3;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(24);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(5);
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

        internal override int GetSize() => (Version >= 4 ? _transactionsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 3 ? _v3AndBelowTransactionalId.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 3 ? _v3AndBelowProducerId.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 3 ? _v3AndBelowProducerEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 3 ? _v3AndBelowTopicsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AddPartitionsToTxnRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AddPartitionsToTxnRequest(version);
            if (instance.Version >= 4)
                instance.TransactionsCollection = await Map<String, AddPartitionsToTxnTransaction>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AddPartitionsToTxnTransaction.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.TransactionalId, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 3)
                instance.V3AndBelowTransactionalId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 3)
                instance.V3AndBelowProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 3)
                instance.V3AndBelowProducerEpoch = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 3)
                instance.V3AndBelowTopicsCollection = await Array<AddPartitionsToTxnTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AddPartitionsToTxnTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AddPartitionsToTxnRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 4)
                await _transactionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 3)
                await _v3AndBelowTransactionalId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 3)
                await _v3AndBelowProducerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 3)
                await _v3AndBelowProducerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 3)
                await _v3AndBelowTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Map<String, AddPartitionsToTxnTransaction> _transactionsCollection = Map<String, AddPartitionsToTxnTransaction>.Default;
        /// <summary>
        /// <para>List of transactions to add partitions to.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public Map<String, AddPartitionsToTxnTransaction> TransactionsCollection
        {
            get => _transactionsCollection;
            private set
            {
                if (Version >= 4 == false)
                    throw new UnsupportedVersionException($"TransactionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                _transactionsCollection = value;
            }
        }

        /// <summary>
        /// <para>List of transactions to add partitions to.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public AddPartitionsToTxnRequest WithTransactionsCollection(params Func<AddPartitionsToTxnTransaction, AddPartitionsToTxnTransaction>[] createFields)
        {
            TransactionsCollection = createFields.Select(createField => createField(new AddPartitionsToTxnTransaction(Version))).ToDictionary(field => field.TransactionalId);
            return this;
        }

        public delegate AddPartitionsToTxnTransaction CreateAddPartitionsToTxnTransaction(AddPartitionsToTxnTransaction field);
        /// <summary>
        /// <para>List of transactions to add partitions to.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public AddPartitionsToTxnRequest WithTransactionsCollection(IEnumerable<CreateAddPartitionsToTxnTransaction> createFields)
        {
            TransactionsCollection = createFields.Select(createField => createField(new AddPartitionsToTxnTransaction(Version))).ToDictionary(field => field.TransactionalId);
            return this;
        }

        public class AddPartitionsToTxnTransaction : ISerialize
        {
            internal AddPartitionsToTxnTransaction(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 4 ? _transactionalId.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _producerId.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _producerEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _verifyOnly.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _topicsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AddPartitionsToTxnTransaction> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AddPartitionsToTxnTransaction(version);
                if (instance.Version >= 4)
                    instance.TransactionalId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.ProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.ProducerEpoch = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.VerifyOnly = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.TopicsCollection = await Array<AddPartitionsToTxnTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AddPartitionsToTxnTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AddPartitionsToTxnTransaction is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 4)
                    await _transactionalId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _producerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _producerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _verifyOnly.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _transactionalId = String.Default;
            /// <summary>
            /// <para>The transactional id corresponding to the transaction.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public String TransactionalId
            {
                get => _transactionalId;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"TransactionalId does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _transactionalId = value;
                }
            }

            /// <summary>
            /// <para>The transactional id corresponding to the transaction.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public AddPartitionsToTxnTransaction WithTransactionalId(String transactionalId)
            {
                TransactionalId = transactionalId;
                return this;
            }

            private Int64 _producerId = Int64.Default;
            /// <summary>
            /// <para>Current producer id in use by the transactional id.</para>
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
            /// <para>Current producer id in use by the transactional id.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public AddPartitionsToTxnTransaction WithProducerId(Int64 producerId)
            {
                ProducerId = producerId;
                return this;
            }

            private Int16 _producerEpoch = Int16.Default;
            /// <summary>
            /// <para>Current epoch associated with the producer id.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Int16 ProducerEpoch
            {
                get => _producerEpoch;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"ProducerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _producerEpoch = value;
                }
            }

            /// <summary>
            /// <para>Current epoch associated with the producer id.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public AddPartitionsToTxnTransaction WithProducerEpoch(Int16 producerEpoch)
            {
                ProducerEpoch = producerEpoch;
                return this;
            }

            private Boolean _verifyOnly = new Boolean(false);
            /// <summary>
            /// <para>Boolean to signify if we want to check if the partition is in the transaction rather than add it.</para>
            /// <para>Versions: 4+</para>
            /// <para>Default: false</para>
            /// </summary>
            public Boolean VerifyOnly
            {
                get => _verifyOnly;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"VerifyOnly does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _verifyOnly = value;
                }
            }

            /// <summary>
            /// <para>Boolean to signify if we want to check if the partition is in the transaction rather than add it.</para>
            /// <para>Versions: 4+</para>
            /// <para>Default: false</para>
            /// </summary>
            public AddPartitionsToTxnTransaction WithVerifyOnly(Boolean verifyOnly)
            {
                VerifyOnly = verifyOnly;
                return this;
            }

            private Array<AddPartitionsToTxnTopic> _topicsCollection = Array.Empty<AddPartitionsToTxnTopic>();
            /// <summary>
            /// <para>The partitions to add to the transaction.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Array<AddPartitionsToTxnTopic> TopicsCollection
            {
                get => _topicsCollection;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _topicsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions to add to the transaction.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public AddPartitionsToTxnTransaction WithTopicsCollection(Array<AddPartitionsToTxnTopic> topicsCollection)
            {
                TopicsCollection = topicsCollection;
                return this;
            }
        }

        private String _v3AndBelowTransactionalId = String.Default;
        /// <summary>
        /// <para>The transactional id corresponding to the transaction.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public String V3AndBelowTransactionalId
        {
            get => _v3AndBelowTransactionalId;
            private set
            {
                if (Version >= 0 && Version <= 3 == false)
                    throw new UnsupportedVersionException($"V3AndBelowTransactionalId does not support version {Version} and has been defined as not ignorable. Supported versions: 0-3");
                _v3AndBelowTransactionalId = value;
            }
        }

        /// <summary>
        /// <para>The transactional id corresponding to the transaction.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public AddPartitionsToTxnRequest WithV3AndBelowTransactionalId(String v3AndBelowTransactionalId)
        {
            V3AndBelowTransactionalId = v3AndBelowTransactionalId;
            return this;
        }

        private Int64 _v3AndBelowProducerId = Int64.Default;
        /// <summary>
        /// <para>Current producer id in use by the transactional id.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public Int64 V3AndBelowProducerId
        {
            get => _v3AndBelowProducerId;
            private set
            {
                if (Version >= 0 && Version <= 3 == false)
                    throw new UnsupportedVersionException($"V3AndBelowProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0-3");
                _v3AndBelowProducerId = value;
            }
        }

        /// <summary>
        /// <para>Current producer id in use by the transactional id.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public AddPartitionsToTxnRequest WithV3AndBelowProducerId(Int64 v3AndBelowProducerId)
        {
            V3AndBelowProducerId = v3AndBelowProducerId;
            return this;
        }

        private Int16 _v3AndBelowProducerEpoch = Int16.Default;
        /// <summary>
        /// <para>Current epoch associated with the producer id.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public Int16 V3AndBelowProducerEpoch
        {
            get => _v3AndBelowProducerEpoch;
            private set
            {
                if (Version >= 0 && Version <= 3 == false)
                    throw new UnsupportedVersionException($"V3AndBelowProducerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0-3");
                _v3AndBelowProducerEpoch = value;
            }
        }

        /// <summary>
        /// <para>Current epoch associated with the producer id.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public AddPartitionsToTxnRequest WithV3AndBelowProducerEpoch(Int16 v3AndBelowProducerEpoch)
        {
            V3AndBelowProducerEpoch = v3AndBelowProducerEpoch;
            return this;
        }

        private Array<AddPartitionsToTxnTopic> _v3AndBelowTopicsCollection = Array.Empty<AddPartitionsToTxnTopic>();
        /// <summary>
        /// <para>The partitions to add to the transaction.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public Array<AddPartitionsToTxnTopic> V3AndBelowTopicsCollection
        {
            get => _v3AndBelowTopicsCollection;
            private set
            {
                if (Version >= 0 && Version <= 3 == false)
                    throw new UnsupportedVersionException($"V3AndBelowTopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-3");
                _v3AndBelowTopicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The partitions to add to the transaction.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public AddPartitionsToTxnRequest WithV3AndBelowTopicsCollection(Array<AddPartitionsToTxnTopic> v3AndBelowTopicsCollection)
        {
            V3AndBelowTopicsCollection = v3AndBelowTopicsCollection;
            return this;
        }

        public class AddPartitionsToTxnTopic : ISerialize
        {
            internal AddPartitionsToTxnTopic(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AddPartitionsToTxnTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AddPartitionsToTxnTopic(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AddPartitionsToTxnTopic is unknown");
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
            /// <para>The name of the topic.</para>
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
            /// <para>The name of the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AddPartitionsToTxnTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partition indexes to add to the transaction</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<Int32> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partition indexes to add to the transaction</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AddPartitionsToTxnTopic WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        public AddPartitionsToTxnResponse Respond() => new AddPartitionsToTxnResponse(Version);
    }
}
