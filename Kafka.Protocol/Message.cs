using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public abstract class Message
    {
        public abstract Int16 Version { get; }

        public abstract ValueTask WriteToAsync(
            Stream writer,
            CancellationToken cancellationToken = default);

        public abstract int GetSize();
    }
}