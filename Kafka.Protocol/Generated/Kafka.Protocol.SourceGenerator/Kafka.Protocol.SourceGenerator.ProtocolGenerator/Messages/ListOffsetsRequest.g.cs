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
    public class ListOffsetsRequest : Message, IRespond<ListOffsetsResponse>
    {
        public ListOffsetsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ListOffsetsRequest does not support version {version}. Valid versions are: 0-9");
            Version = version;
            IsFlexibleVersion = version >= 6;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(2);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(9);
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

        internal override int GetSize() => _replicaId.GetSize(IsFlexibleVersion) + (Version >= 2 ? _isolationLevel.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ListOffsetsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ListOffsetsRequest(version);
            instance.ReplicaId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2)
                instance.IsolationLevel = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<ListOffsetsTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ListOffsetsTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ListOffsetsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _replicaId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 2)
                await _isolationLevel.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _replicaId = Int32.Default;
        /// <summary>
        /// <para>The broker ID of the requester, or -1 if this request is being made by a normal consumer.</para>
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
        /// <para>The broker ID of the requester, or -1 if this request is being made by a normal consumer.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListOffsetsRequest WithReplicaId(Int32 replicaId)
        {
            ReplicaId = replicaId;
            return this;
        }

        private Int8 _isolationLevel = Int8.Default;
        /// <summary>
        /// <para>This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public Int8 IsolationLevel
        {
            get => _isolationLevel;
            private set
            {
                if (Version >= 2 == false)
                    throw new UnsupportedVersionException($"IsolationLevel does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                _isolationLevel = value;
            }
        }

        /// <summary>
        /// <para>This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public ListOffsetsRequest WithIsolationLevel(Int8 isolationLevel)
        {
            IsolationLevel = isolationLevel;
            return this;
        }

        private Array<ListOffsetsTopic> _topicsCollection = Array.Empty<ListOffsetsTopic>();
        /// <summary>
        /// <para>Each topic in the request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ListOffsetsTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic in the request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListOffsetsRequest WithTopicsCollection(params Func<ListOffsetsTopic, ListOffsetsTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new ListOffsetsTopic(Version))).ToArray();
            return this;
        }

        public delegate ListOffsetsTopic CreateListOffsetsTopic(ListOffsetsTopic field);
        /// <summary>
        /// <para>Each topic in the request.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListOffsetsRequest WithTopicsCollection(IEnumerable<CreateListOffsetsTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new ListOffsetsTopic(Version))).ToArray();
            return this;
        }

        public class ListOffsetsTopic : ISerialize
        {
            internal ListOffsetsTopic(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ListOffsetsTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ListOffsetsTopic(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<ListOffsetsPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ListOffsetsPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ListOffsetsTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public ListOffsetsTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<ListOffsetsPartition> _partitionsCollection = Array.Empty<ListOffsetsPartition>();
            /// <summary>
            /// <para>Each partition in the request.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<ListOffsetsPartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition in the request.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ListOffsetsTopic WithPartitionsCollection(params Func<ListOffsetsPartition, ListOffsetsPartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new ListOffsetsPartition(Version))).ToArray();
                return this;
            }

            public delegate ListOffsetsPartition CreateListOffsetsPartition(ListOffsetsPartition field);
            /// <summary>
            /// <para>Each partition in the request.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ListOffsetsTopic WithPartitionsCollection(IEnumerable<CreateListOffsetsPartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new ListOffsetsPartition(Version))).ToArray();
                return this;
            }

            public class ListOffsetsPartition : ISerialize
            {
                internal ListOffsetsPartition(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + (Version >= 4 ? _currentLeaderEpoch.GetSize(IsFlexibleVersion) : 0) + _timestamp.GetSize(IsFlexibleVersion) + (Version >= 0 && Version <= 0 ? _maxNumOffsets.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<ListOffsetsPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new ListOffsetsPartition(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 4)
                        instance.CurrentLeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Timestamp = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 0 && instance.Version <= 0)
                        instance.MaxNumOffsets = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for ListOffsetsPartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 4)
                        await _currentLeaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _timestamp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 0 && Version <= 0)
                        await _maxNumOffsets.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public ListOffsetsPartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int32 _currentLeaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>The current leader epoch.</para>
                /// <para>Versions: 4+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int32 CurrentLeaderEpoch
                {
                    get => _currentLeaderEpoch;
                    private set
                    {
                        _currentLeaderEpoch = value;
                    }
                }

                /// <summary>
                /// <para>The current leader epoch.</para>
                /// <para>Versions: 4+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public ListOffsetsPartition WithCurrentLeaderEpoch(Int32 currentLeaderEpoch)
                {
                    CurrentLeaderEpoch = currentLeaderEpoch;
                    return this;
                }

                private Int64 _timestamp = Int64.Default;
                /// <summary>
                /// <para>The current timestamp.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 Timestamp
                {
                    get => _timestamp;
                    private set
                    {
                        _timestamp = value;
                    }
                }

                /// <summary>
                /// <para>The current timestamp.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public ListOffsetsPartition WithTimestamp(Int64 timestamp)
                {
                    Timestamp = timestamp;
                    return this;
                }

                private Int32 _maxNumOffsets = new Int32(1);
                /// <summary>
                /// <para>The maximum number of offsets to report.</para>
                /// <para>Versions: 0</para>
                /// <para>Default: 1</para>
                /// </summary>
                public Int32 MaxNumOffsets
                {
                    get => _maxNumOffsets;
                    private set
                    {
                        if (Version >= 0 && Version <= 0 == false)
                            throw new UnsupportedVersionException($"MaxNumOffsets does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
                        _maxNumOffsets = value;
                    }
                }

                /// <summary>
                /// <para>The maximum number of offsets to report.</para>
                /// <para>Versions: 0</para>
                /// <para>Default: 1</para>
                /// </summary>
                public ListOffsetsPartition WithMaxNumOffsets(Int32 maxNumOffsets)
                {
                    MaxNumOffsets = maxNumOffsets;
                    return this;
                }
            }
        }

        public ListOffsetsResponse Respond() => new ListOffsetsResponse(Version);
    }
}
