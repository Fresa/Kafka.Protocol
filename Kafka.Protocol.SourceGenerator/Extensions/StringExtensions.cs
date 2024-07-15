namespace Kafka.Protocol.SourceGenerator.Extensions
{
    internal static class StringExtensions
    {
        public static string ToPascalCase(this string str, char delimiter)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            var sections = str
                .ToLower()
                .Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries)
                .Select(section => section.First().ToString().ToUpper() + string.Join(string.Empty, section.Skip(1)));

            return string.Concat(sections);
        }

        public static string FirstCharacterToUpperCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return str.First().ToString().ToUpper() + string.Join(string.Empty, str.Skip(1));
        }

        public static string FirstCharacterToLowerCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return str.First().ToString().ToLower() + string.Join(string.Empty, str.Skip(1));
        }
    }
}