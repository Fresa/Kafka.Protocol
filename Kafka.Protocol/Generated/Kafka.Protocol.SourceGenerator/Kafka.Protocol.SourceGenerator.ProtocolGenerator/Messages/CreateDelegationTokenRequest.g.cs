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
    public class CreateDelegationTokenRequest : Message, IRespond<CreateDelegationTokenResponse>
    {
        public CreateDelegationTokenRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"CreateDelegationTokenRequest does not support version {version}. Valid versions are: 0-3");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(38);
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

        internal override int GetSize() => (Version >= 3 ? _ownerPrincipalType.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _ownerPrincipalName.GetSize(IsFlexibleVersion) : 0) + _renewersCollection.GetSize(IsFlexibleVersion) + _maxLifetimeMs.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<CreateDelegationTokenRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new CreateDelegationTokenRequest(version);
            if (instance.Version >= 3)
                instance.OwnerPrincipalType = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.OwnerPrincipalName = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.RenewersCollection = await Array<CreatableRenewers>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => CreatableRenewers.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.MaxLifetimeMs = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for CreateDelegationTokenRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 3)
                await _ownerPrincipalType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _ownerPrincipalName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _renewersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _maxLifetimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private NullableString _ownerPrincipalType = NullableString.Default;
        /// <summary>
        /// <para>The principal type of the owner of the token. If it's null it defaults to the token request principal.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public String? OwnerPrincipalType
        {
            get => _ownerPrincipalType;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"OwnerPrincipalType does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                if (Version >= 3 == false && value == null)
                    throw new UnsupportedVersionException($"OwnerPrincipalType does not support null for version {Version}. Supported versions for null value: 3+");
                _ownerPrincipalType = value;
            }
        }

        /// <summary>
        /// <para>The principal type of the owner of the token. If it's null it defaults to the token request principal.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public CreateDelegationTokenRequest WithOwnerPrincipalType(String? ownerPrincipalType)
        {
            OwnerPrincipalType = ownerPrincipalType;
            return this;
        }

        private NullableString _ownerPrincipalName = NullableString.Default;
        /// <summary>
        /// <para>The principal name of the owner of the token. If it's null it defaults to the token request principal.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public String? OwnerPrincipalName
        {
            get => _ownerPrincipalName;
            private set
            {
                if (Version >= 3 == false)
                    throw new UnsupportedVersionException($"OwnerPrincipalName does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                if (Version >= 3 == false && value == null)
                    throw new UnsupportedVersionException($"OwnerPrincipalName does not support null for version {Version}. Supported versions for null value: 3+");
                _ownerPrincipalName = value;
            }
        }

        /// <summary>
        /// <para>The principal name of the owner of the token. If it's null it defaults to the token request principal.</para>
        /// <para>Versions: 3+</para>
        /// </summary>
        public CreateDelegationTokenRequest WithOwnerPrincipalName(String? ownerPrincipalName)
        {
            OwnerPrincipalName = ownerPrincipalName;
            return this;
        }

        private Array<CreatableRenewers> _renewersCollection = Array.Empty<CreatableRenewers>();
        /// <summary>
        /// <para>A list of those who are allowed to renew this token before it expires.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<CreatableRenewers> RenewersCollection
        {
            get => _renewersCollection;
            private set
            {
                _renewersCollection = value;
            }
        }

        /// <summary>
        /// <para>A list of those who are allowed to renew this token before it expires.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenRequest WithRenewersCollection(params Func<CreatableRenewers, CreatableRenewers>[] createFields)
        {
            RenewersCollection = createFields.Select(createField => createField(new CreatableRenewers(Version))).ToArray();
            return this;
        }

        public delegate CreatableRenewers CreateCreatableRenewers(CreatableRenewers field);
        /// <summary>
        /// <para>A list of those who are allowed to renew this token before it expires.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenRequest WithRenewersCollection(IEnumerable<CreateCreatableRenewers> createFields)
        {
            RenewersCollection = createFields.Select(createField => createField(new CreatableRenewers(Version))).ToArray();
            return this;
        }

        public class CreatableRenewers : ISerialize
        {
            internal CreatableRenewers(Int16 version)
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
            internal static async ValueTask<CreatableRenewers> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new CreatableRenewers(version);
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
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for CreatableRenewers is unknown");
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
            /// <para>The type of the Kafka principal.</para>
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
            /// <para>The type of the Kafka principal.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatableRenewers WithPrincipalType(String principalType)
            {
                PrincipalType = principalType;
                return this;
            }

            private String _principalName = String.Default;
            /// <summary>
            /// <para>The name of the Kafka principal.</para>
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
            /// <para>The name of the Kafka principal.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatableRenewers WithPrincipalName(String principalName)
            {
                PrincipalName = principalName;
                return this;
            }
        }

        private Int64 _maxLifetimeMs = Int64.Default;
        /// <summary>
        /// <para>The maximum lifetime of the token in milliseconds, or -1 to use the server side default.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 MaxLifetimeMs
        {
            get => _maxLifetimeMs;
            private set
            {
                _maxLifetimeMs = value;
            }
        }

        /// <summary>
        /// <para>The maximum lifetime of the token in milliseconds, or -1 to use the server side default.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenRequest WithMaxLifetimeMs(Int64 maxLifetimeMs)
        {
            MaxLifetimeMs = maxLifetimeMs;
            return this;
        }

        public CreateDelegationTokenResponse Respond() => new CreateDelegationTokenResponse(Version);
    }
}
