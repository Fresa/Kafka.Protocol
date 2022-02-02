using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Kafka.Protocol.Records;
using Xunit;
using Record = Kafka.Protocol.Records.Record;

namespace Kafka.Protocol.Tests.Records
{
    namespace RecordBatchTests
    {
        public partial class Given_a_record
        {
            public class When_calculating_length : UnitTestSpecificationAsync
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

                private byte[] _bytes = null!;
                private const bool AsCompact = false;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await _record.WriteToAsync(writer, AsCompact, CancellationToken)
                            .ConfigureAwait(false);
                    }

                    _bytes = writer.ToArray();
                }

                [Fact]
                public void It_should_return_the_length_of_the_record_being_serialized()
                {
                    _record.GetSize(AsCompact).Should()
                        .BeGreaterThan(0)
                        .And.Be(_bytes.Length);
                }

                [Fact]
                public async Task It_should_be_readable()
                {
                    var reader = await _bytes.ToReaderAsync()
                        .ConfigureAwait(false);
                    await Record.FromReaderAsync(reader, AsCompact, CancellationToken)
                        .ConfigureAwait(false);
                    reader.TryRead(out _).Should().BeFalse();
                }
            }
        }
    }
}