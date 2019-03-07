using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Method : Symbol
    {
        internal Method(
            string name, 
            int version,
            MethodType type,
            Queue<SymbolSequence> expression, 
            List<Symbol> symbols) 
            : base(name, expression)
        {
            Version = version;
            Type = type;
            Symbols = symbols;
        }

        public int Version { get; }
        internal MethodType Type { get; }
        public List<Symbol> Symbols { get; }
    }
}