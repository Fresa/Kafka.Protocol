using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface ISerialize
    {
        void ReadFrom(IKafkaReader reader);
        Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default);
    }
}