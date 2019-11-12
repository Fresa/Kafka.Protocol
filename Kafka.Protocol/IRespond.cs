namespace Kafka.Protocol
{
    public interface IRespond<out TMessage>
        where TMessage : Message
    {
        TMessage Respond();
    }
}