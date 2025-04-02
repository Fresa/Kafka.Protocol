#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public class RequestHeader
    {
        public RequestHeader(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"RequestHeader does not support version {version}. Valid versions are: 1-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        public static readonly Int16 MinVersion = Int16.From(1);
        public static readonly Int16 MaxVersion = Int16.From(2);
        public Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal int GetSize() => _requestApiKey.GetSize(IsFlexibleVersion) + _requestApiVersion.GetSize(IsFlexibleVersion) + _correlationId.GetSize(IsFlexibleVersion) + (Version >= 1 ? _clientId.GetSize(false) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<RequestHeader> FromReaderAsync(PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new RequestHeader(MinVersion);
            instance.RequestApiKey = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.RequestApiVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance = new RequestHeader(Messages.GetRequestHeaderVersionFor(instance.RequestApiKey, instance.RequestApiVersion))
            {
                RequestApiKey = instance.RequestApiKey,
                RequestApiVersion = instance.RequestApiVersion
            };
            instance.CorrelationId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.ClientId = await NullableString.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for RequestHeader is unknown");
                    }
                }
            }

            return instance;
        }

        internal async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _requestApiKey.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _requestApiVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _correlationId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _clientId.WriteToAsync(writer, false, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int16 _requestApiKey = Int16.Default;
        /// <summary>
        /// <para>The API key of this request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int16 RequestApiKey
        {
            get => _requestApiKey;
            private set
            {
                _requestApiKey = value;
            }
        }

        /// <summary>
        /// <para>The API key of this request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public RequestHeader WithRequestApiKey(Int16 requestApiKey)
        {
            RequestApiKey = requestApiKey;
            return this;
        }

        private Int16 _requestApiVersion = Int16.Default;
        /// <summary>
        /// <para>The API version of this request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int16 RequestApiVersion
        {
            get => _requestApiVersion;
            private set
            {
                _requestApiVersion = value;
            }
        }

        /// <summary>
        /// <para>The API version of this request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public RequestHeader WithRequestApiVersion(Int16 requestApiVersion)
        {
            RequestApiVersion = requestApiVersion;
            return this;
        }

        private Int32 _correlationId = Int32.Default;
        /// <summary>
        /// <para>The correlation ID of this request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 CorrelationId
        {
            get => _correlationId;
            private set
            {
                _correlationId = value;
            }
        }

        /// <summary>
        /// <para>The correlation ID of this request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public RequestHeader WithCorrelationId(Int32 correlationId)
        {
            CorrelationId = correlationId;
            return this;
        }

        private NullableString _clientId = NullableString.Default;
        /// <summary>
        /// <para>The client ID string.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public String? ClientId
        {
            get => _clientId;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"ClientId does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                if (Version >= 1 == false && value == null)
                    throw new UnsupportedVersionException($"ClientId does not support null for version {Version}. Supported versions for null value: 1+");
                _clientId = value;
            }
        }

        /// <summary>
        /// <para>The client ID string.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public RequestHeader WithClientId(String? clientId)
        {
            ClientId = clientId;
            return this;
        }
    }
}
