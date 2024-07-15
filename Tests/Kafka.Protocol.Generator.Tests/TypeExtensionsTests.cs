using System.Collections.Generic;
using FluentAssertions;
using Kafka.Protocol.SourceGenerator.Extensions;
using Test.It.With.XUnit;
using Xunit;
using Type = System.Type;

namespace Kafka.Protocol.SourceGenerator.UnitTests
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

        public class When_generating_pretty_name_for_a_generic_array : XUnit2Specification
        {
            private Type _type;
            private string _prettyName;

            protected override void Given()
            {
                _type = typeof(IEnumerable<>).GetGenericArguments()[0].MakeArrayType();
            }

            protected override void When()
            {
                _prettyName = _type.GetPrettyName();
            }

            [Fact]
            public void It_should_have_generated_a_pretty_name()
            {
                _prettyName.Should().Be("T[]");
            }
        }
    }
}