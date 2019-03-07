using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Symbol
    {
        internal Symbol(string name, string description, Queue<SymbolSequence> expression)
        {
            Name = name;
            Description = description;
            Expression = expression;
        }

        public string Name { get; }
        public string Description { get; }
        public Queue<SymbolSequence> Expression { get; }
    }
}