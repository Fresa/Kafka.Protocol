using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests.Primitives
{
    public partial class Given_an_array_of_int32
    {
        public class When_writing : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[12];
            private readonly Array<Int32> _value = Array<Int32>.From(257, 1);
            private MemoryStream _stream = default!;

            protected override Task GivenAsync()
            {
                _stream = new MemoryStream(_buffer);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _value.WriteToAsync(_stream)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 1);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _value.GetSize().Should().Be(12);
            }
        }

        public class When_reading : XUnit2SpecificationAsync
        {
            private PipeReader _reader = default!;
            private Int32[] _value = default!;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 1 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await Array<Int32>.FromReaderAsync(_reader, 
                        () => Int32.FromReaderAsync(_reader))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeEquivalentTo(new Int32(257), new Int32(1));
            }
        }
    }
}