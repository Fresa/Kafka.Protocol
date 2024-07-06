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
    public class UpdateRaftVoterRequest : Message, IRespond<UpdateRaftVoterResponse>
    {
        public UpdateRaftVoterRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"UpdateRaftVoterRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(82);
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

        internal override int GetSize() => _clusterId.GetSize(IsFlexibleVersion) + _voterId.GetSize(IsFlexibleVersion) + _voterDirectoryId.GetSize(IsFlexibleVersion) + _listenersCollection.GetSize(IsFlexibleVersion) + _kRaftVersionFeature.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<UpdateRaftVoterRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new UpdateRaftVoterRequest(version);
            instance.ClusterId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.VoterId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.VoterDirectoryId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ListenersCollection = await Map<String, Listener>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Listener.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            instance.KRaftVersionFeature_ = await KRaftVersionFeature.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for UpdateRaftVoterRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _clusterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _voterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _voterDirectoryId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _listenersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _kRaftVersionFeature.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _clusterId = String.Default;
        /// <summary>
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
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateRaftVoterRequest WithClusterId(String clusterId)
        {
            ClusterId = clusterId;
            return this;
        }

        private Int32 _voterId = Int32.Default;
        /// <summary>
        /// <para>The replica id of the voter getting updated in the topic partition</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 VoterId
        {
            get => _voterId;
            private set
            {
                _voterId = value;
            }
        }

        /// <summary>
        /// <para>The replica id of the voter getting updated in the topic partition</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateRaftVoterRequest WithVoterId(Int32 voterId)
        {
            VoterId = voterId;
            return this;
        }

        private Uuid _voterDirectoryId = Uuid.Default;
        /// <summary>
        /// <para>The directory id of the voter getting updated in the topic partition</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Uuid VoterDirectoryId
        {
            get => _voterDirectoryId;
            private set
            {
                _voterDirectoryId = value;
            }
        }

        /// <summary>
        /// <para>The directory id of the voter getting updated in the topic partition</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateRaftVoterRequest WithVoterDirectoryId(Uuid voterDirectoryId)
        {
            VoterDirectoryId = voterDirectoryId;
            return this;
        }

        private Map<String, Listener> _listenersCollection = Map<String, Listener>.Default;
        /// <summary>
        /// <para>The endpoint that can be used to communicate with the leader</para>
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
        /// <para>The endpoint that can be used to communicate with the leader</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateRaftVoterRequest WithListenersCollection(params Func<Listener, Listener>[] createFields)
        {
            ListenersCollection = createFields.Select(createField => createField(new Listener(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate Listener CreateListener(Listener field);
        /// <summary>
        /// <para>The endpoint that can be used to communicate with the leader</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateRaftVoterRequest WithListenersCollection(IEnumerable<CreateListener> createFields)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _host.GetSize(IsFlexibleVersion) + _port.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Listener> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Listener(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The name of the endpoint</para>
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
            /// <para>The name of the endpoint</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Listener WithName(String name)
            {
                Name = name;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The hostname</para>
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
            /// <para>The hostname</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Listener WithHost(String host)
            {
                Host = host;
                return this;
            }

            private UInt16 _port = UInt16.Default;
            /// <summary>
            /// <para>The port</para>
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
            /// <para>The port</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Listener WithPort(UInt16 port)
            {
                Port = port;
                return this;
            }
        }

        private KRaftVersionFeature _kRaftVersionFeature = default !;
        /// <summary>
        /// <para>The range of versions of the protocol that the replica supports</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public KRaftVersionFeature KRaftVersionFeature_
        {
            get => _kRaftVersionFeature;
            private set
            {
                _kRaftVersionFeature = value;
            }
        }

        /// <summary>
        /// <para>The range of versions of the protocol that the replica supports</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateRaftVoterRequest WithKRaftVersionFeature_(Func<KRaftVersionFeature, KRaftVersionFeature> createField)
        {
            KRaftVersionFeature_ = createField(new KRaftVersionFeature(Version));
            return this;
        }

        public class KRaftVersionFeature : ISerialize
        {
            internal KRaftVersionFeature(Int16 version)
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
            internal int GetSize(bool _) => _minSupportedVersion.GetSize(IsFlexibleVersion) + _maxSupportedVersion.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<KRaftVersionFeature> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new KRaftVersionFeature(version);
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
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for KRaftVersionFeature is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _minSupportedVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _maxSupportedVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int16 _minSupportedVersion = Int16.Default;
            /// <summary>
            /// <para>The minimum supported KRaft protocol version</para>
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
            /// <para>The minimum supported KRaft protocol version</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public KRaftVersionFeature WithMinSupportedVersion(Int16 minSupportedVersion)
            {
                MinSupportedVersion = minSupportedVersion;
                return this;
            }

            private Int16 _maxSupportedVersion = Int16.Default;
            /// <summary>
            /// <para>The maximum supported KRaft protocol version</para>
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
            /// <para>The maximum supported KRaft protocol version</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public KRaftVersionFeature WithMaxSupportedVersion(Int16 maxSupportedVersion)
            {
                MaxSupportedVersion = maxSupportedVersion;
                return this;
            }
        }

        public UpdateRaftVoterResponse Respond() => new UpdateRaftVoterResponse(Version);
    }
}
