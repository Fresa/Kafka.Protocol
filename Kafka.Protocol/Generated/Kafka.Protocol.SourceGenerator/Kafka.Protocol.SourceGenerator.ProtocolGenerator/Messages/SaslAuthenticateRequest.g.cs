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
    public class SaslAuthenticateRequest : Message, IRespond<SaslAuthenticateResponse>
    {
        public SaslAuthenticateRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"SaslAuthenticateRequest does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(36);
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

        internal override int GetSize() => _authBytes.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<SaslAuthenticateRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new SaslAuthenticateRequest(version);
            instance.AuthBytes = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for SaslAuthenticateRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _authBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Bytes _authBytes = Bytes.Default;
        /// <summary>
        /// <para>The SASL authentication bytes from the client, as defined by the SASL mechanism.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Bytes AuthBytes
        {
            get => _authBytes;
            private set
            {
                _authBytes = value;
            }
        }

        /// <summary>
        /// <para>The SASL authentication bytes from the client, as defined by the SASL mechanism.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public SaslAuthenticateRequest WithAuthBytes(Bytes authBytes)
        {
            AuthBytes = authBytes;
            return this;
        }

        public SaslAuthenticateResponse Respond() => new SaslAuthenticateResponse(Version);
    }
}
