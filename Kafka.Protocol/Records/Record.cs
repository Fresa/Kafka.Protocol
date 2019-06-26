namespace Kafka.Protocol.Records
{
    public class Record
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
    }
}