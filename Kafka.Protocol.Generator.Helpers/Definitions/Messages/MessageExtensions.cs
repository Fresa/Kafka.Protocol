using System.Collections.Generic;
using System.Linq;

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

        public static IEnumerable<Field> GetTaggedFields(this Message message) =>
            message.Fields
                .Where(childField => childField.Tag.HasValue)
                .OrderBy(childField => childField.Tag);

        public static IEnumerable<Field> GetNonTaggedFields(this Message message) =>
            message.Fields
                .Where(childField => !childField.Tag.HasValue);
    }
}