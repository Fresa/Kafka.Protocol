using System;
using Kafka.Protocol;

namespace Kafka.TestServer
{
    internal class KafkaTestFramework
    {
        public KafkaTestFramework On<TServerMethod, TClientMethod>()
            where TServerMethod : Message
            where TClientMethod : Message
        {
            throw new NotImplementedException();
        }
    }
}