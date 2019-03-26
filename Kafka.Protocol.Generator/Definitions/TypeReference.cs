namespace Kafka.Protocol.Generator.Definitions
{
    public class TypeReference
    {
        internal TypeReference(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}