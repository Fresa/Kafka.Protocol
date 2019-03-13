namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class OrSymbolSequence : OperatorSymbolSequence
    {
        internal OrSymbolSequence()
            : base(new SymbolReference(" | "))
        {
        }

        internal override int Precedence => 1;
    }
}