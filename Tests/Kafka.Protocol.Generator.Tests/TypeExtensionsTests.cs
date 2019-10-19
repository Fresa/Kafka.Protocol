using FluentAssertions;
using Kafka.Protocol.Generator.Helpers.Extensions;
using Test.It.With.XUnit;
using Xunit;
using Type = System.Type;

namespace Kafka.Protocol.Generator.Helpers.Tests
{
    public partial class Given_type_extensions
    {
        public class When_generating_pretty_name_for_a_byte_array : XUnit2Specification
        {
            private Type _type;
            private string _prettyName;

            protected override void Given()
            {
                _type = typeof(byte[]);
            }

            protected override void When()
            {
                _prettyName = _type.GetPrettyName();
            }

            [Fact]
            public void It_should_have_generated_a_pretty_name()
            {
                _prettyName.Should().Be("byte[]");
            }
        }
    }
}