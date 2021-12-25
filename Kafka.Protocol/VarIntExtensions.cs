namespace Kafka.Protocol
{
    internal static class VarIntExtensions
    {
        internal static int GetSizeOf(this VarInt varInt) => 
            varInt.Value.GetVarIntLength();
    }
}