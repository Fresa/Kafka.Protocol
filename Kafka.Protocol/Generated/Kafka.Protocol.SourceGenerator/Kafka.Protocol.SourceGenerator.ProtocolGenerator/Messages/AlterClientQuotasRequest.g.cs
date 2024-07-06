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
    public class AlterClientQuotasRequest : Message, IRespond<AlterClientQuotasResponse>
    {
        public AlterClientQuotasRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AlterClientQuotasRequest does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = version >= 1;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(49);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(1);
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

        internal override int GetSize() => _entriesCollection.GetSize(IsFlexibleVersion) + _validateOnly.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AlterClientQuotasRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AlterClientQuotasRequest(version);
            instance.EntriesCollection = await Array<EntryData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => EntryData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ValidateOnly = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterClientQuotasRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _entriesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _validateOnly.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<EntryData> _entriesCollection = Array.Empty<EntryData>();
        /// <summary>
        /// <para>The quota configuration entries to alter.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<EntryData> EntriesCollection
        {
            get => _entriesCollection;
            private set
            {
                _entriesCollection = value;
            }
        }

        /// <summary>
        /// <para>The quota configuration entries to alter.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterClientQuotasRequest WithEntriesCollection(params Func<EntryData, EntryData>[] createFields)
        {
            EntriesCollection = createFields.Select(createField => createField(new EntryData(Version))).ToArray();
            return this;
        }

        public delegate EntryData CreateEntryData(EntryData field);
        /// <summary>
        /// <para>The quota configuration entries to alter.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterClientQuotasRequest WithEntriesCollection(IEnumerable<CreateEntryData> createFields)
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
            internal int GetSize(bool _) => _entityCollection.GetSize(IsFlexibleVersion) + _opsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<EntryData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new EntryData(version);
                instance.EntityCollection = await Array<EntityData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => EntityData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                instance.OpsCollection = await Array<OpData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => OpData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
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
                await _opsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Array<EntityData> _entityCollection = Array.Empty<EntityData>();
            /// <summary>
            /// <para>The quota entity to alter.</para>
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
            /// <para>The quota entity to alter.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public EntryData WithEntityCollection(params Func<EntityData, EntityData>[] createFields)
            {
                EntityCollection = createFields.Select(createField => createField(new EntityData(Version))).ToArray();
                return this;
            }

            public delegate EntityData CreateEntityData(EntityData field);
            /// <summary>
            /// <para>The quota entity to alter.</para>
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
                /// <para>The name of the entity, or null if the default.</para>
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
                /// <para>The name of the entity, or null if the default.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public EntityData WithEntityName(String? entityName)
                {
                    EntityName = entityName;
                    return this;
                }
            }

            private Array<OpData> _opsCollection = Array.Empty<OpData>();
            /// <summary>
            /// <para>An individual quota configuration entry to alter.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<OpData> OpsCollection
            {
                get => _opsCollection;
                private set
                {
                    _opsCollection = value;
                }
            }

            /// <summary>
            /// <para>An individual quota configuration entry to alter.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public EntryData WithOpsCollection(params Func<OpData, OpData>[] createFields)
            {
                OpsCollection = createFields.Select(createField => createField(new OpData(Version))).ToArray();
                return this;
            }

            public delegate OpData CreateOpData(OpData field);
            /// <summary>
            /// <para>An individual quota configuration entry to alter.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public EntryData WithOpsCollection(IEnumerable<CreateOpData> createFields)
            {
                OpsCollection = createFields.Select(createField => createField(new OpData(Version))).ToArray();
                return this;
            }

            public class OpData : ISerialize
            {
                internal OpData(Int16 version)
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
                internal int GetSize(bool _) => _key.GetSize(IsFlexibleVersion) + _value.GetSize(IsFlexibleVersion) + _remove.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<OpData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new OpData(version);
                    instance.Key = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Value = await Float64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Remove = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for OpData is unknown");
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
                    await _remove.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public OpData WithKey(String key)
                {
                    Key = key;
                    return this;
                }

                private Float64 _value = Float64.Default;
                /// <summary>
                /// <para>The value to set, otherwise ignored if the value is to be removed.</para>
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
                /// <para>The value to set, otherwise ignored if the value is to be removed.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public OpData WithValue(Float64 value)
                {
                    Value = value;
                    return this;
                }

                private Boolean _remove = Boolean.Default;
                /// <summary>
                /// <para>Whether the quota configuration value should be removed, otherwise set.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Boolean Remove
                {
                    get => _remove;
                    private set
                    {
                        _remove = value;
                    }
                }

                /// <summary>
                /// <para>Whether the quota configuration value should be removed, otherwise set.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public OpData WithRemove(Boolean remove)
                {
                    Remove = remove;
                    return this;
                }
            }
        }

        private Boolean _validateOnly = Boolean.Default;
        /// <summary>
        /// <para>Whether the alteration should be validated, but not performed.</para>
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
        /// <para>Whether the alteration should be validated, but not performed.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterClientQuotasRequest WithValidateOnly(Boolean validateOnly)
        {
            ValidateOnly = validateOnly;
            return this;
        }

        public AlterClientQuotasResponse Respond() => new AlterClientQuotasResponse(Version);
    }
}
