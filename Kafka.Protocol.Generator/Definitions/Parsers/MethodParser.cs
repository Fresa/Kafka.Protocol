using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class MethodParser
    {
        internal static Method Parse(Specification specification, IEnumerable<PrimitiveType> primitiveTypes)
        {
            var methodRule = specification.Rules.First();
            var metaData = MethodMetaDataParser.Parse(methodRule.Symbol);

            var types = TypesParser.Parse(specification, primitiveTypes);

            var methodType = types.First(@new => @new.Name == methodRule.Symbol.Name);

            return new Method
            {
                Name = metaData.Name,
                Version = metaData.Version,
                Fields = methodType.Fields,
                Type = metaData.Type
            };
        }
    }
}