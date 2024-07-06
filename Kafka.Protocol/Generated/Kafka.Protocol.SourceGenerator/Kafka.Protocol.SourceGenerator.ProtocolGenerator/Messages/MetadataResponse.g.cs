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
    public class MetadataResponse : Message
    {
        public MetadataResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"MetadataResponse does not support version {version}. Valid versions are: 0-12");
            Version = version;
            IsFlexibleVersion = version >= 9;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(3);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(12);
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

        internal override int GetSize() => (Version >= 3 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + _brokersCollection.GetSize(IsFlexibleVersion) + (Version >= 2 ? _clusterId.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _controllerId.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (Version >= 8 && Version <= 10 ? _clusterAuthorizedOperations.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<MetadataResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new MetadataResponse(version);
            if (instance.Version >= 3)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.BrokersCollection = await Map<Int32, MetadataResponseBroker>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => MetadataResponseBroker.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.NodeId, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2)
                instance.ClusterId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.ControllerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Map<NullableString, MetadataResponseTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => MetadataResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 8 && instance.Version <= 10)
                instance.ClusterAuthorizedOperations = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for MetadataResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 3)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _brokersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 2)
                await _clusterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _controllerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 8 && Version <= 10)
                await _clusterAuthorizedOperations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 3+</para>
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
        /// <para>Versions: 3+</para>
        /// </summary>
        public MetadataResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Map<Int32, MetadataResponseBroker> _brokersCollection = Map<Int32, MetadataResponseBroker>.Default;
        /// <summary>
        /// <para>A list of brokers present in the cluster.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<Int32, MetadataResponseBroker> BrokersCollection
        {
            get => _brokersCollection;
            private set
            {
                _brokersCollection = value;
            }
        }

        /// <summary>
        /// <para>A list of brokers present in the cluster.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public MetadataResponse WithBrokersCollection(params Func<MetadataResponseBroker, MetadataResponseBroker>[] createFields)
        {
            BrokersCollection = createFields.Select(createField => createField(new MetadataResponseBroker(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public delegate MetadataResponseBroker CreateMetadataResponseBroker(MetadataResponseBroker field);
        /// <summary>
        /// <para>A list of brokers present in the cluster.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public MetadataResponse WithBrokersCollection(IEnumerable<CreateMetadataResponseBroker> createFields)
        {
            BrokersCollection = createFields.Select(createField => createField(new MetadataResponseBroker(Version))).ToDictionary(field => field.NodeId);
            return this;
        }

        public class MetadataResponseBroker : ISerialize
        {
            internal MetadataResponseBroker(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 9;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _nodeId.GetSize(IsFlexibleVersion) + _host.GetSize(IsFlexibleVersion) + _port.GetSize(IsFlexibleVersion) + (Version >= 1 ? _rack.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<MetadataResponseBroker> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new MetadataResponseBroker(version);
                instance.NodeId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Port = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.Rack = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for MetadataResponseBroker is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _nodeId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _rack.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _nodeId = Int32.Default;
            /// <summary>
            /// <para>The broker ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 NodeId
            {
                get => _nodeId;
                private set
                {
                    _nodeId = value;
                }
            }

            /// <summary>
            /// <para>The broker ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public MetadataResponseBroker WithNodeId(Int32 nodeId)
            {
                NodeId = nodeId;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The broker hostname.</para>
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
            /// <para>The broker hostname.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public MetadataResponseBroker WithHost(String host)
            {
                Host = host;
                return this;
            }

            private Int32 _port = Int32.Default;
            /// <summary>
            /// <para>The broker port.</para>
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
            /// <para>The broker port.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public MetadataResponseBroker WithPort(Int32 port)
            {
                Port = port;
                return this;
            }

            private NullableString _rack = new NullableString(null);
            /// <summary>
            /// <para>The rack of the broker, or null if it has not been assigned to a rack.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? Rack
            {
                get => _rack;
                private set
                {
                    if (Version >= 1 == false && value == null)
                        throw new UnsupportedVersionException($"Rack does not support null for version {Version}. Supported versions for null value: 1+");
                    _rack = value;
                }
            }

            /// <summary>
            /// <para>The rack of the broker, or null if it has not been assigned to a rack.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: null</para>
            /// </summary>
            public MetadataResponseBroker WithRack(String? rack)
            {
                Rack = rack;
                return this;
            }
        }

        private NullableString _clusterId = new NullableString(null);
        /// <summary>
        /// <para>The cluster ID that responding broker belongs to.</para>
        /// <para>Versions: 2+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ClusterId
        {
            get => _clusterId;
            private set
            {
                if (Version >= 2 == false && value == null)
                    throw new UnsupportedVersionException($"ClusterId does not support null for version {Version}. Supported versions for null value: 2+");
                _clusterId = value;
            }
        }

        /// <summary>
        /// <para>The cluster ID that responding broker belongs to.</para>
        /// <para>Versions: 2+</para>
        /// <para>Default: null</para>
        /// </summary>
        public MetadataResponse WithClusterId(String? clusterId)
        {
            ClusterId = clusterId;
            return this;
        }

        private Int32 _controllerId = new Int32(-1);
        /// <summary>
        /// <para>The ID of the controller broker.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
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
        /// <para>The ID of the controller broker.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public MetadataResponse WithControllerId(Int32 controllerId)
        {
            ControllerId = controllerId;
            return this;
        }

        private Map<NullableString, MetadataResponseTopic> _topicsCollection = Map<NullableString, MetadataResponseTopic>.Default;
        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<NullableString, MetadataResponseTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public MetadataResponse WithTopicsCollection(params Func<MetadataResponseTopic, MetadataResponseTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new MetadataResponseTopic(Version))).ToDictionary(field => (NullableString)field.Name);
            return this;
        }

        public delegate MetadataResponseTopic CreateMetadataResponseTopic(MetadataResponseTopic field);
        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public MetadataResponse WithTopicsCollection(IEnumerable<CreateMetadataResponseTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new MetadataResponseTopic(Version))).ToDictionary(field => (NullableString)field.Name);
            return this;
        }

        public class MetadataResponseTopic : ISerialize
        {
            internal MetadataResponseTopic(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 9;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _name.GetSize(IsFlexibleVersion) + (Version >= 10 ? _topicId.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _isInternal.GetSize(IsFlexibleVersion) : 0) + _partitionsCollection.GetSize(IsFlexibleVersion) + (Version >= 8 ? _topicAuthorizedOperations.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<MetadataResponseTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new MetadataResponseTopic(version);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Name = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 10)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.IsInternal = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<MetadataResponsePartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => MetadataResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 8)
                    instance.TopicAuthorizedOperations = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for MetadataResponseTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 10)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _isInternal.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 8)
                    await _topicAuthorizedOperations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The topic error, or 0 if there was no error.</para>
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
            /// <para>The topic error, or 0 if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public MetadataResponseTopic WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _name = NullableString.Default;
            /// <summary>
            /// <para>The topic name. Null for non-existing topics queried by ID. This is never null when ErrorCode is zero. One of Name and TopicId is always populated.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String? Name
            {
                get => _name;
                private set
                {
                    if (Version >= 12 == false && value == null)
                        throw new UnsupportedVersionException($"Name does not support null for version {Version}. Supported versions for null value: 12+");
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The topic name. Null for non-existing topics queried by ID. This is never null when ErrorCode is zero. One of Name and TopicId is always populated.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public MetadataResponseTopic WithName(String? name)
            {
                Name = name;
                return this;
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The topic id. Zero for non-existing topics queried by name. This is never zero when ErrorCode is zero. One of Name and TopicId is always populated.</para>
            /// <para>Versions: 10+</para>
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
            /// <para>The topic id. Zero for non-existing topics queried by name. This is never zero when ErrorCode is zero. One of Name and TopicId is always populated.</para>
            /// <para>Versions: 10+</para>
            /// </summary>
            public MetadataResponseTopic WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Boolean _isInternal = new Boolean(false);
            /// <summary>
            /// <para>True if the topic is internal.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: false</para>
            /// </summary>
            public Boolean IsInternal
            {
                get => _isInternal;
                private set
                {
                    _isInternal = value;
                }
            }

            /// <summary>
            /// <para>True if the topic is internal.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: false</para>
            /// </summary>
            public MetadataResponseTopic WithIsInternal(Boolean isInternal)
            {
                IsInternal = isInternal;
                return this;
            }

            private Array<MetadataResponsePartition> _partitionsCollection = Array.Empty<MetadataResponsePartition>();
            /// <summary>
            /// <para>Each partition in the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<MetadataResponsePartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition in the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public MetadataResponseTopic WithPartitionsCollection(params Func<MetadataResponsePartition, MetadataResponsePartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new MetadataResponsePartition(Version))).ToArray();
                return this;
            }

            public delegate MetadataResponsePartition CreateMetadataResponsePartition(MetadataResponsePartition field);
            /// <summary>
            /// <para>Each partition in the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public MetadataResponseTopic WithPartitionsCollection(IEnumerable<CreateMetadataResponsePartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new MetadataResponsePartition(Version))).ToArray();
                return this;
            }

            public class MetadataResponsePartition : ISerialize
            {
                internal MetadataResponsePartition(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 9;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _partitionIndex.GetSize(IsFlexibleVersion) + _leaderId.GetSize(IsFlexibleVersion) + (Version >= 7 ? _leaderEpoch.GetSize(IsFlexibleVersion) : 0) + _replicaNodesCollection.GetSize(IsFlexibleVersion) + _isrNodesCollection.GetSize(IsFlexibleVersion) + (Version >= 5 ? _offlineReplicasCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<MetadataResponsePartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new MetadataResponsePartition(version);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 7)
                        instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ReplicaNodesCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.IsrNodesCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 5)
                        instance.OfflineReplicasCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for MetadataResponsePartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 7)
                        await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _replicaNodesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _isrNodesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 5)
                        await _offlineReplicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The partition error, or 0 if there was no error.</para>
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
                /// <para>The partition error, or 0 if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public MetadataResponsePartition WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
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
                public MetadataResponsePartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int32 _leaderId = Int32.Default;
                /// <summary>
                /// <para>The ID of the leader broker.</para>
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
                /// <para>The ID of the leader broker.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public MetadataResponsePartition WithLeaderId(Int32 leaderId)
                {
                    LeaderId = leaderId;
                    return this;
                }

                private Int32 _leaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>The leader epoch of this partition.</para>
                /// <para>Versions: 7+</para>
                /// <para>Default: -1</para>
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
                /// <para>The leader epoch of this partition.</para>
                /// <para>Versions: 7+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public MetadataResponsePartition WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }

                private Array<Int32> _replicaNodesCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The set of all nodes that host this partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> ReplicaNodesCollection
                {
                    get => _replicaNodesCollection;
                    private set
                    {
                        _replicaNodesCollection = value;
                    }
                }

                /// <summary>
                /// <para>The set of all nodes that host this partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public MetadataResponsePartition WithReplicaNodesCollection(Array<Int32> replicaNodesCollection)
                {
                    ReplicaNodesCollection = replicaNodesCollection;
                    return this;
                }

                private Array<Int32> _isrNodesCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The set of nodes that are in sync with the leader for this partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> IsrNodesCollection
                {
                    get => _isrNodesCollection;
                    private set
                    {
                        _isrNodesCollection = value;
                    }
                }

                /// <summary>
                /// <para>The set of nodes that are in sync with the leader for this partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public MetadataResponsePartition WithIsrNodesCollection(Array<Int32> isrNodesCollection)
                {
                    IsrNodesCollection = isrNodesCollection;
                    return this;
                }

                private Array<Int32> _offlineReplicasCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The set of offline replicas of this partition.</para>
                /// <para>Versions: 5+</para>
                /// </summary>
                public Array<Int32> OfflineReplicasCollection
                {
                    get => _offlineReplicasCollection;
                    private set
                    {
                        _offlineReplicasCollection = value;
                    }
                }

                /// <summary>
                /// <para>The set of offline replicas of this partition.</para>
                /// <para>Versions: 5+</para>
                /// </summary>
                public MetadataResponsePartition WithOfflineReplicasCollection(Array<Int32> offlineReplicasCollection)
                {
                    OfflineReplicasCollection = offlineReplicasCollection;
                    return this;
                }
            }

            private Int32 _topicAuthorizedOperations = new Int32(-2147483648);
            /// <summary>
            /// <para>32-bit bitfield to represent authorized operations for this topic.</para>
            /// <para>Versions: 8+</para>
            /// <para>Default: -2147483648</para>
            /// </summary>
            public Int32 TopicAuthorizedOperations
            {
                get => _topicAuthorizedOperations;
                private set
                {
                    if (Version >= 8 == false)
                        throw new UnsupportedVersionException($"TopicAuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                    _topicAuthorizedOperations = value;
                }
            }

            /// <summary>
            /// <para>32-bit bitfield to represent authorized operations for this topic.</para>
            /// <para>Versions: 8+</para>
            /// <para>Default: -2147483648</para>
            /// </summary>
            public MetadataResponseTopic WithTopicAuthorizedOperations(Int32 topicAuthorizedOperations)
            {
                TopicAuthorizedOperations = topicAuthorizedOperations;
                return this;
            }
        }

        private Int32 _clusterAuthorizedOperations = new Int32(-2147483648);
        /// <summary>
        /// <para>32-bit bitfield to represent authorized operations for this cluster.</para>
        /// <para>Versions: 8-10</para>
        /// <para>Default: -2147483648</para>
        /// </summary>
        public Int32 ClusterAuthorizedOperations
        {
            get => _clusterAuthorizedOperations;
            private set
            {
                if (Version >= 8 && Version <= 10 == false)
                    throw new UnsupportedVersionException($"ClusterAuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 8-10");
                _clusterAuthorizedOperations = value;
            }
        }

        /// <summary>
        /// <para>32-bit bitfield to represent authorized operations for this cluster.</para>
        /// <para>Versions: 8-10</para>
        /// <para>Default: -2147483648</para>
        /// </summary>
        public MetadataResponse WithClusterAuthorizedOperations(Int32 clusterAuthorizedOperations)
        {
            ClusterAuthorizedOperations = clusterAuthorizedOperations;
            return this;
        }
    }
}
