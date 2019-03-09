namespace Kafka.Protocol.Generator.Definitions
{
    internal class FieldReference
    {
        public FieldReference(TypeReference type, bool isOptional)
        {
            Type = type;
            IsOptional = isOptional;
        }

        public TypeReference Type { get; }
        public bool IsOptional { get; }
    }
}