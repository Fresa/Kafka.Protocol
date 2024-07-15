#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents a raw sequence of bytes or null. For non-null values, first the length N is given as an INT32. Then N bytes follow. A null value is encoded with length of -1 and there are no following bytes.</para>
    /// </summary>
    public readonly partial struct NullableBytes : ISerialize
    {
        public byte[]? Value { get; }

        public NullableBytes(params byte[]? value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is NullableBytes comparingNullableBytes && this == comparingNullableBytes;
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;
        public override string ToString() => Value?.ToString() ?? string.Empty;
        public static bool operator ==(NullableBytes x, NullableBytes y) => x.Value == y.Value;
        public static bool operator !=(NullableBytes x, NullableBytes y) => !(x == y);
        public static implicit operator byte[]? (NullableBytes value) => value.Value;
        public static implicit operator NullableBytes(byte[]? value) => From(value);
        public static implicit operator Bytes? (NullableBytes value) => value.Value == null ? null as Bytes? : Bytes.From(value.Value);
        public static implicit operator NullableBytes(Bytes? value) => From(value?.Value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static NullableBytes From(params byte[]? value) => new NullableBytes(value);
        public static NullableBytes Default { get; } = From(default);
    }
}
