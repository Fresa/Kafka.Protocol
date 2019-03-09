using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class FieldParser
    {
        internal static Field Parse(Rule rule)
        {
            var fieldReferences = new List<FieldReference>();
            while (rule.Expression.Any())
            {
                var symbolSequence = rule.Expression.Dequeue();
                var fieldReference = FieldReferenceParser.Parse(symbolSequence);
                fieldReferences.Add(fieldReference);
            }

            return new Field(
                rule.Symbol.Name,
                fieldReferences);
        }
    }

}