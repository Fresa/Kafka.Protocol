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
    public class ListConfigResourcesRequest : Message, IRespond<ListConfigResourcesResponse>
    {
        public ListConfigResourcesRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ListConfigResourcesRequest does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(74);
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
            return new Tags.TagSection();
        }

        internal override int GetSize() => (Version >= 1 ? _resourceTypesCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ListConfigResourcesRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ListConfigResourcesRequest(version);
            if (instance.Version >= 1)
                instance.ResourceTypesCollection = await Array<Int8>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ListConfigResourcesRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 1)
                await _resourceTypesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<Int8> _resourceTypesCollection = Array.Empty<Int8>();
        /// <summary>
        /// <para>The list of resource type. If the list is empty, it uses default supported config resource types.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public Array<Int8> ResourceTypesCollection
        {
            get => _resourceTypesCollection;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"ResourceTypesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _resourceTypesCollection = value;
            }
        }

        /// <summary>
        /// <para>The list of resource type. If the list is empty, it uses default supported config resource types.</para>
        /// <para>Versions: 1+</para>
        /// </summary>
        public ListConfigResourcesRequest WithResourceTypesCollection(Array<Int8> resourceTypesCollection)
        {
            ResourceTypesCollection = resourceTypesCollection;
            return this;
        }

        public ListConfigResourcesResponse Respond() => new ListConfigResourcesResponse(Version);
    }
}
