using System.Collections.Generic;
using FluentAssertions;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.BackusNaurForm.Parsers;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Tests
{
    public partial class Given_an_expression_parser
    {
        public class When_parsing_a_expression_with_or : XUnit2Specification
        {
            private Queue<SymbolSequence> _symbolSequences;
            private string _expression;

            public When_parsing_a_expression_with_or()
            {
            }

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
            public void It_should_have_parsed_the_fields()
            {
                _symbolSequences.ToArray()
                    .Should()
                    .HaveCount(5)
                    .And
                    .Subject
                    .Should()
                    .BeEquivalentTo(
                        SymbolSequence.Operands.Required(
                            "Size"),
                        SymbolSequence.Operands.Required(
                            "RequestMessage"),
                        SymbolSequence.Operands.Required(
                            "ResponseMessage"),
                        SymbolSequence.Operators.Or,
                        SymbolSequence.Operators.And);
            }
        }
    }
}