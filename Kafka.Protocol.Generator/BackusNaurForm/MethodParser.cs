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
            var methodExpression = ExpressionParser.Parse(buffer, ref symbolCollection);

            while (buffer.HasNext())
            {
                RuleParser.Parse(buffer, ref symbolCollection);
            }

            return new Method(
                methodSymbol.Name, 
                "",
                methodSymbol.Version,
                methodSymbol.Type,
                methodExpression,
                symbolCollection.Values.ToList());
        }
    }
}