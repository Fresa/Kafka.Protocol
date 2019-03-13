namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class OperandSymbolSequence : SymbolSequence
    {
        public OperandSymbolSequence(SymbolReference symbolReference, bool isOptional)
            : base(symbolReference, isOptional, SymbolSequenceType.Operand)
        {
        }
    }
}