using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents a sequence of objects of a given type T. Type T can be either a primitive type (e.g. STRING) or a structure. First, the length N is given as an INT32. Then N instances of type T follow. A null array is represented with a length of -1. In protocol documentation an array of T instances is referred to as [T].</para>
    /// </summary>
    public readonly partial struct Array<T> : ISerialize where T : ISerialize
    {
        public T[] Value { get; }

        public Array(params T[] value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is Array<T> comparingArray && this == comparingArray;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(Array<T> x, Array<T> y) => x.Value == y.Value;
        public static bool operator !=(Array<T> x, Array<T> y) => !(x == y);
        public static implicit operator T[](Array<T> value) => value.Value;
        public static implicit operator Array<T>(T[] value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static Array<T> From(params T[] value) => new Array<T>(value);
        public static Array<T> Default { get; } = From(System.Array.Empty<T>());
    }
}
