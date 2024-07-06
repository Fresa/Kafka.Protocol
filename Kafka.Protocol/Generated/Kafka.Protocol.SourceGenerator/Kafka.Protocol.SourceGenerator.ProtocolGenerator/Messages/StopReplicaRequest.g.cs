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
    public class StopReplicaRequest : Message, IRespond<StopReplicaResponse>
    {
        public StopReplicaRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"StopReplicaRequest does not support version {version}. Valid versions are: 0-4");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(5);
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

        internal override int GetSize() => _controllerId.GetSize(IsFlexibleVersion) + (Version >= 4 ? _isKRaftController.GetSize(IsFlexibleVersion) : 0) + _controllerEpoch.GetSize(IsFlexibleVersion) + (Version >= 1 ? _brokerEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 2 ? _deletePartitions.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 0 ? _ungroupedPartitionsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 && Version <= 2 ? _topicsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _topicStatesCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<StopReplicaRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new StopReplicaRequest(version);
            instance.ControllerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 4)
                instance.IsKRaftController = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ControllerEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.BrokerEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 2)
                instance.DeletePartitions = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 0)
                instance.UngroupedPartitionsCollection = await Array<StopReplicaPartitionV0>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => StopReplicaPartitionV0.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1 && instance.Version <= 2)
                instance.TopicsCollection = await Array<StopReplicaTopicV1>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => StopReplicaTopicV1.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.TopicStatesCollection = await Array<StopReplicaTopicState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => StopReplicaTopicState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for StopReplicaRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _controllerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 4)
                await _isKRaftController.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _controllerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _brokerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 2)
                await _deletePartitions.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 0)
                await _ungroupedPartitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1 && Version <= 2)
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _topicStatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _controllerId = Int32.Default;
        /// <summary>
        /// <para>The controller id.</para>
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
        /// <para>The controller id.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StopReplicaRequest WithControllerId(Int32 controllerId)
        {
            ControllerId = controllerId;
            return this;
        }

        private Boolean _isKRaftController = new Boolean(false);
        /// <summary>
        /// <para>If KRaft controller id is used during migration. See KIP-866</para>
        /// <para>Versions: 4+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean IsKRaftController
        {
            get => _isKRaftController;
            private set
            {
                if (Version >= 4 == false)
                    throw new UnsupportedVersionException($"IsKRaftController does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                _isKRaftController = value;
            }
        }

        /// <summary>
        /// <para>If KRaft controller id is used during migration. See KIP-866</para>
        /// <para>Versions: 4+</para>
        /// <para>Default: false</para>
        /// </summary>
        public StopReplicaRequest WithIsKRaftController(Boolean isKRaftController)
        {
            IsKRaftController = isKRaftController;
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
        public StopReplicaRequest WithControllerEpoch(Int32 controllerEpoch)
        {
            ControllerEpoch = controllerEpoch;
            return this;
        }

        private Int64 _brokerEpoch = new Int64(-1);
        /// <summary>
        /// <para>The broker epoch.</para>
        /// <para>Versions: 1+</para>
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
        /// <para>The broker epoch.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public StopReplicaRequest WithBrokerEpoch(Int64 brokerEpoch)
        {
            BrokerEpoch = brokerEpoch;
            return this;
        }

        private Boolean _deletePartitions = Boolean.Default;
        /// <summary>
        /// <para>Whether these partitions should be deleted.</para>
        /// <para>Versions: 0-2</para>
        /// </summary>
        public Boolean DeletePartitions
        {
            get => _deletePartitions;
            private set
            {
                if (Version >= 0 && Version <= 2 == false)
                    throw new UnsupportedVersionException($"DeletePartitions does not support version {Version} and has been defined as not ignorable. Supported versions: 0-2");
                _deletePartitions = value;
            }
        }

        /// <summary>
        /// <para>Whether these partitions should be deleted.</para>
        /// <para>Versions: 0-2</para>
        /// </summary>
        public StopReplicaRequest WithDeletePartitions(Boolean deletePartitions)
        {
            DeletePartitions = deletePartitions;
            return this;
        }

        private Array<StopReplicaPartitionV0> _ungroupedPartitionsCollection = Array.Empty<StopReplicaPartitionV0>();
        /// <summary>
        /// <para>The partitions to stop.</para>
        /// <para>Versions: 0</para>
        /// </summary>
        public Array<StopReplicaPartitionV0> UngroupedPartitionsCollection
        {
            get => _ungroupedPartitionsCollection;
            private set
            {
                if (Version >= 0 && Version <= 0 == false)
                    throw new UnsupportedVersionException($"UngroupedPartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
                _ungroupedPartitionsCollection = value;
            }
        }

        /// <summary>
        /// <para>The partitions to stop.</para>
        /// <para>Versions: 0</para>
        /// </summary>
        public StopReplicaRequest WithUngroupedPartitionsCollection(params Func<StopReplicaPartitionV0, StopReplicaPartitionV0>[] createFields)
        {
            UngroupedPartitionsCollection = createFields.Select(createField => createField(new StopReplicaPartitionV0(Version))).ToArray();
            return this;
        }

        public delegate StopReplicaPartitionV0 CreateStopReplicaPartitionV0(StopReplicaPartitionV0 field);
        /// <summary>
        /// <para>The partitions to stop.</para>
        /// <para>Versions: 0</para>
        /// </summary>
        public StopReplicaRequest WithUngroupedPartitionsCollection(IEnumerable<CreateStopReplicaPartitionV0> createFields)
        {
            UngroupedPartitionsCollection = createFields.Select(createField => createField(new StopReplicaPartitionV0(Version))).ToArray();
            return this;
        }

        public class StopReplicaPartitionV0 : ISerialize
        {
            internal StopReplicaPartitionV0(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 2;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 0 && Version <= 0 ? _topicName.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 0 ? _partitionIndex.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<StopReplicaPartitionV0> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new StopReplicaPartitionV0(version);
                if (instance.Version >= 0 && instance.Version <= 0)
                    instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 0 && instance.Version <= 0)
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for StopReplicaPartitionV0 is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 0 && Version <= 0)
                    await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 0 && Version <= 0)
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0</para>
            /// </summary>
            public String TopicName
            {
                get => _topicName;
                private set
                {
                    if (Version >= 0 && Version <= 0 == false)
                        throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
                    _topicName = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0</para>
            /// </summary>
            public StopReplicaPartitionV0 WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Int32 _partitionIndex = Int32.Default;
            /// <summary>
            /// <para>The partition index.</para>
            /// <para>Versions: 0</para>
            /// </summary>
            public Int32 PartitionIndex
            {
                get => _partitionIndex;
                private set
                {
                    if (Version >= 0 && Version <= 0 == false)
                        throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
                    _partitionIndex = value;
                }
            }

            /// <summary>
            /// <para>The partition index.</para>
            /// <para>Versions: 0</para>
            /// </summary>
            public StopReplicaPartitionV0 WithPartitionIndex(Int32 partitionIndex)
            {
                PartitionIndex = partitionIndex;
                return this;
            }
        }

        private Array<StopReplicaTopicV1> _topicsCollection = Array.Empty<StopReplicaTopicV1>();
        /// <summary>
        /// <para>The topics to stop.</para>
        /// <para>Versions: 1-2</para>
        /// </summary>
        public Array<StopReplicaTopicV1> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                if (Version >= 1 && Version <= 2 == false)
                    throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1-2");
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to stop.</para>
        /// <para>Versions: 1-2</para>
        /// </summary>
        public StopReplicaRequest WithTopicsCollection(params Func<StopReplicaTopicV1, StopReplicaTopicV1>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new StopReplicaTopicV1(Version))).ToArray();
            return this;
        }

        public delegate StopReplicaTopicV1 CreateStopReplicaTopicV1(StopReplicaTopicV1 field);
        /// <summary>
        /// <para>The topics to stop.</para>
        /// <para>Versions: 1-2</para>
        /// </summary>
        public StopReplicaRequest WithTopicsCollection(IEnumerable<CreateStopReplicaTopicV1> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new StopReplicaTopicV1(Version))).ToArray();
            return this;
        }

        public class StopReplicaTopicV1 : ISerialize
        {
            internal StopReplicaTopicV1(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 2;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 1 && Version <= 2 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 && Version <= 2 ? _partitionIndexesCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<StopReplicaTopicV1> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new StopReplicaTopicV1(version);
                if (instance.Version >= 1 && instance.Version <= 2)
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1 && instance.Version <= 2)
                    instance.PartitionIndexesCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for StopReplicaTopicV1 is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 1 && Version <= 2)
                    await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1 && Version <= 2)
                    await _partitionIndexesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 1-2</para>
            /// </summary>
            public String Name
            {
                get => _name;
                private set
                {
                    if (Version >= 1 && Version <= 2 == false)
                        throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 1-2");
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 1-2</para>
            /// </summary>
            public StopReplicaTopicV1 WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<Int32> _partitionIndexesCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partition indexes.</para>
            /// <para>Versions: 1-2</para>
            /// </summary>
            public Array<Int32> PartitionIndexesCollection
            {
                get => _partitionIndexesCollection;
                private set
                {
                    if (Version >= 1 && Version <= 2 == false)
                        throw new UnsupportedVersionException($"PartitionIndexesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1-2");
                    _partitionIndexesCollection = value;
                }
            }

            /// <summary>
            /// <para>The partition indexes.</para>
            /// <para>Versions: 1-2</para>
            /// </summary>
            public StopReplicaTopicV1 WithPartitionIndexesCollection(Array<Int32> partitionIndexesCollection)
            {
                PartitionIndexesCollection = partitionIndexesCollection;
                return this;
            }
        }

        private Array<StopReplicaTopicState> _topicStatesCollection = Array.Empty<StopReplicaTopicState>();
        /// <summary>
        /// <para>Each topic.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public Array<StopReplicaTopicState> TopicStatesCollection
        {
            get => _topicStatesCollection;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"TopicStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                _topicStatesCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public StopReplicaRequest WithTopicStatesCollection(params Func<StopReplicaTopicState, StopReplicaTopicState>[] createFields)
        {
            TopicStatesCollection = createFields.Select(createField => createField(new StopReplicaTopicState(Version))).ToArray();
            return this;
        }

        public delegate StopReplicaTopicState CreateStopReplicaTopicState(StopReplicaTopicState field);
        /// <summary>
        /// <para>Each topic.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public StopReplicaRequest WithTopicStatesCollection(IEnumerable<CreateStopReplicaTopicState> createFields)
        {
            TopicStatesCollection = createFields.Select(createField => createField(new StopReplicaTopicState(Version))).ToArray();
            return this;
        }

        public class StopReplicaTopicState : ISerialize
        {
            internal StopReplicaTopicState(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 2;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 3 ? _topicName.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _partitionStatesCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<StopReplicaTopicState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new StopReplicaTopicState(version);
                if (instance.Version >= 3)
                    instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.PartitionStatesCollection = await Array<StopReplicaPartitionState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => StopReplicaPartitionState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for StopReplicaTopicState is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 3)
                    await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _partitionStatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public String TopicName
            {
                get => _topicName;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _topicName = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public StopReplicaTopicState WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Array<StopReplicaPartitionState> _partitionStatesCollection = Array.Empty<StopReplicaPartitionState>();
            /// <summary>
            /// <para>The state of each partition</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public Array<StopReplicaPartitionState> PartitionStatesCollection
            {
                get => _partitionStatesCollection;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"PartitionStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _partitionStatesCollection = value;
                }
            }

            /// <summary>
            /// <para>The state of each partition</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public StopReplicaTopicState WithPartitionStatesCollection(params Func<StopReplicaPartitionState, StopReplicaPartitionState>[] createFields)
            {
                PartitionStatesCollection = createFields.Select(createField => createField(new StopReplicaPartitionState(Version))).ToArray();
                return this;
            }

            public delegate StopReplicaPartitionState CreateStopReplicaPartitionState(StopReplicaPartitionState field);
            /// <summary>
            /// <para>The state of each partition</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public StopReplicaTopicState WithPartitionStatesCollection(IEnumerable<CreateStopReplicaPartitionState> createFields)
            {
                PartitionStatesCollection = createFields.Select(createField => createField(new StopReplicaPartitionState(Version))).ToArray();
                return this;
            }

            public class StopReplicaPartitionState : ISerialize
            {
                internal StopReplicaPartitionState(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 2;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => (Version >= 3 ? _partitionIndex.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _leaderEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _deletePartition.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<StopReplicaPartitionState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new StopReplicaPartitionState(version);
                    if (instance.Version >= 3)
                        instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 3)
                        instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 3)
                        instance.DeletePartition = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for StopReplicaPartitionState is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    if (Version >= 3)
                        await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 3)
                        await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 3)
                        await _deletePartition.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _partitionIndex = Int32.Default;
                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 3+</para>
                /// </summary>
                public Int32 PartitionIndex
                {
                    get => _partitionIndex;
                    private set
                    {
                        if (Version >= 3 == false)
                            throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                        _partitionIndex = value;
                    }
                }

                /// <summary>
                /// <para>The partition index.</para>
                /// <para>Versions: 3+</para>
                /// </summary>
                public StopReplicaPartitionState WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int32 _leaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>The leader epoch.</para>
                /// <para>Versions: 3+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int32 LeaderEpoch
                {
                    get => _leaderEpoch;
                    private set
                    {
                        if (Version >= 3 == false)
                            throw new UnsupportedVersionException($"LeaderEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                        _leaderEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The leader epoch.</para>
                /// <para>Versions: 3+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public StopReplicaPartitionState WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }

                private Boolean _deletePartition = Boolean.Default;
                /// <summary>
                /// <para>Whether this partition should be deleted.</para>
                /// <para>Versions: 3+</para>
                /// </summary>
                public Boolean DeletePartition
                {
                    get => _deletePartition;
                    private set
                    {
                        if (Version >= 3 == false)
                            throw new UnsupportedVersionException($"DeletePartition does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                        _deletePartition = value;
                    }
                }

                /// <summary>
                /// <para>Whether this partition should be deleted.</para>
                /// <para>Versions: 3+</para>
                /// </summary>
                public StopReplicaPartitionState WithDeletePartition(Boolean deletePartition)
                {
                    DeletePartition = deletePartition;
                    return this;
                }
            }
        }

        public StopReplicaResponse Respond() => new StopReplicaResponse(Version);
    }
}
