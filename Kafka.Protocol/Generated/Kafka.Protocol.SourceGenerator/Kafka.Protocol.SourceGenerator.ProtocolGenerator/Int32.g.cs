#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents an integer between -2^31 and 2^31-1 inclusive. The values are encoded using four bytes in network byte order (big-endian).</para>
    /// </summary>
    public readonly partial struct Int32 : ISerialize
    {
        public int Value { get; }

        public Int32(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is Int32 comparingInt32 && this == comparingInt32;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(Int32 x, Int32 y) => x.Value == y.Value;
        public static bool operator !=(Int32 x, Int32 y) => !(x == y);
        public static implicit operator int (Int32 value) => value.Value;
        public static implicit operator Int32(int value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static Int32 From(int value) => new Int32(value);
        public static Int32 Default { get; } = From(default);
    }
}
