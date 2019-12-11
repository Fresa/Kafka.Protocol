using System;
using System.Data;
using System.IO;
using System.Linq;
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

        public async ValueTask WriteBooleanAsync(Boolean value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteInt8Async(Int8 value, CancellationToken cancellationToken = default)
        {
            await WriteByteAsync((byte)value.Value, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteInt16Async(Int16 value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteInt32Async(Int32 value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteInt64Async(Int64 value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteUInt32Async(UInt32 value, CancellationToken cancellationToken = default)
        {
            await WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteVarIntAsync(VarInt value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteVarLongAsync(VarLong value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteStringAsync(String value, CancellationToken cancellationToken = default)
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

            await WriteInt16Async(Int16.From((short)bytes.Length), cancellationToken)
                .ConfigureAwait(false);
            await WriteAsLittleEndianAsync(bytes, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteNullableStringAsync(String? value, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                await WriteInt16Async(Int16.From(-1), cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                await WriteStringAsync(value.Value, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        public async ValueTask WriteBytesAsync(Bytes value, CancellationToken cancellationToken = default)
        {
            await WriteInt32Async(Int32.From(value.Value.Length), cancellationToken)
                .ConfigureAwait(false);
            await WriteAsLittleEndianAsync(value.Value, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteNullableBytesAsync(Bytes? value, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                await WriteInt32Async( Int32.From(-1), cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                await WriteBytesAsync(value.Value, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        public async ValueTask WriteArrayAsync<T>(CancellationToken cancellationToken, params T[] items)
            where T : ISerialize
        {
            await WriteNullableArrayAsync(cancellationToken, items)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteNullableArrayAsync<T>(CancellationToken cancellationToken, params T[]? items)
            where T : ISerialize
        {
            if (items == null)
            {
                await WriteInt32Async( Int32.From(-1), cancellationToken)
                    .ConfigureAwait(false);
                return;
            }

            await WriteInt32Async(Int32.From(items.Length), cancellationToken)
                .ConfigureAwait(false);
            foreach (var item in items)
            {
                await item.WriteToAsync(this, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        private async ValueTask WriteByteAsync(byte value, CancellationToken cancellationToken = default)
        {
            await WriteAsLittleEndianAsync(new[] { value }, cancellationToken)
                .ConfigureAwait(false);
        }

        private async ValueTask WriteAsLittleEndianAsync(byte[] value, CancellationToken cancellationToken = default)
        {
            if (BitConverter.IsLittleEndian == false)
            {
                Array.Reverse(value);
            }

            await WriteAsync(value, cancellationToken)
                .ConfigureAwait(false);
        }

        private async ValueTask WriteAsBigEndianAsync(byte[] value, CancellationToken cancellationToken = default)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(value);
            }

            await WriteAsync(value, cancellationToken)
                .ConfigureAwait(false);
        }

        private async ValueTask WriteAsync(byte[] value, CancellationToken cancellationToken = default)
        {
            if (value.Any() == false)
            {
                return;
            }

            await _buffer.WriteAsync(value.AsMemory(), cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask DisposeAsync()
        {
            await _buffer.FlushAsync()
                .ConfigureAwait(false);
        }
    }
}