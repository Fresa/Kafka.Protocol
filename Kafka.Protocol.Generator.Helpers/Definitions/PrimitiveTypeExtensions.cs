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
                case "varint":
                    typeName = "VarInt";
                    break;
                case "varlong":
                    typeName = "VarLong";
                    break;
                case "uint16":
                    typeName = "UInt16";
                    break;
                case "uint32":
                    typeName = "UInt32";
                    break;
                case "uvarint":
                    typeName = "UVarInt";
                    break;
            }

            return typeName + (isArray ? "[]" : "");
        }

        public static string GetTypeName(this PrimitiveType primitiveType) =>
            primitiveType
                .ResolveType()
                .GetPrettyName();

        private static Type ResolveType(this PrimitiveType primitiveType)
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
                case "bytes":
                    return Type<byte[]>();
                case "float64":
                    return Type<double>()
                        .ToArrayType(isArray);
                case "uuid":
                    return Type<Guid>()
                        .ToArrayType(isArray);
                case "uvarint":
                    return Type<uint>()
                        .ToArrayType(isArray);
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
                return $"Array.Empty<{type.GetPrettyName().Replace("[]", "")}>()";
            }

            switch (type)
            {
                case Type t when t == typeof(string):
                    return "string.Empty";
                default:
                    return "default";
            }
        }

        public static bool IsArray(this PrimitiveType primitiveType) => 
            primitiveType.ResolveType().IsArray;

        private static Type Type<T>()
        {
            return typeof(T);
        }
    }
}