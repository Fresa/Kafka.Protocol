using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Log.It;
using Log.It.With.NLog;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests
{
    public partial class Given_an_unsupported_request_payload
    {
        public class When_reading_the_payload : XUnit2SpecificationAsync
        {
            private PipeReader _reader;
            private Exception _exceptionCaught;

            static When_reading_the_payload()
            {
                LogFactory.Initialize(new NLogFactory(new LogicalThreadContext()));
            }

            protected override async Task GivenAsync()
            {
                _reader = await new byte[]
                    {
                        0, 0, 0, 10, // Length
                        0, 18, 0, 100, 0, 0, 0, 0, 0, 0 // Header with ApiRequestVersion api key and unsupported version (100)
                    }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                try
                {
                    await RequestPayload
                        .ReadFromAsync(RequestHeader.MaxVersion, _reader,
                            new CancellationTokenSource(TimeSpan.FromSeconds(2))
                                .Token)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _exceptionCaught = ex;
                }
            }

            [Fact]
            public void It_should_throw_unsupported_version()
            {
                _exceptionCaught.Should().BeOfType<UnsupportedVersionException>();
            }
        }
    }
}