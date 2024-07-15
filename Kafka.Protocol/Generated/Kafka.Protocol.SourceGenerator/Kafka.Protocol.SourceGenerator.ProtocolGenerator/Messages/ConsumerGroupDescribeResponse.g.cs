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
    public class ConsumerGroupDescribeResponse : Message
    {
        public ConsumerGroupDescribeResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ConsumerGroupDescribeResponse does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(69);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _groupsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ConsumerGroupDescribeResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ConsumerGroupDescribeResponse(version);
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
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ConsumerGroupDescribeResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
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
        public ConsumerGroupDescribeResponse WithThrottleTimeMs(Int32 throttleTimeMs)
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
        public ConsumerGroupDescribeResponse WithGroupsCollection(params Func<DescribedGroup, DescribedGroup>[] createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new DescribedGroup(Version))).ToArray();
            return this;
        }

        public delegate DescribedGroup CreateDescribedGroup(DescribedGroup field);
        /// <summary>
        /// <para>Each described group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ConsumerGroupDescribeResponse WithGroupsCollection(IEnumerable<CreateDescribedGroup> createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new DescribedGroup(Version))).ToArray();
            return this;
        }

        public class DescribedGroup : ISerialize
        {
            internal DescribedGroup(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = true;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _groupId.GetSize(IsFlexibleVersion) + _groupState.GetSize(IsFlexibleVersion) + _groupEpoch.GetSize(IsFlexibleVersion) + _assignmentEpoch.GetSize(IsFlexibleVersion) + _assignorName.GetSize(IsFlexibleVersion) + _membersCollection.GetSize(IsFlexibleVersion) + _authorizedOperations.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribedGroup> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribedGroup(version);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.GroupState = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.GroupEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.AssignmentEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.AssignorName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.MembersCollection = await Array<Member>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Member.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
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
                await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _groupState.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _groupEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _assignmentEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _assignorName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _membersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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

            private NullableString _errorMessage = new NullableString(null);
            /// <summary>
            /// <para>The top-level error message, or null if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? ErrorMessage
            {
                get => _errorMessage;
                private set
                {
                    _errorMessage = value;
                }
            }

            /// <summary>
            /// <para>The top-level error message, or null if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public DescribedGroup WithErrorMessage(String? errorMessage)
            {
                ErrorMessage = errorMessage;
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

            private Int32 _groupEpoch = Int32.Default;
            /// <summary>
            /// <para>The group epoch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 GroupEpoch
            {
                get => _groupEpoch;
                private set
                {
                    _groupEpoch = value;
                }
            }

            /// <summary>
            /// <para>The group epoch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithGroupEpoch(Int32 groupEpoch)
            {
                GroupEpoch = groupEpoch;
                return this;
            }

            private Int32 _assignmentEpoch = Int32.Default;
            /// <summary>
            /// <para>The assignment epoch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 AssignmentEpoch
            {
                get => _assignmentEpoch;
                private set
                {
                    _assignmentEpoch = value;
                }
            }

            /// <summary>
            /// <para>The assignment epoch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithAssignmentEpoch(Int32 assignmentEpoch)
            {
                AssignmentEpoch = assignmentEpoch;
                return this;
            }

            private String _assignorName = String.Default;
            /// <summary>
            /// <para>The selected assignor.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String AssignorName
            {
                get => _assignorName;
                private set
                {
                    _assignorName = value;
                }
            }

            /// <summary>
            /// <para>The selected assignor.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithAssignorName(String assignorName)
            {
                AssignorName = assignorName;
                return this;
            }

            private Array<Member> _membersCollection = Array.Empty<Member>();
            /// <summary>
            /// <para>The members.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<Member> MembersCollection
            {
                get => _membersCollection;
                private set
                {
                    _membersCollection = value;
                }
            }

            /// <summary>
            /// <para>The members.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithMembersCollection(params Func<Member, Member>[] createFields)
            {
                MembersCollection = createFields.Select(createField => createField(new Member(Version))).ToArray();
                return this;
            }

            public delegate Member CreateMember(Member field);
            /// <summary>
            /// <para>The members.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedGroup WithMembersCollection(IEnumerable<CreateMember> createFields)
            {
                MembersCollection = createFields.Select(createField => createField(new Member(Version))).ToArray();
                return this;
            }

            public class Member : ISerialize
            {
                internal Member(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = true;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _memberId.GetSize(IsFlexibleVersion) + _instanceId.GetSize(IsFlexibleVersion) + _rackId.GetSize(IsFlexibleVersion) + _memberEpoch.GetSize(IsFlexibleVersion) + _clientId.GetSize(IsFlexibleVersion) + _clientHost.GetSize(IsFlexibleVersion) + _subscribedTopicNamesCollection.GetSize(IsFlexibleVersion) + _subscribedTopicRegex.GetSize(IsFlexibleVersion) + _assignment.GetSize(IsFlexibleVersion) + _targetAssignment.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<Member> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new Member(version);
                    instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.InstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.RackId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.MemberEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ClientId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ClientHost = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.SubscribedTopicNamesCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.SubscribedTopicRegex = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Assignment_ = await Assignment.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                    instance.TargetAssignment = await Assignment.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for Member is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _instanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _rackId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _memberEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _clientId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _clientHost.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _subscribedTopicNamesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _subscribedTopicRegex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _assignment.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _targetAssignment.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
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
                public Member WithMemberId(String memberId)
                {
                    MemberId = memberId;
                    return this;
                }

                private NullableString _instanceId = new NullableString(null);
                /// <summary>
                /// <para>The member instance ID.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public String? InstanceId
                {
                    get => _instanceId;
                    private set
                    {
                        _instanceId = value;
                    }
                }

                /// <summary>
                /// <para>The member instance ID.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Member WithInstanceId(String? instanceId)
                {
                    InstanceId = instanceId;
                    return this;
                }

                private NullableString _rackId = new NullableString(null);
                /// <summary>
                /// <para>The member rack ID.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public String? RackId
                {
                    get => _rackId;
                    private set
                    {
                        _rackId = value;
                    }
                }

                /// <summary>
                /// <para>The member rack ID.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Member WithRackId(String? rackId)
                {
                    RackId = rackId;
                    return this;
                }

                private Int32 _memberEpoch = Int32.Default;
                /// <summary>
                /// <para>The current member epoch.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 MemberEpoch
                {
                    get => _memberEpoch;
                    private set
                    {
                        _memberEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The current member epoch.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithMemberEpoch(Int32 memberEpoch)
                {
                    MemberEpoch = memberEpoch;
                    return this;
                }

                private String _clientId = String.Default;
                /// <summary>
                /// <para>The client ID.</para>
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
                /// <para>The client ID.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithClientId(String clientId)
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
                public Member WithClientHost(String clientHost)
                {
                    ClientHost = clientHost;
                    return this;
                }

                private Array<String> _subscribedTopicNamesCollection = Array.Empty<String>();
                /// <summary>
                /// <para>The subscribed topic names.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<String> SubscribedTopicNamesCollection
                {
                    get => _subscribedTopicNamesCollection;
                    private set
                    {
                        _subscribedTopicNamesCollection = value;
                    }
                }

                /// <summary>
                /// <para>The subscribed topic names.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithSubscribedTopicNamesCollection(Array<String> subscribedTopicNamesCollection)
                {
                    SubscribedTopicNamesCollection = subscribedTopicNamesCollection;
                    return this;
                }

                private NullableString _subscribedTopicRegex = new NullableString(null);
                /// <summary>
                /// <para>the subscribed topic regex otherwise or null of not provided.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public String? SubscribedTopicRegex
                {
                    get => _subscribedTopicRegex;
                    private set
                    {
                        _subscribedTopicRegex = value;
                    }
                }

                /// <summary>
                /// <para>the subscribed topic regex otherwise or null of not provided.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Member WithSubscribedTopicRegex(String? subscribedTopicRegex)
                {
                    SubscribedTopicRegex = subscribedTopicRegex;
                    return this;
                }

                private Assignment _assignment = default !;
                /// <summary>
                /// <para>The current assignment.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Assignment Assignment_
                {
                    get => _assignment;
                    private set
                    {
                        _assignment = value;
                    }
                }

                /// <summary>
                /// <para>The current assignment.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithAssignment_(Assignment assignment)
                {
                    Assignment_ = assignment;
                    return this;
                }

                private Assignment _targetAssignment = default !;
                /// <summary>
                /// <para>The target assignment.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Assignment TargetAssignment
                {
                    get => _targetAssignment;
                    private set
                    {
                        _targetAssignment = value;
                    }
                }

                /// <summary>
                /// <para>The target assignment.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithTargetAssignment(Assignment targetAssignment)
                {
                    TargetAssignment = targetAssignment;
                    return this;
                }
            }

            private Int32 _authorizedOperations = new Int32(-2147483648);
            /// <summary>
            /// <para>32-bit bitfield to represent authorized operations for this group.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: -2147483648</para>
            /// </summary>
            public Int32 AuthorizedOperations
            {
                get => _authorizedOperations;
                private set
                {
                    _authorizedOperations = value;
                }
            }

            /// <summary>
            /// <para>32-bit bitfield to represent authorized operations for this group.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: -2147483648</para>
            /// </summary>
            public DescribedGroup WithAuthorizedOperations(Int32 authorizedOperations)
            {
                AuthorizedOperations = authorizedOperations;
                return this;
            }
        }

        public class TopicPartitions : ISerialize
        {
            internal TopicPartitions(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = true;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _topicId.GetSize(IsFlexibleVersion) + _topicName.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicPartitions> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicPartitions(version);
                instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicPartitions is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The topic ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Uuid TopicId
            {
                get => _topicId;
                private set
                {
                    _topicId = value;
                }
            }

            /// <summary>
            /// <para>The topic ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartitions WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String TopicName
            {
                get => _topicName;
                private set
                {
                    _topicName = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartitions WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<Int32> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartitions WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        public class Assignment : ISerialize
        {
            internal Assignment(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = true;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _topicPartitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Assignment> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Assignment(version);
                instance.TopicPartitionsCollection = await Array<TopicPartitions>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicPartitions.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Assignment is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicPartitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Array<TopicPartitions> _topicPartitionsCollection = Array.Empty<TopicPartitions>();
            /// <summary>
            /// <para>The assigned topic-partitions to the member.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TopicPartitions> TopicPartitionsCollection
            {
                get => _topicPartitionsCollection;
                private set
                {
                    _topicPartitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The assigned topic-partitions to the member.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Assignment WithTopicPartitionsCollection(Array<TopicPartitions> topicPartitionsCollection)
            {
                TopicPartitionsCollection = topicPartitionsCollection;
                return this;
            }
        }
    }
}
