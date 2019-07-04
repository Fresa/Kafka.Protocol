using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests
{
    public partial class Given_a_unsigned_long
    {
        public partial class When_getting_value_from_bit_range : XUnit2Specification
        {
            [Theory]
            [InlineData(5, 0, 2, 5)]
            [InlineData(5, 2, 2, 1)]
            [InlineData(8, 0, 2, 0)]
            [InlineData(8, 0, 10, 8)]
            [InlineData(int.MaxValue, 2, 4, 7)]
            [InlineData(uint.MaxValue, 31, 31, 1)]
            [InlineData(ulong.MaxValue, 62, 63, 3)]
            [InlineData(ulong.MaxValue, 0, 0, 1)]
            public void It_should_calculate_the_value_of_the_bit_range(ulong value, int fromBit, int toBit, ulong result)
            {
                value.GetValueOfBitRange(fromBit, toBit).Should().Be(result);
            }
        }

        public partial class When_setting_a_bit : XUnit2Specification
        {
            [Theory]
            [InlineData(5, 0, false, 4)]
            [InlineData(5, 0, true, 5)]
            [InlineData(5, 3, false, 5)]
            [InlineData(ulong.MaxValue, 5, true, ulong.MaxValue)]
            [InlineData(0, 3, true, 8)]
            [InlineData(0, 63, false, 0)]
            public void It_should_calculate_the_value_of_the_bit_range(ulong value, int bitIndex, bool bitValue, ulong result)
            {
                value.SetBit(bitIndex, bitValue).Should().Be(result);
            }
        }
    }
}