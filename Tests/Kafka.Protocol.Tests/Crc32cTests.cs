using System.Text;
using FluentAssertions;
using Kafka.Protocol.Cryptography;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests
{
    public partial class Given_a_byte_array
    {
        public class When_calculating_crc32c : XUnit2Specification
        {
            private readonly byte[] _data = Encoding.UTF8.GetBytes("hello world");
            private uint _crc;

            protected override void When()
            {
                _crc = Crc32C.Compute(_data);
            }

            [Fact]
            public void It_should_return_a_checksum()
            {
                _crc.Should().Be(3381945770);
            }
        }

        public class When_appending_crc32c : XUnit2Specification
        {
            private readonly byte[] _data = Encoding.UTF8.GetBytes("hello world");
            private uint _crc;

            protected override void When()
            {
                for (var i = 0; i < _data.Length; i++)
                {
                    _crc = Crc32C.Append(_crc, _data[i..(i + 1)]);
                }
            }

            [Fact]
            public void It_should_return_a_checksum()
            {
                _crc.Should().Be(3381945770);
            }
        }
    }
}