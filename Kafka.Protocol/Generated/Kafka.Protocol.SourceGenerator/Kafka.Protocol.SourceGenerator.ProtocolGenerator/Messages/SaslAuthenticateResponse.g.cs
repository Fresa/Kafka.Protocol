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
    public class SaslAuthenticateResponse : Message
    {
        public SaslAuthenticateResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"SaslAuthenticateResponse does not support version {version}. Valid versions are: 0-2");
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
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _authBytes.GetSize(IsFlexibleVersion) + (Version >= 1 ? _sessionLifetimeMs.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<SaslAuthenticateResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new SaslAuthenticateResponse(version);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.AuthBytes = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.SessionLifetimeMs = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for SaslAuthenticateResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _authBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _sessionLifetimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The error code, or 0 if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int16 ErrorCode
        {
            get => _errorCode;
            private set
            {
                _errorCode = value;
            }
        }

        /// <summary>
        /// <para>The error code, or 0 if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public SaslAuthenticateResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private NullableString _errorMessage = NullableString.Default;
        /// <summary>
        /// <para>The error message, or null if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String? ErrorMessage
        {
            get => _errorMessage;
            private set
            {
                _errorMessage = value;
            }
        }

        /// <summary>
        /// <para>The error message, or null if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public SaslAuthenticateResponse WithErrorMessage(String? errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        private Bytes _authBytes = Bytes.Default;
        /// <summary>
        /// <para>The SASL authentication bytes from the server, as defined by the SASL mechanism.</para>
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
        /// <para>The SASL authentication bytes from the server, as defined by the SASL mechanism.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public SaslAuthenticateResponse WithAuthBytes(Bytes authBytes)
        {
            AuthBytes = authBytes;
            return this;
        }

        private Int64 _sessionLifetimeMs = new Int64(0);
        /// <summary>
        /// <para>Number of milliseconds after which only re-authentication over the existing connection to create a new session can occur.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public Int64 SessionLifetimeMs
        {
            get => _sessionLifetimeMs;
            private set
            {
                _sessionLifetimeMs = value;
            }
        }

        /// <summary>
        /// <para>Number of milliseconds after which only re-authentication over the existing connection to create a new session can occur.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public SaslAuthenticateResponse WithSessionLifetimeMs(Int64 sessionLifetimeMs)
        {
            SessionLifetimeMs = sessionLifetimeMs;
            return this;
        }
    }
}
