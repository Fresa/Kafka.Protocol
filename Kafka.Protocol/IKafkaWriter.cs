using System;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

namespace Kafka.Protocol
{
    public interface IKafkaWriter : IAsyncDisposable
    {
        ValueTask WriteBooleanAsync(Boolean value, CancellationToken cancellationToken = default);
        ValueTask WriteInt8Async(Int8 value, CancellationToken cancellationToken = default);
        ValueTask WriteInt16Async(Int16 value, CancellationToken cancellationToken = default);
        ValueTask WriteInt32Async(Int32 value, CancellationToken cancellationToken = default);
        ValueTask WriteInt64Async(Int64 value, CancellationToken cancellationToken = default);
        ValueTask WriteUInt16Async(UInt16 value, CancellationToken cancellationToken = default);
        ValueTask WriteUInt32Async(UInt32 value, CancellationToken cancellationToken = default);
        ValueTask WriteVarIntAsync(VarInt value, CancellationToken cancellationToken = default);
        ValueTask WriteUVarIntAsync(UVarInt value, CancellationToken cancellationToken = default);
        ValueTask WriteVarLongAsync(VarLong value, CancellationToken cancellationToken = default);
        ValueTask WriteFloat64Async(Float64 value, CancellationToken cancellationToken = default);

        ValueTask WriteStringAsync(String value, CancellationToken cancellationToken = default);
        ValueTask WriteNullableStringAsync(String? value, CancellationToken cancellationToken = default);
        ValueTask WriteCompactStringAsync(String value, CancellationToken cancellationToken = default);
        ValueTask WriteCompactNullableStringAsync(String? value, CancellationToken cancellationToken);

        ValueTask WriteBytesAsync(Bytes value, CancellationToken cancellationToken = default);
        ValueTask WriteBytesAsync(byte[] value, CancellationToken cancellationToken = default);
        ValueTask WriteNullableBytesAsync(Bytes? value, CancellationToken cancellationToken = default);
        ValueTask WriteCompactBytesAsync(Bytes value, CancellationToken cancellationToken = default);
        ValueTask WriteCompactNullableBytesAsync(Bytes? value, CancellationToken cancellationToken = default);

        ValueTask WriteNullableArrayAsync<T>(CancellationToken cancellationToken = default, params T[]? items)
            where T : ISerialize;
        ValueTask WriteArrayAsync<T>(CancellationToken cancellationToken = default, params T[] items)
            where T : ISerialize;
        ValueTask WriteCompactArrayAsync<T>(CancellationToken cancellationToken = default, params T[] items)
            where T : ISerialize;
        ValueTask WriteCompactNullableArrayAsync<T>(CancellationToken cancellationToken = default, params T[]? items)
            where T : ISerialize;

        ValueTask WriteRecordBatchAsync(RecordBatch value,
            CancellationToken cancellationToken = default);
        ValueTask WriteNullableRecordBatchAsync(RecordBatch? value,
            CancellationToken cancellationToken = default);

        ValueTask WriteUuidAsync(Uuid value,
            CancellationToken cancellationToken = default);

    }
}