using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct NullableArray<T> : IEnumerable<T>
    {
        internal int GetSize(bool asCompact) =>
            (asCompact
                ? UVarInt.From(Value == null ? 0 : (uint)Value.Length + 1).GetSize(asCompact)
                : 4) +
            (Value?.Sum(item => item.GetSize(asCompact)) ?? 0);

        internal async ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default)
        {
            if (asCompact)
            {
                UVarInt length = Value == null ? 0 : (uint)Value.Length + 1;
                await length.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                Int32 length = Value?.Length ?? -1;
                await length
                    .WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
            }

            if (Value == null)
            {
                return;
            }

            foreach (var item in Value)
            {
                await item.WriteToAsync(writer, asCompact, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        internal static async ValueTask<NullableArray<T>> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            Func<ValueTask<T>> createItem,
            CancellationToken cancellationToken = default)
        {
            var length = asCompact
                ? (int)(await UVarInt
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false)).Value - 1
                : (int)await Int32.FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false);
            
            if (length == -1)
            {
                return default;
            }

            var result = new T[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = await createItem()
                    .ConfigureAwait(false);
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator() =>
            Value?.AsEnumerable()?.GetEnumerator() ??
            Enumerable.Empty<T>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();
    }
}