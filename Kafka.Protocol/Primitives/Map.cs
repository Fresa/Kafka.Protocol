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
    public partial struct Map<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private Array<TValue> AsArray() =>
            Array<TValue>.From(Value.Values.ToArray());

        internal int GetSize(bool asCompact) =>
            AsArray()
                .GetSize(asCompact);

        internal ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default) =>
            AsArray()
                .WriteToAsync(writer, asCompact, cancellationToken);

        internal static async ValueTask<Map<TKey, TValue>> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            Func<ValueTask<TValue>> createValue,
            Func<TValue, TKey> selectKey,
            CancellationToken cancellationToken = default) =>
            From((await Array<TValue>
                    .FromReaderAsync(reader, asCompact, createValue,
                        cancellationToken)
                    .ConfigureAwait(false))
                .ToDictionary(selectKey));

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => 
            Value.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();

        public TValue this[TKey key] => Value[key];
    }
}