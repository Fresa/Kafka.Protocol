using System;
using System.Collections.Generic;
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

        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);

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
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            await Header.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await Message.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
        }
        
        public static async ValueTask<RequestPayload> ReadFromAsync(
            Int16 headerVersion,
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            // Read payload size
            var size = await Int32.FromReaderAsync(reader, false, cancellationToken)
                .ConfigureAwait(false);

            var header = await RequestHeader
                .FromReaderAsync(
                    headerVersion,
                    reader,
                    cancellationToken)
                .ConfigureAwait(false);
            Logger.Debug("Read header {@header}", header);

            var message = await Messages
                .CreateRequestMessageFromReaderAsync(
                    header.RequestApiKey,
                    header.RequestApiVersion,
                    reader,
                    cancellationToken)
                .ConfigureAwait(false);
            Logger.Debug("Read message {messageType} {@message}",
                message.GetType(), message);

            var actualPayloadSize = header.GetSize() + message.GetSize();
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

            if (size.Value > actualPayloadSize)
            {
                throw new CorruptMessageException($"Expected size {size} got {actualPayloadSize}");
            }

            return new RequestPayload(header, message);
        }
    }
}