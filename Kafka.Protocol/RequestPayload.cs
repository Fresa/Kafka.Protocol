using System.IO;
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

        internal async Task<byte[]> WriteToAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = new MemoryStream();
            await using (var writer = new KafkaWriter(stream))
            {
                await Header.WriteToAsync(writer, cancellationToken);
                await Message.WriteToAsync(writer, cancellationToken);
            }

            return stream.GetBuffer();
        }

        public static RequestPayload ReadFrom(int version, byte[] payload)
        {
            var kafkaReader = new KafkaReader(payload);
            var header = new RequestHeader(version);
            header.ReadFrom(kafkaReader);
            var message = Messages.Create(
                header.RequestApiKey.Value,
                header.RequestApiVersion.Value);
            message.ReadFrom(kafkaReader);

            return new RequestPayload(header, message);
        }
    }
}