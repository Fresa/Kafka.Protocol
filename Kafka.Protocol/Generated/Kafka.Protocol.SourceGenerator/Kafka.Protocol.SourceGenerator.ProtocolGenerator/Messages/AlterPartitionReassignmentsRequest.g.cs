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
    public class AlterPartitionReassignmentsRequest : Message, IRespond<AlterPartitionReassignmentsResponse>
    {
        public AlterPartitionReassignmentsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AlterPartitionReassignmentsRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(45);
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

        internal override int GetSize() => _timeoutMs.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AlterPartitionReassignmentsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AlterPartitionReassignmentsRequest(version);
            instance.TimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<ReassignableTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ReassignableTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterPartitionReassignmentsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _timeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _timeoutMs = new Int32(60000);
        /// <summary>
        /// <para>The time in ms to wait for the request to complete.</para>
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
        /// <para>The time in ms to wait for the request to complete.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 60000</para>
        /// </summary>
        public AlterPartitionReassignmentsRequest WithTimeoutMs(Int32 timeoutMs)
        {
            TimeoutMs = timeoutMs;
            return this;
        }

        private Array<ReassignableTopic> _topicsCollection = Array.Empty<ReassignableTopic>();
        /// <summary>
        /// <para>The topics to reassign.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ReassignableTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to reassign.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterPartitionReassignmentsRequest WithTopicsCollection(params Func<ReassignableTopic, ReassignableTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new ReassignableTopic(Version))).ToArray();
            return this;
        }

        public delegate ReassignableTopic CreateReassignableTopic(ReassignableTopic field);
        /// <summary>
        /// <para>The topics to reassign.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterPartitionReassignmentsRequest WithTopicsCollection(IEnumerable<CreateReassignableTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new ReassignableTopic(Version))).ToArray();
            return this;
        }

        public class ReassignableTopic : ISerialize
        {
            internal ReassignableTopic(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ReassignableTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ReassignableTopic(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<ReassignablePartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ReassignablePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ReassignableTopic is unknown");
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
            public ReassignableTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<ReassignablePartition> _partitionsCollection = Array.Empty<ReassignablePartition>();
            /// <summary>
            /// <para>The partitions to reassign.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<ReassignablePartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions to reassign.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ReassignableTopic WithPartitionsCollection(params Func<ReassignablePartition, ReassignablePartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new ReassignablePartition(Version))).ToArray();
                return this;
            }

            public delegate ReassignablePartition CreateReassignablePartition(ReassignablePartition field);
            /// <summary>
            /// <para>The partitions to reassign.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ReassignableTopic WithPartitionsCollection(IEnumerable<CreateReassignablePartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new ReassignablePartition(Version))).ToArray();
                return this;
            }

            public class ReassignablePartition : ISerialize
            {
                internal ReassignablePartition(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _replicasCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<ReassignablePartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new ReassignablePartition(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ReplicasCollection = await NullableArray<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for ReassignablePartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _replicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public ReassignablePartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private NullableArray<Int32> _replicasCollection = new NullableArray<Int32>(null);
                /// <summary>
                /// <para>The replicas to place the partitions on, or null to cancel a pending reassignment for this partition.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public Array<Int32>? ReplicasCollection
                {
                    get => _replicasCollection;
                    private set
                    {
                        _replicasCollection = value;
                    }
                }

                /// <summary>
                /// <para>The replicas to place the partitions on, or null to cancel a pending reassignment for this partition.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public ReassignablePartition WithReplicasCollection(Array<Int32>? replicasCollection)
                {
                    ReplicasCollection = replicasCollection;
                    return this;
                }
            }
        }

        public AlterPartitionReassignmentsResponse Respond() => new AlterPartitionReassignmentsResponse(Version);
    }
}
