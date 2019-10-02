using System;

namespace Kafka.Protocol
{
    internal static class IntExtensions
    {
        internal static uint EncodeAsZigZag(this int value)
        {
            return (uint)((value << 1) ^ (value >> 31));
        }

        internal static bool InRange(this int value, int start, int end)
        {
            return value >= start &&
                   value <= end;
        }
    }
}