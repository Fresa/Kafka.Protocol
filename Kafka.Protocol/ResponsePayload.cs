using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public sealed class ResponsePayload
    {
        public RequestPayload RequestPayload { get; }
        public ResponseHeader Header { get; }
        public Message Message { get; }

        private ResponsePayload(RequestPayload requestPayload, ResponseHeader header, Message message)
        {
            RequestPayload = requestPayload;
            Header = header;
            Message = message;
        }

        public async Task WriteToAsync(
            IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await Header.WriteToAsync(writer, cancellationToken);
            await Message.WriteToAsync(writer, cancellationToken);
        }

        public static async ValueTask<ResponsePayload> ReadFromAsync(
            RequestPayload requestPayload, 
            IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            var header = new ResponseHeader(requestPayload.Header.Version);
            await header.ReadFromAsync(reader, cancellationToken);
            var message = Messages.Create(requestPayload.Header.RequestApiKey.Value, requestPayload.Header.Version);
            await message.ReadFromAsync(reader, cancellationToken);

            return new ResponsePayload(requestPayload, header, message);
        }
    }
}