namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class StartParenthesisSymbolSequence : OperatorSymbolSequence
    {
        internal StartParenthesisSymbolSequence()
            : base(new SymbolReference("("))
        {
        }

        internal override int Precedence => -1;
    }
}