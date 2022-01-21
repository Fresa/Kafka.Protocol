using System;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct Int8
    {
        internal int GetSize(bool asCompact) => 1;

        internal ValueTask WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken = default) =>
            writer.WriteAsLittleEndianAsync(new[] { (byte)Value }, cancellationToken);

        internal static async ValueTask<Int8> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default) =>
            Convert.ToSByte(
                (await reader.ReadAsLittleEndianAsync(1, cancellationToken)
                    .ConfigureAwait(false))
                .First());
    }
}