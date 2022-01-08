using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct UInt16
    {
        public int GetSize() => 2;

        public ValueTask WriteToAsync(Stream writer,
            
            CancellationToken cancellationToken = default) =>
            writer.WriteAsBigEndianAsync(BitConverter.GetBytes(Value),
                cancellationToken);

        public static async ValueTask<UInt16> FromReaderAsync(
            PipeReader reader,
            
            CancellationToken cancellationToken = default) =>
            BitConverter.ToUInt16(
                await reader.ReadAsBigEndianAsync(2, cancellationToken)
                    .ConfigureAwait(false),
                0);
    }
}