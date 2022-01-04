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
    public sealed class RequestPayload : ISerialize
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

        public int GetSize(bool asCompact) =>
            Header.GetSize(asCompact) +
            Message.GetSize(asCompact);
        
        public static async ValueTask<RequestPayload> ReadFromAsync(
            Int16 headerVersion,
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            // Read payload size
            var size = Int32.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false);

            var report = reader.EnsureExpectedSize(size);
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

            // todo: Why is Confluent.Kafka client sending 4 extra bytes containing zeros in the ApiVersionsRequest?
            if (report.BytesRead < size.Value)
            {
                var bytesUnRead = "";
                var unreadLength = size.Value - report.BytesRead;
                for (var i = 0; i < unreadLength; i++)
                {
                    bytesUnRead +=
                        (byte)(await reader.ReadInt8Async(
                            cancellationToken)).Value + " ";
                }
                Logger.Warning("Detected {length} unknown bytes {unknownBytes}, ignoring",
                    unreadLength,
                    bytesUnRead.Trim());
            }

            report.Dispose();
            return new RequestPayload(header, message);
        }
    }
}