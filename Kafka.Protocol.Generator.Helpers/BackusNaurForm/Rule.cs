namespace Kafka.Protocol.Generator.Helpers.BackusNaurForm
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