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
    public class DescribeConfigsResponse : Message
    {
        public DescribeConfigsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeConfigsResponse does not support version {version}. Valid versions are: 0-4");
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
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _resultsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeConfigsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeConfigsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ResultsCollection = await Array<DescribeConfigsResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeConfigsResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeConfigsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _resultsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public DescribeConfigsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Array<DescribeConfigsResult> _resultsCollection = Array.Empty<DescribeConfigsResult>();
        /// <summary>
        /// <para>The results for each resource.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DescribeConfigsResult> ResultsCollection
        {
            get => _resultsCollection;
            private set
            {
                _resultsCollection = value;
            }
        }

        /// <summary>
        /// <para>The results for each resource.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeConfigsResponse WithResultsCollection(params Func<DescribeConfigsResult, DescribeConfigsResult>[] createFields)
        {
            ResultsCollection = createFields.Select(createField => createField(new DescribeConfigsResult(Version))).ToArray();
            return this;
        }

        public delegate DescribeConfigsResult CreateDescribeConfigsResult(DescribeConfigsResult field);
        /// <summary>
        /// <para>The results for each resource.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeConfigsResponse WithResultsCollection(IEnumerable<CreateDescribeConfigsResult> createFields)
        {
            ResultsCollection = createFields.Select(createField => createField(new DescribeConfigsResult(Version))).ToArray();
            return this;
        }

        public class DescribeConfigsResult : ISerialize
        {
            internal DescribeConfigsResult(Int16 version)
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
            internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _resourceType.GetSize(IsFlexibleVersion) + _resourceName.GetSize(IsFlexibleVersion) + _configsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribeConfigsResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribeConfigsResult(version);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ResourceType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ResourceName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ConfigsCollection = await Array<DescribeConfigsResourceResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeConfigsResourceResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeConfigsResult is unknown");
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
                await _configsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The error code, or 0 if we were able to successfully describe the configurations.</para>
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
            /// <para>The error code, or 0 if we were able to successfully describe the configurations.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeConfigsResult WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _errorMessage = NullableString.Default;
            /// <summary>
            /// <para>The error message, or null if we were able to successfully describe the configurations.</para>
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
            /// <para>The error message, or null if we were able to successfully describe the configurations.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeConfigsResult WithErrorMessage(String? errorMessage)
            {
                ErrorMessage = errorMessage;
                return this;
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
            public DescribeConfigsResult WithResourceType(Int8 resourceType)
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
            public DescribeConfigsResult WithResourceName(String resourceName)
            {
                ResourceName = resourceName;
                return this;
            }

            private Array<DescribeConfigsResourceResult> _configsCollection = Array.Empty<DescribeConfigsResourceResult>();
            /// <summary>
            /// <para>Each listed configuration.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<DescribeConfigsResourceResult> ConfigsCollection
            {
                get => _configsCollection;
                private set
                {
                    _configsCollection = value;
                }
            }

            /// <summary>
            /// <para>Each listed configuration.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeConfigsResult WithConfigsCollection(params Func<DescribeConfigsResourceResult, DescribeConfigsResourceResult>[] createFields)
            {
                ConfigsCollection = createFields.Select(createField => createField(new DescribeConfigsResourceResult(Version))).ToArray();
                return this;
            }

            public delegate DescribeConfigsResourceResult CreateDescribeConfigsResourceResult(DescribeConfigsResourceResult field);
            /// <summary>
            /// <para>Each listed configuration.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeConfigsResult WithConfigsCollection(IEnumerable<CreateDescribeConfigsResourceResult> createFields)
            {
                ConfigsCollection = createFields.Select(createField => createField(new DescribeConfigsResourceResult(Version))).ToArray();
                return this;
            }

            public class DescribeConfigsResourceResult : ISerialize
            {
                internal DescribeConfigsResourceResult(Int16 version)
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
                internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _value.GetSize(IsFlexibleVersion) + _readOnly.GetSize(IsFlexibleVersion) + (Version >= 0 && Version <= 0 ? _isDefault.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _configSource.GetSize(IsFlexibleVersion) : 0) + _isSensitive.GetSize(IsFlexibleVersion) + (Version >= 1 ? _synonymsCollection.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _configType.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _documentation.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<DescribeConfigsResourceResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new DescribeConfigsResourceResult(version);
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Value = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.ReadOnly = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 0 && instance.Version <= 0)
                        instance.IsDefault = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.ConfigSource = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.IsSensitive = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 1)
                        instance.SynonymsCollection = await Array<DescribeConfigsSynonym>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeConfigsSynonym.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 3)
                        instance.ConfigType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 3)
                        instance.Documentation = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeConfigsResourceResult is unknown");
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
                    await _readOnly.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 0 && Version <= 0)
                        await _isDefault.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _configSource.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _isSensitive.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 1)
                        await _synonymsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 3)
                        await _configType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 3)
                        await _documentation.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private String _name = String.Default;
                /// <summary>
                /// <para>The configuration name.</para>
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
                /// <para>The configuration name.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeConfigsResourceResult WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private NullableString _value = NullableString.Default;
                /// <summary>
                /// <para>The configuration value.</para>
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
                /// <para>The configuration value.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeConfigsResourceResult WithValue(String? value)
                {
                    Value = value;
                    return this;
                }

                private Boolean _readOnly = Boolean.Default;
                /// <summary>
                /// <para>True if the configuration is read-only.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Boolean ReadOnly
                {
                    get => _readOnly;
                    private set
                    {
                        _readOnly = value;
                    }
                }

                /// <summary>
                /// <para>True if the configuration is read-only.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeConfigsResourceResult WithReadOnly(Boolean readOnly)
                {
                    ReadOnly = readOnly;
                    return this;
                }

                private Boolean _isDefault = Boolean.Default;
                /// <summary>
                /// <para>True if the configuration is not set.</para>
                /// <para>Versions: 0</para>
                /// </summary>
                public Boolean IsDefault
                {
                    get => _isDefault;
                    private set
                    {
                        if (Version >= 0 && Version <= 0 == false)
                            throw new UnsupportedVersionException($"IsDefault does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
                        _isDefault = value;
                    }
                }

                /// <summary>
                /// <para>True if the configuration is not set.</para>
                /// <para>Versions: 0</para>
                /// </summary>
                public DescribeConfigsResourceResult WithIsDefault(Boolean isDefault)
                {
                    IsDefault = isDefault;
                    return this;
                }

                private Int8 _configSource = new Int8(-1);
                /// <summary>
                /// <para>The configuration source.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int8 ConfigSource
                {
                    get => _configSource;
                    private set
                    {
                        _configSource = value;
                    }
                }

                /// <summary>
                /// <para>The configuration source.</para>
                /// <para>Versions: 1+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public DescribeConfigsResourceResult WithConfigSource(Int8 configSource)
                {
                    ConfigSource = configSource;
                    return this;
                }

                private Boolean _isSensitive = Boolean.Default;
                /// <summary>
                /// <para>True if this configuration is sensitive.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Boolean IsSensitive
                {
                    get => _isSensitive;
                    private set
                    {
                        _isSensitive = value;
                    }
                }

                /// <summary>
                /// <para>True if this configuration is sensitive.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribeConfigsResourceResult WithIsSensitive(Boolean isSensitive)
                {
                    IsSensitive = isSensitive;
                    return this;
                }

                private Array<DescribeConfigsSynonym> _synonymsCollection = Array.Empty<DescribeConfigsSynonym>();
                /// <summary>
                /// <para>The synonyms for this configuration key.</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public Array<DescribeConfigsSynonym> SynonymsCollection
                {
                    get => _synonymsCollection;
                    private set
                    {
                        _synonymsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The synonyms for this configuration key.</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public DescribeConfigsResourceResult WithSynonymsCollection(params Func<DescribeConfigsSynonym, DescribeConfigsSynonym>[] createFields)
                {
                    SynonymsCollection = createFields.Select(createField => createField(new DescribeConfigsSynonym(Version))).ToArray();
                    return this;
                }

                public delegate DescribeConfigsSynonym CreateDescribeConfigsSynonym(DescribeConfigsSynonym field);
                /// <summary>
                /// <para>The synonyms for this configuration key.</para>
                /// <para>Versions: 1+</para>
                /// </summary>
                public DescribeConfigsResourceResult WithSynonymsCollection(IEnumerable<CreateDescribeConfigsSynonym> createFields)
                {
                    SynonymsCollection = createFields.Select(createField => createField(new DescribeConfigsSynonym(Version))).ToArray();
                    return this;
                }

                public class DescribeConfigsSynonym : ISerialize
                {
                    internal DescribeConfigsSynonym(Int16 version)
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
                    internal int GetSize(bool _) => (Version >= 1 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _value.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _source.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                    internal static async ValueTask<DescribeConfigsSynonym> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                    {
                        var instance = new DescribeConfigsSynonym(version);
                        if (instance.Version >= 1)
                            instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 1)
                            instance.Value = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.Version >= 1)
                            instance.Source = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (instance.IsFlexibleVersion)
                        {
                            var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                            await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                            {
                                switch (tag.Tag)
                                {
                                    default:
                                        throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeConfigsSynonym is unknown");
                                }
                            }
                        }

                        return instance;
                    }

                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                    {
                        if (Version >= 1)
                            await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 1)
                            await _value.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (Version >= 1)
                            await _source.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                        if (IsFlexibleVersion)
                        {
                            await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    private String _name = String.Default;
                    /// <summary>
                    /// <para>The synonym name.</para>
                    /// <para>Versions: 1+</para>
                    /// </summary>
                    public String Name
                    {
                        get => _name;
                        private set
                        {
                            if (Version >= 1 == false)
                                throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                            _name = value;
                        }
                    }

                    /// <summary>
                    /// <para>The synonym name.</para>
                    /// <para>Versions: 1+</para>
                    /// </summary>
                    public DescribeConfigsSynonym WithName(String name)
                    {
                        Name = name;
                        return this;
                    }

                    private NullableString _value = NullableString.Default;
                    /// <summary>
                    /// <para>The synonym value.</para>
                    /// <para>Versions: 1+</para>
                    /// </summary>
                    public String? Value
                    {
                        get => _value;
                        private set
                        {
                            if (Version >= 1 == false)
                                throw new UnsupportedVersionException($"Value does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                            _value = value;
                        }
                    }

                    /// <summary>
                    /// <para>The synonym value.</para>
                    /// <para>Versions: 1+</para>
                    /// </summary>
                    public DescribeConfigsSynonym WithValue(String? value)
                    {
                        Value = value;
                        return this;
                    }

                    private Int8 _source = Int8.Default;
                    /// <summary>
                    /// <para>The synonym source.</para>
                    /// <para>Versions: 1+</para>
                    /// </summary>
                    public Int8 Source
                    {
                        get => _source;
                        private set
                        {
                            if (Version >= 1 == false)
                                throw new UnsupportedVersionException($"Source does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                            _source = value;
                        }
                    }

                    /// <summary>
                    /// <para>The synonym source.</para>
                    /// <para>Versions: 1+</para>
                    /// </summary>
                    public DescribeConfigsSynonym WithSource(Int8 source)
                    {
                        Source = source;
                        return this;
                    }
                }

                private Int8 _configType = new Int8(0);
                /// <summary>
                /// <para>The configuration data type. Type can be one of the following values - BOOLEAN, STRING, INT, SHORT, LONG, DOUBLE, LIST, CLASS, PASSWORD</para>
                /// <para>Versions: 3+</para>
                /// <para>Default: 0</para>
                /// </summary>
                public Int8 ConfigType
                {
                    get => _configType;
                    private set
                    {
                        _configType = value;
                    }
                }

                /// <summary>
                /// <para>The configuration data type. Type can be one of the following values - BOOLEAN, STRING, INT, SHORT, LONG, DOUBLE, LIST, CLASS, PASSWORD</para>
                /// <para>Versions: 3+</para>
                /// <para>Default: 0</para>
                /// </summary>
                public DescribeConfigsResourceResult WithConfigType(Int8 configType)
                {
                    ConfigType = configType;
                    return this;
                }

                private NullableString _documentation = NullableString.Default;
                /// <summary>
                /// <para>The configuration documentation.</para>
                /// <para>Versions: 3+</para>
                /// </summary>
                public String? Documentation
                {
                    get => _documentation;
                    private set
                    {
                        _documentation = value;
                    }
                }

                /// <summary>
                /// <para>The configuration documentation.</para>
                /// <para>Versions: 3+</para>
                /// </summary>
                public DescribeConfigsResourceResult WithDocumentation(String? documentation)
                {
                    Documentation = documentation;
                    return this;
                }
            }
        }
    }
}
