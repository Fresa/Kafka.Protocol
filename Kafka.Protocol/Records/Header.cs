namespace Kafka.Protocol.Records
{
    public class Header : ISerialize
    {
        public VarInt HeaderKeyLength { get; set; } = VarInt.Default;
        public String HeaderKey { get; set; } = String.Default;
        public VarInt HeaderValueLength { get; set; } = VarInt.Default;
        public Bytes Value { get; set; } = Bytes.Default;

        public void ReadFrom(IKafkaReader reader)
        {
            HeaderKeyLength = VarInt.From(reader.ReadVarInt());
            HeaderKey = String.From(reader.ReadString());
            HeaderValueLength = VarInt.From(reader.ReadVarInt());
            Value = Bytes.From(reader.ReadBytes());
        }

        public void WriteTo(IKafkaWriter writer)
        {
            writer.WriteVarInt(HeaderKeyLength.Value);
            writer.WriteString(HeaderKey.Value);
            writer.WriteVarInt(HeaderValueLength.Value);
            writer.WriteBytes(Value.Value);
        }
    }
}