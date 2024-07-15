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
    public class DeleteAclsResponse : Message
    {
        public DeleteAclsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DeleteAclsResponse does not support version {version}. Valid versions are: 0-3");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(31);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(3);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _filterResultsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DeleteAclsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DeleteAclsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.FilterResultsCollection = await Array<DeleteAclsFilterResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DeleteAclsFilterResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteAclsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _filterResultsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public DeleteAclsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Array<DeleteAclsFilterResult> _filterResultsCollection = Array.Empty<DeleteAclsFilterResult>();
        /// <summary>
        /// <para>The results for each filter.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DeleteAclsFilterResult> FilterResultsCollection
        {
            get => _filterResultsCollection;
            private set
            {
                _filterResultsCollection = value;
            }
        }

        /// <summary>
        /// <para>The results for each filter.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteAclsResponse WithFilterResultsCollection(params Func<DeleteAclsFilterResult, DeleteAclsFilterResult>[] createFields)
        {
            FilterResultsCollection = createFields.Select(createField => createField(new DeleteAclsFilterResult(Version))).ToArray();
            return this;
        }

        public delegate DeleteAclsFilterResult CreateDeleteAclsFilterResult(DeleteAclsFilterResult field);
        /// <summary>
        /// <para>The results for each filter.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DeleteAclsResponse WithFilterResultsCollection(IEnumerable<CreateDeleteAclsFilterResult> createFields)
        {
            FilterResultsCollection = createFields.Select(createField => createField(new DeleteAclsFilterResult(Version))).ToArray();
            return this;
        }

        public class DeleteAclsFilterResult : ISerialize
        {
            internal DeleteAclsFilterResult(Int16 version)
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
            internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _matchingAclsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DeleteAclsFilterResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DeleteAclsFilterResult(version);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.MatchingAclsCollection = await Array<DeleteAclsMatchingAcl>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DeleteAclsMatchingAcl.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteAclsFilterResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _matchingAclsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The error code, or 0 if the filter succeeded.</para>
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
            /// <para>The error code, or 0 if the filter succeeded.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteAclsFilterResult WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _errorMessage = NullableString.Default;
            /// <summary>
            /// <para>The error message, or null if the filter succeeded.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String? ErrorMessage
            {
                get => _errorMessage;
                private set
                {
                    _errorMessage = value;
                }
            }

            /// <summary>
            /// <para>The error message, or null if the filter succeeded.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteAclsFilterResult WithErrorMessage(String? errorMessage)
            {
                ErrorMessage = errorMessage;
                return this;
            }

            private Array<DeleteAclsMatchingAcl> _matchingAclsCollection = Array.Empty<DeleteAclsMatchingAcl>();
            /// <summary>
            /// <para>The ACLs which matched this filter.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<DeleteAclsMatchingAcl> MatchingAclsCollection
            {
                get => _matchingAclsCollection;
                private set
                {
                    _matchingAclsCollection = value;
                }
            }

            /// <summary>
            /// <para>The ACLs which matched this filter.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteAclsFilterResult WithMatchingAclsCollection(params Func<DeleteAclsMatchingAcl, DeleteAclsMatchingAcl>[] createFields)
            {
                MatchingAclsCollection = createFields.Select(createField => createField(new DeleteAclsMatchingAcl(Version))).ToArray();
                return this;
            }

            public delegate DeleteAclsMatchingAcl CreateDeleteAclsMatchingAcl(DeleteAclsMatchingAcl field);
            /// <summary>
            /// <para>The ACLs which matched this filter.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DeleteAclsFilterResult WithMatchingAclsCollection(IEnumerable<CreateDeleteAclsMatchingAcl> createFields)
            {
                MatchingAclsCollection = createFields.Select(createField => createField(new DeleteAclsMatchingAcl(Version))).ToArray();
                return this;
            }

            public class DeleteAclsMatchingAcl : ISerialize
            {
                internal DeleteAclsMatchingAcl(Int16 version)
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
                internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _resourceType.GetSize(IsFlexibleVersion) + _resourceName.GetSize(IsFlexibleVersion) + (Version >= 1 ? _patternType.GetSize(IsFlexibleVersion) : 0) + _principal.GetSize(IsFlexibleVersion) + _host.GetSize(IsFlexibleVersion) + _operation.GetSize(IsFlexibleVersion) + _permissionType.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<DeleteAclsMatchingAcl> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new DeleteAclsMatchingAcl(version);
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ResourceType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ResourceName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.PatternType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for DeleteAclsMatchingAcl is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _resourceType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _resourceName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _patternType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _principal.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _operation.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _permissionType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int16 _errorCode = Int16.Default;
                /// <summary>
                /// <para>The deletion error code, or 0 if the deletion succeeded.</para>
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
                /// <para>The deletion error code, or 0 if the deletion succeeded.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DeleteAclsMatchingAcl WithErrorCode(Int16 errorCode)
                {
                    ErrorCode = errorCode;
                    return this;
                }

                private NullableString _errorMessage = NullableString.Default;
                /// <summary>
                /// <para>The deletion error message, or null if the deletion succeeded.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public String? ErrorMessage
                {
                    get => _errorMessage;
                    private set
                    {
                        _errorMessage = value;
                    }
                }

                /// <summary>
                /// <para>The deletion error message, or null if the deletion succeeded.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DeleteAclsMatchingAcl WithErrorMessage(String? errorMessage)
                {
                    ErrorMessage = errorMessage;
                    return this;
                }

                private Int8 _resourceType = Int8.Default;
                /// <summary>
                /// <para>The ACL resource type.</para>
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
                /// <para>The ACL resource type.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DeleteAclsMatchingAcl WithResourceType(Int8 resourceType)
                {
                    ResourceType = resourceType;
                    return this;
                }

                private String _resourceName = String.Default;
                /// <summary>
                /// <para>The ACL resource name.</para>
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
                /// <para>The ACL resource name.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DeleteAclsMatchingAcl WithResourceName(String resourceName)
                {
                    ResourceName = resourceName;
                    return this;
                }

                private Int8 _patternType = new Int8(3);
                /// <summary>
                /// <para>The ACL resource pattern type.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: 3</para>
                /// </summary>
                public Int8 PatternType
                {
                    get => _patternType;
                    private set
                    {
                        if (Version >= 1 == false)
                            throw new UnsupportedVersionException($"PatternType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                        _patternType = value;
                    }
                }

                /// <summary>
                /// <para>The ACL resource pattern type.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: 3</para>
                /// </summary>
                public DeleteAclsMatchingAcl WithPatternType(Int8 patternType)
                {
                    PatternType = patternType;
                    return this;
                }

                private String _principal = String.Default;
                /// <summary>
                /// <para>The ACL principal.</para>
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
                /// <para>The ACL principal.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DeleteAclsMatchingAcl WithPrincipal(String principal)
                {
                    Principal = principal;
                    return this;
                }

                private String _host = String.Default;
                /// <summary>
                /// <para>The ACL host.</para>
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
                /// <para>The ACL host.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DeleteAclsMatchingAcl WithHost(String host)
                {
                    Host = host;
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
                public DeleteAclsMatchingAcl WithOperation(Int8 operation)
                {
                    Operation = operation;
                    return this;
                }

                private Int8 _permissionType = Int8.Default;
                /// <summary>
                /// <para>The ACL permission type.</para>
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
                /// <para>The ACL permission type.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DeleteAclsMatchingAcl WithPermissionType(Int8 permissionType)
                {
                    PermissionType = permissionType;
                    return this;
                }
            }
        }
    }
}
