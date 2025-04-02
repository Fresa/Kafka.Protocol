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
    public class DeleteTopicsRequest : Message, IRespond<DeleteTopicsResponse>
    {
        public DeleteTopicsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DeleteTopicsRequest does not support version {version}. Valid versions are: 1-6");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(20);
        public static readonly Int16 MinVersion = Int16.From(1);
        public static readonly Int16 MaxVersion = Int16.From(6);
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

        internal override int GetSize() => (Version >= 6 ? _topicsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 5 ? _topicNamesCollection.GetSize(IsFlexibleVersion) : 0) + _timeoutMs.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DeleteTopicsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DeleteTopicsRequest(version);
            if (instance.Version >= 6)
                instance.TopicsCollection = await Array<DeleteTopicState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DeleteTopicState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 5)
                instance.TopicNamesCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.TimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteTopicsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 6)
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 5)
                await _topicNamesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _timeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<DeleteTopicState> _topicsCollection = Array.Empty<DeleteTopicState>();
        /// <summary>
        /// <para>The name or topic ID of the topic.</para>
        /// <para>Versions: 6+</para>
        /// </summary>
        public Array<DeleteTopicState> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                if (Version >= 6 == false)
                    throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 6+");
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The name or topic ID of the topic.</para>
        /// <para>Versions: 6+</para>
        /// </summary>
        public DeleteTopicsRequest WithTopicsCollection(params Func<DeleteTopicState, DeleteTopicState>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new DeleteTopicState(Version))).ToArray();
            return this;
        }

        public delegate DeleteTopicState CreateDeleteTopicState(DeleteTopicState field);
        /// <summary>
        /// <para>The name or topic ID of the topic.</para>
        /// <para>Versions: 6+</para>
        /// </summary>
        public DeleteTopicsRequest WithTopicsCollection(IEnumerable<CreateDeleteTopicState> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new DeleteTopicState(Version))).ToArray();
            return this;
        }

        public class DeleteTopicState : ISerialize
        {
            internal DeleteTopicState(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 4;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 6 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 6 ? _topicId.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DeleteTopicState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DeleteTopicState(version);
                if (instance.Version >= 6)
                    instance.Name = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 6)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteTopicState is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 6)
                    await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 6)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private NullableString _name = new NullableString(null);
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 6+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? Name
            {
                get => _name;
                private set
                {
                    if (Version >= 6 == false)
                        throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 6+");
                    if (Version >= 6 == false && value == null)
                        throw new UnsupportedVersionException($"Name does not support null for version {Version}. Supported versions for null value: 6+");
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 6+</para>
            /// <para>Default: null</para>
            /// </summary>
            public DeleteTopicState WithName(String? name)
            {
                Name = name;
                return this;
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The unique topic ID.</para>
            /// <para>Versions: 6+</para>
            /// </summary>
            public Uuid TopicId
            {
                get => _topicId;
                private set
                {
                    if (Version >= 6 == false)
                        throw new UnsupportedVersionException($"TopicId does not support version {Version} and has been defined as not ignorable. Supported versions: 6+");
                    _topicId = value;
                }
            }

            /// <summary>
            /// <para>The unique topic ID.</para>
            /// <para>Versions: 6+</para>
            /// </summary>
            public DeleteTopicState WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }
        }

        private Array<String> _topicNamesCollection = Array.Empty<String>();
        /// <summary>
        /// <para>The names of the topics to delete.</para>
        /// <para>Versions: 0-5</para>
        /// </summary>
        public Array<String> TopicNamesCollection
        {
            get => _topicNamesCollection;
            private set
            {
                _topicNamesCollection = value;
            }
        }

        /// <summary>
        /// <para>The names of the topics to delete.</para>
        /// <para>Versions: 0-5</para>
        /// </summary>
        public DeleteTopicsRequest WithTopicNamesCollection(Array<String> topicNamesCollection)
        {
            TopicNamesCollection = topicNamesCollection;
            return this;
        }

        private Int32 _timeoutMs = Int32.Default;
        /// <summary>
        /// <para>The length of time in milliseconds to wait for the deletions to complete.</para>
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
        /// <para>The length of time in milliseconds to wait for the deletions to complete.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteTopicsRequest WithTimeoutMs(Int32 timeoutMs)
        {
            TimeoutMs = timeoutMs;
            return this;
        }

        public DeleteTopicsResponse Respond() => new DeleteTopicsResponse(Version);
    }
}
