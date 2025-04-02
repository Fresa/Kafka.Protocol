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
    public class DescribeAclsRequest : Message, IRespond<DescribeAclsResponse>
    {
        public DescribeAclsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeAclsRequest does not support version {version}. Valid versions are: 1-3");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(29);
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

        internal override int GetSize() => _resourceTypeFilter.GetSize(IsFlexibleVersion) + _resourceNameFilter.GetSize(IsFlexibleVersion) + (Version >= 1 ? _patternTypeFilter.GetSize(IsFlexibleVersion) : 0) + _principalFilter.GetSize(IsFlexibleVersion) + _hostFilter.GetSize(IsFlexibleVersion) + _operation.GetSize(IsFlexibleVersion) + _permissionType.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeAclsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeAclsRequest(version);
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
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeAclsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
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
        public DescribeAclsRequest WithResourceTypeFilter(Int8 resourceTypeFilter)
        {
            ResourceTypeFilter = resourceTypeFilter;
            return this;
        }

        private NullableString _resourceNameFilter = NullableString.Default;
        /// <summary>
        /// <para>The resource name, or null to match any resource name.</para>
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
        /// <para>The resource name, or null to match any resource name.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeAclsRequest WithResourceNameFilter(String? resourceNameFilter)
        {
            ResourceNameFilter = resourceNameFilter;
            return this;
        }

        private Int8 _patternTypeFilter = new Int8(3);
        /// <summary>
        /// <para>The resource pattern to match.</para>
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
        /// <para>The resource pattern to match.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: 3</para>
        /// </summary>
        public DescribeAclsRequest WithPatternTypeFilter(Int8 patternTypeFilter)
        {
            PatternTypeFilter = patternTypeFilter;
            return this;
        }

        private NullableString _principalFilter = NullableString.Default;
        /// <summary>
        /// <para>The principal to match, or null to match any principal.</para>
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
        /// <para>The principal to match, or null to match any principal.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeAclsRequest WithPrincipalFilter(String? principalFilter)
        {
            PrincipalFilter = principalFilter;
            return this;
        }

        private NullableString _hostFilter = NullableString.Default;
        /// <summary>
        /// <para>The host to match, or null to match any host.</para>
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
        /// <para>The host to match, or null to match any host.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeAclsRequest WithHostFilter(String? hostFilter)
        {
            HostFilter = hostFilter;
            return this;
        }

        private Int8 _operation = Int8.Default;
        /// <summary>
        /// <para>The operation to match.</para>
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
        /// <para>The operation to match.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeAclsRequest WithOperation(Int8 operation)
        {
            Operation = operation;
            return this;
        }

        private Int8 _permissionType = Int8.Default;
        /// <summary>
        /// <para>The permission type to match.</para>
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
        /// <para>The permission type to match.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeAclsRequest WithPermissionType(Int8 permissionType)
        {
            PermissionType = permissionType;
            return this;
        }

        public DescribeAclsResponse Respond() => new DescribeAclsResponse(Version);
    }
}
