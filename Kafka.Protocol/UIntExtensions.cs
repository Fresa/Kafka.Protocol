﻿namespace Kafka.Protocol
{
    internal static class UIntExtensions
    {
        internal static byte[] EncodeAsVarInt(this uint value) => 
            ((ulong) value).EncodeAsVarInt();
    }
}