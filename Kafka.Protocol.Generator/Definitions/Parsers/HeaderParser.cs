using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class HeaderParser
    {
        internal static Header Parse(Specification specification)
        {
            var headerRule = specification.Rules.First();
            var metaData = HeaderMetaDataParser.Parse(headerRule.Symbol);

            var postFixFieldExpression = FieldParser
                .Parse(headerRule)
                .PostFixFieldExpression;

            var fields = 
                specification.Rules.Skip(1)
                    .Select(FieldParser.Parse)
                    .ToList();

            return new Header(
                metaData,
                postFixFieldExpression,
                fields);
        }
    }
}