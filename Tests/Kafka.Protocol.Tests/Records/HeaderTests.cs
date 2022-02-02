using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Kafka.Protocol.Tests.Records
{
    namespace RecordBatchTests
    {
        public partial class Given_a_record_header
        {
            public class When_calculating_length : UnitTestSpecificationAsync
            {
                private readonly Kafka.Protocol.Records.Header _header = new()
                {
                    Key = "key1",
                    Value = Encoding.UTF8.GetBytes("value1")
                };

                private byte[] _bytes = null!;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await _header.WriteToAsync(writer, false, CancellationToken)
                            .ConfigureAwait(false);
                    }

                    _bytes = writer.ToArray();
                }

                [Fact]
                public void It_should_return_the_length_of_the_header_being_serialized()
                {
                    _header.GetSize(false).Should()
                        .BeGreaterThan(0)
                        .And.Be(_bytes.Length);
                }

                [Fact]
                public async Task It_should_be_readable()
                {
                    var reader = await _bytes.ToReaderAsync()
                        .ConfigureAwait(false);
                    await Protocol.Records.Header.FromReaderAsync(reader, true, CancellationToken)
                        .ConfigureAwait(false);
                    reader.TryRead(out _).Should().BeFalse();
                }
            }
        }
    }
}