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
    public class LeaveGroupRequest : Message, IRespond<LeaveGroupResponse>
    {
        public LeaveGroupRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"LeaveGroupRequest does not support version {version}. Valid versions are: 0-5");
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
                return (short)(IsFlexibleVersion ? 2 : 1);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + (Version >= 0 && Version <= 2 ? _memberId.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _membersCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<LeaveGroupRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new LeaveGroupRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 2)
                instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.MembersCollection = await Array<MemberIdentity>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => MemberIdentity.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaveGroupRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 2)
                await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _membersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _groupId = String.Default;
        /// <summary>
        /// <para>The ID of the group to leave.</para>
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
        /// <para>The ID of the group to leave.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public LeaveGroupRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The member ID to remove from the group.</para>
        /// <para>Versions: 0-2</para>
        /// </summary>
        public String MemberId
        {
            get => _memberId;
            private set
            {
                if (Version >= 0 && Version <= 2 == false)
                    throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 0-2");
                _memberId = value;
            }
        }

        /// <summary>
        /// <para>The member ID to remove from the group.</para>
        /// <para>Versions: 0-2</para>
        /// </summary>
        public LeaveGroupRequest WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private Array<MemberIdentity> _membersCollection = Array.Empty<MemberIdentity>();
        /// <summary>
        /// <para>List of leaving member identities.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public Array<MemberIdentity> MembersCollection
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
        /// <para>List of leaving member identities.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public LeaveGroupRequest WithMembersCollection(params Func<MemberIdentity, MemberIdentity>[] createFields)
        {
            MembersCollection = createFields.Select(createField => createField(new MemberIdentity(Version))).ToArray();
            return this;
        }

        public delegate MemberIdentity CreateMemberIdentity(MemberIdentity field);
        /// <summary>
        /// <para>List of leaving member identities.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public LeaveGroupRequest WithMembersCollection(IEnumerable<CreateMemberIdentity> createFields)
        {
            MembersCollection = createFields.Select(createField => createField(new MemberIdentity(Version))).ToArray();
            return this;
        }

        public class MemberIdentity : ISerialize
        {
            internal MemberIdentity(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 3 ? _memberId.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _groupInstanceId.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _reason.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<MemberIdentity> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new MemberIdentity(version);
                if (instance.Version >= 3)
                    instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.GroupInstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 5)
                    instance.Reason = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for MemberIdentity is unknown");
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
                if (Version >= 5)
                    await _reason.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public MemberIdentity WithMemberId(String memberId)
            {
                MemberId = memberId;
                return this;
            }

            private NullableString _groupInstanceId = new NullableString(null);
            /// <summary>
            /// <para>The group instance ID to remove from the group.</para>
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
            /// <para>The group instance ID to remove from the group.</para>
            /// <para>Versions: 3+</para>
            /// <para>Default: null</para>
            /// </summary>
            public MemberIdentity WithGroupInstanceId(String? groupInstanceId)
            {
                GroupInstanceId = groupInstanceId;
                return this;
            }

            private NullableString _reason = new NullableString(null);
            /// <summary>
            /// <para>The reason why the member left the group.</para>
            /// <para>Versions: 5+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? Reason
            {
                get => _reason;
                private set
                {
                    if (Version >= 5 == false && value == null)
                        throw new UnsupportedVersionException($"Reason does not support null for version {Version}. Supported versions for null value: 5+");
                    _reason = value;
                }
            }

            /// <summary>
            /// <para>The reason why the member left the group.</para>
            /// <para>Versions: 5+</para>
            /// <para>Default: null</para>
            /// </summary>
            public MemberIdentity WithReason(String? reason)
            {
                Reason = reason;
                return this;
            }
        }

        public LeaveGroupResponse Respond() => new LeaveGroupResponse(Version);
    }
}
