using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Log.It;

namespace Kafka.Protocol
{
    public sealed class RequestPayload 
    {
        public RequestHeader Header { get; }
        public Message Message { get; }

        private static readonly ILogger Logger =
            LogFactory.Create<RequestPayload>();

        public RequestPayload(
            RequestHeader header,
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
            
            Logger.Debug("Writing message {messageType} ({size} bytes) {@message}", 
                Message.GetType().Name, messageSize, Message);
            await Message.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
        }

        public static async ValueTask<RequestPayload> ReadFromAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            // Read payload size
            var size = await Int32.FromReaderAsync(reader, false, cancellationToken)
                .ConfigureAwait(false);

            var header = await RequestHeader
                .FromReaderAsync(
                    reader,
                    cancellationToken)
                .ConfigureAwait(false);
            var headerSize = header.GetSize();
            Logger.Debug("Read header ({size} bytes) {@header}", headerSize, header);

            var message = await Messages
                .CreateRequestMessageFromReaderAsync(
                    header.RequestApiKey,
                    header.RequestApiVersion,
                    reader,
                    cancellationToken)
                .ConfigureAwait(false);
            var messageSize = message.GetSize();
            Logger.Debug("Read message {messageType} ({size} bytes) {@message}",
                message.GetType().Name, messageSize, message);

            var actualPayloadSize = headerSize + messageSize;
            // todo: Why is Confluent.Kafka client sending 4 extra bytes containing zeros in the ApiVersionsRequest?
            if (actualPayloadSize < size.Value)
            {
                var unreadLength = size.Value - actualPayloadSize;
                var unreadBytes = await reader.ReadAsLittleEndianAsync(unreadLength, cancellationToken)
                    .ConfigureAwait(false);
                Logger.Warning("Detected {length} unknown bytes {unknownBytes}, ignoring",
                    unreadLength,
                    string.Join(" ", unreadBytes.Take(1000)) + (unreadBytes.Length > 1000 ? " ..." : ""));
            }
            
            return new RequestPayload(header, message);
        }
    }
}