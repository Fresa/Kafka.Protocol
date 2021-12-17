namespace Kafka.Protocol
{
    internal static class IntExtensions
    {
        internal static uint EncodeAsZigZag(this int value)
        {
            return (uint)((value << 1) ^ (value >> 31));
        }

        internal static int GetVarIntLength(this int value) =>
            ((ulong)value).GetVarIntLength();
    }
}