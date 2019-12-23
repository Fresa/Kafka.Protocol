namespace Kafka.Protocol.Generator.Helpers.Definitions.Messages
{
    public static class MessageExtensions
    {
        public static bool IsResponse(this Message message)
        {
            return message.Type.ToUpper() == "RESPONSE";
        }

        public static bool IsRequest(this Message message)
        {
            return message.Type.ToUpper() == "REQUEST";
        }
    }
}