using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public partial struct CompactNullableBytes
    {
        public int GetSize() =>
            VarInt.From(Value == null ? 1 : Value.Length + 1).GetSize() +
            (Value?.Length ?? 0);

        public async ValueTask WriteToAsync(Stream writer,
            CancellationToken cancellationToken = default)
        {
            UVarInt length = Value == null ? 0 : (uint)Value.Length + 1;
            await length.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);

            if (Value == null)
            {
                return;
            }

            await writer.WriteAsLittleEndianAsync(Value,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public static async ValueTask<CompactNullableBytes> FromReaderAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            var length = (int)(await UVarInt.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false)).Value - 1;

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