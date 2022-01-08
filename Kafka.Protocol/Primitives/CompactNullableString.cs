using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct CompactNullableString
    {
        public int GetSize() =>
            VarInt.From(Value == null ? 1 : (Value.Length + 1)).GetSize() +
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

            await writer.WriteAsLittleEndianAsync(Encoding.UTF8.GetBytes(Value),
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public static async ValueTask<CompactNullableString> FromReaderAsync(
            PipeReader reader,

            CancellationToken cancellationToken = default)
        {
            var length = (int)(await UVarInt.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false)).Value - 1;

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