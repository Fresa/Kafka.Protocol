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
    public class DescribeConfigsRequest : Message, IRespond<DescribeConfigsResponse>
    {
        public DescribeConfigsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeConfigsRequest does not support version {version}. Valid versions are: 0-4");
            Version = version;
            IsFlexibleVersion = version >= 4;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(32);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(4);
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

        internal override int GetSize() => _resourcesCollection.GetSize(IsFlexibleVersion) + (Version >= 1 ? _includeSynonyms.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _includeDocumentation.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeConfigsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeConfigsRequest(version);
            instance.ResourcesCollection = await Array<DescribeConfigsResource>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeConfigsResource.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.IncludeSynonyms = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.IncludeDocumentation = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeConfigsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _resourcesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _includeSynonyms.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _includeDocumentation.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<DescribeConfigsResource> _resourcesCollection = Array.Empty<DescribeConfigsResource>();
        /// <summary>
        /// <para>The resources whose configurations we want to describe.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DescribeConfigsResource> ResourcesCollection
        {
            get => _resourcesCollection;
            private set
            {
                _resourcesCollection = value;
            }
        }

        /// <summary>
        /// <para>The resources whose configurations we want to describe.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeConfigsRequest WithResourcesCollection(params Func<DescribeConfigsResource, DescribeConfigsResource>[] createFields)
        {
            ResourcesCollection = createFields.Select(createField => createField(new DescribeConfigsResource(Version))).ToArray();
            return this;
        }

        public delegate DescribeConfigsResource CreateDescribeConfigsResource(DescribeConfigsResource field);
        /// <summary>
        /// <para>The resources whose configurations we want to describe.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeConfigsRequest WithResourcesCollection(IEnumerable<CreateDescribeConfigsResource> createFields)
        {
            ResourcesCollection = createFields.Select(createField => createField(new DescribeConfigsResource(Version))).ToArray();
            return this;
        }

        public class DescribeConfigsResource : ISerialize
        {
            internal DescribeConfigsResource(Int16 version)
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
            internal int GetSize(bool _) => _resourceType.GetSize(IsFlexibleVersion) + _resourceName.GetSize(IsFlexibleVersion) + _configurationKeysCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribeConfigsResource> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribeConfigsResource(version);
                instance.ResourceType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ResourceName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ConfigurationKeysCollection = await NullableArray<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeConfigsResource is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _resourceType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _resourceName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _configurationKeysCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int8 _resourceType = Int8.Default;
            /// <summary>
            /// <para>The resource type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int8 ResourceType
            {
                get => _resourceType;
                private set
                {
                    _resourceType = value;
                }
            }

            /// <summary>
            /// <para>The resource type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeConfigsResource WithResourceType(Int8 resourceType)
            {
                ResourceType = resourceType;
                return this;
            }

            private String _resourceName = String.Default;
            /// <summary>
            /// <para>The resource name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String ResourceName
            {
                get => _resourceName;
                private set
                {
                    _resourceName = value;
                }
            }

            /// <summary>
            /// <para>The resource name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeConfigsResource WithResourceName(String resourceName)
            {
                ResourceName = resourceName;
                return this;
            }

            private NullableArray<String> _configurationKeysCollection = Array.Empty<String>();
            /// <summary>
            /// <para>The configuration keys to list, or null to list all configuration keys.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<String>? ConfigurationKeysCollection
            {
                get => _configurationKeysCollection;
                private set
                {
                    _configurationKeysCollection = value;
                }
            }

            /// <summary>
            /// <para>The configuration keys to list, or null to list all configuration keys.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeConfigsResource WithConfigurationKeysCollection(Array<String>? configurationKeysCollection)
            {
                ConfigurationKeysCollection = configurationKeysCollection;
                return this;
            }
        }

        private Boolean _includeSynonyms = new Boolean(false);
        /// <summary>
        /// <para>True if we should include all synonyms.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean IncludeSynonyms
        {
            get => _includeSynonyms;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"IncludeSynonyms does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _includeSynonyms = value;
            }
        }

        /// <summary>
        /// <para>True if we should include all synonyms.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: false</para>
        /// </summary>
        public DescribeConfigsRequest WithIncludeSynonyms(Boolean includeSynonyms)
        {
            IncludeSynonyms = includeSynonyms;
            return this;
        }

        private Boolean _includeDocumentation = new Boolean(false);
        /// <summary>
        /// <para>True if we should include configuration documentation.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean IncludeDocumentation
        {
            get => _includeDocumentation;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"IncludeDocumentation does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                _includeDocumentation = value;
            }
        }

        /// <summary>
        /// <para>True if we should include configuration documentation.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: false</para>
        /// </summary>
        public DescribeConfigsRequest WithIncludeDocumentation(Boolean includeDocumentation)
        {
            IncludeDocumentation = includeDocumentation;
            return this;
        }

        public DescribeConfigsResponse Respond() => new DescribeConfigsResponse(Version);
    }
}
