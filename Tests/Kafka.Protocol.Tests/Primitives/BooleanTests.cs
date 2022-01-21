using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests.Primitives
{
    public partial class Given_a_boolean
    {
        public class When_writing_true : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[1];
            private readonly Boolean _value = true;
            private MemoryStream _stream = default!;

            protected override Task GivenAsync()
            {
                _stream = new MemoryStream(_buffer);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _value.WriteToAsync(_stream, false)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(1);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _value.GetSize(false).Should().Be(1);
            }
        }

        public class When_writing_false : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[1];
            private readonly Boolean _value = false;
            private MemoryStream _stream = default!;

            protected override Task GivenAsync()
            {
                _stream = new MemoryStream(_buffer);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _value.WriteToAsync(_stream, false)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _value.GetSize(false).Should().Be(1);
            }
        }

        public class When_reading_a_truthy_boolean : XUnit2SpecificationAsync
        {
            private PipeReader _reader = default!;
            private Boolean _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 1 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await Boolean.FromReaderAsync(_reader, false)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().BeTrue();
            }
        }

        public class When_reading_a_falsy_boolean : XUnit2SpecificationAsync
        {
            private PipeReader _reader = default!;
            private Boolean _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await Boolean.FromReaderAsync(_reader, false)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().BeFalse();
            }
        }
    }
}