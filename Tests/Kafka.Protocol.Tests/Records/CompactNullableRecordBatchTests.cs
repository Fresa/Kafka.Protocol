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
        public partial class Given_a_compact_nullable_record_batch
        {
            private static readonly CompactNullableRecordBatch RecordBatch = new()
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
                TimestampType =
                    Protocol.Records.RecordBatch.Timestamp.CreateTime,
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
                        await RecordBatch.WriteToAsync(writer,
                                CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    _actualLength = writer.ToArray().Length;
                }

                [Fact]
                public void It_should_report_correct_size()
                {
                    RecordBatch.GetSize().Should().Be(_actualLength);
                }
            }
        }
    }
}