using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Kafka.Protocol.Records;
using Test.It.With.XUnit;
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
                BatchLength = 3,
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

            public class When_writing : XUnit2SpecificationAsync
            {
                private int _actualLength;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, false, CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    _actualLength = writer.ToArray().Length;
                }
                
                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(false).Should().Be(_actualLength);
                }
            }

            public class When_writing_as_compact : XUnit2SpecificationAsync
            {
                
                private int _actualLength;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, true, CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    _actualLength = writer.ToArray().Length;
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(true).Should().Be(_actualLength);
                }
            }
        }

        public partial class Given_a_nullable_record_batch
        {
            private static readonly NullableRecordBatch RecordBatch = new()
            {
                Records = new Array<Record>(),
                Attributes = 1,
                BaseOffset = 1,
                BaseSequence = 2,
                BatchLength = 3,
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

            public class When_writing : XUnit2SpecificationAsync
            {
                private int _actualLength;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, false, CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    _actualLength = writer.ToArray().Length;
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(false).Should().Be(_actualLength);
                }
            }

            public class When_writing_as_compact : XUnit2SpecificationAsync
            {

                private int _actualLength;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await RecordBatch.WriteToAsync(writer, true, CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    _actualLength = writer.ToArray().Length;
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize(true).Should().Be(_actualLength);
                }
            }
        }
    }
}