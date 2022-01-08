using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests.Primitives
{
    public partial class Given_a_compact_nullable_string
    {
        public class When_writing : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[6];
            private readonly CompactNullableString _value = "ABCDE";
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
                    .Equal(6, 65, 66, 67, 68, 69);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _value.GetSize().Should().Be(6);
            }
        }

        public class When_writing_null : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[1];
            private readonly CompactNullableString _value = default;
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
                    .Equal(0);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _value.GetSize().Should().Be(1);
            }
        }
        
        public class When_reading : XUnit2SpecificationAsync
        {
            private PipeReader _reader = default!;
            private CompactNullableString _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 6, 65, 66, 67, 68, 69 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await CompactNullableString.FromReaderAsync(_reader)
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
            private CompactNullableString _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await CompactNullableString.FromReaderAsync(_reader)
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