// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The UNSIGNED_VARINT type describes an unsigned variable length integer.</para>
    /// </summary>
    public readonly partial struct UVarInt : ISerialize
    {
        public uint Value { get; }

        public UVarInt(uint value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is UVarInt comparingUVarInt && this == comparingUVarInt;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(UVarInt x, UVarInt y) => x.Value == y.Value;
        public static bool operator !=(UVarInt x, UVarInt y) => !(x == y);
        public static implicit operator uint (UVarInt value) => value.Value;
        public static implicit operator UVarInt(uint value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static UVarInt From(uint value) => new UVarInt(value);
        public static UVarInt Default { get; } = From(default);
    }
}
