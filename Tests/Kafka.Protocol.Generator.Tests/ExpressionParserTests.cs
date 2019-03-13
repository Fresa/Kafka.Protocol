using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.BackusNaurForm.Parsers;
using Kafka.Protocol.Generator.Definitions;
using Kafka.Protocol.Generator.Definitions.Parsers;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Tests
{
    public partial class Given_an_expression_parser
    {
        public class When_parsing_a_expression_with_or : XUnit2Specification
        {
            private FieldReferenceParser _parser;
            private SymbolSequence _symbolSequence;
            private Queue<SymbolSequence> _symbolSequences;
            private string _expression;

            protected override void Given()
            {
                _expression = "Size (RequestMessage | ResponseMessage)";
            }

            protected override void When()
            {
                _symbolSequences = ExpressionParser.Parse(
                    new Buffer<char>(_expression.ToCharArray()));
            }

            [Fact]
            public void It_should_have_parsed_the_type_name()
            {
                _symbolSequences.Should().HaveCount(5);
            }

            [Fact]
            public void It_should_have_parsed_the_fields()
            {
                _symbolSequences.ToList()[0]
                    .Should().Be(
                        SymbolSequence.Operands.Required(
                            "Size"));
            }

            [Fact]
            public void It_should_have_parsed_the_fields_2()
            {
                _symbolSequences.ToList()[1]
                    .Should().Be(
                        SymbolSequence.Operands.Required(
                            "RequestMessage"));
            }

            [Fact]
            public void It_should_have_parsed_the_fields_3()
            {
                _symbolSequences.ToList()[2]
                    .Should().Be(
                        SymbolSequence.Operands.Required(
                            "ResponseMessage"));
            }

            [Fact]
            public void It_should_have_parsed_the_fields_4()
            {
                _symbolSequences.ToList()[3]
                    .Should().Be(
                        SymbolSequence.Operators.Or);
            }

            [Fact]
            public void It_should_have_parsed_the_fields_5()
            {
                _symbolSequences.ToList()[4]
                    .Should().Be(
                        SymbolSequence.Operators.And);

            }

            [Fact]
            public void Bla()
            {
                infixToPostfix("b*(c+d)")
                    .Should().Be("bcd+*");

            }
        }

        internal static int Prec(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }

        // The main method that converts given infix expression  
        // to postfix expression.   
        public static string infixToPostfix(string exp)
        {
            // initializing empty String for result  
            string result = "";

            // initializing empty stack  
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; ++i)
            {
                char c = exp[i];

                // If the scanned character is an operand, add it to output.  
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }

                // If the scanned character is an '(', push it to the stack.  
                else if (c == '(')
                {
                    stack.Push(c);
                }

                //  If the scanned character is an ')', pop and output from the stack   
                // until an '(' is encountered.  
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        return "Invalid Expression"; // invalid expression 
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else // an operator is encountered 
                {
                    while (stack.Count > 0 && Prec(c) <= Prec(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }

            }

            // pop all the operators from the stack  
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
    }



}