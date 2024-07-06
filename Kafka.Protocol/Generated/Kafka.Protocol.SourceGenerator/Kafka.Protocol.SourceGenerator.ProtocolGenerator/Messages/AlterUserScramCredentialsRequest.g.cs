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
    public class AlterUserScramCredentialsRequest : Message, IRespond<AlterUserScramCredentialsResponse>
    {
        public AlterUserScramCredentialsRequest(Int16 version)
        {
            if (version.InRange(MinVersion, MaxVersion) == false)
                throw new UnsupportedVersionException($"AlterUserScramCredentialsRequest does not support version {version}. Valid versions are: 0");
            Version = version;
            IsFlexibleVersion = true;
        }

        internal override Int16 ApiMessageKey => ApiKey;

        public static readonly Int16 ApiKey = Int16.From(51);
        public static readonly Int16 MinVersion = Int16.From(0);
        public static readonly Int16 MaxVersion = Int16.From(0);
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

        internal override int GetSize() => _deletionsCollection.GetSize(IsFlexibleVersion) + _upsertionsCollection.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
        internal static async ValueTask<AlterUserScramCredentialsRequest> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
        {
            var instance = new AlterUserScramCredentialsRequest(version);
            instance.DeletionsCollection = await Array<ScramCredentialDeletion>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ScramCredentialDeletion.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            instance.UpsertionsCollection = await Array<ScramCredentialUpsertion>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => ScramCredentialUpsertion.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    switch (tag.Tag)
                    {
                        default:
                            throw new InvalidOperationException($"Tag '{tag.Tag}' for AlterUserScramCredentialsRequest is unknown");
                    }
                }
            }

            return instance;
        }

        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
        {
            await _deletionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            await _upsertionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
            if (IsFlexibleVersion)
            {
                await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
            }
        }

        private Array<ScramCredentialDeletion> _deletionsCollection = Array.Empty<ScramCredentialDeletion>();
        /// <summary>
        /// <para>The SCRAM credentials to remove.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ScramCredentialDeletion> DeletionsCollection
        {
            get => _deletionsCollection;
            private set
            {
                _deletionsCollection = value;
            }
        }

        /// <summary>
        /// <para>The SCRAM credentials to remove.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterUserScramCredentialsRequest WithDeletionsCollection(params Func<ScramCredentialDeletion, ScramCredentialDeletion>[] createFields)
        {
            DeletionsCollection = createFields.Select(createField => createField(new ScramCredentialDeletion(Version))).ToArray();
            return this;
        }

        public delegate ScramCredentialDeletion CreateScramCredentialDeletion(ScramCredentialDeletion field);
        /// <summary>
        /// <para>The SCRAM credentials to remove.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterUserScramCredentialsRequest WithDeletionsCollection(IEnumerable<CreateScramCredentialDeletion> createFields)
        {
            DeletionsCollection = createFields.Select(createField => createField(new ScramCredentialDeletion(Version))).ToArray();
            return this;
        }

        public class ScramCredentialDeletion : ISerialize
        {
            internal ScramCredentialDeletion(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _mechanism.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ScramCredentialDeletion> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ScramCredentialDeletion(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Mechanism = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ScramCredentialDeletion is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _mechanism.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The user name.</para>
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
            /// <para>The user name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ScramCredentialDeletion WithName(String name)
            {
                Name = name;
                return this;
            }

            private Int8 _mechanism = Int8.Default;
            /// <summary>
            /// <para>The SCRAM mechanism.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int8 Mechanism
            {
                get => _mechanism;
                private set
                {
                    _mechanism = value;
                }
            }

            /// <summary>
            /// <para>The SCRAM mechanism.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ScramCredentialDeletion WithMechanism(Int8 mechanism)
            {
                Mechanism = mechanism;
                return this;
            }
        }

        private Array<ScramCredentialUpsertion> _upsertionsCollection = Array.Empty<ScramCredentialUpsertion>();
        /// <summary>
        /// <para>The SCRAM credentials to update/insert.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public Array<ScramCredentialUpsertion> UpsertionsCollection
        {
            get => _upsertionsCollection;
            private set
            {
                _upsertionsCollection = value;
            }
        }

        /// <summary>
        /// <para>The SCRAM credentials to update/insert.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterUserScramCredentialsRequest WithUpsertionsCollection(params Func<ScramCredentialUpsertion, ScramCredentialUpsertion>[] createFields)
        {
            UpsertionsCollection = createFields.Select(createField => createField(new ScramCredentialUpsertion(Version))).ToArray();
            return this;
        }

        public delegate ScramCredentialUpsertion CreateScramCredentialUpsertion(ScramCredentialUpsertion field);
        /// <summary>
        /// <para>The SCRAM credentials to update/insert.</para>
        /// <para>Versions: 0+</para>
        /// </summary>
        public AlterUserScramCredentialsRequest WithUpsertionsCollection(IEnumerable<CreateScramCredentialUpsertion> createFields)
        {
            UpsertionsCollection = createFields.Select(createField => createField(new ScramCredentialUpsertion(Version))).ToArray();
            return this;
        }

        public class ScramCredentialUpsertion : ISerialize
        {
            internal ScramCredentialUpsertion(Int16 version)
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
            internal int GetSize(bool _) => _name.GetSize(IsFlexibleVersion) + _mechanism.GetSize(IsFlexibleVersion) + _iterations.GetSize(IsFlexibleVersion) + _salt.GetSize(IsFlexibleVersion) + _saltedPassword.GetSize(IsFlexibleVersion) + (IsFlexibleVersion ? CreateTagSection().GetSize() : 0);
            internal static async ValueTask<ScramCredentialUpsertion> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
            {
                var instance = new ScramCredentialUpsertion(version);
                instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Mechanism = await Int8.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Iterations = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.Salt = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                instance.SaltedPassword = await Bytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (instance.IsFlexibleVersion)
                {
                    var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                    await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
                    {
                        switch (tag.Tag)
                        {
                            default:
                                throw new InvalidOperationException($"Tag '{tag.Tag}' for ScramCredentialUpsertion is unknown");
                        }
                    }
                }

                return instance;
            }

            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
            internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
            {
                await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _mechanism.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _iterations.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _salt.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                await _saltedPassword.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                if (IsFlexibleVersion)
                {
                    await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
                }
            }

            private String _name = String.Default;
            /// <summary>
            /// <para>The user name.</para>
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
            /// <para>The user name.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ScramCredentialUpsertion WithName(String name)
            {
                Name = name;
                return this;
            }

            private Int8 _mechanism = Int8.Default;
            /// <summary>
            /// <para>The SCRAM mechanism.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int8 Mechanism
            {
                get => _mechanism;
                private set
                {
                    _mechanism = value;
                }
            }

            /// <summary>
            /// <para>The SCRAM mechanism.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ScramCredentialUpsertion WithMechanism(Int8 mechanism)
            {
                Mechanism = mechanism;
                return this;
            }

            private Int32 _iterations = Int32.Default;
            /// <summary>
            /// <para>The number of iterations.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Int32 Iterations
            {
                get => _iterations;
                private set
                {
                    _iterations = value;
                }
            }

            /// <summary>
            /// <para>The number of iterations.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ScramCredentialUpsertion WithIterations(Int32 iterations)
            {
                Iterations = iterations;
                return this;
            }

            private Bytes _salt = Bytes.Default;
            /// <summary>
            /// <para>A random salt generated by the client.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Bytes Salt
            {
                get => _salt;
                private set
                {
                    _salt = value;
                }
            }

            /// <summary>
            /// <para>A random salt generated by the client.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ScramCredentialUpsertion WithSalt(Bytes salt)
            {
                Salt = salt;
                return this;
            }

            private Bytes _saltedPassword = Bytes.Default;
            /// <summary>
            /// <para>The salted password.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public Bytes SaltedPassword
            {
                get => _saltedPassword;
                private set
                {
                    _saltedPassword = value;
                }
            }

            /// <summary>
            /// <para>The salted password.</para>
            /// <para>Versions: 0+</para>
            /// </summary>
            public ScramCredentialUpsertion WithSaltedPassword(Bytes saltedPassword)
            {
                SaltedPassword = saltedPassword;
                return this;
            }
        }

        public AlterUserScramCredentialsResponse Respond() => new AlterUserScramCredentialsResponse(Version);
    }
}
