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
    public class ConsumerProtocolSubscription
    {
        public ConsumerProtocolSubscription(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ConsumerProtocolSubscription does not support version {version}. Valid versions are: 0-3");
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

        internal int GetSize() => _topicsCollection.GetSize(IsFlexibleVersion) + _userData.GetSize(IsFlexibleVersion) + (Version >= 1 ? _ownedPartitionsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 ? _generationId.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _rackId.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        public static async ValueTask<ConsumerProtocolSubscription> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
            var reader = pipe.Reader;
            var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
            var instance = new ConsumerProtocolSubscription(version);
            instance.TopicsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.UserData = await NullableBytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.OwnedPartitionsCollection = await Map<String, TopicPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicPartition.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Topic, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2)
                instance.GenerationId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.RackId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ConsumerProtocolSubscription is unknown");
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
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _userData.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _ownedPartitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 2)
                    await _generationId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _rackId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }

                return new Bytes(writer.ToArray());
            }
        }

        private Array<String> _topicsCollection = Array.Empty<String>();
        /// <summary>
        /// <para>The topics that the member wants to consume.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<String> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics that the member wants to consume.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ConsumerProtocolSubscription WithTopicsCollection(Array<String> topicsCollection)
        {
            TopicsCollection = topicsCollection;
            return this;
        }

        private NullableBytes _userData = new NullableBytes(null);
        /// <summary>
        /// <para>User data that will be passed back to the consumer.</para>
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
        /// <para>User data that will be passed back to the consumer.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ConsumerProtocolSubscription WithUserData(Bytes? userData)
        {
            UserData = userData;
            return this;
        }

        private Map<String, TopicPartition> _ownedPartitionsCollection = Map<String, TopicPartition>.Default;
        /// <summary>
        /// <para>The partitions that the member owns.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public Map<String, TopicPartition> OwnedPartitionsCollection
        {
            get => _ownedPartitionsCollection;
            private set
            {
                _ownedPartitionsCollection = value;
            }
        }

        /// <summary>
        /// <para>The partitions that the member owns.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public ConsumerProtocolSubscription WithOwnedPartitionsCollection(params Func<TopicPartition, TopicPartition>[] createFields)
        {
            OwnedPartitionsCollection = createFields.Select(createField => createField(new TopicPartition(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public delegate TopicPartition CreateTopicPartition(TopicPartition field);
        /// <summary>
        /// <para>The partitions that the member owns.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public ConsumerProtocolSubscription WithOwnedPartitionsCollection(IEnumerable<CreateTopicPartition> createFields)
        {
            OwnedPartitionsCollection = createFields.Select(createField => createField(new TopicPartition(Version))).ToDictionary(field => field.Topic);
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
            internal int GetSize(bool _) => (Version >= 1 ? _topic.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _partitionsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicPartition(version);
                if (instance.Version >= 1)
                    instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
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
                if (Version >= 1)
                    await _topic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topic = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public String Topic
            {
                get => _topic;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"Topic does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _topic = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public TopicPartition WithTopic(String topic)
            {
                Topic = topic;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partition ids.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public Array<Int32> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partition ids.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public TopicPartition WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        private Int32 _generationId = new Int32(-1);
        /// <summary>
        /// <para>The generation id of the member.</para>
        /// <para>Versions: 2+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int32 GenerationId
        {
            get => _generationId;
            private set
            {
                _generationId = value;
            }
        }

        /// <summary>
        /// <para>The generation id of the member.</para>
        /// <para>Versions: 2+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public ConsumerProtocolSubscription WithGenerationId(Int32 generationId)
        {
            GenerationId = generationId;
            return this;
        }

        private NullableString _rackId = new NullableString(null);
        /// <summary>
        /// <para>The rack id of the member.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? RackId
        {
            get => _rackId;
            private set
            {
                if (Version >= 3 == false && value == null)
                    throw new UnsupportedVersionException($"RackId does not support null for version {Version}. Supported versions for null value: 3+");
                _rackId = value;
            }
        }

        /// <summary>
        /// <para>The rack id of the member.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ConsumerProtocolSubscription WithRackId(String? rackId)
        {
            RackId = rackId;
            return this;
        }
    }
}
