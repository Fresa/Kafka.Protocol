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
    public class DescribeUserScramCredentialsResponse : Message
    {
        public DescribeUserScramCredentialsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeUserScramCredentialsResponse does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(50);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _resultsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeUserScramCredentialsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeUserScramCredentialsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ResultsCollection = await Array<DescribeUserScramCredentialsResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => DescribeUserScramCredentialsResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeUserScramCredentialsResponse is unknown");
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
        public DescribeUserScramCredentialsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The message-level error code, 0 except for user authorization or infrastructure issues.</para>
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
        /// <para>The message-level error code, 0 except for user authorization or infrastructure issues.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeUserScramCredentialsResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private NullableString _errorMessage = NullableString.Default;
        /// <summary>
        /// <para>The message-level error message, if any.</para>
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
        /// <para>The message-level error message, if any.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeUserScramCredentialsResponse WithErrorMessage(String? errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        private Array<DescribeUserScramCredentialsResult> _resultsCollection = Array.Empty<DescribeUserScramCredentialsResult>();
        /// <summary>
        /// <para>The results for descriptions, one per user.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<DescribeUserScramCredentialsResult> ResultsCollection
        {
            get => _resultsCollection;
            private set
            {
                _resultsCollection = value;
            }
        }

        /// <summary>
        /// <para>The results for descriptions, one per user.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeUserScramCredentialsResponse WithResultsCollection(params Func<DescribeUserScramCredentialsResult, DescribeUserScramCredentialsResult>[] createFields)
        {
            ResultsCollection = createFields.Select(createField => createField(new DescribeUserScramCredentialsResult(Version))).ToArray();
            return this;
        }

        public delegate DescribeUserScramCredentialsResult CreateDescribeUserScramCredentialsResult(DescribeUserScramCredentialsResult field);
        /// <summary>
        /// <para>The results for descriptions, one per user.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeUserScramCredentialsResponse WithResultsCollection(IEnumerable<CreateDescribeUserScramCredentialsResult> createFields)
        {
            ResultsCollection = createFields.Select(createField => createField(new DescribeUserScramCredentialsResult(Version))).ToArray();
            return this;
        }

        public class DescribeUserScramCredentialsResult : ISerialize
        {
            internal DescribeUserScramCredentialsResult(Int16 version)
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
            internal int GetSize(bool _) => _user.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _credentialInfosCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<DescribeUserScramCredentialsResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new DescribeUserScramCredentialsResult(version);
                instance.User = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.CredentialInfosCollection = await Array<CredentialInfo>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => CredentialInfo.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeUserScramCredentialsResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _user.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _credentialInfosCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _user = String.Default;
            /// <summary>
            /// <para>The user name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String User
            {
                get => _user;
                private set
                {
                    _user = value;
                }
            }

            /// <summary>
            /// <para>The user name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeUserScramCredentialsResult WithUser(String user)
            {
                User = user;
                return this;
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The user-level error code.</para>
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
            /// <para>The user-level error code.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeUserScramCredentialsResult WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _errorMessage = NullableString.Default;
            /// <summary>
            /// <para>The user-level error message, if any.</para>
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
            /// <para>The user-level error message, if any.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeUserScramCredentialsResult WithErrorMessage(String? errorMessage)
            {
                ErrorMessage = errorMessage;
                return this;
            }

            private Array<CredentialInfo> _credentialInfosCollection = Array.Empty<CredentialInfo>();
            /// <summary>
            /// <para>The mechanism and related information associated with the user's SCRAM credentials.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<CredentialInfo> CredentialInfosCollection
            {
                get => _credentialInfosCollection;
                private set
                {
                    _credentialInfosCollection = value;
                }
            }

            /// <summary>
            /// <para>The mechanism and related information associated with the user's SCRAM credentials.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeUserScramCredentialsResult WithCredentialInfosCollection(params Func<CredentialInfo, CredentialInfo>[] createFields)
            {
                CredentialInfosCollection = createFields.Select(createField => createField(new CredentialInfo(Version))).ToArray();
                return this;
            }

            public delegate CredentialInfo CreateCredentialInfo(CredentialInfo field);
            /// <summary>
            /// <para>The mechanism and related information associated with the user's SCRAM credentials.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public DescribeUserScramCredentialsResult WithCredentialInfosCollection(IEnumerable<CreateCredentialInfo> createFields)
            {
                CredentialInfosCollection = createFields.Select(createField => createField(new CredentialInfo(Version))).ToArray();
                return this;
            }

            public class CredentialInfo : ISerialize
            {
                internal CredentialInfo(Int16 version)
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
                internal int GetSize(bool _) => _mechanism.GetSize(IsFlexibleVersion) + _iterations.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<CredentialInfo> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new CredentialInfo(version);
                    instance.Mechanism = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.Iterations = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for CredentialInfo is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _mechanism.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _iterations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Int8 _mechanism = Int8.Default;
                /// <summary>
                /// <para>The SCRAM mechanism.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int8 Mechanism
                {
                    get => _mechanism;
                    private set
                    {
                        _mechanism = value;
                    }
                }

                /// <summary>
                /// <para>The SCRAM mechanism.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public CredentialInfo WithMechanism(Int8 mechanism)
                {
                    Mechanism = mechanism;
                    return this;
                }

                private Int32 _iterations = Int32.Default;
                /// <summary>
                /// <para>The number of iterations used in the SCRAM credential.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Int32 Iterations
                {
                    get => _iterations;
                    private set
                    {
                        _iterations = value;
                    }
                }

                /// <summary>
                /// <para>The number of iterations used in the SCRAM credential.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public CredentialInfo WithIterations(Int32 iterations)
                {
                    Iterations = iterations;
                    return this;
                }
            }
        }
    }
}
