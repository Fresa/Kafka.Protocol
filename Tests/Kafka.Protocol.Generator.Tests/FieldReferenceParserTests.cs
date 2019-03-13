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
        public class When_parsing_a_valid_symbol_sequence_with_a_generic_symbol_reference : XUnit2Specification
        {
            private FieldReferenceParser _parser;
            private SymbolSequence _symbolSequence;
            private FieldExpressionToken _fieldReference;

            protected override void Given()
            {
                _symbolSequence = SymbolSequence.Operands.Required(
                    "ARRAY(INT32)");
            }

            protected override void When()
            {
                _fieldReference = FieldReferenceParser.Parse(_symbolSequence);
            }

            [Fact]
            public void It_should_have_parsed_a_operand()
            {
                _fieldReference.ExpressionType
                    .Should().Be(FieldExpressionType.Operand);
            }

            [Fact]
            public void It_should_have_parsed_the_type_name()
            {
                _fieldReference.As<FieldReference>().Type.Name
                    .Should().Be("ARRAY");
            }

            [Fact]
            public void It_should_have_parsed_the_generic_type_argument()
            {
                _fieldReference
                    .As<FieldReference>()
                    .Type
                    .IsGeneric
                    .Should().BeTrue();
                _fieldReference
                    .As<FieldReference>()
                    .Type
                    .GenericArgument
                    .Name
                    .Should().Be("INT32");
            }

            [Fact]
            public void It_should_have_mapped_is_optional()
            {
                _fieldReference
                    .As<FieldReference>()
                    .IsOptional
                    .Should().BeFalse();
            }
        }
    }
}