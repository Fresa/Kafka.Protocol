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
    public class GetTelemetrySubscriptionsResponse : Message
    {
        public GetTelemetrySubscriptionsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"GetTelemetrySubscriptionsResponse does not support version {version}. Valid versions are: 0");
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
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _clientInstanceId.GetSize(IsFlexibleVersion) + _subscriptionId.GetSize(IsFlexibleVersion) + _acceptedCompressionTypesCollection.GetSize(IsFlexibleVersion) + _pushIntervalMs.GetSize(IsFlexibleVersion) + _telemetryMaxBytes.GetSize(IsFlexibleVersion) + _deltaTemporality.GetSize(IsFlexibleVersion) + _requestedMetricsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<GetTelemetrySubscriptionsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new GetTelemetrySubscriptionsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ClientInstanceId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.SubscriptionId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.AcceptedCompressionTypesCollection = await Array<Int8>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.PushIntervalMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TelemetryMaxBytes = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.DeltaTemporality = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.RequestedMetricsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for GetTelemetrySubscriptionsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _clientInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _subscriptionId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _acceptedCompressionTypesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _pushIntervalMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _telemetryMaxBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _deltaTemporality.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _requestedMetricsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 ThrottleTimeMs
        {
            get => _throttleTimeMs;
            private set
            {
                _throttleTimeMs = value;
            }
        }

        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public GetTelemetrySubscriptionsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
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
        public GetTelemetrySubscriptionsResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Uuid _clientInstanceId = Uuid.Default;
        /// <summary>
        /// <para>Assigned client instance id if ClientInstanceId was 0 in the request, else 0.</para>
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
        /// <para>Assigned client instance id if ClientInstanceId was 0 in the request, else 0.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public GetTelemetrySubscriptionsResponse WithClientInstanceId(Uuid clientInstanceId)
        {
            ClientInstanceId = clientInstanceId;
            return this;
        }

        private Int32 _subscriptionId = Int32.Default;
        /// <summary>
        /// <para>Unique identifier for the current subscription set for this client instance.</para>
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
        /// <para>Unique identifier for the current subscription set for this client instance.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public GetTelemetrySubscriptionsResponse WithSubscriptionId(Int32 subscriptionId)
        {
            SubscriptionId = subscriptionId;
            return this;
        }

        private Array<Int8> _acceptedCompressionTypesCollection = Array.Empty<Int8>();
        /// <summary>
        /// <para>Compression types that broker accepts for the PushTelemetryRequest.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<Int8> AcceptedCompressionTypesCollection
        {
            get => _acceptedCompressionTypesCollection;
            private set
            {
                _acceptedCompressionTypesCollection = value;
            }
        }

        /// <summary>
        /// <para>Compression types that broker accepts for the PushTelemetryRequest.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public GetTelemetrySubscriptionsResponse WithAcceptedCompressionTypesCollection(Array<Int8> acceptedCompressionTypesCollection)
        {
            AcceptedCompressionTypesCollection = acceptedCompressionTypesCollection;
            return this;
        }

        private Int32 _pushIntervalMs = Int32.Default;
        /// <summary>
        /// <para>Configured push interval, which is the lowest configured interval in the current subscription set.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 PushIntervalMs
        {
            get => _pushIntervalMs;
            private set
            {
                _pushIntervalMs = value;
            }
        }

        /// <summary>
        /// <para>Configured push interval, which is the lowest configured interval in the current subscription set.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public GetTelemetrySubscriptionsResponse WithPushIntervalMs(Int32 pushIntervalMs)
        {
            PushIntervalMs = pushIntervalMs;
            return this;
        }

        private Int32 _telemetryMaxBytes = Int32.Default;
        /// <summary>
        /// <para>The maximum bytes of binary data the broker accepts in PushTelemetryRequest.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 TelemetryMaxBytes
        {
            get => _telemetryMaxBytes;
            private set
            {
                _telemetryMaxBytes = value;
            }
        }

        /// <summary>
        /// <para>The maximum bytes of binary data the broker accepts in PushTelemetryRequest.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public GetTelemetrySubscriptionsResponse WithTelemetryMaxBytes(Int32 telemetryMaxBytes)
        {
            TelemetryMaxBytes = telemetryMaxBytes;
            return this;
        }

        private Boolean _deltaTemporality = Boolean.Default;
        /// <summary>
        /// <para>Flag to indicate monotonic/counter metrics are to be emitted as deltas or cumulative values</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean DeltaTemporality
        {
            get => _deltaTemporality;
            private set
            {
                _deltaTemporality = value;
            }
        }

        /// <summary>
        /// <para>Flag to indicate monotonic/counter metrics are to be emitted as deltas or cumulative values</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public GetTelemetrySubscriptionsResponse WithDeltaTemporality(Boolean deltaTemporality)
        {
            DeltaTemporality = deltaTemporality;
            return this;
        }

        private Array<String> _requestedMetricsCollection = Array.Empty<String>();
        /// <summary>
        /// <para>Requested metrics prefix string match. Empty array: No metrics subscribed, Array[0] empty string: All metrics subscribed.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<String> RequestedMetricsCollection
        {
            get => _requestedMetricsCollection;
            private set
            {
                _requestedMetricsCollection = value;
            }
        }

        /// <summary>
        /// <para>Requested metrics prefix string match. Empty array: No metrics subscribed, Array[0] empty string: All metrics subscribed.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public GetTelemetrySubscriptionsResponse WithRequestedMetricsCollection(Array<String> requestedMetricsCollection)
        {
            RequestedMetricsCollection = requestedMetricsCollection;
            return this;
        }
    }
}
