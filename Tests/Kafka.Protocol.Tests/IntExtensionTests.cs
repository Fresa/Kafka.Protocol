using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests
{
    public partial class Given_an_int
    {
        public partial class When_getting_value_from_bit_range : XUnit2Specification
        {
            [Theory]
            [InlineData(5, 0, 2, 5)]
            [InlineData(5, 2, 2, 1)]
            [InlineData(8, 0, 2, 0)]
            [InlineData(8, 0, 10, 8)]
            public void It_should_calculate_the_value_of_the_bit_range(int value, int fromBit, int toBit, int result)
            {
                value.GetValueOfBitRange(fromBit, toBit).Should().Be(result);
            }
        }
    }
}