using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct Uuid
    {
        internal int GetSize(bool asCompact) => 16;

        internal ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default)
        {
            Span<byte> buffer = stackalloc byte[16];
            Value.TryWriteBytes(buffer);

            return writer.WriteAsync(Reorder(buffer).ToArray(), cancellationToken);
        }

        internal static async ValueTask<Uuid> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            var bytes = await reader.ReadAsync(16, cancellationToken)
                .ConfigureAwait(false);

            return new Guid(Reorder(new Span<byte>(bytes)));
        }

        private static Span<byte> Reorder(Span<byte> buffer)
        {
            // The three first sections in a GUID is stored as little endian while the rest is big endian
            buffer[..4].Reverse();
            buffer[4..6].Reverse();
            buffer[6..8].Reverse();
            return buffer;
        }
    }
}