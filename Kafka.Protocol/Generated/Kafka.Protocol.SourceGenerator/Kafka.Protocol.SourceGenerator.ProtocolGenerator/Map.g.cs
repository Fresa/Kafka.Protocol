using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents a sequence of objects with a map key.</para>
    /// </summary>
    public readonly partial struct Map<TKey, TValue> : ISerialize where TKey : ISerialize where TValue : ISerialize
    {
        public Dictionary<TKey, TValue> Value { get; }

        public Map(Dictionary<TKey, TValue> value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is Map<TKey, TValue> comparingMap && this == comparingMap;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(Map<TKey, TValue> x, Map<TKey, TValue> y) => x.Value == y.Value;
        public static bool operator !=(Map<TKey, TValue> x, Map<TKey, TValue> y) => !(x == y);
        public static implicit operator Dictionary<TKey, TValue>(Map<TKey, TValue> value) => value.Value;
        public static implicit operator Map<TKey, TValue>(Dictionary<TKey, TValue> value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static Map<TKey, TValue> From(Dictionary<TKey, TValue> value) => new Map<TKey, TValue>(value);
        public static Map<TKey, TValue> Default { get; } = From(new Dictionary<TKey, TValue>());
    }
}
