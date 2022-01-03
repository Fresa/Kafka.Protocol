using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface ISerialize
    {
        ValueTask WriteToAsync(Stream writer, 
            bool asCompact = false,
            CancellationToken cancellationToken = default);

        int GetSize(bool asCompact = false);
    }
}