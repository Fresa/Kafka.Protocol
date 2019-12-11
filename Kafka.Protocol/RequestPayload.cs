using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public sealed class RequestPayload : IPayload
    {
        public RequestHeader Header { get; }
        public Message Message { get; }

        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);

        public RequestPayload(
            RequestHeader header,
            Message message)
        {
            Header = header;
            Message = message;
        }

        public async ValueTask WriteToAsync(
            IKafkaWriter kafkaWriter,
            CancellationToken cancellationToken = default)
        {
            await Header.WriteToAsync(kafkaWriter, cancellationToken)
                .ConfigureAwait(false);
            await Message.WriteToAsync(kafkaWriter, cancellationToken)
                .ConfigureAwait(false);
        }

        public static async ValueTask<RequestPayload> ReadFromAsync(
            Int16 version,
            IKafkaReader kafkaReader,
            CancellationToken cancellationToken = default)
        {
            await kafkaReader.ReadInt32Async(cancellationToken)
                .ConfigureAwait(false);
            var header = await RequestHeader.FromReaderAsync(
                version,
                kafkaReader,
                cancellationToken)
                .ConfigureAwait(false);

            var message = await Messages.CreateMessageFromReaderAsync(
                header.RequestApiKey,
                header.RequestApiVersion,
                kafkaReader,
                cancellationToken)
                .ConfigureAwait(false);

            return new RequestPayload(header, message);
        }
    }
}