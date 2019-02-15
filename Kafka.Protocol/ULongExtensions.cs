using System;

namespace Kafka.Protocol
{
    internal static class ULongExtensions
    {
        internal static byte[] EncodeAsVarInt(this ulong value)
        {
            var buffer = new byte[10];
            var position = 0;
            do
            {
                // Take 7 bits
                var byteValue = value & 0x7f;
                // Remove 7 bits
                value >>= 7;

                // Value should be encoded to more than one byte?
                if (value > 0)
                {
                    // Add 1 to most significant bit to indicate more bytes will follow
                    byteValue |= 128;
                }

                buffer[position++] = (byte)byteValue;
            } while (value > 0);

            var result = new byte[position];
            Buffer.BlockCopy(buffer, 0, result, 0, position);

            return result;
        }

        internal static long DecodeFromZigZag(this ulong value)
        {
            return (long) ((value >> 1) - (value & 1) * value);
        }
    }
}