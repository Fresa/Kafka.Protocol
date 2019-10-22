using System;
using System.Linq;

namespace Kafka.Protocol.Generator.Helpers.Extensions
{
    public static class TypeExtensions
    {
        public static string GetPrettyName(this Type type)
        {
            if (type == null)
            {
                return "";
            }
            
            var elementType = type.IsArray ? 
                type.GetElementType() : 
                type;

            var prettyName = elementType?.FullName;
            switch (Type.GetTypeCode(elementType))
            {
                case TypeCode.Boolean:
                    prettyName = "bool";
                    break;
                case TypeCode.Int16:
                    prettyName = "short";
                    break;
                case TypeCode.Int32:
                    prettyName = "int";
                    break;
                case TypeCode.UInt32:
                    prettyName = "uint";
                    break;
                case TypeCode.Int64:
                    prettyName = "long";
                    break;
                case TypeCode.String:
                    prettyName = "string";
                    break;
                case TypeCode.Byte:
                    prettyName = "byte";
                    break;
                case TypeCode.SByte:
                    prettyName = "sbyte";
                    break;
                case TypeCode.Char:
                    prettyName = "char";
                    break;
                case TypeCode.Decimal:
                    prettyName = "decimal";
                    break;
                case TypeCode.Double:
                    prettyName = "double";
                    break;
            }

            prettyName += type.IsArray ? "[]" : "";

            if (type.IsGenericType == false)
            {
                return prettyName;
            }

            if (prettyName.IndexOf('`') > 0)
            {
                prettyName = prettyName.Remove(prettyName.IndexOf('`'));
            }

            var genericArguments = type.GetGenericArguments()
                .Select(GetPrettyName);

            return $"{prettyName}<{string.Join(", ", genericArguments)}>";
        }

        internal static Type ToArrayType(this Type type, bool isArray)
        {
            if (isArray || type.IsArray)
            {
                return type.MakeArrayType();
            }

            return type;
        }
    }
}