using System;
using Kafka.Protocol.Generator.Helpers.Extensions;

namespace Kafka.Protocol.Generator.Helpers.Definitions
{
    public static class PrimitiveTypeExtensions
    {
        public static string GetClassName(this PrimitiveType primitiveType)
        {
            var typeName = primitiveType.Type.ToPascalCase('_');

            var isArray = false;
            if (typeName.StartsWith("[]"))
            {
                isArray = true;
                typeName = typeName.Substring(2);
            }

            switch (typeName.ToLower())
            {
                case "int8":
                    typeName = "Int8";
                    break;
                case "varint":
                    typeName = "VarInt";
                    break;
                case "varlong":
                    typeName = "VarLong";
                    break;
                case "nullablestring":
                    typeName = "NullableString";
                    break;
                case "nullablebytes":
                    typeName = "NullableBytes";
                    break;
                case "bytes":
                    typeName = "Bytes";
                    break;
                case "uint32":
                    typeName = "UInt32";
                    break;
            }

            return typeName + (isArray ? "[]" : "");
        }

        public static bool IsNullable(this PrimitiveType primitiveType)
        {
            return primitiveType
                .Type
                .ToUpper()
                .Contains("NULLABLE");
        }

        public static string GetTypeName(this PrimitiveType primitiveType)
        {
            return primitiveType
                .ResolveType()
                .GetPrettyFullName() + 
                   (primitiveType.IsNullable() ? "?" : "");
        }

        private static System.Type ResolveType(this PrimitiveType primitiveType)
        {
            var typeName = primitiveType.GetClassName();

            var isArray = false;
            if (typeName.StartsWith("[]"))
            {
                isArray = true;
                typeName = typeName.Substring(2);
            }

            switch (typeName.ToLower())
            {
                case "int8":
                    return Type<sbyte>()
                        .ToArrayType(isArray);
                case "varint":
                    return Type<int>()
                        .ToArrayType(isArray);
                case "varlong":
                    return Type<long>()
                        .ToArrayType(isArray);
                case "nullablestring":
                    return Type<string>()
                        .ToArrayType(isArray);
                case "nullablebytes":
                    return Type<byte[]>();
                case "bytes":
                    return Type<byte[]>();
            }

            var resolvedType = typeof(int)
                .Assembly
                .GetType(
                    $"System.{typeName}",
                    false,
                    true);

            if (resolvedType == null)
            {
                throw new InvalidOperationException($"Could not resolve '{primitiveType.Type}' to a primitive type");
            }

            return resolvedType
                .ToArrayType(isArray);
        }

        public static string GetDefaultValue(this PrimitiveType primitiveType)
        {
            var type = primitiveType.ResolveType();
            if (type.IsArray)
            {
                return $"new {type.GetPrettyFullName().Replace("[]", "[0]")}";
            }

            switch (type)
            {
                case System.Type t when t == typeof(string):
                    return "System.String.Empty";
                default:
                    return "default";
            }
        }

        private static System.Type Type<T>()
        {
            return typeof(T);
        }
    }
}