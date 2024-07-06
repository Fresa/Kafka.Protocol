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
    public class LeaderAndIsrResponse : Message
    {
        public LeaderAndIsrResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"LeaderAndIsrResponse does not support version {version}. Valid versions are: 0-7");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(4);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(7);
        public override Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        // https://github.com/apache/kafka/blob/99b9b3e84f4e98c3f07714e1de6a139a004cbc5b/generator/src/main/java/org/apache/kafka/message/ApiMessageTypeGenerator.java#L324
        public Int16 HeaderVersion
        {
            get
            {
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _errorCode.GetSize(IsFlexibleVersion) + (Version >= 0 && Version <= 4 ? _partitionErrorsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _topicsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<LeaderAndIsrResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new LeaderAndIsrResponse(version);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 4)
                instance.PartitionErrorsCollection = await Array<LeaderAndIsrPartitionError>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => LeaderAndIsrPartitionError.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 5)
                instance.TopicsCollection = await Map<Uuid, LeaderAndIsrTopicError>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => LeaderAndIsrTopicError.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.TopicId, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderAndIsrResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 4)
                await _partitionErrorsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 5)
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The error code, or 0 if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int16 ErrorCode
        {
            get => _errorCode;
            private set
            {
                _errorCode = value;
            }
        }

        /// <summary>
        /// <para>The error code, or 0 if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public LeaderAndIsrResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<LeaderAndIsrPartitionError> _partitionErrorsCollection = Array.Empty<LeaderAndIsrPartitionError>();
        /// <summary>
        /// <para>Each partition in v0 to v4 message.</para>
        /// <para>Versions: 0-4</para>
        /// </summary>
        public Array<LeaderAndIsrPartitionError> PartitionErrorsCollection
        {
            get => _partitionErrorsCollection;
            private set
            {
                if (Version >= 0 && Version <= 4 == false)
                    throw new UnsupportedVersionException($"PartitionErrorsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-4");
                _partitionErrorsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each partition in v0 to v4 message.</para>
        /// <para>Versions: 0-4</para>
        /// </summary>
        public LeaderAndIsrResponse WithPartitionErrorsCollection(Array<LeaderAndIsrPartitionError> partitionErrorsCollection)
        {
            PartitionErrorsCollection = partitionErrorsCollection;
            return this;
        }

        private Map<Uuid, LeaderAndIsrTopicError> _topicsCollection = Map<Uuid, LeaderAndIsrTopicError>.Default;
        /// <summary>
        /// <para>Each topic</para>
        /// <para>Versions: 5+</para>
        /// </summary>
        public Map<Uuid, LeaderAndIsrTopicError> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                if (Version >= 5 == false)
                    throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic</para>
        /// <para>Versions: 5+</para>
        /// </summary>
        public LeaderAndIsrResponse WithTopicsCollection(params Func<LeaderAndIsrTopicError, LeaderAndIsrTopicError>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new LeaderAndIsrTopicError(Version))).ToDictionary(field => field.TopicId);
            return this;
        }

        public delegate LeaderAndIsrTopicError CreateLeaderAndIsrTopicError(LeaderAndIsrTopicError field);
        /// <summary>
        /// <para>Each topic</para>
        /// <para>Versions: 5+</para>
        /// </summary>
        public LeaderAndIsrResponse WithTopicsCollection(IEnumerable<CreateLeaderAndIsrTopicError> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new LeaderAndIsrTopicError(Version))).ToDictionary(field => field.TopicId);
            return this;
        }

        public class LeaderAndIsrTopicError : ISerialize
        {
            internal LeaderAndIsrTopicError(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 5 ? _topicId.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _partitionErrorsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<LeaderAndIsrTopicError> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new LeaderAndIsrTopicError(version);
                if (instance.Version >= 5)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 5)
                    instance.PartitionErrorsCollection = await Array<LeaderAndIsrPartitionError>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => LeaderAndIsrPartitionError.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderAndIsrTopicError is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 5)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 5)
                    await _partitionErrorsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The unique topic ID</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public Uuid TopicId
            {
                get => _topicId;
                private set
                {
                    if (Version >= 5 == false)
                        throw new UnsupportedVersionException($"TopicId does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                    _topicId = value;
                }
            }

            /// <summary>
            /// <para>The unique topic ID</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public LeaderAndIsrTopicError WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<LeaderAndIsrPartitionError> _partitionErrorsCollection = Array.Empty<LeaderAndIsrPartitionError>();
            /// <summary>
            /// <para>Each partition.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public Array<LeaderAndIsrPartitionError> PartitionErrorsCollection
            {
                get => _partitionErrorsCollection;
                private set
                {
                    if (Version >= 5 == false)
                        throw new UnsupportedVersionException($"PartitionErrorsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                    _partitionErrorsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public LeaderAndIsrTopicError WithPartitionErrorsCollection(Array<LeaderAndIsrPartitionError> partitionErrorsCollection)
            {
                PartitionErrorsCollection = partitionErrorsCollection;
                return this;
            }
        }

        public class LeaderAndIsrPartitionError : ISerialize
        {
            internal LeaderAndIsrPartitionError(Int16 version)
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
            internal int GetSize(bool _) => (Version >= 0 && Version <= 4 ? _topicName.GetSize(IsFlexibleVersion) : 0) + _partitionIndex.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<LeaderAndIsrPartitionError> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new LeaderAndIsrPartitionError(version);
                if (instance.Version >= 0 && instance.Version <= 4)
                    instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderAndIsrPartitionError is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 0 && Version <= 4)
                    await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0-4</para>
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
            /// <para>The topic name.</para>
            /// <para>Versions: 0-4</para>
            /// </summary>
            public LeaderAndIsrPartitionError WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
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
            public LeaderAndIsrPartitionError WithPartitionIndex(Int32 partitionIndex)
            {
                PartitionIndex = partitionIndex;
                return this;
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The partition error code, or 0 if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 ErrorCode
            {
                get => _errorCode;
                private set
                {
                    _errorCode = value;
                }
            }

            /// <summary>
            /// <para>The partition error code, or 0 if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public LeaderAndIsrPartitionError WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }
        }
    }
}
