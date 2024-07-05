#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents a sequence of characters or null. For non-null strings, first the length N is given as an INT16. Then N bytes follow which are the UTF-8 encoding of the character sequence. A null value is encoded with length of -1 and there are no following bytes.</para>
    /// </summary>
    public readonly partial struct NullableString : ISerialize
    {
        public string? Value { get; }

        public NullableString(string? value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is NullableString comparingNullableString && this == comparingNullableString;
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;
        public override string ToString() => Value?.ToString() ?? string.Empty;
        public static bool operator ==(NullableString x, NullableString y) => x.Value == y.Value;
        public static bool operator !=(NullableString x, NullableString y) => !(x == y);
        public static implicit operator string? (NullableString value) => value.Value;
        public static implicit operator NullableString(string? value) => From(value);
        public static implicit operator String? (NullableString value) => value.Value == null ? null as String? : String.From(value.Value);
        public static implicit operator NullableString(String? value) => From(value?.Value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static NullableString From(string? value) => new NullableString(value);
        public static NullableString Default { get; } = From(default);
    }
}
