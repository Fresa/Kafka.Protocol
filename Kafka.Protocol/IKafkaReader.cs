using System;

namespace Kafka.Protocol
{
    public interface IKafkaReader
    {
        bool ReadBoolean();
        sbyte ReadInt8();
        short ReadInt16();
        int ReadInt32();
        long ReadInt64();
        uint ReadUInt32();

        int ReadVarInt();
        long ReadVarLong();

        string ReadString();
        string? ReadNullableString();

        byte[] ReadBytes();
        byte[]? ReadNullableBytes();

        T[]? Read<T>(Func<T> factory) 
            where T : ISerialize;
    }
}