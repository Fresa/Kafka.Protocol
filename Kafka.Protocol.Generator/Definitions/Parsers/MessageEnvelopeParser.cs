using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class MessageEnvelopeParser
    {
        internal static MessageEnvelope Parse(Specification specification, IEnumerable<PrimitiveType> primitiveTypes)
        {
            var headerRule = specification.Rules.First();
            var types = TypesParser.Parse(specification, primitiveTypes);

            var headerType = types.First(@new => @new.Name == headerRule.Symbol.Name);

            return new MessageEnvelope(
                headerRule.Symbol.Name,
                headerType.Fields);
        }
    }
}