namespace Kafka.Protocol.Generator.Definitions
{
    public class ErrorCode
    {
        public string Error { get; internal set; }
        public int Code { get; internal set; }
        public bool Retriable { get; internal set; }
        public string Description { get; internal set; }
    }
}