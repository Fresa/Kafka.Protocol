// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents an integer between -2^31 and 2^31-1 inclusive. Encoding follows the variable-length zig-zag encoding from  <a href="http://code.google.com/apis/protocolbuffers/docs/encoding.html"> Google Protocol Buffers</a>.</para>
    /// </summary>
    public readonly partial struct VarInt : ISerialize
    {
        public int Value { get; }

        public VarInt(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is VarInt comparingVarInt && this == comparingVarInt;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(VarInt x, VarInt y) => x.Value == y.Value;
        public static bool operator !=(VarInt x, VarInt y) => !(x == y);
        public static implicit operator int (VarInt value) => value.Value;
        public static implicit operator VarInt(int value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static VarInt From(int value) => new VarInt(value);
        public static VarInt Default { get; } = From(default);
    }
}
