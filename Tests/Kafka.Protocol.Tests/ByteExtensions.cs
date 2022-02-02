using System;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tests
{
    internal static class ByteExtensions
    {
        internal static async Task<PipeReader> ToReaderAsync(this byte[] bytes, CancellationToken cancellation = default)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(new ReadOnlyMemory<byte>(bytes), cancellation)
                .ConfigureAwait(false);
            return pipe.Reader;
        }
    }
}