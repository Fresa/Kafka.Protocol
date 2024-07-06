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
    public class AlterConfigsRequest : Message, IRespond<AlterConfigsResponse>
    {
        public AlterConfigsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AlterConfigsRequest does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(33);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(2);
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

        internal override int GetSize() => _resourcesCollection.GetSize(IsFlexibleVersion) + _validateOnly.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AlterConfigsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AlterConfigsRequest(version);
            instance.ResourcesCollection = await Map<Int8, AlterConfigsResource>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterConfigsResource.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.ResourceType, cancellationToken).ConfigureAwait(false);
            instance.ValidateOnly = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterConfigsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _resourcesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _validateOnly.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Map<Int8, AlterConfigsResource> _resourcesCollection = Map<Int8, AlterConfigsResource>.Default;
        /// <summary>
        /// <para>The updates for each resource.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<Int8, AlterConfigsResource> ResourcesCollection
        {
            get => _resourcesCollection;
            private set
            {
                _resourcesCollection = value;
            }
        }

        /// <summary>
        /// <para>The updates for each resource.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterConfigsRequest WithResourcesCollection(params Func<AlterConfigsResource, AlterConfigsResource>[] createFields)
        {
            ResourcesCollection = createFields.Select(createField => createField(new AlterConfigsResource(Version))).ToDictionary(field => field.ResourceType);
            return this;
        }

        public delegate AlterConfigsResource CreateAlterConfigsResource(AlterConfigsResource field);
        /// <summary>
        /// <para>The updates for each resource.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterConfigsRequest WithResourcesCollection(IEnumerable<CreateAlterConfigsResource> createFields)
        {
            ResourcesCollection = createFields.Select(createField => createField(new AlterConfigsResource(Version))).ToDictionary(field => field.ResourceType);
            return this;
        }

        public class AlterConfigsResource : ISerialize
        {
            internal AlterConfigsResource(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 2;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _resourceType.GetSize(IsFlexibleVersion) + _resourceName.GetSize(IsFlexibleVersion) + _configsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AlterConfigsResource> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AlterConfigsResource(version);
                instance.ResourceType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ResourceName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ConfigsCollection = await Map<String, AlterableConfig>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterableConfig.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterConfigsResource is unknown");
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
                await _configsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public AlterConfigsResource WithResourceType(Int8 resourceType)
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
            public AlterConfigsResource WithResourceName(String resourceName)
            {
                ResourceName = resourceName;
                return this;
            }

            private Map<String, AlterableConfig> _configsCollection = Map<String, AlterableConfig>.Default;
            /// <summary>
            /// <para>The configurations.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Map<String, AlterableConfig> ConfigsCollection
            {
                get => _configsCollection;
                private set
                {
                    _configsCollection = value;
                }
            }

            /// <summary>
            /// <para>The configurations.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterConfigsResource WithConfigsCollection(params Func<AlterableConfig, AlterableConfig>[] createFields)
            {
                ConfigsCollection = createFields.Select(createField => createField(new AlterableConfig(Version))).ToDictionary(field => field.Name);
                return this;
            }

            public delegate AlterableConfig CreateAlterableConfig(AlterableConfig field);
            /// <summary>
            /// <para>The configurations.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterConfigsResource WithConfigsCollection(IEnumerable<CreateAlterableConfig> createFields)
            {
                ConfigsCollection = createFields.Select(createField => createField(new AlterableConfig(Version))).ToDictionary(field => field.Name);
                return this;
            }

            public class AlterableConfig : ISerialize
            {
                internal AlterableConfig(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 2;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _value.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<AlterableConfig> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new AlterableConfig(version);
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Value = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterableConfig is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _value.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private String _name = String.Default;
                /// <summary>
                /// <para>The configuration key name.</para>
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
                /// <para>The configuration key name.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public AlterableConfig WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private NullableString _value = NullableString.Default;
                /// <summary>
                /// <para>The value to set for the configuration key.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public String? Value
                {
                    get => _value;
                    private set
                    {
                        _value = value;
                    }
                }

                /// <summary>
                /// <para>The value to set for the configuration key.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public AlterableConfig WithValue(String? value)
                {
                    Value = value;
                    return this;
                }
            }
        }

        private Boolean _validateOnly = Boolean.Default;
        /// <summary>
        /// <para>True if we should validate the request, but not change the configurations.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean ValidateOnly
        {
            get => _validateOnly;
            private set
            {
                _validateOnly = value;
            }
        }

        /// <summary>
        /// <para>True if we should validate the request, but not change the configurations.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterConfigsRequest WithValidateOnly(Boolean validateOnly)
        {
            ValidateOnly = validateOnly;
            return this;
        }

        public AlterConfigsResponse Respond() => new AlterConfigsResponse(Version);
    }
}
