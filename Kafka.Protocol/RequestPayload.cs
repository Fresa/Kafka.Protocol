using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public sealed class RequestPayload
    {
        public RequestHeader Header { get; }
        public Message Message { get; }

        private RequestPayload(RequestHeader header, Message message)
        {
            Header = header;
            Message = message;
        }

        internal async Task<byte[]> WriteToAsync(
            CancellationToken cancellationToken = default)
        {
            await using var stream = new MemoryStream();
            await using (var writer = new KafkaWriter(stream))
            {
                await Header.WriteToAsync(writer, cancellationToken);
                await Message.WriteToAsync(writer, cancellationToken);
            }

            return stream.GetBuffer();
        }

        public static async ValueTask<RequestPayload> ReadFrom(
            int version, 
            IKafkaReader kafkaReader,
            CancellationToken cancellationToken = default)
        {
            var header = new RequestHeader(version);
            await header.ReadFromAsync(kafkaReader, cancellationToken);
            var message = Messages.Create(
                header.RequestApiKey.Value,
                header.RequestApiVersion.Value);
            await message.ReadFromAsync(kafkaReader, cancellationToken);

            return new RequestPayload(header, message);
        }
    }
}