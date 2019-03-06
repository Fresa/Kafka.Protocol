using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Symbol
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Queue<SymbolSequence> Expression { get; set; } = new Queue<SymbolSequence>();
    }
}