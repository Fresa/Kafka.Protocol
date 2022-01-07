using System.IO;
using System.Text;
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
        public partial class Given_a_record
        {
            public class When_calculating_length : XUnit2SpecificationAsync
            {
                private readonly Record _record = new()
                {
                    Attributes = 1,
                    Headers = new[]
                    {
                        new Header()
                    },
                    Key = Encoding.UTF8.GetBytes("key1"),
                    OffsetDelta = 2,
                    TimestampDelta = 3,
                    Value = Encoding.UTF8.GetBytes("value1")
                };

                private int _actualLength;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await _record.WriteToAsync(writer, false, CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    _actualLength = writer.ToArray().Length;
                }

                [Fact]
                public void It_should_return_the_length_of_the_record_being_serialized()
                {
                    _record.GetSize(false).Should()
                        .BeGreaterThan(0)
                        .And.Be(_actualLength);
                }
            }
        }
    }
}