using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Records
{
    public class Record : ISerialize
    {
        public VarInt Length { get; set; } = VarInt.Default;
        public Int8 Attributes { get; set; } = Int8.Default;
        public VarInt TimestampDelta { get; set; } = VarInt.Default;
        public VarInt OffsetDelta { get; set; } = VarInt.Default;
        public VarInt KeyLength { get; set; } = VarInt.Default;
        public Bytes Key { get; set; } = Bytes.Default;
        public VarInt ValueLen { get; set; } = VarInt.Default;
        public Bytes Value { get; set; } = Bytes.Default;
        public Header[]? Headers { get; set; } = new Header[0];

        public static async ValueTask<Record> FromReaderAsync(
            IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            return new Record
            {
                Length = await reader.ReadVarIntAsync(cancellationToken)
                    .ConfigureAwait(false),
                Attributes = await reader.ReadInt8Async(cancellationToken)
                    .ConfigureAwait(false),
                TimestampDelta = await reader.ReadVarIntAsync(cancellationToken)
                    .ConfigureAwait(false),
                OffsetDelta = await reader.ReadVarIntAsync(cancellationToken)
                    .ConfigureAwait(false),
                KeyLength = await reader.ReadVarIntAsync(cancellationToken)
                    .ConfigureAwait(false),
                Key = await reader.ReadBytesAsync(cancellationToken)
                    .ConfigureAwait(false),
                ValueLen = await reader.ReadVarIntAsync(cancellationToken)
                    .ConfigureAwait(false),
                Value = await reader.ReadBytesAsync(cancellationToken)
                    .ConfigureAwait(false),
                Headers = await reader.ReadArrayAsync(
                        async ()
                            => await Header
                                .FromReaderAsync(reader, cancellationToken)
                                .ConfigureAwait(false),
                        cancellationToken)
                    .ConfigureAwait(false)
            };
        }

        public async ValueTask WriteToAsync(
            IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteVarIntAsync(Length, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteInt8Async(Attributes, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteVarIntAsync(TimestampDelta, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteVarIntAsync(OffsetDelta, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteVarIntAsync(KeyLength, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteBytesAsync(Key, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteVarIntAsync(ValueLen, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteBytesAsync(Value, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteNullableArrayAsync(cancellationToken, Headers)
                .ConfigureAwait(false);
        }
    }
}