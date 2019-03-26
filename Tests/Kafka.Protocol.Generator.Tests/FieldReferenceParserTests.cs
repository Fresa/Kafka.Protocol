using FluentAssertions;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions;
using Kafka.Protocol.Generator.Definitions.FieldExpression;
using Kafka.Protocol.Generator.Definitions.Parsers;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Tests
{
    public partial class Given_a_field_reference_parser
    {
        public class When_parsing_a_valid_repeatable_symbol_sequence : XUnit2Specification
        {
            private SymbolSequence _symbolSequence;
            private FieldExpressionToken _fieldReference;

            protected override void Given()
            {
                _symbolSequence = SymbolSequence.Operand(
                    "{INT32}");
            }

            protected override void When()
            {
                _fieldReference = FieldReferenceParser.Parse(_symbolSequence);
            }

            [Fact]
            public void It_should_have_parsed_an_operand()
            {
                _fieldReference
                    .Should().BeOfType<FieldReference>();
            }

            [Fact]
            public void It_should_have_parsed_the_type_name()
            {
                _fieldReference.As<FieldReference>().Type.Name
                    .Should().Be("INT32");
            }

            [Fact]
            public void It_should_have_detected_that_the_field_is_repeatable()
            {
                _fieldReference
                    .As<FieldReference>()
                    .IsRepeatable
                    .Should().BeTrue();                
            }
        }
    }
}