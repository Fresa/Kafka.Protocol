using FluentAssertions;
using Kafka.Protocol.Generator.Definitions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Tests
{
    public partial class Given_an_open_end_range_expression
    {
        public class When_parsing : XUnit2Specification
        {
            private VersionRange _range;

            protected override void Given()
            {
                _range = VersionRange.Parse("0+");
            }

            [Fact]
            public void It_should_create_a_range_with_from()
            {
                _range.From.Should().Be(0);
            }

            [Fact]
            public void It_should_create_a_range_with_to()
            {
                _range.To.Should().Be(int.MaxValue);
            }
        }
    }

    public partial class Given_a_closed_end_range_expression
    {
        public class When_parsing : XUnit2Specification
        {
            private VersionRange _range;

            protected override void Given()
            {
                _range = VersionRange.Parse("1-2");
            }

            [Fact]
            public void It_should_create_a_range_with_from()
            {
                _range.From.Should().Be(1);
            }

            [Fact]
            public void It_should_create_a_range_with_to()
            {
                _range.To.Should().Be(2);
            }
        }
    }
}