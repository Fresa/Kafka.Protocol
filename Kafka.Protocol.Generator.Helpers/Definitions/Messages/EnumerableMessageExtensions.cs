using System.Collections.Generic;
using System.Linq;

namespace Kafka.Protocol.Generator.Helpers.Definitions.Messages
{
    public static class EnumerableMessageExtensions
    {
        public static bool TryGetResponseMessageDefinitionFrom(
            this IEnumerable<Message> messageDefinitions,
            Message messageRequest,
            out Message messageResponse)
        {
            if (messageRequest.IsResponse())
            {
                messageResponse = default;
                return false;
            }

            messageResponse = messageDefinitions.First(
                message =>
                    message.ApiKey == messageRequest.ApiKey &&
                    message.IsResponse());
            return true;
        }
    }
}