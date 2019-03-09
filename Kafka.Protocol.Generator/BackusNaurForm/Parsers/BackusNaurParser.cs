using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.BackusNaurForm.Parsers
{
    internal class BackusNaurParser
    {
        internal static Specification Parse(IBuffer<char> buffer)
        {
            var specification = new Specification();
            while (buffer.HasNext())
            {
                var symbol = RuleParser.Parse(buffer);
                specification.Rules.Enqueue(symbol);
            }

            return specification;
        }
    }
}