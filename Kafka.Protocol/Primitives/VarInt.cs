using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct VarInt
    {
        internal int GetSize(bool asCompact) => ((VarLong)Value).GetSize(asCompact);

        internal ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default) =>
            ((VarLong)Value).WriteToAsync(writer, asCompact, cancellationToken);

        internal static async ValueTask<VarInt> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default) =>
            (int)await VarLong.FromReaderAsync(reader, asCompact, cancellationToken)
                .ConfigureAwait(false);
    }
}