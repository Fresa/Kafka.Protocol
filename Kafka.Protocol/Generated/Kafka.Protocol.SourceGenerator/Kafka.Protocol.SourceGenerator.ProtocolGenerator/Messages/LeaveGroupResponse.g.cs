#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

// ReSharper disable MemberHidesStaticFromOuterClass FromReaderAsync will cause a lot of these warnings
namespace Kafka.Protocol
{
    public class LeaveGroupResponse : Message
    {
        public LeaveGroupResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"LeaveGroupResponse does not support version {version}. Valid versions are: 0-5");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(13);
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

        internal override int GetSize() => (Version >= 1 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + _errorCode.GetSize(IsFlexibleVersion) + (Version >= 3 ? _membersCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<LeaveGroupResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new LeaveGroupResponse(version);
            if (instance.Version >= 1)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.MembersCollection = await Array<MemberResponse>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => MemberResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaveGroupResponse is unknown");
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
            if (Version >= 3)
                await _membersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public LeaveGroupResponse WithThrottleTimeMs(Int32 throttleTimeMs)
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
        public LeaveGroupResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<MemberResponse> _membersCollection = Array.Empty<MemberResponse>();
        /// <summary>
        /// <para>List of leaving member responses.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public Array<MemberResponse> MembersCollection
        {
            get => _membersCollection;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"MembersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                _membersCollection = value;
            }
        }

        /// <summary>
        /// <para>List of leaving member responses.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public LeaveGroupResponse WithMembersCollection(params Func<MemberResponse, MemberResponse>[] createFields)
        {
            MembersCollection = createFields.Select(createField => createField(new MemberResponse(Version))).ToArray();
            return this;
        }

        public delegate MemberResponse CreateMemberResponse(MemberResponse field);
        /// <summary>
        /// <para>List of leaving member responses.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public LeaveGroupResponse WithMembersCollection(IEnumerable<CreateMemberResponse> createFields)
        {
            MembersCollection = createFields.Select(createField => createField(new MemberResponse(Version))).ToArray();
            return this;
        }

        public class MemberResponse : ISerialize
        {
            internal MemberResponse(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 4;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 3 ? _memberId.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _groupInstanceId.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<MemberResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new MemberResponse(version);
                if (instance.Version >= 3)
                    instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.GroupInstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for MemberResponse is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 3)
                    await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _groupInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _memberId = String.Default;
            /// <summary>
            /// <para>The member ID to remove from the group.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public String MemberId
            {
                get => _memberId;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _memberId = value;
                }
            }

            /// <summary>
            /// <para>The member ID to remove from the group.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public MemberResponse WithMemberId(String memberId)
            {
                MemberId = memberId;
                return this;
            }

            private NullableString _groupInstanceId = NullableString.Default;
            /// <summary>
            /// <para>The group instance ID to remove from the group.</para>
            /// <para>Versions: 3+</para>
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
            /// <para>The group instance ID to remove from the group.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public MemberResponse WithGroupInstanceId(String? groupInstanceId)
            {
                GroupInstanceId = groupInstanceId;
                return this;
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The error code, or 0 if there was no error.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public Int16 ErrorCode
            {
                get => _errorCode;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _errorCode = value;
                }
            }

            /// <summary>
            /// <para>The error code, or 0 if there was no error.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public MemberResponse WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }
        }
    }
}
