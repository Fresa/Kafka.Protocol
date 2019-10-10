namespace Kafka.Protocol.Generator.Helpers.BackusNaurForm
{
    internal class AndSymbolSequence : OperatorSymbolSequence
    {
        internal AndSymbolSequence()
            : base(new SymbolReference(" "))
        {
        }

        internal override int Precedence => 2;
    }
}