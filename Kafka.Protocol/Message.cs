using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public abstract class Message : ISerialize
    {
        public abstract Int16 Version { get; }

        public abstract ValueTask WriteToAsync(
            IKafkaWriter writer, 
            CancellationToken cancellationToken = default);

        public abstract int GetSize(IKafkaWriter writer);
    }
}