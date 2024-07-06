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
    public class CreateDelegationTokenResponse : Message
    {
        public CreateDelegationTokenResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"CreateDelegationTokenResponse does not support version {version}. Valid versions are: 0-3");
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
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _errorCode.GetSize(IsFlexibleVersion) + _principalType.GetSize(IsFlexibleVersion) + _principalName.GetSize(IsFlexibleVersion) + (Version >= 3 ? _tokenRequesterPrincipalType.GetSize(IsFlexibleVersion) : 0) + (Version >= 3 ? _tokenRequesterPrincipalName.GetSize(IsFlexibleVersion) : 0) + _issueTimestampMs.GetSize(IsFlexibleVersion) + _expiryTimestampMs.GetSize(IsFlexibleVersion) + _maxTimestampMs.GetSize(IsFlexibleVersion) + _tokenId.GetSize(IsFlexibleVersion) + _hmac.GetSize(IsFlexibleVersion) + _throttleTimeMs.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<CreateDelegationTokenResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new CreateDelegationTokenResponse(version);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.PrincipalType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.PrincipalName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.TokenRequesterPrincipalType = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 3)
                instance.TokenRequesterPrincipalName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.IssueTimestampMs = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ExpiryTimestampMs = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.MaxTimestampMs = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TokenId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.Hmac = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for CreateDelegationTokenResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _principalType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _principalName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _tokenRequesterPrincipalType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 3)
                await _tokenRequesterPrincipalName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _issueTimestampMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _expiryTimestampMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _maxTimestampMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _tokenId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _hmac.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The top-level error, or zero if there was no error.</para>
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
        /// <para>The top-level error, or zero if there was no error.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private String _principalType = String.Default;
        /// <summary>
        /// <para>The principal type of the token owner.</para>
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
        /// <para>The principal type of the token owner.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenResponse WithPrincipalType(String principalType)
        {
            PrincipalType = principalType;
            return this;
        }

        private String _principalName = String.Default;
        /// <summary>
        /// <para>The name of the token owner.</para>
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
        /// <para>The name of the token owner.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenResponse WithPrincipalName(String principalName)
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
        public CreateDelegationTokenResponse WithTokenRequesterPrincipalType(String tokenRequesterPrincipalType)
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
        public CreateDelegationTokenResponse WithTokenRequesterPrincipalName(String tokenRequesterPrincipalName)
        {
            TokenRequesterPrincipalName = tokenRequesterPrincipalName;
            return this;
        }

        private Int64 _issueTimestampMs = Int64.Default;
        /// <summary>
        /// <para>When this token was generated.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 IssueTimestampMs
        {
            get => _issueTimestampMs;
            private set
            {
                _issueTimestampMs = value;
            }
        }

        /// <summary>
        /// <para>When this token was generated.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenResponse WithIssueTimestampMs(Int64 issueTimestampMs)
        {
            IssueTimestampMs = issueTimestampMs;
            return this;
        }

        private Int64 _expiryTimestampMs = Int64.Default;
        /// <summary>
        /// <para>When this token expires.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 ExpiryTimestampMs
        {
            get => _expiryTimestampMs;
            private set
            {
                _expiryTimestampMs = value;
            }
        }

        /// <summary>
        /// <para>When this token expires.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenResponse WithExpiryTimestampMs(Int64 expiryTimestampMs)
        {
            ExpiryTimestampMs = expiryTimestampMs;
            return this;
        }

        private Int64 _maxTimestampMs = Int64.Default;
        /// <summary>
        /// <para>The maximum lifetime of this token.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 MaxTimestampMs
        {
            get => _maxTimestampMs;
            private set
            {
                _maxTimestampMs = value;
            }
        }

        /// <summary>
        /// <para>The maximum lifetime of this token.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenResponse WithMaxTimestampMs(Int64 maxTimestampMs)
        {
            MaxTimestampMs = maxTimestampMs;
            return this;
        }

        private String _tokenId = String.Default;
        /// <summary>
        /// <para>The token UUID.</para>
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
        /// <para>The token UUID.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenResponse WithTokenId(String tokenId)
        {
            TokenId = tokenId;
            return this;
        }

        private Bytes _hmac = Bytes.Default;
        /// <summary>
        /// <para>HMAC of the delegation token.</para>
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
        /// <para>HMAC of the delegation token.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateDelegationTokenResponse WithHmac(Bytes hmac)
        {
            Hmac = hmac;
            return this;
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
        public CreateDelegationTokenResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }
    }
}
