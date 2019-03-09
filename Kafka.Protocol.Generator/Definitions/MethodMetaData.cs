using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions
{
    internal class MethodMetaData
    {
        internal MethodMetaData(string name, int version, MethodType type)
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