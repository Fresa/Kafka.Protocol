﻿using System.Threading.Tasks;
using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests
{
    public partial class Given_a_kafka_reader
    {
        public class When_reading_a_truthy_boolean : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private Boolean _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 1 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadBooleanAsync()
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
            private KafkaReader _reader;
            private Boolean _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadBooleanAsync()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().BeFalse();
            }
        }

        public class When_reading_int8 : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private Int8 _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 65 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadInt8Async()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().Be(65);
            }
        }

        public class When_reading_int16 : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private Int16 _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 1, 0 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadInt16Async()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().Be(256);
            }
        }

        public class When_reading_int32 : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private Int32 _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 1, 1 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadInt32Async()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().Be(257);
            }
        }

        public class When_reading_int64 : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private Int64 _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 0, 0, 0, 0, 65 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadInt64Async()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().Be(65);
            }
        }

        public class When_reading_an_unsigned_int32 : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private UInt32 _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 2 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadUInt32Async()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().Be(2);
            }
        }

        public class When_reading_a_string : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private String _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 5, 65, 66, 67, 68, 69 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadStringAsync()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().Be("ABCDE");
            }
        }

        public class When_reading_a_nullable_string : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private String? _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 5, 65, 66, 67, 68, 69 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadNullableStringAsync()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().NotBeNull();
                _value?.Value.Should().Be("ABCDE");
            }
        }

        public class When_reading_a_null_string : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private String? _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 255, 255 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadNullableStringAsync()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().Be(null);
            }
        }

        public class When_reading_bytes : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private Bytes _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 3, 1, 0, 6 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadBytesAsync()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().BeEquivalentTo(1, 0, 6);
            }
        }

        public class When_reading_nullable_bytes : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private Bytes? _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 3, 1, 0, 6 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadNullableBytesAsync()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().NotBeNull();
                _value?.Value.Should().BeEquivalentTo(1, 0, 6);
            }
        }

        public class When_reading_a_null_byte_array : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private Bytes? _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 255, 255, 255, 255 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadNullableBytesAsync()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeNull();
            }
        }

        public class When_reading_var_int : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private VarInt _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 216, 4 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadVarIntAsync()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().Be(300);
            }
        }

        public class When_reading_var_long : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private VarLong _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 216, 4 }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadVarLongAsync()
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Value.Should().Be(300);
            }
        }

        public class When_reading_array_of_int32 : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private Int32[] _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 1 }.ToReaderAsync();
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader.ReadArrayAsync(
                        async () => await Int32.FromReaderAsync(_reader)
                            .ConfigureAwait(false))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeEquivalentTo(new Int32(257), new Int32(1));
            }
        }

        public class When_reading_a_null_array_of_int32 : XUnit2SpecificationAsync
        {
            private KafkaReader _reader;
            private Int32[] _value;

            protected override async Task GivenAsync()
            {
                _reader = await new byte[] { 255, 255, 255, 255 }
                    .ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _value = await _reader
                    .ReadNullableArrayAsync(
                        async () => await Int32.FromReaderAsync(_reader)
                            .ConfigureAwait(false))
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_parse_correctly()
            {
                _value.Should().BeNull();
            }
        }
    }
}