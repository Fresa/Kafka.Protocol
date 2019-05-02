namespace Kafka.Protocol
{
    public interface ISerialize
    {
        void ReadFrom(IKafkaReader reader);
        void WriteTo(IKafkaWriter writer);
    }
}