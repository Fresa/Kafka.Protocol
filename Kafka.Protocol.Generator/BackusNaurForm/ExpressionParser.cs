using System.Collections.Generic;

namespace Kafka.Protocol.Generator.BackusNaurForm
{
    internal class ExpressionParser
    {
        private readonly IBuffer<char> _buffer;
        private readonly SymbolCollection _symbolCollection;
        private const char End = '\n';

        private ExpressionParser(IBuffer<char> buffer, SymbolCollection symbolCollection)
        {
            _buffer = buffer;
            _symbolCollection = symbolCollection;
        }

        private Queue<SymbolSequence> Expression { get; } = new Queue<SymbolSequence>();
        private string _fieldExpressionBuffer = "";

        internal static Queue<SymbolSequence> Parse(
            IBuffer<char> buffer, 
            SymbolCollection symbolCollection)
        {
            var parser = new ExpressionParser(buffer, symbolCollection);

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

            _fieldExpressionBuffer += chr;
            return true;
        }

        private void AddCurrentExpression()
        {
            var currentFieldExpression = _fieldExpressionBuffer.Trim();
            _fieldExpressionBuffer = "";

            if (string.IsNullOrEmpty(currentFieldExpression))
            {
                return;
            }

            var name = ParseName(currentFieldExpression, out var isOptional);
            var rule = _symbolCollection.GetOrAdd(name, _ => new Symbol { Name = name });

            Expression.Enqueue(new SymbolSequence
            {
                Reference = rule,
                IsOptional = isOptional
            });
        }

        private string ParseName(string expression, out bool isOptional)
        {
            isOptional = false;
            if (expression.StartsWith("[") &&
                expression.EndsWith("]"))
            {
                expression = expression.Substring(1, expression.Length - 2);
                isOptional = true;
            }

            return expression;
        }
    }
}