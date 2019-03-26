using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.BackusNaurForm.Parsers
{
    internal class ExpressionParser
    {
        private readonly IBuffer<char> _buffer;
        private const string End = "\n";
        private static readonly string Or = SymbolSequence.Operators.Or.SymbolReference.Name;
        private static readonly string And = SymbolSequence.Operators.And.SymbolReference.Name;
        private static readonly string StartOfGroup = SymbolSequence.Operators.StartOfGroup.SymbolReference.Name;
        private static readonly string EndOfGroup = SymbolSequence.Operators.EndOfGroup.SymbolReference.Name;

        private ExpressionParser(IBuffer<char> buffer)
        {
            _buffer = buffer;
        }

        private PostFixExpression PostFixExpression { get; } = new PostFixExpression();

        private readonly Stack<OperatorSymbolSequence> _operatorStack = new Stack<OperatorSymbolSequence>();

        private string _operandBuffer = "";
        private int _inconsistentArrayDefinitionLevel;

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
                        PostFixExpression.Add(_operatorStack.Pop());
                    }

                    if (_operatorStack.Any() == false ||
                        _operatorStack.Pop() !=
                        SymbolSequence.Operators.StartOfGroup)
                    {
                        throw _buffer
                            .CreateSyntaxError($"Missing '{StartOfGroup}'");
                    }

                    continue;
                }

                if (AtStartOfInconsistentArrayDefinition())
                {
                    _operandBuffer += _buffer.Current;
                    _inconsistentArrayDefinitionLevel++;
                    continue;
                }

                if (AtEndOfInconsistentArrayDefinition())
                {
                    _operandBuffer += _buffer.Current;
                    _inconsistentArrayDefinitionLevel--;
                    continue;
                }

                if (AtOperator(out var @operator))
                {
                    if (TryAddCurrentOperand() == false)
                    {
                        throw _buffer
                            .CreateSyntaxError($"Expected an operand before an operator of '{@operator}' operator");
                    }

                    PushOperator(@operator);
                    continue;                   
                }

                _operandBuffer += _buffer.Current;
            }

            TryAddCurrentOperand();
            while (_operatorStack.Any())
            {
                PostFixExpression.Add(_operatorStack.Pop());
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
            return _buffer.CurrentSequenceIs(StartOfGroup) &&
                   _buffer.PeekBehind() == ' ';
        }

        private bool AtEndOfGroup()
        {
            return _buffer.CurrentSequenceIs(EndOfGroup) &&
                   _inconsistentArrayDefinitionLevel == 0;
        }

        /// <summary>
        /// Not to be mixed up with grouping symbols. It's incorrect BNF syntax, but needs to be handled
        /// </summary>
        /// <returns></returns>
        private bool AtStartOfInconsistentArrayDefinition()
        {
            return _buffer.CurrentSequenceIs(StartOfGroup) &&
                   _buffer.PeekBehind() != ' ';
        }

        /// <summary>
        /// Not to be mixed up with grouping symbols. It's incorrect BNF syntax, but needs to be handled
        /// </summary>
        /// <returns></returns>
        private bool AtEndOfInconsistentArrayDefinition()
        {
            return _buffer.CurrentSequenceIs(EndOfGroup) &&
                   _inconsistentArrayDefinitionLevel > 0;
        }

        private readonly Dictionary<string, OperatorSymbolSequence> _operators =
            new Dictionary<string, OperatorSymbolSequence>
            {
                {
                    Or, SymbolSequence.Operators.Or
                },
                {
                    And, SymbolSequence.Operators.And
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
                PostFixExpression.Add(
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

            PostFixExpression.Add(symbol);
            return true;
        }

        private static SymbolSequence ParseSymbolSequence(
            string symbolSequence)
        {
            var symbolName = symbolSequence;

            HandleInconsistentArraySpecification(ref symbolName);
            
            return SymbolSequence.Operand(symbolName);
        }

        /// <summary>
        /// The specification is inconsistent when it comes to arrays. Sometimes [] is used, sometimes it is ARRAY(). Harmonizing for consistency.
        /// Also note that [] does not mean optional as by the BNF specification but 'array'
        /// </summary>
        /// <param name="symbolName"></param>
        private static void HandleInconsistentArraySpecification(ref string symbolName)
        {
            if (symbolName.StartsWith("ARRAY(") &&
                symbolName.EndsWith(")"))
            {
                symbolName = symbolName.Substring(6, symbolName.Length - 7);
                symbolName = $"[{symbolName}]";
            }
        }
    }
}