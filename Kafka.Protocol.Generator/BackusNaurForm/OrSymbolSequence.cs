namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class OrSymbolSequence : OperatorSymbolSequence
    {
        internal OrSymbolSequence()
            : base(new SymbolReference("OR"))
        {
        }

        internal override int Precedence => 1;
    }
}