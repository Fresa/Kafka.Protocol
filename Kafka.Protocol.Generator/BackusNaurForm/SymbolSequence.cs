namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class SymbolSequence
    {
        internal SymbolSequence(SymbolReference symbolReference, bool isOptional)
        {
            SymbolReference = symbolReference;
            IsOptional = isOptional;
        }

        public SymbolReference SymbolReference { get;  }
        public bool IsOptional { get; }

        public override string ToString()
        {
            return SymbolReference.Name;
        }
    }
}