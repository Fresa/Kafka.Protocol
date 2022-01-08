using System;
using System.IO;
using System.IO.Pipelines;
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
            PipeReader reader,
            
            CancellationToken cancellationToken = default)
        {
            var keyLength = await VarInt.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false);
            var key = Encoding.UTF8.GetString(await reader
                .ReadAsync(keyLength, cancellationToken)
                .ConfigureAwait(false));
            
            var valueLength = await VarInt.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false);
            var value = await reader.ReadAsync(
                    valueLength,
                    cancellationToken)
                .ConfigureAwait(false);
            
            return new Header
            {
                Key = key,
                Value = value
            };
        }
        
        public async ValueTask WriteToAsync(
            Stream writer,
            
            CancellationToken cancellationToken = default)
        {
            await VarInt.From(Key.Value.Length).WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteAsLittleEndianAsync(Encoding.UTF8.GetBytes(Key), cancellationToken)
                .ConfigureAwait(false);
            await VarInt.From(Value.Length).WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteAsLittleEndianAsync(Value, cancellationToken)
                .ConfigureAwait(false);
        }

        public int GetSize() =>
            VarInt.From(Key.Value.Length).GetSize() +
            Key.Value.Length +
            VarInt.From(Value.Length).GetSize() +
            Value.Length;
    }
}