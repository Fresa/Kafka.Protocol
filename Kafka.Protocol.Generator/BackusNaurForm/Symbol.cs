using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Symbol
    {
        internal Symbol(string name, Queue<SymbolSequence> expression)
        {
            Name = name;
            Expression = expression;
        }

        public string Name { get; }
        public string Description { get; set; }
        public Queue<SymbolSequence> Expression { get; }
    }
}