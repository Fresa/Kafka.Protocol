namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class RuleParser
    {
        internal static Symbol Parse(
            IBuffer<char> buffer,
            ref SymbolCollection symbolCollection)
        {
            var symbolName = SymbolNameParser.Parse(buffer);

            var symbol = symbolCollection.GetOrAdd(
                symbolName, 
                _ => new Symbol(
                    symbolName,
                    ""));

            var expression = ExpressionParser.Parse(buffer, ref symbolCollection);

            symbol.Expression = expression;

            return symbol;
        }
    }
}