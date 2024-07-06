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
    public class CreateAclsRequest : Message, IRespond<CreateAclsResponse>
    {
        public CreateAclsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"CreateAclsRequest does not support version {version}. Valid versions are: 0-3");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(30);
        public static readonly Int16 MinVersion = Int16.From(0);
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

        internal override int GetSize() => _creationsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<CreateAclsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new CreateAclsRequest(version);
            instance.CreationsCollection = await Array<AclCreation>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AclCreation.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for CreateAclsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _creationsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<AclCreation> _creationsCollection = Array.Empty<AclCreation>();
        /// <summary>
        /// <para>The ACLs that we want to create.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<AclCreation> CreationsCollection
        {
            get => _creationsCollection;
            private set
            {
                _creationsCollection = value;
            }
        }

        /// <summary>
        /// <para>The ACLs that we want to create.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateAclsRequest WithCreationsCollection(params Func<AclCreation, AclCreation>[] createFields)
        {
            CreationsCollection = createFields.Select(createField => createField(new AclCreation(Version))).ToArray();
            return this;
        }

        public delegate AclCreation CreateAclCreation(AclCreation field);
        /// <summary>
        /// <para>The ACLs that we want to create.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateAclsRequest WithCreationsCollection(IEnumerable<CreateAclCreation> createFields)
        {
            CreationsCollection = createFields.Select(createField => createField(new AclCreation(Version))).ToArray();
            return this;
        }

        public class AclCreation : ISerialize
        {
            internal AclCreation(Int16 version)
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
            internal int GetSize(bool _) => _resourceType.GetSize(IsFlexibleVersion) + _resourceName.GetSize(IsFlexibleVersion) + (Version >= 1 ? _resourcePatternType.GetSize(IsFlexibleVersion) : 0) + _principal.GetSize(IsFlexibleVersion) + _host.GetSize(IsFlexibleVersion) + _operation.GetSize(IsFlexibleVersion) + _permissionType.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AclCreation> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AclCreation(version);
                instance.ResourceType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ResourceName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.ResourcePatternType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Principal = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AclCreation is unknown");
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
                if (Version >= 1)
                    await _resourcePatternType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _principal.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _operation.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _permissionType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int8 _resourceType = Int8.Default;
            /// <summary>
            /// <para>The type of the resource.</para>
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
            /// <para>The type of the resource.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AclCreation WithResourceType(Int8 resourceType)
            {
                ResourceType = resourceType;
                return this;
            }

            private String _resourceName = String.Default;
            /// <summary>
            /// <para>The resource name for the ACL.</para>
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
            /// <para>The resource name for the ACL.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AclCreation WithResourceName(String resourceName)
            {
                ResourceName = resourceName;
                return this;
            }

            private Int8 _resourcePatternType = new Int8(3);
            /// <summary>
            /// <para>The pattern type for the ACL.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: 3</para>
            /// </summary>
            public Int8 ResourcePatternType
            {
                get => _resourcePatternType;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"ResourcePatternType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _resourcePatternType = value;
                }
            }

            /// <summary>
            /// <para>The pattern type for the ACL.</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: 3</para>
            /// </summary>
            public AclCreation WithResourcePatternType(Int8 resourcePatternType)
            {
                ResourcePatternType = resourcePatternType;
                return this;
            }

            private String _principal = String.Default;
            /// <summary>
            /// <para>The principal for the ACL.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Principal
            {
                get => _principal;
                private set
                {
                    _principal = value;
                }
            }

            /// <summary>
            /// <para>The principal for the ACL.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AclCreation WithPrincipal(String principal)
            {
                Principal = principal;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The host for the ACL.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Host
            {
                get => _host;
                private set
                {
                    _host = value;
                }
            }

            /// <summary>
            /// <para>The host for the ACL.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AclCreation WithHost(String host)
            {
                Host = host;
                return this;
            }

            private Int8 _operation = Int8.Default;
            /// <summary>
            /// <para>The operation type for the ACL (read, write, etc.).</para>
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
            /// <para>The operation type for the ACL (read, write, etc.).</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AclCreation WithOperation(Int8 operation)
            {
                Operation = operation;
                return this;
            }

            private Int8 _permissionType = Int8.Default;
            /// <summary>
            /// <para>The permission type for the ACL (allow, deny, etc.).</para>
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
            /// <para>The permission type for the ACL (allow, deny, etc.).</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AclCreation WithPermissionType(Int8 permissionType)
            {
                PermissionType = permissionType;
                return this;
            }
        }

        public CreateAclsResponse Respond() => new CreateAclsResponse(Version);
    }
}
