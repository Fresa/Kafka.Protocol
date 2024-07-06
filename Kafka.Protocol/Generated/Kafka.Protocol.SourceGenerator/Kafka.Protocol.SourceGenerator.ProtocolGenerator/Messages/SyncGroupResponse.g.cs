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
    public class SyncGroupResponse : Message
    {
        public SyncGroupResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"SyncGroupResponse does not support version {version}. Valid versions are: 0-5");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(14);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(5);
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

        internal override int GetSize() => (Version >= 1 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + _errorCode.GetSize(IsFlexibleVersion) + (Version >= 5 ? _protocolType.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _protocolName.GetSize(IsFlexibleVersion) : 0) + _assignment.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<SyncGroupResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new SyncGroupResponse(version);
            if (instance.Version >= 1)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 5)
                instance.ProtocolType = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 5)
                instance.ProtocolName = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.Assignment = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for SyncGroupResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 1)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 5)
                await _protocolType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 5)
                await _protocolName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _assignment.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 1+</para>
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
        /// <para>Versions: 1+</para>
        /// </summary>
        public SyncGroupResponse WithThrottleTimeMs(Int32 throttleTimeMs)
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
        public SyncGroupResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private NullableString _protocolType = new NullableString(null);
        /// <summary>
        /// <para>The group protocol type.</para>
        /// <para>Versions: 5+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ProtocolType
        {
            get => _protocolType;
            private set
            {
                if (Version >= 5 == false && value == null)
                    throw new UnsupportedVersionException($"ProtocolType does not support null for version {Version}. Supported versions for null value: 5+");
                _protocolType = value;
            }
        }

        /// <summary>
        /// <para>The group protocol type.</para>
        /// <para>Versions: 5+</para>
        /// <para>Default: null</para>
        /// </summary>
        public SyncGroupResponse WithProtocolType(String? protocolType)
        {
            ProtocolType = protocolType;
            return this;
        }

        private NullableString _protocolName = new NullableString(null);
        /// <summary>
        /// <para>The group protocol name.</para>
        /// <para>Versions: 5+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ProtocolName
        {
            get => _protocolName;
            private set
            {
                if (Version >= 5 == false && value == null)
                    throw new UnsupportedVersionException($"ProtocolName does not support null for version {Version}. Supported versions for null value: 5+");
                _protocolName = value;
            }
        }

        /// <summary>
        /// <para>The group protocol name.</para>
        /// <para>Versions: 5+</para>
        /// <para>Default: null</para>
        /// </summary>
        public SyncGroupResponse WithProtocolName(String? protocolName)
        {
            ProtocolName = protocolName;
            return this;
        }

        private Bytes _assignment = Bytes.Default;
        /// <summary>
        /// <para>The member assignment.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Bytes Assignment
        {
            get => _assignment;
            private set
            {
                _assignment = value;
            }
        }

        /// <summary>
        /// <para>The member assignment.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public SyncGroupResponse WithAssignment(Bytes assignment)
        {
            Assignment = assignment;
            return this;
        }
    }
}
