using System;
using System.Collections.Generic;
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
                { } name when name.Contains("array") => $"{typeName}<T>",
                { } name when name.Contains("map") => $"{typeName}<TKey, TValue>",
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

        public static bool IsCompact(this PrimitiveType primitiveType)
        {
            return primitiveType
                .Type
                .ToUpper()
                .Contains("COMPACT");
        }

        public static string GetTypeName(this PrimitiveType primitiveType) =>
            primitiveType
                .ResolveType()
                .GetPrettyName() +
            (primitiveType.IsNullable() ? "?" : "");

        private static Type ResolveType(this PrimitiveType primitiveType)
        {
            var typeName = primitiveType
                .GetClassName();

            return typeName.ToLower() switch
            {
                "int8" => typeof(sbyte),
                "varint" => typeof(int),
                "varlong" => typeof(long),
                "float64" => typeof(double),
                "uuid" => typeof(Guid),
                "uvarint" => typeof(uint),
                { } name when name.Contains("bytes") => typeof(byte[]),
                { } name when name.Contains("string") => typeof(string),
                { } name when name.Contains("array") => typeof(IEnumerable<>).GetGenericArguments()[0].MakeArrayType(),
                { } name when name.Contains("map") => typeof(Dictionary<,>),
                _ => typeof(int).Assembly
                         .GetType($"System.{typeName}", false, true) ??
                     throw new InvalidOperationException(
                         $"Could not resolve '{primitiveType.Type}/{typeName}' to a primitive type")
            };
        }

        public static string GetDefaultValue(this PrimitiveType primitiveType)
        {
            var type = primitiveType.ResolveType();
            
            return type switch
            {
                { } when primitiveType.IsNullable() => "default",
                { } t when t == typeof(Dictionary<,>) => "new Dictionary<TKey, TValue>()",
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
            var typeName = primitive.GetClassName();
            return typeName.ToUpper() switch
            {
                { } name when name.Contains("ARRAY") => new
                    Dictionary<string, string>
                    {
                        ["T"] = "ISerialize"
                    },
                { } name when name.Contains("MAP") => new
                    Dictionary<string, string>
                    {
                        ["TKey"] = "ISerialize",
                        ["TValue"] = "ISerialize"
                    },
                _ => new Dictionary<string, string>()
            };
        }
    }
}