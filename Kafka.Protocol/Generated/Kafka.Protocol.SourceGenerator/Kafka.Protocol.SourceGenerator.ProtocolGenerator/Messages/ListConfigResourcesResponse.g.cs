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
    public class ListConfigResourcesResponse : Message
    {
        public ListConfigResourcesResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ListConfigResourcesResponse does not support version {version}. Valid versions are: 0-1");
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
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _configResourcesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ListConfigResourcesResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ListConfigResourcesResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ConfigResourcesCollection = await Array<ConfigResource>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ConfigResource.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ListConfigResourcesResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _configResourcesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
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
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListConfigResourcesResponse WithThrottleTimeMs(Int32 throttleTimeMs)
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
        public ListConfigResourcesResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<ConfigResource> _configResourcesCollection = Array.Empty<ConfigResource>();
        /// <summary>
        /// <para>Each config resource in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ConfigResource> ConfigResourcesCollection
        {
            get => _configResourcesCollection;
            private set
            {
                _configResourcesCollection = value;
            }
        }

        /// <summary>
        /// <para>Each config resource in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListConfigResourcesResponse WithConfigResourcesCollection(params Func<ConfigResource, ConfigResource>[] createFields)
        {
            ConfigResourcesCollection = createFields.Select(createField => createField(new ConfigResource(Version))).ToArray();
            return this;
        }

        public delegate ConfigResource CreateConfigResource(ConfigResource field);
        /// <summary>
        /// <para>Each config resource in the response.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListConfigResourcesResponse WithConfigResourcesCollection(IEnumerable<CreateConfigResource> createFields)
        {
            ConfigResourcesCollection = createFields.Select(createField => createField(new ConfigResource(Version))).ToArray();
            return this;
        }

        public class ConfigResource : ISerialize
        {
            internal ConfigResource(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = true;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _resourceName.GetSize(IsFlexibleVersion) + (Version >= 1 ? _resourceType.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ConfigResource> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ConfigResource(version);
                instance.ResourceName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.ResourceType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ConfigResource is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _resourceName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _resourceType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
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
            public ConfigResource WithResourceName(String resourceName)
            {
                ResourceName = resourceName;
                return this;
            }

            private Int8 _resourceType = new Int8(16);
            /// <summary>
            /// <para>The resource type.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: 16</para>
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
            /// <para>Versions: 1+</para>
            /// <para>Default: 16</para>
            /// </summary>
            public ConfigResource WithResourceType(Int8 resourceType)
            {
                ResourceType = resourceType;
                return this;
            }
        }
    }
}
