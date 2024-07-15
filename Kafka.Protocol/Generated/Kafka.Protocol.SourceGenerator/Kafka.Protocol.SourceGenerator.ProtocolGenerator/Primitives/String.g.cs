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
    /// <para>Represents a sequence of characters. First the length N is given as an INT16. Then N bytes follow which are the UTF-8 encoding of the character sequence. Length must not be negative.</para>
    /// </summary>
    public readonly partial struct String : ISerialize
    {
        public string Value { get; }

        public String(string value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is String comparingString && this == comparingString;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(String x, String y) => x.Value == y.Value;
        public static bool operator !=(String x, String y) => !(x == y);
        public static implicit operator string (String value) => value.Value;
        public static implicit operator String(string value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static String From(string value) => new String(value);
        public static String Default { get; } = From(string.Empty);
    }
}
