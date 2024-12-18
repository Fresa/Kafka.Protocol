using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Logging;

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
            var headerSize = Header.GetSize();
            var messageSize = Message.GetSize();
            await Int32.From(headerSize + messageSize)
                .WriteToAsync(writer, false, cancellationToken)
                .ConfigureAwait(false);
            
            KafkaEventSource.Log.ResponseHeaderWritten(headerSize, Header);
            await Header.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);

            KafkaEventSource.Log.ResponseMessageWritten(messageSize, Message);
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
            var headerSize = header.GetSize();
            KafkaEventSource.Log.ResponseHeaderRead(headerSize, header);

            var message = await Messages
                .CreateResponseMessageFromReaderAsync(
                    requestPayload.Header.RequestApiKey,
                    requestPayload.Header.RequestApiVersion,
                    reader,
                    cancellationToken)
                .ConfigureAwait(false);
            var messageSize = message.GetSize();
            KafkaEventSource.Log.ResponseMessageRead(messageSize, message);

            var actualPayloadSize = headerSize + messageSize;
            if (payloadSize.Value != actualPayloadSize)
            {
                throw new CorruptMessageException($"Expected size {payloadSize} got {actualPayloadSize}");
            }
            
            return new ResponsePayload(header, message);
        }
    }
}