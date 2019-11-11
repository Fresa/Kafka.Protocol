using System;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.TestServer
{
    internal class DataReceiver
    {
        private readonly INetworkClient _networkClient;
        private const int MinimumBufferSize = 512;

        internal DataReceiver(INetworkClient networkClient)
        {
            _networkClient = networkClient;
        }

        internal async Task ReceiveAsync(PipeWriter writer, CancellationToken cancellationToken)
        {
            try
            {
                FlushResult result;
                do
                {
                    var memory = writer.GetMemory(MinimumBufferSize);
                    var bytesRead = await _networkClient.ReceiveAsync(
                        memory,
                        cancellationToken);

                    if (bytesRead == 0)
                    {
                        return;
                    }

                    Debug.WriteLine($"Wrote {bytesRead} bytes");
                    writer.Advance(bytesRead);

                    result = await writer.FlushAsync(cancellationToken);
                } while (result.IsCanceled == false &&
                         result.IsCompleted == false);
            }
            catch (Exception ex)
            {
                writer.Complete(ex);
                throw;
            }

            writer.Complete();
        }
    }
}