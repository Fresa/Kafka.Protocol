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
    public class JoinGroupRequest : Message, IRespond<JoinGroupResponse>
    {
        public JoinGroupRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"JoinGroupRequest does not support version {version}. Valid versions are: 0-9");
            Version = version;
            IsFlexibleVersion = version >= 6;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(11);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(9);
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

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + _sessionTimeoutMs.GetSize(IsFlexibleVersion) + (Version >= 1 ? _rebalanceTimeoutMs.GetSize(IsFlexibleVersion) : 0) + _memberId.GetSize(IsFlexibleVersion) + (Version >= 5 ? _groupInstanceId.GetSize(IsFlexibleVersion) : 0) + _protocolType.GetSize(IsFlexibleVersion) + _protocolsCollection.GetSize(IsFlexibleVersion) + (Version >= 8 ? _reason.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<JoinGroupRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new JoinGroupRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.SessionTimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.RebalanceTimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 5)
                instance.GroupInstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ProtocolType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ProtocolsCollection = await Map<String, JoinGroupRequestProtocol>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => JoinGroupRequestProtocol.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 8)
                instance.Reason = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for JoinGroupRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _sessionTimeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _rebalanceTimeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 5)
                await _groupInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _protocolType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _protocolsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 8)
                await _reason.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public JoinGroupRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private Int32 _sessionTimeoutMs = Int32.Default;
        /// <summary>
        /// <para>The coordinator considers the consumer dead if it receives no heartbeat after this timeout in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 SessionTimeoutMs
        {
            get => _sessionTimeoutMs;
            private set
            {
                _sessionTimeoutMs = value;
            }
        }

        /// <summary>
        /// <para>The coordinator considers the consumer dead if it receives no heartbeat after this timeout in milliseconds.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public JoinGroupRequest WithSessionTimeoutMs(Int32 sessionTimeoutMs)
        {
            SessionTimeoutMs = sessionTimeoutMs;
            return this;
        }

        private Int32 _rebalanceTimeoutMs = new Int32(-1);
        /// <summary>
        /// <para>The maximum time in milliseconds that the coordinator will wait for each member to rejoin when rebalancing the group.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int32 RebalanceTimeoutMs
        {
            get => _rebalanceTimeoutMs;
            private set
            {
                _rebalanceTimeoutMs = value;
            }
        }

        /// <summary>
        /// <para>The maximum time in milliseconds that the coordinator will wait for each member to rejoin when rebalancing the group.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public JoinGroupRequest WithRebalanceTimeoutMs(Int32 rebalanceTimeoutMs)
        {
            RebalanceTimeoutMs = rebalanceTimeoutMs;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The member id assigned by the group coordinator.</para>
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
        /// <para>The member id assigned by the group coordinator.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public JoinGroupRequest WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private NullableString _groupInstanceId = new NullableString(null);
        /// <summary>
        /// <para>The unique identifier of the consumer instance provided by end user.</para>
        /// <para>Versions: 5+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? GroupInstanceId
        {
            get => _groupInstanceId;
            private set
            {
                if (Version >= 5 == false)
                    throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                if (Version >= 5 == false && value == null)
                    throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 5+");
                _groupInstanceId = value;
            }
        }

        /// <summary>
        /// <para>The unique identifier of the consumer instance provided by end user.</para>
        /// <para>Versions: 5+</para>
        /// <para>Default: null</para>
        /// </summary>
        public JoinGroupRequest WithGroupInstanceId(String? groupInstanceId)
        {
            GroupInstanceId = groupInstanceId;
            return this;
        }

        private String _protocolType = String.Default;
        /// <summary>
        /// <para>The unique name the for class of protocols implemented by the group we want to join.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String ProtocolType
        {
            get => _protocolType;
            private set
            {
                _protocolType = value;
            }
        }

        /// <summary>
        /// <para>The unique name the for class of protocols implemented by the group we want to join.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public JoinGroupRequest WithProtocolType(String protocolType)
        {
            ProtocolType = protocolType;
            return this;
        }

        private Map<String, JoinGroupRequestProtocol> _protocolsCollection = Map<String, JoinGroupRequestProtocol>.Default;
        /// <summary>
        /// <para>The list of protocols that the member supports.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, JoinGroupRequestProtocol> ProtocolsCollection
        {
            get => _protocolsCollection;
            private set
            {
                _protocolsCollection = value;
            }
        }

        /// <summary>
        /// <para>The list of protocols that the member supports.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public JoinGroupRequest WithProtocolsCollection(params Func<JoinGroupRequestProtocol, JoinGroupRequestProtocol>[] createFields)
        {
            ProtocolsCollection = createFields.Select(createField => createField(new JoinGroupRequestProtocol(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate JoinGroupRequestProtocol CreateJoinGroupRequestProtocol(JoinGroupRequestProtocol field);
        /// <summary>
        /// <para>The list of protocols that the member supports.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public JoinGroupRequest WithProtocolsCollection(IEnumerable<CreateJoinGroupRequestProtocol> createFields)
        {
            ProtocolsCollection = createFields.Select(createField => createField(new JoinGroupRequestProtocol(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class JoinGroupRequestProtocol : ISerialize
        {
            internal JoinGroupRequestProtocol(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 6;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _metadata.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<JoinGroupRequestProtocol> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new JoinGroupRequestProtocol(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Metadata = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for JoinGroupRequestProtocol is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _metadata.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The protocol name.</para>
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
            /// <para>The protocol name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public JoinGroupRequestProtocol WithName(String name)
            {
                Name = name;
                return this;
            }

            private Bytes _metadata = Bytes.Default;
            /// <summary>
            /// <para>The protocol metadata.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Bytes Metadata
            {
                get => _metadata;
                private set
                {
                    _metadata = value;
                }
            }

            /// <summary>
            /// <para>The protocol metadata.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public JoinGroupRequestProtocol WithMetadata(Bytes metadata)
            {
                Metadata = metadata;
                return this;
            }
        }

        private NullableString _reason = new NullableString(null);
        /// <summary>
        /// <para>The reason why the member (re-)joins the group.</para>
        /// <para>Versions: 8+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? Reason
        {
            get => _reason;
            private set
            {
                if (Version >= 8 == false && value == null)
                    throw new UnsupportedVersionException($"Reason does not support null for version {Version}. Supported versions for null value: 8+");
                _reason = value;
            }
        }

        /// <summary>
        /// <para>The reason why the member (re-)joins the group.</para>
        /// <para>Versions: 8+</para>
        /// <para>Default: null</para>
        /// </summary>
        public JoinGroupRequest WithReason(String? reason)
        {
            Reason = reason;
            return this;
        }

        public JoinGroupResponse Respond() => new JoinGroupResponse(Version);
    }
}
