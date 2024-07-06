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
    public class LeaderAndIsrRequest : Message, IRespond<LeaderAndIsrResponse>
    {
        public LeaderAndIsrRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"LeaderAndIsrRequest does not support version {version}. Valid versions are: 0-7");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(4);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(7);
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

        internal override int GetSize() => _controllerId.GetSize(IsFlexibleVersion) + (Version >= 7 ? _isKRaftController.GetSize(IsFlexibleVersion) : 0) + _controllerEpoch.GetSize(IsFlexibleVersion) + (Version >= 2 ? _brokerEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _type.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 1 ? _ungroupedPartitionStatesCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 ? _topicStatesCollection.GetSize(IsFlexibleVersion) : 0) + _liveLeadersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<LeaderAndIsrRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new LeaderAndIsrRequest(version);
            instance.ControllerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 7)
                instance.IsKRaftController = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ControllerEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2)
                instance.BrokerEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 5)
                instance.Type = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 1)
                instance.UngroupedPartitionStatesCollection = await Array<LeaderAndIsrPartitionState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => LeaderAndIsrPartitionState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2)
                instance.TopicStatesCollection = await Array<LeaderAndIsrTopicState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => LeaderAndIsrTopicState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.LiveLeadersCollection = await Array<LeaderAndIsrLiveLeader>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => LeaderAndIsrLiveLeader.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderAndIsrRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _controllerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 7)
                await _isKRaftController.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _controllerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 2)
                await _brokerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 5)
                await _type.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 1)
                await _ungroupedPartitionStatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 2)
                await _topicStatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _liveLeadersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _controllerId = Int32.Default;
        /// <summary>
        /// <para>The current controller ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 ControllerId
        {
            get => _controllerId;
            private set
            {
                _controllerId = value;
            }
        }

        /// <summary>
        /// <para>The current controller ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public LeaderAndIsrRequest WithControllerId(Int32 controllerId)
        {
            ControllerId = controllerId;
            return this;
        }

        private Boolean _isKRaftController = new Boolean(false);
        /// <summary>
        /// <para>If KRaft controller id is used during migration. See KIP-866</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean IsKRaftController
        {
            get => _isKRaftController;
            private set
            {
                if (Version >= 7 == false)
                    throw new UnsupportedVersionException($"IsKRaftController does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
                _isKRaftController = value;
            }
        }

        /// <summary>
        /// <para>If KRaft controller id is used during migration. See KIP-866</para>
        /// <para>Versions: 7+</para>
        /// <para>Default: false</para>
        /// </summary>
        public LeaderAndIsrRequest WithIsKRaftController(Boolean isKRaftController)
        {
            IsKRaftController = isKRaftController;
            return this;
        }

        private Int32 _controllerEpoch = Int32.Default;
        /// <summary>
        /// <para>The current controller epoch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 ControllerEpoch
        {
            get => _controllerEpoch;
            private set
            {
                _controllerEpoch = value;
            }
        }

        /// <summary>
        /// <para>The current controller epoch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public LeaderAndIsrRequest WithControllerEpoch(Int32 controllerEpoch)
        {
            ControllerEpoch = controllerEpoch;
            return this;
        }

        private Int64 _brokerEpoch = new Int64(-1);
        /// <summary>
        /// <para>The current broker epoch.</para>
        /// <para>Versions: 2+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int64 BrokerEpoch
        {
            get => _brokerEpoch;
            private set
            {
                _brokerEpoch = value;
            }
        }

        /// <summary>
        /// <para>The current broker epoch.</para>
        /// <para>Versions: 2+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public LeaderAndIsrRequest WithBrokerEpoch(Int64 brokerEpoch)
        {
            BrokerEpoch = brokerEpoch;
            return this;
        }

        private Int8 _type = Int8.Default;
        /// <summary>
        /// <para>The type that indicates whether all topics are included in the request</para>
        /// <para>Versions: 5+</para>
        /// </summary>
        public Int8 Type
        {
            get => _type;
            private set
            {
                if (Version >= 5 == false)
                    throw new UnsupportedVersionException($"Type does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                _type = value;
            }
        }

        /// <summary>
        /// <para>The type that indicates whether all topics are included in the request</para>
        /// <para>Versions: 5+</para>
        /// </summary>
        public LeaderAndIsrRequest WithType(Int8 type)
        {
            Type = type;
            return this;
        }

        private Array<LeaderAndIsrPartitionState> _ungroupedPartitionStatesCollection = Array.Empty<LeaderAndIsrPartitionState>();
        /// <summary>
        /// <para>The state of each partition, in a v0 or v1 message.</para>
        /// <para>Versions: 0-1</para>
        /// </summary>
        public Array<LeaderAndIsrPartitionState> UngroupedPartitionStatesCollection
        {
            get => _ungroupedPartitionStatesCollection;
            private set
            {
                if (Version >= 0 && Version <= 1 == false)
                    throw new UnsupportedVersionException($"UngroupedPartitionStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-1");
                _ungroupedPartitionStatesCollection = value;
            }
        }

        /// <summary>
        /// <para>The state of each partition, in a v0 or v1 message.</para>
        /// <para>Versions: 0-1</para>
        /// </summary>
        public LeaderAndIsrRequest WithUngroupedPartitionStatesCollection(Array<LeaderAndIsrPartitionState> ungroupedPartitionStatesCollection)
        {
            UngroupedPartitionStatesCollection = ungroupedPartitionStatesCollection;
            return this;
        }

        private Array<LeaderAndIsrTopicState> _topicStatesCollection = Array.Empty<LeaderAndIsrTopicState>();
        /// <summary>
        /// <para>Each topic.</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public Array<LeaderAndIsrTopicState> TopicStatesCollection
        {
            get => _topicStatesCollection;
            private set
            {
                if (Version >= 2 == false)
                    throw new UnsupportedVersionException($"TopicStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                _topicStatesCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic.</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public LeaderAndIsrRequest WithTopicStatesCollection(params Func<LeaderAndIsrTopicState, LeaderAndIsrTopicState>[] createFields)
        {
            TopicStatesCollection = createFields.Select(createField => createField(new LeaderAndIsrTopicState(Version))).ToArray();
            return this;
        }

        public delegate LeaderAndIsrTopicState CreateLeaderAndIsrTopicState(LeaderAndIsrTopicState field);
        /// <summary>
        /// <para>Each topic.</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public LeaderAndIsrRequest WithTopicStatesCollection(IEnumerable<CreateLeaderAndIsrTopicState> createFields)
        {
            TopicStatesCollection = createFields.Select(createField => createField(new LeaderAndIsrTopicState(Version))).ToArray();
            return this;
        }

        public class LeaderAndIsrTopicState : ISerialize
        {
            internal LeaderAndIsrTopicState(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 2 ? _topicName.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _topicId.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 ? _partitionStatesCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<LeaderAndIsrTopicState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new LeaderAndIsrTopicState(version);
                if (instance.Version >= 2)
                    instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 5)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 2)
                    instance.PartitionStatesCollection = await Array<LeaderAndIsrPartitionState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => LeaderAndIsrPartitionState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderAndIsrTopicState is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 2)
                    await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 5)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 2)
                    await _partitionStatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public String TopicName
            {
                get => _topicName;
                private set
                {
                    if (Version >= 2 == false)
                        throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                    _topicName = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public LeaderAndIsrTopicState WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The unique topic ID.</para>
            /// <para>Versions: 5+</para>
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
            /// <para>The unique topic ID.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public LeaderAndIsrTopicState WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<LeaderAndIsrPartitionState> _partitionStatesCollection = Array.Empty<LeaderAndIsrPartitionState>();
            /// <summary>
            /// <para>The state of each partition</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public Array<LeaderAndIsrPartitionState> PartitionStatesCollection
            {
                get => _partitionStatesCollection;
                private set
                {
                    if (Version >= 2 == false)
                        throw new UnsupportedVersionException($"PartitionStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                    _partitionStatesCollection = value;
                }
            }

            /// <summary>
            /// <para>The state of each partition</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public LeaderAndIsrTopicState WithPartitionStatesCollection(Array<LeaderAndIsrPartitionState> partitionStatesCollection)
            {
                PartitionStatesCollection = partitionStatesCollection;
                return this;
            }
        }

        private Array<LeaderAndIsrLiveLeader> _liveLeadersCollection = Array.Empty<LeaderAndIsrLiveLeader>();
        /// <summary>
        /// <para>The current live leaders.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<LeaderAndIsrLiveLeader> LiveLeadersCollection
        {
            get => _liveLeadersCollection;
            private set
            {
                _liveLeadersCollection = value;
            }
        }

        /// <summary>
        /// <para>The current live leaders.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public LeaderAndIsrRequest WithLiveLeadersCollection(params Func<LeaderAndIsrLiveLeader, LeaderAndIsrLiveLeader>[] createFields)
        {
            LiveLeadersCollection = createFields.Select(createField => createField(new LeaderAndIsrLiveLeader(Version))).ToArray();
            return this;
        }

        public delegate LeaderAndIsrLiveLeader CreateLeaderAndIsrLiveLeader(LeaderAndIsrLiveLeader field);
        /// <summary>
        /// <para>The current live leaders.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public LeaderAndIsrRequest WithLiveLeadersCollection(IEnumerable<CreateLeaderAndIsrLiveLeader> createFields)
        {
            LiveLeadersCollection = createFields.Select(createField => createField(new LeaderAndIsrLiveLeader(Version))).ToArray();
            return this;
        }

        public class LeaderAndIsrLiveLeader : ISerialize
        {
            internal LeaderAndIsrLiveLeader(Int16 version)
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
            internal int GetSize(bool _) => _brokerId.GetSize(IsFlexibleVersion) + _hostName.GetSize(IsFlexibleVersion) + _port.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<LeaderAndIsrLiveLeader> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new LeaderAndIsrLiveLeader(version);
                instance.BrokerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.HostName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Port = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderAndIsrLiveLeader is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _brokerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _hostName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _brokerId = Int32.Default;
            /// <summary>
            /// <para>The leader's broker ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 BrokerId
            {
                get => _brokerId;
                private set
                {
                    _brokerId = value;
                }
            }

            /// <summary>
            /// <para>The leader's broker ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrLiveLeader WithBrokerId(Int32 brokerId)
            {
                BrokerId = brokerId;
                return this;
            }

            private String _hostName = String.Default;
            /// <summary>
            /// <para>The leader's hostname.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String HostName
            {
                get => _hostName;
                private set
                {
                    _hostName = value;
                }
            }

            /// <summary>
            /// <para>The leader's hostname.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrLiveLeader WithHostName(String hostName)
            {
                HostName = hostName;
                return this;
            }

            private Int32 _port = Int32.Default;
            /// <summary>
            /// <para>The leader's port.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 Port
            {
                get => _port;
                private set
                {
                    _port = value;
                }
            }

            /// <summary>
            /// <para>The leader's port.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrLiveLeader WithPort(Int32 port)
            {
                Port = port;
                return this;
            }
        }

        public class LeaderAndIsrPartitionState : ISerialize
        {
            internal LeaderAndIsrPartitionState(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 0 && Version <= 1 ? _topicName.GetSize(IsFlexibleVersion) : 0) + _partitionIndex.GetSize(IsFlexibleVersion) + _controllerEpoch.GetSize(IsFlexibleVersion) + _leader.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + _isrCollection.GetSize(IsFlexibleVersion) + _partitionEpoch.GetSize(IsFlexibleVersion) + _replicasCollection.GetSize(IsFlexibleVersion) + (Version >= 3 ? _addingReplicasCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _removingReplicasCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _isNew.GetSize(IsFlexibleVersion) : 0) + (Version >= 6 ? _leaderRecoveryState.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<LeaderAndIsrPartitionState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new LeaderAndIsrPartitionState(version);
                if (instance.Version >= 0 && instance.Version <= 1)
                    instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ControllerEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Leader = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.IsrCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.PartitionEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ReplicasCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.AddingReplicasCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.RemovingReplicasCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.IsNew = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 6)
                    instance.LeaderRecoveryState = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderAndIsrPartitionState is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 0 && Version <= 1)
                    await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _controllerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _leader.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _isrCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _replicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _addingReplicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _removingReplicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _isNew.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 6)
                    await _leaderRecoveryState.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The topic name.  This is only present in v0 or v1.</para>
            /// <para>Versions: 0-1</para>
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
            /// <para>The topic name.  This is only present in v0 or v1.</para>
            /// <para>Versions: 0-1</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Int32 _partitionIndex = Int32.Default;
            /// <summary>
            /// <para>The partition index.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 PartitionIndex
            {
                get => _partitionIndex;
                private set
                {
                    _partitionIndex = value;
                }
            }

            /// <summary>
            /// <para>The partition index.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithPartitionIndex(Int32 partitionIndex)
            {
                PartitionIndex = partitionIndex;
                return this;
            }

            private Int32 _controllerEpoch = Int32.Default;
            /// <summary>
            /// <para>The controller epoch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 ControllerEpoch
            {
                get => _controllerEpoch;
                private set
                {
                    _controllerEpoch = value;
                }
            }

            /// <summary>
            /// <para>The controller epoch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithControllerEpoch(Int32 controllerEpoch)
            {
                ControllerEpoch = controllerEpoch;
                return this;
            }

            private Int32 _leader = Int32.Default;
            /// <summary>
            /// <para>The broker ID of the leader.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 Leader
            {
                get => _leader;
                private set
                {
                    _leader = value;
                }
            }

            /// <summary>
            /// <para>The broker ID of the leader.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithLeader(Int32 leader)
            {
                Leader = leader;
                return this;
            }

            private Int32 _leaderEpoch = Int32.Default;
            /// <summary>
            /// <para>The leader epoch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 LeaderEpoch
            {
                get => _leaderEpoch;
                private set
                {
                    _leaderEpoch = value;
                }
            }

            /// <summary>
            /// <para>The leader epoch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithLeaderEpoch(Int32 leaderEpoch)
            {
                LeaderEpoch = leaderEpoch;
                return this;
            }

            private Array<Int32> _isrCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The in-sync replica IDs.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<Int32> IsrCollection
            {
                get => _isrCollection;
                private set
                {
                    _isrCollection = value;
                }
            }

            /// <summary>
            /// <para>The in-sync replica IDs.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithIsrCollection(Array<Int32> isrCollection)
            {
                IsrCollection = isrCollection;
                return this;
            }

            private Int32 _partitionEpoch = Int32.Default;
            /// <summary>
            /// <para>The current epoch for the partition. The epoch is a monotonically increasing value which is incremented after every partition change. (Since the LeaderAndIsr request is only used by the legacy controller, this corresponds to the zkVersion)</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 PartitionEpoch
            {
                get => _partitionEpoch;
                private set
                {
                    _partitionEpoch = value;
                }
            }

            /// <summary>
            /// <para>The current epoch for the partition. The epoch is a monotonically increasing value which is incremented after every partition change. (Since the LeaderAndIsr request is only used by the legacy controller, this corresponds to the zkVersion)</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithPartitionEpoch(Int32 partitionEpoch)
            {
                PartitionEpoch = partitionEpoch;
                return this;
            }

            private Array<Int32> _replicasCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The replica IDs.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<Int32> ReplicasCollection
            {
                get => _replicasCollection;
                private set
                {
                    _replicasCollection = value;
                }
            }

            /// <summary>
            /// <para>The replica IDs.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithReplicasCollection(Array<Int32> replicasCollection)
            {
                ReplicasCollection = replicasCollection;
                return this;
            }

            private Array<Int32> _addingReplicasCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The replica IDs that we are adding this partition to, or null if no replicas are being added.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public Array<Int32> AddingReplicasCollection
            {
                get => _addingReplicasCollection;
                private set
                {
                    _addingReplicasCollection = value;
                }
            }

            /// <summary>
            /// <para>The replica IDs that we are adding this partition to, or null if no replicas are being added.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithAddingReplicasCollection(Array<Int32> addingReplicasCollection)
            {
                AddingReplicasCollection = addingReplicasCollection;
                return this;
            }

            private Array<Int32> _removingReplicasCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The replica IDs that we are removing this partition from, or null if no replicas are being removed.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public Array<Int32> RemovingReplicasCollection
            {
                get => _removingReplicasCollection;
                private set
                {
                    _removingReplicasCollection = value;
                }
            }

            /// <summary>
            /// <para>The replica IDs that we are removing this partition from, or null if no replicas are being removed.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithRemovingReplicasCollection(Array<Int32> removingReplicasCollection)
            {
                RemovingReplicasCollection = removingReplicasCollection;
                return this;
            }

            private Boolean _isNew = new Boolean(false);
            /// <summary>
            /// <para>Whether the replica should have existed on the broker or not.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: false</para>
            /// </summary>
            public Boolean IsNew
            {
                get => _isNew;
                private set
                {
                    _isNew = value;
                }
            }

            /// <summary>
            /// <para>Whether the replica should have existed on the broker or not.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: false</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithIsNew(Boolean isNew)
            {
                IsNew = isNew;
                return this;
            }

            private Int8 _leaderRecoveryState = new Int8(0);
            /// <summary>
            /// <para>1 if the partition is recovering from an unclean leader election; 0 otherwise.</para>
            /// <para>Versions: 6+</para>
            /// <para>Default: 0</para>
            /// </summary>
            public Int8 LeaderRecoveryState
            {
                get => _leaderRecoveryState;
                private set
                {
                    if (Version >= 6 == false)
                        throw new UnsupportedVersionException($"LeaderRecoveryState does not support version {Version} and has been defined as not ignorable. Supported versions: 6+");
                    _leaderRecoveryState = value;
                }
            }

            /// <summary>
            /// <para>1 if the partition is recovering from an unclean leader election; 0 otherwise.</para>
            /// <para>Versions: 6+</para>
            /// <para>Default: 0</para>
            /// </summary>
            public LeaderAndIsrPartitionState WithLeaderRecoveryState(Int8 leaderRecoveryState)
            {
                LeaderRecoveryState = leaderRecoveryState;
                return this;
            }
        }

        public LeaderAndIsrResponse Respond() => new LeaderAndIsrResponse(Version);
    }
}
