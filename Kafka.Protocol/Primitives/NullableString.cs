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
        public int GetSize() =>
            2 + (Value?.Length ?? 0);

        public async ValueTask WriteToAsync(Stream writer,
            CancellationToken cancellationToken = default)
        {
            if (Value == null)
            {
                await Int16.From(-1)
                    .WriteToAsync(writer, cancellationToken)
                    .ConfigureAwait(false);
                return;
            }

            var bytes = Encoding.UTF8.GetBytes(Value);

            if (bytes.Length > short.MaxValue)
            {
                throw new SyntaxErrorException($"value is to long. Max length: {short.MaxValue}. Current value length: {bytes.Length}");
            }

            await ((Int16)bytes.Length).WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteAsLittleEndianAsync(bytes, cancellationToken)
                .ConfigureAwait(false);
        }

        public static async ValueTask<NullableString> FromReaderAsync(
            PipeReader reader,

            CancellationToken cancellationToken = default)
        {
            var length = await Int16.FromReaderAsync(reader, cancellationToken)
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