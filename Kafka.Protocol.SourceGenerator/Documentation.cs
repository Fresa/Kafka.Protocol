using System.Text;

namespace Kafka.Protocol.SourceGenerator;

internal static class Documentation
{
    internal static string Generate(params string[] comments)
    {
        if (comments.Length == 0)
        {
            return string.Empty;
        }

        var documentation = comments.Aggregate(new StringBuilder(), (aggregatedDocumentation, doc) =>
        {
            if (string.IsNullOrEmpty(doc))
            {
                return aggregatedDocumentation;
            }

            foreach (var line in doc.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries))
            {
                aggregatedDocumentation.AppendLine($"/// <para>{doc}</para>");
            }

            return aggregatedDocumentation;
        }).ToString();
        
        return string.IsNullOrEmpty(documentation)
            ? string.Empty
            : $"""
               /// <summary>
               {documentation.Trim()}
               /// </summary>
               """;
    }
}