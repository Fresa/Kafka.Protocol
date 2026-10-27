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
    public class AbortedTxn
    {
        public AbortedTxn(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AbortedTxn does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = false;
        }

        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
        public Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal int GetSize() => _producerId.GetSize(IsFlexibleVersion) + _firstOffset.GetSize(IsFlexibleVersion) + _lastOffset.GetSize(IsFlexibleVersion) + _lastStableOffset.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        public static async ValueTask<AbortedTxn> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
            var reader = pipe.Reader;
            var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
            var instance = new AbortedTxn(version);
            instance.ProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.FirstOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.LastOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.LastStableOffset = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AbortedTxn is unknown");
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
                await _producerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _firstOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _lastOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _lastStableOffset.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }

                return new Bytes(writer.ToArray());
            }
        }

        private Int64 _producerId = Int64.Default;
        /// <summary>
        /// <para>The producer id associated with the aborted transaction</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 ProducerId
        {
            get => _producerId;
            private set
            {
                _producerId = value;
            }
        }

        /// <summary>
        /// <para>The producer id associated with the aborted transaction</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AbortedTxn WithProducerId(Int64 producerId)
        {
            ProducerId = producerId;
            return this;
        }

        private Int64 _firstOffset = Int64.Default;
        /// <summary>
        /// <para>The first offset in the aborted transaction</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 FirstOffset
        {
            get => _firstOffset;
            private set
            {
                _firstOffset = value;
            }
        }

        /// <summary>
        /// <para>The first offset in the aborted transaction</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AbortedTxn WithFirstOffset(Int64 firstOffset)
        {
            FirstOffset = firstOffset;
            return this;
        }

        private Int64 _lastOffset = Int64.Default;
        /// <summary>
        /// <para>The last offset in the aborted transaction</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 LastOffset
        {
            get => _lastOffset;
            private set
            {
                _lastOffset = value;
            }
        }

        /// <summary>
        /// <para>The last offset in the aborted transaction</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AbortedTxn WithLastOffset(Int64 lastOffset)
        {
            LastOffset = lastOffset;
            return this;
        }

        private Int64 _lastStableOffset = Int64.Default;
        /// <summary>
        /// <para>The last stable offset at the time the transaction was aborted</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int64 LastStableOffset
        {
            get => _lastStableOffset;
            private set
            {
                _lastStableOffset = value;
            }
        }

        /// <summary>
        /// <para>The last stable offset at the time the transaction was aborted</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AbortedTxn WithLastStableOffset(Int64 lastStableOffset)
        {
            LastStableOffset = lastStableOffset;
            return this;
        }
    }
}
