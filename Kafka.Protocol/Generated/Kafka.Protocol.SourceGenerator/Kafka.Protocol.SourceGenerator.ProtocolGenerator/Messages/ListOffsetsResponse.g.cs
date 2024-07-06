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
    public class ListOffsetsResponse : Message
    {
        public ListOffsetsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ListOffsetsResponse does not support version {version}. Valid versions are: 0-8");
            Version = version;
            IsFlexibleVersion = version >= 6;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(2);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(8);
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

        internal override int GetSize() => (Version >= 2 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ListOffsetsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ListOffsetsResponse(version);
            if (instance.Version >= 2)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<ListOffsetsTopicResponse>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ListOffsetsTopicResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ListOffsetsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 2)
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
        /// <para>Versions: 2+</para>
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
        /// <para>Versions: 2+</para>
        /// </summary>
        public ListOffsetsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Array<ListOffsetsTopicResponse> _topicsCollection = Array.Empty<ListOffsetsTopicResponse>();
        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ListOffsetsTopicResponse> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListOffsetsResponse WithTopicsCollection(params Func<ListOffsetsTopicResponse, ListOffsetsTopicResponse>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new ListOffsetsTopicResponse(Version))).ToArray();
            return this;
        }

        public delegate ListOffsetsTopicResponse CreateListOffsetsTopicResponse(ListOffsetsTopicResponse field);
        /// <summary>
        /// <para>Each topic in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListOffsetsResponse WithTopicsCollection(IEnumerable<CreateListOffsetsTopicResponse> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new ListOffsetsTopicResponse(Version))).ToArray();
            return this;
        }

        public class ListOffsetsTopicResponse : ISerialize
        {
            internal ListOffsetsTopicResponse(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 6;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ListOffsetsTopicResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ListOffsetsTopicResponse(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<ListOffsetsPartitionResponse>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ListOffsetsPartitionResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ListOffsetsTopicResponse is unknown");
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
            /// <para>The topic name</para>
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
            /// <para>The topic name</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ListOffsetsTopicResponse WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<ListOffsetsPartitionResponse> _partitionsCollection = Array.Empty<ListOffsetsPartitionResponse>();
            /// <summary>
            /// <para>Each partition in the response.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<ListOffsetsPartitionResponse> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each partition in the response.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ListOffsetsTopicResponse WithPartitionsCollection(params Func<ListOffsetsPartitionResponse, ListOffsetsPartitionResponse>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new ListOffsetsPartitionResponse(Version))).ToArray();
                return this;
            }

            public delegate ListOffsetsPartitionResponse CreateListOffsetsPartitionResponse(ListOffsetsPartitionResponse field);
            /// <summary>
            /// <para>Each partition in the response.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ListOffsetsTopicResponse WithPartitionsCollection(IEnumerable<CreateListOffsetsPartitionResponse> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new ListOffsetsPartitionResponse(Version))).ToArray();
                return this;
            }

            public class ListOffsetsPartitionResponse : ISerialize
            {
                internal ListOffsetsPartitionResponse(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 6;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + (Version >= 0 && Version <= 0 ? _oldStyleOffsetsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _timestamp.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _offset.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _leaderEpoch.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<ListOffsetsPartitionResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new ListOffsetsPartitionResponse(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 0 && instance.Version <= 0)
                        instance.OldStyleOffsetsCollection = await Array<Int64>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.Timestamp = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.Offset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 4)
                        instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for ListOffsetsPartitionResponse is unknown");
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
                    if (Version >= 0 && Version <= 0)
                        await _oldStyleOffsetsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _timestamp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _offset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 4)
                        await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public ListOffsetsPartitionResponse WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The partition error code, or 0 if there was no error.</para>
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
                /// <para>The partition error code, or 0 if there was no error.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public ListOffsetsPartitionResponse WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private Array<Int64> _oldStyleOffsetsCollection = Array.Empty<Int64>();
                /// <summary>
                /// <para>The result offsets.</para>
                /// <para>Versions: 0</para>
                /// </summary>
                public Array<Int64> OldStyleOffsetsCollection
                {
                    get => _oldStyleOffsetsCollection;
                    private set
                    {
                        if (Version >= 0 && Version <= 0 == false)
                            throw new UnsupportedVersionException($"OldStyleOffsetsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
                        _oldStyleOffsetsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The result offsets.</para>
                /// <para>Versions: 0</para>
                /// </summary>
                public ListOffsetsPartitionResponse WithOldStyleOffsetsCollection(Array<Int64> oldStyleOffsetsCollection)
                {
                    OldStyleOffsetsCollection = oldStyleOffsetsCollection;
                    return this;
                }

                private Int64 _timestamp = new Int64(-1);
                /// <summary>
                /// <para>The timestamp associated with the returned offset.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int64 Timestamp
                {
                    get => _timestamp;
                    private set
                    {
                        if (Version >= 1 == false)
                            throw new UnsupportedVersionException($"Timestamp does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                        _timestamp = value;
                    }
                }

                /// <summary>
                /// <para>The timestamp associated with the returned offset.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public ListOffsetsPartitionResponse WithTimestamp(Int64 timestamp)
                {
                    Timestamp = timestamp;
                    return this;
                }

                private Int64 _offset = new Int64(-1);
                /// <summary>
                /// <para>The returned offset.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int64 Offset
                {
                    get => _offset;
                    private set
                    {
                        if (Version >= 1 == false)
                            throw new UnsupportedVersionException($"Offset does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                        _offset = value;
                    }
                }

                /// <summary>
                /// <para>The returned offset.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public ListOffsetsPartitionResponse WithOffset(Int64 offset)
                {
                    Offset = offset;
                    return this;
                }

                private Int32 _leaderEpoch = new Int32(-1);
                /// <summary>
                /// <para>Versions: 4+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int32 LeaderEpoch
                {
                    get => _leaderEpoch;
                    private set
                    {
                        if (Version >= 4 == false)
                            throw new UnsupportedVersionException($"LeaderEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                        _leaderEpoch = value;
                    }
                }

                /// <summary>
                /// <para>Versions: 4+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public ListOffsetsPartitionResponse WithLeaderEpoch(Int32 leaderEpoch)
                {
                    LeaderEpoch = leaderEpoch;
                    return this;
                }
            }
        }
    }
}
