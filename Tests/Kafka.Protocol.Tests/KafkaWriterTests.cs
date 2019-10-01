using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests
{
    public partial class Given_a_kafka_writer
    {
        public class When_writing_true : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[1];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteBooleanAsync(true);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(1);
            }
        }

        public class When_writing_false : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[1];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteBooleanAsync(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(0);
            }
        }

        public class When_writing_int8 : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[1];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteInt8Async(65);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(65);
            }
        }

        public class When_writing_int16 : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[2];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteInt16Async(256);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(1, 0);
            }
        }

        public class When_writing_int32 : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[4];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteInt32Async(257);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(0, 0, 1, 1);
            }
        }

        public class When_writing_int64 : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[8];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteInt64Async(65);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(0, 0, 0, 0, 0, 0, 0, 65);
            }
        }

        public class When_writing_an_unsigned_int32 : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[4];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteUInt32Async(2);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(0, 0, 0, 2);
            }
        }

        public class When_writing_a_string : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[7];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteStringAsync("ABCDE");
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(0, 5, 65, 66, 67, 68, 69);
            }
        }

        public class When_writing_null_as_string : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[7];
            private Action _action;

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _action = _writer.Invoking(writer => writer.WriteStringAsync(null));
            }

            [Fact]
            public void It_should_throw()
            {
                _action.Should().Throw<ArgumentNullException>();
            }
        }

        public class When_writing_a_string_as_nullable_string : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[7];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteNullableStringAsync("ABCDE");
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(0, 5, 65, 66, 67, 68, 69);
            }
        }

        public class When_writing_null_as_nullable_string : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[2];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteNullableStringAsync(null);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(255, 255);
            }
        }

        public class When_writing_bytes : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[7];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteBytesAsync(new byte[] { 1, 0, 6 });
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(0, 0, 0, 3, 1, 0, 6);
            }
        }

        public class When_writing_bytes_as_nullable_bytes : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[7];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteNullableBytesAsync(new byte[] { 1, 0, 6 });
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(0, 0, 0, 3, 1, 0, 6);
            }
        }

        public class When_writing_null_as_nullable_bytes : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[4];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteNullableBytesAsync(null);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(255, 255, 255, 255);
            }
        }

        public class When_writing_var_int : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[2];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteVarIntAsync(300);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(216, 4);
            }
        }

        public class When_writing_var_long : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[2];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteVarLongAsync(value: 300);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(216, 4);
            }
        }

        public class When_writing_array_of_int32 : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[12];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteAsync(new Int32(257), new Int32(1));
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 1);
            }
        }

        public class When_writing_null_to_array_of_int32 : XUnit2Specification
        {
            private KafkaWriter _writer;
            private readonly byte[] _buffer = new byte[4];

            protected override void Given()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
            }

            protected override void When()
            {
                _writer.WriteAsync<Int32>(null);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should().Equal(255, 255, 255, 255);
            }
        }
    }
}