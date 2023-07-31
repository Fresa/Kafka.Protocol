using System;
using System.Collections.Generic;
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

        private static string[]? _primitiveTypeNames;

        public static void SetPrimitiveTypeNames(string[] typeNames)
        {
            //if (_primitiveTypeNames != null)
            //    throw new InvalidOperationException(
            //        "Primitive type names have already been set");

            _primitiveTypeNames = typeNames;
        }

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
            var type = field.GetNonNullableFullTypeName();
            if (!field.IsNullable()) 
                return type;
            return field.Fields != null && !field.IsArray()
                ? $"Nullable<{type}>"
                : $"Nullable{type}";
        }

        private static string GetNonNullableFullTypeName(this Field field)
        {
            var name = field.GetFullTypeNameWithoutArrayCharacters();

            if (field.TryGetMapKeyField(out var mapKeyField))
            {
                return $"Map<{mapKeyField.GetTypeName()}, {name}>";
            }

            return field.IsArray() ? $"Array<{name}>" : name;
        }

        public static string GetNullableFullTypeName(this Field field) =>
            field.GetNonNullableFullTypeName() + (field.IsNullable() ? "?" : "");

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
                    typeName = "RecordBatch";
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

        public static IEnumerable<Field> GetTaggedFields(this Field field) =>
            field.Fields?
                .Where(childField => childField.Tag.HasValue)
                .OrderBy(childField => childField.Tag) ??
            Enumerable.Empty<Field>();

        public static bool IsPrimitiveType(this Field field)
        {
            if (_primitiveTypeNames == null)
                throw new InvalidOperationException(
                    $"Primitive types have not been defined via {nameof(SetPrimitiveTypeNames)}");
            
            var typeName = field.GetFullTypeNameWithoutArrayCharacters();
            return _primitiveTypeNames
                .Any(primitiveTypeName =>
                    typeName == primitiveTypeName);
        }

        public static string GetDefaultValue(this Field field)
        {
            if (field.IsNullable() && field.Fields != null)
                return $"new {field.GetFullTypeName()}()";
            if (field.Default != null)
                return $"new {field.GetFullTypeName()}({(field.Default == string.Empty ? "string.Empty" : field.Default)})";
            if (field.IsDictionary() || field.IsPrimitiveType())
                return $"{field.GetFullTypeName()}.Default";
            if (field.IsArray())
                return $"Array.Empty<{field.GetFullTypeNameWithoutArrayCharacters()}>";
            
            return "default!";
        }
    }
}