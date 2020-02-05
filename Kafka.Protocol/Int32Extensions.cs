namespace Kafka.Protocol
{
    internal static class Int32Extensions
    {
        internal static VarInt ToVarInt(this Int32 value)
        {
            return VarInt.From(value.Value);
        }
    }
}