using System.IO;
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

        public async Task<byte[]> WriteAsync()
        {
            await using var stream = new MemoryStream();
            await using (var writer = new KafkaWriter(stream))
            {
                Header.WriteTo(writer);
                Message.WriteTo(writer);
            }

            return stream.GetBuffer();
        }

        public static ResponsePayload ReadFrom(RequestPayload requestPayload, byte[] payload)
        {
            var reader = new KafkaReader(payload);
            var header = new ResponseHeader(requestPayload.Header.Version);
            header.ReadFrom(reader);
            var message = Messages.Create(requestPayload.Header.RequestApiKey.Value, requestPayload.Header.Version);
            message.ReadFrom(reader);

            return new ResponsePayload(requestPayload, header, message);
        }
    }
}