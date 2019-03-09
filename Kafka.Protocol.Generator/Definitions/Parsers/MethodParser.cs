using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class MethodParser
    {
        internal static Method Parse(Specification specification)
        {
            var methodRule = specification.Rules.Dequeue();
            var metaData = MethodMetaDataParser.Parse(methodRule.Symbol);

            var fieldReferences = FieldParser.Parse(methodRule).FieldReferences;

            var fields = new List<Field>();
            while (specification.Rules.Any())
            {
                var rule = specification.Rules.Dequeue();
                var field = FieldParser.Parse(rule);
                fields.Add(field);
            }

            return new Method(
                metaData,
                fieldReferences,
                fields);
        }
    }
}