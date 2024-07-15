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
    public class VotersRecord
    {
        public VotersRecord(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"VotersRecord does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
        public Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal int GetSize() => _version.GetSize(IsFlexibleVersion) + _votersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        public static async ValueTask<VotersRecord> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
            var reader = pipe.Reader;
            var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
            var instance = new VotersRecord(version);
            instance.Version_ = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.VotersCollection = await Array<Voter>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Voter.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for VotersRecord is unknown");
                    }
                }
            }

            return instance;
        }

        public async ValueTask<Bytes> ToBytesAsync(CancellationToken cancellationToken = default)
        {
            var writer = new MemoryStream();
            await using (writer.ConfigureAwait(false))
            {
                await Version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _votersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }

                return new Bytes(writer.ToArray());
            }
        }

        private Int16 _version = Int16.Default;
        /// <summary>
        /// <para>The version of the voters record</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int16 Version_
        {
            get => _version;
            private set
            {
                _version = value;
            }
        }

        /// <summary>
        /// <para>The version of the voters record</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public VotersRecord WithVersion_(Int16 version)
        {
            Version_ = version;
            return this;
        }

        private Array<Voter> _votersCollection = Array.Empty<Voter>();
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<Voter> VotersCollection
        {
            get => _votersCollection;
            private set
            {
                _votersCollection = value;
            }
        }

        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public VotersRecord WithVotersCollection(params Func<Voter, Voter>[] createFields)
        {
            VotersCollection = createFields.Select(createField => createField(new Voter(Version))).ToArray();
            return this;
        }

        public delegate Voter CreateVoter(Voter field);
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public VotersRecord WithVotersCollection(IEnumerable<CreateVoter> createFields)
        {
            VotersCollection = createFields.Select(createField => createField(new Voter(Version))).ToArray();
            return this;
        }

        public class Voter : ISerialize
        {
            internal Voter(Int16 version)
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
            internal int GetSize(bool _) => _voterId.GetSize(IsFlexibleVersion) + _voterDirectoryId.GetSize(IsFlexibleVersion) + _endpointsCollection.GetSize(IsFlexibleVersion) + _kRaftVersionFeature.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Voter> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Voter(version);
                instance.VoterId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.VoterDirectoryId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.EndpointsCollection = await Map<String, Endpoint>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Endpoint.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
                instance.KRaftVersionFeature_ = await KRaftVersionFeature.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Voter is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _voterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _voterDirectoryId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _endpointsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _kRaftVersionFeature.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _voterId = Int32.Default;
            /// <summary>
            /// <para>The replica id of the voter in the topic partition</para>
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
            /// <para>The replica id of the voter in the topic partition</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Voter WithVoterId(Int32 voterId)
            {
                VoterId = voterId;
                return this;
            }

            private Uuid _voterDirectoryId = Uuid.Default;
            /// <summary>
            /// <para>The directory id of the voter in the topic partition</para>
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
            /// <para>The directory id of the voter in the topic partition</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Voter WithVoterDirectoryId(Uuid voterDirectoryId)
            {
                VoterDirectoryId = voterDirectoryId;
                return this;
            }

            private Map<String, Endpoint> _endpointsCollection = Map<String, Endpoint>.Default;
            /// <summary>
            /// <para>The endpoint that can be used to communicate with the voter</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Map<String, Endpoint> EndpointsCollection
            {
                get => _endpointsCollection;
                private set
                {
                    _endpointsCollection = value;
                }
            }

            /// <summary>
            /// <para>The endpoint that can be used to communicate with the voter</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Voter WithEndpointsCollection(params Func<Endpoint, Endpoint>[] createFields)
            {
                EndpointsCollection = createFields.Select(createField => createField(new Endpoint(Version))).ToDictionary(field => field.Name);
                return this;
            }

            public delegate Endpoint CreateEndpoint(Endpoint field);
            /// <summary>
            /// <para>The endpoint that can be used to communicate with the voter</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Voter WithEndpointsCollection(IEnumerable<CreateEndpoint> createFields)
            {
                EndpointsCollection = createFields.Select(createField => createField(new Endpoint(Version))).ToDictionary(field => field.Name);
                return this;
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
                internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _host.GetSize(IsFlexibleVersion) + _port.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<Endpoint> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new Endpoint(version);
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
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for Endpoint is unknown");
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
                public Endpoint WithName(String name)
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
                public Endpoint WithHost(String host)
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
                public Endpoint WithPort(UInt16 port)
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
            public Voter WithKRaftVersionFeature_(Func<KRaftVersionFeature, KRaftVersionFeature> createField)
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
        }
    }
}
