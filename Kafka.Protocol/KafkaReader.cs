using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public class KafkaReader : IKafkaReader
    {
        private readonly byte[] _buffer;
        private int _position;

        public KafkaReader(params byte[] buffer)
        {
            _buffer = buffer;
        }

        public int Length =>
            _buffer.Length;

        public bool ReadBoolean()
        {
            return BitConverter.ToBoolean(
                ReadAsLittleEndian(1),
                0);
        }

        public sbyte ReadInt8()
        {
            return Convert.ToSByte(ReadByte());
        }

        public short ReadInt16()
        {
            return BitConverter.ToInt16(
                ReadAsBigEndian(2),
                0);
        }

        public int ReadInt32()
        {
            return BitConverter.ToInt32(
                ReadAsBigEndian(4),
                0);
        }

        public long ReadInt64()
        {
            return BitConverter.ToInt64(
                ReadAsBigEndian(8),
                0);
        }

        public uint ReadUInt32()
        {
            return BitConverter.ToUInt32(
                ReadAsBigEndian(4),
                0);
        }

        public int ReadVarInt()
        {
            return (int)ReadVarLong();
        }

        public long ReadVarLong()
        {
            var more = true;
            ulong value = 0;
            var shift = 0;
            while (more)
            {
                var lowerBits = ReadByte();
                more = (lowerBits & 128) != 0;
                value |= (uint)((lowerBits & 0x7f) << shift);
                shift += 7;
            }

            return value.DecodeFromZigZag();
        }

        public string ReadString()
        {
            var length = ReadInt16();
            var bytes = ReadAsLittleEndian(length);
            return Encoding.UTF8.GetString(bytes);
        }

        public string? ReadNullableString()
        {
            var length = ReadInt16();
            if (length == -1)
            {
                return null;
            }

            var bytes = ReadAsLittleEndian(length);
            return Encoding.UTF8.GetString(bytes);
        }

        public byte[] ReadBytes()
        {
            var length = ReadInt32();
            return ReadAsLittleEndian(length);
        }

        public byte[]? ReadNullableBytes()
        {
            var length = ReadInt32();
            if (length == -1)
            {
                return null;
            }

            return ReadAsLittleEndian(length);
        }
        
        public T[]? Read<T>(Func<T> createItem) 
            where T : ISerialize
        {
            var length = ReadInt32();
            if (length == -1)
            {
                return null;
            }

            var result = new T[length];
            for (var i = 0; i < length; i++)
            {
                var item = createItem();
                item.ReadFrom(this);
                result[i] = item;
            }

            return result;
        }

        private byte ReadByte()
        {
            return ReadAsLittleEndian(1)
                .First();
        }

        private byte[] ReadAsLittleEndian(int length)
        {
            var bytes = Read(length);
            if (BitConverter.IsLittleEndian == false)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }

        private byte[] ReadAsBigEndian(int length)
        {
            var bytes = Read(length);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }

        private byte[] Read(int length)
        {
            if (_buffer.Length < _position + length)
            {
                throw new InvalidOperationException(
                    $"Tried to read outside the buffer. Buffer length: {_buffer.Length}, Position: {_position}, Read request length: {length}.");
            }

            var bytes = new byte[length];
            Array.Copy(
                _buffer,
                _position,
                bytes,
                0,
                length);
            _position += length;
            return bytes;
        }
    }

    public class KafkaReader2 //: IKafkaReader
    {
        private readonly PipeReader _reader;

        public KafkaReader2(PipeReader reader)
        {
            _reader = reader;
        }

        public async ValueTask<bool> ReadBooleanAsync(
            CancellationToken cancellationToken = default)
        {
            return BitConverter.ToBoolean(
                await ReadAsLittleEndianAsync(1, cancellationToken),
                0);
        }

        public async ValueTask<sbyte> ReadInt8Async(
            CancellationToken cancellationToken = default)
        {
            return Convert.ToSByte(
                await ReadByteAsync(cancellationToken));
        }

        public async ValueTask<short> ReadInt16Async(
            CancellationToken cancellationToken = default)
        {
            return BitConverter.ToInt16(
                await ReadAsBigEndianAsync(2, cancellationToken),
                0);
        }

        public async Task<int> ReadInt32Async(
            CancellationToken cancellationToken = default)
        {
            return BitConverter.ToInt32(
                await ReadAsBigEndianAsync(4, cancellationToken),
                0);
        }

        public async ValueTask<long> ReadInt64Async(
            CancellationToken cancellationToken = default)
        {
            return BitConverter.ToInt64(
                await ReadAsBigEndianAsync(8, cancellationToken),
                0);
        }

        public async ValueTask<uint> ReadUInt32Async(
            CancellationToken cancellationToken = default)
        {
            return BitConverter.ToUInt32(
                await ReadAsBigEndianAsync(4, cancellationToken),
                0);
        }

        public async ValueTask<int> ReadVarIntAsync(
            CancellationToken cancellationToken = default)
        {
            return (int)await ReadVarLongAsync(cancellationToken);
        }

        public async ValueTask<long> ReadVarLongAsync(
            CancellationToken cancellationToken = default)
        {
            var more = true;
            ulong value = 0;
            var shift = 0;
            while (more)
            {
                var lowerBits = await ReadByteAsync(cancellationToken);
                more = (lowerBits & 128) != 0;
                value |= (uint)((lowerBits & 0x7f) << shift);
                shift += 7;
            }

            return value.DecodeFromZigZag();
        }

        public async ValueTask<string> ReadStringAsync(
            CancellationToken cancellationToken = default)
        {
            var length = await ReadInt16Async(cancellationToken);
            var bytes = await ReadAsLittleEndianAsync(length, cancellationToken);
            return Encoding.UTF8.GetString(bytes);
        }

        public async ValueTask<string?> ReadNullableStringAsync(
            CancellationToken cancellationToken = default)
        {
            var length = await ReadInt16Async(cancellationToken);
            if (length == -1)
            {
                return null;
            }

            var bytes = await ReadAsLittleEndianAsync(length, cancellationToken);
            return Encoding.UTF8.GetString(bytes);
        }

        public async ValueTask<byte[]> ReadBytesAsync(
            CancellationToken cancellationToken = default)
        {
            var length = await ReadInt32Async(cancellationToken);
            return await ReadAsLittleEndianAsync(length, cancellationToken);
        }

        public async ValueTask<byte[]?> ReadNullableBytesAsync(
            CancellationToken cancellationToken = default)
        {
            var length = await ReadInt32Async(cancellationToken);
            if (length == -1)
            {
                return null;
            }

            return await ReadAsLittleEndianAsync(length, cancellationToken);
        }

        //public async ValueTask<T[]?> ReadAsync<T>(Func<T> createItem,
        //    CancellationToken cancellationToken = default)
        //    where T : ISerialize
        //{
        //    var length = await ReadInt32Async(cancellationToken);
        //    if (length == -1)
        //    {
        //        return null;
        //    }

        //    var result = new T[length];
        //    for (var i = 0; i < length; i++)
        //    {
        //        var item = createItem();
        //        item.ReadFrom(this);
        //        result[i] = item;
        //    }

        //    return result;
        //}

        private async Task<byte> ReadByteAsync(CancellationToken cancellationToken = default)
        {
            return (await ReadAsLittleEndianAsync(1, cancellationToken))
                .First();
        }

        private async ValueTask<byte[]> ReadAsLittleEndianAsync(
            int length,
            CancellationToken cancellationToken = default)
        {
            var bytes = await ReadAsync(length, cancellationToken);
            if (BitConverter.IsLittleEndian == false)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }

        private async ValueTask<byte[]> ReadAsBigEndianAsync(
            int length,
            CancellationToken cancellationToken = default)
        {
            var bytes = await ReadAsync(length, cancellationToken);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }

        private async ValueTask<byte[]> ReadAsync(
            int length,
            CancellationToken cancellationToken = default)
        {
            ReadResult result;
            do
            {
                result = await _reader.ReadAsync(cancellationToken);
            } while (result.Buffer.Length < length);

            var bytes = result.Buffer.Slice(0, length).ToArray();
            _reader.AdvanceTo(result.Buffer.GetPosition(length));
            return bytes;
        }
    }
}