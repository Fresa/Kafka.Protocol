using System;
using System.Data;
using System.IO;
using System.Text;
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

        public void WriteBoolean(bool value)
        {
            WriteAsLittleEndian(BitConverter.GetBytes(value));
        }

        public void WriteInt8(sbyte value)
        {
            WriteByte((byte)value);
        }

        public void WriteInt16(short value)
        {
            WriteAsBigEndian(BitConverter.GetBytes(value));
        }

        public void WriteInt32(int value)
        {
            WriteAsBigEndian(BitConverter.GetBytes(value));
        }

        public void WriteInt64(long value)
        {
            WriteAsBigEndian(BitConverter.GetBytes(value));
        }

        public void WriteUInt32(uint value)
        {
            WriteAsBigEndian(BitConverter.GetBytes(value));
        }

        public void WriteVarInt(int value)
        {
            WriteAsLittleEndian(
                value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt());
        }

        public void WriteVarLong(long value)
        {
            WriteAsLittleEndian(
                value
                    .EncodeAsZigZag()
                    .EncodeAsVarInt());
        }

        public void WriteString(string value)
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

            WriteInt16((short)bytes.Length);
            WriteAsLittleEndian(bytes);
        }

        public void WriteNullableString(string value)
        {
            if (value == null)
            {
                WriteInt16(-1);
            }
            else
            {
                WriteString(value);
            }
        }

        public void WriteBytes(byte[] value)
        {
            value ??= Array.Empty<byte>();
            WriteInt32(value.Length);
            WriteAsLittleEndian(value);
        }

        public void WriteNullableBytes(byte[] value)
        {
            if (value == null)
            {
                WriteInt32(-1);
            }
            else
            {
                WriteBytes(value);
            }
        }

        public void Write<T>(params T[] items) 
            where T : ISerialize
        {
            if (items == null)
            {
                WriteInt32(-1);
                return;
            }

            WriteInt32(items.Length);
            foreach (var item in items)
            {
                item.WriteTo(this);
            }
        }

        private void WriteByte(byte value)
        {
            WriteAsLittleEndian(new[] { value });
        }

        private void WriteAsLittleEndian(byte[] value)
        {
            if (BitConverter.IsLittleEndian == false)
            {
                Array.Reverse(value);
            }
            Write(value);
        }

        private void WriteAsBigEndian(byte[] value)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(value);
            }
            Write(value);
        }

        private void Write(byte[] value)
        {
            _buffer.Write(value, 0, value.Length);
        }

        public async ValueTask DisposeAsync()
        {
            await _buffer.FlushAsync();
        }
    }
}