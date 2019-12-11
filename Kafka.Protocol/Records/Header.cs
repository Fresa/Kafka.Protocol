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

        public static async ValueTask<Header> FromReaderAsync(
            IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            return new Header
            {
                HeaderKeyLength = await reader
                    .ReadVarIntAsync(cancellationToken)
                    .ConfigureAwait(false),
                HeaderKey = await reader.ReadStringAsync(cancellationToken)
                    .ConfigureAwait(false),
                HeaderValueLength = await reader
                    .ReadVarIntAsync(cancellationToken)
                    .ConfigureAwait(false),
                Value = await reader.ReadBytesAsync(cancellationToken)
                    .ConfigureAwait(false)
            };
        }

        public async ValueTask WriteToAsync(
            IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteVarIntAsync(HeaderKeyLength, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteStringAsync(HeaderKey, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteVarIntAsync(HeaderValueLength, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteBytesAsync(Value, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}