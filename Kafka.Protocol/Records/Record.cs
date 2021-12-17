using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Records
{
    public class Record : ISerialize
    {
        public Int8 Attributes { get; set; } = Int8.Default;
        public VarLong TimestampDelta { get; set; } = VarLong.Default;
        public VarInt OffsetDelta { get; set; } = VarInt.Default;
        public byte[] Key { get; set; } = Array.Empty<byte>();
        public byte[] Value { get; set; } = Array.Empty<byte>();
        public Header[] Headers { get; set; } = Array.Empty<Header>();

        public static async ValueTask<Record> FromReaderAsync(
            IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            var record = new Record
            {
                Attributes = await reader.ReadInt8Async(cancellationToken)
                    .ConfigureAwait(false),
                TimestampDelta = await reader
                    .ReadVarLongAsync(cancellationToken)
                    .ConfigureAwait(false),
                OffsetDelta = await reader.ReadVarIntAsync(cancellationToken)
                    .ConfigureAwait(false),
            };

            var keyLength = await reader.ReadVarIntAsync(cancellationToken)
                .ConfigureAwait(false);
            record.Key = await reader.ReadBytesAsync(
                    keyLength, 
                    cancellationToken)
                .ConfigureAwait(false);
            var valueLen = await reader.ReadVarIntAsync(cancellationToken)
                .ConfigureAwait(false);
            record.Value = await reader.ReadBytesAsync(
                    valueLen,
                    cancellationToken)
                .ConfigureAwait(false);
            var headerCount = await reader.ReadVarIntAsync(cancellationToken);
            record.Headers = await reader.ReadArrayAsync(
                    headerCount,
                    async ()
                        => await Header
                            .FromReaderAsync(reader, cancellationToken)
                            .ConfigureAwait(false),
                    cancellationToken)
                .ConfigureAwait(false);
            return record;
        }

        internal int Length =>
            1 +
            ((ulong)TimestampDelta.Value).GetVarIntLength() +
            OffsetDelta.Value.GetVarIntLength() +
            Key.Length.GetVarIntLength() +
            Key.Length +
            Value.Length.GetVarIntLength() +
            Value.Length +
            Headers.Sum(header => header.Length);

        public async ValueTask WriteToAsync(
            IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteVarIntAsync(Length, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteInt8Async(Attributes, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteVarLongAsync(TimestampDelta, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteVarIntAsync(OffsetDelta, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteVarIntAsync(Key.Length, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteBytesAsync(Key, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteVarIntAsync(Value.Length, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteBytesAsync(Value, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteArrayAsync(cancellationToken, Headers)
                .ConfigureAwait(false);
        }
    }
}