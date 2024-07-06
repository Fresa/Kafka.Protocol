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
    public class DeleteRecordsResponse : Message
    {
        public DeleteRecordsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DeleteRecordsResponse does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(21);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DeleteRecordsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DeleteRecordsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Map<String, DeleteRecordsTopicResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DeleteRecordsTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteRecordsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public DeleteRecordsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Map<String, DeleteRecordsTopicResult> _topicsCollection = Map<String, DeleteRecordsTopicResult>.Default;
        /// <summary>
        /// <para>Each topic that we wanted to delete records from.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, DeleteRecordsTopicResult> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic that we wanted to delete records from.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteRecordsResponse WithTopicsCollection(params Func<DeleteRecordsTopicResult, DeleteRecordsTopicResult>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new DeleteRecordsTopicResult(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate DeleteRecordsTopicResult CreateDeleteRecordsTopicResult(DeleteRecordsTopicResult field);
        /// <summary>
        /// <para>Each topic that we wanted to delete records from.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteRecordsResponse WithTopicsCollection(IEnumerable<CreateDeleteRecordsTopicResult> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new DeleteRecordsTopicResult(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class DeleteRecordsTopicResult : ISerialize
        {
            internal DeleteRecordsTopicResult(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DeleteRecordsTopicResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DeleteRecordsTopicResult(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Map<Int32, DeleteRecordsPartitionResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DeleteRecordsPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.PartitionIndex, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteRecordsTopicResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public DeleteRecordsTopicResult WithName(String name)
            {
                Name = name;
                return this;
            }

            private Map<Int32, DeleteRecordsPartitionResult> _partitionsCollection = Map<Int32, DeleteRecordsPartitionResult>.Default;
            /// <summary>
            /// <para>Each partition that we wanted to delete records from.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Map<Int32, DeleteRecordsPartitionResult> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition that we wanted to delete records from.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteRecordsTopicResult WithPartitionsCollection(params Func<DeleteRecordsPartitionResult, DeleteRecordsPartitionResult>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new DeleteRecordsPartitionResult(Version))).ToDictionary(field => field.PartitionIndex);
                return this;
            }

            public delegate DeleteRecordsPartitionResult CreateDeleteRecordsPartitionResult(DeleteRecordsPartitionResult field);
            /// <summary>
            /// <para>Each partition that we wanted to delete records from.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteRecordsTopicResult WithPartitionsCollection(IEnumerable<CreateDeleteRecordsPartitionResult> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new DeleteRecordsPartitionResult(Version))).ToDictionary(field => field.PartitionIndex);
                return this;
            }

            public class DeleteRecordsPartitionResult : ISerialize
            {
                internal DeleteRecordsPartitionResult(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _lowWatermark.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<DeleteRecordsPartitionResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new DeleteRecordsPartitionResult(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.LowWatermark = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteRecordsPartitionResult is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _lowWatermark.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public DeleteRecordsPartitionResult WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int64 _lowWatermark = Int64.Default;
                /// <summary>
                /// <para>The partition low water mark.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int64 LowWatermark
                {
                    get => _lowWatermark;
                    private set
                    {
                        _lowWatermark = value;
                    }
                }

                /// <summary>
                /// <para>The partition low water mark.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DeleteRecordsPartitionResult WithLowWatermark(Int64 lowWatermark)
                {
                    LowWatermark = lowWatermark;
                    return this;
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The deletion error code, or 0 if the deletion succeeded.</para>
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
                /// <para>The deletion error code, or 0 if the deletion succeeded.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DeleteRecordsPartitionResult WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }
            }
        }
    }
}
