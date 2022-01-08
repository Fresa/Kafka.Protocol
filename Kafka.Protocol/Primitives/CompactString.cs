using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct CompactString
    {
        public int GetSize() =>
            CompactNullableString.From(Value).GetSize();

        public ValueTask WriteToAsync(Stream writer,
            CancellationToken cancellationToken = default) =>
            CompactNullableString.From(Value)
                .WriteToAsync(writer, cancellationToken);

        public static async ValueTask<String> FromReaderAsync(
            PipeReader reader,

            CancellationToken cancellationToken = default) =>
            (await CompactNullableString.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false)).Value ??
            $"The string cannot be null. Consider changing to {nameof(CompactNullableString)}";

        public static implicit operator CompactString(String value) => value.Value;
    }
}