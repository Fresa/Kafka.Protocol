using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct Array<T>
    {
        public int GetSize(bool asCompact) =>
            ((NullableArray<T>)Value).GetSize(asCompact);

        public ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default) =>
            ((NullableArray<T>)Value).WriteToAsync(writer, asCompact,
                cancellationToken);

        public static async ValueTask<Array<T>> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            Func<ValueTask<T>> createItem,
            CancellationToken cancellationToken = default) =>
            (await NullableArray<T>
                .FromReaderAsync(reader, asCompact, createItem,
                    cancellationToken)
                .ConfigureAwait(false)).Value ??
            throw new NotSupportedException(
                $"The array cannot be null. Consider changing to {nameof(NullableArray<T>)}");
    }
}