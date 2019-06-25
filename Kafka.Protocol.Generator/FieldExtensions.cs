using System.Collections.Generic;
using System.Linq;
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

        public static bool IsDictionary(this Field field)
        {
            return field.Fields?.Any(subField => subField.MapKey) ?? false;
        }

        public static bool TryGetMapKeyField(this Field field, out Field mapKeyField)
        {
            mapKeyField = field.Fields?
                .FirstOrDefault(subField => subField.MapKey);

            return mapKeyField != default;
        }

        public static string GetName(this Field field)
        {
            return field.Name + (field.IsArray() ? "Collection" : "");
        }

        public static string GetTypeName(this Field field)
        {
            var name = field.GetTypeNameWithoutArrayCharacters();
            if (field.IsArray() == false)
            {
                return name;
            }

            if (field.TryGetMapKeyField(out var mapKeyField))
            {
                return $"Dictionary<{mapKeyField.GetTypeName()}, {name}>";
            }

            return name + ArrayTypeCharacter;
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