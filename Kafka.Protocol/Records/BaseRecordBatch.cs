using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Cryptography;

namespace Kafka.Protocol.Records
{
    public abstract class BaseRecordBatch : ISerialize
    {
        protected BaseRecordBatch()
        {
        }

        protected BaseRecordBatch(BaseRecordBatch recordBatch)
        {
            BaseOffset = recordBatch.BaseOffset;
            BatchLength = recordBatch.BatchLength;
            PartitionLeaderEpoch = recordBatch.PartitionLeaderEpoch;
            Magic = recordBatch.Magic;
            Crc = recordBatch.Crc;
            Attributes = recordBatch.Attributes;
            LastOffsetDelta = recordBatch.LastOffsetDelta;
            FirstTimestamp = recordBatch.FirstTimestamp;
            MaxTimestamp = recordBatch.MaxTimestamp;
            ProducerId = recordBatch.ProducerId;
            ProducerEpoch = recordBatch.ProducerEpoch;
            BaseSequence = recordBatch.BaseSequence;
            Records = recordBatch.Records;
        }

        public Int64 BaseOffset { get; set; } = Int64.Default;
        /// <summary>
        /// The batch length is not calculated until the record batch is serialized as it is
        /// dependent on the underlying message serialization format
        /// </summary>
        public Int32 BatchLength { get; private set; } = Int32.Default;
        public Int32 PartitionLeaderEpoch { get; set; } = Int32.Default;
        public Int8 Magic { get; set; } = Int8.Default;
        /// <summary>
        /// The CRC is not calculated until the record batch is serialized as it is
        /// dependent on the underlying message serialization format
        /// </summary>
        public UInt32 Crc { get; private set; } = UInt32.Default;
        public Int16 Attributes { get; set; } = Int16.Default;
        public Int32 LastOffsetDelta { get; set; } = Int32.Default;
        public Int64 FirstTimestamp { get; set; } = Int64.Default;
        public Int64 MaxTimestamp { get; set; } = Int64.Default;
        public Int64 ProducerId { get; set; } = Int64.Default;
        public Int16 ProducerEpoch { get; set; } = Int16.Default;
        public Int32 BaseSequence { get; set; } = Int32.Default;
        protected NullableArray<Record> Records { get; set; }

        public RecordBatch.CompressionType Compression
        {
            get => (RecordBatch.CompressionType)Attributes.GetValueOfBitRange(0, 2);
            set => Attributes =
                Attributes.SetBitRangeValue(0, 2, (ushort)value);
        }

        public RecordBatch.Timestamp TimestampType
        {
            get => (RecordBatch.Timestamp)Convert.ToByte(
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

        protected internal static async ValueTask<T> FromReaderAsync<T>(
            T recordBatch,
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default)
            where T : BaseRecordBatch
        {
            var size = asCompact
                ? (int)(await UVarInt
                    .FromReaderAsync(reader, true, cancellationToken)
                    .ConfigureAwait(false)).Value - 1
                : (int)await Int32.FromReaderAsync(reader, false, cancellationToken)
                    .ConfigureAwait(false);
            if (size < 0)
            {
                return recordBatch;
            }

            recordBatch.BaseOffset = await Int64.FromReaderAsync(reader, false,
                    cancellationToken)
                .ConfigureAwait(false);
            recordBatch.BatchLength = await Int32.FromReaderAsync(reader, false,
                    cancellationToken)
                .ConfigureAwait(false);
            recordBatch.PartitionLeaderEpoch = await Int32
                .FromReaderAsync(reader, false, cancellationToken)
                .ConfigureAwait(false);
            recordBatch.Magic = await Int8
                .FromReaderAsync(reader, false, cancellationToken)
                .ConfigureAwait(false);
            recordBatch.Crc = await UInt32
                .FromReaderAsync(reader, false, cancellationToken)
                .ConfigureAwait(false);

            var checksumReader = new ChecksumCalculatingPipeReader(reader);
            recordBatch.Attributes = await Int16.FromReaderAsync(checksumReader, false,
                    cancellationToken)
                .ConfigureAwait(false);
            recordBatch.LastOffsetDelta = await Int32
                .FromReaderAsync(checksumReader, false, cancellationToken)
                .ConfigureAwait(false);
            recordBatch.FirstTimestamp = await Int64
                .FromReaderAsync(checksumReader, false, cancellationToken)
                .ConfigureAwait(false);
            recordBatch.MaxTimestamp = await Int64
                .FromReaderAsync(checksumReader, false, cancellationToken)
                .ConfigureAwait(false);
            recordBatch.ProducerId = await Int64.FromReaderAsync(checksumReader, false,
                    cancellationToken)
                .ConfigureAwait(false);
            recordBatch.ProducerEpoch = await Int16
                .FromReaderAsync(checksumReader, false, cancellationToken)
                .ConfigureAwait(false);
            recordBatch.BaseSequence = await Int32
                .FromReaderAsync(checksumReader, false, cancellationToken)
                .ConfigureAwait(false);
            recordBatch.Records = await NullableArray<Record>.FromReaderAsync(
                    checksumReader, false,
                    () => Record.FromReaderAsync(checksumReader, false,
                        cancellationToken), cancellationToken)
                .ConfigureAwait(false);

            if (checksumReader.Checksum != recordBatch.Crc)
            {
                throw new CorruptMessageException(
                    $"Record batch is corrupt. The read data has crc {checksumReader.Checksum} but the record batch states that crc should be {recordBatch.Crc}");
            }

            var batchLength = recordBatch.GetBatchLength();
            if (batchLength != recordBatch.BatchLength)
            {
                throw new CorruptMessageException(
                    $"Expected batch length of {recordBatch.BatchLength} but the actual length is {recordBatch}");
            }

            var actualSize = recordBatch.PayloadSize();
            if (size != actualSize)
            {
                throw new CorruptMessageException($"Expected size {size} got {actualSize}");
            }

            return recordBatch;
        }

        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        internal async ValueTask WriteToAsync(
            Stream writer,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            var bytes = await SerializeCrcData(cancellationToken)
                .ConfigureAwait(false);
            // Batch length is not part of CRC so we can calculate CRC without the batch length being set
            Crc = Crc32C.Compute(bytes);
            // Batch length includes the length of the CRC so it needs to be calculated after CRC has been set
            BatchLength = GetBatchLength();

            var size = PayloadSize();
            if (asCompact)
            {
                UVarInt length = Records.Value == null ? 0 : (uint)size + 1;
                await length.WriteToAsync(writer, true, cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                Int32 length = Records.Value == null ? -1 : size;
                await length
                    .WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
            }

            if (Records.Value != null)
            {
                await BaseOffset
                    .WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await BatchLength
                    .WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await PartitionLeaderEpoch
                    .WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await Magic.WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await Crc.WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await writer.WriteAsync(bytes, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        internal int GetSize(bool asCompact)
        {
            var size = PayloadSize();
            return (asCompact
                       ? UVarInt.From(Records.Value == null ? 0 : (uint)size + 1).GetSize(true)
                       : Int32.From(Records.Value == null ? -1 : size).GetSize(false)) +
                   size;
        }

        private int PayloadSize() =>
            Records.Value == null
                ? 0
                : BaseOffset.GetSize(false) +
                  BatchLength.GetSize(false) +
                  PartitionLeaderEpoch.GetSize(false) +
                  Magic.GetSize(false) +
                  Crc.GetSize(false) +
                  Attributes.GetSize(false) +
                  LastOffsetDelta.GetSize(false) +
                  FirstTimestamp.GetSize(false) +
                  MaxTimestamp.GetSize(false) +
                  ProducerId.GetSize(false) +
                  ProducerEpoch.GetSize(false) +
                  BaseSequence.GetSize(false) +
                  NullableArray<Record>.From(Records)
                      .GetSize(false);

        private int GetBatchLength() =>
            Attributes.GetSize(false) +
            Crc.GetSize(false) +
            BaseSequence.GetSize(false) +
            FirstTimestamp.GetSize(false) +
            LastOffsetDelta.GetSize(false) +
            Magic.GetSize(false) +
            MaxTimestamp.GetSize(false) +
            PartitionLeaderEpoch.GetSize(false) +
            ProducerEpoch.GetSize(false) +
            Records.GetSize(false) +
            ProducerId.GetSize(false);

        private async ValueTask<byte[]> SerializeCrcData(CancellationToken cancellationToken)
        {
            var writer = new MemoryStream();
            await using (writer.ConfigureAwait(false))
            {
                await Attributes.WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await LastOffsetDelta.WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await FirstTimestamp.WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await MaxTimestamp.WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await ProducerId.WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await ProducerEpoch.WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
                await BaseSequence.WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);

                // todo: support compression
                await Records.WriteToAsync(writer, false, cancellationToken)
                    .ConfigureAwait(false);
             
                return writer.ToArray();
            }
        }
    }
}