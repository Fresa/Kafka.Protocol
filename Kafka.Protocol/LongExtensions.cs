namespace Kafka.Protocol
{
    internal static class LongExtensions
    {
        internal static ulong EncodeAsZigZag(this long value)
        {
            return (ulong)((value << 1) ^ (value >> 63));
        }
    }
}