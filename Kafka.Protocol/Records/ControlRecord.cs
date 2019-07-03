namespace Kafka.Protocol.Records
{
    public class ControlRecord : ISerialize
    {
        public Int16 Version { get; set; } = Int16.Default;
        public Int16 Type { get; set; } = Int16.Default;
        
        public void ReadFrom(IKafkaReader reader)
        {
            Version = Int16.From(reader.ReadInt16());
            Type = Int16.From(reader.ReadInt16());
        }

        public void WriteTo(IKafkaWriter writer)
        {
            writer.WriteInt16(Version.Value);
            writer.WriteInt16(Type.Value);
        }
    }
}