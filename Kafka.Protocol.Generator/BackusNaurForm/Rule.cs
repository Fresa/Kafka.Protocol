using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Rule
    {
        internal Rule(Symbol symbol, Queue<SymbolSequence> expression)
        {
            Symbol = symbol;
            Expression = expression;
        }

        public Symbol Symbol { get; }
        public Queue<SymbolSequence> Expression { get; }
    }
}