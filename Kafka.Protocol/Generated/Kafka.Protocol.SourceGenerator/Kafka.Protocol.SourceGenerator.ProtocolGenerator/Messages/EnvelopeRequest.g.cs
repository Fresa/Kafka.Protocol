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
    public class EnvelopeRequest : Message, IRespond<EnvelopeResponse>
    {
        public EnvelopeRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"EnvelopeRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(58);
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

        internal override int GetSize() => _requestData.GetSize(IsFlexibleVersion) + _requestPrincipal.GetSize(IsFlexibleVersion) + _clientHostAddress.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<EnvelopeRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new EnvelopeRequest(version);
            instance.RequestData = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.RequestPrincipal = await NullableBytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ClientHostAddress = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for EnvelopeRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _requestData.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _requestPrincipal.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _clientHostAddress.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Bytes _requestData = Bytes.Default;
        /// <summary>
        /// <para>The embedded request header and data.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Bytes RequestData
        {
            get => _requestData;
            private set
            {
                _requestData = value;
            }
        }

        /// <summary>
        /// <para>The embedded request header and data.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public EnvelopeRequest WithRequestData(Bytes requestData)
        {
            RequestData = requestData;
            return this;
        }

        private NullableBytes _requestPrincipal = NullableBytes.Default;
        /// <summary>
        /// <para>Value of the initial client principal when the request is redirected by a broker.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Bytes? RequestPrincipal
        {
            get => _requestPrincipal;
            private set
            {
                _requestPrincipal = value;
            }
        }

        /// <summary>
        /// <para>Value of the initial client principal when the request is redirected by a broker.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public EnvelopeRequest WithRequestPrincipal(Bytes? requestPrincipal)
        {
            RequestPrincipal = requestPrincipal;
            return this;
        }

        private Bytes _clientHostAddress = Bytes.Default;
        /// <summary>
        /// <para>The original client's address in bytes.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Bytes ClientHostAddress
        {
            get => _clientHostAddress;
            private set
            {
                _clientHostAddress = value;
            }
        }

        /// <summary>
        /// <para>The original client's address in bytes.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public EnvelopeRequest WithClientHostAddress(Bytes clientHostAddress)
        {
            ClientHostAddress = clientHostAddress;
            return this;
        }

        public EnvelopeResponse Respond() => new EnvelopeResponse(Version);
    }
}
