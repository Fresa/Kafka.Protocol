using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class FieldParser
    {
        internal static Field Parse(Rule rule)
        {
            var fieldExpressionTokens = new Queue<FieldExpressionToken>();
            while (rule.PostFixExpression.Any())
            {
                var symbolSequence = rule.PostFixExpression.Dequeue();
                var fieldExpressionToken = FieldReferenceParser.Parse(symbolSequence);
                fieldExpressionTokens.Enqueue(fieldExpressionToken);
            }

            return new Field(
                rule.Symbol.Name,
                new PostFixFieldExpression(fieldExpressionTokens));
        }
    }

}