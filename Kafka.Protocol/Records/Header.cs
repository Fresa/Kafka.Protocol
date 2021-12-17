using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Records
{
    public class Header : ISerialize
    {
        public String Key { get; set; } = String.Default;
        public byte[] Value { get; set; } = Array.Empty<byte>();

        public static async ValueTask<Header> FromReaderAsync(
            IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            var keyLength = await reader
                .ReadVarIntAsync(cancellationToken)
                .ConfigureAwait(false);
            var header = new Header
            {
                Key = await reader.ReadStringAsync(
                        keyLength,
                        cancellationToken)
                    .ConfigureAwait(false)
            };
            var valueLength = await reader
                .ReadVarIntAsync(cancellationToken)
                .ConfigureAwait(false);
            header.Value = await reader.ReadBytesAsync(
                    valueLength,
                    cancellationToken)
                .ConfigureAwait(false);
            return header;
        }

        internal int Length =>
            Key.Value.Length.GetVarIntLength() + 
            Key.Value.Length + 
            Value.Length.GetVarIntLength() +
            Value.Length;

        public async ValueTask WriteToAsync(
            IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteVarIntAsync(Key.Value.Length, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteBytesAsync(Encoding.UTF8.GetBytes(Key), cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteVarIntAsync(Value.Length, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteBytesAsync(Value, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}