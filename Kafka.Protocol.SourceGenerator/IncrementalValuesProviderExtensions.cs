using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Kafka.Protocol.SourceGenerator;

internal static class IncrementalValuesProviderExtensions
{
    internal static IncrementalValuesProvider<(string Path, SourceText Content)> ReadTextFromFilesMatching(
            this IncrementalValuesProvider<AdditionalText>
                additionalTextProvider,
            Regex filePattern) =>
        additionalTextProvider
            .Where(file =>
                filePattern.IsMatch(file.Path))
            .Select(static (text, token) =>
                (text.Path, Content: text.GetText(token)))
            .Where(static text => text.Content is not null)
            .Select(static (text, _) => (text.Path, text.Content!));
}