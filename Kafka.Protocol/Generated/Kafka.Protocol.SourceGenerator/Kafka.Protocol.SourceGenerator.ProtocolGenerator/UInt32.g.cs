// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents an integer between 0 and 2^32-1 inclusive. The values are encoded using four bytes in network byte order (big-endian).</para>
    /// </summary>
    public readonly partial struct UInt32 : ISerialize
    {
        public uint Value { get; }

        public UInt32(uint value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is UInt32 comparingUInt32 && this == comparingUInt32;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(UInt32 x, UInt32 y) => x.Value == y.Value;
        public static bool operator !=(UInt32 x, UInt32 y) => !(x == y);
        public static implicit operator uint (UInt32 value) => value.Value;
        public static implicit operator UInt32(uint value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static UInt32 From(uint value) => new UInt32(value);
        public static UInt32 Default { get; } = From(default);
    }
}
