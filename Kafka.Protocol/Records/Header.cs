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

        public static async ValueTask<Header> FromReaderAsync(IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            return new Header
            {
                HeaderKeyLength = await reader.ReadVarIntAsync(cancellationToken),
                HeaderKey = await reader.ReadStringAsync(cancellationToken),
                HeaderValueLength = await reader.ReadVarIntAsync(cancellationToken),
                Value = await reader.ReadBytesAsync(cancellationToken)
            };
        }

        public async Task WriteToAsync(IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteVarIntAsync(HeaderKeyLength, cancellationToken);
            await writer.WriteStringAsync(HeaderKey, cancellationToken);
            await writer.WriteVarIntAsync(HeaderValueLength, cancellationToken);
            await writer.WriteBytesAsync(Value, cancellationToken);
        }
    }
}