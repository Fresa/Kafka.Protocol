using System;
using System.Collections.Generic;
using System.Linq;

namespace Kafka.Protocol.Generator.Helpers.Definitions.Messages
{
    public static class EnumerableMessageExtensions
    {
        public static bool TryGetResponseMessageDefinitionFrom(
            this IEnumerable<Message> messageDefinitions,
            Message messageRequest,
            out Message? messageResponse)
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

        public static void AddReferencesToFields(
            this IEnumerable<Message> messageDefinitions)
        {
            foreach (var messageDefinition in messageDefinitions)
            {
                foreach (var field in messageDefinition.Fields)
                {
                    AddReferenceToField(field, null);
                }

                if (messageDefinition.CommonStructs != null)
                {
                    foreach (var field in messageDefinition.CommonStructs.SelectMany(@struct => @struct.Fields))
                    {
                        AddReferenceToField(field, null);
                    }
                }

                void AddReferenceToField(Field field, Field? parent)
                {
                    field.Message = messageDefinition;
                    field.Parent = parent;
                    if (field.Fields == null)
                    {
                        return;
                    }

                    foreach (var child in field.Fields)
                    {
                        AddReferenceToField(child, field);
                    }
                }
            }
        }
    }
}