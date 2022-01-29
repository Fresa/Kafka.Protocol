using System.IO;
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