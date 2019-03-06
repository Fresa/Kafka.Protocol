using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.BackusNaurForm;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Tests
{
    public partial class Given_a_BNF_parser
    {       
        public class When_parsing_valid_BNF_syntax : XUnit2Specification
        {
            private BackusNaurFormParser _parser;
            private string _syntax;
            private List<Symbol> _fields => _message.Fields;
            private Method _message;

            protected override void Given()
            {
                _parser = new BackusNaurFormParser();
                _syntax =
                    @"Produce Request (Version: 7) => transactional_id acks timeout [topic_data] 
                      transactional_id => NULLABLE_STRING
                      acks => INT16
                      timeout => INT32
                      topic_data => topic [data] 
                        topic => STRING
                        data => partition record_set 
                          partition => INT32
                          record_set => RECORDS";
            }

            protected override void When()
            {
                _message = _parser.Parse(_syntax);
            }

            [Fact]
            public void It_should_have_parsed_all_fields()
            {
                _fields.Should().HaveCount(13);
            }

            [Fact]
            public void It_should_have_parsed_message_name()
            {
                _message.Name.Should().Be("Produce");
            }

            [Fact]
            public void It_should_have_parsed_message_version()
            {
                _message.Version.Should().Be(7);
            }

            [Fact]
            public void It_should_have_parsed_message_expressions()
            {
                _message.Expression.Should().HaveCount(4);
            }

            [Fact]
            public void It_should_have_parsed_message_expression_of_transactional_id()
            {
                _message
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "transactional_id"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_message_expression_of_acks()
            {
                _message
                    .Expression
                    .ToArray()[1]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "acks"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_message_expression_of_timeout()
            {
                _message
                    .Expression
                    .ToArray()[2]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "timeout"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_message_expression_of_topic_data()
            {
                _message
                    .Expression
                    .ToArray()[3]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "topic_data"),
                            IsOptional = true
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_transactional_id_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "transactional_id");
            }

            [Fact]
            public void It_should_have_parsed_transactional_id_field_expressions()
            {
                _fields.Single(field => field.Name == "transactional_id")
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_transactional_id_field_expression_of_nullable_string()
            {
                _fields.Single(field => field.Name == "transactional_id")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "NULLABLE_STRING"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_acks_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "acks");
            }

            [Fact]
            public void It_should_have_parsed_acks_field_expressions()
            {
                _fields.Single(field => field.Name == "acks")
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_acks_field_expression_of_INT16()
            {
                _fields.Single(field => field.Name == "acks")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "INT16"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_timeout_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "timeout");
            }

            [Fact]
            public void It_should_have_parsed_timeout_field_expressions()
            {
                _fields.Single(field => field.Name == "timeout")
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_timeout_field_expression_of_INT32()
            {
                _fields.Single(field => field.Name == "timeout")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "INT32"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_topic_data_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "topic_data");
            }

            [Fact]
            public void It_should_have_parsed_topic_data_field_expressions()
            {
                _fields.Single(field => field.Name == "topic_data")
                    .Expression
                    .Should()
                    .HaveCount(2);
            }

            [Fact]
            public void It_should_have_parsed_topic_data_field_expression_of_topic()
            {
                _fields.Single(field => field.Name == "topic_data")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "topic"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_topic_data_field_expression_of_data()
            {
                _fields.Single(field => field.Name == "topic_data")
                    .Expression
                    .ToArray()[1]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "data"),
                            IsOptional = true
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_topic_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "topic");

            }

            [Fact]
            public void It_should_have_parsed_topic_field_expressions()
            {
                _fields.Single(field => field.Name == "topic")
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_topic_field_expression_of_STRING()
            {
                _fields.Single(field => field.Name == "topic")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "STRING"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_data_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "data");

            }

            [Fact]
            public void It_should_have_parsed_data_field_expressions()
            {
                _fields.Single(field => field.Name == "data")
                    .Expression
                    .Should()
                    .HaveCount(2);
            }

            [Fact]
            public void It_should_have_parsed_data_field_expression_of_partition()
            {
                _fields.Single(field => field.Name == "data")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "partition"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_data_field_expression_of_record_set()
            {
                _fields.Single(field => field.Name == "data")
                    .Expression
                    .ToArray()[1]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "record_set"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_partition_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "partition");

            }

            [Fact]
            public void It_should_have_parsed_partition_field_expressions()
            {
                _fields.Single(field => field.Name == "partition")
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_partition_field_expression_of_INT32()
            {
                _fields.Single(field => field.Name == "partition")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "INT32"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_record_set_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "record_set");

            }

            [Fact]
            public void It_should_have_parsed_record_set_field_expressions()
            {
                _fields.Single(field => field.Name == "record_set")
                    .Expression
                    .Should()
                    .HaveCount(1);
            }

            [Fact]
            public void It_should_have_parsed_record_set_field_expression_of_RECORDS()
            {
                _fields.Single(field => field.Name == "record_set")
                    .Expression
                    .ToArray()[0]
                    .Should().BeEquivalentTo(
                        new SymbolSequence
                        {
                            Reference = _fields.First(field => field.Name == "RECORDS"),
                            IsOptional = false
                        }
                    );
            }

            [Fact]
            public void It_should_have_parsed_NULLABLE_STRING_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "NULLABLE_STRING");

            }

            [Fact]
            public void It_should_have_parsed_NULLABLE_STRING_field_expressions()
            {
                _fields.Single(field => field.Name == "NULLABLE_STRING")
                    .Expression
                    .Should()
                    .HaveCount(0);
            }

            [Fact]
            public void It_should_have_parsed_INT16_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "INT16");

            }

            [Fact]
            public void It_should_have_parsed_INT16_field_expressions()
            {
                _fields.Single(field => field.Name == "INT16")
                    .Expression
                    .Should()
                    .HaveCount(0);
            }

            [Fact]
            public void It_should_have_parsed_INT32_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "INT32");

            }

            [Fact]
            public void It_should_have_parsed_INT32_field_expressions()
            {
                _fields.Single(field => field.Name == "INT32")
                    .Expression
                    .Should()
                    .HaveCount(0);
            }

            [Fact]
            public void It_should_have_parsed_STRING_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "STRING");

            }

            [Fact]
            public void It_should_have_parsed_STRING_field_expressions()
            {
                _fields.Single(field => field.Name == "STRING")
                    .Expression
                    .Should()
                    .HaveCount(0);
            }

            [Fact]
            public void It_should_have_parsed_RECORDS_field_name()
            {
                _fields.Should().ContainSingle(field => field.Name == "RECORDS");

            }

            [Fact]
            public void It_should_have_parsed_RECORDS_field_expressions()
            {
                _fields.Single(field => field.Name == "RECORDS")
                    .Expression
                    .Should()
                    .HaveCount(0);
            }
        }
    }
}
