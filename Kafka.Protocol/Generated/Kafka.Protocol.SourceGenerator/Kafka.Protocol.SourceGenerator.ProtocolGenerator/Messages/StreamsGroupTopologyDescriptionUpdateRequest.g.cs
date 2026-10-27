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
    public class StreamsGroupTopologyDescriptionUpdateRequest : Message, IRespond<StreamsGroupTopologyDescriptionUpdateResponse>
    {
        public StreamsGroupTopologyDescriptionUpdateRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"StreamsGroupTopologyDescriptionUpdateRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(93);
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

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + _memberId.GetSize(IsFlexibleVersion) + _topologyEpoch.GetSize(IsFlexibleVersion) + _topologyDescription.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<StreamsGroupTopologyDescriptionUpdateRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new StreamsGroupTopologyDescriptionUpdateRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopologyEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopologyDescription_ = await TopologyDescription.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for StreamsGroupTopologyDescriptionUpdateRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topologyEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topologyDescription.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _groupId = String.Default;
        /// <summary>
        /// <para>The streams group identifier.</para>
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
        /// <para>The streams group identifier.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupTopologyDescriptionUpdateRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The ID of the streams group member sending the push. The broker validates that this member is still in the group; mismatches (including when the group itself has been deleted) are rejected with UNKNOWN_MEMBER_ID so the client treats itself as fenced and rejoins.</para>
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
        /// <para>The ID of the streams group member sending the push. The broker validates that this member is still in the group; mismatches (including when the group itself has been deleted) are rejected with UNKNOWN_MEMBER_ID so the client treats itself as fenced and rejoins.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupTopologyDescriptionUpdateRequest WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private Int32 _topologyEpoch = Int32.Default;
        /// <summary>
        /// <para>The epoch of the topology being described.</para>
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
        /// <para>The epoch of the topology being described.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupTopologyDescriptionUpdateRequest WithTopologyEpoch(Int32 topologyEpoch)
        {
            TopologyEpoch = topologyEpoch;
            return this;
        }

        private TopologyDescription _topologyDescription = default!;
        /// <summary>
        /// <para>The topology description.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public TopologyDescription TopologyDescription_
        {
            get => _topologyDescription;
            private set
            {
                _topologyDescription = value;
            }
        }

        /// <summary>
        /// <para>The topology description.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupTopologyDescriptionUpdateRequest WithTopologyDescription_(TopologyDescription topologyDescription)
        {
            TopologyDescription_ = topologyDescription;
            return this;
        }

        public class TopologyDescription : ISerialize
        {
            internal TopologyDescription(Int16 version)
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
            internal int GetSize(bool _) => _subtopologiesCollection.GetSize(IsFlexibleVersion) + _globalStoresCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopologyDescription> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopologyDescription(version);
                instance.SubtopologiesCollection = await Array<TopologyDescriptionSubtopology>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopologyDescriptionSubtopology.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.GlobalStoresCollection = await Array<TopologyDescriptionGlobalStore>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopologyDescriptionGlobalStore.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopologyDescription is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _subtopologiesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _globalStoresCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Array<TopologyDescriptionSubtopology> _subtopologiesCollection = Array.Empty<TopologyDescriptionSubtopology>();
            /// <summary>
            /// <para>The subtopologies that make up this topology.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TopologyDescriptionSubtopology> SubtopologiesCollection
            {
                get => _subtopologiesCollection;
                private set
                {
                    _subtopologiesCollection = value;
                }
            }

            /// <summary>
            /// <para>The subtopologies that make up this topology.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescription WithSubtopologiesCollection(Array<TopologyDescriptionSubtopology> subtopologiesCollection)
            {
                SubtopologiesCollection = subtopologiesCollection;
                return this;
            }

            private Array<TopologyDescriptionGlobalStore> _globalStoresCollection = Array.Empty<TopologyDescriptionGlobalStore>();
            /// <summary>
            /// <para>Global state stores used by this topology.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TopologyDescriptionGlobalStore> GlobalStoresCollection
            {
                get => _globalStoresCollection;
                private set
                {
                    _globalStoresCollection = value;
                }
            }

            /// <summary>
            /// <para>Global state stores used by this topology.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescription WithGlobalStoresCollection(Array<TopologyDescriptionGlobalStore> globalStoresCollection)
            {
                GlobalStoresCollection = globalStoresCollection;
                return this;
            }
        }

        public class TopologyDescriptionSubtopology : ISerialize
        {
            internal TopologyDescriptionSubtopology(Int16 version)
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
            internal int GetSize(bool _) => _subtopologyId.GetSize(IsFlexibleVersion) + _nodesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopologyDescriptionSubtopology> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopologyDescriptionSubtopology(version);
                instance.SubtopologyId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.NodesCollection = await Array<TopologyDescriptionNode>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopologyDescriptionNode.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopologyDescriptionSubtopology is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _subtopologyId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _nodesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _subtopologyId = String.Default;
            /// <summary>
            /// <para>The subtopology identifier, unique within the topology.</para>
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
            /// <para>The subtopology identifier, unique within the topology.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionSubtopology WithSubtopologyId(String subtopologyId)
            {
                SubtopologyId = subtopologyId;
                return this;
            }

            private Array<TopologyDescriptionNode> _nodesCollection = Array.Empty<TopologyDescriptionNode>();
            /// <summary>
            /// <para>The processing nodes in this subtopology.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TopologyDescriptionNode> NodesCollection
            {
                get => _nodesCollection;
                private set
                {
                    _nodesCollection = value;
                }
            }

            /// <summary>
            /// <para>The processing nodes in this subtopology.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionSubtopology WithNodesCollection(Array<TopologyDescriptionNode> nodesCollection)
            {
                NodesCollection = nodesCollection;
                return this;
            }
        }

        public class TopologyDescriptionNode : ISerialize
        {
            internal TopologyDescriptionNode(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _nodeType.GetSize(IsFlexibleVersion) + _sourceTopicsCollection.GetSize(IsFlexibleVersion) + _sinkTopic.GetSize(IsFlexibleVersion) + _storesCollection.GetSize(IsFlexibleVersion) + _successorsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopologyDescriptionNode> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopologyDescriptionNode(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.NodeType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.SourceTopicsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.SinkTopic = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.StoresCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.SuccessorsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopologyDescriptionNode is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _nodeType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _sourceTopicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _sinkTopic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _storesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _successorsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The name of this node (e.g., KSTREAM-SOURCE-0000000000).</para>
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
            /// <para>The name of this node (e.g., KSTREAM-SOURCE-0000000000).</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionNode WithName(String name)
            {
                Name = name;
                return this;
            }

            private Int8 _nodeType = Int8.Default;
            /// <summary>
            /// <para>The type of this node: 1=SOURCE, 2=PROCESSOR, 3=SINK.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int8 NodeType
            {
                get => _nodeType;
                private set
                {
                    _nodeType = value;
                }
            }

            /// <summary>
            /// <para>The type of this node: 1=SOURCE, 2=PROCESSOR, 3=SINK.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionNode WithNodeType(Int8 nodeType)
            {
                NodeType = nodeType;
                return this;
            }

            private Array<String> _sourceTopicsCollection = Array.Empty<String>();
            /// <summary>
            /// <para>The source topics this node reads from. Defined only for source nodes, may be empty if source topics are dynamically determined.</para>
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
            /// <para>The source topics this node reads from. Defined only for source nodes, may be empty if source topics are dynamically determined.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionNode WithSourceTopicsCollection(Array<String> sourceTopicsCollection)
            {
                SourceTopicsCollection = sourceTopicsCollection;
                return this;
            }

            private NullableString _sinkTopic = new NullableString(null);
            /// <summary>
            /// <para>The topic this node writes to. Defined only for sink nodes, may be null if sink topic is dynamically determined.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? SinkTopic
            {
                get => _sinkTopic;
                private set
                {
                    _sinkTopic = value;
                }
            }

            /// <summary>
            /// <para>The topic this node writes to. Defined only for sink nodes, may be null if sink topic is dynamically determined.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public TopologyDescriptionNode WithSinkTopic(String? sinkTopic)
            {
                SinkTopic = sinkTopic;
                return this;
            }

            private Array<String> _storesCollection = Array.Empty<String>();
            /// <summary>
            /// <para>The state store names accessed by this node. Defined only for processor nodes.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<String> StoresCollection
            {
                get => _storesCollection;
                private set
                {
                    _storesCollection = value;
                }
            }

            /// <summary>
            /// <para>The state store names accessed by this node. Defined only for processor nodes.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionNode WithStoresCollection(Array<String> storesCollection)
            {
                StoresCollection = storesCollection;
                return this;
            }

            private Array<String> _successorsCollection = Array.Empty<String>();
            /// <summary>
            /// <para>The names of successor nodes in the processing graph. Predecessor relationships are reconstructed from this field.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<String> SuccessorsCollection
            {
                get => _successorsCollection;
                private set
                {
                    _successorsCollection = value;
                }
            }

            /// <summary>
            /// <para>The names of successor nodes in the processing graph. Predecessor relationships are reconstructed from this field.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionNode WithSuccessorsCollection(Array<String> successorsCollection)
            {
                SuccessorsCollection = successorsCollection;
                return this;
            }
        }

        public class TopologyDescriptionGlobalStore : ISerialize
        {
            internal TopologyDescriptionGlobalStore(Int16 version)
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
            internal int GetSize(bool _) => _source.GetSize(IsFlexibleVersion) + _processor.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopologyDescriptionGlobalStore> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopologyDescriptionGlobalStore(version);
                instance.Source = await TopologyDescriptionNode.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                instance.Processor = await TopologyDescriptionNode.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopologyDescriptionGlobalStore is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _source.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _processor.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private TopologyDescriptionNode _source = default!;
            /// <summary>
            /// <para>The source node providing data to the global store.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionNode Source
            {
                get => _source;
                private set
                {
                    _source = value;
                }
            }

            /// <summary>
            /// <para>The source node providing data to the global store.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionGlobalStore WithSource(TopologyDescriptionNode source)
            {
                Source = source;
                return this;
            }

            private TopologyDescriptionNode _processor = default!;
            /// <summary>
            /// <para>The processor node that populates the global store.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionNode Processor
            {
                get => _processor;
                private set
                {
                    _processor = value;
                }
            }

            /// <summary>
            /// <para>The processor node that populates the global store.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopologyDescriptionGlobalStore WithProcessor(TopologyDescriptionNode processor)
            {
                Processor = processor;
                return this;
            }
        }

        public StreamsGroupTopologyDescriptionUpdateResponse Respond() => new StreamsGroupTopologyDescriptionUpdateResponse(Version);
    }
}
