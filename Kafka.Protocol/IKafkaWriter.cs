using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface IKafkaWriter : IAsyncDisposable
    {
        Task WriteBooleanAsync(bool value, CancellationToken cancellationToken = default);
        Task WriteInt8Async(sbyte value, CancellationToken cancellationToken = default);
        Task WriteInt16Async(short value, CancellationToken cancellationToken = default);
        Task WriteInt32Async(int value, CancellationToken cancellationToken = default);
        Task WriteInt64Async(long value, CancellationToken cancellationToken = default);
        Task WriteUInt32Async(uint value, CancellationToken cancellationToken = default);

        Task WriteVarIntAsync(int value, CancellationToken cancellationToken = default);
        Task WriteVarLongAsync(long value, CancellationToken cancellationToken = default);

        Task WriteStringAsync(string value, CancellationToken cancellationToken = default);
        Task WriteNullableStringAsync(string? value, CancellationToken cancellationToken = default);

        Task WriteBytesAsync(byte[] value, CancellationToken cancellationToken = default);
        Task WriteNullableBytesAsync(byte[]? value, CancellationToken cancellationToken = default);

        Task WriteAsync<T>(CancellationToken cancellationToken, params T[]? items)
            where T : ISerialize;
        Task WriteAsync<T>(params T[]? items) 
            where T : ISerialize;
    }
}