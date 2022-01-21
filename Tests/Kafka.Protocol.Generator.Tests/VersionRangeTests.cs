using FluentAssertions;
using Kafka.Protocol.Generator.Helpers.Definitions;
using Test.It.With.XUnit;
using Xunit;
using Xunit.Abstractions;

namespace Kafka.Protocol.Generator.Helpers.Tests
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
                _range.To.Should().BeNull();
            }

            [Fact]
            public void It_should_indicate_full_range()
            {
                _range.Full.Should().BeTrue();
            }

            [Fact]
            public void It_should_be_a_range()
            {
                _range.None.Should().BeFalse();
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

            [Fact]
            public void It_should_not_indicate_full_range()
            {
                _range.Full.Should().BeFalse();
            }

            [Fact]
            public void It_should_be_a_range()
            {
                _range.None.Should().BeFalse();
            }
        }
    }

    public partial class Given_a_none_range_expression
    {
        public class When_parsing : XUnit2Specification
        {
            private VersionRange _range;

            protected override void Given()
            {
                _range = VersionRange.Parse("none");
            }

            [Fact]
            public void It_should_create_a_range_with_from()
            {
                _range.From.Should().BeNull();
            }

            [Fact]
            public void It_should_create_a_range_with_to()
            {
                _range.To.Should().BeNull();
            }

            [Fact]
            public void It_should_not_indicate_full_range()
            {
                _range.Full.Should().BeFalse();
            }

            [Fact]
            public void It_should_not_be_a_range()
            {
                _range.None.Should().BeTrue();
            }
        }
    }

    public partial class Given_two_ranges
    {
        public class When_getting_the_excepted_subset
        {
            [Theory]
            [InlineData("none", "none", "none")]
            [InlineData("none", "2+", "none")]
            [InlineData("1+", "none", "1+")]
            [InlineData("1-3", "2-3", "1-2")]
            [InlineData("1-3", "1-3", "none")]
            [InlineData("1+", "2+", "1-2")]
            [InlineData("1+", "1+", "none")]
            public void It_should_generate_the_correct_except(string range, string exceptRange, string result)
            {
                VersionRange.Parse(range)
                    .Except(VersionRange.Parse(exceptRange)).Should()
                    .BeEquivalentTo(VersionRange.Parse(result));
            }
        }
    }

    public partial class Given_a_single_version_range_expression
    {
        public class When_parsing : XUnit2Specification
        {
            private VersionRange _range;

            protected override void Given()
            {
                _range = VersionRange.Parse("0");
            }

            [Fact]
            public void It_should_create_a_range_with_from()
            {
                _range.From.Should().Be(0);
            }

            [Fact]
            public void It_should_create_a_range_with_to()
            {
                _range.To.Should().Be(0);
            }

            [Fact]
            public void It_should_not_indicate_full_range()
            {
                _range.Full.Should().BeFalse();
            }

            [Fact]
            public void It_should_be_a_range()
            {
                _range.None.Should().BeFalse();
            }
        }
    }
}