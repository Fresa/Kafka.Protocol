// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents a raw sequence of bytes. First the length N is given as an INT32. Then N bytes follow.</para>
    /// </summary>
    public readonly partial struct Bytes : ISerialize
    {
        public byte[] Value { get; }

        public Bytes(params byte[] value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is Bytes comparingBytes && this == comparingBytes;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(Bytes x, Bytes y) => x.Value == y.Value;
        public static bool operator !=(Bytes x, Bytes y) => !(x == y);
        public static implicit operator byte[](Bytes value) => value.Value;
        public static implicit operator Bytes(byte[] value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static Bytes From(params byte[] value) => new Bytes(value);
        public static Bytes Default { get; } = From(System.Array.Empty<byte>());
    }
}
