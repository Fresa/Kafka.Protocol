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
    public class DefaultPrincipalData
    {
        public DefaultPrincipalData(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"DefaultPrincipalData does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
        public Int16 Version { get; }
        internal bool IsFlexibleVersion { get; }

        private Tags.TagSection CreateTagSection()
        {
            return new Tags.TagSection();
        }

        internal int GetSize() => _type.GetSize(IsFlexibleVersion) + _name.GetSize(IsFlexibleVersion) + _tokenAuthenticated.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        public static async ValueTask<DefaultPrincipalData> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
        {
            var pipe = new Pipe();
            await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
            var reader = pipe.Reader;
            var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
            var instance = new DefaultPrincipalData(version);
            instance.Type = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            instance.TokenAuthenticated = await Boolean.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for DefaultPrincipalData is unknown");
                    }
                }
            }

            return instance;
        }

        public async ValueTask<Bytes> ToBytesAsync(CancellationToken cancellationToken = default)
        {
            var writer = new MemoryStream();
            await using (writer.ConfigureAwait(false))
            {
                await Version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _type.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _tokenAuthenticated.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }

                return new Bytes(writer.ToArray());
            }
        }

        private String _type = String.Default;
        /// <summary>
        /// <para>The principal type.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String Type
        {
            get => _type;
            private set
            {
                _type = value;
            }
        }

        /// <summary>
        /// <para>The principal type.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DefaultPrincipalData WithType(String type)
        {
            Type = type;
            return this;
        }

        private String _name = String.Default;
        /// <summary>
        /// <para>The principal name.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public String Name
        {
            get => _name;
            private set
            {
                _name = value;
            }
        }

        /// <summary>
        /// <para>The principal name.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DefaultPrincipalData WithName(String name)
        {
            Name = name;
            return this;
        }

        private Boolean _tokenAuthenticated = Boolean.Default;
        /// <summary>
        /// <para>Whether the principal was authenticated by a delegation token on the forwarding broker.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Boolean TokenAuthenticated
        {
            get => _tokenAuthenticated;
            private set
            {
                _tokenAuthenticated = value;
            }
        }

        /// <summary>
        /// <para>Whether the principal was authenticated by a delegation token on the forwarding broker.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public DefaultPrincipalData WithTokenAuthenticated(Boolean tokenAuthenticated)
        {
            TokenAuthenticated = tokenAuthenticated;
            return this;
        }
    }
}
