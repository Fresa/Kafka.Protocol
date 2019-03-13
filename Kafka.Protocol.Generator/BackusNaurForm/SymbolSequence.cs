namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal abstract class SymbolSequence
    {
        internal SymbolSequence(SymbolReference symbolReference, bool isOptional)
        {
            SymbolReference = symbolReference;
            IsOptional = isOptional;
        }

        public SymbolReference SymbolReference { get; }
        public bool IsOptional { get; }

        public override string ToString()
        {
            return SymbolReference.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is SymbolSequence comparingSymbolSequence && this == comparingSymbolSequence;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = GetType().GetHashCode();
                hashCode = (hashCode * 397) ^ SymbolReference.GetHashCode();
                hashCode = (hashCode * 397) ^ IsOptional.GetHashCode();
                return hashCode;
            }
        }
        
        public static bool operator ==(SymbolSequence x, SymbolSequence y)
        {
            if (x is null)
            {
                return y is null;
            }

            if (y is null)
            {
                return false;
            }

            return x.SymbolReference.Name == y.SymbolReference.Name &&
                x.IsOptional == y.IsOptional;
        }

        public static bool operator !=(SymbolSequence x, SymbolSequence y)
        {
            return !(x == y);
        }

        internal static class Operators
        {
            internal static OrSymbolSequence Or =>
                new OrSymbolSequence();
            internal static AndSymbolSequence And =>
                new AndSymbolSequence();
            internal static StartOfGroupSymbolSequence StartOfGroup =>
                new StartOfGroupSymbolSequence();
            internal static EndOfGroupSymbolSequence EndOfGroup =>
                new EndOfGroupSymbolSequence();
        }

        internal static class Operands
        {
            internal static OperandSymbolSequence Optional(string symbolReference)
                => new OperandSymbolSequence(
                    new SymbolReference(symbolReference), true);
            internal static OperandSymbolSequence Required(string symbolReference)
                => new OperandSymbolSequence(
                    new SymbolReference(symbolReference), false);
        }
    }
}