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
    public class DescribeClientQuotasResponse : Message
    {
        public DescribeClientQuotasResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeClientQuotasResponse does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = version >= 1;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(48);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _entriesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeClientQuotasResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeClientQuotasResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.EntriesCollection = await NullableArray<EntryData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => EntryData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeClientQuotasResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _entriesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
        public DescribeClientQuotasResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The error code, or `0` if the quota description succeeded.</para>
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
        /// <para>The error code, or `0` if the quota description succeeded.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClientQuotasResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private NullableString _errorMessage = NullableString.Default;
        /// <summary>
        /// <para>The error message, or `null` if the quota description succeeded.</para>
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
        /// <para>The error message, or `null` if the quota description succeeded.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClientQuotasResponse WithErrorMessage(String? errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        private NullableArray<EntryData> _entriesCollection = Array.Empty<EntryData>();
        /// <summary>
        /// <para>A result entry.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<EntryData>? EntriesCollection
        {
            get => _entriesCollection;
            private set
            {
                _entriesCollection = value;
            }
        }

        /// <summary>
        /// <para>A result entry.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClientQuotasResponse WithEntriesCollection(params Func<EntryData, EntryData>[] createFields)
        {
            EntriesCollection = createFields.Select(createField => createField(new EntryData(Version))).ToArray();
            return this;
        }

        public delegate EntryData CreateEntryData(EntryData field);
        /// <summary>
        /// <para>A result entry.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClientQuotasResponse WithEntriesCollection(IEnumerable<CreateEntryData> createFields)
        {
            EntriesCollection = createFields.Select(createField => createField(new EntryData(Version))).ToArray();
            return this;
        }

        public class EntryData : ISerialize
        {
            internal EntryData(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 1;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _entityCollection.GetSize(IsFlexibleVersion) + _valuesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<EntryData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new EntryData(version);
                instance.EntityCollection = await Array<EntityData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => EntityData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.ValuesCollection = await Array<ValueData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ValueData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for EntryData is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _entityCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _valuesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Array<EntityData> _entityCollection = Array.Empty<EntityData>();
            /// <summary>
            /// <para>The quota entity description.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<EntityData> EntityCollection
            {
                get => _entityCollection;
                private set
                {
                    _entityCollection = value;
                }
            }

            /// <summary>
            /// <para>The quota entity description.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public EntryData WithEntityCollection(params Func<EntityData, EntityData>[] createFields)
            {
                EntityCollection = createFields.Select(createField => createField(new EntityData(Version))).ToArray();
                return this;
            }

            public delegate EntityData CreateEntityData(EntityData field);
            /// <summary>
            /// <para>The quota entity description.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public EntryData WithEntityCollection(IEnumerable<CreateEntityData> createFields)
            {
                EntityCollection = createFields.Select(createField => createField(new EntityData(Version))).ToArray();
                return this;
            }

            public class EntityData : ISerialize
            {
                internal EntityData(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 1;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _entityType.GetSize(IsFlexibleVersion) + _entityName.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<EntityData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new EntityData(version);
                    instance.EntityType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.EntityName = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for EntityData is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _entityType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _entityName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private String _entityType = String.Default;
                /// <summary>
                /// <para>The entity type.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public String EntityType
                {
                    get => _entityType;
                    private set
                    {
                        _entityType = value;
                    }
                }

                /// <summary>
                /// <para>The entity type.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public EntityData WithEntityType(String entityType)
                {
                    EntityType = entityType;
                    return this;
                }

                private NullableString _entityName = NullableString.Default;
                /// <summary>
                /// <para>The entity name, or null if the default.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public String? EntityName
                {
                    get => _entityName;
                    private set
                    {
                        _entityName = value;
                    }
                }

                /// <summary>
                /// <para>The entity name, or null if the default.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public EntityData WithEntityName(String? entityName)
                {
                    EntityName = entityName;
                    return this;
                }
            }

            private Array<ValueData> _valuesCollection = Array.Empty<ValueData>();
            /// <summary>
            /// <para>The quota values for the entity.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<ValueData> ValuesCollection
            {
                get => _valuesCollection;
                private set
                {
                    _valuesCollection = value;
                }
            }

            /// <summary>
            /// <para>The quota values for the entity.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public EntryData WithValuesCollection(params Func<ValueData, ValueData>[] createFields)
            {
                ValuesCollection = createFields.Select(createField => createField(new ValueData(Version))).ToArray();
                return this;
            }

            public delegate ValueData CreateValueData(ValueData field);
            /// <summary>
            /// <para>The quota values for the entity.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public EntryData WithValuesCollection(IEnumerable<CreateValueData> createFields)
            {
                ValuesCollection = createFields.Select(createField => createField(new ValueData(Version))).ToArray();
                return this;
            }

            public class ValueData : ISerialize
            {
                internal ValueData(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 1;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => _key.GetSize(IsFlexibleVersion) + _value.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<ValueData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new ValueData(version);
                    instance.Key = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Value = await Float64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for ValueData is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _key.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _value.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private String _key = String.Default;
                /// <summary>
                /// <para>The quota configuration key.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public String Key
                {
                    get => _key;
                    private set
                    {
                        _key = value;
                    }
                }

                /// <summary>
                /// <para>The quota configuration key.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public ValueData WithKey(String key)
                {
                    Key = key;
                    return this;
                }

                private Float64 _value = Float64.Default;
                /// <summary>
                /// <para>The quota configuration value.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Float64 Value
                {
                    get => _value;
                    private set
                    {
                        _value = value;
                    }
                }

                /// <summary>
                /// <para>The quota configuration value.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public ValueData WithValue(Float64 value)
                {
                    Value = value;
                    return this;
                }
            }
        }
    }
}
