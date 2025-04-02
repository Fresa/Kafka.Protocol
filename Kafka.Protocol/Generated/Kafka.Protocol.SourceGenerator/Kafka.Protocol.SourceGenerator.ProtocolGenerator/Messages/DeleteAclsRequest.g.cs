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
    public class DeleteAclsRequest : Message, IRespond<DeleteAclsResponse>
    {
        public DeleteAclsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DeleteAclsRequest does not support version {version}. Valid versions are: 1-3");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(31);
        public static readonly Int16 MinVersion = Int16.From(1);
        public static readonly Int16 MaxVersion = Int16.From(3);
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

        internal override int GetSize() => _filtersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DeleteAclsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DeleteAclsRequest(version);
            instance.FiltersCollection = await Array<DeleteAclsFilter>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DeleteAclsFilter.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteAclsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _filtersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<DeleteAclsFilter> _filtersCollection = Array.Empty<DeleteAclsFilter>();
        /// <summary>
        /// <para>The filters to use when deleting ACLs.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DeleteAclsFilter> FiltersCollection
        {
            get => _filtersCollection;
            private set
            {
                _filtersCollection = value;
            }
        }

        /// <summary>
        /// <para>The filters to use when deleting ACLs.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteAclsRequest WithFiltersCollection(params Func<DeleteAclsFilter, DeleteAclsFilter>[] createFields)
        {
            FiltersCollection = createFields.Select(createField => createField(new DeleteAclsFilter(Version))).ToArray();
            return this;
        }

        public delegate DeleteAclsFilter CreateDeleteAclsFilter(DeleteAclsFilter field);
        /// <summary>
        /// <para>The filters to use when deleting ACLs.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteAclsRequest WithFiltersCollection(IEnumerable<CreateDeleteAclsFilter> createFields)
        {
            FiltersCollection = createFields.Select(createField => createField(new DeleteAclsFilter(Version))).ToArray();
            return this;
        }

        public class DeleteAclsFilter : ISerialize
        {
            internal DeleteAclsFilter(Int16 version)
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
            internal int GetSize(bool _) => _resourceTypeFilter.GetSize(IsFlexibleVersion) + _resourceNameFilter.GetSize(IsFlexibleVersion) + (Version >= 1 ? _patternTypeFilter.GetSize(IsFlexibleVersion) : 0) + _principalFilter.GetSize(IsFlexibleVersion) + _hostFilter.GetSize(IsFlexibleVersion) + _operation.GetSize(IsFlexibleVersion) + _permissionType.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DeleteAclsFilter> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DeleteAclsFilter(version);
                instance.ResourceTypeFilter = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ResourceNameFilter = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.PatternTypeFilter = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PrincipalFilter = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.HostFilter = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Operation = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PermissionType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteAclsFilter is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _resourceTypeFilter.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _resourceNameFilter.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _patternTypeFilter.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _principalFilter.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _hostFilter.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _operation.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _permissionType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int8 _resourceTypeFilter = Int8.Default;
            /// <summary>
            /// <para>The resource type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int8 ResourceTypeFilter
            {
                get => _resourceTypeFilter;
                private set
                {
                    _resourceTypeFilter = value;
                }
            }

            /// <summary>
            /// <para>The resource type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteAclsFilter WithResourceTypeFilter(Int8 resourceTypeFilter)
            {
                ResourceTypeFilter = resourceTypeFilter;
                return this;
            }

            private NullableString _resourceNameFilter = NullableString.Default;
            /// <summary>
            /// <para>The resource name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String? ResourceNameFilter
            {
                get => _resourceNameFilter;
                private set
                {
                    _resourceNameFilter = value;
                }
            }

            /// <summary>
            /// <para>The resource name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteAclsFilter WithResourceNameFilter(String? resourceNameFilter)
            {
                ResourceNameFilter = resourceNameFilter;
                return this;
            }

            private Int8 _patternTypeFilter = new Int8(3);
            /// <summary>
            /// <para>The pattern type.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: 3</para>
            /// </summary>
            public Int8 PatternTypeFilter
            {
                get => _patternTypeFilter;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"PatternTypeFilter does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _patternTypeFilter = value;
                }
            }

            /// <summary>
            /// <para>The pattern type.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: 3</para>
            /// </summary>
            public DeleteAclsFilter WithPatternTypeFilter(Int8 patternTypeFilter)
            {
                PatternTypeFilter = patternTypeFilter;
                return this;
            }

            private NullableString _principalFilter = NullableString.Default;
            /// <summary>
            /// <para>The principal filter, or null to accept all principals.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String? PrincipalFilter
            {
                get => _principalFilter;
                private set
                {
                    _principalFilter = value;
                }
            }

            /// <summary>
            /// <para>The principal filter, or null to accept all principals.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteAclsFilter WithPrincipalFilter(String? principalFilter)
            {
                PrincipalFilter = principalFilter;
                return this;
            }

            private NullableString _hostFilter = NullableString.Default;
            /// <summary>
            /// <para>The host filter, or null to accept all hosts.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String? HostFilter
            {
                get => _hostFilter;
                private set
                {
                    _hostFilter = value;
                }
            }

            /// <summary>
            /// <para>The host filter, or null to accept all hosts.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteAclsFilter WithHostFilter(String? hostFilter)
            {
                HostFilter = hostFilter;
                return this;
            }

            private Int8 _operation = Int8.Default;
            /// <summary>
            /// <para>The ACL operation.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int8 Operation
            {
                get => _operation;
                private set
                {
                    _operation = value;
                }
            }

            /// <summary>
            /// <para>The ACL operation.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteAclsFilter WithOperation(Int8 operation)
            {
                Operation = operation;
                return this;
            }

            private Int8 _permissionType = Int8.Default;
            /// <summary>
            /// <para>The permission type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int8 PermissionType
            {
                get => _permissionType;
                private set
                {
                    _permissionType = value;
                }
            }

            /// <summary>
            /// <para>The permission type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteAclsFilter WithPermissionType(Int8 permissionType)
            {
                PermissionType = permissionType;
                return this;
            }
        }

        public DeleteAclsResponse Respond() => new DeleteAclsResponse(Version);
    }
}
