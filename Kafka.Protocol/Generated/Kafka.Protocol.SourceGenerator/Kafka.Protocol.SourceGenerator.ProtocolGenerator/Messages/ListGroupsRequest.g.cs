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
    public class ListGroupsRequest : Message, IRespond<ListGroupsResponse>
    {
        public ListGroupsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ListGroupsRequest does not support version {version}. Valid versions are: 0-5");
            Version = version;
            IsFlexibleVersion = version >= 3;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(16);
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

        internal override int GetSize() => (Version >= 4 ? _statesFilterCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _typesFilterCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ListGroupsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ListGroupsRequest(version);
            if (instance.Version >= 4)
                instance.StatesFilterCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 5)
                instance.TypesFilterCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ListGroupsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 4)
                await _statesFilterCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 5)
                await _typesFilterCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<String> _statesFilterCollection = Array.Empty<String>();
        /// <summary>
        /// <para>The states of the groups we want to list. If empty, all groups are returned with their state.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public Array<String> StatesFilterCollection
        {
            get => _statesFilterCollection;
            private set
            {
                if (Version >= 4 == false)
                    throw new UnsupportedVersionException($"StatesFilterCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                _statesFilterCollection = value;
            }
        }

        /// <summary>
        /// <para>The states of the groups we want to list. If empty, all groups are returned with their state.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public ListGroupsRequest WithStatesFilterCollection(Array<String> statesFilterCollection)
        {
            StatesFilterCollection = statesFilterCollection;
            return this;
        }

        private Array<String> _typesFilterCollection = Array.Empty<String>();
        /// <summary>
        /// <para>The types of the groups we want to list. If empty, all groups are returned with their type.</para>
        /// <para>Versions: 5+</para>
        /// </summary>
        public Array<String> TypesFilterCollection
        {
            get => _typesFilterCollection;
            private set
            {
                if (Version >= 5 == false)
                    throw new UnsupportedVersionException($"TypesFilterCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                _typesFilterCollection = value;
            }
        }

        /// <summary>
        /// <para>The types of the groups we want to list. If empty, all groups are returned with their type.</para>
        /// <para>Versions: 5+</para>
        /// </summary>
        public ListGroupsRequest WithTypesFilterCollection(Array<String> typesFilterCollection)
        {
            TypesFilterCollection = typesFilterCollection;
            return this;
        }

        public ListGroupsResponse Respond() => new ListGroupsResponse(Version);
    }
}
