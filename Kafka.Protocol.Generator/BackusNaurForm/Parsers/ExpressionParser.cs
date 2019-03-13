using System.Collections.Generic;
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

        private PostFixExpression PostFixExpression { get; } = new PostFixExpression();

        private readonly Stack<OperatorSymbolSequence> _operatorStack = new Stack<OperatorSymbolSequence>();

        private string _operandBuffer = "";
        private int _genericParameterLevel;

        internal static PostFixExpression Parse(
            IBuffer<char> buffer)
        {
            var parser = new ExpressionParser(buffer);

            parser.Parse();

            return parser.PostFixExpression;
        }

        private void Parse()
        {
            while (MoveToNext())
            {
                if (ExcessiveWhiteSpaceDetected())
                {
                    continue;
                }

                if (AtStartOfGroup())
                {
                    _operatorStack.Push(
                        SymbolSequence.Operators.StartOfGroup);
                    continue;
                }

                if (AtEndOfGroup())
                {
                    if (TryAddCurrentOperand() == false)
                    {
                        throw _buffer
                            .CreateSyntaxError("Expected an operand before end of group");
                    }

                    while (_operatorStack.Any() &&
                           _operatorStack.Peek() !=
                           SymbolSequence.Operators.StartOfGroup)
                    {
                        PostFixExpression.Enqueue(_operatorStack.Pop());
                    }

                    if (_operatorStack.Any() == false ||
                        _operatorStack.Pop() !=
                        SymbolSequence.Operators.StartOfGroup)
                    {
                        throw _buffer
                            .CreateSyntaxError("Missing '('");
                    }

                    continue;
                }

                if (AtStartOfGenericSymbol())
                {
                    _operandBuffer += _buffer.Current;
                    _genericParameterLevel++;
                    continue;
                }

                if (AtEndOfGenericSymbol())
                {
                    _operandBuffer += _buffer.Current;
                    _genericParameterLevel--;
                    continue;
                }

                if (AtOperator(out var @operator))
                {
                    if (TryAddCurrentOperand() == false)
                    {
                        throw _buffer
                            .CreateSyntaxError($"Expected an operand before an '{@operator}' operator");
                    }

                    PushOperator(@operator);
                    continue;                   
                }

                _operandBuffer += _buffer.Current;
            }

            TryAddCurrentOperand();
            while (_operatorStack.Any())
            {
                PostFixExpression.Enqueue(_operatorStack.Pop());
            }
        }

        private bool MoveToNext()
        {
            var moved = _buffer.MoveToNext();
            if (moved == false)
            {
                return false;
            }

            if (_buffer.CurrentSequenceIs(End))
            {
                return false;
            }

            if (_buffer.CurrentSequenceIs($" {End}"))
            {
                return false;
            }

            if (_buffer.Current == ' ' && _buffer.HasNext() == false)
            {
                return false;
            }

            return true;
        }

        private bool ExcessiveWhiteSpaceDetected()
        {
            return _buffer.CurrentSequenceIs("  ");
        }

        private bool AtStartOfGroup()
        {
            return _buffer.Current == '(' &&
                   _buffer.PeekBehind() == ' ';
        }

        private bool AtEndOfGroup()
        {
            return _buffer.Current == ')' &&
                   _genericParameterLevel == 0;
        }

        private bool AtStartOfGenericSymbol()
        {
            return _buffer.Current == '(' &&
                   _buffer.PeekBehind() != ' ';
        }

        private bool AtEndOfGenericSymbol()
        {
            return _buffer.Current == ')' &&
                   _genericParameterLevel > 0;
        }

        private readonly Dictionary<string, OperatorSymbolSequence> _operators =
            new Dictionary<string, OperatorSymbolSequence>
            {
                {
                    " | ", SymbolSequence.Operators.Or
                },
                {
                    " ", SymbolSequence.Operators.And
                }
            };

        private bool AtOperator(out OperatorSymbolSequence operatorSymbolSequence)
        {
            foreach (var @operator in _operators)
            {
                if (_buffer.CurrentSequenceIs(@operator.Key))
                {
                    _buffer.MoveForward(@operator.Key.Length - 1);
                    operatorSymbolSequence = @operator.Value;
                    return true;
                }
            }

            operatorSymbolSequence = default;
            return false;
        }

        private void PushOperator(OperatorSymbolSequence @operator)
        {
            while (_operatorStack.Any() &&
                   @operator
                       .Precedence <=
                   _operatorStack
                       .Peek()
                       .Precedence)
            {
                PostFixExpression.Enqueue(
                    _operatorStack.Pop());
            }

            _operatorStack.Push(@operator);
        }

        private bool TryAddCurrentOperand()
        {
            var symbolSequence = _operandBuffer.Trim();
            _operandBuffer = "";

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
            var symbolName = symbolSequence;

            if (IsOptional(ref symbolName))
            {
                return SymbolSequence.Operands.Optional(symbolName);
            }

            return SymbolSequence.Operands.Required(symbolName);
        }

        private static bool IsOptional(ref string symbolName)
        {
            if (symbolName.StartsWith("[") &&
                symbolName.EndsWith("]"))
            {
                symbolName = symbolName.Substring(
                    1,
                    symbolName.Length - 2);

                return true;
            }

            return false;
        }
    }
}