using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Kafka.Protocol.Cryptography;
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
            public class When_calculating_length : XUnit2SpecificationAsync
            {
                private readonly RecordBatch _recordBatch = new()
                {
                    Records = new []
                    {
                        new Record()
                    },
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

                private int _actualLength;

                protected override async Task WhenAsync()
                {
                    var stream = new MemoryStream();
                    await using (stream.ConfigureAwait(false))
                    {
                        var writer = new KafkaWriter(stream);
                        await using (writer.ConfigureAwait(false))
                        {
                            await _recordBatch.WriteToAsync(writer)
                                .ConfigureAwait(false);
                        }
                    }

                    _actualLength = stream.ToArray().Length;
                }

                [Fact]
                public void It_should_return_the_length_of_the_record_batch_being_serialized()
                {
                    _recordBatch.Length.Should().Be(_actualLength);
                }
            }
        }
    }
}