namespace Kafka.Protocol
{
    public abstract class Message : ISerialize
    {
        public abstract int Version { get; }

        public abstract void ReadFrom(IKafkaReader reader);
        public abstract void WriteTo(IKafkaWriter writer);
    }
}