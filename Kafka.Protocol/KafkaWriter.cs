using System;
using System.Data;
using System.IO;
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

        public async Task WriteBooleanAsync(Boolean value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);
        }

        public async Task WriteInt8Async(Int8 value, CancellationToken cancellationToken = default)
        {
            await WriteByteAsync((byte)value.Value, cancellationToken);
        }

        public async Task WriteInt16Async(Int16 value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);
        }

        public async Task WriteInt32Async(Int32 value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);
        }

        public async Task WriteInt64Async(Int64 value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);
        }

        public async Task WriteUInt32Async(UInt32 value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);
        }

        public async Task WriteVarIntAsync(VarInt value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken);
        }

        public async Task WriteVarLongAsync(VarLong value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken);
        }

        public async Task WriteStringAsync(String value, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var bytes = Encoding.UTF8.GetBytes(value.Value);

            if (bytes.Length > short.MaxValue)
            {
                throw new SyntaxErrorException($"{value} is to long");
            }

            await WriteInt16Async(Int16.From((short)bytes.Length), cancellationToken);
            await WriteAsLittleEndianAsync(bytes, cancellationToken);
        }

        public async Task WriteNullableStringAsync(String? value, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                await WriteInt16Async(Int16.From(-1), cancellationToken);
            }
            else
            {
                await WriteStringAsync(value.Value, cancellationToken);
            }
        }

        public async Task WriteBytesAsync(Bytes value, CancellationToken cancellationToken = default)
        {
            await WriteInt32Async(Int32.From(value.Value.Length), cancellationToken);
            await WriteAsLittleEndianAsync(value.Value, cancellationToken);
        }

        public async Task WriteNullableBytesAsync(Bytes? value, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                await WriteInt32Async( Int32.From(-1), cancellationToken);
            }
            else
            {
                await WriteBytesAsync(value.Value, cancellationToken);
            }
        }

        public async Task WriteArrayAsync<T>(CancellationToken cancellationToken, params T[] items)
            where T : ISerialize
        {
            await WriteNullableArrayAsync(cancellationToken, items);
        }

        public async Task WriteNullableArrayAsync<T>(CancellationToken cancellationToken, params T[]? items)
            where T : ISerialize
        {
            if (items == null)
            {
                await WriteInt32Async( Int32.From(-1), cancellationToken);
                return;
            }

            await WriteInt32Async(Int32.From(items.Length), cancellationToken);
            foreach (var item in items)
            {
                await item.WriteToAsync(this, cancellationToken);
            }
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