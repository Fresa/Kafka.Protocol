using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Tags
{
    internal class TagSection
    {
        private readonly TaggedField[] _taggedFields;

        public TagSection() => 
            _taggedFields = Array.Empty<TaggedField>();

        public TagSection(params TaggedField[] taggedFields) => 
            _taggedFields = taggedFields;

        internal async ValueTask WriteToAsync(Stream writer, 
            CancellationToken cancellationToken = default)
        {
            await ((UVarInt)(uint)_taggedFields.Length)
                .WriteToAsync(writer, true, cancellationToken)
                .ConfigureAwait(false);

            foreach (var taggedField in _taggedFields.OrderBy(field => field.Tag))
            {
                await taggedField
                    .WriteToAsync(writer, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        internal int GetSize() => 
            ((UVarInt) (uint)_taggedFields.Length).GetSize(true) +
            _taggedFields.Sum(field => field.GetSize());
        
        internal static async Task<IAsyncEnumerable<TaggedField>> FromReaderAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            var length = await UVarInt.FromReaderAsync(reader, true, cancellationToken)
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
            private readonly PipeReader _reader;
            private uint _length;
            private readonly CancellationToken _cancellation;

            public TaggedFieldAsyncEnumerator(PipeReader reader, UVarInt length, CancellationToken cancellation)
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