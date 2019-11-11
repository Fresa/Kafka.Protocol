using System;
using Kafka.Protocol;

namespace Kafka.TestServer
{
    internal class KafkaTestFramework
    {
        //public static KafkaTestFramework Start(string hostname)
        //{

        //}

        public KafkaTestFramework On<TServerMethod, TClientMethod>(
            Func<TServerMethod, TClientMethod> subscription)
            where TServerMethod : Message
            where TClientMethod : Message
        {
            throw new NotImplementedException();
        }
    }
}