using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Method : Symbol
    {
        public int Version { get; set; }
        internal MethodType Type { get; set; }
        public List<Symbol> Fields { get; set; } = new List<Symbol>();
    }
}