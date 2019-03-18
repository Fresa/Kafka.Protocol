using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions
{
    internal class FieldReference : FieldExpressionToken
    {
        public FieldReference(TypeReference type)
        {
            Type = type;
        }

        public TypeReference Type { get; }
    }
}