namespace Kafka.Protocol.Generator.Helpers.BackusNaurForm
{
    internal abstract class OperatorSymbolSequence : SymbolSequence
    {
        protected OperatorSymbolSequence(SymbolReference symbolReference) 
            : base(symbolReference)
        {
        }

        internal abstract int Precedence { get; }
    }
}