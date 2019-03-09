using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Specification
    {
        public Queue<Rule> Rules { get; } = new Queue<Rule>();
    }
}