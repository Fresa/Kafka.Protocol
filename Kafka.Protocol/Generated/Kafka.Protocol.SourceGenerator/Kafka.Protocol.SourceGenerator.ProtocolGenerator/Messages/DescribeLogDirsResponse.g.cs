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
    public class DescribeLogDirsResponse : Message
    {
        public DescribeLogDirsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeLogDirsResponse does not support version {version}. Valid versions are: 1-4");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(35);
        public static readonly Int16 MinVersion = Int16.From(1);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + (Version >= 3 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + _resultsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeLogDirsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeLogDirsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ResultsCollection = await Array<DescribeLogDirsResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeLogDirsResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeLogDirsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _resultsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public DescribeLogDirsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The error code, or 0 if there was no error.</para>
        /// <para>Versions: 3+</para>
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
        /// <para>Versions: 3+</para>
        /// </summary>
        public DescribeLogDirsResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<DescribeLogDirsResult> _resultsCollection = Array.Empty<DescribeLogDirsResult>();
        /// <summary>
        /// <para>The log directories.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DescribeLogDirsResult> ResultsCollection
        {
            get => _resultsCollection;
            private set
            {
                _resultsCollection = value;
            }
        }

        /// <summary>
        /// <para>The log directories.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeLogDirsResponse WithResultsCollection(params Func<DescribeLogDirsResult, DescribeLogDirsResult>[] createFields)
        {
            ResultsCollection = createFields.Select(createField => createField(new DescribeLogDirsResult(Version))).ToArray();
            return this;
        }

        public delegate DescribeLogDirsResult CreateDescribeLogDirsResult(DescribeLogDirsResult field);
        /// <summary>
        /// <para>The log directories.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeLogDirsResponse WithResultsCollection(IEnumerable<CreateDescribeLogDirsResult> createFields)
        {
            ResultsCollection = createFields.Select(createField => createField(new DescribeLogDirsResult(Version))).ToArray();
            return this;
        }

        public class DescribeLogDirsResult : ISerialize
        {
            internal DescribeLogDirsResult(Int16 version)
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
            internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _logDir.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (Version >= 4 ? _totalBytes.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _usableBytes.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribeLogDirsResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribeLogDirsResult(version);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.LogDir = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicsCollection = await Array<DescribeLogDirsTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeLogDirsTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.TotalBytes = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.UsableBytes = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeLogDirsResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _logDir.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _totalBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _usableBytes.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public DescribeLogDirsResult WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private String _logDir = String.Default;
            /// <summary>
            /// <para>The absolute log directory path.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String LogDir
            {
                get => _logDir;
                private set
                {
                    _logDir = value;
                }
            }

            /// <summary>
            /// <para>The absolute log directory path.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeLogDirsResult WithLogDir(String logDir)
            {
                LogDir = logDir;
                return this;
            }

            private Array<DescribeLogDirsTopic> _topicsCollection = Array.Empty<DescribeLogDirsTopic>();
            /// <summary>
            /// <para>The topics.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<DescribeLogDirsTopic> TopicsCollection
            {
                get => _topicsCollection;
                private set
                {
                    _topicsCollection = value;
                }
            }

            /// <summary>
            /// <para>The topics.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeLogDirsResult WithTopicsCollection(params Func<DescribeLogDirsTopic, DescribeLogDirsTopic>[] createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new DescribeLogDirsTopic(Version))).ToArray();
                return this;
            }

            public delegate DescribeLogDirsTopic CreateDescribeLogDirsTopic(DescribeLogDirsTopic field);
            /// <summary>
            /// <para>The topics.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeLogDirsResult WithTopicsCollection(IEnumerable<CreateDescribeLogDirsTopic> createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new DescribeLogDirsTopic(Version))).ToArray();
                return this;
            }

            public class DescribeLogDirsTopic : ISerialize
            {
                internal DescribeLogDirsTopic(Int16 version)
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
                internal static async ValueTask<DescribeLogDirsTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new DescribeLogDirsTopic(version);
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionsCollection = await Array<DescribeLogDirsPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeLogDirsPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeLogDirsTopic is unknown");
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
                public DescribeLogDirsTopic WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private Array<DescribeLogDirsPartition> _partitionsCollection = Array.Empty<DescribeLogDirsPartition>();
                /// <summary>
                /// <para>The partitions.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<DescribeLogDirsPartition> PartitionsCollection
                {
                    get => _partitionsCollection;
                    private set
                    {
                        _partitionsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The partitions.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeLogDirsTopic WithPartitionsCollection(params Func<DescribeLogDirsPartition, DescribeLogDirsPartition>[] createFields)
                {
                    PartitionsCollection = createFields.Select(createField => createField(new DescribeLogDirsPartition(Version))).ToArray();
                    return this;
                }

                public delegate DescribeLogDirsPartition CreateDescribeLogDirsPartition(DescribeLogDirsPartition field);
                /// <summary>
                /// <para>The partitions.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeLogDirsTopic WithPartitionsCollection(IEnumerable<CreateDescribeLogDirsPartition> createFields)
                {
                    PartitionsCollection = createFields.Select(createField => createField(new DescribeLogDirsPartition(Version))).ToArray();
                    return this;
                }

                public class DescribeLogDirsPartition : ISerialize
                {
                    internal DescribeLogDirsPartition(Int16 version)
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
                    internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _partitionSize.GetSize(IsFlexibleVersion) + _offsetLag.GetSize(IsFlexibleVersion) + _isFutureKey.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<DescribeLogDirsPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new DescribeLogDirsPartition(version);
                        instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.PartitionSize = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.OffsetLag = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        instance.IsFutureKey = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeLogDirsPartition is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _partitionSize.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _offsetLag.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        await _isFutureKey.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                    public DescribeLogDirsPartition WithPartitionIndex(Int32 partitionIndex)
                    {
                        PartitionIndex = partitionIndex;
                        return this;
                    }

                    private Int64 _partitionSize = Int64.Default;
                    /// <summary>
                    /// <para>The size of the log segments in this partition in bytes.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int64 PartitionSize
                    {
                        get => _partitionSize;
                        private set
                        {
                            _partitionSize = value;
                        }
                    }

                    /// <summary>
                    /// <para>The size of the log segments in this partition in bytes.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public DescribeLogDirsPartition WithPartitionSize(Int64 partitionSize)
                    {
                        PartitionSize = partitionSize;
                        return this;
                    }

                    private Int64 _offsetLag = Int64.Default;
                    /// <summary>
                    /// <para>The lag of the log's LEO w.r.t. partition's HW (if it is the current log for the partition) or current replica's LEO (if it is the future log for the partition).</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Int64 OffsetLag
                    {
                        get => _offsetLag;
                        private set
                        {
                            _offsetLag = value;
                        }
                    }

                    /// <summary>
                    /// <para>The lag of the log's LEO w.r.t. partition's HW (if it is the current log for the partition) or current replica's LEO (if it is the future log for the partition).</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public DescribeLogDirsPartition WithOffsetLag(Int64 offsetLag)
                    {
                        OffsetLag = offsetLag;
                        return this;
                    }

                    private Boolean _isFutureKey = Boolean.Default;
                    /// <summary>
                    /// <para>True if this log is created by AlterReplicaLogDirsRequest and will replace the current log of the replica in the future.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public Boolean IsFutureKey
                    {
                        get => _isFutureKey;
                        private set
                        {
                            _isFutureKey = value;
                        }
                    }

                    /// <summary>
                    /// <para>True if this log is created by AlterReplicaLogDirsRequest and will replace the current log of the replica in the future.</para>
                    /// <para>Versions: 0+</para>
                    /// </summary>
                    public DescribeLogDirsPartition WithIsFutureKey(Boolean isFutureKey)
                    {
                        IsFutureKey = isFutureKey;
                        return this;
                    }
                }
            }

            private Int64 _totalBytes = new Int64(-1);
            /// <summary>
            /// <para>The total size in bytes of the volume the log directory is in.</para>
            /// <para>Versions: 4+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public Int64 TotalBytes
            {
                get => _totalBytes;
                private set
                {
                    _totalBytes = value;
                }
            }

            /// <summary>
            /// <para>The total size in bytes of the volume the log directory is in.</para>
            /// <para>Versions: 4+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public DescribeLogDirsResult WithTotalBytes(Int64 totalBytes)
            {
                TotalBytes = totalBytes;
                return this;
            }

            private Int64 _usableBytes = new Int64(-1);
            /// <summary>
            /// <para>The usable size in bytes of the volume the log directory is in.</para>
            /// <para>Versions: 4+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public Int64 UsableBytes
            {
                get => _usableBytes;
                private set
                {
                    _usableBytes = value;
                }
            }

            /// <summary>
            /// <para>The usable size in bytes of the volume the log directory is in.</para>
            /// <para>Versions: 4+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public DescribeLogDirsResult WithUsableBytes(Int64 usableBytes)
            {
                UsableBytes = usableBytes;
                return this;
            }
        }
    }
}
