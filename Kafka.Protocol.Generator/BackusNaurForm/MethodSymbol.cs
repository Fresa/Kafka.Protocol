namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class MethodSymbol
    {
        internal MethodSymbol(string name, int version, MethodType type)
        {
            Name = name;
            Version = version;
            Type = type;
        }

        public string Name { get; }
        public int Version { get; }
        internal MethodType Type { get; }

    }
}