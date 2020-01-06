using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Log.It;

namespace Kafka.Protocol
{
    public sealed class RequestPayload : IPayload
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
            IKafkaWriter kafkaWriter,
            CancellationToken cancellationToken = default)
        {
            await Header.WriteToAsync(kafkaWriter, cancellationToken)
                .ConfigureAwait(false);
            await Message.WriteToAsync(kafkaWriter, cancellationToken)
                .ConfigureAwait(false);
        }

        public static async ValueTask<RequestPayload> ReadFromAsync(
            Int16 headerVersion,
            IKafkaReader kafkaReader,
            CancellationToken cancellationToken = default)
        {
            // Read payload size
            var size = await kafkaReader
                .ReadInt32Async(cancellationToken)
                .ConfigureAwait(false);

            using var report = kafkaReader.EnsureExpectedSize(size);
            var header = await RequestHeader
                .FromReaderAsync(
                    headerVersion,
                    kafkaReader,
                    cancellationToken)
                .ConfigureAwait(false);
            Logger.Debug("Read header {@header}", header);

            var message = await Messages
                .CreateRequestMessageFromReaderAsync(
                    header.RequestApiKey,
                    header.RequestApiVersion,
                    kafkaReader,
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
                        (byte)(await kafkaReader.ReadInt8Async(
                            cancellationToken)).Value + " ";
                }
                Logger.Warning("Detected {length} unknown bytes {unknownBytes}, ignoring",
                    unreadLength,
                    bytesUnRead.Trim());
            }

            return new RequestPayload(header, message);
        }
    }
}