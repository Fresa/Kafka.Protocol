using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct Bytes
    {
        public int GetSize(bool asCompact) =>
            ((NullableBytes)Value).GetSize(asCompact);

        public ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default) =>
            ((NullableBytes)Value).WriteToAsync(writer, asCompact,
                cancellationToken);

        public static async ValueTask<Bytes> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default) =>
            (await NullableBytes
                .FromReaderAsync(reader, asCompact,
                    cancellationToken)
                .ConfigureAwait(false)).Value ??
            throw new NotSupportedException(
                $"The byte array cannot be null. Consider changing to {nameof(NullableBytes)}");
    }
}