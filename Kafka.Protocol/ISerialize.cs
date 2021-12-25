using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface ISerialize
    {
        ValueTask WriteToAsync(IKafkaWriter writer, 
            CancellationToken cancellationToken = default);

        int GetSize(IKafkaWriter writer);
    }
}