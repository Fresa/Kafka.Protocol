using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kafka.Protocol.Generator.Helpers.BackusNaurForm;
using Kafka.Protocol.Generator.Helpers.BackusNaurForm.Parsers;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Helpers.Tests
{
    public partial class Given_a_BNF_parser
    {
        public class When_parsing_valid_BNF_syntax : XUnit2Specification
        {
            private string _syntax;
            private List<Rule> _fields => _message.Rules.ToList();
            private Specification _message;

            protected override void Given()
            {
                _syntax =
                    @"Produce Request (Version: 7) => transactional_id acks timeout [topic_data] 
                      transactional_id => NULLABLE_STRING
                      acks => INT16
                      timeout => INT32
                      topic_data => topic [data] 
                        topic => STRING
                        data => partition record_set 
                          partition => INT32
                          record_set => RECORDS(INT32)"
                        .Replace("\r\n", "\n");
            }

            protected override void When()
            {
                _message = BackusNaurParser.Parse(new Buffer<char>(_syntax.ToCharArray()));
            }

            [Fact]
            public void It_should_have_parsed_all_fields()
            {
                _fields.Should().HaveCount(9);
            }

            [Fact]
            public void It_should_have_parsed_message_name()
            {
                _fields.Should().ContainSingle(
                    field => 
                        field.Symbol.Name == "Produce Request (Version: 7)");
            }

            [Fact]
            public void It_should_have_parsed_message_expressions()
            {
                _fields.Single(field => field.Symbol.Name == "Produce Request (Version: 7)")
                    .PostFixExpression
                    .Should()
                    .HaveCount(7)
                    .And
                    .Subject
                    .ToArray()
                    .Should()
                    .BeEquivalentTo(
                        SymbolSequence.Operand(
                            "transactional_id"),
                        SymbolSequence.Operand(
                            "acks"),
                        SymbolSequence.Operators.And,
                        SymbolSequence.Operand(
                            "timeout"),
                        SymbolSequence.Operators.And,
                        SymbolSequence.Operand(
                            "{topic_data}"),
                        SymbolSequence.Operators.And);
            }
            
            [Fact]
            public void It_should_have_parsed_transactional_id_field_name()
            {
                _fields.Should().ContainSingle(field => field.Symbol.Name == "transactional_id");
            }

            [Fact]
            public void It_should_have_parsed_transactional_id_field_expressions()
            {
                _fields.Single(field => field.Symbol.Name == "transactional_id")
                    .PostFixExpression
                    .Should()
                    .HaveCount(1)
                    .And
                    .Subject
                    .ToArray()
                    .Should()
                    .BeEquivalentTo(
                        SymbolSequence.Operand(
                            "NULLABLE_STRING"));
            }

            [Fact]
            public void It_should_have_parsed_acks_field_name()
            {
                _fields.Should().ContainSingle(field => field.Symbol.Name == "acks");
            }

            [Fact]
            public void It_should_have_parsed_acks_field_expressions()
            {
                _fields.Single(field => field.Symbol.Name == "acks")
                    .PostFixExpression
                    .Should()
                    .HaveCount(1)
                    .And
                    .Subject
                    .ToArray()
                    .Should()
                    .BeEquivalentTo(
                        SymbolSequence.Operand(
                            "INT16"));
            }
            
            [Fact]
            public void It_should_have_parsed_timeout_field_name()
            {
                _fields.Should().ContainSingle(field => field.Symbol.Name == "timeout");
            }

            [Fact]
            public void It_should_have_parsed_timeout_field_expressions()
            {
                _fields.Single(field => field.Symbol.Name == "timeout")
                    .PostFixExpression
                    .Should()
                    .HaveCount(1)
                    .And
                    .Subject
                    .ToArray()
                    .Should()
                    .BeEquivalentTo(
                        SymbolSequence.Operand(
                            "INT32"));
            }

            [Fact]
            public void It_should_have_parsed_topic_data_field_name()
            {
                _fields.Should().ContainSingle(field => field.Symbol.Name == "topic_data");
            }

            [Fact]
            public void It_should_have_parsed_topic_data_field_expressions()
            {
                _fields.Single(field => field.Symbol.Name == "topic_data")
                    .PostFixExpression
                    .Should()
                    .HaveCount(3)
                    .And
                    .Subject
                    .ToArray()
                    .Should()
                    .BeEquivalentTo(
                        SymbolSequence.Operand(
                            "topic"),
                        SymbolSequence.Operand(
                            "{data}"),
                        SymbolSequence.Operators.And);
            }

            [Fact]
            public void It_should_have_parsed_topic_field_name()
            {
                _fields.Should().ContainSingle(field => field.Symbol.Name == "topic");

            }

            [Fact]
            public void It_should_have_parsed_topic_field_expressions()
            {
                _fields.Single(field => field.Symbol.Name == "topic")
                    .PostFixExpression
                    .Should()
                    .HaveCount(1)
                    .And
                    .Subject
                    .ToArray()
                    .Should()
                    .BeEquivalentTo(
                        SymbolSequence.Operand(
                            "STRING"));
            }
            
            [Fact]
            public void It_should_have_parsed_data_field_name()
            {
                _fields.Should().ContainSingle(field => field.Symbol.Name == "data");

            }

            [Fact]
            public void It_should_have_parsed_data_field_expressions()
            {
                _fields.Single(field => field.Symbol.Name == "data")
                    .PostFixExpression
                    .Should()
                    .HaveCount(3)
                    .And
                    .Subject
                    .ToArray()
                    .Should()
                    .BeEquivalentTo(
                        SymbolSequence.Operand(
                            "partition"), 
                        SymbolSequence.Operand(
                            "record_set"), 
                        SymbolSequence.Operators.And);
            }
            
            [Fact]
            public void It_should_have_parsed_partition_field_name()
            {
                _fields.Should().ContainSingle(field => field.Symbol.Name == "partition");
            }

            [Fact]
            public void It_should_have_parsed_partition_field_expressions()
            {
                _fields.Single(field => field.Symbol.Name == "partition")
                    .PostFixExpression
                    .Should()
                    .HaveCount(1)
                    .And
                    .Subject
                    .ToArray()
                    .Should()
                    .BeEquivalentTo(
                        SymbolSequence.Operand(
                            "INT32"));
            }

            [Fact]
            public void It_should_have_parsed_record_set_field_name()
            {
                _fields.Should().ContainSingle(field => 
                    field.Symbol.Name == "record_set");

            }

            [Fact]
            public void It_should_have_parsed_record_set_field_expressions()
            {
                _fields.Single(field => field.Symbol.Name == "record_set")
                    .PostFixExpression
                    .Should()
                    .HaveCount(1)
                    .And
                    .Subject
                    .ToArray()
                    .Should()
                    .BeEquivalentTo(
                        SymbolSequence.Operand(
                            "RECORDS(INT32)"));
            }
        }
    }
}
