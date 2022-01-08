using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct Boolean
    {
        public int GetSize() => 1;

        public ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default) =>
            writer.WriteAsLittleEndianAsync(BitConverter.GetBytes(Value), cancellationToken);

        public static async ValueTask<Boolean> FromReaderAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default) =>
            BitConverter.ToBoolean(
                await reader.ReadAsLittleEndianAsync(1, cancellationToken)
                    .ConfigureAwait(false),
                0);
    }
}