using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol;

namespace Kafka.TestServer
{
    internal class RequestReader
    {
        private readonly PipeReader _reader;

        public RequestReader(PipeReader reader)
        {
            _reader = reader;
        }

        internal async Task<RequestPayload> ReadAsync(CancellationToken cancellationToken)
        {
            int? size = null;
            ReadResult result;
            do
            {
                result = await _reader.ReadAsync(cancellationToken);
                if (result.Buffer.Length <= 4)
                {
                    continue;
                }

                var reader = new KafkaReader(result.Buffer.ToArray());
                size = reader.ReadInt32();
                _reader.AdvanceTo(result.Buffer.GetPosition(4));
                break;

            } while (result.IsCanceled == false &&
                     result.IsCompleted == false);

            if (size == null)
            {
                throw new InvalidOperationException("Expected to read a size");
            }

            do
            {
                result = await _reader.ReadAsync(cancellationToken);
            } while (result.Buffer.Length < size &&
                     result.IsCanceled == false &&
                     result.IsCompleted == false);

            if (result.Buffer.Length != size)
            {
                throw new InvalidOperationException($"Expected {size} bytes, got {result.Buffer.Length}");
            }

            return RequestPayload.ReadFrom(
                0, 
                result.Buffer.ToArray());
        }
    }
}