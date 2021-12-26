using System;
using System.IO;
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
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[1];
            private readonly Boolean _value = true;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteBooleanAsync(_value)
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
                _writer.SizeOfBoolean(_value).Should().Be(1);
            }
        }

        public class When_writing_false : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[1];
            private readonly Boolean _value = false;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteBooleanAsync(_value)
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
                _writer.SizeOfBoolean(_value).Should().Be(1);
            }
        }

        public class When_writing_int8 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[1];
            private readonly Int8 _value = 65;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteInt8Async(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(65);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfInt8(_value).Should().Be(1);
            }
        }

        public class When_writing_int16 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[2];
            private readonly Int16 _value = 256;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteInt16Async(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(1, 0);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfInt16(_value).Should().Be(2);
            }
        }

        public class When_writing_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[4];
            private readonly Int32 _value = 257;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteInt32Async(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 1, 1);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfInt32(_value).Should().Be(4);
            }
        }

        public class When_writing_int64 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[8];
            private readonly Int64 _value = 65;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteInt64Async(_value)  
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 0, 0, 0, 0, 0, 65);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfInt64(_value).Should().Be(8);
            }
        }

        public class When_writing_an_unsigned_int16 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[2];
            private readonly UInt16 _value = 2;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteUInt16Async(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 2);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfUInt16(_value).Should().Be(2);
            }
        }

        public class When_writing_an_unsigned_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[4];
            private readonly UInt32 _value = 2;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteUInt32Async(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 0, 2);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfUInt32(_value).Should().Be(4);
            }
        }

        public class When_writing_a_string : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[7];
            private readonly String _value = "ABCDE";

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteStringAsync(_value)
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
                _writer.SizeOfString(_value).Should().Be(7);
            }
        }

        public class
            When_writing_a_string_as_nullable_string : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[7];
            private readonly String _value = "ABCDE";

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteNullableStringAsync(_value)
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
                _writer.SizeOfNullableString(_value).Should().Be(7);
            }
        }

        public class
            When_writing_null_as_nullable_string : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[2];
            private readonly String? _value = null;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteNullableStringAsync(_value)
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
                _writer.SizeOfNullableString(_value).Should().Be(2);
            }
        }

        public class When_writing_a_compact_string : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[6];
            private readonly String _value = "ABCDE";

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteCompactStringAsync(_value)
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
                _writer.SizeOfCompactString(_value).Should().Be(6);
            }
        }

        public class When_writing_a_nullable_compact_string : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[6];
            private readonly String _value = "ABCDE";

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteCompactNullableStringAsync(_value)
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
                _writer.SizeOfCompactNullableString(_value).Should().Be(6);
            }
        }

        public class When_writing_null_as_nullable_compact_string : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[1];
            private readonly String? _value = null;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteCompactNullableStringAsync(_value)
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
                _writer.SizeOfCompactNullableString(_value).Should().Be(1);
            }
        }

        public class When_writing_bytes : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[7];
            private readonly Bytes _value = Bytes.From(1, 0, 6);

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteBytesAsync(_value)
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
                _writer.SizeOfBytes(_value).Should().Be(7);
            }
        }

        public class
            When_writing_bytes_as_nullable_bytes : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[7];
            private readonly Bytes _value = Bytes.From(1, 0, 6);

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync() =>
                await _writer.WriteNullableBytesAsync(_value)
                    .ConfigureAwait(false);

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 0, 0, 3, 1, 0, 6);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfBytes(_value).Should().Be(7);
            }
        }

        public class
            When_writing_null_as_nullable_bytes : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[4];
            private readonly Bytes? _value = null;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteNullableBytesAsync(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(255, 255, 255, 255);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfNullableBytes(_value).Should().Be(4);
            }
        }

        public class When_writing_compact_bytes : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[4];
            private readonly Bytes _value = Bytes.From(1, 0, 6);

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteCompactBytesAsync(_value)
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
                _writer.SizeOfCompactBytes(_value).Should().Be(4);
            }
        }

        public class
            When_writing_bytes_as_compact_nullable_bytes : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[4];
            private readonly Bytes _value = Bytes.From(1, 0, 6);

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteCompactNullableBytesAsync(
                        _value)
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
                _writer.SizeOfCompactNullableBytes(_value).Should().Be(4);
            }
        }

        public class
            When_writing_null_as_compact_nullable_bytes : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[1];
            private readonly Bytes? _value = null;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteCompactNullableBytesAsync(_value)
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
                _writer.SizeOfCompactNullableBytes(_value).Should().Be(1);
            }
        }

        public class When_writing_var_int : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[2];
            private readonly VarInt _value = 300;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteVarIntAsync(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(216, 4);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfVarInt(_value).Should().Be(2);
            }
        }

        public class When_writing_uvarint : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[2];
            private readonly UVarInt _value = 300;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteUVarIntAsync(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(172, 2);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfUVarInt(_value).Should().Be(2);
            }
        }

        public class When_writing_var_long : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[2];
            private readonly VarLong _value = 300;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteVarLongAsync(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(216, 4);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfVarLong(_value).Should().Be(2);
            }
        }

        public class When_writing_array_of_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[12];
            private readonly Int32[] _value = { new(257), new(1) };

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteArrayAsync(
                        items: _value)
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
                _writer.SizeOfArray(_value).Should().Be(12);
            }
        }

        public class When_writing_a_compact_array_of_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[9];
            private readonly Int32[] _value = { new(257), new(1) };

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteCompactArrayAsync(
                        items: _value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(3, 0, 0, 1, 1, 0, 0, 0, 1);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfCompactArray(new Int32(257), new Int32(1)).Should().Be(9);
            }
        }

        public class
            When_writing_null_to_array_of_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[4];
            private readonly Int32[]? _value = null;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteNullableArrayAsync(
                        items: _value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(255, 255, 255, 255);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfNullableArray(_value).Should().Be(4);
            }
        }

        public class When_writing_a_nullable_compact_array_of_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[9];
            private readonly Int32[]? _value = { new(257), new(1) };

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteCompactNullableArrayAsync(
                        items: _value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(3, 0, 0, 1, 1, 0, 0, 0, 1);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfCompactNullableArray(_value).Should().Be(9);
            }
        }

        public class When_writing_null_as_a_nullable_compact_array_of_int32 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[1];
            private readonly Int32[]? _value = null;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteCompactNullableArrayAsync<Int32>(
                        items: _value)
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
                _writer.SizeOfCompactNullableArray(_value).Should().Be(1);
            }
        }

        public class When_writing_a_float64 : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[8];
            private readonly Float64 _value = 0.01171875;

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteFloat64Async(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(63, 136, 0, 0, 0, 0, 0, 0);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfFloat64(_value).Should().Be(8);
            }
        }

        public class When_writing_an_uuid : XUnit2SpecificationAsync
        {
            private KafkaWriter _writer = default!;
            private readonly byte[] _buffer = new byte[16];
            private readonly Uuid _value = Guid.Parse("00010203-0405-0607-0809-0a0b0c0d0e0f");

            protected override Task GivenAsync()
            {
                var stream = new MemoryStream(_buffer);
                _writer = new KafkaWriter(stream);
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                await _writer.WriteUuidAsync(_value)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _buffer.Should()
                    .Equal(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            }

            [Fact]
            public void It_should_report_correct_size()
            {
                _writer.SizeOfUuid(_value).Should().Be(16);
            }
        }
    }
}