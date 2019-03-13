using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions
{
    internal class FieldReference : FieldExpressionToken
    {
        public FieldReference(TypeReference type, bool isOptional)
        {
            Type = type;
            IsOptional = isOptional;
        }

        public TypeReference Type { get; }
        public bool IsOptional { get; }
        internal override FieldExpressionType ExpressionType => 
            FieldExpressionType.Operand;
    }
}