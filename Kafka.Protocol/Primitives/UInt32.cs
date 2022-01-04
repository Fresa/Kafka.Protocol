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
        public int GetSize(bool _ = false) => 4;

        public ValueTask WriteToAsync(Stream writer, bool _ = false,
            CancellationToken cancellationToken = default) =>
            writer.WriteAsBigEndianAsync(BitConverter.GetBytes(Value),
                cancellationToken);

        public static async ValueTask<UInt32> FromReaderAsync(
            PipeReader reader,
            bool _ = false,
            CancellationToken cancellationToken = default) =>
            BitConverter.ToUInt32(
                await reader.ReadAsBigEndianAsync(4, cancellationToken)
                    .ConfigureAwait(false),
                0);
    }
}