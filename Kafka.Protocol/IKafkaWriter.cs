using System;

namespace Kafka.Protocol
{
    public interface IKafkaWriter : IDisposable
    {
        void WriteBoolean(bool value);
        void WriteInt8(sbyte value);
        void WriteInt16(short value);
        void WriteInt32(int value);
        void WriteInt64(long value);
        void WriteUInt32(uint value);

        void WriteVarInt(int value);
        void WriteVarLong(long value);

        void WriteString(string value);
        void WriteNullableString(string value);

        void WriteBytes(byte[] value);
        void WriteNullableBytes(byte[] value);

        void WriteArrayInt32(int[] values);
    }

}