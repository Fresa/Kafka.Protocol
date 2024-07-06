#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

namespace Kafka.Protocol
{
    public class ListTransactionsResponse : Message
    {
        public ListTransactionsResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ListTransactionsResponse does not support version {version}. Valid versions are: 0-1");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(66);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(1);
        public override Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        // https://github.com/apache/kafka/blob/99b9b3e84f4e98c3f07714e1de6a139a004cbc5b/generator/src/main/java/org/apache/kafka/message/ApiMessageTypeGenerator.java#L324
        public Int16 HeaderVersion
        {
            get
            {
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _throttleTimeMs.GetSize(IsFlexibleVersion) + _errorCode.GetSize(IsFlexibleVersion) + _unknownStateFiltersCollection.GetSize(IsFlexibleVersion) + _transactionStatesCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ListTransactionsResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ListTransactionsResponse(version);
            instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.UnknownStateFiltersCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.TransactionStatesCollection = await Array<TransactionState>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TransactionState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ListTransactionsResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _unknownStateFiltersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _transactionStatesCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int32 ThrottleTimeMs
        {
            get => _throttleTimeMs;
            private set
            {
                _throttleTimeMs = value;
            }
        }

        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListTransactionsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Int16 ErrorCode
        {
            get => _errorCode;
            private set
            {
                _errorCode = value;
            }
        }

        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListTransactionsResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private Array<String> _unknownStateFiltersCollection = Array.Empty<String>();
        /// <summary>
        /// <para>Set of state filters provided in the request which were unknown to the transaction coordinator</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<String> UnknownStateFiltersCollection
        {
            get => _unknownStateFiltersCollection;
            private set
            {
                _unknownStateFiltersCollection = value;
            }
        }

        /// <summary>
        /// <para>Set of state filters provided in the request which were unknown to the transaction coordinator</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListTransactionsResponse WithUnknownStateFiltersCollection(Array<String> unknownStateFiltersCollection)
        {
            UnknownStateFiltersCollection = unknownStateFiltersCollection;
            return this;
        }

        private Array<TransactionState> _transactionStatesCollection = Array.Empty<TransactionState>();
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<TransactionState> TransactionStatesCollection
        {
            get => _transactionStatesCollection;
            private set
            {
                _transactionStatesCollection = value;
            }
        }

        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListTransactionsResponse WithTransactionStatesCollection(params Func<TransactionState, TransactionState>[] createFields)
        {
            TransactionStatesCollection = createFields.Select(createField => createField(new TransactionState(Version))).ToArray();
            return this;
        }

        public delegate TransactionState CreateTransactionState(TransactionState field);
        /// <summary>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListTransactionsResponse WithTransactionStatesCollection(IEnumerable<CreateTransactionState> createFields)
        {
            TransactionStatesCollection = createFields.Select(createField => createField(new TransactionState(Version))).ToArray();
            return this;
        }

        public class TransactionState : ISerialize
        {
            internal TransactionState(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = true;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => _transactionalId.GetSize(IsFlexibleVersion) + _producerId.GetSize(IsFlexibleVersion) + _transactionState.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<TransactionState> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new TransactionState(version);
                instance.TransactionalId = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.ProducerId = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.TransactionState_ = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for TransactionState is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _transactionalId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _producerId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _transactionState.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _transactionalId = String.Default;
            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String TransactionalId
            {
                get => _transactionalId;
                private set
                {
                    _transactionalId = value;
                }
            }

            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TransactionState WithTransactionalId(String transactionalId)
            {
                TransactionalId = transactionalId;
                return this;
            }

            private Int64 _producerId = Int64.Default;
            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int64 ProducerId
            {
                get => _producerId;
                private set
                {
                    _producerId = value;
                }
            }

            /// <summary>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TransactionState WithProducerId(Int64 producerId)
            {
                ProducerId = producerId;
                return this;
            }

            private String _transactionState = String.Default;
            /// <summary>
            /// <para>The current transaction state of the producer</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public String TransactionState_
            {
                get => _transactionState;
                private set
                {
                    _transactionState = value;
                }
            }

            /// <summary>
            /// <para>The current transaction state of the producer</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public TransactionState WithTransactionState_(String transactionState)
            {
                TransactionState_ = transactionState;
                return this;
            }
        }
    }
}
