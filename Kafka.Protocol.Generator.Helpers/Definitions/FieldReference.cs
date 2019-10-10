using Kafka.Protocol.Generator.Helpers.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Helpers.Definitions
{
    public class FieldReference : FieldExpressionToken
    {
        internal FieldReference(TypeReference type, bool isRepeatable)
        {
            Type = type;
            IsRepeatable = isRepeatable;
        }

        public TypeReference Type { get; }
        public bool IsRepeatable { get; }
    }
}