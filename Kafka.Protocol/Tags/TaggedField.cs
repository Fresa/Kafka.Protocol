using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tags
{
    internal class TaggedField
    {
        public UVarInt Tag { get; set; } = UVarInt.Default;
        public UVarInt Length { get; set; } = UVarInt.Default;
        public ISerialize Field { get; set; } = default!;

        internal async ValueTask WriteToAsync(Stream writer, 
            CancellationToken cancellationToken = default)
        {
            await Tag.WriteToAsync(writer, true, cancellationToken)
                .ConfigureAwait(false);

            UVarInt size = (uint) Field.GetSize(true);
            await size.WriteToAsync(writer, true, cancellationToken)
                .ConfigureAwait(false);
            
            await Field.WriteToAsync(writer, true, cancellationToken)
                .ConfigureAwait(false);
        }

        internal int GetSize()
        {
            var fieldSize = Field.GetSize(true);
            return Tag.GetSize(true) +
                   UVarInt.From((uint)fieldSize).GetSize(true) +
                   fieldSize;
        }

        internal static async ValueTask<TaggedField> FromReaderAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            var tag = await UVarInt.FromReaderAsync(reader, true, cancellationToken)
                .ConfigureAwait(false);
            var length = await UVarInt.FromReaderAsync(reader, true, cancellationToken)
                .ConfigureAwait(false);

            return new TaggedField
            {
                Tag = tag,
                Length = length
            };
        }
    }
}