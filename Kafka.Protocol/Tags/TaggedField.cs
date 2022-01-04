using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tags
{
    public class TaggedField : ISerialize
    {
        public UVarInt Tag { get; set; } = UVarInt.Default;
        public UVarInt Length { get; set; } = UVarInt.Default;
        public ISerialize Field { get; set; } = default!;

        public async ValueTask WriteToAsync(Stream writer, bool asCompact = false,
            CancellationToken cancellationToken = default)
        {
            await Tag.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);

            UVarInt size = (uint) Field.GetSize(asCompact);
            await size.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
            
            await Field.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
        }

        public int GetSize(bool asCompact = false)
        {
            var fieldSize = Field.GetSize(asCompact);
            return Tag.GetSize(asCompact) +
                   UVarInt.From((uint)fieldSize).GetSize(asCompact) +
                   fieldSize;
        }

        public static async ValueTask<TaggedField> FromReaderAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            var tag = await UVarInt.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false);
            var length = await UVarInt.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false);

            return new TaggedField
            {
                Tag = tag,
                Length = length
            };
        }
    }
}