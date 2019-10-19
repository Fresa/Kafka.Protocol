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
                HeaderKeyLength = VarInt.From(await reader.ReadVarIntAsync(cancellationToken)),
                HeaderKey = String.From(await reader.ReadStringAsync(cancellationToken)),
                HeaderValueLength = VarInt.From(await reader.ReadVarIntAsync(cancellationToken)),
                Value = Bytes.From(await reader.ReadBytesAsync(cancellationToken))
            };
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