namespace Kafka.Protocol.Records
{
    public class Record : ISerialize
    {
        public VarInt Length { get; set; } = VarInt.Default;
        public Int8 Attributes { get; set; } = Int8.Default;
        public VarInt TimestampDelta { get; set; } = VarInt.Default;
        public VarInt OffsetDelta { get; set; } = VarInt.Default;
        public VarInt KeyLength { get; set; } = VarInt.Default;
        public Bytes Bytes { get; set; } = Bytes.Default;
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
            Bytes = Bytes.From(reader.ReadBytes());
            ValueLen = VarInt.From(reader.ReadVarInt());
            Value = Bytes.From(reader.ReadBytes());
            Headers = reader.Read(() => new Header());
        }

        public void WriteTo(IKafkaWriter writer)
        {
            writer.WriteVarInt(Length.Value);
            writer.WriteInt8(Attributes.Value);
            writer.WriteVarInt(TimestampDelta.Value);
            writer.WriteVarInt(OffsetDelta.Value);
            writer.WriteVarInt(KeyLength.Value);
            writer.WriteBytes(Bytes.Value);
            writer.WriteVarInt(ValueLen.Value);
            writer.WriteBytes(Value.Value);
            writer.Write(Headers);
        }
    }
}