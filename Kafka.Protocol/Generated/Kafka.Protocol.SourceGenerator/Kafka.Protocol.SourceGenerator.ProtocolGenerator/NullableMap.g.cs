using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol;

namespace Kafka.Protocol2
{
    /// <summary>
    /// <para>Represents a nullable sequence of objects with a map key.</para>
    /// </summary>
    public readonly partial struct NullableMap<TKey, TValue> : ISerialize where TKey : ISerialize where TValue : ISerialize
    {
        public Dictionary<TKey, TValue>? Value { get; }

        public NullableMap(Dictionary<TKey, TValue>? value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is NullableMap<TKey, TValue> comparingNullableMap && this == comparingNullableMap;
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;
        public override string ToString() => Value?.ToString() ?? string.Empty;
        public static bool operator ==(NullableMap<TKey, TValue> x, NullableMap<TKey, TValue> y) => x.Value == y.Value;
        public static bool operator !=(NullableMap<TKey, TValue> x, NullableMap<TKey, TValue> y) => !(x == y);
        public static implicit operator Dictionary<TKey, TValue>? (NullableMap<TKey, TValue> value) => value.Value;
        public static implicit operator NullableMap<TKey, TValue>(Dictionary<TKey, TValue>? value) => From(value);
        public static implicit operator Map<TKey, TValue>? (NullableMap<TKey, TValue> value) => value.Value == null ? null as Map<TKey, TValue>? : Map<TKey, TValue>.From(value.Value);
        public static implicit operator NullableMap<TKey, TValue>(Map<TKey, TValue>? value) => From(value?.Value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static NullableMap<TKey, TValue> From(Dictionary<TKey, TValue>? value) => new NullableMap<TKey, TValue>(value);
        public static NullableMap<TKey, TValue> Default { get; } = From(default);
    }
}
