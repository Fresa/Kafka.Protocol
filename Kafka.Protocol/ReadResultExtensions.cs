using System.IO.Pipelines;

namespace Kafka.Protocol
{
    internal static class ReadResultExtensions
    {
        internal static bool HasMoreData(
            this ReadResult readResult)
            => readResult.IsCanceled == false &&
               readResult.IsCompleted == false;
    }
}