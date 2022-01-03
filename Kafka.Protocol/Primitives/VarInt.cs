using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct VarInt
    {
        public int GetSize(bool _ = false) => ((VarLong)Value).GetSize();

        public ValueTask WriteToAsync(Stream writer, bool _ = false,
            CancellationToken cancellationToken = default) =>
            ((VarLong)Value).WriteToAsync(writer, cancellationToken: cancellationToken);

        public static async ValueTask<VarInt> FromReaderAsync(PipeReader reader,
            CancellationToken cancellationToken = default) =>
            (int)await VarLong.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false);
    }
}