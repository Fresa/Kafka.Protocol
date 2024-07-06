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
    public class DescribeQuorumResponse : Message
    {
        public DescribeQuorumResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeQuorumResponse does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(55);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(2);
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

        internal override int GetSize() => _errorCode.GetSize(IsFlexibleVersion) + (Version >= 2 ? _errorMessage.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (Version >= 2 ? _nodesCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeQuorumResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeQuorumResponse(version);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2)
                instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<TopicData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2)
                instance.NodesCollection = await Map<Int32, Node>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Node.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.NodeId, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeQuorumResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 2)
                await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 2)
                await _nodesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The top level error code.</para>
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
        /// <para>The top level error code.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeQuorumResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private NullableString _errorMessage = NullableString.Default;
        /// <summary>
        /// <para>The error message, or null if there was no error.</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public String? ErrorMessage
        {
            get => _errorMessage;
            private set
            {
                if (Version >= 2 == false && value == null)
                    throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 2+");
                _errorMessage = value;
            }
        }

        /// <summary>
        /// <para>The error message, or null if there was no error.</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public DescribeQuorumResponse WithErrorMessage(String? errorMessage)
        {
            ErrorMessage = errorMessage;
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
        public DescribeQuorumResponse WithTopicsCollection(params Func<TopicData, TopicData>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicData(Version))).ToArray();
            return this;
        }

        public delegate TopicData CreateTopicData(TopicData field);
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeQuorumResponse WithTopicsCollection(IEnumerable<CreateTopicData> createFields)
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
            internal int GetSize(bool _) => _topicName.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicData(version);
                instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
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
            public TopicData WithTopicName(String topicName)
            {
                TopicName = topicName;
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + (Version >= 2 ? _errorMessage.GetSize(IsFlexibleVersion) : 0) + _leaderId.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + _highWatermark.GetSize(IsFlexibleVersion) + _currentVotersCollection.GetSize(IsFlexibleVersion) + _observersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionData(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 2)
                        instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.HighWatermark = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.CurrentVotersCollection = await Array<ReplicaState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ReplicaState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.ObserversCollection = await Array<ReplicaState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ReplicaState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
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
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 2)
                        await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _highWatermark.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _currentVotersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _observersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
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
                public PartitionData WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
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
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private NullableString _errorMessage = NullableString.Default;
                /// <summary>
                /// <para>The error message, or null if there was no error.</para>
                /// <para>Versions: 2+</para>
                /// </summary>
                public String? ErrorMessage
                {
                    get => _errorMessage;
                    private set
                    {
                        if (Version >= 2 == false && value == null)
                            throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 2+");
                        _errorMessage = value;
                    }
                }

                /// <summary>
                /// <para>The error message, or null if there was no error.</para>
                /// <para>Versions: 2+</para>
                /// </summary>
                public PartitionData WithErrorMessage(String? errorMessage)
                {
                    ErrorMessage = errorMessage;
                    return this;
                }

                private Int32 _leaderId = Int32.Default;
                /// <summary>
                /// <para>The ID of the current leader or -1 if the leader is unknown.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 LeaderId
                {
                    get => _leaderId;
                    private set
                    {
                        _leaderId = value;
                    }
                }

                /// <summary>
                /// <para>The ID of the current leader or -1 if the leader is unknown.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithLeaderId(Int32 leaderId)
                {
                    LeaderId = leaderId;
                    return this;
                }

                private Int32 _leaderEpoch = Int32.Default;
                /// <summary>
                /// <para>The latest known leader epoch</para>
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
                /// <para>The latest known leader epoch</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }

                private Int64 _highWatermark = Int64.Default;
                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 HighWatermark
                {
                    get => _highWatermark;
                    private set
                    {
                        _highWatermark = value;
                    }
                }

                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithHighWatermark(Int64 highWatermark)
                {
                    HighWatermark = highWatermark;
                    return this;
                }

                private Array<ReplicaState> _currentVotersCollection = Array.Empty<ReplicaState>();
                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<ReplicaState> CurrentVotersCollection
                {
                    get => _currentVotersCollection;
                    private set
                    {
                        _currentVotersCollection = value;
                    }
                }

                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithCurrentVotersCollection(Array<ReplicaState> currentVotersCollection)
                {
                    CurrentVotersCollection = currentVotersCollection;
                    return this;
                }

                private Array<ReplicaState> _observersCollection = Array.Empty<ReplicaState>();
                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<ReplicaState> ObserversCollection
                {
                    get => _observersCollection;
                    private set
                    {
                        _observersCollection = value;
                    }
                }

                /// <summary>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithObserversCollection(Array<ReplicaState> observersCollection)
                {
                    ObserversCollection = observersCollection;
                    return this;
                }
            }
        }

        private Map<Int32, Node> _nodesCollection = Map<Int32, Node>.Default;
        /// <summary>
        /// <para>Versions: 2+</para>
        /// </summary>
        public Map<Int32, Node> NodesCollection
        {
            get => _nodesCollection;
            private set
            {
                if (Version >= 2 == false)
                    throw new UnsupportedVersionException($"NodesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                _nodesCollection = value;
            }
        }

        /// <summary>
        /// <para>Versions: 2+</para>
        /// </summary>
        public DescribeQuorumResponse WithNodesCollection(params Func<Node, Node>[] createFields)
        {
            NodesCollection = createFields.Select(createField => createField(new Node(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public delegate Node CreateNode(Node field);
        /// <summary>
        /// <para>Versions: 2+</para>
        /// </summary>
        public DescribeQuorumResponse WithNodesCollection(IEnumerable<CreateNode> createFields)
        {
            NodesCollection = createFields.Select(createField => createField(new Node(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public class Node : ISerialize
        {
            internal Node(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 2 ? _nodeId.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 ? _listenersCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Node> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Node(version);
                if (instance.Version >= 2)
                    instance.NodeId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 2)
                    instance.ListenersCollection = await Map<String, Listener>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Listener.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Node is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 2)
                    await _nodeId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 2)
                    await _listenersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _nodeId = Int32.Default;
            /// <summary>
            /// <para>The ID of the associated node</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public Int32 NodeId
            {
                get => _nodeId;
                private set
                {
                    if (Version >= 2 == false)
                        throw new UnsupportedVersionException($"NodeId does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                    _nodeId = value;
                }
            }

            /// <summary>
            /// <para>The ID of the associated node</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public Node WithNodeId(Int32 nodeId)
            {
                NodeId = nodeId;
                return this;
            }

            private Map<String, Listener> _listenersCollection = Map<String, Listener>.Default;
            /// <summary>
            /// <para>The listeners of this controller</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public Map<String, Listener> ListenersCollection
            {
                get => _listenersCollection;
                private set
                {
                    if (Version >= 2 == false)
                        throw new UnsupportedVersionException($"ListenersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                    _listenersCollection = value;
                }
            }

            /// <summary>
            /// <para>The listeners of this controller</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public Node WithListenersCollection(params Func<Listener, Listener>[] createFields)
            {
                ListenersCollection = createFields.Select(createField => createField(new Listener(Version))).ToDictionary(field => field.Name);
                return this;
            }

            public delegate Listener CreateListener(Listener field);
            /// <summary>
            /// <para>The listeners of this controller</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public Node WithListenersCollection(IEnumerable<CreateListener> createFields)
            {
                ListenersCollection = createFields.Select(createField => createField(new Listener(Version))).ToDictionary(field => field.Name);
                return this;
            }

            public class Listener : ISerialize
            {
                internal Listener(Int16 version)
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
                internal int GetSize(bool _) => (Version >= 2 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 ? _host.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 ? _port.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<Listener> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new Listener(version);
                    if (instance.Version >= 2)
                        instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 2)
                        instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 2)
                        instance.Port = await UInt16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for Listener is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    if (Version >= 2)
                        await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 2)
                        await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 2)
                        await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private String _name = String.Default;
                /// <summary>
                /// <para>The name of the endpoint</para>
                /// <para>Versions: 2+</para>
                /// </summary>
                public String Name
                {
                    get => _name;
                    private set
                    {
                        if (Version >= 2 == false)
                            throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                        _name = value;
                    }
                }

                /// <summary>
                /// <para>The name of the endpoint</para>
                /// <para>Versions: 2+</para>
                /// </summary>
                public Listener WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private String _host = String.Default;
                /// <summary>
                /// <para>The hostname</para>
                /// <para>Versions: 2+</para>
                /// </summary>
                public String Host
                {
                    get => _host;
                    private set
                    {
                        if (Version >= 2 == false)
                            throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                        _host = value;
                    }
                }

                /// <summary>
                /// <para>The hostname</para>
                /// <para>Versions: 2+</para>
                /// </summary>
                public Listener WithHost(String host)
                {
                    Host = host;
                    return this;
                }

                private UInt16 _port = UInt16.Default;
                /// <summary>
                /// <para>The port</para>
                /// <para>Versions: 2+</para>
                /// </summary>
                public UInt16 Port
                {
                    get => _port;
                    private set
                    {
                        if (Version >= 2 == false)
                            throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                        _port = value;
                    }
                }

                /// <summary>
                /// <para>The port</para>
                /// <para>Versions: 2+</para>
                /// </summary>
                public Listener WithPort(UInt16 port)
                {
                    Port = port;
                    return this;
                }
            }
        }

        public class ReplicaState : ISerialize
        {
            internal ReplicaState(Int16 version)
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
            internal int GetSize(bool _) => _replicaId.GetSize(IsFlexibleVersion) + (Version >= 2 ? _replicaDirectoryId.GetSize(IsFlexibleVersion) : 0) + _logEndOffset.GetSize(IsFlexibleVersion) + (Version >= 1 ? _lastFetchTimestamp.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _lastCaughtUpTimestamp.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ReplicaState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ReplicaState(version);
                instance.ReplicaId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 2)
                    instance.ReplicaDirectoryId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.LogEndOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.LastFetchTimestamp = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.LastCaughtUpTimestamp = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ReplicaState is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _replicaId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 2)
                    await _replicaDirectoryId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _logEndOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _lastFetchTimestamp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _lastCaughtUpTimestamp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _replicaId = Int32.Default;
            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 ReplicaId
            {
                get => _replicaId;
                private set
                {
                    _replicaId = value;
                }
            }

            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ReplicaState WithReplicaId(Int32 replicaId)
            {
                ReplicaId = replicaId;
                return this;
            }

            private Uuid _replicaDirectoryId = Uuid.Default;
            /// <summary>
            /// <para>Versions: 2+</para>
            /// </summary>
            public Uuid ReplicaDirectoryId
            {
                get => _replicaDirectoryId;
                private set
                {
                    if (Version >= 2 == false)
                        throw new UnsupportedVersionException($"ReplicaDirectoryId does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                    _replicaDirectoryId = value;
                }
            }

            /// <summary>
            /// <para>Versions: 2+</para>
            /// </summary>
            public ReplicaState WithReplicaDirectoryId(Uuid replicaDirectoryId)
            {
                ReplicaDirectoryId = replicaDirectoryId;
                return this;
            }

            private Int64 _logEndOffset = Int64.Default;
            /// <summary>
            /// <para>The last known log end offset of the follower or -1 if it is unknown</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int64 LogEndOffset
            {
                get => _logEndOffset;
                private set
                {
                    _logEndOffset = value;
                }
            }

            /// <summary>
            /// <para>The last known log end offset of the follower or -1 if it is unknown</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ReplicaState WithLogEndOffset(Int64 logEndOffset)
            {
                LogEndOffset = logEndOffset;
                return this;
            }

            private Int64 _lastFetchTimestamp = new Int64(-1);
            /// <summary>
            /// <para>The last known leader wall clock time time when a follower fetched from the leader. This is reported as -1 both for the current leader or if it is unknown for a voter</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public Int64 LastFetchTimestamp
            {
                get => _lastFetchTimestamp;
                private set
                {
                    _lastFetchTimestamp = value;
                }
            }

            /// <summary>
            /// <para>The last known leader wall clock time time when a follower fetched from the leader. This is reported as -1 both for the current leader or if it is unknown for a voter</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public ReplicaState WithLastFetchTimestamp(Int64 lastFetchTimestamp)
            {
                LastFetchTimestamp = lastFetchTimestamp;
                return this;
            }

            private Int64 _lastCaughtUpTimestamp = new Int64(-1);
            /// <summary>
            /// <para>The leader wall clock append time of the offset for which the follower made the most recent fetch request. This is reported as the current time for the leader and -1 if unknown for a voter</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public Int64 LastCaughtUpTimestamp
            {
                get => _lastCaughtUpTimestamp;
                private set
                {
                    _lastCaughtUpTimestamp = value;
                }
            }

            /// <summary>
            /// <para>The leader wall clock append time of the offset for which the follower made the most recent fetch request. This is reported as the current time for the leader and -1 if unknown for a voter</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public ReplicaState WithLastCaughtUpTimestamp(Int64 lastCaughtUpTimestamp)
            {
                LastCaughtUpTimestamp = lastCaughtUpTimestamp;
                return this;
            }
        }
    }
}
