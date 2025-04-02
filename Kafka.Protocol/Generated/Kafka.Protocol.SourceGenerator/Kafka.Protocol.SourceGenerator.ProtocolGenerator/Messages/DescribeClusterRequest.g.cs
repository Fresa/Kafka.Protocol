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
    public class DescribeClusterRequest : Message, IRespond<DescribeClusterResponse>
    {
        public DescribeClusterRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DescribeClusterRequest does not support version {version}. Valid versions are: 0-2");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(60);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(2);
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

        internal override int GetSize() => _includeClusterAuthorizedOperations.GetSize(IsFlexibleVersion) + (Version >= 1 ? _endpointType.GetSize(IsFlexibleVersion) : 0) + (Version >= 2 ? _includeFencedBrokers.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<DescribeClusterRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new DescribeClusterRequest(version);
            instance.IncludeClusterAuthorizedOperations = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.EndpointType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 2)
                instance.IncludeFencedBrokers = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DescribeClusterRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _includeClusterAuthorizedOperations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _endpointType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 2)
                await _includeFencedBrokers.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Boolean _includeClusterAuthorizedOperations = Boolean.Default;
        /// <summary>
        /// <para>Whether to include cluster authorized operations.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean IncludeClusterAuthorizedOperations
        {
            get => _includeClusterAuthorizedOperations;
            private set
            {
                _includeClusterAuthorizedOperations = value;
            }
        }

        /// <summary>
        /// <para>Whether to include cluster authorized operations.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DescribeClusterRequest WithIncludeClusterAuthorizedOperations(Boolean includeClusterAuthorizedOperations)
        {
            IncludeClusterAuthorizedOperations = includeClusterAuthorizedOperations;
            return this;
        }

        private Int8 _endpointType = new Int8(1);
        /// <summary>
        /// <para>The endpoint type to describe. 1=brokers, 2=controllers.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: 1</para>
        /// </summary>
        public Int8 EndpointType
        {
            get => _endpointType;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"EndpointType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _endpointType = value;
            }
        }

        /// <summary>
        /// <para>The endpoint type to describe. 1=brokers, 2=controllers.</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: 1</para>
        /// </summary>
        public DescribeClusterRequest WithEndpointType(Int8 endpointType)
        {
            EndpointType = endpointType;
            return this;
        }

        private Boolean _includeFencedBrokers = Boolean.Default;
        /// <summary>
        /// <para>Whether to include fenced brokers when listing brokers.</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public Boolean IncludeFencedBrokers
        {
            get => _includeFencedBrokers;
            private set
            {
                if (Version >= 2 == false)
                    throw new UnsupportedVersionException($"IncludeFencedBrokers does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
                _includeFencedBrokers = value;
            }
        }

        /// <summary>
        /// <para>Whether to include fenced brokers when listing brokers.</para>
        /// <para>Versions: 2+</para>
        /// </summary>
        public DescribeClusterRequest WithIncludeFencedBrokers(Boolean includeFencedBrokers)
        {
            IncludeFencedBrokers = includeFencedBrokers;
            return this;
        }

        public DescribeClusterResponse Respond() => new DescribeClusterResponse(Version);
    }
}
