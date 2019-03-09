using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions.Parsers
{
    internal class FieldReferenceParser
    {
        internal static FieldReference Parse(SymbolSequence symbolSequence)
        {
            var type =
                ParseTypeReference(
                    new Buffer<char>(
                        symbolSequence.SymbolReference.Name.ToCharArray()));

            return new FieldReference(
                type, 
                symbolSequence.IsOptional);
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