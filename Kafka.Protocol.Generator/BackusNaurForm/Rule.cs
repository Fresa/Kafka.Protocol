using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Rule
    {
        internal Rule(Symbol symbol, Queue<SymbolSequence> postFixExpression)
        {
            Symbol = symbol;
            PostFixExpression = postFixExpression;
        }

        public Symbol Symbol { get; }
        public Queue<SymbolSequence> PostFixExpression { get; }
    }
}