using System;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tests
{
    internal class DataReceiver
    {
        private readonly Socket _socket;
        private const int MinimumBufferSize = 512;

        internal DataReceiver(Socket socket)
        {
            _socket = socket;
        }

        internal async Task ReceiveAsync(PipeWriter writer, CancellationToken cancellationToken)
        {
            try
            {
                FlushResult result;
                do
                {
                    var memory = writer.GetMemory(MinimumBufferSize);
                    var bytesRead = await _socket.ReceiveAsync(
                        memory,
                        SocketFlags.None,
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