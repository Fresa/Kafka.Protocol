using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface IKafkaReader
    {
        ValueTask<bool> ReadBooleanAsync(
            CancellationToken cancellationToken = default);

        ValueTask<sbyte> ReadInt8Async(
            CancellationToken cancellationToken = default);

        ValueTask<short> ReadInt16Async(
            CancellationToken cancellationToken = default);

        ValueTask<int> ReadInt32Async(
            CancellationToken cancellationToken = default);

        ValueTask<long> ReadInt64Async(
            CancellationToken cancellationToken = default);

        ValueTask<uint> ReadUInt32Async(
            CancellationToken cancellationToken = default);

        ValueTask<int> ReadVarIntAsync(
            CancellationToken cancellationToken = default);

        ValueTask<long> ReadVarLongAsync(
            CancellationToken cancellationToken = default);

        ValueTask<string> ReadStringAsync(
            CancellationToken cancellationToken = default);

        ValueTask<string?> ReadNullableStringAsync(
            CancellationToken cancellationToken = default);

        ValueTask<byte[]> ReadBytesAsync(
            CancellationToken cancellationToken = default);

        ValueTask<byte[]?> ReadNullableBytesAsync(
            CancellationToken cancellationToken = default);

        ValueTask<T[]?> ReadAsync<T>(Func<T> factory,
            CancellationToken cancellationToken = default)
            where T : ISerialize;
    }
}