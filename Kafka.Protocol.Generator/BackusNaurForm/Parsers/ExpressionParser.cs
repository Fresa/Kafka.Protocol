using System.Collections.Generic;
using System.Data;
using System.Linq;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.BackusNaurForm.Parsers
{
    internal class ExpressionParser
    {
        private readonly IBuffer<char> _buffer;
        private const string End = "\n";

        private ExpressionParser(IBuffer<char> buffer)
        {
            _buffer = buffer;
        }

        private Queue<SymbolSequence> PostFixExpression { get; } = new Queue<SymbolSequence>();

        private readonly Stack<OperatorSymbolSequence> _operatorStack = new Stack<OperatorSymbolSequence>();

        private string _operand = "";
        private int _genericParameterLevel;

        internal static Queue<SymbolSequence> Parse(
            IBuffer<char> buffer)
        {
            var parser = new ExpressionParser(buffer);

            while (parser.Next()) { }

            return parser.PostFixExpression;
        }

        private bool Next()
        {
            if (_buffer.MoveToNext() == false ||
                _buffer.CurrentSequenceIs(End))
            {
                _buffer.MoveForward(1);
                TryAddCurrentOperand();
                while (_operatorStack.Any())
                {
                    PostFixExpression.Enqueue(_operatorStack.Pop());
                }
                return false;
            }

            var chr = _buffer.Current;

            if (chr == '(')
            {
                if (_buffer.PeekBehind() == ' ')
                {
                    _operatorStack.Push(
                        SymbolSequence.Operators.StartParenthesis);
                    return true;
                }

                _genericParameterLevel++;
            }

            if (chr == ')')
            {
                if (_genericParameterLevel == 0)
                {
                    if (TryAddCurrentOperand() == false)
                    {
                        throw _buffer
                            .CreateSyntaxError("Expected an operand before end of grouping operator");
                    }
                    while (_operatorStack.Any() &&
                           _operatorStack.Peek() !=
                           SymbolSequence.Operators.StartParenthesis)
                    {
                        PostFixExpression.Enqueue(_operatorStack.Pop());
                    }

                    if (_operatorStack.Any() == false ||
                        _operatorStack.Pop() !=
                        SymbolSequence.Operators.StartParenthesis)
                    {
                        throw new SyntaxErrorException("Missing '('");
                    }

                    return true;
                }

                _genericParameterLevel--;
            }

            if (_buffer.CurrentSequenceIs(" | "))
            {
                _buffer.MoveForward(2);
                if (TryAddCurrentOperand() == false)
                {
                    throw _buffer
                        .CreateSyntaxError("Expected an operand before an OR operator");
                }
                PushOperator(SymbolSequence.Operators.Or);
                return true;
            }

            if (chr == ' ' &&
                TryAddCurrentOperand())
            {
                if (_buffer.HasNext() == false)
                {
                    return true;
                }

                if (_buffer.CurrentSequenceIs("  "))
                {
                    return true;
                }

                if (_buffer.CurrentSequenceIs($" {End}"))
                {
                    return true;
                }

                PushOperator(SymbolSequence.Operators.And);

                return true;
            }

            _operand += chr;
            return true;
        }

        private void PushOperator(OperatorSymbolSequence @operator)
        {
            while (_operatorStack.Any() &&
                   @operator.Precedence <= _operatorStack.Peek().Precedence)
            {
                PostFixExpression.Enqueue(_operatorStack.Pop());
            }
            _operatorStack.Push(@operator);
        }

        private bool TryAddCurrentOperand()
        {
            var symbolSequence = _operand.Trim();
            _operand = "";

            if (string.IsNullOrEmpty(symbolSequence))
            {
                return false;
            }

            var symbol = ParseSymbolSequence(
                symbolSequence);

            PostFixExpression.Enqueue(symbol);
            return true;
        }

        private static SymbolSequence ParseSymbolSequence(
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

            if (isOptional)
            {
                return SymbolSequence.Operands.Optional(symbolName);
            }

            return SymbolSequence.Operands.Required(symbolName);
        }
    }
}