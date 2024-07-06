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
    public class ElectLeadersResponse : Message
    {
        public ElectLeadersResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ElectLeadersResponse does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(43);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + (Version >= 1 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + _replicaElectionResultsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ElectLeadersResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ElectLeadersResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ReplicaElectionResultsCollection = await Array<ReplicaElectionResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ReplicaElectionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ElectLeadersResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _replicaElectionResultsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public ElectLeadersResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The top level response error code.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public Int16 ErrorCode
        {
            get => _errorCode;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _errorCode = value;
            }
        }

        /// <summary>
        /// <para>The top level response error code.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public ElectLeadersResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<ReplicaElectionResult> _replicaElectionResultsCollection = Array.Empty<ReplicaElectionResult>();
        /// <summary>
        /// <para>The election results, or an empty array if the requester did not have permission and the request asks for all partitions.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ReplicaElectionResult> ReplicaElectionResultsCollection
        {
            get => _replicaElectionResultsCollection;
            private set
            {
                _replicaElectionResultsCollection = value;
            }
        }

        /// <summary>
        /// <para>The election results, or an empty array if the requester did not have permission and the request asks for all partitions.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ElectLeadersResponse WithReplicaElectionResultsCollection(params Func<ReplicaElectionResult, ReplicaElectionResult>[] createFields)
        {
            ReplicaElectionResultsCollection = createFields.Select(createField => createField(new ReplicaElectionResult(Version))).ToArray();
            return this;
        }

        public delegate ReplicaElectionResult CreateReplicaElectionResult(ReplicaElectionResult field);
        /// <summary>
        /// <para>The election results, or an empty array if the requester did not have permission and the request asks for all partitions.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ElectLeadersResponse WithReplicaElectionResultsCollection(IEnumerable<CreateReplicaElectionResult> createFields)
        {
            ReplicaElectionResultsCollection = createFields.Select(createField => createField(new ReplicaElectionResult(Version))).ToArray();
            return this;
        }

        public class ReplicaElectionResult : ISerialize
        {
            internal ReplicaElectionResult(Int16 version)
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
            internal int GetSize(bool _) => _topic.GetSize(IsFlexibleVersion) + _partitionResultCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ReplicaElectionResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ReplicaElectionResult(version);
                instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionResultCollection = await Array<PartitionResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => PartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ReplicaElectionResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionResultCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public ReplicaElectionResult WithTopic(String topic)
            {
                Topic = topic;
                return this;
            }

            private Array<PartitionResult> _partitionResultCollection = Array.Empty<PartitionResult>();
            /// <summary>
            /// <para>The results for each partition</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<PartitionResult> PartitionResultCollection
            {
                get => _partitionResultCollection;
                private set
                {
                    _partitionResultCollection = value;
                }
            }

            /// <summary>
            /// <para>The results for each partition</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ReplicaElectionResult WithPartitionResultCollection(params Func<PartitionResult, PartitionResult>[] createFields)
            {
                PartitionResultCollection = createFields.Select(createField => createField(new PartitionResult(Version))).ToArray();
                return this;
            }

            public delegate PartitionResult CreatePartitionResult(PartitionResult field);
            /// <summary>
            /// <para>The results for each partition</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ReplicaElectionResult WithPartitionResultCollection(IEnumerable<CreatePartitionResult> createFields)
            {
                PartitionResultCollection = createFields.Select(createField => createField(new PartitionResult(Version))).ToArray();
                return this;
            }

            public class PartitionResult : ISerialize
            {
                internal PartitionResult(Int16 version)
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
                internal int GetSize(bool _) => _partitionId.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<PartitionResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new PartitionResult(version);
                    instance.PartitionId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for PartitionResult is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _partitionId = Int32.Default;
                /// <summary>
                /// <para>The partition id</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 PartitionId
                {
                    get => _partitionId;
                    private set
                    {
                        _partitionId = value;
                    }
                }

                /// <summary>
                /// <para>The partition id</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionResult WithPartitionId(Int32 partitionId)
                {
                    PartitionId = partitionId;
                    return this;
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The result error, or zero if there was no error.</para>
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
                /// <para>The result error, or zero if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionResult WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private NullableString _errorMessage = NullableString.Default;
                /// <summary>
                /// <para>The result message, or null if there was no error.</para>
                /// <para>Versions: 0+</para>
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
                /// <para>The result message, or null if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public PartitionResult WithErrorMessage(String? errorMessage)
                {
                    ErrorMessage = errorMessage;
                    return this;
                }
            }
        }
    }
}
