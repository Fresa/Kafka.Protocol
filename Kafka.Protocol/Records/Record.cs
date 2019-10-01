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
        public Header[] Headers { get; set; } = new Header[0];

        public void ReadFrom(IKafkaReader reader)
        {
            Length = VarInt.From(reader.ReadVarInt());
            Attributes = Int8.From(reader.ReadInt8());
            TimestampDelta = VarInt.From(reader.ReadVarInt());
            OffsetDelta = VarInt.From(reader.ReadVarInt());
            KeyLength = VarInt.From(reader.ReadVarInt());
            Key = Bytes.From(reader.ReadBytes());
            ValueLen = VarInt.From(reader.ReadVarInt());
            Value = Bytes.From(reader.ReadBytes());
            Headers = reader.Read(() => new Header());
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