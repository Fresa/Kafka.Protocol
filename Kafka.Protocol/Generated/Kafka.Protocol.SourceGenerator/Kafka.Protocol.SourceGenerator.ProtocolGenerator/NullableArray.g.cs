using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents a sequence of objects of a given type T. Type T can be either a primitive type (e.g. STRING) or a structure. First, the length N + 1 is given as an UNSIGNED_VARINT. Then N instances of type T follow. A null array is represented with a length of 0. In protocol documentation an array of T instances is referred to as [T].</para>
    /// </summary>
    public readonly partial struct NullableArray<T> : ISerialize where T : ISerialize
    {
        public T[]? Value { get; }

        public NullableArray(params T[]? value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is NullableArray<T> comparingNullableArray && this == comparingNullableArray;
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;
        public override string ToString() => Value?.ToString() ?? string.Empty;
        public static bool operator ==(NullableArray<T> x, NullableArray<T> y) => x.Value == y.Value;
        public static bool operator !=(NullableArray<T> x, NullableArray<T> y) => !(x == y);
        public static implicit operator T[]? (NullableArray<T> value) => value.Value;
        public static implicit operator NullableArray<T>(T[]? value) => From(value);
        public static implicit operator Array<T>? (NullableArray<T> value) => value.Value == null ? null as Array<T>? : Array<T>.From(value.Value);
        public static implicit operator NullableArray<T>(Array<T>? value) => From(value?.Value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static NullableArray<T> From(params T[]? value) => new NullableArray<T>(value);
        public static NullableArray<T> Default { get; } = From(default);
    }
}
