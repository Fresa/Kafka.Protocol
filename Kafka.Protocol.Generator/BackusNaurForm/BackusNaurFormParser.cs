using System.Linq;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class BackusNaurFormParser
    {
        internal Method Parse(string bnf)
        {
            var chars = new Buffer<char>(bnf.ToArray());

            return MethodParser.Parse(chars);
        }
    }
}