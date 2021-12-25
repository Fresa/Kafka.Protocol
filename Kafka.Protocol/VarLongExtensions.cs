namespace Kafka.Protocol
{
    internal static class VarLongExtensions
    {
        internal static int GetSizeOf(this VarLong varInt) =>
            ((ulong)varInt.Value).GetVarIntLength();
    }
}