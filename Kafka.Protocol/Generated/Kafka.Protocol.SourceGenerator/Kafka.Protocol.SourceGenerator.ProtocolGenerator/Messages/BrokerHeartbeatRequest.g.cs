#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

namespace Kafka.Protocol
{
    public class BrokerHeartbeatRequest : Message, IRespond<BrokerHeartbeatResponse>
    {
        public BrokerHeartbeatRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"BrokerHeartbeatRequest does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(63);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(1);
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
            var tags = new List<Tags.TaggedField>();
            if (Version >= 1 && _offlineLogDirsCollectionIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 0, Field = _offlineLogDirsCollection });
            }

            return new Tags.TagSection(tags.ToArray());
        }

        internal override int GetSize() => +(IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<BrokerHeartbeatRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new BrokerHeartbeatRequest(version);
            instance.BrokerId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.BrokerEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.CurrentMetadataOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.WantFence = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.WantShutDown = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        case 0:
                            if (instance.Version >= 1)
                                instance.OfflineLogDirsCollection = await Array<Uuid>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field OfflineLogDirsCollection is not supported for version {instance.Version}");
                        {
                            var size = instance._offlineLogDirsCollection.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field OfflineLogDirsCollection read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for BrokerHeartbeatRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _brokerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _brokerEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _currentMetadataOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _wantFence.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _wantShutDown.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public BrokerHeartbeatRequest WithBrokerId(Int32 brokerId)
        {
            BrokerId = brokerId;
            return this;
        }

        private Int64 _brokerEpoch = new Int64(-1);
        /// <summary>
        /// <para>The broker epoch.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int64 BrokerEpoch
        {
            get => _brokerEpoch;
            private set
            {
                _brokerEpoch = value;
            }
        }

        /// <summary>
        /// <para>The broker epoch.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public BrokerHeartbeatRequest WithBrokerEpoch(Int64 brokerEpoch)
        {
            BrokerEpoch = brokerEpoch;
            return this;
        }

        private Int64 _currentMetadataOffset = Int64.Default;
        /// <summary>
        /// <para>The highest metadata offset which the broker has reached.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 CurrentMetadataOffset
        {
            get => _currentMetadataOffset;
            private set
            {
                _currentMetadataOffset = value;
            }
        }

        /// <summary>
        /// <para>The highest metadata offset which the broker has reached.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerHeartbeatRequest WithCurrentMetadataOffset(Int64 currentMetadataOffset)
        {
            CurrentMetadataOffset = currentMetadataOffset;
            return this;
        }

        private Boolean _wantFence = Boolean.Default;
        /// <summary>
        /// <para>True if the broker wants to be fenced, false otherwise.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean WantFence
        {
            get => _wantFence;
            private set
            {
                _wantFence = value;
            }
        }

        /// <summary>
        /// <para>True if the broker wants to be fenced, false otherwise.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerHeartbeatRequest WithWantFence(Boolean wantFence)
        {
            WantFence = wantFence;
            return this;
        }

        private Boolean _wantShutDown = Boolean.Default;
        /// <summary>
        /// <para>True if the broker wants to be shut down, false otherwise.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean WantShutDown
        {
            get => _wantShutDown;
            private set
            {
                _wantShutDown = value;
            }
        }

        /// <summary>
        /// <para>True if the broker wants to be shut down, false otherwise.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public BrokerHeartbeatRequest WithWantShutDown(Boolean wantShutDown)
        {
            WantShutDown = wantShutDown;
            return this;
        }

        private bool _offlineLogDirsCollectionIsSet;
        private Array<Uuid> _offlineLogDirsCollection = Array.Empty<Uuid>();
        /// <summary>
        /// <para>Log directories that failed and went offline.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public Array<Uuid> OfflineLogDirsCollection
        {
            get => _offlineLogDirsCollection;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"OfflineLogDirsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _offlineLogDirsCollection = value;
                _offlineLogDirsCollectionIsSet = true;
            }
        }

        /// <summary>
        /// <para>Log directories that failed and went offline.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public BrokerHeartbeatRequest WithOfflineLogDirsCollection(Array<Uuid> offlineLogDirsCollection)
        {
            OfflineLogDirsCollection = offlineLogDirsCollection;
            return this;
        }

        public BrokerHeartbeatResponse Respond() => new BrokerHeartbeatResponse(Version);
    }
}
