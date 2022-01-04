using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    internal static class PipeReaderExtensions
    {
        internal static async ValueTask<byte[]> ReadAsLittleEndianAsync(
            this PipeReader reader,
            int length,
            CancellationToken cancellationToken = default)
        {
            var bytes = await ReadAsync(reader, length, cancellationToken)
                .ConfigureAwait(false);
            if (BitConverter.IsLittleEndian == false)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }

        internal static async ValueTask<byte[]> ReadAsBigEndianAsync(
            this PipeReader reader,
            int length,
            CancellationToken cancellationToken = default)
        {
            var bytes = await ReadAsync(reader, length, cancellationToken)
                .ConfigureAwait(false);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }

        internal static async ValueTask<byte[]> ReadAsync(
            this PipeReader reader,
            int length,
            CancellationToken cancellationToken = default)
        {
            if (length <= 0)
            {
                return Array.Empty<byte>();
            }

            var bufferWriter = new ArrayBufferWriter<byte>(length);

            ReadResult result;
            do
            {
                result = await reader.ReadAsync(cancellationToken)
                    .ConfigureAwait(false);
                var buffer = result.Buffer.Slice(
                    0, Math.Min(bufferWriter.FreeCapacity, result.Buffer.Length));
                buffer.CopyTo(bufferWriter.GetSpan());
                bufferWriter.Advance((int)buffer.Length);

                reader.AdvanceTo(buffer.End);
            } while (result.HasMoreData() && bufferWriter.WrittenCount < length);

            if (bufferWriter.WrittenCount < length)
            {
                throw new InvalidOperationException(
                    $"Expected {length} bytes, got {bufferWriter.WrittenCount}");
            }

            return bufferWriter.WrittenMemory.ToArray();
        }
    }
}