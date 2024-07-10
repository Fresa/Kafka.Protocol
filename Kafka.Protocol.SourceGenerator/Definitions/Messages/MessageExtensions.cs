namespace Kafka.Protocol.SourceGenerator.Definitions.Messages
{
    internal static class MessageExtensions
    {
        public static bool IsResponse(this Message message)
        {
            return message.Type.ToUpper() == "RESPONSE";
        }

        public static bool IsRequest(this Message message)
        {
            return message.Type.ToUpper() == "REQUEST";
        }

        public static bool IsMessage(this Message message)
        {
            return message.IsRequest() || message.IsResponse();
        }

        public static bool IsHeader(this Message message)
        {
            return message.Type.ToUpper() == "HEADER";
        }

        public static bool IsRequestHeader(this Message message)
        {
            return message.Name.ToUpper() == "REQUESTHEADER";
        }

        public static bool IsData(this Message message)
        {
            return message.Type.ToUpper() == "DATA";
        }

        public static IEnumerable<Field> GetTaggedFields(this Message message) =>
            message.Fields
                .Where(childField => childField.Tag.HasValue)
                .OrderBy(childField => childField.Tag);
    }
}