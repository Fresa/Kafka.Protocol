using Kafka.Protocol.Generator.Definitions.Messages;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator
{
    public static class FieldExtensions
    {
        public static bool IsArray(this Field field)
        {
            return field.Type.StartsWith("[]");
        }

        public static string GetName(this Field field)
        {
            return field.Name + (field.IsArray() ? "Collection" : "");
        }

        public static string GetTypeName(this Field field)
        {
            var typeName = field.Type;
            if (field.IsArray())
            {
                typeName = typeName.Substring(2);
            }

            switch (typeName.ToLower())
            {
                case "bool":
                    typeName = "Boolean";
                    break;
            }

            typeName = typeName.FirstCharacterToUpperCase();
            return typeName + (field.IsArray() ? "[]" : "");
        }
    }
}