using System;
using System.Linq;

namespace Kafka.Protocol.Generator.Extensions
{
    public static class TypeExtensions
    {
        public static string GetPrettyFullName(this Type type)
        {
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
    }
}