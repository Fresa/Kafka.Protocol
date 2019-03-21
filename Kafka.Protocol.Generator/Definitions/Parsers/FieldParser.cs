using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class FieldParser
    {
        internal static Field Parse(Rule rule)
        {
            var fieldExpressionTokens =
                rule.PostFixExpression
                    .Select(FieldReferenceParser.Parse)
                    .ToList();
            
            return new Field(
                rule.Symbol.Name,
                new PostFixFieldExpression(fieldExpressionTokens));
        }
    }
}