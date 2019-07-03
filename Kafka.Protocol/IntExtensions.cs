using System;

namespace Kafka.Protocol
{
    internal static class IntExtensions
    {
        internal static uint EncodeAsZigZag(this int value)
        {
            return (uint)((value << 1) ^ (value >> 31));
        }

        internal static bool InRange(this int value, IRange<int> range)
        {
            return range.InRange(value);
        }

        internal static bool IsBitSet(this int value, int bitIndex)
        {
            return value.GetValueOfBitRange(bitIndex, bitIndex) == 1;
        }

        internal static int GetValueOfBitRange(this int value,
            int fromBitIndex,
            int toBitIndex)
        {
            if (fromBitIndex < 0 || fromBitIndex > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(fromBitIndex), "From must be in range 0-31");
            }

            if (toBitIndex < 0 || toBitIndex > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(toBitIndex), "To must be in range 0-31");
            }

            if (toBitIndex < fromBitIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(toBitIndex), "To must be greater than or equal to from");
            }

            // Shift in ones covering the range
            var mask = (int)(uint.MaxValue >> (31 - toBitIndex)) << fromBitIndex;

            // Bit AND to get the range value and 0 index the result
            return (value & mask) >> fromBitIndex;
        }
    }
}