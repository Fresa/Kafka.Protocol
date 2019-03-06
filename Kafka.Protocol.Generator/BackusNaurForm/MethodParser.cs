using System.Linq;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class MethodParser
    {
        internal static Method Parse(IBuffer<char> buffer)
        {
            var methodSymbol = MethodSymbolParser.Parse(buffer);

            var symbolCollection = new SymbolCollection();
            var methodExpression = ExpressionParser.Parse(buffer, symbolCollection);

            while (buffer.HasNext())
            {
                RuleParser.Parse(buffer, ref symbolCollection);
            }

            return new Method
            {
                Name = methodSymbol.Name,
                Version = methodSymbol.Version,
                Type = methodSymbol.Type,
                Expression = methodExpression,
                Fields = symbolCollection.Values.ToList()
            };
        }
    }
}