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
    public class DescribeClientQuotasRequest : Message, IRespond<DescribeClientQuotasResponse>
    {
        public DescribeClientQuotasRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeClientQuotasRequest does not support version {version}. Valid versions are: 0-1");
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
                return (short)(IsFlexibleVersion ? 2 : 1);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _componentsCollection.GetSize(IsFlexibleVersion) + _strict.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeClientQuotasRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeClientQuotasRequest(version);
            instance.ComponentsCollection = await Array<ComponentData>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ComponentData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.Strict = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeClientQuotasRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _componentsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _strict.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<ComponentData> _componentsCollection = Array.Empty<ComponentData>();
        /// <summary>
        /// <para>Filter components to apply to quota entities.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ComponentData> ComponentsCollection
        {
            get => _componentsCollection;
            private set
            {
                _componentsCollection = value;
            }
        }

        /// <summary>
        /// <para>Filter components to apply to quota entities.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClientQuotasRequest WithComponentsCollection(params Func<ComponentData, ComponentData>[] createFields)
        {
            ComponentsCollection = createFields.Select(createField => createField(new ComponentData(Version))).ToArray();
            return this;
        }

        public delegate ComponentData CreateComponentData(ComponentData field);
        /// <summary>
        /// <para>Filter components to apply to quota entities.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClientQuotasRequest WithComponentsCollection(IEnumerable<CreateComponentData> createFields)
        {
            ComponentsCollection = createFields.Select(createField => createField(new ComponentData(Version))).ToArray();
            return this;
        }

        public class ComponentData : ISerialize
        {
            internal ComponentData(Int16 version)
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
            internal int GetSize(bool _) => _entityType.GetSize(IsFlexibleVersion) + _matchType.GetSize(IsFlexibleVersion) + _match.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ComponentData> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ComponentData(version);
                instance.EntityType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.MatchType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Match = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ComponentData is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _entityType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _matchType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _match.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _entityType = String.Default;
            /// <summary>
            /// <para>The entity type that the filter component applies to.</para>
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
            /// <para>The entity type that the filter component applies to.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ComponentData WithEntityType(String entityType)
            {
                EntityType = entityType;
                return this;
            }

            private Int8 _matchType = Int8.Default;
            /// <summary>
            /// <para>How to match the entity {0 = exact name, 1 = default name, 2 = any specified name}.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int8 MatchType
            {
                get => _matchType;
                private set
                {
                    _matchType = value;
                }
            }

            /// <summary>
            /// <para>How to match the entity {0 = exact name, 1 = default name, 2 = any specified name}.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ComponentData WithMatchType(Int8 matchType)
            {
                MatchType = matchType;
                return this;
            }

            private NullableString _match = NullableString.Default;
            /// <summary>
            /// <para>The string to match against, or null if unused for the match type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String? Match
            {
                get => _match;
                private set
                {
                    _match = value;
                }
            }

            /// <summary>
            /// <para>The string to match against, or null if unused for the match type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ComponentData WithMatch(String? match)
            {
                Match = match;
                return this;
            }
        }

        private Boolean _strict = Boolean.Default;
        /// <summary>
        /// <para>Whether the match is strict, i.e. should exclude entities with unspecified entity types.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean Strict
        {
            get => _strict;
            private set
            {
                _strict = value;
            }
        }

        /// <summary>
        /// <para>Whether the match is strict, i.e. should exclude entities with unspecified entity types.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClientQuotasRequest WithStrict(Boolean strict)
        {
            Strict = strict;
            return this;
        }

        public DescribeClientQuotasResponse Respond() => new DescribeClientQuotasResponse(Version);
    }
}
