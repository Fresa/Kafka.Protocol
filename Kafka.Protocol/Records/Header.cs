using System.Threading;
using System.Threading.Tasks;

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

        public async Task WriteToAsync(IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteVarIntAsync(HeaderKeyLength.Value, cancellationToken);
            await writer.WriteStringAsync(HeaderKey.Value, cancellationToken);
            await writer.WriteVarIntAsync(HeaderValueLength.Value, cancellationToken);
            await writer.WriteBytesAsync(Value.Value, cancellationToken);
        }
    }
}