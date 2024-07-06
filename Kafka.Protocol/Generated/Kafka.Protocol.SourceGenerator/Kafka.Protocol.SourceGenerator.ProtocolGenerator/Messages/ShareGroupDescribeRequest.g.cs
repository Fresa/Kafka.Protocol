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
    public class ShareGroupDescribeRequest : Message, IRespond<ShareGroupDescribeResponse>
    {
        public ShareGroupDescribeRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ShareGroupDescribeRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(77);
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

        internal override int GetSize() => _groupIdsCollection.GetSize(IsFlexibleVersion) + _includeAuthorizedOperations.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ShareGroupDescribeRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ShareGroupDescribeRequest(version);
            instance.GroupIdsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.IncludeAuthorizedOperations = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ShareGroupDescribeRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _groupIdsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _includeAuthorizedOperations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<String> _groupIdsCollection = Array.Empty<String>();
        /// <summary>
        /// <para>The ids of the groups to describe</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<String> GroupIdsCollection
        {
            get => _groupIdsCollection;
            private set
            {
                _groupIdsCollection = value;
            }
        }

        /// <summary>
        /// <para>The ids of the groups to describe</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareGroupDescribeRequest WithGroupIdsCollection(Array<String> groupIdsCollection)
        {
            GroupIdsCollection = groupIdsCollection;
            return this;
        }

        private Boolean _includeAuthorizedOperations = Boolean.Default;
        /// <summary>
        /// <para>Whether to include authorized operations.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean IncludeAuthorizedOperations
        {
            get => _includeAuthorizedOperations;
            private set
            {
                _includeAuthorizedOperations = value;
            }
        }

        /// <summary>
        /// <para>Whether to include authorized operations.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ShareGroupDescribeRequest WithIncludeAuthorizedOperations(Boolean includeAuthorizedOperations)
        {
            IncludeAuthorizedOperations = includeAuthorizedOperations;
            return this;
        }

        public ShareGroupDescribeResponse Respond() => new ShareGroupDescribeResponse(Version);
    }
}
