// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable MemberHidesStaticFromOuterClass FromReaderAsync will cause a lot of these warnings

namespace Kafka.Protocol
{
	/// <summary>
	/// Represents a boolean value in a byte. Values 0 and 1 are used to represent false and true respectively. When reading a boolean value, any non-zero value is considered true.
	/// </summary>
	public readonly struct Boolean : ISerialize 
	{
		public bool Value { get; }

		public Boolean(bool value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Boolean comparingBoolean && this == comparingBoolean;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Boolean x, Boolean y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Boolean x, Boolean y)
		{
			return !(x == y);
		}

		public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteBooleanAsync(this, cancellationToken).ConfigureAwait(false);
		}

		public static Boolean From(bool value)
		{
			return new Boolean(value);
		}

		public static async ValueTask<Boolean> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
		}

		public static Boolean Default => From(default);
	}

	/// <summary>
	/// Represents an integer between -2^7 and 2^7-1 inclusive.
	/// </summary>
	public readonly struct Int8 : ISerialize 
	{
		public sbyte Value { get; }

		public Int8(sbyte value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Int8 comparingInt8 && this == comparingInt8;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Int8 x, Int8 y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Int8 x, Int8 y)
		{
			return !(x == y);
		}

		public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteInt8Async(this, cancellationToken).ConfigureAwait(false);
		}

		public static Int8 From(sbyte value)
		{
			return new Int8(value);
		}

		public static async ValueTask<Int8> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
		}

		public static Int8 Default => From(default);
	}

	/// <summary>
	/// Represents an integer between -2^15 and 2^15-1 inclusive. The values are encoded using two bytes in network byte order (big-endian).
	/// </summary>
	public readonly struct Int16 : ISerialize 
	{
		public short Value { get; }

		public Int16(short value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Int16 comparingInt16 && this == comparingInt16;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Int16 x, Int16 y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Int16 x, Int16 y)
		{
			return !(x == y);
		}

		public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteInt16Async(this, cancellationToken).ConfigureAwait(false);
		}

		public static Int16 From(short value)
		{
			return new Int16(value);
		}

		public static async ValueTask<Int16> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
		}

		public static Int16 Default => From(default);
	}

	/// <summary>
	/// Represents an integer between -2^31 and 2^31-1 inclusive. The values are encoded using four bytes in network byte order (big-endian).
	/// </summary>
	public readonly struct Int32 : ISerialize 
	{
		public int Value { get; }

		public Int32(int value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Int32 comparingInt32 && this == comparingInt32;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Int32 x, Int32 y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Int32 x, Int32 y)
		{
			return !(x == y);
		}

		public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteInt32Async(this, cancellationToken).ConfigureAwait(false);
		}

		public static Int32 From(int value)
		{
			return new Int32(value);
		}

		public static async ValueTask<Int32> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
		}

		public static Int32 Default => From(default);
	}

	/// <summary>
	/// Represents an integer between -2^63 and 2^63-1 inclusive. The values are encoded using eight bytes in network byte order (big-endian).
	/// </summary>
	public readonly struct Int64 : ISerialize 
	{
		public long Value { get; }

		public Int64(long value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Int64 comparingInt64 && this == comparingInt64;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Int64 x, Int64 y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Int64 x, Int64 y)
		{
			return !(x == y);
		}

		public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteInt64Async(this, cancellationToken).ConfigureAwait(false);
		}

		public static Int64 From(long value)
		{
			return new Int64(value);
		}

		public static async ValueTask<Int64> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
		}

		public static Int64 Default => From(default);
	}

	/// <summary>
	/// Represents an integer between 0 and 2^32-1 inclusive. The values are encoded using four bytes in network byte order (big-endian).
	/// </summary>
	public readonly struct UInt32 : ISerialize 
	{
		public uint Value { get; }

		public UInt32(uint value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is UInt32 comparingUInt32 && this == comparingUInt32;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (UInt32 x, UInt32 y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (UInt32 x, UInt32 y)
		{
			return !(x == y);
		}

		public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteUInt32Async(this, cancellationToken).ConfigureAwait(false);
		}

		public static UInt32 From(uint value)
		{
			return new UInt32(value);
		}

		public static async ValueTask<UInt32> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadUInt32Async(cancellationToken).ConfigureAwait(false);
		}

		public static UInt32 Default => From(default);
	}

	/// <summary>
	/// Represents an integer between -2^31 and 2^31-1 inclusive. Encoding follows the variable-length zig-zag encoding from  <a href="http://code.google.com/apis/protocolbuffers/docs/encoding.html"> Google Protocol Buffers</a>.
	/// </summary>
	public readonly struct VarInt : ISerialize 
	{
		public int Value { get; }

		public VarInt(int value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is VarInt comparingVarInt && this == comparingVarInt;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (VarInt x, VarInt y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (VarInt x, VarInt y)
		{
			return !(x == y);
		}

		public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteVarIntAsync(this, cancellationToken).ConfigureAwait(false);
		}

		public static VarInt From(int value)
		{
			return new VarInt(value);
		}

		public static async ValueTask<VarInt> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadVarIntAsync(cancellationToken).ConfigureAwait(false);
		}

		public static VarInt Default => From(default);
	}

	/// <summary>
	/// Represents an integer between -2^63 and 2^63-1 inclusive. Encoding follows the variable-length zig-zag encoding from  <a href="http://code.google.com/apis/protocolbuffers/docs/encoding.html"> Google Protocol Buffers</a>.
	/// </summary>
	public readonly struct VarLong : ISerialize 
	{
		public long Value { get; }

		public VarLong(long value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is VarLong comparingVarLong && this == comparingVarLong;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (VarLong x, VarLong y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (VarLong x, VarLong y)
		{
			return !(x == y);
		}

		public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteVarLongAsync(this, cancellationToken).ConfigureAwait(false);
		}

		public static VarLong From(long value)
		{
			return new VarLong(value);
		}

		public static async ValueTask<VarLong> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadVarLongAsync(cancellationToken).ConfigureAwait(false);
		}

		public static VarLong Default => From(default);
	}

	/// <summary>
	/// Represents a sequence of characters. First the length N is given as an INT16. Then N bytes follow which are the UTF-8 encoding of the character sequence. Length must not be negative.
	/// </summary>
	public readonly struct String : ISerialize 
	{
		public string Value { get; }

		public String(string value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is String comparingString && this == comparingString;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (String x, String y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (String x, String y)
		{
			return !(x == y);
		}

		public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteStringAsync(this, cancellationToken).ConfigureAwait(false);
		}

		public static String From(string value)
		{
			return new String(value);
		}

		public static async ValueTask<String> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
		}

		public static String Default => From(string.Empty);
	}

	/// <summary>
	/// Represents a raw sequence of bytes. First the length N is given as an INT32. Then N bytes follow.
	/// </summary>
	public readonly struct Bytes : ISerialize 
	{
		public byte[] Value { get; }

		public Bytes(byte[] value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Bytes comparingBytes && this == comparingBytes;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Bytes x, Bytes y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Bytes x, Bytes y)
		{
			return !(x == y);
		}

		public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteBytesAsync(this, cancellationToken).ConfigureAwait(false);
		}

		public static Bytes From(byte[] value)
		{
			return new Bytes(value);
		}

		public static async ValueTask<Bytes> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
		}

		public static Bytes Default => From(new byte[0]);
	}
	/// <summary>
	/// The server experienced an unexpected error when processing the request.
	/// </summary>
	public class UnknownServerErrorException : Exception
	{
		public UnknownServerErrorException()
		{

		}

		public UnknownServerErrorException(string message) : base(message)
		{

		}

		public int Code { get; } = -1;
	}

	public class NoneException : Exception
	{
		public NoneException()
		{

		}

		public NoneException(string message) : base(message)
		{

		}

		public int Code { get; } = 0;
	}

	/// <summary>
	/// The requested offset is not within the range of offsets maintained by the server.
	/// </summary>
	public class OffsetOutOfRangeException : Exception
	{
		public OffsetOutOfRangeException()
		{

		}

		public OffsetOutOfRangeException(string message) : base(message)
		{

		}

		public int Code { get; } = 1;
	}

	/// <summary>
	/// This message has failed its CRC checksum, exceeds the valid size, has a null key for a compacted topic, or is otherwise corrupt.
	/// </summary>
	public class CorruptMessageException : Exception
	{
		public CorruptMessageException()
		{

		}

		public CorruptMessageException(string message) : base(message)
		{

		}

		public int Code { get; } = 2;
	}

	/// <summary>
	/// This server does not host this topic-partition.
	/// </summary>
	public class UnknownTopicOrPartitionException : Exception
	{
		public UnknownTopicOrPartitionException()
		{

		}

		public UnknownTopicOrPartitionException(string message) : base(message)
		{

		}

		public int Code { get; } = 3;
	}

	/// <summary>
	/// The requested fetch size is invalid.
	/// </summary>
	public class InvalidFetchSizeException : Exception
	{
		public InvalidFetchSizeException()
		{

		}

		public InvalidFetchSizeException(string message) : base(message)
		{

		}

		public int Code { get; } = 4;
	}

	/// <summary>
	/// There is no leader for this topic-partition as we are in the middle of a leadership election.
	/// </summary>
	public class LeaderNotAvailableException : Exception
	{
		public LeaderNotAvailableException()
		{

		}

		public LeaderNotAvailableException(string message) : base(message)
		{

		}

		public int Code { get; } = 5;
	}

	/// <summary>
	/// This server is not the leader for that topic-partition.
	/// </summary>
	public class NotLeaderForPartitionException : Exception
	{
		public NotLeaderForPartitionException()
		{

		}

		public NotLeaderForPartitionException(string message) : base(message)
		{

		}

		public int Code { get; } = 6;
	}

	/// <summary>
	/// The request timed out.
	/// </summary>
	public class RequestTimedOutException : Exception
	{
		public RequestTimedOutException()
		{

		}

		public RequestTimedOutException(string message) : base(message)
		{

		}

		public int Code { get; } = 7;
	}

	/// <summary>
	/// The broker is not available.
	/// </summary>
	public class BrokerNotAvailableException : Exception
	{
		public BrokerNotAvailableException()
		{

		}

		public BrokerNotAvailableException(string message) : base(message)
		{

		}

		public int Code { get; } = 8;
	}

	/// <summary>
	/// The replica is not available for the requested topic-partition.
	/// </summary>
	public class ReplicaNotAvailableException : Exception
	{
		public ReplicaNotAvailableException()
		{

		}

		public ReplicaNotAvailableException(string message) : base(message)
		{

		}

		public int Code { get; } = 9;
	}

	/// <summary>
	/// The request included a message larger than the max message size the server will accept.
	/// </summary>
	public class MessageTooLargeException : Exception
	{
		public MessageTooLargeException()
		{

		}

		public MessageTooLargeException(string message) : base(message)
		{

		}

		public int Code { get; } = 10;
	}

	/// <summary>
	/// The controller moved to another broker.
	/// </summary>
	public class StaleControllerEpochException : Exception
	{
		public StaleControllerEpochException()
		{

		}

		public StaleControllerEpochException(string message) : base(message)
		{

		}

		public int Code { get; } = 11;
	}

	/// <summary>
	/// The metadata field of the offset request was too large.
	/// </summary>
	public class OffsetMetadataTooLargeException : Exception
	{
		public OffsetMetadataTooLargeException()
		{

		}

		public OffsetMetadataTooLargeException(string message) : base(message)
		{

		}

		public int Code { get; } = 12;
	}

	/// <summary>
	/// The server disconnected before a response was received.
	/// </summary>
	public class NetworkExceptionException : Exception
	{
		public NetworkExceptionException()
		{

		}

		public NetworkExceptionException(string message) : base(message)
		{

		}

		public int Code { get; } = 13;
	}

	/// <summary>
	/// The coordinator is loading and hence can't process requests.
	/// </summary>
	public class CoordinatorLoadInProgressException : Exception
	{
		public CoordinatorLoadInProgressException()
		{

		}

		public CoordinatorLoadInProgressException(string message) : base(message)
		{

		}

		public int Code { get; } = 14;
	}

	/// <summary>
	/// The coordinator is not available.
	/// </summary>
	public class CoordinatorNotAvailableException : Exception
	{
		public CoordinatorNotAvailableException()
		{

		}

		public CoordinatorNotAvailableException(string message) : base(message)
		{

		}

		public int Code { get; } = 15;
	}

	/// <summary>
	/// This is not the correct coordinator.
	/// </summary>
	public class NotCoordinatorException : Exception
	{
		public NotCoordinatorException()
		{

		}

		public NotCoordinatorException(string message) : base(message)
		{

		}

		public int Code { get; } = 16;
	}

	/// <summary>
	/// The request attempted to perform an operation on an invalid topic.
	/// </summary>
	public class InvalidTopicExceptionException : Exception
	{
		public InvalidTopicExceptionException()
		{

		}

		public InvalidTopicExceptionException(string message) : base(message)
		{

		}

		public int Code { get; } = 17;
	}

	/// <summary>
	/// The request included message batch larger than the configured segment size on the server.
	/// </summary>
	public class RecordListTooLargeException : Exception
	{
		public RecordListTooLargeException()
		{

		}

		public RecordListTooLargeException(string message) : base(message)
		{

		}

		public int Code { get; } = 18;
	}

	/// <summary>
	/// Messages are rejected since there are fewer in-sync replicas than required.
	/// </summary>
	public class NotEnoughReplicasException : Exception
	{
		public NotEnoughReplicasException()
		{

		}

		public NotEnoughReplicasException(string message) : base(message)
		{

		}

		public int Code { get; } = 19;
	}

	/// <summary>
	/// Messages are written to the log, but to fewer in-sync replicas than required.
	/// </summary>
	public class NotEnoughReplicasAfterAppendException : Exception
	{
		public NotEnoughReplicasAfterAppendException()
		{

		}

		public NotEnoughReplicasAfterAppendException(string message) : base(message)
		{

		}

		public int Code { get; } = 20;
	}

	/// <summary>
	/// Produce request specified an invalid value for required acks.
	/// </summary>
	public class InvalidRequiredAcksException : Exception
	{
		public InvalidRequiredAcksException()
		{

		}

		public InvalidRequiredAcksException(string message) : base(message)
		{

		}

		public int Code { get; } = 21;
	}

	/// <summary>
	/// Specified group generation id is not valid.
	/// </summary>
	public class IllegalGenerationException : Exception
	{
		public IllegalGenerationException()
		{

		}

		public IllegalGenerationException(string message) : base(message)
		{

		}

		public int Code { get; } = 22;
	}

	/// <summary>
	/// The group member's supported protocols are incompatible with those of existing members or first group member tried to join with empty protocol type or empty protocol list.
	/// </summary>
	public class InconsistentGroupProtocolException : Exception
	{
		public InconsistentGroupProtocolException()
		{

		}

		public InconsistentGroupProtocolException(string message) : base(message)
		{

		}

		public int Code { get; } = 23;
	}

	/// <summary>
	/// The configured groupId is invalid.
	/// </summary>
	public class InvalidGroupIdException : Exception
	{
		public InvalidGroupIdException()
		{

		}

		public InvalidGroupIdException(string message) : base(message)
		{

		}

		public int Code { get; } = 24;
	}

	/// <summary>
	/// The coordinator is not aware of this member.
	/// </summary>
	public class UnknownMemberIdException : Exception
	{
		public UnknownMemberIdException()
		{

		}

		public UnknownMemberIdException(string message) : base(message)
		{

		}

		public int Code { get; } = 25;
	}

	/// <summary>
	/// The session timeout is not within the range allowed by the broker (as configured by group.min.session.timeout.ms and group.max.session.timeout.ms).
	/// </summary>
	public class InvalidSessionTimeoutException : Exception
	{
		public InvalidSessionTimeoutException()
		{

		}

		public InvalidSessionTimeoutException(string message) : base(message)
		{

		}

		public int Code { get; } = 26;
	}

	/// <summary>
	/// The group is rebalancing, so a rejoin is needed.
	/// </summary>
	public class RebalanceInProgressException : Exception
	{
		public RebalanceInProgressException()
		{

		}

		public RebalanceInProgressException(string message) : base(message)
		{

		}

		public int Code { get; } = 27;
	}

	/// <summary>
	/// The committing offset data size is not valid.
	/// </summary>
	public class InvalidCommitOffsetSizeException : Exception
	{
		public InvalidCommitOffsetSizeException()
		{

		}

		public InvalidCommitOffsetSizeException(string message) : base(message)
		{

		}

		public int Code { get; } = 28;
	}

	/// <summary>
	/// Not authorized to access topics: [Topic authorization failed.]
	/// </summary>
	public class TopicAuthorizationFailedException : Exception
	{
		public TopicAuthorizationFailedException()
		{

		}

		public TopicAuthorizationFailedException(string message) : base(message)
		{

		}

		public int Code { get; } = 29;
	}

	/// <summary>
	/// Not authorized to access group: Group authorization failed.
	/// </summary>
	public class GroupAuthorizationFailedException : Exception
	{
		public GroupAuthorizationFailedException()
		{

		}

		public GroupAuthorizationFailedException(string message) : base(message)
		{

		}

		public int Code { get; } = 30;
	}

	/// <summary>
	/// Cluster authorization failed.
	/// </summary>
	public class ClusterAuthorizationFailedException : Exception
	{
		public ClusterAuthorizationFailedException()
		{

		}

		public ClusterAuthorizationFailedException(string message) : base(message)
		{

		}

		public int Code { get; } = 31;
	}

	/// <summary>
	/// The timestamp of the message is out of acceptable range.
	/// </summary>
	public class InvalidTimestampException : Exception
	{
		public InvalidTimestampException()
		{

		}

		public InvalidTimestampException(string message) : base(message)
		{

		}

		public int Code { get; } = 32;
	}

	/// <summary>
	/// The broker does not support the requested SASL mechanism.
	/// </summary>
	public class UnsupportedSaslMechanismException : Exception
	{
		public UnsupportedSaslMechanismException()
		{

		}

		public UnsupportedSaslMechanismException(string message) : base(message)
		{

		}

		public int Code { get; } = 33;
	}

	/// <summary>
	/// Request is not valid given the current SASL state.
	/// </summary>
	public class IllegalSaslStateException : Exception
	{
		public IllegalSaslStateException()
		{

		}

		public IllegalSaslStateException(string message) : base(message)
		{

		}

		public int Code { get; } = 34;
	}

	/// <summary>
	/// The version of API is not supported.
	/// </summary>
	public class UnsupportedVersionException : Exception
	{
		public UnsupportedVersionException()
		{

		}

		public UnsupportedVersionException(string message) : base(message)
		{

		}

		public int Code { get; } = 35;
	}

	/// <summary>
	/// Topic with this name already exists.
	/// </summary>
	public class TopicAlreadyExistsException : Exception
	{
		public TopicAlreadyExistsException()
		{

		}

		public TopicAlreadyExistsException(string message) : base(message)
		{

		}

		public int Code { get; } = 36;
	}

	/// <summary>
	/// Number of partitions is below 1.
	/// </summary>
	public class InvalidPartitionsException : Exception
	{
		public InvalidPartitionsException()
		{

		}

		public InvalidPartitionsException(string message) : base(message)
		{

		}

		public int Code { get; } = 37;
	}

	/// <summary>
	/// Replication factor is below 1 or larger than the number of available brokers.
	/// </summary>
	public class InvalidReplicationFactorException : Exception
	{
		public InvalidReplicationFactorException()
		{

		}

		public InvalidReplicationFactorException(string message) : base(message)
		{

		}

		public int Code { get; } = 38;
	}

	/// <summary>
	/// Replica assignment is invalid.
	/// </summary>
	public class InvalidReplicaAssignmentException : Exception
	{
		public InvalidReplicaAssignmentException()
		{

		}

		public InvalidReplicaAssignmentException(string message) : base(message)
		{

		}

		public int Code { get; } = 39;
	}

	/// <summary>
	/// Configuration is invalid.
	/// </summary>
	public class InvalidConfigException : Exception
	{
		public InvalidConfigException()
		{

		}

		public InvalidConfigException(string message) : base(message)
		{

		}

		public int Code { get; } = 40;
	}

	/// <summary>
	/// This is not the correct controller for this cluster.
	/// </summary>
	public class NotControllerException : Exception
	{
		public NotControllerException()
		{

		}

		public NotControllerException(string message) : base(message)
		{

		}

		public int Code { get; } = 41;
	}

	/// <summary>
	/// This most likely occurs because of a request being malformed by the client library or the message was sent to an incompatible broker. See the broker logs for more details.
	/// </summary>
	public class InvalidRequestException : Exception
	{
		public InvalidRequestException()
		{

		}

		public InvalidRequestException(string message) : base(message)
		{

		}

		public int Code { get; } = 42;
	}

	/// <summary>
	/// The message format version on the broker does not support the request.
	/// </summary>
	public class UnsupportedForMessageFormatException : Exception
	{
		public UnsupportedForMessageFormatException()
		{

		}

		public UnsupportedForMessageFormatException(string message) : base(message)
		{

		}

		public int Code { get; } = 43;
	}

	/// <summary>
	/// Request parameters do not satisfy the configured policy.
	/// </summary>
	public class PolicyViolationException : Exception
	{
		public PolicyViolationException()
		{

		}

		public PolicyViolationException(string message) : base(message)
		{

		}

		public int Code { get; } = 44;
	}

	/// <summary>
	/// The broker received an out of order sequence number.
	/// </summary>
	public class OutOfOrderSequenceNumberException : Exception
	{
		public OutOfOrderSequenceNumberException()
		{

		}

		public OutOfOrderSequenceNumberException(string message) : base(message)
		{

		}

		public int Code { get; } = 45;
	}

	/// <summary>
	/// The broker received a duplicate sequence number.
	/// </summary>
	public class DuplicateSequenceNumberException : Exception
	{
		public DuplicateSequenceNumberException()
		{

		}

		public DuplicateSequenceNumberException(string message) : base(message)
		{

		}

		public int Code { get; } = 46;
	}

	/// <summary>
	/// Producer attempted an operation with an old epoch. Either there is a newer producer with the same transactionalId, or the producer's transaction has been expired by the broker.
	/// </summary>
	public class InvalidProducerEpochException : Exception
	{
		public InvalidProducerEpochException()
		{

		}

		public InvalidProducerEpochException(string message) : base(message)
		{

		}

		public int Code { get; } = 47;
	}

	/// <summary>
	/// The producer attempted a transactional operation in an invalid state.
	/// </summary>
	public class InvalidTxnStateException : Exception
	{
		public InvalidTxnStateException()
		{

		}

		public InvalidTxnStateException(string message) : base(message)
		{

		}

		public int Code { get; } = 48;
	}

	/// <summary>
	/// The producer attempted to use a producer id which is not currently assigned to its transactional id.
	/// </summary>
	public class InvalidProducerIdMappingException : Exception
	{
		public InvalidProducerIdMappingException()
		{

		}

		public InvalidProducerIdMappingException(string message) : base(message)
		{

		}

		public int Code { get; } = 49;
	}

	/// <summary>
	/// The transaction timeout is larger than the maximum value allowed by the broker (as configured by transaction.max.timeout.ms).
	/// </summary>
	public class InvalidTransactionTimeoutException : Exception
	{
		public InvalidTransactionTimeoutException()
		{

		}

		public InvalidTransactionTimeoutException(string message) : base(message)
		{

		}

		public int Code { get; } = 50;
	}

	/// <summary>
	/// The producer attempted to update a transaction while another concurrent operation on the same transaction was ongoing.
	/// </summary>
	public class ConcurrentTransactionsException : Exception
	{
		public ConcurrentTransactionsException()
		{

		}

		public ConcurrentTransactionsException(string message) : base(message)
		{

		}

		public int Code { get; } = 51;
	}

	/// <summary>
	/// Indicates that the transaction coordinator sending a WriteTxnMarker is no longer the current coordinator for a given producer.
	/// </summary>
	public class TransactionCoordinatorFencedException : Exception
	{
		public TransactionCoordinatorFencedException()
		{

		}

		public TransactionCoordinatorFencedException(string message) : base(message)
		{

		}

		public int Code { get; } = 52;
	}

	/// <summary>
	/// Transactional Id authorization failed.
	/// </summary>
	public class TransactionalIdAuthorizationFailedException : Exception
	{
		public TransactionalIdAuthorizationFailedException()
		{

		}

		public TransactionalIdAuthorizationFailedException(string message) : base(message)
		{

		}

		public int Code { get; } = 53;
	}

	/// <summary>
	/// Security features are disabled.
	/// </summary>
	public class SecurityDisabledException : Exception
	{
		public SecurityDisabledException()
		{

		}

		public SecurityDisabledException(string message) : base(message)
		{

		}

		public int Code { get; } = 54;
	}

	/// <summary>
	/// The broker did not attempt to execute this operation. This may happen for batched RPCs where some operations in the batch failed, causing the broker to respond without trying the rest.
	/// </summary>
	public class OperationNotAttemptedException : Exception
	{
		public OperationNotAttemptedException()
		{

		}

		public OperationNotAttemptedException(string message) : base(message)
		{

		}

		public int Code { get; } = 55;
	}

	/// <summary>
	/// Disk error when trying to access log file on the disk.
	/// </summary>
	public class KafkaStorageErrorException : Exception
	{
		public KafkaStorageErrorException()
		{

		}

		public KafkaStorageErrorException(string message) : base(message)
		{

		}

		public int Code { get; } = 56;
	}

	/// <summary>
	/// The user-specified log directory is not found in the broker config.
	/// </summary>
	public class LogDirNotFoundException : Exception
	{
		public LogDirNotFoundException()
		{

		}

		public LogDirNotFoundException(string message) : base(message)
		{

		}

		public int Code { get; } = 57;
	}

	/// <summary>
	/// SASL Authentication failed.
	/// </summary>
	public class SaslAuthenticationFailedException : Exception
	{
		public SaslAuthenticationFailedException()
		{

		}

		public SaslAuthenticationFailedException(string message) : base(message)
		{

		}

		public int Code { get; } = 58;
	}

	/// <summary>
	/// This exception is raised by the broker if it could not locate the producer metadata associated with the producerId in question. This could happen if, for instance, the producer's records were deleted because their retention time had elapsed. Once the last records of the producerId are removed, the producer's metadata is removed from the broker, and future appends by the producer will return this exception.
	/// </summary>
	public class UnknownProducerIdException : Exception
	{
		public UnknownProducerIdException()
		{

		}

		public UnknownProducerIdException(string message) : base(message)
		{

		}

		public int Code { get; } = 59;
	}

	/// <summary>
	/// A partition reassignment is in progress.
	/// </summary>
	public class ReassignmentInProgressException : Exception
	{
		public ReassignmentInProgressException()
		{

		}

		public ReassignmentInProgressException(string message) : base(message)
		{

		}

		public int Code { get; } = 60;
	}

	/// <summary>
	/// Delegation Token feature is not enabled.
	/// </summary>
	public class DelegationTokenAuthDisabledException : Exception
	{
		public DelegationTokenAuthDisabledException()
		{

		}

		public DelegationTokenAuthDisabledException(string message) : base(message)
		{

		}

		public int Code { get; } = 61;
	}

	/// <summary>
	/// Delegation Token is not found on server.
	/// </summary>
	public class DelegationTokenNotFoundException : Exception
	{
		public DelegationTokenNotFoundException()
		{

		}

		public DelegationTokenNotFoundException(string message) : base(message)
		{

		}

		public int Code { get; } = 62;
	}

	/// <summary>
	/// Specified Principal is not valid Owner/Renewer.
	/// </summary>
	public class DelegationTokenOwnerMismatchException : Exception
	{
		public DelegationTokenOwnerMismatchException()
		{

		}

		public DelegationTokenOwnerMismatchException(string message) : base(message)
		{

		}

		public int Code { get; } = 63;
	}

	/// <summary>
	/// Delegation Token requests are not allowed on PLAINTEXT/1-way SSL channels and on delegation token authenticated channels.
	/// </summary>
	public class DelegationTokenRequestNotAllowedException : Exception
	{
		public DelegationTokenRequestNotAllowedException()
		{

		}

		public DelegationTokenRequestNotAllowedException(string message) : base(message)
		{

		}

		public int Code { get; } = 64;
	}

	/// <summary>
	/// Delegation Token authorization failed.
	/// </summary>
	public class DelegationTokenAuthorizationFailedException : Exception
	{
		public DelegationTokenAuthorizationFailedException()
		{

		}

		public DelegationTokenAuthorizationFailedException(string message) : base(message)
		{

		}

		public int Code { get; } = 65;
	}

	/// <summary>
	/// Delegation Token is expired.
	/// </summary>
	public class DelegationTokenExpiredException : Exception
	{
		public DelegationTokenExpiredException()
		{

		}

		public DelegationTokenExpiredException(string message) : base(message)
		{

		}

		public int Code { get; } = 66;
	}

	/// <summary>
	/// Supplied principalType is not supported.
	/// </summary>
	public class InvalidPrincipalTypeException : Exception
	{
		public InvalidPrincipalTypeException()
		{

		}

		public InvalidPrincipalTypeException(string message) : base(message)
		{

		}

		public int Code { get; } = 67;
	}

	/// <summary>
	/// The group is not empty.
	/// </summary>
	public class NonEmptyGroupException : Exception
	{
		public NonEmptyGroupException()
		{

		}

		public NonEmptyGroupException(string message) : base(message)
		{

		}

		public int Code { get; } = 68;
	}

	/// <summary>
	/// The group id does not exist.
	/// </summary>
	public class GroupIdNotFoundException : Exception
	{
		public GroupIdNotFoundException()
		{

		}

		public GroupIdNotFoundException(string message) : base(message)
		{

		}

		public int Code { get; } = 69;
	}

	/// <summary>
	/// The fetch session ID was not found.
	/// </summary>
	public class FetchSessionIdNotFoundException : Exception
	{
		public FetchSessionIdNotFoundException()
		{

		}

		public FetchSessionIdNotFoundException(string message) : base(message)
		{

		}

		public int Code { get; } = 70;
	}

	/// <summary>
	/// The fetch session epoch is invalid.
	/// </summary>
	public class InvalidFetchSessionEpochException : Exception
	{
		public InvalidFetchSessionEpochException()
		{

		}

		public InvalidFetchSessionEpochException(string message) : base(message)
		{

		}

		public int Code { get; } = 71;
	}

	/// <summary>
	/// There is no listener on the leader broker that matches the listener on which metadata request was processed.
	/// </summary>
	public class ListenerNotFoundException : Exception
	{
		public ListenerNotFoundException()
		{

		}

		public ListenerNotFoundException(string message) : base(message)
		{

		}

		public int Code { get; } = 72;
	}

	/// <summary>
	/// Topic deletion is disabled.
	/// </summary>
	public class TopicDeletionDisabledException : Exception
	{
		public TopicDeletionDisabledException()
		{

		}

		public TopicDeletionDisabledException(string message) : base(message)
		{

		}

		public int Code { get; } = 73;
	}

	/// <summary>
	/// The leader epoch in the request is older than the epoch on the broker
	/// </summary>
	public class FencedLeaderEpochException : Exception
	{
		public FencedLeaderEpochException()
		{

		}

		public FencedLeaderEpochException(string message) : base(message)
		{

		}

		public int Code { get; } = 74;
	}

	/// <summary>
	/// The leader epoch in the request is newer than the epoch on the broker
	/// </summary>
	public class UnknownLeaderEpochException : Exception
	{
		public UnknownLeaderEpochException()
		{

		}

		public UnknownLeaderEpochException(string message) : base(message)
		{

		}

		public int Code { get; } = 75;
	}

	/// <summary>
	/// The requesting client does not support the compression type of given partition.
	/// </summary>
	public class UnsupportedCompressionTypeException : Exception
	{
		public UnsupportedCompressionTypeException()
		{

		}

		public UnsupportedCompressionTypeException(string message) : base(message)
		{

		}

		public int Code { get; } = 76;
	}

	public static class Messages 
	{
		public static async ValueTask<Message> CreateRequestMessageFromReaderAsync(
			Int16 apiKey, 
			Int16 version, 
			IKafkaReader reader, 
			CancellationToken cancellationToken = default)
		{
			if (AddOffsetsToTxnRequest.ApiKey == apiKey)
			{
				return await AddOffsetsToTxnRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (AddPartitionsToTxnRequest.ApiKey == apiKey)
			{
				return await AddPartitionsToTxnRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (AlterConfigsRequest.ApiKey == apiKey)
			{
				return await AlterConfigsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (AlterReplicaLogDirsRequest.ApiKey == apiKey)
			{
				return await AlterReplicaLogDirsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ApiVersionsRequest.ApiKey == apiKey)
			{
				return await ApiVersionsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ControlledShutdownRequest.ApiKey == apiKey)
			{
				return await ControlledShutdownRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (CreateAclsRequest.ApiKey == apiKey)
			{
				return await CreateAclsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (CreateDelegationTokenRequest.ApiKey == apiKey)
			{
				return await CreateDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (CreatePartitionsRequest.ApiKey == apiKey)
			{
				return await CreatePartitionsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (CreateTopicsRequest.ApiKey == apiKey)
			{
				return await CreateTopicsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DeleteAclsRequest.ApiKey == apiKey)
			{
				return await DeleteAclsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DeleteGroupsRequest.ApiKey == apiKey)
			{
				return await DeleteGroupsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DeleteRecordsRequest.ApiKey == apiKey)
			{
				return await DeleteRecordsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DeleteTopicsRequest.ApiKey == apiKey)
			{
				return await DeleteTopicsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DescribeAclsRequest.ApiKey == apiKey)
			{
				return await DescribeAclsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DescribeConfigsRequest.ApiKey == apiKey)
			{
				return await DescribeConfigsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DescribeDelegationTokenRequest.ApiKey == apiKey)
			{
				return await DescribeDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DescribeGroupsRequest.ApiKey == apiKey)
			{
				return await DescribeGroupsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DescribeLogDirsRequest.ApiKey == apiKey)
			{
				return await DescribeLogDirsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ElectLeadersRequest.ApiKey == apiKey)
			{
				return await ElectLeadersRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (EndTxnRequest.ApiKey == apiKey)
			{
				return await EndTxnRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ExpireDelegationTokenRequest.ApiKey == apiKey)
			{
				return await ExpireDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (FetchRequest.ApiKey == apiKey)
			{
				return await FetchRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (FindCoordinatorRequest.ApiKey == apiKey)
			{
				return await FindCoordinatorRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (HeartbeatRequest.ApiKey == apiKey)
			{
				return await HeartbeatRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (IncrementalAlterConfigsRequest.ApiKey == apiKey)
			{
				return await IncrementalAlterConfigsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (InitProducerIdRequest.ApiKey == apiKey)
			{
				return await InitProducerIdRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (JoinGroupRequest.ApiKey == apiKey)
			{
				return await JoinGroupRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (LeaderAndIsrRequest.ApiKey == apiKey)
			{
				return await LeaderAndIsrRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (LeaveGroupRequest.ApiKey == apiKey)
			{
				return await LeaveGroupRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ListGroupsRequest.ApiKey == apiKey)
			{
				return await ListGroupsRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ListOffsetRequest.ApiKey == apiKey)
			{
				return await ListOffsetRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (MetadataRequest.ApiKey == apiKey)
			{
				return await MetadataRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (OffsetCommitRequest.ApiKey == apiKey)
			{
				return await OffsetCommitRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (OffsetFetchRequest.ApiKey == apiKey)
			{
				return await OffsetFetchRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (OffsetForLeaderEpochRequest.ApiKey == apiKey)
			{
				return await OffsetForLeaderEpochRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ProduceRequest.ApiKey == apiKey)
			{
				return await ProduceRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (RenewDelegationTokenRequest.ApiKey == apiKey)
			{
				return await RenewDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (SaslAuthenticateRequest.ApiKey == apiKey)
			{
				return await SaslAuthenticateRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (SaslHandshakeRequest.ApiKey == apiKey)
			{
				return await SaslHandshakeRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (StopReplicaRequest.ApiKey == apiKey)
			{
				return await StopReplicaRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (SyncGroupRequest.ApiKey == apiKey)
			{
				return await SyncGroupRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (TxnOffsetCommitRequest.ApiKey == apiKey)
			{
				return await TxnOffsetCommitRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (UpdateMetadataRequest.ApiKey == apiKey)
			{
				return await UpdateMetadataRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (WriteTxnMarkersRequest.ApiKey == apiKey)
			{
				return await WriteTxnMarkersRequest.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			throw new ArgumentException($"{apiKey} is not supported");
		}

		public static async ValueTask<Message> CreateResponseMessageFromReaderAsync(
			Int16 apiKey, 
			Int16 version, 
			IKafkaReader reader, 
			CancellationToken cancellationToken = default)
		{
			if (AddOffsetsToTxnResponse.ApiKey == apiKey)
			{
				return await AddOffsetsToTxnResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (AddPartitionsToTxnResponse.ApiKey == apiKey)
			{
				return await AddPartitionsToTxnResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (AlterConfigsResponse.ApiKey == apiKey)
			{
				return await AlterConfigsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (AlterReplicaLogDirsResponse.ApiKey == apiKey)
			{
				return await AlterReplicaLogDirsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ApiVersionsResponse.ApiKey == apiKey)
			{
				return await ApiVersionsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ControlledShutdownResponse.ApiKey == apiKey)
			{
				return await ControlledShutdownResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (CreateAclsResponse.ApiKey == apiKey)
			{
				return await CreateAclsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (CreateDelegationTokenResponse.ApiKey == apiKey)
			{
				return await CreateDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (CreatePartitionsResponse.ApiKey == apiKey)
			{
				return await CreatePartitionsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (CreateTopicsResponse.ApiKey == apiKey)
			{
				return await CreateTopicsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DeleteAclsResponse.ApiKey == apiKey)
			{
				return await DeleteAclsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DeleteGroupsResponse.ApiKey == apiKey)
			{
				return await DeleteGroupsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DeleteRecordsResponse.ApiKey == apiKey)
			{
				return await DeleteRecordsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DeleteTopicsResponse.ApiKey == apiKey)
			{
				return await DeleteTopicsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DescribeAclsResponse.ApiKey == apiKey)
			{
				return await DescribeAclsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DescribeConfigsResponse.ApiKey == apiKey)
			{
				return await DescribeConfigsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DescribeDelegationTokenResponse.ApiKey == apiKey)
			{
				return await DescribeDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DescribeGroupsResponse.ApiKey == apiKey)
			{
				return await DescribeGroupsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (DescribeLogDirsResponse.ApiKey == apiKey)
			{
				return await DescribeLogDirsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ElectLeadersResponse.ApiKey == apiKey)
			{
				return await ElectLeadersResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (EndTxnResponse.ApiKey == apiKey)
			{
				return await EndTxnResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ExpireDelegationTokenResponse.ApiKey == apiKey)
			{
				return await ExpireDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (FetchResponse.ApiKey == apiKey)
			{
				return await FetchResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (FindCoordinatorResponse.ApiKey == apiKey)
			{
				return await FindCoordinatorResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (HeartbeatResponse.ApiKey == apiKey)
			{
				return await HeartbeatResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (IncrementalAlterConfigsResponse.ApiKey == apiKey)
			{
				return await IncrementalAlterConfigsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (InitProducerIdResponse.ApiKey == apiKey)
			{
				return await InitProducerIdResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (JoinGroupResponse.ApiKey == apiKey)
			{
				return await JoinGroupResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (LeaderAndIsrResponse.ApiKey == apiKey)
			{
				return await LeaderAndIsrResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (LeaveGroupResponse.ApiKey == apiKey)
			{
				return await LeaveGroupResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ListGroupsResponse.ApiKey == apiKey)
			{
				return await ListGroupsResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ListOffsetResponse.ApiKey == apiKey)
			{
				return await ListOffsetResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (MetadataResponse.ApiKey == apiKey)
			{
				return await MetadataResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (OffsetCommitResponse.ApiKey == apiKey)
			{
				return await OffsetCommitResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (OffsetFetchResponse.ApiKey == apiKey)
			{
				return await OffsetFetchResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (OffsetForLeaderEpochResponse.ApiKey == apiKey)
			{
				return await OffsetForLeaderEpochResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (ProduceResponse.ApiKey == apiKey)
			{
				return await ProduceResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (RenewDelegationTokenResponse.ApiKey == apiKey)
			{
				return await RenewDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (SaslAuthenticateResponse.ApiKey == apiKey)
			{
				return await SaslAuthenticateResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (SaslHandshakeResponse.ApiKey == apiKey)
			{
				return await SaslHandshakeResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (StopReplicaResponse.ApiKey == apiKey)
			{
				return await StopReplicaResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (SyncGroupResponse.ApiKey == apiKey)
			{
				return await SyncGroupResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (TxnOffsetCommitResponse.ApiKey == apiKey)
			{
				return await TxnOffsetCommitResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (UpdateMetadataResponse.ApiKey == apiKey)
			{
				return await UpdateMetadataResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			if (WriteTxnMarkersResponse.ApiKey == apiKey)
			{
				return await WriteTxnMarkersResponse.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
			}

			throw new ArgumentException($"{apiKey} is not supported");
		}
	}

	public class AddOffsetsToTxnRequest : Message, IRespond<AddOffsetsToTxnResponse>
	{
		public AddOffsetsToTxnRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"AddOffsetsToTxnRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(25);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<AddOffsetsToTxnRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AddOffsetsToTxnRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerId = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(TransactionalId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ProducerId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ProducerEpoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
			}
		}

		private String _transactionalId = String.Default;
		/// <summary>
		/// The transactional id corresponding to the transaction.
		/// </summary>
		public String TransactionalId 
		{
			get => _transactionalId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TransactionalId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_transactionalId = value;
			}
		}

		/// <summary>
		/// The transactional id corresponding to the transaction.
		/// </summary>
		public AddOffsetsToTxnRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		private Int64 _producerId = Int64.Default;
		/// <summary>
		/// Current producer id in use by the transactional id.
		/// </summary>
		public Int64 ProducerId 
		{
			get => _producerId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_producerId = value;
			}
		}

		/// <summary>
		/// Current producer id in use by the transactional id.
		/// </summary>
		public AddOffsetsToTxnRequest WithProducerId(Int64 producerId)
		{
			ProducerId = producerId;
			return this;
		}

		private Int16 _producerEpoch = Int16.Default;
		/// <summary>
		/// Current epoch associated with the producer id.
		/// </summary>
		public Int16 ProducerEpoch 
		{
			get => _producerEpoch;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProducerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_producerEpoch = value;
			}
		}

		/// <summary>
		/// Current epoch associated with the producer id.
		/// </summary>
		public AddOffsetsToTxnRequest WithProducerEpoch(Int16 producerEpoch)
		{
			ProducerEpoch = producerEpoch;
			return this;
		}

		private String _groupId = String.Default;
		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public String GroupId 
		{
			get => _groupId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupId = value;
			}
		}

		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public AddOffsetsToTxnRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		public AddOffsetsToTxnResponse Respond()
			=> new AddOffsetsToTxnResponse(Version);
	}

	public class AddOffsetsToTxnResponse : Message
	{
		public AddOffsetsToTxnResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"AddOffsetsToTxnResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(25);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<AddOffsetsToTxnResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AddOffsetsToTxnResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public AddOffsetsToTxnResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The response error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The response error code, or 0 if there was no error.
		/// </summary>
		public AddOffsetsToTxnResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class AddPartitionsToTxnRequest : Message, IRespond<AddPartitionsToTxnResponse>
	{
		public AddPartitionsToTxnRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"AddPartitionsToTxnRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(24);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<AddPartitionsToTxnRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AddPartitionsToTxnRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerId = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = (await reader.ReadArrayAsync(async () => await AddPartitionsToTxnTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(TransactionalId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ProducerId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ProducerEpoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection.Values.ToArray()).ConfigureAwait(false);
			}
		}

		private String _transactionalId = String.Default;
		/// <summary>
		/// The transactional id corresponding to the transaction.
		/// </summary>
		public String TransactionalId 
		{
			get => _transactionalId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TransactionalId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_transactionalId = value;
			}
		}

		/// <summary>
		/// The transactional id corresponding to the transaction.
		/// </summary>
		public AddPartitionsToTxnRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		private Int64 _producerId = Int64.Default;
		/// <summary>
		/// Current producer id in use by the transactional id.
		/// </summary>
		public Int64 ProducerId 
		{
			get => _producerId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_producerId = value;
			}
		}

		/// <summary>
		/// Current producer id in use by the transactional id.
		/// </summary>
		public AddPartitionsToTxnRequest WithProducerId(Int64 producerId)
		{
			ProducerId = producerId;
			return this;
		}

		private Int16 _producerEpoch = Int16.Default;
		/// <summary>
		/// Current epoch associated with the producer id.
		/// </summary>
		public Int16 ProducerEpoch 
		{
			get => _producerEpoch;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProducerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_producerEpoch = value;
			}
		}

		/// <summary>
		/// Current epoch associated with the producer id.
		/// </summary>
		public AddPartitionsToTxnRequest WithProducerEpoch(Int16 producerEpoch)
		{
			ProducerEpoch = producerEpoch;
			return this;
		}

		private Dictionary<String, AddPartitionsToTxnTopic> _topicsCollection = new Dictionary<String, AddPartitionsToTxnTopic>();
		/// <summary>
		/// The partitions to add to the transation.
		/// </summary>
		public Dictionary<String, AddPartitionsToTxnTopic> TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// The partitions to add to the transation.
		/// </summary>
		public AddPartitionsToTxnRequest WithTopicsCollection(params Func<AddPartitionsToTxnTopic, AddPartitionsToTxnTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateAddPartitionsToTxnTopic()))
				.ToDictionary(field => field.Name);
			return this;
		}

		internal AddPartitionsToTxnTopic CreateAddPartitionsToTxnTopic()
		{
			return new AddPartitionsToTxnTopic(Version);
		}

		public class AddPartitionsToTxnTopic : ISerialize
		{
			internal AddPartitionsToTxnTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<AddPartitionsToTxnTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AddPartitionsToTxnTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The name of the topic.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The name of the topic.
			/// </summary>
			public AddPartitionsToTxnTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private Int32[] _partitionsCollection = Array.Empty<Int32>();
			/// <summary>
			/// The partition indexes to add to the transaction
			/// </summary>
			public Int32[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// The partition indexes to add to the transaction
			/// </summary>
			public AddPartitionsToTxnTopic WithPartitionsCollection(Int32[] partitionsCollection)
			{
				PartitionsCollection = partitionsCollection;
				return this;
			}
		}

		public AddPartitionsToTxnResponse Respond()
			=> new AddPartitionsToTxnResponse(Version);
	}

	public class AddPartitionsToTxnResponse : Message
	{
		public AddPartitionsToTxnResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"AddPartitionsToTxnResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(24);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<AddPartitionsToTxnResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AddPartitionsToTxnResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = (await reader.ReadArrayAsync(async () => await AddPartitionsToTxnTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection.Values.ToArray()).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public AddPartitionsToTxnResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Dictionary<String, AddPartitionsToTxnTopicResult> _resultsCollection = new Dictionary<String, AddPartitionsToTxnTopicResult>();
		/// <summary>
		/// The results for each topic.
		/// </summary>
		public Dictionary<String, AddPartitionsToTxnTopicResult> ResultsCollection 
		{
			get => _resultsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resultsCollection = value;
			}
		}

		/// <summary>
		/// The results for each topic.
		/// </summary>
		public AddPartitionsToTxnResponse WithResultsCollection(params Func<AddPartitionsToTxnTopicResult, AddPartitionsToTxnTopicResult>[] createFields)
		{
			ResultsCollection = createFields
				.Select(createField => createField(CreateAddPartitionsToTxnTopicResult()))
				.ToDictionary(field => field.Name);
			return this;
		}

		internal AddPartitionsToTxnTopicResult CreateAddPartitionsToTxnTopicResult()
		{
			return new AddPartitionsToTxnTopicResult(Version);
		}

		public class AddPartitionsToTxnTopicResult : ISerialize
		{
			internal AddPartitionsToTxnTopicResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<AddPartitionsToTxnTopicResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AddPartitionsToTxnTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResultsCollection = (await reader.ReadArrayAsync(async () => await AddPartitionsToTxnPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.PartitionIndex);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ResultsCollection.Values.ToArray()).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public AddPartitionsToTxnTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			private Dictionary<Int32, AddPartitionsToTxnPartitionResult> _resultsCollection = new Dictionary<Int32, AddPartitionsToTxnPartitionResult>();
			/// <summary>
			/// The results for each partition
			/// </summary>
			public Dictionary<Int32, AddPartitionsToTxnPartitionResult> ResultsCollection 
			{
				get => _resultsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resultsCollection = value;
				}
			}

			/// <summary>
			/// The results for each partition
			/// </summary>
			public AddPartitionsToTxnTopicResult WithResultsCollection(params Func<AddPartitionsToTxnPartitionResult, AddPartitionsToTxnPartitionResult>[] createFields)
			{
				ResultsCollection = createFields
					.Select(createField => createField(CreateAddPartitionsToTxnPartitionResult()))
					.ToDictionary(field => field.PartitionIndex);
				return this;
			}

			internal AddPartitionsToTxnPartitionResult CreateAddPartitionsToTxnPartitionResult()
			{
				return new AddPartitionsToTxnPartitionResult(Version);
			}

			public class AddPartitionsToTxnPartitionResult : ISerialize
			{
				internal AddPartitionsToTxnPartitionResult(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<AddPartitionsToTxnPartitionResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AddPartitionsToTxnPartitionResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition indexes.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition indexes.
				/// </summary>
				public AddPartitionsToTxnPartitionResult WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The response error code.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The response error code.
				/// </summary>
				public AddPartitionsToTxnPartitionResult WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}
	}

	public class AlterConfigsRequest : Message, IRespond<AlterConfigsResponse>
	{
		public AlterConfigsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"AlterConfigsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(33);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<AlterConfigsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AlterConfigsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourcesCollection = (await reader.ReadArrayAsync(async () => await AlterConfigsResource.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.ResourceType);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ValidateOnly = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResourcesCollection.Values.ToArray()).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBooleanAsync(ValidateOnly, cancellationToken).ConfigureAwait(false);
			}
		}

		private Dictionary<Int8, AlterConfigsResource> _resourcesCollection = new Dictionary<Int8, AlterConfigsResource>();
		/// <summary>
		/// The updates for each resource.
		/// </summary>
		public Dictionary<Int8, AlterConfigsResource> ResourcesCollection 
		{
			get => _resourcesCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResourcesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resourcesCollection = value;
			}
		}

		/// <summary>
		/// The updates for each resource.
		/// </summary>
		public AlterConfigsRequest WithResourcesCollection(params Func<AlterConfigsResource, AlterConfigsResource>[] createFields)
		{
			ResourcesCollection = createFields
				.Select(createField => createField(CreateAlterConfigsResource()))
				.ToDictionary(field => field.ResourceType);
			return this;
		}

		internal AlterConfigsResource CreateAlterConfigsResource()
		{
			return new AlterConfigsResource(Version);
		}

		public class AlterConfigsResource : ISerialize
		{
			internal AlterConfigsResource(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<AlterConfigsResource> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterConfigsResource(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ConfigsCollection = (await reader.ReadArrayAsync(async () => await AlterableConfig.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ConfigsCollection.Values.ToArray()).ConfigureAwait(false);
				}
			}

			private Int8 _resourceType = Int8.Default;
			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceType 
			{
				get => _resourceType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceType = value;
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public AlterConfigsResource WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			private String _resourceName = String.Default;
			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceName 
			{
				get => _resourceName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceName = value;
				}
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			public AlterConfigsResource WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}

			private Dictionary<String, AlterableConfig> _configsCollection = new Dictionary<String, AlterableConfig>();
			/// <summary>
			/// The configurations.
			/// </summary>
			public Dictionary<String, AlterableConfig> ConfigsCollection 
			{
				get => _configsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ConfigsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_configsCollection = value;
				}
			}

			/// <summary>
			/// The configurations.
			/// </summary>
			public AlterConfigsResource WithConfigsCollection(params Func<AlterableConfig, AlterableConfig>[] createFields)
			{
				ConfigsCollection = createFields
					.Select(createField => createField(CreateAlterableConfig()))
					.ToDictionary(field => field.Name);
				return this;
			}

			internal AlterableConfig CreateAlterableConfig()
			{
				return new AlterableConfig(Version);
			}

			public class AlterableConfig : ISerialize
			{
				internal AlterableConfig(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<AlterableConfig> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AlterableConfig(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Value = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(Value, cancellationToken).ConfigureAwait(false);
					}
				}

				private String _name = String.Default;
				/// <summary>
				/// The configuration key name.
				/// </summary>
				public String Name 
				{
					get => _name;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_name = value;
					}
				}

				/// <summary>
				/// The configuration key name.
				/// </summary>
				public AlterableConfig WithName(String name)
				{
					Name = name;
					return this;
				}

				private String? _value = String.Default;
				/// <summary>
				/// The value to set for the configuration key.
				/// </summary>
				public String? Value 
				{
					get => _value;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Value does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"Value does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_value = value;
					}
				}

				/// <summary>
				/// The value to set for the configuration key.
				/// </summary>
				public AlterableConfig WithValue(String value)
				{
					Value = value;
					return this;
				}
			}
		}

		private Boolean _validateOnly = Boolean.Default;
		/// <summary>
		/// True if we should validate the request, but not change the configurations.
		/// </summary>
		public Boolean ValidateOnly 
		{
			get => _validateOnly;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ValidateOnly does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_validateOnly = value;
			}
		}

		/// <summary>
		/// True if we should validate the request, but not change the configurations.
		/// </summary>
		public AlterConfigsRequest WithValidateOnly(Boolean validateOnly)
		{
			ValidateOnly = validateOnly;
			return this;
		}

		public AlterConfigsResponse Respond()
			=> new AlterConfigsResponse(Version);
	}

	public class AlterConfigsResponse : Message
	{
		public AlterConfigsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"AlterConfigsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(33);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<AlterConfigsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AlterConfigsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResponsesCollection = await reader.ReadArrayAsync(async () => await AlterConfigsResourceResponse.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResponsesCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public AlterConfigsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private AlterConfigsResourceResponse[] _responsesCollection = Array.Empty<AlterConfigsResourceResponse>();
		/// <summary>
		/// The responses for each resource.
		/// </summary>
		public AlterConfigsResourceResponse[] ResponsesCollection 
		{
			get => _responsesCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResponsesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_responsesCollection = value;
			}
		}

		/// <summary>
		/// The responses for each resource.
		/// </summary>
		public AlterConfigsResponse WithResponsesCollection(params Func<AlterConfigsResourceResponse, AlterConfigsResourceResponse>[] createFields)
		{
			ResponsesCollection = createFields
				.Select(createField => createField(CreateAlterConfigsResourceResponse()))
				.ToArray();
			return this;
		}

		internal AlterConfigsResourceResponse CreateAlterConfigsResourceResponse()
		{
			return new AlterConfigsResourceResponse(Version);
		}

		public class AlterConfigsResourceResponse : ISerialize
		{
			internal AlterConfigsResourceResponse(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<AlterConfigsResourceResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterConfigsResourceResponse(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The resource error code.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The resource error code.
			/// </summary>
			public AlterConfigsResourceResponse WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			private String? _errorMessage = String.Default;
			/// <summary>
			/// The resource error message, or null if there was no error.
			/// </summary>
			public String? ErrorMessage 
			{
				get => _errorMessage;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_errorMessage = value;
				}
			}

			/// <summary>
			/// The resource error message, or null if there was no error.
			/// </summary>
			public AlterConfigsResourceResponse WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}

			private Int8 _resourceType = Int8.Default;
			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceType 
			{
				get => _resourceType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceType = value;
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public AlterConfigsResourceResponse WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			private String _resourceName = String.Default;
			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceName 
			{
				get => _resourceName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceName = value;
				}
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			public AlterConfigsResourceResponse WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}
		}
	}

	public class AlterReplicaLogDirsRequest : Message, IRespond<AlterReplicaLogDirsResponse>
	{
		public AlterReplicaLogDirsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"AlterReplicaLogDirsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(34);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<AlterReplicaLogDirsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AlterReplicaLogDirsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.DirsCollection = (await reader.ReadArrayAsync(async () => await AlterReplicaLogDir.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Path);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, DirsCollection.Values.ToArray()).ConfigureAwait(false);
			}
		}

		private Dictionary<String, AlterReplicaLogDir> _dirsCollection = new Dictionary<String, AlterReplicaLogDir>();
		/// <summary>
		/// The alterations to make for each directory.
		/// </summary>
		public Dictionary<String, AlterReplicaLogDir> DirsCollection 
		{
			get => _dirsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"DirsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_dirsCollection = value;
			}
		}

		/// <summary>
		/// The alterations to make for each directory.
		/// </summary>
		public AlterReplicaLogDirsRequest WithDirsCollection(params Func<AlterReplicaLogDir, AlterReplicaLogDir>[] createFields)
		{
			DirsCollection = createFields
				.Select(createField => createField(CreateAlterReplicaLogDir()))
				.ToDictionary(field => field.Path);
			return this;
		}

		internal AlterReplicaLogDir CreateAlterReplicaLogDir()
		{
			return new AlterReplicaLogDir(Version);
		}

		public class AlterReplicaLogDir : ISerialize
		{
			internal AlterReplicaLogDir(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<AlterReplicaLogDir> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterReplicaLogDir(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Path = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicsCollection = (await reader.ReadArrayAsync(async () => await AlterReplicaLogDirTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Path, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, TopicsCollection.Values.ToArray()).ConfigureAwait(false);
				}
			}

			private String _path = String.Default;
			/// <summary>
			/// The absolute directory path.
			/// </summary>
			public String Path 
			{
				get => _path;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Path does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_path = value;
				}
			}

			/// <summary>
			/// The absolute directory path.
			/// </summary>
			public AlterReplicaLogDir WithPath(String path)
			{
				Path = path;
				return this;
			}

			private Dictionary<String, AlterReplicaLogDirTopic> _topicsCollection = new Dictionary<String, AlterReplicaLogDirTopic>();
			/// <summary>
			/// The topics to add to the directory.
			/// </summary>
			public Dictionary<String, AlterReplicaLogDirTopic> TopicsCollection 
			{
				get => _topicsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topicsCollection = value;
				}
			}

			/// <summary>
			/// The topics to add to the directory.
			/// </summary>
			public AlterReplicaLogDir WithTopicsCollection(params Func<AlterReplicaLogDirTopic, AlterReplicaLogDirTopic>[] createFields)
			{
				TopicsCollection = createFields
					.Select(createField => createField(CreateAlterReplicaLogDirTopic()))
					.ToDictionary(field => field.Name);
				return this;
			}

			internal AlterReplicaLogDirTopic CreateAlterReplicaLogDirTopic()
			{
				return new AlterReplicaLogDirTopic(Version);
			}

			public class AlterReplicaLogDirTopic : ISerialize
			{
				internal AlterReplicaLogDirTopic(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<AlterReplicaLogDirTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AlterReplicaLogDirTopic(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
					}
				}

				private String _name = String.Default;
				/// <summary>
				/// The topic name.
				/// </summary>
				public String Name 
				{
					get => _name;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_name = value;
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				public AlterReplicaLogDirTopic WithName(String name)
				{
					Name = name;
					return this;
				}

				private Int32[] _partitionsCollection = Array.Empty<Int32>();
				/// <summary>
				/// The partition indexes.
				/// </summary>
				public Int32[] PartitionsCollection 
				{
					get => _partitionsCollection;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionsCollection = value;
					}
				}

				/// <summary>
				/// The partition indexes.
				/// </summary>
				public AlterReplicaLogDirTopic WithPartitionsCollection(Int32[] partitionsCollection)
				{
					PartitionsCollection = partitionsCollection;
					return this;
				}
			}
		}

		public AlterReplicaLogDirsResponse Respond()
			=> new AlterReplicaLogDirsResponse(Version);
	}

	public class AlterReplicaLogDirsResponse : Message
	{
		public AlterReplicaLogDirsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"AlterReplicaLogDirsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(34);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<AlterReplicaLogDirsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AlterReplicaLogDirsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = await reader.ReadArrayAsync(async () => await AlterReplicaLogDirTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public AlterReplicaLogDirsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private AlterReplicaLogDirTopicResult[] _resultsCollection = Array.Empty<AlterReplicaLogDirTopicResult>();
		/// <summary>
		/// The results for each topic.
		/// </summary>
		public AlterReplicaLogDirTopicResult[] ResultsCollection 
		{
			get => _resultsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resultsCollection = value;
			}
		}

		/// <summary>
		/// The results for each topic.
		/// </summary>
		public AlterReplicaLogDirsResponse WithResultsCollection(params Func<AlterReplicaLogDirTopicResult, AlterReplicaLogDirTopicResult>[] createFields)
		{
			ResultsCollection = createFields
				.Select(createField => createField(CreateAlterReplicaLogDirTopicResult()))
				.ToArray();
			return this;
		}

		internal AlterReplicaLogDirTopicResult CreateAlterReplicaLogDirTopicResult()
		{
			return new AlterReplicaLogDirTopicResult(Version);
		}

		public class AlterReplicaLogDirTopicResult : ISerialize
		{
			internal AlterReplicaLogDirTopicResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<AlterReplicaLogDirTopicResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterReplicaLogDirTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await AlterReplicaLogDirPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _topicName = String.Default;
			/// <summary>
			/// The name of the topic.
			/// </summary>
			public String TopicName 
			{
				get => _topicName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topicName = value;
				}
			}

			/// <summary>
			/// The name of the topic.
			/// </summary>
			public AlterReplicaLogDirTopicResult WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			private AlterReplicaLogDirPartitionResult[] _partitionsCollection = Array.Empty<AlterReplicaLogDirPartitionResult>();
			/// <summary>
			/// The results for each partition.
			/// </summary>
			public AlterReplicaLogDirPartitionResult[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// The results for each partition.
			/// </summary>
			public AlterReplicaLogDirTopicResult WithPartitionsCollection(params Func<AlterReplicaLogDirPartitionResult, AlterReplicaLogDirPartitionResult>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateAlterReplicaLogDirPartitionResult()))
					.ToArray();
				return this;
			}

			internal AlterReplicaLogDirPartitionResult CreateAlterReplicaLogDirPartitionResult()
			{
				return new AlterReplicaLogDirPartitionResult(Version);
			}

			public class AlterReplicaLogDirPartitionResult : ISerialize
			{
				internal AlterReplicaLogDirPartitionResult(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<AlterReplicaLogDirPartitionResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AlterReplicaLogDirPartitionResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public AlterReplicaLogDirPartitionResult WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public AlterReplicaLogDirPartitionResult WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}
	}

	public class ApiVersionsRequest : Message, IRespond<ApiVersionsResponse>
	{
		public ApiVersionsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ApiVersionsRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(18);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<ApiVersionsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ApiVersionsRequest(version);

			return await new ValueTask<ApiVersionsRequest>(instance);
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await Task.CompletedTask;
		}

		public ApiVersionsResponse Respond()
			=> new ApiVersionsResponse(Version);
	}

	public class ApiVersionsResponse : Message
	{
		public ApiVersionsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ApiVersionsResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(18);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<ApiVersionsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ApiVersionsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ApiKeysCollection = (await reader.ReadArrayAsync(async () => await ApiVersionsResponseKey.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Index);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ApiKeysCollection.Values.ToArray()).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The top-level error code.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The top-level error code.
		/// </summary>
		public ApiVersionsResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private Dictionary<Int16, ApiVersionsResponseKey> _apiKeysCollection = new Dictionary<Int16, ApiVersionsResponseKey>();
		/// <summary>
		/// The APIs supported by the broker.
		/// </summary>
		public Dictionary<Int16, ApiVersionsResponseKey> ApiKeysCollection 
		{
			get => _apiKeysCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ApiKeysCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_apiKeysCollection = value;
			}
		}

		/// <summary>
		/// The APIs supported by the broker.
		/// </summary>
		public ApiVersionsResponse WithApiKeysCollection(params Func<ApiVersionsResponseKey, ApiVersionsResponseKey>[] createFields)
		{
			ApiKeysCollection = createFields
				.Select(createField => createField(CreateApiVersionsResponseKey()))
				.ToDictionary(field => field.Index);
			return this;
		}

		internal ApiVersionsResponseKey CreateApiVersionsResponseKey()
		{
			return new ApiVersionsResponseKey(Version);
		}

		public class ApiVersionsResponseKey : ISerialize
		{
			internal ApiVersionsResponseKey(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<ApiVersionsResponseKey> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ApiVersionsResponseKey(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Index = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MinVersion = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MaxVersion = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(Index, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(MinVersion, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(MaxVersion, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int16 _index = Int16.Default;
			/// <summary>
			/// The API index.
			/// </summary>
			public Int16 Index 
			{
				get => _index;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Index does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_index = value;
				}
			}

			/// <summary>
			/// The API index.
			/// </summary>
			public ApiVersionsResponseKey WithIndex(Int16 index)
			{
				Index = index;
				return this;
			}

			private Int16 _minVersion = Int16.Default;
			/// <summary>
			/// The minimum supported version, inclusive.
			/// </summary>
			public Int16 MinVersion 
			{
				get => _minVersion;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"MinVersion does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_minVersion = value;
				}
			}

			/// <summary>
			/// The minimum supported version, inclusive.
			/// </summary>
			public ApiVersionsResponseKey WithMinVersion(Int16 minVersion)
			{
				MinVersion = minVersion;
				return this;
			}

			private Int16 _maxVersion = Int16.Default;
			/// <summary>
			/// The maximum supported version, inclusive.
			/// </summary>
			public Int16 MaxVersion 
			{
				get => _maxVersion;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"MaxVersion does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_maxVersion = value;
				}
			}

			/// <summary>
			/// The maximum supported version, inclusive.
			/// </summary>
			public ApiVersionsResponseKey WithMaxVersion(Int16 maxVersion)
			{
				MaxVersion = maxVersion;
				return this;
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public ApiVersionsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class ControlledShutdownRequest : Message, IRespond<ControlledShutdownResponse>
	{
		public ControlledShutdownRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ControlledShutdownRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(7);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<ControlledShutdownRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ControlledShutdownRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.BrokerId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.BrokerEpoch = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(BrokerId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt64Async(BrokerEpoch, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _brokerId = Int32.Default;
		/// <summary>
		/// The id of the broker for which controlled shutdown has been requested.
		/// </summary>
		public Int32 BrokerId 
		{
			get => _brokerId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"BrokerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_brokerId = value;
			}
		}

		/// <summary>
		/// The id of the broker for which controlled shutdown has been requested.
		/// </summary>
		public ControlledShutdownRequest WithBrokerId(Int32 brokerId)
		{
			BrokerId = brokerId;
			return this;
		}

		private Int64 _brokerEpoch = new Int64(-1);
		/// <summary>
		/// The broker epoch.
		/// </summary>
		public Int64 BrokerEpoch 
		{
			get => _brokerEpoch;
			set 
			{
				_brokerEpoch = value;
			}
		}

		/// <summary>
		/// The broker epoch.
		/// </summary>
		public ControlledShutdownRequest WithBrokerEpoch(Int64 brokerEpoch)
		{
			BrokerEpoch = brokerEpoch;
			return this;
		}

		public ControlledShutdownResponse Respond()
			=> new ControlledShutdownResponse(Version);
	}

	public class ControlledShutdownResponse : Message
	{
		public ControlledShutdownResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ControlledShutdownResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(7);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<ControlledShutdownResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ControlledShutdownResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.RemainingPartitionsCollection = (await reader.ReadArrayAsync(async () => await RemainingPartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.TopicName);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, RemainingPartitionsCollection.Values.ToArray()).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The top-level error code.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The top-level error code.
		/// </summary>
		public ControlledShutdownResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private Dictionary<String, RemainingPartition> _remainingPartitionsCollection = new Dictionary<String, RemainingPartition>();
		/// <summary>
		/// The partitions that the broker still leads.
		/// </summary>
		public Dictionary<String, RemainingPartition> RemainingPartitionsCollection 
		{
			get => _remainingPartitionsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"RemainingPartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_remainingPartitionsCollection = value;
			}
		}

		/// <summary>
		/// The partitions that the broker still leads.
		/// </summary>
		public ControlledShutdownResponse WithRemainingPartitionsCollection(params Func<RemainingPartition, RemainingPartition>[] createFields)
		{
			RemainingPartitionsCollection = createFields
				.Select(createField => createField(CreateRemainingPartition()))
				.ToDictionary(field => field.TopicName);
			return this;
		}

		internal RemainingPartition CreateRemainingPartition()
		{
			return new RemainingPartition(Version);
		}

		public class RemainingPartition : ISerialize
		{
			internal RemainingPartition(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<RemainingPartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new RemainingPartition(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _topicName = String.Default;
			/// <summary>
			/// The name of the topic.
			/// </summary>
			public String TopicName 
			{
				get => _topicName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topicName = value;
				}
			}

			/// <summary>
			/// The name of the topic.
			/// </summary>
			public RemainingPartition WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			private Int32 _partitionIndex = Int32.Default;
			/// <summary>
			/// The index of the partition.
			/// </summary>
			public Int32 PartitionIndex 
			{
				get => _partitionIndex;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionIndex = value;
				}
			}

			/// <summary>
			/// The index of the partition.
			/// </summary>
			public RemainingPartition WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}
		}
	}

	public class CreateAclsRequest : Message, IRespond<CreateAclsResponse>
	{
		public CreateAclsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"CreateAclsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(30);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<CreateAclsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateAclsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.CreationsCollection = await reader.ReadArrayAsync(async () => await CreatableAcl.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, CreationsCollection).ConfigureAwait(false);
			}
		}

		private CreatableAcl[] _creationsCollection = Array.Empty<CreatableAcl>();
		/// <summary>
		/// The ACLs that we want to create.
		/// </summary>
		public CreatableAcl[] CreationsCollection 
		{
			get => _creationsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"CreationsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_creationsCollection = value;
			}
		}

		/// <summary>
		/// The ACLs that we want to create.
		/// </summary>
		public CreateAclsRequest WithCreationsCollection(params Func<CreatableAcl, CreatableAcl>[] createFields)
		{
			CreationsCollection = createFields
				.Select(createField => createField(CreateCreatableAcl()))
				.ToArray();
			return this;
		}

		internal CreatableAcl CreateCreatableAcl()
		{
			return new CreatableAcl(Version);
		}

		public class CreatableAcl : ISerialize
		{
			internal CreatableAcl(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<CreatableAcl> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatableAcl(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.ResourcePatternType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Principal = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Host = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Operation = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PermissionType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourcePatternType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Principal, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Host, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(Operation, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(PermissionType, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int8 _resourceType = Int8.Default;
			/// <summary>
			/// The type of the resource.
			/// </summary>
			public Int8 ResourceType 
			{
				get => _resourceType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceType = value;
				}
			}

			/// <summary>
			/// The type of the resource.
			/// </summary>
			public CreatableAcl WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			private String _resourceName = String.Default;
			/// <summary>
			/// The resource name for the ACL.
			/// </summary>
			public String ResourceName 
			{
				get => _resourceName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceName = value;
				}
			}

			/// <summary>
			/// The resource name for the ACL.
			/// </summary>
			public CreatableAcl WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}

			private Int8 _resourcePatternType = new Int8(3);
			/// <summary>
			/// The pattern type for the ACL.
			/// </summary>
			public Int8 ResourcePatternType 
			{
				get => _resourcePatternType;
				set 
				{
					if (Version.InRange(1, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourcePatternType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
					}

					_resourcePatternType = value;
				}
			}

			/// <summary>
			/// The pattern type for the ACL.
			/// </summary>
			public CreatableAcl WithResourcePatternType(Int8 resourcePatternType)
			{
				ResourcePatternType = resourcePatternType;
				return this;
			}

			private String _principal = String.Default;
			/// <summary>
			/// The principal for the ACL.
			/// </summary>
			public String Principal 
			{
				get => _principal;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Principal does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_principal = value;
				}
			}

			/// <summary>
			/// The principal for the ACL.
			/// </summary>
			public CreatableAcl WithPrincipal(String principal)
			{
				Principal = principal;
				return this;
			}

			private String _host = String.Default;
			/// <summary>
			/// The host for the ACL.
			/// </summary>
			public String Host 
			{
				get => _host;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_host = value;
				}
			}

			/// <summary>
			/// The host for the ACL.
			/// </summary>
			public CreatableAcl WithHost(String host)
			{
				Host = host;
				return this;
			}

			private Int8 _operation = Int8.Default;
			/// <summary>
			/// The operation type for the ACL (read, write, etc.).
			/// </summary>
			public Int8 Operation 
			{
				get => _operation;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Operation does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_operation = value;
				}
			}

			/// <summary>
			/// The operation type for the ACL (read, write, etc.).
			/// </summary>
			public CreatableAcl WithOperation(Int8 operation)
			{
				Operation = operation;
				return this;
			}

			private Int8 _permissionType = Int8.Default;
			/// <summary>
			/// The permission type for the ACL (allow, deny, etc.).
			/// </summary>
			public Int8 PermissionType 
			{
				get => _permissionType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PermissionType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_permissionType = value;
				}
			}

			/// <summary>
			/// The permission type for the ACL (allow, deny, etc.).
			/// </summary>
			public CreatableAcl WithPermissionType(Int8 permissionType)
			{
				PermissionType = permissionType;
				return this;
			}
		}

		public CreateAclsResponse Respond()
			=> new CreateAclsResponse(Version);
	}

	public class CreateAclsResponse : Message
	{
		public CreateAclsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"CreateAclsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(30);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<CreateAclsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateAclsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = await reader.ReadArrayAsync(async () => await CreatableAclResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public CreateAclsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private CreatableAclResult[] _resultsCollection = Array.Empty<CreatableAclResult>();
		/// <summary>
		/// The results for each ACL creation.
		/// </summary>
		public CreatableAclResult[] ResultsCollection 
		{
			get => _resultsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resultsCollection = value;
			}
		}

		/// <summary>
		/// The results for each ACL creation.
		/// </summary>
		public CreateAclsResponse WithResultsCollection(params Func<CreatableAclResult, CreatableAclResult>[] createFields)
		{
			ResultsCollection = createFields
				.Select(createField => createField(CreateCreatableAclResult()))
				.ToArray();
			return this;
		}

		internal CreatableAclResult CreateCreatableAclResult()
		{
			return new CreatableAclResult(Version);
		}

		public class CreatableAclResult : ISerialize
		{
			internal CreatableAclResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<CreatableAclResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatableAclResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The result error, or zero if there was no error.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The result error, or zero if there was no error.
			/// </summary>
			public CreatableAclResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			private String? _errorMessage = String.Default;
			/// <summary>
			/// The result message, or null if there was no error.
			/// </summary>
			public String? ErrorMessage 
			{
				get => _errorMessage;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_errorMessage = value;
				}
			}

			/// <summary>
			/// The result message, or null if there was no error.
			/// </summary>
			public CreatableAclResult WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}
		}
	}

	public class CreateDelegationTokenRequest : Message, IRespond<CreateDelegationTokenResponse>
	{
		public CreateDelegationTokenRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"CreateDelegationTokenRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(38);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<CreateDelegationTokenRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateDelegationTokenRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.RenewersCollection = await reader.ReadArrayAsync(async () => await CreatableRenewers.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MaxLifetimeMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, RenewersCollection).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(MaxLifetimeMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private CreatableRenewers[] _renewersCollection = Array.Empty<CreatableRenewers>();
		/// <summary>
		/// A list of those who are allowed to renew this token before it expires.
		/// </summary>
		public CreatableRenewers[] RenewersCollection 
		{
			get => _renewersCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"RenewersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_renewersCollection = value;
			}
		}

		/// <summary>
		/// A list of those who are allowed to renew this token before it expires.
		/// </summary>
		public CreateDelegationTokenRequest WithRenewersCollection(params Func<CreatableRenewers, CreatableRenewers>[] createFields)
		{
			RenewersCollection = createFields
				.Select(createField => createField(CreateCreatableRenewers()))
				.ToArray();
			return this;
		}

		internal CreatableRenewers CreateCreatableRenewers()
		{
			return new CreatableRenewers(Version);
		}

		public class CreatableRenewers : ISerialize
		{
			internal CreatableRenewers(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<CreatableRenewers> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatableRenewers(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalType = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalName, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _principalType = String.Default;
			/// <summary>
			/// The type of the Kafka principal.
			/// </summary>
			public String PrincipalType 
			{
				get => _principalType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PrincipalType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_principalType = value;
				}
			}

			/// <summary>
			/// The type of the Kafka principal.
			/// </summary>
			public CreatableRenewers WithPrincipalType(String principalType)
			{
				PrincipalType = principalType;
				return this;
			}

			private String _principalName = String.Default;
			/// <summary>
			/// The name of the Kafka principal.
			/// </summary>
			public String PrincipalName 
			{
				get => _principalName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PrincipalName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_principalName = value;
				}
			}

			/// <summary>
			/// The name of the Kafka principal.
			/// </summary>
			public CreatableRenewers WithPrincipalName(String principalName)
			{
				PrincipalName = principalName;
				return this;
			}
		}

		private Int64 _maxLifetimeMs = Int64.Default;
		/// <summary>
		/// The maximum lifetime of the token in milliseconds, or -1 to use the server side default.
		/// </summary>
		public Int64 MaxLifetimeMs 
		{
			get => _maxLifetimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MaxLifetimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_maxLifetimeMs = value;
			}
		}

		/// <summary>
		/// The maximum lifetime of the token in milliseconds, or -1 to use the server side default.
		/// </summary>
		public CreateDelegationTokenRequest WithMaxLifetimeMs(Int64 maxLifetimeMs)
		{
			MaxLifetimeMs = maxLifetimeMs;
			return this;
		}

		public CreateDelegationTokenResponse Respond()
			=> new CreateDelegationTokenResponse(Version);
	}

	public class CreateDelegationTokenResponse : Message
	{
		public CreateDelegationTokenResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"CreateDelegationTokenResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(38);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<CreateDelegationTokenResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateDelegationTokenResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PrincipalType = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PrincipalName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.IssueTimestampMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ExpiryTimestampMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MaxTimestampMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TokenId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Hmac = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(PrincipalType, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(PrincipalName, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(IssueTimestampMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ExpiryTimestampMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(MaxTimestampMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(TokenId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(Hmac, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The top-level error, or zero if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The top-level error, or zero if there was no error.
		/// </summary>
		public CreateDelegationTokenResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private String _principalType = String.Default;
		/// <summary>
		/// The principal type of the token owner.
		/// </summary>
		public String PrincipalType 
		{
			get => _principalType;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"PrincipalType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_principalType = value;
			}
		}

		/// <summary>
		/// The principal type of the token owner.
		/// </summary>
		public CreateDelegationTokenResponse WithPrincipalType(String principalType)
		{
			PrincipalType = principalType;
			return this;
		}

		private String _principalName = String.Default;
		/// <summary>
		/// The name of the token owner.
		/// </summary>
		public String PrincipalName 
		{
			get => _principalName;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"PrincipalName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_principalName = value;
			}
		}

		/// <summary>
		/// The name of the token owner.
		/// </summary>
		public CreateDelegationTokenResponse WithPrincipalName(String principalName)
		{
			PrincipalName = principalName;
			return this;
		}

		private Int64 _issueTimestampMs = Int64.Default;
		/// <summary>
		/// When this token was generated.
		/// </summary>
		public Int64 IssueTimestampMs 
		{
			get => _issueTimestampMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"IssueTimestampMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_issueTimestampMs = value;
			}
		}

		/// <summary>
		/// When this token was generated.
		/// </summary>
		public CreateDelegationTokenResponse WithIssueTimestampMs(Int64 issueTimestampMs)
		{
			IssueTimestampMs = issueTimestampMs;
			return this;
		}

		private Int64 _expiryTimestampMs = Int64.Default;
		/// <summary>
		/// When this token expires.
		/// </summary>
		public Int64 ExpiryTimestampMs 
		{
			get => _expiryTimestampMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ExpiryTimestampMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_expiryTimestampMs = value;
			}
		}

		/// <summary>
		/// When this token expires.
		/// </summary>
		public CreateDelegationTokenResponse WithExpiryTimestampMs(Int64 expiryTimestampMs)
		{
			ExpiryTimestampMs = expiryTimestampMs;
			return this;
		}

		private Int64 _maxTimestampMs = Int64.Default;
		/// <summary>
		/// The maximum lifetime of this token.
		/// </summary>
		public Int64 MaxTimestampMs 
		{
			get => _maxTimestampMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MaxTimestampMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_maxTimestampMs = value;
			}
		}

		/// <summary>
		/// The maximum lifetime of this token.
		/// </summary>
		public CreateDelegationTokenResponse WithMaxTimestampMs(Int64 maxTimestampMs)
		{
			MaxTimestampMs = maxTimestampMs;
			return this;
		}

		private String _tokenId = String.Default;
		/// <summary>
		/// The token UUID.
		/// </summary>
		public String TokenId 
		{
			get => _tokenId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TokenId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_tokenId = value;
			}
		}

		/// <summary>
		/// The token UUID.
		/// </summary>
		public CreateDelegationTokenResponse WithTokenId(String tokenId)
		{
			TokenId = tokenId;
			return this;
		}

		private Bytes _hmac = Bytes.Default;
		/// <summary>
		/// HMAC of the delegation token.
		/// </summary>
		public Bytes Hmac 
		{
			get => _hmac;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Hmac does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_hmac = value;
			}
		}

		/// <summary>
		/// HMAC of the delegation token.
		/// </summary>
		public CreateDelegationTokenResponse WithHmac(Bytes hmac)
		{
			Hmac = hmac;
			return this;
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public CreateDelegationTokenResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class CreatePartitionsRequest : Message, IRespond<CreatePartitionsResponse>
	{
		public CreatePartitionsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"CreatePartitionsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(37);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<CreatePartitionsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreatePartitionsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await CreatePartitionsTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ValidateOnly = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBooleanAsync(ValidateOnly, cancellationToken).ConfigureAwait(false);
			}
		}

		private CreatePartitionsTopic[] _topicsCollection = Array.Empty<CreatePartitionsTopic>();
		/// <summary>
		/// Each topic that we want to create new partitions inside.
		/// </summary>
		public CreatePartitionsTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic that we want to create new partitions inside.
		/// </summary>
		public CreatePartitionsRequest WithTopicsCollection(params Func<CreatePartitionsTopic, CreatePartitionsTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateCreatePartitionsTopic()))
				.ToArray();
			return this;
		}

		internal CreatePartitionsTopic CreateCreatePartitionsTopic()
		{
			return new CreatePartitionsTopic(Version);
		}

		public class CreatePartitionsTopic : ISerialize
		{
			internal CreatePartitionsTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<CreatePartitionsTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatePartitionsTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Count = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.AssignmentsCollection = await reader.ReadNullableArrayAsync(async () => await CreatePartitionsAssignment.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(Count, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableArrayAsync(cancellationToken, AssignmentsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public CreatePartitionsTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private Int32 _count = Int32.Default;
			/// <summary>
			/// The new partition count.
			/// </summary>
			public Int32 Count 
			{
				get => _count;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Count does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_count = value;
				}
			}

			/// <summary>
			/// The new partition count.
			/// </summary>
			public CreatePartitionsTopic WithCount(Int32 count)
			{
				Count = count;
				return this;
			}

			private CreatePartitionsAssignment[]? _assignmentsCollection = Array.Empty<CreatePartitionsAssignment>();
			/// <summary>
			/// The new partition assignments.
			/// </summary>
			public CreatePartitionsAssignment[]? AssignmentsCollection 
			{
				get => _assignmentsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"AssignmentsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"AssignmentsCollection does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_assignmentsCollection = value;
				}
			}

			/// <summary>
			/// The new partition assignments.
			/// </summary>
			public CreatePartitionsTopic WithAssignmentsCollection(params Func<CreatePartitionsAssignment, CreatePartitionsAssignment>[] createFields)
			{
				AssignmentsCollection = createFields
					.Select(createField => createField(CreateCreatePartitionsAssignment()))
					.ToArray();
				return this;
			}

			internal CreatePartitionsAssignment CreateCreatePartitionsAssignment()
			{
				return new CreatePartitionsAssignment(Version);
			}

			public class CreatePartitionsAssignment : ISerialize
			{
				internal CreatePartitionsAssignment(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<CreatePartitionsAssignment> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new CreatePartitionsAssignment(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.BrokerIdsCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, BrokerIdsCollection).ConfigureAwait(false);
					}
				}

				private Int32[] _brokerIdsCollection = Array.Empty<Int32>();
				/// <summary>
				/// The assigned broker IDs.
				/// </summary>
				public Int32[] BrokerIdsCollection 
				{
					get => _brokerIdsCollection;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"BrokerIdsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_brokerIdsCollection = value;
					}
				}

				/// <summary>
				/// The assigned broker IDs.
				/// </summary>
				public CreatePartitionsAssignment WithBrokerIdsCollection(Int32[] brokerIdsCollection)
				{
					BrokerIdsCollection = brokerIdsCollection;
					return this;
				}
			}
		}

		private Int32 _timeoutMs = Int32.Default;
		/// <summary>
		/// The time in ms to wait for the partitions to be created.
		/// </summary>
		public Int32 TimeoutMs 
		{
			get => _timeoutMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TimeoutMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_timeoutMs = value;
			}
		}

		/// <summary>
		/// The time in ms to wait for the partitions to be created.
		/// </summary>
		public CreatePartitionsRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}

		private Boolean _validateOnly = Boolean.Default;
		/// <summary>
		/// If true, then validate the request, but don't actually increase the number of partitions.
		/// </summary>
		public Boolean ValidateOnly 
		{
			get => _validateOnly;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ValidateOnly does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_validateOnly = value;
			}
		}

		/// <summary>
		/// If true, then validate the request, but don't actually increase the number of partitions.
		/// </summary>
		public CreatePartitionsRequest WithValidateOnly(Boolean validateOnly)
		{
			ValidateOnly = validateOnly;
			return this;
		}

		public CreatePartitionsResponse Respond()
			=> new CreatePartitionsResponse(Version);
	}

	public class CreatePartitionsResponse : Message
	{
		public CreatePartitionsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"CreatePartitionsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(37);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<CreatePartitionsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreatePartitionsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = await reader.ReadArrayAsync(async () => await CreatePartitionsTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public CreatePartitionsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private CreatePartitionsTopicResult[] _resultsCollection = Array.Empty<CreatePartitionsTopicResult>();
		/// <summary>
		/// The partition creation results for each topic.
		/// </summary>
		public CreatePartitionsTopicResult[] ResultsCollection 
		{
			get => _resultsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resultsCollection = value;
			}
		}

		/// <summary>
		/// The partition creation results for each topic.
		/// </summary>
		public CreatePartitionsResponse WithResultsCollection(params Func<CreatePartitionsTopicResult, CreatePartitionsTopicResult>[] createFields)
		{
			ResultsCollection = createFields
				.Select(createField => createField(CreateCreatePartitionsTopicResult()))
				.ToArray();
			return this;
		}

		internal CreatePartitionsTopicResult CreateCreatePartitionsTopicResult()
		{
			return new CreatePartitionsTopicResult(Version);
		}

		public class CreatePartitionsTopicResult : ISerialize
		{
			internal CreatePartitionsTopicResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<CreatePartitionsTopicResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatePartitionsTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public CreatePartitionsTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The result error, or zero if there was no error.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The result error, or zero if there was no error.
			/// </summary>
			public CreatePartitionsTopicResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			private String? _errorMessage = String.Default;
			/// <summary>
			/// The result message, or null if there was no error.
			/// </summary>
			public String? ErrorMessage 
			{
				get => _errorMessage;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_errorMessage = value;
				}
			}

			/// <summary>
			/// The result message, or null if there was no error.
			/// </summary>
			public CreatePartitionsTopicResult WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}
		}
	}

	public class CreateTopicsRequest : Message, IRespond<CreateTopicsResponse>
	{
		public CreateTopicsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"CreateTopicsRequest does not support version {version}. Valid versions are: 0-4");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(19);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(4);

		public override Int16 Version { get; }

		public static async ValueTask<CreateTopicsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateTopicsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = (await reader.ReadArrayAsync(async () => await CreatableTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ValidateOnly = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection.Values.ToArray()).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteBooleanAsync(ValidateOnly, cancellationToken).ConfigureAwait(false);
			}
		}

		private Dictionary<String, CreatableTopic> _topicsCollection = new Dictionary<String, CreatableTopic>();
		/// <summary>
		/// The topics to create.
		/// </summary>
		public Dictionary<String, CreatableTopic> TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// The topics to create.
		/// </summary>
		public CreateTopicsRequest WithTopicsCollection(params Func<CreatableTopic, CreatableTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateCreatableTopic()))
				.ToDictionary(field => field.Name);
			return this;
		}

		internal CreatableTopic CreateCreatableTopic()
		{
			return new CreatableTopic(Version);
		}

		public class CreatableTopic : ISerialize
		{
			internal CreatableTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<CreatableTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatableTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.NumPartitions = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ReplicationFactor = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.AssignmentsCollection = (await reader.ReadArrayAsync(async () => await CreatableReplicaAssignment.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.PartitionIndex);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ConfigsCollection = (await reader.ReadArrayAsync(async () => await CreateableTopicConfig.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(NumPartitions, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ReplicationFactor, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, AssignmentsCollection.Values.ToArray()).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ConfigsCollection.Values.ToArray()).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public CreatableTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private Int32 _numPartitions = Int32.Default;
			/// <summary>
			/// The number of partitions to create in the topic, or -1 if we are either specifying a manual partition assignment or using the default partitions.
			/// </summary>
			public Int32 NumPartitions 
			{
				get => _numPartitions;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"NumPartitions does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_numPartitions = value;
				}
			}

			/// <summary>
			/// The number of partitions to create in the topic, or -1 if we are either specifying a manual partition assignment or using the default partitions.
			/// </summary>
			public CreatableTopic WithNumPartitions(Int32 numPartitions)
			{
				NumPartitions = numPartitions;
				return this;
			}

			private Int16 _replicationFactor = Int16.Default;
			/// <summary>
			/// The number of replicas to create for each partition in the topic, or -1 if we are either specifying a manual partition assignment or using the default replication factor.
			/// </summary>
			public Int16 ReplicationFactor 
			{
				get => _replicationFactor;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ReplicationFactor does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_replicationFactor = value;
				}
			}

			/// <summary>
			/// The number of replicas to create for each partition in the topic, or -1 if we are either specifying a manual partition assignment or using the default replication factor.
			/// </summary>
			public CreatableTopic WithReplicationFactor(Int16 replicationFactor)
			{
				ReplicationFactor = replicationFactor;
				return this;
			}

			private Dictionary<Int32, CreatableReplicaAssignment> _assignmentsCollection = new Dictionary<Int32, CreatableReplicaAssignment>();
			/// <summary>
			/// The manual partition assignment, or the empty array if we are using automatic assignment.
			/// </summary>
			public Dictionary<Int32, CreatableReplicaAssignment> AssignmentsCollection 
			{
				get => _assignmentsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"AssignmentsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_assignmentsCollection = value;
				}
			}

			/// <summary>
			/// The manual partition assignment, or the empty array if we are using automatic assignment.
			/// </summary>
			public CreatableTopic WithAssignmentsCollection(params Func<CreatableReplicaAssignment, CreatableReplicaAssignment>[] createFields)
			{
				AssignmentsCollection = createFields
					.Select(createField => createField(CreateCreatableReplicaAssignment()))
					.ToDictionary(field => field.PartitionIndex);
				return this;
			}

			internal CreatableReplicaAssignment CreateCreatableReplicaAssignment()
			{
				return new CreatableReplicaAssignment(Version);
			}

			public class CreatableReplicaAssignment : ISerialize
			{
				internal CreatableReplicaAssignment(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<CreatableReplicaAssignment> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new CreatableReplicaAssignment(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.BrokerIdsCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, BrokerIdsCollection).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public CreatableReplicaAssignment WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int32[] _brokerIdsCollection = Array.Empty<Int32>();
				/// <summary>
				/// The brokers to place the partition on.
				/// </summary>
				public Int32[] BrokerIdsCollection 
				{
					get => _brokerIdsCollection;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"BrokerIdsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_brokerIdsCollection = value;
					}
				}

				/// <summary>
				/// The brokers to place the partition on.
				/// </summary>
				public CreatableReplicaAssignment WithBrokerIdsCollection(Int32[] brokerIdsCollection)
				{
					BrokerIdsCollection = brokerIdsCollection;
					return this;
				}
			}

			private Dictionary<String, CreateableTopicConfig> _configsCollection = new Dictionary<String, CreateableTopicConfig>();
			/// <summary>
			/// The custom topic configurations to set.
			/// </summary>
			public Dictionary<String, CreateableTopicConfig> ConfigsCollection 
			{
				get => _configsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ConfigsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_configsCollection = value;
				}
			}

			/// <summary>
			/// The custom topic configurations to set.
			/// </summary>
			public CreatableTopic WithConfigsCollection(params Func<CreateableTopicConfig, CreateableTopicConfig>[] createFields)
			{
				ConfigsCollection = createFields
					.Select(createField => createField(CreateCreateableTopicConfig()))
					.ToDictionary(field => field.Name);
				return this;
			}

			internal CreateableTopicConfig CreateCreateableTopicConfig()
			{
				return new CreateableTopicConfig(Version);
			}

			public class CreateableTopicConfig : ISerialize
			{
				internal CreateableTopicConfig(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<CreateableTopicConfig> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new CreateableTopicConfig(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Value = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(Value, cancellationToken).ConfigureAwait(false);
					}
				}

				private String _name = String.Default;
				/// <summary>
				/// The configuration name.
				/// </summary>
				public String Name 
				{
					get => _name;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_name = value;
					}
				}

				/// <summary>
				/// The configuration name.
				/// </summary>
				public CreateableTopicConfig WithName(String name)
				{
					Name = name;
					return this;
				}

				private String? _value = String.Default;
				/// <summary>
				/// The configuration value.
				/// </summary>
				public String? Value 
				{
					get => _value;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Value does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"Value does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_value = value;
					}
				}

				/// <summary>
				/// The configuration value.
				/// </summary>
				public CreateableTopicConfig WithValue(String value)
				{
					Value = value;
					return this;
				}
			}
		}

		private Int32 _timeoutMs = new Int32(60000);
		/// <summary>
		/// How long to wait in milliseconds before timing out the request.
		/// </summary>
		public Int32 TimeoutMs 
		{
			get => _timeoutMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TimeoutMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_timeoutMs = value;
			}
		}

		/// <summary>
		/// How long to wait in milliseconds before timing out the request.
		/// </summary>
		public CreateTopicsRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}

		private Boolean _validateOnly = new Boolean(false);
		/// <summary>
		/// If true, check that the topics can be created as specified, but don't create anything.
		/// </summary>
		public Boolean ValidateOnly 
		{
			get => _validateOnly;
			set 
			{
				if (Version.InRange(1, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ValidateOnly does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
				}

				_validateOnly = value;
			}
		}

		/// <summary>
		/// If true, check that the topics can be created as specified, but don't create anything.
		/// </summary>
		public CreateTopicsRequest WithValidateOnly(Boolean validateOnly)
		{
			ValidateOnly = validateOnly;
			return this;
		}

		public CreateTopicsResponse Respond()
			=> new CreateTopicsResponse(Version);
	}

	public class CreateTopicsResponse : Message
	{
		public CreateTopicsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"CreateTopicsResponse does not support version {version}. Valid versions are: 0-4");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(19);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(4);

		public override Int16 Version { get; }

		public static async ValueTask<CreateTopicsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateTopicsResponse(version);
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = (await reader.ReadArrayAsync(async () => await CreatableTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection.Values.ToArray()).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public CreateTopicsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Dictionary<String, CreatableTopicResult> _topicsCollection = new Dictionary<String, CreatableTopicResult>();
		/// <summary>
		/// Results for each topic we tried to create.
		/// </summary>
		public Dictionary<String, CreatableTopicResult> TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Results for each topic we tried to create.
		/// </summary>
		public CreateTopicsResponse WithTopicsCollection(params Func<CreatableTopicResult, CreatableTopicResult>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateCreatableTopicResult()))
				.ToDictionary(field => field.Name);
			return this;
		}

		internal CreatableTopicResult CreateCreatableTopicResult()
		{
			return new CreatableTopicResult(Version);
		}

		public class CreatableTopicResult : ISerialize
		{
			internal CreatableTopicResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<CreatableTopicResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatableTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public CreatableTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The error code, or 0 if there was no error.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The error code, or 0 if there was no error.
			/// </summary>
			public CreatableTopicResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			private String? _errorMessage = String.Default;
			/// <summary>
			/// The error message, or null if there was no error.
			/// </summary>
			public String? ErrorMessage 
			{
				get => _errorMessage;
				set 
				{
					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_errorMessage = value;
				}
			}

			/// <summary>
			/// The error message, or null if there was no error.
			/// </summary>
			public CreatableTopicResult WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}
		}
	}

	public class DeleteAclsRequest : Message, IRespond<DeleteAclsResponse>
	{
		public DeleteAclsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DeleteAclsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(31);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DeleteAclsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteAclsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.FiltersCollection = await reader.ReadArrayAsync(async () => await DeleteAclsFilter.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, FiltersCollection).ConfigureAwait(false);
			}
		}

		private DeleteAclsFilter[] _filtersCollection = Array.Empty<DeleteAclsFilter>();
		/// <summary>
		/// The filters to use when deleting ACLs.
		/// </summary>
		public DeleteAclsFilter[] FiltersCollection 
		{
			get => _filtersCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"FiltersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_filtersCollection = value;
			}
		}

		/// <summary>
		/// The filters to use when deleting ACLs.
		/// </summary>
		public DeleteAclsRequest WithFiltersCollection(params Func<DeleteAclsFilter, DeleteAclsFilter>[] createFields)
		{
			FiltersCollection = createFields
				.Select(createField => createField(CreateDeleteAclsFilter()))
				.ToArray();
			return this;
		}

		internal DeleteAclsFilter CreateDeleteAclsFilter()
		{
			return new DeleteAclsFilter(Version);
		}

		public class DeleteAclsFilter : ISerialize
		{
			internal DeleteAclsFilter(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DeleteAclsFilter> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeleteAclsFilter(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceTypeFilter = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceNameFilter = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.PatternTypeFilter = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalFilter = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.HostFilter = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Operation = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PermissionType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceTypeFilter, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ResourceNameFilter, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteInt8Async(PatternTypeFilter, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(PrincipalFilter, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(HostFilter, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(Operation, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(PermissionType, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int8 _resourceTypeFilter = Int8.Default;
			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceTypeFilter 
			{
				get => _resourceTypeFilter;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceTypeFilter does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceTypeFilter = value;
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public DeleteAclsFilter WithResourceTypeFilter(Int8 resourceTypeFilter)
			{
				ResourceTypeFilter = resourceTypeFilter;
				return this;
			}

			private String? _resourceNameFilter = String.Default;
			/// <summary>
			/// The resource name.
			/// </summary>
			public String? ResourceNameFilter 
			{
				get => _resourceNameFilter;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceNameFilter does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"ResourceNameFilter does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_resourceNameFilter = value;
				}
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			public DeleteAclsFilter WithResourceNameFilter(String resourceNameFilter)
			{
				ResourceNameFilter = resourceNameFilter;
				return this;
			}

			private Int8 _patternTypeFilter = new Int8(3);
			/// <summary>
			/// The pattern type.
			/// </summary>
			public Int8 PatternTypeFilter 
			{
				get => _patternTypeFilter;
				set 
				{
					if (Version.InRange(1, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PatternTypeFilter does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
					}

					_patternTypeFilter = value;
				}
			}

			/// <summary>
			/// The pattern type.
			/// </summary>
			public DeleteAclsFilter WithPatternTypeFilter(Int8 patternTypeFilter)
			{
				PatternTypeFilter = patternTypeFilter;
				return this;
			}

			private String? _principalFilter = String.Default;
			/// <summary>
			/// The principal filter, or null to accept all principals.
			/// </summary>
			public String? PrincipalFilter 
			{
				get => _principalFilter;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PrincipalFilter does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"PrincipalFilter does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_principalFilter = value;
				}
			}

			/// <summary>
			/// The principal filter, or null to accept all principals.
			/// </summary>
			public DeleteAclsFilter WithPrincipalFilter(String principalFilter)
			{
				PrincipalFilter = principalFilter;
				return this;
			}

			private String? _hostFilter = String.Default;
			/// <summary>
			/// The host filter, or null to accept all hosts.
			/// </summary>
			public String? HostFilter 
			{
				get => _hostFilter;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"HostFilter does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"HostFilter does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_hostFilter = value;
				}
			}

			/// <summary>
			/// The host filter, or null to accept all hosts.
			/// </summary>
			public DeleteAclsFilter WithHostFilter(String hostFilter)
			{
				HostFilter = hostFilter;
				return this;
			}

			private Int8 _operation = Int8.Default;
			/// <summary>
			/// The ACL operation.
			/// </summary>
			public Int8 Operation 
			{
				get => _operation;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Operation does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_operation = value;
				}
			}

			/// <summary>
			/// The ACL operation.
			/// </summary>
			public DeleteAclsFilter WithOperation(Int8 operation)
			{
				Operation = operation;
				return this;
			}

			private Int8 _permissionType = Int8.Default;
			/// <summary>
			/// The permission type.
			/// </summary>
			public Int8 PermissionType 
			{
				get => _permissionType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PermissionType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_permissionType = value;
				}
			}

			/// <summary>
			/// The permission type.
			/// </summary>
			public DeleteAclsFilter WithPermissionType(Int8 permissionType)
			{
				PermissionType = permissionType;
				return this;
			}
		}

		public DeleteAclsResponse Respond()
			=> new DeleteAclsResponse(Version);
	}

	public class DeleteAclsResponse : Message
	{
		public DeleteAclsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DeleteAclsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(31);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DeleteAclsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteAclsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.FilterResultsCollection = await reader.ReadArrayAsync(async () => await DeleteAclsFilterResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, FilterResultsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public DeleteAclsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private DeleteAclsFilterResult[] _filterResultsCollection = Array.Empty<DeleteAclsFilterResult>();
		/// <summary>
		/// The results for each filter.
		/// </summary>
		public DeleteAclsFilterResult[] FilterResultsCollection 
		{
			get => _filterResultsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"FilterResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_filterResultsCollection = value;
			}
		}

		/// <summary>
		/// The results for each filter.
		/// </summary>
		public DeleteAclsResponse WithFilterResultsCollection(params Func<DeleteAclsFilterResult, DeleteAclsFilterResult>[] createFields)
		{
			FilterResultsCollection = createFields
				.Select(createField => createField(CreateDeleteAclsFilterResult()))
				.ToArray();
			return this;
		}

		internal DeleteAclsFilterResult CreateDeleteAclsFilterResult()
		{
			return new DeleteAclsFilterResult(Version);
		}

		public class DeleteAclsFilterResult : ISerialize
		{
			internal DeleteAclsFilterResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DeleteAclsFilterResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeleteAclsFilterResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MatchingAclsCollection = await reader.ReadArrayAsync(async () => await DeleteAclsMatchingAcl.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, MatchingAclsCollection).ConfigureAwait(false);
				}
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The error code, or 0 if the filter succeeded.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The error code, or 0 if the filter succeeded.
			/// </summary>
			public DeleteAclsFilterResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			private String? _errorMessage = String.Default;
			/// <summary>
			/// The error message, or null if the filter succeeded.
			/// </summary>
			public String? ErrorMessage 
			{
				get => _errorMessage;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_errorMessage = value;
				}
			}

			/// <summary>
			/// The error message, or null if the filter succeeded.
			/// </summary>
			public DeleteAclsFilterResult WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}

			private DeleteAclsMatchingAcl[] _matchingAclsCollection = Array.Empty<DeleteAclsMatchingAcl>();
			/// <summary>
			/// The ACLs which matched this filter.
			/// </summary>
			public DeleteAclsMatchingAcl[] MatchingAclsCollection 
			{
				get => _matchingAclsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"MatchingAclsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_matchingAclsCollection = value;
				}
			}

			/// <summary>
			/// The ACLs which matched this filter.
			/// </summary>
			public DeleteAclsFilterResult WithMatchingAclsCollection(params Func<DeleteAclsMatchingAcl, DeleteAclsMatchingAcl>[] createFields)
			{
				MatchingAclsCollection = createFields
					.Select(createField => createField(CreateDeleteAclsMatchingAcl()))
					.ToArray();
				return this;
			}

			internal DeleteAclsMatchingAcl CreateDeleteAclsMatchingAcl()
			{
				return new DeleteAclsMatchingAcl(Version);
			}

			public class DeleteAclsMatchingAcl : ISerialize
			{
				internal DeleteAclsMatchingAcl(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<DeleteAclsMatchingAcl> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DeleteAclsMatchingAcl(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ResourceType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ResourceName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.PatternType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Principal = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Host = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Operation = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PermissionType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(ResourceType, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(ResourceName, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt8Async(PatternType, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Principal, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Host, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(Operation, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(PermissionType, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The deletion error code, or 0 if the deletion succeeded.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The deletion error code, or 0 if the deletion succeeded.
				/// </summary>
				public DeleteAclsMatchingAcl WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				private String? _errorMessage = String.Default;
				/// <summary>
				/// The deletion error message, or null if the deletion succeeded.
				/// </summary>
				public String? ErrorMessage 
				{
					get => _errorMessage;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_errorMessage = value;
					}
				}

				/// <summary>
				/// The deletion error message, or null if the deletion succeeded.
				/// </summary>
				public DeleteAclsMatchingAcl WithErrorMessage(String errorMessage)
				{
					ErrorMessage = errorMessage;
					return this;
				}

				private Int8 _resourceType = Int8.Default;
				/// <summary>
				/// The ACL resource type.
				/// </summary>
				public Int8 ResourceType 
				{
					get => _resourceType;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ResourceType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_resourceType = value;
					}
				}

				/// <summary>
				/// The ACL resource type.
				/// </summary>
				public DeleteAclsMatchingAcl WithResourceType(Int8 resourceType)
				{
					ResourceType = resourceType;
					return this;
				}

				private String _resourceName = String.Default;
				/// <summary>
				/// The ACL resource name.
				/// </summary>
				public String ResourceName 
				{
					get => _resourceName;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ResourceName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_resourceName = value;
					}
				}

				/// <summary>
				/// The ACL resource name.
				/// </summary>
				public DeleteAclsMatchingAcl WithResourceName(String resourceName)
				{
					ResourceName = resourceName;
					return this;
				}

				private Int8 _patternType = new Int8(3);
				/// <summary>
				/// The ACL resource pattern type.
				/// </summary>
				public Int8 PatternType 
				{
					get => _patternType;
					set 
					{
						if (Version.InRange(1, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PatternType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
						}

						_patternType = value;
					}
				}

				/// <summary>
				/// The ACL resource pattern type.
				/// </summary>
				public DeleteAclsMatchingAcl WithPatternType(Int8 patternType)
				{
					PatternType = patternType;
					return this;
				}

				private String _principal = String.Default;
				/// <summary>
				/// The ACL principal.
				/// </summary>
				public String Principal 
				{
					get => _principal;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Principal does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_principal = value;
					}
				}

				/// <summary>
				/// The ACL principal.
				/// </summary>
				public DeleteAclsMatchingAcl WithPrincipal(String principal)
				{
					Principal = principal;
					return this;
				}

				private String _host = String.Default;
				/// <summary>
				/// The ACL host.
				/// </summary>
				public String Host 
				{
					get => _host;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_host = value;
					}
				}

				/// <summary>
				/// The ACL host.
				/// </summary>
				public DeleteAclsMatchingAcl WithHost(String host)
				{
					Host = host;
					return this;
				}

				private Int8 _operation = Int8.Default;
				/// <summary>
				/// The ACL operation.
				/// </summary>
				public Int8 Operation 
				{
					get => _operation;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Operation does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_operation = value;
					}
				}

				/// <summary>
				/// The ACL operation.
				/// </summary>
				public DeleteAclsMatchingAcl WithOperation(Int8 operation)
				{
					Operation = operation;
					return this;
				}

				private Int8 _permissionType = Int8.Default;
				/// <summary>
				/// The ACL permission type.
				/// </summary>
				public Int8 PermissionType 
				{
					get => _permissionType;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PermissionType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_permissionType = value;
					}
				}

				/// <summary>
				/// The ACL permission type.
				/// </summary>
				public DeleteAclsMatchingAcl WithPermissionType(Int8 permissionType)
				{
					PermissionType = permissionType;
					return this;
				}
			}
		}
	}

	public class DeleteGroupsRequest : Message, IRespond<DeleteGroupsResponse>
	{
		public DeleteGroupsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DeleteGroupsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(42);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DeleteGroupsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteGroupsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupsNamesCollection = await reader.ReadArrayAsync(async () => await String.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, GroupsNamesCollection).ConfigureAwait(false);
			}
		}

		private String[] _groupsNamesCollection = Array.Empty<String>();
		/// <summary>
		/// The group names to delete.
		/// </summary>
		public String[] GroupsNamesCollection 
		{
			get => _groupsNamesCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupsNamesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupsNamesCollection = value;
			}
		}

		/// <summary>
		/// The group names to delete.
		/// </summary>
		public DeleteGroupsRequest WithGroupsNamesCollection(String[] groupsNamesCollection)
		{
			GroupsNamesCollection = groupsNamesCollection;
			return this;
		}

		public DeleteGroupsResponse Respond()
			=> new DeleteGroupsResponse(Version);
	}

	public class DeleteGroupsResponse : Message
	{
		public DeleteGroupsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DeleteGroupsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(42);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DeleteGroupsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteGroupsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = (await reader.ReadArrayAsync(async () => await DeletableGroupResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.GroupId);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection.Values.ToArray()).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public DeleteGroupsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Dictionary<String, DeletableGroupResult> _resultsCollection = new Dictionary<String, DeletableGroupResult>();
		/// <summary>
		/// The deletion results
		/// </summary>
		public Dictionary<String, DeletableGroupResult> ResultsCollection 
		{
			get => _resultsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resultsCollection = value;
			}
		}

		/// <summary>
		/// The deletion results
		/// </summary>
		public DeleteGroupsResponse WithResultsCollection(params Func<DeletableGroupResult, DeletableGroupResult>[] createFields)
		{
			ResultsCollection = createFields
				.Select(createField => createField(CreateDeletableGroupResult()))
				.ToDictionary(field => field.GroupId);
			return this;
		}

		internal DeletableGroupResult CreateDeletableGroupResult()
		{
			return new DeletableGroupResult(Version);
		}

		public class DeletableGroupResult : ISerialize
		{
			internal DeletableGroupResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DeletableGroupResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeletableGroupResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _groupId = String.Default;
			/// <summary>
			/// The group id
			/// </summary>
			public String GroupId 
			{
				get => _groupId;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_groupId = value;
				}
			}

			/// <summary>
			/// The group id
			/// </summary>
			public DeletableGroupResult WithGroupId(String groupId)
			{
				GroupId = groupId;
				return this;
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The deletion error, or 0 if the deletion succeeded.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The deletion error, or 0 if the deletion succeeded.
			/// </summary>
			public DeletableGroupResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}
		}
	}

	public class DeleteRecordsRequest : Message, IRespond<DeleteRecordsResponse>
	{
		public DeleteRecordsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DeleteRecordsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(21);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DeleteRecordsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteRecordsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await DeleteRecordsTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private DeleteRecordsTopic[] _topicsCollection = Array.Empty<DeleteRecordsTopic>();
		/// <summary>
		/// Each topic that we want to delete records from.
		/// </summary>
		public DeleteRecordsTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic that we want to delete records from.
		/// </summary>
		public DeleteRecordsRequest WithTopicsCollection(params Func<DeleteRecordsTopic, DeleteRecordsTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateDeleteRecordsTopic()))
				.ToArray();
			return this;
		}

		internal DeleteRecordsTopic CreateDeleteRecordsTopic()
		{
			return new DeleteRecordsTopic(Version);
		}

		public class DeleteRecordsTopic : ISerialize
		{
			internal DeleteRecordsTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DeleteRecordsTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeleteRecordsTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await DeleteRecordsPartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public DeleteRecordsTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private DeleteRecordsPartition[] _partitionsCollection = Array.Empty<DeleteRecordsPartition>();
			/// <summary>
			/// Each partition that we want to delete records from.
			/// </summary>
			public DeleteRecordsPartition[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// Each partition that we want to delete records from.
			/// </summary>
			public DeleteRecordsTopic WithPartitionsCollection(params Func<DeleteRecordsPartition, DeleteRecordsPartition>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateDeleteRecordsPartition()))
					.ToArray();
				return this;
			}

			internal DeleteRecordsPartition CreateDeleteRecordsPartition()
			{
				return new DeleteRecordsPartition(Version);
			}

			public class DeleteRecordsPartition : ISerialize
			{
				internal DeleteRecordsPartition(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<DeleteRecordsPartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DeleteRecordsPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Offset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(Offset, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public DeleteRecordsPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int64 _offset = Int64.Default;
				/// <summary>
				/// The deletion offset.
				/// </summary>
				public Int64 Offset 
				{
					get => _offset;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Offset does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_offset = value;
					}
				}

				/// <summary>
				/// The deletion offset.
				/// </summary>
				public DeleteRecordsPartition WithOffset(Int64 offset)
				{
					Offset = offset;
					return this;
				}
			}
		}

		private Int32 _timeoutMs = Int32.Default;
		/// <summary>
		/// How long to wait for the deletion to complete, in milliseconds.
		/// </summary>
		public Int32 TimeoutMs 
		{
			get => _timeoutMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TimeoutMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_timeoutMs = value;
			}
		}

		/// <summary>
		/// How long to wait for the deletion to complete, in milliseconds.
		/// </summary>
		public DeleteRecordsRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}

		public DeleteRecordsResponse Respond()
			=> new DeleteRecordsResponse(Version);
	}

	public class DeleteRecordsResponse : Message
	{
		public DeleteRecordsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DeleteRecordsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(21);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DeleteRecordsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteRecordsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await DeleteRecordsTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public DeleteRecordsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private DeleteRecordsTopicResult[] _topicsCollection = Array.Empty<DeleteRecordsTopicResult>();
		/// <summary>
		/// Each topic that we wanted to delete records from.
		/// </summary>
		public DeleteRecordsTopicResult[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic that we wanted to delete records from.
		/// </summary>
		public DeleteRecordsResponse WithTopicsCollection(params Func<DeleteRecordsTopicResult, DeleteRecordsTopicResult>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateDeleteRecordsTopicResult()))
				.ToArray();
			return this;
		}

		internal DeleteRecordsTopicResult CreateDeleteRecordsTopicResult()
		{
			return new DeleteRecordsTopicResult(Version);
		}

		public class DeleteRecordsTopicResult : ISerialize
		{
			internal DeleteRecordsTopicResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DeleteRecordsTopicResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeleteRecordsTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await DeleteRecordsPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public DeleteRecordsTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			private DeleteRecordsPartitionResult[] _partitionsCollection = Array.Empty<DeleteRecordsPartitionResult>();
			/// <summary>
			/// Each partition that we wanted to delete records from.
			/// </summary>
			public DeleteRecordsPartitionResult[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// Each partition that we wanted to delete records from.
			/// </summary>
			public DeleteRecordsTopicResult WithPartitionsCollection(params Func<DeleteRecordsPartitionResult, DeleteRecordsPartitionResult>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateDeleteRecordsPartitionResult()))
					.ToArray();
				return this;
			}

			internal DeleteRecordsPartitionResult CreateDeleteRecordsPartitionResult()
			{
				return new DeleteRecordsPartitionResult(Version);
			}

			public class DeleteRecordsPartitionResult : ISerialize
			{
				internal DeleteRecordsPartitionResult(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<DeleteRecordsPartitionResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DeleteRecordsPartitionResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.LowWatermark = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(LowWatermark, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public DeleteRecordsPartitionResult WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int64 _lowWatermark = Int64.Default;
				/// <summary>
				/// The partition low water mark.
				/// </summary>
				public Int64 LowWatermark 
				{
					get => _lowWatermark;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"LowWatermark does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_lowWatermark = value;
					}
				}

				/// <summary>
				/// The partition low water mark.
				/// </summary>
				public DeleteRecordsPartitionResult WithLowWatermark(Int64 lowWatermark)
				{
					LowWatermark = lowWatermark;
					return this;
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The deletion error code, or 0 if the deletion succeeded.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The deletion error code, or 0 if the deletion succeeded.
				/// </summary>
				public DeleteRecordsPartitionResult WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}
	}

	public class DeleteTopicsRequest : Message, IRespond<DeleteTopicsResponse>
	{
		public DeleteTopicsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DeleteTopicsRequest does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(20);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(3);

		public override Int16 Version { get; }

		public static async ValueTask<DeleteTopicsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteTopicsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicNamesCollection = await reader.ReadArrayAsync(async () => await String.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicNamesCollection).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private String[] _topicNamesCollection = Array.Empty<String>();
		/// <summary>
		/// The names of the topics to delete
		/// </summary>
		public String[] TopicNamesCollection 
		{
			get => _topicNamesCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicNamesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicNamesCollection = value;
			}
		}

		/// <summary>
		/// The names of the topics to delete
		/// </summary>
		public DeleteTopicsRequest WithTopicNamesCollection(String[] topicNamesCollection)
		{
			TopicNamesCollection = topicNamesCollection;
			return this;
		}

		private Int32 _timeoutMs = Int32.Default;
		/// <summary>
		/// The length of time in milliseconds to wait for the deletions to complete.
		/// </summary>
		public Int32 TimeoutMs 
		{
			get => _timeoutMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TimeoutMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_timeoutMs = value;
			}
		}

		/// <summary>
		/// The length of time in milliseconds to wait for the deletions to complete.
		/// </summary>
		public DeleteTopicsRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}

		public DeleteTopicsResponse Respond()
			=> new DeleteTopicsResponse(Version);
	}

	public class DeleteTopicsResponse : Message
	{
		public DeleteTopicsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DeleteTopicsResponse does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(20);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(3);

		public override Int16 Version { get; }

		public static async ValueTask<DeleteTopicsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteTopicsResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResponsesCollection = (await reader.ReadArrayAsync(async () => await DeletableTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResponsesCollection.Values.ToArray()).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(1, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public DeleteTopicsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Dictionary<String, DeletableTopicResult> _responsesCollection = new Dictionary<String, DeletableTopicResult>();
		/// <summary>
		/// The results for each topic we tried to delete.
		/// </summary>
		public Dictionary<String, DeletableTopicResult> ResponsesCollection 
		{
			get => _responsesCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResponsesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_responsesCollection = value;
			}
		}

		/// <summary>
		/// The results for each topic we tried to delete.
		/// </summary>
		public DeleteTopicsResponse WithResponsesCollection(params Func<DeletableTopicResult, DeletableTopicResult>[] createFields)
		{
			ResponsesCollection = createFields
				.Select(createField => createField(CreateDeletableTopicResult()))
				.ToDictionary(field => field.Name);
			return this;
		}

		internal DeletableTopicResult CreateDeletableTopicResult()
		{
			return new DeletableTopicResult(Version);
		}

		public class DeletableTopicResult : ISerialize
		{
			internal DeletableTopicResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DeletableTopicResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeletableTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			public DeletableTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The deletion error, or 0 if the deletion succeeded.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The deletion error, or 0 if the deletion succeeded.
			/// </summary>
			public DeletableTopicResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}
		}
	}

	public class DescribeAclsRequest : Message, IRespond<DescribeAclsResponse>
	{
		public DescribeAclsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DescribeAclsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(29);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DescribeAclsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeAclsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourceType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourceNameFilter = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ResourcePatternType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PrincipalFilter = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.HostFilter = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Operation = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PermissionType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt8Async(ResourceType, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(ResourceNameFilter, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt8Async(ResourcePatternType, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(PrincipalFilter, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(HostFilter, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt8Async(Operation, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt8Async(PermissionType, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int8 _resourceType = Int8.Default;
		/// <summary>
		/// The resource type.
		/// </summary>
		public Int8 ResourceType 
		{
			get => _resourceType;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResourceType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resourceType = value;
			}
		}

		/// <summary>
		/// The resource type.
		/// </summary>
		public DescribeAclsRequest WithResourceType(Int8 resourceType)
		{
			ResourceType = resourceType;
			return this;
		}

		private String? _resourceNameFilter = String.Default;
		/// <summary>
		/// The resource name, or null to match any resource name.
		/// </summary>
		public String? ResourceNameFilter 
		{
			get => _resourceNameFilter;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResourceNameFilter does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(0, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"ResourceNameFilter does not support null for version {Version}. Supported versions for null value: 0+");
				}

				_resourceNameFilter = value;
			}
		}

		/// <summary>
		/// The resource name, or null to match any resource name.
		/// </summary>
		public DescribeAclsRequest WithResourceNameFilter(String resourceNameFilter)
		{
			ResourceNameFilter = resourceNameFilter;
			return this;
		}

		private Int8 _resourcePatternType = new Int8(3);
		/// <summary>
		/// The resource pattern to match.
		/// </summary>
		public Int8 ResourcePatternType 
		{
			get => _resourcePatternType;
			set 
			{
				if (Version.InRange(1, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResourcePatternType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
				}

				_resourcePatternType = value;
			}
		}

		/// <summary>
		/// The resource pattern to match.
		/// </summary>
		public DescribeAclsRequest WithResourcePatternType(Int8 resourcePatternType)
		{
			ResourcePatternType = resourcePatternType;
			return this;
		}

		private String? _principalFilter = String.Default;
		/// <summary>
		/// The principal to match, or null to match any principal.
		/// </summary>
		public String? PrincipalFilter 
		{
			get => _principalFilter;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"PrincipalFilter does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(0, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"PrincipalFilter does not support null for version {Version}. Supported versions for null value: 0+");
				}

				_principalFilter = value;
			}
		}

		/// <summary>
		/// The principal to match, or null to match any principal.
		/// </summary>
		public DescribeAclsRequest WithPrincipalFilter(String principalFilter)
		{
			PrincipalFilter = principalFilter;
			return this;
		}

		private String? _hostFilter = String.Default;
		/// <summary>
		/// The host to match, or null to match any host.
		/// </summary>
		public String? HostFilter 
		{
			get => _hostFilter;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"HostFilter does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(0, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"HostFilter does not support null for version {Version}. Supported versions for null value: 0+");
				}

				_hostFilter = value;
			}
		}

		/// <summary>
		/// The host to match, or null to match any host.
		/// </summary>
		public DescribeAclsRequest WithHostFilter(String hostFilter)
		{
			HostFilter = hostFilter;
			return this;
		}

		private Int8 _operation = Int8.Default;
		/// <summary>
		/// The operation to match.
		/// </summary>
		public Int8 Operation 
		{
			get => _operation;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Operation does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_operation = value;
			}
		}

		/// <summary>
		/// The operation to match.
		/// </summary>
		public DescribeAclsRequest WithOperation(Int8 operation)
		{
			Operation = operation;
			return this;
		}

		private Int8 _permissionType = Int8.Default;
		/// <summary>
		/// The permission type to match.
		/// </summary>
		public Int8 PermissionType 
		{
			get => _permissionType;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"PermissionType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_permissionType = value;
			}
		}

		/// <summary>
		/// The permission type to match.
		/// </summary>
		public DescribeAclsRequest WithPermissionType(Int8 permissionType)
		{
			PermissionType = permissionType;
			return this;
		}

		public DescribeAclsResponse Respond()
			=> new DescribeAclsResponse(Version);
	}

	public class DescribeAclsResponse : Message
	{
		public DescribeAclsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DescribeAclsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(29);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DescribeAclsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeAclsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourcesCollection = await reader.ReadArrayAsync(async () => await DescribeAclsResource.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResourcesCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public DescribeAclsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public DescribeAclsResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private String? _errorMessage = String.Default;
		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public String? ErrorMessage 
		{
			get => _errorMessage;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(0, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
				}

				_errorMessage = value;
			}
		}

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public DescribeAclsResponse WithErrorMessage(String errorMessage)
		{
			ErrorMessage = errorMessage;
			return this;
		}

		private DescribeAclsResource[] _resourcesCollection = Array.Empty<DescribeAclsResource>();
		/// <summary>
		/// Each Resource that is referenced in an ACL.
		/// </summary>
		public DescribeAclsResource[] ResourcesCollection 
		{
			get => _resourcesCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResourcesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resourcesCollection = value;
			}
		}

		/// <summary>
		/// Each Resource that is referenced in an ACL.
		/// </summary>
		public DescribeAclsResponse WithResourcesCollection(params Func<DescribeAclsResource, DescribeAclsResource>[] createFields)
		{
			ResourcesCollection = createFields
				.Select(createField => createField(CreateDescribeAclsResource()))
				.ToArray();
			return this;
		}

		internal DescribeAclsResource CreateDescribeAclsResource()
		{
			return new DescribeAclsResource(Version);
		}

		public class DescribeAclsResource : ISerialize
		{
			internal DescribeAclsResource(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DescribeAclsResource> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribeAclsResource(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Type = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.PatternType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.AclsCollection = await reader.ReadArrayAsync(async () => await AclDescription.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(Type, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteInt8Async(PatternType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, AclsCollection).ConfigureAwait(false);
				}
			}

			private Int8 _type = Int8.Default;
			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 Type 
			{
				get => _type;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Type does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_type = value;
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public DescribeAclsResource WithType(Int8 type)
			{
				Type = type;
				return this;
			}

			private String _name = String.Default;
			/// <summary>
			/// The resource name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			public DescribeAclsResource WithName(String name)
			{
				Name = name;
				return this;
			}

			private Int8 _patternType = new Int8(3);
			/// <summary>
			/// The resource pattern type.
			/// </summary>
			public Int8 PatternType 
			{
				get => _patternType;
				set 
				{
					if (Version.InRange(1, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PatternType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
					}

					_patternType = value;
				}
			}

			/// <summary>
			/// The resource pattern type.
			/// </summary>
			public DescribeAclsResource WithPatternType(Int8 patternType)
			{
				PatternType = patternType;
				return this;
			}

			private AclDescription[] _aclsCollection = Array.Empty<AclDescription>();
			/// <summary>
			/// The ACLs.
			/// </summary>
			public AclDescription[] AclsCollection 
			{
				get => _aclsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"AclsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_aclsCollection = value;
				}
			}

			/// <summary>
			/// The ACLs.
			/// </summary>
			public DescribeAclsResource WithAclsCollection(params Func<AclDescription, AclDescription>[] createFields)
			{
				AclsCollection = createFields
					.Select(createField => createField(CreateAclDescription()))
					.ToArray();
				return this;
			}

			internal AclDescription CreateAclDescription()
			{
				return new AclDescription(Version);
			}

			public class AclDescription : ISerialize
			{
				internal AclDescription(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<AclDescription> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AclDescription(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Principal = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Host = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Operation = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PermissionType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Principal, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Host, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(Operation, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(PermissionType, cancellationToken).ConfigureAwait(false);
					}
				}

				private String _principal = String.Default;
				/// <summary>
				/// The ACL principal.
				/// </summary>
				public String Principal 
				{
					get => _principal;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Principal does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_principal = value;
					}
				}

				/// <summary>
				/// The ACL principal.
				/// </summary>
				public AclDescription WithPrincipal(String principal)
				{
					Principal = principal;
					return this;
				}

				private String _host = String.Default;
				/// <summary>
				/// The ACL host.
				/// </summary>
				public String Host 
				{
					get => _host;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_host = value;
					}
				}

				/// <summary>
				/// The ACL host.
				/// </summary>
				public AclDescription WithHost(String host)
				{
					Host = host;
					return this;
				}

				private Int8 _operation = Int8.Default;
				/// <summary>
				/// The ACL operation.
				/// </summary>
				public Int8 Operation 
				{
					get => _operation;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Operation does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_operation = value;
					}
				}

				/// <summary>
				/// The ACL operation.
				/// </summary>
				public AclDescription WithOperation(Int8 operation)
				{
					Operation = operation;
					return this;
				}

				private Int8 _permissionType = Int8.Default;
				/// <summary>
				/// The ACL permission type.
				/// </summary>
				public Int8 PermissionType 
				{
					get => _permissionType;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PermissionType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_permissionType = value;
					}
				}

				/// <summary>
				/// The ACL permission type.
				/// </summary>
				public AclDescription WithPermissionType(Int8 permissionType)
				{
					PermissionType = permissionType;
					return this;
				}
			}
		}
	}

	public class DescribeConfigsRequest : Message, IRespond<DescribeConfigsResponse>
	{
		public DescribeConfigsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DescribeConfigsRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(32);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<DescribeConfigsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeConfigsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourcesCollection = await reader.ReadArrayAsync(async () => await DescribeConfigsResource.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.IncludeSynoyms = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResourcesCollection).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteBooleanAsync(IncludeSynoyms, cancellationToken).ConfigureAwait(false);
			}
		}

		private DescribeConfigsResource[] _resourcesCollection = Array.Empty<DescribeConfigsResource>();
		/// <summary>
		/// The resources whose configurations we want to describe.
		/// </summary>
		public DescribeConfigsResource[] ResourcesCollection 
		{
			get => _resourcesCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResourcesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resourcesCollection = value;
			}
		}

		/// <summary>
		/// The resources whose configurations we want to describe.
		/// </summary>
		public DescribeConfigsRequest WithResourcesCollection(params Func<DescribeConfigsResource, DescribeConfigsResource>[] createFields)
		{
			ResourcesCollection = createFields
				.Select(createField => createField(CreateDescribeConfigsResource()))
				.ToArray();
			return this;
		}

		internal DescribeConfigsResource CreateDescribeConfigsResource()
		{
			return new DescribeConfigsResource(Version);
		}

		public class DescribeConfigsResource : ISerialize
		{
			internal DescribeConfigsResource(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DescribeConfigsResource> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribeConfigsResource(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ConfigurationKeysCollection = await reader.ReadNullableArrayAsync(async () => await String.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableArrayAsync(cancellationToken, ConfigurationKeysCollection).ConfigureAwait(false);
				}
			}

			private Int8 _resourceType = Int8.Default;
			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceType 
			{
				get => _resourceType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceType = value;
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public DescribeConfigsResource WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			private String _resourceName = String.Default;
			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceName 
			{
				get => _resourceName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceName = value;
				}
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			public DescribeConfigsResource WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}

			private String[]? _configurationKeysCollection = Array.Empty<String>();
			/// <summary>
			/// The configuration keys to list, or null to list all configuration keys.
			/// </summary>
			public String[]? ConfigurationKeysCollection 
			{
				get => _configurationKeysCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ConfigurationKeysCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"ConfigurationKeysCollection does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_configurationKeysCollection = value;
				}
			}

			/// <summary>
			/// The configuration keys to list, or null to list all configuration keys.
			/// </summary>
			public DescribeConfigsResource WithConfigurationKeysCollection(String[] configurationKeysCollection)
			{
				ConfigurationKeysCollection = configurationKeysCollection;
				return this;
			}
		}

		private Boolean _includeSynoyms = new Boolean(false);
		/// <summary>
		/// True if we should include all synonyms.
		/// </summary>
		public Boolean IncludeSynoyms 
		{
			get => _includeSynoyms;
			set 
			{
				if (Version.InRange(1, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"IncludeSynoyms does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
				}

				_includeSynoyms = value;
			}
		}

		/// <summary>
		/// True if we should include all synonyms.
		/// </summary>
		public DescribeConfigsRequest WithIncludeSynoyms(Boolean includeSynoyms)
		{
			IncludeSynoyms = includeSynoyms;
			return this;
		}

		public DescribeConfigsResponse Respond()
			=> new DescribeConfigsResponse(Version);
	}

	public class DescribeConfigsResponse : Message
	{
		public DescribeConfigsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DescribeConfigsResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(32);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<DescribeConfigsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeConfigsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = await reader.ReadArrayAsync(async () => await DescribeConfigsResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public DescribeConfigsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private DescribeConfigsResult[] _resultsCollection = Array.Empty<DescribeConfigsResult>();
		/// <summary>
		/// The results for each resource.
		/// </summary>
		public DescribeConfigsResult[] ResultsCollection 
		{
			get => _resultsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resultsCollection = value;
			}
		}

		/// <summary>
		/// The results for each resource.
		/// </summary>
		public DescribeConfigsResponse WithResultsCollection(params Func<DescribeConfigsResult, DescribeConfigsResult>[] createFields)
		{
			ResultsCollection = createFields
				.Select(createField => createField(CreateDescribeConfigsResult()))
				.ToArray();
			return this;
		}

		internal DescribeConfigsResult CreateDescribeConfigsResult()
		{
			return new DescribeConfigsResult(Version);
		}

		public class DescribeConfigsResult : ISerialize
		{
			internal DescribeConfigsResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DescribeConfigsResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribeConfigsResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ConfigsCollection = await reader.ReadArrayAsync(async () => await DescribeConfigsResourceResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ConfigsCollection).ConfigureAwait(false);
				}
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The error code, or 0 if we were able to successfully describe the configurations.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The error code, or 0 if we were able to successfully describe the configurations.
			/// </summary>
			public DescribeConfigsResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			private String? _errorMessage = String.Default;
			/// <summary>
			/// The error message, or null if we were able to successfully describe the configurations.
			/// </summary>
			public String? ErrorMessage 
			{
				get => _errorMessage;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_errorMessage = value;
				}
			}

			/// <summary>
			/// The error message, or null if we were able to successfully describe the configurations.
			/// </summary>
			public DescribeConfigsResult WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}

			private Int8 _resourceType = Int8.Default;
			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceType 
			{
				get => _resourceType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceType = value;
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public DescribeConfigsResult WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			private String _resourceName = String.Default;
			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceName 
			{
				get => _resourceName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceName = value;
				}
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			public DescribeConfigsResult WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}

			private DescribeConfigsResourceResult[] _configsCollection = Array.Empty<DescribeConfigsResourceResult>();
			/// <summary>
			/// Each listed configuration.
			/// </summary>
			public DescribeConfigsResourceResult[] ConfigsCollection 
			{
				get => _configsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ConfigsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_configsCollection = value;
				}
			}

			/// <summary>
			/// Each listed configuration.
			/// </summary>
			public DescribeConfigsResult WithConfigsCollection(params Func<DescribeConfigsResourceResult, DescribeConfigsResourceResult>[] createFields)
			{
				ConfigsCollection = createFields
					.Select(createField => createField(CreateDescribeConfigsResourceResult()))
					.ToArray();
				return this;
			}

			internal DescribeConfigsResourceResult CreateDescribeConfigsResourceResult()
			{
				return new DescribeConfigsResourceResult(Version);
			}

			public class DescribeConfigsResourceResult : ISerialize
			{
				internal DescribeConfigsResourceResult(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<DescribeConfigsResourceResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DescribeConfigsResourceResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Value = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ReadOnly = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 0)) 
					{
						instance.IsDefault = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.ConfigSource = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.IsSensitive = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.SynonymsCollection = await reader.ReadArrayAsync(async () => await DescribeConfigsSynonym.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(Value, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteBooleanAsync(ReadOnly, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 0)) 
					{
						await writer.WriteBooleanAsync(IsDefault, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt8Async(ConfigSource, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteBooleanAsync(IsSensitive, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, SynonymsCollection).ConfigureAwait(false);
					}
				}

				private String _name = String.Default;
				/// <summary>
				/// The configuration name.
				/// </summary>
				public String Name 
				{
					get => _name;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_name = value;
					}
				}

				/// <summary>
				/// The configuration name.
				/// </summary>
				public DescribeConfigsResourceResult WithName(String name)
				{
					Name = name;
					return this;
				}

				private String? _value = String.Default;
				/// <summary>
				/// The configuration value.
				/// </summary>
				public String? Value 
				{
					get => _value;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Value does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"Value does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_value = value;
					}
				}

				/// <summary>
				/// The configuration value.
				/// </summary>
				public DescribeConfigsResourceResult WithValue(String value)
				{
					Value = value;
					return this;
				}

				private Boolean _readOnly = Boolean.Default;
				/// <summary>
				/// True if the configuration is read-only.
				/// </summary>
				public Boolean ReadOnly 
				{
					get => _readOnly;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ReadOnly does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_readOnly = value;
					}
				}

				/// <summary>
				/// True if the configuration is read-only.
				/// </summary>
				public DescribeConfigsResourceResult WithReadOnly(Boolean readOnly)
				{
					ReadOnly = readOnly;
					return this;
				}

				private Boolean _isDefault = Boolean.Default;
				/// <summary>
				/// True if the configuration is not set.
				/// </summary>
				public Boolean IsDefault 
				{
					get => _isDefault;
					set 
					{
						if (Version.InRange(0, 0) == false) 
						{
							throw new UnsupportedVersionException($"IsDefault does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
						}

						_isDefault = value;
					}
				}

				/// <summary>
				/// True if the configuration is not set.
				/// </summary>
				public DescribeConfigsResourceResult WithIsDefault(Boolean isDefault)
				{
					IsDefault = isDefault;
					return this;
				}

				private Int8 _configSource = new Int8(-1);
				/// <summary>
				/// The configuration source.
				/// </summary>
				public Int8 ConfigSource 
				{
					get => _configSource;
					set 
					{
						_configSource = value;
					}
				}

				/// <summary>
				/// The configuration source.
				/// </summary>
				public DescribeConfigsResourceResult WithConfigSource(Int8 configSource)
				{
					ConfigSource = configSource;
					return this;
				}

				private Boolean _isSensitive = Boolean.Default;
				/// <summary>
				/// True if this configuration is sensitive.
				/// </summary>
				public Boolean IsSensitive 
				{
					get => _isSensitive;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"IsSensitive does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_isSensitive = value;
					}
				}

				/// <summary>
				/// True if this configuration is sensitive.
				/// </summary>
				public DescribeConfigsResourceResult WithIsSensitive(Boolean isSensitive)
				{
					IsSensitive = isSensitive;
					return this;
				}

				private DescribeConfigsSynonym[] _synonymsCollection = Array.Empty<DescribeConfigsSynonym>();
				/// <summary>
				/// The synonyms for this configuration key.
				/// </summary>
				public DescribeConfigsSynonym[] SynonymsCollection 
				{
					get => _synonymsCollection;
					set 
					{
						_synonymsCollection = value;
					}
				}

				/// <summary>
				/// The synonyms for this configuration key.
				/// </summary>
				public DescribeConfigsResourceResult WithSynonymsCollection(params Func<DescribeConfigsSynonym, DescribeConfigsSynonym>[] createFields)
				{
					SynonymsCollection = createFields
						.Select(createField => createField(CreateDescribeConfigsSynonym()))
						.ToArray();
					return this;
				}

				internal DescribeConfigsSynonym CreateDescribeConfigsSynonym()
				{
					return new DescribeConfigsSynonym(Version);
				}

				public class DescribeConfigsSynonym : ISerialize
				{
					internal DescribeConfigsSynonym(Int16 version)
					{
						Version = version;
					}

					internal Int16 Version { get; }

					public static async ValueTask<DescribeConfigsSynonym> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
					{
						var instance = new DescribeConfigsSynonym(version);
						if (instance.Version.InRange(1, 2147483647)) 
						{
							instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
						}
						if (instance.Version.InRange(1, 2147483647)) 
						{
							instance.Value = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
						}
						if (instance.Version.InRange(1, 2147483647)) 
						{
							instance.Source = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
						}
						return instance;
					}

					public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
					{
						if (Version.InRange(1, 2147483647)) 
						{
							await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
						}
						if (Version.InRange(1, 2147483647)) 
						{
							await writer.WriteNullableStringAsync(Value, cancellationToken).ConfigureAwait(false);
						}
						if (Version.InRange(1, 2147483647)) 
						{
							await writer.WriteInt8Async(Source, cancellationToken).ConfigureAwait(false);
						}
					}

					private String _name = String.Default;
					/// <summary>
					/// The synonym name.
					/// </summary>
					public String Name 
					{
						get => _name;
						set 
						{
							if (Version.InRange(1, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
							}

							_name = value;
						}
					}

					/// <summary>
					/// The synonym name.
					/// </summary>
					public DescribeConfigsSynonym WithName(String name)
					{
						Name = name;
						return this;
					}

					private String? _value = String.Default;
					/// <summary>
					/// The synonym value.
					/// </summary>
					public String? Value 
					{
						get => _value;
						set 
						{
							if (Version.InRange(1, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"Value does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
							}

							if (Version.InRange(0, 2147483647) == false &&
								value == null) 
							{
								throw new UnsupportedVersionException($"Value does not support null for version {Version}. Supported versions for null value: 0+");
							}

							_value = value;
						}
					}

					/// <summary>
					/// The synonym value.
					/// </summary>
					public DescribeConfigsSynonym WithValue(String value)
					{
						Value = value;
						return this;
					}

					private Int8 _source = Int8.Default;
					/// <summary>
					/// The synonym source.
					/// </summary>
					public Int8 Source 
					{
						get => _source;
						set 
						{
							if (Version.InRange(1, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"Source does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
							}

							_source = value;
						}
					}

					/// <summary>
					/// The synonym source.
					/// </summary>
					public DescribeConfigsSynonym WithSource(Int8 source)
					{
						Source = source;
						return this;
					}
				}
			}
		}
	}

	public class DescribeDelegationTokenRequest : Message, IRespond<DescribeDelegationTokenResponse>
	{
		public DescribeDelegationTokenRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DescribeDelegationTokenRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(41);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DescribeDelegationTokenRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeDelegationTokenRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.OwnersCollection = await reader.ReadNullableArrayAsync(async () => await DescribeDelegationTokenOwner.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableArrayAsync(cancellationToken, OwnersCollection).ConfigureAwait(false);
			}
		}

		private DescribeDelegationTokenOwner[]? _ownersCollection = Array.Empty<DescribeDelegationTokenOwner>();
		/// <summary>
		/// Each owner that we want to describe delegation tokens for, or null to describe all tokens.
		/// </summary>
		public DescribeDelegationTokenOwner[]? OwnersCollection 
		{
			get => _ownersCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"OwnersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(0, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"OwnersCollection does not support null for version {Version}. Supported versions for null value: 0+");
				}

				_ownersCollection = value;
			}
		}

		/// <summary>
		/// Each owner that we want to describe delegation tokens for, or null to describe all tokens.
		/// </summary>
		public DescribeDelegationTokenRequest WithOwnersCollection(params Func<DescribeDelegationTokenOwner, DescribeDelegationTokenOwner>[] createFields)
		{
			OwnersCollection = createFields
				.Select(createField => createField(CreateDescribeDelegationTokenOwner()))
				.ToArray();
			return this;
		}

		internal DescribeDelegationTokenOwner CreateDescribeDelegationTokenOwner()
		{
			return new DescribeDelegationTokenOwner(Version);
		}

		public class DescribeDelegationTokenOwner : ISerialize
		{
			internal DescribeDelegationTokenOwner(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DescribeDelegationTokenOwner> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribeDelegationTokenOwner(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalType = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalName, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _principalType = String.Default;
			/// <summary>
			/// The owner principal type.
			/// </summary>
			public String PrincipalType 
			{
				get => _principalType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PrincipalType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_principalType = value;
				}
			}

			/// <summary>
			/// The owner principal type.
			/// </summary>
			public DescribeDelegationTokenOwner WithPrincipalType(String principalType)
			{
				PrincipalType = principalType;
				return this;
			}

			private String _principalName = String.Default;
			/// <summary>
			/// The owner principal name.
			/// </summary>
			public String PrincipalName 
			{
				get => _principalName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PrincipalName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_principalName = value;
				}
			}

			/// <summary>
			/// The owner principal name.
			/// </summary>
			public DescribeDelegationTokenOwner WithPrincipalName(String principalName)
			{
				PrincipalName = principalName;
				return this;
			}
		}

		public DescribeDelegationTokenResponse Respond()
			=> new DescribeDelegationTokenResponse(Version);
	}

	public class DescribeDelegationTokenResponse : Message
	{
		public DescribeDelegationTokenResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DescribeDelegationTokenResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(41);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DescribeDelegationTokenResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeDelegationTokenResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TokensCollection = await reader.ReadArrayAsync(async () => await DescribedDelegationToken.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TokensCollection).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public DescribeDelegationTokenResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private DescribedDelegationToken[] _tokensCollection = Array.Empty<DescribedDelegationToken>();
		/// <summary>
		/// The tokens.
		/// </summary>
		public DescribedDelegationToken[] TokensCollection 
		{
			get => _tokensCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TokensCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_tokensCollection = value;
			}
		}

		/// <summary>
		/// The tokens.
		/// </summary>
		public DescribeDelegationTokenResponse WithTokensCollection(params Func<DescribedDelegationToken, DescribedDelegationToken>[] createFields)
		{
			TokensCollection = createFields
				.Select(createField => createField(CreateDescribedDelegationToken()))
				.ToArray();
			return this;
		}

		internal DescribedDelegationToken CreateDescribedDelegationToken()
		{
			return new DescribedDelegationToken(Version);
		}

		public class DescribedDelegationToken : ISerialize
		{
			internal DescribedDelegationToken(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DescribedDelegationToken> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribedDelegationToken(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalType = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.IssueTimestamp = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ExpiryTimestamp = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MaxTimestamp = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TokenId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Hmac = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.RenewersCollection = await reader.ReadArrayAsync(async () => await DescribedDelegationTokenRenewer.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt64Async(IssueTimestamp, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt64Async(ExpiryTimestamp, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt64Async(MaxTimestamp, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(TokenId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteBytesAsync(Hmac, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, RenewersCollection).ConfigureAwait(false);
				}
			}

			private String _principalType = String.Default;
			/// <summary>
			/// The token principal type.
			/// </summary>
			public String PrincipalType 
			{
				get => _principalType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PrincipalType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_principalType = value;
				}
			}

			/// <summary>
			/// The token principal type.
			/// </summary>
			public DescribedDelegationToken WithPrincipalType(String principalType)
			{
				PrincipalType = principalType;
				return this;
			}

			private String _principalName = String.Default;
			/// <summary>
			/// The token principal name.
			/// </summary>
			public String PrincipalName 
			{
				get => _principalName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PrincipalName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_principalName = value;
				}
			}

			/// <summary>
			/// The token principal name.
			/// </summary>
			public DescribedDelegationToken WithPrincipalName(String principalName)
			{
				PrincipalName = principalName;
				return this;
			}

			private Int64 _issueTimestamp = Int64.Default;
			/// <summary>
			/// The token issue timestamp in milliseconds.
			/// </summary>
			public Int64 IssueTimestamp 
			{
				get => _issueTimestamp;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"IssueTimestamp does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_issueTimestamp = value;
				}
			}

			/// <summary>
			/// The token issue timestamp in milliseconds.
			/// </summary>
			public DescribedDelegationToken WithIssueTimestamp(Int64 issueTimestamp)
			{
				IssueTimestamp = issueTimestamp;
				return this;
			}

			private Int64 _expiryTimestamp = Int64.Default;
			/// <summary>
			/// The token expiry timestamp in milliseconds.
			/// </summary>
			public Int64 ExpiryTimestamp 
			{
				get => _expiryTimestamp;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ExpiryTimestamp does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_expiryTimestamp = value;
				}
			}

			/// <summary>
			/// The token expiry timestamp in milliseconds.
			/// </summary>
			public DescribedDelegationToken WithExpiryTimestamp(Int64 expiryTimestamp)
			{
				ExpiryTimestamp = expiryTimestamp;
				return this;
			}

			private Int64 _maxTimestamp = Int64.Default;
			/// <summary>
			/// The token maximum timestamp length in milliseconds.
			/// </summary>
			public Int64 MaxTimestamp 
			{
				get => _maxTimestamp;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"MaxTimestamp does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_maxTimestamp = value;
				}
			}

			/// <summary>
			/// The token maximum timestamp length in milliseconds.
			/// </summary>
			public DescribedDelegationToken WithMaxTimestamp(Int64 maxTimestamp)
			{
				MaxTimestamp = maxTimestamp;
				return this;
			}

			private String _tokenId = String.Default;
			/// <summary>
			/// The token ID.
			/// </summary>
			public String TokenId 
			{
				get => _tokenId;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TokenId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_tokenId = value;
				}
			}

			/// <summary>
			/// The token ID.
			/// </summary>
			public DescribedDelegationToken WithTokenId(String tokenId)
			{
				TokenId = tokenId;
				return this;
			}

			private Bytes _hmac = Bytes.Default;
			/// <summary>
			/// The token HMAC.
			/// </summary>
			public Bytes Hmac 
			{
				get => _hmac;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Hmac does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_hmac = value;
				}
			}

			/// <summary>
			/// The token HMAC.
			/// </summary>
			public DescribedDelegationToken WithHmac(Bytes hmac)
			{
				Hmac = hmac;
				return this;
			}

			private DescribedDelegationTokenRenewer[] _renewersCollection = Array.Empty<DescribedDelegationTokenRenewer>();
			/// <summary>
			/// Those who are able to renew this token before it expires.
			/// </summary>
			public DescribedDelegationTokenRenewer[] RenewersCollection 
			{
				get => _renewersCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"RenewersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_renewersCollection = value;
				}
			}

			/// <summary>
			/// Those who are able to renew this token before it expires.
			/// </summary>
			public DescribedDelegationToken WithRenewersCollection(params Func<DescribedDelegationTokenRenewer, DescribedDelegationTokenRenewer>[] createFields)
			{
				RenewersCollection = createFields
					.Select(createField => createField(CreateDescribedDelegationTokenRenewer()))
					.ToArray();
				return this;
			}

			internal DescribedDelegationTokenRenewer CreateDescribedDelegationTokenRenewer()
			{
				return new DescribedDelegationTokenRenewer(Version);
			}

			public class DescribedDelegationTokenRenewer : ISerialize
			{
				internal DescribedDelegationTokenRenewer(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<DescribedDelegationTokenRenewer> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DescribedDelegationTokenRenewer(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PrincipalType = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PrincipalName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(PrincipalType, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(PrincipalName, cancellationToken).ConfigureAwait(false);
					}
				}

				private String _principalType = String.Default;
				/// <summary>
				/// The renewer principal type
				/// </summary>
				public String PrincipalType 
				{
					get => _principalType;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PrincipalType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_principalType = value;
					}
				}

				/// <summary>
				/// The renewer principal type
				/// </summary>
				public DescribedDelegationTokenRenewer WithPrincipalType(String principalType)
				{
					PrincipalType = principalType;
					return this;
				}

				private String _principalName = String.Default;
				/// <summary>
				/// The renewer principal name
				/// </summary>
				public String PrincipalName 
				{
					get => _principalName;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PrincipalName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_principalName = value;
					}
				}

				/// <summary>
				/// The renewer principal name
				/// </summary>
				public DescribedDelegationTokenRenewer WithPrincipalName(String principalName)
				{
					PrincipalName = principalName;
					return this;
				}
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public DescribeDelegationTokenResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class DescribeGroupsRequest : Message, IRespond<DescribeGroupsResponse>
	{
		public DescribeGroupsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DescribeGroupsRequest does not support version {version}. Valid versions are: 0-4");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(15);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(4);

		public override Int16 Version { get; }

		public static async ValueTask<DescribeGroupsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeGroupsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupsCollection = await reader.ReadArrayAsync(async () => await String.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.IncludeAuthorizedOperations = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, GroupsCollection).ConfigureAwait(false);
			}
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteBooleanAsync(IncludeAuthorizedOperations, cancellationToken).ConfigureAwait(false);
			}
		}

		private String[] _groupsCollection = Array.Empty<String>();
		/// <summary>
		/// The names of the groups to describe
		/// </summary>
		public String[] GroupsCollection 
		{
			get => _groupsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupsCollection = value;
			}
		}

		/// <summary>
		/// The names of the groups to describe
		/// </summary>
		public DescribeGroupsRequest WithGroupsCollection(String[] groupsCollection)
		{
			GroupsCollection = groupsCollection;
			return this;
		}

		private Boolean _includeAuthorizedOperations = Boolean.Default;
		/// <summary>
		/// Whether to include authorized operations.
		/// </summary>
		public Boolean IncludeAuthorizedOperations 
		{
			get => _includeAuthorizedOperations;
			set 
			{
				if (Version.InRange(3, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"IncludeAuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
				}

				_includeAuthorizedOperations = value;
			}
		}

		/// <summary>
		/// Whether to include authorized operations.
		/// </summary>
		public DescribeGroupsRequest WithIncludeAuthorizedOperations(Boolean includeAuthorizedOperations)
		{
			IncludeAuthorizedOperations = includeAuthorizedOperations;
			return this;
		}

		public DescribeGroupsResponse Respond()
			=> new DescribeGroupsResponse(Version);
	}

	public class DescribeGroupsResponse : Message
	{
		public DescribeGroupsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DescribeGroupsResponse does not support version {version}. Valid versions are: 0-4");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(15);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(4);

		public override Int16 Version { get; }

		public static async ValueTask<DescribeGroupsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeGroupsResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupsCollection = await reader.ReadArrayAsync(async () => await DescribedGroup.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, GroupsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public DescribeGroupsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private DescribedGroup[] _groupsCollection = Array.Empty<DescribedGroup>();
		/// <summary>
		/// Each described group.
		/// </summary>
		public DescribedGroup[] GroupsCollection 
		{
			get => _groupsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupsCollection = value;
			}
		}

		/// <summary>
		/// Each described group.
		/// </summary>
		public DescribeGroupsResponse WithGroupsCollection(params Func<DescribedGroup, DescribedGroup>[] createFields)
		{
			GroupsCollection = createFields
				.Select(createField => createField(CreateDescribedGroup()))
				.ToArray();
			return this;
		}

		internal DescribedGroup CreateDescribedGroup()
		{
			return new DescribedGroup(Version);
		}

		public class DescribedGroup : ISerialize
		{
			internal DescribedGroup(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DescribedGroup> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribedGroup(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.GroupState = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProtocolType = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProtocolData = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MembersCollection = await reader.ReadArrayAsync(async () => await DescribedGroupMember.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(3, 2147483647)) 
				{
					instance.AuthorizedOperations = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(GroupState, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ProtocolType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ProtocolData, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, MembersCollection).ConfigureAwait(false);
				}
				if (Version.InRange(3, 2147483647)) 
				{
					await writer.WriteInt32Async(AuthorizedOperations, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The describe error, or 0 if there was no error.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The describe error, or 0 if there was no error.
			/// </summary>
			public DescribedGroup WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			private String _groupId = String.Default;
			/// <summary>
			/// The group ID string.
			/// </summary>
			public String GroupId 
			{
				get => _groupId;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_groupId = value;
				}
			}

			/// <summary>
			/// The group ID string.
			/// </summary>
			public DescribedGroup WithGroupId(String groupId)
			{
				GroupId = groupId;
				return this;
			}

			private String _groupState = String.Default;
			/// <summary>
			/// The group state string, or the empty string.
			/// </summary>
			public String GroupState 
			{
				get => _groupState;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"GroupState does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_groupState = value;
				}
			}

			/// <summary>
			/// The group state string, or the empty string.
			/// </summary>
			public DescribedGroup WithGroupState(String groupState)
			{
				GroupState = groupState;
				return this;
			}

			private String _protocolType = String.Default;
			/// <summary>
			/// The group protocol type, or the empty string.
			/// </summary>
			public String ProtocolType 
			{
				get => _protocolType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ProtocolType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_protocolType = value;
				}
			}

			/// <summary>
			/// The group protocol type, or the empty string.
			/// </summary>
			public DescribedGroup WithProtocolType(String protocolType)
			{
				ProtocolType = protocolType;
				return this;
			}

			private String _protocolData = String.Default;
			/// <summary>
			/// The group protocol data, or the empty string.
			/// </summary>
			public String ProtocolData 
			{
				get => _protocolData;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ProtocolData does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_protocolData = value;
				}
			}

			/// <summary>
			/// The group protocol data, or the empty string.
			/// </summary>
			public DescribedGroup WithProtocolData(String protocolData)
			{
				ProtocolData = protocolData;
				return this;
			}

			private DescribedGroupMember[] _membersCollection = Array.Empty<DescribedGroupMember>();
			/// <summary>
			/// The group members.
			/// </summary>
			public DescribedGroupMember[] MembersCollection 
			{
				get => _membersCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"MembersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_membersCollection = value;
				}
			}

			/// <summary>
			/// The group members.
			/// </summary>
			public DescribedGroup WithMembersCollection(params Func<DescribedGroupMember, DescribedGroupMember>[] createFields)
			{
				MembersCollection = createFields
					.Select(createField => createField(CreateDescribedGroupMember()))
					.ToArray();
				return this;
			}

			internal DescribedGroupMember CreateDescribedGroupMember()
			{
				return new DescribedGroupMember(Version);
			}

			public class DescribedGroupMember : ISerialize
			{
				internal DescribedGroupMember(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<DescribedGroupMember> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DescribedGroupMember(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.MemberId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(4, 2147483647)) 
					{
						instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ClientId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ClientHost = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.MemberMetadata = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.MemberAssignment = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(MemberId, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(4, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(ClientId, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(ClientHost, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteBytesAsync(MemberMetadata, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteBytesAsync(MemberAssignment, cancellationToken).ConfigureAwait(false);
					}
				}

				private String _memberId = String.Default;
				/// <summary>
				/// The member ID assigned by the group coordinator.
				/// </summary>
				public String MemberId 
				{
					get => _memberId;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_memberId = value;
					}
				}

				/// <summary>
				/// The member ID assigned by the group coordinator.
				/// </summary>
				public DescribedGroupMember WithMemberId(String memberId)
				{
					MemberId = memberId;
					return this;
				}

				private String? _groupInstanceId;
				/// <summary>
				/// The unique identifier of the consumer instance provided by end user.
				/// </summary>
				public String? GroupInstanceId 
				{
					get => _groupInstanceId;
					set 
					{
						if (Version.InRange(4, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
						}

						if (Version.InRange(4, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 4+");
						}

						_groupInstanceId = value;
					}
				}

				/// <summary>
				/// The unique identifier of the consumer instance provided by end user.
				/// </summary>
				public DescribedGroupMember WithGroupInstanceId(String groupInstanceId)
				{
					GroupInstanceId = groupInstanceId;
					return this;
				}

				private String _clientId = String.Default;
				/// <summary>
				/// The client ID used in the member's latest join group request.
				/// </summary>
				public String ClientId 
				{
					get => _clientId;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ClientId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_clientId = value;
					}
				}

				/// <summary>
				/// The client ID used in the member's latest join group request.
				/// </summary>
				public DescribedGroupMember WithClientId(String clientId)
				{
					ClientId = clientId;
					return this;
				}

				private String _clientHost = String.Default;
				/// <summary>
				/// The client host.
				/// </summary>
				public String ClientHost 
				{
					get => _clientHost;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ClientHost does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_clientHost = value;
					}
				}

				/// <summary>
				/// The client host.
				/// </summary>
				public DescribedGroupMember WithClientHost(String clientHost)
				{
					ClientHost = clientHost;
					return this;
				}

				private Bytes _memberMetadata = Bytes.Default;
				/// <summary>
				/// The metadata corresponding to the current group protocol in use.
				/// </summary>
				public Bytes MemberMetadata 
				{
					get => _memberMetadata;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"MemberMetadata does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_memberMetadata = value;
					}
				}

				/// <summary>
				/// The metadata corresponding to the current group protocol in use.
				/// </summary>
				public DescribedGroupMember WithMemberMetadata(Bytes memberMetadata)
				{
					MemberMetadata = memberMetadata;
					return this;
				}

				private Bytes _memberAssignment = Bytes.Default;
				/// <summary>
				/// The current assignment provided by the group leader.
				/// </summary>
				public Bytes MemberAssignment 
				{
					get => _memberAssignment;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"MemberAssignment does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_memberAssignment = value;
					}
				}

				/// <summary>
				/// The current assignment provided by the group leader.
				/// </summary>
				public DescribedGroupMember WithMemberAssignment(Bytes memberAssignment)
				{
					MemberAssignment = memberAssignment;
					return this;
				}
			}

			private Int32 _authorizedOperations = new Int32(-2147483648);
			/// <summary>
			/// 32-bit bitfield to represent authorized operations for this group.
			/// </summary>
			public Int32 AuthorizedOperations 
			{
				get => _authorizedOperations;
				set 
				{
					if (Version.InRange(3, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"AuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
					}

					_authorizedOperations = value;
				}
			}

			/// <summary>
			/// 32-bit bitfield to represent authorized operations for this group.
			/// </summary>
			public DescribedGroup WithAuthorizedOperations(Int32 authorizedOperations)
			{
				AuthorizedOperations = authorizedOperations;
				return this;
			}
		}
	}

	public class DescribeLogDirsRequest : Message, IRespond<DescribeLogDirsResponse>
	{
		public DescribeLogDirsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DescribeLogDirsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(35);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DescribeLogDirsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeLogDirsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadNullableArrayAsync(async () => await DescribableLogDirTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private DescribableLogDirTopic[]? _topicsCollection = Array.Empty<DescribableLogDirTopic>();
		/// <summary>
		/// Each topic that we want to describe log directories for, or null for all topics.
		/// </summary>
		public DescribableLogDirTopic[]? TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(0, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support null for version {Version}. Supported versions for null value: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic that we want to describe log directories for, or null for all topics.
		/// </summary>
		public DescribeLogDirsRequest WithTopicsCollection(params Func<DescribableLogDirTopic, DescribableLogDirTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateDescribableLogDirTopic()))
				.ToArray();
			return this;
		}

		internal DescribableLogDirTopic CreateDescribableLogDirTopic()
		{
			return new DescribableLogDirTopic(Version);
		}

		public class DescribableLogDirTopic : ISerialize
		{
			internal DescribableLogDirTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DescribableLogDirTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribableLogDirTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Topic = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndexCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Topic, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionIndexCollection).ConfigureAwait(false);
				}
			}

			private String _topic = String.Default;
			/// <summary>
			/// The topic name
			/// </summary>
			public String Topic 
			{
				get => _topic;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Topic does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topic = value;
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			public DescribableLogDirTopic WithTopic(String topic)
			{
				Topic = topic;
				return this;
			}

			private Int32[] _partitionIndexCollection = Array.Empty<Int32>();
			/// <summary>
			/// The partition indxes.
			/// </summary>
			public Int32[] PartitionIndexCollection 
			{
				get => _partitionIndexCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionIndexCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionIndexCollection = value;
				}
			}

			/// <summary>
			/// The partition indxes.
			/// </summary>
			public DescribableLogDirTopic WithPartitionIndexCollection(Int32[] partitionIndexCollection)
			{
				PartitionIndexCollection = partitionIndexCollection;
				return this;
			}
		}

		public DescribeLogDirsResponse Respond()
			=> new DescribeLogDirsResponse(Version);
	}

	public class DescribeLogDirsResponse : Message
	{
		public DescribeLogDirsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"DescribeLogDirsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(35);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<DescribeLogDirsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeLogDirsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = await reader.ReadArrayAsync(async () => await DescribeLogDirsResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public DescribeLogDirsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private DescribeLogDirsResult[] _resultsCollection = Array.Empty<DescribeLogDirsResult>();
		/// <summary>
		/// The log directories.
		/// </summary>
		public DescribeLogDirsResult[] ResultsCollection 
		{
			get => _resultsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resultsCollection = value;
			}
		}

		/// <summary>
		/// The log directories.
		/// </summary>
		public DescribeLogDirsResponse WithResultsCollection(params Func<DescribeLogDirsResult, DescribeLogDirsResult>[] createFields)
		{
			ResultsCollection = createFields
				.Select(createField => createField(CreateDescribeLogDirsResult()))
				.ToArray();
			return this;
		}

		internal DescribeLogDirsResult CreateDescribeLogDirsResult()
		{
			return new DescribeLogDirsResult(Version);
		}

		public class DescribeLogDirsResult : ISerialize
		{
			internal DescribeLogDirsResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<DescribeLogDirsResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribeLogDirsResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.LogDir = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicsCollection = await reader.ReadArrayAsync(async () => await DescribeLogDirsTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(LogDir, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
				}
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The error code, or 0 if there was no error.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The error code, or 0 if there was no error.
			/// </summary>
			public DescribeLogDirsResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			private String _logDir = String.Default;
			/// <summary>
			/// The absolute log directory path.
			/// </summary>
			public String LogDir 
			{
				get => _logDir;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"LogDir does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_logDir = value;
				}
			}

			/// <summary>
			/// The absolute log directory path.
			/// </summary>
			public DescribeLogDirsResult WithLogDir(String logDir)
			{
				LogDir = logDir;
				return this;
			}

			private DescribeLogDirsTopic[] _topicsCollection = Array.Empty<DescribeLogDirsTopic>();
			/// <summary>
			/// Each topic.
			/// </summary>
			public DescribeLogDirsTopic[] TopicsCollection 
			{
				get => _topicsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topicsCollection = value;
				}
			}

			/// <summary>
			/// Each topic.
			/// </summary>
			public DescribeLogDirsResult WithTopicsCollection(params Func<DescribeLogDirsTopic, DescribeLogDirsTopic>[] createFields)
			{
				TopicsCollection = createFields
					.Select(createField => createField(CreateDescribeLogDirsTopic()))
					.ToArray();
				return this;
			}

			internal DescribeLogDirsTopic CreateDescribeLogDirsTopic()
			{
				return new DescribeLogDirsTopic(Version);
			}

			public class DescribeLogDirsTopic : ISerialize
			{
				internal DescribeLogDirsTopic(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<DescribeLogDirsTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DescribeLogDirsTopic(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await DescribeLogDirsPartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
					}
				}

				private String _name = String.Default;
				/// <summary>
				/// The topic name.
				/// </summary>
				public String Name 
				{
					get => _name;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_name = value;
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				public DescribeLogDirsTopic WithName(String name)
				{
					Name = name;
					return this;
				}

				private DescribeLogDirsPartition[] _partitionsCollection = Array.Empty<DescribeLogDirsPartition>();
				public DescribeLogDirsPartition[] PartitionsCollection 
				{
					get => _partitionsCollection;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionsCollection = value;
					}
				}

				public DescribeLogDirsTopic WithPartitionsCollection(params Func<DescribeLogDirsPartition, DescribeLogDirsPartition>[] createFields)
				{
					PartitionsCollection = createFields
						.Select(createField => createField(CreateDescribeLogDirsPartition()))
						.ToArray();
					return this;
				}

				internal DescribeLogDirsPartition CreateDescribeLogDirsPartition()
				{
					return new DescribeLogDirsPartition(Version);
				}

				public class DescribeLogDirsPartition : ISerialize
				{
					internal DescribeLogDirsPartition(Int16 version)
					{
						Version = version;
					}

					internal Int16 Version { get; }

					public static async ValueTask<DescribeLogDirsPartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
					{
						var instance = new DescribeLogDirsPartition(version);
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
						}
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.PartitionSize = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
						}
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.OffsetLag = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
						}
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.IsFutureKey = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
						}
						return instance;
					}

					public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
					{
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
						}
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteInt64Async(PartitionSize, cancellationToken).ConfigureAwait(false);
						}
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteInt64Async(OffsetLag, cancellationToken).ConfigureAwait(false);
						}
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteBooleanAsync(IsFutureKey, cancellationToken).ConfigureAwait(false);
						}
					}

					private Int32 _partitionIndex = Int32.Default;
					/// <summary>
					/// The partition index.
					/// </summary>
					public Int32 PartitionIndex 
					{
						get => _partitionIndex;
						set 
						{
							if (Version.InRange(0, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
							}

							_partitionIndex = value;
						}
					}

					/// <summary>
					/// The partition index.
					/// </summary>
					public DescribeLogDirsPartition WithPartitionIndex(Int32 partitionIndex)
					{
						PartitionIndex = partitionIndex;
						return this;
					}

					private Int64 _partitionSize = Int64.Default;
					/// <summary>
					/// The size of the log segments in this partition in bytes.
					/// </summary>
					public Int64 PartitionSize 
					{
						get => _partitionSize;
						set 
						{
							if (Version.InRange(0, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"PartitionSize does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
							}

							_partitionSize = value;
						}
					}

					/// <summary>
					/// The size of the log segments in this partition in bytes.
					/// </summary>
					public DescribeLogDirsPartition WithPartitionSize(Int64 partitionSize)
					{
						PartitionSize = partitionSize;
						return this;
					}

					private Int64 _offsetLag = Int64.Default;
					/// <summary>
					/// The lag of the log's LEO w.r.t. partition's HW (if it is the current log for the partition) or current replica's LEO (if it is the future log for the partition)
					/// </summary>
					public Int64 OffsetLag 
					{
						get => _offsetLag;
						set 
						{
							if (Version.InRange(0, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"OffsetLag does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
							}

							_offsetLag = value;
						}
					}

					/// <summary>
					/// The lag of the log's LEO w.r.t. partition's HW (if it is the current log for the partition) or current replica's LEO (if it is the future log for the partition)
					/// </summary>
					public DescribeLogDirsPartition WithOffsetLag(Int64 offsetLag)
					{
						OffsetLag = offsetLag;
						return this;
					}

					private Boolean _isFutureKey = Boolean.Default;
					/// <summary>
					/// True if this log is created by AlterReplicaLogDirsRequest and will replace the current log of the replica in the future.
					/// </summary>
					public Boolean IsFutureKey 
					{
						get => _isFutureKey;
						set 
						{
							if (Version.InRange(0, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"IsFutureKey does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
							}

							_isFutureKey = value;
						}
					}

					/// <summary>
					/// True if this log is created by AlterReplicaLogDirsRequest and will replace the current log of the replica in the future.
					/// </summary>
					public DescribeLogDirsPartition WithIsFutureKey(Boolean isFutureKey)
					{
						IsFutureKey = isFutureKey;
						return this;
					}
				}
			}
		}
	}

	public class ElectLeadersRequest : Message, IRespond<ElectLeadersResponse>
	{
		public ElectLeadersRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ElectLeadersRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(43);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<ElectLeadersRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ElectLeadersRequest(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ElectionType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicPartitionsCollection = await reader.ReadNullableArrayAsync(async () => await TopicPartitions.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt8Async(ElectionType, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableArrayAsync(cancellationToken, TopicPartitionsCollection).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int8 _electionType = Int8.Default;
		/// <summary>
		/// Type of elections to conduct for the partition. A value of '0' elects the preferred replica. A value of '1' elects the first live replica if there are no in-sync replica.
		/// </summary>
		public Int8 ElectionType 
		{
			get => _electionType;
			set 
			{
				if (Version.InRange(1, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ElectionType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
				}

				_electionType = value;
			}
		}

		/// <summary>
		/// Type of elections to conduct for the partition. A value of '0' elects the preferred replica. A value of '1' elects the first live replica if there are no in-sync replica.
		/// </summary>
		public ElectLeadersRequest WithElectionType(Int8 electionType)
		{
			ElectionType = electionType;
			return this;
		}

		private TopicPartitions[]? _topicPartitionsCollection = Array.Empty<TopicPartitions>();
		/// <summary>
		/// The topic partitions to elect leaders.
		/// </summary>
		public TopicPartitions[]? TopicPartitionsCollection 
		{
			get => _topicPartitionsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicPartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(0, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"TopicPartitionsCollection does not support null for version {Version}. Supported versions for null value: 0+");
				}

				_topicPartitionsCollection = value;
			}
		}

		/// <summary>
		/// The topic partitions to elect leaders.
		/// </summary>
		public ElectLeadersRequest WithTopicPartitionsCollection(params Func<TopicPartitions, TopicPartitions>[] createFields)
		{
			TopicPartitionsCollection = createFields
				.Select(createField => createField(CreateTopicPartitions()))
				.ToArray();
			return this;
		}

		internal TopicPartitions CreateTopicPartitions()
		{
			return new TopicPartitions(Version);
		}

		public class TopicPartitions : ISerialize
		{
			internal TopicPartitions(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<TopicPartitions> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TopicPartitions(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Topic = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIdCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Topic, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionIdCollection).ConfigureAwait(false);
				}
			}

			private String _topic = String.Default;
			/// <summary>
			/// The name of a topic.
			/// </summary>
			public String Topic 
			{
				get => _topic;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Topic does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topic = value;
				}
			}

			/// <summary>
			/// The name of a topic.
			/// </summary>
			public TopicPartitions WithTopic(String topic)
			{
				Topic = topic;
				return this;
			}

			private Int32[] _partitionIdCollection = Array.Empty<Int32>();
			/// <summary>
			/// The partitions of this topic whose leader should be elected.
			/// </summary>
			public Int32[] PartitionIdCollection 
			{
				get => _partitionIdCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionIdCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionIdCollection = value;
				}
			}

			/// <summary>
			/// The partitions of this topic whose leader should be elected.
			/// </summary>
			public TopicPartitions WithPartitionIdCollection(Int32[] partitionIdCollection)
			{
				PartitionIdCollection = partitionIdCollection;
				return this;
			}
		}

		private Int32 _timeoutMs = new Int32(60000);
		/// <summary>
		/// The time in ms to wait for the election to complete.
		/// </summary>
		public Int32 TimeoutMs 
		{
			get => _timeoutMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TimeoutMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_timeoutMs = value;
			}
		}

		/// <summary>
		/// The time in ms to wait for the election to complete.
		/// </summary>
		public ElectLeadersRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}

		public ElectLeadersResponse Respond()
			=> new ElectLeadersResponse(Version);
	}

	public class ElectLeadersResponse : Message
	{
		public ElectLeadersResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ElectLeadersResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(43);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<ElectLeadersResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ElectLeadersResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ReplicaElectionResultsCollection = await reader.ReadArrayAsync(async () => await ReplicaElectionResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ReplicaElectionResultsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public ElectLeadersResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The top level response error code.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(1, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The top level response error code.
		/// </summary>
		public ElectLeadersResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private ReplicaElectionResult[] _replicaElectionResultsCollection = Array.Empty<ReplicaElectionResult>();
		/// <summary>
		/// The election results, or an empty array if the requester did not have permission and the request asks for all partitions.
		/// </summary>
		public ReplicaElectionResult[] ReplicaElectionResultsCollection 
		{
			get => _replicaElectionResultsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ReplicaElectionResultsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_replicaElectionResultsCollection = value;
			}
		}

		/// <summary>
		/// The election results, or an empty array if the requester did not have permission and the request asks for all partitions.
		/// </summary>
		public ElectLeadersResponse WithReplicaElectionResultsCollection(params Func<ReplicaElectionResult, ReplicaElectionResult>[] createFields)
		{
			ReplicaElectionResultsCollection = createFields
				.Select(createField => createField(CreateReplicaElectionResult()))
				.ToArray();
			return this;
		}

		internal ReplicaElectionResult CreateReplicaElectionResult()
		{
			return new ReplicaElectionResult(Version);
		}

		public class ReplicaElectionResult : ISerialize
		{
			internal ReplicaElectionResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<ReplicaElectionResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ReplicaElectionResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Topic = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionResultCollection = await reader.ReadArrayAsync(async () => await PartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Topic, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionResultCollection).ConfigureAwait(false);
				}
			}

			private String _topic = String.Default;
			/// <summary>
			/// The topic name
			/// </summary>
			public String Topic 
			{
				get => _topic;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Topic does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topic = value;
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			public ReplicaElectionResult WithTopic(String topic)
			{
				Topic = topic;
				return this;
			}

			private PartitionResult[] _partitionResultCollection = Array.Empty<PartitionResult>();
			/// <summary>
			/// The results for each partition
			/// </summary>
			public PartitionResult[] PartitionResultCollection 
			{
				get => _partitionResultCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionResultCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionResultCollection = value;
				}
			}

			/// <summary>
			/// The results for each partition
			/// </summary>
			public ReplicaElectionResult WithPartitionResultCollection(params Func<PartitionResult, PartitionResult>[] createFields)
			{
				PartitionResultCollection = createFields
					.Select(createField => createField(CreatePartitionResult()))
					.ToArray();
				return this;
			}

			internal PartitionResult CreatePartitionResult()
			{
				return new PartitionResult(Version);
			}

			public class PartitionResult : ISerialize
			{
				internal PartitionResult(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<PartitionResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new PartitionResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionId, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionId = Int32.Default;
				/// <summary>
				/// The partition id
				/// </summary>
				public Int32 PartitionId 
				{
					get => _partitionId;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionId = value;
					}
				}

				/// <summary>
				/// The partition id
				/// </summary>
				public PartitionResult WithPartitionId(Int32 partitionId)
				{
					PartitionId = partitionId;
					return this;
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The result error, or zero if there was no error.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The result error, or zero if there was no error.
				/// </summary>
				public PartitionResult WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				private String? _errorMessage = String.Default;
				/// <summary>
				/// The result message, or null if there was no error.
				/// </summary>
				public String? ErrorMessage 
				{
					get => _errorMessage;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_errorMessage = value;
					}
				}

				/// <summary>
				/// The result message, or null if there was no error.
				/// </summary>
				public PartitionResult WithErrorMessage(String errorMessage)
				{
					ErrorMessage = errorMessage;
					return this;
				}
			}
		}
	}

	public class EndTxnRequest : Message, IRespond<EndTxnResponse>
	{
		public EndTxnRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"EndTxnRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(26);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<EndTxnRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new EndTxnRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerId = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Committed = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(TransactionalId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ProducerId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ProducerEpoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBooleanAsync(Committed, cancellationToken).ConfigureAwait(false);
			}
		}

		private String _transactionalId = String.Default;
		/// <summary>
		/// The ID of the transaction to end.
		/// </summary>
		public String TransactionalId 
		{
			get => _transactionalId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TransactionalId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_transactionalId = value;
			}
		}

		/// <summary>
		/// The ID of the transaction to end.
		/// </summary>
		public EndTxnRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		private Int64 _producerId = Int64.Default;
		/// <summary>
		/// The producer ID.
		/// </summary>
		public Int64 ProducerId 
		{
			get => _producerId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_producerId = value;
			}
		}

		/// <summary>
		/// The producer ID.
		/// </summary>
		public EndTxnRequest WithProducerId(Int64 producerId)
		{
			ProducerId = producerId;
			return this;
		}

		private Int16 _producerEpoch = Int16.Default;
		/// <summary>
		/// The current epoch associated with the producer.
		/// </summary>
		public Int16 ProducerEpoch 
		{
			get => _producerEpoch;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProducerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_producerEpoch = value;
			}
		}

		/// <summary>
		/// The current epoch associated with the producer.
		/// </summary>
		public EndTxnRequest WithProducerEpoch(Int16 producerEpoch)
		{
			ProducerEpoch = producerEpoch;
			return this;
		}

		private Boolean _committed = Boolean.Default;
		/// <summary>
		/// True if the transaction was committed, false if it was aborted.
		/// </summary>
		public Boolean Committed 
		{
			get => _committed;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Committed does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_committed = value;
			}
		}

		/// <summary>
		/// True if the transaction was committed, false if it was aborted.
		/// </summary>
		public EndTxnRequest WithCommitted(Boolean committed)
		{
			Committed = committed;
			return this;
		}

		public EndTxnResponse Respond()
			=> new EndTxnResponse(Version);
	}

	public class EndTxnResponse : Message
	{
		public EndTxnResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"EndTxnResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(26);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<EndTxnResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new EndTxnResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public EndTxnResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public EndTxnResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class ExpireDelegationTokenRequest : Message, IRespond<ExpireDelegationTokenResponse>
	{
		public ExpireDelegationTokenRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ExpireDelegationTokenRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(40);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<ExpireDelegationTokenRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ExpireDelegationTokenRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Hmac = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ExpiryTimePeriodMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(Hmac, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ExpiryTimePeriodMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private Bytes _hmac = Bytes.Default;
		/// <summary>
		/// The HMAC of the delegation token to be expired.
		/// </summary>
		public Bytes Hmac 
		{
			get => _hmac;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Hmac does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_hmac = value;
			}
		}

		/// <summary>
		/// The HMAC of the delegation token to be expired.
		/// </summary>
		public ExpireDelegationTokenRequest WithHmac(Bytes hmac)
		{
			Hmac = hmac;
			return this;
		}

		private Int64 _expiryTimePeriodMs = Int64.Default;
		/// <summary>
		/// The expiry time period in milliseconds.
		/// </summary>
		public Int64 ExpiryTimePeriodMs 
		{
			get => _expiryTimePeriodMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ExpiryTimePeriodMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_expiryTimePeriodMs = value;
			}
		}

		/// <summary>
		/// The expiry time period in milliseconds.
		/// </summary>
		public ExpireDelegationTokenRequest WithExpiryTimePeriodMs(Int64 expiryTimePeriodMs)
		{
			ExpiryTimePeriodMs = expiryTimePeriodMs;
			return this;
		}

		public ExpireDelegationTokenResponse Respond()
			=> new ExpireDelegationTokenResponse(Version);
	}

	public class ExpireDelegationTokenResponse : Message
	{
		public ExpireDelegationTokenResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ExpireDelegationTokenResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(40);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<ExpireDelegationTokenResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ExpireDelegationTokenResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ExpiryTimestampMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ExpiryTimestampMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public ExpireDelegationTokenResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private Int64 _expiryTimestampMs = Int64.Default;
		/// <summary>
		/// The timestamp in milliseconds at which this token expires.
		/// </summary>
		public Int64 ExpiryTimestampMs 
		{
			get => _expiryTimestampMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ExpiryTimestampMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_expiryTimestampMs = value;
			}
		}

		/// <summary>
		/// The timestamp in milliseconds at which this token expires.
		/// </summary>
		public ExpireDelegationTokenResponse WithExpiryTimestampMs(Int64 expiryTimestampMs)
		{
			ExpiryTimestampMs = expiryTimestampMs;
			return this;
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public ExpireDelegationTokenResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class FetchRequest : Message, IRespond<FetchResponse>
	{
		public FetchRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"FetchRequest does not support version {version}. Valid versions are: 0-11");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(1);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(11);

		public override Int16 Version { get; }

		public static async ValueTask<FetchRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new FetchRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ReplicaId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MaxWait = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MinBytes = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.MaxBytes = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(4, 2147483647)) 
			{
				instance.IsolationLevel = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.SessionId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.Epoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await FetchableTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.ForgottenCollection = await reader.ReadArrayAsync(async () => await ForgottenTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(11, 2147483647)) 
			{
				instance.RackId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ReplicaId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(MaxWait, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(MinBytes, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteInt32Async(MaxBytes, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(4, 2147483647)) 
			{
				await writer.WriteInt8Async(IsolationLevel, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteInt32Async(SessionId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteInt32Async(Epoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ForgottenCollection).ConfigureAwait(false);
			}
			if (Version.InRange(11, 2147483647)) 
			{
				await writer.WriteStringAsync(RackId, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _replicaId = Int32.Default;
		/// <summary>
		/// The broker ID of the follower, of -1 if this request is from a consumer.
		/// </summary>
		public Int32 ReplicaId 
		{
			get => _replicaId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ReplicaId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_replicaId = value;
			}
		}

		/// <summary>
		/// The broker ID of the follower, of -1 if this request is from a consumer.
		/// </summary>
		public FetchRequest WithReplicaId(Int32 replicaId)
		{
			ReplicaId = replicaId;
			return this;
		}

		private Int32 _maxWait = Int32.Default;
		/// <summary>
		/// The maximum time in milliseconds to wait for the response.
		/// </summary>
		public Int32 MaxWait 
		{
			get => _maxWait;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MaxWait does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_maxWait = value;
			}
		}

		/// <summary>
		/// The maximum time in milliseconds to wait for the response.
		/// </summary>
		public FetchRequest WithMaxWait(Int32 maxWait)
		{
			MaxWait = maxWait;
			return this;
		}

		private Int32 _minBytes = Int32.Default;
		/// <summary>
		/// The minimum bytes to accumulate in the response.
		/// </summary>
		public Int32 MinBytes 
		{
			get => _minBytes;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MinBytes does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_minBytes = value;
			}
		}

		/// <summary>
		/// The minimum bytes to accumulate in the response.
		/// </summary>
		public FetchRequest WithMinBytes(Int32 minBytes)
		{
			MinBytes = minBytes;
			return this;
		}

		private Int32 _maxBytes = new Int32(0x7fffffff);
		/// <summary>
		/// The maximum bytes to fetch.  See KIP-74 for cases where this limit may not be honored.
		/// </summary>
		public Int32 MaxBytes 
		{
			get => _maxBytes;
			set 
			{
				_maxBytes = value;
			}
		}

		/// <summary>
		/// The maximum bytes to fetch.  See KIP-74 for cases where this limit may not be honored.
		/// </summary>
		public FetchRequest WithMaxBytes(Int32 maxBytes)
		{
			MaxBytes = maxBytes;
			return this;
		}

		private Int8 _isolationLevel = new Int8(0);
		/// <summary>
		/// This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records
		/// </summary>
		public Int8 IsolationLevel 
		{
			get => _isolationLevel;
			set 
			{
				if (Version.InRange(4, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"IsolationLevel does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
				}

				_isolationLevel = value;
			}
		}

		/// <summary>
		/// This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records
		/// </summary>
		public FetchRequest WithIsolationLevel(Int8 isolationLevel)
		{
			IsolationLevel = isolationLevel;
			return this;
		}

		private Int32 _sessionId = new Int32(0);
		/// <summary>
		/// The fetch session ID.
		/// </summary>
		public Int32 SessionId 
		{
			get => _sessionId;
			set 
			{
				if (Version.InRange(7, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"SessionId does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
				}

				_sessionId = value;
			}
		}

		/// <summary>
		/// The fetch session ID.
		/// </summary>
		public FetchRequest WithSessionId(Int32 sessionId)
		{
			SessionId = sessionId;
			return this;
		}

		private Int32 _epoch = new Int32(-1);
		/// <summary>
		/// The fetch session ID.
		/// </summary>
		public Int32 Epoch 
		{
			get => _epoch;
			set 
			{
				if (Version.InRange(7, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Epoch does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
				}

				_epoch = value;
			}
		}

		/// <summary>
		/// The fetch session ID.
		/// </summary>
		public FetchRequest WithEpoch(Int32 epoch)
		{
			Epoch = epoch;
			return this;
		}

		private FetchableTopic[] _topicsCollection = Array.Empty<FetchableTopic>();
		/// <summary>
		/// The topics to fetch.
		/// </summary>
		public FetchableTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// The topics to fetch.
		/// </summary>
		public FetchRequest WithTopicsCollection(params Func<FetchableTopic, FetchableTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateFetchableTopic()))
				.ToArray();
			return this;
		}

		internal FetchableTopic CreateFetchableTopic()
		{
			return new FetchableTopic(Version);
		}

		public class FetchableTopic : ISerialize
		{
			internal FetchableTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<FetchableTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new FetchableTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.FetchPartitionsCollection = await reader.ReadArrayAsync(async () => await FetchPartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, FetchPartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The name of the topic to fetch.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The name of the topic to fetch.
			/// </summary>
			public FetchableTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private FetchPartition[] _fetchPartitionsCollection = Array.Empty<FetchPartition>();
			/// <summary>
			/// The partitions to fetch.
			/// </summary>
			public FetchPartition[] FetchPartitionsCollection 
			{
				get => _fetchPartitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"FetchPartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_fetchPartitionsCollection = value;
				}
			}

			/// <summary>
			/// The partitions to fetch.
			/// </summary>
			public FetchableTopic WithFetchPartitionsCollection(params Func<FetchPartition, FetchPartition>[] createFields)
			{
				FetchPartitionsCollection = createFields
					.Select(createField => createField(CreateFetchPartition()))
					.ToArray();
				return this;
			}

			internal FetchPartition CreateFetchPartition()
			{
				return new FetchPartition(Version);
			}

			public class FetchPartition : ISerialize
			{
				internal FetchPartition(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<FetchPartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new FetchPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(9, 2147483647)) 
					{
						instance.CurrentLeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.FetchOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(5, 2147483647)) 
					{
						instance.LogStartOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.MaxBytes = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(9, 2147483647)) 
					{
						await writer.WriteInt32Async(CurrentLeaderEpoch, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(FetchOffset, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(5, 2147483647)) 
					{
						await writer.WriteInt64Async(LogStartOffset, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(MaxBytes, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public FetchPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int32 _currentLeaderEpoch = new Int32(-1);
				/// <summary>
				/// The current leader epoch of the partition.
				/// </summary>
				public Int32 CurrentLeaderEpoch 
				{
					get => _currentLeaderEpoch;
					set 
					{
						_currentLeaderEpoch = value;
					}
				}

				/// <summary>
				/// The current leader epoch of the partition.
				/// </summary>
				public FetchPartition WithCurrentLeaderEpoch(Int32 currentLeaderEpoch)
				{
					CurrentLeaderEpoch = currentLeaderEpoch;
					return this;
				}

				private Int64 _fetchOffset = Int64.Default;
				/// <summary>
				/// The message offset.
				/// </summary>
				public Int64 FetchOffset 
				{
					get => _fetchOffset;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"FetchOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_fetchOffset = value;
					}
				}

				/// <summary>
				/// The message offset.
				/// </summary>
				public FetchPartition WithFetchOffset(Int64 fetchOffset)
				{
					FetchOffset = fetchOffset;
					return this;
				}

				private Int64 _logStartOffset = new Int64(-1);
				/// <summary>
				/// The earliest available offset of the follower replica.  The field is only used when the request is sent by the follower.
				/// </summary>
				public Int64 LogStartOffset 
				{
					get => _logStartOffset;
					set 
					{
						if (Version.InRange(5, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"LogStartOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
						}

						_logStartOffset = value;
					}
				}

				/// <summary>
				/// The earliest available offset of the follower replica.  The field is only used when the request is sent by the follower.
				/// </summary>
				public FetchPartition WithLogStartOffset(Int64 logStartOffset)
				{
					LogStartOffset = logStartOffset;
					return this;
				}

				private Int32 _maxBytes = Int32.Default;
				/// <summary>
				/// The maximum bytes to fetch from this partition.  See KIP-74 for cases where this limit may not be honored.
				/// </summary>
				public Int32 MaxBytes 
				{
					get => _maxBytes;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"MaxBytes does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_maxBytes = value;
					}
				}

				/// <summary>
				/// The maximum bytes to fetch from this partition.  See KIP-74 for cases where this limit may not be honored.
				/// </summary>
				public FetchPartition WithMaxBytes(Int32 maxBytes)
				{
					MaxBytes = maxBytes;
					return this;
				}
			}
		}

		private ForgottenTopic[] _forgottenCollection = Array.Empty<ForgottenTopic>();
		/// <summary>
		/// In an incremental fetch request, the partitions to remove.
		/// </summary>
		public ForgottenTopic[] ForgottenCollection 
		{
			get => _forgottenCollection;
			set 
			{
				if (Version.InRange(7, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ForgottenCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
				}

				_forgottenCollection = value;
			}
		}

		/// <summary>
		/// In an incremental fetch request, the partitions to remove.
		/// </summary>
		public FetchRequest WithForgottenCollection(params Func<ForgottenTopic, ForgottenTopic>[] createFields)
		{
			ForgottenCollection = createFields
				.Select(createField => createField(CreateForgottenTopic()))
				.ToArray();
			return this;
		}

		internal ForgottenTopic CreateForgottenTopic()
		{
			return new ForgottenTopic(Version);
		}

		public class ForgottenTopic : ISerialize
		{
			internal ForgottenTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<ForgottenTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ForgottenTopic(version);
				if (instance.Version.InRange(7, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(7, 2147483647)) 
				{
					instance.ForgottenPartitionIndexesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(7, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(7, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ForgottenPartitionIndexesCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The partition name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(7, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The partition name.
			/// </summary>
			public ForgottenTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private Int32[] _forgottenPartitionIndexesCollection = Array.Empty<Int32>();
			/// <summary>
			/// The partitions indexes to forget.
			/// </summary>
			public Int32[] ForgottenPartitionIndexesCollection 
			{
				get => _forgottenPartitionIndexesCollection;
				set 
				{
					if (Version.InRange(7, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ForgottenPartitionIndexesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
					}

					_forgottenPartitionIndexesCollection = value;
				}
			}

			/// <summary>
			/// The partitions indexes to forget.
			/// </summary>
			public ForgottenTopic WithForgottenPartitionIndexesCollection(Int32[] forgottenPartitionIndexesCollection)
			{
				ForgottenPartitionIndexesCollection = forgottenPartitionIndexesCollection;
				return this;
			}
		}

		private String _rackId = new String();
		/// <summary>
		/// Rack ID of the consumer making this request
		/// </summary>
		public String RackId 
		{
			get => _rackId;
			set 
			{
				_rackId = value;
			}
		}

		/// <summary>
		/// Rack ID of the consumer making this request
		/// </summary>
		public FetchRequest WithRackId(String rackId)
		{
			RackId = rackId;
			return this;
		}

		public FetchResponse Respond()
			=> new FetchResponse(Version);
	}

	public class FetchResponse : Message
	{
		public FetchResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"FetchResponse does not support version {version}. Valid versions are: 0-11");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(1);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(11);

		public override Int16 Version { get; }

		public static async ValueTask<FetchResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new FetchResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.SessionId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await FetchableTopicResponse.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteInt32Async(SessionId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public FetchResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The top level response error code.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(7, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The top level response error code.
		/// </summary>
		public FetchResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private Int32 _sessionId = new Int32(0);
		/// <summary>
		/// The fetch session ID, or 0 if this is not part of a fetch session.
		/// </summary>
		public Int32 SessionId 
		{
			get => _sessionId;
			set 
			{
				if (Version.InRange(7, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"SessionId does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
				}

				_sessionId = value;
			}
		}

		/// <summary>
		/// The fetch session ID, or 0 if this is not part of a fetch session.
		/// </summary>
		public FetchResponse WithSessionId(Int32 sessionId)
		{
			SessionId = sessionId;
			return this;
		}

		private FetchableTopicResponse[] _topicsCollection = Array.Empty<FetchableTopicResponse>();
		/// <summary>
		/// The response topics.
		/// </summary>
		public FetchableTopicResponse[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// The response topics.
		/// </summary>
		public FetchResponse WithTopicsCollection(params Func<FetchableTopicResponse, FetchableTopicResponse>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateFetchableTopicResponse()))
				.ToArray();
			return this;
		}

		internal FetchableTopicResponse CreateFetchableTopicResponse()
		{
			return new FetchableTopicResponse(Version);
		}

		public class FetchableTopicResponse : ISerialize
		{
			internal FetchableTopicResponse(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<FetchableTopicResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new FetchableTopicResponse(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await FetchablePartitionResponse.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public FetchableTopicResponse WithName(String name)
			{
				Name = name;
				return this;
			}

			private FetchablePartitionResponse[] _partitionsCollection = Array.Empty<FetchablePartitionResponse>();
			/// <summary>
			/// The topic partitions.
			/// </summary>
			public FetchablePartitionResponse[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// The topic partitions.
			/// </summary>
			public FetchableTopicResponse WithPartitionsCollection(params Func<FetchablePartitionResponse, FetchablePartitionResponse>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateFetchablePartitionResponse()))
					.ToArray();
				return this;
			}

			internal FetchablePartitionResponse CreateFetchablePartitionResponse()
			{
				return new FetchablePartitionResponse(Version);
			}

			public class FetchablePartitionResponse : ISerialize
			{
				internal FetchablePartitionResponse(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<FetchablePartitionResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new FetchablePartitionResponse(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.HighWatermark = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(4, 2147483647)) 
					{
						instance.LastStableOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(5, 2147483647)) 
					{
						instance.LogStartOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(4, 2147483647)) 
					{
						instance.AbortedCollection = await reader.ReadNullableArrayAsync(async () => await AbortedTransaction.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(11, 2147483647)) 
					{
						instance.PreferredReadReplica = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Records = await reader.ReadNullableBytesAsync(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(HighWatermark, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(4, 2147483647)) 
					{
						await writer.WriteInt64Async(LastStableOffset, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(5, 2147483647)) 
					{
						await writer.WriteInt64Async(LogStartOffset, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(4, 2147483647)) 
					{
						await writer.WriteNullableArrayAsync(cancellationToken, AbortedCollection).ConfigureAwait(false);
					}
					if (Version.InRange(11, 2147483647)) 
					{
						await writer.WriteInt32Async(PreferredReadReplica, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableBytesAsync(Records, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partiiton index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partiiton index.
				/// </summary>
				public FetchablePartitionResponse WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The error code, or 0 if there was no fetch error.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The error code, or 0 if there was no fetch error.
				/// </summary>
				public FetchablePartitionResponse WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				private Int64 _highWatermark = Int64.Default;
				/// <summary>
				/// The current high water mark.
				/// </summary>
				public Int64 HighWatermark 
				{
					get => _highWatermark;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"HighWatermark does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_highWatermark = value;
					}
				}

				/// <summary>
				/// The current high water mark.
				/// </summary>
				public FetchablePartitionResponse WithHighWatermark(Int64 highWatermark)
				{
					HighWatermark = highWatermark;
					return this;
				}

				private Int64 _lastStableOffset = new Int64(-1);
				/// <summary>
				/// The last stable offset (or LSO) of the partition. This is the last offset such that the state of all transactional records prior to this offset have been decided (ABORTED or COMMITTED)
				/// </summary>
				public Int64 LastStableOffset 
				{
					get => _lastStableOffset;
					set 
					{
						_lastStableOffset = value;
					}
				}

				/// <summary>
				/// The last stable offset (or LSO) of the partition. This is the last offset such that the state of all transactional records prior to this offset have been decided (ABORTED or COMMITTED)
				/// </summary>
				public FetchablePartitionResponse WithLastStableOffset(Int64 lastStableOffset)
				{
					LastStableOffset = lastStableOffset;
					return this;
				}

				private Int64 _logStartOffset = new Int64(-1);
				/// <summary>
				/// The current log start offset.
				/// </summary>
				public Int64 LogStartOffset 
				{
					get => _logStartOffset;
					set 
					{
						_logStartOffset = value;
					}
				}

				/// <summary>
				/// The current log start offset.
				/// </summary>
				public FetchablePartitionResponse WithLogStartOffset(Int64 logStartOffset)
				{
					LogStartOffset = logStartOffset;
					return this;
				}

				private AbortedTransaction[]? _abortedCollection = Array.Empty<AbortedTransaction>();
				/// <summary>
				/// The aborted transactions.
				/// </summary>
				public AbortedTransaction[]? AbortedCollection 
				{
					get => _abortedCollection;
					set 
					{
						if (Version.InRange(4, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"AbortedCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
						}

						if (Version.InRange(4, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"AbortedCollection does not support null for version {Version}. Supported versions for null value: 4+");
						}

						_abortedCollection = value;
					}
				}

				/// <summary>
				/// The aborted transactions.
				/// </summary>
				public FetchablePartitionResponse WithAbortedCollection(params Func<AbortedTransaction, AbortedTransaction>[] createFields)
				{
					AbortedCollection = createFields
						.Select(createField => createField(CreateAbortedTransaction()))
						.ToArray();
					return this;
				}

				internal AbortedTransaction CreateAbortedTransaction()
				{
					return new AbortedTransaction(Version);
				}

				public class AbortedTransaction : ISerialize
				{
					internal AbortedTransaction(Int16 version)
					{
						Version = version;
					}

					internal Int16 Version { get; }

					public static async ValueTask<AbortedTransaction> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
					{
						var instance = new AbortedTransaction(version);
						if (instance.Version.InRange(4, 2147483647)) 
						{
							instance.ProducerId = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
						}
						if (instance.Version.InRange(4, 2147483647)) 
						{
							instance.FirstOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
						}
						return instance;
					}

					public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
					{
						if (Version.InRange(4, 2147483647)) 
						{
							await writer.WriteInt64Async(ProducerId, cancellationToken).ConfigureAwait(false);
						}
						if (Version.InRange(4, 2147483647)) 
						{
							await writer.WriteInt64Async(FirstOffset, cancellationToken).ConfigureAwait(false);
						}
					}

					private Int64 _producerId = Int64.Default;
					/// <summary>
					/// The producer id associated with the aborted transaction.
					/// </summary>
					public Int64 ProducerId 
					{
						get => _producerId;
						set 
						{
							if (Version.InRange(4, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"ProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
							}

							_producerId = value;
						}
					}

					/// <summary>
					/// The producer id associated with the aborted transaction.
					/// </summary>
					public AbortedTransaction WithProducerId(Int64 producerId)
					{
						ProducerId = producerId;
						return this;
					}

					private Int64 _firstOffset = Int64.Default;
					/// <summary>
					/// The first offset in the aborted transaction.
					/// </summary>
					public Int64 FirstOffset 
					{
						get => _firstOffset;
						set 
						{
							if (Version.InRange(4, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"FirstOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
							}

							_firstOffset = value;
						}
					}

					/// <summary>
					/// The first offset in the aborted transaction.
					/// </summary>
					public AbortedTransaction WithFirstOffset(Int64 firstOffset)
					{
						FirstOffset = firstOffset;
						return this;
					}
				}

				private Int32 _preferredReadReplica = Int32.Default;
				/// <summary>
				/// The preferred read replica for the consumer to use on its next fetch request
				/// </summary>
				public Int32 PreferredReadReplica 
				{
					get => _preferredReadReplica;
					set 
					{
						_preferredReadReplica = value;
					}
				}

				/// <summary>
				/// The preferred read replica for the consumer to use on its next fetch request
				/// </summary>
				public FetchablePartitionResponse WithPreferredReadReplica(Int32 preferredReadReplica)
				{
					PreferredReadReplica = preferredReadReplica;
					return this;
				}

				private Bytes? _records = Bytes.Default;
				/// <summary>
				/// The record data.
				/// </summary>
				public Bytes? Records 
				{
					get => _records;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Records does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"Records does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_records = value;
					}
				}

				/// <summary>
				/// The record data.
				/// </summary>
				public FetchablePartitionResponse WithRecords(Bytes records)
				{
					Records = records;
					return this;
				}
			}
		}
	}

	public class FindCoordinatorRequest : Message, IRespond<FindCoordinatorResponse>
	{
		public FindCoordinatorRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"FindCoordinatorRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(10);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<FindCoordinatorRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new FindCoordinatorRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Key = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.KeyType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(Key, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt8Async(KeyType, cancellationToken).ConfigureAwait(false);
			}
		}

		private String _key = String.Default;
		/// <summary>
		/// The coordinator key.
		/// </summary>
		public String Key 
		{
			get => _key;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Key does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_key = value;
			}
		}

		/// <summary>
		/// The coordinator key.
		/// </summary>
		public FindCoordinatorRequest WithKey(String key)
		{
			Key = key;
			return this;
		}

		private Int8 _keyType = new Int8(0);
		/// <summary>
		/// The coordinator key type.  (Group, transaction, etc.)
		/// </summary>
		public Int8 KeyType 
		{
			get => _keyType;
			set 
			{
				if (Version.InRange(1, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"KeyType does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
				}

				_keyType = value;
			}
		}

		/// <summary>
		/// The coordinator key type.  (Group, transaction, etc.)
		/// </summary>
		public FindCoordinatorRequest WithKeyType(Int8 keyType)
		{
			KeyType = keyType;
			return this;
		}

		public FindCoordinatorResponse Respond()
			=> new FindCoordinatorResponse(Version);
	}

	public class FindCoordinatorResponse : Message
	{
		public FindCoordinatorResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"FindCoordinatorResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(10);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<FindCoordinatorResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new FindCoordinatorResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.NodeId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Host = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Port = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(NodeId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(Host, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(Port, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public FindCoordinatorResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public FindCoordinatorResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private String? _errorMessage = String.Default;
		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public String? ErrorMessage 
		{
			get => _errorMessage;
			set 
			{
				if (Version.InRange(1, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 1+");
				}

				_errorMessage = value;
			}
		}

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public FindCoordinatorResponse WithErrorMessage(String errorMessage)
		{
			ErrorMessage = errorMessage;
			return this;
		}

		private Int32 _nodeId = Int32.Default;
		/// <summary>
		/// The node id.
		/// </summary>
		public Int32 NodeId 
		{
			get => _nodeId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"NodeId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_nodeId = value;
			}
		}

		/// <summary>
		/// The node id.
		/// </summary>
		public FindCoordinatorResponse WithNodeId(Int32 nodeId)
		{
			NodeId = nodeId;
			return this;
		}

		private String _host = String.Default;
		/// <summary>
		/// The host name.
		/// </summary>
		public String Host 
		{
			get => _host;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_host = value;
			}
		}

		/// <summary>
		/// The host name.
		/// </summary>
		public FindCoordinatorResponse WithHost(String host)
		{
			Host = host;
			return this;
		}

		private Int32 _port = Int32.Default;
		/// <summary>
		/// The port.
		/// </summary>
		public Int32 Port 
		{
			get => _port;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_port = value;
			}
		}

		/// <summary>
		/// The port.
		/// </summary>
		public FindCoordinatorResponse WithPort(Int32 port)
		{
			Port = port;
			return this;
		}
	}

	public class HeartbeatRequest : Message, IRespond<HeartbeatResponse>
	{
		public HeartbeatRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"HeartbeatRequest does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(12);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(3);

		public override Int16 Version { get; }

		public static async ValueTask<HeartbeatRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new HeartbeatRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GenerationId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(GenerationId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken).ConfigureAwait(false);
			}
		}

		private String _groupId = String.Default;
		/// <summary>
		/// The group id.
		/// </summary>
		public String GroupId 
		{
			get => _groupId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupId = value;
			}
		}

		/// <summary>
		/// The group id.
		/// </summary>
		public HeartbeatRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		private Int32 _generationId = Int32.Default;
		/// <summary>
		/// The generation of the group.
		/// </summary>
		public Int32 GenerationId 
		{
			get => _generationId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GenerationId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_generationId = value;
			}
		}

		/// <summary>
		/// The generation of the group.
		/// </summary>
		public HeartbeatRequest WithGenerationId(Int32 generationId)
		{
			GenerationId = generationId;
			return this;
		}

		private String _memberId = String.Default;
		/// <summary>
		/// The member ID.
		/// </summary>
		public String MemberId 
		{
			get => _memberId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_memberId = value;
			}
		}

		/// <summary>
		/// The member ID.
		/// </summary>
		public HeartbeatRequest WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}

		private String? _groupInstanceId;
		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		public String? GroupInstanceId 
		{
			get => _groupInstanceId;
			set 
			{
				if (Version.InRange(3, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
				}

				if (Version.InRange(3, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 3+");
				}

				_groupInstanceId = value;
			}
		}

		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		public HeartbeatRequest WithGroupInstanceId(String groupInstanceId)
		{
			GroupInstanceId = groupInstanceId;
			return this;
		}

		public HeartbeatResponse Respond()
			=> new HeartbeatResponse(Version);
	}

	public class HeartbeatResponse : Message
	{
		public HeartbeatResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"HeartbeatResponse does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(12);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(3);

		public override Int16 Version { get; }

		public static async ValueTask<HeartbeatResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new HeartbeatResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public HeartbeatResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public HeartbeatResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class IncrementalAlterConfigsRequest : Message, IRespond<IncrementalAlterConfigsResponse>
	{
		public IncrementalAlterConfigsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"IncrementalAlterConfigsRequest does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(44);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(0);

		public override Int16 Version { get; }

		public static async ValueTask<IncrementalAlterConfigsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new IncrementalAlterConfigsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourcesCollection = (await reader.ReadArrayAsync(async () => await AlterConfigsResource.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.ResourceType);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ValidateOnly = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResourcesCollection.Values.ToArray()).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBooleanAsync(ValidateOnly, cancellationToken).ConfigureAwait(false);
			}
		}

		private Dictionary<Int8, AlterConfigsResource> _resourcesCollection = new Dictionary<Int8, AlterConfigsResource>();
		/// <summary>
		/// The incremental updates for each resource.
		/// </summary>
		public Dictionary<Int8, AlterConfigsResource> ResourcesCollection 
		{
			get => _resourcesCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResourcesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_resourcesCollection = value;
			}
		}

		/// <summary>
		/// The incremental updates for each resource.
		/// </summary>
		public IncrementalAlterConfigsRequest WithResourcesCollection(params Func<AlterConfigsResource, AlterConfigsResource>[] createFields)
		{
			ResourcesCollection = createFields
				.Select(createField => createField(CreateAlterConfigsResource()))
				.ToDictionary(field => field.ResourceType);
			return this;
		}

		internal AlterConfigsResource CreateAlterConfigsResource()
		{
			return new AlterConfigsResource(Version);
		}

		public class AlterConfigsResource : ISerialize
		{
			internal AlterConfigsResource(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<AlterConfigsResource> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterConfigsResource(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ConfigsCollection = (await reader.ReadArrayAsync(async () => await AlterableConfig.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ConfigsCollection.Values.ToArray()).ConfigureAwait(false);
				}
			}

			private Int8 _resourceType = Int8.Default;
			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceType 
			{
				get => _resourceType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceType = value;
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public AlterConfigsResource WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			private String _resourceName = String.Default;
			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceName 
			{
				get => _resourceName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceName = value;
				}
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			public AlterConfigsResource WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}

			private Dictionary<String, AlterableConfig> _configsCollection = new Dictionary<String, AlterableConfig>();
			/// <summary>
			/// The configurations.
			/// </summary>
			public Dictionary<String, AlterableConfig> ConfigsCollection 
			{
				get => _configsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ConfigsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_configsCollection = value;
				}
			}

			/// <summary>
			/// The configurations.
			/// </summary>
			public AlterConfigsResource WithConfigsCollection(params Func<AlterableConfig, AlterableConfig>[] createFields)
			{
				ConfigsCollection = createFields
					.Select(createField => createField(CreateAlterableConfig()))
					.ToDictionary(field => field.Name);
				return this;
			}

			internal AlterableConfig CreateAlterableConfig()
			{
				return new AlterableConfig(Version);
			}

			public class AlterableConfig : ISerialize
			{
				internal AlterableConfig(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<AlterableConfig> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AlterableConfig(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ConfigOperation = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Value = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(ConfigOperation, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(Value, cancellationToken).ConfigureAwait(false);
					}
				}

				private String _name = String.Default;
				/// <summary>
				/// The configuration key name.
				/// </summary>
				public String Name 
				{
					get => _name;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_name = value;
					}
				}

				/// <summary>
				/// The configuration key name.
				/// </summary>
				public AlterableConfig WithName(String name)
				{
					Name = name;
					return this;
				}

				private Int8 _configOperation = Int8.Default;
				/// <summary>
				/// The type (Set, Delete, Append, Subtract) of operation.
				/// </summary>
				public Int8 ConfigOperation 
				{
					get => _configOperation;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ConfigOperation does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_configOperation = value;
					}
				}

				/// <summary>
				/// The type (Set, Delete, Append, Subtract) of operation.
				/// </summary>
				public AlterableConfig WithConfigOperation(Int8 configOperation)
				{
					ConfigOperation = configOperation;
					return this;
				}

				private String? _value = String.Default;
				/// <summary>
				/// The value to set for the configuration key.
				/// </summary>
				public String? Value 
				{
					get => _value;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Value does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"Value does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_value = value;
					}
				}

				/// <summary>
				/// The value to set for the configuration key.
				/// </summary>
				public AlterableConfig WithValue(String value)
				{
					Value = value;
					return this;
				}
			}
		}

		private Boolean _validateOnly = Boolean.Default;
		/// <summary>
		/// True if we should validate the request, but not change the configurations.
		/// </summary>
		public Boolean ValidateOnly 
		{
			get => _validateOnly;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ValidateOnly does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_validateOnly = value;
			}
		}

		/// <summary>
		/// True if we should validate the request, but not change the configurations.
		/// </summary>
		public IncrementalAlterConfigsRequest WithValidateOnly(Boolean validateOnly)
		{
			ValidateOnly = validateOnly;
			return this;
		}

		public IncrementalAlterConfigsResponse Respond()
			=> new IncrementalAlterConfigsResponse(Version);
	}

	public class IncrementalAlterConfigsResponse : Message
	{
		public IncrementalAlterConfigsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"IncrementalAlterConfigsResponse does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(44);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(0);

		public override Int16 Version { get; }

		public static async ValueTask<IncrementalAlterConfigsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new IncrementalAlterConfigsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResponsesCollection = await reader.ReadArrayAsync(async () => await AlterConfigsResourceResponse.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResponsesCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public IncrementalAlterConfigsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private AlterConfigsResourceResponse[] _responsesCollection = Array.Empty<AlterConfigsResourceResponse>();
		/// <summary>
		/// The responses for each resource.
		/// </summary>
		public AlterConfigsResourceResponse[] ResponsesCollection 
		{
			get => _responsesCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResponsesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_responsesCollection = value;
			}
		}

		/// <summary>
		/// The responses for each resource.
		/// </summary>
		public IncrementalAlterConfigsResponse WithResponsesCollection(params Func<AlterConfigsResourceResponse, AlterConfigsResourceResponse>[] createFields)
		{
			ResponsesCollection = createFields
				.Select(createField => createField(CreateAlterConfigsResourceResponse()))
				.ToArray();
			return this;
		}

		internal AlterConfigsResourceResponse CreateAlterConfigsResourceResponse()
		{
			return new AlterConfigsResourceResponse(Version);
		}

		public class AlterConfigsResourceResponse : ISerialize
		{
			internal AlterConfigsResourceResponse(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<AlterConfigsResourceResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterConfigsResourceResponse(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The resource error code.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The resource error code.
			/// </summary>
			public AlterConfigsResourceResponse WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			private String? _errorMessage = String.Default;
			/// <summary>
			/// The resource error message, or null if there was no error.
			/// </summary>
			public String? ErrorMessage 
			{
				get => _errorMessage;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_errorMessage = value;
				}
			}

			/// <summary>
			/// The resource error message, or null if there was no error.
			/// </summary>
			public AlterConfigsResourceResponse WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}

			private Int8 _resourceType = Int8.Default;
			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceType 
			{
				get => _resourceType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceType = value;
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public AlterConfigsResourceResponse WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			private String _resourceName = String.Default;
			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceName 
			{
				get => _resourceName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ResourceName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_resourceName = value;
				}
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			public AlterConfigsResourceResponse WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}
		}
	}

	public class InitProducerIdRequest : Message, IRespond<InitProducerIdResponse>
	{
		public InitProducerIdRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"InitProducerIdRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(22);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<InitProducerIdRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new InitProducerIdRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionTimeoutMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(TransactionalId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TransactionTimeoutMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private String? _transactionalId = String.Default;
		/// <summary>
		/// The transactional id, or null if the producer is not transactional.
		/// </summary>
		public String? TransactionalId 
		{
			get => _transactionalId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TransactionalId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(0, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"TransactionalId does not support null for version {Version}. Supported versions for null value: 0+");
				}

				_transactionalId = value;
			}
		}

		/// <summary>
		/// The transactional id, or null if the producer is not transactional.
		/// </summary>
		public InitProducerIdRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		private Int32 _transactionTimeoutMs = Int32.Default;
		/// <summary>
		/// The time in ms to wait for before aborting idle transactions sent by this producer. This is only relevant if a TransactionalId has been defined.
		/// </summary>
		public Int32 TransactionTimeoutMs 
		{
			get => _transactionTimeoutMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TransactionTimeoutMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_transactionTimeoutMs = value;
			}
		}

		/// <summary>
		/// The time in ms to wait for before aborting idle transactions sent by this producer. This is only relevant if a TransactionalId has been defined.
		/// </summary>
		public InitProducerIdRequest WithTransactionTimeoutMs(Int32 transactionTimeoutMs)
		{
			TransactionTimeoutMs = transactionTimeoutMs;
			return this;
		}

		public InitProducerIdResponse Respond()
			=> new InitProducerIdResponse(Version);
	}

	public class InitProducerIdResponse : Message
	{
		public InitProducerIdResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"InitProducerIdResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(22);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<InitProducerIdResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new InitProducerIdResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerId = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ProducerId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ProducerEpoch, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public InitProducerIdResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public InitProducerIdResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private Int64 _producerId = new Int64(-1);
		/// <summary>
		/// The current producer id.
		/// </summary>
		public Int64 ProducerId 
		{
			get => _producerId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_producerId = value;
			}
		}

		/// <summary>
		/// The current producer id.
		/// </summary>
		public InitProducerIdResponse WithProducerId(Int64 producerId)
		{
			ProducerId = producerId;
			return this;
		}

		private Int16 _producerEpoch = Int16.Default;
		/// <summary>
		/// The current epoch associated with the producer id.
		/// </summary>
		public Int16 ProducerEpoch 
		{
			get => _producerEpoch;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProducerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_producerEpoch = value;
			}
		}

		/// <summary>
		/// The current epoch associated with the producer id.
		/// </summary>
		public InitProducerIdResponse WithProducerEpoch(Int16 producerEpoch)
		{
			ProducerEpoch = producerEpoch;
			return this;
		}
	}

	public class JoinGroupRequest : Message, IRespond<JoinGroupResponse>
	{
		public JoinGroupRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"JoinGroupRequest does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(11);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(5);

		public override Int16 Version { get; }

		public static async ValueTask<JoinGroupRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new JoinGroupRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.SessionTimeoutMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.RebalanceTimeoutMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(5, 2147483647)) 
			{
				instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProtocolType = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProtocolsCollection = (await reader.ReadArrayAsync(async () => await JoinGroupRequestProtocol.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(SessionTimeoutMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(RebalanceTimeoutMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(5, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(ProtocolType, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ProtocolsCollection.Values.ToArray()).ConfigureAwait(false);
			}
		}

		private String _groupId = String.Default;
		/// <summary>
		/// The group identifier.
		/// </summary>
		public String GroupId 
		{
			get => _groupId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupId = value;
			}
		}

		/// <summary>
		/// The group identifier.
		/// </summary>
		public JoinGroupRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		private Int32 _sessionTimeoutMs = Int32.Default;
		/// <summary>
		/// The coordinator considers the consumer dead if it receives no heartbeat after this timeout in milliseconds.
		/// </summary>
		public Int32 SessionTimeoutMs 
		{
			get => _sessionTimeoutMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"SessionTimeoutMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_sessionTimeoutMs = value;
			}
		}

		/// <summary>
		/// The coordinator considers the consumer dead if it receives no heartbeat after this timeout in milliseconds.
		/// </summary>
		public JoinGroupRequest WithSessionTimeoutMs(Int32 sessionTimeoutMs)
		{
			SessionTimeoutMs = sessionTimeoutMs;
			return this;
		}

		private Int32 _rebalanceTimeoutMs = new Int32(-1);
		/// <summary>
		/// The maximum time in milliseconds that the coordinator will wait for each member to rejoin when rebalancing the group.
		/// </summary>
		public Int32 RebalanceTimeoutMs 
		{
			get => _rebalanceTimeoutMs;
			set 
			{
				_rebalanceTimeoutMs = value;
			}
		}

		/// <summary>
		/// The maximum time in milliseconds that the coordinator will wait for each member to rejoin when rebalancing the group.
		/// </summary>
		public JoinGroupRequest WithRebalanceTimeoutMs(Int32 rebalanceTimeoutMs)
		{
			RebalanceTimeoutMs = rebalanceTimeoutMs;
			return this;
		}

		private String _memberId = String.Default;
		/// <summary>
		/// The member id assigned by the group coordinator.
		/// </summary>
		public String MemberId 
		{
			get => _memberId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_memberId = value;
			}
		}

		/// <summary>
		/// The member id assigned by the group coordinator.
		/// </summary>
		public JoinGroupRequest WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}

		private String? _groupInstanceId;
		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		public String? GroupInstanceId 
		{
			get => _groupInstanceId;
			set 
			{
				if (Version.InRange(5, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
				}

				if (Version.InRange(5, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 5+");
				}

				_groupInstanceId = value;
			}
		}

		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		public JoinGroupRequest WithGroupInstanceId(String groupInstanceId)
		{
			GroupInstanceId = groupInstanceId;
			return this;
		}

		private String _protocolType = String.Default;
		/// <summary>
		/// The unique name the for class of protocols implemented by the group we want to join.
		/// </summary>
		public String ProtocolType 
		{
			get => _protocolType;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProtocolType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_protocolType = value;
			}
		}

		/// <summary>
		/// The unique name the for class of protocols implemented by the group we want to join.
		/// </summary>
		public JoinGroupRequest WithProtocolType(String protocolType)
		{
			ProtocolType = protocolType;
			return this;
		}

		private Dictionary<String, JoinGroupRequestProtocol> _protocolsCollection = new Dictionary<String, JoinGroupRequestProtocol>();
		/// <summary>
		/// The list of protocols that the member supports.
		/// </summary>
		public Dictionary<String, JoinGroupRequestProtocol> ProtocolsCollection 
		{
			get => _protocolsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProtocolsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_protocolsCollection = value;
			}
		}

		/// <summary>
		/// The list of protocols that the member supports.
		/// </summary>
		public JoinGroupRequest WithProtocolsCollection(params Func<JoinGroupRequestProtocol, JoinGroupRequestProtocol>[] createFields)
		{
			ProtocolsCollection = createFields
				.Select(createField => createField(CreateJoinGroupRequestProtocol()))
				.ToDictionary(field => field.Name);
			return this;
		}

		internal JoinGroupRequestProtocol CreateJoinGroupRequestProtocol()
		{
			return new JoinGroupRequestProtocol(Version);
		}

		public class JoinGroupRequestProtocol : ISerialize
		{
			internal JoinGroupRequestProtocol(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<JoinGroupRequestProtocol> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new JoinGroupRequestProtocol(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Metadata = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteBytesAsync(Metadata, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The protocol name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The protocol name.
			/// </summary>
			public JoinGroupRequestProtocol WithName(String name)
			{
				Name = name;
				return this;
			}

			private Bytes _metadata = Bytes.Default;
			/// <summary>
			/// The protocol metadata.
			/// </summary>
			public Bytes Metadata 
			{
				get => _metadata;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Metadata does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_metadata = value;
				}
			}

			/// <summary>
			/// The protocol metadata.
			/// </summary>
			public JoinGroupRequestProtocol WithMetadata(Bytes metadata)
			{
				Metadata = metadata;
				return this;
			}
		}

		public JoinGroupResponse Respond()
			=> new JoinGroupResponse(Version);
	}

	public class JoinGroupResponse : Message
	{
		public JoinGroupResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"JoinGroupResponse does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(11);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(5);

		public override Int16 Version { get; }

		public static async ValueTask<JoinGroupResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new JoinGroupResponse(version);
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GenerationId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProtocolName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Leader = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MembersCollection = await reader.ReadArrayAsync(async () => await JoinGroupResponseMember.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(GenerationId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(ProtocolName, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(Leader, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, MembersCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public JoinGroupResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public JoinGroupResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private Int32 _generationId = new Int32(-1);
		/// <summary>
		/// The generation ID of the group.
		/// </summary>
		public Int32 GenerationId 
		{
			get => _generationId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GenerationId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_generationId = value;
			}
		}

		/// <summary>
		/// The generation ID of the group.
		/// </summary>
		public JoinGroupResponse WithGenerationId(Int32 generationId)
		{
			GenerationId = generationId;
			return this;
		}

		private String _protocolName = String.Default;
		/// <summary>
		/// The group protocol selected by the coordinator.
		/// </summary>
		public String ProtocolName 
		{
			get => _protocolName;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProtocolName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_protocolName = value;
			}
		}

		/// <summary>
		/// The group protocol selected by the coordinator.
		/// </summary>
		public JoinGroupResponse WithProtocolName(String protocolName)
		{
			ProtocolName = protocolName;
			return this;
		}

		private String _leader = String.Default;
		/// <summary>
		/// The leader of the group.
		/// </summary>
		public String Leader 
		{
			get => _leader;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Leader does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_leader = value;
			}
		}

		/// <summary>
		/// The leader of the group.
		/// </summary>
		public JoinGroupResponse WithLeader(String leader)
		{
			Leader = leader;
			return this;
		}

		private String _memberId = String.Default;
		/// <summary>
		/// The member ID assigned by the group coordinator.
		/// </summary>
		public String MemberId 
		{
			get => _memberId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_memberId = value;
			}
		}

		/// <summary>
		/// The member ID assigned by the group coordinator.
		/// </summary>
		public JoinGroupResponse WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}

		private JoinGroupResponseMember[] _membersCollection = Array.Empty<JoinGroupResponseMember>();
		public JoinGroupResponseMember[] MembersCollection 
		{
			get => _membersCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MembersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_membersCollection = value;
			}
		}

		public JoinGroupResponse WithMembersCollection(params Func<JoinGroupResponseMember, JoinGroupResponseMember>[] createFields)
		{
			MembersCollection = createFields
				.Select(createField => createField(CreateJoinGroupResponseMember()))
				.ToArray();
			return this;
		}

		internal JoinGroupResponseMember CreateJoinGroupResponseMember()
		{
			return new JoinGroupResponseMember(Version);
		}

		public class JoinGroupResponseMember : ISerialize
		{
			internal JoinGroupResponseMember(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<JoinGroupResponseMember> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new JoinGroupResponseMember(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MemberId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(5, 2147483647)) 
				{
					instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Metadata = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(MemberId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(5, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteBytesAsync(Metadata, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _memberId = String.Default;
			/// <summary>
			/// The group member ID.
			/// </summary>
			public String MemberId 
			{
				get => _memberId;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_memberId = value;
				}
			}

			/// <summary>
			/// The group member ID.
			/// </summary>
			public JoinGroupResponseMember WithMemberId(String memberId)
			{
				MemberId = memberId;
				return this;
			}

			private String? _groupInstanceId;
			/// <summary>
			/// The unique identifier of the consumer instance provided by end user.
			/// </summary>
			public String? GroupInstanceId 
			{
				get => _groupInstanceId;
				set 
				{
					if (Version.InRange(5, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
					}

					if (Version.InRange(5, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 5+");
					}

					_groupInstanceId = value;
				}
			}

			/// <summary>
			/// The unique identifier of the consumer instance provided by end user.
			/// </summary>
			public JoinGroupResponseMember WithGroupInstanceId(String groupInstanceId)
			{
				GroupInstanceId = groupInstanceId;
				return this;
			}

			private Bytes _metadata = Bytes.Default;
			/// <summary>
			/// The group member metadata.
			/// </summary>
			public Bytes Metadata 
			{
				get => _metadata;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Metadata does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_metadata = value;
				}
			}

			/// <summary>
			/// The group member metadata.
			/// </summary>
			public JoinGroupResponseMember WithMetadata(Bytes metadata)
			{
				Metadata = metadata;
				return this;
			}
		}
	}

	public class LeaderAndIsrRequest : Message, IRespond<LeaderAndIsrResponse>
	{
		public LeaderAndIsrRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"LeaderAndIsrRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(4);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<LeaderAndIsrRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new LeaderAndIsrRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.BrokerEpoch = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 1)) 
			{
				instance.PartitionStatesV0Collection = await reader.ReadArrayAsync(async () => await LeaderAndIsrRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.TopicStatesCollection = await reader.ReadArrayAsync(async () => await LeaderAndIsrRequestTopicState.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.LiveLeadersCollection = await reader.ReadArrayAsync(async () => await LeaderAndIsrLiveLeader.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerEpoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt64Async(BrokerEpoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 1)) 
			{
				await writer.WriteArrayAsync(cancellationToken, PartitionStatesV0Collection).ConfigureAwait(false);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicStatesCollection).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, LiveLeadersCollection).ConfigureAwait(false);
			}
		}

		private Int32 _controllerId = Int32.Default;
		/// <summary>
		/// The current controller ID.
		/// </summary>
		public Int32 ControllerId 
		{
			get => _controllerId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ControllerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_controllerId = value;
			}
		}

		/// <summary>
		/// The current controller ID.
		/// </summary>
		public LeaderAndIsrRequest WithControllerId(Int32 controllerId)
		{
			ControllerId = controllerId;
			return this;
		}

		private Int32 _controllerEpoch = Int32.Default;
		/// <summary>
		/// The current controller epoch.
		/// </summary>
		public Int32 ControllerEpoch 
		{
			get => _controllerEpoch;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ControllerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_controllerEpoch = value;
			}
		}

		/// <summary>
		/// The current controller epoch.
		/// </summary>
		public LeaderAndIsrRequest WithControllerEpoch(Int32 controllerEpoch)
		{
			ControllerEpoch = controllerEpoch;
			return this;
		}

		private Int64 _brokerEpoch = new Int64(-1);
		/// <summary>
		/// The current broker epoch.
		/// </summary>
		public Int64 BrokerEpoch 
		{
			get => _brokerEpoch;
			set 
			{
				_brokerEpoch = value;
			}
		}

		/// <summary>
		/// The current broker epoch.
		/// </summary>
		public LeaderAndIsrRequest WithBrokerEpoch(Int64 brokerEpoch)
		{
			BrokerEpoch = brokerEpoch;
			return this;
		}

		private LeaderAndIsrRequestPartition[] _partitionStatesV0Collection = Array.Empty<LeaderAndIsrRequestPartition>();
		/// <summary>
		/// The state of each partition, in a v0 or v1 message.
		/// </summary>
		public LeaderAndIsrRequestPartition[] PartitionStatesV0Collection 
		{
			get => _partitionStatesV0Collection;
			set 
			{
				if (Version.InRange(0, 1) == false) 
				{
					throw new UnsupportedVersionException($"PartitionStatesV0Collection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-1");
				}

				_partitionStatesV0Collection = value;
			}
		}

		/// <summary>
		/// The state of each partition, in a v0 or v1 message.
		/// </summary>
		public LeaderAndIsrRequest WithPartitionStatesV0Collection(LeaderAndIsrRequestPartition[] partitionStatesV0Collection)
		{
			PartitionStatesV0Collection = partitionStatesV0Collection;
			return this;
		}

		private LeaderAndIsrRequestTopicState[] _topicStatesCollection = Array.Empty<LeaderAndIsrRequestTopicState>();
		/// <summary>
		/// Each topic.
		/// </summary>
		public LeaderAndIsrRequestTopicState[] TopicStatesCollection 
		{
			get => _topicStatesCollection;
			set 
			{
				if (Version.InRange(2, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
				}

				_topicStatesCollection = value;
			}
		}

		/// <summary>
		/// Each topic.
		/// </summary>
		public LeaderAndIsrRequest WithTopicStatesCollection(params Func<LeaderAndIsrRequestTopicState, LeaderAndIsrRequestTopicState>[] createFields)
		{
			TopicStatesCollection = createFields
				.Select(createField => createField(CreateLeaderAndIsrRequestTopicState()))
				.ToArray();
			return this;
		}

		internal LeaderAndIsrRequestTopicState CreateLeaderAndIsrRequestTopicState()
		{
			return new LeaderAndIsrRequestTopicState(Version);
		}

		public class LeaderAndIsrRequestTopicState : ISerialize
		{
			internal LeaderAndIsrRequestTopicState(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<LeaderAndIsrRequestTopicState> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new LeaderAndIsrRequestTopicState(version);
				if (instance.Version.InRange(2, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(2, 2147483647)) 
				{
					instance.PartitionStatesV0Collection = await reader.ReadArrayAsync(async () => await LeaderAndIsrRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(2, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(2, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionStatesV0Collection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(2, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public LeaderAndIsrRequestTopicState WithName(String name)
			{
				Name = name;
				return this;
			}

			private LeaderAndIsrRequestPartition[] _partitionStatesV0Collection = Array.Empty<LeaderAndIsrRequestPartition>();
			/// <summary>
			/// The state of each partition
			/// </summary>
			public LeaderAndIsrRequestPartition[] PartitionStatesV0Collection 
			{
				get => _partitionStatesV0Collection;
				set 
				{
					if (Version.InRange(2, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionStatesV0Collection does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
					}

					_partitionStatesV0Collection = value;
				}
			}

			/// <summary>
			/// The state of each partition
			/// </summary>
			public LeaderAndIsrRequestTopicState WithPartitionStatesV0Collection(LeaderAndIsrRequestPartition[] partitionStatesV0Collection)
			{
				PartitionStatesV0Collection = partitionStatesV0Collection;
				return this;
			}
		}

		private LeaderAndIsrLiveLeader[] _liveLeadersCollection = Array.Empty<LeaderAndIsrLiveLeader>();
		/// <summary>
		/// The current live leaders.
		/// </summary>
		public LeaderAndIsrLiveLeader[] LiveLeadersCollection 
		{
			get => _liveLeadersCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"LiveLeadersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_liveLeadersCollection = value;
			}
		}

		/// <summary>
		/// The current live leaders.
		/// </summary>
		public LeaderAndIsrRequest WithLiveLeadersCollection(params Func<LeaderAndIsrLiveLeader, LeaderAndIsrLiveLeader>[] createFields)
		{
			LiveLeadersCollection = createFields
				.Select(createField => createField(CreateLeaderAndIsrLiveLeader()))
				.ToArray();
			return this;
		}

		internal LeaderAndIsrLiveLeader CreateLeaderAndIsrLiveLeader()
		{
			return new LeaderAndIsrLiveLeader(Version);
		}

		public class LeaderAndIsrLiveLeader : ISerialize
		{
			internal LeaderAndIsrLiveLeader(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<LeaderAndIsrLiveLeader> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new LeaderAndIsrLiveLeader(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.BrokerId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.HostName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Port = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(BrokerId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(HostName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(Port, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int32 _brokerId = Int32.Default;
			/// <summary>
			/// The leader's broker ID.
			/// </summary>
			public Int32 BrokerId 
			{
				get => _brokerId;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"BrokerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_brokerId = value;
				}
			}

			/// <summary>
			/// The leader's broker ID.
			/// </summary>
			public LeaderAndIsrLiveLeader WithBrokerId(Int32 brokerId)
			{
				BrokerId = brokerId;
				return this;
			}

			private String _hostName = String.Default;
			/// <summary>
			/// The leader's hostname.
			/// </summary>
			public String HostName 
			{
				get => _hostName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"HostName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_hostName = value;
				}
			}

			/// <summary>
			/// The leader's hostname.
			/// </summary>
			public LeaderAndIsrLiveLeader WithHostName(String hostName)
			{
				HostName = hostName;
				return this;
			}

			private Int32 _port = Int32.Default;
			/// <summary>
			/// The leader's port.
			/// </summary>
			public Int32 Port 
			{
				get => _port;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_port = value;
				}
			}

			/// <summary>
			/// The leader's port.
			/// </summary>
			public LeaderAndIsrLiveLeader WithPort(Int32 port)
			{
				Port = port;
				return this;
			}
		}

		public class LeaderAndIsrRequestPartition : ISerialize
		{
			internal LeaderAndIsrRequestPartition(Int16 version)
			{
				if (version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"LeaderAndIsrRequestPartition does not support version {version}. Valid versions are: 0+");
				}

				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<LeaderAndIsrRequestPartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new LeaderAndIsrRequestPartition(version);
				if (instance.Version.InRange(0, 1)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ControllerEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.LeaderKey = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.IsrReplicasCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ZkVersion = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ReplicasCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.IsNew = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 1)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(ControllerEpoch, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(LeaderKey, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(LeaderEpoch, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, IsrReplicasCollection).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(ZkVersion, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ReplicasCollection).ConfigureAwait(false);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteBooleanAsync(IsNew, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _topicName = String.Default;
			/// <summary>
			/// The topic name.  This is only present in v0 or v1.
			/// </summary>
			public String TopicName 
			{
				get => _topicName;
				set 
				{
					if (Version.InRange(0, 1) == false) 
					{
						throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 0-1");
					}

					_topicName = value;
				}
			}

			/// <summary>
			/// The topic name.  This is only present in v0 or v1.
			/// </summary>
			public LeaderAndIsrRequestPartition WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			private Int32 _partitionIndex = Int32.Default;
			/// <summary>
			/// The partition index.
			/// </summary>
			public Int32 PartitionIndex 
			{
				get => _partitionIndex;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionIndex = value;
				}
			}

			/// <summary>
			/// The partition index.
			/// </summary>
			public LeaderAndIsrRequestPartition WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}

			private Int32 _controllerEpoch = Int32.Default;
			/// <summary>
			/// The controller epoch.
			/// </summary>
			public Int32 ControllerEpoch 
			{
				get => _controllerEpoch;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ControllerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_controllerEpoch = value;
				}
			}

			/// <summary>
			/// The controller epoch.
			/// </summary>
			public LeaderAndIsrRequestPartition WithControllerEpoch(Int32 controllerEpoch)
			{
				ControllerEpoch = controllerEpoch;
				return this;
			}

			private Int32 _leaderKey = Int32.Default;
			/// <summary>
			/// The broker ID of the leader.
			/// </summary>
			public Int32 LeaderKey 
			{
				get => _leaderKey;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"LeaderKey does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_leaderKey = value;
				}
			}

			/// <summary>
			/// The broker ID of the leader.
			/// </summary>
			public LeaderAndIsrRequestPartition WithLeaderKey(Int32 leaderKey)
			{
				LeaderKey = leaderKey;
				return this;
			}

			private Int32 _leaderEpoch = Int32.Default;
			/// <summary>
			/// The leader epoch.
			/// </summary>
			public Int32 LeaderEpoch 
			{
				get => _leaderEpoch;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"LeaderEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_leaderEpoch = value;
				}
			}

			/// <summary>
			/// The leader epoch.
			/// </summary>
			public LeaderAndIsrRequestPartition WithLeaderEpoch(Int32 leaderEpoch)
			{
				LeaderEpoch = leaderEpoch;
				return this;
			}

			private Int32[] _isrReplicasCollection = Array.Empty<Int32>();
			/// <summary>
			/// The in-sync replica IDs.
			/// </summary>
			public Int32[] IsrReplicasCollection 
			{
				get => _isrReplicasCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"IsrReplicasCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_isrReplicasCollection = value;
				}
			}

			/// <summary>
			/// The in-sync replica IDs.
			/// </summary>
			public LeaderAndIsrRequestPartition WithIsrReplicasCollection(Int32[] isrReplicasCollection)
			{
				IsrReplicasCollection = isrReplicasCollection;
				return this;
			}

			private Int32 _zkVersion = Int32.Default;
			/// <summary>
			/// The ZooKeeper version.
			/// </summary>
			public Int32 ZkVersion 
			{
				get => _zkVersion;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ZkVersion does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_zkVersion = value;
				}
			}

			/// <summary>
			/// The ZooKeeper version.
			/// </summary>
			public LeaderAndIsrRequestPartition WithZkVersion(Int32 zkVersion)
			{
				ZkVersion = zkVersion;
				return this;
			}

			private Int32[] _replicasCollection = Array.Empty<Int32>();
			/// <summary>
			/// The replica IDs.
			/// </summary>
			public Int32[] ReplicasCollection 
			{
				get => _replicasCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ReplicasCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_replicasCollection = value;
				}
			}

			/// <summary>
			/// The replica IDs.
			/// </summary>
			public LeaderAndIsrRequestPartition WithReplicasCollection(Int32[] replicasCollection)
			{
				ReplicasCollection = replicasCollection;
				return this;
			}

			private Boolean _isNew = new Boolean(false);
			/// <summary>
			/// Whether the replica should have existed on the broker or not.
			/// </summary>
			public Boolean IsNew 
			{
				get => _isNew;
				set 
				{
					_isNew = value;
				}
			}

			/// <summary>
			/// Whether the replica should have existed on the broker or not.
			/// </summary>
			public LeaderAndIsrRequestPartition WithIsNew(Boolean isNew)
			{
				IsNew = isNew;
				return this;
			}
		}

		public LeaderAndIsrResponse Respond()
			=> new LeaderAndIsrResponse(Version);
	}

	public class LeaderAndIsrResponse : Message
	{
		public LeaderAndIsrResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"LeaderAndIsrResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(4);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<LeaderAndIsrResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new LeaderAndIsrResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await LeaderAndIsrResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public LeaderAndIsrResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private LeaderAndIsrResponsePartition[] _partitionsCollection = Array.Empty<LeaderAndIsrResponsePartition>();
		/// <summary>
		/// Each partition.
		/// </summary>
		public LeaderAndIsrResponsePartition[] PartitionsCollection 
		{
			get => _partitionsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_partitionsCollection = value;
			}
		}

		/// <summary>
		/// Each partition.
		/// </summary>
		public LeaderAndIsrResponse WithPartitionsCollection(params Func<LeaderAndIsrResponsePartition, LeaderAndIsrResponsePartition>[] createFields)
		{
			PartitionsCollection = createFields
				.Select(createField => createField(CreateLeaderAndIsrResponsePartition()))
				.ToArray();
			return this;
		}

		internal LeaderAndIsrResponsePartition CreateLeaderAndIsrResponsePartition()
		{
			return new LeaderAndIsrResponsePartition(Version);
		}

		public class LeaderAndIsrResponsePartition : ISerialize
		{
			internal LeaderAndIsrResponsePartition(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<LeaderAndIsrResponsePartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new LeaderAndIsrResponsePartition(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _topicName = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String TopicName 
			{
				get => _topicName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topicName = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public LeaderAndIsrResponsePartition WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			private Int32 _partitionIndex = Int32.Default;
			/// <summary>
			/// The partition index.
			/// </summary>
			public Int32 PartitionIndex 
			{
				get => _partitionIndex;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionIndex = value;
				}
			}

			/// <summary>
			/// The partition index.
			/// </summary>
			public LeaderAndIsrResponsePartition WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The partition error code, or 0 if there was no error.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The partition error code, or 0 if there was no error.
			/// </summary>
			public LeaderAndIsrResponsePartition WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}
		}
	}

	public class LeaveGroupRequest : Message, IRespond<LeaveGroupResponse>
	{
		public LeaveGroupRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"LeaveGroupRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(13);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<LeaveGroupRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new LeaveGroupRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken).ConfigureAwait(false);
			}
		}

		private String _groupId = String.Default;
		/// <summary>
		/// The ID of the group to leave.
		/// </summary>
		public String GroupId 
		{
			get => _groupId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupId = value;
			}
		}

		/// <summary>
		/// The ID of the group to leave.
		/// </summary>
		public LeaveGroupRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		private String _memberId = String.Default;
		/// <summary>
		/// The member ID to remove from the group.
		/// </summary>
		public String MemberId 
		{
			get => _memberId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_memberId = value;
			}
		}

		/// <summary>
		/// The member ID to remove from the group.
		/// </summary>
		public LeaveGroupRequest WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}

		public LeaveGroupResponse Respond()
			=> new LeaveGroupResponse(Version);
	}

	public class LeaveGroupResponse : Message
	{
		public LeaveGroupResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"LeaveGroupResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(13);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<LeaveGroupResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new LeaveGroupResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public LeaveGroupResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public LeaveGroupResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class ListGroupsRequest : Message, IRespond<ListGroupsResponse>
	{
		public ListGroupsRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ListGroupsRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(16);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<ListGroupsRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ListGroupsRequest(version);

			return await new ValueTask<ListGroupsRequest>(instance);
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await Task.CompletedTask;
		}

		public ListGroupsResponse Respond()
			=> new ListGroupsResponse(Version);
	}

	public class ListGroupsResponse : Message
	{
		public ListGroupsResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ListGroupsResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(16);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<ListGroupsResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ListGroupsResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupsCollection = await reader.ReadArrayAsync(async () => await ListedGroup.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, GroupsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public ListGroupsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public ListGroupsResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private ListedGroup[] _groupsCollection = Array.Empty<ListedGroup>();
		/// <summary>
		/// Each group in the response.
		/// </summary>
		public ListedGroup[] GroupsCollection 
		{
			get => _groupsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupsCollection = value;
			}
		}

		/// <summary>
		/// Each group in the response.
		/// </summary>
		public ListGroupsResponse WithGroupsCollection(params Func<ListedGroup, ListedGroup>[] createFields)
		{
			GroupsCollection = createFields
				.Select(createField => createField(CreateListedGroup()))
				.ToArray();
			return this;
		}

		internal ListedGroup CreateListedGroup()
		{
			return new ListedGroup(Version);
		}

		public class ListedGroup : ISerialize
		{
			internal ListedGroup(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<ListedGroup> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ListedGroup(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProtocolType = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ProtocolType, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _groupId = String.Default;
			/// <summary>
			/// The group ID.
			/// </summary>
			public String GroupId 
			{
				get => _groupId;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_groupId = value;
				}
			}

			/// <summary>
			/// The group ID.
			/// </summary>
			public ListedGroup WithGroupId(String groupId)
			{
				GroupId = groupId;
				return this;
			}

			private String _protocolType = String.Default;
			/// <summary>
			/// The group protocol type.
			/// </summary>
			public String ProtocolType 
			{
				get => _protocolType;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ProtocolType does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_protocolType = value;
				}
			}

			/// <summary>
			/// The group protocol type.
			/// </summary>
			public ListedGroup WithProtocolType(String protocolType)
			{
				ProtocolType = protocolType;
				return this;
			}
		}
	}

	public class ListOffsetRequest : Message, IRespond<ListOffsetResponse>
	{
		public ListOffsetRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ListOffsetRequest does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(2);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(5);

		public override Int16 Version { get; }

		public static async ValueTask<ListOffsetRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ListOffsetRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ReplicaId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.IsolationLevel = await reader.ReadInt8Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await ListOffsetTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ReplicaId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt8Async(IsolationLevel, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _replicaId = Int32.Default;
		/// <summary>
		/// The broker ID of the requestor, or -1 if this request is being made by a normal consumer.
		/// </summary>
		public Int32 ReplicaId 
		{
			get => _replicaId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ReplicaId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_replicaId = value;
			}
		}

		/// <summary>
		/// The broker ID of the requestor, or -1 if this request is being made by a normal consumer.
		/// </summary>
		public ListOffsetRequest WithReplicaId(Int32 replicaId)
		{
			ReplicaId = replicaId;
			return this;
		}

		private Int8 _isolationLevel = Int8.Default;
		/// <summary>
		/// This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records
		/// </summary>
		public Int8 IsolationLevel 
		{
			get => _isolationLevel;
			set 
			{
				if (Version.InRange(2, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"IsolationLevel does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
				}

				_isolationLevel = value;
			}
		}

		/// <summary>
		/// This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records
		/// </summary>
		public ListOffsetRequest WithIsolationLevel(Int8 isolationLevel)
		{
			IsolationLevel = isolationLevel;
			return this;
		}

		private ListOffsetTopic[] _topicsCollection = Array.Empty<ListOffsetTopic>();
		/// <summary>
		/// Each topic in the request.
		/// </summary>
		public ListOffsetTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic in the request.
		/// </summary>
		public ListOffsetRequest WithTopicsCollection(params Func<ListOffsetTopic, ListOffsetTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateListOffsetTopic()))
				.ToArray();
			return this;
		}

		internal ListOffsetTopic CreateListOffsetTopic()
		{
			return new ListOffsetTopic(Version);
		}

		public class ListOffsetTopic : ISerialize
		{
			internal ListOffsetTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<ListOffsetTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ListOffsetTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await ListOffsetPartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public ListOffsetTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private ListOffsetPartition[] _partitionsCollection = Array.Empty<ListOffsetPartition>();
			/// <summary>
			/// Each partition in the request.
			/// </summary>
			public ListOffsetPartition[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// Each partition in the request.
			/// </summary>
			public ListOffsetTopic WithPartitionsCollection(params Func<ListOffsetPartition, ListOffsetPartition>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateListOffsetPartition()))
					.ToArray();
				return this;
			}

			internal ListOffsetPartition CreateListOffsetPartition()
			{
				return new ListOffsetPartition(Version);
			}

			public class ListOffsetPartition : ISerialize
			{
				internal ListOffsetPartition(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<ListOffsetPartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new ListOffsetPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(4, 2147483647)) 
					{
						instance.CurrentLeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Timestamp = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 0)) 
					{
						instance.MaxNumOffsets = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(4, 2147483647)) 
					{
						await writer.WriteInt32Async(CurrentLeaderEpoch, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(Timestamp, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 0)) 
					{
						await writer.WriteInt32Async(MaxNumOffsets, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public ListOffsetPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int32 _currentLeaderEpoch = Int32.Default;
				/// <summary>
				/// The current leader epoch.
				/// </summary>
				public Int32 CurrentLeaderEpoch 
				{
					get => _currentLeaderEpoch;
					set 
					{
						if (Version.InRange(4, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"CurrentLeaderEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
						}

						_currentLeaderEpoch = value;
					}
				}

				/// <summary>
				/// The current leader epoch.
				/// </summary>
				public ListOffsetPartition WithCurrentLeaderEpoch(Int32 currentLeaderEpoch)
				{
					CurrentLeaderEpoch = currentLeaderEpoch;
					return this;
				}

				private Int64 _timestamp = Int64.Default;
				/// <summary>
				/// The current timestamp.
				/// </summary>
				public Int64 Timestamp 
				{
					get => _timestamp;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Timestamp does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_timestamp = value;
					}
				}

				/// <summary>
				/// The current timestamp.
				/// </summary>
				public ListOffsetPartition WithTimestamp(Int64 timestamp)
				{
					Timestamp = timestamp;
					return this;
				}

				private Int32 _maxNumOffsets = Int32.Default;
				/// <summary>
				/// The maximum number of offsets to report.
				/// </summary>
				public Int32 MaxNumOffsets 
				{
					get => _maxNumOffsets;
					set 
					{
						if (Version.InRange(0, 0) == false) 
						{
							throw new UnsupportedVersionException($"MaxNumOffsets does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
						}

						_maxNumOffsets = value;
					}
				}

				/// <summary>
				/// The maximum number of offsets to report.
				/// </summary>
				public ListOffsetPartition WithMaxNumOffsets(Int32 maxNumOffsets)
				{
					MaxNumOffsets = maxNumOffsets;
					return this;
				}
			}
		}

		public ListOffsetResponse Respond()
			=> new ListOffsetResponse(Version);
	}

	public class ListOffsetResponse : Message
	{
		public ListOffsetResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ListOffsetResponse does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(2);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(5);

		public override Int16 Version { get; }

		public static async ValueTask<ListOffsetResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ListOffsetResponse(version);
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await ListOffsetTopicResponse.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public ListOffsetResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private ListOffsetTopicResponse[] _topicsCollection = Array.Empty<ListOffsetTopicResponse>();
		/// <summary>
		/// Each topic in the response.
		/// </summary>
		public ListOffsetTopicResponse[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic in the response.
		/// </summary>
		public ListOffsetResponse WithTopicsCollection(params Func<ListOffsetTopicResponse, ListOffsetTopicResponse>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateListOffsetTopicResponse()))
				.ToArray();
			return this;
		}

		internal ListOffsetTopicResponse CreateListOffsetTopicResponse()
		{
			return new ListOffsetTopicResponse(Version);
		}

		public class ListOffsetTopicResponse : ISerialize
		{
			internal ListOffsetTopicResponse(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<ListOffsetTopicResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ListOffsetTopicResponse(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await ListOffsetPartitionResponse.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			public ListOffsetTopicResponse WithName(String name)
			{
				Name = name;
				return this;
			}

			private ListOffsetPartitionResponse[] _partitionsCollection = Array.Empty<ListOffsetPartitionResponse>();
			/// <summary>
			/// Each partition in the response.
			/// </summary>
			public ListOffsetPartitionResponse[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// Each partition in the response.
			/// </summary>
			public ListOffsetTopicResponse WithPartitionsCollection(params Func<ListOffsetPartitionResponse, ListOffsetPartitionResponse>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateListOffsetPartitionResponse()))
					.ToArray();
				return this;
			}

			internal ListOffsetPartitionResponse CreateListOffsetPartitionResponse()
			{
				return new ListOffsetPartitionResponse(Version);
			}

			public class ListOffsetPartitionResponse : ISerialize
			{
				internal ListOffsetPartitionResponse(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<ListOffsetPartitionResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new ListOffsetPartitionResponse(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 0)) 
					{
						instance.OldStyleOffsetsCollection = await reader.ReadArrayAsync(async () => await Int64.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.Timestamp = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.Offset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(4, 2147483647)) 
					{
						instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 0)) 
					{
						await writer.WriteArrayAsync(cancellationToken, OldStyleOffsetsCollection).ConfigureAwait(false);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt64Async(Timestamp, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt64Async(Offset, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(4, 2147483647)) 
					{
						await writer.WriteInt32Async(LeaderEpoch, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public ListOffsetPartitionResponse WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The partition error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The partition error code, or 0 if there was no error.
				/// </summary>
				public ListOffsetPartitionResponse WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				private Int64[] _oldStyleOffsetsCollection = Array.Empty<Int64>();
				/// <summary>
				/// The result offsets.
				/// </summary>
				public Int64[] OldStyleOffsetsCollection 
				{
					get => _oldStyleOffsetsCollection;
					set 
					{
						if (Version.InRange(0, 0) == false) 
						{
							throw new UnsupportedVersionException($"OldStyleOffsetsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
						}

						_oldStyleOffsetsCollection = value;
					}
				}

				/// <summary>
				/// The result offsets.
				/// </summary>
				public ListOffsetPartitionResponse WithOldStyleOffsetsCollection(Int64[] oldStyleOffsetsCollection)
				{
					OldStyleOffsetsCollection = oldStyleOffsetsCollection;
					return this;
				}

				private Int64 _timestamp = new Int64(-1);
				/// <summary>
				/// The timestamp associated with the returned offset.
				/// </summary>
				public Int64 Timestamp 
				{
					get => _timestamp;
					set 
					{
						if (Version.InRange(1, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Timestamp does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
						}

						_timestamp = value;
					}
				}

				/// <summary>
				/// The timestamp associated with the returned offset.
				/// </summary>
				public ListOffsetPartitionResponse WithTimestamp(Int64 timestamp)
				{
					Timestamp = timestamp;
					return this;
				}

				private Int64 _offset = new Int64(-1);
				/// <summary>
				/// The returned offset.
				/// </summary>
				public Int64 Offset 
				{
					get => _offset;
					set 
					{
						if (Version.InRange(1, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Offset does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
						}

						_offset = value;
					}
				}

				/// <summary>
				/// The returned offset.
				/// </summary>
				public ListOffsetPartitionResponse WithOffset(Int64 offset)
				{
					Offset = offset;
					return this;
				}

				private Int32 _leaderEpoch = Int32.Default;
				public Int32 LeaderEpoch 
				{
					get => _leaderEpoch;
					set 
					{
						if (Version.InRange(4, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"LeaderEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
						}

						_leaderEpoch = value;
					}
				}

				public ListOffsetPartitionResponse WithLeaderEpoch(Int32 leaderEpoch)
				{
					LeaderEpoch = leaderEpoch;
					return this;
				}
			}
		}
	}

	public class MetadataRequest : Message, IRespond<MetadataResponse>
	{
		public MetadataRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"MetadataRequest does not support version {version}. Valid versions are: 0-8");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(3);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(8);

		public override Int16 Version { get; }

		public static async ValueTask<MetadataRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new MetadataRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadNullableArrayAsync(async () => await MetadataRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(4, 2147483647)) 
			{
				instance.AllowAutoTopicCreation = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(8, 2147483647)) 
			{
				instance.IncludeClusterAuthorizedOperations = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(8, 2147483647)) 
			{
				instance.IncludeTopicAuthorizedOperations = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
			if (Version.InRange(4, 2147483647)) 
			{
				await writer.WriteBooleanAsync(AllowAutoTopicCreation, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(8, 2147483647)) 
			{
				await writer.WriteBooleanAsync(IncludeClusterAuthorizedOperations, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(8, 2147483647)) 
			{
				await writer.WriteBooleanAsync(IncludeTopicAuthorizedOperations, cancellationToken).ConfigureAwait(false);
			}
		}

		private MetadataRequestTopic[]? _topicsCollection = Array.Empty<MetadataRequestTopic>();
		/// <summary>
		/// The topics to fetch metadata for.
		/// </summary>
		public MetadataRequestTopic[]? TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(1, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support null for version {Version}. Supported versions for null value: 1+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// The topics to fetch metadata for.
		/// </summary>
		public MetadataRequest WithTopicsCollection(params Func<MetadataRequestTopic, MetadataRequestTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateMetadataRequestTopic()))
				.ToArray();
			return this;
		}

		internal MetadataRequestTopic CreateMetadataRequestTopic()
		{
			return new MetadataRequestTopic(Version);
		}

		public class MetadataRequestTopic : ISerialize
		{
			internal MetadataRequestTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<MetadataRequestTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new MetadataRequestTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public MetadataRequestTopic WithName(String name)
			{
				Name = name;
				return this;
			}
		}

		private Boolean _allowAutoTopicCreation = new Boolean(true);
		/// <summary>
		/// If this is true, the broker may auto-create topics that we requested which do not already exist, if it is configured to do so.
		/// </summary>
		public Boolean AllowAutoTopicCreation 
		{
			get => _allowAutoTopicCreation;
			set 
			{
				if (Version.InRange(4, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"AllowAutoTopicCreation does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
				}

				_allowAutoTopicCreation = value;
			}
		}

		/// <summary>
		/// If this is true, the broker may auto-create topics that we requested which do not already exist, if it is configured to do so.
		/// </summary>
		public MetadataRequest WithAllowAutoTopicCreation(Boolean allowAutoTopicCreation)
		{
			AllowAutoTopicCreation = allowAutoTopicCreation;
			return this;
		}

		private Boolean _includeClusterAuthorizedOperations = Boolean.Default;
		/// <summary>
		/// Whether to include cluster authorized operations.
		/// </summary>
		public Boolean IncludeClusterAuthorizedOperations 
		{
			get => _includeClusterAuthorizedOperations;
			set 
			{
				if (Version.InRange(8, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"IncludeClusterAuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
				}

				_includeClusterAuthorizedOperations = value;
			}
		}

		/// <summary>
		/// Whether to include cluster authorized operations.
		/// </summary>
		public MetadataRequest WithIncludeClusterAuthorizedOperations(Boolean includeClusterAuthorizedOperations)
		{
			IncludeClusterAuthorizedOperations = includeClusterAuthorizedOperations;
			return this;
		}

		private Boolean _includeTopicAuthorizedOperations = Boolean.Default;
		/// <summary>
		/// Whether to include topic authorized operations.
		/// </summary>
		public Boolean IncludeTopicAuthorizedOperations 
		{
			get => _includeTopicAuthorizedOperations;
			set 
			{
				if (Version.InRange(8, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"IncludeTopicAuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
				}

				_includeTopicAuthorizedOperations = value;
			}
		}

		/// <summary>
		/// Whether to include topic authorized operations.
		/// </summary>
		public MetadataRequest WithIncludeTopicAuthorizedOperations(Boolean includeTopicAuthorizedOperations)
		{
			IncludeTopicAuthorizedOperations = includeTopicAuthorizedOperations;
			return this;
		}

		public MetadataResponse Respond()
			=> new MetadataResponse(Version);
	}

	public class MetadataResponse : Message
	{
		public MetadataResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"MetadataResponse does not support version {version}. Valid versions are: 0-8");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(3);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(8);

		public override Int16 Version { get; }

		public static async ValueTask<MetadataResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new MetadataResponse(version);
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.BrokersCollection = (await reader.ReadArrayAsync(async () => await MetadataResponseBroker.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.NodeId);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ClusterId = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ControllerId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = (await reader.ReadArrayAsync(async () => await MetadataResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false)).ToDictionary(field => field.Name);
			}
			if (instance.Version.InRange(8, 2147483647)) 
			{
				instance.ClusterAuthorizedOperations = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, BrokersCollection.Values.ToArray()).ConfigureAwait(false);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(ClusterId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection.Values.ToArray()).ConfigureAwait(false);
			}
			if (Version.InRange(8, 2147483647)) 
			{
				await writer.WriteInt32Async(ClusterAuthorizedOperations, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(3, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public MetadataResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Dictionary<Int32, MetadataResponseBroker> _brokersCollection = new Dictionary<Int32, MetadataResponseBroker>();
		/// <summary>
		/// Each broker in the response.
		/// </summary>
		public Dictionary<Int32, MetadataResponseBroker> BrokersCollection 
		{
			get => _brokersCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"BrokersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_brokersCollection = value;
			}
		}

		/// <summary>
		/// Each broker in the response.
		/// </summary>
		public MetadataResponse WithBrokersCollection(params Func<MetadataResponseBroker, MetadataResponseBroker>[] createFields)
		{
			BrokersCollection = createFields
				.Select(createField => createField(CreateMetadataResponseBroker()))
				.ToDictionary(field => field.NodeId);
			return this;
		}

		internal MetadataResponseBroker CreateMetadataResponseBroker()
		{
			return new MetadataResponseBroker(Version);
		}

		public class MetadataResponseBroker : ISerialize
		{
			internal MetadataResponseBroker(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<MetadataResponseBroker> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new MetadataResponseBroker(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.NodeId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Host = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Port = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.Rack = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(NodeId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Host, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(Port, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(Rack, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int32 _nodeId = Int32.Default;
			/// <summary>
			/// The broker ID.
			/// </summary>
			public Int32 NodeId 
			{
				get => _nodeId;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"NodeId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_nodeId = value;
				}
			}

			/// <summary>
			/// The broker ID.
			/// </summary>
			public MetadataResponseBroker WithNodeId(Int32 nodeId)
			{
				NodeId = nodeId;
				return this;
			}

			private String _host = String.Default;
			/// <summary>
			/// The broker hostname.
			/// </summary>
			public String Host 
			{
				get => _host;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_host = value;
				}
			}

			/// <summary>
			/// The broker hostname.
			/// </summary>
			public MetadataResponseBroker WithHost(String host)
			{
				Host = host;
				return this;
			}

			private Int32 _port = Int32.Default;
			/// <summary>
			/// The broker port.
			/// </summary>
			public Int32 Port 
			{
				get => _port;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_port = value;
				}
			}

			/// <summary>
			/// The broker port.
			/// </summary>
			public MetadataResponseBroker WithPort(Int32 port)
			{
				Port = port;
				return this;
			}

			private String? _rack;
			/// <summary>
			/// The rack of the broker, or null if it has not been assigned to a rack.
			/// </summary>
			public String? Rack 
			{
				get => _rack;
				set 
				{
					if (Version.InRange(1, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"Rack does not support null for version {Version}. Supported versions for null value: 1+");
					}

					_rack = value;
				}
			}

			/// <summary>
			/// The rack of the broker, or null if it has not been assigned to a rack.
			/// </summary>
			public MetadataResponseBroker WithRack(String rack)
			{
				Rack = rack;
				return this;
			}
		}

		private String? _clusterId;
		/// <summary>
		/// The cluster ID that responding broker belongs to.
		/// </summary>
		public String? ClusterId 
		{
			get => _clusterId;
			set 
			{
				if (Version.InRange(2, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"ClusterId does not support null for version {Version}. Supported versions for null value: 2+");
				}

				_clusterId = value;
			}
		}

		/// <summary>
		/// The cluster ID that responding broker belongs to.
		/// </summary>
		public MetadataResponse WithClusterId(String clusterId)
		{
			ClusterId = clusterId;
			return this;
		}

		private Int32 _controllerId = new Int32(-1);
		/// <summary>
		/// The ID of the controller broker.
		/// </summary>
		public Int32 ControllerId 
		{
			get => _controllerId;
			set 
			{
				_controllerId = value;
			}
		}

		/// <summary>
		/// The ID of the controller broker.
		/// </summary>
		public MetadataResponse WithControllerId(Int32 controllerId)
		{
			ControllerId = controllerId;
			return this;
		}

		private Dictionary<String, MetadataResponseTopic> _topicsCollection = new Dictionary<String, MetadataResponseTopic>();
		/// <summary>
		/// Each topic in the response.
		/// </summary>
		public Dictionary<String, MetadataResponseTopic> TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic in the response.
		/// </summary>
		public MetadataResponse WithTopicsCollection(params Func<MetadataResponseTopic, MetadataResponseTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateMetadataResponseTopic()))
				.ToDictionary(field => field.Name);
			return this;
		}

		internal MetadataResponseTopic CreateMetadataResponseTopic()
		{
			return new MetadataResponseTopic(Version);
		}

		public class MetadataResponseTopic : ISerialize
		{
			internal MetadataResponseTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<MetadataResponseTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new MetadataResponseTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.IsInternal = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await MetadataResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(8, 2147483647)) 
				{
					instance.TopicAuthorizedOperations = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteBooleanAsync(IsInternal, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
				if (Version.InRange(8, 2147483647)) 
				{
					await writer.WriteInt32Async(TopicAuthorizedOperations, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The topic error, or 0 if there was no error.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The topic error, or 0 if there was no error.
			/// </summary>
			public MetadataResponseTopic WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public MetadataResponseTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private Boolean _isInternal = new Boolean(false);
			/// <summary>
			/// True if the topic is internal.
			/// </summary>
			public Boolean IsInternal 
			{
				get => _isInternal;
				set 
				{
					_isInternal = value;
				}
			}

			/// <summary>
			/// True if the topic is internal.
			/// </summary>
			public MetadataResponseTopic WithIsInternal(Boolean isInternal)
			{
				IsInternal = isInternal;
				return this;
			}

			private MetadataResponsePartition[] _partitionsCollection = Array.Empty<MetadataResponsePartition>();
			/// <summary>
			/// Each partition in the topic.
			/// </summary>
			public MetadataResponsePartition[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// Each partition in the topic.
			/// </summary>
			public MetadataResponseTopic WithPartitionsCollection(params Func<MetadataResponsePartition, MetadataResponsePartition>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateMetadataResponsePartition()))
					.ToArray();
				return this;
			}

			internal MetadataResponsePartition CreateMetadataResponsePartition()
			{
				return new MetadataResponsePartition(Version);
			}

			public class MetadataResponsePartition : ISerialize
			{
				internal MetadataResponsePartition(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<MetadataResponsePartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new MetadataResponsePartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.LeaderId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(7, 2147483647)) 
					{
						instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ReplicaNodesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.IsrNodesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(5, 2147483647)) 
					{
						instance.OfflineReplicasCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(LeaderId, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(7, 2147483647)) 
					{
						await writer.WriteInt32Async(LeaderEpoch, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, ReplicaNodesCollection).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, IsrNodesCollection).ConfigureAwait(false);
					}
					if (Version.InRange(5, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, OfflineReplicasCollection).ConfigureAwait(false);
					}
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The partition error, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The partition error, or 0 if there was no error.
				/// </summary>
				public MetadataResponsePartition WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public MetadataResponsePartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int32 _leaderId = Int32.Default;
				/// <summary>
				/// The ID of the leader broker.
				/// </summary>
				public Int32 LeaderId 
				{
					get => _leaderId;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"LeaderId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_leaderId = value;
					}
				}

				/// <summary>
				/// The ID of the leader broker.
				/// </summary>
				public MetadataResponsePartition WithLeaderId(Int32 leaderId)
				{
					LeaderId = leaderId;
					return this;
				}

				private Int32 _leaderEpoch = new Int32(-1);
				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				public Int32 LeaderEpoch 
				{
					get => _leaderEpoch;
					set 
					{
						_leaderEpoch = value;
					}
				}

				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				public MetadataResponsePartition WithLeaderEpoch(Int32 leaderEpoch)
				{
					LeaderEpoch = leaderEpoch;
					return this;
				}

				private Int32[] _replicaNodesCollection = Array.Empty<Int32>();
				/// <summary>
				/// The set of all nodes that host this partition.
				/// </summary>
				public Int32[] ReplicaNodesCollection 
				{
					get => _replicaNodesCollection;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ReplicaNodesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_replicaNodesCollection = value;
					}
				}

				/// <summary>
				/// The set of all nodes that host this partition.
				/// </summary>
				public MetadataResponsePartition WithReplicaNodesCollection(Int32[] replicaNodesCollection)
				{
					ReplicaNodesCollection = replicaNodesCollection;
					return this;
				}

				private Int32[] _isrNodesCollection = Array.Empty<Int32>();
				/// <summary>
				/// The set of nodes that are in sync with the leader for this partition.
				/// </summary>
				public Int32[] IsrNodesCollection 
				{
					get => _isrNodesCollection;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"IsrNodesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_isrNodesCollection = value;
					}
				}

				/// <summary>
				/// The set of nodes that are in sync with the leader for this partition.
				/// </summary>
				public MetadataResponsePartition WithIsrNodesCollection(Int32[] isrNodesCollection)
				{
					IsrNodesCollection = isrNodesCollection;
					return this;
				}

				private Int32[] _offlineReplicasCollection = Array.Empty<Int32>();
				/// <summary>
				/// The set of offline replicas of this partition.
				/// </summary>
				public Int32[] OfflineReplicasCollection 
				{
					get => _offlineReplicasCollection;
					set 
					{
						_offlineReplicasCollection = value;
					}
				}

				/// <summary>
				/// The set of offline replicas of this partition.
				/// </summary>
				public MetadataResponsePartition WithOfflineReplicasCollection(Int32[] offlineReplicasCollection)
				{
					OfflineReplicasCollection = offlineReplicasCollection;
					return this;
				}
			}

			private Int32 _topicAuthorizedOperations = new Int32(-2147483648);
			/// <summary>
			/// 32-bit bitfield to represent authorized operations for this topic.
			/// </summary>
			public Int32 TopicAuthorizedOperations 
			{
				get => _topicAuthorizedOperations;
				set 
				{
					if (Version.InRange(8, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TopicAuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
					}

					_topicAuthorizedOperations = value;
				}
			}

			/// <summary>
			/// 32-bit bitfield to represent authorized operations for this topic.
			/// </summary>
			public MetadataResponseTopic WithTopicAuthorizedOperations(Int32 topicAuthorizedOperations)
			{
				TopicAuthorizedOperations = topicAuthorizedOperations;
				return this;
			}
		}

		private Int32 _clusterAuthorizedOperations = new Int32(-2147483648);
		/// <summary>
		/// 32-bit bitfield to represent authorized operations for this cluster.
		/// </summary>
		public Int32 ClusterAuthorizedOperations 
		{
			get => _clusterAuthorizedOperations;
			set 
			{
				if (Version.InRange(8, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ClusterAuthorizedOperations does not support version {Version} and has been defined as not ignorable. Supported versions: 8+");
				}

				_clusterAuthorizedOperations = value;
			}
		}

		/// <summary>
		/// 32-bit bitfield to represent authorized operations for this cluster.
		/// </summary>
		public MetadataResponse WithClusterAuthorizedOperations(Int32 clusterAuthorizedOperations)
		{
			ClusterAuthorizedOperations = clusterAuthorizedOperations;
			return this;
		}
	}

	public class OffsetCommitRequest : Message, IRespond<OffsetCommitResponse>
	{
		public OffsetCommitRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"OffsetCommitRequest does not support version {version}. Valid versions are: 0-7");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(8);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(7);

		public override Int16 Version { get; }

		public static async ValueTask<OffsetCommitRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetCommitRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.GenerationId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(2, 4)) 
			{
				instance.RetentionTimeMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await OffsetCommitRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(GenerationId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(2, 4)) 
			{
				await writer.WriteInt64Async(RetentionTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private String _groupId = String.Default;
		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public String GroupId 
		{
			get => _groupId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupId = value;
			}
		}

		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public OffsetCommitRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		private Int32 _generationId = new Int32(-1);
		/// <summary>
		/// The generation of the group.
		/// </summary>
		public Int32 GenerationId 
		{
			get => _generationId;
			set 
			{
				_generationId = value;
			}
		}

		/// <summary>
		/// The generation of the group.
		/// </summary>
		public OffsetCommitRequest WithGenerationId(Int32 generationId)
		{
			GenerationId = generationId;
			return this;
		}

		private String _memberId = String.Default;
		/// <summary>
		/// The member ID assigned by the group coordinator.
		/// </summary>
		public String MemberId 
		{
			get => _memberId;
			set 
			{
				_memberId = value;
			}
		}

		/// <summary>
		/// The member ID assigned by the group coordinator.
		/// </summary>
		public OffsetCommitRequest WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}

		private String? _groupInstanceId;
		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		public String? GroupInstanceId 
		{
			get => _groupInstanceId;
			set 
			{
				if (Version.InRange(7, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 7+");
				}

				if (Version.InRange(7, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 7+");
				}

				_groupInstanceId = value;
			}
		}

		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		public OffsetCommitRequest WithGroupInstanceId(String groupInstanceId)
		{
			GroupInstanceId = groupInstanceId;
			return this;
		}

		private Int64 _retentionTimeMs = new Int64(-1);
		/// <summary>
		/// The time period in ms to retain the offset.
		/// </summary>
		public Int64 RetentionTimeMs 
		{
			get => _retentionTimeMs;
			set 
			{
				_retentionTimeMs = value;
			}
		}

		/// <summary>
		/// The time period in ms to retain the offset.
		/// </summary>
		public OffsetCommitRequest WithRetentionTimeMs(Int64 retentionTimeMs)
		{
			RetentionTimeMs = retentionTimeMs;
			return this;
		}

		private OffsetCommitRequestTopic[] _topicsCollection = Array.Empty<OffsetCommitRequestTopic>();
		/// <summary>
		/// The topics to commit offsets for.
		/// </summary>
		public OffsetCommitRequestTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// The topics to commit offsets for.
		/// </summary>
		public OffsetCommitRequest WithTopicsCollection(params Func<OffsetCommitRequestTopic, OffsetCommitRequestTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateOffsetCommitRequestTopic()))
				.ToArray();
			return this;
		}

		internal OffsetCommitRequestTopic CreateOffsetCommitRequestTopic()
		{
			return new OffsetCommitRequestTopic(Version);
		}

		public class OffsetCommitRequestTopic : ISerialize
		{
			internal OffsetCommitRequestTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<OffsetCommitRequestTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetCommitRequestTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await OffsetCommitRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public OffsetCommitRequestTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private OffsetCommitRequestPartition[] _partitionsCollection = Array.Empty<OffsetCommitRequestPartition>();
			/// <summary>
			/// Each partition to commit offsets for.
			/// </summary>
			public OffsetCommitRequestPartition[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// Each partition to commit offsets for.
			/// </summary>
			public OffsetCommitRequestTopic WithPartitionsCollection(params Func<OffsetCommitRequestPartition, OffsetCommitRequestPartition>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateOffsetCommitRequestPartition()))
					.ToArray();
				return this;
			}

			internal OffsetCommitRequestPartition CreateOffsetCommitRequestPartition()
			{
				return new OffsetCommitRequestPartition(Version);
			}

			public class OffsetCommitRequestPartition : ISerialize
			{
				internal OffsetCommitRequestPartition(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<OffsetCommitRequestPartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new OffsetCommitRequestPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.CommittedOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(6, 2147483647)) 
					{
						instance.CommittedLeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(1, 1)) 
					{
						instance.CommitTimestamp = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.CommittedMetadata = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(CommittedOffset, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(6, 2147483647)) 
					{
						await writer.WriteInt32Async(CommittedLeaderEpoch, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(1, 1)) 
					{
						await writer.WriteInt64Async(CommitTimestamp, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(CommittedMetadata, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public OffsetCommitRequestPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int64 _committedOffset = Int64.Default;
				/// <summary>
				/// The message offset to be committed.
				/// </summary>
				public Int64 CommittedOffset 
				{
					get => _committedOffset;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"CommittedOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_committedOffset = value;
					}
				}

				/// <summary>
				/// The message offset to be committed.
				/// </summary>
				public OffsetCommitRequestPartition WithCommittedOffset(Int64 committedOffset)
				{
					CommittedOffset = committedOffset;
					return this;
				}

				private Int32 _committedLeaderEpoch = new Int32(-1);
				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				public Int32 CommittedLeaderEpoch 
				{
					get => _committedLeaderEpoch;
					set 
					{
						_committedLeaderEpoch = value;
					}
				}

				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				public OffsetCommitRequestPartition WithCommittedLeaderEpoch(Int32 committedLeaderEpoch)
				{
					CommittedLeaderEpoch = committedLeaderEpoch;
					return this;
				}

				private Int64 _commitTimestamp = new Int64(-1);
				/// <summary>
				/// The timestamp of the commit.
				/// </summary>
				public Int64 CommitTimestamp 
				{
					get => _commitTimestamp;
					set 
					{
						if (Version.InRange(1, 1) == false) 
						{
							throw new UnsupportedVersionException($"CommitTimestamp does not support version {Version} and has been defined as not ignorable. Supported versions: 1");
						}

						_commitTimestamp = value;
					}
				}

				/// <summary>
				/// The timestamp of the commit.
				/// </summary>
				public OffsetCommitRequestPartition WithCommitTimestamp(Int64 commitTimestamp)
				{
					CommitTimestamp = commitTimestamp;
					return this;
				}

				private String? _committedMetadata = String.Default;
				/// <summary>
				/// Any associated metadata the client wants to keep.
				/// </summary>
				public String? CommittedMetadata 
				{
					get => _committedMetadata;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"CommittedMetadata does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"CommittedMetadata does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_committedMetadata = value;
					}
				}

				/// <summary>
				/// Any associated metadata the client wants to keep.
				/// </summary>
				public OffsetCommitRequestPartition WithCommittedMetadata(String committedMetadata)
				{
					CommittedMetadata = committedMetadata;
					return this;
				}
			}
		}

		public OffsetCommitResponse Respond()
			=> new OffsetCommitResponse(Version);
	}

	public class OffsetCommitResponse : Message
	{
		public OffsetCommitResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"OffsetCommitResponse does not support version {version}. Valid versions are: 0-7");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(8);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(7);

		public override Int16 Version { get; }

		public static async ValueTask<OffsetCommitResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetCommitResponse(version);
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await OffsetCommitResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public OffsetCommitResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private OffsetCommitResponseTopic[] _topicsCollection = Array.Empty<OffsetCommitResponseTopic>();
		/// <summary>
		/// The responses for each topic.
		/// </summary>
		public OffsetCommitResponseTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// The responses for each topic.
		/// </summary>
		public OffsetCommitResponse WithTopicsCollection(params Func<OffsetCommitResponseTopic, OffsetCommitResponseTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateOffsetCommitResponseTopic()))
				.ToArray();
			return this;
		}

		internal OffsetCommitResponseTopic CreateOffsetCommitResponseTopic()
		{
			return new OffsetCommitResponseTopic(Version);
		}

		public class OffsetCommitResponseTopic : ISerialize
		{
			internal OffsetCommitResponseTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<OffsetCommitResponseTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetCommitResponseTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await OffsetCommitResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public OffsetCommitResponseTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private OffsetCommitResponsePartition[] _partitionsCollection = Array.Empty<OffsetCommitResponsePartition>();
			/// <summary>
			/// The responses for each partition in the topic.
			/// </summary>
			public OffsetCommitResponsePartition[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// The responses for each partition in the topic.
			/// </summary>
			public OffsetCommitResponseTopic WithPartitionsCollection(params Func<OffsetCommitResponsePartition, OffsetCommitResponsePartition>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateOffsetCommitResponsePartition()))
					.ToArray();
				return this;
			}

			internal OffsetCommitResponsePartition CreateOffsetCommitResponsePartition()
			{
				return new OffsetCommitResponsePartition(Version);
			}

			public class OffsetCommitResponsePartition : ISerialize
			{
				internal OffsetCommitResponsePartition(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<OffsetCommitResponsePartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new OffsetCommitResponsePartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public OffsetCommitResponsePartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public OffsetCommitResponsePartition WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}
	}

	public class OffsetFetchRequest : Message, IRespond<OffsetFetchResponse>
	{
		public OffsetFetchRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"OffsetFetchRequest does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(9);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(5);

		public override Int16 Version { get; }

		public static async ValueTask<OffsetFetchRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetFetchRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadNullableArrayAsync(async () => await OffsetFetchRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private String _groupId = String.Default;
		/// <summary>
		/// The group to fetch offsets for.
		/// </summary>
		public String GroupId 
		{
			get => _groupId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupId = value;
			}
		}

		/// <summary>
		/// The group to fetch offsets for.
		/// </summary>
		public OffsetFetchRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		private OffsetFetchRequestTopic[]? _topicsCollection = Array.Empty<OffsetFetchRequestTopic>();
		/// <summary>
		/// Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.
		/// </summary>
		public OffsetFetchRequestTopic[]? TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(2, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support null for version {Version}. Supported versions for null value: 2+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.
		/// </summary>
		public OffsetFetchRequest WithTopicsCollection(params Func<OffsetFetchRequestTopic, OffsetFetchRequestTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateOffsetFetchRequestTopic()))
				.ToArray();
			return this;
		}

		internal OffsetFetchRequestTopic CreateOffsetFetchRequestTopic()
		{
			return new OffsetFetchRequestTopic(Version);
		}

		public class OffsetFetchRequestTopic : ISerialize
		{
			internal OffsetFetchRequestTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<OffsetFetchRequestTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetFetchRequestTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndexesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionIndexesCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public OffsetFetchRequestTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private Int32[] _partitionIndexesCollection = Array.Empty<Int32>();
			/// <summary>
			/// The partition indexes we would like to fetch offsets for.
			/// </summary>
			public Int32[] PartitionIndexesCollection 
			{
				get => _partitionIndexesCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionIndexesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionIndexesCollection = value;
				}
			}

			/// <summary>
			/// The partition indexes we would like to fetch offsets for.
			/// </summary>
			public OffsetFetchRequestTopic WithPartitionIndexesCollection(Int32[] partitionIndexesCollection)
			{
				PartitionIndexesCollection = partitionIndexesCollection;
				return this;
			}
		}

		public OffsetFetchResponse Respond()
			=> new OffsetFetchResponse(Version);
	}

	public class OffsetFetchResponse : Message
	{
		public OffsetFetchResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"OffsetFetchResponse does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(9);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(5);

		public override Int16 Version { get; }

		public static async ValueTask<OffsetFetchResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetFetchResponse(version);
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await OffsetFetchResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public OffsetFetchResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private OffsetFetchResponseTopic[] _topicsCollection = Array.Empty<OffsetFetchResponseTopic>();
		/// <summary>
		/// The responses per topic.
		/// </summary>
		public OffsetFetchResponseTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// The responses per topic.
		/// </summary>
		public OffsetFetchResponse WithTopicsCollection(params Func<OffsetFetchResponseTopic, OffsetFetchResponseTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateOffsetFetchResponseTopic()))
				.ToArray();
			return this;
		}

		internal OffsetFetchResponseTopic CreateOffsetFetchResponseTopic()
		{
			return new OffsetFetchResponseTopic(Version);
		}

		public class OffsetFetchResponseTopic : ISerialize
		{
			internal OffsetFetchResponseTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<OffsetFetchResponseTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetFetchResponseTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await OffsetFetchResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public OffsetFetchResponseTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private OffsetFetchResponsePartition[] _partitionsCollection = Array.Empty<OffsetFetchResponsePartition>();
			/// <summary>
			/// The responses per partition
			/// </summary>
			public OffsetFetchResponsePartition[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// The responses per partition
			/// </summary>
			public OffsetFetchResponseTopic WithPartitionsCollection(params Func<OffsetFetchResponsePartition, OffsetFetchResponsePartition>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateOffsetFetchResponsePartition()))
					.ToArray();
				return this;
			}

			internal OffsetFetchResponsePartition CreateOffsetFetchResponsePartition()
			{
				return new OffsetFetchResponsePartition(Version);
			}

			public class OffsetFetchResponsePartition : ISerialize
			{
				internal OffsetFetchResponsePartition(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<OffsetFetchResponsePartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new OffsetFetchResponsePartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.CommittedOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(5, 2147483647)) 
					{
						instance.CommittedLeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Metadata = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(CommittedOffset, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(5, 2147483647)) 
					{
						await writer.WriteInt32Async(CommittedLeaderEpoch, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(Metadata, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public OffsetFetchResponsePartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int64 _committedOffset = Int64.Default;
				/// <summary>
				/// The committed message offset.
				/// </summary>
				public Int64 CommittedOffset 
				{
					get => _committedOffset;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"CommittedOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_committedOffset = value;
					}
				}

				/// <summary>
				/// The committed message offset.
				/// </summary>
				public OffsetFetchResponsePartition WithCommittedOffset(Int64 committedOffset)
				{
					CommittedOffset = committedOffset;
					return this;
				}

				private Int32 _committedLeaderEpoch = Int32.Default;
				/// <summary>
				/// The leader epoch.
				/// </summary>
				public Int32 CommittedLeaderEpoch 
				{
					get => _committedLeaderEpoch;
					set 
					{
						if (Version.InRange(5, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"CommittedLeaderEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
						}

						_committedLeaderEpoch = value;
					}
				}

				/// <summary>
				/// The leader epoch.
				/// </summary>
				public OffsetFetchResponsePartition WithCommittedLeaderEpoch(Int32 committedLeaderEpoch)
				{
					CommittedLeaderEpoch = committedLeaderEpoch;
					return this;
				}

				private String? _metadata = String.Default;
				/// <summary>
				/// The partition metadata.
				/// </summary>
				public String? Metadata 
				{
					get => _metadata;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Metadata does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"Metadata does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_metadata = value;
					}
				}

				/// <summary>
				/// The partition metadata.
				/// </summary>
				public OffsetFetchResponsePartition WithMetadata(String metadata)
				{
					Metadata = metadata;
					return this;
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public OffsetFetchResponsePartition WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}

		private Int16 _errorCode = new Int16(0);
		/// <summary>
		/// The top-level error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(2, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 2+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The top-level error code, or 0 if there was no error.
		/// </summary>
		public OffsetFetchResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class OffsetForLeaderEpochRequest : Message, IRespond<OffsetForLeaderEpochResponse>
	{
		public OffsetForLeaderEpochRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"OffsetForLeaderEpochRequest does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(23);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(3);

		public override Int16 Version { get; }

		public static async ValueTask<OffsetForLeaderEpochRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetForLeaderEpochRequest(version);
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.ReplicaId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await OffsetForLeaderTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteInt32Async(ReplicaId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _replicaId = new Int32(-2);
		/// <summary>
		/// The broker ID of the follower, of -1 if this request is from a consumer.
		/// </summary>
		public Int32 ReplicaId 
		{
			get => _replicaId;
			set 
			{
				_replicaId = value;
			}
		}

		/// <summary>
		/// The broker ID of the follower, of -1 if this request is from a consumer.
		/// </summary>
		public OffsetForLeaderEpochRequest WithReplicaId(Int32 replicaId)
		{
			ReplicaId = replicaId;
			return this;
		}

		private OffsetForLeaderTopic[] _topicsCollection = Array.Empty<OffsetForLeaderTopic>();
		/// <summary>
		/// Each topic to get offsets for.
		/// </summary>
		public OffsetForLeaderTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic to get offsets for.
		/// </summary>
		public OffsetForLeaderEpochRequest WithTopicsCollection(params Func<OffsetForLeaderTopic, OffsetForLeaderTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateOffsetForLeaderTopic()))
				.ToArray();
			return this;
		}

		internal OffsetForLeaderTopic CreateOffsetForLeaderTopic()
		{
			return new OffsetForLeaderTopic(Version);
		}

		public class OffsetForLeaderTopic : ISerialize
		{
			internal OffsetForLeaderTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<OffsetForLeaderTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetForLeaderTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await OffsetForLeaderPartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public OffsetForLeaderTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private OffsetForLeaderPartition[] _partitionsCollection = Array.Empty<OffsetForLeaderPartition>();
			/// <summary>
			/// Each partition to get offsets for.
			/// </summary>
			public OffsetForLeaderPartition[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// Each partition to get offsets for.
			/// </summary>
			public OffsetForLeaderTopic WithPartitionsCollection(params Func<OffsetForLeaderPartition, OffsetForLeaderPartition>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateOffsetForLeaderPartition()))
					.ToArray();
				return this;
			}

			internal OffsetForLeaderPartition CreateOffsetForLeaderPartition()
			{
				return new OffsetForLeaderPartition(Version);
			}

			public class OffsetForLeaderPartition : ISerialize
			{
				internal OffsetForLeaderPartition(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<OffsetForLeaderPartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new OffsetForLeaderPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(2, 2147483647)) 
					{
						instance.CurrentLeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(2, 2147483647)) 
					{
						await writer.WriteInt32Async(CurrentLeaderEpoch, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(LeaderEpoch, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public OffsetForLeaderPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int32 _currentLeaderEpoch = new Int32(-1);
				/// <summary>
				/// An epoch used to fence consumers/replicas with old metadata.  If the epoch provided by the client is larger than the current epoch known to the broker, then the UNKNOWN_LEADER_EPOCH error code will be returned. If the provided epoch is smaller, then the FENCED_LEADER_EPOCH error code will be returned.
				/// </summary>
				public Int32 CurrentLeaderEpoch 
				{
					get => _currentLeaderEpoch;
					set 
					{
						_currentLeaderEpoch = value;
					}
				}

				/// <summary>
				/// An epoch used to fence consumers/replicas with old metadata.  If the epoch provided by the client is larger than the current epoch known to the broker, then the UNKNOWN_LEADER_EPOCH error code will be returned. If the provided epoch is smaller, then the FENCED_LEADER_EPOCH error code will be returned.
				/// </summary>
				public OffsetForLeaderPartition WithCurrentLeaderEpoch(Int32 currentLeaderEpoch)
				{
					CurrentLeaderEpoch = currentLeaderEpoch;
					return this;
				}

				private Int32 _leaderEpoch = Int32.Default;
				/// <summary>
				/// The epoch to look up an offset for.
				/// </summary>
				public Int32 LeaderEpoch 
				{
					get => _leaderEpoch;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"LeaderEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_leaderEpoch = value;
					}
				}

				/// <summary>
				/// The epoch to look up an offset for.
				/// </summary>
				public OffsetForLeaderPartition WithLeaderEpoch(Int32 leaderEpoch)
				{
					LeaderEpoch = leaderEpoch;
					return this;
				}
			}
		}

		public OffsetForLeaderEpochResponse Respond()
			=> new OffsetForLeaderEpochResponse(Version);
	}

	public class OffsetForLeaderEpochResponse : Message
	{
		public OffsetForLeaderEpochResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"OffsetForLeaderEpochResponse does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(23);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(3);

		public override Int16 Version { get; }

		public static async ValueTask<OffsetForLeaderEpochResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetForLeaderEpochResponse(version);
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await OffsetForLeaderTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public OffsetForLeaderEpochResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private OffsetForLeaderTopicResult[] _topicsCollection = Array.Empty<OffsetForLeaderTopicResult>();
		/// <summary>
		/// Each topic we fetched offsets for.
		/// </summary>
		public OffsetForLeaderTopicResult[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic we fetched offsets for.
		/// </summary>
		public OffsetForLeaderEpochResponse WithTopicsCollection(params Func<OffsetForLeaderTopicResult, OffsetForLeaderTopicResult>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateOffsetForLeaderTopicResult()))
				.ToArray();
			return this;
		}

		internal OffsetForLeaderTopicResult CreateOffsetForLeaderTopicResult()
		{
			return new OffsetForLeaderTopicResult(Version);
		}

		public class OffsetForLeaderTopicResult : ISerialize
		{
			internal OffsetForLeaderTopicResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<OffsetForLeaderTopicResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetForLeaderTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await OffsetForLeaderPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public OffsetForLeaderTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			private OffsetForLeaderPartitionResult[] _partitionsCollection = Array.Empty<OffsetForLeaderPartitionResult>();
			/// <summary>
			/// Each partition in the topic we fetched offsets for.
			/// </summary>
			public OffsetForLeaderPartitionResult[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// Each partition in the topic we fetched offsets for.
			/// </summary>
			public OffsetForLeaderTopicResult WithPartitionsCollection(params Func<OffsetForLeaderPartitionResult, OffsetForLeaderPartitionResult>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateOffsetForLeaderPartitionResult()))
					.ToArray();
				return this;
			}

			internal OffsetForLeaderPartitionResult CreateOffsetForLeaderPartitionResult()
			{
				return new OffsetForLeaderPartitionResult(Version);
			}

			public class OffsetForLeaderPartitionResult : ISerialize
			{
				internal OffsetForLeaderPartitionResult(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<OffsetForLeaderPartitionResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new OffsetForLeaderPartitionResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.EndOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt32Async(LeaderEpoch, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(EndOffset, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The error code 0, or if there was no error.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The error code 0, or if there was no error.
				/// </summary>
				public OffsetForLeaderPartitionResult WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public OffsetForLeaderPartitionResult WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int32 _leaderEpoch = new Int32(-1);
				/// <summary>
				/// The leader epoch of the partition.
				/// </summary>
				public Int32 LeaderEpoch 
				{
					get => _leaderEpoch;
					set 
					{
						_leaderEpoch = value;
					}
				}

				/// <summary>
				/// The leader epoch of the partition.
				/// </summary>
				public OffsetForLeaderPartitionResult WithLeaderEpoch(Int32 leaderEpoch)
				{
					LeaderEpoch = leaderEpoch;
					return this;
				}

				private Int64 _endOffset = Int64.Default;
				/// <summary>
				/// The end offset of the epoch.
				/// </summary>
				public Int64 EndOffset 
				{
					get => _endOffset;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"EndOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_endOffset = value;
					}
				}

				/// <summary>
				/// The end offset of the epoch.
				/// </summary>
				public OffsetForLeaderPartitionResult WithEndOffset(Int64 endOffset)
				{
					EndOffset = endOffset;
					return this;
				}
			}
		}
	}

	public class ProduceRequest : Message, IRespond<ProduceResponse>
	{
		public ProduceRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ProduceRequest does not support version {version}. Valid versions are: 0-7");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(0);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(7);

		public override Int16 Version { get; }

		public static async ValueTask<ProduceRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ProduceRequest(version);
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Acks = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await TopicProduceData.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(TransactionalId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(Acks, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private String? _transactionalId = String.Default;
		/// <summary>
		/// The transactional ID, or null if the producer is not transactional.
		/// </summary>
		public String? TransactionalId 
		{
			get => _transactionalId;
			set 
			{
				if (Version.InRange(3, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TransactionalId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
				}

				if (Version.InRange(0, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"TransactionalId does not support null for version {Version}. Supported versions for null value: 0+");
				}

				_transactionalId = value;
			}
		}

		/// <summary>
		/// The transactional ID, or null if the producer is not transactional.
		/// </summary>
		public ProduceRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		private Int16 _acks = Int16.Default;
		/// <summary>
		/// The number of acknowledgments the producer requires the leader to have received before considering a request complete. Allowed values: 0 for no acknowledgments, 1 for only the leader and -1 for the full ISR.
		/// </summary>
		public Int16 Acks 
		{
			get => _acks;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Acks does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_acks = value;
			}
		}

		/// <summary>
		/// The number of acknowledgments the producer requires the leader to have received before considering a request complete. Allowed values: 0 for no acknowledgments, 1 for only the leader and -1 for the full ISR.
		/// </summary>
		public ProduceRequest WithAcks(Int16 acks)
		{
			Acks = acks;
			return this;
		}

		private Int32 _timeoutMs = Int32.Default;
		/// <summary>
		/// The timeout to await a response in miliseconds.
		/// </summary>
		public Int32 TimeoutMs 
		{
			get => _timeoutMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TimeoutMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_timeoutMs = value;
			}
		}

		/// <summary>
		/// The timeout to await a response in miliseconds.
		/// </summary>
		public ProduceRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}

		private TopicProduceData[] _topicsCollection = Array.Empty<TopicProduceData>();
		/// <summary>
		/// Each topic to produce to.
		/// </summary>
		public TopicProduceData[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic to produce to.
		/// </summary>
		public ProduceRequest WithTopicsCollection(params Func<TopicProduceData, TopicProduceData>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateTopicProduceData()))
				.ToArray();
			return this;
		}

		internal TopicProduceData CreateTopicProduceData()
		{
			return new TopicProduceData(Version);
		}

		public class TopicProduceData : ISerialize
		{
			internal TopicProduceData(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<TopicProduceData> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TopicProduceData(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await PartitionProduceData.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public TopicProduceData WithName(String name)
			{
				Name = name;
				return this;
			}

			private PartitionProduceData[] _partitionsCollection = Array.Empty<PartitionProduceData>();
			/// <summary>
			/// Each partition to produce to.
			/// </summary>
			public PartitionProduceData[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// Each partition to produce to.
			/// </summary>
			public TopicProduceData WithPartitionsCollection(params Func<PartitionProduceData, PartitionProduceData>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreatePartitionProduceData()))
					.ToArray();
				return this;
			}

			internal PartitionProduceData CreatePartitionProduceData()
			{
				return new PartitionProduceData(Version);
			}

			public class PartitionProduceData : ISerialize
			{
				internal PartitionProduceData(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<PartitionProduceData> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new PartitionProduceData(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Records = await reader.ReadNullableBytesAsync(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableBytesAsync(Records, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public PartitionProduceData WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Bytes? _records = Bytes.Default;
				/// <summary>
				/// The record data to be produced.
				/// </summary>
				public Bytes? Records 
				{
					get => _records;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Records does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"Records does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_records = value;
					}
				}

				/// <summary>
				/// The record data to be produced.
				/// </summary>
				public PartitionProduceData WithRecords(Bytes records)
				{
					Records = records;
					return this;
				}
			}
		}

		public ProduceResponse Respond()
			=> new ProduceResponse(Version);
	}

	public class ProduceResponse : Message
	{
		public ProduceResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ProduceResponse does not support version {version}. Valid versions are: 0-7");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(0);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(7);

		public override Int16 Version { get; }

		public static async ValueTask<ProduceResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ProduceResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResponsesCollection = await reader.ReadArrayAsync(async () => await TopicProduceResponse.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResponsesCollection).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private TopicProduceResponse[] _responsesCollection = Array.Empty<TopicProduceResponse>();
		/// <summary>
		/// Each produce response
		/// </summary>
		public TopicProduceResponse[] ResponsesCollection 
		{
			get => _responsesCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ResponsesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_responsesCollection = value;
			}
		}

		/// <summary>
		/// Each produce response
		/// </summary>
		public ProduceResponse WithResponsesCollection(params Func<TopicProduceResponse, TopicProduceResponse>[] createFields)
		{
			ResponsesCollection = createFields
				.Select(createField => createField(CreateTopicProduceResponse()))
				.ToArray();
			return this;
		}

		internal TopicProduceResponse CreateTopicProduceResponse()
		{
			return new TopicProduceResponse(Version);
		}

		public class TopicProduceResponse : ISerialize
		{
			internal TopicProduceResponse(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<TopicProduceResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TopicProduceResponse(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await PartitionProduceResponse.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			public TopicProduceResponse WithName(String name)
			{
				Name = name;
				return this;
			}

			private PartitionProduceResponse[] _partitionsCollection = Array.Empty<PartitionProduceResponse>();
			/// <summary>
			/// Each partition that we produced to within the topic.
			/// </summary>
			public PartitionProduceResponse[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// Each partition that we produced to within the topic.
			/// </summary>
			public TopicProduceResponse WithPartitionsCollection(params Func<PartitionProduceResponse, PartitionProduceResponse>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreatePartitionProduceResponse()))
					.ToArray();
				return this;
			}

			internal PartitionProduceResponse CreatePartitionProduceResponse()
			{
				return new PartitionProduceResponse(Version);
			}

			public class PartitionProduceResponse : ISerialize
			{
				internal PartitionProduceResponse(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<PartitionProduceResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new PartitionProduceResponse(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.BaseOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(2, 2147483647)) 
					{
						instance.LogAppendTimeMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(5, 2147483647)) 
					{
						instance.LogStartOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(BaseOffset, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(2, 2147483647)) 
					{
						await writer.WriteInt64Async(LogAppendTimeMs, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(5, 2147483647)) 
					{
						await writer.WriteInt64Async(LogStartOffset, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public PartitionProduceResponse WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public PartitionProduceResponse WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				private Int64 _baseOffset = Int64.Default;
				/// <summary>
				/// The base offset.
				/// </summary>
				public Int64 BaseOffset 
				{
					get => _baseOffset;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"BaseOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_baseOffset = value;
					}
				}

				/// <summary>
				/// The base offset.
				/// </summary>
				public PartitionProduceResponse WithBaseOffset(Int64 baseOffset)
				{
					BaseOffset = baseOffset;
					return this;
				}

				private Int64 _logAppendTimeMs = new Int64(-1);
				/// <summary>
				/// The timestamp returned by broker after appending the messages. If CreateTime is used for the topic, the timestamp will be -1.  If LogAppendTime is used for the topic, the timestamp will be the broker local time when the messages are appended.
				/// </summary>
				public Int64 LogAppendTimeMs 
				{
					get => _logAppendTimeMs;
					set 
					{
						_logAppendTimeMs = value;
					}
				}

				/// <summary>
				/// The timestamp returned by broker after appending the messages. If CreateTime is used for the topic, the timestamp will be -1.  If LogAppendTime is used for the topic, the timestamp will be the broker local time when the messages are appended.
				/// </summary>
				public PartitionProduceResponse WithLogAppendTimeMs(Int64 logAppendTimeMs)
				{
					LogAppendTimeMs = logAppendTimeMs;
					return this;
				}

				private Int64 _logStartOffset = new Int64(-1);
				/// <summary>
				/// The log start offset.
				/// </summary>
				public Int64 LogStartOffset 
				{
					get => _logStartOffset;
					set 
					{
						_logStartOffset = value;
					}
				}

				/// <summary>
				/// The log start offset.
				/// </summary>
				public PartitionProduceResponse WithLogStartOffset(Int64 logStartOffset)
				{
					LogStartOffset = logStartOffset;
					return this;
				}
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public ProduceResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class RenewDelegationTokenRequest : Message, IRespond<RenewDelegationTokenResponse>
	{
		public RenewDelegationTokenRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"RenewDelegationTokenRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(39);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<RenewDelegationTokenRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new RenewDelegationTokenRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Hmac = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.RenewPeriodMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(Hmac, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(RenewPeriodMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private Bytes _hmac = Bytes.Default;
		/// <summary>
		/// The HMAC of the delegation token to be renewed.
		/// </summary>
		public Bytes Hmac 
		{
			get => _hmac;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Hmac does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_hmac = value;
			}
		}

		/// <summary>
		/// The HMAC of the delegation token to be renewed.
		/// </summary>
		public RenewDelegationTokenRequest WithHmac(Bytes hmac)
		{
			Hmac = hmac;
			return this;
		}

		private Int64 _renewPeriodMs = Int64.Default;
		/// <summary>
		/// The renewal time period in milliseconds.
		/// </summary>
		public Int64 RenewPeriodMs 
		{
			get => _renewPeriodMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"RenewPeriodMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_renewPeriodMs = value;
			}
		}

		/// <summary>
		/// The renewal time period in milliseconds.
		/// </summary>
		public RenewDelegationTokenRequest WithRenewPeriodMs(Int64 renewPeriodMs)
		{
			RenewPeriodMs = renewPeriodMs;
			return this;
		}

		public RenewDelegationTokenResponse Respond()
			=> new RenewDelegationTokenResponse(Version);
	}

	public class RenewDelegationTokenResponse : Message
	{
		public RenewDelegationTokenResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"RenewDelegationTokenResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(39);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<RenewDelegationTokenResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new RenewDelegationTokenResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ExpiryTimestampMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ExpiryTimestampMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public RenewDelegationTokenResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private Int64 _expiryTimestampMs = Int64.Default;
		/// <summary>
		/// The timestamp in milliseconds at which this token expires.
		/// </summary>
		public Int64 ExpiryTimestampMs 
		{
			get => _expiryTimestampMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ExpiryTimestampMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_expiryTimestampMs = value;
			}
		}

		/// <summary>
		/// The timestamp in milliseconds at which this token expires.
		/// </summary>
		public RenewDelegationTokenResponse WithExpiryTimestampMs(Int64 expiryTimestampMs)
		{
			ExpiryTimestampMs = expiryTimestampMs;
			return this;
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public RenewDelegationTokenResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class RequestHeader : Message, IRespond<ProduceResponse>
	{
		public RequestHeader(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"RequestHeader does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(0);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(0);

		public override Int16 Version { get; }

		public static async ValueTask<RequestHeader> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new RequestHeader(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.RequestApiKey = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.RequestApiVersion = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.CorrelationId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ClientId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(RequestApiKey, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(RequestApiVersion, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(CorrelationId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(ClientId, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int16 _requestApiKey = Int16.Default;
		/// <summary>
		/// The API key of this request.
		/// </summary>
		public Int16 RequestApiKey 
		{
			get => _requestApiKey;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"RequestApiKey does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_requestApiKey = value;
			}
		}

		/// <summary>
		/// The API key of this request.
		/// </summary>
		public RequestHeader WithRequestApiKey(Int16 requestApiKey)
		{
			RequestApiKey = requestApiKey;
			return this;
		}

		private Int16 _requestApiVersion = Int16.Default;
		/// <summary>
		/// The API version of this request.
		/// </summary>
		public Int16 RequestApiVersion 
		{
			get => _requestApiVersion;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"RequestApiVersion does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_requestApiVersion = value;
			}
		}

		/// <summary>
		/// The API version of this request.
		/// </summary>
		public RequestHeader WithRequestApiVersion(Int16 requestApiVersion)
		{
			RequestApiVersion = requestApiVersion;
			return this;
		}

		private Int32 _correlationId = Int32.Default;
		/// <summary>
		/// The correlation ID of this request.
		/// </summary>
		public Int32 CorrelationId 
		{
			get => _correlationId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"CorrelationId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_correlationId = value;
			}
		}

		/// <summary>
		/// The correlation ID of this request.
		/// </summary>
		public RequestHeader WithCorrelationId(Int32 correlationId)
		{
			CorrelationId = correlationId;
			return this;
		}

		private String _clientId = String.Default;
		/// <summary>
		/// The client ID string.
		/// </summary>
		public String ClientId 
		{
			get => _clientId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ClientId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_clientId = value;
			}
		}

		/// <summary>
		/// The client ID string.
		/// </summary>
		public RequestHeader WithClientId(String clientId)
		{
			ClientId = clientId;
			return this;
		}

		public ProduceResponse Respond()
			=> new ProduceResponse(Version);
	}

	public class ResponseHeader : Message, IRespond<ProduceResponse>
	{
		public ResponseHeader(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"ResponseHeader does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(0);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(0);

		public override Int16 Version { get; }

		public static async ValueTask<ResponseHeader> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ResponseHeader(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.CorrelationId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(CorrelationId, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _correlationId = Int32.Default;
		/// <summary>
		/// The correlation ID of this response.
		/// </summary>
		public Int32 CorrelationId 
		{
			get => _correlationId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"CorrelationId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_correlationId = value;
			}
		}

		/// <summary>
		/// The correlation ID of this response.
		/// </summary>
		public ResponseHeader WithCorrelationId(Int32 correlationId)
		{
			CorrelationId = correlationId;
			return this;
		}

		public ProduceResponse Respond()
			=> new ProduceResponse(Version);
	}

	public class SaslAuthenticateRequest : Message, IRespond<SaslAuthenticateResponse>
	{
		public SaslAuthenticateRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"SaslAuthenticateRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(36);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<SaslAuthenticateRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SaslAuthenticateRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.AuthBytes = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(AuthBytes, cancellationToken).ConfigureAwait(false);
			}
		}

		private Bytes _authBytes = Bytes.Default;
		/// <summary>
		/// The SASL authentication bytes from the client, as defined by the SASL mechanism.
		/// </summary>
		public Bytes AuthBytes 
		{
			get => _authBytes;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"AuthBytes does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_authBytes = value;
			}
		}

		/// <summary>
		/// The SASL authentication bytes from the client, as defined by the SASL mechanism.
		/// </summary>
		public SaslAuthenticateRequest WithAuthBytes(Bytes authBytes)
		{
			AuthBytes = authBytes;
			return this;
		}

		public SaslAuthenticateResponse Respond()
			=> new SaslAuthenticateResponse(Version);
	}

	public class SaslAuthenticateResponse : Message
	{
		public SaslAuthenticateResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"SaslAuthenticateResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(36);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<SaslAuthenticateResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SaslAuthenticateResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.AuthBytes = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.SessionLifetimeMs = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(AuthBytes, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt64Async(SessionLifetimeMs, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public SaslAuthenticateResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private String? _errorMessage = String.Default;
		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public String? ErrorMessage 
		{
			get => _errorMessage;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorMessage does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				if (Version.InRange(0, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"ErrorMessage does not support null for version {Version}. Supported versions for null value: 0+");
				}

				_errorMessage = value;
			}
		}

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public SaslAuthenticateResponse WithErrorMessage(String errorMessage)
		{
			ErrorMessage = errorMessage;
			return this;
		}

		private Bytes _authBytes = Bytes.Default;
		/// <summary>
		/// The SASL authentication bytes from the server, as defined by the SASL mechanism.
		/// </summary>
		public Bytes AuthBytes 
		{
			get => _authBytes;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"AuthBytes does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_authBytes = value;
			}
		}

		/// <summary>
		/// The SASL authentication bytes from the server, as defined by the SASL mechanism.
		/// </summary>
		public SaslAuthenticateResponse WithAuthBytes(Bytes authBytes)
		{
			AuthBytes = authBytes;
			return this;
		}

		private Int64 _sessionLifetimeMs = new Int64(0);
		/// <summary>
		/// The SASL authentication bytes from the server, as defined by the SASL mechanism.
		/// </summary>
		public Int64 SessionLifetimeMs 
		{
			get => _sessionLifetimeMs;
			set 
			{
				if (Version.InRange(1, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"SessionLifetimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
				}

				_sessionLifetimeMs = value;
			}
		}

		/// <summary>
		/// The SASL authentication bytes from the server, as defined by the SASL mechanism.
		/// </summary>
		public SaslAuthenticateResponse WithSessionLifetimeMs(Int64 sessionLifetimeMs)
		{
			SessionLifetimeMs = sessionLifetimeMs;
			return this;
		}
	}

	public class SaslHandshakeRequest : Message, IRespond<SaslHandshakeResponse>
	{
		public SaslHandshakeRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"SaslHandshakeRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(17);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<SaslHandshakeRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SaslHandshakeRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Mechanism = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(Mechanism, cancellationToken).ConfigureAwait(false);
			}
		}

		private String _mechanism = String.Default;
		/// <summary>
		/// The SASL mechanism chosen by the client.
		/// </summary>
		public String Mechanism 
		{
			get => _mechanism;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Mechanism does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_mechanism = value;
			}
		}

		/// <summary>
		/// The SASL mechanism chosen by the client.
		/// </summary>
		public SaslHandshakeRequest WithMechanism(String mechanism)
		{
			Mechanism = mechanism;
			return this;
		}

		public SaslHandshakeResponse Respond()
			=> new SaslHandshakeResponse(Version);
	}

	public class SaslHandshakeResponse : Message
	{
		public SaslHandshakeResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"SaslHandshakeResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(17);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<SaslHandshakeResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SaslHandshakeResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MechanismsCollection = await reader.ReadArrayAsync(async () => await String.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, MechanismsCollection).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public SaslHandshakeResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private String[] _mechanismsCollection = Array.Empty<String>();
		/// <summary>
		/// The mechanisms enabled in the server.
		/// </summary>
		public String[] MechanismsCollection 
		{
			get => _mechanismsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MechanismsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_mechanismsCollection = value;
			}
		}

		/// <summary>
		/// The mechanisms enabled in the server.
		/// </summary>
		public SaslHandshakeResponse WithMechanismsCollection(String[] mechanismsCollection)
		{
			MechanismsCollection = mechanismsCollection;
			return this;
		}
	}

	public class StopReplicaRequest : Message, IRespond<StopReplicaResponse>
	{
		public StopReplicaRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"StopReplicaRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(5);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<StopReplicaRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new StopReplicaRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.BrokerEpoch = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.DeletePartitions = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 0)) 
			{
				instance.PartitionsV0Collection = await reader.ReadArrayAsync(async () => await StopReplicaRequestPartitionV0.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await StopReplicaRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerEpoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt64Async(BrokerEpoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBooleanAsync(DeletePartitions, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 0)) 
			{
				await writer.WriteArrayAsync(cancellationToken, PartitionsV0Collection).ConfigureAwait(false);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _controllerId = Int32.Default;
		/// <summary>
		/// The controller id.
		/// </summary>
		public Int32 ControllerId 
		{
			get => _controllerId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ControllerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_controllerId = value;
			}
		}

		/// <summary>
		/// The controller id.
		/// </summary>
		public StopReplicaRequest WithControllerId(Int32 controllerId)
		{
			ControllerId = controllerId;
			return this;
		}

		private Int32 _controllerEpoch = Int32.Default;
		/// <summary>
		/// The controller epoch.
		/// </summary>
		public Int32 ControllerEpoch 
		{
			get => _controllerEpoch;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ControllerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_controllerEpoch = value;
			}
		}

		/// <summary>
		/// The controller epoch.
		/// </summary>
		public StopReplicaRequest WithControllerEpoch(Int32 controllerEpoch)
		{
			ControllerEpoch = controllerEpoch;
			return this;
		}

		private Int64 _brokerEpoch = new Int64(-1);
		/// <summary>
		/// The broker epoch.
		/// </summary>
		public Int64 BrokerEpoch 
		{
			get => _brokerEpoch;
			set 
			{
				_brokerEpoch = value;
			}
		}

		/// <summary>
		/// The broker epoch.
		/// </summary>
		public StopReplicaRequest WithBrokerEpoch(Int64 brokerEpoch)
		{
			BrokerEpoch = brokerEpoch;
			return this;
		}

		private Boolean _deletePartitions = Boolean.Default;
		/// <summary>
		/// Whether these partitions should be deleted.
		/// </summary>
		public Boolean DeletePartitions 
		{
			get => _deletePartitions;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"DeletePartitions does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_deletePartitions = value;
			}
		}

		/// <summary>
		/// Whether these partitions should be deleted.
		/// </summary>
		public StopReplicaRequest WithDeletePartitions(Boolean deletePartitions)
		{
			DeletePartitions = deletePartitions;
			return this;
		}

		private StopReplicaRequestPartitionV0[] _partitionsV0Collection = Array.Empty<StopReplicaRequestPartitionV0>();
		/// <summary>
		/// The partitions to stop.
		/// </summary>
		public StopReplicaRequestPartitionV0[] PartitionsV0Collection 
		{
			get => _partitionsV0Collection;
			set 
			{
				if (Version.InRange(0, 0) == false) 
				{
					throw new UnsupportedVersionException($"PartitionsV0Collection does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
				}

				_partitionsV0Collection = value;
			}
		}

		/// <summary>
		/// The partitions to stop.
		/// </summary>
		public StopReplicaRequest WithPartitionsV0Collection(params Func<StopReplicaRequestPartitionV0, StopReplicaRequestPartitionV0>[] createFields)
		{
			PartitionsV0Collection = createFields
				.Select(createField => createField(CreateStopReplicaRequestPartitionV0()))
				.ToArray();
			return this;
		}

		internal StopReplicaRequestPartitionV0 CreateStopReplicaRequestPartitionV0()
		{
			return new StopReplicaRequestPartitionV0(Version);
		}

		public class StopReplicaRequestPartitionV0 : ISerialize
		{
			internal StopReplicaRequestPartitionV0(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<StopReplicaRequestPartitionV0> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new StopReplicaRequestPartitionV0(version);
				if (instance.Version.InRange(0, 0)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 0)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 0)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 0)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _topicName = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String TopicName 
			{
				get => _topicName;
				set 
				{
					if (Version.InRange(0, 0) == false) 
					{
						throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
					}

					_topicName = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public StopReplicaRequestPartitionV0 WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			private Int32 _partitionIndex = Int32.Default;
			/// <summary>
			/// The partition index.
			/// </summary>
			public Int32 PartitionIndex 
			{
				get => _partitionIndex;
				set 
				{
					if (Version.InRange(0, 0) == false) 
					{
						throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0");
					}

					_partitionIndex = value;
				}
			}

			/// <summary>
			/// The partition index.
			/// </summary>
			public StopReplicaRequestPartitionV0 WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}
		}

		private StopReplicaRequestTopic[] _topicsCollection = Array.Empty<StopReplicaRequestTopic>();
		/// <summary>
		/// The topics to stop.
		/// </summary>
		public StopReplicaRequestTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(1, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// The topics to stop.
		/// </summary>
		public StopReplicaRequest WithTopicsCollection(params Func<StopReplicaRequestTopic, StopReplicaRequestTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateStopReplicaRequestTopic()))
				.ToArray();
			return this;
		}

		internal StopReplicaRequestTopic CreateStopReplicaRequestTopic()
		{
			return new StopReplicaRequestTopic(Version);
		}

		public class StopReplicaRequestTopic : ISerialize
		{
			internal StopReplicaRequestTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<StopReplicaRequestTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new StopReplicaRequestTopic(version);
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.PartitionIndexesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionIndexesCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(1, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public StopReplicaRequestTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private Int32[] _partitionIndexesCollection = Array.Empty<Int32>();
			/// <summary>
			/// The partition indexes.
			/// </summary>
			public Int32[] PartitionIndexesCollection 
			{
				get => _partitionIndexesCollection;
				set 
				{
					if (Version.InRange(1, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionIndexesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
					}

					_partitionIndexesCollection = value;
				}
			}

			/// <summary>
			/// The partition indexes.
			/// </summary>
			public StopReplicaRequestTopic WithPartitionIndexesCollection(Int32[] partitionIndexesCollection)
			{
				PartitionIndexesCollection = partitionIndexesCollection;
				return this;
			}
		}

		public StopReplicaResponse Respond()
			=> new StopReplicaResponse(Version);
	}

	public class StopReplicaResponse : Message
	{
		public StopReplicaResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"StopReplicaResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(5);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(1);

		public override Int16 Version { get; }

		public static async ValueTask<StopReplicaResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new StopReplicaResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await StopReplicaResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The top-level error code, or 0 if there was no top-level error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The top-level error code, or 0 if there was no top-level error.
		/// </summary>
		public StopReplicaResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private StopReplicaResponsePartition[] _partitionsCollection = Array.Empty<StopReplicaResponsePartition>();
		/// <summary>
		/// The responses for each partition.
		/// </summary>
		public StopReplicaResponsePartition[] PartitionsCollection 
		{
			get => _partitionsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_partitionsCollection = value;
			}
		}

		/// <summary>
		/// The responses for each partition.
		/// </summary>
		public StopReplicaResponse WithPartitionsCollection(params Func<StopReplicaResponsePartition, StopReplicaResponsePartition>[] createFields)
		{
			PartitionsCollection = createFields
				.Select(createField => createField(CreateStopReplicaResponsePartition()))
				.ToArray();
			return this;
		}

		internal StopReplicaResponsePartition CreateStopReplicaResponsePartition()
		{
			return new StopReplicaResponsePartition(Version);
		}

		public class StopReplicaResponsePartition : ISerialize
		{
			internal StopReplicaResponsePartition(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<StopReplicaResponsePartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new StopReplicaResponsePartition(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _topicName = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String TopicName 
			{
				get => _topicName;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topicName = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public StopReplicaResponsePartition WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			private Int32 _partitionIndex = Int32.Default;
			/// <summary>
			/// The partition index.
			/// </summary>
			public Int32 PartitionIndex 
			{
				get => _partitionIndex;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionIndex = value;
				}
			}

			/// <summary>
			/// The partition index.
			/// </summary>
			public StopReplicaResponsePartition WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}

			private Int16 _errorCode = Int16.Default;
			/// <summary>
			/// The partition error code, or 0 if there was no partition error.
			/// </summary>
			public Int16 ErrorCode 
			{
				get => _errorCode;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_errorCode = value;
				}
			}

			/// <summary>
			/// The partition error code, or 0 if there was no partition error.
			/// </summary>
			public StopReplicaResponsePartition WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}
		}
	}

	public class SyncGroupRequest : Message, IRespond<SyncGroupResponse>
	{
		public SyncGroupRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"SyncGroupRequest does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(14);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(3);

		public override Int16 Version { get; }

		public static async ValueTask<SyncGroupRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SyncGroupRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GenerationId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.AssignmentsCollection = await reader.ReadArrayAsync(async () => await SyncGroupRequestAssignment.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(GenerationId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, AssignmentsCollection).ConfigureAwait(false);
			}
		}

		private String _groupId = String.Default;
		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public String GroupId 
		{
			get => _groupId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupId = value;
			}
		}

		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public SyncGroupRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		private Int32 _generationId = Int32.Default;
		/// <summary>
		/// The generation of the group.
		/// </summary>
		public Int32 GenerationId 
		{
			get => _generationId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GenerationId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_generationId = value;
			}
		}

		/// <summary>
		/// The generation of the group.
		/// </summary>
		public SyncGroupRequest WithGenerationId(Int32 generationId)
		{
			GenerationId = generationId;
			return this;
		}

		private String _memberId = String.Default;
		/// <summary>
		/// The member ID assigned by the group.
		/// </summary>
		public String MemberId 
		{
			get => _memberId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_memberId = value;
			}
		}

		/// <summary>
		/// The member ID assigned by the group.
		/// </summary>
		public SyncGroupRequest WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}

		private String? _groupInstanceId;
		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		public String? GroupInstanceId 
		{
			get => _groupInstanceId;
			set 
			{
				if (Version.InRange(3, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupInstanceId does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
				}

				if (Version.InRange(3, 2147483647) == false &&
					value == null) 
				{
					throw new UnsupportedVersionException($"GroupInstanceId does not support null for version {Version}. Supported versions for null value: 3+");
				}

				_groupInstanceId = value;
			}
		}

		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		public SyncGroupRequest WithGroupInstanceId(String groupInstanceId)
		{
			GroupInstanceId = groupInstanceId;
			return this;
		}

		private SyncGroupRequestAssignment[] _assignmentsCollection = Array.Empty<SyncGroupRequestAssignment>();
		/// <summary>
		/// Each assignment.
		/// </summary>
		public SyncGroupRequestAssignment[] AssignmentsCollection 
		{
			get => _assignmentsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"AssignmentsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_assignmentsCollection = value;
			}
		}

		/// <summary>
		/// Each assignment.
		/// </summary>
		public SyncGroupRequest WithAssignmentsCollection(params Func<SyncGroupRequestAssignment, SyncGroupRequestAssignment>[] createFields)
		{
			AssignmentsCollection = createFields
				.Select(createField => createField(CreateSyncGroupRequestAssignment()))
				.ToArray();
			return this;
		}

		internal SyncGroupRequestAssignment CreateSyncGroupRequestAssignment()
		{
			return new SyncGroupRequestAssignment(Version);
		}

		public class SyncGroupRequestAssignment : ISerialize
		{
			internal SyncGroupRequestAssignment(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<SyncGroupRequestAssignment> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new SyncGroupRequestAssignment(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MemberId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Assignment = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(MemberId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteBytesAsync(Assignment, cancellationToken).ConfigureAwait(false);
				}
			}

			private String _memberId = String.Default;
			/// <summary>
			/// The ID of the member to assign.
			/// </summary>
			public String MemberId 
			{
				get => _memberId;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"MemberId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_memberId = value;
				}
			}

			/// <summary>
			/// The ID of the member to assign.
			/// </summary>
			public SyncGroupRequestAssignment WithMemberId(String memberId)
			{
				MemberId = memberId;
				return this;
			}

			private Bytes _assignment = Bytes.Default;
			/// <summary>
			/// The member assignment.
			/// </summary>
			public Bytes Assignment 
			{
				get => _assignment;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Assignment does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_assignment = value;
				}
			}

			/// <summary>
			/// The member assignment.
			/// </summary>
			public SyncGroupRequestAssignment WithAssignment(Bytes assignment)
			{
				Assignment = assignment;
				return this;
			}
		}

		public SyncGroupResponse Respond()
			=> new SyncGroupResponse(Version);
	}

	public class SyncGroupResponse : Message
	{
		public SyncGroupResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"SyncGroupResponse does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(14);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(3);

		public override Int16 Version { get; }

		public static async ValueTask<SyncGroupResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SyncGroupResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Assignment = await reader.ReadBytesAsync(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(Assignment, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public SyncGroupResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public SyncGroupResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		private Bytes _assignment = Bytes.Default;
		/// <summary>
		/// The member assignment.
		/// </summary>
		public Bytes Assignment 
		{
			get => _assignment;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"Assignment does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_assignment = value;
			}
		}

		/// <summary>
		/// The member assignment.
		/// </summary>
		public SyncGroupResponse WithAssignment(Bytes assignment)
		{
			Assignment = assignment;
			return this;
		}
	}

	public class TxnOffsetCommitRequest : Message, IRespond<TxnOffsetCommitResponse>
	{
		public TxnOffsetCommitRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"TxnOffsetCommitRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(28);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<TxnOffsetCommitRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new TxnOffsetCommitRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerId = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await TxnOffsetCommitRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(TransactionalId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ProducerId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ProducerEpoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private String _transactionalId = String.Default;
		/// <summary>
		/// The ID of the transaction.
		/// </summary>
		public String TransactionalId 
		{
			get => _transactionalId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TransactionalId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_transactionalId = value;
			}
		}

		/// <summary>
		/// The ID of the transaction.
		/// </summary>
		public TxnOffsetCommitRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		private String _groupId = String.Default;
		/// <summary>
		/// The ID of the group.
		/// </summary>
		public String GroupId 
		{
			get => _groupId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"GroupId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_groupId = value;
			}
		}

		/// <summary>
		/// The ID of the group.
		/// </summary>
		public TxnOffsetCommitRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		private Int64 _producerId = Int64.Default;
		/// <summary>
		/// The current producer ID in use by the transactional ID.
		/// </summary>
		public Int64 ProducerId 
		{
			get => _producerId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_producerId = value;
			}
		}

		/// <summary>
		/// The current producer ID in use by the transactional ID.
		/// </summary>
		public TxnOffsetCommitRequest WithProducerId(Int64 producerId)
		{
			ProducerId = producerId;
			return this;
		}

		private Int16 _producerEpoch = Int16.Default;
		/// <summary>
		/// The current epoch associated with the producer ID.
		/// </summary>
		public Int16 ProducerEpoch 
		{
			get => _producerEpoch;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ProducerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_producerEpoch = value;
			}
		}

		/// <summary>
		/// The current epoch associated with the producer ID.
		/// </summary>
		public TxnOffsetCommitRequest WithProducerEpoch(Int16 producerEpoch)
		{
			ProducerEpoch = producerEpoch;
			return this;
		}

		private TxnOffsetCommitRequestTopic[] _topicsCollection = Array.Empty<TxnOffsetCommitRequestTopic>();
		/// <summary>
		/// Each topic that we want to committ offsets for.
		/// </summary>
		public TxnOffsetCommitRequestTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// Each topic that we want to committ offsets for.
		/// </summary>
		public TxnOffsetCommitRequest WithTopicsCollection(params Func<TxnOffsetCommitRequestTopic, TxnOffsetCommitRequestTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateTxnOffsetCommitRequestTopic()))
				.ToArray();
			return this;
		}

		internal TxnOffsetCommitRequestTopic CreateTxnOffsetCommitRequestTopic()
		{
			return new TxnOffsetCommitRequestTopic(Version);
		}

		public class TxnOffsetCommitRequestTopic : ISerialize
		{
			internal TxnOffsetCommitRequestTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<TxnOffsetCommitRequestTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TxnOffsetCommitRequestTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await TxnOffsetCommitRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public TxnOffsetCommitRequestTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private TxnOffsetCommitRequestPartition[] _partitionsCollection = Array.Empty<TxnOffsetCommitRequestPartition>();
			/// <summary>
			/// The partitions inside the topic that we want to committ offsets for.
			/// </summary>
			public TxnOffsetCommitRequestPartition[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// The partitions inside the topic that we want to committ offsets for.
			/// </summary>
			public TxnOffsetCommitRequestTopic WithPartitionsCollection(params Func<TxnOffsetCommitRequestPartition, TxnOffsetCommitRequestPartition>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateTxnOffsetCommitRequestPartition()))
					.ToArray();
				return this;
			}

			internal TxnOffsetCommitRequestPartition CreateTxnOffsetCommitRequestPartition()
			{
				return new TxnOffsetCommitRequestPartition(Version);
			}

			public class TxnOffsetCommitRequestPartition : ISerialize
			{
				internal TxnOffsetCommitRequestPartition(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<TxnOffsetCommitRequestPartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new TxnOffsetCommitRequestPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.CommittedOffset = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(2, 2147483647)) 
					{
						instance.CommittedLeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.CommittedMetadata = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(CommittedOffset, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(2, 2147483647)) 
					{
						await writer.WriteInt32Async(CommittedLeaderEpoch, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(CommittedMetadata, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The index of the partition within the topic.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The index of the partition within the topic.
				/// </summary>
				public TxnOffsetCommitRequestPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int64 _committedOffset = Int64.Default;
				/// <summary>
				/// The message offset to be committed.
				/// </summary>
				public Int64 CommittedOffset 
				{
					get => _committedOffset;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"CommittedOffset does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_committedOffset = value;
					}
				}

				/// <summary>
				/// The message offset to be committed.
				/// </summary>
				public TxnOffsetCommitRequestPartition WithCommittedOffset(Int64 committedOffset)
				{
					CommittedOffset = committedOffset;
					return this;
				}

				private Int32 _committedLeaderEpoch = new Int32(-1);
				/// <summary>
				/// The leader epoch of the last consumed record.
				/// </summary>
				public Int32 CommittedLeaderEpoch 
				{
					get => _committedLeaderEpoch;
					set 
					{
						_committedLeaderEpoch = value;
					}
				}

				/// <summary>
				/// The leader epoch of the last consumed record.
				/// </summary>
				public TxnOffsetCommitRequestPartition WithCommittedLeaderEpoch(Int32 committedLeaderEpoch)
				{
					CommittedLeaderEpoch = committedLeaderEpoch;
					return this;
				}

				private String? _committedMetadata = String.Default;
				/// <summary>
				/// Any associated metadata the client wants to keep.
				/// </summary>
				public String? CommittedMetadata 
				{
					get => _committedMetadata;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"CommittedMetadata does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						if (Version.InRange(0, 2147483647) == false &&
							value == null) 
						{
							throw new UnsupportedVersionException($"CommittedMetadata does not support null for version {Version}. Supported versions for null value: 0+");
						}

						_committedMetadata = value;
					}
				}

				/// <summary>
				/// Any associated metadata the client wants to keep.
				/// </summary>
				public TxnOffsetCommitRequestPartition WithCommittedMetadata(String committedMetadata)
				{
					CommittedMetadata = committedMetadata;
					return this;
				}
			}
		}

		public TxnOffsetCommitResponse Respond()
			=> new TxnOffsetCommitResponse(Version);
	}

	public class TxnOffsetCommitResponse : Message
	{
		public TxnOffsetCommitResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"TxnOffsetCommitResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(28);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(2);

		public override Int16 Version { get; }

		public static async ValueTask<TxnOffsetCommitResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new TxnOffsetCommitResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await TxnOffsetCommitResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
			}
		}

		private Int32 _throttleTimeMs = Int32.Default;
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ThrottleTimeMs does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_throttleTimeMs = value;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public TxnOffsetCommitResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		private TxnOffsetCommitResponseTopic[] _topicsCollection = Array.Empty<TxnOffsetCommitResponseTopic>();
		/// <summary>
		/// The responses for each topic.
		/// </summary>
		public TxnOffsetCommitResponseTopic[] TopicsCollection 
		{
			get => _topicsCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_topicsCollection = value;
			}
		}

		/// <summary>
		/// The responses for each topic.
		/// </summary>
		public TxnOffsetCommitResponse WithTopicsCollection(params Func<TxnOffsetCommitResponseTopic, TxnOffsetCommitResponseTopic>[] createFields)
		{
			TopicsCollection = createFields
				.Select(createField => createField(CreateTxnOffsetCommitResponseTopic()))
				.ToArray();
			return this;
		}

		internal TxnOffsetCommitResponseTopic CreateTxnOffsetCommitResponseTopic()
		{
			return new TxnOffsetCommitResponseTopic(Version);
		}

		public class TxnOffsetCommitResponseTopic : ISerialize
		{
			internal TxnOffsetCommitResponseTopic(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<TxnOffsetCommitResponseTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TxnOffsetCommitResponseTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await TxnOffsetCommitResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
				}
			}

			private String _name = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name 
			{
				get => _name;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_name = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public TxnOffsetCommitResponseTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			private TxnOffsetCommitResponsePartition[] _partitionsCollection = Array.Empty<TxnOffsetCommitResponsePartition>();
			/// <summary>
			/// The responses for each partition in the topic.
			/// </summary>
			public TxnOffsetCommitResponsePartition[] PartitionsCollection 
			{
				get => _partitionsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionsCollection = value;
				}
			}

			/// <summary>
			/// The responses for each partition in the topic.
			/// </summary>
			public TxnOffsetCommitResponseTopic WithPartitionsCollection(params Func<TxnOffsetCommitResponsePartition, TxnOffsetCommitResponsePartition>[] createFields)
			{
				PartitionsCollection = createFields
					.Select(createField => createField(CreateTxnOffsetCommitResponsePartition()))
					.ToArray();
				return this;
			}

			internal TxnOffsetCommitResponsePartition CreateTxnOffsetCommitResponsePartition()
			{
				return new TxnOffsetCommitResponsePartition(Version);
			}

			public class TxnOffsetCommitResponsePartition : ISerialize
			{
				internal TxnOffsetCommitResponsePartition(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<TxnOffsetCommitResponsePartition> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new TxnOffsetCommitResponsePartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _partitionIndex = Int32.Default;
				/// <summary>
				/// The partitition index.
				/// </summary>
				public Int32 PartitionIndex 
				{
					get => _partitionIndex;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndex = value;
					}
				}

				/// <summary>
				/// The partitition index.
				/// </summary>
				public TxnOffsetCommitResponsePartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				private Int16 _errorCode = Int16.Default;
				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode 
				{
					get => _errorCode;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_errorCode = value;
					}
				}

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public TxnOffsetCommitResponsePartition WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}
	}

	public class UpdateMetadataRequest : Message, IRespond<UpdateMetadataResponse>
	{
		public UpdateMetadataRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"UpdateMetadataRequest does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(6);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(5);

		public override Int16 Version { get; }

		public static async ValueTask<UpdateMetadataRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new UpdateMetadataRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerId = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(5, 2147483647)) 
			{
				instance.BrokerEpoch = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 4)) 
			{
				instance.LegacyPartitionStatesCollection = await reader.ReadArrayAsync(async () => await UpdateMetadataPartitionState.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(5, 2147483647)) 
			{
				instance.TopicStatesCollection = await reader.ReadArrayAsync(async () => await UpdateMetadataRequestTopicState.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.BrokersCollection = await reader.ReadArrayAsync(async () => await UpdateMetadataRequestBroker.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerId, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerEpoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(5, 2147483647)) 
			{
				await writer.WriteInt64Async(BrokerEpoch, cancellationToken).ConfigureAwait(false);
			}
			if (Version.InRange(0, 4)) 
			{
				await writer.WriteArrayAsync(cancellationToken, LegacyPartitionStatesCollection).ConfigureAwait(false);
			}
			if (Version.InRange(5, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicStatesCollection).ConfigureAwait(false);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, BrokersCollection).ConfigureAwait(false);
			}
		}

		private Int32 _controllerId = Int32.Default;
		/// <summary>
		/// The controller id.
		/// </summary>
		public Int32 ControllerId 
		{
			get => _controllerId;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ControllerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_controllerId = value;
			}
		}

		/// <summary>
		/// The controller id.
		/// </summary>
		public UpdateMetadataRequest WithControllerId(Int32 controllerId)
		{
			ControllerId = controllerId;
			return this;
		}

		private Int32 _controllerEpoch = Int32.Default;
		/// <summary>
		/// The controller epoch.
		/// </summary>
		public Int32 ControllerEpoch 
		{
			get => _controllerEpoch;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ControllerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_controllerEpoch = value;
			}
		}

		/// <summary>
		/// The controller epoch.
		/// </summary>
		public UpdateMetadataRequest WithControllerEpoch(Int32 controllerEpoch)
		{
			ControllerEpoch = controllerEpoch;
			return this;
		}

		private Int64 _brokerEpoch = new Int64(-1);
		/// <summary>
		/// The broker epoch.
		/// </summary>
		public Int64 BrokerEpoch 
		{
			get => _brokerEpoch;
			set 
			{
				_brokerEpoch = value;
			}
		}

		/// <summary>
		/// The broker epoch.
		/// </summary>
		public UpdateMetadataRequest WithBrokerEpoch(Int64 brokerEpoch)
		{
			BrokerEpoch = brokerEpoch;
			return this;
		}

		private UpdateMetadataPartitionState[] _legacyPartitionStatesCollection = Array.Empty<UpdateMetadataPartitionState>();
		/// <summary>
		/// In older versions of this RPC, each partition that we would like to update.
		/// </summary>
		public UpdateMetadataPartitionState[] LegacyPartitionStatesCollection 
		{
			get => _legacyPartitionStatesCollection;
			set 
			{
				if (Version.InRange(0, 4) == false) 
				{
					throw new UnsupportedVersionException($"LegacyPartitionStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0-4");
				}

				_legacyPartitionStatesCollection = value;
			}
		}

		/// <summary>
		/// In older versions of this RPC, each partition that we would like to update.
		/// </summary>
		public UpdateMetadataRequest WithLegacyPartitionStatesCollection(UpdateMetadataPartitionState[] legacyPartitionStatesCollection)
		{
			LegacyPartitionStatesCollection = legacyPartitionStatesCollection;
			return this;
		}

		private UpdateMetadataRequestTopicState[] _topicStatesCollection = Array.Empty<UpdateMetadataRequestTopicState>();
		/// <summary>
		/// In newer versions of this RPC, each topic that we would like to update.
		/// </summary>
		public UpdateMetadataRequestTopicState[] TopicStatesCollection 
		{
			get => _topicStatesCollection;
			set 
			{
				if (Version.InRange(5, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"TopicStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
				}

				_topicStatesCollection = value;
			}
		}

		/// <summary>
		/// In newer versions of this RPC, each topic that we would like to update.
		/// </summary>
		public UpdateMetadataRequest WithTopicStatesCollection(params Func<UpdateMetadataRequestTopicState, UpdateMetadataRequestTopicState>[] createFields)
		{
			TopicStatesCollection = createFields
				.Select(createField => createField(CreateUpdateMetadataRequestTopicState()))
				.ToArray();
			return this;
		}

		internal UpdateMetadataRequestTopicState CreateUpdateMetadataRequestTopicState()
		{
			return new UpdateMetadataRequestTopicState(Version);
		}

		public class UpdateMetadataRequestTopicState : ISerialize
		{
			internal UpdateMetadataRequestTopicState(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<UpdateMetadataRequestTopicState> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new UpdateMetadataRequestTopicState(version);
				if (instance.Version.InRange(5, 2147483647)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(5, 2147483647)) 
				{
					instance.PartitionStatesCollection = await reader.ReadArrayAsync(async () => await UpdateMetadataPartitionState.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(5, 2147483647)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(5, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionStatesCollection).ConfigureAwait(false);
				}
			}

			private String _topicName = String.Default;
			/// <summary>
			/// The topic name.
			/// </summary>
			public String TopicName 
			{
				get => _topicName;
				set 
				{
					if (Version.InRange(5, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
					}

					_topicName = value;
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public UpdateMetadataRequestTopicState WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			private UpdateMetadataPartitionState[] _partitionStatesCollection = Array.Empty<UpdateMetadataPartitionState>();
			/// <summary>
			/// The partition that we would like to update.
			/// </summary>
			public UpdateMetadataPartitionState[] PartitionStatesCollection 
			{
				get => _partitionStatesCollection;
				set 
				{
					if (Version.InRange(5, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionStatesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 5+");
					}

					_partitionStatesCollection = value;
				}
			}

			/// <summary>
			/// The partition that we would like to update.
			/// </summary>
			public UpdateMetadataRequestTopicState WithPartitionStatesCollection(UpdateMetadataPartitionState[] partitionStatesCollection)
			{
				PartitionStatesCollection = partitionStatesCollection;
				return this;
			}
		}

		private UpdateMetadataRequestBroker[] _brokersCollection = Array.Empty<UpdateMetadataRequestBroker>();
		public UpdateMetadataRequestBroker[] BrokersCollection 
		{
			get => _brokersCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"BrokersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_brokersCollection = value;
			}
		}

		public UpdateMetadataRequest WithBrokersCollection(params Func<UpdateMetadataRequestBroker, UpdateMetadataRequestBroker>[] createFields)
		{
			BrokersCollection = createFields
				.Select(createField => createField(CreateUpdateMetadataRequestBroker()))
				.ToArray();
			return this;
		}

		internal UpdateMetadataRequestBroker CreateUpdateMetadataRequestBroker()
		{
			return new UpdateMetadataRequestBroker(Version);
		}

		public class UpdateMetadataRequestBroker : ISerialize
		{
			internal UpdateMetadataRequestBroker(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<UpdateMetadataRequestBroker> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new UpdateMetadataRequestBroker(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Id = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 0)) 
				{
					instance.V0Host = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 0)) 
				{
					instance.V0Port = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.EndpointsCollection = await reader.ReadArrayAsync(async () => await UpdateMetadataRequestEndpoint.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(2, 2147483647)) 
				{
					instance.Rack = await reader.ReadNullableStringAsync(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(Id, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 0)) 
				{
					await writer.WriteStringAsync(V0Host, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 0)) 
				{
					await writer.WriteInt32Async(V0Port, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, EndpointsCollection).ConfigureAwait(false);
				}
				if (Version.InRange(2, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(Rack, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int32 _id = Int32.Default;
			/// <summary>
			/// The broker id.
			/// </summary>
			public Int32 Id 
			{
				get => _id;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Id does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_id = value;
				}
			}

			/// <summary>
			/// The broker id.
			/// </summary>
			public UpdateMetadataRequestBroker WithId(Int32 id)
			{
				Id = id;
				return this;
			}

			private String _v0Host = String.Default;
			/// <summary>
			/// The broker hostname.
			/// </summary>
			public String V0Host 
			{
				get => _v0Host;
				set 
				{
					_v0Host = value;
				}
			}

			/// <summary>
			/// The broker hostname.
			/// </summary>
			public UpdateMetadataRequestBroker WithV0Host(String v0Host)
			{
				V0Host = v0Host;
				return this;
			}

			private Int32 _v0Port = Int32.Default;
			/// <summary>
			/// The broker port.
			/// </summary>
			public Int32 V0Port 
			{
				get => _v0Port;
				set 
				{
					_v0Port = value;
				}
			}

			/// <summary>
			/// The broker port.
			/// </summary>
			public UpdateMetadataRequestBroker WithV0Port(Int32 v0Port)
			{
				V0Port = v0Port;
				return this;
			}

			private UpdateMetadataRequestEndpoint[] _endpointsCollection = Array.Empty<UpdateMetadataRequestEndpoint>();
			/// <summary>
			/// The broker endpoints.
			/// </summary>
			public UpdateMetadataRequestEndpoint[] EndpointsCollection 
			{
				get => _endpointsCollection;
				set 
				{
					if (Version.InRange(1, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"EndpointsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
					}

					_endpointsCollection = value;
				}
			}

			/// <summary>
			/// The broker endpoints.
			/// </summary>
			public UpdateMetadataRequestBroker WithEndpointsCollection(params Func<UpdateMetadataRequestEndpoint, UpdateMetadataRequestEndpoint>[] createFields)
			{
				EndpointsCollection = createFields
					.Select(createField => createField(CreateUpdateMetadataRequestEndpoint()))
					.ToArray();
				return this;
			}

			internal UpdateMetadataRequestEndpoint CreateUpdateMetadataRequestEndpoint()
			{
				return new UpdateMetadataRequestEndpoint(Version);
			}

			public class UpdateMetadataRequestEndpoint : ISerialize
			{
				internal UpdateMetadataRequestEndpoint(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<UpdateMetadataRequestEndpoint> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new UpdateMetadataRequestEndpoint(version);
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.Port = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.Host = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(3, 2147483647)) 
					{
						instance.Listener = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.SecurityProtocol = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt32Async(Port, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteStringAsync(Host, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(3, 2147483647)) 
					{
						await writer.WriteStringAsync(Listener, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt16Async(SecurityProtocol, cancellationToken).ConfigureAwait(false);
					}
				}

				private Int32 _port = Int32.Default;
				/// <summary>
				/// The port of this endpoint
				/// </summary>
				public Int32 Port 
				{
					get => _port;
					set 
					{
						if (Version.InRange(1, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Port does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
						}

						_port = value;
					}
				}

				/// <summary>
				/// The port of this endpoint
				/// </summary>
				public UpdateMetadataRequestEndpoint WithPort(Int32 port)
				{
					Port = port;
					return this;
				}

				private String _host = String.Default;
				/// <summary>
				/// The hostname of this endpoint
				/// </summary>
				public String Host 
				{
					get => _host;
					set 
					{
						if (Version.InRange(1, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Host does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
						}

						_host = value;
					}
				}

				/// <summary>
				/// The hostname of this endpoint
				/// </summary>
				public UpdateMetadataRequestEndpoint WithHost(String host)
				{
					Host = host;
					return this;
				}

				private String _listener = String.Default;
				/// <summary>
				/// The listener name.
				/// </summary>
				public String Listener 
				{
					get => _listener;
					set 
					{
						if (Version.InRange(3, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Listener does not support version {Version} and has been defined as not ignorable. Supported versions: 3+");
						}

						_listener = value;
					}
				}

				/// <summary>
				/// The listener name.
				/// </summary>
				public UpdateMetadataRequestEndpoint WithListener(String listener)
				{
					Listener = listener;
					return this;
				}

				private Int16 _securityProtocol = Int16.Default;
				/// <summary>
				/// The security protocol type.
				/// </summary>
				public Int16 SecurityProtocol 
				{
					get => _securityProtocol;
					set 
					{
						if (Version.InRange(1, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"SecurityProtocol does not support version {Version} and has been defined as not ignorable. Supported versions: 1+");
						}

						_securityProtocol = value;
					}
				}

				/// <summary>
				/// The security protocol type.
				/// </summary>
				public UpdateMetadataRequestEndpoint WithSecurityProtocol(Int16 securityProtocol)
				{
					SecurityProtocol = securityProtocol;
					return this;
				}
			}

			private String? _rack = String.Default;
			/// <summary>
			/// The rack which this broker belongs to.
			/// </summary>
			public String? Rack 
			{
				get => _rack;
				set 
				{
					if (Version.InRange(0, 2147483647) == false &&
						value == null) 
					{
						throw new UnsupportedVersionException($"Rack does not support null for version {Version}. Supported versions for null value: 0+");
					}

					_rack = value;
				}
			}

			/// <summary>
			/// The rack which this broker belongs to.
			/// </summary>
			public UpdateMetadataRequestBroker WithRack(String rack)
			{
				Rack = rack;
				return this;
			}
		}

		public class UpdateMetadataPartitionState : ISerialize
		{
			internal UpdateMetadataPartitionState(Int16 version)
			{
				if (version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"UpdateMetadataPartitionState does not support version {version}. Valid versions are: 0+");
				}

				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<UpdateMetadataPartitionState> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new UpdateMetadataPartitionState(version);
				if (instance.Version.InRange(0, 4)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ControllerEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Leader = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.IsrCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ZkVersion = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ReplicasCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(4, 2147483647)) 
				{
					instance.OfflineReplicasCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 4)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(ControllerEpoch, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(Leader, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(LeaderEpoch, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, IsrCollection).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(ZkVersion, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ReplicasCollection).ConfigureAwait(false);
				}
				if (Version.InRange(4, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, OfflineReplicasCollection).ConfigureAwait(false);
				}
			}

			private String _topicName = String.Default;
			/// <summary>
			/// In older versions of this RPC, the topic name.
			/// </summary>
			public String TopicName 
			{
				get => _topicName;
				set 
				{
					if (Version.InRange(0, 4) == false) 
					{
						throw new UnsupportedVersionException($"TopicName does not support version {Version} and has been defined as not ignorable. Supported versions: 0-4");
					}

					_topicName = value;
				}
			}

			/// <summary>
			/// In older versions of this RPC, the topic name.
			/// </summary>
			public UpdateMetadataPartitionState WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			private Int32 _partitionIndex = Int32.Default;
			/// <summary>
			/// The partition index.
			/// </summary>
			public Int32 PartitionIndex 
			{
				get => _partitionIndex;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_partitionIndex = value;
				}
			}

			/// <summary>
			/// The partition index.
			/// </summary>
			public UpdateMetadataPartitionState WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}

			private Int32 _controllerEpoch = Int32.Default;
			/// <summary>
			/// The controller epoch.
			/// </summary>
			public Int32 ControllerEpoch 
			{
				get => _controllerEpoch;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ControllerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_controllerEpoch = value;
				}
			}

			/// <summary>
			/// The controller epoch.
			/// </summary>
			public UpdateMetadataPartitionState WithControllerEpoch(Int32 controllerEpoch)
			{
				ControllerEpoch = controllerEpoch;
				return this;
			}

			private Int32 _leader = Int32.Default;
			/// <summary>
			/// The ID of the broker which is the current partition leader.
			/// </summary>
			public Int32 Leader 
			{
				get => _leader;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"Leader does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_leader = value;
				}
			}

			/// <summary>
			/// The ID of the broker which is the current partition leader.
			/// </summary>
			public UpdateMetadataPartitionState WithLeader(Int32 leader)
			{
				Leader = leader;
				return this;
			}

			private Int32 _leaderEpoch = Int32.Default;
			/// <summary>
			/// The leader epoch of this partition.
			/// </summary>
			public Int32 LeaderEpoch 
			{
				get => _leaderEpoch;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"LeaderEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_leaderEpoch = value;
				}
			}

			/// <summary>
			/// The leader epoch of this partition.
			/// </summary>
			public UpdateMetadataPartitionState WithLeaderEpoch(Int32 leaderEpoch)
			{
				LeaderEpoch = leaderEpoch;
				return this;
			}

			private Int32[] _isrCollection = Array.Empty<Int32>();
			/// <summary>
			/// The brokers which are in the ISR for this partition.
			/// </summary>
			public Int32[] IsrCollection 
			{
				get => _isrCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"IsrCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_isrCollection = value;
				}
			}

			/// <summary>
			/// The brokers which are in the ISR for this partition.
			/// </summary>
			public UpdateMetadataPartitionState WithIsrCollection(Int32[] isrCollection)
			{
				IsrCollection = isrCollection;
				return this;
			}

			private Int32 _zkVersion = Int32.Default;
			/// <summary>
			/// The Zookeeper version.
			/// </summary>
			public Int32 ZkVersion 
			{
				get => _zkVersion;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ZkVersion does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_zkVersion = value;
				}
			}

			/// <summary>
			/// The Zookeeper version.
			/// </summary>
			public UpdateMetadataPartitionState WithZkVersion(Int32 zkVersion)
			{
				ZkVersion = zkVersion;
				return this;
			}

			private Int32[] _replicasCollection = Array.Empty<Int32>();
			/// <summary>
			/// All the replicas of this partition.
			/// </summary>
			public Int32[] ReplicasCollection 
			{
				get => _replicasCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ReplicasCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_replicasCollection = value;
				}
			}

			/// <summary>
			/// All the replicas of this partition.
			/// </summary>
			public UpdateMetadataPartitionState WithReplicasCollection(Int32[] replicasCollection)
			{
				ReplicasCollection = replicasCollection;
				return this;
			}

			private Int32[] _offlineReplicasCollection = Array.Empty<Int32>();
			/// <summary>
			/// The replicas of this partition which are offline.
			/// </summary>
			public Int32[] OfflineReplicasCollection 
			{
				get => _offlineReplicasCollection;
				set 
				{
					if (Version.InRange(4, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"OfflineReplicasCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 4+");
					}

					_offlineReplicasCollection = value;
				}
			}

			/// <summary>
			/// The replicas of this partition which are offline.
			/// </summary>
			public UpdateMetadataPartitionState WithOfflineReplicasCollection(Int32[] offlineReplicasCollection)
			{
				OfflineReplicasCollection = offlineReplicasCollection;
				return this;
			}
		}

		public UpdateMetadataResponse Respond()
			=> new UpdateMetadataResponse(Version);
	}

	public class UpdateMetadataResponse : Message
	{
		public UpdateMetadataResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"UpdateMetadataResponse does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(6);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(5);

		public override Int16 Version { get; }

		public static async ValueTask<UpdateMetadataResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new UpdateMetadataResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
			}
		}

		private Int16 _errorCode = Int16.Default;
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode 
		{
			get => _errorCode;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_errorCode = value;
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public UpdateMetadataResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class WriteTxnMarkersRequest : Message, IRespond<WriteTxnMarkersResponse>
	{
		public WriteTxnMarkersRequest(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"WriteTxnMarkersRequest does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(27);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(0);

		public override Int16 Version { get; }

		public static async ValueTask<WriteTxnMarkersRequest> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new WriteTxnMarkersRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MarkersCollection = await reader.ReadArrayAsync(async () => await WritableTxnMarker.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, MarkersCollection).ConfigureAwait(false);
			}
		}

		private WritableTxnMarker[] _markersCollection = Array.Empty<WritableTxnMarker>();
		/// <summary>
		/// The transaction markers to be written.
		/// </summary>
		public WritableTxnMarker[] MarkersCollection 
		{
			get => _markersCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MarkersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_markersCollection = value;
			}
		}

		/// <summary>
		/// The transaction markers to be written.
		/// </summary>
		public WriteTxnMarkersRequest WithMarkersCollection(params Func<WritableTxnMarker, WritableTxnMarker>[] createFields)
		{
			MarkersCollection = createFields
				.Select(createField => createField(CreateWritableTxnMarker()))
				.ToArray();
			return this;
		}

		internal WritableTxnMarker CreateWritableTxnMarker()
		{
			return new WritableTxnMarker(Version);
		}

		public class WritableTxnMarker : ISerialize
		{
			internal WritableTxnMarker(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<WritableTxnMarker> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new WritableTxnMarker(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProducerId = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TransactionResult = await reader.ReadBooleanAsync(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicsCollection = await reader.ReadArrayAsync(async () => await WritableTxnMarkerTopic.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.CoordinatorEpoch = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt64Async(ProducerId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ProducerEpoch, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteBooleanAsync(TransactionResult, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(CoordinatorEpoch, cancellationToken).ConfigureAwait(false);
				}
			}

			private Int64 _producerId = Int64.Default;
			/// <summary>
			/// The current producer ID.
			/// </summary>
			public Int64 ProducerId 
			{
				get => _producerId;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_producerId = value;
				}
			}

			/// <summary>
			/// The current producer ID.
			/// </summary>
			public WritableTxnMarker WithProducerId(Int64 producerId)
			{
				ProducerId = producerId;
				return this;
			}

			private Int16 _producerEpoch = Int16.Default;
			/// <summary>
			/// The current epoch associated with the producer ID.
			/// </summary>
			public Int16 ProducerEpoch 
			{
				get => _producerEpoch;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ProducerEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_producerEpoch = value;
				}
			}

			/// <summary>
			/// The current epoch associated with the producer ID.
			/// </summary>
			public WritableTxnMarker WithProducerEpoch(Int16 producerEpoch)
			{
				ProducerEpoch = producerEpoch;
				return this;
			}

			private Boolean _transactionResult = Boolean.Default;
			/// <summary>
			/// The result of the transaction to write to the partitions (false = ABORT, true = COMMIT).
			/// </summary>
			public Boolean TransactionResult 
			{
				get => _transactionResult;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TransactionResult does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_transactionResult = value;
				}
			}

			/// <summary>
			/// The result of the transaction to write to the partitions (false = ABORT, true = COMMIT).
			/// </summary>
			public WritableTxnMarker WithTransactionResult(Boolean transactionResult)
			{
				TransactionResult = transactionResult;
				return this;
			}

			private WritableTxnMarkerTopic[] _topicsCollection = Array.Empty<WritableTxnMarkerTopic>();
			/// <summary>
			/// Each topic that we want to write transaction marker(s) for.
			/// </summary>
			public WritableTxnMarkerTopic[] TopicsCollection 
			{
				get => _topicsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topicsCollection = value;
				}
			}

			/// <summary>
			/// Each topic that we want to write transaction marker(s) for.
			/// </summary>
			public WritableTxnMarker WithTopicsCollection(params Func<WritableTxnMarkerTopic, WritableTxnMarkerTopic>[] createFields)
			{
				TopicsCollection = createFields
					.Select(createField => createField(CreateWritableTxnMarkerTopic()))
					.ToArray();
				return this;
			}

			internal WritableTxnMarkerTopic CreateWritableTxnMarkerTopic()
			{
				return new WritableTxnMarkerTopic(Version);
			}

			public class WritableTxnMarkerTopic : ISerialize
			{
				internal WritableTxnMarkerTopic(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<WritableTxnMarkerTopic> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new WritableTxnMarkerTopic(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndexesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, PartitionIndexesCollection).ConfigureAwait(false);
					}
				}

				private String _name = String.Default;
				/// <summary>
				/// The topic name.
				/// </summary>
				public String Name 
				{
					get => _name;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_name = value;
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				public WritableTxnMarkerTopic WithName(String name)
				{
					Name = name;
					return this;
				}

				private Int32[] _partitionIndexesCollection = Array.Empty<Int32>();
				/// <summary>
				/// The indexes of the partitions to write transaction markers for.
				/// </summary>
				public Int32[] PartitionIndexesCollection 
				{
					get => _partitionIndexesCollection;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionIndexesCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionIndexesCollection = value;
					}
				}

				/// <summary>
				/// The indexes of the partitions to write transaction markers for.
				/// </summary>
				public WritableTxnMarkerTopic WithPartitionIndexesCollection(Int32[] partitionIndexesCollection)
				{
					PartitionIndexesCollection = partitionIndexesCollection;
					return this;
				}
			}

			private Int32 _coordinatorEpoch = Int32.Default;
			/// <summary>
			/// Epoch associated with the transaction state partition hosted by this transaction coordinator
			/// </summary>
			public Int32 CoordinatorEpoch 
			{
				get => _coordinatorEpoch;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"CoordinatorEpoch does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_coordinatorEpoch = value;
				}
			}

			/// <summary>
			/// Epoch associated with the transaction state partition hosted by this transaction coordinator
			/// </summary>
			public WritableTxnMarker WithCoordinatorEpoch(Int32 coordinatorEpoch)
			{
				CoordinatorEpoch = coordinatorEpoch;
				return this;
			}
		}

		public WriteTxnMarkersResponse Respond()
			=> new WriteTxnMarkersResponse(Version);
	}

	public class WriteTxnMarkersResponse : Message
	{
		public WriteTxnMarkersResponse(Int16 version)
		{
			if (version.InRange(MinVersion, MaxVersion) == false) 
			{
				throw new UnsupportedVersionException($"WriteTxnMarkersResponse does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public static readonly Int16 ApiKey = Int16.From(27);

		public static readonly Int16 MinVersion = Int16.From(0);
		public static readonly Int16 MaxVersion = Int16.From(0);

		public override Int16 Version { get; }

		public static async ValueTask<WriteTxnMarkersResponse> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new WriteTxnMarkersResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MarkersCollection = await reader.ReadArrayAsync(async () => await WritableTxnMarkerResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
			}
			return instance;
		}

		public override async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, MarkersCollection).ConfigureAwait(false);
			}
		}

		private WritableTxnMarkerResult[] _markersCollection = Array.Empty<WritableTxnMarkerResult>();
		/// <summary>
		/// The results for writing makers.
		/// </summary>
		public WritableTxnMarkerResult[] MarkersCollection 
		{
			get => _markersCollection;
			set 
			{
				if (Version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"MarkersCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
				}

				_markersCollection = value;
			}
		}

		/// <summary>
		/// The results for writing makers.
		/// </summary>
		public WriteTxnMarkersResponse WithMarkersCollection(params Func<WritableTxnMarkerResult, WritableTxnMarkerResult>[] createFields)
		{
			MarkersCollection = createFields
				.Select(createField => createField(CreateWritableTxnMarkerResult()))
				.ToArray();
			return this;
		}

		internal WritableTxnMarkerResult CreateWritableTxnMarkerResult()
		{
			return new WritableTxnMarkerResult(Version);
		}

		public class WritableTxnMarkerResult : ISerialize
		{
			internal WritableTxnMarkerResult(Int16 version)
			{
				Version = version;
			}

			internal Int16 Version { get; }

			public static async ValueTask<WritableTxnMarkerResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new WritableTxnMarkerResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProducerId = await reader.ReadInt64Async(cancellationToken).ConfigureAwait(false);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicsCollection = await reader.ReadArrayAsync(async () => await WritableTxnMarkerTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
				}
				return instance;
			}

			public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt64Async(ProducerId, cancellationToken).ConfigureAwait(false);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, TopicsCollection).ConfigureAwait(false);
				}
			}

			private Int64 _producerId = Int64.Default;
			/// <summary>
			/// The current producer ID in use by the transactional ID.
			/// </summary>
			public Int64 ProducerId 
			{
				get => _producerId;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"ProducerId does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_producerId = value;
				}
			}

			/// <summary>
			/// The current producer ID in use by the transactional ID.
			/// </summary>
			public WritableTxnMarkerResult WithProducerId(Int64 producerId)
			{
				ProducerId = producerId;
				return this;
			}

			private WritableTxnMarkerTopicResult[] _topicsCollection = Array.Empty<WritableTxnMarkerTopicResult>();
			/// <summary>
			/// The results by topic.
			/// </summary>
			public WritableTxnMarkerTopicResult[] TopicsCollection 
			{
				get => _topicsCollection;
				set 
				{
					if (Version.InRange(0, 2147483647) == false) 
					{
						throw new UnsupportedVersionException($"TopicsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
					}

					_topicsCollection = value;
				}
			}

			/// <summary>
			/// The results by topic.
			/// </summary>
			public WritableTxnMarkerResult WithTopicsCollection(params Func<WritableTxnMarkerTopicResult, WritableTxnMarkerTopicResult>[] createFields)
			{
				TopicsCollection = createFields
					.Select(createField => createField(CreateWritableTxnMarkerTopicResult()))
					.ToArray();
				return this;
			}

			internal WritableTxnMarkerTopicResult CreateWritableTxnMarkerTopicResult()
			{
				return new WritableTxnMarkerTopicResult(Version);
			}

			public class WritableTxnMarkerTopicResult : ISerialize
			{
				internal WritableTxnMarkerTopicResult(Int16 version)
				{
					Version = version;
				}

				internal Int16 Version { get; }

				public static async ValueTask<WritableTxnMarkerTopicResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new WritableTxnMarkerTopicResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken).ConfigureAwait(false);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await WritableTxnMarkerPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
					}
					return instance;
				}

				public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken).ConfigureAwait(false);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, PartitionsCollection).ConfigureAwait(false);
					}
				}

				private String _name = String.Default;
				/// <summary>
				/// The topic name.
				/// </summary>
				public String Name 
				{
					get => _name;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"Name does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_name = value;
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				public WritableTxnMarkerTopicResult WithName(String name)
				{
					Name = name;
					return this;
				}

				private WritableTxnMarkerPartitionResult[] _partitionsCollection = Array.Empty<WritableTxnMarkerPartitionResult>();
				/// <summary>
				/// The results by partition.
				/// </summary>
				public WritableTxnMarkerPartitionResult[] PartitionsCollection 
				{
					get => _partitionsCollection;
					set 
					{
						if (Version.InRange(0, 2147483647) == false) 
						{
							throw new UnsupportedVersionException($"PartitionsCollection does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
						}

						_partitionsCollection = value;
					}
				}

				/// <summary>
				/// The results by partition.
				/// </summary>
				public WritableTxnMarkerTopicResult WithPartitionsCollection(params Func<WritableTxnMarkerPartitionResult, WritableTxnMarkerPartitionResult>[] createFields)
				{
					PartitionsCollection = createFields
						.Select(createField => createField(CreateWritableTxnMarkerPartitionResult()))
						.ToArray();
					return this;
				}

				internal WritableTxnMarkerPartitionResult CreateWritableTxnMarkerPartitionResult()
				{
					return new WritableTxnMarkerPartitionResult(Version);
				}

				public class WritableTxnMarkerPartitionResult : ISerialize
				{
					internal WritableTxnMarkerPartitionResult(Int16 version)
					{
						Version = version;
					}

					internal Int16 Version { get; }

					public static async ValueTask<WritableTxnMarkerPartitionResult> FromReaderAsync(Int16 version, IKafkaReader reader, CancellationToken cancellationToken = default)
					{
						var instance = new WritableTxnMarkerPartitionResult(version);
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken).ConfigureAwait(false);
						}
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.ErrorCode = await reader.ReadInt16Async(cancellationToken).ConfigureAwait(false);
						}
						return instance;
					}

					public async ValueTask WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
					{
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteInt32Async(PartitionIndex, cancellationToken).ConfigureAwait(false);
						}
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteInt16Async(ErrorCode, cancellationToken).ConfigureAwait(false);
						}
					}

					private Int32 _partitionIndex = Int32.Default;
					/// <summary>
					/// The partition index.
					/// </summary>
					public Int32 PartitionIndex 
					{
						get => _partitionIndex;
						set 
						{
							if (Version.InRange(0, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"PartitionIndex does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
							}

							_partitionIndex = value;
						}
					}

					/// <summary>
					/// The partition index.
					/// </summary>
					public WritableTxnMarkerPartitionResult WithPartitionIndex(Int32 partitionIndex)
					{
						PartitionIndex = partitionIndex;
						return this;
					}

					private Int16 _errorCode = Int16.Default;
					/// <summary>
					/// The error code, or 0 if there was no error.
					/// </summary>
					public Int16 ErrorCode 
					{
						get => _errorCode;
						set 
						{
							if (Version.InRange(0, 2147483647) == false) 
							{
								throw new UnsupportedVersionException($"ErrorCode does not support version {Version} and has been defined as not ignorable. Supported versions: 0+");
							}

							_errorCode = value;
						}
					}

					/// <summary>
					/// The error code, or 0 if there was no error.
					/// </summary>
					public WritableTxnMarkerPartitionResult WithErrorCode(Int16 errorCode)
					{
						ErrorCode = errorCode;
						return this;
					}
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
					.WithIndex(AddOffsetsToTxnRequest.ApiKey)
					.WithMinVersion(AddOffsetsToTxnRequest.MinVersion)
					.WithMaxVersion(AddOffsetsToTxnRequest.MaxVersion),
				key => key
					.WithIndex(AddPartitionsToTxnRequest.ApiKey)
					.WithMinVersion(AddPartitionsToTxnRequest.MinVersion)
					.WithMaxVersion(AddPartitionsToTxnRequest.MaxVersion),
				key => key
					.WithIndex(AlterConfigsRequest.ApiKey)
					.WithMinVersion(AlterConfigsRequest.MinVersion)
					.WithMaxVersion(AlterConfigsRequest.MaxVersion),
				key => key
					.WithIndex(AlterReplicaLogDirsRequest.ApiKey)
					.WithMinVersion(AlterReplicaLogDirsRequest.MinVersion)
					.WithMaxVersion(AlterReplicaLogDirsRequest.MaxVersion),
				key => key
					.WithIndex(ApiVersionsRequest.ApiKey)
					.WithMinVersion(ApiVersionsRequest.MinVersion)
					.WithMaxVersion(ApiVersionsRequest.MaxVersion),
				key => key
					.WithIndex(ControlledShutdownRequest.ApiKey)
					.WithMinVersion(ControlledShutdownRequest.MinVersion)
					.WithMaxVersion(ControlledShutdownRequest.MaxVersion),
				key => key
					.WithIndex(CreateAclsRequest.ApiKey)
					.WithMinVersion(CreateAclsRequest.MinVersion)
					.WithMaxVersion(CreateAclsRequest.MaxVersion),
				key => key
					.WithIndex(CreateDelegationTokenRequest.ApiKey)
					.WithMinVersion(CreateDelegationTokenRequest.MinVersion)
					.WithMaxVersion(CreateDelegationTokenRequest.MaxVersion),
				key => key
					.WithIndex(CreatePartitionsRequest.ApiKey)
					.WithMinVersion(CreatePartitionsRequest.MinVersion)
					.WithMaxVersion(CreatePartitionsRequest.MaxVersion),
				key => key
					.WithIndex(CreateTopicsRequest.ApiKey)
					.WithMinVersion(CreateTopicsRequest.MinVersion)
					.WithMaxVersion(CreateTopicsRequest.MaxVersion),
				key => key
					.WithIndex(DeleteAclsRequest.ApiKey)
					.WithMinVersion(DeleteAclsRequest.MinVersion)
					.WithMaxVersion(DeleteAclsRequest.MaxVersion),
				key => key
					.WithIndex(DeleteGroupsRequest.ApiKey)
					.WithMinVersion(DeleteGroupsRequest.MinVersion)
					.WithMaxVersion(DeleteGroupsRequest.MaxVersion),
				key => key
					.WithIndex(DeleteRecordsRequest.ApiKey)
					.WithMinVersion(DeleteRecordsRequest.MinVersion)
					.WithMaxVersion(DeleteRecordsRequest.MaxVersion),
				key => key
					.WithIndex(DeleteTopicsRequest.ApiKey)
					.WithMinVersion(DeleteTopicsRequest.MinVersion)
					.WithMaxVersion(DeleteTopicsRequest.MaxVersion),
				key => key
					.WithIndex(DescribeAclsRequest.ApiKey)
					.WithMinVersion(DescribeAclsRequest.MinVersion)
					.WithMaxVersion(DescribeAclsRequest.MaxVersion),
				key => key
					.WithIndex(DescribeConfigsRequest.ApiKey)
					.WithMinVersion(DescribeConfigsRequest.MinVersion)
					.WithMaxVersion(DescribeConfigsRequest.MaxVersion),
				key => key
					.WithIndex(DescribeDelegationTokenRequest.ApiKey)
					.WithMinVersion(DescribeDelegationTokenRequest.MinVersion)
					.WithMaxVersion(DescribeDelegationTokenRequest.MaxVersion),
				key => key
					.WithIndex(DescribeGroupsRequest.ApiKey)
					.WithMinVersion(DescribeGroupsRequest.MinVersion)
					.WithMaxVersion(DescribeGroupsRequest.MaxVersion),
				key => key
					.WithIndex(DescribeLogDirsRequest.ApiKey)
					.WithMinVersion(DescribeLogDirsRequest.MinVersion)
					.WithMaxVersion(DescribeLogDirsRequest.MaxVersion),
				key => key
					.WithIndex(ElectLeadersRequest.ApiKey)
					.WithMinVersion(ElectLeadersRequest.MinVersion)
					.WithMaxVersion(ElectLeadersRequest.MaxVersion),
				key => key
					.WithIndex(EndTxnRequest.ApiKey)
					.WithMinVersion(EndTxnRequest.MinVersion)
					.WithMaxVersion(EndTxnRequest.MaxVersion),
				key => key
					.WithIndex(ExpireDelegationTokenRequest.ApiKey)
					.WithMinVersion(ExpireDelegationTokenRequest.MinVersion)
					.WithMaxVersion(ExpireDelegationTokenRequest.MaxVersion),
				key => key
					.WithIndex(FetchRequest.ApiKey)
					.WithMinVersion(FetchRequest.MinVersion)
					.WithMaxVersion(FetchRequest.MaxVersion),
				key => key
					.WithIndex(FindCoordinatorRequest.ApiKey)
					.WithMinVersion(FindCoordinatorRequest.MinVersion)
					.WithMaxVersion(FindCoordinatorRequest.MaxVersion),
				key => key
					.WithIndex(HeartbeatRequest.ApiKey)
					.WithMinVersion(HeartbeatRequest.MinVersion)
					.WithMaxVersion(HeartbeatRequest.MaxVersion),
				key => key
					.WithIndex(IncrementalAlterConfigsRequest.ApiKey)
					.WithMinVersion(IncrementalAlterConfigsRequest.MinVersion)
					.WithMaxVersion(IncrementalAlterConfigsRequest.MaxVersion),
				key => key
					.WithIndex(InitProducerIdRequest.ApiKey)
					.WithMinVersion(InitProducerIdRequest.MinVersion)
					.WithMaxVersion(InitProducerIdRequest.MaxVersion),
				key => key
					.WithIndex(JoinGroupRequest.ApiKey)
					.WithMinVersion(JoinGroupRequest.MinVersion)
					.WithMaxVersion(JoinGroupRequest.MaxVersion),
				key => key
					.WithIndex(LeaderAndIsrRequest.ApiKey)
					.WithMinVersion(LeaderAndIsrRequest.MinVersion)
					.WithMaxVersion(LeaderAndIsrRequest.MaxVersion),
				key => key
					.WithIndex(LeaveGroupRequest.ApiKey)
					.WithMinVersion(LeaveGroupRequest.MinVersion)
					.WithMaxVersion(LeaveGroupRequest.MaxVersion),
				key => key
					.WithIndex(ListGroupsRequest.ApiKey)
					.WithMinVersion(ListGroupsRequest.MinVersion)
					.WithMaxVersion(ListGroupsRequest.MaxVersion),
				key => key
					.WithIndex(ListOffsetRequest.ApiKey)
					.WithMinVersion(ListOffsetRequest.MinVersion)
					.WithMaxVersion(ListOffsetRequest.MaxVersion),
				key => key
					.WithIndex(MetadataRequest.ApiKey)
					.WithMinVersion(MetadataRequest.MinVersion)
					.WithMaxVersion(MetadataRequest.MaxVersion),
				key => key
					.WithIndex(OffsetCommitRequest.ApiKey)
					.WithMinVersion(OffsetCommitRequest.MinVersion)
					.WithMaxVersion(OffsetCommitRequest.MaxVersion),
				key => key
					.WithIndex(OffsetFetchRequest.ApiKey)
					.WithMinVersion(OffsetFetchRequest.MinVersion)
					.WithMaxVersion(OffsetFetchRequest.MaxVersion),
				key => key
					.WithIndex(OffsetForLeaderEpochRequest.ApiKey)
					.WithMinVersion(OffsetForLeaderEpochRequest.MinVersion)
					.WithMaxVersion(OffsetForLeaderEpochRequest.MaxVersion),
				key => key
					.WithIndex(ProduceRequest.ApiKey)
					.WithMinVersion(ProduceRequest.MinVersion)
					.WithMaxVersion(ProduceRequest.MaxVersion),
				key => key
					.WithIndex(RenewDelegationTokenRequest.ApiKey)
					.WithMinVersion(RenewDelegationTokenRequest.MinVersion)
					.WithMaxVersion(RenewDelegationTokenRequest.MaxVersion),
				key => key
					.WithIndex(SaslAuthenticateRequest.ApiKey)
					.WithMinVersion(SaslAuthenticateRequest.MinVersion)
					.WithMaxVersion(SaslAuthenticateRequest.MaxVersion),
				key => key
					.WithIndex(SaslHandshakeRequest.ApiKey)
					.WithMinVersion(SaslHandshakeRequest.MinVersion)
					.WithMaxVersion(SaslHandshakeRequest.MaxVersion),
				key => key
					.WithIndex(StopReplicaRequest.ApiKey)
					.WithMinVersion(StopReplicaRequest.MinVersion)
					.WithMaxVersion(StopReplicaRequest.MaxVersion),
				key => key
					.WithIndex(SyncGroupRequest.ApiKey)
					.WithMinVersion(SyncGroupRequest.MinVersion)
					.WithMaxVersion(SyncGroupRequest.MaxVersion),
				key => key
					.WithIndex(TxnOffsetCommitRequest.ApiKey)
					.WithMinVersion(TxnOffsetCommitRequest.MinVersion)
					.WithMaxVersion(TxnOffsetCommitRequest.MaxVersion),
				key => key
					.WithIndex(UpdateMetadataRequest.ApiKey)
					.WithMinVersion(UpdateMetadataRequest.MinVersion)
					.WithMaxVersion(UpdateMetadataRequest.MaxVersion),
				key => key
					.WithIndex(WriteTxnMarkersRequest.ApiKey)
					.WithMinVersion(WriteTxnMarkersRequest.MinVersion)
					.WithMaxVersion(WriteTxnMarkersRequest.MaxVersion));
		}
	}
}