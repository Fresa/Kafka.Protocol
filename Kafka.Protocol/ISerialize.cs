using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public interface ISerialize
    {
        internal ValueTask WriteToAsync(Stream writer, 
            bool asCompact,
            CancellationToken cancellationToken = default);

        internal int GetSize(bool asCompact);
    }
}