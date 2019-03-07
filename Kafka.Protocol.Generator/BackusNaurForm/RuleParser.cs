namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class RuleParser
    {
        internal static Symbol Parse(
            IBuffer<char> buffer)
        {
            var symbolName = SymbolNameParser.Parse(buffer);
            
            var expression = ExpressionParser.Parse(buffer);

            return new Symbol(
                symbolName,
                expression);
        }
    }
}