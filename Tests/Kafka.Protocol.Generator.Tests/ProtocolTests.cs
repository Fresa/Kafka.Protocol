using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.Helpers.Definitions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Helpers.Tests
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
            private static readonly Lazy<ProtocolSpecification> ProtocolLoader = new Lazy<ProtocolSpecification>(() => ProtocolSpecification.Load(ApacheKafkaDefinitionPage));

            private ProtocolSpecification ProtocolSpecification => ProtocolLoader.Value;

            [Fact]
            public void It_should_have_parsed_errors()
            {
                ProtocolSpecification.ErrorCodes
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
            public void It_should_have_parsed_primitives()
            {
                ProtocolSpecification.PrimitiveTypes
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
