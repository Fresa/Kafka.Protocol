using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tags
{
    public class TaggedField
    {
        public UVarInt Tag { get; set; } = UVarInt.Default;
        public UVarInt Length { get; set; } = UVarInt.Default;
        public ISerialize Field { get; set; } = default!;

        public async ValueTask WriteToAsync(Stream writer, 
            CancellationToken cancellationToken = default)
        {
            await Tag.WriteToAsync(writer, false, cancellationToken)
                .ConfigureAwait(false);

            UVarInt size = (uint) Field.GetSize(false);
            await size.WriteToAsync(writer, false, cancellationToken)
                .ConfigureAwait(false);
            
            await Field.WriteToAsync(writer, false, cancellationToken)
                .ConfigureAwait(false);
        }

        public int GetSize()
        {
            var fieldSize = Field.GetSize(false);
            return Tag.GetSize(false) +
                   UVarInt.From((uint)fieldSize).GetSize(false) +
                   fieldSize;
        }

        public static async ValueTask<TaggedField> FromReaderAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            var tag = await UVarInt.FromReaderAsync(reader, false, cancellationToken)
                .ConfigureAwait(false);
            var length = await UVarInt.FromReaderAsync(reader, false, cancellationToken)
                .ConfigureAwait(false);

            return new TaggedField
            {
                Tag = tag,
                Length = length
            };
        }
    }
}