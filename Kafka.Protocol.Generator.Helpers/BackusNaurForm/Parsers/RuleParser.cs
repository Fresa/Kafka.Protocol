namespace Kafka.Protocol.Generator.Helpers.BackusNaurForm.Parsers
{
    internal class RuleParser
    {
        internal static Rule Parse(
            IBuffer<char> buffer)
        {
            var symbolName = SymbolParser.Parse(buffer);
            
            var expression = ExpressionParser.Parse(buffer);

            return new Rule(
                symbolName,
                expression);
        }
    }
}