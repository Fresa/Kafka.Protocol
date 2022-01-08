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
    public partial struct CompactMap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private CompactArray<TValue> AsArray() =>
            CompactArray<TValue>.From(Value.Values.ToArray());

        public int GetSize() =>
            AsArray()
                .GetSize();

        public ValueTask WriteToAsync(Stream writer,
            CancellationToken cancellationToken = default) =>
            AsArray()
                .WriteToAsync(writer, cancellationToken);

        public static async ValueTask<CompactMap<TKey, TValue>> FromReaderAsync(
            PipeReader reader,

            Func<ValueTask<TValue>> createValue,
            Func<TValue, TKey> selectKey,
            CancellationToken cancellationToken = default) =>
            From((await CompactArray<TValue>
                    .FromReaderAsync(reader, createValue,
                        cancellationToken)
                    .ConfigureAwait(false))
                .ToDictionary(selectKey));

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() =>
            Value.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}