using System.Net;

namespace Kafka.TestServer
{
    public sealed class SocketBasedKafkaTestFramework : KafkaTestFramework
    {
        private readonly SocketServer _socketServer;

        internal SocketBasedKafkaTestFramework(SocketServer socketServer)
            : base(socketServer)
        {
            _socketServer = socketServer;
        }

        public int Port => _socketServer.Port;
    }
}