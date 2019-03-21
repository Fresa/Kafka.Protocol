using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class MessageEnvelopeParser
    {
        internal static MessageEnvelope Parse(Specification specification)
        {
            var headerRule = specification.Rules.First();
            
            var postFixFieldExpression = FieldParser
                .Parse(headerRule)
                .PostFixFieldExpression;

            var fields = specification.Rules
                .Skip(1)
                .Select(FieldParser.Parse)
                .ToList();

            return new MessageEnvelope(
                headerRule.Symbol.Name,
                postFixFieldExpression,
                fields);
        }
    }
}