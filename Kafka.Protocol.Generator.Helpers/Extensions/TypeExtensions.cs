using System;
using System.Linq;

namespace Kafka.Protocol.Generator.Helpers.Extensions
{
    public static class TypeExtensions
    {
        public static string GetPrettyFullName(this Type type)
        {
            if (type == null)
            {
                return "";
            }

            var prettyName = type.FullName;
            if (type.IsGenericType == false)
            {
                return prettyName;
            }

            if (prettyName?.IndexOf('`') > 0)
            {
                prettyName = prettyName.Remove(prettyName.IndexOf('`'));
            }

            var genericArguments = type.GetGenericArguments()
                .Select(GetPrettyFullName);

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