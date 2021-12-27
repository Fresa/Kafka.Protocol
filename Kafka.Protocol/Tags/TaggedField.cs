using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tags
{
    public class TaggedField : ISerialize
    {
        public UVarInt Tag { get; set; } = UVarInt.Default;
        public UVarInt Length { get; set; } = UVarInt.Default;
        public ISerialize Field { get; set; } = default!;

        public async ValueTask WriteToAsync(IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteUVarIntAsync(Tag, cancellationToken)
                .ConfigureAwait(false);
            await writer.WriteUVarIntAsync((uint)Field.GetSize(writer), cancellationToken)
                .ConfigureAwait(false);

            await Field.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
        }

        public int GetSize(IKafkaWriter writer)
        {
            var fieldSize = Field.GetSize(writer);
            return writer.SizeOfUVarInt(Tag) +
                   writer.SizeOfUVarInt((uint)fieldSize) +
                   fieldSize;
        }

        public static async ValueTask<TaggedField> FromReaderAsync(
            IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            var tag = await reader.ReadUVarIntAsync(cancellationToken)
                .ConfigureAwait(false);
            var length = await reader.ReadUVarIntAsync(cancellationToken)
                .ConfigureAwait(false);

            return new TaggedField
            {
                Tag = tag,
                Length = length
            };
        }
    }
}