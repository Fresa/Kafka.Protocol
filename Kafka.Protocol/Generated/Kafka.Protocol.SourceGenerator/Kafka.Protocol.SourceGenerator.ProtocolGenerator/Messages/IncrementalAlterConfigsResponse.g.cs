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
    public class IncrementalAlterConfigsResponse : Message
    {
        public IncrementalAlterConfigsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"IncrementalAlterConfigsResponse does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = version >= 1;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(44);
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

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _responsesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<IncrementalAlterConfigsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new IncrementalAlterConfigsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ResponsesCollection = await Array<AlterConfigsResourceResponse>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterConfigsResourceResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for IncrementalAlterConfigsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _responsesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
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
        /// <para>Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public IncrementalAlterConfigsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Array<AlterConfigsResourceResponse> _responsesCollection = Array.Empty<AlterConfigsResourceResponse>();
        /// <summary>
        /// <para>The responses for each resource.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<AlterConfigsResourceResponse> ResponsesCollection
        {
            get => _responsesCollection;
            private set
            {
                _responsesCollection = value;
            }
        }

        /// <summary>
        /// <para>The responses for each resource.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public IncrementalAlterConfigsResponse WithResponsesCollection(params Func<AlterConfigsResourceResponse, AlterConfigsResourceResponse>[] createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new AlterConfigsResourceResponse(Version))).ToArray();
            return this;
        }

        public delegate AlterConfigsResourceResponse CreateAlterConfigsResourceResponse(AlterConfigsResourceResponse field);
        /// <summary>
        /// <para>The responses for each resource.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public IncrementalAlterConfigsResponse WithResponsesCollection(IEnumerable<CreateAlterConfigsResourceResponse> createFields)
        {
            ResponsesCollection = createFields.Select(createField => createField(new AlterConfigsResourceResponse(Version))).ToArray();
            return this;
        }

        public class AlterConfigsResourceResponse : ISerialize
        {
            internal AlterConfigsResourceResponse(Int16 version)
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
            internal int GetSize(bool _) => _errorCode.GetSize(IsFlexibleVersion) + _errorMessage.GetSize(IsFlexibleVersion) + _resourceType.GetSize(IsFlexibleVersion) + _resourceName.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AlterConfigsResourceResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AlterConfigsResourceResponse(version);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ResourceType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ResourceName = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterConfigsResourceResponse is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _resourceType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _resourceName.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The resource error code.</para>
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
            /// <para>The resource error code.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterConfigsResourceResponse WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _errorMessage = NullableString.Default;
            /// <summary>
            /// <para>The resource error message, or null if there was no error.</para>
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
            /// <para>The resource error message, or null if there was no error.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterConfigsResourceResponse WithErrorMessage(String? errorMessage)
            {
                ErrorMessage = errorMessage;
                return this;
            }

            private Int8 _resourceType = Int8.Default;
            /// <summary>
            /// <para>The resource type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int8 ResourceType
            {
                get => _resourceType;
                private set
                {
                    _resourceType = value;
                }
            }

            /// <summary>
            /// <para>The resource type.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterConfigsResourceResponse WithResourceType(Int8 resourceType)
            {
                ResourceType = resourceType;
                return this;
            }

            private String _resourceName = String.Default;
            /// <summary>
            /// <para>The resource name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String ResourceName
            {
                get => _resourceName;
                private set
                {
                    _resourceName = value;
                }
            }

            /// <summary>
            /// <para>The resource name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterConfigsResourceResponse WithResourceName(String resourceName)
            {
                ResourceName = resourceName;
                return this;
            }
        }
    }
}
