using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.Helpers.BackusNaurForm;

namespace Kafka.Protocol.Generator.Helpers.Definitions.Parsers
{
    internal class HeaderParser
    {
        internal static Header Parse(Specification specification, IEnumerable<PrimitiveType> primitiveTypes)
        {
            var headerRule = specification.Rules.First();
            var metaData = HeaderMetaDataParser.Parse(headerRule.Symbol);

            var types = TypesParser.Parse(specification, primitiveTypes);

            var headerType = types.First(@new => @new.Name == headerRule.Symbol.Name);

            return new Header(
                metaData,
                headerType.Fields);
        }
    }
}