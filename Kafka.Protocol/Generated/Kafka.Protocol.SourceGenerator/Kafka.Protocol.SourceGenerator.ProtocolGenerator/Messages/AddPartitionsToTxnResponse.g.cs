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
    public class AddPartitionsToTxnResponse : Message
    {
        public AddPartitionsToTxnResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AddPartitionsToTxnResponse does not support version {version}. Valid versions are: 0-5");
            Version = version;
            IsFlexibleVersion = version >= 3;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(24);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(5);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + (Version >= 4 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _resultsByTransactionCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 3 ? _resultsByTopicV3AndBelowCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AddPartitionsToTxnResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AddPartitionsToTxnResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 4)
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 4)
                instance.ResultsByTransactionCollection = await Map<String, AddPartitionsToTxnResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AddPartitionsToTxnResult.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.TransactionalId, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 3)
                instance.ResultsByTopicV3AndBelowCollection = await Array<AddPartitionsToTxnTopicResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AddPartitionsToTxnTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AddPartitionsToTxnResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 4)
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 4)
                await _resultsByTransactionCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 3)
                await _resultsByTopicV3AndBelowCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public AddPartitionsToTxnResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The response top level error code.</para>
        /// <para>Versions: 4+</para>
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
        /// <para>The response top level error code.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public AddPartitionsToTxnResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Map<String, AddPartitionsToTxnResult> _resultsByTransactionCollection = Map<String, AddPartitionsToTxnResult>.Default;
        /// <summary>
        /// <para>Results categorized by transactional ID.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public Map<String, AddPartitionsToTxnResult> ResultsByTransactionCollection
        {
            get => _resultsByTransactionCollection;
            private set
            {
                if (Version >= 4 == false)
                    throw new UnsupportedVersionException($"ResultsByTransactionCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                _resultsByTransactionCollection = value;
            }
        }

        /// <summary>
        /// <para>Results categorized by transactional ID.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public AddPartitionsToTxnResponse WithResultsByTransactionCollection(params Func<AddPartitionsToTxnResult, AddPartitionsToTxnResult>[] createFields)
        {
            ResultsByTransactionCollection = createFields.Select(createField => createField(new AddPartitionsToTxnResult(Version))).ToDictionary(field => field.TransactionalId);
            return this;
        }

        public delegate AddPartitionsToTxnResult CreateAddPartitionsToTxnResult(AddPartitionsToTxnResult field);
        /// <summary>
        /// <para>Results categorized by transactional ID.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public AddPartitionsToTxnResponse WithResultsByTransactionCollection(IEnumerable<CreateAddPartitionsToTxnResult> createFields)
        {
            ResultsByTransactionCollection = createFields.Select(createField => createField(new AddPartitionsToTxnResult(Version))).ToDictionary(field => field.TransactionalId);
            return this;
        }

        public class AddPartitionsToTxnResult : ISerialize
        {
            internal AddPartitionsToTxnResult(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 4 ? _transactionalId.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _topicResultsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AddPartitionsToTxnResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AddPartitionsToTxnResult(version);
                if (instance.Version >= 4)
                    instance.TransactionalId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.TopicResultsCollection = await Array<AddPartitionsToTxnTopicResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AddPartitionsToTxnTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AddPartitionsToTxnResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 4)
                    await _transactionalId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _topicResultsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _transactionalId = String.Default;
            /// <summary>
            /// <para>The transactional id corresponding to the transaction.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public String TransactionalId
            {
                get => _transactionalId;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"TransactionalId does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _transactionalId = value;
                }
            }

            /// <summary>
            /// <para>The transactional id corresponding to the transaction.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public AddPartitionsToTxnResult WithTransactionalId(String transactionalId)
            {
                TransactionalId = transactionalId;
                return this;
            }

            private Array<AddPartitionsToTxnTopicResult> _topicResultsCollection = Array.Empty<AddPartitionsToTxnTopicResult>();
            /// <summary>
            /// <para>The results for each topic.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Array<AddPartitionsToTxnTopicResult> TopicResultsCollection
            {
                get => _topicResultsCollection;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"TopicResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _topicResultsCollection = value;
                }
            }

            /// <summary>
            /// <para>The results for each topic.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public AddPartitionsToTxnResult WithTopicResultsCollection(Array<AddPartitionsToTxnTopicResult> topicResultsCollection)
            {
                TopicResultsCollection = topicResultsCollection;
                return this;
            }
        }

        private Array<AddPartitionsToTxnTopicResult> _resultsByTopicV3AndBelowCollection = Array.Empty<AddPartitionsToTxnTopicResult>();
        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public Array<AddPartitionsToTxnTopicResult> ResultsByTopicV3AndBelowCollection
        {
            get => _resultsByTopicV3AndBelowCollection;
            private set
            {
                if (Version >= 0 && Version <= 3 == false)
                    throw new UnsupportedVersionException($"ResultsByTopicV3AndBelowCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-3");
                _resultsByTopicV3AndBelowCollection = value;
            }
        }

        /// <summary>
        /// <para>The results for each topic.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public AddPartitionsToTxnResponse WithResultsByTopicV3AndBelowCollection(Array<AddPartitionsToTxnTopicResult> resultsByTopicV3AndBelowCollection)
        {
            ResultsByTopicV3AndBelowCollection = resultsByTopicV3AndBelowCollection;
            return this;
        }

        public class AddPartitionsToTxnTopicResult : ISerialize
        {
            internal AddPartitionsToTxnTopicResult(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _resultsByPartitionCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AddPartitionsToTxnTopicResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AddPartitionsToTxnTopicResult(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ResultsByPartitionCollection = await Array<AddPartitionsToTxnPartitionResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AddPartitionsToTxnPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AddPartitionsToTxnTopicResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _resultsByPartitionCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
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
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AddPartitionsToTxnTopicResult WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<AddPartitionsToTxnPartitionResult> _resultsByPartitionCollection = Array.Empty<AddPartitionsToTxnPartitionResult>();
            /// <summary>
            /// <para>The results for each partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<AddPartitionsToTxnPartitionResult> ResultsByPartitionCollection
            {
                get => _resultsByPartitionCollection;
                private set
                {
                    _resultsByPartitionCollection = value;
                }
            }

            /// <summary>
            /// <para>The results for each partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AddPartitionsToTxnTopicResult WithResultsByPartitionCollection(Array<AddPartitionsToTxnPartitionResult> resultsByPartitionCollection)
            {
                ResultsByPartitionCollection = resultsByPartitionCollection;
                return this;
            }
        }

        public class AddPartitionsToTxnPartitionResult : ISerialize
        {
            internal AddPartitionsToTxnPartitionResult(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _partitionErrorCode.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AddPartitionsToTxnPartitionResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AddPartitionsToTxnPartitionResult(version);
                instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AddPartitionsToTxnPartitionResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionErrorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _partitionIndex = Int32.Default;
            /// <summary>
            /// <para>The partition indexes.</para>
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
            /// <para>The partition indexes.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AddPartitionsToTxnPartitionResult WithPartitionIndex(Int32 partitionIndex)
            {
                PartitionIndex = partitionIndex;
                return this;
            }

            private Int16 _partitionErrorCode = Int16.Default;
            /// <summary>
            /// <para>The response error code.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 PartitionErrorCode
            {
                get => _partitionErrorCode;
                private set
                {
                    _partitionErrorCode = value;
                }
            }

            /// <summary>
            /// <para>The response error code.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AddPartitionsToTxnPartitionResult WithPartitionErrorCode(Int16 partitionErrorCode)
            {
                PartitionErrorCode = partitionErrorCode;
                return this;
            }
        }
    }
}
