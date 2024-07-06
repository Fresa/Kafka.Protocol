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
    public class JoinGroupResponse : Message
    {
        public JoinGroupResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"JoinGroupResponse does not support version {version}. Valid versions are: 0-9");
            Version = version;
            IsFlexibleVersion = version >= 6;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(11);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(9);
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

        internal override int GetSize() => (Version >= 2 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + _errorCode.GetSize(IsFlexibleVersion) + _generationId.GetSize(IsFlexibleVersion) + (Version >= 7 ? _protocolType.GetSize(IsFlexibleVersion) : 0) + _protocolName.GetSize(IsFlexibleVersion) + _leader.GetSize(IsFlexibleVersion) + (Version >= 9 ? _skipAssignment.GetSize(IsFlexibleVersion) : 0) + _memberId.GetSize(IsFlexibleVersion) + _membersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<JoinGroupResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new JoinGroupResponse(version);
            if (instance.Version >= 2)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.GenerationId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 7)
                instance.ProtocolType = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ProtocolName = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.Leader = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 9)
                instance.SkipAssignment = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MembersCollection = await Array<JoinGroupResponseMember>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => JoinGroupResponseMember.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for JoinGroupResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 2)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _generationId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 7)
                await _protocolType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _protocolName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _leader.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 9)
                await _skipAssignment.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _membersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 2+</para>
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
        /// <para>Versions: 2+</para>
        /// </summary>
        public JoinGroupResponse WithThrottleTimeMs(Int32 throttleTimeMs)
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
        public JoinGroupResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Int32 _generationId = new Int32(-1);
        /// <summary>
        /// <para>The generation ID of the group.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
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
        /// <para>The generation ID of the group.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public JoinGroupResponse WithGenerationId(Int32 generationId)
        {
            GenerationId = generationId;
            return this;
        }

        private NullableString _protocolType = new NullableString(null);
        /// <summary>
        /// <para>The group protocol name.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ProtocolType
        {
            get => _protocolType;
            private set
            {
                if (Version >= 7 == false && value == null)
                    throw new UnsupportedVersionException($"ProtocolType does not support null for version {Version}. Supported versions for null value: 7+");
                _protocolType = value;
            }
        }

        /// <summary>
        /// <para>The group protocol name.</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: null</para>
        /// </summary>
        public JoinGroupResponse WithProtocolType(String? protocolType)
        {
            ProtocolType = protocolType;
            return this;
        }

        private NullableString _protocolName = NullableString.Default;
        /// <summary>
        /// <para>The group protocol selected by the coordinator.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String? ProtocolName
        {
            get => _protocolName;
            private set
            {
                if (Version >= 7 == false && value == null)
                    throw new UnsupportedVersionException($"ProtocolName does not support null for version {Version}. Supported versions for null value: 7+");
                _protocolName = value;
            }
        }

        /// <summary>
        /// <para>The group protocol selected by the coordinator.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public JoinGroupResponse WithProtocolName(String? protocolName)
        {
            ProtocolName = protocolName;
            return this;
        }

        private String _leader = String.Default;
        /// <summary>
        /// <para>The leader of the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String Leader
        {
            get => _leader;
            private set
            {
                _leader = value;
            }
        }

        /// <summary>
        /// <para>The leader of the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public JoinGroupResponse WithLeader(String leader)
        {
            Leader = leader;
            return this;
        }

        private Boolean _skipAssignment = new Boolean(false);
        /// <summary>
        /// <para>True if the leader must skip running the assignment.</para>
        /// <para>Versions: 9+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean SkipAssignment
        {
            get => _skipAssignment;
            private set
            {
                if (Version >= 9 == false)
                    throw new UnsupportedVersionException($"SkipAssignment does not support version {Version} and has been defined as not ignorable. Supported versions: 9+");
                _skipAssignment = value;
            }
        }

        /// <summary>
        /// <para>True if the leader must skip running the assignment.</para>
        /// <para>Versions: 9+</para>
        /// <para>Default: false</para>
        /// </summary>
        public JoinGroupResponse WithSkipAssignment(Boolean skipAssignment)
        {
            SkipAssignment = skipAssignment;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The member ID assigned by the group coordinator.</para>
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
        /// <para>The member ID assigned by the group coordinator.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public JoinGroupResponse WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private Array<JoinGroupResponseMember> _membersCollection = Array.Empty<JoinGroupResponseMember>();
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<JoinGroupResponseMember> MembersCollection
        {
            get => _membersCollection;
            private set
            {
                _membersCollection = value;
            }
        }

        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public JoinGroupResponse WithMembersCollection(params Func<JoinGroupResponseMember, JoinGroupResponseMember>[] createFields)
        {
            MembersCollection = createFields.Select(createField => createField(new JoinGroupResponseMember(Version))).ToArray();
            return this;
        }

        public delegate JoinGroupResponseMember CreateJoinGroupResponseMember(JoinGroupResponseMember field);
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public JoinGroupResponse WithMembersCollection(IEnumerable<CreateJoinGroupResponseMember> createFields)
        {
            MembersCollection = createFields.Select(createField => createField(new JoinGroupResponseMember(Version))).ToArray();
            return this;
        }

        public class JoinGroupResponseMember : ISerialize
        {
            internal JoinGroupResponseMember(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 6;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _memberId.GetSize(IsFlexibleVersion) + (Version >= 5 ? _groupInstanceId.GetSize(IsFlexibleVersion) : 0) + _metadata.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<JoinGroupResponseMember> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new JoinGroupResponseMember(version);
                instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 5)
                    instance.GroupInstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Metadata = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for JoinGroupResponseMember is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 5)
                    await _groupInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _metadata.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _memberId = String.Default;
            /// <summary>
            /// <para>The group member ID.</para>
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
            /// <para>The group member ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public JoinGroupResponseMember WithMemberId(String memberId)
            {
                MemberId = memberId;
                return this;
            }

            private NullableString _groupInstanceId = new NullableString(null);
            /// <summary>
            /// <para>The unique identifier of the consumer instance provided by end user.</para>
            /// <para>Versions: 5+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? GroupInstanceId
            {
                get => _groupInstanceId;
                private set
                {
                    if (Version >= 5 == false && value == null)
                        throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 5+");
                    _groupInstanceId = value;
                }
            }

            /// <summary>
            /// <para>The unique identifier of the consumer instance provided by end user.</para>
            /// <para>Versions: 5+</para>
            /// <para>Default: null</para>
            /// </summary>
            public JoinGroupResponseMember WithGroupInstanceId(String? groupInstanceId)
            {
                GroupInstanceId = groupInstanceId;
                return this;
            }

            private Bytes _metadata = Bytes.Default;
            /// <summary>
            /// <para>The group member metadata.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Bytes Metadata
            {
                get => _metadata;
                private set
                {
                    _metadata = value;
                }
            }

            /// <summary>
            /// <para>The group member metadata.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public JoinGroupResponseMember WithMetadata(Bytes metadata)
            {
                Metadata = metadata;
                return this;
            }
        }
    }
}
