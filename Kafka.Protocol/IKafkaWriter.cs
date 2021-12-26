using System;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

namespace Kafka.Protocol
{
    public interface IKafkaWriter : IAsyncDisposable
    {
        int SizeOfBoolean(Boolean value);
        ValueTask WriteBooleanAsync(Boolean value, CancellationToken cancellationToken = default);

        int SizeOfInt8(Int8 value);
        ValueTask WriteInt8Async(Int8 value, CancellationToken cancellationToken = default);

        int SizeOfInt16(Int16 value);
        ValueTask WriteInt16Async(Int16 value, CancellationToken cancellationToken = default);
        int SizeOfUInt16(UInt16 value);
        ValueTask WriteUInt16Async(UInt16 value, CancellationToken cancellationToken = default);

        int SizeOfInt32(Int32 value);
        ValueTask WriteInt32Async(Int32 value, CancellationToken cancellationToken = default);
        int SizeOfUInt32(UInt32 value);
        ValueTask WriteUInt32Async(UInt32 value, CancellationToken cancellationToken = default);

        int SizeOfInt64(Int64 value);
        ValueTask WriteInt64Async(Int64 value, CancellationToken cancellationToken = default);

        int SizeOfVarInt(VarInt value);
        ValueTask WriteVarIntAsync(VarInt value, CancellationToken cancellationToken = default);
        int SizeOfUVarInt(UVarInt value);
        ValueTask WriteUVarIntAsync(UVarInt value, CancellationToken cancellationToken = default);

        int SizeOfVarLong(VarLong value);
        ValueTask WriteVarLongAsync(VarLong value, CancellationToken cancellationToken = default);

        int SizeOfFloat64(Float64 value);
        ValueTask WriteFloat64Async(Float64 value, CancellationToken cancellationToken = default);

        int SizeOfString(String value);
        ValueTask WriteStringAsync(String value, CancellationToken cancellationToken = default);
        int SizeOfNullableString(String? value);
        ValueTask WriteNullableStringAsync(String? value, CancellationToken cancellationToken = default);
        int SizeOfCompactString(String value);
        ValueTask WriteCompactStringAsync(String value, CancellationToken cancellationToken = default);
        int SizeOfCompactNullableString(String? value);
        ValueTask WriteCompactNullableStringAsync(String? value, CancellationToken cancellationToken);

        int SizeOfBytes(Bytes value);
        ValueTask WriteBytesAsync(Bytes value, CancellationToken cancellationToken = default);
        ValueTask WriteBytesAsync(byte[] value, CancellationToken cancellationToken = default);
        int SizeOfNullableBytes(Bytes? value);
        ValueTask WriteNullableBytesAsync(Bytes? value, CancellationToken cancellationToken = default);
        int SizeOfCompactBytes(Bytes value);
        ValueTask WriteCompactBytesAsync(Bytes value, CancellationToken cancellationToken = default);
        int SizeOfCompactNullableBytes(Bytes? value);
        ValueTask WriteCompactNullableBytesAsync(Bytes? value, CancellationToken cancellationToken = default);

        int SizeOfArray<T>(params T[] items)
            where T : ISerialize;
        ValueTask WriteArrayAsync<T>(CancellationToken cancellationToken = default, params T[] items)
            where T : ISerialize;
        int SizeOfNullableArray<T>(params T[]? items)
            where T : ISerialize;
        ValueTask WriteNullableArrayAsync<T>(CancellationToken cancellationToken = default, params T[]? items)
            where T : ISerialize;
        int SizeOfCompactArray<T>(params T[] items)
            where T : ISerialize;
        ValueTask WriteCompactArrayAsync<T>(CancellationToken cancellationToken = default, params T[] items)
            where T : ISerialize;
        int SizeOfCompactNullableArray<T>(params T[]? items)
            where T : ISerialize;
        ValueTask WriteCompactNullableArrayAsync<T>(CancellationToken cancellationToken = default, params T[]? items)
            where T : ISerialize;

        int SizeOfRecordBatch(RecordBatch value);
        ValueTask WriteRecordBatchAsync(RecordBatch value,
            CancellationToken cancellationToken = default);
        int SizeOfNullableRecordBatch(RecordBatch? value);
        ValueTask WriteNullableRecordBatchAsync(RecordBatch? value,
            CancellationToken cancellationToken = default);

        int SizeOfUuid(Uuid value);
        ValueTask WriteUuidAsync(Uuid value,
            CancellationToken cancellationToken = default);

        int SizeOf(ISerialize item) => item.GetSize(this);
    }
}