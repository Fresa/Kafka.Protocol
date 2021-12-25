using System;
using System.IO;
using System.Linq;
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

        public static async ValueTask<RecordBatch> ReadFromAsync(
            Int16 version,
            IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            var recordBatch = new RecordBatch
            {
                BaseOffset = await reader.ReadInt64Async(cancellationToken)
                    .ConfigureAwait(false),
                BatchLength = await reader.ReadInt32Async(cancellationToken)
                    .ConfigureAwait(false),
                PartitionLeaderEpoch = await reader
                    .ReadInt32Async(cancellationToken)
                    .ConfigureAwait(false),
                Magic = await reader.ReadInt8Async(cancellationToken)
                    .ConfigureAwait(false),
                Crc = await reader.ReadInt32Async(cancellationToken)
                    .ConfigureAwait(false),
                Attributes = await reader.ReadInt16Async(cancellationToken)
                    .ConfigureAwait(false),
                LastOffsetDelta = await reader
                    .ReadInt32Async(cancellationToken)
                    .ConfigureAwait(false),
                FirstTimestamp = await reader
                    .ReadInt64Async(cancellationToken)
                    .ConfigureAwait(false),
                MaxTimestamp = await reader.ReadInt64Async(cancellationToken)
                    .ConfigureAwait(false),
                ProducerId = await reader.ReadInt64Async(cancellationToken)
                    .ConfigureAwait(false),
                ProducerEpoch = await reader.ReadInt16Async(cancellationToken)
                    .ConfigureAwait(false),
                BaseSequence = await reader.ReadInt32Async(cancellationToken)
                    .ConfigureAwait(false),
                Records = await reader.ReadArrayAsync(
                        async () =>
                            await Record
                                .FromReaderAsync(reader,
                                    cancellationToken)
                                .ConfigureAwait(false), cancellationToken)
                    .ConfigureAwait(false)
            };

            await recordBatch.CheckForDataCorruption(cancellationToken)
                .ConfigureAwait(false);

            return recordBatch;
        }

        private async ValueTask CheckForDataCorruption(
            CancellationToken cancellationToken = default)
        {
            var bytes = await SerializeCrcData(cancellationToken)
                .ConfigureAwait(false);
            var crc = Crc32C.Compute(bytes);
            if (crc != Crc)
            {
                throw new CorruptMessageException(
                    $"Record batch is corrupt. The read data has crc {crc} but the record batch states that crc should be {Crc}");
            }
        }

        internal int Length => SizeOf;

        public async ValueTask WriteToAsync(
            IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteInt64Async(BaseOffset, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteInt32Async(BatchLength, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteInt32Async(
                    PartitionLeaderEpoch, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteInt8Async(Magic, cancellationToken)
                .ConfigureAwait(false);
            
            var bytes = await SerializeCrcData(cancellationToken)
                .ConfigureAwait(false);
            Crc = Int32.From((int) Crc32C.Compute(bytes));

            await writer.WriteInt32Async(Crc, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteBytesAsync(bytes, cancellationToken)
                .ConfigureAwait(false);
        }

        public int SizeOf =>
            61 +
            Records.Sum(record => record.Length);

        private async ValueTask<byte[]> SerializeCrcData(
            CancellationToken cancellationToken = default)
        {
            var buffer = new MemoryStream();
            await using (buffer.ConfigureAwait(false))
            {
                var bufferWriter = new KafkaWriter(buffer);
                await using (bufferWriter.ConfigureAwait(false))
                {
                    await bufferWriter.WriteInt16Async(Attributes, cancellationToken)
                        .ConfigureAwait(false);
                    await bufferWriter.WriteInt32Async(LastOffsetDelta, cancellationToken)
                        .ConfigureAwait(false);
                    await bufferWriter.WriteInt64Async(FirstTimestamp, cancellationToken)
                        .ConfigureAwait(false);
                    await bufferWriter.WriteInt64Async(MaxTimestamp, cancellationToken)
                        .ConfigureAwait(false);
                    await bufferWriter.WriteInt64Async(ProducerId, cancellationToken)
                        .ConfigureAwait(false);
                    await bufferWriter.WriteInt16Async(ProducerEpoch, cancellationToken)
                        .ConfigureAwait(false);
                    await bufferWriter.WriteInt32Async(BaseSequence, cancellationToken)
                        .ConfigureAwait(false);

                    // todo: support compression
                    await bufferWriter.WriteArrayAsync(cancellationToken, Records)
                        .ConfigureAwait(false);
                }
            }

            return buffer.ToArray();
        }
    }
}