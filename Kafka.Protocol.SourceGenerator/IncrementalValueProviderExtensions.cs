using System.Collections.Immutable;
using Kafka.Protocol.Generator.Helpers.Definitions.Messages;
using Microsoft.CodeAnalysis;

namespace Kafka.Protocol.SourceGenerator;

internal static class IncrementalValueProviderExtensions
{
    internal static IncrementalValueProvider<ImmutableArray<Message>> ThrowIfEmpty(
        this IncrementalValueProvider<ImmutableArray<Message>> messageValuesProvider,
        string exceptionMessage)
    {
        return messageValuesProvider.Select((array, _) =>
        {
            if (array.IsEmpty)
            {
                throw new InvalidOperationException(exceptionMessage);
            }
            return array;
        });
    }
}