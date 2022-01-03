using System;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct NullableArray<T>
    {
        public int GetSize(bool asCompact) =>
            asCompact
                ? Value == null ? 1 : (Value.Length + 1).GetVarIntLength() +
                                      Value.Length
                : 4 + (Value?.Sum(item => item.GetSize(asCompact)) ?? 0);

        public async ValueTask WriteToAsync(Stream writer, bool asCompact,
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

        public static async ValueTask<NullableArray<T>> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            Func<ValueTask<T>> createItem,
            CancellationToken cancellationToken = default)
        {
            var length = asCompact
                ? (int)(await UVarInt
                    .FromReaderAsync(reader, cancellationToken)
                    .ConfigureAwait(false)).Value - 1
                : (int)await Int32.FromReaderAsync(reader, cancellationToken)
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
    }
}