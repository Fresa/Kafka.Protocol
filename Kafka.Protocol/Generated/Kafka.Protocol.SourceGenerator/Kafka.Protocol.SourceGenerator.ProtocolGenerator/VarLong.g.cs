using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents an integer between -2^63 and 2^63-1 inclusive. Encoding follows the variable-length zig-zag encoding from  <a href="http://code.google.com/apis/protocolbuffers/docs/encoding.html"> Google Protocol Buffers</a>.</para>
    /// </summary>
    public readonly partial struct VarLong : ISerialize
    {
        public long Value { get; }

        public VarLong(long value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is VarLong comparingVarLong && this == comparingVarLong;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(VarLong x, VarLong y) => x.Value == y.Value;
        public static bool operator !=(VarLong x, VarLong y) => !(x == y);
        public static implicit operator long (VarLong value) => value.Value;
        public static implicit operator VarLong(long value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static VarLong From(long value) => new VarLong(value);
        public static VarLong Default { get; } = From(default);
    }
}
