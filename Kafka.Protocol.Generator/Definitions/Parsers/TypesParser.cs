using System;
using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions.Messages;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal static class TypesParser
    {
        internal static List<Type> Parse(Specification specification, IEnumerable<PrimitiveType> primitiveTypes)
        {
            var reversedRules = specification.Rules.ToList();
            reversedRules.Reverse();

            var types = primitiveTypes.Select(type => new Type
            {
                Name = type.Type
            }).ToList();

            foreach (var rule in reversedRules)
            {
                var operands = new Stack<List<FieldReference>>();

                var type = new Type
                {
                    Name = rule.Symbol.Name
                };

                types.Add(type);

                if (!rule.PostFixExpression.Any())
                {
                    continue;
                }

                foreach (var expressionToken in rule.PostFixExpression)
                {
                    if (expressionToken is OperandSymbolSequence operand)
                    {
                        operands.Push(new List<FieldReference> { FieldReferenceParser.ParseOperand(operand) });
                        continue;
                    }

                    if (expressionToken is AndSymbolSequence)
                    {
                        var references = operands.Pop();
                        references.AddRange(operands.Pop());

                        operands.Push(references);
                        continue;
                    }

                    if (expressionToken is OrSymbolSequence)
                    {
                        throw new NotImplementedException();
                    }
                }

                var fieldReferences = operands.Pop();
                fieldReferences.Reverse();

                foreach (var fieldReference in fieldReferences)
                {
                    type.Fields.Add(
                        new Field(
                            fieldReference,
                            types.First(fieldType => fieldType.Name.Equals(fieldReference.Type.Name, StringComparison.InvariantCultureIgnoreCase)))
                    );
                }
            }

            return types;
        }
    }
}