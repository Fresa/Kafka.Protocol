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

        public static async ValueTask<Record> FromReaderAsync(IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            return new Record
            {
                Length = await reader.ReadVarIntAsync(cancellationToken),
                Attributes = await reader.ReadInt8Async(cancellationToken),
                TimestampDelta = await reader.ReadVarIntAsync(cancellationToken),
                OffsetDelta = await reader.ReadVarIntAsync(cancellationToken),
                KeyLength = await reader.ReadVarIntAsync(cancellationToken),
                Key = await reader.ReadBytesAsync(cancellationToken),
                ValueLen = await reader.ReadVarIntAsync(cancellationToken),
                Value = await reader.ReadBytesAsync(cancellationToken),
                Headers = await reader.ReadArrayAsync(async () => await Header.FromReaderAsync(reader, cancellationToken),
                cancellationToken)
            };
        }

        public async ValueTask WriteToAsync(IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteVarIntAsync(Length, cancellationToken);
            await writer.WriteInt8Async(Attributes, cancellationToken);
            await writer.WriteVarIntAsync(TimestampDelta, cancellationToken);
            await writer.WriteVarIntAsync(OffsetDelta, cancellationToken);
            await writer.WriteVarIntAsync(KeyLength, cancellationToken);
            await writer.WriteBytesAsync(Key, cancellationToken);
            await writer.WriteVarIntAsync(ValueLen, cancellationToken);
            await writer.WriteBytesAsync(Value, cancellationToken);
            await writer.WriteNullableArrayAsync(cancellationToken, Headers);
        }
    }
}