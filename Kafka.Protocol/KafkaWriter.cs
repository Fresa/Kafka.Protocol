using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

namespace Kafka.Protocol
{
    public class KafkaWriter : IKafkaWriter
    {
        private readonly Stream _buffer;

        public KafkaWriter(Stream buffer)
        {
            _buffer = buffer;
        }

        public ValueTask WriteBooleanAsync(Boolean value, CancellationToken cancellationToken = default) => 
            WriteAsLittleEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);

        public ValueTask WriteInt8Async(Int8 value, CancellationToken cancellationToken = default) => 
            WriteByteAsync((byte)value.Value, cancellationToken);

        public ValueTask WriteInt16Async(Int16 value,
            CancellationToken cancellationToken = default) =>
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value),
                cancellationToken);

        public ValueTask WriteInt32Async(Int32 value, CancellationToken cancellationToken = default) => 
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);

        public ValueTask WriteInt64Async(Int64 value, CancellationToken cancellationToken = default) => 
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);

        public ValueTask WriteUInt16Async(UInt16 value,
            CancellationToken cancellationToken = default) =>
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);

        public ValueTask WriteUInt32Async(UInt32 value, CancellationToken cancellationToken = default) => 
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);

        public ValueTask WriteVarIntAsync(VarInt value, CancellationToken cancellationToken = default) =>
            WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken);

        public ValueTask WriteUVarIntAsync(UVarInt value, CancellationToken cancellationToken = default) =>
            WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsVarInt(), cancellationToken);

        public ValueTask WriteVarLongAsync(VarLong value, CancellationToken cancellationToken = default) =>
            WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken);

        public ValueTask WriteFloat64Async(Float64 value,
            CancellationToken cancellationToken = default) =>
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value),
                cancellationToken);

        public async ValueTask WriteStringAsync(String value, CancellationToken cancellationToken = default)
        {
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

        public ValueTask WriteCompactStringAsync(String value,
            CancellationToken cancellationToken = default) =>
            WriteCompactNullableBytesAsync(Encoding.UTF8.GetBytes(value.Value),
                cancellationToken);

        public ValueTask WriteCompactNullableStringAsync(String? value,
            CancellationToken cancellationToken = default) =>
            WriteCompactNullableBytesAsync(
                value == null
                    ? null
                    : Encoding.UTF8.GetBytes(value.Value.Value),
                cancellationToken);

        public ValueTask WriteNullableStringAsync(String? value, CancellationToken cancellationToken = default) =>
            value.HasValue
                ? WriteStringAsync(value.Value, cancellationToken)
                : WriteInt16Async(Int16.From(-1), cancellationToken);

        public async ValueTask WriteBytesAsync(Bytes value, CancellationToken cancellationToken = default)
        {
            await WriteInt32Async(Int32.From(value.Value.Length), cancellationToken)
                .ConfigureAwait(false);
            await WriteAsLittleEndianAsync(value.Value, cancellationToken)
                .ConfigureAwait(false);
        }

        public ValueTask WriteBytesAsync(byte[] value,
            CancellationToken cancellationToken = default) =>
            WriteAsync(value, cancellationToken);

        public ValueTask WriteNullableBytesAsync(Bytes? value, CancellationToken cancellationToken = default) =>
            value.HasValue
                ? WriteBytesAsync(value.Value, cancellationToken)
                : WriteInt32Async(Int32.From(-1), cancellationToken);

        public ValueTask WriteCompactBytesAsync(Bytes value,
            CancellationToken cancellationToken = default) =>
            WriteCompactNullableBytesAsync(value.Value, cancellationToken);

        public ValueTask WriteCompactNullableBytesAsync(Bytes? value,
            CancellationToken cancellationToken = default) =>
            WriteCompactNullableBytesAsync(value?.Value, cancellationToken);

        private async ValueTask WriteCompactNullableBytesAsync(byte[]? value,
            CancellationToken cancellationToken = default)
        {
            var length = value == null ? 0 : (uint)value.Length + 1;
            await WriteUVarIntAsync(length, cancellationToken)
                .ConfigureAwait(false);
            
            if (value == null)
            {
                return;
            }

            await WriteAsLittleEndianAsync(value,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public ValueTask WriteArrayAsync<T>(CancellationToken cancellationToken, params T[] items)
            where T : ISerialize =>
            WriteNullableArrayAsync(cancellationToken, items);

        public ValueTask WriteCompactArrayAsync<T>(
            CancellationToken cancellationToken = default, params T[] items) where T : ISerialize
        {
            throw new NotImplementedException();
        }

        public ValueTask WriteCompactNullableArrayAsync<T>(
            CancellationToken cancellationToken = default, params T[] items) where T : ISerialize
        {
            throw new NotImplementedException();
        }

        public async ValueTask WriteRecordBatchAsync(RecordBatch value,
            CancellationToken cancellationToken = default)
        {
            await WriteInt32Async(value.Length, cancellationToken)
                .ConfigureAwait(false);
            await value.WriteToAsync(this, cancellationToken);
        }

        public ValueTask WriteNullableRecordBatchAsync(RecordBatch? value,
            CancellationToken cancellationToken = default) =>
            value == null
                ? WriteNullableBytesAsync(null, cancellationToken)
                : WriteRecordBatchAsync(value, cancellationToken);

        public ValueTask WriteUuidAsync(Uuid value,
            CancellationToken cancellationToken = default)
        {
            Span<byte> buffer = stackalloc byte[16];
            value.Value.TryWriteBytes(buffer);
            // The three first sections in a GUID is stored as little endian while the rest is big endian
            buffer[..4].Reverse();
            buffer[4..6].Reverse();
            buffer[6..8].Reverse();

            return WriteAsync(buffer.ToArray(), cancellationToken);
        }

        public async ValueTask WriteNullableArrayAsync<T>(CancellationToken cancellationToken, params T[]? items)
            where T : ISerialize
        {
            if (items == null)
            {
                await WriteInt32Async(Int32.From(-1), cancellationToken)
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

        private ValueTask WriteByteAsync(byte value, CancellationToken cancellationToken = default) => 
            WriteAsLittleEndianAsync(new[] { value }, cancellationToken);

        private ValueTask WriteAsLittleEndianAsync(byte[] value, CancellationToken cancellationToken = default)
        {
            if (BitConverter.IsLittleEndian == false)
            {
                Array.Reverse(value);
            }

            return WriteAsync(value, cancellationToken);
        }

        private ValueTask WriteAsBigEndianAsync(byte[] value, CancellationToken cancellationToken = default)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(value);
            }

            return WriteAsync(value, cancellationToken);
        }

        private ValueTask WriteAsync(byte[] value, CancellationToken cancellationToken = default)
        {
            if (value.Any() == false)
            {
                return default;
            }

            return _buffer.WriteAsync(value.AsMemory(), cancellationToken);
        }

        public ValueTask DisposeAsync() =>
            new ValueTask(_buffer.FlushAsync());
    }
}