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
    public class ListGroupsResponse : Message
    {
        public ListGroupsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ListGroupsResponse does not support version {version}. Valid versions are: 0-6");
            Version = version;
            IsFlexibleVersion = version >= 3;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(16);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(6);
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
            return new Tags.TagSection();
        }

        internal override int GetSize() => (Version >= 1 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + _errorCode.GetSize(IsFlexibleVersion) + _groupsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ListGroupsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ListGroupsResponse(version);
            if (instance.Version >= 1)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.GroupsCollection = await Array<ListedGroup>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ListedGroup.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ListGroupsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 1)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _groupsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 1+</para>
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
        /// <para>Versions: 1+</para>
        /// </summary>
        public ListGroupsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The error code, or 0 if there was no error.</para>
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
        /// <para>The error code, or 0 if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListGroupsResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<ListedGroup> _groupsCollection = Array.Empty<ListedGroup>();
        /// <summary>
        /// <para>Each group in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ListedGroup> GroupsCollection
        {
            get => _groupsCollection;
            private set
            {
                _groupsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each group in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListGroupsResponse WithGroupsCollection(params Func<ListedGroup, ListedGroup>[] createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new ListedGroup(Version))).ToArray();
            return this;
        }

        public delegate ListedGroup CreateListedGroup(ListedGroup field);
        /// <summary>
        /// <para>Each group in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListGroupsResponse WithGroupsCollection(IEnumerable<CreateListedGroup> createFields)
        {
            GroupsCollection = createFields.Select(createField => createField(new ListedGroup(Version))).ToArray();
            return this;
        }

        public class ListedGroup : ISerialize
        {
            internal ListedGroup(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _groupId.GetSize(IsFlexibleVersion) + _protocolType.GetSize(IsFlexibleVersion) + (Version >= 4 ? _groupState.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _groupType.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ListedGroup> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ListedGroup(version);
                instance.GroupId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ProtocolType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.GroupState = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 5)
                    instance.GroupType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ListedGroup is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _groupId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _protocolType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _groupState.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 5)
                    await _groupType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _groupId = String.Default;
            /// <summary>
            /// <para>The group ID.</para>
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
            /// <para>The group ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ListedGroup WithGroupId(String groupId)
            {
                GroupId = groupId;
                return this;
            }

            private String _protocolType = String.Default;
            /// <summary>
            /// <para>The group protocol type.</para>
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
            /// <para>The group protocol type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ListedGroup WithProtocolType(String protocolType)
            {
                ProtocolType = protocolType;
                return this;
            }

            private String _groupState = String.Default;
            /// <summary>
            /// <para>The group state name.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public String GroupState
            {
                get => _groupState;
                private set
                {
                    _groupState = value;
                }
            }

            /// <summary>
            /// <para>The group state name.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public ListedGroup WithGroupState(String groupState)
            {
                GroupState = groupState;
                return this;
            }

            private String _groupType = String.Default;
            /// <summary>
            /// <para>The group type name.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public String GroupType
            {
                get => _groupType;
                private set
                {
                    _groupType = value;
                }
            }

            /// <summary>
            /// <para>The group type name.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public ListedGroup WithGroupType(String groupType)
            {
                GroupType = groupType;
                return this;
            }
        }
    }
}
