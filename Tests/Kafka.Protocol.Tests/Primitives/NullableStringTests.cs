using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests.Primitives
{
    public partial class Given_a_nullable_string
    {
        public class When_writing : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[7];
            private readonly NullableString _value = "ABCDE";
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
                    .Equal(0, 5, 65, 66, 67, 68, 69);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _value.GetSize(false).Should().Be(7);
            }
        }

        public class When_writing_null : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[2];
            private readonly NullableString _value = default;
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
                    .Equal(255, 255);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _value.GetSize(false).Should().Be(2);
            }
        }

        public class When_writing_as_compact : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[6];
            private readonly NullableString _value = "ABCDE";
            private MemoryStream _stream = default!;

            protected override Task GivenAsync()
            {
                _stream = new MemoryStream(_buffer);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _value.WriteToAsync(_stream, true)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(6, 65, 66, 67, 68, 69);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _value.GetSize(true).Should().Be(6);
            }
        }

        public class When_writing_null_as_compact : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[1];
            private readonly NullableString _value = default;
            private MemoryStream _stream = default!;

            protected override Task GivenAsync()
            {
                _stream = new MemoryStream(_buffer);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _value.WriteToAsync(_stream, true)
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
                _value.GetSize(true).Should().Be(1);
            }
        }

        public class When_reading : XUnit2SpecificationAsync
        {
            private PipeReader _reader = default!;
            private NullableString _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 5, 65, 66, 67, 68, 69 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await NullableString.FromReaderAsync(_reader, false)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().NotBeNull();
                _value.Value.Should().Be("ABCDE");
            }
        }

        public class When_reading_null : XUnit2SpecificationAsync
        {
            private PipeReader _reader = default!;
            private NullableString _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 255, 255 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await NullableString.FromReaderAsync(_reader, false)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().BeNull();
            }
        }

        public class When_reading_as_compact : XUnit2SpecificationAsync
        {
            private PipeReader _reader = default!;
            private NullableString _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 6, 65, 66, 67, 68, 69 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await NullableString.FromReaderAsync(_reader, true)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().NotBeNull();
                _value.Value.Should().Be("ABCDE");
            }
        }

        public class When_reading_null_as_compact : XUnit2SpecificationAsync
        {
            private PipeReader _reader = default!;
            private NullableString _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await NullableString.FromReaderAsync(_reader, true)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().BeNull();
            }
        }
    }
}