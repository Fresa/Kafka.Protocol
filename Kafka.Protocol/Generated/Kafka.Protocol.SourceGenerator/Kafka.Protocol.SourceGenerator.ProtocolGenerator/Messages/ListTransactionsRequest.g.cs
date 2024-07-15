#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kafka.Protocol.Records;

// ReSharper disable MemberHidesStaticFromOuterClass FromReaderAsync will cause a lot of these warnings
namespace Kafka.Protocol
{
    public class ListTransactionsRequest : Message, IRespond<ListTransactionsResponse>
    {
        public ListTransactionsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"ListTransactionsRequest does not support version {version}. Valid versions are: 0-1");
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
                return (short)(IsFlexibleVersion ? 2 : 1);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => _stateFiltersCollection.GetSize(IsFlexibleVersion) + _producerIdFiltersCollection.GetSize(IsFlexibleVersion) + (Version >= 1 ? _durationFilter.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<ListTransactionsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new ListTransactionsRequest(version);
            instance.StateFiltersCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.ProducerIdFiltersCollection = await Array<Int64>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.DurationFilter = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for ListTransactionsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _stateFiltersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _producerIdFiltersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _durationFilter.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<String> _stateFiltersCollection = Array.Empty<String>();
        /// <summary>
        /// <para>The transaction states to filter by: if empty, all transactions are returned; if non-empty, then only transactions matching one of the filtered states will be returned</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<String> StateFiltersCollection
        {
            get => _stateFiltersCollection;
            private set
            {
                _stateFiltersCollection = value;
            }
        }

        /// <summary>
        /// <para>The transaction states to filter by: if empty, all transactions are returned; if non-empty, then only transactions matching one of the filtered states will be returned</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListTransactionsRequest WithStateFiltersCollection(Array<String> stateFiltersCollection)
        {
            StateFiltersCollection = stateFiltersCollection;
            return this;
        }

        private Array<Int64> _producerIdFiltersCollection = Array.Empty<Int64>();
        /// <summary>
        /// <para>The producerIds to filter by: if empty, all transactions will be returned; if non-empty, only transactions which match one of the filtered producerIds will be returned</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<Int64> ProducerIdFiltersCollection
        {
            get => _producerIdFiltersCollection;
            private set
            {
                _producerIdFiltersCollection = value;
            }
        }

        /// <summary>
        /// <para>The producerIds to filter by: if empty, all transactions will be returned; if non-empty, only transactions which match one of the filtered producerIds will be returned</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public ListTransactionsRequest WithProducerIdFiltersCollection(Array<Int64> producerIdFiltersCollection)
        {
            ProducerIdFiltersCollection = producerIdFiltersCollection;
            return this;
        }

        private Int64 _durationFilter = new Int64(-1);
        /// <summary>
        /// <para>Duration (in millis) to filter by: if < 0 , all  transactions  will  be  returned ; otherwise , only  transactions  running  longer  than  this  duration  will  be  returned</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public Int64 DurationFilter
        {
            get => _durationFilter;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"DurationFilter does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _durationFilter = value;
            }
        }

        /// <summary>
        /// <para>Duration (in millis) to filter by: if < 0 , all  transactions  will  be  returned ; otherwise , only  transactions  running  longer  than  this  duration  will  be  returned</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: -1</para>
        /// </summary>
        public ListTransactionsRequest WithDurationFilter(Int64 durationFilter)
        {
            DurationFilter = durationFilter;
            return this;
        }

        public ListTransactionsResponse Respond() => new ListTransactionsResponse(Version);
    }
}
