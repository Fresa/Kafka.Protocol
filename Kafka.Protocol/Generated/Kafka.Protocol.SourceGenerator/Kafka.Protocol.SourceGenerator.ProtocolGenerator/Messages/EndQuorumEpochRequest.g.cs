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
    public class EndQuorumEpochRequest : Message, IRespond<EndQuorumEpochResponse>
    {
        public EndQuorumEpochRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"EndQuorumEpochRequest does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = version >= 1;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(54);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(1);
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

        internal override int GetSize() => _clusterId.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (Version >= 1 ? _leaderEndpointsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<EndQuorumEpochRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new EndQuorumEpochRequest(version);
            instance.ClusterId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<TopicData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.LeaderEndpointsCollection = await Map<String, LeaderEndpoint>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => LeaderEndpoint.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for EndQuorumEpochRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _clusterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _leaderEndpointsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private NullableString _clusterId = new NullableString(null);
        /// <summary>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ClusterId
        {
            get => _clusterId;
            private set
            {
                _clusterId = value;
            }
        }

        /// <summary>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public EndQuorumEpochRequest WithClusterId(String? clusterId)
        {
            ClusterId = clusterId;
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
        public EndQuorumEpochRequest WithTopicsCollection(params Func<TopicData, TopicData>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicData(Version))).ToArray();
            return this;
        }

        public delegate TopicData CreateTopicData(TopicData field);
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public EndQuorumEpochRequest WithTopicsCollection(IEnumerable<CreateTopicData> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicData(Version))).ToArray();
            return this;
        }

        public class TopicData : ISerialize
        {
            internal TopicData(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 1;
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
                    IsFlexibleVersion = version >= 1;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _leaderId.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + (Version >= 0 && Version <= 0 ? _preferredSuccessorsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _preferredCandidatesCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionData(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 0 && instance.Version <= 0)
                        instance.PreferredSuccessorsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.PreferredCandidatesCollection = await Array<ReplicaInfo>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ReplicaInfo.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
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
                    await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 0 && Version <= 0)
                        await _preferredSuccessorsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _preferredCandidatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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

                private Int32 _leaderId = Int32.Default;
                /// <summary>
                /// <para>The current leader ID that is resigning</para>
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
                /// <para>The current leader ID that is resigning</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithLeaderId(Int32 leaderId)
                {
                    LeaderId = leaderId;
                    return this;
                }

                private Int32 _leaderEpoch = Int32.Default;
                /// <summary>
                /// <para>The current epoch</para>
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
                /// <para>The current epoch</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionData WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }

                private Array<Int32> _preferredSuccessorsCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>A sorted list of preferred successors to start the election</para>
                /// <para>Versions: 0</para>
                /// </summary>
                public Array<Int32> PreferredSuccessorsCollection
                {
                    get => _preferredSuccessorsCollection;
                    private set
                    {
                        _preferredSuccessorsCollection = value;
                    }
                }

                /// <summary>
                /// <para>A sorted list of preferred successors to start the election</para>
                /// <para>Versions: 0</para>
                /// </summary>
                public PartitionData WithPreferredSuccessorsCollection(Array<Int32> preferredSuccessorsCollection)
                {
                    PreferredSuccessorsCollection = preferredSuccessorsCollection;
                    return this;
                }

                private Array<ReplicaInfo> _preferredCandidatesCollection = Array.Empty<ReplicaInfo>();
                /// <summary>
                /// <para>A sorted list of preferred candidates to start the election</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public Array<ReplicaInfo> PreferredCandidatesCollection
                {
                    get => _preferredCandidatesCollection;
                    private set
                    {
                        _preferredCandidatesCollection = value;
                    }
                }

                /// <summary>
                /// <para>A sorted list of preferred candidates to start the election</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public PartitionData WithPreferredCandidatesCollection(params Func<ReplicaInfo, ReplicaInfo>[] createFields)
                {
                    PreferredCandidatesCollection = createFields.Select(createField => createField(new ReplicaInfo(Version))).ToArray();
                    return this;
                }

                public delegate ReplicaInfo CreateReplicaInfo(ReplicaInfo field);
                /// <summary>
                /// <para>A sorted list of preferred candidates to start the election</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public PartitionData WithPreferredCandidatesCollection(IEnumerable<CreateReplicaInfo> createFields)
                {
                    PreferredCandidatesCollection = createFields.Select(createField => createField(new ReplicaInfo(Version))).ToArray();
                    return this;
                }

                public class ReplicaInfo : ISerialize
                {
                    internal ReplicaInfo(Int16 version)
                    {
                        Version = version;
                        IsFlexibleVersion = version >= 1;
                    }

                    internal Int16 Version { get; }
                    internal bool IsFlexibleVersion { get; }

                    private Tags.TagSection CreateTagSection()
                    {
                        return new Tags.TagSection();
                    }

                    int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                    internal int GetSize(bool _) => (Version >= 1 ? _candidateId.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _candidateDirectoryId.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<ReplicaInfo> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new ReplicaInfo(version);
                        if (instance.Version >= 1)
                            instance.CandidateId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 1)
                            instance.CandidateDirectoryId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for ReplicaInfo is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        if (Version >= 1)
                            await _candidateId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 1)
                            await _candidateDirectoryId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int32 _candidateId = Int32.Default;
                    /// <summary>
                    /// <para>Versions: 1+</para>
                    /// </summary>
                    public Int32 CandidateId
                    {
                        get => _candidateId;
                        private set
                        {
                            if (Version >= 1 == false)
                                throw new UnsupportedVersionException($"CandidateId does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                            _candidateId = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 1+</para>
                    /// </summary>
                    public ReplicaInfo WithCandidateId(Int32 candidateId)
                    {
                        CandidateId = candidateId;
                        return this;
                    }

                    private Uuid _candidateDirectoryId = Uuid.Default;
                    /// <summary>
                    /// <para>Versions: 1+</para>
                    /// </summary>
                    public Uuid CandidateDirectoryId
                    {
                        get => _candidateDirectoryId;
                        private set
                        {
                            if (Version >= 1 == false)
                                throw new UnsupportedVersionException($"CandidateDirectoryId does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                            _candidateDirectoryId = value;
                        }
                    }

                    /// <summary>
                    /// <para>Versions: 1+</para>
                    /// </summary>
                    public ReplicaInfo WithCandidateDirectoryId(Uuid candidateDirectoryId)
                    {
                        CandidateDirectoryId = candidateDirectoryId;
                        return this;
                    }
                }
            }
        }

        private Map<String, LeaderEndpoint> _leaderEndpointsCollection = Map<String, LeaderEndpoint>.Default;
        /// <summary>
        /// <para>Endpoints for the leader</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public Map<String, LeaderEndpoint> LeaderEndpointsCollection
        {
            get => _leaderEndpointsCollection;
            private set
            {
                _leaderEndpointsCollection = value;
            }
        }

        /// <summary>
        /// <para>Endpoints for the leader</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public EndQuorumEpochRequest WithLeaderEndpointsCollection(params Func<LeaderEndpoint, LeaderEndpoint>[] createFields)
        {
            LeaderEndpointsCollection = createFields.Select(createField => createField(new LeaderEndpoint(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate LeaderEndpoint CreateLeaderEndpoint(LeaderEndpoint field);
        /// <summary>
        /// <para>Endpoints for the leader</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public EndQuorumEpochRequest WithLeaderEndpointsCollection(IEnumerable<CreateLeaderEndpoint> createFields)
        {
            LeaderEndpointsCollection = createFields.Select(createField => createField(new LeaderEndpoint(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class LeaderEndpoint : ISerialize
        {
            internal LeaderEndpoint(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 1;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 1 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _host.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _port.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<LeaderEndpoint> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new LeaderEndpoint(version);
                if (instance.Version >= 1)
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderEndpoint is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 1)
                    await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The name of the endpoint</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public String Name
            {
                get => _name;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The name of the endpoint</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public LeaderEndpoint WithName(String name)
            {
                Name = name;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The node's hostname</para>
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
            /// <para>The node's hostname</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public LeaderEndpoint WithHost(String host)
            {
                Host = host;
                return this;
            }

            private UInt16 _port = UInt16.Default;
            /// <summary>
            /// <para>The node's port</para>
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
            /// <para>The node's port</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public LeaderEndpoint WithPort(UInt16 port)
            {
                Port = port;
                return this;
            }
        }

        public EndQuorumEpochResponse Respond() => new EndQuorumEpochResponse(Version);
    }
}
