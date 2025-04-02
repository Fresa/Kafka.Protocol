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
    public class DescribeDelegationTokenResponse : Message
    {
        public DescribeDelegationTokenResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeDelegationTokenResponse does not support version {version}. Valid versions are: 1-3");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(41);
        public static readonly Int16 MinVersion = Int16.From(1);
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

        internal override int GetSize() => _errorCode.GetSize(IsFlexibleVersion) + _tokensCollection.GetSize(IsFlexibleVersion) + _throttleTimeMs.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeDelegationTokenResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeDelegationTokenResponse(version);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TokensCollection = await Array<DescribedDelegationToken>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribedDelegationToken.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeDelegationTokenResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _tokensCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The error code, or 0 if there was no error.</para>
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
        /// <para>The error code, or 0 if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeDelegationTokenResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<DescribedDelegationToken> _tokensCollection = Array.Empty<DescribedDelegationToken>();
        /// <summary>
        /// <para>The tokens.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DescribedDelegationToken> TokensCollection
        {
            get => _tokensCollection;
            private set
            {
                _tokensCollection = value;
            }
        }

        /// <summary>
        /// <para>The tokens.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeDelegationTokenResponse WithTokensCollection(params Func<DescribedDelegationToken, DescribedDelegationToken>[] createFields)
        {
            TokensCollection = createFields.Select(createField => createField(new DescribedDelegationToken(Version))).ToArray();
            return this;
        }

        public delegate DescribedDelegationToken CreateDescribedDelegationToken(DescribedDelegationToken field);
        /// <summary>
        /// <para>The tokens.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeDelegationTokenResponse WithTokensCollection(IEnumerable<CreateDescribedDelegationToken> createFields)
        {
            TokensCollection = createFields.Select(createField => createField(new DescribedDelegationToken(Version))).ToArray();
            return this;
        }

        public class DescribedDelegationToken : ISerialize
        {
            internal DescribedDelegationToken(Int16 version)
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
            internal int GetSize(bool _) => _principalType.GetSize(IsFlexibleVersion) + _principalName.GetSize(IsFlexibleVersion) + (Version >= 3 ? _tokenRequesterPrincipalType.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _tokenRequesterPrincipalName.GetSize(IsFlexibleVersion) : 0) + _issueTimestamp.GetSize(IsFlexibleVersion) + _expiryTimestamp.GetSize(IsFlexibleVersion) + _maxTimestamp.GetSize(IsFlexibleVersion) + _tokenId.GetSize(IsFlexibleVersion) + _hmac.GetSize(IsFlexibleVersion) + _renewersCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribedDelegationToken> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribedDelegationToken(version);
                instance.PrincipalType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.PrincipalName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.TokenRequesterPrincipalType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 3)
                    instance.TokenRequesterPrincipalName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.IssueTimestamp = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ExpiryTimestamp = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.MaxTimestamp = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TokenId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Hmac = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.RenewersCollection = await Array<DescribedDelegationTokenRenewer>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribedDelegationTokenRenewer.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribedDelegationToken is unknown");
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
                if (Version >= 3)
                    await _tokenRequesterPrincipalType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 3)
                    await _tokenRequesterPrincipalName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _issueTimestamp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _expiryTimestamp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _maxTimestamp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _tokenId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _hmac.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _renewersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _principalType = String.Default;
            /// <summary>
            /// <para>The token principal type.</para>
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
            /// <para>The token principal type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedDelegationToken WithPrincipalType(String principalType)
            {
                PrincipalType = principalType;
                return this;
            }

            private String _principalName = String.Default;
            /// <summary>
            /// <para>The token principal name.</para>
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
            /// <para>The token principal name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedDelegationToken WithPrincipalName(String principalName)
            {
                PrincipalName = principalName;
                return this;
            }

            private String _tokenRequesterPrincipalType = String.Default;
            /// <summary>
            /// <para>The principal type of the requester of the token.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public String TokenRequesterPrincipalType
            {
                get => _tokenRequesterPrincipalType;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"TokenRequesterPrincipalType does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _tokenRequesterPrincipalType = value;
                }
            }

            /// <summary>
            /// <para>The principal type of the requester of the token.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public DescribedDelegationToken WithTokenRequesterPrincipalType(String tokenRequesterPrincipalType)
            {
                TokenRequesterPrincipalType = tokenRequesterPrincipalType;
                return this;
            }

            private String _tokenRequesterPrincipalName = String.Default;
            /// <summary>
            /// <para>The principal type of the requester of the token.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public String TokenRequesterPrincipalName
            {
                get => _tokenRequesterPrincipalName;
                private set
                {
                    if (Version >= 3 == false)
                        throw new UnsupportedVersionException($"TokenRequesterPrincipalName does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
                    _tokenRequesterPrincipalName = value;
                }
            }

            /// <summary>
            /// <para>The principal type of the requester of the token.</para>
            /// <para>Versions: 3+</para>
            /// </summary>
            public DescribedDelegationToken WithTokenRequesterPrincipalName(String tokenRequesterPrincipalName)
            {
                TokenRequesterPrincipalName = tokenRequesterPrincipalName;
                return this;
            }

            private Int64 _issueTimestamp = Int64.Default;
            /// <summary>
            /// <para>The token issue timestamp in milliseconds.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int64 IssueTimestamp
            {
                get => _issueTimestamp;
                private set
                {
                    _issueTimestamp = value;
                }
            }

            /// <summary>
            /// <para>The token issue timestamp in milliseconds.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedDelegationToken WithIssueTimestamp(Int64 issueTimestamp)
            {
                IssueTimestamp = issueTimestamp;
                return this;
            }

            private Int64 _expiryTimestamp = Int64.Default;
            /// <summary>
            /// <para>The token expiry timestamp in milliseconds.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int64 ExpiryTimestamp
            {
                get => _expiryTimestamp;
                private set
                {
                    _expiryTimestamp = value;
                }
            }

            /// <summary>
            /// <para>The token expiry timestamp in milliseconds.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedDelegationToken WithExpiryTimestamp(Int64 expiryTimestamp)
            {
                ExpiryTimestamp = expiryTimestamp;
                return this;
            }

            private Int64 _maxTimestamp = Int64.Default;
            /// <summary>
            /// <para>The token maximum timestamp length in milliseconds.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int64 MaxTimestamp
            {
                get => _maxTimestamp;
                private set
                {
                    _maxTimestamp = value;
                }
            }

            /// <summary>
            /// <para>The token maximum timestamp length in milliseconds.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedDelegationToken WithMaxTimestamp(Int64 maxTimestamp)
            {
                MaxTimestamp = maxTimestamp;
                return this;
            }

            private String _tokenId = String.Default;
            /// <summary>
            /// <para>The token ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String TokenId
            {
                get => _tokenId;
                private set
                {
                    _tokenId = value;
                }
            }

            /// <summary>
            /// <para>The token ID.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedDelegationToken WithTokenId(String tokenId)
            {
                TokenId = tokenId;
                return this;
            }

            private Bytes _hmac = Bytes.Default;
            /// <summary>
            /// <para>The token HMAC.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Bytes Hmac
            {
                get => _hmac;
                private set
                {
                    _hmac = value;
                }
            }

            /// <summary>
            /// <para>The token HMAC.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedDelegationToken WithHmac(Bytes hmac)
            {
                Hmac = hmac;
                return this;
            }

            private Array<DescribedDelegationTokenRenewer> _renewersCollection = Array.Empty<DescribedDelegationTokenRenewer>();
            /// <summary>
            /// <para>Those who are able to renew this token before it expires.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<DescribedDelegationTokenRenewer> RenewersCollection
            {
                get => _renewersCollection;
                private set
                {
                    _renewersCollection = value;
                }
            }

            /// <summary>
            /// <para>Those who are able to renew this token before it expires.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedDelegationToken WithRenewersCollection(params Func<DescribedDelegationTokenRenewer, DescribedDelegationTokenRenewer>[] createFields)
            {
                RenewersCollection = createFields.Select(createField => createField(new DescribedDelegationTokenRenewer(Version))).ToArray();
                return this;
            }

            public delegate DescribedDelegationTokenRenewer CreateDescribedDelegationTokenRenewer(DescribedDelegationTokenRenewer field);
            /// <summary>
            /// <para>Those who are able to renew this token before it expires.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribedDelegationToken WithRenewersCollection(IEnumerable<CreateDescribedDelegationTokenRenewer> createFields)
            {
                RenewersCollection = createFields.Select(createField => createField(new DescribedDelegationTokenRenewer(Version))).ToArray();
                return this;
            }

            public class DescribedDelegationTokenRenewer : ISerialize
            {
                internal DescribedDelegationTokenRenewer(Int16 version)
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
                internal static async ValueTask<DescribedDelegationTokenRenewer> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new DescribedDelegationTokenRenewer(version);
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
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribedDelegationTokenRenewer is unknown");
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
                /// <para>The renewer principal type.</para>
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
                /// <para>The renewer principal type.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribedDelegationTokenRenewer WithPrincipalType(String principalType)
                {
                    PrincipalType = principalType;
                    return this;
                }

                private String _principalName = String.Default;
                /// <summary>
                /// <para>The renewer principal name.</para>
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
                /// <para>The renewer principal name.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public DescribedDelegationTokenRenewer WithPrincipalName(String principalName)
                {
                    PrincipalName = principalName;
                    return this;
                }
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
        public DescribeDelegationTokenResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }
    }
}
