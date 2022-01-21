using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct UVarInt
    {
        internal int GetSize(bool asCompact)
        {
            var value = Value;
            var length = 0;
            do
            {
                // Remove 7 bits
                value >>= 7;
                length++;
            } while (value > 0);

            return length;
        }

        internal ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default) =>
            writer.WriteAsLittleEndianAsync(
                Value
                    .EncodeAsVarInt(), cancellationToken);

        internal static async ValueTask<UVarInt> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            var more = true;
            uint value = 0;
            var shift = 0;
            while (more)
            {
                var lowerBits = (await reader
                    .ReadAsLittleEndianAsync(1, cancellationToken)
                    .ConfigureAwait(false)).First();

                more = (lowerBits & 128) != 0;
                value |= (uint)((lowerBits & 0x7f) << shift);
                shift += 7;
            }

            return value;
        }
    }
}