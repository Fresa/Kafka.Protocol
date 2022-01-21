using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct NullableBytes
    {
        internal int GetSize(bool asCompact) =>
            (asCompact
                ? VarInt.From(Value == null ? 1 : Value.Length + 1).GetSize(asCompact)
                : 4) + 
            (Value?.Length ?? 0);

        internal async ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default)
        {
            if (asCompact)
            {
                UVarInt length = Value == null ? 0 : (uint)Value.Length + 1;
                await length.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                Int32 length = Value?.Length ?? -1;
                await length.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
            }

            if (Value == null)
            {
                return;
            }

            await writer.WriteAsLittleEndianAsync(Value,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        internal static async ValueTask<NullableBytes> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            var length = asCompact
                ? (int)(await UVarInt.FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false)).Value - 1
                : (int)await Int32.FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false);

            if (length == -1)
            {
                return Default;
            }

            return
                await reader.ReadAsLittleEndianAsync(length, cancellationToken)
                    .ConfigureAwait(false);
        }
    }
}