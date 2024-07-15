namespace Kafka.Protocol.SourceGenerator;

internal static class EnumerableExtensions
{
    internal static string AggregateToString<T>(this IEnumerable<T> items,
        Func<T, string> transform) =>
        items.Aggregate(string.Empty, (aggregation, item) =>
            $"""
             {aggregation}
             {transform(item)}
             """);
}