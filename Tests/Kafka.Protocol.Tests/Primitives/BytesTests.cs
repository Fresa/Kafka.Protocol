﻿using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests.Primitives
{
    public partial class Given_bytes
    {
        public class When_writing : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[7];
            private readonly Bytes _value = Bytes.From(1, 0, 6);
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
                    .Equal(0, 0, 0, 3, 1, 0, 6);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _value.GetSize(false).Should().Be(7);
            }
        }

        public class When_writing_as_compact : XUnit2SpecificationAsync
        {
            private readonly byte[] _buffer = new byte[4];
            private readonly Bytes _value = Bytes.From(1, 0, 6);
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
                    .Equal(4, 1, 0, 6);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _value.GetSize(true).Should().Be(4);
            }
        }

        public class When_reading : XUnit2SpecificationAsync
        {
            private PipeReader _reader = default!;
            private Bytes _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 3, 1, 0, 6 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await Bytes.FromReaderAsync(_reader, false)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().BeEquivalentTo(1, 0, 6);
            }
        }

        public class When_reading_as_compact : XUnit2SpecificationAsync
        {
            private PipeReader _reader = default!;
            private Bytes _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 4, 1, 0, 6 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await Bytes.FromReaderAsync(_reader, true)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().BeEquivalentTo(1, 0, 6);
            }
        }
    }
}