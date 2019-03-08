using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class ExpressionParser
    {
        private readonly IBuffer<char> _buffer;
        private const char End = '\n';

        private ExpressionParser(IBuffer<char> buffer)
        {
            _buffer = buffer;
        }

        private Queue<SymbolSequence> Expression { get; } = new Queue<SymbolSequence>();
        private string _symbolSequence = "";

        internal static Queue<SymbolSequence> Parse(
            IBuffer<char> buffer)
        {
            var parser = new ExpressionParser(buffer);

            while (parser.Next()) { }

            return parser.Expression;
        }

        private bool Next()
        {
            if (_buffer.MoveToNext() == false)
            {
                AddCurrentExpression();
                return false;
            }

            var chr = _buffer.Current;
            if (chr == End)
            {
                AddCurrentExpression();
                return false;
            }

            if (chr == ' ')
            {
                AddCurrentExpression();
                return true;
            }

            _symbolSequence += chr;
            return true;
        }

        private void AddCurrentExpression()
        {
            var symbolSequence = _symbolSequence.Trim();
            _symbolSequence = "";

            if (string.IsNullOrEmpty(symbolSequence))
            {
                return;
            }

            var symbol = ParseSymbolSequence(
                symbolSequence);

            Expression.Enqueue(symbol);
        }

        private SymbolSequence ParseSymbolSequence(
            string symbolSequence)
        {
            var isOptional = false;
            var symbolName = symbolSequence;

            if (symbolSequence.StartsWith("[") &&
                symbolSequence.EndsWith("]"))
            {
                symbolName = symbolSequence.Substring(
                    1,
                    symbolSequence.Length - 2);

                isOptional = true;
            }

            var symbolReference = ParseSymbolReference(new Buffer<char>(symbolName.ToCharArray()));

            return new SymbolSequence(
                symbolReference,
                isOptional);
        }

        private static SymbolReference ParseSymbolReference(IBuffer<char> symbolSequence)
        {
            var name = "";
            SymbolReference genericSymbolReference = null;
            while (symbolSequence.MoveToNext())
            {
                var chr = symbolSequence.Current;
                if (chr == '(')
                {
                    genericSymbolReference = ParseSymbolReference(symbolSequence);
                    continue;
                }

                if (chr == ')')
                {
                    continue;
                }

                name += chr;
            }

            return new SymbolReference(name, genericSymbolReference);
        }
    }
}