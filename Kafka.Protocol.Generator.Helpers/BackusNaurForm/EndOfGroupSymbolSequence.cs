namespace Kafka.Protocol.Generator.Helpers.BackusNaurForm
{
    internal class EndOfGroupSymbolSequence : OperatorSymbolSequence
    {
        internal EndOfGroupSymbolSequence()
            : base(new SymbolReference(")"))
        {
        }

        internal override int Precedence => -1;
    }
}