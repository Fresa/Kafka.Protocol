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
    public class CreateTopicsResponse : Message
    {
        public CreateTopicsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"CreateTopicsResponse does not support version {version}. Valid versions are: 0-7");
            Version = version;
            IsFlexibleVersion = version >= 5;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(19);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(7);
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

        internal override int GetSize() => (Version >= 2 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<CreateTopicsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new CreateTopicsResponse(version);
            if (instance.Version >= 2)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TopicsCollection = await Map<String, CreatableTopicResult>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => CreatableTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for CreateTopicsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 2)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 2+</para>
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
        /// <para>Versions: 2+</para>
        /// </summary>
        public CreateTopicsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Map<String, CreatableTopicResult> _topicsCollection = Map<String, CreatableTopicResult>.Default;
        /// <summary>
        /// <para>Results for each topic we tried to create.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, CreatableTopicResult> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Results for each topic we tried to create.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateTopicsResponse WithTopicsCollection(params Func<CreatableTopicResult, CreatableTopicResult>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new CreatableTopicResult(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate CreatableTopicResult CreateCreatableTopicResult(CreatableTopicResult field);
        /// <summary>
        /// <para>Results for each topic we tried to create.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreateTopicsResponse WithTopicsCollection(IEnumerable<CreateCreatableTopicResult> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new CreatableTopicResult(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class CreatableTopicResult : ISerialize
        {
            internal CreatableTopicResult(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 5;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                var tags = new List<Tags.TaggedField>();
                if (Version >= 5 && _topicConfigErrorCodeIsSet)
                {
                    tags.Add(new Tags.TaggedField { Tag = 0, Field = _topicConfigErrorCode });
                }

                return new Tags.TagSection(tags.ToArray());
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 5 ? _numPartitions.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _replicationFactor.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _configsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<CreatableTopicResult> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new CreatableTopicResult(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 7)
                    instance.TopicId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 1)
                    instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 5)
                    instance.NumPartitions = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 5)
                    instance.ReplicationFactor = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 5)
                    instance.ConfigsCollection = await NullableArray<CreatableTopicConfigs>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => CreatableTopicConfigs.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            case 0:
                                if (instance.Version >= 5)
                                    instance.TopicConfigErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                                else
                                    throw new InvalidOperationException($"Field TopicConfigErrorCode is not supported for version {instance.Version}");
                            {
                                var size = instance._topicConfigErrorCode.GetSize(true);
                                if (size != tag.Length)
                                    throw new CorruptMessageException($"Tagged field TopicConfigErrorCode read length {tag.Length} but had actual length of {size}");
                            }

                                break;
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for CreatableTopicResult is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 7)
                    await _topicId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 1)
                    await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 5)
                    await _numPartitions.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 5)
                    await _replicationFactor.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 5)
                    await _configsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Name
            {
                get => _name;
                private set
                {
                    _name = value;
                }
            }

            /// <summary>
            /// <para>The topic name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatableTopicResult WithName(String name)
            {
                Name = name;
                return this;
            }

            private Uuid _topicId = Uuid.Default;
            /// <summary>
            /// <para>The unique topic ID</para>
            /// <para>Versions: 7+</para>
            /// </summary>
            public Uuid TopicId
            {
                get => _topicId;
                private set
                {
                    _topicId = value;
                }
            }

            /// <summary>
            /// <para>The unique topic ID</para>
            /// <para>Versions: 7+</para>
            /// </summary>
            public CreatableTopicResult WithTopicId(Uuid topicId)
            {
                TopicId = topicId;
                return this;
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
            public CreatableTopicResult WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _errorMessage = NullableString.Default;
            /// <summary>
            /// <para>The error message, or null if there was no error.</para>
            /// <para>Versions: 1+</para>
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
            /// <para>The error message, or null if there was no error.</para>
            /// <para>Versions: 1+</para>
            /// </summary>
            public CreatableTopicResult WithErrorMessage(String? errorMessage)
            {
                ErrorMessage = errorMessage;
                return this;
            }

            private bool _topicConfigErrorCodeIsSet;
            private Int16 _topicConfigErrorCode = Int16.Default;
            /// <summary>
            /// <para>Optional topic config error returned if configs are not returned in the response.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public Int16 TopicConfigErrorCode
            {
                get => _topicConfigErrorCode;
                private set
                {
                    _topicConfigErrorCode = value;
                    _topicConfigErrorCodeIsSet = true;
                }
            }

            /// <summary>
            /// <para>Optional topic config error returned if configs are not returned in the response.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public CreatableTopicResult WithTopicConfigErrorCode(Int16 topicConfigErrorCode)
            {
                TopicConfigErrorCode = topicConfigErrorCode;
                return this;
            }

            private Int32 _numPartitions = new Int32(-1);
            /// <summary>
            /// <para>Number of partitions of the topic.</para>
            /// <para>Versions: 5+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public Int32 NumPartitions
            {
                get => _numPartitions;
                private set
                {
                    _numPartitions = value;
                }
            }

            /// <summary>
            /// <para>Number of partitions of the topic.</para>
            /// <para>Versions: 5+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public CreatableTopicResult WithNumPartitions(Int32 numPartitions)
            {
                NumPartitions = numPartitions;
                return this;
            }

            private Int16 _replicationFactor = new Int16(-1);
            /// <summary>
            /// <para>Replication factor of the topic.</para>
            /// <para>Versions: 5+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public Int16 ReplicationFactor
            {
                get => _replicationFactor;
                private set
                {
                    _replicationFactor = value;
                }
            }

            /// <summary>
            /// <para>Replication factor of the topic.</para>
            /// <para>Versions: 5+</para>
            /// <para>Default: -1</para>
            /// </summary>
            public CreatableTopicResult WithReplicationFactor(Int16 replicationFactor)
            {
                ReplicationFactor = replicationFactor;
                return this;
            }

            private NullableArray<CreatableTopicConfigs> _configsCollection = Array.Empty<CreatableTopicConfigs>();
            /// <summary>
            /// <para>Configuration of the topic.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public Array<CreatableTopicConfigs>? ConfigsCollection
            {
                get => _configsCollection;
                private set
                {
                    if (Version >= 5 == false && value == null)
                        throw new UnsupportedVersionException($"ConfigsCollection does not support null for version {Version}. Supported versions for null value: 5+");
                    _configsCollection = value;
                }
            }

            /// <summary>
            /// <para>Configuration of the topic.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public CreatableTopicResult WithConfigsCollection(params Func<CreatableTopicConfigs, CreatableTopicConfigs>[] createFields)
            {
                ConfigsCollection = createFields.Select(createField => createField(new CreatableTopicConfigs(Version))).ToArray();
                return this;
            }

            public delegate CreatableTopicConfigs CreateCreatableTopicConfigs(CreatableTopicConfigs field);
            /// <summary>
            /// <para>Configuration of the topic.</para>
            /// <para>Versions: 5+</para>
            /// </summary>
            public CreatableTopicResult WithConfigsCollection(IEnumerable<CreateCreatableTopicConfigs> createFields)
            {
                ConfigsCollection = createFields.Select(createField => createField(new CreatableTopicConfigs(Version))).ToArray();
                return this;
            }

            public class CreatableTopicConfigs : ISerialize
            {
                internal CreatableTopicConfigs(Int16 version)
                {
                    Version = version;
                    IsFlexibleVersion = version >= 5;
                }

                internal Int16 Version { get; }
                internal bool IsFlexibleVersion { get; }

                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }

                int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                internal int GetSize(bool _) => (Version >= 5 ? _name.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _value.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _readOnly.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _configSource.GetSize(IsFlexibleVersion) : 0) + (Version >= 5 ? _isSensitive.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<CreatableTopicConfigs> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new CreatableTopicConfigs(version);
                    if (instance.Version >= 5)
                        instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 5)
                        instance.Value = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 5)
                        instance.ReadOnly = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 5)
                        instance.ConfigSource = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.Version >= 5)
                        instance.IsSensitive = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for CreatableTopicConfigs is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    if (Version >= 5)
                        await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 5)
                        await _value.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 5)
                        await _readOnly.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 5)
                        await _configSource.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (Version >= 5)
                        await _isSensitive.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private String _name = String.Default;
                /// <summary>
                /// <para>The configuration name.</para>
                /// <para>Versions: 5+</para>
                /// </summary>
                public String Name
                {
                    get => _name;
                    private set
                    {
                        if (Version >= 5 == false)
                            throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                        _name = value;
                    }
                }

                /// <summary>
                /// <para>The configuration name.</para>
                /// <para>Versions: 5+</para>
                /// </summary>
                public CreatableTopicConfigs WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private NullableString _value = NullableString.Default;
                /// <summary>
                /// <para>The configuration value.</para>
                /// <para>Versions: 5+</para>
                /// </summary>
                public String? Value
                {
                    get => _value;
                    private set
                    {
                        if (Version >= 5 == false)
                            throw new UnsupportedVersionException($"Value does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                        if (Version >= 5 == false && value == null)
                            throw new UnsupportedVersionException($"Value does not support null for version {Version}. Supported versions for null value: 5+");
                        _value = value;
                    }
                }

                /// <summary>
                /// <para>The configuration value.</para>
                /// <para>Versions: 5+</para>
                /// </summary>
                public CreatableTopicConfigs WithValue(String? value)
                {
                    Value = value;
                    return this;
                }

                private Boolean _readOnly = Boolean.Default;
                /// <summary>
                /// <para>True if the configuration is read-only.</para>
                /// <para>Versions: 5+</para>
                /// </summary>
                public Boolean ReadOnly
                {
                    get => _readOnly;
                    private set
                    {
                        if (Version >= 5 == false)
                            throw new UnsupportedVersionException($"ReadOnly does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                        _readOnly = value;
                    }
                }

                /// <summary>
                /// <para>True if the configuration is read-only.</para>
                /// <para>Versions: 5+</para>
                /// </summary>
                public CreatableTopicConfigs WithReadOnly(Boolean readOnly)
                {
                    ReadOnly = readOnly;
                    return this;
                }

                private Int8 _configSource = new Int8(-1);
                /// <summary>
                /// <para>The configuration source.</para>
                /// <para>Versions: 5+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public Int8 ConfigSource
                {
                    get => _configSource;
                    private set
                    {
                        _configSource = value;
                    }
                }

                /// <summary>
                /// <para>The configuration source.</para>
                /// <para>Versions: 5+</para>
                /// <para>Default: -1</para>
                /// </summary>
                public CreatableTopicConfigs WithConfigSource(Int8 configSource)
                {
                    ConfigSource = configSource;
                    return this;
                }

                private Boolean _isSensitive = Boolean.Default;
                /// <summary>
                /// <para>True if this configuration is sensitive.</para>
                /// <para>Versions: 5+</para>
                /// </summary>
                public Boolean IsSensitive
                {
                    get => _isSensitive;
                    private set
                    {
                        if (Version >= 5 == false)
                            throw new UnsupportedVersionException($"IsSensitive does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
                        _isSensitive = value;
                    }
                }

                /// <summary>
                /// <para>True if this configuration is sensitive.</para>
                /// <para>Versions: 5+</para>
                /// </summary>
                public CreatableTopicConfigs WithIsSensitive(Boolean isSensitive)
                {
                    IsSensitive = isSensitive;
                    return this;
                }
            }
        }
    }
}
