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
    public class StreamsGroupHeartbeatResponse : Message
    {
        public StreamsGroupHeartbeatResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"StreamsGroupHeartbeatResponse does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(88);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _memberId.GetSize(IsFlexibleVersion) + _memberEpoch.GetSize(IsFlexibleVersion) + _heartbeatIntervalMs.GetSize(IsFlexibleVersion) + _acceptableRecoveryLag.GetSize(IsFlexibleVersion) + _taskOffsetIntervalMs.GetSize(IsFlexibleVersion) + _statusCollection.GetSize(IsFlexibleVersion) + _activeTasksCollection.GetSize(IsFlexibleVersion) + _standbyTasksCollection.GetSize(IsFlexibleVersion) + _warmupTasksCollection.GetSize(IsFlexibleVersion) + _endpointInformationEpoch.GetSize(IsFlexibleVersion) + _partitionsByUserEndpointCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<StreamsGroupHeartbeatResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new StreamsGroupHeartbeatResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.HeartbeatIntervalMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.AcceptableRecoveryLag = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TaskOffsetIntervalMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.StatusCollection = await NullableArray<Status>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Status.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ActiveTasksCollection = await NullableArray<TaskIds>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskIds.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.StandbyTasksCollection = await NullableArray<TaskIds>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskIds.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.WarmupTasksCollection = await NullableArray<TaskIds>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TaskIds.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.EndpointInformationEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.PartitionsByUserEndpointCollection = await NullableArray<EndpointToPartitions>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => EndpointToPartitions.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for StreamsGroupHeartbeatResponse is unknown");
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
            await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _heartbeatIntervalMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _acceptableRecoveryLag.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _taskOffsetIntervalMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _statusCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _activeTasksCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _standbyTasksCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _warmupTasksCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _endpointInformationEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _partitionsByUserEndpointCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public StreamsGroupHeartbeatResponse WithThrottleTimeMs(Int32 throttleTimeMs)
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
        public StreamsGroupHeartbeatResponse WithErrorCode(Int16 errorCode)
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
        public StreamsGroupHeartbeatResponse WithErrorMessage(String? errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The member id is always generated by the streams consumer.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String MemberId
        {
            get => _memberId;
            private set
            {
                _memberId = value;
            }
        }

        /// <summary>
        /// <para>The member id is always generated by the streams consumer.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private Int32 _memberEpoch = Int32.Default;
        /// <summary>
        /// <para>The member epoch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 MemberEpoch
        {
            get => _memberEpoch;
            private set
            {
                _memberEpoch = value;
            }
        }

        /// <summary>
        /// <para>The member epoch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithMemberEpoch(Int32 memberEpoch)
        {
            MemberEpoch = memberEpoch;
            return this;
        }

        private Int32 _heartbeatIntervalMs = Int32.Default;
        /// <summary>
        /// <para>The heartbeat interval in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 HeartbeatIntervalMs
        {
            get => _heartbeatIntervalMs;
            private set
            {
                _heartbeatIntervalMs = value;
            }
        }

        /// <summary>
        /// <para>The heartbeat interval in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithHeartbeatIntervalMs(Int32 heartbeatIntervalMs)
        {
            HeartbeatIntervalMs = heartbeatIntervalMs;
            return this;
        }

        private Int32 _acceptableRecoveryLag = Int32.Default;
        /// <summary>
        /// <para>The maximal lag a warm-up task can have to be considered caught-up.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 AcceptableRecoveryLag
        {
            get => _acceptableRecoveryLag;
            private set
            {
                _acceptableRecoveryLag = value;
            }
        }

        /// <summary>
        /// <para>The maximal lag a warm-up task can have to be considered caught-up.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithAcceptableRecoveryLag(Int32 acceptableRecoveryLag)
        {
            AcceptableRecoveryLag = acceptableRecoveryLag;
            return this;
        }

        private Int32 _taskOffsetIntervalMs = Int32.Default;
        /// <summary>
        /// <para>The interval in which the task changelog offsets on a client are updated on the broker. The offsets are sent with the next heartbeat after this time has passed.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 TaskOffsetIntervalMs
        {
            get => _taskOffsetIntervalMs;
            private set
            {
                _taskOffsetIntervalMs = value;
            }
        }

        /// <summary>
        /// <para>The interval in which the task changelog offsets on a client are updated on the broker. The offsets are sent with the next heartbeat after this time has passed.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithTaskOffsetIntervalMs(Int32 taskOffsetIntervalMs)
        {
            TaskOffsetIntervalMs = taskOffsetIntervalMs;
            return this;
        }

        private NullableArray<Status> _statusCollection = Array.Empty<Status>();
        /// <summary>
        /// <para>Indicate zero or more status for the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<Status>? StatusCollection
        {
            get => _statusCollection;
            private set
            {
                _statusCollection = value;
            }
        }

        /// <summary>
        /// <para>Indicate zero or more status for the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithStatusCollection(Array<Status>? statusCollection)
        {
            StatusCollection = statusCollection;
            return this;
        }

        private NullableArray<TaskIds> _activeTasksCollection = new NullableArray<TaskIds>(null);
        /// <summary>
        /// <para>Assigned active tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<TaskIds>? ActiveTasksCollection
        {
            get => _activeTasksCollection;
            private set
            {
                _activeTasksCollection = value;
            }
        }

        /// <summary>
        /// <para>Assigned active tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithActiveTasksCollection(Array<TaskIds>? activeTasksCollection)
        {
            ActiveTasksCollection = activeTasksCollection;
            return this;
        }

        private NullableArray<TaskIds> _standbyTasksCollection = new NullableArray<TaskIds>(null);
        /// <summary>
        /// <para>Assigned standby tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<TaskIds>? StandbyTasksCollection
        {
            get => _standbyTasksCollection;
            private set
            {
                _standbyTasksCollection = value;
            }
        }

        /// <summary>
        /// <para>Assigned standby tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithStandbyTasksCollection(Array<TaskIds>? standbyTasksCollection)
        {
            StandbyTasksCollection = standbyTasksCollection;
            return this;
        }

        private NullableArray<TaskIds> _warmupTasksCollection = new NullableArray<TaskIds>(null);
        /// <summary>
        /// <para>Assigned warm-up tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<TaskIds>? WarmupTasksCollection
        {
            get => _warmupTasksCollection;
            private set
            {
                _warmupTasksCollection = value;
            }
        }

        /// <summary>
        /// <para>Assigned warm-up tasks for this client. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithWarmupTasksCollection(Array<TaskIds>? warmupTasksCollection)
        {
            WarmupTasksCollection = warmupTasksCollection;
            return this;
        }

        private Int32 _endpointInformationEpoch = Int32.Default;
        /// <summary>
        /// <para>The endpoint epoch set in the response</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 EndpointInformationEpoch
        {
            get => _endpointInformationEpoch;
            private set
            {
                _endpointInformationEpoch = value;
            }
        }

        /// <summary>
        /// <para>The endpoint epoch set in the response</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithEndpointInformationEpoch(Int32 endpointInformationEpoch)
        {
            EndpointInformationEpoch = endpointInformationEpoch;
            return this;
        }

        private NullableArray<EndpointToPartitions> _partitionsByUserEndpointCollection = new NullableArray<EndpointToPartitions>(null);
        /// <summary>
        /// <para>Global assignment information used for IQ. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<EndpointToPartitions>? PartitionsByUserEndpointCollection
        {
            get => _partitionsByUserEndpointCollection;
            private set
            {
                _partitionsByUserEndpointCollection = value;
            }
        }

        /// <summary>
        /// <para>Global assignment information used for IQ. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithPartitionsByUserEndpointCollection(params Func<EndpointToPartitions, EndpointToPartitions>[] createFields)
        {
            PartitionsByUserEndpointCollection = createFields.Select(createField => createField(new EndpointToPartitions(Version))).ToArray();
            return this;
        }

        public delegate EndpointToPartitions CreateEndpointToPartitions(EndpointToPartitions field);
        /// <summary>
        /// <para>Global assignment information used for IQ. Null if unchanged since last heartbeat.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public StreamsGroupHeartbeatResponse WithPartitionsByUserEndpointCollection(IEnumerable<CreateEndpointToPartitions> createFields)
        {
            PartitionsByUserEndpointCollection = createFields.Select(createField => createField(new EndpointToPartitions(Version))).ToArray();
            return this;
        }

        public class EndpointToPartitions : ISerialize
        {
            internal EndpointToPartitions(Int16 version)
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
            internal int GetSize(bool _) => _userEndpoint.GetSize(IsFlexibleVersion) + _activePartitionsCollection.GetSize(IsFlexibleVersion) + _standbyPartitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<EndpointToPartitions> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new EndpointToPartitions(version);
                instance.UserEndpoint = await Endpoint.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                instance.ActivePartitionsCollection = await Array<TopicPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.StandbyPartitionsCollection = await Array<TopicPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for EndpointToPartitions is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _userEndpoint.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _activePartitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _standbyPartitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Endpoint _userEndpoint = default!;
            /// <summary>
            /// <para>User-defined endpoint to connect to the node</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Endpoint UserEndpoint
            {
                get => _userEndpoint;
                private set
                {
                    _userEndpoint = value;
                }
            }

            /// <summary>
            /// <para>User-defined endpoint to connect to the node</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public EndpointToPartitions WithUserEndpoint(Endpoint userEndpoint)
            {
                UserEndpoint = userEndpoint;
                return this;
            }

            private Array<TopicPartition> _activePartitionsCollection = Array.Empty<TopicPartition>();
            /// <summary>
            /// <para>All topic partitions materialized by active tasks on the node</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TopicPartition> ActivePartitionsCollection
            {
                get => _activePartitionsCollection;
                private set
                {
                    _activePartitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>All topic partitions materialized by active tasks on the node</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public EndpointToPartitions WithActivePartitionsCollection(Array<TopicPartition> activePartitionsCollection)
            {
                ActivePartitionsCollection = activePartitionsCollection;
                return this;
            }

            private Array<TopicPartition> _standbyPartitionsCollection = Array.Empty<TopicPartition>();
            /// <summary>
            /// <para>All topic partitions materialized by standby tasks on the node</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<TopicPartition> StandbyPartitionsCollection
            {
                get => _standbyPartitionsCollection;
                private set
                {
                    _standbyPartitionsCollection = value;
                }
            }

            /// <summary>
            /// <para>All topic partitions materialized by standby tasks on the node</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public EndpointToPartitions WithStandbyPartitionsCollection(Array<TopicPartition> standbyPartitionsCollection)
            {
                StandbyPartitionsCollection = standbyPartitionsCollection;
                return this;
            }
        }

        public class Status : ISerialize
        {
            internal Status(Int16 version)
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
            internal int GetSize(bool _) => _statusCode.GetSize(IsFlexibleVersion) + _statusDetail.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Status> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Status(version);
                instance.StatusCode = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.StatusDetail = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Status is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _statusCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _statusDetail.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int8 _statusCode = Int8.Default;
            /// <summary>
            /// <para>A code to indicate that a particular status is active for the group membership</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int8 StatusCode
            {
                get => _statusCode;
                private set
                {
                    _statusCode = value;
                }
            }

            /// <summary>
            /// <para>A code to indicate that a particular status is active for the group membership</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Status WithStatusCode(Int8 statusCode)
            {
                StatusCode = statusCode;
                return this;
            }

            private String _statusDetail = String.Default;
            /// <summary>
            /// <para>A string representation of the status.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String StatusDetail
            {
                get => _statusDetail;
                private set
                {
                    _statusDetail = value;
                }
            }

            /// <summary>
            /// <para>A string representation of the status.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Status WithStatusDetail(String statusDetail)
            {
                StatusDetail = statusDetail;
                return this;
            }
        }

        public class TopicPartition : ISerialize
        {
            internal TopicPartition(Int16 version)
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
            internal int GetSize(bool _) => _topic.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TopicPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TopicPartition(version);
                instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicPartition is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _topic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _topic = String.Default;
            /// <summary>
            /// <para>topic name</para>
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
            /// <para>topic name</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartition WithTopic(String topic)
            {
                Topic = topic;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>partitions</para>
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
            /// <para>partitions</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TopicPartition WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        public class TaskIds : ISerialize
        {
            internal TaskIds(Int16 version)
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
            internal int GetSize(bool _) => _subtopologyId.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TaskIds> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TaskIds(version);
                instance.SubtopologyId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TaskIds is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _subtopologyId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _subtopologyId = String.Default;
            /// <summary>
            /// <para>The subtopology identifier.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String SubtopologyId
            {
                get => _subtopologyId;
                private set
                {
                    _subtopologyId = value;
                }
            }

            /// <summary>
            /// <para>The subtopology identifier.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TaskIds WithSubtopologyId(String subtopologyId)
            {
                SubtopologyId = subtopologyId;
                return this;
            }

            private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
            /// <summary>
            /// <para>The partitions of the input topics processed by this member.</para>
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
            /// <para>The partitions of the input topics processed by this member.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TaskIds WithPartitionsCollection(Array<Int32> partitionsCollection)
            {
                PartitionsCollection = partitionsCollection;
                return this;
            }
        }

        public class Endpoint : ISerialize
        {
            internal Endpoint(Int16 version)
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
            internal int GetSize(bool _) => _host.GetSize(IsFlexibleVersion) + _port.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Endpoint> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Endpoint(version);
                instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Port = await UInt16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Endpoint is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>host of the endpoint</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Host
            {
                get => _host;
                private set
                {
                    _host = value;
                }
            }

            /// <summary>
            /// <para>host of the endpoint</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Endpoint WithHost(String host)
            {
                Host = host;
                return this;
            }

            private UInt16 _port = UInt16.Default;
            /// <summary>
            /// <para>port of the endpoint</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public UInt16 Port
            {
                get => _port;
                private set
                {
                    _port = value;
                }
            }

            /// <summary>
            /// <para>port of the endpoint</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Endpoint WithPort(UInt16 port)
            {
                Port = port;
                return this;
            }
        }
    }
}
