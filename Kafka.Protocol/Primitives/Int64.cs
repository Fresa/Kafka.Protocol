using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct Int64
    {
        public int GetSize(bool _ = false) => 8;

        public ValueTask WriteToAsync(Stream writer, bool _ = false,
            CancellationToken cancellationToken = default) =>
            writer.WriteAsBigEndianAsync(BitConverter.GetBytes(Value),
                cancellationToken);

        public static async ValueTask<Int64> FromReaderAsync(PipeReader reader,
            CancellationToken cancellationToken = default) =>
            BitConverter.ToInt64(
                await reader.ReadAsBigEndianAsync(8, cancellationToken)
                    .ConfigureAwait(false),
                0);
    }
}