namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class SymbolSequence
    {
        internal SymbolSequence(Symbol symbol, bool isOptional)
        {
            Symbol = symbol;
            IsOptional = isOptional;
        }

        public Symbol Symbol { get;  }
        public bool IsOptional { get; }
    }
}