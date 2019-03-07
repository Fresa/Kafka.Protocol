using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Symbol
    {
        internal Symbol(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
        public Queue<SymbolSequence> Expression { get; set; } = new Queue<SymbolSequence>();
    }
}