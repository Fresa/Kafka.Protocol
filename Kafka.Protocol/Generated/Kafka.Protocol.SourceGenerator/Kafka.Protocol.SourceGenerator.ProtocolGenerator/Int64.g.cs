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
    /// <para>Represents an integer between -2^63 and 2^63-1 inclusive. The values are encoded using eight bytes in network byte order (big-endian).</para>
    /// </summary>
    public readonly partial struct Int64 : ISerialize
    {
        public long Value { get; }

        public Int64(long value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is Int64 comparingInt64 && this == comparingInt64;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(Int64 x, Int64 y) => x.Value == y.Value;
        public static bool operator !=(Int64 x, Int64 y) => !(x == y);
        public static implicit operator long (Int64 value) => value.Value;
        public static implicit operator Int64(long value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static Int64 From(long value) => new Int64(value);
        public static Int64 Default { get; } = From(default);
    }
}
