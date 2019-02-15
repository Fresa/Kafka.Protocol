using System;
using System.Linq;
using System.Text;

namespace Kafka.Protocol
{
    internal class KafkaReader : IKafkaReader
    {
        private readonly byte[] _buffer;
        private int _position;

        internal KafkaReader(params byte[] buffer)
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
            return Convert.ToSByte(
                ReadByte());
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

        public string ReadNullableString()
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

        public byte[] ReadNullableBytes()
        {
            var length = ReadInt32();
            if (length == -1)
            {
                return null;
            }
            return ReadAsLittleEndian(length);
        }

        public int[] ReadArrayInt32()
        {
            var length = ReadInt32();
            if (length == -1)
            {
                return null;
            }

            var result = new int[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = ReadInt32();
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
                throw new InvalidOperationException($"Tried to read outside the buffer. Buffer length: {_buffer.Length}, Position: {_position}, Read request length: {length}.");
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
}