using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    internal static class StreamExtensions
    {
        internal static ValueTask WriteAsLittleEndianAsync(this Stream buffer, byte[] value, CancellationToken cancellationToken = default)
        {
            if (BitConverter.IsLittleEndian == false)
            {
                Array.Reverse(value);
            }

            return WriteAsync(buffer, value, cancellationToken);
        }

        internal static ValueTask WriteAsBigEndianAsync(this Stream buffer, byte[] value, CancellationToken cancellationToken = default)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(value);
            }

            return WriteAsync(buffer, value, cancellationToken);
        }

        private static ValueTask WriteAsync(this Stream buffer, byte[] value, CancellationToken cancellationToken = default)
        {
            if (value.Any() == false)
            {
                return default;
            }

            return buffer.WriteAsync(value.AsMemory(), cancellationToken);
        }
    }
}