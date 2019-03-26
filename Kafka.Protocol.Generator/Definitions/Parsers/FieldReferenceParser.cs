using System;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class FieldReferenceParser
    {
        internal static FieldExpressionToken Parse(SymbolSequence symbolSequence)
        {
            switch (symbolSequence)
            {
                case OperandSymbolSequence operand:
                    return ParseOperand(operand);
                case AndSymbolSequence _:
                    return FieldExpressionOperator.And;
                case OrSymbolSequence _:
                    return FieldExpressionOperator.Or;
            }

            throw new InvalidOperationException($"{symbolSequence} is not supported");
        }

        internal static FieldReference ParseOperand(OperandSymbolSequence symbolSequence)
        {
            var type =
                ParseTypeReference(
                    new Buffer<char>(
                        symbolSequence.SymbolReference.Name.ToCharArray()));

            return new FieldReference(type);
        }

        private static TypeReference ParseTypeReference(
            IBuffer<char> symbolReferenceName)
        {
            var name = "";
            TypeReference genericTypeReference = null;
            while (symbolReferenceName.MoveToNext())
            {
                var chr = symbolReferenceName.Current;
                if (chr == '(')
                {
                    genericTypeReference = ParseTypeReference(symbolReferenceName);
                    continue;
                }

                if (chr == ')')
                {
                    continue;
                }

                name += chr;
            }

            return new TypeReference(name, genericTypeReference);
        }
    }
}