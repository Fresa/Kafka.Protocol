using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.TestServer
{
    internal sealed class InMemoryNetworkClient : INetworkClient
    {
        private readonly Pipe _pipe;

        public InMemoryNetworkClient(Pipe pipe)
        {
            _pipe = pipe;
        }

        public async ValueTask DisposeAsync()
        {
            await new ValueTask();
        }

        public async ValueTask<int> SendAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
        {
            await _pipe.Writer.WriteAsync(buffer, cancellationToken);
            _pipe.Writer.Advance(buffer.Length);
            return buffer.Length;
        }

        public async ValueTask<int> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        {
            var result = await _pipe.Reader.ReadAsync(cancellationToken);
            var length = result.Buffer.Length > buffer.Length ?
                buffer.Length :
                (int)result.Buffer.Length;

            result
                .Buffer
                .Slice(0, length)
                .CopyTo(
                    buffer
                        .Slice(0, length)
                        .Span);

            var position = result.Buffer.GetPosition(length);
            _pipe.Reader.AdvanceTo(position);
            return length;
        }
    }
}