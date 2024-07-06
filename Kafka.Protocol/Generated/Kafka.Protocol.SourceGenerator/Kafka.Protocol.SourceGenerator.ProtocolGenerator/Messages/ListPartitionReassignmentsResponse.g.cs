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
    public class ListPartitionReassignmentsResponse : Message
    {
        public ListPartitionReassignmentsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ListPartitionReassignmentsResponse does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(46);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ListPartitionReassignmentsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ListPartitionReassignmentsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Array<OngoingTopicReassignment>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OngoingTopicReassignment.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ListPartitionReassignmentsResponse is unknown");
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
        public ListPartitionReassignmentsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The top-level error code, or 0 if there was no error</para>
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
        /// <para>The top-level error code, or 0 if there was no error</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListPartitionReassignmentsResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private NullableString _errorMessage = NullableString.Default;
        /// <summary>
        /// <para>The top-level error message, or null if there was no error.</para>
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
        /// <para>The top-level error message, or null if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListPartitionReassignmentsResponse WithErrorMessage(String? errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        private Array<OngoingTopicReassignment> _topicsCollection = Array.Empty<OngoingTopicReassignment>();
        /// <summary>
        /// <para>The ongoing reassignments for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<OngoingTopicReassignment> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>The ongoing reassignments for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListPartitionReassignmentsResponse WithTopicsCollection(params Func<OngoingTopicReassignment, OngoingTopicReassignment>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OngoingTopicReassignment(Version))).ToArray();
            return this;
        }

        public delegate OngoingTopicReassignment CreateOngoingTopicReassignment(OngoingTopicReassignment field);
        /// <summary>
        /// <para>The ongoing reassignments for each topic.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListPartitionReassignmentsResponse WithTopicsCollection(IEnumerable<CreateOngoingTopicReassignment> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new OngoingTopicReassignment(Version))).ToArray();
            return this;
        }

        public class OngoingTopicReassignment : ISerialize
        {
            internal OngoingTopicReassignment(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<OngoingTopicReassignment> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new OngoingTopicReassignment(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<OngoingPartitionReassignment>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OngoingPartitionReassignment.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for OngoingTopicReassignment is unknown");
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
            public OngoingTopicReassignment WithName(String name)
            {
                Name = name;
                return this;
            }

            private Array<OngoingPartitionReassignment> _partitionsCollection = Array.Empty<OngoingPartitionReassignment>();
            /// <summary>
            /// <para>The ongoing reassignments for each partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<OngoingPartitionReassignment> PartitionsCollection
            {
                get => _partitionsCollection;
                private set
                {
                    _partitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>The ongoing reassignments for each partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OngoingTopicReassignment WithPartitionsCollection(params Func<OngoingPartitionReassignment, OngoingPartitionReassignment>[] createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new OngoingPartitionReassignment(Version))).ToArray();
                return this;
            }

            public delegate OngoingPartitionReassignment CreateOngoingPartitionReassignment(OngoingPartitionReassignment field);
            /// <summary>
            /// <para>The ongoing reassignments for each partition.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public OngoingTopicReassignment WithPartitionsCollection(IEnumerable<CreateOngoingPartitionReassignment> createFields)
            {
                PartitionsCollection = createFields.Select(createField => createField(new OngoingPartitionReassignment(Version))).ToArray();
                return this;
            }

            public class OngoingPartitionReassignment : ISerialize
            {
                internal OngoingPartitionReassignment(Int16 version)
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
                internal int GetSize(bool _) => _partitionIndex.GetSize(IsFlexibleVersion) + _replicasCollection.GetSize(IsFlexibleVersion) + _addingReplicasCollection.GetSize(IsFlexibleVersion) + _removingReplicasCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<OngoingPartitionReassignment> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new OngoingPartitionReassignment(version);
                    instance.PartitionIndex = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ReplicasCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.AddingReplicasCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    instance.RemovingReplicasCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for OngoingPartitionReassignment is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _partitionIndex.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _replicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _addingReplicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _removingReplicasCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int32 _partitionIndex = Int32.Default;
                /// <summary>
                /// <para>The index of the partition.</para>
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
                /// <para>The index of the partition.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public OngoingPartitionReassignment WithPartitionIndex(Int32 partitionIndex)
                {
                    PartitionIndex = partitionIndex;
                    return this;
                }

                private Array<Int32> _replicasCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The current replica set.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> ReplicasCollection
                {
                    get => _replicasCollection;
                    private set
                    {
                        _replicasCollection = value;
                    }
                }

                /// <summary>
                /// <para>The current replica set.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public OngoingPartitionReassignment WithReplicasCollection(Array<Int32> replicasCollection)
                {
                    ReplicasCollection = replicasCollection;
                    return this;
                }

                private Array<Int32> _addingReplicasCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The set of replicas we are currently adding.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> AddingReplicasCollection
                {
                    get => _addingReplicasCollection;
                    private set
                    {
                        _addingReplicasCollection = value;
                    }
                }

                /// <summary>
                /// <para>The set of replicas we are currently adding.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public OngoingPartitionReassignment WithAddingReplicasCollection(Array<Int32> addingReplicasCollection)
                {
                    AddingReplicasCollection = addingReplicasCollection;
                    return this;
                }

                private Array<Int32> _removingReplicasCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The set of replicas we are currently removing.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> RemovingReplicasCollection
                {
                    get => _removingReplicasCollection;
                    private set
                    {
                        _removingReplicasCollection = value;
                    }
                }

                /// <summary>
                /// <para>The set of replicas we are currently removing.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public OngoingPartitionReassignment WithRemovingReplicasCollection(Array<Int32> removingReplicasCollection)
                {
                    RemovingReplicasCollection = removingReplicasCollection;
                    return this;
                }
            }
        }
    }
}
