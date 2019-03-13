namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Rule
    {
        internal Rule(Symbol symbol, PostFixExpression postFixExpression)
        {
            Symbol = symbol;
            PostFixExpression = postFixExpression;
        }

        public Symbol Symbol { get; }
        public PostFixExpression PostFixExpression { get; }
    }
}