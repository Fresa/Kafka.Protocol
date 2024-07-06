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
    public class UpdateMetadataRequest : Message, IRespond<UpdateMetadataResponse>
    {
        public UpdateMetadataRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"UpdateMetadataRequest does not support version {version}. Valid versions are: 0-8");
            Version = version;
            IsFlexibleVersion = version >= 6;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(6);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(8);
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
            var tags = new List<Tags.TaggedField>();
            if (Version >= 8 && _typeIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 0, Field = _type });
            }

            return new Tags.TagSection(tags.ToArray());
        }

        internal override int GetSize() => _controllerEpoch.GetSize(IsFlexibleVersion) + (Version >= 5 ? _brokerEpoch.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 4 ? _ungroupedPartitionStatesCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _topicStatesCollection.GetSize(IsFlexibleVersion) : 0) + _liveBrokersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<UpdateMetadataRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new UpdateMetadataRequest(version);
            instance.ControllerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 8)
                instance.IsKRaftController = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ControllerEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 5)
                instance.BrokerEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 4)
                instance.UngroupedPartitionStatesCollection = await Array<UpdateMetadataPartitionState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => UpdateMetadataPartitionState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 5)
                instance.TopicStatesCollection = await Array<UpdateMetadataTopicState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => UpdateMetadataTopicState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.LiveBrokersCollection = await Array<UpdateMetadataBroker>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => UpdateMetadataBroker.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        case 0:
                            if (instance.Version >= 8)
                                instance.Type = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field Type is not supported for version {instance.Version}");
                        {
                            var size = instance._type.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field Type read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for UpdateMetadataRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _controllerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 8)
                await _isKRaftController.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _controllerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 5)
                await _brokerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 4)
                await _ungroupedPartitionStatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 5)
                await _topicStatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _liveBrokersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public UpdateMetadataRequest WithControllerId(Int32 controllerId)
        {
            ControllerId = controllerId;
            return this;
        }

        private Boolean _isKRaftController = new Boolean(false);
        /// <summary>
        /// <para>If KRaft controller id is used during migration. See KIP-866</para>
        /// <para>Versions: 8+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean IsKRaftController
        {
            get => _isKRaftController;
            private set
            {
                if (Version >= 8 == false)
                    throw new UnsupportedVersionException($"IsKRaftController does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                _isKRaftController = value;
            }
        }

        /// <summary>
        /// <para>If KRaft controller id is used during migration. See KIP-866</para>
        /// <para>Versions: 8+</para>
        /// <para>Default: false</para>
        /// </summary>
        public UpdateMetadataRequest WithIsKRaftController(Boolean isKRaftController)
        {
            IsKRaftController = isKRaftController;
            return this;
        }

        private bool _typeIsSet;
        private Int8 _type = new Int8(0);
        /// <summary>
        /// <para>Indicates if this request is a Full metadata snapshot (2), Incremental (1), or Unknown (0). Using during ZK migration, see KIP-866</para>
        /// <para>Versions: 8+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public Int8 Type
        {
            get => _type;
            private set
            {
                if (Version >= 8 == false)
                    throw new UnsupportedVersionException($"Type does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                _type = value;
                _typeIsSet = true;
            }
        }

        /// <summary>
        /// <para>Indicates if this request is a Full metadata snapshot (2), Incremental (1), or Unknown (0). Using during ZK migration, see KIP-866</para>
        /// <para>Versions: 8+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public UpdateMetadataRequest WithType(Int8 type)
        {
            Type = type;
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
        public UpdateMetadataRequest WithControllerEpoch(Int32 controllerEpoch)
        {
            ControllerEpoch = controllerEpoch;
            return this;
        }

        private Int64 _brokerEpoch = new Int64(-1);
        /// <summary>
        /// <para>The broker epoch.</para>
        /// <para>Versions: 5+</para>
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
        /// <para>Versions: 5+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public UpdateMetadataRequest WithBrokerEpoch(Int64 brokerEpoch)
        {
            BrokerEpoch = brokerEpoch;
            return this;
        }

        private Array<UpdateMetadataPartitionState> _ungroupedPartitionStatesCollection = Array.Empty<UpdateMetadataPartitionState>();
        /// <summary>
        /// <para>In older versions of this RPC, each partition that we would like to update.</para>
        /// <para>Versions: 0-4</para>
        /// </summary>
        public Array<UpdateMetadataPartitionState> UngroupedPartitionStatesCollection
        {
            get => _ungroupedPartitionStatesCollection;
            private set
            {
                if (Version >= 0 && Version <= 4 == false)
                    throw new UnsupportedVersionException($"UngroupedPartitionStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-4");
                _ungroupedPartitionStatesCollection = value;
            }
        }

        /// <summary>
        /// <para>In older versions of this RPC, each partition that we would like to update.</para>
        /// <para>Versions: 0-4</para>
        /// </summary>
        public UpdateMetadataRequest WithUngroupedPartitionStatesCollection(Array<UpdateMetadataPartitionState> ungroupedPartitionStatesCollection)
        {
            UngroupedPartitionStatesCollection = ungroupedPartitionStatesCollection;
            return this;
        }

        private Array<UpdateMetadataTopicState> _topicStatesCollection = Array.Empty<UpdateMetadataTopicState>();
        /// <summary>
        /// <para>In newer versions of this RPC, each topic that we would like to update.</para>
        /// <para>Versions: 5+</para>
        /// </summary>
        public Array<UpdateMetadataTopicState> TopicStatesCollection
        {
            get => _topicStatesCollection;
            private set
            {
                if (Version >= 5 == false)
                    throw new UnsupportedVersionException($"TopicStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                _topicStatesCollection = value;
            }
        }

        /// <summary>
        /// <para>In newer versions of this RPC, each topic that we would like to update.</para>
        /// <para>Versions: 5+</para>
        /// </summary>
        public UpdateMetadataRequest WithTopicStatesCollection(params Func<UpdateMetadataTopicState, UpdateMetadataTopicState>[] createFields)
        {
            TopicStatesCollection = createFields.Select(createField => createField(new UpdateMetadataTopicState(Version))).ToArray();
            return this;
        }

        public delegate UpdateMetadataTopicState CreateUpdateMetadataTopicState(UpdateMetadataTopicState field);
        /// <summary>
        /// <para>In newer versions of this RPC, each topic that we would like to update.</para>
        /// <para>Versions: 5+</para>
        /// </summary>
        public UpdateMetadataRequest WithTopicStatesCollection(IEnumerable<CreateUpdateMetadataTopicState> createFields)
        {
            TopicStatesCollection = createFields.Select(createField => createField(new UpdateMetadataTopicState(Version))).ToArray();
            return this;
        }

        public class UpdateMetadataTopicState : ISerialize
        {
            internal UpdateMetadataTopicState(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 6;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 5 ? _topicName.GetSize(IsFlexibleVersion) : 0) + (Version >= 7 ? _topicId.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _partitionStatesCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<UpdateMetadataTopicState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new UpdateMetadataTopicState(version);
                if (instance.Version >= 5)
                    instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 7)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 5)
                    instance.PartitionStatesCollection = await Array<UpdateMetadataPartitionState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => UpdateMetadataPartitionState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for UpdateMetadataTopicState is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 5)
                    await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 7)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 5)
                    await _partitionStatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public String TopicName
            {
                get => _topicName;
                private set
                {
                    if (Version >= 5 == false)
                        throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                    _topicName = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public UpdateMetadataTopicState WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The topic id.</para>
            /// <para>Versions: 7+</para>
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
            /// <para>The topic id.</para>
            /// <para>Versions: 7+</para>
            /// </summary>
            public UpdateMetadataTopicState WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<UpdateMetadataPartitionState> _partitionStatesCollection = Array.Empty<UpdateMetadataPartitionState>();
            /// <summary>
            /// <para>The partition that we would like to update.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public Array<UpdateMetadataPartitionState> PartitionStatesCollection
            {
                get => _partitionStatesCollection;
                private set
                {
                    if (Version >= 5 == false)
                        throw new UnsupportedVersionException($"PartitionStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                    _partitionStatesCollection = value;
                }
            }

            /// <summary>
            /// <para>The partition that we would like to update.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public UpdateMetadataTopicState WithPartitionStatesCollection(Array<UpdateMetadataPartitionState> partitionStatesCollection)
            {
                PartitionStatesCollection = partitionStatesCollection;
                return this;
            }
        }

        private Array<UpdateMetadataBroker> _liveBrokersCollection = Array.Empty<UpdateMetadataBroker>();
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<UpdateMetadataBroker> LiveBrokersCollection
        {
            get => _liveBrokersCollection;
            private set
            {
                _liveBrokersCollection = value;
            }
        }

        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateMetadataRequest WithLiveBrokersCollection(params Func<UpdateMetadataBroker, UpdateMetadataBroker>[] createFields)
        {
            LiveBrokersCollection = createFields.Select(createField => createField(new UpdateMetadataBroker(Version))).ToArray();
            return this;
        }

        public delegate UpdateMetadataBroker CreateUpdateMetadataBroker(UpdateMetadataBroker field);
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateMetadataRequest WithLiveBrokersCollection(IEnumerable<CreateUpdateMetadataBroker> createFields)
        {
            LiveBrokersCollection = createFields.Select(createField => createField(new UpdateMetadataBroker(Version))).ToArray();
            return this;
        }

        public class UpdateMetadataBroker : ISerialize
        {
            internal UpdateMetadataBroker(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 6;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _id.GetSize(IsFlexibleVersion) + (Version >= 0 && Version <= 0 ? _v0Host.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 0 ? _v0Port.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _endpointsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 ? _rack.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<UpdateMetadataBroker> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new UpdateMetadataBroker(version);
                instance.Id = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 0 && instance.Version <= 0)
                    instance.V0Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 0 && instance.Version <= 0)
                    instance.V0Port = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.EndpointsCollection = await Array<UpdateMetadataEndpoint>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => UpdateMetadataEndpoint.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 2)
                    instance.Rack = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for UpdateMetadataBroker is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _id.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 0 && Version <= 0)
                    await _v0Host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 0 && Version <= 0)
                    await _v0Port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _endpointsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 2)
                    await _rack.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _id = Int32.Default;
            /// <summary>
            /// <para>The broker id.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 Id
            {
                get => _id;
                private set
                {
                    _id = value;
                }
            }

            /// <summary>
            /// <para>The broker id.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public UpdateMetadataBroker WithId(Int32 id)
            {
                Id = id;
                return this;
            }

            private String _v0Host = String.Default;
            /// <summary>
            /// <para>The broker hostname.</para>
            /// <para>Versions: 0</para>
            /// </summary>
            public String V0Host
            {
                get => _v0Host;
                private set
                {
                    _v0Host = value;
                }
            }

            /// <summary>
            /// <para>The broker hostname.</para>
            /// <para>Versions: 0</para>
            /// </summary>
            public UpdateMetadataBroker WithV0Host(String v0Host)
            {
                V0Host = v0Host;
                return this;
            }

            private Int32 _v0Port = Int32.Default;
            /// <summary>
            /// <para>The broker port.</para>
            /// <para>Versions: 0</para>
            /// </summary>
            public Int32 V0Port
            {
                get => _v0Port;
                private set
                {
                    _v0Port = value;
                }
            }

            /// <summary>
            /// <para>The broker port.</para>
            /// <para>Versions: 0</para>
            /// </summary>
            public UpdateMetadataBroker WithV0Port(Int32 v0Port)
            {
                V0Port = v0Port;
                return this;
            }

            private Array<UpdateMetadataEndpoint> _endpointsCollection = Array.Empty<UpdateMetadataEndpoint>();
            /// <summary>
            /// <para>The broker endpoints.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public Array<UpdateMetadataEndpoint> EndpointsCollection
            {
                get => _endpointsCollection;
                private set
                {
                    _endpointsCollection = value;
                }
            }

            /// <summary>
            /// <para>The broker endpoints.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public UpdateMetadataBroker WithEndpointsCollection(params Func<UpdateMetadataEndpoint, UpdateMetadataEndpoint>[] createFields)
            {
                EndpointsCollection = createFields.Select(createField => createField(new UpdateMetadataEndpoint(Version))).ToArray();
                return this;
            }

            public delegate UpdateMetadataEndpoint CreateUpdateMetadataEndpoint(UpdateMetadataEndpoint field);
            /// <summary>
            /// <para>The broker endpoints.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public UpdateMetadataBroker WithEndpointsCollection(IEnumerable<CreateUpdateMetadataEndpoint> createFields)
            {
                EndpointsCollection = createFields.Select(createField => createField(new UpdateMetadataEndpoint(Version))).ToArray();
                return this;
            }

            public class UpdateMetadataEndpoint : ISerialize
            {
                internal UpdateMetadataEndpoint(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 6;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => (Version >= 1 ? _port.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _host.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _listener.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _securityProtocol.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<UpdateMetadataEndpoint> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new UpdateMetadataEndpoint(version);
                    if (instance.Version >= 1)
                        instance.Port = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 3)
                        instance.Listener = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.SecurityProtocol = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for UpdateMetadataEndpoint is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    if (Version >= 1)
                        await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 3)
                        await _listener.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _securityProtocol.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _port = Int32.Default;
                /// <summary>
                /// <para>The port of this endpoint</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public Int32 Port
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
                /// <para>The port of this endpoint</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public UpdateMetadataEndpoint WithPort(Int32 port)
                {
                    Port = port;
                    return this;
                }

                private String _host = String.Default;
                /// <summary>
                /// <para>The hostname of this endpoint</para>
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
                /// <para>The hostname of this endpoint</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public UpdateMetadataEndpoint WithHost(String host)
                {
                    Host = host;
                    return this;
                }

                private String _listener = String.Default;
                /// <summary>
                /// <para>The listener name.</para>
                /// <para>Versions: 3+</para>
                /// </summary>
                public String Listener
                {
                    get => _listener;
                    private set
                    {
                        _listener = value;
                    }
                }

                /// <summary>
                /// <para>The listener name.</para>
                /// <para>Versions: 3+</para>
                /// </summary>
                public UpdateMetadataEndpoint WithListener(String listener)
                {
                    Listener = listener;
                    return this;
                }

                private Int16 _securityProtocol = Int16.Default;
                /// <summary>
                /// <para>The security protocol type.</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public Int16 SecurityProtocol
                {
                    get => _securityProtocol;
                    private set
                    {
                        if (Version >= 1 == false)
                            throw new UnsupportedVersionException($"SecurityProtocol does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                        _securityProtocol = value;
                    }
                }

                /// <summary>
                /// <para>The security protocol type.</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public UpdateMetadataEndpoint WithSecurityProtocol(Int16 securityProtocol)
                {
                    SecurityProtocol = securityProtocol;
                    return this;
                }
            }

            private NullableString _rack = NullableString.Default;
            /// <summary>
            /// <para>The rack which this broker belongs to.</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public String? Rack
            {
                get => _rack;
                private set
                {
                    _rack = value;
                }
            }

            /// <summary>
            /// <para>The rack which this broker belongs to.</para>
            /// <para>Versions: 2+</para>
            /// </summary>
            public UpdateMetadataBroker WithRack(String? rack)
            {
                Rack = rack;
                return this;
            }
        }

        public class UpdateMetadataPartitionState : ISerialize
        {
            internal UpdateMetadataPartitionState(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 6;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 0 && Version <= 4 ? _topicName.GetSize(IsFlexibleVersion) : 0) + _partitionIndex.GetSize(IsFlexibleVersion) + _controllerEpoch.GetSize(IsFlexibleVersion) + _leader.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + _isrCollection.GetSize(IsFlexibleVersion) + _zkVersion.GetSize(IsFlexibleVersion) + _replicasCollection.GetSize(IsFlexibleVersion) + (Version >= 4 ? _offlineReplicasCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<UpdateMetadataPartitionState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new UpdateMetadataPartitionState(version);
                if (instance.Version >= 0 && instance.Version <= 4)
                    instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ControllerEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Leader = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.IsrCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.ZkVersion = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ReplicasCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.OfflineReplicasCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for UpdateMetadataPartitionState is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 0 && Version <= 4)
                    await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _controllerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _leader.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _isrCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _zkVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _replicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _offlineReplicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>In older versions of this RPC, the topic name.</para>
            /// <para>Versions: 0-4</para>
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
            /// <para>In older versions of this RPC, the topic name.</para>
            /// <para>Versions: 0-4</para>
            /// </summary>
            public UpdateMetadataPartitionState WithTopicName(String topicName)
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
            public UpdateMetadataPartitionState WithPartitionIndex(Int32 partitionIndex)
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
            public UpdateMetadataPartitionState WithControllerEpoch(Int32 controllerEpoch)
            {
                ControllerEpoch = controllerEpoch;
                return this;
            }

            private Int32 _leader = Int32.Default;
            /// <summary>
            /// <para>The ID of the broker which is the current partition leader.</para>
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
            /// <para>The ID of the broker which is the current partition leader.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public UpdateMetadataPartitionState WithLeader(Int32 leader)
            {
                Leader = leader;
                return this;
            }

            private Int32 _leaderEpoch = Int32.Default;
            /// <summary>
            /// <para>The leader epoch of this partition.</para>
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
            /// <para>The leader epoch of this partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public UpdateMetadataPartitionState WithLeaderEpoch(Int32 leaderEpoch)
            {
                LeaderEpoch = leaderEpoch;
                return this;
            }

            private Array<Int32> _isrCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The brokers which are in the ISR for this partition.</para>
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
            /// <para>The brokers which are in the ISR for this partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public UpdateMetadataPartitionState WithIsrCollection(Array<Int32> isrCollection)
            {
                IsrCollection = isrCollection;
                return this;
            }

            private Int32 _zkVersion = Int32.Default;
            /// <summary>
            /// <para>The Zookeeper version.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 ZkVersion
            {
                get => _zkVersion;
                private set
                {
                    _zkVersion = value;
                }
            }

            /// <summary>
            /// <para>The Zookeeper version.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public UpdateMetadataPartitionState WithZkVersion(Int32 zkVersion)
            {
                ZkVersion = zkVersion;
                return this;
            }

            private Array<Int32> _replicasCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>All the replicas of this partition.</para>
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
            /// <para>All the replicas of this partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public UpdateMetadataPartitionState WithReplicasCollection(Array<Int32> replicasCollection)
            {
                ReplicasCollection = replicasCollection;
                return this;
            }

            private Array<Int32> _offlineReplicasCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The replicas of this partition which are offline.</para>
            /// <para>Versions: 4+</para>
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
            /// <para>The replicas of this partition which are offline.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public UpdateMetadataPartitionState WithOfflineReplicasCollection(Array<Int32> offlineReplicasCollection)
            {
                OfflineReplicasCollection = offlineReplicasCollection;
                return this;
            }
        }

        public UpdateMetadataResponse Respond() => new UpdateMetadataResponse(Version);
    }
}
