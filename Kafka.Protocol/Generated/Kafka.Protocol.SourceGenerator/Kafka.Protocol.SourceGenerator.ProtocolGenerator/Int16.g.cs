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
    /// <para>Represents an integer between -2^15 and 2^15-1 inclusive. The values are encoded using two bytes in network byte order (big-endian).</para>
    /// </summary>
    public readonly partial struct Int16 : ISerialize
    {
        public short Value { get; }

        public Int16(short value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is Int16 comparingInt16 && this == comparingInt16;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(Int16 x, Int16 y) => x.Value == y.Value;
        public static bool operator !=(Int16 x, Int16 y) => !(x == y);
        public static implicit operator short (Int16 value) => value.Value;
        public static implicit operator Int16(short value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static Int16 From(short value) => new Int16(value);
        public static Int16 Default { get; } = From(default);
    }
}
