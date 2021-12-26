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

        public int SizeOfBoolean(Boolean value) => 1;
        public ValueTask WriteBooleanAsync(Boolean value, CancellationToken cancellationToken = default) => 
            WriteAsLittleEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);

        public int SizeOfInt8(Int8 value) => 1;
        public ValueTask WriteInt8Async(Int8 value, CancellationToken cancellationToken = default) => 
            WriteByteAsync((byte)value.Value, cancellationToken);

        public int SizeOfInt16(Int16 value) => 2;
        public ValueTask WriteInt16Async(Int16 value,
            CancellationToken cancellationToken = default) =>
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value),
                cancellationToken);

        public int SizeOfUInt16(UInt16 value) => 2;
        public ValueTask WriteUInt16Async(UInt16 value,
            CancellationToken cancellationToken = default) =>
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);

        public int SizeOfInt32(Int32 value) => 4;
        public ValueTask WriteInt32Async(Int32 value, CancellationToken cancellationToken = default) => 
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);

        public int SizeOfUInt32(UInt32 value) => 4;
        public ValueTask WriteUInt32Async(UInt32 value, CancellationToken cancellationToken = default) =>
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);

        public int SizeOfInt64(Int64 value) => 8;
        public ValueTask WriteInt64Async(Int64 value, CancellationToken cancellationToken = default) => 
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value), cancellationToken);

        public int SizeOfVarInt(VarInt value) => value.GetSizeOf();
        public ValueTask WriteVarIntAsync(VarInt value, CancellationToken cancellationToken = default) =>
            WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken);

        public int SizeOfUVarInt(UVarInt value) =>
            ((ulong)value.Value).GetVarIntLength();
        public ValueTask WriteUVarIntAsync(UVarInt value, CancellationToken cancellationToken = default) =>
            WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsVarInt(), cancellationToken);

        public int SizeOfVarLong(VarLong value) => value.GetSizeOf();
        public ValueTask WriteVarLongAsync(VarLong value, CancellationToken cancellationToken = default) =>
            WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken);

        public int SizeOfFloat64(Float64 value) => 8;
        public ValueTask WriteFloat64Async(Float64 value,
            CancellationToken cancellationToken = default) =>
            WriteAsBigEndianAsync(BitConverter.GetBytes(value.Value),
                cancellationToken);

        public int SizeOfString(String value) => 2 + value.Value.Length;
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

        public int SizeOfNullableString(String? value) =>
            2 + (value?.Value.Length ?? 0);
        public ValueTask WriteNullableStringAsync(String? value, CancellationToken cancellationToken = default) =>
            value.HasValue
                ? WriteStringAsync(value.Value, cancellationToken)
                : WriteInt16Async(Int16.From(-1), cancellationToken);

        public int SizeOfCompactString(String value) =>
            (value.Value.Length + 1).GetVarIntLength() + 
            value.Value.Length;
        public ValueTask WriteCompactStringAsync(String value,
            CancellationToken cancellationToken = default) =>
            WriteCompactNullableBytesAsync(Encoding.UTF8.GetBytes(value.Value),
                cancellationToken);

        public int SizeOfCompactNullableString(String? value) =>
            value == null ? 1 : SizeOfCompactString((String)value);
        public ValueTask WriteCompactNullableStringAsync(String? value,
            CancellationToken cancellationToken = default) =>
            WriteCompactNullableBytesAsync(
                value == null
                    ? null
                    : Encoding.UTF8.GetBytes(value.Value.Value),
                cancellationToken);

        public int SizeOfBytes(Bytes value) => 4 + value.Value.Length;
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

        public int SizeOfNullableBytes(Bytes? value) =>
            4 + (value?.Value.Length ?? 0);
        public ValueTask WriteNullableBytesAsync(Bytes? value, CancellationToken cancellationToken = default) =>
            value.HasValue
                ? WriteBytesAsync(value.Value, cancellationToken)
                : WriteInt32Async(Int32.From(-1), cancellationToken);

        public int SizeOfCompactBytes(Bytes value) =>
            (value.Value.Length + 1).GetVarIntLength() +
            value.Value.Length;
        public ValueTask WriteCompactBytesAsync(Bytes value,
            CancellationToken cancellationToken = default) =>
            WriteCompactNullableBytesAsync(value.Value, cancellationToken);

        public int SizeOfCompactNullableBytes(Bytes? value) =>
            value == null ? 1 : SizeOfCompactBytes((Bytes)value);
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

        public int SizeOfArray<T>(T[] items) where T : ISerialize =>
            4 + items.Sum(item => item.GetSize(this));
        public ValueTask WriteArrayAsync<T>(CancellationToken cancellationToken = default, params T[] items)
            where T : ISerialize =>
            WriteNullableArrayAsync(cancellationToken, items);

        public int SizeOfNullableArray<T>(params T[]? items) where T : ISerialize =>
            4 + (items?.Sum(item => item.GetSize(this)) ?? 0);
        public async ValueTask WriteNullableArrayAsync<T>(CancellationToken cancellationToken = default, params T[]? items)
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

        public int SizeOfCompactArray<T>(params T[] items) where T : ISerialize =>
            (items.Length + 1).GetVarIntLength() +
            items.Sum(item => item.GetSize(this));
        public ValueTask WriteCompactArrayAsync<T>(
            CancellationToken cancellationToken = default, params T[] items) where T : ISerialize =>
            WriteCompactNullableArrayAsync(cancellationToken, items);

        public int SizeOfCompactNullableArray<T>(params T[]? items)
            where T : ISerialize =>
            items == null
                ? 1
                : (items.Length + 1).GetVarIntLength() +
                  items.Sum(item => item.GetSize(this));
        public async ValueTask WriteCompactNullableArrayAsync<T>(
            CancellationToken cancellationToken = default, params T[]? items) where T : ISerialize
        {
            if (items == null)
            {
                await WriteUVarIntAsync(0, cancellationToken)
                    .ConfigureAwait(false);
                return;
            }

            await WriteUVarIntAsync((uint)items.Length + 1, cancellationToken)
                .ConfigureAwait(false);
            foreach (var item in items)
            {
                await item.WriteToAsync(this, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        public int SizeOfRecordBatch(RecordBatch value) => value.SizeOf;
        public async ValueTask WriteRecordBatchAsync(RecordBatch value,
            CancellationToken cancellationToken = default)
        {
            await WriteInt32Async(value.Length, cancellationToken)
                .ConfigureAwait(false);
            await value.WriteToAsync(this, cancellationToken);
        }

        public int SizeOfNullableRecordBatch(RecordBatch? value) =>
            value?.SizeOf ?? 4;
        public ValueTask WriteNullableRecordBatchAsync(RecordBatch? value,
            CancellationToken cancellationToken = default) =>
            value == null
                ? WriteNullableBytesAsync(null, cancellationToken)
                : WriteRecordBatchAsync(value, cancellationToken);

        public int SizeOfUuid(Uuid value) => 16;
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