namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class AndSymbolSequence : OperatorSymbolSequence
    {
        internal AndSymbolSequence()
            : base(new SymbolReference("AND"))
        {
        }

        internal override int Precedence => 2;
    }
}