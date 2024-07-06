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
    public class AlterPartitionRequest : Message, IRespond<AlterPartitionResponse>
    {
        public AlterPartitionRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AlterPartitionRequest does not support version {version}. Valid versions are: 0-3");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(56);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(3);
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

        internal override int GetSize() => _brokerId.GetSize(IsFlexibleVersion) + _brokerEpoch.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AlterPartitionRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AlterPartitionRequest(version);
            instance.BrokerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.BrokerEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<TopicData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterPartitionRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _brokerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _brokerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _brokerId = Int32.Default;
        /// <summary>
        /// <para>The ID of the requesting broker</para>
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
        /// <para>The ID of the requesting broker</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterPartitionRequest WithBrokerId(Int32 brokerId)
        {
            BrokerId = brokerId;
            return this;
        }

        private Int64 _brokerEpoch = new Int64(-1);
        /// <summary>
        /// <para>The epoch of the requesting broker</para>
        /// <para>Versions: 0+</para>
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
        /// <para>The epoch of the requesting broker</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public AlterPartitionRequest WithBrokerEpoch(Int64 brokerEpoch)
        {
            BrokerEpoch = brokerEpoch;
            return this;
        }

        private Array<TopicData> _topicsCollection = Array.Empty<TopicData>();
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<TopicData> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterPartitionRequest WithTopicsCollection(params Func<TopicData, TopicData>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicData(Version))).ToArray();
            return this;
        }

        public delegate TopicData CreateTopicData(TopicData field);
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterPartitionRequest WithTopicsCollection(IEnumerable<CreateTopicData> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicData(Version))).ToArray();
            return this;
        }

        public class TopicData : ISerialize
        {
            internal TopicData(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 0 && Version <= 1 ? _topicName.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 ? _topicId.GetSize(IsFlexibleVersion) : 0) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicData(version);
                if (instance.Version >= 0 && instance.Version <= 1)
                    instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 2)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<PartitionData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => PartitionData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicData is unknown");
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
                if (Version >= 2)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The name of the topic to alter ISRs for</para>
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
            /// <para>The name of the topic to alter ISRs for</para>
            /// <para>Versions: 0-1</para>
            /// </summary>
            public TopicData WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The ID of the topic to alter ISRs for</para>
            /// <para>Versions: 2+</para>
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
            /// <para>The ID of the topic to alter ISRs for</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public TopicData WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<PartitionData> _partitionsCollection = Array.Empty<PartitionData>();
            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<PartitionData> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicData WithPartitionsCollection(params Func<PartitionData, PartitionData>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionData(Version))).ToArray();
                return this;
            }

            public delegate PartitionData CreatePartitionData(PartitionData field);
            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicData WithPartitionsCollection(IEnumerable<CreatePartitionData> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionData(Version))).ToArray();
                return this;
            }

            public class PartitionData : ISerialize
            {
                internal PartitionData(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + (Version >= 0 && Version <= 2 ? _newIsrCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _newIsrWithEpochsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _leaderRecoveryState.GetSize(IsFlexibleVersion) : 0) + _partitionEpoch.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionData(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 0 && instance.Version <= 2)
                        instance.NewIsrCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 3)
                        instance.NewIsrWithEpochsCollection = await Array<BrokerState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => BrokerState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.LeaderRecoveryState = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for PartitionData is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 0 && Version <= 2)
                        await _newIsrCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 3)
                        await _newIsrWithEpochsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _leaderRecoveryState.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _partitionEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _partitionIndex = Int32.Default;
                /// <summary>
                /// <para>The partition index</para>
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
                /// <para>The partition index</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int32 _leaderEpoch = Int32.Default;
                /// <summary>
                /// <para>The leader epoch of this partition</para>
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
                /// <para>The leader epoch of this partition</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }

                private Array<Int32> _newIsrCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The ISR for this partition. Deprecated since version 3.</para>
                /// <para>Versions: 0-2</para>
                /// </summary>
                public Array<Int32> NewIsrCollection
                {
                    get => _newIsrCollection;
                    private set
                    {
                        if (Version >= 0 && Version <= 2 == false)
                            throw new UnsupportedVersionException($"NewIsrCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-2");
                        _newIsrCollection = value;
                    }
                }

                /// <summary>
                /// <para>The ISR for this partition. Deprecated since version 3.</para>
                /// <para>Versions: 0-2</para>
                /// </summary>
                public PartitionData WithNewIsrCollection(Array<Int32> newIsrCollection)
                {
                    NewIsrCollection = newIsrCollection;
                    return this;
                }

                private Array<BrokerState> _newIsrWithEpochsCollection = Array.Empty<BrokerState>();
                /// <summary>
                /// <para>Versions: 3+</para>
                /// </summary>
                public Array<BrokerState> NewIsrWithEpochsCollection
                {
                    get => _newIsrWithEpochsCollection;
                    private set
                    {
                        if (Version >= 3 == false)
                            throw new UnsupportedVersionException($"NewIsrWithEpochsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                        _newIsrWithEpochsCollection = value;
                    }
                }

                /// <summary>
                /// <para>Versions: 3+</para>
                /// </summary>
                public PartitionData WithNewIsrWithEpochsCollection(params Func<BrokerState, BrokerState>[] createFields)
                {
                    NewIsrWithEpochsCollection = createFields.Select(createField => createField(new BrokerState(Version))).ToArray();
                    return this;
                }

                public delegate BrokerState CreateBrokerState(BrokerState field);
                /// <summary>
                /// <para>Versions: 3+</para>
                /// </summary>
                public PartitionData WithNewIsrWithEpochsCollection(IEnumerable<CreateBrokerState> createFields)
                {
                    NewIsrWithEpochsCollection = createFields.Select(createField => createField(new BrokerState(Version))).ToArray();
                    return this;
                }

                public class BrokerState : ISerialize
                {
                    internal BrokerState(Int16 version)
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
                    internal int GetSize(bool _) => (Version >= 3 ? _brokerId.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _brokerEpoch.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<BrokerState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new BrokerState(version);
                        if (instance.Version >= 3)
                            instance.BrokerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 3)
                            instance.BrokerEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for BrokerState is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        if (Version >= 3)
                            await _brokerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 3)
                            await _brokerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int32 _brokerId = Int32.Default;
                    /// <summary>
                    /// <para>The ID of the broker.</para>
                    /// <para>Versions: 3+</para>
                    /// </summary>
                    public Int32 BrokerId
                    {
                        get => _brokerId;
                        private set
                        {
                            if (Version >= 3 == false)
                                throw new UnsupportedVersionException($"BrokerId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                            _brokerId = value;
                        }
                    }

                    /// <summary>
                    /// <para>The ID of the broker.</para>
                    /// <para>Versions: 3+</para>
                    /// </summary>
                    public BrokerState WithBrokerId(Int32 brokerId)
                    {
                        BrokerId = brokerId;
                        return this;
                    }

                    private Int64 _brokerEpoch = new Int64(-1);
                    /// <summary>
                    /// <para>The epoch of the broker. It will be -1 if the epoch check is not supported.</para>
                    /// <para>Versions: 3+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public Int64 BrokerEpoch
                    {
                        get => _brokerEpoch;
                        private set
                        {
                            if (Version >= 3 == false)
                                throw new UnsupportedVersionException($"BrokerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                            _brokerEpoch = value;
                        }
                    }

                    /// <summary>
                    /// <para>The epoch of the broker. It will be -1 if the epoch check is not supported.</para>
                    /// <para>Versions: 3+</para>
                    /// <para>Default: -1</para>
                    /// </summary>
                    public BrokerState WithBrokerEpoch(Int64 brokerEpoch)
                    {
                        BrokerEpoch = brokerEpoch;
                        return this;
                    }
                }

                private Int8 _leaderRecoveryState = new Int8(0);
                /// <summary>
                /// <para>1 if the partition is recovering from an unclean leader election; 0 otherwise.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: 0</para>
                /// </summary>
                public Int8 LeaderRecoveryState
                {
                    get => _leaderRecoveryState;
                    private set
                    {
                        if (Version >= 1 == false)
                            throw new UnsupportedVersionException($"LeaderRecoveryState does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                        _leaderRecoveryState = value;
                    }
                }

                /// <summary>
                /// <para>1 if the partition is recovering from an unclean leader election; 0 otherwise.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: 0</para>
                /// </summary>
                public PartitionData WithLeaderRecoveryState(Int8 leaderRecoveryState)
                {
                    LeaderRecoveryState = leaderRecoveryState;
                    return this;
                }

                private Int32 _partitionEpoch = Int32.Default;
                /// <summary>
                /// <para>The expected epoch of the partition which is being updated. For legacy cluster this is the ZkVersion in the LeaderAndIsr request.</para>
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
                /// <para>The expected epoch of the partition which is being updated. For legacy cluster this is the ZkVersion in the LeaderAndIsr request.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithPartitionEpoch(Int32 partitionEpoch)
                {
                    PartitionEpoch = partitionEpoch;
                    return this;
                }
            }
        }

        public AlterPartitionResponse Respond() => new AlterPartitionResponse(Version);
    }
}
