using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Kafka.Protocol.SourceGenerator;

internal static class IncrementalValuesProviderExtensions
{
    internal static IncrementalValuesProvider<SourceText> ReadTextFromFilesMatching(
        this IncrementalValuesProvider<AdditionalText> additionalTextProvider,
        Regex filePattern) =>
        additionalTextProvider
            .Where(file =>
                filePattern.IsMatch(file.Path))
            .Select(static (text, token) =>
                text.GetText(token))
            .Where(static text => text is not null)
            .Select(static (text, _) => text!);
}