using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Tests
{
    public partial class Given_an_apache_kafka_definition_document
    {       
        public class When_parsing : XUnit2Specification
        {
            private readonly HtmlDocument _apacheKafkaDefinitionPage = new HtmlDocument();
            private Protocol _protocol;

            protected override void Given()
            {
                var path = Path.Combine(Environment.CurrentDirectory, @"Apache Kafka.html");
                _apacheKafkaDefinitionPage.LoadHtml(File.ReadAllText(path));
            }

            protected override void When()
            {
                _protocol = Protocol.Load(_apacheKafkaDefinitionPage);
            }

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
            public void It_should_have_fetch_message()
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
                    .HaveCount(14)
                    .And.Subject
                    .Values
                    .Select(type => 
                        type.Description)
                    .Should()
                    .NotContainNulls();
            }
        }
    }
}
