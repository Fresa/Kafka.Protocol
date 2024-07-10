using System.Diagnostics.CodeAnalysis;

namespace Kafka.Protocol.SourceGenerator.Definitions.Messages
{
    internal static class EnumerableMessageExtensions
    {
        public static bool TryGetResponseMessageDefinitionFrom(
            this IEnumerable<Message> messageDefinitions,
            Message messageRequest,
            [NotNullWhen(true)] out Message? messageResponse)
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

        public static Message AddReferencesToFields(
            this Message messageDefinition)
        {
            foreach (var field in messageDefinition.Fields)
            {
                field.Message = messageDefinition;
                AddReferenceToField(field);
            }

            if (messageDefinition.CommonStructs != null)
            {
                foreach (var commonStruct in messageDefinition.CommonStructs)
                {
                    commonStruct.Message = messageDefinition;
                    foreach (var field in commonStruct.Fields)
                    {
                        AddReferenceToField(field);
                    }
                }
            }

            return messageDefinition;

            void AddReferenceToField(Field field, Field? parent = null)
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