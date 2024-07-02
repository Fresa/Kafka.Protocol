using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Represents a type 4 immutable universally unique identifier (Uuid). The values are encoded using sixteen bytes in network byte order (big-endian).</para>
    /// </summary>
    public readonly partial struct Uuid : ISerialize
    {
        public Guid Value { get; }

        public Uuid(Guid value)
        {
            Value = value;
        }

        public override bool Equals(object obj) => obj is Uuid comparingUuid && this == comparingUuid;
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(Uuid x, Uuid y) => x.Value == y.Value;
        public static bool operator !=(Uuid x, Uuid y) => !(x == y);
        public static implicit operator Guid(Uuid value) => value.Value;
        public static implicit operator Uuid(Guid value) => From(value);
        int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
        public static Uuid From(Guid value) => new Uuid(value);
        public static Uuid Default { get; } = From(default);
    }
}
