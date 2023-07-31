using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    /// <summary>
    /// Represents a nullable struct
    /// https://cwiki.apache.org/confluence/display/KAFKA/KIP-893%3A+The+Kafka+protocol+should+support+nullable+structs
    /// </summary>
    /// <typeparam name="T">A struct</typeparam>
    public readonly struct Nullable<T> : ISerialize
        where T : ISerialize
    {
        /// <summary>
        /// Create a nullable struct
        /// </summary>
        /// <param name="value">A struct</param>
        public Nullable([AllowNull] T value)
        {
            Value = value;
        }

        /// <summary>
        /// A struct or null
        /// </summary>
        [AllowNull]
        public T Value { get; }

        ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken) =>
            WriteToAsync(writer, asCompact, cancellationToken);

        internal async ValueTask WriteToAsync(Stream writer, bool asCompact,
            CancellationToken cancellationToken)
        {
            await GetNullIndicator(asCompact)
                .WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);

            if (Value == null)
                return;
            await Value.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
        }

        internal static async ValueTask<Nullable<T>> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            Func<ValueTask<T>> createItem,
            CancellationToken cancellationToken = default)
        {
            var isNull = asCompact
                ? (await VarInt
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false)) == 0
                : (await Int8
                    .FromReaderAsync(reader, asCompact, cancellationToken)
                    .ConfigureAwait(false)) == -1;
            if (isNull)
                return new Nullable<T>();

            var value = await createItem().ConfigureAwait(false);
            return new Nullable<T>(value);
        }

        int ISerialize.GetSize(bool asCompact) =>
            GetSize(asCompact);
        internal int GetSize(bool asCompact) =>
            GetNullIndicator(asCompact).GetSize(asCompact) +
            Value?.GetSize(asCompact) ?? 0;

        private ISerialize GetNullIndicator(bool asCompact) =>
            asCompact
                ? (ISerialize)VarInt.From(Value == null ? 0 : 1)
                : Int8.From(Value == null ? (sbyte)-1 : (sbyte)1);

        [return: MaybeNull]
        public static implicit operator T(Nullable<T> value) => value.Value;

        public static implicit operator Nullable<T>([AllowNull] T value) => new Nullable<T>(value);
    }
}