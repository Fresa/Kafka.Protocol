using System;
using System.Collections.Generic;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator
{
    public class ProtocolPrimitiveTypeConverter
    {
        public Type Convert(string type)
        {
            type = type.ToPascalCase('_');

            switch (type.ToLower())
            {
                case "int8":
                    return Type<sbyte>();
                case "varint":
                    return Type<int>();
                case "varlong":
                    return Type<long>();
                case "nullablestring":
                    return Type<string>();
                case "nullablebytes":
                    return Type<byte[]>();
                case "bytes":
                    return Type<byte[]>();
                case "records":
                    return Type<byte[]>();
            }

            var resolvedType = typeof(int)
                .Assembly
                .GetType(
                    $"System.{type}",
                    false,
                    true);

            if (resolvedType != null)
            {
                return resolvedType;
            }

            throw new NotSupportedException($"Unknown type '{type}'.");
        }

        private static Type Type<T>()
        {
            return typeof(T);
        }
    }
}