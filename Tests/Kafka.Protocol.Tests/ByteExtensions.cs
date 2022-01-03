using System;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tests
{
    internal static class ByteExtensions
    {
        internal static async Task<KafkaReader> ToKafkaReaderAsync(this byte[] bytes)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(new ReadOnlyMemory<byte>(bytes))
                .ConfigureAwait(false);
            return new KafkaReader(pipe.Reader);
        }

        internal static async Task<PipeReader> ToReaderAsync(this byte[] bytes)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(new ReadOnlyMemory<byte>(bytes))
                .ConfigureAwait(false);
            return pipe.Reader;
        }
    }
}