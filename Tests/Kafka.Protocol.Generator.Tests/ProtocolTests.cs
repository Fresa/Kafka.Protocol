using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions;
using Kafka.Protocol.Generator.Definitions.FieldExpression;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Tests
{
    public partial class Given_an_apache_kafka_definition_document
    {       
        public class When_parsing : XUnit2Specification
        {
            static When_parsing()
            {
                var path = Path.Combine(Environment.CurrentDirectory, @"Apache Kafka.html");
                ApacheKafkaDefinitionPage.LoadHtml(File.ReadAllText(path));
            }

            private static readonly HtmlDocument ApacheKafkaDefinitionPage = new HtmlDocument();
            private static readonly Lazy<Protocol> ProtocolLoader = new Lazy<Protocol>(() => Protocol.Load(ApacheKafkaDefinitionPage));

            private Protocol _protocol => ProtocolLoader.Value;

            [Fact]
            public void It_should_have_parsed_errors()
            {
                _protocol.ErrorCodes
                    .Should().HaveCount(78)
                    .And.ContainKey(1)
                    .And.Subject[1].Should().BeEquivalentTo(new ErrorCode
                    {
                        Code = 1,
                        Description = "The requested offset is not within the range of offsets maintained by the server.",
                        Error = "OFFSET_OUT_OF_RANGE",
                        Retriable = false
                    });
            }

            [Fact]
            public void It_should_have_parsed_fetch_message()
            {
                _protocol.Messages
                    .Should().HaveCount(43)
                    .And.ContainKey(1)
                    .And.Subject[1]
                    .Should()
                    .BeEquivalentTo(
                        new Message(
                            1, 
                            "Fetch",
                            new List<Method>()), 
                        options => 
                            options
                                .Excluding(message => 
                                    message
                                        .Methods));
            }

            [Fact]
            public void It_should_have_parsed_fetch_message_requests()
            {
                _protocol.Messages[1]
                    .Methods
                    .Where(method =>
                        method.Type == MethodType.Request)
                    .Should()
                    .HaveCount(11);
            }

            [Fact]
            public void It_should_have_parsed_fetch_message_responses()
            {
                _protocol.Messages[1]
                    .Methods
                    .Where(method =>
                        method.Type == MethodType.Response)
                    .Should()
                    .HaveCount(11);
            }

            [Fact]
            public void It_should_have_parsed_primitives()
            {
                _protocol.PrimitiveTypes
                    .Should()
                    .HaveCount(16)
                    .And.Subject
                    .Values
                    .Select(type => 
                        type.Description)
                    .Should()
                    .NotContainNulls();
            }

            [Fact]
            public void It_should_have_parsed_request_header()
            {
                _protocol.RequestHeader
                    .Should()
                    .BeEquivalentTo(
                        new Header(
                            new HeaderMetaData("Header", MethodType.Request), 
                            new PostFixFieldExpression(new Queue<FieldExpressionToken>()), 
                            new List<Field>()),
                        options =>
                            options
                                .Excluding(header =>
                                    header
                                        .Fields)
                                .Excluding(header => 
                                    header
                                        .PostFixFieldExpression));
            }

            [Fact]
            public void It_should_have_parsed_response_header()
            {
                _protocol.ResponseHeader
                    .Should()
                    .BeEquivalentTo(
                        new Header(
                            new HeaderMetaData("Header", MethodType.Response),
                            new PostFixFieldExpression(new Queue<FieldExpressionToken>()), 
                            new List<Field>()),
                        options =>
                            options
                                .Excluding(header =>
                                    header
                                        .Fields)
                                .Excluding(header =>
                                    header
                                        .PostFixFieldExpression));
            }

            [Fact]
            public void It_should_have_parsed_message_envelope()
            {
                _protocol.MessageEnvelope.Name
                    .Should().Be("RequestOrResponse");
            }
        }
    }
}
