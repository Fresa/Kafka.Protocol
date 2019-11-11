using Kafka.Protocol;
using Test.It.Specifications;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.TestServer.Tests
{
    public partial class Given_a_kafka_test_framework_and_a_message_subscription
    {
        public partial class When_the_client_sends_the_message_subscribed : XUnit2Specification
        {
            private KafkaTestFramework _testServer;

            protected override void Given()
            {
                _testServer = new KafkaTestFramework();
                _testServer.On<ApiVersionsRequest, ApiVersionsResponse>(
                    request => new ApiVersionsResponse(2)
                        .WithThrottleTimeMs(Int32.From(100))
                        .WithApiKeysCollection(
                            key => key
                                .WithIndex(Int16.From(1))
                                .WithMaxVersion(Int16.From(10))
                                .WithMinVersion(Int16.From(0))));
            }

            protected override void When()
            {
                //_testServer.Send()
            }

            [Fact]
            public void The_subscription_should_receive_the_message()
            {

            }
        }
    }
}