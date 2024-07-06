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
    public class SyncGroupRequest : Message, IRespond<SyncGroupResponse>
    {
        public SyncGroupRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"SyncGroupRequest does not support version {version}. Valid versions are: 0-5");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(14);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(5);
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

        internal override int GetSize() => _groupId.GetSize(IsFlexibleVersion) + _generationId.GetSize(IsFlexibleVersion) + _memberId.GetSize(IsFlexibleVersion) + (Version >= 3 ? _groupInstanceId.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _protocolType.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _protocolName.GetSize(IsFlexibleVersion) : 0) + _assignmentsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<SyncGroupRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new SyncGroupRequest(version);
            instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.GenerationId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.GroupInstanceId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 5)
                instance.ProtocolType = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 5)
                instance.ProtocolName = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.AssignmentsCollection = await Array<SyncGroupRequestAssignment>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => SyncGroupRequestAssignment.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for SyncGroupRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _generationId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _groupInstanceId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 5)
                await _protocolType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 5)
                await _protocolName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _assignmentsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _groupId = String.Default;
        /// <summary>
        /// <para>The unique group identifier.</para>
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
        /// <para>The unique group identifier.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public SyncGroupRequest WithGroupId(String groupId)
        {
            GroupId = groupId;
            return this;
        }

        private Int32 _generationId = Int32.Default;
        /// <summary>
        /// <para>The generation of the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 GenerationId
        {
            get => _generationId;
            private set
            {
                _generationId = value;
            }
        }

        /// <summary>
        /// <para>The generation of the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public SyncGroupRequest WithGenerationId(Int32 generationId)
        {
            GenerationId = generationId;
            return this;
        }

        private String _memberId = String.Default;
        /// <summary>
        /// <para>The member ID assigned by the group.</para>
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
        /// <para>The member ID assigned by the group.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public SyncGroupRequest WithMemberId(String memberId)
        {
            MemberId = memberId;
            return this;
        }

        private NullableString _groupInstanceId = new NullableString(null);
        /// <summary>
        /// <para>The unique identifier of the consumer instance provided by end user.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? GroupInstanceId
        {
            get => _groupInstanceId;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                if (Version >= 3 == false && value == null)
                    throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 3+");
                _groupInstanceId = value;
            }
        }

        /// <summary>
        /// <para>The unique identifier of the consumer instance provided by end user.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: null</para>
        /// </summary>
        public SyncGroupRequest WithGroupInstanceId(String? groupInstanceId)
        {
            GroupInstanceId = groupInstanceId;
            return this;
        }

        private NullableString _protocolType = new NullableString(null);
        /// <summary>
        /// <para>The group protocol type.</para>
        /// <para>Versions: 5+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ProtocolType
        {
            get => _protocolType;
            private set
            {
                if (Version >= 5 == false && value == null)
                    throw new UnsupportedVersionException($"ProtocolType does not support null for version {Version}. Supported versions for null value: 5+");
                _protocolType = value;
            }
        }

        /// <summary>
        /// <para>The group protocol type.</para>
        /// <para>Versions: 5+</para>
        /// <para>Default: null</para>
        /// </summary>
        public SyncGroupRequest WithProtocolType(String? protocolType)
        {
            ProtocolType = protocolType;
            return this;
        }

        private NullableString _protocolName = new NullableString(null);
        /// <summary>
        /// <para>The group protocol name.</para>
        /// <para>Versions: 5+</para>
        /// <para>Default: null</para>
        /// </summary>
        public String? ProtocolName
        {
            get => _protocolName;
            private set
            {
                if (Version >= 5 == false && value == null)
                    throw new UnsupportedVersionException($"ProtocolName does not support null for version {Version}. Supported versions for null value: 5+");
                _protocolName = value;
            }
        }

        /// <summary>
        /// <para>The group protocol name.</para>
        /// <para>Versions: 5+</para>
        /// <para>Default: null</para>
        /// </summary>
        public SyncGroupRequest WithProtocolName(String? protocolName)
        {
            ProtocolName = protocolName;
            return this;
        }

        private Array<SyncGroupRequestAssignment> _assignmentsCollection = Array.Empty<SyncGroupRequestAssignment>();
        /// <summary>
        /// <para>Each assignment.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<SyncGroupRequestAssignment> AssignmentsCollection
        {
            get => _assignmentsCollection;
            private set
            {
                _assignmentsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each assignment.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public SyncGroupRequest WithAssignmentsCollection(params Func<SyncGroupRequestAssignment, SyncGroupRequestAssignment>[] createFields)
        {
            AssignmentsCollection = createFields.Select(createField => createField(new SyncGroupRequestAssignment(Version))).ToArray();
            return this;
        }

        public delegate SyncGroupRequestAssignment CreateSyncGroupRequestAssignment(SyncGroupRequestAssignment field);
        /// <summary>
        /// <para>Each assignment.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public SyncGroupRequest WithAssignmentsCollection(IEnumerable<CreateSyncGroupRequestAssignment> createFields)
        {
            AssignmentsCollection = createFields.Select(createField => createField(new SyncGroupRequestAssignment(Version))).ToArray();
            return this;
        }

        public class SyncGroupRequestAssignment : ISerialize
        {
            internal SyncGroupRequestAssignment(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 4;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _memberId.GetSize(IsFlexibleVersion) + _assignment.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<SyncGroupRequestAssignment> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new SyncGroupRequestAssignment(version);
                instance.MemberId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Assignment = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for SyncGroupRequestAssignment is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _memberId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _assignment.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _memberId = String.Default;
            /// <summary>
            /// <para>The ID of the member to assign.</para>
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
            /// <para>The ID of the member to assign.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public SyncGroupRequestAssignment WithMemberId(String memberId)
            {
                MemberId = memberId;
                return this;
            }

            private Bytes _assignment = Bytes.Default;
            /// <summary>
            /// <para>The member assignment.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Bytes Assignment
            {
                get => _assignment;
                private set
                {
                    _assignment = value;
                }
            }

            /// <summary>
            /// <para>The member assignment.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public SyncGroupRequestAssignment WithAssignment(Bytes assignment)
            {
                Assignment = assignment;
                return this;
            }
        }

        public SyncGroupResponse Respond() => new SyncGroupResponse(Version);
    }
}
