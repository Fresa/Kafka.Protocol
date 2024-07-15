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
    public class DescribeDelegationTokenRequest : Message, IRespond<DescribeDelegationTokenResponse>
    {
        public DescribeDelegationTokenRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeDelegationTokenRequest does not support version {version}. Valid versions are: 0-3");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(41);
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

        internal override int GetSize() => _ownersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeDelegationTokenRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeDelegationTokenRequest(version);
            instance.OwnersCollection = await NullableArray<DescribeDelegationTokenOwner>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeDelegationTokenOwner.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeDelegationTokenRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _ownersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private NullableArray<DescribeDelegationTokenOwner> _ownersCollection = Array.Empty<DescribeDelegationTokenOwner>();
        /// <summary>
        /// <para>Each owner that we want to describe delegation tokens for, or null to describe all tokens.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DescribeDelegationTokenOwner>? OwnersCollection
        {
            get => _ownersCollection;
            private set
            {
                _ownersCollection = value;
            }
        }

        /// <summary>
        /// <para>Each owner that we want to describe delegation tokens for, or null to describe all tokens.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeDelegationTokenRequest WithOwnersCollection(params Func<DescribeDelegationTokenOwner, DescribeDelegationTokenOwner>[] createFields)
        {
            OwnersCollection = createFields.Select(createField => createField(new DescribeDelegationTokenOwner(Version))).ToArray();
            return this;
        }

        public delegate DescribeDelegationTokenOwner CreateDescribeDelegationTokenOwner(DescribeDelegationTokenOwner field);
        /// <summary>
        /// <para>Each owner that we want to describe delegation tokens for, or null to describe all tokens.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeDelegationTokenRequest WithOwnersCollection(IEnumerable<CreateDescribeDelegationTokenOwner> createFields)
        {
            OwnersCollection = createFields.Select(createField => createField(new DescribeDelegationTokenOwner(Version))).ToArray();
            return this;
        }

        public class DescribeDelegationTokenOwner : ISerialize
        {
            internal DescribeDelegationTokenOwner(Int16 version)
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
            internal int GetSize(bool _) => _principalType.GetSize(IsFlexibleVersion) + _principalName.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribeDelegationTokenOwner> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribeDelegationTokenOwner(version);
                instance.PrincipalType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PrincipalName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeDelegationTokenOwner is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _principalType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _principalName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _principalType = String.Default;
            /// <summary>
            /// <para>The owner principal type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String PrincipalType
            {
                get => _principalType;
                private set
                {
                    _principalType = value;
                }
            }

            /// <summary>
            /// <para>The owner principal type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeDelegationTokenOwner WithPrincipalType(String principalType)
            {
                PrincipalType = principalType;
                return this;
            }

            private String _principalName = String.Default;
            /// <summary>
            /// <para>The owner principal name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String PrincipalName
            {
                get => _principalName;
                private set
                {
                    _principalName = value;
                }
            }

            /// <summary>
            /// <para>The owner principal name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeDelegationTokenOwner WithPrincipalName(String principalName)
            {
                PrincipalName = principalName;
                return this;
            }
        }

        public DescribeDelegationTokenResponse Respond() => new DescribeDelegationTokenResponse(Version);
    }
}
