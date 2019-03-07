using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class Method : Symbol
    {
        internal Method(
            string name, 
            string description, 
            int version,
            MethodType type,
            Queue<SymbolSequence> expression, 
            List<Symbol> symbols) 
            : base(name, description)
        {
            Version = version;
            Type = type;
            Symbols = symbols;
            Expression = expression;
        }

        public int Version { get; }
        internal MethodType Type { get; }
        public List<Symbol> Symbols { get; }

    }
}