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
    public class ApiVersionsRequest : Message, IRespond<ApiVersionsResponse>
    {
        public ApiVersionsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ApiVersionsRequest does not support version {version}. Valid versions are: 0-3");
            Version = version;
            IsFlexibleVersion = version >= 3;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(18);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(3);
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

        internal override int GetSize() => (Version >= 3 ? _clientSoftwareName.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _clientSoftwareVersion.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ApiVersionsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ApiVersionsRequest(version);
            if (instance.Version >= 3)
                instance.ClientSoftwareName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.ClientSoftwareVersion = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ApiVersionsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 3)
                await _clientSoftwareName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _clientSoftwareVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _clientSoftwareName = String.Default;
        /// <summary>
        /// <para>The name of the client.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public String ClientSoftwareName
        {
            get => _clientSoftwareName;
            private set
            {
                _clientSoftwareName = value;
            }
        }

        /// <summary>
        /// <para>The name of the client.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public ApiVersionsRequest WithClientSoftwareName(String clientSoftwareName)
        {
            ClientSoftwareName = clientSoftwareName;
            return this;
        }

        private String _clientSoftwareVersion = String.Default;
        /// <summary>
        /// <para>The version of the client.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public String ClientSoftwareVersion
        {
            get => _clientSoftwareVersion;
            private set
            {
                _clientSoftwareVersion = value;
            }
        }

        /// <summary>
        /// <para>The version of the client.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public ApiVersionsRequest WithClientSoftwareVersion(String clientSoftwareVersion)
        {
            ClientSoftwareVersion = clientSoftwareVersion;
            return this;
        }

        public ApiVersionsResponse Respond() => new ApiVersionsResponse(Version);
    }
}
