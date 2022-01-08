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
    public partial struct Array<T> : IEnumerable<T>
    {
        public int GetSize() =>
            ((NullableArray<T>)Value).GetSize();

        public ValueTask WriteToAsync(Stream writer,
            CancellationToken cancellationToken = default) =>
            ((NullableArray<T>)Value).WriteToAsync(writer,
                cancellationToken);

        public static async ValueTask<Array<T>> FromReaderAsync(
            PipeReader reader,
            
            Func<ValueTask<T>> createItem,
            CancellationToken cancellationToken = default) =>
            (await NullableArray<T>
                .FromReaderAsync(reader, createItem,
                    cancellationToken)
                .ConfigureAwait(false)).Value ??
            throw new NotSupportedException(
                $"The array cannot be null. Consider changing to {nameof(NullableArray<T>)}");

        public IEnumerator<T> GetEnumerator() => 
            Value.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();
    }
}