namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class SymbolSequence
    {
        internal SymbolSequence(SymbolReference symbol, bool isOptional)
        {
            Symbol = symbol;
            IsOptional = isOptional;
        }

        public SymbolReference Symbol { get;  }
        public bool IsOptional { get; }
    }
}