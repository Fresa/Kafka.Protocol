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
    public class BrokerRegistrationRequest : Message, IRespond<BrokerRegistrationResponse>
    {
        public BrokerRegistrationRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"BrokerRegistrationRequest does not support version {version}. Valid versions are: 0-4");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(62);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(4);
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

        internal override int GetSize() => _brokerId.GetSize(IsFlexibleVersion) + _clusterId.GetSize(IsFlexibleVersion) + _incarnationId.GetSize(IsFlexibleVersion) + _listenersCollection.GetSize(IsFlexibleVersion) + _featuresCollection.GetSize(IsFlexibleVersion) + _rack.GetSize(IsFlexibleVersion) + (Version >= 1 ? _isMigratingZkBroker.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 ? _logDirsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _previousBrokerEpoch.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<BrokerRegistrationRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new BrokerRegistrationRequest(version);
            instance.BrokerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ClusterId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.IncarnationId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ListenersCollection = await Map<String, Listener>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Listener.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            instance.FeaturesCollection = await Map<String, Feature>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Feature.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            instance.Rack = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.IsMigratingZkBroker = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2)
                instance.LogDirsCollection = await Array<Uuid>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.PreviousBrokerEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for BrokerRegistrationRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _brokerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _clusterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _incarnationId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _listenersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _featuresCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _rack.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _isMigratingZkBroker.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 2)
                await _logDirsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _previousBrokerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public BrokerRegistrationRequest WithBrokerId(Int32 brokerId)
        {
            BrokerId = brokerId;
            return this;
        }

        private String _clusterId = String.Default;
        /// <summary>
        /// <para>The cluster id of the broker process.</para>
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
        /// <para>The cluster id of the broker process.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerRegistrationRequest WithClusterId(String clusterId)
        {
            ClusterId = clusterId;
            return this;
        }

        private Uuid _incarnationId = Uuid.Default;
        /// <summary>
        /// <para>The incarnation id of the broker process.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Uuid IncarnationId
        {
            get => _incarnationId;
            private set
            {
                _incarnationId = value;
            }
        }

        /// <summary>
        /// <para>The incarnation id of the broker process.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerRegistrationRequest WithIncarnationId(Uuid incarnationId)
        {
            IncarnationId = incarnationId;
            return this;
        }

        private Map<String, Listener> _listenersCollection = Map<String, Listener>.Default;
        /// <summary>
        /// <para>The listeners of this broker.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, Listener> ListenersCollection
        {
            get => _listenersCollection;
            private set
            {
                _listenersCollection = value;
            }
        }

        /// <summary>
        /// <para>The listeners of this broker.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerRegistrationRequest WithListenersCollection(params Func<Listener, Listener>[] createFields)
        {
            ListenersCollection = createFields.Select(createField => createField(new Listener(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate Listener CreateListener(Listener field);
        /// <summary>
        /// <para>The listeners of this broker.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerRegistrationRequest WithListenersCollection(IEnumerable<CreateListener> createFields)
        {
            ListenersCollection = createFields.Select(createField => createField(new Listener(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class Listener : ISerialize
        {
            internal Listener(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _host.GetSize(IsFlexibleVersion) + _port.GetSize(IsFlexibleVersion) + _securityProtocol.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Listener> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Listener(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Port = await UInt16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.SecurityProtocol = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Listener is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _securityProtocol.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The name of the endpoint.</para>
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
            /// <para>The name of the endpoint.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Listener WithName(String name)
            {
                Name = name;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The hostname.</para>
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
            /// <para>The hostname.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Listener WithHost(String host)
            {
                Host = host;
                return this;
            }

            private UInt16 _port = UInt16.Default;
            /// <summary>
            /// <para>The port.</para>
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
            /// <para>The port.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Listener WithPort(UInt16 port)
            {
                Port = port;
                return this;
            }

            private Int16 _securityProtocol = Int16.Default;
            /// <summary>
            /// <para>The security protocol.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 SecurityProtocol
            {
                get => _securityProtocol;
                private set
                {
                    _securityProtocol = value;
                }
            }

            /// <summary>
            /// <para>The security protocol.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Listener WithSecurityProtocol(Int16 securityProtocol)
            {
                SecurityProtocol = securityProtocol;
                return this;
            }
        }

        private Map<String, Feature> _featuresCollection = Map<String, Feature>.Default;
        /// <summary>
        /// <para>The features on this broker. Note: in v0-v3, features with MinSupportedVersion = 0 are omitted.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, Feature> FeaturesCollection
        {
            get => _featuresCollection;
            private set
            {
                _featuresCollection = value;
            }
        }

        /// <summary>
        /// <para>The features on this broker. Note: in v0-v3, features with MinSupportedVersion = 0 are omitted.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerRegistrationRequest WithFeaturesCollection(params Func<Feature, Feature>[] createFields)
        {
            FeaturesCollection = createFields.Select(createField => createField(new Feature(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate Feature CreateFeature(Feature field);
        /// <summary>
        /// <para>The features on this broker. Note: in v0-v3, features with MinSupportedVersion = 0 are omitted.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerRegistrationRequest WithFeaturesCollection(IEnumerable<CreateFeature> createFields)
        {
            FeaturesCollection = createFields.Select(createField => createField(new Feature(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class Feature : ISerialize
        {
            internal Feature(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _minSupportedVersion.GetSize(IsFlexibleVersion) + _maxSupportedVersion.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Feature> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Feature(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.MinSupportedVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.MaxSupportedVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Feature is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _minSupportedVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _maxSupportedVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The feature name.</para>
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
            /// <para>The feature name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Feature WithName(String name)
            {
                Name = name;
                return this;
            }

            private Int16 _minSupportedVersion = Int16.Default;
            /// <summary>
            /// <para>The minimum supported feature level.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 MinSupportedVersion
            {
                get => _minSupportedVersion;
                private set
                {
                    _minSupportedVersion = value;
                }
            }

            /// <summary>
            /// <para>The minimum supported feature level.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Feature WithMinSupportedVersion(Int16 minSupportedVersion)
            {
                MinSupportedVersion = minSupportedVersion;
                return this;
            }

            private Int16 _maxSupportedVersion = Int16.Default;
            /// <summary>
            /// <para>The maximum supported feature level.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 MaxSupportedVersion
            {
                get => _maxSupportedVersion;
                private set
                {
                    _maxSupportedVersion = value;
                }
            }

            /// <summary>
            /// <para>The maximum supported feature level.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Feature WithMaxSupportedVersion(Int16 maxSupportedVersion)
            {
                MaxSupportedVersion = maxSupportedVersion;
                return this;
            }
        }

        private NullableString _rack = NullableString.Default;
        /// <summary>
        /// <para>The rack which this broker is in.</para>
        /// <para>Versions: 0+</para>
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
        /// <para>The rack which this broker is in.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerRegistrationRequest WithRack(String? rack)
        {
            Rack = rack;
            return this;
        }

        private Boolean _isMigratingZkBroker = new Boolean(false);
        /// <summary>
        /// <para>If the required configurations for ZK migration are present, this value is set to true.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean IsMigratingZkBroker
        {
            get => _isMigratingZkBroker;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"IsMigratingZkBroker does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _isMigratingZkBroker = value;
            }
        }

        /// <summary>
        /// <para>If the required configurations for ZK migration are present, this value is set to true.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: false</para>
        /// </summary>
        public BrokerRegistrationRequest WithIsMigratingZkBroker(Boolean isMigratingZkBroker)
        {
            IsMigratingZkBroker = isMigratingZkBroker;
            return this;
        }

        private Array<Uuid> _logDirsCollection = Array.Empty<Uuid>();
        /// <summary>
        /// <para>Log directories configured in this broker which are available.</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public Array<Uuid> LogDirsCollection
        {
            get => _logDirsCollection;
            private set
            {
                _logDirsCollection = value;
            }
        }

        /// <summary>
        /// <para>Log directories configured in this broker which are available.</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public BrokerRegistrationRequest WithLogDirsCollection(Array<Uuid> logDirsCollection)
        {
            LogDirsCollection = logDirsCollection;
            return this;
        }

        private Int64 _previousBrokerEpoch = new Int64(-1);
        /// <summary>
        /// <para>The epoch before a clean shutdown.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int64 PreviousBrokerEpoch
        {
            get => _previousBrokerEpoch;
            private set
            {
                _previousBrokerEpoch = value;
            }
        }

        /// <summary>
        /// <para>The epoch before a clean shutdown.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public BrokerRegistrationRequest WithPreviousBrokerEpoch(Int64 previousBrokerEpoch)
        {
            PreviousBrokerEpoch = previousBrokerEpoch;
            return this;
        }

        public BrokerRegistrationResponse Respond() => new BrokerRegistrationResponse(Version);
    }
}
