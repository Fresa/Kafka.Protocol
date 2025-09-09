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
    public class AlterShareGroupOffsetsResponse : Message
    {
        public AlterShareGroupOffsetsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AlterShareGroupOffsetsResponse does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(91);
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
        internal static async ValueTask<AlterShareGroupOffsetsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AlterShareGroupOffsetsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ResponsesCollection = await Map<String, AlterShareGroupOffsetsResponseTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterShareGroupOffsetsResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.TopicName, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterShareGroupOffsetsResponse is unknown");
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
        public AlterShareGroupOffsetsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
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
        public AlterShareGroupOffsetsResponse WithErrorCode(Int16 errorCode)
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
        public AlterShareGroupOffsetsResponse WithErrorMessage(String? errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        private Map<String, AlterShareGroupOffsetsResponseTopic> _responsesCollection = Map<String, AlterShareGroupOffsetsResponseTopic>.Default;
        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, AlterShareGroupOffsetsResponseTopic> ResponsesCollection
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
        public AlterShareGroupOffsetsResponse WithResponsesCollection(params Func<AlterShareGroupOffsetsResponseTopic, AlterShareGroupOffsetsResponseTopic>[] createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new AlterShareGroupOffsetsResponseTopic(Version))).ToDictionary(field => field.TopicName);
            return this;
        }

        public delegate AlterShareGroupOffsetsResponseTopic CreateAlterShareGroupOffsetsResponseTopic(AlterShareGroupOffsetsResponseTopic field);
        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterShareGroupOffsetsResponse WithResponsesCollection(IEnumerable<CreateAlterShareGroupOffsetsResponseTopic> createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new AlterShareGroupOffsetsResponseTopic(Version))).ToDictionary(field => field.TopicName);
            return this;
        }

        public class AlterShareGroupOffsetsResponseTopic : ISerialize
        {
            internal AlterShareGroupOffsetsResponseTopic(Int16 version)
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
            internal int GetSize(bool _) => _topicName.GetSize(IsFlexibleVersion) + _topicId.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AlterShareGroupOffsetsResponseTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AlterShareGroupOffsetsResponseTopic(version);
                instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<AlterShareGroupOffsetsResponsePartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterShareGroupOffsetsResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterShareGroupOffsetsResponseTopic is unknown");
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
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public AlterShareGroupOffsetsResponseTopic WithTopicName(String topicName)
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
            public AlterShareGroupOffsetsResponseTopic WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<AlterShareGroupOffsetsResponsePartition> _partitionsCollection = Array.Empty<AlterShareGroupOffsetsResponsePartition>();
            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<AlterShareGroupOffsetsResponsePartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterShareGroupOffsetsResponseTopic WithPartitionsCollection(params Func<AlterShareGroupOffsetsResponsePartition, AlterShareGroupOffsetsResponsePartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new AlterShareGroupOffsetsResponsePartition(Version))).ToArray();
                return this;
            }

            public delegate AlterShareGroupOffsetsResponsePartition CreateAlterShareGroupOffsetsResponsePartition(AlterShareGroupOffsetsResponsePartition field);
            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterShareGroupOffsetsResponseTopic WithPartitionsCollection(IEnumerable<CreateAlterShareGroupOffsetsResponsePartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new AlterShareGroupOffsetsResponsePartition(Version))).ToArray();
                return this;
            }

            public class AlterShareGroupOffsetsResponsePartition : ISerialize
            {
                internal AlterShareGroupOffsetsResponsePartition(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<AlterShareGroupOffsetsResponsePartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new AlterShareGroupOffsetsResponsePartition(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterShareGroupOffsetsResponsePartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
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
                public AlterShareGroupOffsetsResponsePartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
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
                public AlterShareGroupOffsetsResponsePartition WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private NullableString _errorMessage = new NullableString(null);
                /// <summary>
                /// <para>The error message, or null if there was no error.</para>
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
                /// <para>The error message, or null if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// <para>Default: null</para>
                /// </summary>
                public AlterShareGroupOffsetsResponsePartition WithErrorMessage(String? errorMessage)
                {
                    ErrorMessage = errorMessage;
                    return this;
                }
            }
        }
    }
}
