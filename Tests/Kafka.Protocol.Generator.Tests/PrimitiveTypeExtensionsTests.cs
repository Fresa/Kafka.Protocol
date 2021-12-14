using FluentAssertions;
using Kafka.Protocol.Generator.Helpers.Definitions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Helpers.Tests
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
                    Type = "nullablestring"
                };
            }

            protected override void When()
            {
                _typeName = _type.GetTypeName();
            }

            [Fact]
            public void It_should_returned_a_type()
            {
                _typeName.Should().Be("string?");
            }
        }

        public class When_getting_nullabillity : XUnit2Specification
        {
            private PrimitiveType _type;
            private bool _isNullable;

            protected override void Given()
            {
                _type = new PrimitiveType
                {
                    Type = "nullablestring"
                };
            }

            protected override void When()
            {
                _isNullable = _type.IsNullable();
            }

            [Fact]
            public void It_should_have_returned_nullable()
            {
                _isNullable.Should().BeTrue();
            }
        }
    }
}