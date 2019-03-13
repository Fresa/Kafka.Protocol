namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal abstract class OperatorSymbolSequence : SymbolSequence
    {
        protected OperatorSymbolSequence(SymbolReference symbolReference) 
            : base(symbolReference, false)
        {
        }

        internal abstract int Precedence { get; }
    }
}