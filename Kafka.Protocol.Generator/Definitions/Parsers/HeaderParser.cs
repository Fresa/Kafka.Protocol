using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class HeaderParser
    {
        internal static Header Parse(Specification specification)
        {
            var headerRule = specification.Rules.Dequeue();
            var metaData = HeaderMetaDataParser.Parse(headerRule.Symbol);

            var fieldReferences = FieldParser.Parse(headerRule).FieldReferences;

            var fields = new List<Field>();
            while (specification.Rules.Any())
            {
                var rule = specification.Rules.Dequeue();
                var field = FieldParser.Parse(rule);
                fields.Add(field);
            }

            return new Header(
                metaData,
                fieldReferences,
                fields);
        }
    }
}