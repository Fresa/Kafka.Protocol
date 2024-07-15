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
    public class FindCoordinatorRequest : Message, IRespond<FindCoordinatorResponse>
    {
        public FindCoordinatorRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"FindCoordinatorRequest does not support version {version}. Valid versions are: 0-6");
            Version = version;
            IsFlexibleVersion = version >= 3;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(10);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(6);
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

        internal override int GetSize() => (Version >= 0 && Version <= 3 ? _key.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 ? _keyType.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _coordinatorKeysCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<FindCoordinatorRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new FindCoordinatorRequest(version);
            if (instance.Version >= 0 && instance.Version <= 3)
                instance.Key = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1)
                instance.KeyType = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 4)
                instance.CoordinatorKeysCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for FindCoordinatorRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 0 && Version <= 3)
                await _key.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1)
                await _keyType.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 4)
                await _coordinatorKeysCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private String _key = String.Default;
        /// <summary>
        /// <para>The coordinator key.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public String Key
        {
            get => _key;
            private set
            {
                if (Version >= 0 && Version <= 3 == false)
                    throw new UnsupportedVersionException($"Key does not support version {Version} and has been defined as not ignorable. Supported versions: 0-3");
                _key = value;
            }
        }

        /// <summary>
        /// <para>The coordinator key.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public FindCoordinatorRequest WithKey(String key)
        {
            Key = key;
            return this;
        }

        private Int8 _keyType = new Int8(0);
        /// <summary>
        /// <para>The coordinator key type. (Group, transaction, etc.)</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public Int8 KeyType
        {
            get => _keyType;
            private set
            {
                if (Version >= 1 == false)
                    throw new UnsupportedVersionException($"KeyType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
                _keyType = value;
            }
        }

        /// <summary>
        /// <para>The coordinator key type. (Group, transaction, etc.)</para>
        /// <para>Versions: 1+</para>
        /// <para>Default: 0</para>
        /// </summary>
        public FindCoordinatorRequest WithKeyType(Int8 keyType)
        {
            KeyType = keyType;
            return this;
        }

        private Array<String> _coordinatorKeysCollection = Array.Empty<String>();
        /// <summary>
        /// <para>The coordinator keys.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public Array<String> CoordinatorKeysCollection
        {
            get => _coordinatorKeysCollection;
            private set
            {
                if (Version >= 4 == false)
                    throw new UnsupportedVersionException($"CoordinatorKeysCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                _coordinatorKeysCollection = value;
            }
        }

        /// <summary>
        /// <para>The coordinator keys.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public FindCoordinatorRequest WithCoordinatorKeysCollection(Array<String> coordinatorKeysCollection)
        {
            CoordinatorKeysCollection = coordinatorKeysCollection;
            return this;
        }

        public FindCoordinatorResponse Respond() => new FindCoordinatorResponse(Version);
    }
}
