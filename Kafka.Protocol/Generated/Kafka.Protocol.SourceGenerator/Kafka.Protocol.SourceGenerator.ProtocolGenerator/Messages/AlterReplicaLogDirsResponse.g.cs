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
    public class AlterReplicaLogDirsResponse : Message
    {
        public AlterReplicaLogDirsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AlterReplicaLogDirsResponse does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(34);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(2);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _resultsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AlterReplicaLogDirsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AlterReplicaLogDirsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ResultsCollection = await Array<AlterReplicaLogDirTopicResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterReplicaLogDirTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterReplicaLogDirsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _resultsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
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
        /// <para>Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterReplicaLogDirsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Array<AlterReplicaLogDirTopicResult> _resultsCollection = Array.Empty<AlterReplicaLogDirTopicResult>();
        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<AlterReplicaLogDirTopicResult> ResultsCollection
        {
            get => _resultsCollection;
            private set
            {
                _resultsCollection = value;
            }
        }

        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterReplicaLogDirsResponse WithResultsCollection(params Func<AlterReplicaLogDirTopicResult, AlterReplicaLogDirTopicResult>[] createFields)
        {
            ResultsCollection = createFields.Select(createField => createField(new AlterReplicaLogDirTopicResult(Version))).ToArray();
            return this;
        }

        public delegate AlterReplicaLogDirTopicResult CreateAlterReplicaLogDirTopicResult(AlterReplicaLogDirTopicResult field);
        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterReplicaLogDirsResponse WithResultsCollection(IEnumerable<CreateAlterReplicaLogDirTopicResult> createFields)
        {
            ResultsCollection = createFields.Select(createField => createField(new AlterReplicaLogDirTopicResult(Version))).ToArray();
            return this;
        }

        public class AlterReplicaLogDirTopicResult : ISerialize
        {
            internal AlterReplicaLogDirTopicResult(Int16 version)
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
            internal int GetSize(bool _) => _topicName.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AlterReplicaLogDirTopicResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AlterReplicaLogDirTopicResult(version);
                instance.TopicName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<AlterReplicaLogDirPartitionResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterReplicaLogDirPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterReplicaLogDirTopicResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topicName = String.Default;
            /// <summary>
            /// <para>The name of the topic.</para>
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
            /// <para>The name of the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterReplicaLogDirTopicResult WithTopicName(String topicName)
            {
                TopicName = topicName;
                return this;
            }

            private Array<AlterReplicaLogDirPartitionResult> _partitionsCollection = Array.Empty<AlterReplicaLogDirPartitionResult>();
            /// <summary>
            /// <para>The results for each partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<AlterReplicaLogDirPartitionResult> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The results for each partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterReplicaLogDirTopicResult WithPartitionsCollection(params Func<AlterReplicaLogDirPartitionResult, AlterReplicaLogDirPartitionResult>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new AlterReplicaLogDirPartitionResult(Version))).ToArray();
                return this;
            }

            public delegate AlterReplicaLogDirPartitionResult CreateAlterReplicaLogDirPartitionResult(AlterReplicaLogDirPartitionResult field);
            /// <summary>
            /// <para>The results for each partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterReplicaLogDirTopicResult WithPartitionsCollection(IEnumerable<CreateAlterReplicaLogDirPartitionResult> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new AlterReplicaLogDirPartitionResult(Version))).ToArray();
                return this;
            }

            public class AlterReplicaLogDirPartitionResult : ISerialize
            {
                internal AlterReplicaLogDirPartitionResult(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<AlterReplicaLogDirPartitionResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new AlterReplicaLogDirPartitionResult(version);
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
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterReplicaLogDirPartitionResult is unknown");
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
                public AlterReplicaLogDirPartitionResult WithPartitionIndex(Int32 partitionIndex)
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
                public AlterReplicaLogDirPartitionResult WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }
            }
        }
    }
}
