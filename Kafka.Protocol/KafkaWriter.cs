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

        public ValueTask WriteVarLongAsync(VarLong value, CancellationToken cancellationToken = default) =>
            WriteAsLittleEndianAsync(
                value.Value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt(), cancellationToken);

        public ValueTask WriteFloat64Async(Float64 value,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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

        public ValueTask WriteCompactStringAsync(CompactString value,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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

        public ValueTask WriteCompactBytesAsync(CompactBytes value,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask WriteArrayAsync<T>(CancellationToken cancellationToken, params T[] items)
            where T : ISerialize =>
            WriteNullableArrayAsync(cancellationToken, items);

        public ValueTask WriteRecordBatchAsync(RecordBatch value,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask WriteNullableRecordBatchAsync(RecordBatch? value,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask WriteUuidAsync(Uuid value,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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