using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public sealed class ResponsePayload : ISerialize
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
            Stream writer,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            await Header.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await Message.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
        }

        public int GetSize(bool asCompact) =>
            Header.GetSize() +
            Message.GetSize();

        public static async ValueTask<ResponsePayload> ReadFromAsync(
            RequestPayload requestPayload,
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            var payloadSize = await Int32.FromReaderAsync(reader, false, cancellationToken)
                .ConfigureAwait(false);

            var header = await ResponseHeader.FromReaderAsync(
                    requestPayload.Header.Version,
                    reader,
                    cancellationToken)
                .ConfigureAwait(false);

            var message = await Messages
                .CreateResponseMessageFromReaderAsync(
                    requestPayload.Header.RequestApiKey,
                    requestPayload.Header.RequestApiVersion,
                    reader,
                    cancellationToken)
                .ConfigureAwait(false);
            
            var actualPayloadSize = header.GetSize() + message.GetSize();
            if (payloadSize.Value != actualPayloadSize)
            {
                throw new CorruptMessageException($"Expected size {payloadSize} got {actualPayloadSize}");
            }

            return new ResponsePayload(requestPayload, header, message);
        }
    }
}