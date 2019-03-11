using FluentAssertions;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions;
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
            private FieldReference _fieldReference;

            protected override void Given()
            {
                _symbolSequence = new SymbolSequence(
                    new SymbolReference(
                        "ARRAY(INT32)"), 
                    false);
            }

            protected override void When()
            {
                _fieldReference = FieldReferenceParser.Parse(_symbolSequence);
            }

            [Fact]
            public void It_should_have_parsed_the_type_name()
            {
                _fieldReference.Type.Name
                    .Should().Be("ARRAY");
            }

            [Fact]
            public void It_should_have_parsed_the_generic_type_argument()
            {
                _fieldReference
                    .Type
                    .IsGeneric
                    .Should().BeTrue();
                _fieldReference
                    .Type
                    .GenericArgument
                    .Name
                    .Should().Be("INT32");
            }

            [Fact]
            public void It_should_have_mapped_is_optional()
            {
                _fieldReference
                    .IsOptional
                    .Should().BeFalse();
            }
        }
    }
}