namespace Kafka.Protocol
{
    internal class VersionRange : IRange<int> 
    {
        private readonly int _from;
        private readonly int _to;

        public VersionRange(int from, int to)
        {
            _from = @from;
            _to = to;
        }

        public bool InRange(int version)
        {
            return version >= _from &&
                   version <= _to;
        }
    }
}