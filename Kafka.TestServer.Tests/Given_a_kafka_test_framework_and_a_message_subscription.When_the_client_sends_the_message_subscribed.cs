using System.Threading.Tasks;
using Kafka.Protocol;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.TestServer.Tests
{
    public partial class Given_a_kafka_test_framework_and_a_message_subscription
    {
        public partial class When_the_client_sends_the_message_subscribed : XUnit2SpecificationAsync
        {
            private readonly InMemoryKafkaTestFramework _testServer = 
                KafkaTestFramework.InMemory();

            protected override Task GivenAsync()
            {
                _testServer.On<ApiVersionsRequest, ApiVersionsResponse>(
                    request => request.Respond()
                        .WithThrottleTimeMs(Int32.From(100))
                        .WithApiKeysCollection(
                            key => key
                                .WithIndex(FetchRequest.ApiKey)
                                .WithMinVersion(FetchRequest.MinVersion)
                                .WithMaxVersion(FetchRequest.MaxVersion)));

                return Task.CompletedTask;
            }

            protected override async Task WhenAsync()
            {
                await using (_testServer.Start())
                {
                    var client = await _testServer
                        .CreateRequestClientAsync()
                        .ConfigureAwait(false);
                    
                    await using var _ = client
                        .ConfigureAwait(false);
                    
                    var requestPayload = new RequestPayload(
                        new RequestHeader(RequestHeader.MaxVersion)
                            .WithRequestApiKey(ApiVersionsRequest.ApiKey)
                            .WithRequestApiVersion(ApiVersionsRequest.MaxVersion)
                            .WithCorrelationId(Int32.From(12)),
                        new ApiVersionsRequest(ApiVersionsRequest.MaxVersion));

                    await client
                        .SendAsync(requestPayload)
                        .ConfigureAwait(false);

                    var response = await client
                        .ReadAsync(requestPayload)
                        .ConfigureAwait(false);
                }
            }

            [Fact]
            public void The_subscription_should_receive_the_message()
            {

            }

            protected override async Task DisposeAsync(bool disposing)
            {
                await _testServer
                    .DisposeAsync()
                    .ConfigureAwait(false);
            }
        }
    }
}