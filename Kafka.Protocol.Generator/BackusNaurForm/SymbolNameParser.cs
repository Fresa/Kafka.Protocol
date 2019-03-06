using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class SymbolNameParser
    {
        private const string DefinedAs = "=>";
        private readonly IBuffer<char> _buffer;

        private SymbolNameParser(IBuffer<char> buffer)
        {
            _buffer = buffer;
        }

        private string _name = "";

        internal static string Parse(IBuffer<char> buffer)
        {
            var parser = new SymbolNameParser(buffer);

            while (parser.Next()) { }

            return parser._name;
        }

        private bool Next()
        {
            if (_buffer.MoveToNext() == false)
            {
                return false;
            }

            var chr = _buffer.Current;
            if (_buffer.CurrentSequenceIs(DefinedAs))
            {
                _buffer.MoveForward(DefinedAs.Length);
                _name = _name.Trim();
                return false;
            }

            _name += chr;
            return true;
        }
    }
}