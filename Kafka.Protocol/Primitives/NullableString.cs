using System.Data;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct NullableString
    {
        internal int GetSize(bool asCompact) =>
            (asCompact
                ? VarInt.From(Value == null ? 1 : (Value.Length + 1)).GetSize(asCompact)
                : 2) + 
            (Value?.Length ?? 0);

        internal async ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default)
        {
            if (asCompact)
            {
                UVarInt length = Value == null ? 0 : (uint)Value.Length + 1;
                await length.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);

                if (Value == null)
                {
                    return;
                }

                await writer.WriteAsLittleEndianAsync(Encoding.UTF8.GetBytes(Value),
                        cancellationToken)
                    .ConfigureAwait(false);
                return;
            }

            if (Value == null)
            {
                await Int16.From(-1)
                    .WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
                return;
            }

            var bytes = Encoding.UTF8.GetBytes(Value);

            if (bytes.Length > short.MaxValue)
            {
                throw new SyntaxErrorException($"value is to long. Max length: {short.MaxValue}. Current value length: {bytes.Length}");
            }

            await ((Int16)bytes.Length).WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteAsLittleEndianAsync(bytes, cancellationToken)
                .ConfigureAwait(false);
        }

        internal static async ValueTask<NullableString> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            var length = asCompact
                ? (int)(await UVarInt.FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false)).Value - 1
                : await Int16.FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false);
            
            if (length == -1)
            {
                return Default;
            }

            var bytes = await reader.ReadAsLittleEndianAsync(length, cancellationToken)
                .ConfigureAwait(false);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}