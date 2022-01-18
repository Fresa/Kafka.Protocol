using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Log.It;

namespace Kafka.Protocol
{
    public sealed class ResponsePayload
    {
        public ResponseHeader Header { get; }
        public Message Message { get; }

        private static readonly ILogger Logger =
            LogFactory.Create<ResponsePayload>();

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
            
            Logger.Debug("Writing header ({size} bytes) {@header}", headerSize, Header);
            await Header.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);

            Logger.Debug("Writing message ({size} bytes) {@message}", messageSize, Message);
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
            Logger.Debug("Read header ({size} bytes) {@header}", headerSize, header);

            var message = await Messages
                .CreateResponseMessageFromReaderAsync(
                    requestPayload.Header.RequestApiKey,
                    requestPayload.Header.RequestApiVersion,
                    reader,
                    cancellationToken)
                .ConfigureAwait(false);
            var messageSize = message.GetSize();
            Logger.Debug("Read message ({size} bytes) {messageType} {@message}",
                messageSize, message.GetType(), message);

            var actualPayloadSize = headerSize + messageSize;
            if (payloadSize.Value != actualPayloadSize)
            {
                throw new CorruptMessageException($"Expected size {payloadSize} got {actualPayloadSize}");
            }

            if (reader.TryRead(out var a))
            {
                throw new InvalidOperationException();
            }

            return new ResponsePayload(header, message);
        }
    }
}