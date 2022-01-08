using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Kafka.Protocol.Records;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests.Records
{
    namespace RecordBatchTests
    {
        public partial class Given_a_record_header
        {
            public class When_calculating_length : XUnit2SpecificationAsync
            {
                private readonly Header _header = new()
                {
                    Key = "key1",
                    Value = Encoding.UTF8.GetBytes("value1")
                };

                private int _actualLength;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await _header.WriteToAsync(writer, CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    _actualLength = writer.ToArray().Length;
                }

                [Fact]
                public void It_should_return_the_length_of_the_header_being_serialized()
                {
                    _header.GetSize().Should()
                        .BeGreaterThan(0)
                        .And.Be(_actualLength);
                }
            }
        }
    }
}