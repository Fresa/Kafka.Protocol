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
    public class FindCoordinatorResponse : Message
    {
        public FindCoordinatorResponse(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"FindCoordinatorResponse does not support version {version}. Valid versions are: 0-6");
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
                return (short)(IsFlexibleVersion ? 1 : 0);
            }
        }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal override int GetSize() => (Version >= 1 ? _throttleTimeMs.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 3 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + (Version >= 1 && Version <= 3 ? _errorMessage.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 3 ? _nodeId.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 3 ? _host.GetSize(IsFlexibleVersion) : 0) + (Version >= 0 && Version <= 3 ? _port.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _coordinatorsCollection.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<FindCoordinatorResponse> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new FindCoordinatorResponse(version);
            if (instance.Version >= 1)
                instance.ThrottleTimeMs = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 3)
                instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 1 && instance.Version <= 3)
                instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 3)
                instance.NodeId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 3)
                instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 0 && instance.Version <= 3)
                instance.Port = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.Version >= 4)
                instance.CoordinatorsCollection = await Array<Coordinator>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Coordinator.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for FindCoordinatorResponse is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            if (Version >= 1)
                await _throttleTimeMs.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 3)
                await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 1 && Version <= 3)
                await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 3)
                await _nodeId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 3)
                await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 0 && Version <= 3)
                await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (Version >= 4)
                await _coordinatorsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Int32 _throttleTimeMs = Int32.Default;
        /// <summary>
        /// <para>The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</para>
        /// <para>Versions: 1+</para>
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
        /// <para>Versions: 1+</para>
        /// </summary>
        public FindCoordinatorResponse WithThrottleTimeMs(Int32 throttleTimeMs)
        {
            ThrottleTimeMs = throttleTimeMs;
            return this;
        }

        private Int16 _errorCode = Int16.Default;
        /// <summary>
        /// <para>The error code, or 0 if there was no error.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public Int16 ErrorCode
        {
            get => _errorCode;
            private set
            {
                if (Version >= 0 && Version <= 3 == false)
                    throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0-3");
                _errorCode = value;
            }
        }

        /// <summary>
        /// <para>The error code, or 0 if there was no error.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public FindCoordinatorResponse WithErrorCode(Int16 errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        private NullableString _errorMessage = NullableString.Default;
        /// <summary>
        /// <para>The error message, or null if there was no error.</para>
        /// <para>Versions: 1-3</para>
        /// </summary>
        public String? ErrorMessage
        {
            get => _errorMessage;
            private set
            {
                if (Version >= 1 && Version <= 3 == false && value == null)
                    throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 1-3");
                _errorMessage = value;
            }
        }

        /// <summary>
        /// <para>The error message, or null if there was no error.</para>
        /// <para>Versions: 1-3</para>
        /// </summary>
        public FindCoordinatorResponse WithErrorMessage(String? errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        private Int32 _nodeId = Int32.Default;
        /// <summary>
        /// <para>The node id.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public Int32 NodeId
        {
            get => _nodeId;
            private set
            {
                if (Version >= 0 && Version <= 3 == false)
                    throw new UnsupportedVersionException($"NodeId does not support version {Version} and has been defined as not ignorable. Supported versions: 0-3");
                _nodeId = value;
            }
        }

        /// <summary>
        /// <para>The node id.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public FindCoordinatorResponse WithNodeId(Int32 nodeId)
        {
            NodeId = nodeId;
            return this;
        }

        private String _host = String.Default;
        /// <summary>
        /// <para>The host name.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public String Host
        {
            get => _host;
            private set
            {
                if (Version >= 0 && Version <= 3 == false)
                    throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 0-3");
                _host = value;
            }
        }

        /// <summary>
        /// <para>The host name.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public FindCoordinatorResponse WithHost(String host)
        {
            Host = host;
            return this;
        }

        private Int32 _port = Int32.Default;
        /// <summary>
        /// <para>The port.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public Int32 Port
        {
            get => _port;
            private set
            {
                if (Version >= 0 && Version <= 3 == false)
                    throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 0-3");
                _port = value;
            }
        }

        /// <summary>
        /// <para>The port.</para>
        /// <para>Versions: 0-3</para>
        /// </summary>
        public FindCoordinatorResponse WithPort(Int32 port)
        {
            Port = port;
            return this;
        }

        private Array<Coordinator> _coordinatorsCollection = Array.Empty<Coordinator>();
        /// <summary>
        /// <para>Each coordinator result in the response.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public Array<Coordinator> CoordinatorsCollection
        {
            get => _coordinatorsCollection;
            private set
            {
                if (Version >= 4 == false)
                    throw new UnsupportedVersionException($"CoordinatorsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                _coordinatorsCollection = value;
            }
        }

        /// <summary>
        /// <para>Each coordinator result in the response.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public FindCoordinatorResponse WithCoordinatorsCollection(params Func<Coordinator, Coordinator>[] createFields)
        {
            CoordinatorsCollection = createFields.Select(createField => createField(new Coordinator(Version))).ToArray();
            return this;
        }

        public delegate Coordinator CreateCoordinator(Coordinator field);
        /// <summary>
        /// <para>Each coordinator result in the response.</para>
        /// <para>Versions: 4+</para>
        /// </summary>
        public FindCoordinatorResponse WithCoordinatorsCollection(IEnumerable<CreateCoordinator> createFields)
        {
            CoordinatorsCollection = createFields.Select(createField => createField(new Coordinator(Version))).ToArray();
            return this;
        }

        public class Coordinator : ISerialize
        {
            internal Coordinator(Int16 version)
            {
                Version = version;
                IsFlexibleVersion = version >= 3;
            }

            internal Int16 Version { get; }
            internal bool IsFlexibleVersion { get; }

            private Tags.TagSection CreateTagSection()
            {
                return new Tags.TagSection();
            }

            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
            internal int GetSize(bool _) => (Version >= 4 ? _key.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _nodeId.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _host.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _port.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _errorCode.GetSize(IsFlexibleVersion) : 0) + (Version >= 4 ? _errorMessage.GetSize(IsFlexibleVersion) : 0) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<Coordinator> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new Coordinator(version);
                if (instance.Version >= 4)
                    instance.Key = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.NodeId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.Port = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.ErrorCode = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.Version >= 4)
                    instance.ErrorMessage = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for Coordinator is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                if (Version >= 4)
                    await _key.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _nodeId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _errorCode.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (Version >= 4)
                    await _errorMessage.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _key = String.Default;
            /// <summary>
            /// <para>The coordinator key.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public String Key
            {
                get => _key;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"Key does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _key = value;
                }
            }

            /// <summary>
            /// <para>The coordinator key.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Coordinator WithKey(String key)
            {
                Key = key;
                return this;
            }

            private Int32 _nodeId = Int32.Default;
            /// <summary>
            /// <para>The node id.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Int32 NodeId
            {
                get => _nodeId;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"NodeId does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _nodeId = value;
                }
            }

            /// <summary>
            /// <para>The node id.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Coordinator WithNodeId(Int32 nodeId)
            {
                NodeId = nodeId;
                return this;
            }

            private String _host = String.Default;
            /// <summary>
            /// <para>The host name.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public String Host
            {
                get => _host;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _host = value;
                }
            }

            /// <summary>
            /// <para>The host name.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Coordinator WithHost(String host)
            {
                Host = host;
                return this;
            }

            private Int32 _port = Int32.Default;
            /// <summary>
            /// <para>The port.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Int32 Port
            {
                get => _port;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _port = value;
                }
            }

            /// <summary>
            /// <para>The port.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Coordinator WithPort(Int32 port)
            {
                Port = port;
                return this;
            }

            private Int16 _errorCode = Int16.Default;
            /// <summary>
            /// <para>The error code, or 0 if there was no error.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Int16 ErrorCode
            {
                get => _errorCode;
                private set
                {
                    if (Version >= 4 == false)
                        throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
                    _errorCode = value;
                }
            }

            /// <summary>
            /// <para>The error code, or 0 if there was no error.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Coordinator WithErrorCode(Int16 errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            private NullableString _errorMessage = NullableString.Default;
            /// <summary>
            /// <para>The error message, or null if there was no error.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public String? ErrorMessage
            {
                get => _errorMessage;
                private set
                {
                    if (Version >= 4 == false && value == null)
                        throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 4+");
                    _errorMessage = value;
                }
            }

            /// <summary>
            /// <para>The error message, or null if there was no error.</para>
            /// <para>Versions: 4+</para>
            /// </summary>
            public Coordinator WithErrorMessage(String? errorMessage)
            {
                ErrorMessage = errorMessage;
                return this;
            }
        }
    }
}
