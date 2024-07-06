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
    public class DescribeClusterResponse : Message
    {
        public DescribeClusterResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeClusterResponse does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(60);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(1);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + (Version >= 1 ? _endpointType.GetSize(IsFlexibleVersion) : 0) + _clusterId.GetSize(IsFlexibleVersion) + _controllerId.GetSize(IsFlexibleVersion) + _brokersCollection.GetSize(IsFlexibleVersion) + _clusterAuthorizedOperations.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeClusterResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeClusterResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.EndpointType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ClusterId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ControllerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.BrokersCollection = await Map<Int32, DescribeClusterBroker>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeClusterBroker.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.BrokerId, cancellationToken).ConfigureAwait(false);
            instance.ClusterAuthorizedOperations = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeClusterResponse is unknown");
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
            if (Version >= 1)
                await _endpointType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _clusterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _controllerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _brokersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _clusterAuthorizedOperations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public DescribeClusterResponse WithThrottleTimeMs(Int32 throttleTimeMs)
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
        public DescribeClusterResponse WithErrorCode(Int16 errorCode)
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
        public DescribeClusterResponse WithErrorMessage(String? errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        private Int8 _endpointType = new Int8(1);
        /// <summary>
        /// <para>The endpoint type that was described. 1=brokers, 2=controllers.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: 1</para>
        /// </summary>
        public Int8 EndpointType
        {
            get => _endpointType;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"EndpointType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _endpointType = value;
            }
        }

        /// <summary>
        /// <para>The endpoint type that was described. 1=brokers, 2=controllers.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: 1</para>
        /// </summary>
        public DescribeClusterResponse WithEndpointType(Int8 endpointType)
        {
            EndpointType = endpointType;
            return this;
        }

        private String _clusterId = String.Default;
        /// <summary>
        /// <para>The cluster ID that responding broker belongs to.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String ClusterId
        {
            get => _clusterId;
            private set
            {
                _clusterId = value;
            }
        }

        /// <summary>
        /// <para>The cluster ID that responding broker belongs to.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClusterResponse WithClusterId(String clusterId)
        {
            ClusterId = clusterId;
            return this;
        }

        private Int32 _controllerId = new Int32(-1);
        /// <summary>
        /// <para>The ID of the controller broker.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int32 ControllerId
        {
            get => _controllerId;
            private set
            {
                _controllerId = value;
            }
        }

        /// <summary>
        /// <para>The ID of the controller broker.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public DescribeClusterResponse WithControllerId(Int32 controllerId)
        {
            ControllerId = controllerId;
            return this;
        }

        private Map<Int32, DescribeClusterBroker> _brokersCollection = Map<Int32, DescribeClusterBroker>.Default;
        /// <summary>
        /// <para>Each broker in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<Int32, DescribeClusterBroker> BrokersCollection
        {
            get => _brokersCollection;
            private set
            {
                _brokersCollection = value;
            }
        }

        /// <summary>
        /// <para>Each broker in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClusterResponse WithBrokersCollection(params Func<DescribeClusterBroker, DescribeClusterBroker>[] createFields)
        {
            BrokersCollection = createFields.Select(createField => createField(new DescribeClusterBroker(Version))).ToDictionary(field => field.BrokerId);
            return this;
        }

        public delegate DescribeClusterBroker CreateDescribeClusterBroker(DescribeClusterBroker field);
        /// <summary>
        /// <para>Each broker in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClusterResponse WithBrokersCollection(IEnumerable<CreateDescribeClusterBroker> createFields)
        {
            BrokersCollection = createFields.Select(createField => createField(new DescribeClusterBroker(Version))).ToDictionary(field => field.BrokerId);
            return this;
        }

        public class DescribeClusterBroker : ISerialize
        {
            internal DescribeClusterBroker(Int16 version)
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
            internal int GetSize(bool _) => _brokerId.GetSize(IsFlexibleVersion) + _host.GetSize(IsFlexibleVersion) + _port.GetSize(IsFlexibleVersion) + _rack.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribeClusterBroker> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribeClusterBroker(version);
                instance.BrokerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Port = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Rack = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeClusterBroker is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _brokerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _rack.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _brokerId = Int32.Default;
            /// <summary>
            /// <para>The broker ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 BrokerId
            {
                get => _brokerId;
                private set
                {
                    _brokerId = value;
                }
            }

            /// <summary>
            /// <para>The broker ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeClusterBroker WithBrokerId(Int32 brokerId)
            {
                BrokerId = brokerId;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The broker hostname.</para>
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
            /// <para>The broker hostname.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeClusterBroker WithHost(String host)
            {
                Host = host;
                return this;
            }

            private Int32 _port = Int32.Default;
            /// <summary>
            /// <para>The broker port.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 Port
            {
                get => _port;
                private set
                {
                    _port = value;
                }
            }

            /// <summary>
            /// <para>The broker port.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeClusterBroker WithPort(Int32 port)
            {
                Port = port;
                return this;
            }

            private NullableString _rack = new NullableString(null);
            /// <summary>
            /// <para>The rack of the broker, or null if it has not been assigned to a rack.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public String? Rack
            {
                get => _rack;
                private set
                {
                    _rack = value;
                }
            }

            /// <summary>
            /// <para>The rack of the broker, or null if it has not been assigned to a rack.</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: null</para>
            /// </summary>
            public DescribeClusterBroker WithRack(String? rack)
            {
                Rack = rack;
                return this;
            }
        }

        private Int32 _clusterAuthorizedOperations = new Int32(-2147483648);
        /// <summary>
        /// <para>32-bit bitfield to represent authorized operations for this cluster.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -2147483648</para>
        /// </summary>
        public Int32 ClusterAuthorizedOperations
        {
            get => _clusterAuthorizedOperations;
            private set
            {
                _clusterAuthorizedOperations = value;
            }
        }

        /// <summary>
        /// <para>32-bit bitfield to represent authorized operations for this cluster.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -2147483648</para>
        /// </summary>
        public DescribeClusterResponse WithClusterAuthorizedOperations(Int32 clusterAuthorizedOperations)
        {
            ClusterAuthorizedOperations = clusterAuthorizedOperations;
            return this;
        }
    }
}
