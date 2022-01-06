using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Cryptography;

namespace Kafka.Protocol.Records
{
    public class RecordBatch : ISerialize
    {
        internal static RecordBatch Default => new RecordBatch();

        public Int64 BaseOffset { get; set; } = Int64.Default;
        public Int32 BatchLength { get; set; } = Int32.Default;
        public Int32 PartitionLeaderEpoch { get; set; } = Int32.Default;
        public Int8 Magic { get; set; } = Int8.Default;
        public Int32 Crc { get; private set; } = Int32.Default;
        public Int16 Attributes { get; set; } = Int16.Default;
        public Int32 LastOffsetDelta { get; set; } = Int32.Default;
        public Int64 FirstTimestamp { get; set; } = Int64.Default;
        public Int64 MaxTimestamp { get; set; } = Int64.Default;
        public Int64 ProducerId { get; set; } = Int64.Default;
        public Int16 ProducerEpoch { get; set; } = Int16.Default;
        public Int32 BaseSequence { get; set; } = Int32.Default;
        public Record[] Records { get; set; } = Array.Empty<Record>();

        [Flags]
        public enum CompressionType : ushort
        {
            None = 0,
            Gzip = 1,
            Snappy = 2,
            Lz4 = 4,
            Zstd = 8
        }

        public CompressionType Compression
        {
            get => (CompressionType)Attributes.GetValueOfBitRange(0, 2);
            set => Attributes =
                Attributes.SetBitRangeValue(0, 2, (ushort)value);
        }

        [Flags]
        public enum Timestamp : byte
        {
            CreateTime = 0,
            LogAppendTime = 1
        }

        public Timestamp TimestampType
        {
            get => (Timestamp)Convert.ToByte(
                Attributes.IsBitSet(3));
            set => Attributes.SetBit(3, Convert.ToBoolean((byte)value));
        }

        public bool IsTransactional
        {
            get => Attributes.IsBitSet(4);
            set => Attributes = Attributes.SetBit(4, value);
        }

        public bool IsControlBatch
        {
            get => Attributes.IsBitSet(5);
            set => Attributes = Attributes.SetBit(5, value);
        }

        public static async ValueTask<RecordBatch> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            var recordBatch = new RecordBatch
            {
                BaseOffset = await Int64.FromReaderAsync(reader, asCompact,
                        cancellationToken)
                    .ConfigureAwait(false),
                BatchLength = await Int32.FromReaderAsync(reader, asCompact,
                        cancellationToken)
                    .ConfigureAwait(false),
                PartitionLeaderEpoch = await Int32
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false),
                Magic = await Int8
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false),
                Crc = await Int32
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false),
                Attributes = await Int16.FromReaderAsync(reader, asCompact,
                        cancellationToken)
                    .ConfigureAwait(false),
                LastOffsetDelta = await Int32
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false),
                FirstTimestamp = await Int64
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false),
                MaxTimestamp = await Int64
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false),
                ProducerId = await Int64.FromReaderAsync(reader, asCompact,
                        cancellationToken)
                    .ConfigureAwait(false),
                ProducerEpoch = await Int16
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false),
                BaseSequence = await Int32
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false),
                Records = await Array<Record>.FromReaderAsync(reader, asCompact,
                        () => Record.FromReaderAsync(reader, asCompact,
                            cancellationToken), cancellationToken)
                    .ConfigureAwait(false)
            };

            await recordBatch.CheckForDataCorruption(asCompact, cancellationToken)
                .ConfigureAwait(false);

            return recordBatch;
        }

        private async ValueTask CheckForDataCorruption(
            bool asCompact,
            CancellationToken cancellationToken)
        {
            var bytes = await SerializeCrcData(asCompact, cancellationToken)
                .ConfigureAwait(false);
            var crc = Crc32C.Compute(bytes);
            if (crc != Crc)
            {
                throw new CorruptMessageException(
                    $"Record batch is corrupt. The read data has crc {crc} but the record batch states that crc should be {Crc}");
            }
        }

        public async ValueTask WriteToAsync(
            Stream writer,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            await BaseOffset.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
            await BatchLength.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
            await PartitionLeaderEpoch.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
            await Magic.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);

            var bytes = await SerializeCrcData(asCompact, cancellationToken)
                .ConfigureAwait(false);
            Crc = (int)Crc32C.Compute(bytes);

            await Crc.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
            await Bytes.From(bytes).WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
        }

        public int GetSize(bool asCompact) =>
            BaseOffset.GetSize(asCompact) +
            BatchLength.GetSize(asCompact) +
            PartitionLeaderEpoch.GetSize(asCompact) +
            Magic.GetSize(asCompact) +
            Crc.GetSize(asCompact) +
            Attributes.GetSize(asCompact) +
            LastOffsetDelta.GetSize(asCompact) +
            FirstTimestamp.GetSize(asCompact) +
            MaxTimestamp.GetSize(asCompact) +
            ProducerId.GetSize(asCompact) +
            ProducerEpoch.GetSize(asCompact) +
            BaseSequence.GetSize(asCompact) +
            Array<Record>.From(Records).GetSize(asCompact);

        private async ValueTask<byte[]> SerializeCrcData(
            bool asCompact,
            CancellationToken cancellationToken)
        {
            var writer = new MemoryStream();
            await using (writer.ConfigureAwait(false))
            {
                await Attributes.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
                await LastOffsetDelta.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
                await FirstTimestamp.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
                await MaxTimestamp.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
                await ProducerId.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
                await ProducerEpoch.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
                await BaseSequence.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
                
                // todo: support compression
                await Array<Record>.From(Records).WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
            }

            return writer.ToArray();
        }
    }
}