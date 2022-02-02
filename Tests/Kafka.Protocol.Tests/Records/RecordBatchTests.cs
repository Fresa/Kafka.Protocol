using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;
using FluentAssertions;
using Kafka.Protocol.Records;
using Xunit;
using Record = Kafka.Protocol.Records.Record;

namespace Kafka.Protocol.Tests.Records
{
    namespace RecordBatchTests
    {
        public partial class Given_a_record_batch
        {
            private static readonly RecordBatch RecordBatch = new()
            {
                Records = new Array<Record>(),
                Attributes = 1,
                BaseOffset = 1,
                BaseSequence = 2,
                FirstTimestamp = 5,
                Magic = 2,
                LastOffsetDelta = 6,
                PartitionLeaderEpoch = 7,
                MaxTimestamp = 8,
                ProducerEpoch = 9,
                ProducerId = 10,
                TimestampType = RecordBatch.Timestamp.CreateTime,
                Compression = RecordBatch.CompressionType.None,
                IsControlBatch = false,
                IsTransactional = true
            };

            private static readonly byte[] SerializedRecordBatch =
            {
                0, 0, 0, 72, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 2,
                245, 128, 13, 119, 0, 0, 0, 0, 0, 0, 0, 0, 1, 126, 182, 115, 70,
                201, 0, 0, 1, 126, 182, 115, 70, 201, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 1, 20, 0,
                0, 0, 1, 8, 116, 101, 115, 116, 0
            };

            public class When_writing : UnitTestSpecificationAsync
            {
                private byte[] _bytes = null!;
                private const bool AsCompact = false;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, AsCompact, CancellationToken)
                            .ConfigureAwait(false);
                    }

                    _bytes = writer.ToArray();
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(AsCompact).Should().Be(_bytes.Length);
                }

                [Fact]
                public async Task It_should_be_readable()
                {
                    var reader = await _bytes.ToReaderAsync()
                        .ConfigureAwait(false);
                    await RecordBatch.FromReaderAsync(reader, AsCompact, CancellationToken)
                        .ConfigureAwait(false);
                    reader.TryRead(out _).Should().BeFalse();
                }
            }

            public class When_reading : UnitTestSpecificationAsync
            {
                private const bool AsCompact = false;
                private RecordBatch _recordBatch = null!;
                private PipeReader _reader = null!;

                protected override async Task WhenAsync()
                {
                    _reader = await SerializedRecordBatch.ToReaderAsync(CancellationToken)
                        .ConfigureAwait(false);
                    _recordBatch = await RecordBatch.FromReaderAsync(_reader,
                            AsCompact, CancellationToken)
                        .ConfigureAwait(false);
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    _recordBatch.GetSize(AsCompact).Should().Be(SerializedRecordBatch.Length);
                }

                [Fact]
                public void It_should_have_been_correctly_deserialized()
                {
                    _recordBatch.Should().BeEquivalentTo(new RecordBatch
                    {
                        Records = new Array<Record>(new Record
                        {
                            Attributes = 0,
                            TimestampDelta = 0,
                            OffsetDelta = 0,
                            Value = new byte[] { 116, 101, 115, 116 },
                            Headers = Array.Empty<Header>()
                        }),
                        BaseOffset = 0,
                        PartitionLeaderEpoch = 0,
                        Magic = 2,
                        Attributes = 0,
                        LastOffsetDelta = 0,
                        FirstTimestamp = 1643738515145,
                        MaxTimestamp = 1643738515145,
                        ProducerId = -1,
                        ProducerEpoch = -1,
                        BaseSequence = -1,
                        Compression = RecordBatch.CompressionType.None,
                        TimestampType = RecordBatch.Timestamp.CreateTime,
                        IsTransactional = false,
                        IsControlBatch = false
                    }, options => options
                        .Excluding(batch => batch.Crc)
                        .Excluding(batch => batch.BatchLength));

                    _recordBatch.BatchLength.Value.Should().Be(60);
                    _recordBatch.Crc.Value.Should().Be(4118809975);
                }

                [Fact]
                public void It_should_have_read_all_bytes()
                {
                    _reader.TryRead(out _).Should().BeFalse();
                }
            }

            public class When_writing_as_compact : UnitTestSpecificationAsync
            {
                private byte[] _bytes = null!;
                private const bool AsCompact = true;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, AsCompact, CancellationToken)
                            .ConfigureAwait(false);
                    }

                    _bytes = writer.ToArray();
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(AsCompact).Should().Be(_bytes.Length);
                }

                [Fact]
                public async Task It_should_be_readable()
                {
                    var reader = await _bytes.ToReaderAsync()
                        .ConfigureAwait(false);
                    await RecordBatch.FromReaderAsync(reader, AsCompact, CancellationToken)
                        .ConfigureAwait(false);
                    reader.TryRead(out _).Should().BeFalse();
                }
            }
        }

        public partial class Given_a_nullable_record_batch
        {
            private static readonly NullableRecordBatch RecordBatch = new()
            {
                Records = new Array<Record>(new Record
                {
                    Value = new byte[] { 1, 2, 3, 4 }
                }),
                Attributes = 1,
                BaseOffset = 1,
                BaseSequence = 2,
                FirstTimestamp = 5,
                Magic = 2,
                LastOffsetDelta = 6,
                PartitionLeaderEpoch = 7,
                MaxTimestamp = 8,
                ProducerEpoch = 9,
                ProducerId = 10,
                TimestampType = Protocol.Records.RecordBatch.Timestamp.CreateTime,
                Compression = Protocol.Records.RecordBatch.CompressionType.None,
                IsControlBatch = false,
                IsTransactional = true
            };

            public class When_writing : UnitTestSpecificationAsync
            {
                private byte[] _bytes = null!;
                private const bool AsCompact = false;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, AsCompact, CancellationToken)
                            .ConfigureAwait(false);
                    }

                    _bytes = writer.ToArray();
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(AsCompact).Should().Be(_bytes.Length);
                }

                [Fact]
                public async Task It_should_be_readable()
                {
                    var reader = await _bytes.ToReaderAsync()
                        .ConfigureAwait(false);
                    await NullableRecordBatch.FromReaderAsync(reader, AsCompact, CancellationToken)
                        .ConfigureAwait(false);
                    reader.TryRead(out _).Should().BeFalse();
                }
            }

            public class When_writing_as_compact : UnitTestSpecificationAsync
            {
                private byte[] _bytes = null!;
                private const bool AsCompact = true;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, AsCompact, CancellationToken)
                            .ConfigureAwait(false);
                    }

                    _bytes = writer.ToArray();
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(AsCompact).Should().Be(_bytes.Length);
                }

                [Fact]
                public async Task It_should_be_readable()
                {
                    var reader = await _bytes.ToReaderAsync()
                        .ConfigureAwait(false);
                    await NullableRecordBatch.FromReaderAsync(reader, AsCompact, CancellationToken)
                        .ConfigureAwait(false);
                    reader.TryRead(out _).Should().BeFalse();
                }
            }

            public class When_writing_null_as_compact : UnitTestSpecificationAsync
            {
                private byte[] _bytes = null!;
                private const bool AsCompact = true;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, AsCompact, CancellationToken)
                            .ConfigureAwait(false);
                    }

                    _bytes = writer.ToArray();
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(AsCompact).Should().Be(_bytes.Length);
                }

                [Fact]
                public async Task It_should_be_readable()
                {
                    var reader = await _bytes.ToReaderAsync()
                        .ConfigureAwait(false);
                    await NullableRecordBatch.FromReaderAsync(reader, AsCompact, CancellationToken)
                        .ConfigureAwait(false);
                    reader.TryRead(out _).Should().BeFalse();
                }
            }
        }

        public partial class Given_a_null_record_batch
        {
            private static readonly NullableRecordBatch RecordBatch = new();

            public class When_writing : UnitTestSpecificationAsync
            {
                private byte[] _bytes = null!;
                private const bool AsCompact = false;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, AsCompact, CancellationToken)
                            .ConfigureAwait(false);
                    }

                    _bytes = writer.ToArray();
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(AsCompact).Should().Be(_bytes.Length);
                }

                [Fact]
                public async Task It_should_be_readable()
                {
                    var reader = await _bytes.ToReaderAsync()
                        .ConfigureAwait(false);
                    await NullableRecordBatch.FromReaderAsync(reader, AsCompact, CancellationToken)
                        .ConfigureAwait(false);
                    reader.TryRead(out _).Should().BeFalse();
                }
            }

            public class When_writing_as_compact : UnitTestSpecificationAsync
            {
                private byte[] _bytes = null!;
                private const bool AsCompact = true;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, AsCompact, CancellationToken)
                            .ConfigureAwait(false);
                    }

                    _bytes = writer.ToArray();
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(AsCompact).Should().Be(_bytes.Length);
                }


                [Fact]
                public async Task It_should_be_readable()
                {
                    var reader = await _bytes.ToReaderAsync()
                        .ConfigureAwait(false);
                    await NullableRecordBatch.FromReaderAsync(reader, AsCompact, CancellationToken)
                        .ConfigureAwait(false);
                    reader.TryRead(out _).Should().BeFalse();
                }
            }
        }
    }
}