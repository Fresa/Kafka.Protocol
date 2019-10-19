using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface ISerialize
    {
        Task WriteToAsync(IKafkaWriter writer, 
            CancellationToken cancellationToken = default);
    }
}