using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class MethodParser
    {
        internal static Method Parse(Specification specification)
        {
            var methodRule = specification.Rules.First();
            var metaData = MethodMetaDataParser.Parse(methodRule.Symbol);

            var postFixFieldExpression = FieldParser
                .Parse(methodRule)
                .PostFixFieldExpression;

            var fields = specification.Rules
                .Skip(1)
                .Select(FieldParser.Parse)
                .ToList();

            return new Method(
                metaData,
                postFixFieldExpression,
                fields);
        }
    }
}