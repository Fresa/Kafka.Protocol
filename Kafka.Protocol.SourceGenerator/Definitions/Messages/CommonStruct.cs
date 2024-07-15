namespace Kafka.Protocol.SourceGenerator.Definitions.Messages
{
    public class CommonStruct
    {
        public string Name { get; set; } = default!;

        public string Versions { get; set; } = default!;

        public List<Field> Fields { get; set; } = new();
        public Message Message { get; set; } = default!;
    }
}