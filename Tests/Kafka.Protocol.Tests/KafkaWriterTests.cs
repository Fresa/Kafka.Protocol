using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests
{
    public partial class Given_a_kafka_writer
    {
        public class When_writing_true : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[1];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteBooleanAsync(Boolean.From(true))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(1);
            }
        }

        public class When_writing_false : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[1];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteBooleanAsync(Boolean.From(false))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0);
            }
        }

        public class When_writing_int8 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[1];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteInt8Async(Int8.From(65))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(65);
            }
        }

        public class When_writing_int16 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[2];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteInt16Async(Int16.From(256))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(1, 0);
            }
        }

        public class When_writing_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[4];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteInt32Async(Int32.From(257))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 1, 1);
            }
        }

        public class When_writing_int64 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[8];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteInt64Async(Int64.From(65))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 0, 0, 0, 0, 0, 65);
            }
        }

        public class When_writing_an_unsigned_int16 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[2];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteUInt16Async(UInt16.From(2))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 2);
            }
        }

        public class When_writing_an_unsigned_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[4];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteUInt32Async(UInt32.From(2))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 0, 2);
            }
        }

        public class When_writing_a_string : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[7];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteStringAsync(String.From("ABCDE"))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 5, 65, 66, 67, 68, 69);
            }
        }

        public class
            When_writing_a_string_as_nullable_string : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[7];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteNullableStringAsync(String.From("ABCDE"))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 5, 65, 66, 67, 68, 69);
            }
        }

        public class
            When_writing_null_as_nullable_string : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[2];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteNullableStringAsync(null)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(255, 255);
            }
        }

        public class When_writing_bytes : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[7];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteBytesAsync(Bytes.From(new byte[] {1, 0, 6}))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 0, 3, 1, 0, 6);
            }
        }

        public class
            When_writing_bytes_as_nullable_bytes : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[7];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteNullableBytesAsync(
                        Bytes.From(new byte[] {1, 0, 6}))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 0, 3, 1, 0, 6);
            }
        }

        public class
            When_writing_null_as_nullable_bytes : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[4];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteNullableBytesAsync(null)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(255, 255, 255, 255);
            }
        }

        public class When_writing_var_int : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[2];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteVarIntAsync(VarInt.From(300))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(216, 4);
            }
        }

        public class When_writing_var_long : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[2];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteVarLongAsync(VarLong.From(300))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(216, 4);
            }
        }

        public class When_writing_array_of_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[12];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteArrayAsync(
                        CancellationToken.None, new Int32(257), new Int32(1))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 1);
            }
        }

        public class
            When_writing_null_to_array_of_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[4];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteNullableArrayAsync<Int32>(
                        CancellationToken.None, null)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(255, 255, 255, 255);
            }
        }

        public class When_writing_a_float64 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[8];

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteFloat64Async(Float64.From(0.01171875))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(63, 136, 0, 0, 0, 0, 0, 0);
            }
        }
    }
}