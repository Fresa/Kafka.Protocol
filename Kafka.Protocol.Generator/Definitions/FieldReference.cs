using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions
{
    public class FieldReference : FieldExpressionToken
    {
        internal FieldReference(TypeReference type)
        {
            Type = type;
        }

        public TypeReference Type { get; }
    }
}