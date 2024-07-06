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
    public class GetTelemetrySubscriptionsRequest : Message, IRespond<GetTelemetrySubscriptionsResponse>
    {
        public GetTelemetrySubscriptionsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"GetTelemetrySubscriptionsRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(71);
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

        internal override int GetSize() => _clientInstanceId.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<GetTelemetrySubscriptionsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new GetTelemetrySubscriptionsRequest(version);
            instance.ClientInstanceId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for GetTelemetrySubscriptionsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _clientInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Uuid _clientInstanceId = Uuid.Default;
        /// <summary>
        /// <para>Unique id for this client instance, must be set to 0 on the first request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Uuid ClientInstanceId
        {
            get => _clientInstanceId;
            private set
            {
                _clientInstanceId = value;
            }
        }

        /// <summary>
        /// <para>Unique id for this client instance, must be set to 0 on the first request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public GetTelemetrySubscriptionsRequest WithClientInstanceId(Uuid clientInstanceId)
        {
            ClientInstanceId = clientInstanceId;
            return this;
        }

        public GetTelemetrySubscriptionsResponse Respond() => new GetTelemetrySubscriptionsResponse(Version);
    }
}
