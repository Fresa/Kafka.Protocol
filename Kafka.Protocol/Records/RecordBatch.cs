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

        public Compressions Compression => new Compressions(this);

        public class Compressions
        {
            private readonly RecordBatch _recordBatch;

            internal Compressions(
                RecordBatch recordBatch)
            {
                _recordBatch = recordBatch;
            }

            private ushort Value
            {
                get => _recordBatch.Attributes.GetValueOfBitRange(0, 2);
                set => _recordBatch.Attributes =
                    _recordBatch.Attributes.SetBitRangeValue(0, 2, value);
            }

            public bool None
            {
                get => Value == 0;
                set
                {
                    if (value)
                    {
                        Value = 0;
                    }
                }
            }

            public bool Gzip
            {
                get => Value == 1;
                set
                {
                    if (value)
                    {
                        Value = 1;
                    }
                }
            }

            public bool Snappy
            {
                get => Value == 2;
                set
                {
                    if (value)
                    {
                        Value = 2;
                    }
                }
            }

            public bool Lz4
            {
                get => Value == 3;
                set
                {
                    if (value)
                    {
                        Value = 3;
                    }
                }
            }

            public bool Zstd
            {
                get => Value == 4;
                set
                {
                    if (value)
                    {
                        Value = 4;
                    }
                }
            }
        }

        public TimestampTypes TimestampType => new TimestampTypes(this);

        public class TimestampTypes
        {
            private readonly RecordBatch _recordBatch;

            internal TimestampTypes(
                RecordBatch recordBatch)
            {
                _recordBatch = recordBatch;
            }

            public bool CreateTime
            {
                get => !LogAppendTime;
                set => LogAppendTime = !value;
            }

            public bool LogAppendTime
            {
                get => _recordBatch.Attributes.IsBitSet(3);
                set => _recordBatch.Attributes =
                    _recordBatch.Attributes.SetBit(3, value);
            }
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

        internal int Length =>
            61 +
            Records.Sum(record => record.Length);

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

                    await bufferWriter.WriteInt32Async(Records.Length, cancellationToken)
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