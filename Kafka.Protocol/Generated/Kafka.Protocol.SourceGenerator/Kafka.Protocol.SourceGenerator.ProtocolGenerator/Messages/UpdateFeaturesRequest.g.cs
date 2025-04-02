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
    public class UpdateFeaturesRequest : Message, IRespond<UpdateFeaturesResponse>
    {
        public UpdateFeaturesRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"UpdateFeaturesRequest does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(57);
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

        internal override int GetSize() => _timeoutMs.GetSize(IsFlexibleVersion) + _featureUpdatesCollection.GetSize(IsFlexibleVersion) + (Version >= 1 ? _validateOnly.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<UpdateFeaturesRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new UpdateFeaturesRequest(version);
            instance.TimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.FeatureUpdatesCollection = await Map<String, FeatureUpdateKey>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => FeatureUpdateKey.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Feature, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.ValidateOnly = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for UpdateFeaturesRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _timeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _featureUpdatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _validateOnly.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _timeoutMs = new Int32(60000);
        /// <summary>
        /// <para>How long to wait in milliseconds before timing out the request.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 60000</para>
        /// </summary>
        public Int32 TimeoutMs
        {
            get => _timeoutMs;
            private set
            {
                _timeoutMs = value;
            }
        }

        /// <summary>
        /// <para>How long to wait in milliseconds before timing out the request.</para>
        /// <para>Versions: 0+</para>
        /// <para>Default: 60000</para>
        /// </summary>
        public UpdateFeaturesRequest WithTimeoutMs(Int32 timeoutMs)
        {
            TimeoutMs = timeoutMs;
            return this;
        }

        private Map<String, FeatureUpdateKey> _featureUpdatesCollection = Map<String, FeatureUpdateKey>.Default;
        /// <summary>
        /// <para>The list of updates to finalized features.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, FeatureUpdateKey> FeatureUpdatesCollection
        {
            get => _featureUpdatesCollection;
            private set
            {
                _featureUpdatesCollection = value;
            }
        }

        /// <summary>
        /// <para>The list of updates to finalized features.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateFeaturesRequest WithFeatureUpdatesCollection(params Func<FeatureUpdateKey, FeatureUpdateKey>[] createFields)
        {
            FeatureUpdatesCollection = createFields.Select(createField => createField(new FeatureUpdateKey(Version))).ToDictionary(field => field.Feature);
            return this;
        }

        public delegate FeatureUpdateKey CreateFeatureUpdateKey(FeatureUpdateKey field);
        /// <summary>
        /// <para>The list of updates to finalized features.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public UpdateFeaturesRequest WithFeatureUpdatesCollection(IEnumerable<CreateFeatureUpdateKey> createFields)
        {
            FeatureUpdatesCollection = createFields.Select(createField => createField(new FeatureUpdateKey(Version))).ToDictionary(field => field.Feature);
            return this;
        }

        public class FeatureUpdateKey : ISerialize
        {
            internal FeatureUpdateKey(Int16 version)
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
            internal int GetSize(bool _) => _feature.GetSize(IsFlexibleVersion) + _maxVersionLevel.GetSize(IsFlexibleVersion) + (Version >= 0 && Version <= 0 ? _allowDowngrade.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _upgradeType.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<FeatureUpdateKey> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new FeatureUpdateKey(version);
                instance.Feature = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.MaxVersionLevel = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 0 && instance.Version <= 0)
                    instance.AllowDowngrade = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.UpgradeType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for FeatureUpdateKey is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _feature.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _maxVersionLevel.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 0 && Version <= 0)
                    await _allowDowngrade.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _upgradeType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _feature = String.Default;
            /// <summary>
            /// <para>The name of the finalized feature to be updated.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Feature
            {
                get => _feature;
                private set
                {
                    _feature = value;
                }
            }

            /// <summary>
            /// <para>The name of the finalized feature to be updated.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public FeatureUpdateKey WithFeature(String feature)
            {
                Feature = feature;
                return this;
            }

            private Int16 _maxVersionLevel = Int16.Default;
            /// <summary>
            /// <para>The new maximum version level for the finalized feature. A value >= 1 is valid. A value < 1 , is  special , and  can  be  used  to  request  the  deletion  of  the  finalized  feature.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int16 MaxVersionLevel
            {
                get => _maxVersionLevel;
                private set
                {
                    _maxVersionLevel = value;
                }
            }

            /// <summary>
            /// <para>The new maximum version level for the finalized feature. A value >= 1 is valid. A value < 1 , is  special , and  can  be  used  to  request  the  deletion  of  the  finalized  feature.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public FeatureUpdateKey WithMaxVersionLevel(Int16 maxVersionLevel)
            {
                MaxVersionLevel = maxVersionLevel;
                return this;
            }

            private Boolean _allowDowngrade = Boolean.Default;
            /// <summary>
            /// <para>DEPRECATED in version 1 (see DowngradeType). When set to true, the finalized feature version level is allowed to be downgraded/deleted. The downgrade request will fail if the new maximum version level is a value that's not lower than the existing maximum finalized version level.</para>
            /// <para>Versions: 0</para>
            /// </summary>
            public Boolean AllowDowngrade
            {
                get => _allowDowngrade;
                private set
                {
                    if (Version >= 0 && Version <= 0 == false)
                        throw new UnsupportedVersionException($"AllowDowngrade does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
                    _allowDowngrade = value;
                }
            }

            /// <summary>
            /// <para>DEPRECATED in version 1 (see DowngradeType). When set to true, the finalized feature version level is allowed to be downgraded/deleted. The downgrade request will fail if the new maximum version level is a value that's not lower than the existing maximum finalized version level.</para>
            /// <para>Versions: 0</para>
            /// </summary>
            public FeatureUpdateKey WithAllowDowngrade(Boolean allowDowngrade)
            {
                AllowDowngrade = allowDowngrade;
                return this;
            }

            private Int8 _upgradeType = new Int8(1);
            /// <summary>
            /// <para>Determine which type of upgrade will be performed: 1 will perform an upgrade only (default), 2 is safe downgrades only (lossless), 3 is unsafe downgrades (lossy).</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: 1</para>
            /// </summary>
            public Int8 UpgradeType
            {
                get => _upgradeType;
                private set
                {
                    if (Version >= 1 == false)
                        throw new UnsupportedVersionException($"UpgradeType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                    _upgradeType = value;
                }
            }

            /// <summary>
            /// <para>Determine which type of upgrade will be performed: 1 will perform an upgrade only (default), 2 is safe downgrades only (lossless), 3 is unsafe downgrades (lossy).</para>
            /// <para>Versions: 1+</para>
            /// <para>Default: 1</para>
            /// </summary>
            public FeatureUpdateKey WithUpgradeType(Int8 upgradeType)
            {
                UpgradeType = upgradeType;
                return this;
            }
        }

        private Boolean _validateOnly = new Boolean(false);
        /// <summary>
        /// <para>True if we should validate the request, but not perform the upgrade or downgrade.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: false</para>
        /// </summary>
        public Boolean ValidateOnly
        {
            get => _validateOnly;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"ValidateOnly does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _validateOnly = value;
            }
        }

        /// <summary>
        /// <para>True if we should validate the request, but not perform the upgrade or downgrade.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: false</para>
        /// </summary>
        public UpdateFeaturesRequest WithValidateOnly(Boolean validateOnly)
        {
            ValidateOnly = validateOnly;
            return this;
        }

        public UpdateFeaturesResponse Respond() => new UpdateFeaturesResponse(Version);
    }
}
