using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Kafka.TestServer
{
    public sealed class InMemoryKafkaTestFramework : KafkaTestFramework
    {
        private readonly ITargetBlock<INetworkClient> _clients;

        internal InMemoryKafkaTestFramework(
            BufferBlock<INetworkClient> clients) 
            : base(InMemoryServer.Start(clients))
        {
            _clients = clients;
        }

        public async ValueTask SendAsync(Pipe pipe)
        {
            await _clients.SendAsync(new InMemoryNetworkClient(pipe));
        }

        public async Task<INetworkClient> CreateClientAsync(
            CancellationToken cancellationToken = default)
        {
            var client = new InMemoryNetworkClient(new Pipe());
            await _clients.SendAsync(client, cancellationToken);
            return client;
        }
    }
}