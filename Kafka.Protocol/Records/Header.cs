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
            var header = new Header
            {
                HeaderKeyLength = await reader
                    .ReadVarIntAsync(cancellationToken)
                    .ConfigureAwait(false)
            };
            header.HeaderKey = await reader.ReadStringAsync(
                    header.HeaderKeyLength,
                    cancellationToken)
                .ConfigureAwait(false);
            header.HeaderValueLength = await reader
                .ReadVarIntAsync(cancellationToken)
                .ConfigureAwait(false);
            header.Value = await reader.ReadBytesAsync(
                    header.HeaderValueLength,
                    cancellationToken)
                .ConfigureAwait(false);
            return header;
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