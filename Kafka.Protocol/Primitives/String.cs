using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct String
    {
        public int GetSize() =>
            NullableString.From(Value).GetSize();

        public ValueTask WriteToAsync(Stream writer,
            CancellationToken cancellationToken = default) =>
            NullableString.From(Value)
                .WriteToAsync(writer, cancellationToken);

        public static async ValueTask<String> FromReaderAsync(
            PipeReader reader,
            
            CancellationToken cancellationToken = default) =>
            (await NullableString.FromReaderAsync(reader, cancellationToken)
                .ConfigureAwait(false)).Value ??
            $"The string cannot be null. Consider changing to {nameof(NullableString)}";

        public static implicit operator NullableString(String value) => value.Value;
    }
}