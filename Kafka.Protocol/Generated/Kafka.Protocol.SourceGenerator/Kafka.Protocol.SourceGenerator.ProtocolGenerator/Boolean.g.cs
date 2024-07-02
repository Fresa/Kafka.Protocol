using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents a boolean value in a byte. Values 0 and 1 are used to represent false and true respectively. When reading a boolean value, any non-zero value is considered true.</para>
    /// </summary>
    public readonly partial struct Boolean : ISerialize
    {
        public bool Value { get; }

        public Boolean(bool value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is Boolean comparingBoolean && this == comparingBoolean;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(Boolean x, Boolean y) => x.Value == y.Value;
        public static bool operator !=(Boolean x, Boolean y) => !(x == y);
        public static implicit operator bool (Boolean value) => value.Value;
        public static implicit operator Boolean(bool value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static Boolean From(bool value) => new Boolean(value);
        public static Boolean Default { get; } = From(default);
    }
}
