using Kafka.Protocol.Generator.Definitions.Messages;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator
{
    public static class FieldExtensions
    {
        private const string ArrayTypeCharacter = "[]";

        public static bool IsArray(this Field field)
        {
            return field.Type.StartsWith(ArrayTypeCharacter);
        }

        public static string GetName(this Field field)
        {
            return field.Name + (field.IsArray() ? "Collection" : "");
        }

        public static string GetTypeName(this Field field)
        {
            return field.GetTypeNameWithoutArrayCharacters() +
                   (field.IsArray() ? ArrayTypeCharacter : "");
        }

        public static string GetTypeNameWithoutArrayCharacters(this Field field)
        {
            var typeName = field.Type;
            if (field.IsArray())
            {
                typeName = typeName.TrimStart(ArrayTypeCharacter.ToCharArray());
            }

            switch (typeName.ToLower())
            {
                case "bool":
                    typeName = "Boolean";
                    break;
            }

            return typeName.FirstCharacterToUpperCase();
        }
    }
}