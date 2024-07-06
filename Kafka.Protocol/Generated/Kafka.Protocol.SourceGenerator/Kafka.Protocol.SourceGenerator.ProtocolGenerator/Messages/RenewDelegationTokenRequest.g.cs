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
    public class RenewDelegationTokenRequest : Message, IRespond<RenewDelegationTokenResponse>
    {
        public RenewDelegationTokenRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"RenewDelegationTokenRequest does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(39);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(2);
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

        internal override int GetSize() => _hmac.GetSize(IsFlexibleVersion) + _renewPeriodMs.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<RenewDelegationTokenRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new RenewDelegationTokenRequest(version);
            instance.Hmac = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.RenewPeriodMs = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for RenewDelegationTokenRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _hmac.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _renewPeriodMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Bytes _hmac = Bytes.Default;
        /// <summary>
        /// <para>The HMAC of the delegation token to be renewed.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Bytes Hmac
        {
            get => _hmac;
            private set
            {
                _hmac = value;
            }
        }

        /// <summary>
        /// <para>The HMAC of the delegation token to be renewed.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public RenewDelegationTokenRequest WithHmac(Bytes hmac)
        {
            Hmac = hmac;
            return this;
        }

        private Int64 _renewPeriodMs = Int64.Default;
        /// <summary>
        /// <para>The renewal time period in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 RenewPeriodMs
        {
            get => _renewPeriodMs;
            private set
            {
                _renewPeriodMs = value;
            }
        }

        /// <summary>
        /// <para>The renewal time period in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public RenewDelegationTokenRequest WithRenewPeriodMs(Int64 renewPeriodMs)
        {
            RenewPeriodMs = renewPeriodMs;
            return this;
        }

        public RenewDelegationTokenResponse Respond() => new RenewDelegationTokenResponse(Version);
    }
}
