using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents an integer between -2^7 and 2^7-1 inclusive.</para>
    /// </summary>
    public readonly partial struct Int8 : ISerialize
    {
        public sbyte Value { get; }

        public Int8(sbyte value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is Int8 comparingInt8 && this == comparingInt8;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(Int8 x, Int8 y) => x.Value == y.Value;
        public static bool operator !=(Int8 x, Int8 y) => !(x == y);
        public static implicit operator sbyte (Int8 value) => value.Value;
        public static implicit operator Int8(sbyte value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static Int8 From(sbyte value) => new Int8(value);
        public static Int8 Default { get; } = From(default);
    }
}
