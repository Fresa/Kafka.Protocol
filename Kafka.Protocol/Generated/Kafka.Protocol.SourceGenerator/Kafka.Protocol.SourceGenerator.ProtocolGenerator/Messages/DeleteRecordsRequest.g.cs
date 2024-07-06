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
    public class DeleteRecordsRequest : Message, IRespond<DeleteRecordsResponse>
    {
        public DeleteRecordsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DeleteRecordsRequest does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(21);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(2);
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

        internal override int GetSize() => _topicsCollection.GetSize(IsFlexibleVersion) + _timeoutMs.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DeleteRecordsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DeleteRecordsRequest(version);
            instance.TopicsCollection = await Array<DeleteRecordsTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DeleteRecordsTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.TimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteRecordsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _timeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<DeleteRecordsTopic> _topicsCollection = Array.Empty<DeleteRecordsTopic>();
        /// <summary>
        /// <para>Each topic that we want to delete records from.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DeleteRecordsTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic that we want to delete records from.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteRecordsRequest WithTopicsCollection(params Func<DeleteRecordsTopic, DeleteRecordsTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new DeleteRecordsTopic(Version))).ToArray();
            return this;
        }

        public delegate DeleteRecordsTopic CreateDeleteRecordsTopic(DeleteRecordsTopic field);
        /// <summary>
        /// <para>Each topic that we want to delete records from.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteRecordsRequest WithTopicsCollection(IEnumerable<CreateDeleteRecordsTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new DeleteRecordsTopic(Version))).ToArray();
            return this;
        }

        public class DeleteRecordsTopic : ISerialize
        {
            internal DeleteRecordsTopic(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 2;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DeleteRecordsTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DeleteRecordsTopic(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<DeleteRecordsPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DeleteRecordsPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteRecordsTopic is unknown");
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
            public DeleteRecordsTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<DeleteRecordsPartition> _partitionsCollection = Array.Empty<DeleteRecordsPartition>();
            /// <summary>
            /// <para>Each partition that we want to delete records from.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<DeleteRecordsPartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition that we want to delete records from.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteRecordsTopic WithPartitionsCollection(params Func<DeleteRecordsPartition, DeleteRecordsPartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new DeleteRecordsPartition(Version))).ToArray();
                return this;
            }

            public delegate DeleteRecordsPartition CreateDeleteRecordsPartition(DeleteRecordsPartition field);
            /// <summary>
            /// <para>Each partition that we want to delete records from.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteRecordsTopic WithPartitionsCollection(IEnumerable<CreateDeleteRecordsPartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new DeleteRecordsPartition(Version))).ToArray();
                return this;
            }

            public class DeleteRecordsPartition : ISerialize
            {
                internal DeleteRecordsPartition(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 2;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _offset.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<DeleteRecordsPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new DeleteRecordsPartition(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Offset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteRecordsPartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _offset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public DeleteRecordsPartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int64 _offset = Int64.Default;
                /// <summary>
                /// <para>The deletion offset.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 Offset
                {
                    get => _offset;
                    private set
                    {
                        _offset = value;
                    }
                }

                /// <summary>
                /// <para>The deletion offset.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DeleteRecordsPartition WithOffset(Int64 offset)
                {
                    Offset = offset;
                    return this;
                }
            }
        }

        private Int32 _timeoutMs = Int32.Default;
        /// <summary>
        /// <para>How long to wait for the deletion to complete, in milliseconds.</para>
        /// <para>Versions: 0+</para>
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
        /// <para>How long to wait for the deletion to complete, in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteRecordsRequest WithTimeoutMs(Int32 timeoutMs)
        {
            TimeoutMs = timeoutMs;
            return this;
        }

        public DeleteRecordsResponse Respond() => new DeleteRecordsResponse(Version);
    }
}
