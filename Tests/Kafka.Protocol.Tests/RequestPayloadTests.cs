using System;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Log.It;
using Log.It.With.NLog;
using Test.It.With.XUnit;
using Xunit;
using Xunit.Abstractions;

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
                        .ReadFromAsync(_reader,
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

    public partial class Given_a_supported_request_payload
    {
        public class When_reading_the_payload(
            ITestOutputHelper testOutputHelper) : XUnit2SpecificationAsync
        {
            private PipeReader? _reader;
            private RequestPayload? _payload;
            private readonly LogEventListener _logEventListener = new(testOutputHelper);

            protected override async Task GivenAsync()
            {
                _reader = await new byte[]
                    {
                        0, 0, 0, 10, // Length
                        0, 18, // Api Key (ApiRequestVersion)
                        0, 0, // Version
                        0, 0, 0, 0, // Correlation id
                        255, 255 // Client id
                    }.ToReaderAsync()
                    .ConfigureAwait(false);
            }

            protected override async Task WhenAsync()
            {
                _payload = await RequestPayload
                    .ReadFromAsync(_reader!,
                        new CancellationTokenSource(TimeSpan.FromSeconds(2))
                            .Token)
                    .ConfigureAwait(false);
            }

            [Fact]
            public void It_should_have_parsed_the_payload()
            {
                var message = new ApiVersionsRequest(0);
                _payload.Should().NotBeNull()
                    .And.BeEquivalentTo(new RequestPayload(
                        new RequestHeader(message.HeaderVersion)
                            .WithRequestApiKey(message.ApiMessageKey),
                        message));
            }

            protected override Task DisposeAsync(bool disposing)
            {
                _logEventListener.Dispose();
                return base.DisposeAsync(disposing);
            }
        }
    }
}