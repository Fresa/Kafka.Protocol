using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol;

namespace Kafka.TestServer
{
    internal class RequestReader
    {
        private readonly KafkaReader2 _reader;

        public RequestReader(PipeReader reader)
        {
            _reader = new KafkaReader2(reader);
        }

        internal async Task<RequestPayload> ReadAsync(CancellationToken cancellationToken)
        {
            var buffer = await _reader.ReadBytesAsync(cancellationToken);

            return RequestPayload.ReadFrom(
                0, 
                buffer);
        }
    }
}