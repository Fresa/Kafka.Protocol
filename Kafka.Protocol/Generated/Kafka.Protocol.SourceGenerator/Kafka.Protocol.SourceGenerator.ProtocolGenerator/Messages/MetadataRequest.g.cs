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
    public class MetadataRequest : Message, IRespond<MetadataResponse>
    {
        public MetadataRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"MetadataRequest does not support version {version}. Valid versions are: 0-12");
            Version = version;
            IsFlexibleVersion = version >= 9;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(3);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(12);
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

        internal override int GetSize() => _topicsCollection.GetSize(IsFlexibleVersion) + (Version >= 4 ? _allowAutoTopicCreation.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 && Version <= 10 ? _includeClusterAuthorizedOperations.GetSize(IsFlexibleVersion) : 0) + (Version >= 8 ? _includeTopicAuthorizedOperations.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<MetadataRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new MetadataRequest(version);
            instance.TopicsCollection = await NullableArray<MetadataRequestTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => MetadataRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 4)
                instance.AllowAutoTopicCreation = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 8 && instance.Version <= 10)
                instance.IncludeClusterAuthorizedOperations = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 8)
                instance.IncludeTopicAuthorizedOperations = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for MetadataRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 4)
                await _allowAutoTopicCreation.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 8 && Version <= 10)
                await _includeClusterAuthorizedOperations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 8)
                await _includeTopicAuthorizedOperations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private NullableArray<MetadataRequestTopic> _topicsCollection = Array.Empty<MetadataRequestTopic>();
        /// <summary>
        /// <para>The topics to fetch metadata for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<MetadataRequestTopic>? TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                if (Version >= 1 == false && value == null)
                    throw new UnsupportedVersionException($"TopicsCollection does not support null for version {Version}. Supported versions for null value: 1+");
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to fetch metadata for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public MetadataRequest WithTopicsCollection(params Func<MetadataRequestTopic, MetadataRequestTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new MetadataRequestTopic(Version))).ToArray();
            return this;
        }

        public delegate MetadataRequestTopic CreateMetadataRequestTopic(MetadataRequestTopic field);
        /// <summary>
        /// <para>The topics to fetch metadata for.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public MetadataRequest WithTopicsCollection(IEnumerable<CreateMetadataRequestTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new MetadataRequestTopic(Version))).ToArray();
            return this;
        }

        public class MetadataRequestTopic : ISerialize
        {
            internal MetadataRequestTopic(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 9;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 10 ? _topicId.GetSize(IsFlexibleVersion) : 0) + _name.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<MetadataRequestTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new MetadataRequestTopic(version);
                if (instance.Version >= 10)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Name = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for MetadataRequestTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 10)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The topic id.</para>
            /// <para>Versions: 10+</para>
            /// </summary>
            public Uuid TopicId
            {
                get => _topicId;
                private set
                {
                    _topicId = value;
                }
            }

            /// <summary>
            /// <para>The topic id.</para>
            /// <para>Versions: 10+</para>
            /// </summary>
            public MetadataRequestTopic WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private NullableString _name = NullableString.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String? Name
            {
                get => _name;
                private set
                {
                    if (Version >= 10 == false && value == null)
                        throw new UnsupportedVersionException($"Name does not support null for version {Version}. Supported versions for null value: 10+");
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public MetadataRequestTopic WithName(String? name)
            {
                Name = name;
                return this;
            }
        }

        private Boolean _allowAutoTopicCreation = new Boolean(true);
        /// <summary>
        /// <para>If this is true, the broker may auto-create topics that we requested which do not already exist, if it is configured to do so.</para>
        /// <para>Versions: 4+</para>
        /// <para>Default: true</para>
        /// </summary>
        public Boolean AllowAutoTopicCreation
        {
            get => _allowAutoTopicCreation;
            private set
            {
                if (Version >= 4 == false)
                    throw new UnsupportedVersionException($"AllowAutoTopicCreation does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                _allowAutoTopicCreation = value;
            }
        }

        /// <summary>
        /// <para>If this is true, the broker may auto-create topics that we requested which do not already exist, if it is configured to do so.</para>
        /// <para>Versions: 4+</para>
        /// <para>Default: true</para>
        /// </summary>
        public MetadataRequest WithAllowAutoTopicCreation(Boolean allowAutoTopicCreation)
        {
            AllowAutoTopicCreation = allowAutoTopicCreation;
            return this;
        }

        private Boolean _includeClusterAuthorizedOperations = Boolean.Default;
        /// <summary>
        /// <para>Whether to include cluster authorized operations.</para>
        /// <para>Versions: 8-10</para>
        /// </summary>
        public Boolean IncludeClusterAuthorizedOperations
        {
            get => _includeClusterAuthorizedOperations;
            private set
            {
                if (Version >= 8 && Version <= 10 == false)
                    throw new UnsupportedVersionException($"IncludeClusterAuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 8-10");
                _includeClusterAuthorizedOperations = value;
            }
        }

        /// <summary>
        /// <para>Whether to include cluster authorized operations.</para>
        /// <para>Versions: 8-10</para>
        /// </summary>
        public MetadataRequest WithIncludeClusterAuthorizedOperations(Boolean includeClusterAuthorizedOperations)
        {
            IncludeClusterAuthorizedOperations = includeClusterAuthorizedOperations;
            return this;
        }

        private Boolean _includeTopicAuthorizedOperations = Boolean.Default;
        /// <summary>
        /// <para>Whether to include topic authorized operations.</para>
        /// <para>Versions: 8+</para>
        /// </summary>
        public Boolean IncludeTopicAuthorizedOperations
        {
            get => _includeTopicAuthorizedOperations;
            private set
            {
                if (Version >= 8 == false)
                    throw new UnsupportedVersionException($"IncludeTopicAuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
                _includeTopicAuthorizedOperations = value;
            }
        }

        /// <summary>
        /// <para>Whether to include topic authorized operations.</para>
        /// <para>Versions: 8+</para>
        /// </summary>
        public MetadataRequest WithIncludeTopicAuthorizedOperations(Boolean includeTopicAuthorizedOperations)
        {
            IncludeTopicAuthorizedOperations = includeTopicAuthorizedOperations;
            return this;
        }

        public MetadataResponse Respond() => new MetadataResponse(Version);
    }
}
