using System;
using System.Threading;
using System.Threading.Tasks;

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

        ValueTask<UInt32> ReadUInt32Async(
            CancellationToken cancellationToken = default);

        ValueTask<VarInt> ReadVarIntAsync(
            CancellationToken cancellationToken = default);

        ValueTask<VarLong> ReadVarLongAsync(
            CancellationToken cancellationToken = default);

        ValueTask<String> ReadStringAsync(
            CancellationToken cancellationToken = default);

        ValueTask<String?> ReadNullableStringAsync(
            CancellationToken cancellationToken = default);

        ValueTask<Bytes> ReadBytesAsync(
            CancellationToken cancellationToken = default);

        ValueTask<Bytes?> ReadNullableBytesAsync(
            CancellationToken cancellationToken = default);

        ValueTask<T[]> ReadArrayAsync<T>(Func<ValueTask<T>> factory,
            CancellationToken cancellationToken = default)
            where T : ISerialize;

        ValueTask<T[]?> ReadNullableArrayAsync<T>(Func<ValueTask<T>> factory,
            CancellationToken cancellationToken = default)
            where T : ISerialize;
    }
}