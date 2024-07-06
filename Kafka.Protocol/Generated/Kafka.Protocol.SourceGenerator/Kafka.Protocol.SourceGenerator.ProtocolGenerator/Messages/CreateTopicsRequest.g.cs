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
    public class CreateTopicsRequest : Message, IRespond<CreateTopicsResponse>
    {
        public CreateTopicsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"CreateTopicsRequest does not support version {version}. Valid versions are: 0-7");
            Version = version;
            IsFlexibleVersion = version >= 5;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(19);
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

        internal override int GetSize() => _topicsCollection.GetSize(IsFlexibleVersion) + _timeoutMs.GetSize(IsFlexibleVersion) + (Version >= 1 ? _validateOnly.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<CreateTopicsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new CreateTopicsRequest(version);
            instance.TopicsCollection = await Map<String, CreatableTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => CreatableTopic.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            instance.TimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.ValidateOnly = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for CreateTopicsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _timeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _validateOnly.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Map<String, CreatableTopic> _topicsCollection = Map<String, CreatableTopic>.Default;
        /// <summary>
        /// <para>The topics to create.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, CreatableTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to create.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateTopicsRequest WithTopicsCollection(params Func<CreatableTopic, CreatableTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new CreatableTopic(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate CreatableTopic CreateCreatableTopic(CreatableTopic field);
        /// <summary>
        /// <para>The topics to create.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateTopicsRequest WithTopicsCollection(IEnumerable<CreateCreatableTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new CreatableTopic(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class CreatableTopic : ISerialize
        {
            internal CreatableTopic(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 5;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _numPartitions.GetSize(IsFlexibleVersion) + _replicationFactor.GetSize(IsFlexibleVersion) + _assignmentsCollection.GetSize(IsFlexibleVersion) + _configsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<CreatableTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new CreatableTopic(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.NumPartitions = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ReplicationFactor = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.AssignmentsCollection = await Map<Int32, CreatableReplicaAssignment>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => CreatableReplicaAssignment.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.PartitionIndex, cancellationToken).ConfigureAwait(false);
                instance.ConfigsCollection = await Map<String, CreateableTopicConfig>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => CreateableTopicConfig.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for CreatableTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _numPartitions.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _replicationFactor.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _assignmentsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _configsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
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
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatableTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Int32 _numPartitions = Int32.Default;
            /// <summary>
            /// <para>The number of partitions to create in the topic, or -1 if we are either specifying a manual partition assignment or using the default partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 NumPartitions
            {
                get => _numPartitions;
                private set
                {
                    _numPartitions = value;
                }
            }

            /// <summary>
            /// <para>The number of partitions to create in the topic, or -1 if we are either specifying a manual partition assignment or using the default partitions.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatableTopic WithNumPartitions(Int32 numPartitions)
            {
                NumPartitions = numPartitions;
                return this;
            }

            private Int16 _replicationFactor = Int16.Default;
            /// <summary>
            /// <para>The number of replicas to create for each partition in the topic, or -1 if we are either specifying a manual partition assignment or using the default replication factor.</para>
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
            /// <para>The number of replicas to create for each partition in the topic, or -1 if we are either specifying a manual partition assignment or using the default replication factor.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatableTopic WithReplicationFactor(Int16 replicationFactor)
            {
                ReplicationFactor = replicationFactor;
                return this;
            }

            private Map<Int32, CreatableReplicaAssignment> _assignmentsCollection = Map<Int32, CreatableReplicaAssignment>.Default;
            /// <summary>
            /// <para>The manual partition assignment, or the empty array if we are using automatic assignment.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Map<Int32, CreatableReplicaAssignment> AssignmentsCollection
            {
                get => _assignmentsCollection;
                private set
                {
                    _assignmentsCollection = value;
                }
            }

            /// <summary>
            /// <para>The manual partition assignment, or the empty array if we are using automatic assignment.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatableTopic WithAssignmentsCollection(params Func<CreatableReplicaAssignment, CreatableReplicaAssignment>[] createFields)
            {
                AssignmentsCollection = createFields.Select(createField => createField(new CreatableReplicaAssignment(Version))).ToDictionary(field => field.PartitionIndex);
                return this;
            }

            public delegate CreatableReplicaAssignment CreateCreatableReplicaAssignment(CreatableReplicaAssignment field);
            /// <summary>
            /// <para>The manual partition assignment, or the empty array if we are using automatic assignment.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatableTopic WithAssignmentsCollection(IEnumerable<CreateCreatableReplicaAssignment> createFields)
            {
                AssignmentsCollection = createFields.Select(createField => createField(new CreatableReplicaAssignment(Version))).ToDictionary(field => field.PartitionIndex);
                return this;
            }

            public class CreatableReplicaAssignment : ISerialize
            {
                internal CreatableReplicaAssignment(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 5;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _brokerIdsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<CreatableReplicaAssignment> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new CreatableReplicaAssignment(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.BrokerIdsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for CreatableReplicaAssignment is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _brokerIdsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public CreatableReplicaAssignment WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Array<Int32> _brokerIdsCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The brokers to place the partition on.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> BrokerIdsCollection
                {
                    get => _brokerIdsCollection;
                    private set
                    {
                        _brokerIdsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The brokers to place the partition on.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public CreatableReplicaAssignment WithBrokerIdsCollection(Array<Int32> brokerIdsCollection)
                {
                    BrokerIdsCollection = brokerIdsCollection;
                    return this;
                }
            }

            private Map<String, CreateableTopicConfig> _configsCollection = Map<String, CreateableTopicConfig>.Default;
            /// <summary>
            /// <para>The custom topic configurations to set.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Map<String, CreateableTopicConfig> ConfigsCollection
            {
                get => _configsCollection;
                private set
                {
                    _configsCollection = value;
                }
            }

            /// <summary>
            /// <para>The custom topic configurations to set.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatableTopic WithConfigsCollection(params Func<CreateableTopicConfig, CreateableTopicConfig>[] createFields)
            {
                ConfigsCollection = createFields.Select(createField => createField(new CreateableTopicConfig(Version))).ToDictionary(field => field.Name);
                return this;
            }

            public delegate CreateableTopicConfig CreateCreateableTopicConfig(CreateableTopicConfig field);
            /// <summary>
            /// <para>The custom topic configurations to set.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatableTopic WithConfigsCollection(IEnumerable<CreateCreateableTopicConfig> createFields)
            {
                ConfigsCollection = createFields.Select(createField => createField(new CreateableTopicConfig(Version))).ToDictionary(field => field.Name);
                return this;
            }

            public class CreateableTopicConfig : ISerialize
            {
                internal CreateableTopicConfig(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 5;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _value.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<CreateableTopicConfig> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new CreateableTopicConfig(version);
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Value = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for CreateableTopicConfig is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _value.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private String _name = String.Default;
                /// <summary>
                /// <para>The configuration name.</para>
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
                /// <para>The configuration name.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public CreateableTopicConfig WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private NullableString _value = NullableString.Default;
                /// <summary>
                /// <para>The configuration value.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public String? Value
                {
                    get => _value;
                    private set
                    {
                        _value = value;
                    }
                }

                /// <summary>
                /// <para>The configuration value.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public CreateableTopicConfig WithValue(String? value)
                {
                    Value = value;
                    return this;
                }
            }
        }

        private Int32 _timeoutMs = new Int32(60000);
        /// <summary>
        /// <para>How long to wait in milliseconds before timing out the request.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 60000</para>
        /// </summary>
        public Int32 TimeoutMs
        {
            get => _timeoutMs;
            private set
            {
                _timeoutMs = value;
            }
        }

        /// <summary>
        /// <para>How long to wait in milliseconds before timing out the request.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 60000</para>
        /// </summary>
        public CreateTopicsRequest WithTimeoutMs(Int32 timeoutMs)
        {
            TimeoutMs = timeoutMs;
            return this;
        }

        private Boolean _validateOnly = new Boolean(false);
        /// <summary>
        /// <para>If true, check that the topics can be created as specified, but don't create anything.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean ValidateOnly
        {
            get => _validateOnly;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"ValidateOnly does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _validateOnly = value;
            }
        }

        /// <summary>
        /// <para>If true, check that the topics can be created as specified, but don't create anything.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: false</para>
        /// </summary>
        public CreateTopicsRequest WithValidateOnly(Boolean validateOnly)
        {
            ValidateOnly = validateOnly;
            return this;
        }

        public CreateTopicsResponse Respond() => new CreateTopicsResponse(Version);
    }
}
