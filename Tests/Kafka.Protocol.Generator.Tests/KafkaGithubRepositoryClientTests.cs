using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Kafka.Protocol.Generator.Definitions.Messages;
using Newtonsoft.Json;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Generator.Tests
{
    public partial class Given_a_kafka_github_repository_client
    {
        public class When_getting_messages : XUnit2SpecificationAsync
        {
            private KafkaGithubRepositoryClient _client;
            private IEnumerable<Message> _messages;

            protected override Task GivenAsync()
            {
                _client = new KafkaGithubRepositoryClient();
                return base.GivenAsync();
            }

            protected override async Task WhenAsync()
            {
                _messages = await _client.GetMessages();
            }

            [Fact(Skip = "fetches messages from the Kafka Github repository, which will be spammed with requests when using a live test runner like NCrunch")]
            public void It_should_have_fetched_messages()
            {
                _messages.Should().HaveCountGreaterThan(0);
            }
        }
    }
}