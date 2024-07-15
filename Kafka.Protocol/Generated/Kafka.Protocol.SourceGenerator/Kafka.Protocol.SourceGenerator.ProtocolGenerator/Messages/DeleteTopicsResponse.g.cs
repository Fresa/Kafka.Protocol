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
    public class DeleteTopicsResponse : Message
    {
        public DeleteTopicsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DeleteTopicsResponse does not support version {version}. Valid versions are: 0-6");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(20);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(6);
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

        internal override int GetSize() => (Version >= 1 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + _responsesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DeleteTopicsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DeleteTopicsResponse(version);
            if (instance.Version >= 1)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ResponsesCollection = await Map<NullableString, DeletableTopicResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DeletableTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteTopicsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 1)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _responsesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 1+</para>
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
        /// <para>Versions: 1+</para>
        /// </summary>
        public DeleteTopicsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Map<NullableString, DeletableTopicResult> _responsesCollection = Map<NullableString, DeletableTopicResult>.Default;
        /// <summary>
        /// <para>The results for each topic we tried to delete.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<NullableString, DeletableTopicResult> ResponsesCollection
        {
            get => _responsesCollection;
            private set
            {
                _responsesCollection = value;
            }
        }

        /// <summary>
        /// <para>The results for each topic we tried to delete.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteTopicsResponse WithResponsesCollection(params Func<DeletableTopicResult, DeletableTopicResult>[] createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new DeletableTopicResult(Version))).ToDictionary(field => (NullableString)field.Name);
            return this;
        }

        public delegate DeletableTopicResult CreateDeletableTopicResult(DeletableTopicResult field);
        /// <summary>
        /// <para>The results for each topic we tried to delete.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteTopicsResponse WithResponsesCollection(IEnumerable<CreateDeletableTopicResult> createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new DeletableTopicResult(Version))).ToDictionary(field => (NullableString)field.Name);
            return this;
        }

        public class DeletableTopicResult : ISerialize
        {
            internal DeletableTopicResult(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + (Version >= 6 ? _topicId.GetSize(IsFlexibleVersion) : 0) + _errorCode.GetSize(IsFlexibleVersion) + (Version >= 5 ? _errorMessage.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DeletableTopicResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DeletableTopicResult(version);
                instance.Name = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 6)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 5)
                    instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DeletableTopicResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 6)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 5)
                    await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private NullableString _name = NullableString.Default;
            /// <summary>
            /// <para>The topic name</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String? Name
            {
                get => _name;
                private set
                {
                    if (Version >= 6 == false && value == null)
                        throw new UnsupportedVersionException($"Name does not support null for version {Version}. Supported versions for null value: 6+");
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The topic name</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeletableTopicResult WithName(String? name)
            {
                Name = name;
                return this;
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>the unique topic ID</para>
            /// <para>Versions: 6+</para>
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
            /// <para>the unique topic ID</para>
            /// <para>Versions: 6+</para>
            /// </summary>
            public DeletableTopicResult WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The deletion error, or 0 if the deletion succeeded.</para>
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
            /// <para>The deletion error, or 0 if the deletion succeeded.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeletableTopicResult WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _errorMessage = new NullableString(null);
            /// <summary>
            /// <para>The error message, or null if there was no error.</para>
            /// <para>Versions: 5+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? ErrorMessage
            {
                get => _errorMessage;
                private set
                {
                    if (Version >= 5 == false && value == null)
                        throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 5+");
                    _errorMessage = value;
                }
            }

            /// <summary>
            /// <para>The error message, or null if there was no error.</para>
            /// <para>Versions: 5+</para>
            /// <para>Default: null</para>
            /// </summary>
            public DeletableTopicResult WithErrorMessage(String? errorMessage)
            {
                ErrorMessage = errorMessage;
                return this;
            }
        }
    }
}
