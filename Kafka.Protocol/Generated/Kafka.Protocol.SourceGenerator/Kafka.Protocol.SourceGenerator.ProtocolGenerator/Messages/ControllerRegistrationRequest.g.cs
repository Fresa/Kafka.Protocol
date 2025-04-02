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
    public class ControllerRegistrationRequest : Message, IRespond<ControllerRegistrationResponse>
    {
        public ControllerRegistrationRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ControllerRegistrationRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(70);
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

        internal override int GetSize() => _controllerId.GetSize(IsFlexibleVersion) + _incarnationId.GetSize(IsFlexibleVersion) + _zkMigrationReady.GetSize(IsFlexibleVersion) + _listenersCollection.GetSize(IsFlexibleVersion) + _featuresCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ControllerRegistrationRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ControllerRegistrationRequest(version);
            instance.ControllerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.IncarnationId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ZkMigrationReady = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ListenersCollection = await Map<String, Listener>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Listener.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            instance.FeaturesCollection = await Map<String, Feature>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Feature.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ControllerRegistrationRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _controllerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _incarnationId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _zkMigrationReady.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _listenersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _featuresCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _controllerId = Int32.Default;
        /// <summary>
        /// <para>The ID of the controller to register.</para>
        /// <para>Versions: 0+</para>
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
        /// <para>The ID of the controller to register.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ControllerRegistrationRequest WithControllerId(Int32 controllerId)
        {
            ControllerId = controllerId;
            return this;
        }

        private Uuid _incarnationId = Uuid.Default;
        /// <summary>
        /// <para>The controller incarnation ID, which is unique to each process run.</para>
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
        /// <para>The controller incarnation ID, which is unique to each process run.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ControllerRegistrationRequest WithIncarnationId(Uuid incarnationId)
        {
            IncarnationId = incarnationId;
            return this;
        }

        private Boolean _zkMigrationReady = Boolean.Default;
        /// <summary>
        /// <para>Set if the required configurations for ZK migration are present.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean ZkMigrationReady
        {
            get => _zkMigrationReady;
            private set
            {
                _zkMigrationReady = value;
            }
        }

        /// <summary>
        /// <para>Set if the required configurations for ZK migration are present.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ControllerRegistrationRequest WithZkMigrationReady(Boolean zkMigrationReady)
        {
            ZkMigrationReady = zkMigrationReady;
            return this;
        }

        private Map<String, Listener> _listenersCollection = Map<String, Listener>.Default;
        /// <summary>
        /// <para>The listeners of this controller.</para>
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
        /// <para>The listeners of this controller.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ControllerRegistrationRequest WithListenersCollection(params Func<Listener, Listener>[] createFields)
        {
            ListenersCollection = createFields.Select(createField => createField(new Listener(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate Listener CreateListener(Listener field);
        /// <summary>
        /// <para>The listeners of this controller.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ControllerRegistrationRequest WithListenersCollection(IEnumerable<CreateListener> createFields)
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
        /// <para>The features on this controller.</para>
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
        /// <para>The features on this controller.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ControllerRegistrationRequest WithFeaturesCollection(params Func<Feature, Feature>[] createFields)
        {
            FeaturesCollection = createFields.Select(createField => createField(new Feature(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate Feature CreateFeature(Feature field);
        /// <summary>
        /// <para>The features on this controller.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ControllerRegistrationRequest WithFeaturesCollection(IEnumerable<CreateFeature> createFields)
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

        public ControllerRegistrationResponse Respond() => new ControllerRegistrationResponse(Version);
    }
}
