using System;
using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.Helpers.Extensions;

namespace Kafka.Protocol.Generator.Helpers.Definitions
{
    public static class PrimitiveTypeExtensions
    {
        public static string GetClassName(this PrimitiveType primitiveType)
        {
            var typeName = primitiveType.Type.ToPascalCase('_');

            return typeName.ToLower() switch
            {
                "varint" => "VarInt",
                "varlong" => "VarLong",
                "uint16" => "UInt16",
                "uint32" => "UInt32",
                "uvarint" => "UVarInt",
                "array" => "Array<T>",
                "nullablearray" => "NullableArray<T>",
                _ => typeName
            };
        }

        public static bool IsNullable(this PrimitiveType primitiveType)
        {
            return primitiveType
                .Type
                .ToUpper()
                .Contains("NULLABLE");
        }

        public static string GetTypeName(this PrimitiveType primitiveType) =>
            primitiveType
                .ResolveType()
                .GetPrettyName() +
            (primitiveType.IsNullable() ? "?" : "");

        private static Type ResolveType(this PrimitiveType primitiveType)
        {
            var typeName = primitiveType
                .GetClassName()
                .Replace("Nullable", "");

            return typeName.ToLower() switch
            {
                "int8" => typeof(sbyte),
                "varint" => typeof(int),
                "varlong" => typeof(long),
                "bytes" => typeof(byte[]),
                "float64" => typeof(double),
                "uuid" => typeof(Guid),
                "uvarint" => typeof(uint),
                "array<t>" => typeof(IEnumerable<>).GetGenericArguments()[0].MakeArrayType(),
                _ => typeof(int).Assembly
                         .GetType($"System.{typeName}", false, true) ??
                     throw new InvalidOperationException(
                         $"Could not resolve '{primitiveType.Type}' to a primitive type")
            };
        }

        public static string GetDefaultValue(this PrimitiveType primitiveType)
        {
            var type = primitiveType.ResolveType();

            return type switch
            {
                { IsArray: true } =>
                    $"System.Array.Empty<{primitiveType.GetTypeName().Replace("[]", "")}>()",
                { } t when t == typeof(string) => "string.Empty",
                _ => "default"
            };
        }

        public static bool IsArray(this PrimitiveType primitiveType) => 
            primitiveType.ResolveType().IsArray;

        public static IReadOnlyDictionary<string, string> GetGenericArgumentConstraints(
            this PrimitiveType primitive)
        {
            if (primitive.GetClassName().Replace("Nullable", "").ToUpper() ==
                "ARRAY<T>")
            {
                return new Dictionary<string, string>
                {
                    ["T"] = "ISerialize"
                };
            }

            return new Dictionary<string, string>();
        }
    }
}