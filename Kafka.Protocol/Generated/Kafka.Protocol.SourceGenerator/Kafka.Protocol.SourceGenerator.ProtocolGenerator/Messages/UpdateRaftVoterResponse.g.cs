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
    public class UpdateRaftVoterResponse : Message
    {
        public UpdateRaftVoterResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"UpdateRaftVoterResponse does not support version {version}. Valid versions are: 0");
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
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            var tags = new List<Tags.TaggedField>();
            if (_currentLeaderIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 0, Field = _currentLeader });
            }

            return new Tags.TagSection(tags.ToArray());
        }

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<UpdateRaftVoterResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new UpdateRaftVoterResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        case 0:
                            instance.CurrentLeader_ = await CurrentLeader.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);
                        {
                            var size = instance._currentLeader.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field CurrentLeader_ read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for UpdateRaftVoterResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public UpdateRaftVoterResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The error code, or 0 if there was no error</para>
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
        /// <para>The error code, or 0 if there was no error</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateRaftVoterResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private bool _currentLeaderIsSet;
        private CurrentLeader _currentLeader = default !;
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CurrentLeader CurrentLeader_
        {
            get => _currentLeader;
            private set
            {
                _currentLeader = value;
                _currentLeaderIsSet = true;
            }
        }

        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateRaftVoterResponse WithCurrentLeader_(Func<CurrentLeader, CurrentLeader> createField)
        {
            CurrentLeader_ = createField(new CurrentLeader(Version));
            return this;
        }

        public class CurrentLeader : ISerialize
        {
            internal CurrentLeader(Int16 version)
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
            internal int GetSize(bool _) => _leaderId.GetSize(IsFlexibleVersion) + _leaderEpoch.GetSize(IsFlexibleVersion) + _host.GetSize(IsFlexibleVersion) + _port.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<CurrentLeader> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new CurrentLeader(version);
                instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.LeaderEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Port = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for CurrentLeader is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _leaderEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int32 _leaderId = new Int32(-1);
            /// <summary>
            /// <para>The replica id of the current leader or -1 if the leader is unknown</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: -1</para>
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
            /// <para>The replica id of the current leader or -1 if the leader is unknown</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public CurrentLeader WithLeaderId(Int32 leaderId)
            {
                LeaderId = leaderId;
                return this;
            }

            private Int32 _leaderEpoch = new Int32(-1);
            /// <summary>
            /// <para>The latest known leader epoch</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public Int32 LeaderEpoch
            {
                get => _leaderEpoch;
                private set
                {
                    _leaderEpoch = value;
                }
            }

            /// <summary>
            /// <para>The latest known leader epoch</para>
            /// <para>Versions: 0+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public CurrentLeader WithLeaderEpoch(Int32 leaderEpoch)
            {
                LeaderEpoch = leaderEpoch;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The node's hostname</para>
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
            /// <para>The node's hostname</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CurrentLeader WithHost(String host)
            {
                Host = host;
                return this;
            }

            private Int32 _port = Int32.Default;
            /// <summary>
            /// <para>The node's port</para>
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
            /// <para>The node's port</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CurrentLeader WithPort(Int32 port)
            {
                Port = port;
                return this;
            }
        }
    }
}
