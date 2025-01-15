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
    public partial struct Map<TKey, TValue> : IDictionary<TKey, TValue>
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

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => 
            Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();

        /// <inheritdoc />
        public void Add(TKey key, TValue value)
        {
            Value.Add(key, value);
        }

        /// <inheritdoc />
        public bool ContainsKey(TKey key)
        {
            return Value.ContainsKey(key);
        }

        /// <inheritdoc />
        public bool Remove(TKey key)
        {
            return Value.Remove(key);
        }

        /// <inheritdoc />
        public bool TryGetValue(TKey key, out TValue value)
        {
            return Value.TryGetValue(key, out value);
        }

        /// <inheritdoc />
        public TValue this[TKey key]
        {
            get => Value[key];
            set => Value[key] = value;
        }

        /// <inheritdoc />
        public ICollection<TKey> Keys => Value.Keys;

        /// <inheritdoc />
        public ICollection<TValue> Values => Value.Values;

        /// <inheritdoc />
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Value.Add(item.Key, item.Value);
        }

        /// <inheritdoc />
        public void Clear()
        {
            Value.Clear();
        }

        /// <inheritdoc />
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Value.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((IDictionary<TKey, TValue>)Value).CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Value.Remove(item.Key);
        }

        /// <inheritdoc />
        public int Count => Value.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;
    }
}