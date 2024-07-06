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
    public class ResponseHeader
    {
        public ResponseHeader(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ResponseHeader does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = version >= 1;
        }

        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(1);
        public Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal int GetSize() => _correlationId.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ResponseHeader> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ResponseHeader(version);
            instance.CorrelationId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ResponseHeader is unknown");
                    }
                }
            }

            return instance;
        }

        internal async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _correlationId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _correlationId = Int32.Default;
        /// <summary>
        /// <para>The correlation ID of this response.</para>
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
        /// <para>The correlation ID of this response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ResponseHeader WithCorrelationId(Int32 correlationId)
        {
            CorrelationId = correlationId;
            return this;
        }
    }
}
