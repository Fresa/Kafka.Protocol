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
    public class PushTelemetryRequest : Message, IRespond<PushTelemetryResponse>
    {
        public PushTelemetryRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"PushTelemetryRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(72);
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

        internal override int GetSize() => _clientInstanceId.GetSize(IsFlexibleVersion) + _subscriptionId.GetSize(IsFlexibleVersion) + _terminating.GetSize(IsFlexibleVersion) + _compressionType.GetSize(IsFlexibleVersion) + _metrics.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<PushTelemetryRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new PushTelemetryRequest(version);
            instance.ClientInstanceId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.SubscriptionId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.Terminating = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.CompressionType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.Metrics = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for PushTelemetryRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _clientInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _subscriptionId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _terminating.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _compressionType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _metrics.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Uuid _clientInstanceId = Uuid.Default;
        /// <summary>
        /// <para>Unique id for this client instance.</para>
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
        /// <para>Unique id for this client instance.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public PushTelemetryRequest WithClientInstanceId(Uuid clientInstanceId)
        {
            ClientInstanceId = clientInstanceId;
            return this;
        }

        private Int32 _subscriptionId = Int32.Default;
        /// <summary>
        /// <para>Unique identifier for the current subscription.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 SubscriptionId
        {
            get => _subscriptionId;
            private set
            {
                _subscriptionId = value;
            }
        }

        /// <summary>
        /// <para>Unique identifier for the current subscription.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public PushTelemetryRequest WithSubscriptionId(Int32 subscriptionId)
        {
            SubscriptionId = subscriptionId;
            return this;
        }

        private Boolean _terminating = Boolean.Default;
        /// <summary>
        /// <para>Client is terminating the connection.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean Terminating
        {
            get => _terminating;
            private set
            {
                _terminating = value;
            }
        }

        /// <summary>
        /// <para>Client is terminating the connection.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public PushTelemetryRequest WithTerminating(Boolean terminating)
        {
            Terminating = terminating;
            return this;
        }

        private Int8 _compressionType = Int8.Default;
        /// <summary>
        /// <para>Compression codec used to compress the metrics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int8 CompressionType
        {
            get => _compressionType;
            private set
            {
                _compressionType = value;
            }
        }

        /// <summary>
        /// <para>Compression codec used to compress the metrics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public PushTelemetryRequest WithCompressionType(Int8 compressionType)
        {
            CompressionType = compressionType;
            return this;
        }

        private Bytes _metrics = Bytes.Default;
        /// <summary>
        /// <para>Metrics encoded in OpenTelemetry MetricsData v1 protobuf format.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Bytes Metrics
        {
            get => _metrics;
            private set
            {
                _metrics = value;
            }
        }

        /// <summary>
        /// <para>Metrics encoded in OpenTelemetry MetricsData v1 protobuf format.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public PushTelemetryRequest WithMetrics(Bytes metrics)
        {
            Metrics = metrics;
            return this;
        }

        public PushTelemetryResponse Respond() => new PushTelemetryResponse(Version);
    }
}
