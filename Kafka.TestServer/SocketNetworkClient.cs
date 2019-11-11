using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.TestServer
{
    internal sealed class SocketNetworkClient : INetworkClient
    {
        private readonly Socket _socket;

        public SocketNetworkClient(Socket socket)
        {
            _socket = socket;
        }

        public async ValueTask DisposeAsync()
        {
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
            _socket.Dispose();
            await new ValueTask();
        }

        public async ValueTask<int> SendAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
        {
            return await _socket.SendAsync(buffer, SocketFlags.None, cancellationToken);
        }

        public async ValueTask<int> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        {
            return await _socket.ReceiveAsync(buffer, SocketFlags.None, cancellationToken);
        }
    }
}