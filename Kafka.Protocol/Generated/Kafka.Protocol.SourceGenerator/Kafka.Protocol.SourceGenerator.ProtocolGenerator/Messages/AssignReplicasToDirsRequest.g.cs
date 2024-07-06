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
    public class AssignReplicasToDirsRequest : Message, IRespond<AssignReplicasToDirsResponse>
    {
        public AssignReplicasToDirsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AssignReplicasToDirsRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(73);
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

        internal override int GetSize() => _brokerId.GetSize(IsFlexibleVersion) + _brokerEpoch.GetSize(IsFlexibleVersion) + _directoriesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AssignReplicasToDirsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AssignReplicasToDirsRequest(version);
            instance.BrokerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.BrokerEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.DirectoriesCollection = await Array<DirectoryData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DirectoryData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AssignReplicasToDirsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _brokerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _brokerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _directoriesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public AssignReplicasToDirsRequest WithBrokerId(Int32 brokerId)
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
        public AssignReplicasToDirsRequest WithBrokerEpoch(Int64 brokerEpoch)
        {
            BrokerEpoch = brokerEpoch;
            return this;
        }

        private Array<DirectoryData> _directoriesCollection = Array.Empty<DirectoryData>();
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DirectoryData> DirectoriesCollection
        {
            get => _directoriesCollection;
            private set
            {
                _directoriesCollection = value;
            }
        }

        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AssignReplicasToDirsRequest WithDirectoriesCollection(params Func<DirectoryData, DirectoryData>[] createFields)
        {
            DirectoriesCollection = createFields.Select(createField => createField(new DirectoryData(Version))).ToArray();
            return this;
        }

        public delegate DirectoryData CreateDirectoryData(DirectoryData field);
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AssignReplicasToDirsRequest WithDirectoriesCollection(IEnumerable<CreateDirectoryData> createFields)
        {
            DirectoriesCollection = createFields.Select(createField => createField(new DirectoryData(Version))).ToArray();
            return this;
        }

        public class DirectoryData : ISerialize
        {
            internal DirectoryData(Int16 version)
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
            internal int GetSize(bool _) => _id.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DirectoryData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DirectoryData(version);
                instance.Id = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicsCollection = await Array<TopicData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DirectoryData is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _id.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Uuid _id = Uuid.Default;
            /// <summary>
            /// <para>The ID of the directory</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Uuid Id
            {
                get => _id;
                private set
                {
                    _id = value;
                }
            }

            /// <summary>
            /// <para>The ID of the directory</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DirectoryData WithId(Uuid id)
            {
                Id = id;
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
            public DirectoryData WithTopicsCollection(params Func<TopicData, TopicData>[] createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new TopicData(Version))).ToArray();
                return this;
            }

            public delegate TopicData CreateTopicData(TopicData field);
            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DirectoryData WithTopicsCollection(IEnumerable<CreateTopicData> createFields)
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
                internal int GetSize(bool _) => _topicId.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<TopicData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new TopicData(version);
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
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Uuid _topicId = Uuid.Default;
                /// <summary>
                /// <para>The ID of the assigned topic</para>
                /// <para>Versions: 0+</para>
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
                /// <para>The ID of the assigned topic</para>
                /// <para>Versions: 0+</para>
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
                    internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<PartitionData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new PartitionData(version);
                        instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                }
            }
        }

        public AssignReplicasToDirsResponse Respond() => new AssignReplicasToDirsResponse(Version);
    }
}
