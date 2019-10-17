using System;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tests
{
    internal static class ByteExtensions
    {
        internal static async Task<KafkaReader> ToReaderAsync(this byte[] bytes)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(new ReadOnlyMemory<byte>(bytes));
            return new KafkaReader(pipe.Reader);
        }
    }
}