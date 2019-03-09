using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.BackusNaurForm.Parsers;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Tests
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
                          record_set => RECORDS(INT32)";
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
                    .Expression.Should().HaveCount(4);
            }

            [Fact]
            public void It_should_have_parsed_message_expression_of_transactional_id()
            {
                _fields.Single(field => field.Symbol.Name == "Produce Request (Version: 7)")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("transactional_id"),
                            false));
            }

            [Fact]
            public void It_should_have_parsed_message_expression_of_acks()
            {
                _fields.Single(field => field.Symbol.Name == "Produce Request (Version: 7)")
                    .Expression
                    .ToArray()[1]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("acks"),
                            false));
            }

            [Fact]
            public void It_should_have_parsed_message_expression_of_timeout()
            {
                _fields.Single(field => field.Symbol.Name == "Produce Request (Version: 7)")
                    .Expression
                    .ToArray()[2]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("timeout"),
                            false));
            }

            [Fact]
            public void It_should_have_parsed_message_expression_of_topic_data()
            {
                _fields.Single(field => field.Symbol.Name == "Produce Request (Version: 7)")
                    .Expression
                    .ToArray()[3]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("topic_data"),
                            true));
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
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_transactional_id_field_expression_of_nullable_string()
            {
                _fields.Single(field => field.Symbol.Name == "transactional_id")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("NULLABLE_STRING"),
                            false));
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
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_acks_field_expression_of_INT16()
            {
                _fields.Single(field => field.Symbol.Name == "acks")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("INT16"),
                            false));
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
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_timeout_field_expression_of_INT32()
            {
                _fields.Single(field => field.Symbol.Name == "timeout")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("INT32"),
                            false));
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
                    .Expression
                    .Should()
                    .HaveCount(2);
            }

            [Fact]
            public void It_should_have_parsed_topic_data_field_expression_of_topic()
            {
                _fields.Single(field => field.Symbol.Name == "topic_data")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("topic"),
                            false));
            }

            [Fact]
            public void It_should_have_parsed_topic_data_field_expression_of_data()
            {
                _fields.Single(field => field.Symbol.Name == "topic_data")
                    .Expression
                    .ToArray()[1]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("data"),
                            true));
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
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_topic_field_expression_of_STRING()
            {
                _fields.Single(field => field.Symbol.Name == "topic")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("STRING"),
                            false));
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
                    .Expression
                    .Should()
                    .HaveCount(2);
            }

            [Fact]
            public void It_should_have_parsed_data_field_expression_of_partition()
            {
                _fields.Single(field => field.Symbol.Name == "data")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("partition"),
                            false));
            }

            [Fact]
            public void It_should_have_parsed_data_field_expression_of_record_set()
            {
                _fields.Single(field => field.Symbol.Name == "data")
                    .Expression
                    .ToArray()[1]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("record_set"),
                            false));
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
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_partition_field_expression_of_INT32()
            {
                _fields.Single(field => field.Symbol.Name == "partition")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("INT32"),
                            false));
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
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_record_set_field_expression_of_RECORDS()
            {
                _fields.Single(field => field.Symbol.Name == "record_set")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence(
                            new SymbolReference("RECORDS(INT32)"),
                            false));
            }
        }
    }
}
