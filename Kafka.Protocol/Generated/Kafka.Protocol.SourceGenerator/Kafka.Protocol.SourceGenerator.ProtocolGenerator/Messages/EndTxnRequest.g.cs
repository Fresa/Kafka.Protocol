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
    public class EndTxnRequest : Message, IRespond<EndTxnResponse>
    {
        public EndTxnRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"EndTxnRequest does not support version {version}. Valid versions are: 0-4");
            Version = version;
            IsFlexibleVersion = version >= 3;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(26);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(4);
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

        internal override int GetSize() => _transactionalId.GetSize(IsFlexibleVersion) + _producerId.GetSize(IsFlexibleVersion) + _producerEpoch.GetSize(IsFlexibleVersion) + _committed.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<EndTxnRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new EndTxnRequest(version);
            instance.TransactionalId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ProducerEpoch = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.Committed = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for EndTxnRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _transactionalId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _producerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _producerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _committed.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _transactionalId = String.Default;
        /// <summary>
        /// <para>The ID of the transaction to end.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String TransactionalId
        {
            get => _transactionalId;
            private set
            {
                _transactionalId = value;
            }
        }

        /// <summary>
        /// <para>The ID of the transaction to end.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public EndTxnRequest WithTransactionalId(String transactionalId)
        {
            TransactionalId = transactionalId;
            return this;
        }

        private Int64 _producerId = Int64.Default;
        /// <summary>
        /// <para>The producer ID.</para>
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
        /// <para>The producer ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public EndTxnRequest WithProducerId(Int64 producerId)
        {
            ProducerId = producerId;
            return this;
        }

        private Int16 _producerEpoch = Int16.Default;
        /// <summary>
        /// <para>The current epoch associated with the producer.</para>
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
        /// <para>The current epoch associated with the producer.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public EndTxnRequest WithProducerEpoch(Int16 producerEpoch)
        {
            ProducerEpoch = producerEpoch;
            return this;
        }

        private Boolean _committed = Boolean.Default;
        /// <summary>
        /// <para>True if the transaction was committed, false if it was aborted.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean Committed
        {
            get => _committed;
            private set
            {
                _committed = value;
            }
        }

        /// <summary>
        /// <para>True if the transaction was committed, false if it was aborted.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public EndTxnRequest WithCommitted(Boolean committed)
        {
            Committed = committed;
            return this;
        }

        public EndTxnResponse Respond() => new EndTxnResponse(Version);
    }
}
