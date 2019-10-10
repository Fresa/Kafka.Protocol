namespace Kafka.Protocol.Generator.Helpers
{
    internal class Buffer<T> : IBuffer<T>
    {
        internal Buffer(T[] items)
        {
            Items = items;
        }

        public T Current =>
            Items[Position];

        public bool MoveToNext()
        {
            Position++;
            return Position < Items.Length;
        }

        public bool MoveToPrevious()
        {
            Position--;
            return Position >= 0;
        }

        public T[] Items { get; }

        public int Position { get; private set; } = -1;
    }
}