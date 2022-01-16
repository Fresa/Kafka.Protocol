using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public sealed class ResponsePayload
    {
        public ResponseHeader Header { get; }
        public Message Message { get; }

        public ResponsePayload(
            ResponseHeader header,
            Message message)
        {
            Header = header;
            Message = message;
        }

        public async ValueTask WriteToAsync(
            Stream writer,
            CancellationToken cancellationToken = default)
        {
            var size = Header.GetSize() +
                       Message.GetSize();
            await Int32.From(size)
                .WriteToAsync(writer, false, cancellationToken)
                .ConfigureAwait(false);
            await Header.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await Message.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
        }

        public static async ValueTask<ResponsePayload> ReadFromAsync(
            RequestPayload requestPayload,
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            var payloadSize = await Int32.FromReaderAsync(reader, false, cancellationToken)
                .ConfigureAwait(false);

            var header = await ResponseHeader.FromReaderAsync(
                    Messages.GetResponseHeaderVersionFor(requestPayload),
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

            return new ResponsePayload(header, message);
        }
    }
}