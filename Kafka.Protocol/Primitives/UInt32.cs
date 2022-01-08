using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct UInt32
    {
        public int GetSize(bool asCompact) => 4;

        public ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default) =>
            writer.WriteAsBigEndianAsync(BitConverter.GetBytes(Value),
                cancellationToken);

        public static async ValueTask<UInt32> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default) =>
            BitConverter.ToUInt32(
                await reader.ReadAsBigEndianAsync(4, cancellationToken)
                    .ConfigureAwait(false),
                0);
    }
}