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
    public class RemoveRaftVoterRequest : Message, IRespond<RemoveRaftVoterResponse>
    {
        public RemoveRaftVoterRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"RemoveRaftVoterRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(81);
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

        internal override int GetSize() => _clusterId.GetSize(IsFlexibleVersion) + _voterId.GetSize(IsFlexibleVersion) + _voterDirectoryId.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<RemoveRaftVoterRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new RemoveRaftVoterRequest(version);
            instance.ClusterId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.VoterId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.VoterDirectoryId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for RemoveRaftVoterRequest is unknown");
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
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private NullableString _clusterId = NullableString.Default;
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String? ClusterId
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
        public RemoveRaftVoterRequest WithClusterId(String? clusterId)
        {
            ClusterId = clusterId;
            return this;
        }

        private Int32 _voterId = Int32.Default;
        /// <summary>
        /// <para>The replica id of the voter getting removed from the topic partition</para>
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
        /// <para>The replica id of the voter getting removed from the topic partition</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public RemoveRaftVoterRequest WithVoterId(Int32 voterId)
        {
            VoterId = voterId;
            return this;
        }

        private Uuid _voterDirectoryId = Uuid.Default;
        /// <summary>
        /// <para>The directory id of the voter getting removed from the topic partition</para>
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
        /// <para>The directory id of the voter getting removed from the topic partition</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public RemoveRaftVoterRequest WithVoterDirectoryId(Uuid voterDirectoryId)
        {
            VoterDirectoryId = voterDirectoryId;
            return this;
        }

        public RemoveRaftVoterResponse Respond() => new RemoveRaftVoterResponse(Version);
    }
}
