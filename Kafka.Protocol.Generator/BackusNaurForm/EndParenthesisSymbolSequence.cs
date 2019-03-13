namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class EndParenthesisSymbolSequence : OperatorSymbolSequence
    {
        internal EndParenthesisSymbolSequence()
            : base(new SymbolReference(")"))
        {
        }

        internal override int Precedence => -1;
    }
}