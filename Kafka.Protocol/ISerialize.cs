using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface ISerialize
    {
        ValueTask ReadFromAsync(IKafkaReader reader, 
            CancellationToken cancellationToken = default);

        Task WriteToAsync(IKafkaWriter writer, 
            CancellationToken cancellationToken = default);
    }
}