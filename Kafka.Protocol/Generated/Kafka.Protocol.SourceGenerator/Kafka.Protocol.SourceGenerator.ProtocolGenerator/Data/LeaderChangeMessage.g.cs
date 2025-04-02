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
    public class LeaderChangeMessage
    {
        public LeaderChangeMessage(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"LeaderChangeMessage does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = true;
        }

        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(1);
        public Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal int GetSize() => _version.GetSize(IsFlexibleVersion) + _leaderId.GetSize(IsFlexibleVersion) + _votersCollection.GetSize(IsFlexibleVersion) + _grantingVotersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        public static async ValueTask<LeaderChangeMessage> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
            var reader = pipe.Reader;
            var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
            var instance = new LeaderChangeMessage(version);
            instance.Version_ = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.VotersCollection = await Array<Voter>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Voter.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.GrantingVotersCollection = await Array<Voter>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Voter.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderChangeMessage is unknown");
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
                await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _votersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _grantingVotersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }

                return new Bytes(writer.ToArray());
            }
        }

        private Int16 _version = Int16.Default;
        /// <summary>
        /// <para>The version of the leader change message.</para>
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
        /// <para>The version of the leader change message.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public LeaderChangeMessage WithVersion_(Int16 version)
        {
            Version_ = version;
            return this;
        }

        private Int32 _leaderId = Int32.Default;
        /// <summary>
        /// <para>The ID of the newly elected leader.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 LeaderId
        {
            get => _leaderId;
            private set
            {
                _leaderId = value;
            }
        }

        /// <summary>
        /// <para>The ID of the newly elected leader.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public LeaderChangeMessage WithLeaderId(Int32 leaderId)
        {
            LeaderId = leaderId;
            return this;
        }

        private Array<Voter> _votersCollection = Array.Empty<Voter>();
        /// <summary>
        /// <para>The set of voters in the quorum for this epoch.</para>
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
        /// <para>The set of voters in the quorum for this epoch.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public LeaderChangeMessage WithVotersCollection(Array<Voter> votersCollection)
        {
            VotersCollection = votersCollection;
            return this;
        }

        private Array<Voter> _grantingVotersCollection = Array.Empty<Voter>();
        /// <summary>
        /// <para>The voters who voted for the leader at the time of election.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<Voter> GrantingVotersCollection
        {
            get => _grantingVotersCollection;
            private set
            {
                _grantingVotersCollection = value;
            }
        }

        /// <summary>
        /// <para>The voters who voted for the leader at the time of election.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public LeaderChangeMessage WithGrantingVotersCollection(Array<Voter> grantingVotersCollection)
        {
            GrantingVotersCollection = grantingVotersCollection;
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
            internal int GetSize(bool _) => _voterId.GetSize(IsFlexibleVersion) + (Version >= 1 ? _voterDirectoryId.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Voter> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Voter(version);
                instance.VoterId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.VoterDirectoryId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                if (Version >= 1)
                    await _voterDirectoryId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _voterId = Int32.Default;
            /// <summary>
            /// <para>The ID of the voter.</para>
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
            /// <para>The ID of the voter.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Voter WithVoterId(Int32 voterId)
            {
                VoterId = voterId;
                return this;
            }

            private Uuid _voterDirectoryId = Uuid.Default;
            /// <summary>
            /// <para>The directory id of the voter.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public Uuid VoterDirectoryId
            {
                get => _voterDirectoryId;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"VoterDirectoryId does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _voterDirectoryId = value;
                }
            }

            /// <summary>
            /// <para>The directory id of the voter.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public Voter WithVoterDirectoryId(Uuid voterDirectoryId)
            {
                VoterDirectoryId = voterDirectoryId;
                return this;
            }
        }
    }
}
