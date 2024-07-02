// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents a double-precision 64-bit format IEEE 754 value. The values are encoded using eight bytes in network byte order (big-endian).</para>
    /// </summary>
    public readonly partial struct Float64 : ISerialize
    {
        public double Value { get; }

        public Float64(double value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is Float64 comparingFloat64 && this == comparingFloat64;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(Float64 x, Float64 y) => x.Value == y.Value;
        public static bool operator !=(Float64 x, Float64 y) => !(x == y);
        public static implicit operator double (Float64 value) => value.Value;
        public static implicit operator Float64(double value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static Float64 From(double value) => new Float64(value);
        public static Float64 Default { get; } = From(default);
    }
}
