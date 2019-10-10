namespace Kafka.Protocol.Generator.Helpers
{
    internal interface IBuffer<out T>
    {
        T Current { get; }
        T[] Items { get; }
        int Position { get; }
        bool MoveToNext();
        bool MoveToPrevious();
    }
}