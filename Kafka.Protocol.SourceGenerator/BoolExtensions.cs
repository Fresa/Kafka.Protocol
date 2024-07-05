namespace Kafka.Protocol.SourceGenerator;

internal static class BoolExtensions
{
    internal static string IfTrue(this bool condition, string str) => 
        condition ? str : string.Empty;
    internal static string IfFalse(this bool condition, string str) =>
        condition ? string.Empty : str;

}