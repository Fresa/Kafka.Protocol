using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests
{
    public partial class Given_a_version_range
    {
        public class When_checking_that_values_are_within_the_range : XUnit2Specification
        {
            [Theory]
            [InlineData(-1, false)]
            [InlineData(0, true)]
            [InlineData(2, true)]
            [InlineData(5, true)]
            [InlineData(7, false)]
            public void It_should_report_if_the_value_is_within_range(short value, bool isInRange)
            {
                Int16.From(value).InRange(0, 5).Should().Be(isInRange);
            }
        }
    }
}