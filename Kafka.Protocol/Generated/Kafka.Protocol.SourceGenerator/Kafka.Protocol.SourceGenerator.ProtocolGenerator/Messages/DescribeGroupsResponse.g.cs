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
    public class DescribeGroupsResponse : Message
    {
        public DescribeGroupsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeGroupsResponse does not support version {version}. Valid versions are: 0-5");
            Version = version;
            IsFlexibleVersion = version >= 5;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(15);
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

        internal override int GetSize() => (Version >= 1 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + _groupsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeGroupsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeGroupsResponse(version);
            if (instance.Version >= 1)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.GroupsCollection = await Array<DescribedGroup>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribedGroup.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeGroupsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 1)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _groupsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public DescribeGroupsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Array<DescribedGroup> _groupsCollection = Array.Empty<DescribedGroup>();
        /// <summary>
        /// <para>Each described group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DescribedGroup> GroupsCollection
        {
            get => _groupsCollection;
            private set
            {
                _groupsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each described group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeGroupsResponse WithGroupsCollection(params Func<DescribedGroup, DescribedGroup>[] createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new DescribedGroup(Version))).ToArray();
            return this;
        }

        public delegate DescribedGroup CreateDescribedGroup(DescribedGroup field);
        /// <summary>
        /// <para>Each described group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeGroupsResponse WithGroupsCollection(IEnumerable<CreateDescribedGroup> createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new DescribedGroup(Version))).ToArray();
            return this;
        }

        public class DescribedGroup : ISerialize
        {
            internal DescribedGroup(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 5;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _groupId.GetSize(IsFlexibleVersion) + _groupState.GetSize(IsFlexibleVersion) + _protocolType.GetSize(IsFlexibleVersion) + _protocolData.GetSize(IsFlexibleVersion) + _membersCollection.GetSize(IsFlexibleVersion) + (Version >= 3 ? _authorizedOperations.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribedGroup> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribedGroup(version);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.GroupState = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ProtocolType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ProtocolData = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.MembersCollection = await Array<DescribedGroupMember>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribedGroupMember.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.AuthorizedOperations = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribedGroup is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _groupState.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _protocolType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _protocolData.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _membersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _authorizedOperations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The describe error, or 0 if there was no error.</para>
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
            /// <para>The describe error, or 0 if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private String _groupId = String.Default;
            /// <summary>
            /// <para>The group ID string.</para>
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
            /// <para>The group ID string.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithGroupId(String groupId)
            {
                GroupId = groupId;
                return this;
            }

            private String _groupState = String.Default;
            /// <summary>
            /// <para>The group state string, or the empty string.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String GroupState
            {
                get => _groupState;
                private set
                {
                    _groupState = value;
                }
            }

            /// <summary>
            /// <para>The group state string, or the empty string.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithGroupState(String groupState)
            {
                GroupState = groupState;
                return this;
            }

            private String _protocolType = String.Default;
            /// <summary>
            /// <para>The group protocol type, or the empty string.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String ProtocolType
            {
                get => _protocolType;
                private set
                {
                    _protocolType = value;
                }
            }

            /// <summary>
            /// <para>The group protocol type, or the empty string.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithProtocolType(String protocolType)
            {
                ProtocolType = protocolType;
                return this;
            }

            private String _protocolData = String.Default;
            /// <summary>
            /// <para>The group protocol data, or the empty string.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String ProtocolData
            {
                get => _protocolData;
                private set
                {
                    _protocolData = value;
                }
            }

            /// <summary>
            /// <para>The group protocol data, or the empty string.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithProtocolData(String protocolData)
            {
                ProtocolData = protocolData;
                return this;
            }

            private Array<DescribedGroupMember> _membersCollection = Array.Empty<DescribedGroupMember>();
            /// <summary>
            /// <para>The group members.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<DescribedGroupMember> MembersCollection
            {
                get => _membersCollection;
                private set
                {
                    _membersCollection = value;
                }
            }

            /// <summary>
            /// <para>The group members.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithMembersCollection(params Func<DescribedGroupMember, DescribedGroupMember>[] createFields)
            {
                MembersCollection = createFields.Select(createField => createField(new DescribedGroupMember(Version))).ToArray();
                return this;
            }

            public delegate DescribedGroupMember CreateDescribedGroupMember(DescribedGroupMember field);
            /// <summary>
            /// <para>The group members.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithMembersCollection(IEnumerable<CreateDescribedGroupMember> createFields)
            {
                MembersCollection = createFields.Select(createField => createField(new DescribedGroupMember(Version))).ToArray();
                return this;
            }

            public class DescribedGroupMember : ISerialize
            {
                internal DescribedGroupMember(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 5;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _memberId.GetSize(IsFlexibleVersion) + (Version >= 4 ? _groupInstanceId.GetSize(IsFlexibleVersion) : 0) + _clientId.GetSize(IsFlexibleVersion) + _clientHost.GetSize(IsFlexibleVersion) + _memberMetadata.GetSize(IsFlexibleVersion) + _memberAssignment.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<DescribedGroupMember> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new DescribedGroupMember(version);
                    instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 4)
                        instance.GroupInstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ClientId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ClientHost = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.MemberMetadata = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.MemberAssignment = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribedGroupMember is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 4)
                        await _groupInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _clientId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _clientHost.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _memberMetadata.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _memberAssignment.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
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
                public DescribedGroupMember WithMemberId(String memberId)
                {
                    MemberId = memberId;
                    return this;
                }

                private NullableString _groupInstanceId = new NullableString(null);
                /// <summary>
                /// <para>The unique identifier of the consumer instance provided by end user.</para>
                /// <para>Versions: 4+</para>
                /// <para>Default: null</para>
                /// </summary>
                public String? GroupInstanceId
                {
                    get => _groupInstanceId;
                    private set
                    {
                        if (Version >= 4 == false && value == null)
                            throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 4+");
                        _groupInstanceId = value;
                    }
                }

                /// <summary>
                /// <para>The unique identifier of the consumer instance provided by end user.</para>
                /// <para>Versions: 4+</para>
                /// <para>Default: null</para>
                /// </summary>
                public DescribedGroupMember WithGroupInstanceId(String? groupInstanceId)
                {
                    GroupInstanceId = groupInstanceId;
                    return this;
                }

                private String _clientId = String.Default;
                /// <summary>
                /// <para>The client ID used in the member's latest join group request.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public String ClientId
                {
                    get => _clientId;
                    private set
                    {
                        _clientId = value;
                    }
                }

                /// <summary>
                /// <para>The client ID used in the member's latest join group request.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribedGroupMember WithClientId(String clientId)
                {
                    ClientId = clientId;
                    return this;
                }

                private String _clientHost = String.Default;
                /// <summary>
                /// <para>The client host.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public String ClientHost
                {
                    get => _clientHost;
                    private set
                    {
                        _clientHost = value;
                    }
                }

                /// <summary>
                /// <para>The client host.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribedGroupMember WithClientHost(String clientHost)
                {
                    ClientHost = clientHost;
                    return this;
                }

                private Bytes _memberMetadata = Bytes.Default;
                /// <summary>
                /// <para>The metadata corresponding to the current group protocol in use.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Bytes MemberMetadata
                {
                    get => _memberMetadata;
                    private set
                    {
                        _memberMetadata = value;
                    }
                }

                /// <summary>
                /// <para>The metadata corresponding to the current group protocol in use.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribedGroupMember WithMemberMetadata(Bytes memberMetadata)
                {
                    MemberMetadata = memberMetadata;
                    return this;
                }

                private Bytes _memberAssignment = Bytes.Default;
                /// <summary>
                /// <para>The current assignment provided by the group leader.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Bytes MemberAssignment
                {
                    get => _memberAssignment;
                    private set
                    {
                        _memberAssignment = value;
                    }
                }

                /// <summary>
                /// <para>The current assignment provided by the group leader.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribedGroupMember WithMemberAssignment(Bytes memberAssignment)
                {
                    MemberAssignment = memberAssignment;
                    return this;
                }
            }

            private Int32 _authorizedOperations = new Int32(-2147483648);
            /// <summary>
            /// <para>32-bit bitfield to represent authorized operations for this group.</para>
            /// <para>Versions: 3+</para>
            /// <para>Default: -2147483648</para>
            /// </summary>
            public Int32 AuthorizedOperations
            {
                get => _authorizedOperations;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"AuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _authorizedOperations = value;
                }
            }

            /// <summary>
            /// <para>32-bit bitfield to represent authorized operations for this group.</para>
            /// <para>Versions: 3+</para>
            /// <para>Default: -2147483648</para>
            /// </summary>
            public DescribedGroup WithAuthorizedOperations(Int32 authorizedOperations)
            {
                AuthorizedOperations = authorizedOperations;
                return this;
            }
        }
    }
}
