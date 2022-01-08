using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct CompactBytes : IEnumerable<byte>
    {
        public int GetSize() =>
            ((CompactNullableBytes)Value).GetSize();

        public ValueTask WriteToAsync(Stream writer,
            CancellationToken cancellationToken = default) =>
            ((CompactNullableBytes)Value).WriteToAsync(writer,
                cancellationToken);

        public static async ValueTask<CompactBytes> FromReaderAsync(
            PipeReader reader,

            CancellationToken cancellationToken = default) =>
            (await CompactNullableBytes
                .FromReaderAsync(reader,
                    cancellationToken)
                .ConfigureAwait(false)).Value ??
            throw new NotSupportedException(
                $"The byte array cannot be null. Consider changing to {nameof(CompactNullableBytes)}");

        public IEnumerator<byte> GetEnumerator() =>
            Value.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}