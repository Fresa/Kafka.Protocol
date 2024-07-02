// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents an integer between 0 and 2^16-1 inclusive. The values are encoded using four bytes in network byte order (big-endian).</para>
    /// </summary>
    public readonly partial struct UInt16 : ISerialize
    {
        public ushort Value { get; }

        public UInt16(ushort value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is UInt16 comparingUInt16 && this == comparingUInt16;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(UInt16 x, UInt16 y) => x.Value == y.Value;
        public static bool operator !=(UInt16 x, UInt16 y) => !(x == y);
        public static implicit operator ushort (UInt16 value) => value.Value;
        public static implicit operator UInt16(ushort value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static UInt16 From(ushort value) => new UInt16(value);
        public static UInt16 Default { get; } = From(default);
    }
}
