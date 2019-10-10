using Kafka.Protocol.Generator.Helpers.Extensions;

namespace Kafka.Protocol.Generator.Helpers.BackusNaurForm.Parsers
{
    internal class BackusNaurParser
    {
        internal static Specification Parse(IBuffer<char> buffer)
        {
            var specification = new Specification();
            while (buffer.HasNext())
            {
                var symbol = RuleParser.Parse(buffer);
                specification.Rules.Add(symbol);
            }

            return specification;
        }
    }
}