using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface IKafkaWriter : IAsyncDisposable
    {
        ValueTask WriteBooleanAsync(Boolean value, CancellationToken cancellationToken = default);
        ValueTask WriteInt8Async(Int8 value, CancellationToken cancellationToken = default);
        ValueTask WriteInt16Async(Int16 value, CancellationToken cancellationToken = default);
        ValueTask WriteInt32Async(Int32 value, CancellationToken cancellationToken = default);
        ValueTask WriteInt64Async(Int64 value, CancellationToken cancellationToken = default);
        ValueTask WriteUInt32Async(UInt32 value, CancellationToken cancellationToken = default);

        ValueTask WriteVarIntAsync(VarInt value, CancellationToken cancellationToken = default);
        ValueTask WriteVarLongAsync(VarLong value, CancellationToken cancellationToken = default);

        ValueTask WriteStringAsync(String value, CancellationToken cancellationToken = default);
        ValueTask WriteNullableStringAsync(String? value, CancellationToken cancellationToken = default);
        
        ValueTask WriteBytesAsync(Bytes value, CancellationToken cancellationToken = default);
        ValueTask WriteNullableBytesAsync(Bytes? value, CancellationToken cancellationToken = default);

        ValueTask WriteNullableArrayAsync<T>(CancellationToken cancellationToken, params T[]? items)
            where T : ISerialize;
        ValueTask WriteArrayAsync<T>(CancellationToken cancellationToken, params T[] items)
            where T : ISerialize;
    }
}