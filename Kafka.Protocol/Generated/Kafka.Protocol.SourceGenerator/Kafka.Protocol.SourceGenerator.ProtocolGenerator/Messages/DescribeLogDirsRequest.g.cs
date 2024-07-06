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
    public class DescribeLogDirsRequest : Message, IRespond<DescribeLogDirsResponse>
    {
        public DescribeLogDirsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeLogDirsRequest does not support version {version}. Valid versions are: 0-4");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(35);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(4);
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

        internal override int GetSize() => _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeLogDirsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeLogDirsRequest(version);
            instance.TopicsCollection = await NullableMap<String, DescribableLogDirTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribableLogDirTopic.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Topic, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeLogDirsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private NullableMap<String, DescribableLogDirTopic> _topicsCollection = NullableMap<String, DescribableLogDirTopic>.Default;
        /// <summary>
        /// <para>Each topic that we want to describe log directories for, or null for all topics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, DescribableLogDirTopic>? TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic that we want to describe log directories for, or null for all topics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeLogDirsRequest WithTopicsCollection(params Func<DescribableLogDirTopic, DescribableLogDirTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new DescribableLogDirTopic(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public delegate DescribableLogDirTopic CreateDescribableLogDirTopic(DescribableLogDirTopic field);
        /// <summary>
        /// <para>Each topic that we want to describe log directories for, or null for all topics.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeLogDirsRequest WithTopicsCollection(IEnumerable<CreateDescribableLogDirTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new DescribableLogDirTopic(Version))).ToDictionary(field => field.Topic);
            return this;
        }

        public class DescribableLogDirTopic : ISerialize
        {
            internal DescribableLogDirTopic(Int16 version)
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
            internal static async ValueTask<DescribableLogDirTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribableLogDirTopic(version);
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
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribableLogDirTopic is unknown");
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
            /// <para>The topic name</para>
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
            /// <para>The topic name</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribableLogDirTopic WithTopic(String topic)
            {
                Topic = topic;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partition indexes.</para>
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
            /// <para>The partition indexes.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribableLogDirTopic WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        public DescribeLogDirsResponse Respond() => new DescribeLogDirsResponse(Version);
    }
}
