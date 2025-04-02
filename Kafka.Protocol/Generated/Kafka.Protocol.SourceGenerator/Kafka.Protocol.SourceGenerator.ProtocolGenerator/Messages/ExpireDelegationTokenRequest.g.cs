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
    public class ExpireDelegationTokenRequest : Message, IRespond<ExpireDelegationTokenResponse>
    {
        public ExpireDelegationTokenRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ExpireDelegationTokenRequest does not support version {version}. Valid versions are: 1-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(40);
        public static readonly Int16 MinVersion = Int16.From(1);
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

        internal override int GetSize() => _hmac.GetSize(IsFlexibleVersion) + _expiryTimePeriodMs.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ExpireDelegationTokenRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ExpireDelegationTokenRequest(version);
            instance.Hmac = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ExpiryTimePeriodMs = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ExpireDelegationTokenRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _hmac.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _expiryTimePeriodMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Bytes _hmac = Bytes.Default;
        /// <summary>
        /// <para>The HMAC of the delegation token to be expired.</para>
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
        /// <para>The HMAC of the delegation token to be expired.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ExpireDelegationTokenRequest WithHmac(Bytes hmac)
        {
            Hmac = hmac;
            return this;
        }

        private Int64 _expiryTimePeriodMs = Int64.Default;
        /// <summary>
        /// <para>The expiry time period in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 ExpiryTimePeriodMs
        {
            get => _expiryTimePeriodMs;
            private set
            {
                _expiryTimePeriodMs = value;
            }
        }

        /// <summary>
        /// <para>The expiry time period in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ExpireDelegationTokenRequest WithExpiryTimePeriodMs(Int64 expiryTimePeriodMs)
        {
            ExpiryTimePeriodMs = expiryTimePeriodMs;
            return this;
        }

        public ExpireDelegationTokenResponse Respond() => new ExpireDelegationTokenResponse(Version);
    }
}
