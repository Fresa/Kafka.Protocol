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
    public class DescribeTopicPartitionsRequest : Message, IRespond<DescribeTopicPartitionsResponse>
    {
        public DescribeTopicPartitionsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeTopicPartitionsRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(75);
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

        internal override int GetSize() => _topicsCollection.GetSize(IsFlexibleVersion) + _responsePartitionLimit.GetSize(IsFlexibleVersion) + _cursor.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeTopicPartitionsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeTopicPartitionsRequest(version);
            instance.TopicsCollection = await Array<TopicRequest>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicRequest.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ResponsePartitionLimit = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.Cursor_ = await Nullable<Cursor>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Cursor.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeTopicPartitionsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _responsePartitionLimit.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _cursor.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<TopicRequest> _topicsCollection = Array.Empty<TopicRequest>();
        /// <summary>
        /// <para>The topics to fetch details for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<TopicRequest> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to fetch details for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeTopicPartitionsRequest WithTopicsCollection(params Func<TopicRequest, TopicRequest>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicRequest(Version))).ToArray();
            return this;
        }

        public delegate TopicRequest CreateTopicRequest(TopicRequest field);
        /// <summary>
        /// <para>The topics to fetch details for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeTopicPartitionsRequest WithTopicsCollection(IEnumerable<CreateTopicRequest> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TopicRequest(Version))).ToArray();
            return this;
        }

        public class TopicRequest : ISerialize
        {
            internal TopicRequest(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicRequest(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicRequest is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public TopicRequest WithName(String name)
            {
                Name = name;
                return this;
            }
        }

        private Int32 _responsePartitionLimit = new Int32(2000);
        /// <summary>
        /// <para>The maximum number of partitions included in the response.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 2000</para>
        /// </summary>
        public Int32 ResponsePartitionLimit
        {
            get => _responsePartitionLimit;
            private set
            {
                _responsePartitionLimit = value;
            }
        }

        /// <summary>
        /// <para>The maximum number of partitions included in the response.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 2000</para>
        /// </summary>
        public DescribeTopicPartitionsRequest WithResponsePartitionLimit(Int32 responsePartitionLimit)
        {
            ResponsePartitionLimit = responsePartitionLimit;
            return this;
        }

        private Nullable<Cursor> _cursor = new Nullable<Cursor>(null);
        /// <summary>
        /// <para>The first topic and partition index to fetch details for.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Cursor? Cursor_
        {
            get => _cursor;
            private set
            {
                _cursor = value;
            }
        }

        /// <summary>
        /// <para>The first topic and partition index to fetch details for.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public DescribeTopicPartitionsRequest WithCursor_(Func<Cursor?, Cursor?> createField)
        {
            Cursor_ = createField(new Cursor(Version));
            return this;
        }

        public class Cursor : ISerialize
        {
            internal Cursor(Int16 version)
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
            internal int GetSize(bool _) => _topicName.GetSize(IsFlexibleVersion) + _partitionIndex.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Cursor> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Cursor(version);
                instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Cursor is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The name for the first topic to process</para>
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
            /// <para>The name for the first topic to process</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Cursor WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Int32 _partitionIndex = Int32.Default;
            /// <summary>
            /// <para>The partition index to start with</para>
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
            /// <para>The partition index to start with</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Cursor WithPartitionIndex(Int32 partitionIndex)
            {
                PartitionIndex = partitionIndex;
                return this;
            }
        }

        public DescribeTopicPartitionsResponse Respond() => new DescribeTopicPartitionsResponse(Version);
    }
}
