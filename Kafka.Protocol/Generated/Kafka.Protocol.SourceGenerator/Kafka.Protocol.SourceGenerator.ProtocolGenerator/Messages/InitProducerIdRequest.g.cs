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
    public class InitProducerIdRequest : Message, IRespond<InitProducerIdResponse>
    {
        public InitProducerIdRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"InitProducerIdRequest does not support version {version}. Valid versions are: 0-6");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(22);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(6);
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

        internal override int GetSize() => _transactionalId.GetSize(IsFlexibleVersion) + _transactionTimeoutMs.GetSize(IsFlexibleVersion) + (Version >= 3 ? _producerId.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _producerEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 6 ? _enable2Pc.GetSize(IsFlexibleVersion) : 0) + (Version >= 6 ? _keepPreparedTxn.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<InitProducerIdRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new InitProducerIdRequest(version);
            instance.TransactionalId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TransactionTimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.ProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.ProducerEpoch = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 6)
                instance.Enable2Pc = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 6)
                instance.KeepPreparedTxn = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for InitProducerIdRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _transactionalId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _transactionTimeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _producerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _producerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 6)
                await _enable2Pc.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 6)
                await _keepPreparedTxn.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private NullableString _transactionalId = NullableString.Default;
        /// <summary>
        /// <para>The transactional id, or null if the producer is not transactional.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String? TransactionalId
        {
            get => _transactionalId;
            private set
            {
                _transactionalId = value;
            }
        }

        /// <summary>
        /// <para>The transactional id, or null if the producer is not transactional.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public InitProducerIdRequest WithTransactionalId(String? transactionalId)
        {
            TransactionalId = transactionalId;
            return this;
        }

        private Int32 _transactionTimeoutMs = Int32.Default;
        /// <summary>
        /// <para>The time in ms to wait before aborting idle transactions sent by this producer. This is only relevant if a TransactionalId has been defined.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 TransactionTimeoutMs
        {
            get => _transactionTimeoutMs;
            private set
            {
                _transactionTimeoutMs = value;
            }
        }

        /// <summary>
        /// <para>The time in ms to wait before aborting idle transactions sent by this producer. This is only relevant if a TransactionalId has been defined.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public InitProducerIdRequest WithTransactionTimeoutMs(Int32 transactionTimeoutMs)
        {
            TransactionTimeoutMs = transactionTimeoutMs;
            return this;
        }

        private Int64 _producerId = new Int64(-1);
        /// <summary>
        /// <para>The producer id. This is used to disambiguate requests if a transactional id is reused following its expiration.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int64 ProducerId
        {
            get => _producerId;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"ProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                _producerId = value;
            }
        }

        /// <summary>
        /// <para>The producer id. This is used to disambiguate requests if a transactional id is reused following its expiration.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public InitProducerIdRequest WithProducerId(Int64 producerId)
        {
            ProducerId = producerId;
            return this;
        }

        private Int16 _producerEpoch = new Int16(-1);
        /// <summary>
        /// <para>The producer's current epoch. This will be checked against the producer epoch on the broker, and the request will return an error if they do not match.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int16 ProducerEpoch
        {
            get => _producerEpoch;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"ProducerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                _producerEpoch = value;
            }
        }

        /// <summary>
        /// <para>The producer's current epoch. This will be checked against the producer epoch on the broker, and the request will return an error if they do not match.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public InitProducerIdRequest WithProducerEpoch(Int16 producerEpoch)
        {
            ProducerEpoch = producerEpoch;
            return this;
        }

        private Boolean _enable2Pc = new Boolean(false);
        /// <summary>
        /// <para>True if the client wants to enable two-phase commit (2PC) protocol for transactions.</para>
        /// <para>Versions: 6+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean Enable2Pc
        {
            get => _enable2Pc;
            private set
            {
                if (Version >= 6 == false)
                    throw new UnsupportedVersionException($"Enable2Pc does not support version {Version} and has been defined as not ignorable. Supported versions: 6+");
                _enable2Pc = value;
            }
        }

        /// <summary>
        /// <para>True if the client wants to enable two-phase commit (2PC) protocol for transactions.</para>
        /// <para>Versions: 6+</para>
        /// <para>Default: false</para>
        /// </summary>
        public InitProducerIdRequest WithEnable2Pc(Boolean enable2Pc)
        {
            Enable2Pc = enable2Pc;
            return this;
        }

        private Boolean _keepPreparedTxn = new Boolean(false);
        /// <summary>
        /// <para>True if the client wants to keep the currently ongoing transaction instead of aborting it.</para>
        /// <para>Versions: 6+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean KeepPreparedTxn
        {
            get => _keepPreparedTxn;
            private set
            {
                if (Version >= 6 == false)
                    throw new UnsupportedVersionException($"KeepPreparedTxn does not support version {Version} and has been defined as not ignorable. Supported versions: 6+");
                _keepPreparedTxn = value;
            }
        }

        /// <summary>
        /// <para>True if the client wants to keep the currently ongoing transaction instead of aborting it.</para>
        /// <para>Versions: 6+</para>
        /// <para>Default: false</para>
        /// </summary>
        public InitProducerIdRequest WithKeepPreparedTxn(Boolean keepPreparedTxn)
        {
            KeepPreparedTxn = keepPreparedTxn;
            return this;
        }

        public InitProducerIdResponse Respond() => new InitProducerIdResponse(Version);
    }
}
