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
    public class HeartbeatRequest : Message, IRespond<HeartbeatResponse>
    {
        public HeartbeatRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"HeartbeatRequest does not support version {version}. Valid versions are: 0-4");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(12);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(4);
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

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + _generationId.GetSize(IsFlexibleVersion) + _memberId.GetSize(IsFlexibleVersion) + (Version >= 3 ? _groupInstanceId.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<HeartbeatRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new HeartbeatRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.GenerationId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.GroupInstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for HeartbeatRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _generationId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _groupInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _groupId = String.Default;
        /// <summary>
        /// <para>The group id.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String GroupId
        {
            get => _groupId;
            private set
            {
                _groupId = value;
            }
        }

        /// <summary>
        /// <para>The group id.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public HeartbeatRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private Int32 _generationId = Int32.Default;
        /// <summary>
        /// <para>The generation of the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 GenerationId
        {
            get => _generationId;
            private set
            {
                _generationId = value;
            }
        }

        /// <summary>
        /// <para>The generation of the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public HeartbeatRequest WithGenerationId(Int32 generationId)
        {
            GenerationId = generationId;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The member ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String MemberId
        {
            get => _memberId;
            private set
            {
                _memberId = value;
            }
        }

        /// <summary>
        /// <para>The member ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public HeartbeatRequest WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private NullableString _groupInstanceId = new NullableString(null);
        /// <summary>
        /// <para>The unique identifier of the consumer instance provided by end user.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? GroupInstanceId
        {
            get => _groupInstanceId;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                if (Version >= 3 == false && value == null)
                    throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 3+");
                _groupInstanceId = value;
            }
        }

        /// <summary>
        /// <para>The unique identifier of the consumer instance provided by end user.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: null</para>
        /// </summary>
        public HeartbeatRequest WithGroupInstanceId(String? groupInstanceId)
        {
            GroupInstanceId = groupInstanceId;
            return this;
        }

        public HeartbeatResponse Respond() => new HeartbeatResponse(Version);
    }
}
