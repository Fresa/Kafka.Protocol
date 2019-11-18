using System.Threading.Tasks.Dataflow;

namespace Kafka.TestServer
{
    public sealed class InMemoryKafkaTestFramework : KafkaTestFramework
    {
        internal InMemoryKafkaTestFramework(
            BufferBlock<INetworkClient> clients) 
            : base(InMemoryServer.Start(clients))
        {
            Clients = clients;
        }

        public ITargetBlock<INetworkClient> Clients { get; set; }
    }
}