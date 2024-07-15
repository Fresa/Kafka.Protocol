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
    public class TxnOffsetCommitResponse : Message
    {
        public TxnOffsetCommitResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"TxnOffsetCommitResponse does not support version {version}. Valid versions are: 0-4");
            Version = version;
            IsFlexibleVersion = version >= 3;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(28);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(4);
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
        internal static async ValueTask<TxnOffsetCommitResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new TxnOffsetCommitResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<TxnOffsetCommitResponseTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TxnOffsetCommitResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for TxnOffsetCommitResponse is unknown");
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
        public TxnOffsetCommitResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Array<TxnOffsetCommitResponseTopic> _topicsCollection = Array.Empty<TxnOffsetCommitResponseTopic>();
        /// <summary>
        /// <para>The responses for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<TxnOffsetCommitResponseTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The responses for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public TxnOffsetCommitResponse WithTopicsCollection(params Func<TxnOffsetCommitResponseTopic, TxnOffsetCommitResponseTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TxnOffsetCommitResponseTopic(Version))).ToArray();
            return this;
        }

        public delegate TxnOffsetCommitResponseTopic CreateTxnOffsetCommitResponseTopic(TxnOffsetCommitResponseTopic field);
        /// <summary>
        /// <para>The responses for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public TxnOffsetCommitResponse WithTopicsCollection(IEnumerable<CreateTxnOffsetCommitResponseTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new TxnOffsetCommitResponseTopic(Version))).ToArray();
            return this;
        }

        public class TxnOffsetCommitResponseTopic : ISerialize
        {
            internal TxnOffsetCommitResponseTopic(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TxnOffsetCommitResponseTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TxnOffsetCommitResponseTopic(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<TxnOffsetCommitResponsePartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TxnOffsetCommitResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TxnOffsetCommitResponseTopic is unknown");
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
            public TxnOffsetCommitResponseTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<TxnOffsetCommitResponsePartition> _partitionsCollection = Array.Empty<TxnOffsetCommitResponsePartition>();
            /// <summary>
            /// <para>The responses for each partition in the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TxnOffsetCommitResponsePartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The responses for each partition in the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TxnOffsetCommitResponseTopic WithPartitionsCollection(params Func<TxnOffsetCommitResponsePartition, TxnOffsetCommitResponsePartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new TxnOffsetCommitResponsePartition(Version))).ToArray();
                return this;
            }

            public delegate TxnOffsetCommitResponsePartition CreateTxnOffsetCommitResponsePartition(TxnOffsetCommitResponsePartition field);
            /// <summary>
            /// <para>The responses for each partition in the topic.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TxnOffsetCommitResponseTopic WithPartitionsCollection(IEnumerable<CreateTxnOffsetCommitResponsePartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new TxnOffsetCommitResponsePartition(Version))).ToArray();
                return this;
            }

            public class TxnOffsetCommitResponsePartition : ISerialize
            {
                internal TxnOffsetCommitResponsePartition(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<TxnOffsetCommitResponsePartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new TxnOffsetCommitResponsePartition(version);
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
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for TxnOffsetCommitResponsePartition is unknown");
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
                public TxnOffsetCommitResponsePartition WithPartitionIndex(Int32 partitionIndex)
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
                public TxnOffsetCommitResponsePartition WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }
            }
        }
    }
}
