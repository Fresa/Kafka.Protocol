using System;
using System.Data;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public class KafkaWriter : IKafkaWriter
    {
        private readonly Stream _buffer;

        public KafkaWriter(Stream buffer)
        {
            _buffer = buffer;
        }

        public async Task WriteBooleanAsync(bool value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(BitConverter.GetBytes(value), cancellationToken);
        }

        public async Task WriteInt8Async(sbyte value, CancellationToken cancellationToken = default)
        {
            await WriteByteAsync((byte)value, cancellationToken);
        }

        public async Task WriteInt16Async(short value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value), cancellationToken);
        }

        public async Task WriteInt32Async(int value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value), cancellationToken);
        }

        public async Task WriteInt64Async(long value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value), cancellationToken);
        }

        public async Task WriteUInt32Async(uint value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value), cancellationToken);
        }

        public async Task WriteVarIntAsync(int value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(
                value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken);
        }

        public async Task WriteVarLongAsync(long value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(
                value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken);
        }

        public async Task WriteStringAsync(string value, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var bytes = Encoding.UTF8.GetBytes(value);

            if (bytes.Length > short.MaxValue)
            {
                throw new SyntaxErrorException($"{value} is to long");
            }

            await WriteInt16Async((short)bytes.Length, cancellationToken);
            await WriteAsLittleEndianAsync(bytes, cancellationToken);
        }

        public async Task WriteNullableStringAsync(string? value, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                await WriteInt16Async(-1, cancellationToken);
            }
            else
            {
                await WriteStringAsync(value, cancellationToken);
            }
        }

        public async Task WriteBytesAsync(byte[] value, CancellationToken cancellationToken = default)
        {
            value ??= Array.Empty<byte>();
            await WriteInt32Async(value.Length, cancellationToken);
            await WriteAsLittleEndianAsync(value, cancellationToken);
        }

        public async Task WriteNullableBytesAsync(byte[]? value, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                await WriteInt32Async(-1, cancellationToken);
            }
            else
            {
                await WriteBytesAsync(value, cancellationToken);
            }
        }

        public async Task WriteAsync<T>(CancellationToken cancellationToken, params T[]? items)
            where T : ISerialize
        {
            if (items == null)
            {
                await WriteInt32Async(-1, cancellationToken);
                return;
            }

            await WriteInt32Async(items.Length, cancellationToken);
            foreach (var item in items)
            {
                await item.WriteToAsync(this, cancellationToken);
            }
        }

        public async Task WriteAsync<T>(params T[]? items) 
            where T : ISerialize
        {
            await WriteAsync(default, items);
        }

        private async Task WriteByteAsync(byte value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(new[] { value }, cancellationToken);
        }

        private async Task WriteAsLittleEndianAsync(byte[] value, CancellationToken cancellationToken = default)
        {
            if (BitConverter.IsLittleEndian == false)
            {
                Array.Reverse(value);
            }

            await WriteAsync(value, cancellationToken);
        }

        private async Task WriteAsBigEndianAsync(byte[] value, CancellationToken cancellationToken = default)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(value);
            }

            await WriteAsync(value, cancellationToken);
        }

        private async Task WriteAsync(byte[] value, CancellationToken cancellationToken = default)
        {
            await _buffer.WriteAsync(value, 0, value.Length, cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            await _buffer.FlushAsync();
        }
    }
}