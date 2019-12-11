using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public sealed class ResponsePayload : IPayload
    {
        public RequestPayload RequestPayload { get; }
        public ResponseHeader Header { get; }
        public Message Message { get; }

        public ResponsePayload(
            RequestPayload requestPayload, 
            ResponseHeader header, 
            Message message)
        {
            RequestPayload = requestPayload;
            Header = header;
            Message = message;
        }

        public async ValueTask WriteToAsync(
            IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await Header.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await Message.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
        }

        public static async ValueTask<ResponsePayload> ReadFromAsync(
            RequestPayload requestPayload, 
            IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            var header = await ResponseHeader.FromReaderAsync(
                requestPayload.Header.Version,
                reader,
                cancellationToken)
                .ConfigureAwait(false);

            var message = await Messages.CreateMessageFromReaderAsync(
                requestPayload.Header.RequestApiKey, 
                requestPayload.Header.Version,
                reader,
                cancellationToken)
                .ConfigureAwait(false);

            return new ResponsePayload(requestPayload, header, message);
        }
    }

    public interface IPayload : ISerialize { }
}