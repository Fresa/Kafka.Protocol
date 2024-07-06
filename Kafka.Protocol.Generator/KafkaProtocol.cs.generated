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
	public class ConsumerProtocolAssignment
	{
		public ConsumerProtocolAssignment(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
				throw new UnsupportedVersionException($"ConsumerProtocolAssignment does not support version {version}. Valid versions are: 0-3");

			Version = version;
			IsFlexibleVersion = false;
		}

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(3);

		public Int16 Version { get; }
		internal bool IsFlexibleVersion { get; }

		private Tags.TagSection CreateTagSection()
		{
			return new Tags.TagSection();
		}

		internal int GetSize() =>
			_assignedPartitionsCollection.GetSize(IsFlexibleVersion) +
			_userData.GetSize(IsFlexibleVersion) +
			(IsFlexibleVersion ? 
				CreateTagSection().GetSize() :
				0);

		public static async ValueTask<ConsumerProtocolAssignment> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
		{
			var pipe = new Pipe();
			await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
			var reader = pipe.Reader;

			var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
			var instance = new ConsumerProtocolAssignment(version);
			instance.AssignedPartitionsCollection = await Map<String, TopicPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicPartition.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Topic, cancellationToken).ConfigureAwait(false);
			instance.UserData = await NullableBytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

			if (instance.IsFlexibleVersion)
			{
				var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
				await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
				{
					switch (tag.Tag)
					{
						default:
							throw new InvalidOperationException($"Tag '{tag.Tag}' for ConsumerProtocolAssignment is unknown");
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
				await _assignedPartitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _userData.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
				return new Bytes(writer.ToArray());
			}
		}

		private Map<String, TopicPartition> _assignedPartitionsCollection = Map<String, TopicPartition>.Default;
		/// <summary>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Map<String, TopicPartition> AssignedPartitionsCollection 
		{
			get => _assignedPartitionsCollection;
			private set 
			{
				_assignedPartitionsCollection = value;
			}
		}

		/// <summary>
		/// <para>Versions: 0+</para>
		/// </summary>
		public ConsumerProtocolAssignment WithAssignedPartitionsCollection(params Func<TopicPartition, TopicPartition>[] createFields)
		{
			AssignedPartitionsCollection = createFields
				.Select(createField => createField(new TopicPartition(Version)))
				.ToDictionary(field => field.Topic);
			return this;
		}

		public delegate TopicPartition CreateTopicPartition(TopicPartition field);

		/// <summary>
		/// <para>Versions: 0+</para>
		/// </summary>
		public ConsumerProtocolAssignment WithAssignedPartitionsCollection(IEnumerable<CreateTopicPartition> createFields)
		{
			AssignedPartitionsCollection = createFields
				.Select(createField => createField(new TopicPartition(Version)))
				.ToDictionary(field => field.Topic);
			return this;
		}

		public class TopicPartition : ISerialize
		{
			internal TopicPartition(Int16 version)
			{
				Version = version;
				IsFlexibleVersion = false;
			}

			internal Int16 Version { get; }
			internal bool IsFlexibleVersion { get; }

			private Tags.TagSection CreateTagSection()
			{
				return new Tags.TagSection();
			}

			int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
			internal int GetSize(bool _) =>
				_topic.GetSize(IsFlexibleVersion) +
				_partitionsCollection.GetSize(IsFlexibleVersion) +
				(IsFlexibleVersion ? 
					CreateTagSection().GetSize() :
					0);

			internal static async ValueTask<TopicPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TopicPartition(version);
				instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);

				if (instance.IsFlexibleVersion)
				{
					var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
					await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
					{
						switch (tag.Tag)
						{
							default:
								throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicPartition is unknown");
						}
					}
				}

				return instance;
			}

			ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
			internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
			{
				await _topic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
			}

			private String _topic = String.Default;
			/// <summary>
			/// <para>Versions: 0+</para>
			/// </summary>
			public String Topic 
			{
				get => _topic;
				private set 
				{
					_topic = value;
				}
			}

			/// <summary>
			/// <para>Versions: 0+</para>
			/// </summary>
			public TopicPartition WithTopic(String topic)
			{
				Topic = topic;
				return this;
			}

			private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
			/// <summary>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Array<Int32> PartitionsCollection 
			{
				get => _partitionsCollection;
				private set 
				{
					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// <para>Versions: 0+</para>
			/// </summary>
			public TopicPartition WithPartitionsCollection(Array<Int32> partitionsCollection)
			{
				PartitionsCollection = partitionsCollection;
				return this;
			}
		}

		private NullableBytes _userData = new NullableBytes(null);
		/// <summary>
		/// <para>Versions: 0+</para>
		/// <para>Default: null</para>
		/// </summary>
		public Bytes? UserData 
		{
			get => _userData;
			private set 
			{
				_userData = value;
			}
		}

		/// <summary>
		/// <para>Versions: 0+</para>
		/// <para>Default: null</para>
		/// </summary>
		public ConsumerProtocolAssignment WithUserData(Bytes? userData)
		{
			UserData = userData;
			return this;
		}
	}

	public class ConsumerProtocolSubscription
	{
		public ConsumerProtocolSubscription(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
				throw new UnsupportedVersionException($"ConsumerProtocolSubscription does not support version {version}. Valid versions are: 0-3");

			Version = version;
			IsFlexibleVersion = false;
		}

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(3);

		public Int16 Version { get; }
		internal bool IsFlexibleVersion { get; }

		private Tags.TagSection CreateTagSection()
		{
			return new Tags.TagSection();
		}

		internal int GetSize() =>
			_topicsCollection.GetSize(IsFlexibleVersion) +
			_userData.GetSize(IsFlexibleVersion) +
			(Version >= 1 ? 
				_ownedPartitionsCollection.GetSize(IsFlexibleVersion):
				0) +
			(Version >= 2 ? 
				_generationId.GetSize(IsFlexibleVersion):
				0) +
			(Version >= 3 ? 
				_rackId.GetSize(IsFlexibleVersion):
				0) +
			(IsFlexibleVersion ? 
				CreateTagSection().GetSize() :
				0);

		public static async ValueTask<ConsumerProtocolSubscription> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
		{
			var pipe = new Pipe();
			await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
			var reader = pipe.Reader;

			var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
			var instance = new ConsumerProtocolSubscription(version);
			instance.TopicsCollection = await Array<String>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);
			instance.UserData = await NullableBytes.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
			if (instance.Version >= 1) 
				instance.OwnedPartitionsCollection = await Map<String, TopicPartition>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => TopicPartition.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Topic, cancellationToken).ConfigureAwait(false);
			if (instance.Version >= 2) 
				instance.GenerationId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
			if (instance.Version >= 3) 
				instance.RackId = await NullableString.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

			if (instance.IsFlexibleVersion)
			{
				var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
				await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
				{
					switch (tag.Tag)
					{
						default:
							throw new InvalidOperationException($"Tag '{tag.Tag}' for ConsumerProtocolSubscription is unknown");
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
				await _topicsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _userData.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				if (Version >= 1)
					await _ownedPartitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				if (Version >= 2)
					await _generationId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				if (Version >= 3)
					await _rackId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
				return new Bytes(writer.ToArray());
			}
		}

		private Array<String> _topicsCollection = Array.Empty<String>();
		/// <summary>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Array<String> TopicsCollection 
		{
			get => _topicsCollection;
			private set 
			{
				_topicsCollection = value;
			}
		}

		/// <summary>
		/// <para>Versions: 0+</para>
		/// </summary>
		public ConsumerProtocolSubscription WithTopicsCollection(Array<String> topicsCollection)
		{
			TopicsCollection = topicsCollection;
			return this;
		}

		private NullableBytes _userData = new NullableBytes(null);
		/// <summary>
		/// <para>Versions: 0+</para>
		/// <para>Default: null</para>
		/// </summary>
		public Bytes? UserData 
		{
			get => _userData;
			private set 
			{
				_userData = value;
			}
		}

		/// <summary>
		/// <para>Versions: 0+</para>
		/// <para>Default: null</para>
		/// </summary>
		public ConsumerProtocolSubscription WithUserData(Bytes? userData)
		{
			UserData = userData;
			return this;
		}

		private Map<String, TopicPartition> _ownedPartitionsCollection = Map<String, TopicPartition>.Default;
		/// <summary>
		/// <para>Versions: 1+</para>
		/// </summary>
		public Map<String, TopicPartition> OwnedPartitionsCollection 
		{
			get => _ownedPartitionsCollection;
			private set 
			{
				_ownedPartitionsCollection = value;
			}
		}

		/// <summary>
		/// <para>Versions: 1+</para>
		/// </summary>
		public ConsumerProtocolSubscription WithOwnedPartitionsCollection(params Func<TopicPartition, TopicPartition>[] createFields)
		{
			OwnedPartitionsCollection = createFields
				.Select(createField => createField(new TopicPartition(Version)))
				.ToDictionary(field => field.Topic);
			return this;
		}

		public delegate TopicPartition CreateTopicPartition(TopicPartition field);

		/// <summary>
		/// <para>Versions: 1+</para>
		/// </summary>
		public ConsumerProtocolSubscription WithOwnedPartitionsCollection(IEnumerable<CreateTopicPartition> createFields)
		{
			OwnedPartitionsCollection = createFields
				.Select(createField => createField(new TopicPartition(Version)))
				.ToDictionary(field => field.Topic);
			return this;
		}

		public class TopicPartition : ISerialize
		{
			internal TopicPartition(Int16 version)
			{
				Version = version;
				IsFlexibleVersion = false;
			}

			internal Int16 Version { get; }
			internal bool IsFlexibleVersion { get; }

			private Tags.TagSection CreateTagSection()
			{
				return new Tags.TagSection();
			}

			int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
			internal int GetSize(bool _) =>
				(Version >= 1 ? 
					_topic.GetSize(IsFlexibleVersion):
					0) +
				(Version >= 1 ? 
					_partitionsCollection.GetSize(IsFlexibleVersion):
					0) +
				(IsFlexibleVersion ? 
					CreateTagSection().GetSize() :
					0);

			internal static async ValueTask<TopicPartition> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TopicPartition(version);
				if (instance.Version >= 1) 
					instance.Topic = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				if (instance.Version >= 1) 
					instance.PartitionsCollection = await Array<Int32>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken), cancellationToken).ConfigureAwait(false);

				if (instance.IsFlexibleVersion)
				{
					var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
					await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
					{
						switch (tag.Tag)
						{
							default:
								throw new InvalidOperationException($"Tag '{tag.Tag}' for TopicPartition is unknown");
						}
					}
				}

				return instance;
			}

			ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
			internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
			{
				if (Version >= 1)
					await _topic.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				if (Version >= 1)
					await _partitionsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
			}

			private String _topic = String.Default;
			/// <summary>
			/// <para>Versions: 1+</para>
			/// </summary>
			public String Topic 
			{
				get => _topic;
				private set 
				{
					if (Version >= 1 == false)
						throw new UnsupportedVersionException($"Topic does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");

					_topic = value;
				}
			}

			/// <summary>
			/// <para>Versions: 1+</para>
			/// </summary>
			public TopicPartition WithTopic(String topic)
			{
				Topic = topic;
				return this;
			}

			private Array<Int32> _partitionsCollection = Array.Empty<Int32>();
			/// <summary>
			/// <para>Versions: 1+</para>
			/// </summary>
			public Array<Int32> PartitionsCollection 
			{
				get => _partitionsCollection;
				private set 
				{
					if (Version >= 1 == false)
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// <para>Versions: 1+</para>
			/// </summary>
			public TopicPartition WithPartitionsCollection(Array<Int32> partitionsCollection)
			{
				PartitionsCollection = partitionsCollection;
				return this;
			}
		}

		private Int32 _generationId = new Int32(-1);
		/// <summary>
		/// <para>Versions: 2+</para>
		/// <para>Default: -1</para>
		/// </summary>
		public Int32 GenerationId 
		{
			get => _generationId;
			private set 
			{
				_generationId = value;
			}
		}

		/// <summary>
		/// <para>Versions: 2+</para>
		/// <para>Default: -1</para>
		/// </summary>
		public ConsumerProtocolSubscription WithGenerationId(Int32 generationId)
		{
			GenerationId = generationId;
			return this;
		}

		private NullableString _rackId = new NullableString(null);
		/// <summary>
		/// <para>Versions: 3+</para>
		/// <para>Default: null</para>
		/// </summary>
		public String? RackId 
		{
			get => _rackId;
			private set 
			{
				if (Version >= 3 == false &&
					value == null) 
					throw new UnsupportedVersionException($"RackId does not support null for version {Version}. Supported versions for null value: 3+");

				_rackId = value;
			}
		}

		/// <summary>
		/// <para>Versions: 3+</para>
		/// <para>Default: null</para>
		/// </summary>
		public ConsumerProtocolSubscription WithRackId(String? rackId)
		{
			RackId = rackId;
			return this;
		}
	}

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

		internal int GetSize() =>
			_type.GetSize(IsFlexibleVersion) +
			_name.GetSize(IsFlexibleVersion) +
			_tokenAuthenticated.GetSize(IsFlexibleVersion) +
			(IsFlexibleVersion ? 
				CreateTagSection().GetSize() :
				0);

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
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
				return new Bytes(writer.ToArray());
			}
		}

		private String _type = String.Default;
		/// <summary>
		/// <para>The principal type</para>
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
		/// <para>The principal type</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public DefaultPrincipalData WithType(String type)
		{
			Type = type;
			return this;
		}

		private String _name = String.Default;
		/// <summary>
		/// <para>The principal name</para>
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
		/// <para>The principal name</para>
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

	public class KRaftVersionRecord
	{
		public KRaftVersionRecord(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
				throw new UnsupportedVersionException($"KRaftVersionRecord does not support version {version}. Valid versions are: 0");

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

		internal int GetSize() =>
			_version.GetSize(IsFlexibleVersion) +
			_kRaftVersion.GetSize(IsFlexibleVersion) +
			(IsFlexibleVersion ? 
				CreateTagSection().GetSize() :
				0);

		public static async ValueTask<KRaftVersionRecord> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
		{
			var pipe = new Pipe();
			await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
			var reader = pipe.Reader;

			var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
			var instance = new KRaftVersionRecord(version);
			instance.Version_ = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
			instance.KRaftVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

			if (instance.IsFlexibleVersion)
			{
				var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
				await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
				{
					switch (tag.Tag)
					{
						default:
							throw new InvalidOperationException($"Tag '{tag.Tag}' for KRaftVersionRecord is unknown");
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
				await _version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _kRaftVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
				return new Bytes(writer.ToArray());
			}
		}

		private Int16 _version = Int16.Default;
		/// <summary>
		/// <para>The version of the kraft version record</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Int16 Version_ 
		{
			get => _version;
			private set 
			{
				_version = value;
			}
		}

		/// <summary>
		/// <para>The version of the kraft version record</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public KRaftVersionRecord WithVersion_(Int16 version)
		{
			Version_ = version;
			return this;
		}

		private Int16 _kRaftVersion = Int16.Default;
		/// <summary>
		/// <para>The kraft protocol version</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Int16 KRaftVersion 
		{
			get => _kRaftVersion;
			private set 
			{
				_kRaftVersion = value;
			}
		}

		/// <summary>
		/// <para>The kraft protocol version</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public KRaftVersionRecord WithKRaftVersion(Int16 kRaftVersion)
		{
			KRaftVersion = kRaftVersion;
			return this;
		}
	}

	public class LeaderChangeMessage
	{
		public LeaderChangeMessage(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
				throw new UnsupportedVersionException($"LeaderChangeMessage does not support version {version}. Valid versions are: 0");

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

		internal int GetSize() =>
			_version.GetSize(IsFlexibleVersion) +
			_leaderId.GetSize(IsFlexibleVersion) +
			_votersCollection.GetSize(IsFlexibleVersion) +
			_grantingVotersCollection.GetSize(IsFlexibleVersion) +
			(IsFlexibleVersion ? 
				CreateTagSection().GetSize() :
				0);

		public static async ValueTask<LeaderChangeMessage> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
		{
			var pipe = new Pipe();
			await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
			var reader = pipe.Reader;

			var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
			var instance = new LeaderChangeMessage(version);
			instance.Version_ = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
			instance.LeaderId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
			instance.VotersCollection = await Array<Voter>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Voter.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);
			instance.GrantingVotersCollection = await Array<Voter>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Voter.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);

			if (instance.IsFlexibleVersion)
			{
				var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
				await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
				{
					switch (tag.Tag)
					{
						default:
							throw new InvalidOperationException($"Tag '{tag.Tag}' for LeaderChangeMessage is unknown");
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
				await _version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _leaderId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _votersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _grantingVotersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
				return new Bytes(writer.ToArray());
			}
		}

		private Int16 _version = Int16.Default;
		/// <summary>
		/// <para>The version of the leader change message</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Int16 Version_ 
		{
			get => _version;
			private set 
			{
				_version = value;
			}
		}

		/// <summary>
		/// <para>The version of the leader change message</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public LeaderChangeMessage WithVersion_(Int16 version)
		{
			Version_ = version;
			return this;
		}

		private Int32 _leaderId = Int32.Default;
		/// <summary>
		/// <para>The ID of the newly elected leader</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Int32 LeaderId 
		{
			get => _leaderId;
			private set 
			{
				_leaderId = value;
			}
		}

		/// <summary>
		/// <para>The ID of the newly elected leader</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public LeaderChangeMessage WithLeaderId(Int32 leaderId)
		{
			LeaderId = leaderId;
			return this;
		}

		private Array<Voter> _votersCollection = Array.Empty<Voter>();
		/// <summary>
		/// <para>The set of voters in the quorum for this epoch</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Array<Voter> VotersCollection 
		{
			get => _votersCollection;
			private set 
			{
				_votersCollection = value;
			}
		}

		/// <summary>
		/// <para>The set of voters in the quorum for this epoch</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public LeaderChangeMessage WithVotersCollection(Array<Voter> votersCollection)
		{
			VotersCollection = votersCollection;
			return this;
		}

		private Array<Voter> _grantingVotersCollection = Array.Empty<Voter>();
		/// <summary>
		/// <para>The voters who voted for the leader at the time of election</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Array<Voter> GrantingVotersCollection 
		{
			get => _grantingVotersCollection;
			private set 
			{
				_grantingVotersCollection = value;
			}
		}

		/// <summary>
		/// <para>The voters who voted for the leader at the time of election</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public LeaderChangeMessage WithGrantingVotersCollection(Array<Voter> grantingVotersCollection)
		{
			GrantingVotersCollection = grantingVotersCollection;
			return this;
		}

		public class Voter : ISerialize
		{
			internal Voter(Int16 version)
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
			internal int GetSize(bool _) =>
				_voterId.GetSize(IsFlexibleVersion) +
				(IsFlexibleVersion ? 
					CreateTagSection().GetSize() :
					0);

			internal static async ValueTask<Voter> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new Voter(version);
				instance.VoterId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (instance.IsFlexibleVersion)
				{
					var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
					await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
					{
						switch (tag.Tag)
						{
							default:
								throw new InvalidOperationException($"Tag '{tag.Tag}' for Voter is unknown");
						}
					}
				}

				return instance;
			}

			ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
			internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
			{
				await _voterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
			}

			private Int32 _voterId = Int32.Default;
			/// <summary>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Int32 VoterId 
			{
				get => _voterId;
				private set 
				{
					_voterId = value;
				}
			}

			/// <summary>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Voter WithVoterId(Int32 voterId)
			{
				VoterId = voterId;
				return this;
			}
		}
	}

	public class SnapshotFooterRecord
	{
		public SnapshotFooterRecord(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
				throw new UnsupportedVersionException($"SnapshotFooterRecord does not support version {version}. Valid versions are: 0");

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

		internal int GetSize() =>
			_version.GetSize(IsFlexibleVersion) +
			(IsFlexibleVersion ? 
				CreateTagSection().GetSize() :
				0);

		public static async ValueTask<SnapshotFooterRecord> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
		{
			var pipe = new Pipe();
			await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
			var reader = pipe.Reader;

			var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
			var instance = new SnapshotFooterRecord(version);
			instance.Version_ = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

			if (instance.IsFlexibleVersion)
			{
				var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
				await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
				{
					switch (tag.Tag)
					{
						default:
							throw new InvalidOperationException($"Tag '{tag.Tag}' for SnapshotFooterRecord is unknown");
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
				await _version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
				return new Bytes(writer.ToArray());
			}
		}

		private Int16 _version = Int16.Default;
		/// <summary>
		/// <para>The version of the snapshot footer record</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Int16 Version_ 
		{
			get => _version;
			private set 
			{
				_version = value;
			}
		}

		/// <summary>
		/// <para>The version of the snapshot footer record</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public SnapshotFooterRecord WithVersion_(Int16 version)
		{
			Version_ = version;
			return this;
		}
	}

	public class SnapshotHeaderRecord
	{
		public SnapshotHeaderRecord(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
				throw new UnsupportedVersionException($"SnapshotHeaderRecord does not support version {version}. Valid versions are: 0");

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

		internal int GetSize() =>
			_version.GetSize(IsFlexibleVersion) +
			_lastContainedLogTimestamp.GetSize(IsFlexibleVersion) +
			(IsFlexibleVersion ? 
				CreateTagSection().GetSize() :
				0);

		public static async ValueTask<SnapshotHeaderRecord> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
		{
			var pipe = new Pipe();
			await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
			var reader = pipe.Reader;

			var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
			var instance = new SnapshotHeaderRecord(version);
			instance.Version_ = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
			instance.LastContainedLogTimestamp = await Int64.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

			if (instance.IsFlexibleVersion)
			{
				var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
				await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
				{
					switch (tag.Tag)
					{
						default:
							throw new InvalidOperationException($"Tag '{tag.Tag}' for SnapshotHeaderRecord is unknown");
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
				await _version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _lastContainedLogTimestamp.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
				return new Bytes(writer.ToArray());
			}
		}

		private Int16 _version = Int16.Default;
		/// <summary>
		/// <para>The version of the snapshot header record</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Int16 Version_ 
		{
			get => _version;
			private set 
			{
				_version = value;
			}
		}

		/// <summary>
		/// <para>The version of the snapshot header record</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public SnapshotHeaderRecord WithVersion_(Int16 version)
		{
			Version_ = version;
			return this;
		}

		private Int64 _lastContainedLogTimestamp = Int64.Default;
		/// <summary>
		/// <para>The append time of the last record from the log contained in this snapshot</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Int64 LastContainedLogTimestamp 
		{
			get => _lastContainedLogTimestamp;
			private set 
			{
				_lastContainedLogTimestamp = value;
			}
		}

		/// <summary>
		/// <para>The append time of the last record from the log contained in this snapshot</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public SnapshotHeaderRecord WithLastContainedLogTimestamp(Int64 lastContainedLogTimestamp)
		{
			LastContainedLogTimestamp = lastContainedLogTimestamp;
			return this;
		}
	}

	public class VotersRecord
	{
		public VotersRecord(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
				throw new UnsupportedVersionException($"VotersRecord does not support version {version}. Valid versions are: 0");

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

		internal int GetSize() =>
			_version.GetSize(IsFlexibleVersion) +
			_votersCollection.GetSize(IsFlexibleVersion) +
			(IsFlexibleVersion ? 
				CreateTagSection().GetSize() :
				0);

		public static async ValueTask<VotersRecord> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default)
		{
			var pipe = new Pipe();
			await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
			var reader = pipe.Reader;

			var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
			var instance = new VotersRecord(version);
			instance.Version_ = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
			instance.VotersCollection = await Array<Voter>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Voter.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken).ConfigureAwait(false);

			if (instance.IsFlexibleVersion)
			{
				var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
				await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
				{
					switch (tag.Tag)
					{
						default:
							throw new InvalidOperationException($"Tag '{tag.Tag}' for VotersRecord is unknown");
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
				await _version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _votersCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
				return new Bytes(writer.ToArray());
			}
		}

		private Int16 _version = Int16.Default;
		/// <summary>
		/// <para>The version of the voters record</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Int16 Version_ 
		{
			get => _version;
			private set 
			{
				_version = value;
			}
		}

		/// <summary>
		/// <para>The version of the voters record</para>
		/// <para>Versions: 0+</para>
		/// </summary>
		public VotersRecord WithVersion_(Int16 version)
		{
			Version_ = version;
			return this;
		}

		private Array<Voter> _votersCollection = Array.Empty<Voter>();
		/// <summary>
		/// <para>Versions: 0+</para>
		/// </summary>
		public Array<Voter> VotersCollection 
		{
			get => _votersCollection;
			private set 
			{
				_votersCollection = value;
			}
		}

		/// <summary>
		/// <para>Versions: 0+</para>
		/// </summary>
		public VotersRecord WithVotersCollection(params Func<Voter, Voter>[] createFields)
		{
			VotersCollection = createFields
				.Select(createField => createField(new Voter(Version)))
				.ToArray();
			return this;
		}

		public delegate Voter CreateVoter(Voter field);

		/// <summary>
		/// <para>Versions: 0+</para>
		/// </summary>
		public VotersRecord WithVotersCollection(IEnumerable<CreateVoter> createFields)
		{
			VotersCollection = createFields
				.Select(createField => createField(new Voter(Version)))
				.ToArray();
			return this;
		}

		public class Voter : ISerialize
		{
			internal Voter(Int16 version)
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
			internal int GetSize(bool _) =>
				_voterId.GetSize(IsFlexibleVersion) +
				_voterDirectoryId.GetSize(IsFlexibleVersion) +
				_endpointsCollection.GetSize(IsFlexibleVersion) +
				_kRaftVersionFeature.GetSize(IsFlexibleVersion) +
				(IsFlexibleVersion ? 
					CreateTagSection().GetSize() :
					0);

			internal static async ValueTask<Voter> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new Voter(version);
				instance.VoterId = await Int32.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				instance.VoterDirectoryId = await Uuid.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				instance.EndpointsCollection = await Map<String, Endpoint>.FromReaderAsync(reader, instance.IsFlexibleVersion, () => Endpoint.FromReaderAsync(instance.Version, reader, cancellationToken), field => field.Name, cancellationToken).ConfigureAwait(false);
				instance.KRaftVersionFeature_ = await KRaftVersionFeature.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false);

				if (instance.IsFlexibleVersion)
				{
					var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
					await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
					{
						switch (tag.Tag)
						{
							default:
								throw new InvalidOperationException($"Tag '{tag.Tag}' for Voter is unknown");
						}
					}
				}

				return instance;
			}

			ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
			internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
			{
				await _voterId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _voterDirectoryId.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _endpointsCollection.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
				await _kRaftVersionFeature.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

				if (IsFlexibleVersion)
					await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
			}

			private Int32 _voterId = Int32.Default;
			/// <summary>
			/// <para>The replica id of the voter in the topic partition</para>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Int32 VoterId 
			{
				get => _voterId;
				private set 
				{
					_voterId = value;
				}
			}

			/// <summary>
			/// <para>The replica id of the voter in the topic partition</para>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Voter WithVoterId(Int32 voterId)
			{
				VoterId = voterId;
				return this;
			}

			private Uuid _voterDirectoryId = Uuid.Default;
			/// <summary>
			/// <para>The directory id of the voter in the topic partition</para>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Uuid VoterDirectoryId 
			{
				get => _voterDirectoryId;
				private set 
				{
					_voterDirectoryId = value;
				}
			}

			/// <summary>
			/// <para>The directory id of the voter in the topic partition</para>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Voter WithVoterDirectoryId(Uuid voterDirectoryId)
			{
				VoterDirectoryId = voterDirectoryId;
				return this;
			}

			private Map<String, Endpoint> _endpointsCollection = Map<String, Endpoint>.Default;
			/// <summary>
			/// <para>The endpoint that can be used to communicate with the voter</para>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Map<String, Endpoint> EndpointsCollection 
			{
				get => _endpointsCollection;
				private set 
				{
					_endpointsCollection = value;
				}
			}

			/// <summary>
			/// <para>The endpoint that can be used to communicate with the voter</para>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Voter WithEndpointsCollection(params Func<Endpoint, Endpoint>[] createFields)
			{
				EndpointsCollection = createFields
					.Select(createField => createField(new Endpoint(Version)))
					.ToDictionary(field => field.Name);
				return this;
			}

			public delegate Endpoint CreateEndpoint(Endpoint field);

			/// <summary>
			/// <para>The endpoint that can be used to communicate with the voter</para>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Voter WithEndpointsCollection(IEnumerable<CreateEndpoint> createFields)
			{
				EndpointsCollection = createFields
					.Select(createField => createField(new Endpoint(Version)))
					.ToDictionary(field => field.Name);
				return this;
			}

			public class Endpoint : ISerialize
			{
				internal Endpoint(Int16 version)
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
				internal int GetSize(bool _) =>
					_name.GetSize(IsFlexibleVersion) +
					_host.GetSize(IsFlexibleVersion) +
					_port.GetSize(IsFlexibleVersion) +
					(IsFlexibleVersion ? 
						CreateTagSection().GetSize() :
						0);

				internal static async ValueTask<Endpoint> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new Endpoint(version);
					instance.Name = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
					instance.Host = await String.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
					instance.Port = await UInt16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

					if (instance.IsFlexibleVersion)
					{
						var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
						await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
						{
							switch (tag.Tag)
							{
								default:
									throw new InvalidOperationException($"Tag '{tag.Tag}' for Endpoint is unknown");
							}
						}
					}

					return instance;
				}

				ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
				internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
				{
					await _name.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
					await _host.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
					await _port.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

					if (IsFlexibleVersion)
						await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
				}

				private String _name = String.Default;
				/// <summary>
				/// <para>The name of the endpoint</para>
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
				/// <para>The name of the endpoint</para>
				/// <para>Versions: 0+</para>
				/// </summary>
				public Endpoint WithName(String name)
				{
					Name = name;
					return this;
				}

				private String _host = String.Default;
				/// <summary>
				/// <para>The hostname</para>
				/// <para>Versions: 0+</para>
				/// </summary>
				public String Host 
				{
					get => _host;
					private set 
					{
						_host = value;
					}
				}

				/// <summary>
				/// <para>The hostname</para>
				/// <para>Versions: 0+</para>
				/// </summary>
				public Endpoint WithHost(String host)
				{
					Host = host;
					return this;
				}

				private UInt16 _port = UInt16.Default;
				/// <summary>
				/// <para>The port</para>
				/// <para>Versions: 0+</para>
				/// </summary>
				public UInt16 Port 
				{
					get => _port;
					private set 
					{
						_port = value;
					}
				}

				/// <summary>
				/// <para>The port</para>
				/// <para>Versions: 0+</para>
				/// </summary>
				public Endpoint WithPort(UInt16 port)
				{
					Port = port;
					return this;
				}
			}

			private KRaftVersionFeature _kRaftVersionFeature = default!;
			/// <summary>
			/// <para>The range of versions of the protocol that the replica supports</para>
			/// <para>Versions: 0+</para>
			/// </summary>
			public KRaftVersionFeature KRaftVersionFeature_ 
			{
				get => _kRaftVersionFeature;
				private set 
				{
					_kRaftVersionFeature = value;
				}
			}

			/// <summary>
			/// <para>The range of versions of the protocol that the replica supports</para>
			/// <para>Versions: 0+</para>
			/// </summary>
			public Voter WithKRaftVersionFeature_(Func<KRaftVersionFeature, KRaftVersionFeature> createField)
			{
				KRaftVersionFeature_ = createField(new KRaftVersionFeature(Version));
				return this;
			}

			public class KRaftVersionFeature : ISerialize
			{
				internal KRaftVersionFeature(Int16 version)
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
				internal int GetSize(bool _) =>
					_minSupportedVersion.GetSize(IsFlexibleVersion) +
					_maxSupportedVersion.GetSize(IsFlexibleVersion) +
					(IsFlexibleVersion ? 
						CreateTagSection().GetSize() :
						0);

				internal static async ValueTask<KRaftVersionFeature> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new KRaftVersionFeature(version);
					instance.MinSupportedVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
					instance.MaxSupportedVersion = await Int16.FromReaderAsync(reader, instance.IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

					if (instance.IsFlexibleVersion)
					{
						var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
						await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false))
						{
							switch (tag.Tag)
							{
								default:
									throw new InvalidOperationException($"Tag '{tag.Tag}' for KRaftVersionFeature is unknown");
							}
						}
					}

					return instance;
				}

				ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
				internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default)
				{
					await _minSupportedVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
					await _maxSupportedVersion.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);

					if (IsFlexibleVersion)
						await CreateTagSection().WriteToAsync(writer, cancellationToken).ConfigureAwait(false);
				}

				private Int16 _minSupportedVersion = Int16.Default;
				/// <summary>
				/// <para>The minimum supported KRaft protocol version</para>
				/// <para>Versions: 0+</para>
				/// </summary>
				public Int16 MinSupportedVersion 
				{
					get => _minSupportedVersion;
					private set 
					{
						_minSupportedVersion = value;
					}
				}

				/// <summary>
				/// <para>The minimum supported KRaft protocol version</para>
				/// <para>Versions: 0+</para>
				/// </summary>
				public KRaftVersionFeature WithMinSupportedVersion(Int16 minSupportedVersion)
				{
					MinSupportedVersion = minSupportedVersion;
					return this;
				}

				private Int16 _maxSupportedVersion = Int16.Default;
				/// <summary>
				/// <para>The maximum supported KRaft protocol version</para>
				/// <para>Versions: 0+</para>
				/// </summary>
				public Int16 MaxSupportedVersion 
				{
					get => _maxSupportedVersion;
					private set 
					{
						_maxSupportedVersion = value;
					}
				}

				/// <summary>
				/// <para>The maximum supported KRaft protocol version</para>
				/// <para>Versions: 0+</para>
				/// </summary>
				public KRaftVersionFeature WithMaxSupportedVersion(Int16 maxSupportedVersion)
				{
					MaxSupportedVersion = maxSupportedVersion;
					return this;
				}
			}
		}
	}

	public static class ResponseExtensions
	{
		public static ApiVersionsResponse WithAllApiKeys(this ApiVersionsResponse response)
		{
			return response.WithApiKeysCollection(
				key => key
					.WithApiKey(AddOffsetsToTxnRequest.ApiKey)
					.WithMinVersion(AddOffsetsToTxnRequest.MinVersion)
					.WithMaxVersion(AddOffsetsToTxnRequest.MaxVersion),
				key => key
					.WithApiKey(AddPartitionsToTxnRequest.ApiKey)
					.WithMinVersion(AddPartitionsToTxnRequest.MinVersion)
					.WithMaxVersion(AddPartitionsToTxnRequest.MaxVersion),
				key => key
					.WithApiKey(AddRaftVoterRequest.ApiKey)
					.WithMinVersion(AddRaftVoterRequest.MinVersion)
					.WithMaxVersion(AddRaftVoterRequest.MaxVersion),
				key => key
					.WithApiKey(AllocateProducerIdsRequest.ApiKey)
					.WithMinVersion(AllocateProducerIdsRequest.MinVersion)
					.WithMaxVersion(AllocateProducerIdsRequest.MaxVersion),
				key => key
					.WithApiKey(AlterClientQuotasRequest.ApiKey)
					.WithMinVersion(AlterClientQuotasRequest.MinVersion)
					.WithMaxVersion(AlterClientQuotasRequest.MaxVersion),
				key => key
					.WithApiKey(AlterConfigsRequest.ApiKey)
					.WithMinVersion(AlterConfigsRequest.MinVersion)
					.WithMaxVersion(AlterConfigsRequest.MaxVersion),
				key => key
					.WithApiKey(AlterPartitionReassignmentsRequest.ApiKey)
					.WithMinVersion(AlterPartitionReassignmentsRequest.MinVersion)
					.WithMaxVersion(AlterPartitionReassignmentsRequest.MaxVersion),
				key => key
					.WithApiKey(AlterPartitionRequest.ApiKey)
					.WithMinVersion(AlterPartitionRequest.MinVersion)
					.WithMaxVersion(AlterPartitionRequest.MaxVersion),
				key => key
					.WithApiKey(AlterReplicaLogDirsRequest.ApiKey)
					.WithMinVersion(AlterReplicaLogDirsRequest.MinVersion)
					.WithMaxVersion(AlterReplicaLogDirsRequest.MaxVersion),
				key => key
					.WithApiKey(AlterUserScramCredentialsRequest.ApiKey)
					.WithMinVersion(AlterUserScramCredentialsRequest.MinVersion)
					.WithMaxVersion(AlterUserScramCredentialsRequest.MaxVersion),
				key => key
					.WithApiKey(ApiVersionsRequest.ApiKey)
					.WithMinVersion(ApiVersionsRequest.MinVersion)
					.WithMaxVersion(ApiVersionsRequest.MaxVersion),
				key => key
					.WithApiKey(AssignReplicasToDirsRequest.ApiKey)
					.WithMinVersion(AssignReplicasToDirsRequest.MinVersion)
					.WithMaxVersion(AssignReplicasToDirsRequest.MaxVersion),
				key => key
					.WithApiKey(BeginQuorumEpochRequest.ApiKey)
					.WithMinVersion(BeginQuorumEpochRequest.MinVersion)
					.WithMaxVersion(BeginQuorumEpochRequest.MaxVersion),
				key => key
					.WithApiKey(BrokerHeartbeatRequest.ApiKey)
					.WithMinVersion(BrokerHeartbeatRequest.MinVersion)
					.WithMaxVersion(BrokerHeartbeatRequest.MaxVersion),
				key => key
					.WithApiKey(BrokerRegistrationRequest.ApiKey)
					.WithMinVersion(BrokerRegistrationRequest.MinVersion)
					.WithMaxVersion(BrokerRegistrationRequest.MaxVersion),
				key => key
					.WithApiKey(ConsumerGroupDescribeRequest.ApiKey)
					.WithMinVersion(ConsumerGroupDescribeRequest.MinVersion)
					.WithMaxVersion(ConsumerGroupDescribeRequest.MaxVersion),
				key => key
					.WithApiKey(ConsumerGroupHeartbeatRequest.ApiKey)
					.WithMinVersion(ConsumerGroupHeartbeatRequest.MinVersion)
					.WithMaxVersion(ConsumerGroupHeartbeatRequest.MaxVersion),
				key => key
					.WithApiKey(ControlledShutdownRequest.ApiKey)
					.WithMinVersion(ControlledShutdownRequest.MinVersion)
					.WithMaxVersion(ControlledShutdownRequest.MaxVersion),
				key => key
					.WithApiKey(ControllerRegistrationRequest.ApiKey)
					.WithMinVersion(ControllerRegistrationRequest.MinVersion)
					.WithMaxVersion(ControllerRegistrationRequest.MaxVersion),
				key => key
					.WithApiKey(CreateAclsRequest.ApiKey)
					.WithMinVersion(CreateAclsRequest.MinVersion)
					.WithMaxVersion(CreateAclsRequest.MaxVersion),
				key => key
					.WithApiKey(CreateDelegationTokenRequest.ApiKey)
					.WithMinVersion(CreateDelegationTokenRequest.MinVersion)
					.WithMaxVersion(CreateDelegationTokenRequest.MaxVersion),
				key => key
					.WithApiKey(CreatePartitionsRequest.ApiKey)
					.WithMinVersion(CreatePartitionsRequest.MinVersion)
					.WithMaxVersion(CreatePartitionsRequest.MaxVersion),
				key => key
					.WithApiKey(CreateTopicsRequest.ApiKey)
					.WithMinVersion(CreateTopicsRequest.MinVersion)
					.WithMaxVersion(CreateTopicsRequest.MaxVersion),
				key => key
					.WithApiKey(DeleteAclsRequest.ApiKey)
					.WithMinVersion(DeleteAclsRequest.MinVersion)
					.WithMaxVersion(DeleteAclsRequest.MaxVersion),
				key => key
					.WithApiKey(DeleteGroupsRequest.ApiKey)
					.WithMinVersion(DeleteGroupsRequest.MinVersion)
					.WithMaxVersion(DeleteGroupsRequest.MaxVersion),
				key => key
					.WithApiKey(DeleteRecordsRequest.ApiKey)
					.WithMinVersion(DeleteRecordsRequest.MinVersion)
					.WithMaxVersion(DeleteRecordsRequest.MaxVersion),
				key => key
					.WithApiKey(DeleteShareGroupStateRequest.ApiKey)
					.WithMinVersion(DeleteShareGroupStateRequest.MinVersion)
					.WithMaxVersion(DeleteShareGroupStateRequest.MaxVersion),
				key => key
					.WithApiKey(DeleteTopicsRequest.ApiKey)
					.WithMinVersion(DeleteTopicsRequest.MinVersion)
					.WithMaxVersion(DeleteTopicsRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeAclsRequest.ApiKey)
					.WithMinVersion(DescribeAclsRequest.MinVersion)
					.WithMaxVersion(DescribeAclsRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeClientQuotasRequest.ApiKey)
					.WithMinVersion(DescribeClientQuotasRequest.MinVersion)
					.WithMaxVersion(DescribeClientQuotasRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeClusterRequest.ApiKey)
					.WithMinVersion(DescribeClusterRequest.MinVersion)
					.WithMaxVersion(DescribeClusterRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeConfigsRequest.ApiKey)
					.WithMinVersion(DescribeConfigsRequest.MinVersion)
					.WithMaxVersion(DescribeConfigsRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeDelegationTokenRequest.ApiKey)
					.WithMinVersion(DescribeDelegationTokenRequest.MinVersion)
					.WithMaxVersion(DescribeDelegationTokenRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeGroupsRequest.ApiKey)
					.WithMinVersion(DescribeGroupsRequest.MinVersion)
					.WithMaxVersion(DescribeGroupsRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeLogDirsRequest.ApiKey)
					.WithMinVersion(DescribeLogDirsRequest.MinVersion)
					.WithMaxVersion(DescribeLogDirsRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeProducersRequest.ApiKey)
					.WithMinVersion(DescribeProducersRequest.MinVersion)
					.WithMaxVersion(DescribeProducersRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeQuorumRequest.ApiKey)
					.WithMinVersion(DescribeQuorumRequest.MinVersion)
					.WithMaxVersion(DescribeQuorumRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeTopicPartitionsRequest.ApiKey)
					.WithMinVersion(DescribeTopicPartitionsRequest.MinVersion)
					.WithMaxVersion(DescribeTopicPartitionsRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeTransactionsRequest.ApiKey)
					.WithMinVersion(DescribeTransactionsRequest.MinVersion)
					.WithMaxVersion(DescribeTransactionsRequest.MaxVersion),
				key => key
					.WithApiKey(DescribeUserScramCredentialsRequest.ApiKey)
					.WithMinVersion(DescribeUserScramCredentialsRequest.MinVersion)
					.WithMaxVersion(DescribeUserScramCredentialsRequest.MaxVersion),
				key => key
					.WithApiKey(ElectLeadersRequest.ApiKey)
					.WithMinVersion(ElectLeadersRequest.MinVersion)
					.WithMaxVersion(ElectLeadersRequest.MaxVersion),
				key => key
					.WithApiKey(EndQuorumEpochRequest.ApiKey)
					.WithMinVersion(EndQuorumEpochRequest.MinVersion)
					.WithMaxVersion(EndQuorumEpochRequest.MaxVersion),
				key => key
					.WithApiKey(EndTxnRequest.ApiKey)
					.WithMinVersion(EndTxnRequest.MinVersion)
					.WithMaxVersion(EndTxnRequest.MaxVersion),
				key => key
					.WithApiKey(EnvelopeRequest.ApiKey)
					.WithMinVersion(EnvelopeRequest.MinVersion)
					.WithMaxVersion(EnvelopeRequest.MaxVersion),
				key => key
					.WithApiKey(ExpireDelegationTokenRequest.ApiKey)
					.WithMinVersion(ExpireDelegationTokenRequest.MinVersion)
					.WithMaxVersion(ExpireDelegationTokenRequest.MaxVersion),
				key => key
					.WithApiKey(FetchRequest.ApiKey)
					.WithMinVersion(FetchRequest.MinVersion)
					.WithMaxVersion(FetchRequest.MaxVersion),
				key => key
					.WithApiKey(FetchSnapshotRequest.ApiKey)
					.WithMinVersion(FetchSnapshotRequest.MinVersion)
					.WithMaxVersion(FetchSnapshotRequest.MaxVersion),
				key => key
					.WithApiKey(FindCoordinatorRequest.ApiKey)
					.WithMinVersion(FindCoordinatorRequest.MinVersion)
					.WithMaxVersion(FindCoordinatorRequest.MaxVersion),
				key => key
					.WithApiKey(GetTelemetrySubscriptionsRequest.ApiKey)
					.WithMinVersion(GetTelemetrySubscriptionsRequest.MinVersion)
					.WithMaxVersion(GetTelemetrySubscriptionsRequest.MaxVersion),
				key => key
					.WithApiKey(HeartbeatRequest.ApiKey)
					.WithMinVersion(HeartbeatRequest.MinVersion)
					.WithMaxVersion(HeartbeatRequest.MaxVersion),
				key => key
					.WithApiKey(IncrementalAlterConfigsRequest.ApiKey)
					.WithMinVersion(IncrementalAlterConfigsRequest.MinVersion)
					.WithMaxVersion(IncrementalAlterConfigsRequest.MaxVersion),
				key => key
					.WithApiKey(InitializeShareGroupStateRequest.ApiKey)
					.WithMinVersion(InitializeShareGroupStateRequest.MinVersion)
					.WithMaxVersion(InitializeShareGroupStateRequest.MaxVersion),
				key => key
					.WithApiKey(InitProducerIdRequest.ApiKey)
					.WithMinVersion(InitProducerIdRequest.MinVersion)
					.WithMaxVersion(InitProducerIdRequest.MaxVersion),
				key => key
					.WithApiKey(JoinGroupRequest.ApiKey)
					.WithMinVersion(JoinGroupRequest.MinVersion)
					.WithMaxVersion(JoinGroupRequest.MaxVersion),
				key => key
					.WithApiKey(LeaderAndIsrRequest.ApiKey)
					.WithMinVersion(LeaderAndIsrRequest.MinVersion)
					.WithMaxVersion(LeaderAndIsrRequest.MaxVersion),
				key => key
					.WithApiKey(LeaveGroupRequest.ApiKey)
					.WithMinVersion(LeaveGroupRequest.MinVersion)
					.WithMaxVersion(LeaveGroupRequest.MaxVersion),
				key => key
					.WithApiKey(ListClientMetricsResourcesRequest.ApiKey)
					.WithMinVersion(ListClientMetricsResourcesRequest.MinVersion)
					.WithMaxVersion(ListClientMetricsResourcesRequest.MaxVersion),
				key => key
					.WithApiKey(ListGroupsRequest.ApiKey)
					.WithMinVersion(ListGroupsRequest.MinVersion)
					.WithMaxVersion(ListGroupsRequest.MaxVersion),
				key => key
					.WithApiKey(ListOffsetsRequest.ApiKey)
					.WithMinVersion(ListOffsetsRequest.MinVersion)
					.WithMaxVersion(ListOffsetsRequest.MaxVersion),
				key => key
					.WithApiKey(ListPartitionReassignmentsRequest.ApiKey)
					.WithMinVersion(ListPartitionReassignmentsRequest.MinVersion)
					.WithMaxVersion(ListPartitionReassignmentsRequest.MaxVersion),
				key => key
					.WithApiKey(ListTransactionsRequest.ApiKey)
					.WithMinVersion(ListTransactionsRequest.MinVersion)
					.WithMaxVersion(ListTransactionsRequest.MaxVersion),
				key => key
					.WithApiKey(MetadataRequest.ApiKey)
					.WithMinVersion(MetadataRequest.MinVersion)
					.WithMaxVersion(MetadataRequest.MaxVersion),
				key => key
					.WithApiKey(OffsetCommitRequest.ApiKey)
					.WithMinVersion(OffsetCommitRequest.MinVersion)
					.WithMaxVersion(OffsetCommitRequest.MaxVersion),
				key => key
					.WithApiKey(OffsetDeleteRequest.ApiKey)
					.WithMinVersion(OffsetDeleteRequest.MinVersion)
					.WithMaxVersion(OffsetDeleteRequest.MaxVersion),
				key => key
					.WithApiKey(OffsetFetchRequest.ApiKey)
					.WithMinVersion(OffsetFetchRequest.MinVersion)
					.WithMaxVersion(OffsetFetchRequest.MaxVersion),
				key => key
					.WithApiKey(OffsetForLeaderEpochRequest.ApiKey)
					.WithMinVersion(OffsetForLeaderEpochRequest.MinVersion)
					.WithMaxVersion(OffsetForLeaderEpochRequest.MaxVersion),
				key => key
					.WithApiKey(ProduceRequest.ApiKey)
					.WithMinVersion(ProduceRequest.MinVersion)
					.WithMaxVersion(ProduceRequest.MaxVersion),
				key => key
					.WithApiKey(PushTelemetryRequest.ApiKey)
					.WithMinVersion(PushTelemetryRequest.MinVersion)
					.WithMaxVersion(PushTelemetryRequest.MaxVersion),
				key => key
					.WithApiKey(ReadShareGroupStateRequest.ApiKey)
					.WithMinVersion(ReadShareGroupStateRequest.MinVersion)
					.WithMaxVersion(ReadShareGroupStateRequest.MaxVersion),
				key => key
					.WithApiKey(ReadShareGroupStateSummaryRequest.ApiKey)
					.WithMinVersion(ReadShareGroupStateSummaryRequest.MinVersion)
					.WithMaxVersion(ReadShareGroupStateSummaryRequest.MaxVersion),
				key => key
					.WithApiKey(RemoveRaftVoterRequest.ApiKey)
					.WithMinVersion(RemoveRaftVoterRequest.MinVersion)
					.WithMaxVersion(RemoveRaftVoterRequest.MaxVersion),
				key => key
					.WithApiKey(RenewDelegationTokenRequest.ApiKey)
					.WithMinVersion(RenewDelegationTokenRequest.MinVersion)
					.WithMaxVersion(RenewDelegationTokenRequest.MaxVersion),
				key => key
					.WithApiKey(SaslAuthenticateRequest.ApiKey)
					.WithMinVersion(SaslAuthenticateRequest.MinVersion)
					.WithMaxVersion(SaslAuthenticateRequest.MaxVersion),
				key => key
					.WithApiKey(SaslHandshakeRequest.ApiKey)
					.WithMinVersion(SaslHandshakeRequest.MinVersion)
					.WithMaxVersion(SaslHandshakeRequest.MaxVersion),
				key => key
					.WithApiKey(ShareAcknowledgeRequest.ApiKey)
					.WithMinVersion(ShareAcknowledgeRequest.MinVersion)
					.WithMaxVersion(ShareAcknowledgeRequest.MaxVersion),
				key => key
					.WithApiKey(ShareFetchRequest.ApiKey)
					.WithMinVersion(ShareFetchRequest.MinVersion)
					.WithMaxVersion(ShareFetchRequest.MaxVersion),
				key => key
					.WithApiKey(ShareGroupDescribeRequest.ApiKey)
					.WithMinVersion(ShareGroupDescribeRequest.MinVersion)
					.WithMaxVersion(ShareGroupDescribeRequest.MaxVersion),
				key => key
					.WithApiKey(ShareGroupHeartbeatRequest.ApiKey)
					.WithMinVersion(ShareGroupHeartbeatRequest.MinVersion)
					.WithMaxVersion(ShareGroupHeartbeatRequest.MaxVersion),
				key => key
					.WithApiKey(StopReplicaRequest.ApiKey)
					.WithMinVersion(StopReplicaRequest.MinVersion)
					.WithMaxVersion(StopReplicaRequest.MaxVersion),
				key => key
					.WithApiKey(SyncGroupRequest.ApiKey)
					.WithMinVersion(SyncGroupRequest.MinVersion)
					.WithMaxVersion(SyncGroupRequest.MaxVersion),
				key => key
					.WithApiKey(TxnOffsetCommitRequest.ApiKey)
					.WithMinVersion(TxnOffsetCommitRequest.MinVersion)
					.WithMaxVersion(TxnOffsetCommitRequest.MaxVersion),
				key => key
					.WithApiKey(UnregisterBrokerRequest.ApiKey)
					.WithMinVersion(UnregisterBrokerRequest.MinVersion)
					.WithMaxVersion(UnregisterBrokerRequest.MaxVersion),
				key => key
					.WithApiKey(UpdateFeaturesRequest.ApiKey)
					.WithMinVersion(UpdateFeaturesRequest.MinVersion)
					.WithMaxVersion(UpdateFeaturesRequest.MaxVersion),
				key => key
					.WithApiKey(UpdateMetadataRequest.ApiKey)
					.WithMinVersion(UpdateMetadataRequest.MinVersion)
					.WithMaxVersion(UpdateMetadataRequest.MaxVersion),
				key => key
					.WithApiKey(UpdateRaftVoterRequest.ApiKey)
					.WithMinVersion(UpdateRaftVoterRequest.MinVersion)
					.WithMaxVersion(UpdateRaftVoterRequest.MaxVersion),
				key => key
					.WithApiKey(VoteRequest.ApiKey)
					.WithMinVersion(VoteRequest.MinVersion)
					.WithMaxVersion(VoteRequest.MaxVersion),
				key => key
					.WithApiKey(WriteShareGroupStateRequest.ApiKey)
					.WithMinVersion(WriteShareGroupStateRequest.MinVersion)
					.WithMaxVersion(WriteShareGroupStateRequest.MaxVersion),
				key => key
					.WithApiKey(WriteTxnMarkersRequest.ApiKey)
					.WithMinVersion(WriteTxnMarkersRequest.MinVersion)
					.WithMaxVersion(WriteTxnMarkersRequest.MaxVersion));
		}
	}
}