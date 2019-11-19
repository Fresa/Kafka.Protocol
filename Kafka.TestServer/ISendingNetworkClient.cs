using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.TestServer
{
    public interface ISendingNetworkClient : IAsyncDisposable
    {
        ValueTask<int> SendAsync(
            ReadOnlyMemory<byte> buffer,
            CancellationToken cancellationToken = default);
    }
}