namespace Kafka.Protocol.Generator.Definitions
{
    public class TypeReference
    {
        internal TypeReference(string name, TypeReference genericArgument)
        {
            Name = name;
            GenericArgument = genericArgument;
        }

        public string Name { get; }
        public bool IsGeneric => 
            GenericArgument != null;
        public TypeReference GenericArgument { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}