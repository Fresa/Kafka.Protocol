using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tags
{
    public class TagSection : ISerialize
    {
        public TaggedField[] TaggedFields { get; set; } =
            Array.Empty<TaggedField>();

        public async ValueTask WriteToAsync(IKafkaWriter writer,
            CancellationToken cancellationToken = default)
        {
            await writer.WriteUVarIntAsync((uint)TaggedFields.Length,
                    cancellationToken)
                .ConfigureAwait(false);

            foreach (var taggedField in TaggedFields.OrderBy(field => field.Tag))
            {
                await taggedField.WriteToAsync(writer, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        public int GetSize(IKafkaWriter writer) =>
            writer.SizeOfUVarInt((uint)TaggedFields.Length) +
            TaggedFields.Sum(field => field.GetSize(writer));
        
        public static async Task<IAsyncEnumerable<TaggedField>> FromReaderAsync(
            IKafkaReader reader,
            CancellationToken cancellationToken = default)
        {
            var length = await reader.ReadVarIntAsync(cancellationToken)
                .ConfigureAwait(false);

            return new TaggedFieldAsyncEnumerable(new TaggedFieldAsyncEnumerator(reader, length,
                cancellationToken));
        }

        private class TaggedFieldAsyncEnumerable : IAsyncEnumerable<TaggedField>
        {
            private readonly IAsyncEnumerator<TaggedField> _enumerator;

            public TaggedFieldAsyncEnumerable(IAsyncEnumerator<TaggedField> enumerator)
            {
                _enumerator = enumerator;
            }
            public IAsyncEnumerator<TaggedField> GetAsyncEnumerator(
                CancellationToken cancellationToken = default)
            {
                return _enumerator;
            }
        }

        private class TaggedFieldAsyncEnumerator : IAsyncEnumerator<TaggedField>
        {
            private readonly IKafkaReader _reader;
            private int _length;
            private readonly CancellationToken _cancellation;

            public TaggedFieldAsyncEnumerator(IKafkaReader reader, VarInt length, CancellationToken cancellation)
            {
                _reader = reader;
                _length = length;
                _cancellation = cancellation;
            }

            public ValueTask DisposeAsync()
            {
                return default;
            }

            public async ValueTask<bool> MoveNextAsync()
            {
                if (_length == 0)
                {
                    return false;
                }

                Current = await TaggedField
                    .FromReaderAsync(_reader, _cancellation)
                    .ConfigureAwait(false);

                _length--;
                return true;
            }

            public TaggedField Current { get; private set; } = default!;
        }
    }
}