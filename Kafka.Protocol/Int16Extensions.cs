using System;

namespace Kafka.Protocol
{
    internal static class Int16Extensions
    {
        internal static bool IsBitSet(this Int16 value, int bitNumber)
        {
            if (bitNumber < 0 ||
                bitNumber > 15)
            {
                throw new ArgumentOutOfRangeException(nameof(bitNumber), "Must be in range 0-15");
            }

            if (value.Value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Must be equal or greater than 0");
            }

            return ((ulong)value.Value)
                .IsBitSet(bitNumber);
        }

        internal static ulong GetValueOfBitRange(this Int16 value, 
            int fromBit, 
            int toBit)
        {
            if (fromBit < 0 ||
                fromBit > 15)
            {
                throw new ArgumentOutOfRangeException(nameof(fromBit), "Must be in range 0-15");
            }

            if (toBit < 0 ||
                toBit > 15)
            {
                throw new ArgumentOutOfRangeException(nameof(toBit), "Must be in range 0-15");
            }

            if (toBit < fromBit)
            {
                throw new ArgumentOutOfRangeException(nameof(toBit), $"Must be equal or greater than {nameof(fromBit)}");
            }

            return ((ulong) value.Value).GetValueOfBitRange(fromBit, toBit);
        }
    }
}