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
    public class DescribeGroupsRequest : Message, IRespond<DescribeGroupsResponse>
    {
        public DescribeGroupsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeGroupsRequest does not support version {version}. Valid versions are: 0-5");
            Version = version;
            IsFlexibleVersion = version >= 5;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(15);
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

        internal override int GetSize() => _groupsCollection.GetSize(IsFlexibleVersion) + (Version >= 3 ? _includeAuthorizedOperations.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeGroupsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeGroupsRequest(version);
            instance.GroupsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.IncludeAuthorizedOperations = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeGroupsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _includeAuthorizedOperations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<String> _groupsCollection = Array.Empty<String>();
        /// <summary>
        /// <para>The names of the groups to describe</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<String> GroupsCollection
        {
            get => _groupsCollection;
            private set
            {
                _groupsCollection = value;
            }
        }

        /// <summary>
        /// <para>The names of the groups to describe</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeGroupsRequest WithGroupsCollection(Array<String> groupsCollection)
        {
            GroupsCollection = groupsCollection;
            return this;
        }

        private Boolean _includeAuthorizedOperations = Boolean.Default;
        /// <summary>
        /// <para>Whether to include authorized operations.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public Boolean IncludeAuthorizedOperations
        {
            get => _includeAuthorizedOperations;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"IncludeAuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                _includeAuthorizedOperations = value;
            }
        }

        /// <summary>
        /// <para>Whether to include authorized operations.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public DescribeGroupsRequest WithIncludeAuthorizedOperations(Boolean includeAuthorizedOperations)
        {
            IncludeAuthorizedOperations = includeAuthorizedOperations;
            return this;
        }

        public DescribeGroupsResponse Respond() => new DescribeGroupsResponse(Version);
    }
}
