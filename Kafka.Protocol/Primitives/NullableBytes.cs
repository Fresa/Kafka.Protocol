using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct NullableBytes
    {
        public int GetSize() =>
            4 + (Value?.Length ?? 0);

        public async ValueTask WriteToAsync(Stream writer,
            CancellationToken cancellationToken = default)
        {
            Int32 length = Value?.Length ?? -1;
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

        public static async ValueTask<NullableBytes> FromReaderAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            var length = (int)await Int32.FromReaderAsync(reader, cancellationToken)
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