using FluentAssertions;
using Kafka.Protocol.SourceGenerator.Definitions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.SourceGenerator.UnitTests
{
    public partial class Given_a_primitive_type
    {
        public class When_getting_type_name : XUnit2Specification
        {
            private PrimitiveType _type;
            private string _typeName;

            protected override void Given()
            {
                _type = new PrimitiveType
                {
                    Type = "string"
                };
            }

            protected override void When()
            {
                _typeName = _type.GetTypeName();
            }

            [Fact]
            public void It_should_returned_a_type()
            {
                _typeName.Should().Be("string");
            }
        }
    }
}