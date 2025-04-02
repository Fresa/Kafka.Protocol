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
    public class AlterReplicaLogDirsRequest : Message, IRespond<AlterReplicaLogDirsResponse>
    {
        public AlterReplicaLogDirsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AlterReplicaLogDirsRequest does not support version {version}. Valid versions are: 1-2");
            Version = version;
            IsFlexibleVersion = version >= 2;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(34);
        public static readonly Int16 MinVersion = Int16.From(1);
        public static readonly Int16 MaxVersion = Int16.From(2);
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

        internal override int GetSize() => _dirsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AlterReplicaLogDirsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AlterReplicaLogDirsRequest(version);
            instance.DirsCollection = await Map<String, AlterReplicaLogDir>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterReplicaLogDir.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Path, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterReplicaLogDirsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _dirsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Map<String, AlterReplicaLogDir> _dirsCollection = Map<String, AlterReplicaLogDir>.Default;
        /// <summary>
        /// <para>The alterations to make for each directory.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Map<String, AlterReplicaLogDir> DirsCollection
        {
            get => _dirsCollection;
            private set
            {
                _dirsCollection = value;
            }
        }

        /// <summary>
        /// <para>The alterations to make for each directory.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterReplicaLogDirsRequest WithDirsCollection(params Func<AlterReplicaLogDir, AlterReplicaLogDir>[] createFields)
        {
            DirsCollection = createFields.Select(createField => createField(new AlterReplicaLogDir(Version))).ToDictionary(field => field.Path);
            return this;
        }

        public delegate AlterReplicaLogDir CreateAlterReplicaLogDir(AlterReplicaLogDir field);
        /// <summary>
        /// <para>The alterations to make for each directory.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterReplicaLogDirsRequest WithDirsCollection(IEnumerable<CreateAlterReplicaLogDir> createFields)
        {
            DirsCollection = createFields.Select(createField => createField(new AlterReplicaLogDir(Version))).ToDictionary(field => field.Path);
            return this;
        }

        public class AlterReplicaLogDir : ISerialize
        {
            internal AlterReplicaLogDir(Int16 version)
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
            internal int GetSize(bool _) => _path.GetSize(IsFlexibleVersion) + _topicsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<AlterReplicaLogDir> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new AlterReplicaLogDir(version);
                instance.Path = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TopicsCollection = await Map<String, AlterReplicaLogDirTopic>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => AlterReplicaLogDirTopic.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterReplicaLogDir is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _path.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _path = String.Default;
            /// <summary>
            /// <para>The absolute directory path.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String Path
            {
                get => _path;
                private set
                {
                    _path = value;
                }
            }

            /// <summary>
            /// <para>The absolute directory path.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterReplicaLogDir WithPath(String path)
            {
                Path = path;
                return this;
            }

            private Map<String, AlterReplicaLogDirTopic> _topicsCollection = Map<String, AlterReplicaLogDirTopic>.Default;
            /// <summary>
            /// <para>The topics to add to the directory.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Map<String, AlterReplicaLogDirTopic> TopicsCollection
            {
                get => _topicsCollection;
                private set
                {
                    _topicsCollection = value;
                }
            }

            /// <summary>
            /// <para>The topics to add to the directory.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterReplicaLogDir WithTopicsCollection(params Func<AlterReplicaLogDirTopic, AlterReplicaLogDirTopic>[] createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new AlterReplicaLogDirTopic(Version))).ToDictionary(field => field.Name);
                return this;
            }

            public delegate AlterReplicaLogDirTopic CreateAlterReplicaLogDirTopic(AlterReplicaLogDirTopic field);
            /// <summary>
            /// <para>The topics to add to the directory.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public AlterReplicaLogDir WithTopicsCollection(IEnumerable<CreateAlterReplicaLogDirTopic> createFields)
            {
                TopicsCollection = createFields.Select(createField => createField(new AlterReplicaLogDirTopic(Version))).ToDictionary(field => field.Name);
                return this;
            }

            public class AlterReplicaLogDirTopic : ISerialize
            {
                internal AlterReplicaLogDirTopic(Int16 version)
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
                internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _partitionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
                internal static async ValueTask<AlterReplicaLogDirTopic> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                {
                    var instance = new AlterReplicaLogDirTopic(version);
                    instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
                    if (instance.IsFlexibleVersion)
                    {
                        var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                        await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                        {
                            switch (tag.Tag)
                            {
                                default:
                                    throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterReplicaLogDirTopic is unknown");
                            }
                        }
                    }

                    return instance;
                }

                ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
                {
                    await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                    await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
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
                public AlterReplicaLogDirTopic WithName(String name)
                {
                    Name = name;
                    return this;
                }

                private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
                /// <summary>
                /// <para>The partition indexes.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public Array<Int32> PartitionsCollection
                {
                    get => _partitionsCollection;
                    private set
                    {
                        _partitionsCollection = value;
                    }
                }

                /// <summary>
                /// <para>The partition indexes.</para>
                /// <para>Versions: 0+</para>
                /// </summary>
                public AlterReplicaLogDirTopic WithPartitionsCollection(Array<Int32> partitionsCollection)
                {
                    PartitionsCollection = partitionsCollection;
                    return this;
                }
            }
        }

        public AlterReplicaLogDirsResponse Respond() => new AlterReplicaLogDirsResponse(Version);
    }
}
