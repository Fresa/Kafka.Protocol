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
    public class BrokerHeartbeatResponse : Message
    {
        public BrokerHeartbeatResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"BrokerHeartbeatResponse does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(63);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(1);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _isCaughtUp.GetSize(IsFlexibleVersion) + _isFenced.GetSize(IsFlexibleVersion) + _shouldShutDown.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<BrokerHeartbeatResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new BrokerHeartbeatResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.IsCaughtUp = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.IsFenced = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ShouldShutDown = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for BrokerHeartbeatResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _isCaughtUp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _isFenced.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _shouldShutDown.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
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
        /// <para>Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerHeartbeatResponse WithThrottleTimeMs(Int32 throttleTimeMs)
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
        public BrokerHeartbeatResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Boolean _isCaughtUp = new Boolean(false);
        /// <summary>
        /// <para>True if the broker has approximately caught up with the latest metadata.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean IsCaughtUp
        {
            get => _isCaughtUp;
            private set
            {
                _isCaughtUp = value;
            }
        }

        /// <summary>
        /// <para>True if the broker has approximately caught up with the latest metadata.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: false</para>
        /// </summary>
        public BrokerHeartbeatResponse WithIsCaughtUp(Boolean isCaughtUp)
        {
            IsCaughtUp = isCaughtUp;
            return this;
        }

        private Boolean _isFenced = new Boolean(true);
        /// <summary>
        /// <para>True if the broker is fenced.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: true</para>
        /// </summary>
        public Boolean IsFenced
        {
            get => _isFenced;
            private set
            {
                _isFenced = value;
            }
        }

        /// <summary>
        /// <para>True if the broker is fenced.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: true</para>
        /// </summary>
        public BrokerHeartbeatResponse WithIsFenced(Boolean isFenced)
        {
            IsFenced = isFenced;
            return this;
        }

        private Boolean _shouldShutDown = Boolean.Default;
        /// <summary>
        /// <para>True if the broker should proceed with its shutdown.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean ShouldShutDown
        {
            get => _shouldShutDown;
            private set
            {
                _shouldShutDown = value;
            }
        }

        /// <summary>
        /// <para>True if the broker should proceed with its shutdown.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerHeartbeatResponse WithShouldShutDown(Boolean shouldShutDown)
        {
            ShouldShutDown = shouldShutDown;
            return this;
        }
    }
}
