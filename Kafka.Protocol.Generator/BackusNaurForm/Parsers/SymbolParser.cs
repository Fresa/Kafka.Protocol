using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.BackusNaurForm.Parsers
{
    internal class SymbolParser
    {
        private const string DefinedAs = "=>";
        private readonly IBuffer<char> _buffer;

        private SymbolParser(IBuffer<char> buffer)
        {
            _buffer = buffer;
        }

        private string _name = "";

        internal static Symbol Parse(IBuffer<char> buffer)
        {
            var parser = new SymbolParser(buffer);

            while (parser.Next()) { }

            return new Symbol(parser._name);
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