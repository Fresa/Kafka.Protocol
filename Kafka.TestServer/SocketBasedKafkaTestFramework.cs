using System.Net;

namespace Kafka.TestServer
{
    public sealed class SocketBasedKafkaTestFramework : KafkaTestFramework
    {
        internal SocketBasedKafkaTestFramework()
            : base(SocketServer.Start())
        {
        }

        internal SocketBasedKafkaTestFramework(IPAddress localIpAddress, int port)
            : base(SocketServer.Start(localIpAddress, port))
        {
        }
    }
}