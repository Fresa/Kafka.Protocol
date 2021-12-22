using System;
using System.Linq;
using Kafka.Protocol.Generator.Helpers.Definitions.Messages;
using Kafka.Protocol.Generator.Helpers.Extensions;

namespace Kafka.Protocol.Generator.Helpers
{
    public static class FieldExtensions
    {
        private const string ArrayTypeCharacter = "[]";

        private static readonly string[] ReservedFieldNames =
        {
            "Version"
        };

        public static bool IsArray(this Field field)
        {
            return field.Type.StartsWith(ArrayTypeCharacter);
        }

        public static bool IsDictionary(this Field field)
        {
            return field.Fields?.Any(subField => subField.MapKey) ?? false;
        }

        public static bool TryGetMapKeyField(
            this Field field,
            out Field mapKeyField)
        {
            mapKeyField = field.Fields?
                .FirstOrDefault(subField => subField.MapKey);

            return mapKeyField != default;
        }

        public static string GetName(this Field field) => 
            field.Name + (field.IsArray() ? "Collection" : "");

        public static string GetFullTypeName(this Field field)
        {
            var name = field.GetFullTypeNameWithoutArrayCharacters();
            if (field.IsArray() == false)
            {
                return name;
            }

            if (field.TryGetMapKeyField(out var mapKeyField))
            {
                return $"Dictionary<{mapKeyField.GetTypeName()}{mapKeyField.GetNullableSign()}, {name}>";
            }

            return name + ArrayTypeCharacter;
        }
        public static string GetTypeName(this Field field)
        {
            return GetFullTypeName(field).Split('.').Last();
        }

        public static string GetNullableSign(this Field field)
        {
            return field.IsNullable() ? "?" : "";
        }

        public static string GetFullTypeNameWithoutArrayCharacters(this Field field)
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
                case "records":
                    typeName = "Records.RecordBatch";
                    break;
                case "uint16":
                    typeName = "UInt16";
                    break;
                case "uint32":
                    typeName = "UInt32";
                    break;
            }

            return typeName.FirstCharacterToUpperCase();
        }

        public static bool IsNullable(this Field field)
        {
            return !string.IsNullOrEmpty(field.NullableVersions);
        }

        public static string GetFieldName(this Field field, string parentFieldTypeName = "")
        {
            var fullTypeName = field.GetFullTypeNameWithoutArrayCharacters();
            var name = field.GetName().FirstCharacterToUpperCase();
            return ReservedFieldNames.Contains(name) || 
                   fullTypeName.Equals(name, StringComparison.CurrentCultureIgnoreCase) ||
                   name.Equals(parentFieldTypeName, StringComparison.CurrentCultureIgnoreCase)
                ? name + "_"
                : name;
        }

        public static string GetPropertyName(this Field field) => 
            $"_{field.GetName().FirstCharacterToLowerCase()}";

        public static bool IsCompactable(this Field field) =>
            field.IsArray() || field.GetTypeName().Equals("string",
                StringComparison.CurrentCultureIgnoreCase);
    }
}