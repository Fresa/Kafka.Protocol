using System;
using System.IO.Pipelines;
using System.Threading.Tasks;
using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests
{
    public partial class Given_a_kafka_reader
    {
        public class When_reading_a_truthy_boolean : XUnit2Specification
        {
            private KafkaReader _reader;
            private bool _value;

            protected override void Given()
            {
                _reader = new KafkaReader(1);
            }

            protected override void When()
            {
                _value = _reader.ReadBoolean();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeTrue();
            }
        }

        public class When_reading_a_falsy_boolean : XUnit2Specification
        {
            private KafkaReader _reader;
            private bool _value;

            protected override void Given()
            {
                _reader = new KafkaReader(0);
            }

            protected override void When()
            {
                _value = _reader.ReadBoolean();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeFalse();
            }
        }

        public class When_reading_int8 : XUnit2Specification
        {
            private KafkaReader _reader;
            private sbyte _value;

            protected override void Given()
            {
                _reader = new KafkaReader(65);
            }

            protected override void When()
            {
                _value = _reader.ReadInt8();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(65);
            }
        }

        public class When_reading_int16 : XUnit2Specification
        {
            private KafkaReader _reader;
            private short _value;

            protected override void Given()
            {
                _reader = new KafkaReader(1, 0);
            }

            protected override void When()
            {
                _value = _reader.ReadInt16();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(256);
            }
        }

        public class When_reading_int32 : XUnit2Specification
        {
            private KafkaReader _reader;
            private int _value;

            protected override void Given()
            {
                _reader = new KafkaReader(0, 0, 1, 1);
            }

            protected override void When()
            {
                _value = _reader.ReadInt32();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(257);
            }
        }

        public class When_reading_int64 : XUnit2Specification
        {
            private KafkaReader _reader;
            private long _value;

            protected override void Given()
            {
                _reader = new KafkaReader(0, 0, 0, 0, 0, 0, 0, 65);
            }

            protected override void When()
            {
                _value = _reader.ReadInt64();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(65);
            }
        }

        public class When_reading_an_unsigned_int32 : XUnit2Specification
        {
            private KafkaReader _reader;
            private uint _value;

            protected override void Given()
            {
                _reader = new KafkaReader(0, 0, 0, 2);
            }

            protected override void When()
            {
                _value = _reader.ReadUInt32();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(2);
            }
        }

        public class When_reading_a_string : XUnit2Specification
        {
            private KafkaReader _reader;
            private string _value;

            protected override void Given()
            {
                _reader = new KafkaReader(0, 5, 65, 66, 67, 68, 69);
            }

            protected override void When()
            {
                _value = _reader.ReadString();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be("ABCDE");
            }
        }

        public class When_reading_a_nullable_string : XUnit2Specification
        {
            private KafkaReader _reader;
            private string _value;

            protected override void Given()
            {
                _reader = new KafkaReader(0, 5, 65, 66, 67, 68, 69);
            }

            protected override void When()
            {
                _value = _reader.ReadNullableString();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be("ABCDE");
            }
        }

        public class When_reading_a_null_string : XUnit2Specification
        {
            private KafkaReader _reader;
            private string _value;

            protected override void Given()
            {
                _reader = new KafkaReader(255, 255);
            }

            protected override void When()
            {
                _value = _reader.ReadNullableString();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(null);
            }
        }

        public class When_reading_bytes : XUnit2Specification
        {
            private KafkaReader _reader;
            private byte[] _value;

            protected override void Given()
            {
                _reader = new KafkaReader(0, 0, 0, 3, 1, 0, 6);
            }

            protected override void When()
            {
                _value = _reader.ReadBytes();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeEquivalentTo(1, 0, 6);
            }
        }

        public class When_reading_nullable_bytes : XUnit2Specification
        {
            private KafkaReader _reader;
            private byte[] _value;

            protected override void Given()
            {
                _reader = new KafkaReader(0, 0, 0, 3, 1, 0, 6);
            }

            protected override void When()
            {
                _value = _reader.ReadNullableBytes();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeEquivalentTo(1, 0, 6);
            }
        }

        public class When_reading_a_null_byte_array : XUnit2Specification
        {
            private KafkaReader _reader;
            private byte[] _value;

            protected override void Given()
            {
                _reader = new KafkaReader(255, 255, 255, 255);
            }

            protected override void When()
            {
                _value = _reader.ReadNullableBytes();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeNull();
            }
        }

        public class When_reading_var_int : XUnit2Specification
        {
            private KafkaReader _reader;
            private int _value;

            protected override void Given()
            {
                _reader = new KafkaReader(216, 4);
            }

            protected override void When()
            {
                _value = _reader.ReadVarInt();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(300);
            }
        }

        public class When_reading_var_long : XUnit2Specification
        {
            private KafkaReader _reader;
            private long _value;

            protected override void Given()
            {
                _reader = new KafkaReader(216, 4);
            }

            protected override void When()
            {
                _value = _reader.ReadVarLong();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(300);
            }
        }

        public class When_reading_array_of_int32 : XUnit2Specification
        {
            private KafkaReader _reader;
            private Int32[] _value;

            protected override void Given()
            {
                _reader = new KafkaReader(0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 1);
            }

            protected override void When()
            {
                _value = _reader.Read(() => new Int32());
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeEquivalentTo(new Int32(257), new Int32(1));
            }
        }

        public class When_reading_a_null_array_of_int32 : XUnit2Specification
        {
            private KafkaReader _reader;
            private Int32[] _value;

            protected override void Given()
            {
                _reader = new KafkaReader(255, 255, 255, 255);
            }

            protected override void When()
            {
                _value = _reader.Read(() => new Int32());
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeNull();
            }
        }
    }

    public partial class Given_a_kafka_reader_2
    {
        public class When_reading_a_truthy_boolean : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private bool _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 1 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadBooleanAsync();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeTrue();
            }
        }

        public class When_reading_a_falsy_boolean : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private bool _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadBooleanAsync();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeFalse();
            }
        }

        public class When_reading_int8 : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private sbyte _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 65 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadInt8Async();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(65);
            }
        }

        public class When_reading_int16 : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private short _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 1, 0 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadInt16Async();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(256);
            }
        }

        public class When_reading_int32 : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private int _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 1, 1 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadInt32Async();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(257);
            }
        }

        public class When_reading_int64 : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private long _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 0, 0, 0, 0, 65 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadInt64Async();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(65);
            }
        }

        public class When_reading_an_unsigned_int32 : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private uint _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 2 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadUInt32Async();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(2);
            }
        }

        public class When_reading_a_string : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private string _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 5, 65, 66, 67, 68, 69 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadStringAsync();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be("ABCDE");
            }
        }

        public class When_reading_a_nullable_string : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private string _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 5, 65, 66, 67, 68, 69 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadNullableStringAsync();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be("ABCDE");
            }
        }

        public class When_reading_a_null_string : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private string _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 255, 255 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadNullableStringAsync();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(null);
            }
        }

        public class When_reading_bytes : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private byte[] _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 3, 1, 0, 6 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadBytesAsync();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeEquivalentTo(1, 0, 6);
            }
        }

        public class When_reading_nullable_bytes : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private byte[] _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 3, 1, 0, 6 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadNullableBytesAsync();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeEquivalentTo(1, 0, 6);
            }
        }

        public class When_reading_a_null_byte_array : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private byte[] _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 255, 255, 255, 255 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadNullableBytesAsync();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeNull();
            }
        }

        public class When_reading_var_int : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private int _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 216, 4 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadVarIntAsync();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(300);
            }
        }

        public class When_reading_var_long : XUnit2SpecificationAsync
        {
            private KafkaReader2 _reader;
            private long _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 216, 4 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadVarLongAsync();
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(300);
            }
        }

        //public class When_reading_array_of_int32 : XUnit2SpecificationAsync
        //{
        //    private KafkaReader2 _reader;
        //    private Int32[] _value;

        //    protected override async Task GivenAsync()
        //    {
        //        _reader = await new byte[] { 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 1 }.ToReaderAsync();
        //    }

        //    protected override async Task WhenAsync()
        //    {
        //        _value = await _reader.ReadAsync(() => new Int32());
        //    }

        //    [Fact]
        //    public void It_should_parse_correctly()
        //    {
        //        _value.Should().BeEquivalentTo(new Int32(257), new Int32(1));
        //    }
        //}

        //public class When_reading_a_null_array_of_int32 : XUnit2SpecificationAsync
        //{
        //    private KafkaReader2 _reader;
        //    private Int32[] _value;

        //    protected override async Task GivenAsync()
        //    {
        //        _reader = await new byte[] { 255, 255, 255, 255 }.ToReaderAsync();
        //    }

        //    protected override async Task WhenAsync()
        //    {
        //        _value = await _reader.ReadAsync(() => new Int32());
        //    }

        //    [Fact]
        //    public void It_should_parse_correctly()
        //    {
        //        _value.Should().BeNull();
        //    }
        //}
    }

    internal static class ByteExtensions
    {
        internal static async Task<KafkaReader2> ToReaderAsync(this byte[] bytes)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(new ReadOnlyMemory<byte>(bytes));
            return new KafkaReader2(pipe.Reader);
        }
    }
}