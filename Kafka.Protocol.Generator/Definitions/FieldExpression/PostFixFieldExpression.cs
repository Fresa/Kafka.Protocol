using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Definitions.FieldExpression
{
    internal class PostFixFieldExpression
    {
        internal PostFixFieldExpression(Queue<FieldExpressionToken> expressionTokens)
        {
            ExpressionTokens = expressionTokens;
        }

        internal Queue<FieldExpressionToken> ExpressionTokens { get; }
    }
}