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
    public class CreatePartitionsRequest : Message, IRespond<CreatePartitionsResponse>
    {
        public CreatePartitionsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"CreatePartitionsRequest does not support version {version}. Valid versions are: 0-3");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(37);
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

        internal override int GetSize() => _topicsCollection.GetSize(IsFlexibleVersion) + _timeoutMs.GetSize(IsFlexibleVersion) + _validateOnly.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<CreatePartitionsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new CreatePartitionsRequest(version);
            instance.TopicsCollection = await Map<String, CreatePartitionsTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => CreatePartitionsTopic.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
            instance.TimeoutMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ValidateOnly = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for CreatePartitionsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _timeoutMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _validateOnly.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Map<String, CreatePartitionsTopic> _topicsCollection = Map<String, CreatePartitionsTopic>.Default;
        /// <summary>
        /// <para>Each topic that we want to create new partitions inside.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, CreatePartitionsTopic> TopicsCollection
        {
            get => _topicsCollection;
            private set
            {
                _topicsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each topic that we want to create new partitions inside.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreatePartitionsRequest WithTopicsCollection(params Func<CreatePartitionsTopic, CreatePartitionsTopic>[] createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new CreatePartitionsTopic(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public delegate CreatePartitionsTopic CreateCreatePartitionsTopic(CreatePartitionsTopic field);
        /// <summary>
        /// <para>Each topic that we want to create new partitions inside.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreatePartitionsRequest WithTopicsCollection(IEnumerable<CreateCreatePartitionsTopic> createFields)
        {
            TopicsCollection = createFields.Select(createField => createField(new CreatePartitionsTopic(Version))).ToDictionary(field => field.Name);
            return this;
        }

        public class CreatePartitionsTopic : ISerialize
        {
            internal CreatePartitionsTopic(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _count.GetSize(IsFlexibleVersion) + _assignmentsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<CreatePartitionsTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new CreatePartitionsTopic(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Count = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.AssignmentsCollection = await NullableArray<CreatePartitionsAssignment>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => CreatePartitionsAssignment.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for CreatePartitionsTopic is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _count.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _assignmentsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
            public CreatePartitionsTopic WithName(String name)
            {
                Name = name;
                return this;
            }

            private Int32 _count = Int32.Default;
            /// <summary>
            /// <para>The new partition count.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 Count
            {
                get => _count;
                private set
                {
                    _count = value;
                }
            }

            /// <summary>
            /// <para>The new partition count.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatePartitionsTopic WithCount(Int32 count)
            {
                Count = count;
                return this;
            }

            private NullableArray<CreatePartitionsAssignment> _assignmentsCollection = Array.Empty<CreatePartitionsAssignment>();
            /// <summary>
            /// <para>The new partition assignments.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Array<CreatePartitionsAssignment>? AssignmentsCollection
            {
                get => _assignmentsCollection;
                private set
                {
                    _assignmentsCollection = value;
                }
            }

            /// <summary>
            /// <para>The new partition assignments.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatePartitionsTopic WithAssignmentsCollection(params Func<CreatePartitionsAssignment, CreatePartitionsAssignment>[] createFields)
            {
                AssignmentsCollection = createFields.Select(createField => createField(new CreatePartitionsAssignment(Version))).ToArray();
                return this;
            }

            public delegate CreatePartitionsAssignment CreateCreatePartitionsAssignment(CreatePartitionsAssignment field);
            /// <summary>
            /// <para>The new partition assignments.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public CreatePartitionsTopic WithAssignmentsCollection(IEnumerable<CreateCreatePartitionsAssignment> createFields)
            {
                AssignmentsCollection = createFields.Select(createField => createField(new CreatePartitionsAssignment(Version))).ToArray();
                return this;
            }

            public class CreatePartitionsAssignment : ISerialize
            {
                internal CreatePartitionsAssignment(Int16 version)
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
                internal int GetSize(bool _) => _brokerIdsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<CreatePartitionsAssignment> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new CreatePartitionsAssignment(version);
                    instance.BrokerIdsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for CreatePartitionsAssignment is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _brokerIdsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    if (IsFlexibleVersion)
                    {
                        await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                    }
                }

                private Array<Int32> _brokerIdsCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The assigned broker IDs.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> BrokerIdsCollection
                {
                    get => _brokerIdsCollection;
                    private set
                    {
                        _brokerIdsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The assigned broker IDs.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public CreatePartitionsAssignment WithBrokerIdsCollection(Array<Int32> brokerIdsCollection)
                {
                    BrokerIdsCollection = brokerIdsCollection;
                    return this;
                }
            }
        }

        private Int32 _timeoutMs = Int32.Default;
        /// <summary>
        /// <para>The time in ms to wait for the partitions to be created.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 TimeoutMs
        {
            get => _timeoutMs;
            private set
            {
                _timeoutMs = value;
            }
        }

        /// <summary>
        /// <para>The time in ms to wait for the partitions to be created.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreatePartitionsRequest WithTimeoutMs(Int32 timeoutMs)
        {
            TimeoutMs = timeoutMs;
            return this;
        }

        private Boolean _validateOnly = Boolean.Default;
        /// <summary>
        /// <para>If true, then validate the request, but don't actually increase the number of partitions.</para>
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
        /// <para>If true, then validate the request, but don't actually increase the number of partitions.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public CreatePartitionsRequest WithValidateOnly(Boolean validateOnly)
        {
            ValidateOnly = validateOnly;
            return this;
        }

        public CreatePartitionsResponse Respond() => new CreatePartitionsResponse(Version);
    }
}
