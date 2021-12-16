using System;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

namespace Kafka.Protocol
{
    public interface IKafkaReader
    {
        ValueTask<Boolean> ReadBooleanAsync(
            CancellationToken cancellationToken = default);

        ValueTask<Int8> ReadInt8Async(
            CancellationToken cancellationToken = default);

        ValueTask<Int16> ReadInt16Async(
            CancellationToken cancellationToken = default);

        ValueTask<Int32> ReadInt32Async(
            CancellationToken cancellationToken = default);

        ValueTask<Int64> ReadInt64Async(
            CancellationToken cancellationToken = default);
        
        ValueTask<UInt16> ReadUInt16Async(
            CancellationToken cancellationToken = default);

        ValueTask<UInt32> ReadUInt32Async(
            CancellationToken cancellationToken = default);

        ValueTask<VarInt> ReadVarIntAsync(
            CancellationToken cancellationToken = default);

        ValueTask<UVarInt> ReadUVarIntAsync(
            CancellationToken cancellationToken = default);

        ValueTask<VarLong> ReadVarLongAsync(
            CancellationToken cancellationToken = default);
        
        ValueTask<Float64> ReadFloat64Async(
            CancellationToken cancellationToken = default);
        
        ValueTask<String> ReadStringAsync(
            VarInt length,
            CancellationToken cancellationToken = default);

        ValueTask<String> ReadStringAsync(
            CancellationToken cancellationToken = default);

        ValueTask<String?> ReadNullableStringAsync(
            CancellationToken cancellationToken = default);
        
        ValueTask<CompactString> ReadCompactStringAsync(
            CancellationToken cancellationToken = default);

        ValueTask<CompactString?> ReadCompactNullableStringAsync(
            CancellationToken cancellationToken = default);

        ValueTask<Bytes> ReadBytesAsync(
            VarInt length,
            CancellationToken cancellationToken = default);

        ValueTask<Bytes> ReadBytesAsync(
            CancellationToken cancellationToken = default);

        ValueTask<Bytes?> ReadNullableBytesAsync(
            CancellationToken cancellationToken = default);

        ValueTask<CompactBytes> ReadCompactBytesAsync(
            CancellationToken cancellationToken = default);

        ValueTask<CompactBytes?> ReadCompactNullableBytesAsync(
            CancellationToken cancellationToken = default);

        ValueTask<T[]> ReadArrayAsync<T>(
            VarInt numberOfItems,
            Func<ValueTask<T>> factory,
            CancellationToken cancellationToken = default)
            where T : ISerialize;
        
        ValueTask<T[]> ReadArrayAsync<T>(
            Func<ValueTask<T>> factory,
            CancellationToken cancellationToken = default)
            where T : ISerialize;

        ValueTask<T[]?> ReadNullableArrayAsync<T>(
            Func<ValueTask<T>> factory,
            CancellationToken cancellationToken = default)
            where T : ISerialize;

        ValueTask<RecordBatch> ReadRecordBatchAsync(
            CancellationToken cancellationToken = default);

        ValueTask<RecordBatch?> ReadNullableRecordBatchAsync(
            CancellationToken cancellationToken = default);

        ValueTask<Uuid> ReadUuidAsync(
            CancellationToken cancellationToken = default);
        
        IStreamLengthReport EnsureExpectedSize(in Int32 length);
    }
}