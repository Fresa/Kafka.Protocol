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
            await Tag.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);

            UVarInt size = (uint) Field.GetSize();
            await size.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
            
            await Field.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
        }

        public int GetSize()
        {
            var fieldSize = Field.GetSize();
            return Tag.GetSize() +
                   UVarInt.From((uint)fieldSize).GetSize() +
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