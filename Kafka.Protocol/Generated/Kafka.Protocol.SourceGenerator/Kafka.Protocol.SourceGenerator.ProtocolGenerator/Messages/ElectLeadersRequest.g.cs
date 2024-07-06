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
    public class ElectLeadersRequest : Message, IRespond<ElectLeadersResponse>
    {
        public ElectLeadersRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ElectLeadersRequest does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(43);
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

        internal override int GetSize() => (Version >= 1 ? _electionType.GetSize(IsFlexibleVersion) : 0) + _topicPartitionsCollection.GetSize(IsFlexibleVersion) + _timeoutMs.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ElectLeadersRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ElectLeadersRequest(version);
            if (instance.Version >= 1)
                instance.ElectionType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicPartitionsCollection = await NullableMap<String, TopicPartitions>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicPartitions.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Topic, cancellationToken).ConfigureAwait(false);
            instance.TimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ElectLeadersRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 1)
                await _electionType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicPartitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _timeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int8 _electionType = Int8.Default;
        /// <summary>
        /// <para>Type of elections to conduct for the partition. A value of '0' elects the preferred replica. A value of '1' elects the first live replica if there are no in-sync replica.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public Int8 ElectionType
        {
            get => _electionType;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"ElectionType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _electionType = value;
            }
        }

        /// <summary>
        /// <para>Type of elections to conduct for the partition. A value of '0' elects the preferred replica. A value of '1' elects the first live replica if there are no in-sync replica.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public ElectLeadersRequest WithElectionType(Int8 electionType)
        {
            ElectionType = electionType;
            return this;
        }

        private NullableMap<String, TopicPartitions> _topicPartitionsCollection = NullableMap<String, TopicPartitions>.Default;
        /// <summary>
        /// <para>The topic partitions to elect leaders.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, TopicPartitions>? TopicPartitionsCollection
        {
            get => _topicPartitionsCollection;
            private set
            {
                _topicPartitionsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topic partitions to elect leaders.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ElectLeadersRequest WithTopicPartitionsCollection(params Func<TopicPartitions, TopicPartitions>[] createFields)
        {
            TopicPartitionsCollection = createFields.Select(createField => createField(new TopicPartitions(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public delegate TopicPartitions CreateTopicPartitions(TopicPartitions field);
        /// <summary>
        /// <para>The topic partitions to elect leaders.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ElectLeadersRequest WithTopicPartitionsCollection(IEnumerable<CreateTopicPartitions> createFields)
        {
            TopicPartitionsCollection = createFields.Select(createField => createField(new TopicPartitions(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public class TopicPartitions : ISerialize
        {
            internal TopicPartitions(Int16 version)
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
            internal int GetSize(bool _) => _topic.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicPartitions> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicPartitions(version);
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
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicPartitions is unknown");
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
            /// <para>The name of a topic.</para>
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
            /// <para>The name of a topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartitions WithTopic(String topic)
            {
                Topic = topic;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partitions of this topic whose leader should be elected.</para>
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
            /// <para>The partitions of this topic whose leader should be elected.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartitions WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        private Int32 _timeoutMs = new Int32(60000);
        /// <summary>
        /// <para>The time in ms to wait for the election to complete.</para>
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
        /// <para>The time in ms to wait for the election to complete.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 60000</para>
        /// </summary>
        public ElectLeadersRequest WithTimeoutMs(Int32 timeoutMs)
        {
            TimeoutMs = timeoutMs;
            return this;
        }

        public ElectLeadersResponse Respond() => new ElectLeadersResponse(Version);
    }
}
