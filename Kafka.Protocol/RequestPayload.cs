using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public sealed class RequestPayload
    {
        public RequestHeader Header { get; }
        public Message Message { get; }

        public RequestPayload(
            RequestHeader header,
            Message message)
        {
            Header = header;
            Message = message;
        }

        internal async ValueTask WriteToAsync(
            IKafkaWriter kafkaWriter,
            CancellationToken cancellationToken = default)
        {
            await Header.WriteToAsync(kafkaWriter, cancellationToken);
            await Message.WriteToAsync(kafkaWriter, cancellationToken);
        }

        public static async ValueTask<RequestPayload> ReadFrom(
            int version,
            IKafkaReader kafkaReader,
            CancellationToken cancellationToken = default)
        {
            await kafkaReader.ReadInt32Async(cancellationToken);
            var header = await RequestHeader.FromReaderAsync(
                version,
                kafkaReader,
                cancellationToken);

            var message = await Messages.CreateMessageFromReaderAsync(
                header.RequestApiKey.Value,
                header.RequestApiVersion.Value,
                kafkaReader,
                cancellationToken);

            return new RequestPayload(header, message);
        }
    }
}