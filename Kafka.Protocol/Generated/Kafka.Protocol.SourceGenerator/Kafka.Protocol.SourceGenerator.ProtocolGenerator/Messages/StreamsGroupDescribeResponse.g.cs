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
    public class StreamsGroupDescribeResponse : Message
    {
        public StreamsGroupDescribeResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"StreamsGroupDescribeResponse does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(89);
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
        internal static async ValueTask<StreamsGroupDescribeResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new StreamsGroupDescribeResponse(version);
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
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for StreamsGroupDescribeResponse is unknown");
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
        public StreamsGroupDescribeResponse WithThrottleTimeMs(Int32 throttleTimeMs)
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
        public StreamsGroupDescribeResponse WithGroupsCollection(params Func<DescribedGroup, DescribedGroup>[] createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new DescribedGroup(Version))).ToArray();
            return this;
        }

        public delegate DescribedGroup CreateDescribedGroup(DescribedGroup field);
        /// <summary>
        /// <para>Each described group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupDescribeResponse WithGroupsCollection(IEnumerable<CreateDescribedGroup> createFields)
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
            internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _groupId.GetSize(IsFlexibleVersion) + _groupState.GetSize(IsFlexibleVersion) + _groupEpoch.GetSize(IsFlexibleVersion) + _assignmentEpoch.GetSize(IsFlexibleVersion) + _topology.GetSize(IsFlexibleVersion) + _membersCollection.GetSize(IsFlexibleVersion) + _authorizedOperations.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribedGroup> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribedGroup(version);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.GroupState = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.GroupEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.AssignmentEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Topology_ = await Nullable<Topology>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Topology.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
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
                await _topology.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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

            private Nullable<Topology> _topology = new Nullable<Topology>(null);
            /// <summary>
            /// <para>The topology metadata currently initialized for the streams application. Can be null in case of a describe error.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public Topology? Topology_
            {
                get => _topology;
                private set
                {
                    _topology = value;
                }
            }

            /// <summary>
            /// <para>The topology metadata currently initialized for the streams application. Can be null in case of a describe error.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public DescribedGroup WithTopology_(Func<Topology?, Topology?> createField)
            {
                Topology_ = createField(new Topology(Version));
                return this;
            }

            public class Topology : ISerialize
            {
                internal Topology(Int16 version)
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
                internal int GetSize(bool _) => _epoch.GetSize(IsFlexibleVersion) + _subtopologiesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<Topology> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new Topology(version);
                    instance.Epoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.SubtopologiesCollection = await NullableArray<Subtopology>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Subtopology.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for Topology is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _epoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _subtopologiesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _epoch = Int32.Default;
                /// <summary>
                /// <para>The epoch of the currently initialized topology for this group.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 Epoch
                {
                    get => _epoch;
                    private set
                    {
                        _epoch = value;
                    }
                }

                /// <summary>
                /// <para>The epoch of the currently initialized topology for this group.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Topology WithEpoch(Int32 epoch)
                {
                    Epoch = epoch;
                    return this;
                }

                private NullableArray<Subtopology> _subtopologiesCollection = new NullableArray<Subtopology>(null);
                /// <summary>
                /// <para>The subtopologies of the streams application. This contains the configured subtopologies, where the number of partitions are set and any regular expressions are resolved to actual topics. Null if the group is uninitialized, source topics are missing or incorrectly partitioned.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Array<Subtopology>? SubtopologiesCollection
                {
                    get => _subtopologiesCollection;
                    private set
                    {
                        _subtopologiesCollection = value;
                    }
                }

                /// <summary>
                /// <para>The subtopologies of the streams application. This contains the configured subtopologies, where the number of partitions are set and any regular expressions are resolved to actual topics. Null if the group is uninitialized, source topics are missing or incorrectly partitioned.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Topology WithSubtopologiesCollection(params Func<Subtopology, Subtopology>[] createFields)
                {
                    SubtopologiesCollection = createFields.Select(createField => createField(new Subtopology(Version))).ToArray();
                    return this;
                }

                public delegate Subtopology CreateSubtopology(Subtopology field);
                /// <summary>
                /// <para>The subtopologies of the streams application. This contains the configured subtopologies, where the number of partitions are set and any regular expressions are resolved to actual topics. Null if the group is uninitialized, source topics are missing or incorrectly partitioned.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Topology WithSubtopologiesCollection(IEnumerable<CreateSubtopology> createFields)
                {
                    SubtopologiesCollection = createFields.Select(createField => createField(new Subtopology(Version))).ToArray();
                    return this;
                }

                public class Subtopology : ISerialize
                {
                    internal Subtopology(Int16 version)
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
                    internal int GetSize(bool _) => _subtopologyId.GetSize(IsFlexibleVersion) + _sourceTopicsCollection.GetSize(IsFlexibleVersion) + _repartitionSinkTopicsCollection.GetSize(IsFlexibleVersion) + _stateChangelogTopicsCollection.GetSize(IsFlexibleVersion) + _repartitionSourceTopicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<Subtopology> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new Subtopology(version);
                        instance.SubtopologyId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.SourceTopicsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                        instance.RepartitionSinkTopicsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                        instance.StateChangelogTopicsCollection = await Array<TopicInfo>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicInfo.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                        instance.RepartitionSourceTopicsCollection = await Array<TopicInfo>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicInfo.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for Subtopology is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        await _subtopologyId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _sourceTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _repartitionSinkTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _stateChangelogTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _repartitionSourceTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private String _subtopologyId = String.Default;
                    /// <summary>
                    /// <para>String to uniquely identify the subtopology.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public String SubtopologyId
                    {
                        get => _subtopologyId;
                        private set
                        {
                            _subtopologyId = value;
                        }
                    }

                    /// <summary>
                    /// <para>String to uniquely identify the subtopology.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Subtopology WithSubtopologyId(String subtopologyId)
                    {
                        SubtopologyId = subtopologyId;
                        return this;
                    }

                    private Array<String> _sourceTopicsCollection = Array.Empty<String>();
                    /// <summary>
                    /// <para>The topics the subtopology reads from.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Array<String> SourceTopicsCollection
                    {
                        get => _sourceTopicsCollection;
                        private set
                        {
                            _sourceTopicsCollection = value;
                        }
                    }

                    /// <summary>
                    /// <para>The topics the subtopology reads from.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Subtopology WithSourceTopicsCollection(Array<String> sourceTopicsCollection)
                    {
                        SourceTopicsCollection = sourceTopicsCollection;
                        return this;
                    }

                    private Array<String> _repartitionSinkTopicsCollection = Array.Empty<String>();
                    /// <summary>
                    /// <para>The repartition topics the subtopology writes to.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Array<String> RepartitionSinkTopicsCollection
                    {
                        get => _repartitionSinkTopicsCollection;
                        private set
                        {
                            _repartitionSinkTopicsCollection = value;
                        }
                    }

                    /// <summary>
                    /// <para>The repartition topics the subtopology writes to.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Subtopology WithRepartitionSinkTopicsCollection(Array<String> repartitionSinkTopicsCollection)
                    {
                        RepartitionSinkTopicsCollection = repartitionSinkTopicsCollection;
                        return this;
                    }

                    private Array<TopicInfo> _stateChangelogTopicsCollection = Array.Empty<TopicInfo>();
                    /// <summary>
                    /// <para>The set of state changelog topics associated with this subtopology. Created automatically.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Array<TopicInfo> StateChangelogTopicsCollection
                    {
                        get => _stateChangelogTopicsCollection;
                        private set
                        {
                            _stateChangelogTopicsCollection = value;
                        }
                    }

                    /// <summary>
                    /// <para>The set of state changelog topics associated with this subtopology. Created automatically.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Subtopology WithStateChangelogTopicsCollection(Array<TopicInfo> stateChangelogTopicsCollection)
                    {
                        StateChangelogTopicsCollection = stateChangelogTopicsCollection;
                        return this;
                    }

                    private Array<TopicInfo> _repartitionSourceTopicsCollection = Array.Empty<TopicInfo>();
                    /// <summary>
                    /// <para>The set of source topics that are internally created repartition topics. Created automatically.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Array<TopicInfo> RepartitionSourceTopicsCollection
                    {
                        get => _repartitionSourceTopicsCollection;
                        private set
                        {
                            _repartitionSourceTopicsCollection = value;
                        }
                    }

                    /// <summary>
                    /// <para>The set of source topics that are internally created repartition topics. Created automatically.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Subtopology WithRepartitionSourceTopicsCollection(Array<TopicInfo> repartitionSourceTopicsCollection)
                    {
                        RepartitionSourceTopicsCollection = repartitionSourceTopicsCollection;
                        return this;
                    }
                }
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
                internal int GetSize(bool _) => _memberId.GetSize(IsFlexibleVersion) + _memberEpoch.GetSize(IsFlexibleVersion) + _instanceId.GetSize(IsFlexibleVersion) + _rackId.GetSize(IsFlexibleVersion) + _clientId.GetSize(IsFlexibleVersion) + _clientHost.GetSize(IsFlexibleVersion) + _topologyEpoch.GetSize(IsFlexibleVersion) + _processId.GetSize(IsFlexibleVersion) + _userEndpoint.GetSize(IsFlexibleVersion) + _clientTagsCollection.GetSize(IsFlexibleVersion) + _taskOffsetsCollection.GetSize(IsFlexibleVersion) + _taskEndOffsetsCollection.GetSize(IsFlexibleVersion) + _assignment.GetSize(IsFlexibleVersion) + _targetAssignment.GetSize(IsFlexibleVersion) + _isClassic.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<Member> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new Member(version);
                    instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.MemberEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.InstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.RackId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ClientId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ClientHost = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.TopologyEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ProcessId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.UserEndpoint = await Nullable<Endpoint>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Endpoint.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.ClientTagsCollection = await Array<KeyValue>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => KeyValue.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.TaskOffsetsCollection = await Array<TaskOffset>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskOffset.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.TaskEndOffsetsCollection = await Array<TaskOffset>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskOffset.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.Assignment_ = await Assignment.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                    instance.TargetAssignment = await Assignment.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                    instance.IsClassic = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                    await _memberEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _instanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _rackId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _clientId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _clientHost.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _topologyEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _processId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _userEndpoint.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _clientTagsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _taskOffsetsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _taskEndOffsetsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _assignment.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _targetAssignment.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _isClassic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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

                private Int32 _memberEpoch = Int32.Default;
                /// <summary>
                /// <para>The member epoch.</para>
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
                /// <para>The member epoch.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithMemberEpoch(Int32 memberEpoch)
                {
                    MemberEpoch = memberEpoch;
                    return this;
                }

                private NullableString _instanceId = new NullableString(null);
                /// <summary>
                /// <para>The member instance ID for static membership.</para>
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
                /// <para>The member instance ID for static membership.</para>
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
                /// <para>The rack ID.</para>
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
                /// <para>The rack ID.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Member WithRackId(String? rackId)
                {
                    RackId = rackId;
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

                private Int32 _topologyEpoch = Int32.Default;
                /// <summary>
                /// <para>The epoch of the topology on the client.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 TopologyEpoch
                {
                    get => _topologyEpoch;
                    private set
                    {
                        _topologyEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The epoch of the topology on the client.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithTopologyEpoch(Int32 topologyEpoch)
                {
                    TopologyEpoch = topologyEpoch;
                    return this;
                }

                private String _processId = String.Default;
                /// <summary>
                /// <para>Identity of the streams instance that may have multiple clients. </para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public String ProcessId
                {
                    get => _processId;
                    private set
                    {
                        _processId = value;
                    }
                }

                /// <summary>
                /// <para>Identity of the streams instance that may have multiple clients. </para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithProcessId(String processId)
                {
                    ProcessId = processId;
                    return this;
                }

                private Nullable<Endpoint> _userEndpoint = new Nullable<Endpoint>(null);
                /// <summary>
                /// <para>User-defined endpoint for Interactive Queries. Null if not defined for this client.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Endpoint? UserEndpoint
                {
                    get => _userEndpoint;
                    private set
                    {
                        _userEndpoint = value;
                    }
                }

                /// <summary>
                /// <para>User-defined endpoint for Interactive Queries. Null if not defined for this client.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Member WithUserEndpoint(Endpoint? userEndpoint)
                {
                    UserEndpoint = userEndpoint;
                    return this;
                }

                private Array<KeyValue> _clientTagsCollection = Array.Empty<KeyValue>();
                /// <summary>
                /// <para>Used for rack-aware assignment algorithm.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<KeyValue> ClientTagsCollection
                {
                    get => _clientTagsCollection;
                    private set
                    {
                        _clientTagsCollection = value;
                    }
                }

                /// <summary>
                /// <para>Used for rack-aware assignment algorithm.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithClientTagsCollection(Array<KeyValue> clientTagsCollection)
                {
                    ClientTagsCollection = clientTagsCollection;
                    return this;
                }

                private Array<TaskOffset> _taskOffsetsCollection = Array.Empty<TaskOffset>();
                /// <summary>
                /// <para>Cumulative changelog offsets for tasks.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<TaskOffset> TaskOffsetsCollection
                {
                    get => _taskOffsetsCollection;
                    private set
                    {
                        _taskOffsetsCollection = value;
                    }
                }

                /// <summary>
                /// <para>Cumulative changelog offsets for tasks.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithTaskOffsetsCollection(Array<TaskOffset> taskOffsetsCollection)
                {
                    TaskOffsetsCollection = taskOffsetsCollection;
                    return this;
                }

                private Array<TaskOffset> _taskEndOffsetsCollection = Array.Empty<TaskOffset>();
                /// <summary>
                /// <para>Cumulative changelog end offsets for tasks.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<TaskOffset> TaskEndOffsetsCollection
                {
                    get => _taskEndOffsetsCollection;
                    private set
                    {
                        _taskEndOffsetsCollection = value;
                    }
                }

                /// <summary>
                /// <para>Cumulative changelog end offsets for tasks.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithTaskEndOffsetsCollection(Array<TaskOffset> taskEndOffsetsCollection)
                {
                    TaskEndOffsetsCollection = taskEndOffsetsCollection;
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

                private Boolean _isClassic = Boolean.Default;
                /// <summary>
                /// <para>True for classic members that have not been upgraded yet.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Boolean IsClassic
                {
                    get => _isClassic;
                    private set
                    {
                        _isClassic = value;
                    }
                }

                /// <summary>
                /// <para>True for classic members that have not been upgraded yet.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Member WithIsClassic(Boolean isClassic)
                {
                    IsClassic = isClassic;
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

        public class Endpoint : ISerialize
        {
            internal Endpoint(Int16 version)
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
            internal int GetSize(bool _) => _host.GetSize(IsFlexibleVersion) + _port.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Endpoint> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Endpoint(version);
                instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Port = await UInt16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Endpoint is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>host of the endpoint</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Host
            {
                get => _host;
                private set
                {
                    _host = value;
                }
            }

            /// <summary>
            /// <para>host of the endpoint</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Endpoint WithHost(String host)
            {
                Host = host;
                return this;
            }

            private UInt16 _port = UInt16.Default;
            /// <summary>
            /// <para>port of the endpoint</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public UInt16 Port
            {
                get => _port;
                private set
                {
                    _port = value;
                }
            }

            /// <summary>
            /// <para>port of the endpoint</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Endpoint WithPort(UInt16 port)
            {
                Port = port;
                return this;
            }
        }

        public class TaskOffset : ISerialize
        {
            internal TaskOffset(Int16 version)
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
            internal int GetSize(bool _) => _subtopologyId.GetSize(IsFlexibleVersion) + _partition.GetSize(IsFlexibleVersion) + _offset.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TaskOffset> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TaskOffset(version);
                instance.SubtopologyId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Partition = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Offset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TaskOffset is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _subtopologyId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partition.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _offset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _subtopologyId = String.Default;
            /// <summary>
            /// <para>The subtopology identifier.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String SubtopologyId
            {
                get => _subtopologyId;
                private set
                {
                    _subtopologyId = value;
                }
            }

            /// <summary>
            /// <para>The subtopology identifier.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TaskOffset WithSubtopologyId(String subtopologyId)
            {
                SubtopologyId = subtopologyId;
                return this;
            }

            private Int32 _partition = Int32.Default;
            /// <summary>
            /// <para>The partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 Partition
            {
                get => _partition;
                private set
                {
                    _partition = value;
                }
            }

            /// <summary>
            /// <para>The partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TaskOffset WithPartition(Int32 partition)
            {
                Partition = partition;
                return this;
            }

            private Int64 _offset = Int64.Default;
            /// <summary>
            /// <para>The offset.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int64 Offset
            {
                get => _offset;
                private set
                {
                    _offset = value;
                }
            }

            /// <summary>
            /// <para>The offset.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TaskOffset WithOffset(Int64 offset)
            {
                Offset = offset;
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
            internal int GetSize(bool _) => _activeTasksCollection.GetSize(IsFlexibleVersion) + _standbyTasksCollection.GetSize(IsFlexibleVersion) + _warmupTasksCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Assignment> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Assignment(version);
                instance.ActiveTasksCollection = await Array<TaskIds>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskIds.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.StandbyTasksCollection = await Array<TaskIds>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskIds.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.WarmupTasksCollection = await Array<TaskIds>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskIds.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
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
                await _activeTasksCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _standbyTasksCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _warmupTasksCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Array<TaskIds> _activeTasksCollection = Array.Empty<TaskIds>();
            /// <summary>
            /// <para>Active tasks for this client.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TaskIds> ActiveTasksCollection
            {
                get => _activeTasksCollection;
                private set
                {
                    _activeTasksCollection = value;
                }
            }

            /// <summary>
            /// <para>Active tasks for this client.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Assignment WithActiveTasksCollection(Array<TaskIds> activeTasksCollection)
            {
                ActiveTasksCollection = activeTasksCollection;
                return this;
            }

            private Array<TaskIds> _standbyTasksCollection = Array.Empty<TaskIds>();
            /// <summary>
            /// <para>Standby tasks for this client.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TaskIds> StandbyTasksCollection
            {
                get => _standbyTasksCollection;
                private set
                {
                    _standbyTasksCollection = value;
                }
            }

            /// <summary>
            /// <para>Standby tasks for this client.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Assignment WithStandbyTasksCollection(Array<TaskIds> standbyTasksCollection)
            {
                StandbyTasksCollection = standbyTasksCollection;
                return this;
            }

            private Array<TaskIds> _warmupTasksCollection = Array.Empty<TaskIds>();
            /// <summary>
            /// <para>Warm-up tasks for this client. </para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TaskIds> WarmupTasksCollection
            {
                get => _warmupTasksCollection;
                private set
                {
                    _warmupTasksCollection = value;
                }
            }

            /// <summary>
            /// <para>Warm-up tasks for this client. </para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Assignment WithWarmupTasksCollection(Array<TaskIds> warmupTasksCollection)
            {
                WarmupTasksCollection = warmupTasksCollection;
                return this;
            }
        }

        public class TaskIds : ISerialize
        {
            internal TaskIds(Int16 version)
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
            internal int GetSize(bool _) => _subtopologyId.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TaskIds> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TaskIds(version);
                instance.SubtopologyId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TaskIds is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _subtopologyId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _subtopologyId = String.Default;
            /// <summary>
            /// <para>The subtopology identifier.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String SubtopologyId
            {
                get => _subtopologyId;
                private set
                {
                    _subtopologyId = value;
                }
            }

            /// <summary>
            /// <para>The subtopology identifier.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TaskIds WithSubtopologyId(String subtopologyId)
            {
                SubtopologyId = subtopologyId;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partitions of the input topics processed by this member.</para>
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
            /// <para>The partitions of the input topics processed by this member.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TaskIds WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        public class KeyValue : ISerialize
        {
            internal KeyValue(Int16 version)
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
            internal int GetSize(bool _) => _key.GetSize(IsFlexibleVersion) + _value.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<KeyValue> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new KeyValue(version);
                instance.Key = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Value = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for KeyValue is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _key.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _value.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _key = String.Default;
            /// <summary>
            /// <para>key of the config</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Key
            {
                get => _key;
                private set
                {
                    _key = value;
                }
            }

            /// <summary>
            /// <para>key of the config</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public KeyValue WithKey(String key)
            {
                Key = key;
                return this;
            }

            private String _value = String.Default;
            /// <summary>
            /// <para>value of the config</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Value
            {
                get => _value;
                private set
                {
                    _value = value;
                }
            }

            /// <summary>
            /// <para>value of the config</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public KeyValue WithValue(String value)
            {
                Value = value;
                return this;
            }
        }

        public class TopicInfo : ISerialize
        {
            internal TopicInfo(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitions.GetSize(IsFlexibleVersion) + _replicationFactor.GetSize(IsFlexibleVersion) + _topicConfigsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicInfo> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicInfo(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Partitions = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ReplicationFactor = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicConfigsCollection = await Array<KeyValue>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => KeyValue.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicInfo is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitions.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _replicationFactor.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _topicConfigsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The name of the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Name
            {
                get => _name;
                private set
                {
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The name of the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicInfo WithName(String name)
            {
                Name = name;
                return this;
            }

            private Int32 _partitions = Int32.Default;
            /// <summary>
            /// <para>The number of partitions in the topic. Can be 0 if no specific number of partitions is enforced. Always 0 for changelog topics.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 Partitions
            {
                get => _partitions;
                private set
                {
                    _partitions = value;
                }
            }

            /// <summary>
            /// <para>The number of partitions in the topic. Can be 0 if no specific number of partitions is enforced. Always 0 for changelog topics.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicInfo WithPartitions(Int32 partitions)
            {
                Partitions = partitions;
                return this;
            }

            private Int16 _replicationFactor = Int16.Default;
            /// <summary>
            /// <para>The replication factor of the topic. Can be 0 if the default replication factor should be used.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 ReplicationFactor
            {
                get => _replicationFactor;
                private set
                {
                    _replicationFactor = value;
                }
            }

            /// <summary>
            /// <para>The replication factor of the topic. Can be 0 if the default replication factor should be used.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicInfo WithReplicationFactor(Int16 replicationFactor)
            {
                ReplicationFactor = replicationFactor;
                return this;
            }

            private Array<KeyValue> _topicConfigsCollection = Array.Empty<KeyValue>();
            /// <summary>
            /// <para>Topic-level configurations as key-value pairs.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<KeyValue> TopicConfigsCollection
            {
                get => _topicConfigsCollection;
                private set
                {
                    _topicConfigsCollection = value;
                }
            }

            /// <summary>
            /// <para>Topic-level configurations as key-value pairs.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicInfo WithTopicConfigsCollection(Array<KeyValue> topicConfigsCollection)
            {
                TopicConfigsCollection = topicConfigsCollection;
                return this;
            }
        }
    }
}
