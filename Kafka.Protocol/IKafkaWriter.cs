using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface IKafkaWriter : IAsyncDisposable
    {
        Task WriteBooleanAsync(Boolean value, CancellationToken cancellationToken = default);
        Task WriteInt8Async(Int8 value, CancellationToken cancellationToken = default);
        Task WriteInt16Async(Int16 value, CancellationToken cancellationToken = default);
        Task WriteInt32Async(Int32 value, CancellationToken cancellationToken = default);
        Task WriteInt64Async(Int64 value, CancellationToken cancellationToken = default);
        Task WriteUInt32Async(UInt32 value, CancellationToken cancellationToken = default);

        Task WriteVarIntAsync(VarInt value, CancellationToken cancellationToken = default);
        Task WriteVarLongAsync(VarLong value, CancellationToken cancellationToken = default);

        Task WriteStringAsync(String value, CancellationToken cancellationToken = default);
        Task WriteNullableStringAsync(String? value, CancellationToken cancellationToken = default);
        
        Task WriteBytesAsync(Bytes value, CancellationToken cancellationToken = default);
        Task WriteNullableBytesAsync(Bytes? value, CancellationToken cancellationToken = default);

        Task WriteNullableArrayAsync<T>(CancellationToken cancellationToken, params T[]? items)
            where T : ISerialize;
        Task WriteArrayAsync<T>(CancellationToken cancellationToken, params T[] items)
            where T : ISerialize;
    }
}