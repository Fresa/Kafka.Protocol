using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public abstract class Message : ISerialize
    {
        public abstract int Version { get; }

        public abstract ValueTask ReadFromAsync(IKafkaReader reader,
            CancellationToken cancellationToken = default);

        public abstract Task WriteToAsync(
            IKafkaWriter writer, 
            CancellationToken cancellationToken = default);
    }
}