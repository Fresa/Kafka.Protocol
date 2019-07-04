using System;

namespace Kafka.Protocol
{
    internal static class ULongExtensions
    {
        private const int MinIndex = 0;
        private const int MaxIndex = 63;
        private const ulong Ones = 0b1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111;

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

        internal static bool IsBitSet(this ulong value, int bitIndex)
        {
            return value.GetValueOfBitRange(bitIndex, bitIndex) == 1;
        }

        internal static ulong GetValueOfBitRange(this ulong value,
            int fromBitIndex,
            int toBitIndex)
        {
            if (fromBitIndex < MinIndex || fromBitIndex > MaxIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(fromBitIndex), $"From must be in range {MinIndex}-{MaxIndex}");
            }

            if (toBitIndex < MinIndex || toBitIndex > MaxIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(toBitIndex), $"To must be in range {MinIndex}-{MaxIndex}");
            }

            if (toBitIndex < fromBitIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(toBitIndex), "To must be greater than or equal to from");
            }

            // Shift in ones covering the range
            var mask = Ones >>
                       MaxIndex - (toBitIndex - fromBitIndex) <<
                       fromBitIndex;

            // Bit AND to get the range value and 0 index the result
            return (value & mask) >> fromBitIndex;
        }

        internal static ulong SetBit(this ulong value, int bitIndex, bool bitValue)
        {
            if (bitIndex < MinIndex || bitIndex > MaxIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(bitIndex), $"Index must be in range {MinIndex}-{MaxIndex}");
            }

            var bitValueAsULong = bitValue ? 1UL : 0;
            bitValueAsULong <<= bitIndex;

            return value | bitValueAsULong;
        }
    }
}