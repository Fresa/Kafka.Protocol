namespace Kafka.Protocol.SourceGenerator.Extensions
{
    public static class TypeExtensions
    {
        private static readonly Dictionary<Type, string> TypeAliasMapping = new Dictionary<Type, string>
        {
            { typeof(bool), "bool" },
            { typeof(short), "short" },
            { typeof(ushort), "ushort" },
            { typeof(int), "int" },
            { typeof(uint), "uint" },
            { typeof(long), "long" },
            { typeof(string), "string" },
            { typeof(byte), "byte" },
            { typeof(sbyte), "sbyte" },
            { typeof(char), "char" },
            { typeof(decimal), "decimal" },
            { typeof(double), "double" }
        };
        
        public static string GetPrettyName(this Type type)
        {
            if (type == null)
            {
                return "";
            }

            var elementType = type.IsArray ?
                type.GetElementType() :
                type;

            if (elementType == null)
            {
                throw new InvalidOperationException($"{type} is an array but has unknown element type");
            }

            if (TypeAliasMapping.TryGetValue(elementType, out var prettyName) == false)
            {
                prettyName = elementType.Name;
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