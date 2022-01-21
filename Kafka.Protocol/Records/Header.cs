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

        internal static async ValueTask<Header> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            var keyLength = await VarInt.FromReaderAsync(reader, asCompact, cancellationToken)
                .ConfigureAwait(false);
            var key = Encoding.UTF8.GetString(await reader
                .ReadAsync(keyLength, cancellationToken)
                .ConfigureAwait(false));
            
            var valueLength = await VarInt.FromReaderAsync(reader, asCompact, cancellationToken)
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

        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken = default) => WriteToAsync(writer, asCompact, cancellationToken);
        internal async ValueTask WriteToAsync(
            Stream writer,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            await VarInt.From(Key.Value.Length).WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteAsLittleEndianAsync(Encoding.UTF8.GetBytes(Key), cancellationToken)
                .ConfigureAwait(false);
            await VarInt.From(Value.Length).WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteAsLittleEndianAsync(Value, cancellationToken)
                .ConfigureAwait(false);
        }

        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        internal int GetSize(bool asCompact) =>
            VarInt.From(Key.Value.Length).GetSize(asCompact) +
            Key.Value.Length +
            VarInt.From(Value.Length).GetSize(asCompact) +
            Value.Length;
    }
}