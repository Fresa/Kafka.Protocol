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
    public class StreamsGroupHeartbeatRequest : Message, IRespond<StreamsGroupHeartbeatResponse>
    {
        public StreamsGroupHeartbeatRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"StreamsGroupHeartbeatRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(88);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
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

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + _memberId.GetSize(IsFlexibleVersion) + _memberEpoch.GetSize(IsFlexibleVersion) + _endpointInformationEpoch.GetSize(IsFlexibleVersion) + _instanceId.GetSize(IsFlexibleVersion) + _rackId.GetSize(IsFlexibleVersion) + _rebalanceTimeoutMs.GetSize(IsFlexibleVersion) + _topology.GetSize(IsFlexibleVersion) + _activeTasksCollection.GetSize(IsFlexibleVersion) + _standbyTasksCollection.GetSize(IsFlexibleVersion) + _warmupTasksCollection.GetSize(IsFlexibleVersion) + _processId.GetSize(IsFlexibleVersion) + _userEndpoint.GetSize(IsFlexibleVersion) + _clientTagsCollection.GetSize(IsFlexibleVersion) + _taskOffsetsCollection.GetSize(IsFlexibleVersion) + _taskEndOffsetsCollection.GetSize(IsFlexibleVersion) + _shutdownApplication.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<StreamsGroupHeartbeatRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new StreamsGroupHeartbeatRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.EndpointInformationEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.InstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.RackId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.RebalanceTimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.Topology_ = await Nullable<Topology>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Topology.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ActiveTasksCollection = await NullableArray<TaskIds>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskIds.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.StandbyTasksCollection = await NullableArray<TaskIds>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskIds.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.WarmupTasksCollection = await NullableArray<TaskIds>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskIds.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ProcessId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.UserEndpoint = await Nullable<Endpoint>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Endpoint.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ClientTagsCollection = await NullableArray<KeyValue>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => KeyValue.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.TaskOffsetsCollection = await NullableArray<TaskOffset>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskOffset.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.TaskEndOffsetsCollection = await NullableArray<TaskOffset>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskOffset.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ShutdownApplication = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for StreamsGroupHeartbeatRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _endpointInformationEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _instanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _rackId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _rebalanceTimeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topology.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _activeTasksCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _standbyTasksCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _warmupTasksCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _processId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _userEndpoint.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _clientTagsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _taskOffsetsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _taskEndOffsetsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _shutdownApplication.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _groupId = String.Default;
        /// <summary>
        /// <para>The group identifier.</para>
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
        /// <para>The group identifier.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The member ID generated by the streams consumer. The member ID must be kept during the entire lifetime of the streams consumer process.</para>
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
        /// <para>The member ID generated by the streams consumer. The member ID must be kept during the entire lifetime of the streams consumer process.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private Int32 _memberEpoch = Int32.Default;
        /// <summary>
        /// <para>The current member epoch; 0 to join the group; -1 to leave the group; -2 to indicate that the static member will rejoin.</para>
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
        /// <para>The current member epoch; 0 to join the group; -1 to leave the group; -2 to indicate that the static member will rejoin.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithMemberEpoch(Int32 memberEpoch)
        {
            MemberEpoch = memberEpoch;
            return this;
        }

        private Int32 _endpointInformationEpoch = Int32.Default;
        /// <summary>
        /// <para>The current endpoint epoch of this client, represents the latest endpoint epoch this client received</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 EndpointInformationEpoch
        {
            get => _endpointInformationEpoch;
            private set
            {
                _endpointInformationEpoch = value;
            }
        }

        /// <summary>
        /// <para>The current endpoint epoch of this client, represents the latest endpoint epoch this client received</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithEndpointInformationEpoch(Int32 endpointInformationEpoch)
        {
            EndpointInformationEpoch = endpointInformationEpoch;
            return this;
        }

        private NullableString _instanceId = new NullableString(null);
        /// <summary>
        /// <para>null if not provided or if it didn't change since the last heartbeat; the instance ID for static membership otherwise.</para>
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
        /// <para>null if not provided or if it didn't change since the last heartbeat; the instance ID for static membership otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithInstanceId(String? instanceId)
        {
            InstanceId = instanceId;
            return this;
        }

        private NullableString _rackId = new NullableString(null);
        /// <summary>
        /// <para>null if not provided or if it didn't change since the last heartbeat; the rack ID of the member otherwise.</para>
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
        /// <para>null if not provided or if it didn't change since the last heartbeat; the rack ID of the member otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithRackId(String? rackId)
        {
            RackId = rackId;
            return this;
        }

        private Int32 _rebalanceTimeoutMs = new Int32(-1);
        /// <summary>
        /// <para>-1 if it didn't change since the last heartbeat; the maximum time in milliseconds that the coordinator will wait on the member to revoke its tasks otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int32 RebalanceTimeoutMs
        {
            get => _rebalanceTimeoutMs;
            private set
            {
                _rebalanceTimeoutMs = value;
            }
        }

        /// <summary>
        /// <para>-1 if it didn't change since the last heartbeat; the maximum time in milliseconds that the coordinator will wait on the member to revoke its tasks otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithRebalanceTimeoutMs(Int32 rebalanceTimeoutMs)
        {
            RebalanceTimeoutMs = rebalanceTimeoutMs;
            return this;
        }

        private Nullable<Topology> _topology = new Nullable<Topology>(null);
        /// <summary>
        /// <para>The topology metadata of the streams application. Used to initialize the topology of the group and to check if the topology corresponds to the topology initialized for the group. Only sent when memberEpoch = 0, must be non-empty. Null otherwise.</para>
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
        /// <para>The topology metadata of the streams application. Used to initialize the topology of the group and to check if the topology corresponds to the topology initialized for the group. Only sent when memberEpoch = 0, must be non-empty. Null otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithTopology_(Func<Topology?, Topology?> createField)
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
                instance.SubtopologiesCollection = await Array<Subtopology>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Subtopology.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
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
            /// <para>The epoch of the topology. Used to check if the topology corresponds to the topology initialized on the brokers.</para>
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
            /// <para>The epoch of the topology. Used to check if the topology corresponds to the topology initialized on the brokers.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Topology WithEpoch(Int32 epoch)
            {
                Epoch = epoch;
                return this;
            }

            private Array<Subtopology> _subtopologiesCollection = Array.Empty<Subtopology>();
            /// <summary>
            /// <para>The sub-topologies of the streams application.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<Subtopology> SubtopologiesCollection
            {
                get => _subtopologiesCollection;
                private set
                {
                    _subtopologiesCollection = value;
                }
            }

            /// <summary>
            /// <para>The sub-topologies of the streams application.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Topology WithSubtopologiesCollection(params Func<Subtopology, Subtopology>[] createFields)
            {
                SubtopologiesCollection = createFields.Select(createField => createField(new Subtopology(Version))).ToArray();
                return this;
            }

            public delegate Subtopology CreateSubtopology(Subtopology field);
            /// <summary>
            /// <para>The sub-topologies of the streams application.</para>
            /// <para>Versions: 0+</para>
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
                internal int GetSize(bool _) => _subtopologyId.GetSize(IsFlexibleVersion) + _sourceTopicsCollection.GetSize(IsFlexibleVersion) + _sourceTopicRegexCollection.GetSize(IsFlexibleVersion) + _stateChangelogTopicsCollection.GetSize(IsFlexibleVersion) + _repartitionSinkTopicsCollection.GetSize(IsFlexibleVersion) + _repartitionSourceTopicsCollection.GetSize(IsFlexibleVersion) + _copartitionGroupsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<Subtopology> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new Subtopology(version);
                    instance.SubtopologyId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.SourceTopicsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.SourceTopicRegexCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.StateChangelogTopicsCollection = await Array<TopicInfo>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicInfo.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.RepartitionSinkTopicsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.RepartitionSourceTopicsCollection = await Array<TopicInfo>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicInfo.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.CopartitionGroupsCollection = await Array<CopartitionGroup>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => CopartitionGroup.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
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
                    await _sourceTopicRegexCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _stateChangelogTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _repartitionSinkTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _repartitionSourceTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _copartitionGroupsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private String _subtopologyId = String.Default;
                /// <summary>
                /// <para>String to uniquely identify the subtopology. Deterministically generated from the topology</para>
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
                /// <para>String to uniquely identify the subtopology. Deterministically generated from the topology</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Subtopology WithSubtopologyId(String subtopologyId)
                {
                    SubtopologyId = subtopologyId;
                    return this;
                }

                private Array<String> _sourceTopicsCollection = Array.Empty<String>();
                /// <summary>
                /// <para>The topics the topology reads from.</para>
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
                /// <para>The topics the topology reads from.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Subtopology WithSourceTopicsCollection(Array<String> sourceTopicsCollection)
                {
                    SourceTopicsCollection = sourceTopicsCollection;
                    return this;
                }

                private Array<String> _sourceTopicRegexCollection = Array.Empty<String>();
                /// <summary>
                /// <para>The regular expressions identifying topics the subtopology reads from.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<String> SourceTopicRegexCollection
                {
                    get => _sourceTopicRegexCollection;
                    private set
                    {
                        _sourceTopicRegexCollection = value;
                    }
                }

                /// <summary>
                /// <para>The regular expressions identifying topics the subtopology reads from.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Subtopology WithSourceTopicRegexCollection(Array<String> sourceTopicRegexCollection)
                {
                    SourceTopicRegexCollection = sourceTopicRegexCollection;
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

                private Array<CopartitionGroup> _copartitionGroupsCollection = Array.Empty<CopartitionGroup>();
                /// <summary>
                /// <para>A subset of source topics that must be copartitioned.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<CopartitionGroup> CopartitionGroupsCollection
                {
                    get => _copartitionGroupsCollection;
                    private set
                    {
                        _copartitionGroupsCollection = value;
                    }
                }

                /// <summary>
                /// <para>A subset of source topics that must be copartitioned.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Subtopology WithCopartitionGroupsCollection(params Func<CopartitionGroup, CopartitionGroup>[] createFields)
                {
                    CopartitionGroupsCollection = createFields.Select(createField => createField(new CopartitionGroup(Version))).ToArray();
                    return this;
                }

                public delegate CopartitionGroup CreateCopartitionGroup(CopartitionGroup field);
                /// <summary>
                /// <para>A subset of source topics that must be copartitioned.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Subtopology WithCopartitionGroupsCollection(IEnumerable<CreateCopartitionGroup> createFields)
                {
                    CopartitionGroupsCollection = createFields.Select(createField => createField(new CopartitionGroup(Version))).ToArray();
                    return this;
                }

                public class CopartitionGroup : ISerialize
                {
                    internal CopartitionGroup(Int16 version)
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
                    internal int GetSize(bool _) => _sourceTopicsCollection.GetSize(IsFlexibleVersion) + _sourceTopicRegexCollection.GetSize(IsFlexibleVersion) + _repartitionSourceTopicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<CopartitionGroup> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new CopartitionGroup(version);
                        instance.SourceTopicsCollection = await Array<Int16>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                        instance.SourceTopicRegexCollection = await Array<Int16>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                        instance.RepartitionSourceTopicsCollection = await Array<Int16>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for CopartitionGroup is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        await _sourceTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _sourceTopicRegexCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _repartitionSourceTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Array<Int16> _sourceTopicsCollection = Array.Empty<Int16>();
                    /// <summary>
                    /// <para>The topics the topology reads from. Index into the array on the subtopology level.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Array<Int16> SourceTopicsCollection
                    {
                        get => _sourceTopicsCollection;
                        private set
                        {
                            _sourceTopicsCollection = value;
                        }
                    }

                    /// <summary>
                    /// <para>The topics the topology reads from. Index into the array on the subtopology level.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public CopartitionGroup WithSourceTopicsCollection(Array<Int16> sourceTopicsCollection)
                    {
                        SourceTopicsCollection = sourceTopicsCollection;
                        return this;
                    }

                    private Array<Int16> _sourceTopicRegexCollection = Array.Empty<Int16>();
                    /// <summary>
                    /// <para>Regular expressions identifying topics the subtopology reads from. Index into the array on the subtopology level.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Array<Int16> SourceTopicRegexCollection
                    {
                        get => _sourceTopicRegexCollection;
                        private set
                        {
                            _sourceTopicRegexCollection = value;
                        }
                    }

                    /// <summary>
                    /// <para>Regular expressions identifying topics the subtopology reads from. Index into the array on the subtopology level.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public CopartitionGroup WithSourceTopicRegexCollection(Array<Int16> sourceTopicRegexCollection)
                    {
                        SourceTopicRegexCollection = sourceTopicRegexCollection;
                        return this;
                    }

                    private Array<Int16> _repartitionSourceTopicsCollection = Array.Empty<Int16>();
                    /// <summary>
                    /// <para>The set of source topics that are internally created repartition topics. Index into the array on the subtopology level.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Array<Int16> RepartitionSourceTopicsCollection
                    {
                        get => _repartitionSourceTopicsCollection;
                        private set
                        {
                            _repartitionSourceTopicsCollection = value;
                        }
                    }

                    /// <summary>
                    /// <para>The set of source topics that are internally created repartition topics. Index into the array on the subtopology level.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public CopartitionGroup WithRepartitionSourceTopicsCollection(Array<Int16> repartitionSourceTopicsCollection)
                    {
                        RepartitionSourceTopicsCollection = repartitionSourceTopicsCollection;
                        return this;
                    }
                }
            }
        }

        private NullableArray<TaskIds> _activeTasksCollection = new NullableArray<TaskIds>(null);
        /// <summary>
        /// <para>Currently owned active tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<TaskIds>? ActiveTasksCollection
        {
            get => _activeTasksCollection;
            private set
            {
                _activeTasksCollection = value;
            }
        }

        /// <summary>
        /// <para>Currently owned active tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithActiveTasksCollection(Array<TaskIds>? activeTasksCollection)
        {
            ActiveTasksCollection = activeTasksCollection;
            return this;
        }

        private NullableArray<TaskIds> _standbyTasksCollection = new NullableArray<TaskIds>(null);
        /// <summary>
        /// <para>Currently owned standby tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<TaskIds>? StandbyTasksCollection
        {
            get => _standbyTasksCollection;
            private set
            {
                _standbyTasksCollection = value;
            }
        }

        /// <summary>
        /// <para>Currently owned standby tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithStandbyTasksCollection(Array<TaskIds>? standbyTasksCollection)
        {
            StandbyTasksCollection = standbyTasksCollection;
            return this;
        }

        private NullableArray<TaskIds> _warmupTasksCollection = new NullableArray<TaskIds>(null);
        /// <summary>
        /// <para>Currently owned warm-up tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<TaskIds>? WarmupTasksCollection
        {
            get => _warmupTasksCollection;
            private set
            {
                _warmupTasksCollection = value;
            }
        }

        /// <summary>
        /// <para>Currently owned warm-up tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithWarmupTasksCollection(Array<TaskIds>? warmupTasksCollection)
        {
            WarmupTasksCollection = warmupTasksCollection;
            return this;
        }

        private NullableString _processId = new NullableString(null);
        /// <summary>
        /// <para>Identity of the streams instance that may have multiple consumers. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ProcessId
        {
            get => _processId;
            private set
            {
                _processId = value;
            }
        }

        /// <summary>
        /// <para>Identity of the streams instance that may have multiple consumers. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithProcessId(String? processId)
        {
            ProcessId = processId;
            return this;
        }

        private Nullable<Endpoint> _userEndpoint = new Nullable<Endpoint>(null);
        /// <summary>
        /// <para>User-defined endpoint for Interactive Queries. Null if unchanged since last heartbeat, or if not defined on the client.</para>
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
        /// <para>User-defined endpoint for Interactive Queries. Null if unchanged since last heartbeat, or if not defined on the client.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithUserEndpoint(Endpoint? userEndpoint)
        {
            UserEndpoint = userEndpoint;
            return this;
        }

        private NullableArray<KeyValue> _clientTagsCollection = new NullableArray<KeyValue>(null);
        /// <summary>
        /// <para>Used for rack-aware assignment algorithm. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<KeyValue>? ClientTagsCollection
        {
            get => _clientTagsCollection;
            private set
            {
                _clientTagsCollection = value;
            }
        }

        /// <summary>
        /// <para>Used for rack-aware assignment algorithm. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithClientTagsCollection(Array<KeyValue>? clientTagsCollection)
        {
            ClientTagsCollection = clientTagsCollection;
            return this;
        }

        private NullableArray<TaskOffset> _taskOffsetsCollection = new NullableArray<TaskOffset>(null);
        /// <summary>
        /// <para>Cumulative changelog offsets for tasks. Only updated when a warm-up task has caught up, and according to the task offset interval. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<TaskOffset>? TaskOffsetsCollection
        {
            get => _taskOffsetsCollection;
            private set
            {
                _taskOffsetsCollection = value;
            }
        }

        /// <summary>
        /// <para>Cumulative changelog offsets for tasks. Only updated when a warm-up task has caught up, and according to the task offset interval. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithTaskOffsetsCollection(Array<TaskOffset>? taskOffsetsCollection)
        {
            TaskOffsetsCollection = taskOffsetsCollection;
            return this;
        }

        private NullableArray<TaskOffset> _taskEndOffsetsCollection = new NullableArray<TaskOffset>(null);
        /// <summary>
        /// <para>Cumulative changelog end-offsets for tasks. Only updated when a warm-up task has caught up, and according to the task offset interval. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<TaskOffset>? TaskEndOffsetsCollection
        {
            get => _taskEndOffsetsCollection;
            private set
            {
                _taskEndOffsetsCollection = value;
            }
        }

        /// <summary>
        /// <para>Cumulative changelog end-offsets for tasks. Only updated when a warm-up task has caught up, and according to the task offset interval. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithTaskEndOffsetsCollection(Array<TaskOffset>? taskEndOffsetsCollection)
        {
            TaskEndOffsetsCollection = taskEndOffsetsCollection;
            return this;
        }

        private Boolean _shutdownApplication = new Boolean(false);
        /// <summary>
        /// <para>Whether all Streams clients in the group should shut down.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean ShutdownApplication
        {
            get => _shutdownApplication;
            private set
            {
                _shutdownApplication = value;
            }
        }

        /// <summary>
        /// <para>Whether all Streams clients in the group should shut down.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: false</para>
        /// </summary>
        public StreamsGroupHeartbeatRequest WithShutdownApplication(Boolean shutdownApplication)
        {
            ShutdownApplication = shutdownApplication;
            return this;
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

        public StreamsGroupHeartbeatResponse Respond() => new StreamsGroupHeartbeatResponse(Version);
    }
}
