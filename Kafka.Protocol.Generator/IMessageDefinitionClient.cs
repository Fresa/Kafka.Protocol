using System.Collections.Generic;
using System.Threading.Tasks;
using Kafka.Protocol.Generator.Definitions.Messages;

namespace Kafka.Protocol.Generator
{
    public interface IMessageDefinitionClient
    {
        Task<IEnumerable<Message>> GetMessagesAsync();
    }

    internal class LocalMessageDefinitionClient : IMessageDefinitionClient
    {
        public Task<IEnumerable<Message>> GetMessagesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}