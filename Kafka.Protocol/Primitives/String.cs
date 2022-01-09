using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct String
    {
        internal int GetSize(bool asCompact) =>
            NullableString.From(Value).GetSize(asCompact);

        internal ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken = default) =>
            NullableString.From(Value)
                .WriteToAsync(writer, asCompact, cancellationToken);

        internal static async ValueTask<String> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default) =>
            (await NullableString.FromReaderAsync(reader, asCompact, cancellationToken)
                .ConfigureAwait(false)).Value ??
            $"The string cannot be null. Consider changing to {nameof(NullableString)}";

        public static implicit operator NullableString(String value) => value.Value;
    }
}