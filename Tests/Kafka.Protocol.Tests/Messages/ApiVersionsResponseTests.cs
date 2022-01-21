using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests.Messages
{
    namespace RecordBatchTests
    {
        public partial class Given_a_api_versions_response
        {
            public class When_serializing : XUnit2SpecificationAsync
            {
                private readonly ApiVersionsResponse _message = new ApiVersionsResponse(3)
                        .WithAllApiKeys();

                private int _actualLength;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await _message.WriteToAsync(writer, CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    _actualLength = writer.ToArray().Length;
                }

                [Fact]
                public void It_should_return_the_length()
                {
                    _message.GetSize().Should()
                        .BeGreaterThan(0)
                        .And.Be(_actualLength);
                }
            }
        }
    }
}