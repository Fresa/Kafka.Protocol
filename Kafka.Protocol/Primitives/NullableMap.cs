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
    public partial struct NullableMap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private NullableArray<TValue> AsArray() =>
            NullableArray<TValue>.From(Value?.Values.ToArray());

        internal int GetSize(bool asCompact) =>
            AsArray()
                .GetSize(asCompact);
        
        internal ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default) =>
            AsArray()
                .WriteToAsync(writer, asCompact, cancellationToken);

        internal static async ValueTask<NullableMap<TKey, TValue>> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            Func<ValueTask<TValue>> createValue,
            Func<TValue, TKey> selectKey,
            CancellationToken cancellationToken = default) =>
            From((await NullableArray<TValue>
                    .FromReaderAsync(reader, asCompact, createValue,
                        cancellationToken)
                    .ConfigureAwait(false)).Value?
                .ToDictionary(selectKey) ?? Default);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() =>
            Value?.AsEnumerable()?.GetEnumerator() ??
            Enumerable.Empty<KeyValuePair<TKey, TValue>>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();
    }
}