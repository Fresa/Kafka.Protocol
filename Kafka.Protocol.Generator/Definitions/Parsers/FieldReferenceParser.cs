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
            return
                ParseTypeReference(
                    new Buffer<char>(
                        symbolSequence.SymbolReference.Name.ToCharArray()));
        }

        private static FieldReference ParseTypeReference(
            IBuffer<char> symbolReferenceName)
        {
            var name = "";
            var isArray = false;
            while (symbolReferenceName.MoveToNext())
            {
                var chr = symbolReferenceName.Current;
                if (chr == '[')
                {
                    isArray = true;
                    continue;
                }

                if (chr == ']')
                {
                    // todo: verify that there is an end bracket
                    continue;
                }

                name += chr;
            }

            return new FieldReference(new TypeReference(name), isArray);
        }
    }
}