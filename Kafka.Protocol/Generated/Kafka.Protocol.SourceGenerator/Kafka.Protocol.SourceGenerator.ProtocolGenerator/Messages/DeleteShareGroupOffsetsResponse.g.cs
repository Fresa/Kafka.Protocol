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
    public class DeleteShareGroupOffsetsResponse : Message
    {
        public DeleteShareGroupOffsetsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DeleteShareGroupOffsetsResponse does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(92);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _responsesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DeleteShareGroupOffsetsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DeleteShareGroupOffsetsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ResponsesCollection = await Array<DeleteShareGroupOffsetsResponseTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DeleteShareGroupOffsetsResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteShareGroupOffsetsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _responsesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 ThrottleTimeMs
        {
            get => _throttleTimeMs;
            private set
            {
                _throttleTimeMs = value;
            }
        }

        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteShareGroupOffsetsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The top-level error code, or 0 if there was no error.</para>
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
        /// <para>The top-level error code, or 0 if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteShareGroupOffsetsResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private NullableString _errorMessage = new NullableString(null);
        /// <summary>
        /// <para>The top-level error message, or null if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ErrorMessage
        {
            get => _errorMessage;
            private set
            {
                _errorMessage = value;
            }
        }

        /// <summary>
        /// <para>The top-level error message, or null if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public DeleteShareGroupOffsetsResponse WithErrorMessage(String? errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        private Array<DeleteShareGroupOffsetsResponseTopic> _responsesCollection = Array.Empty<DeleteShareGroupOffsetsResponseTopic>();
        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DeleteShareGroupOffsetsResponseTopic> ResponsesCollection
        {
            get => _responsesCollection;
            private set
            {
                _responsesCollection = value;
            }
        }

        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteShareGroupOffsetsResponse WithResponsesCollection(params Func<DeleteShareGroupOffsetsResponseTopic, DeleteShareGroupOffsetsResponseTopic>[] createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new DeleteShareGroupOffsetsResponseTopic(Version))).ToArray();
            return this;
        }

        public delegate DeleteShareGroupOffsetsResponseTopic CreateDeleteShareGroupOffsetsResponseTopic(DeleteShareGroupOffsetsResponseTopic field);
        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteShareGroupOffsetsResponse WithResponsesCollection(IEnumerable<CreateDeleteShareGroupOffsetsResponseTopic> createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new DeleteShareGroupOffsetsResponseTopic(Version))).ToArray();
            return this;
        }

        public class DeleteShareGroupOffsetsResponseTopic : ISerialize
        {
            internal DeleteShareGroupOffsetsResponseTopic(Int16 version)
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
            internal int GetSize(bool _) => _topicName.GetSize(IsFlexibleVersion) + _topicId.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DeleteShareGroupOffsetsResponseTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DeleteShareGroupOffsetsResponseTopic(version);
                instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteShareGroupOffsetsResponseTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
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
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteShareGroupOffsetsResponseTopic WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The unique topic ID.</para>
            /// <para>Versions: 0+</para>
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
            /// <para>The unique topic ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteShareGroupOffsetsResponseTopic WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The topic-level error code, or 0 if there was no error.</para>
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
            /// <para>The topic-level error code, or 0 if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteShareGroupOffsetsResponseTopic WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _errorMessage = new NullableString(null);
            /// <summary>
            /// <para>The topic-level error message, or null if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? ErrorMessage
            {
                get => _errorMessage;
                private set
                {
                    _errorMessage = value;
                }
            }

            /// <summary>
            /// <para>The topic-level error message, or null if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public DeleteShareGroupOffsetsResponseTopic WithErrorMessage(String? errorMessage)
            {
                ErrorMessage = errorMessage;
                return this;
            }
        }
    }
}
