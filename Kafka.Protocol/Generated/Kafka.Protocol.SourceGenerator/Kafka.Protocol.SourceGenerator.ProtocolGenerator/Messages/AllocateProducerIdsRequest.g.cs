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
    public class AllocateProducerIdsRequest : Message, IRespond<AllocateProducerIdsResponse>
    {
        public AllocateProducerIdsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AllocateProducerIdsRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(67);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
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

        internal override int GetSize() => _brokerId.GetSize(IsFlexibleVersion) + _brokerEpoch.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AllocateProducerIdsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AllocateProducerIdsRequest(version);
            instance.BrokerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.BrokerEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AllocateProducerIdsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _brokerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _brokerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _brokerId = Int32.Default;
        /// <summary>
        /// <para>The ID of the requesting broker</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 BrokerId
        {
            get => _brokerId;
            private set
            {
                _brokerId = value;
            }
        }

        /// <summary>
        /// <para>The ID of the requesting broker</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AllocateProducerIdsRequest WithBrokerId(Int32 brokerId)
        {
            BrokerId = brokerId;
            return this;
        }

        private Int64 _brokerEpoch = new Int64(-1);
        /// <summary>
        /// <para>The epoch of the requesting broker</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int64 BrokerEpoch
        {
            get => _brokerEpoch;
            private set
            {
                _brokerEpoch = value;
            }
        }

        /// <summary>
        /// <para>The epoch of the requesting broker</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public AllocateProducerIdsRequest WithBrokerEpoch(Int64 brokerEpoch)
        {
            BrokerEpoch = brokerEpoch;
            return this;
        }

        public AllocateProducerIdsResponse Respond() => new AllocateProducerIdsResponse(Version);
    }
}
