namespace Kafka.Protocol.Generator.Definitions
{
    internal class TypeReference
    {
        public TypeReference(string name, TypeReference genericArgument)
        {
            Name = name;
            GenericArgument = genericArgument;
        }

        public string Name { get; }
        public bool IsGeneric => 
            GenericArgument != null;
        public TypeReference GenericArgument { get; }
    }
}