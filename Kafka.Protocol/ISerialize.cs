using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface ISerialize
    {
        ValueTask WriteToAsync(Stream writer, 
            CancellationToken cancellationToken = default);

        int GetSize();
    }
}