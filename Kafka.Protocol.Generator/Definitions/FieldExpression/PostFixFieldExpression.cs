using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Definitions.FieldExpression
{
    public class PostFixFieldExpression
    {
        internal PostFixFieldExpression(List<FieldExpressionToken> expressionTokens)
        {
            ExpressionTokens = expressionTokens;
        }

        public List<FieldExpressionToken> ExpressionTokens { get; }
    }
}