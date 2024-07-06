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
    public class ListPartitionReassignmentsRequest : Message, IRespond<ListPartitionReassignmentsResponse>
    {
        public ListPartitionReassignmentsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ListPartitionReassignmentsRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(46);
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
        internal static async ValueTask<ListPartitionReassignmentsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ListPartitionReassignmentsRequest(version);
            instance.TimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await NullableArray<ListPartitionReassignmentsTopics>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ListPartitionReassignmentsTopics.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ListPartitionReassignmentsRequest is unknown");
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
        public ListPartitionReassignmentsRequest WithTimeoutMs(Int32 timeoutMs)
        {
            TimeoutMs = timeoutMs;
            return this;
        }

        private NullableArray<ListPartitionReassignmentsTopics> _topicsCollection = new NullableArray<ListPartitionReassignmentsTopics>(null);
        /// <summary>
        /// <para>The topics to list partition reassignments for, or null to list everything.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<ListPartitionReassignmentsTopics>? TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to list partition reassignments for, or null to list everything.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ListPartitionReassignmentsRequest WithTopicsCollection(params Func<ListPartitionReassignmentsTopics, ListPartitionReassignmentsTopics>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new ListPartitionReassignmentsTopics(Version))).ToArray();
            return this;
        }

        public delegate ListPartitionReassignmentsTopics CreateListPartitionReassignmentsTopics(ListPartitionReassignmentsTopics field);
        /// <summary>
        /// <para>The topics to list partition reassignments for, or null to list everything.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ListPartitionReassignmentsRequest WithTopicsCollection(IEnumerable<CreateListPartitionReassignmentsTopics> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new ListPartitionReassignmentsTopics(Version))).ToArray();
            return this;
        }

        public class ListPartitionReassignmentsTopics : ISerialize
        {
            internal ListPartitionReassignmentsTopics(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionIndexesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ListPartitionReassignmentsTopics> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ListPartitionReassignmentsTopics(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionIndexesCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ListPartitionReassignmentsTopics is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionIndexesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The topic name</para>
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
            /// <para>The topic name</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ListPartitionReassignmentsTopics WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<Int32> _partitionIndexesCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partitions to list partition reassignments for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<Int32> PartitionIndexesCollection
            {
                get => _partitionIndexesCollection;
                private set
                {
                    _partitionIndexesCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions to list partition reassignments for.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ListPartitionReassignmentsTopics WithPartitionIndexesCollection(Array<Int32> partitionIndexesCollection)
            {
                PartitionIndexesCollection = partitionIndexesCollection;
                return this;
            }
        }

        public ListPartitionReassignmentsResponse Respond() => new ListPartitionReassignmentsResponse(Version);
    }
}
