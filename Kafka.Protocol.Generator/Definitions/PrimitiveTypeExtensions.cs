using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.Definitions
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

        public static string GetTypeName(this PrimitiveType primitiveType)
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
                        .ToArrayType(isArray)
                        .GetPrettyFullName();
                case "varint":
                    return Type<int>()
                        .ToArrayType(isArray)
                        .GetPrettyFullName();
                case "varlong":
                    return Type<long>()
                        .ToArrayType(isArray)
                        .GetPrettyFullName();
                case "nullablestring":
                    return Type<string>()
                        .ToArrayType(isArray)
                        .GetPrettyFullName();
                case "nullablebytes":
                    return Type<byte[]>()
                        .GetPrettyFullName();
                case "bytes":
                    return Type<byte[]>()
                        .GetPrettyFullName();
            }

            var resolvedType = typeof(int)
                .Assembly
                .GetType(
                    $"System.{typeName}",
                    false,
                    true);

            if (resolvedType != null)
            {
                return resolvedType
                    .ToArrayType(isArray)
                    .GetPrettyFullName();
            }

            return typeName + (isArray ? "[]" : "");
        }

        private static System.Type Type<T>()
        {
            return typeof(T);
        }
    }
}