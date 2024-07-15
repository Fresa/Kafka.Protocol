using System.Text;

namespace Kafka.Protocol.SourceGenerator;

internal static class Constraints
{
    internal static string Generate(IReadOnlyDictionary<string, string> constraints) =>
        constraints.Aggregate(new StringBuilder(),
                (constraintExpression, constraint) =>
                    constraintExpression.AppendLine(
                        $"where {constraint.Key} : {constraint.Value}"))
            .ToString();
}