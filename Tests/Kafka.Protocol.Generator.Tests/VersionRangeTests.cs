using FluentAssertions;
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

            [Theory]
            [InlineData(-1, false)]
            [InlineData(0, true)]
            [InlineData(int.MaxValue, true)]
            public void It_should_create_a_valid_range(int version, bool valid)
            {
                _range.IsInRange(version).Should().Be(valid);
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

            [Theory]
            [InlineData(0, false)]
            [InlineData(1, true)]
            [InlineData(2, true)]
            [InlineData(int.MaxValue, false)]
            public void It_should_create_a_valid_range(int version, bool valid)
            {
                _range.IsInRange(version).Should().Be(valid);
            }
        }
    }
}