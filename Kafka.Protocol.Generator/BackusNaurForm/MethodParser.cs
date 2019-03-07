using System.Collections.Generic;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class MethodParser
    {
        internal static Method Parse(IBuffer<char> buffer)
        {
            var methodSymbol = MethodSymbolParser.Parse(buffer);

            var methodExpression = ExpressionParser.Parse(buffer);

            var symbols = new List<Symbol>();
            while (buffer.HasNext())
            {
                var symbol = RuleParser.Parse(buffer);
                symbols.Add(symbol);
            }

            return new Method(
                methodSymbol.Name, 
                methodSymbol.Version,
                methodSymbol.Type,
                methodExpression,
                symbols);
        }
    }
}