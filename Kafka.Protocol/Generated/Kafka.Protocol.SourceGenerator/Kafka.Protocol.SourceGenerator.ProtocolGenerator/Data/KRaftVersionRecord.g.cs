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
    public class KRaftVersionRecord
    {
        public KRaftVersionRecord(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"KRaftVersionRecord does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
        public Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal int GetSize() => _version.GetSize(IsFlexibleVersion) + _kRaftVersion.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        public static async ValueTask<KRaftVersionRecord> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
            var reader = pipe.Reader;
            var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
            var instance = new KRaftVersionRecord(version);
            instance.Version_ = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.KRaftVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for KRaftVersionRecord is unknown");
                    }
                }
            }

            return instance;
        }

        public async ValueTask<Bytes> ToBytesAsync(CancellationToken cancellationToken = default)
        {
            var writer = new MemoryStream();
            await using (writer.ConfigureAwait(false))
            {
                await Version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _kRaftVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }

                return new Bytes(writer.ToArray());
            }
        }

        private Int16 _version = Int16.Default;
        /// <summary>
        /// <para>The version of the kraft version record</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int16 Version_
        {
            get => _version;
            private set
            {
                _version = value;
            }
        }

        /// <summary>
        /// <para>The version of the kraft version record</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public KRaftVersionRecord WithVersion_(Int16 version)
        {
            Version_ = version;
            return this;
        }

        private Int16 _kRaftVersion = Int16.Default;
        /// <summary>
        /// <para>The kraft protocol version</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int16 KRaftVersion
        {
            get => _kRaftVersion;
            private set
            {
                _kRaftVersion = value;
            }
        }

        /// <summary>
        /// <para>The kraft protocol version</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public KRaftVersionRecord WithKRaftVersion(Int16 kRaftVersion)
        {
            KRaftVersion = kRaftVersion;
            return this;
        }
    }
}
