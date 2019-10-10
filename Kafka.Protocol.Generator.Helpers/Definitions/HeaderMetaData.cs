namespace Kafka.Protocol.Generator.Helpers.Definitions
{
    internal class HeaderMetaData
    {
        internal HeaderMetaData(string name, MethodType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        internal MethodType Type { get; }
    }
}