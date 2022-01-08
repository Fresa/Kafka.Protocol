using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol
{
    public partial struct CompactNullableArray<T> : IEnumerable<T>
    {
        public int GetSize() =>
            VarInt.From(Value == null ? 0 : Value.Length + 1).GetSize() +
            (Value?.Sum(item => item.GetSize()) ?? 0);

        public async ValueTask WriteToAsync(Stream writer,
            CancellationToken cancellationToken = default)
        {
            UVarInt length = Value == null ? 0 : (uint)Value.Length + 1;
            await length.WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);

            if (Value == null)
            {
                return;
            }

            foreach (var item in Value)
            {
                await item.WriteToAsync(writer, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        public static async ValueTask<CompactNullableArray<T>> FromReaderAsync(
            PipeReader reader,

            Func<ValueTask<T>> createItem,
            CancellationToken cancellationToken = default)
        {
            var length = (int)(await UVarInt
                .FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false)).Value - 1;

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

        public static implicit operator NullableArray<T>(CompactNullableArray<T> array) =>
            array.Value;
    }
}