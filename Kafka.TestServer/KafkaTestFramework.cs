using System;
using Kafka.Protocol;

namespace Kafka.TestServer
{
    internal class KafkaTestFramework
    {
        //public static KafkaTestFramework Start()
        //{

        //}

        public KafkaTestFramework On<TClientMethod, TServerMethod>(
            Func<TClientMethod, TServerMethod> subscription)
            where TClientMethod : Message, IRespond<TServerMethod>
            where TServerMethod : Message
        {
            throw new NotImplementedException();
        }
    }
}