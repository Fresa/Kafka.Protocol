namespace Kafka.Protocol
{
    internal interface IRange<in T>
    {
        bool InRange(T value);
    }
}