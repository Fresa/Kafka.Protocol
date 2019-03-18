namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal abstract class SymbolSequence
    {
        internal SymbolSequence(SymbolReference symbolReference)
        {
            SymbolReference = symbolReference;
        }

        public SymbolReference SymbolReference { get; }
        
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

            return x.SymbolReference.Name == y.SymbolReference.Name;
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

        internal static OperandSymbolSequence Operand(string symbolReference)
            => new OperandSymbolSequence(
                new SymbolReference(symbolReference));
    }
}