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
    public class ShareFetchRequest : Message, IRespond<ShareFetchResponse>
    {
        public ShareFetchRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ShareFetchRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(78);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
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

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + _memberId.GetSize(IsFlexibleVersion) + _shareSessionEpoch.GetSize(IsFlexibleVersion) + _maxWaitMs.GetSize(IsFlexibleVersion) + _minBytes.GetSize(IsFlexibleVersion) + _maxBytes.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + _forgottenTopicsDataCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ShareFetchRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ShareFetchRequest(version);
            instance.GroupId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ShareSessionEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MaxWaitMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MinBytes = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MaxBytes = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<FetchTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => FetchTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ForgottenTopicsDataCollection = await Array<ForgottenTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ForgottenTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ShareFetchRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _shareSessionEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _maxWaitMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _minBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _maxBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _forgottenTopicsDataCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private NullableString _groupId = new NullableString(null);
        /// <summary>
        /// <para>The group identifier.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? GroupId
        {
            get => _groupId;
            private set
            {
                _groupId = value;
            }
        }

        /// <summary>
        /// <para>The group identifier.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ShareFetchRequest WithGroupId(String? groupId)
        {
            GroupId = groupId;
            return this;
        }

        private NullableString _memberId = NullableString.Default;
        /// <summary>
        /// <para>The member ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String? MemberId
        {
            get => _memberId;
            private set
            {
                _memberId = value;
            }
        }

        /// <summary>
        /// <para>The member ID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareFetchRequest WithMemberId(String? memberId)
        {
            MemberId = memberId;
            return this;
        }

        private Int32 _shareSessionEpoch = Int32.Default;
        /// <summary>
        /// <para>The current share session epoch: 0 to open a share session; -1 to close it; otherwise increments for consecutive requests.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 ShareSessionEpoch
        {
            get => _shareSessionEpoch;
            private set
            {
                _shareSessionEpoch = value;
            }
        }

        /// <summary>
        /// <para>The current share session epoch: 0 to open a share session; -1 to close it; otherwise increments for consecutive requests.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareFetchRequest WithShareSessionEpoch(Int32 shareSessionEpoch)
        {
            ShareSessionEpoch = shareSessionEpoch;
            return this;
        }

        private Int32 _maxWaitMs = Int32.Default;
        /// <summary>
        /// <para>The maximum time in milliseconds to wait for the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 MaxWaitMs
        {
            get => _maxWaitMs;
            private set
            {
                _maxWaitMs = value;
            }
        }

        /// <summary>
        /// <para>The maximum time in milliseconds to wait for the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareFetchRequest WithMaxWaitMs(Int32 maxWaitMs)
        {
            MaxWaitMs = maxWaitMs;
            return this;
        }

        private Int32 _minBytes = Int32.Default;
        /// <summary>
        /// <para>The minimum bytes to accumulate in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 MinBytes
        {
            get => _minBytes;
            private set
            {
                _minBytes = value;
            }
        }

        /// <summary>
        /// <para>The minimum bytes to accumulate in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareFetchRequest WithMinBytes(Int32 minBytes)
        {
            MinBytes = minBytes;
            return this;
        }

        private Int32 _maxBytes = new Int32(0x7fffffff);
        /// <summary>
        /// <para>The maximum bytes to fetch.  See KIP-74 for cases where this limit may not be honored.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 0x7fffffff</para>
        /// </summary>
        public Int32 MaxBytes
        {
            get => _maxBytes;
            private set
            {
                _maxBytes = value;
            }
        }

        /// <summary>
        /// <para>The maximum bytes to fetch.  See KIP-74 for cases where this limit may not be honored.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 0x7fffffff</para>
        /// </summary>
        public ShareFetchRequest WithMaxBytes(Int32 maxBytes)
        {
            MaxBytes = maxBytes;
            return this;
        }

        private Array<FetchTopic> _topicsCollection = Array.Empty<FetchTopic>();
        /// <summary>
        /// <para>The topics to fetch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<FetchTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The topics to fetch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareFetchRequest WithTopicsCollection(params Func<FetchTopic, FetchTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new FetchTopic(Version))).ToArray();
            return this;
        }

        public delegate FetchTopic CreateFetchTopic(FetchTopic field);
        /// <summary>
        /// <para>The topics to fetch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareFetchRequest WithTopicsCollection(IEnumerable<CreateFetchTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new FetchTopic(Version))).ToArray();
            return this;
        }

        public class FetchTopic : ISerialize
        {
            internal FetchTopic(Int16 version)
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
            internal int GetSize(bool _) => _topicId.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<FetchTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new FetchTopic(version);
                instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<FetchPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => FetchPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for FetchTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
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
            public FetchTopic WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<FetchPartition> _partitionsCollection = Array.Empty<FetchPartition>();
            /// <summary>
            /// <para>The partitions to fetch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<FetchPartition> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions to fetch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public FetchTopic WithPartitionsCollection(params Func<FetchPartition, FetchPartition>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new FetchPartition(Version))).ToArray();
                return this;
            }

            public delegate FetchPartition CreateFetchPartition(FetchPartition field);
            /// <summary>
            /// <para>The partitions to fetch.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public FetchTopic WithPartitionsCollection(IEnumerable<CreateFetchPartition> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new FetchPartition(Version))).ToArray();
                return this;
            }

            public class FetchPartition : ISerialize
            {
                internal FetchPartition(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _partitionMaxBytes.GetSize(IsFlexibleVersion) + _acknowledgementBatchesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<FetchPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new FetchPartition(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionMaxBytes = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.AcknowledgementBatchesCollection = await Array<AcknowledgementBatch>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AcknowledgementBatch.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for FetchPartition is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _partitionMaxBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _acknowledgementBatchesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public FetchPartition WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int32 _partitionMaxBytes = Int32.Default;
                /// <summary>
                /// <para>The maximum bytes to fetch from this partition. 0 when only acknowledgement with no fetching is required. See KIP-74 for cases where this limit may not be honored.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 PartitionMaxBytes
                {
                    get => _partitionMaxBytes;
                    private set
                    {
                        _partitionMaxBytes = value;
                    }
                }

                /// <summary>
                /// <para>The maximum bytes to fetch from this partition. 0 when only acknowledgement with no fetching is required. See KIP-74 for cases where this limit may not be honored.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public FetchPartition WithPartitionMaxBytes(Int32 partitionMaxBytes)
                {
                    PartitionMaxBytes = partitionMaxBytes;
                    return this;
                }

                private Array<AcknowledgementBatch> _acknowledgementBatchesCollection = Array.Empty<AcknowledgementBatch>();
                /// <summary>
                /// <para>Record batches to acknowledge.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<AcknowledgementBatch> AcknowledgementBatchesCollection
                {
                    get => _acknowledgementBatchesCollection;
                    private set
                    {
                        _acknowledgementBatchesCollection = value;
                    }
                }

                /// <summary>
                /// <para>Record batches to acknowledge.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public FetchPartition WithAcknowledgementBatchesCollection(params Func<AcknowledgementBatch, AcknowledgementBatch>[] createFields)
                {
                    AcknowledgementBatchesCollection = createFields.Select(createField => createField(new AcknowledgementBatch(Version))).ToArray();
                    return this;
                }

                public delegate AcknowledgementBatch CreateAcknowledgementBatch(AcknowledgementBatch field);
                /// <summary>
                /// <para>Record batches to acknowledge.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public FetchPartition WithAcknowledgementBatchesCollection(IEnumerable<CreateAcknowledgementBatch> createFields)
                {
                    AcknowledgementBatchesCollection = createFields.Select(createField => createField(new AcknowledgementBatch(Version))).ToArray();
                    return this;
                }

                public class AcknowledgementBatch : ISerialize
                {
                    internal AcknowledgementBatch(Int16 version)
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
                    internal int GetSize(bool _) => _firstOffset.GetSize(IsFlexibleVersion) + _lastOffset.GetSize(IsFlexibleVersion) + _acknowledgeTypesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<AcknowledgementBatch> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new AcknowledgementBatch(version);
                        instance.FirstOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.LastOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.AcknowledgeTypesCollection = await Array<Int8>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for AcknowledgementBatch is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        await _firstOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _lastOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _acknowledgeTypesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private Int64 _firstOffset = Int64.Default;
                    /// <summary>
                    /// <para>First offset of batch of records to acknowledge.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int64 FirstOffset
                    {
                        get => _firstOffset;
                        private set
                        {
                            _firstOffset = value;
                        }
                    }

                    /// <summary>
                    /// <para>First offset of batch of records to acknowledge.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public AcknowledgementBatch WithFirstOffset(Int64 firstOffset)
                    {
                        FirstOffset = firstOffset;
                        return this;
                    }

                    private Int64 _lastOffset = Int64.Default;
                    /// <summary>
                    /// <para>Last offset (inclusive) of batch of records to acknowledge.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int64 LastOffset
                    {
                        get => _lastOffset;
                        private set
                        {
                            _lastOffset = value;
                        }
                    }

                    /// <summary>
                    /// <para>Last offset (inclusive) of batch of records to acknowledge.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public AcknowledgementBatch WithLastOffset(Int64 lastOffset)
                    {
                        LastOffset = lastOffset;
                        return this;
                    }

                    private Array<Int8> _acknowledgeTypesCollection = Array.Empty<Int8>();
                    /// <summary>
                    /// <para>Array of acknowledge types - 0:Gap,1:Accept,2:Release,3:Reject.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Array<Int8> AcknowledgeTypesCollection
                    {
                        get => _acknowledgeTypesCollection;
                        private set
                        {
                            _acknowledgeTypesCollection = value;
                        }
                    }

                    /// <summary>
                    /// <para>Array of acknowledge types - 0:Gap,1:Accept,2:Release,3:Reject.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public AcknowledgementBatch WithAcknowledgeTypesCollection(Array<Int8> acknowledgeTypesCollection)
                    {
                        AcknowledgeTypesCollection = acknowledgeTypesCollection;
                        return this;
                    }
                }
            }
        }

        private Array<ForgottenTopic> _forgottenTopicsDataCollection = Array.Empty<ForgottenTopic>();
        /// <summary>
        /// <para>The partitions to remove from this share session.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ForgottenTopic> ForgottenTopicsDataCollection
        {
            get => _forgottenTopicsDataCollection;
            private set
            {
                _forgottenTopicsDataCollection = value;
            }
        }

        /// <summary>
        /// <para>The partitions to remove from this share session.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareFetchRequest WithForgottenTopicsDataCollection(params Func<ForgottenTopic, ForgottenTopic>[] createFields)
        {
            ForgottenTopicsDataCollection = createFields.Select(createField => createField(new ForgottenTopic(Version))).ToArray();
            return this;
        }

        public delegate ForgottenTopic CreateForgottenTopic(ForgottenTopic field);
        /// <summary>
        /// <para>The partitions to remove from this share session.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareFetchRequest WithForgottenTopicsDataCollection(IEnumerable<CreateForgottenTopic> createFields)
        {
            ForgottenTopicsDataCollection = createFields.Select(createField => createField(new ForgottenTopic(Version))).ToArray();
            return this;
        }

        public class ForgottenTopic : ISerialize
        {
            internal ForgottenTopic(Int16 version)
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
            internal int GetSize(bool _) => _topicId.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ForgottenTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ForgottenTopic(version);
                instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ForgottenTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
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
            public ForgottenTopic WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partitions indexes to forget.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<Int32> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The partitions indexes to forget.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ForgottenTopic WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        public ShareFetchResponse Respond() => new ShareFetchResponse(Version);
    }
}
