namespace Kafka.Protocol.SourceGenerator.Definitions
{
    public class ErrorCode
    {
        public string Error { get; init; } = default!;
        public int Code { get; internal init; }
        public bool Retriable { get; internal init; }
        public string? Description { get; internal init; }
    }
}