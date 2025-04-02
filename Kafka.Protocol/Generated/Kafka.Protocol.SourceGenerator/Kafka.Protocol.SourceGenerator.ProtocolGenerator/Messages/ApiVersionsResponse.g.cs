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
    public class ApiVersionsResponse : Message
    {
        public ApiVersionsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ApiVersionsResponse does not support version {version}. Valid versions are: 0-4");
            Version = version;
            IsFlexibleVersion = version >= 3;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(18);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(4);
        public override Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        // https://github.com/apache/kafka/blob/99b9b3e84f4e98c3f07714e1de6a139a004cbc5b/generator/src/main/java/org/apache/kafka/message/ApiMessageTypeGenerator.java#L324
        public Int16 HeaderVersion
        {
            get
            {
                return 0;
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            var tags = new List<Tags.TaggedField>();
            if (Version >= 3 && _supportedFeaturesCollectionIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 0, Field = _supportedFeaturesCollection });
            }

            if (Version >= 3 && _finalizedFeaturesEpochIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 1, Field = _finalizedFeaturesEpoch });
            }

            if (Version >= 3 && _finalizedFeaturesCollectionIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 2, Field = _finalizedFeaturesCollection });
            }

            if (Version >= 3 && _zkMigrationReadyIsSet)
            {
                tags.Add(new Tags.TaggedField { Tag = 3, Field = _zkMigrationReady });
            }

            return new Tags.TagSection(tags.ToArray());
        }

        internal override int GetSize() => _errorCode.GetSize(IsFlexibleVersion) + _apiKeysCollection.GetSize(IsFlexibleVersion) + (Version >= 1 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ApiVersionsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ApiVersionsResponse(version);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ApiKeysCollection = await Map<Int16, ApiVersion>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ApiVersion.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.ApiKey, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        case 0:
                            if (instance.Version >= 3)
                                instance.SupportedFeaturesCollection = await Map<String, SupportedFeatureKey>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => SupportedFeatureKey.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field SupportedFeaturesCollection is not supported for version {instance.Version}");
                        {
                            var size = instance._supportedFeaturesCollection.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field SupportedFeaturesCollection read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        case 1:
                            if (instance.Version >= 3)
                                instance.FinalizedFeaturesEpoch = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field FinalizedFeaturesEpoch is not supported for version {instance.Version}");
                        {
                            var size = instance._finalizedFeaturesEpoch.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field FinalizedFeaturesEpoch read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        case 2:
                            if (instance.Version >= 3)
                                instance.FinalizedFeaturesCollection = await Map<String, FinalizedFeatureKey>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => FinalizedFeatureKey.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field FinalizedFeaturesCollection is not supported for version {instance.Version}");
                        {
                            var size = instance._finalizedFeaturesCollection.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field FinalizedFeaturesCollection read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        case 3:
                            if (instance.Version >= 3)
                                instance.ZkMigrationReady = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                            else
                                throw new InvalidOperationException($"Field ZkMigrationReady is not supported for version {instance.Version}");
                        {
                            var size = instance._zkMigrationReady.GetSize(true);
                            if (size != tag.Length)
                                throw new CorruptMessageException($"Tagged field ZkMigrationReady read length {tag.Length} but had actual length of {size}");
                        }

                            break;
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ApiVersionsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _apiKeysCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The top-level error code.</para>
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
        /// <para>The top-level error code.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ApiVersionsResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Map<Int16, ApiVersion> _apiKeysCollection = Map<Int16, ApiVersion>.Default;
        /// <summary>
        /// <para>The APIs supported by the broker.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<Int16, ApiVersion> ApiKeysCollection
        {
            get => _apiKeysCollection;
            private set
            {
                _apiKeysCollection = value;
            }
        }

        /// <summary>
        /// <para>The APIs supported by the broker.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ApiVersionsResponse WithApiKeysCollection(params Func<ApiVersion, ApiVersion>[] createFields)
        {
            ApiKeysCollection = createFields.Select(createField => createField(new ApiVersion(Version))).ToDictionary(field => field.ApiKey);
            return this;
        }

        public delegate ApiVersion CreateApiVersion(ApiVersion field);
        /// <summary>
        /// <para>The APIs supported by the broker.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ApiVersionsResponse WithApiKeysCollection(IEnumerable<CreateApiVersion> createFields)
        {
            ApiKeysCollection = createFields.Select(createField => createField(new ApiVersion(Version))).ToDictionary(field => field.ApiKey);
            return this;
        }

        public class ApiVersion : ISerialize
        {
            internal ApiVersion(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _apiKey.GetSize(IsFlexibleVersion) + _minVersion.GetSize(IsFlexibleVersion) + _maxVersion.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ApiVersion> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ApiVersion(version);
                instance.ApiKey = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.MinVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.MaxVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ApiVersion is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _apiKey.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _minVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _maxVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int16 _apiKey = Int16.Default;
            /// <summary>
            /// <para>The API index.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 ApiKey
            {
                get => _apiKey;
                private set
                {
                    _apiKey = value;
                }
            }

            /// <summary>
            /// <para>The API index.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ApiVersion WithApiKey(Int16 apiKey)
            {
                ApiKey = apiKey;
                return this;
            }

            private Int16 _minVersion = Int16.Default;
            /// <summary>
            /// <para>The minimum supported version, inclusive.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 MinVersion
            {
                get => _minVersion;
                private set
                {
                    _minVersion = value;
                }
            }

            /// <summary>
            /// <para>The minimum supported version, inclusive.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ApiVersion WithMinVersion(Int16 minVersion)
            {
                MinVersion = minVersion;
                return this;
            }

            private Int16 _maxVersion = Int16.Default;
            /// <summary>
            /// <para>The maximum supported version, inclusive.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 MaxVersion
            {
                get => _maxVersion;
                private set
                {
                    _maxVersion = value;
                }
            }

            /// <summary>
            /// <para>The maximum supported version, inclusive.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ApiVersion WithMaxVersion(Int16 maxVersion)
            {
                MaxVersion = maxVersion;
                return this;
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 1+</para>
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
        /// <para>Versions: 1+</para>
        /// </summary>
        public ApiVersionsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private bool _supportedFeaturesCollectionIsSet;
        private Map<String, SupportedFeatureKey> _supportedFeaturesCollection = Map<String, SupportedFeatureKey>.Default;
        /// <summary>
        /// <para>Features supported by the broker. Note: in v0-v3, features with MinSupportedVersion = 0 are omitted.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public Map<String, SupportedFeatureKey> SupportedFeaturesCollection
        {
            get => _supportedFeaturesCollection;
            private set
            {
                _supportedFeaturesCollection = value;
                _supportedFeaturesCollectionIsSet = true;
            }
        }

        /// <summary>
        /// <para>Features supported by the broker. Note: in v0-v3, features with MinSupportedVersion = 0 are omitted.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public ApiVersionsResponse WithSupportedFeaturesCollection(params Func<SupportedFeatureKey, SupportedFeatureKey>[] createFields)
        {
            SupportedFeaturesCollection = createFields.Select(createField => createField(new SupportedFeatureKey(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate SupportedFeatureKey CreateSupportedFeatureKey(SupportedFeatureKey field);
        /// <summary>
        /// <para>Features supported by the broker. Note: in v0-v3, features with MinSupportedVersion = 0 are omitted.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public ApiVersionsResponse WithSupportedFeaturesCollection(IEnumerable<CreateSupportedFeatureKey> createFields)
        {
            SupportedFeaturesCollection = createFields.Select(createField => createField(new SupportedFeatureKey(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class SupportedFeatureKey : ISerialize
        {
            internal SupportedFeatureKey(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 3 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _minVersion.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _maxVersion.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<SupportedFeatureKey> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new SupportedFeatureKey(version);
                if (instance.Version >= 3)
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.MinVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.MaxVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for SupportedFeatureKey is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 3)
                    await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _minVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _maxVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The name of the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public String Name
            {
                get => _name;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The name of the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public SupportedFeatureKey WithName(String name)
            {
                Name = name;
                return this;
            }

            private Int16 _minVersion = Int16.Default;
            /// <summary>
            /// <para>The minimum supported version for the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public Int16 MinVersion
            {
                get => _minVersion;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"MinVersion does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _minVersion = value;
                }
            }

            /// <summary>
            /// <para>The minimum supported version for the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public SupportedFeatureKey WithMinVersion(Int16 minVersion)
            {
                MinVersion = minVersion;
                return this;
            }

            private Int16 _maxVersion = Int16.Default;
            /// <summary>
            /// <para>The maximum supported version for the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public Int16 MaxVersion
            {
                get => _maxVersion;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"MaxVersion does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _maxVersion = value;
                }
            }

            /// <summary>
            /// <para>The maximum supported version for the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public SupportedFeatureKey WithMaxVersion(Int16 maxVersion)
            {
                MaxVersion = maxVersion;
                return this;
            }
        }

        private bool _finalizedFeaturesEpochIsSet;
        private Int64 _finalizedFeaturesEpoch = new Int64(-1);
        /// <summary>
        /// <para>The monotonically increasing epoch for the finalized features information. Valid values are >= 0. A value of -1 is special and represents unknown epoch.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int64 FinalizedFeaturesEpoch
        {
            get => _finalizedFeaturesEpoch;
            private set
            {
                _finalizedFeaturesEpoch = value;
                _finalizedFeaturesEpochIsSet = true;
            }
        }

        /// <summary>
        /// <para>The monotonically increasing epoch for the finalized features information. Valid values are >= 0. A value of -1 is special and represents unknown epoch.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public ApiVersionsResponse WithFinalizedFeaturesEpoch(Int64 finalizedFeaturesEpoch)
        {
            FinalizedFeaturesEpoch = finalizedFeaturesEpoch;
            return this;
        }

        private bool _finalizedFeaturesCollectionIsSet;
        private Map<String, FinalizedFeatureKey> _finalizedFeaturesCollection = Map<String, FinalizedFeatureKey>.Default;
        /// <summary>
        /// <para>List of cluster-wide finalized features. The information is valid only if FinalizedFeaturesEpoch >= 0.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public Map<String, FinalizedFeatureKey> FinalizedFeaturesCollection
        {
            get => _finalizedFeaturesCollection;
            private set
            {
                _finalizedFeaturesCollection = value;
                _finalizedFeaturesCollectionIsSet = true;
            }
        }

        /// <summary>
        /// <para>List of cluster-wide finalized features. The information is valid only if FinalizedFeaturesEpoch >= 0.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public ApiVersionsResponse WithFinalizedFeaturesCollection(params Func<FinalizedFeatureKey, FinalizedFeatureKey>[] createFields)
        {
            FinalizedFeaturesCollection = createFields.Select(createField => createField(new FinalizedFeatureKey(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate FinalizedFeatureKey CreateFinalizedFeatureKey(FinalizedFeatureKey field);
        /// <summary>
        /// <para>List of cluster-wide finalized features. The information is valid only if FinalizedFeaturesEpoch >= 0.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public ApiVersionsResponse WithFinalizedFeaturesCollection(IEnumerable<CreateFinalizedFeatureKey> createFields)
        {
            FinalizedFeaturesCollection = createFields.Select(createField => createField(new FinalizedFeatureKey(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class FinalizedFeatureKey : ISerialize
        {
            internal FinalizedFeatureKey(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 3 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _maxVersionLevel.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _minVersionLevel.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<FinalizedFeatureKey> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new FinalizedFeatureKey(version);
                if (instance.Version >= 3)
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.MaxVersionLevel = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.MinVersionLevel = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for FinalizedFeatureKey is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 3)
                    await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _maxVersionLevel.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _minVersionLevel.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The name of the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public String Name
            {
                get => _name;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The name of the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public FinalizedFeatureKey WithName(String name)
            {
                Name = name;
                return this;
            }

            private Int16 _maxVersionLevel = Int16.Default;
            /// <summary>
            /// <para>The cluster-wide finalized max version level for the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public Int16 MaxVersionLevel
            {
                get => _maxVersionLevel;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"MaxVersionLevel does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _maxVersionLevel = value;
                }
            }

            /// <summary>
            /// <para>The cluster-wide finalized max version level for the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public FinalizedFeatureKey WithMaxVersionLevel(Int16 maxVersionLevel)
            {
                MaxVersionLevel = maxVersionLevel;
                return this;
            }

            private Int16 _minVersionLevel = Int16.Default;
            /// <summary>
            /// <para>The cluster-wide finalized min version level for the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public Int16 MinVersionLevel
            {
                get => _minVersionLevel;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"MinVersionLevel does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _minVersionLevel = value;
                }
            }

            /// <summary>
            /// <para>The cluster-wide finalized min version level for the feature.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public FinalizedFeatureKey WithMinVersionLevel(Int16 minVersionLevel)
            {
                MinVersionLevel = minVersionLevel;
                return this;
            }
        }

        private bool _zkMigrationReadyIsSet;
        private Boolean _zkMigrationReady = new Boolean(false);
        /// <summary>
        /// <para>Set by a KRaft controller if the required configurations for ZK migration are present.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean ZkMigrationReady
        {
            get => _zkMigrationReady;
            private set
            {
                _zkMigrationReady = value;
                _zkMigrationReadyIsSet = true;
            }
        }

        /// <summary>
        /// <para>Set by a KRaft controller if the required configurations for ZK migration are present.</para>
        /// <para>Versions: 3+</para>
        /// <para>Default: false</para>
        /// </summary>
        public ApiVersionsResponse WithZkMigrationReady(Boolean zkMigrationReady)
        {
            ZkMigrationReady = zkMigrationReady;
            return this;
        }
    }
}
