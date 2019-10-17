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

        public async ValueTask ReadFromAsync(IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            Length = VarInt.From(await reader.ReadVarIntAsync(cancellationToken));
            Attributes = Int8.From(await reader.ReadInt8Async(cancellationToken));
            TimestampDelta = VarInt.From(await reader.ReadVarIntAsync(cancellationToken));
            OffsetDelta = VarInt.From(await reader.ReadVarIntAsync(cancellationToken));
            KeyLength = VarInt.From(await reader.ReadVarIntAsync(cancellationToken));
            Key = Bytes.From(await reader.ReadBytesAsync(cancellationToken));
            ValueLen = VarInt.From(await reader.ReadVarIntAsync(cancellationToken));
            Value = Bytes.From(await reader.ReadBytesAsync(cancellationToken));
            Headers = await reader.ReadAsync(() => new Header(), cancellationToken);
        }

        public async Task WriteToAsync(IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteVarIntAsync(Length.Value, cancellationToken);
            await writer.WriteInt8Async(Attributes.Value, cancellationToken);
            await writer.WriteVarIntAsync(TimestampDelta.Value, cancellationToken);
            await writer.WriteVarIntAsync(OffsetDelta.Value, cancellationToken);
            await writer.WriteVarIntAsync(KeyLength.Value, cancellationToken);
            await writer.WriteBytesAsync(Key.Value, cancellationToken);
            await writer.WriteVarIntAsync(ValueLen.Value, cancellationToken);
            await writer.WriteBytesAsync(Value.Value, cancellationToken);
            await writer.WriteAsync(cancellationToken, Headers);
        }
    }
}