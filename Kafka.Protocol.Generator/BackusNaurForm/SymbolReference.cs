using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class SymbolReference
    {
        internal SymbolReference(
            string name)
        {
            Name = name;
        }

        internal SymbolReference(
            string name, 
            SymbolReference genericSymbolReference)
            : this(name)
        {
            GenericSymbolReference = genericSymbolReference;
        }

        public string Name { get; }
        public bool IsGeneric => 
            GenericSymbolReference != null;
        public SymbolReference GenericSymbolReference { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}