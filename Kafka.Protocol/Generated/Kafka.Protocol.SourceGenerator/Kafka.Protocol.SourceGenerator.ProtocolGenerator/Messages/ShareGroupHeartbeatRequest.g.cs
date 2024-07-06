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
    public class ShareGroupHeartbeatRequest : Message, IRespond<ShareGroupHeartbeatResponse>
    {
        public ShareGroupHeartbeatRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ShareGroupHeartbeatRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(76);
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

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + _memberId.GetSize(IsFlexibleVersion) + _memberEpoch.GetSize(IsFlexibleVersion) + _rackId.GetSize(IsFlexibleVersion) + _subscribedTopicNamesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ShareGroupHeartbeatRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ShareGroupHeartbeatRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberEpoch = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.RackId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.SubscribedTopicNamesCollection = await NullableArray<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ShareGroupHeartbeatRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberEpoch.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _rackId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _subscribedTopicNamesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _groupId = String.Default;
        /// <summary>
        /// <para>The group identifier.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String GroupId
        {
            get => _groupId;
            private set
            {
                _groupId = value;
            }
        }

        /// <summary>
        /// <para>The group identifier.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareGroupHeartbeatRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The member ID generated by the coordinator. The member ID must be kept during the entire lifetime of the member.</para>
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
        /// <para>The member ID generated by the coordinator. The member ID must be kept during the entire lifetime of the member.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareGroupHeartbeatRequest WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private Int32 _memberEpoch = Int32.Default;
        /// <summary>
        /// <para>The current member epoch; 0 to join the group; -1 to leave the group.</para>
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
        /// <para>The current member epoch; 0 to join the group; -1 to leave the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareGroupHeartbeatRequest WithMemberEpoch(Int32 memberEpoch)
        {
            MemberEpoch = memberEpoch;
            return this;
        }

        private NullableString _rackId = new NullableString(null);
        /// <summary>
        /// <para>null if not provided or if it didn't change since the last heartbeat; the rack ID of consumer otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? RackId
        {
            get => _rackId;
            private set
            {
                _rackId = value;
            }
        }

        /// <summary>
        /// <para>null if not provided or if it didn't change since the last heartbeat; the rack ID of consumer otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ShareGroupHeartbeatRequest WithRackId(String? rackId)
        {
            RackId = rackId;
            return this;
        }

        private NullableArray<String> _subscribedTopicNamesCollection = new NullableArray<String>(null);
        /// <summary>
        /// <para>null if it didn't change since the last heartbeat; the subscribed topic names otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public Array<String>? SubscribedTopicNamesCollection
        {
            get => _subscribedTopicNamesCollection;
            private set
            {
                _subscribedTopicNamesCollection = value;
            }
        }

        /// <summary>
        /// <para>null if it didn't change since the last heartbeat; the subscribed topic names otherwise.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: null</para>
        /// </summary>
        public ShareGroupHeartbeatRequest WithSubscribedTopicNamesCollection(Array<String>? subscribedTopicNamesCollection)
        {
            SubscribedTopicNamesCollection = subscribedTopicNamesCollection;
            return this;
        }

        public ShareGroupHeartbeatResponse Respond() => new ShareGroupHeartbeatResponse(Version);
    }
}
