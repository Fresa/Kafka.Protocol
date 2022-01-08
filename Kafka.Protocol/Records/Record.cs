using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Records
{
    public class Record : ISerialize
    {
        public Int8 Attributes { get; set; } = Int8.Default;
        public VarLong TimestampDelta { get; set; } = VarLong.Default;
        public VarInt OffsetDelta { get; set; } = VarInt.Default;
        public byte[] Key { get; set; } = Array.Empty<byte>();
        public byte[] Value { get; set; } = Array.Empty<byte>();
        public Header[] Headers { get; set; } = Array.Empty<Header>();

        public static async ValueTask<Record> FromReaderAsync(
            PipeReader reader,
            
            CancellationToken cancellationToken = default)
        {
            var record = new Record
            {
                Attributes = await Int8.FromReaderAsync(reader, cancellationToken)
                    .ConfigureAwait(false),
                TimestampDelta = await VarLong.FromReaderAsync(reader, cancellationToken)
                    .ConfigureAwait(false),
                OffsetDelta = await VarInt.FromReaderAsync(reader, cancellationToken)
                    .ConfigureAwait(false),
            };

            var keyLength = await VarInt.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false);
            record.Key = await reader.ReadAsync(keyLength, cancellationToken)
                .ConfigureAwait(false);
            var valueLen = await VarInt.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false);
            record.Value = await reader.ReadAsync(
                    valueLen,
                    cancellationToken)
                .ConfigureAwait(false);
            var headerCount = await VarInt
                .FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false);

            var headers = new List<Header>();
            for (var i = 0; i < headerCount; i++)
            {
                headers.Add(await Header.FromReaderAsync(reader, cancellationToken)
                    .ConfigureAwait(false));
            }
            record.Headers = headers.ToArray();
            return record;
        }
        
        public async ValueTask WriteToAsync(
            Stream writer,
            
            CancellationToken cancellationToken = default)
        {
            await VarInt.From(GetSize()).WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await Attributes.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await TimestampDelta.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await OffsetDelta.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await VarInt.From(Key.Length).WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteAsLittleEndianAsync(Key, cancellationToken)
                .ConfigureAwait(false);
            await VarInt.From(Value.Length).WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteAsLittleEndianAsync(Value, cancellationToken)
                .ConfigureAwait(false);

            await VarInt.From(Headers.Length)
                .WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            foreach (var header in Headers)
            {
                await header.WriteToAsync(writer, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        public int GetSize()
        {
            var size = Attributes.GetSize() +
                   TimestampDelta.GetSize() +
                   OffsetDelta.GetSize() +
                   VarInt.From(Key.Length).GetSize() +
                   Key.Length +
                   VarInt.From(Value.Length).GetSize() +
                   Value.Length +
                   VarInt.From(Headers.Length).GetSize() +
                   Headers.Sum(header => header.GetSize());
            return VarInt.From(size).GetSize() + size;
        }
    }
}