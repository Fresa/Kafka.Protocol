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
    public class ConsumerProtocolAssignment
    {
        public ConsumerProtocolAssignment(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ConsumerProtocolAssignment does not support version {version}. Valid versions are: 0-3");
            Version = version;
            IsFlexibleVersion = false;
        }

        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(3);
        public Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal int GetSize() => _assignedPartitionsCollection.GetSize(IsFlexibleVersion) + _userData.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        public static async ValueTask<ConsumerProtocolAssignment> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
            var reader = pipe.Reader;
            var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
            var instance = new ConsumerProtocolAssignment(version);
            instance.AssignedPartitionsCollection = await Map<String, TopicPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicPartition.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Topic, cancellationToken).ConfigureAwait(false);
            instance.UserData = await NullableBytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ConsumerProtocolAssignment is unknown");
                    }
                }
            }

            return instance;
        }

        public async ValueTask<Bytes> ToBytesAsync(CancellationToken cancellationToken = default)
        {
            var writer = new MemoryStream();
            await using (writer.ConfigureAwait(false))
            {
                await Version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _assignedPartitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _userData.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }

                return new Bytes(writer.ToArray());
            }
        }

        private Map<String, TopicPartition> _assignedPartitionsCollection = Map<String, TopicPartition>.Default;
        /// <summary>
        /// <para>The list of topics and partitions assigned to this consumer.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, TopicPartition> AssignedPartitionsCollection
        {
            get => _assignedPartitionsCollection;
            private set
            {
                _assignedPartitionsCollection = value;
            }
        }

        /// <summary>
        /// <para>The list of topics and partitions assigned to this consumer.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ConsumerProtocolAssignment WithAssignedPartitionsCollection(params Func<TopicPartition, TopicPartition>[] createFields)
        {
            AssignedPartitionsCollection = createFields.Select(createField => createField(new TopicPartition(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public delegate TopicPartition CreateTopicPartition(TopicPartition field);
        /// <summary>
        /// <para>The list of topics and partitions assigned to this consumer.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ConsumerProtocolAssignment WithAssignedPartitionsCollection(IEnumerable<CreateTopicPartition> createFields)
        {
            AssignedPartitionsCollection = createFields.Select(createField => createField(new TopicPartition(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public class TopicPartition : ISerialize
        {
            internal TopicPartition(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = false;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _topic.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicPartition(version);
                instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicPartition is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topic = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Topic
            {
                get => _topic;
                private set
                {
                    _topic = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartition WithTopic(String topic)
            {
                Topic = topic;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The list of partitions assigned to this consumer.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<Int32> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The list of partitions assigned to this consumer.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartition WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        private NullableBytes _userData = new NullableBytes(null);
        /// <summary>
        /// <para>User data.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Bytes? UserData
        {
            get => _userData;
            private set
            {
                _userData = value;
            }
        }

        /// <summary>
        /// <para>User data.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ConsumerProtocolAssignment WithUserData(Bytes? userData)
        {
            UserData = userData;
            return this;
        }
    }
}
