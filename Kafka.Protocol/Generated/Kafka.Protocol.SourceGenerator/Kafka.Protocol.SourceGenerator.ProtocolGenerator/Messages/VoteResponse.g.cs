﻿#nullable enable
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
    public class VoteResponse : Message
    {
        public VoteResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"VoteResponse does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(52);
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
            var tags = new List<Tags.TaggedField>();
            if (Version >= 1 && _nodeEndpointsCollectionIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 0, Field = _nodeEndpointsCollection });
            }

            return new Tags.TagSection(tags.ToArray());
        }

        internal override int GetSize() => _errorCode.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<VoteResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new VoteResponse(version);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<TopicData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        case 0:
                            if (instance.Version >= 1)
                                instance.NodeEndpointsCollection = await Map<Int32, NodeEndpoint>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => NodeEndpoint.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.NodeId, cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field NodeEndpointsCollection is not supported for version {instance.Version}");
                        {
                            var size = instance._nodeEndpointsCollection.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field NodeEndpointsCollection read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for VoteResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public VoteResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<TopicData> _topicsCollection = Array.Empty<TopicData>();
        /// <summary>
        /// <para>The results for each topic.</para>
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
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public VoteResponse WithTopicsCollection(params Func<TopicData, TopicData>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicData(Version))).ToArray();
            return this;
        }

        public delegate TopicData CreateTopicData(TopicData field);
        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public VoteResponse WithTopicsCollection(IEnumerable<CreateTopicData> createFields)
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
            /// <para>The results for each partition.</para>
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
            /// <para>The results for each partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicData WithPartitionsCollection(params Func<PartitionData, PartitionData>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new PartitionData(Version))).ToArray();
                return this;
            }

            public delegate PartitionData CreatePartitionData(PartitionData field);
            /// <summary>
            /// <para>The results for each partition.</para>
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _leaderId.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + _voteGranted.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionData(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.VoteGranted = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                    await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _voteGranted.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                /// <para>The partition level error code.</para>
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
                /// <para>The partition level error code.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
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
                /// <para>The latest known leader epoch.</para>
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
                /// <para>The latest known leader epoch.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }

                private Boolean _voteGranted = Boolean.Default;
                /// <summary>
                /// <para>True if the vote was granted and false otherwise.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Boolean VoteGranted
                {
                    get => _voteGranted;
                    private set
                    {
                        _voteGranted = value;
                    }
                }

                /// <summary>
                /// <para>True if the vote was granted and false otherwise.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithVoteGranted(Boolean voteGranted)
                {
                    VoteGranted = voteGranted;
                    return this;
                }
            }
        }

        private bool _nodeEndpointsCollectionIsSet;
        private Map<Int32, NodeEndpoint> _nodeEndpointsCollection = Map<Int32, NodeEndpoint>.Default;
        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionData.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public Map<Int32, NodeEndpoint> NodeEndpointsCollection
        {
            get => _nodeEndpointsCollection;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"NodeEndpointsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _nodeEndpointsCollection = value;
                _nodeEndpointsCollectionIsSet = true;
            }
        }

        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionData.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public VoteResponse WithNodeEndpointsCollection(params Func<NodeEndpoint, NodeEndpoint>[] createFields)
        {
            NodeEndpointsCollection = createFields.Select(createField => createField(new NodeEndpoint(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public delegate NodeEndpoint CreateNodeEndpoint(NodeEndpoint field);
        /// <summary>
        /// <para>Endpoints for all current-leaders enumerated in PartitionData.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public VoteResponse WithNodeEndpointsCollection(IEnumerable<CreateNodeEndpoint> createFields)
        {
            NodeEndpointsCollection = createFields.Select(createField => createField(new NodeEndpoint(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public class NodeEndpoint : ISerialize
        {
            internal NodeEndpoint(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 1 ? _nodeId.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _host.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _port.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<NodeEndpoint> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new NodeEndpoint(version);
                if (instance.Version >= 1)
                    instance.NodeId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.Port = await UInt16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for NodeEndpoint is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 1)
                    await _nodeId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _nodeId = Int32.Default;
            /// <summary>
            /// <para>The ID of the associated node.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public Int32 NodeId
            {
                get => _nodeId;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"NodeId does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _nodeId = value;
                }
            }

            /// <summary>
            /// <para>The ID of the associated node.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public NodeEndpoint WithNodeId(Int32 nodeId)
            {
                NodeId = nodeId;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The node's hostname.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public String Host
            {
                get => _host;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _host = value;
                }
            }

            /// <summary>
            /// <para>The node's hostname.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public NodeEndpoint WithHost(String host)
            {
                Host = host;
                return this;
            }

            private UInt16 _port = UInt16.Default;
            /// <summary>
            /// <para>The node's port.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public UInt16 Port
            {
                get => _port;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _port = value;
                }
            }

            /// <summary>
            /// <para>The node's port.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public NodeEndpoint WithPort(UInt16 port)
            {
                Port = port;
                return this;
            }
        }
    }
}
