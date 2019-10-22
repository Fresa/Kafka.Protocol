// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

		public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteBooleanAsync(this, cancellationToken);
		}

		public static Boolean From(bool value)
		{
			return new Boolean(value);
		}

		public static async ValueTask<Boolean> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadBooleanAsync(cancellationToken);
		}

		public static Boolean Default => From(default);
	}

	/// <summary>
	/// Represents an integer between -2^7 and 2^7-1 inclusive.
	/// </summary>
	public readonly struct Int8 : ISerialize 
	{
		public System.SByte Value { get; }

		public Int8(System.SByte value)
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

		public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteInt8Async(this, cancellationToken);
		}

		public static Int8 From(System.SByte value)
		{
			return new Int8(value);
		}

		public static async ValueTask<Int8> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadInt8Async(cancellationToken);
		}

		public static Int8 Default => From(default);
	}

	/// <summary>
	/// Represents an integer between -2^15 and 2^15-1 inclusive. The values are encoded using two bytes in network byte order (big-endian).
	/// </summary>
	public readonly struct Int16 : ISerialize 
	{
		public System.Int16 Value { get; }

		public Int16(System.Int16 value)
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

		public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteInt16Async(this, cancellationToken);
		}

		public static Int16 From(System.Int16 value)
		{
			return new Int16(value);
		}

		public static async ValueTask<Int16> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadInt16Async(cancellationToken);
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

		public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteInt32Async(this, cancellationToken);
		}

		public static Int32 From(int value)
		{
			return new Int32(value);
		}

		public static async ValueTask<Int32> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadInt32Async(cancellationToken);
		}

		public static Int32 Default => From(default);
	}

	/// <summary>
	/// Represents an integer between -2^63 and 2^63-1 inclusive. The values are encoded using eight bytes in network byte order (big-endian).
	/// </summary>
	public readonly struct Int64 : ISerialize 
	{
		public System.Int64 Value { get; }

		public Int64(System.Int64 value)
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

		public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteInt64Async(this, cancellationToken);
		}

		public static Int64 From(System.Int64 value)
		{
			return new Int64(value);
		}

		public static async ValueTask<Int64> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadInt64Async(cancellationToken);
		}

		public static Int64 Default => From(default);
	}

	/// <summary>
	/// Represents an integer between 0 and 2^32-1 inclusive. The values are encoded using four bytes in network byte order (big-endian).
	/// </summary>
	public readonly struct UInt32 : ISerialize 
	{
		public System.UInt32 Value { get; }

		public UInt32(System.UInt32 value)
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

		public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteUInt32Async(this, cancellationToken);
		}

		public static UInt32 From(System.UInt32 value)
		{
			return new UInt32(value);
		}

		public static async ValueTask<UInt32> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadUInt32Async(cancellationToken);
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

		public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteVarIntAsync(this, cancellationToken);
		}

		public static VarInt From(int value)
		{
			return new VarInt(value);
		}

		public static async ValueTask<VarInt> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadVarIntAsync(cancellationToken);
		}

		public static VarInt Default => From(default);
	}

	/// <summary>
	/// Represents an integer between -2^63 and 2^63-1 inclusive. Encoding follows the variable-length zig-zag encoding from  <a href="http://code.google.com/apis/protocolbuffers/docs/encoding.html"> Google Protocol Buffers</a>.
	/// </summary>
	public readonly struct VarLong : ISerialize 
	{
		public System.Int64 Value { get; }

		public VarLong(System.Int64 value)
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

		public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteVarLongAsync(this, cancellationToken);
		}

		public static VarLong From(System.Int64 value)
		{
			return new VarLong(value);
		}

		public static async ValueTask<VarLong> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadVarLongAsync(cancellationToken);
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

		public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteStringAsync(this, cancellationToken);
		}

		public static String From(string value)
		{
			return new String(value);
		}

		public static async ValueTask<String> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadStringAsync(cancellationToken);
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

		public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await writer.WriteBytesAsync(this, cancellationToken);
		}

		public static Bytes From(byte[] value)
		{
			return new Bytes(value);
		}

		public static async ValueTask<Bytes> FromReaderAsync(IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			return await reader.ReadBytesAsync(cancellationToken);
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
		public static async ValueTask<Message> CreateMessageFromReaderAsync(
			int apiKey, 
			int version, 
			IKafkaReader reader, 
			CancellationToken cancellationToken = default)
		{
			if (AddOffsetsToTxnRequest.ApiKey == apiKey)
			{
				return await AddOffsetsToTxnRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (AddOffsetsToTxnResponse.ApiKey == apiKey)
			{
				return await AddOffsetsToTxnResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (AddPartitionsToTxnRequest.ApiKey == apiKey)
			{
				return await AddPartitionsToTxnRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (AddPartitionsToTxnResponse.ApiKey == apiKey)
			{
				return await AddPartitionsToTxnResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (AlterConfigsRequest.ApiKey == apiKey)
			{
				return await AlterConfigsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (AlterConfigsResponse.ApiKey == apiKey)
			{
				return await AlterConfigsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (AlterReplicaLogDirsRequest.ApiKey == apiKey)
			{
				return await AlterReplicaLogDirsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (AlterReplicaLogDirsResponse.ApiKey == apiKey)
			{
				return await AlterReplicaLogDirsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ApiVersionsRequest.ApiKey == apiKey)
			{
				return await ApiVersionsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ApiVersionsResponse.ApiKey == apiKey)
			{
				return await ApiVersionsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ControlledShutdownRequest.ApiKey == apiKey)
			{
				return await ControlledShutdownRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ControlledShutdownResponse.ApiKey == apiKey)
			{
				return await ControlledShutdownResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (CreateAclsRequest.ApiKey == apiKey)
			{
				return await CreateAclsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (CreateAclsResponse.ApiKey == apiKey)
			{
				return await CreateAclsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (CreateDelegationTokenRequest.ApiKey == apiKey)
			{
				return await CreateDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (CreateDelegationTokenResponse.ApiKey == apiKey)
			{
				return await CreateDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (CreatePartitionsRequest.ApiKey == apiKey)
			{
				return await CreatePartitionsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (CreatePartitionsResponse.ApiKey == apiKey)
			{
				return await CreatePartitionsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (CreateTopicsRequest.ApiKey == apiKey)
			{
				return await CreateTopicsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (CreateTopicsResponse.ApiKey == apiKey)
			{
				return await CreateTopicsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DeleteAclsRequest.ApiKey == apiKey)
			{
				return await DeleteAclsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DeleteAclsResponse.ApiKey == apiKey)
			{
				return await DeleteAclsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DeleteGroupsRequest.ApiKey == apiKey)
			{
				return await DeleteGroupsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DeleteGroupsResponse.ApiKey == apiKey)
			{
				return await DeleteGroupsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DeleteRecordsRequest.ApiKey == apiKey)
			{
				return await DeleteRecordsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DeleteRecordsResponse.ApiKey == apiKey)
			{
				return await DeleteRecordsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DeleteTopicsRequest.ApiKey == apiKey)
			{
				return await DeleteTopicsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DeleteTopicsResponse.ApiKey == apiKey)
			{
				return await DeleteTopicsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DescribeAclsRequest.ApiKey == apiKey)
			{
				return await DescribeAclsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DescribeAclsResponse.ApiKey == apiKey)
			{
				return await DescribeAclsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DescribeConfigsRequest.ApiKey == apiKey)
			{
				return await DescribeConfigsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DescribeConfigsResponse.ApiKey == apiKey)
			{
				return await DescribeConfigsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DescribeDelegationTokenRequest.ApiKey == apiKey)
			{
				return await DescribeDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DescribeDelegationTokenResponse.ApiKey == apiKey)
			{
				return await DescribeDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DescribeGroupsRequest.ApiKey == apiKey)
			{
				return await DescribeGroupsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DescribeGroupsResponse.ApiKey == apiKey)
			{
				return await DescribeGroupsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DescribeLogDirsRequest.ApiKey == apiKey)
			{
				return await DescribeLogDirsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (DescribeLogDirsResponse.ApiKey == apiKey)
			{
				return await DescribeLogDirsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ElectLeadersRequest.ApiKey == apiKey)
			{
				return await ElectLeadersRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ElectLeadersResponse.ApiKey == apiKey)
			{
				return await ElectLeadersResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (EndTxnRequest.ApiKey == apiKey)
			{
				return await EndTxnRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (EndTxnResponse.ApiKey == apiKey)
			{
				return await EndTxnResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ExpireDelegationTokenRequest.ApiKey == apiKey)
			{
				return await ExpireDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ExpireDelegationTokenResponse.ApiKey == apiKey)
			{
				return await ExpireDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (FetchRequest.ApiKey == apiKey)
			{
				return await FetchRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (FetchResponse.ApiKey == apiKey)
			{
				return await FetchResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (FindCoordinatorRequest.ApiKey == apiKey)
			{
				return await FindCoordinatorRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (FindCoordinatorResponse.ApiKey == apiKey)
			{
				return await FindCoordinatorResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (HeartbeatRequest.ApiKey == apiKey)
			{
				return await HeartbeatRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (HeartbeatResponse.ApiKey == apiKey)
			{
				return await HeartbeatResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (IncrementalAlterConfigsRequest.ApiKey == apiKey)
			{
				return await IncrementalAlterConfigsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (IncrementalAlterConfigsResponse.ApiKey == apiKey)
			{
				return await IncrementalAlterConfigsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (InitProducerIdRequest.ApiKey == apiKey)
			{
				return await InitProducerIdRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (InitProducerIdResponse.ApiKey == apiKey)
			{
				return await InitProducerIdResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (JoinGroupRequest.ApiKey == apiKey)
			{
				return await JoinGroupRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (JoinGroupResponse.ApiKey == apiKey)
			{
				return await JoinGroupResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (LeaderAndIsrRequest.ApiKey == apiKey)
			{
				return await LeaderAndIsrRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (LeaderAndIsrResponse.ApiKey == apiKey)
			{
				return await LeaderAndIsrResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (LeaveGroupRequest.ApiKey == apiKey)
			{
				return await LeaveGroupRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (LeaveGroupResponse.ApiKey == apiKey)
			{
				return await LeaveGroupResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ListGroupsRequest.ApiKey == apiKey)
			{
				return await ListGroupsRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ListGroupsResponse.ApiKey == apiKey)
			{
				return await ListGroupsResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ListOffsetRequest.ApiKey == apiKey)
			{
				return await ListOffsetRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ListOffsetResponse.ApiKey == apiKey)
			{
				return await ListOffsetResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (MetadataRequest.ApiKey == apiKey)
			{
				return await MetadataRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (MetadataResponse.ApiKey == apiKey)
			{
				return await MetadataResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (OffsetCommitRequest.ApiKey == apiKey)
			{
				return await OffsetCommitRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (OffsetCommitResponse.ApiKey == apiKey)
			{
				return await OffsetCommitResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (OffsetFetchRequest.ApiKey == apiKey)
			{
				return await OffsetFetchRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (OffsetFetchResponse.ApiKey == apiKey)
			{
				return await OffsetFetchResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (OffsetForLeaderEpochRequest.ApiKey == apiKey)
			{
				return await OffsetForLeaderEpochRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (OffsetForLeaderEpochResponse.ApiKey == apiKey)
			{
				return await OffsetForLeaderEpochResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ProduceRequest.ApiKey == apiKey)
			{
				return await ProduceRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ProduceResponse.ApiKey == apiKey)
			{
				return await ProduceResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (RenewDelegationTokenRequest.ApiKey == apiKey)
			{
				return await RenewDelegationTokenRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (RenewDelegationTokenResponse.ApiKey == apiKey)
			{
				return await RenewDelegationTokenResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (RequestHeader.ApiKey == apiKey)
			{
				return await RequestHeader.FromReaderAsync(version, reader, cancellationToken);
			}

			if (ResponseHeader.ApiKey == apiKey)
			{
				return await ResponseHeader.FromReaderAsync(version, reader, cancellationToken);
			}

			if (SaslAuthenticateRequest.ApiKey == apiKey)
			{
				return await SaslAuthenticateRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (SaslAuthenticateResponse.ApiKey == apiKey)
			{
				return await SaslAuthenticateResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (SaslHandshakeRequest.ApiKey == apiKey)
			{
				return await SaslHandshakeRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (SaslHandshakeResponse.ApiKey == apiKey)
			{
				return await SaslHandshakeResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (StopReplicaRequest.ApiKey == apiKey)
			{
				return await StopReplicaRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (StopReplicaResponse.ApiKey == apiKey)
			{
				return await StopReplicaResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (SyncGroupRequest.ApiKey == apiKey)
			{
				return await SyncGroupRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (SyncGroupResponse.ApiKey == apiKey)
			{
				return await SyncGroupResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (TxnOffsetCommitRequest.ApiKey == apiKey)
			{
				return await TxnOffsetCommitRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (TxnOffsetCommitResponse.ApiKey == apiKey)
			{
				return await TxnOffsetCommitResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (UpdateMetadataRequest.ApiKey == apiKey)
			{
				return await UpdateMetadataRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (UpdateMetadataResponse.ApiKey == apiKey)
			{
				return await UpdateMetadataResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			if (WriteTxnMarkersRequest.ApiKey == apiKey)
			{
				return await WriteTxnMarkersRequest.FromReaderAsync(version, reader, cancellationToken);
			}

			if (WriteTxnMarkersResponse.ApiKey == apiKey)
			{
				return await WriteTxnMarkersResponse.FromReaderAsync(version, reader, cancellationToken);
			}

			throw new ArgumentException($"{apiKey} is not supported");
		}
	}

	public class AddOffsetsToTxnRequest : Message
	{
		public AddOffsetsToTxnRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"AddOffsetsToTxnRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 25;

		public override int Version { get; }

		public static async ValueTask<AddOffsetsToTxnRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AddOffsetsToTxnRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerId = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(TransactionalId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ProducerId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ProducerEpoch, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken);
			}
		}

		/// <summary>
		/// The transactional id corresponding to the transaction.
		/// </summary>
		private String _transactionalId = String.Default;
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

		public AddOffsetsToTxnRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		/// <summary>
		/// Current producer id in use by the transactional id.
		/// </summary>
		private Int64 _producerId = Int64.Default;
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

		public AddOffsetsToTxnRequest WithProducerId(Int64 producerId)
		{
			ProducerId = producerId;
			return this;
		}

		/// <summary>
		/// Current epoch associated with the producer id.
		/// </summary>
		private Int16 _producerEpoch = Int16.Default;
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

		public AddOffsetsToTxnRequest WithProducerEpoch(Int16 producerEpoch)
		{
			ProducerEpoch = producerEpoch;
			return this;
		}

		/// <summary>
		/// The unique group identifier.
		/// </summary>
		private String _groupId = String.Default;
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

		public AddOffsetsToTxnRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}
	}

	public class AddOffsetsToTxnResponse : Message
	{
		public AddOffsetsToTxnResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"AddOffsetsToTxnResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 25;

		public override int Version { get; }

		public static async ValueTask<AddOffsetsToTxnResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AddOffsetsToTxnResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public AddOffsetsToTxnResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The response error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public AddOffsetsToTxnResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class AddPartitionsToTxnRequest : Message
	{
		public AddPartitionsToTxnRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"AddPartitionsToTxnRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 24;

		public override int Version { get; }

		public static async ValueTask<AddPartitionsToTxnRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AddPartitionsToTxnRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerId = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = (await reader.ReadArrayAsync(async () => await AddPartitionsToTxnTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(TransactionalId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ProducerId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ProducerEpoch, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The transactional id corresponding to the transaction.
		/// </summary>
		private String _transactionalId = String.Default;
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

		public AddPartitionsToTxnRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		/// <summary>
		/// Current producer id in use by the transactional id.
		/// </summary>
		private Int64 _producerId = Int64.Default;
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

		public AddPartitionsToTxnRequest WithProducerId(Int64 producerId)
		{
			ProducerId = producerId;
			return this;
		}

		/// <summary>
		/// Current epoch associated with the producer id.
		/// </summary>
		private Int16 _producerEpoch = Int16.Default;
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

		public AddPartitionsToTxnRequest WithProducerEpoch(Int16 producerEpoch)
		{
			ProducerEpoch = producerEpoch;
			return this;
		}

		/// <summary>
		/// The partitions to add to the transation.
		/// </summary>
		private Dictionary<String, AddPartitionsToTxnTopic> _topicsCollection = new Dictionary<String, AddPartitionsToTxnTopic>();
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
			internal AddPartitionsToTxnTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<AddPartitionsToTxnTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AddPartitionsToTxnTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The name of the topic.
			/// </summary>
			private String _name = String.Default;
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

			public AddPartitionsToTxnTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The partition indexes to add to the transaction
			/// </summary>
			private Int32[] _partitionsCollection = Array.Empty<Int32>();
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

			public AddPartitionsToTxnTopic WithPartitionsCollection(Int32[] partitionsCollection)
			{
				PartitionsCollection = partitionsCollection;
				return this;
			}
		}
	}

	public class AddPartitionsToTxnResponse : Message
	{
		public AddPartitionsToTxnResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"AddPartitionsToTxnResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 24;

		public override int Version { get; }

		public static async ValueTask<AddPartitionsToTxnResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AddPartitionsToTxnResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = (await reader.ReadArrayAsync(async () => await AddPartitionsToTxnTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public AddPartitionsToTxnResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The results for each topic.
		/// </summary>
		private Dictionary<String, AddPartitionsToTxnTopicResult> _resultsCollection = new Dictionary<String, AddPartitionsToTxnTopicResult>();
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
			internal AddPartitionsToTxnTopicResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<AddPartitionsToTxnTopicResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AddPartitionsToTxnTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResultsCollection = (await reader.ReadArrayAsync(async () => await AddPartitionsToTxnPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.PartitionIndex);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ResultsCollection.Values.ToArray());
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public AddPartitionsToTxnTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The results for each partition
			/// </summary>
			private Dictionary<Int32, AddPartitionsToTxnPartitionResult> _resultsCollection = new Dictionary<Int32, AddPartitionsToTxnPartitionResult>();
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
				internal AddPartitionsToTxnPartitionResult(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<AddPartitionsToTxnPartitionResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AddPartitionsToTxnPartitionResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
				}

				/// <summary>
				/// The partition indexes.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public AddPartitionsToTxnPartitionResult WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The response error code.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public AddPartitionsToTxnPartitionResult WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}
	}

	public class AlterConfigsRequest : Message
	{
		public AlterConfigsRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"AlterConfigsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 33;

		public override int Version { get; }

		public static async ValueTask<AlterConfigsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AlterConfigsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourcesCollection = (await reader.ReadArrayAsync(async () => await AlterConfigsResource.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.ResourceType);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ValidateOnly = await reader.ReadBooleanAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResourcesCollection.Values.ToArray());
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBooleanAsync(ValidateOnly, cancellationToken);
			}
		}

		/// <summary>
		/// The updates for each resource.
		/// </summary>
		private Dictionary<Int8, AlterConfigsResource> _resourcesCollection = new Dictionary<Int8, AlterConfigsResource>();
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
			internal AlterConfigsResource(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<AlterConfigsResource> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterConfigsResource(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ConfigsCollection = (await reader.ReadArrayAsync(async () => await AlterableConfig.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ConfigsCollection.Values.ToArray());
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			private Int8 _resourceType = Int8.Default;
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

			public AlterConfigsResource WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			private String _resourceName = String.Default;
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

			public AlterConfigsResource WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}

			/// <summary>
			/// The configurations.
			/// </summary>
			private Dictionary<String, AlterableConfig> _configsCollection = new Dictionary<String, AlterableConfig>();
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
				internal AlterableConfig(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<AlterableConfig> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AlterableConfig(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Value = await reader.ReadNullableStringAsync(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(Value, cancellationToken);
					}
				}

				/// <summary>
				/// The configuration key name.
				/// </summary>
				private String _name = String.Default;
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

				public AlterableConfig WithName(String name)
				{
					Name = name;
					return this;
				}

				/// <summary>
				/// The value to set for the configuration key.
				/// </summary>
				private String? _value = String.Default;
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

				public AlterableConfig WithValue(String value)
				{
					Value = value;
					return this;
				}
			}
		}

		/// <summary>
		/// True if we should validate the request, but not change the configurations.
		/// </summary>
		private Boolean _validateOnly = Boolean.Default;
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

		public AlterConfigsRequest WithValidateOnly(Boolean validateOnly)
		{
			ValidateOnly = validateOnly;
			return this;
		}
	}

	public class AlterConfigsResponse : Message
	{
		public AlterConfigsResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"AlterConfigsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 33;

		public override int Version { get; }

		public static async ValueTask<AlterConfigsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AlterConfigsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResponsesCollection = await reader.ReadArrayAsync(async () => await AlterConfigsResourceResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResponsesCollection);
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public AlterConfigsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The responses for each resource.
		/// </summary>
		private AlterConfigsResourceResponse[] _responsesCollection = Array.Empty<AlterConfigsResourceResponse>();
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
			internal AlterConfigsResourceResponse(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<AlterConfigsResourceResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterConfigsResourceResponse(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken);
				}
			}

			/// <summary>
			/// The resource error code.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public AlterConfigsResourceResponse WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			/// <summary>
			/// The resource error message, or null if there was no error.
			/// </summary>
			private String? _errorMessage = String.Default;
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

			public AlterConfigsResourceResponse WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			private Int8 _resourceType = Int8.Default;
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

			public AlterConfigsResourceResponse WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			private String _resourceName = String.Default;
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

			public AlterConfigsResourceResponse WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}
		}
	}

	public class AlterReplicaLogDirsRequest : Message
	{
		public AlterReplicaLogDirsRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"AlterReplicaLogDirsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 34;

		public override int Version { get; }

		public static async ValueTask<AlterReplicaLogDirsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AlterReplicaLogDirsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.DirsCollection = (await reader.ReadArrayAsync(async () => await AlterReplicaLogDir.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Path);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, DirsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The alterations to make for each directory.
		/// </summary>
		private Dictionary<String, AlterReplicaLogDir> _dirsCollection = new Dictionary<String, AlterReplicaLogDir>();
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
			internal AlterReplicaLogDir(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<AlterReplicaLogDir> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterReplicaLogDir(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Path = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicsCollection = (await reader.ReadArrayAsync(async () => await AlterReplicaLogDirTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Path, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, TopicsCollection.Values.ToArray());
				}
			}

			/// <summary>
			/// The absolute directory path.
			/// </summary>
			private String _path = String.Default;
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

			public AlterReplicaLogDir WithPath(String path)
			{
				Path = path;
				return this;
			}

			/// <summary>
			/// The topics to add to the directory.
			/// </summary>
			private Dictionary<String, AlterReplicaLogDirTopic> _topicsCollection = new Dictionary<String, AlterReplicaLogDirTopic>();
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
				internal AlterReplicaLogDirTopic(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<AlterReplicaLogDirTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AlterReplicaLogDirTopic(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				private String _name = String.Default;
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

				public AlterReplicaLogDirTopic WithName(String name)
				{
					Name = name;
					return this;
				}

				/// <summary>
				/// The partition indexes.
				/// </summary>
				private Int32[] _partitionsCollection = Array.Empty<Int32>();
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

				public AlterReplicaLogDirTopic WithPartitionsCollection(Int32[] partitionsCollection)
				{
					PartitionsCollection = partitionsCollection;
					return this;
				}
			}
		}
	}

	public class AlterReplicaLogDirsResponse : Message
	{
		public AlterReplicaLogDirsResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"AlterReplicaLogDirsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 34;

		public override int Version { get; }

		public static async ValueTask<AlterReplicaLogDirsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new AlterReplicaLogDirsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = await reader.ReadArrayAsync(async () => await AlterReplicaLogDirTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection);
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public AlterReplicaLogDirsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The results for each topic.
		/// </summary>
		private AlterReplicaLogDirTopicResult[] _resultsCollection = Array.Empty<AlterReplicaLogDirTopicResult>();
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
			internal AlterReplicaLogDirTopicResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<AlterReplicaLogDirTopicResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterReplicaLogDirTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await AlterReplicaLogDirPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The name of the topic.
			/// </summary>
			private String _topicName = String.Default;
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

			public AlterReplicaLogDirTopicResult WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			/// <summary>
			/// The results for each partition.
			/// </summary>
			private AlterReplicaLogDirPartitionResult[] _partitionsCollection = Array.Empty<AlterReplicaLogDirPartitionResult>();
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
				internal AlterReplicaLogDirPartitionResult(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<AlterReplicaLogDirPartitionResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AlterReplicaLogDirPartitionResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public AlterReplicaLogDirPartitionResult WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public AlterReplicaLogDirPartitionResult WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}
	}

	public class ApiVersionsRequest : Message
	{
		public ApiVersionsRequest(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"ApiVersionsRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 18;

		public override int Version { get; }

		public static async ValueTask<ApiVersionsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ApiVersionsRequest(version);

			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await Task.CompletedTask;
		}
	}

	public class ApiVersionsResponse : Message
	{
		public ApiVersionsResponse(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"ApiVersionsResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 18;

		public override int Version { get; }

		public static async ValueTask<ApiVersionsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ApiVersionsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ApiKeysCollection = (await reader.ReadArrayAsync(async () => await ApiVersionsResponseKey.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Index);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ApiKeysCollection.Values.ToArray());
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
		}

		/// <summary>
		/// The top-level error code.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public ApiVersionsResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The APIs supported by the broker.
		/// </summary>
		private Dictionary<Int16, ApiVersionsResponseKey> _apiKeysCollection = new Dictionary<Int16, ApiVersionsResponseKey>();
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
			internal ApiVersionsResponseKey(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<ApiVersionsResponseKey> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ApiVersionsResponseKey(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Index = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MinVersion = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MaxVersion = await reader.ReadInt16Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(Index, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(MinVersion, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(MaxVersion, cancellationToken);
				}
			}

			/// <summary>
			/// The API index.
			/// </summary>
			private Int16 _index = Int16.Default;
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

			public ApiVersionsResponseKey WithIndex(Int16 index)
			{
				Index = index;
				return this;
			}

			/// <summary>
			/// The minimum supported version, inclusive.
			/// </summary>
			private Int16 _minVersion = Int16.Default;
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

			public ApiVersionsResponseKey WithMinVersion(Int16 minVersion)
			{
				MinVersion = minVersion;
				return this;
			}

			/// <summary>
			/// The maximum supported version, inclusive.
			/// </summary>
			private Int16 _maxVersion = Int16.Default;
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

			public ApiVersionsResponseKey WithMaxVersion(Int16 maxVersion)
			{
				MaxVersion = maxVersion;
				return this;
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public ApiVersionsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class ControlledShutdownRequest : Message
	{
		public ControlledShutdownRequest(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"ControlledShutdownRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 7;

		public override int Version { get; }

		public static async ValueTask<ControlledShutdownRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ControlledShutdownRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.BrokerId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.BrokerEpoch = await reader.ReadInt64Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(BrokerId, cancellationToken);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt64Async(BrokerEpoch, cancellationToken);
			}
		}

		/// <summary>
		/// The id of the broker for which controlled shutdown has been requested.
		/// </summary>
		private Int32 _brokerId = Int32.Default;
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

		public ControlledShutdownRequest WithBrokerId(Int32 brokerId)
		{
			BrokerId = brokerId;
			return this;
		}

		/// <summary>
		/// The broker epoch.
		/// </summary>
		private Int64 _brokerEpoch = new Int64(-1);
		public Int64 BrokerEpoch 
		{
			get => _brokerEpoch;
			set 
			{
				_brokerEpoch = value;
			}
		}

		public ControlledShutdownRequest WithBrokerEpoch(Int64 brokerEpoch)
		{
			BrokerEpoch = brokerEpoch;
			return this;
		}
	}

	public class ControlledShutdownResponse : Message
	{
		public ControlledShutdownResponse(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"ControlledShutdownResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 7;

		public override int Version { get; }

		public static async ValueTask<ControlledShutdownResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ControlledShutdownResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.RemainingPartitionsCollection = (await reader.ReadArrayAsync(async () => await RemainingPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.TopicName);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, RemainingPartitionsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The top-level error code.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public ControlledShutdownResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The partitions that the broker still leads.
		/// </summary>
		private Dictionary<String, RemainingPartition> _remainingPartitionsCollection = new Dictionary<String, RemainingPartition>();
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
			internal RemainingPartition(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<RemainingPartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new RemainingPartition(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken);
				}
			}

			/// <summary>
			/// The name of the topic.
			/// </summary>
			private String _topicName = String.Default;
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

			public RemainingPartition WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			/// <summary>
			/// The index of the partition.
			/// </summary>
			private Int32 _partitionIndex = Int32.Default;
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

			public RemainingPartition WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}
		}
	}

	public class CreateAclsRequest : Message
	{
		public CreateAclsRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"CreateAclsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 30;

		public override int Version { get; }

		public static async ValueTask<CreateAclsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateAclsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.CreationsCollection = await reader.ReadArrayAsync(async () => await CreatableAcl.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, CreationsCollection);
			}
		}

		/// <summary>
		/// The ACLs that we want to create.
		/// </summary>
		private CreatableAcl[] _creationsCollection = Array.Empty<CreatableAcl>();
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
			internal CreatableAcl(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<CreatableAcl> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatableAcl(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.ResourcePatternType = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Principal = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Host = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Operation = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PermissionType = await reader.ReadInt8Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourcePatternType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Principal, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Host, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(Operation, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(PermissionType, cancellationToken);
				}
			}

			/// <summary>
			/// The type of the resource.
			/// </summary>
			private Int8 _resourceType = Int8.Default;
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

			public CreatableAcl WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			/// <summary>
			/// The resource name for the ACL.
			/// </summary>
			private String _resourceName = String.Default;
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

			public CreatableAcl WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}

			/// <summary>
			/// The pattern type for the ACL.
			/// </summary>
			private Int8 _resourcePatternType = new Int8(3);
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

			public CreatableAcl WithResourcePatternType(Int8 resourcePatternType)
			{
				ResourcePatternType = resourcePatternType;
				return this;
			}

			/// <summary>
			/// The principal for the ACL.
			/// </summary>
			private String _principal = String.Default;
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

			public CreatableAcl WithPrincipal(String principal)
			{
				Principal = principal;
				return this;
			}

			/// <summary>
			/// The host for the ACL.
			/// </summary>
			private String _host = String.Default;
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

			public CreatableAcl WithHost(String host)
			{
				Host = host;
				return this;
			}

			/// <summary>
			/// The operation type for the ACL (read, write, etc.).
			/// </summary>
			private Int8 _operation = Int8.Default;
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

			public CreatableAcl WithOperation(Int8 operation)
			{
				Operation = operation;
				return this;
			}

			/// <summary>
			/// The permission type for the ACL (allow, deny, etc.).
			/// </summary>
			private Int8 _permissionType = Int8.Default;
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

			public CreatableAcl WithPermissionType(Int8 permissionType)
			{
				PermissionType = permissionType;
				return this;
			}
		}
	}

	public class CreateAclsResponse : Message
	{
		public CreateAclsResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"CreateAclsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 30;

		public override int Version { get; }

		public static async ValueTask<CreateAclsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateAclsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = await reader.ReadArrayAsync(async () => await CreatableAclResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public CreateAclsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The results for each ACL creation.
		/// </summary>
		private CreatableAclResult[] _resultsCollection = Array.Empty<CreatableAclResult>();
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
			internal CreatableAclResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<CreatableAclResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatableAclResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
				}
			}

			/// <summary>
			/// The result error, or zero if there was no error.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public CreatableAclResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			/// <summary>
			/// The result message, or null if there was no error.
			/// </summary>
			private String? _errorMessage = String.Default;
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

			public CreatableAclResult WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}
		}
	}

	public class CreateDelegationTokenRequest : Message
	{
		public CreateDelegationTokenRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"CreateDelegationTokenRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 38;

		public override int Version { get; }

		public static async ValueTask<CreateDelegationTokenRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateDelegationTokenRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.RenewersCollection = await reader.ReadArrayAsync(async () => await CreatableRenewers.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MaxLifetimeMs = await reader.ReadInt64Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, RenewersCollection);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(MaxLifetimeMs, cancellationToken);
			}
		}

		/// <summary>
		/// A list of those who are allowed to renew this token before it expires.
		/// </summary>
		private CreatableRenewers[] _renewersCollection = Array.Empty<CreatableRenewers>();
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
			internal CreatableRenewers(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<CreatableRenewers> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatableRenewers(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalType = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalName = await reader.ReadStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalName, cancellationToken);
				}
			}

			/// <summary>
			/// The type of the Kafka principal.
			/// </summary>
			private String _principalType = String.Default;
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

			public CreatableRenewers WithPrincipalType(String principalType)
			{
				PrincipalType = principalType;
				return this;
			}

			/// <summary>
			/// The name of the Kafka principal.
			/// </summary>
			private String _principalName = String.Default;
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

			public CreatableRenewers WithPrincipalName(String principalName)
			{
				PrincipalName = principalName;
				return this;
			}
		}

		/// <summary>
		/// The maximum lifetime of the token in milliseconds, or -1 to use the server side default.
		/// </summary>
		private Int64 _maxLifetimeMs = Int64.Default;
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

		public CreateDelegationTokenRequest WithMaxLifetimeMs(Int64 maxLifetimeMs)
		{
			MaxLifetimeMs = maxLifetimeMs;
			return this;
		}
	}

	public class CreateDelegationTokenResponse : Message
	{
		public CreateDelegationTokenResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"CreateDelegationTokenResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 38;

		public override int Version { get; }

		public static async ValueTask<CreateDelegationTokenResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateDelegationTokenResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PrincipalType = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PrincipalName = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.IssueTimestampMs = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ExpiryTimestampMs = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MaxTimestampMs = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TokenId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Hmac = await reader.ReadBytesAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(PrincipalType, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(PrincipalName, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(IssueTimestampMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ExpiryTimestampMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(MaxTimestampMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(TokenId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(Hmac, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
		}

		/// <summary>
		/// The top-level error, or zero if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public CreateDelegationTokenResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The principal type of the token owner.
		/// </summary>
		private String _principalType = String.Default;
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

		public CreateDelegationTokenResponse WithPrincipalType(String principalType)
		{
			PrincipalType = principalType;
			return this;
		}

		/// <summary>
		/// The name of the token owner.
		/// </summary>
		private String _principalName = String.Default;
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

		public CreateDelegationTokenResponse WithPrincipalName(String principalName)
		{
			PrincipalName = principalName;
			return this;
		}

		/// <summary>
		/// When this token was generated.
		/// </summary>
		private Int64 _issueTimestampMs = Int64.Default;
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

		public CreateDelegationTokenResponse WithIssueTimestampMs(Int64 issueTimestampMs)
		{
			IssueTimestampMs = issueTimestampMs;
			return this;
		}

		/// <summary>
		/// When this token expires.
		/// </summary>
		private Int64 _expiryTimestampMs = Int64.Default;
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

		public CreateDelegationTokenResponse WithExpiryTimestampMs(Int64 expiryTimestampMs)
		{
			ExpiryTimestampMs = expiryTimestampMs;
			return this;
		}

		/// <summary>
		/// The maximum lifetime of this token.
		/// </summary>
		private Int64 _maxTimestampMs = Int64.Default;
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

		public CreateDelegationTokenResponse WithMaxTimestampMs(Int64 maxTimestampMs)
		{
			MaxTimestampMs = maxTimestampMs;
			return this;
		}

		/// <summary>
		/// The token UUID.
		/// </summary>
		private String _tokenId = String.Default;
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

		public CreateDelegationTokenResponse WithTokenId(String tokenId)
		{
			TokenId = tokenId;
			return this;
		}

		/// <summary>
		/// HMAC of the delegation token.
		/// </summary>
		private Bytes _hmac = Bytes.Default;
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

		public CreateDelegationTokenResponse WithHmac(Bytes hmac)
		{
			Hmac = hmac;
			return this;
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public CreateDelegationTokenResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class CreatePartitionsRequest : Message
	{
		public CreatePartitionsRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"CreatePartitionsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 37;

		public override int Version { get; }

		public static async ValueTask<CreatePartitionsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreatePartitionsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await CreatePartitionsTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ValidateOnly = await reader.ReadBooleanAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBooleanAsync(ValidateOnly, cancellationToken);
			}
		}

		/// <summary>
		/// Each topic that we want to create new partitions inside.
		/// </summary>
		private CreatePartitionsTopic[] _topicsCollection = Array.Empty<CreatePartitionsTopic>();
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
			internal CreatePartitionsTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<CreatePartitionsTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatePartitionsTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Count = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.AssignmentsCollection = await reader.ReadNullableArrayAsync(async () => await CreatePartitionsAssignment.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(Count, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableArrayAsync(cancellationToken, AssignmentsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public CreatePartitionsTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The new partition count.
			/// </summary>
			private Int32 _count = Int32.Default;
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

			public CreatePartitionsTopic WithCount(Int32 count)
			{
				Count = count;
				return this;
			}

			/// <summary>
			/// The new partition assignments.
			/// </summary>
			private CreatePartitionsAssignment[]? _assignmentsCollection = Array.Empty<CreatePartitionsAssignment>();
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
				internal CreatePartitionsAssignment(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<CreatePartitionsAssignment> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new CreatePartitionsAssignment(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.BrokerIdsCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, BrokerIdsCollection);
					}
				}

				/// <summary>
				/// The assigned broker IDs.
				/// </summary>
				private Int32[] _brokerIdsCollection = Array.Empty<Int32>();
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

				public CreatePartitionsAssignment WithBrokerIdsCollection(Int32[] brokerIdsCollection)
				{
					BrokerIdsCollection = brokerIdsCollection;
					return this;
				}
			}
		}

		/// <summary>
		/// The time in ms to wait for the partitions to be created.
		/// </summary>
		private Int32 _timeoutMs = Int32.Default;
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

		public CreatePartitionsRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}

		/// <summary>
		/// If true, then validate the request, but don't actually increase the number of partitions.
		/// </summary>
		private Boolean _validateOnly = Boolean.Default;
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

		public CreatePartitionsRequest WithValidateOnly(Boolean validateOnly)
		{
			ValidateOnly = validateOnly;
			return this;
		}
	}

	public class CreatePartitionsResponse : Message
	{
		public CreatePartitionsResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"CreatePartitionsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 37;

		public override int Version { get; }

		public static async ValueTask<CreatePartitionsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreatePartitionsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = await reader.ReadArrayAsync(async () => await CreatePartitionsTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public CreatePartitionsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The partition creation results for each topic.
		/// </summary>
		private CreatePartitionsTopicResult[] _resultsCollection = Array.Empty<CreatePartitionsTopicResult>();
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
			internal CreatePartitionsTopicResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<CreatePartitionsTopicResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatePartitionsTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public CreatePartitionsTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The result error, or zero if there was no error.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public CreatePartitionsTopicResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			/// <summary>
			/// The result message, or null if there was no error.
			/// </summary>
			private String? _errorMessage = String.Default;
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

			public CreatePartitionsTopicResult WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}
		}
	}

	public class CreateTopicsRequest : Message
	{
		public CreateTopicsRequest(int version)
		{
			if (version.InRange(0, 4) == false) 
			{
				throw new UnsupportedVersionException($"CreateTopicsRequest does not support version {version}. Valid versions are: 0-4");
			}

			Version = version;
		}

		public const int ApiKey = 19;

		public override int Version { get; }

		public static async ValueTask<CreateTopicsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateTopicsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = (await reader.ReadArrayAsync(async () => await CreatableTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ValidateOnly = await reader.ReadBooleanAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection.Values.ToArray());
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteBooleanAsync(ValidateOnly, cancellationToken);
			}
		}

		/// <summary>
		/// The topics to create.
		/// </summary>
		private Dictionary<String, CreatableTopic> _topicsCollection = new Dictionary<String, CreatableTopic>();
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
			internal CreatableTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<CreatableTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatableTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.NumPartitions = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ReplicationFactor = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.AssignmentsCollection = (await reader.ReadArrayAsync(async () => await CreatableReplicaAssignment.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.PartitionIndex);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ConfigsCollection = (await reader.ReadArrayAsync(async () => await CreateableTopicConfig.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(NumPartitions, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ReplicationFactor, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, AssignmentsCollection.Values.ToArray());
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ConfigsCollection.Values.ToArray());
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public CreatableTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The number of partitions to create in the topic, or -1 if we are either specifying a manual partition assignment or using the default partitions.
			/// </summary>
			private Int32 _numPartitions = Int32.Default;
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

			public CreatableTopic WithNumPartitions(Int32 numPartitions)
			{
				NumPartitions = numPartitions;
				return this;
			}

			/// <summary>
			/// The number of replicas to create for each partition in the topic, or -1 if we are either specifying a manual partition assignment or using the default replication factor.
			/// </summary>
			private Int16 _replicationFactor = Int16.Default;
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

			public CreatableTopic WithReplicationFactor(Int16 replicationFactor)
			{
				ReplicationFactor = replicationFactor;
				return this;
			}

			/// <summary>
			/// The manual partition assignment, or the empty array if we are using automatic assignment.
			/// </summary>
			private Dictionary<Int32, CreatableReplicaAssignment> _assignmentsCollection = new Dictionary<Int32, CreatableReplicaAssignment>();
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
				internal CreatableReplicaAssignment(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<CreatableReplicaAssignment> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new CreatableReplicaAssignment(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.BrokerIdsCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, BrokerIdsCollection);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public CreatableReplicaAssignment WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The brokers to place the partition on.
				/// </summary>
				private Int32[] _brokerIdsCollection = Array.Empty<Int32>();
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

				public CreatableReplicaAssignment WithBrokerIdsCollection(Int32[] brokerIdsCollection)
				{
					BrokerIdsCollection = brokerIdsCollection;
					return this;
				}
			}

			/// <summary>
			/// The custom topic configurations to set.
			/// </summary>
			private Dictionary<String, CreateableTopicConfig> _configsCollection = new Dictionary<String, CreateableTopicConfig>();
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
				internal CreateableTopicConfig(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<CreateableTopicConfig> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new CreateableTopicConfig(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Value = await reader.ReadNullableStringAsync(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(Value, cancellationToken);
					}
				}

				/// <summary>
				/// The configuration name.
				/// </summary>
				private String _name = String.Default;
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

				public CreateableTopicConfig WithName(String name)
				{
					Name = name;
					return this;
				}

				/// <summary>
				/// The configuration value.
				/// </summary>
				private String? _value = String.Default;
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

				public CreateableTopicConfig WithValue(String value)
				{
					Value = value;
					return this;
				}
			}
		}

		/// <summary>
		/// How long to wait in milliseconds before timing out the request.
		/// </summary>
		private Int32 _timeoutMs = new Int32(60000);
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

		public CreateTopicsRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}

		/// <summary>
		/// If true, check that the topics can be created as specified, but don't create anything.
		/// </summary>
		private Boolean _validateOnly = new Boolean(false);
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

		public CreateTopicsRequest WithValidateOnly(Boolean validateOnly)
		{
			ValidateOnly = validateOnly;
			return this;
		}
	}

	public class CreateTopicsResponse : Message
	{
		public CreateTopicsResponse(int version)
		{
			if (version.InRange(0, 4) == false) 
			{
				throw new UnsupportedVersionException($"CreateTopicsResponse does not support version {version}. Valid versions are: 0-4");
			}

			Version = version;
		}

		public const int ApiKey = 19;

		public override int Version { get; }

		public static async ValueTask<CreateTopicsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new CreateTopicsResponse(version);
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = (await reader.ReadArrayAsync(async () => await CreatableTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public CreateTopicsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// Results for each topic we tried to create.
		/// </summary>
		private Dictionary<String, CreatableTopicResult> _topicsCollection = new Dictionary<String, CreatableTopicResult>();
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
			internal CreatableTopicResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<CreatableTopicResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new CreatableTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public CreatableTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The error code, or 0 if there was no error.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public CreatableTopicResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			/// <summary>
			/// The error message, or null if there was no error.
			/// </summary>
			private String? _errorMessage = String.Default;
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

			public CreatableTopicResult WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}
		}
	}

	public class DeleteAclsRequest : Message
	{
		public DeleteAclsRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DeleteAclsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 31;

		public override int Version { get; }

		public static async ValueTask<DeleteAclsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteAclsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.FiltersCollection = await reader.ReadArrayAsync(async () => await DeleteAclsFilter.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, FiltersCollection);
			}
		}

		/// <summary>
		/// The filters to use when deleting ACLs.
		/// </summary>
		private DeleteAclsFilter[] _filtersCollection = Array.Empty<DeleteAclsFilter>();
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
			internal DeleteAclsFilter(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DeleteAclsFilter> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeleteAclsFilter(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceTypeFilter = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceNameFilter = await reader.ReadNullableStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.PatternTypeFilter = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalFilter = await reader.ReadNullableStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.HostFilter = await reader.ReadNullableStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Operation = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PermissionType = await reader.ReadInt8Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceTypeFilter, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ResourceNameFilter, cancellationToken);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteInt8Async(PatternTypeFilter, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(PrincipalFilter, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(HostFilter, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(Operation, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(PermissionType, cancellationToken);
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			private Int8 _resourceTypeFilter = Int8.Default;
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

			public DeleteAclsFilter WithResourceTypeFilter(Int8 resourceTypeFilter)
			{
				ResourceTypeFilter = resourceTypeFilter;
				return this;
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			private String? _resourceNameFilter = String.Default;
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

			public DeleteAclsFilter WithResourceNameFilter(String resourceNameFilter)
			{
				ResourceNameFilter = resourceNameFilter;
				return this;
			}

			/// <summary>
			/// The pattern type.
			/// </summary>
			private Int8 _patternTypeFilter = new Int8(3);
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

			public DeleteAclsFilter WithPatternTypeFilter(Int8 patternTypeFilter)
			{
				PatternTypeFilter = patternTypeFilter;
				return this;
			}

			/// <summary>
			/// The principal filter, or null to accept all principals.
			/// </summary>
			private String? _principalFilter = String.Default;
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

			public DeleteAclsFilter WithPrincipalFilter(String principalFilter)
			{
				PrincipalFilter = principalFilter;
				return this;
			}

			/// <summary>
			/// The host filter, or null to accept all hosts.
			/// </summary>
			private String? _hostFilter = String.Default;
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

			public DeleteAclsFilter WithHostFilter(String hostFilter)
			{
				HostFilter = hostFilter;
				return this;
			}

			/// <summary>
			/// The ACL operation.
			/// </summary>
			private Int8 _operation = Int8.Default;
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

			public DeleteAclsFilter WithOperation(Int8 operation)
			{
				Operation = operation;
				return this;
			}

			/// <summary>
			/// The permission type.
			/// </summary>
			private Int8 _permissionType = Int8.Default;
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

			public DeleteAclsFilter WithPermissionType(Int8 permissionType)
			{
				PermissionType = permissionType;
				return this;
			}
		}
	}

	public class DeleteAclsResponse : Message
	{
		public DeleteAclsResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DeleteAclsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 31;

		public override int Version { get; }

		public static async ValueTask<DeleteAclsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteAclsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.FilterResultsCollection = await reader.ReadArrayAsync(async () => await DeleteAclsFilterResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, FilterResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public DeleteAclsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The results for each filter.
		/// </summary>
		private DeleteAclsFilterResult[] _filterResultsCollection = Array.Empty<DeleteAclsFilterResult>();
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
			internal DeleteAclsFilterResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DeleteAclsFilterResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeleteAclsFilterResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MatchingAclsCollection = await reader.ReadArrayAsync(async () => await DeleteAclsMatchingAcl.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, MatchingAclsCollection);
				}
			}

			/// <summary>
			/// The error code, or 0 if the filter succeeded.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public DeleteAclsFilterResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			/// <summary>
			/// The error message, or null if the filter succeeded.
			/// </summary>
			private String? _errorMessage = String.Default;
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

			public DeleteAclsFilterResult WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}

			/// <summary>
			/// The ACLs which matched this filter.
			/// </summary>
			private DeleteAclsMatchingAcl[] _matchingAclsCollection = Array.Empty<DeleteAclsMatchingAcl>();
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
				internal DeleteAclsMatchingAcl(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<DeleteAclsMatchingAcl> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DeleteAclsMatchingAcl(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ResourceType = await reader.ReadInt8Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ResourceName = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.PatternType = await reader.ReadInt8Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Principal = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Host = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Operation = await reader.ReadInt8Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PermissionType = await reader.ReadInt8Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(ResourceType, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(ResourceName, cancellationToken);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt8Async(PatternType, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Principal, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Host, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(Operation, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(PermissionType, cancellationToken);
					}
				}

				/// <summary>
				/// The deletion error code, or 0 if the deletion succeeded.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public DeleteAclsMatchingAcl WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				/// <summary>
				/// The deletion error message, or null if the deletion succeeded.
				/// </summary>
				private String? _errorMessage = String.Default;
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

				public DeleteAclsMatchingAcl WithErrorMessage(String errorMessage)
				{
					ErrorMessage = errorMessage;
					return this;
				}

				/// <summary>
				/// The ACL resource type.
				/// </summary>
				private Int8 _resourceType = Int8.Default;
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

				public DeleteAclsMatchingAcl WithResourceType(Int8 resourceType)
				{
					ResourceType = resourceType;
					return this;
				}

				/// <summary>
				/// The ACL resource name.
				/// </summary>
				private String _resourceName = String.Default;
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

				public DeleteAclsMatchingAcl WithResourceName(String resourceName)
				{
					ResourceName = resourceName;
					return this;
				}

				/// <summary>
				/// The ACL resource pattern type.
				/// </summary>
				private Int8 _patternType = new Int8(3);
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

				public DeleteAclsMatchingAcl WithPatternType(Int8 patternType)
				{
					PatternType = patternType;
					return this;
				}

				/// <summary>
				/// The ACL principal.
				/// </summary>
				private String _principal = String.Default;
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

				public DeleteAclsMatchingAcl WithPrincipal(String principal)
				{
					Principal = principal;
					return this;
				}

				/// <summary>
				/// The ACL host.
				/// </summary>
				private String _host = String.Default;
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

				public DeleteAclsMatchingAcl WithHost(String host)
				{
					Host = host;
					return this;
				}

				/// <summary>
				/// The ACL operation.
				/// </summary>
				private Int8 _operation = Int8.Default;
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

				public DeleteAclsMatchingAcl WithOperation(Int8 operation)
				{
					Operation = operation;
					return this;
				}

				/// <summary>
				/// The ACL permission type.
				/// </summary>
				private Int8 _permissionType = Int8.Default;
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

				public DeleteAclsMatchingAcl WithPermissionType(Int8 permissionType)
				{
					PermissionType = permissionType;
					return this;
				}
			}
		}
	}

	public class DeleteGroupsRequest : Message
	{
		public DeleteGroupsRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DeleteGroupsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 42;

		public override int Version { get; }

		public static async ValueTask<DeleteGroupsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteGroupsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupsNamesCollection = await reader.ReadArrayAsync(async () => await String.FromReaderAsync(reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, GroupsNamesCollection);
			}
		}

		/// <summary>
		/// The group names to delete.
		/// </summary>
		private String[] _groupsNamesCollection = Array.Empty<String>();
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

		public DeleteGroupsRequest WithGroupsNamesCollection(String[] groupsNamesCollection)
		{
			GroupsNamesCollection = groupsNamesCollection;
			return this;
		}
	}

	public class DeleteGroupsResponse : Message
	{
		public DeleteGroupsResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DeleteGroupsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 42;

		public override int Version { get; }

		public static async ValueTask<DeleteGroupsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteGroupsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = (await reader.ReadArrayAsync(async () => await DeletableGroupResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.GroupId);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public DeleteGroupsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The deletion results
		/// </summary>
		private Dictionary<String, DeletableGroupResult> _resultsCollection = new Dictionary<String, DeletableGroupResult>();
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
			internal DeletableGroupResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DeletableGroupResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeletableGroupResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.GroupId = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(GroupId, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
			}

			/// <summary>
			/// The group id
			/// </summary>
			private String _groupId = String.Default;
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

			public DeletableGroupResult WithGroupId(String groupId)
			{
				GroupId = groupId;
				return this;
			}

			/// <summary>
			/// The deletion error, or 0 if the deletion succeeded.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public DeletableGroupResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}
		}
	}

	public class DeleteRecordsRequest : Message
	{
		public DeleteRecordsRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DeleteRecordsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 21;

		public override int Version { get; }

		public static async ValueTask<DeleteRecordsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteRecordsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await DeleteRecordsTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken);
			}
		}

		/// <summary>
		/// Each topic that we want to delete records from.
		/// </summary>
		private DeleteRecordsTopic[] _topicsCollection = Array.Empty<DeleteRecordsTopic>();
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
			internal DeleteRecordsTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DeleteRecordsTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeleteRecordsTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await DeleteRecordsPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public DeleteRecordsTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// Each partition that we want to delete records from.
			/// </summary>
			private DeleteRecordsPartition[] _partitionsCollection = Array.Empty<DeleteRecordsPartition>();
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
				internal DeleteRecordsPartition(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<DeleteRecordsPartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DeleteRecordsPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Offset = await reader.ReadInt64Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(Offset, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public DeleteRecordsPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The deletion offset.
				/// </summary>
				private Int64 _offset = Int64.Default;
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

				public DeleteRecordsPartition WithOffset(Int64 offset)
				{
					Offset = offset;
					return this;
				}
			}
		}

		/// <summary>
		/// How long to wait for the deletion to complete, in milliseconds.
		/// </summary>
		private Int32 _timeoutMs = Int32.Default;
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

		public DeleteRecordsRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}
	}

	public class DeleteRecordsResponse : Message
	{
		public DeleteRecordsResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DeleteRecordsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 21;

		public override int Version { get; }

		public static async ValueTask<DeleteRecordsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteRecordsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await DeleteRecordsTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public DeleteRecordsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// Each topic that we wanted to delete records from.
		/// </summary>
		private DeleteRecordsTopicResult[] _topicsCollection = Array.Empty<DeleteRecordsTopicResult>();
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
			internal DeleteRecordsTopicResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DeleteRecordsTopicResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeleteRecordsTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await DeleteRecordsPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public DeleteRecordsTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// Each partition that we wanted to delete records from.
			/// </summary>
			private DeleteRecordsPartitionResult[] _partitionsCollection = Array.Empty<DeleteRecordsPartitionResult>();
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
				internal DeleteRecordsPartitionResult(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<DeleteRecordsPartitionResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DeleteRecordsPartitionResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.LowWatermark = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(LowWatermark, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public DeleteRecordsPartitionResult WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The partition low water mark.
				/// </summary>
				private Int64 _lowWatermark = Int64.Default;
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

				public DeleteRecordsPartitionResult WithLowWatermark(Int64 lowWatermark)
				{
					LowWatermark = lowWatermark;
					return this;
				}

				/// <summary>
				/// The deletion error code, or 0 if the deletion succeeded.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public DeleteRecordsPartitionResult WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}
	}

	public class DeleteTopicsRequest : Message
	{
		public DeleteTopicsRequest(int version)
		{
			if (version.InRange(0, 3) == false) 
			{
				throw new UnsupportedVersionException($"DeleteTopicsRequest does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public const int ApiKey = 20;

		public override int Version { get; }

		public static async ValueTask<DeleteTopicsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteTopicsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicNamesCollection = await reader.ReadArrayAsync(async () => await String.FromReaderAsync(reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicNamesCollection);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken);
			}
		}

		/// <summary>
		/// The names of the topics to delete
		/// </summary>
		private String[] _topicNamesCollection = Array.Empty<String>();
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

		public DeleteTopicsRequest WithTopicNamesCollection(String[] topicNamesCollection)
		{
			TopicNamesCollection = topicNamesCollection;
			return this;
		}

		/// <summary>
		/// The length of time in milliseconds to wait for the deletions to complete.
		/// </summary>
		private Int32 _timeoutMs = Int32.Default;
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

		public DeleteTopicsRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}
	}

	public class DeleteTopicsResponse : Message
	{
		public DeleteTopicsResponse(int version)
		{
			if (version.InRange(0, 3) == false) 
			{
				throw new UnsupportedVersionException($"DeleteTopicsResponse does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public const int ApiKey = 20;

		public override int Version { get; }

		public static async ValueTask<DeleteTopicsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DeleteTopicsResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResponsesCollection = (await reader.ReadArrayAsync(async () => await DeletableTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResponsesCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public DeleteTopicsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The results for each topic we tried to delete.
		/// </summary>
		private Dictionary<String, DeletableTopicResult> _responsesCollection = new Dictionary<String, DeletableTopicResult>();
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
			internal DeletableTopicResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DeletableTopicResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DeletableTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			private String _name = String.Default;
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

			public DeletableTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The deletion error, or 0 if the deletion succeeded.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public DeletableTopicResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}
		}
	}

	public class DescribeAclsRequest : Message
	{
		public DescribeAclsRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DescribeAclsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 29;

		public override int Version { get; }

		public static async ValueTask<DescribeAclsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeAclsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourceType = await reader.ReadInt8Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourceNameFilter = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ResourcePatternType = await reader.ReadInt8Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PrincipalFilter = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.HostFilter = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Operation = await reader.ReadInt8Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PermissionType = await reader.ReadInt8Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt8Async(ResourceType, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(ResourceNameFilter, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt8Async(ResourcePatternType, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(PrincipalFilter, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(HostFilter, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt8Async(Operation, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt8Async(PermissionType, cancellationToken);
			}
		}

		/// <summary>
		/// The resource type.
		/// </summary>
		private Int8 _resourceType = Int8.Default;
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

		public DescribeAclsRequest WithResourceType(Int8 resourceType)
		{
			ResourceType = resourceType;
			return this;
		}

		/// <summary>
		/// The resource name, or null to match any resource name.
		/// </summary>
		private String? _resourceNameFilter = String.Default;
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

		public DescribeAclsRequest WithResourceNameFilter(String resourceNameFilter)
		{
			ResourceNameFilter = resourceNameFilter;
			return this;
		}

		/// <summary>
		/// The resource pattern to match.
		/// </summary>
		private Int8 _resourcePatternType = new Int8(3);
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

		public DescribeAclsRequest WithResourcePatternType(Int8 resourcePatternType)
		{
			ResourcePatternType = resourcePatternType;
			return this;
		}

		/// <summary>
		/// The principal to match, or null to match any principal.
		/// </summary>
		private String? _principalFilter = String.Default;
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

		public DescribeAclsRequest WithPrincipalFilter(String principalFilter)
		{
			PrincipalFilter = principalFilter;
			return this;
		}

		/// <summary>
		/// The host to match, or null to match any host.
		/// </summary>
		private String? _hostFilter = String.Default;
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

		public DescribeAclsRequest WithHostFilter(String hostFilter)
		{
			HostFilter = hostFilter;
			return this;
		}

		/// <summary>
		/// The operation to match.
		/// </summary>
		private Int8 _operation = Int8.Default;
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

		public DescribeAclsRequest WithOperation(Int8 operation)
		{
			Operation = operation;
			return this;
		}

		/// <summary>
		/// The permission type to match.
		/// </summary>
		private Int8 _permissionType = Int8.Default;
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

		public DescribeAclsRequest WithPermissionType(Int8 permissionType)
		{
			PermissionType = permissionType;
			return this;
		}
	}

	public class DescribeAclsResponse : Message
	{
		public DescribeAclsResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DescribeAclsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 29;

		public override int Version { get; }

		public static async ValueTask<DescribeAclsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeAclsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourcesCollection = await reader.ReadArrayAsync(async () => await DescribeAclsResource.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResourcesCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public DescribeAclsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public DescribeAclsResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		private String? _errorMessage = String.Default;
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

		public DescribeAclsResponse WithErrorMessage(String errorMessage)
		{
			ErrorMessage = errorMessage;
			return this;
		}

		/// <summary>
		/// Each Resource that is referenced in an ACL.
		/// </summary>
		private DescribeAclsResource[] _resourcesCollection = Array.Empty<DescribeAclsResource>();
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
			internal DescribeAclsResource(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DescribeAclsResource> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribeAclsResource(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Type = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.PatternType = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.AclsCollection = await reader.ReadArrayAsync(async () => await AclDescription.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(Type, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteInt8Async(PatternType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, AclsCollection);
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			private Int8 _type = Int8.Default;
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

			public DescribeAclsResource WithType(Int8 type)
			{
				Type = type;
				return this;
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			private String _name = String.Default;
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

			public DescribeAclsResource WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The resource pattern type.
			/// </summary>
			private Int8 _patternType = new Int8(3);
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

			public DescribeAclsResource WithPatternType(Int8 patternType)
			{
				PatternType = patternType;
				return this;
			}

			/// <summary>
			/// The ACLs.
			/// </summary>
			private AclDescription[] _aclsCollection = Array.Empty<AclDescription>();
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
				internal AclDescription(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<AclDescription> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AclDescription(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Principal = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Host = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Operation = await reader.ReadInt8Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PermissionType = await reader.ReadInt8Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Principal, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Host, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(Operation, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(PermissionType, cancellationToken);
					}
				}

				/// <summary>
				/// The ACL principal.
				/// </summary>
				private String _principal = String.Default;
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

				public AclDescription WithPrincipal(String principal)
				{
					Principal = principal;
					return this;
				}

				/// <summary>
				/// The ACL host.
				/// </summary>
				private String _host = String.Default;
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

				public AclDescription WithHost(String host)
				{
					Host = host;
					return this;
				}

				/// <summary>
				/// The ACL operation.
				/// </summary>
				private Int8 _operation = Int8.Default;
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

				public AclDescription WithOperation(Int8 operation)
				{
					Operation = operation;
					return this;
				}

				/// <summary>
				/// The ACL permission type.
				/// </summary>
				private Int8 _permissionType = Int8.Default;
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

				public AclDescription WithPermissionType(Int8 permissionType)
				{
					PermissionType = permissionType;
					return this;
				}
			}
		}
	}

	public class DescribeConfigsRequest : Message
	{
		public DescribeConfigsRequest(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"DescribeConfigsRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 32;

		public override int Version { get; }

		public static async ValueTask<DescribeConfigsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeConfigsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourcesCollection = await reader.ReadArrayAsync(async () => await DescribeConfigsResource.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.IncludeSynoyms = await reader.ReadBooleanAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResourcesCollection);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteBooleanAsync(IncludeSynoyms, cancellationToken);
			}
		}

		/// <summary>
		/// The resources whose configurations we want to describe.
		/// </summary>
		private DescribeConfigsResource[] _resourcesCollection = Array.Empty<DescribeConfigsResource>();
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
			internal DescribeConfigsResource(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DescribeConfigsResource> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribeConfigsResource(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ConfigurationKeysCollection = await reader.ReadNullableArrayAsync(async () => await String.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableArrayAsync(cancellationToken, ConfigurationKeysCollection);
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			private Int8 _resourceType = Int8.Default;
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

			public DescribeConfigsResource WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			private String _resourceName = String.Default;
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

			public DescribeConfigsResource WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}

			/// <summary>
			/// The configuration keys to list, or null to list all configuration keys.
			/// </summary>
			private String[]? _configurationKeysCollection = Array.Empty<String>();
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

			public DescribeConfigsResource WithConfigurationKeysCollection(String[] configurationKeysCollection)
			{
				ConfigurationKeysCollection = configurationKeysCollection;
				return this;
			}
		}

		/// <summary>
		/// True if we should include all synonyms.
		/// </summary>
		private Boolean _includeSynoyms = new Boolean(false);
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

		public DescribeConfigsRequest WithIncludeSynoyms(Boolean includeSynoyms)
		{
			IncludeSynoyms = includeSynoyms;
			return this;
		}
	}

	public class DescribeConfigsResponse : Message
	{
		public DescribeConfigsResponse(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"DescribeConfigsResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 32;

		public override int Version { get; }

		public static async ValueTask<DescribeConfigsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeConfigsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = await reader.ReadArrayAsync(async () => await DescribeConfigsResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public DescribeConfigsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The results for each resource.
		/// </summary>
		private DescribeConfigsResult[] _resultsCollection = Array.Empty<DescribeConfigsResult>();
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
			internal DescribeConfigsResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DescribeConfigsResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribeConfigsResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ConfigsCollection = await reader.ReadArrayAsync(async () => await DescribeConfigsResourceResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ConfigsCollection);
				}
			}

			/// <summary>
			/// The error code, or 0 if we were able to successfully describe the configurations.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public DescribeConfigsResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			/// <summary>
			/// The error message, or null if we were able to successfully describe the configurations.
			/// </summary>
			private String? _errorMessage = String.Default;
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

			public DescribeConfigsResult WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			private Int8 _resourceType = Int8.Default;
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

			public DescribeConfigsResult WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			private String _resourceName = String.Default;
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

			public DescribeConfigsResult WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}

			/// <summary>
			/// Each listed configuration.
			/// </summary>
			private DescribeConfigsResourceResult[] _configsCollection = Array.Empty<DescribeConfigsResourceResult>();
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
				internal DescribeConfigsResourceResult(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<DescribeConfigsResourceResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DescribeConfigsResourceResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Value = await reader.ReadNullableStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ReadOnly = await reader.ReadBooleanAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 0)) 
					{
						instance.IsDefault = await reader.ReadBooleanAsync(cancellationToken);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.ConfigSource = await reader.ReadInt8Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.IsSensitive = await reader.ReadBooleanAsync(cancellationToken);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.SynonymsCollection = await reader.ReadArrayAsync(async () => await DescribeConfigsSynonym.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(Value, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteBooleanAsync(ReadOnly, cancellationToken);
					}
					if (Version.InRange(0, 0)) 
					{
						await writer.WriteBooleanAsync(IsDefault, cancellationToken);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt8Async(ConfigSource, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteBooleanAsync(IsSensitive, cancellationToken);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, SynonymsCollection);
					}
				}

				/// <summary>
				/// The configuration name.
				/// </summary>
				private String _name = String.Default;
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

				public DescribeConfigsResourceResult WithName(String name)
				{
					Name = name;
					return this;
				}

				/// <summary>
				/// The configuration value.
				/// </summary>
				private String? _value = String.Default;
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

				public DescribeConfigsResourceResult WithValue(String value)
				{
					Value = value;
					return this;
				}

				/// <summary>
				/// True if the configuration is read-only.
				/// </summary>
				private Boolean _readOnly = Boolean.Default;
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

				public DescribeConfigsResourceResult WithReadOnly(Boolean readOnly)
				{
					ReadOnly = readOnly;
					return this;
				}

				/// <summary>
				/// True if the configuration is not set.
				/// </summary>
				private Boolean _isDefault = Boolean.Default;
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

				public DescribeConfigsResourceResult WithIsDefault(Boolean isDefault)
				{
					IsDefault = isDefault;
					return this;
				}

				/// <summary>
				/// The configuration source.
				/// </summary>
				private Int8 _configSource = new Int8(-1);
				public Int8 ConfigSource 
				{
					get => _configSource;
					set 
					{
						_configSource = value;
					}
				}

				public DescribeConfigsResourceResult WithConfigSource(Int8 configSource)
				{
					ConfigSource = configSource;
					return this;
				}

				/// <summary>
				/// True if this configuration is sensitive.
				/// </summary>
				private Boolean _isSensitive = Boolean.Default;
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

				public DescribeConfigsResourceResult WithIsSensitive(Boolean isSensitive)
				{
					IsSensitive = isSensitive;
					return this;
				}

				/// <summary>
				/// The synonyms for this configuration key.
				/// </summary>
				private DescribeConfigsSynonym[] _synonymsCollection = Array.Empty<DescribeConfigsSynonym>();
				public DescribeConfigsSynonym[] SynonymsCollection 
				{
					get => _synonymsCollection;
					set 
					{
						_synonymsCollection = value;
					}
				}

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
					internal DescribeConfigsSynonym(int version)
					{
						Version = version;
					}

					internal int Version { get; }

					public static async ValueTask<DescribeConfigsSynonym> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
					{
						var instance = new DescribeConfigsSynonym(version);
						if (instance.Version.InRange(1, 2147483647)) 
						{
							instance.Name = await reader.ReadStringAsync(cancellationToken);
						}
						if (instance.Version.InRange(1, 2147483647)) 
						{
							instance.Value = await reader.ReadNullableStringAsync(cancellationToken);
						}
						if (instance.Version.InRange(1, 2147483647)) 
						{
							instance.Source = await reader.ReadInt8Async(cancellationToken);
						}
						return instance;
					}

					public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
					{
						if (Version.InRange(1, 2147483647)) 
						{
							await writer.WriteStringAsync(Name, cancellationToken);
						}
						if (Version.InRange(1, 2147483647)) 
						{
							await writer.WriteNullableStringAsync(Value, cancellationToken);
						}
						if (Version.InRange(1, 2147483647)) 
						{
							await writer.WriteInt8Async(Source, cancellationToken);
						}
					}

					/// <summary>
					/// The synonym name.
					/// </summary>
					private String _name = String.Default;
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

					public DescribeConfigsSynonym WithName(String name)
					{
						Name = name;
						return this;
					}

					/// <summary>
					/// The synonym value.
					/// </summary>
					private String? _value = String.Default;
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

					public DescribeConfigsSynonym WithValue(String value)
					{
						Value = value;
						return this;
					}

					/// <summary>
					/// The synonym source.
					/// </summary>
					private Int8 _source = Int8.Default;
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

					public DescribeConfigsSynonym WithSource(Int8 source)
					{
						Source = source;
						return this;
					}
				}
			}
		}
	}

	public class DescribeDelegationTokenRequest : Message
	{
		public DescribeDelegationTokenRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DescribeDelegationTokenRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 41;

		public override int Version { get; }

		public static async ValueTask<DescribeDelegationTokenRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeDelegationTokenRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.OwnersCollection = await reader.ReadNullableArrayAsync(async () => await DescribeDelegationTokenOwner.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableArrayAsync(cancellationToken, OwnersCollection);
			}
		}

		/// <summary>
		/// Each owner that we want to describe delegation tokens for, or null to describe all tokens.
		/// </summary>
		private DescribeDelegationTokenOwner[]? _ownersCollection = Array.Empty<DescribeDelegationTokenOwner>();
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
			internal DescribeDelegationTokenOwner(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DescribeDelegationTokenOwner> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribeDelegationTokenOwner(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalType = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalName = await reader.ReadStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalName, cancellationToken);
				}
			}

			/// <summary>
			/// The owner principal type.
			/// </summary>
			private String _principalType = String.Default;
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

			public DescribeDelegationTokenOwner WithPrincipalType(String principalType)
			{
				PrincipalType = principalType;
				return this;
			}

			/// <summary>
			/// The owner principal name.
			/// </summary>
			private String _principalName = String.Default;
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

			public DescribeDelegationTokenOwner WithPrincipalName(String principalName)
			{
				PrincipalName = principalName;
				return this;
			}
		}
	}

	public class DescribeDelegationTokenResponse : Message
	{
		public DescribeDelegationTokenResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DescribeDelegationTokenResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 41;

		public override int Version { get; }

		public static async ValueTask<DescribeDelegationTokenResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeDelegationTokenResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TokensCollection = await reader.ReadArrayAsync(async () => await DescribedDelegationToken.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TokensCollection);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public DescribeDelegationTokenResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The tokens.
		/// </summary>
		private DescribedDelegationToken[] _tokensCollection = Array.Empty<DescribedDelegationToken>();
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
			internal DescribedDelegationToken(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DescribedDelegationToken> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribedDelegationToken(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalType = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PrincipalName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.IssueTimestamp = await reader.ReadInt64Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ExpiryTimestamp = await reader.ReadInt64Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MaxTimestamp = await reader.ReadInt64Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TokenId = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Hmac = await reader.ReadBytesAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.RenewersCollection = await reader.ReadArrayAsync(async () => await DescribedDelegationTokenRenewer.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(PrincipalName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt64Async(IssueTimestamp, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt64Async(ExpiryTimestamp, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt64Async(MaxTimestamp, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(TokenId, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteBytesAsync(Hmac, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, RenewersCollection);
				}
			}

			/// <summary>
			/// The token principal type.
			/// </summary>
			private String _principalType = String.Default;
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

			public DescribedDelegationToken WithPrincipalType(String principalType)
			{
				PrincipalType = principalType;
				return this;
			}

			/// <summary>
			/// The token principal name.
			/// </summary>
			private String _principalName = String.Default;
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

			public DescribedDelegationToken WithPrincipalName(String principalName)
			{
				PrincipalName = principalName;
				return this;
			}

			/// <summary>
			/// The token issue timestamp in milliseconds.
			/// </summary>
			private Int64 _issueTimestamp = Int64.Default;
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

			public DescribedDelegationToken WithIssueTimestamp(Int64 issueTimestamp)
			{
				IssueTimestamp = issueTimestamp;
				return this;
			}

			/// <summary>
			/// The token expiry timestamp in milliseconds.
			/// </summary>
			private Int64 _expiryTimestamp = Int64.Default;
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

			public DescribedDelegationToken WithExpiryTimestamp(Int64 expiryTimestamp)
			{
				ExpiryTimestamp = expiryTimestamp;
				return this;
			}

			/// <summary>
			/// The token maximum timestamp length in milliseconds.
			/// </summary>
			private Int64 _maxTimestamp = Int64.Default;
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

			public DescribedDelegationToken WithMaxTimestamp(Int64 maxTimestamp)
			{
				MaxTimestamp = maxTimestamp;
				return this;
			}

			/// <summary>
			/// The token ID.
			/// </summary>
			private String _tokenId = String.Default;
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

			public DescribedDelegationToken WithTokenId(String tokenId)
			{
				TokenId = tokenId;
				return this;
			}

			/// <summary>
			/// The token HMAC.
			/// </summary>
			private Bytes _hmac = Bytes.Default;
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

			public DescribedDelegationToken WithHmac(Bytes hmac)
			{
				Hmac = hmac;
				return this;
			}

			/// <summary>
			/// Those who are able to renew this token before it expires.
			/// </summary>
			private DescribedDelegationTokenRenewer[] _renewersCollection = Array.Empty<DescribedDelegationTokenRenewer>();
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
				internal DescribedDelegationTokenRenewer(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<DescribedDelegationTokenRenewer> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DescribedDelegationTokenRenewer(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PrincipalType = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PrincipalName = await reader.ReadStringAsync(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(PrincipalType, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(PrincipalName, cancellationToken);
					}
				}

				/// <summary>
				/// The renewer principal type
				/// </summary>
				private String _principalType = String.Default;
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

				public DescribedDelegationTokenRenewer WithPrincipalType(String principalType)
				{
					PrincipalType = principalType;
					return this;
				}

				/// <summary>
				/// The renewer principal name
				/// </summary>
				private String _principalName = String.Default;
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

				public DescribedDelegationTokenRenewer WithPrincipalName(String principalName)
				{
					PrincipalName = principalName;
					return this;
				}
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public DescribeDelegationTokenResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class DescribeGroupsRequest : Message
	{
		public DescribeGroupsRequest(int version)
		{
			if (version.InRange(0, 4) == false) 
			{
				throw new UnsupportedVersionException($"DescribeGroupsRequest does not support version {version}. Valid versions are: 0-4");
			}

			Version = version;
		}

		public const int ApiKey = 15;

		public override int Version { get; }

		public static async ValueTask<DescribeGroupsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeGroupsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupsCollection = await reader.ReadArrayAsync(async () => await String.FromReaderAsync(reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.IncludeAuthorizedOperations = await reader.ReadBooleanAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, GroupsCollection);
			}
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteBooleanAsync(IncludeAuthorizedOperations, cancellationToken);
			}
		}

		/// <summary>
		/// The names of the groups to describe
		/// </summary>
		private String[] _groupsCollection = Array.Empty<String>();
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

		public DescribeGroupsRequest WithGroupsCollection(String[] groupsCollection)
		{
			GroupsCollection = groupsCollection;
			return this;
		}

		/// <summary>
		/// Whether to include authorized operations.
		/// </summary>
		private Boolean _includeAuthorizedOperations = Boolean.Default;
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

		public DescribeGroupsRequest WithIncludeAuthorizedOperations(Boolean includeAuthorizedOperations)
		{
			IncludeAuthorizedOperations = includeAuthorizedOperations;
			return this;
		}
	}

	public class DescribeGroupsResponse : Message
	{
		public DescribeGroupsResponse(int version)
		{
			if (version.InRange(0, 4) == false) 
			{
				throw new UnsupportedVersionException($"DescribeGroupsResponse does not support version {version}. Valid versions are: 0-4");
			}

			Version = version;
		}

		public const int ApiKey = 15;

		public override int Version { get; }

		public static async ValueTask<DescribeGroupsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeGroupsResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupsCollection = await reader.ReadArrayAsync(async () => await DescribedGroup.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, GroupsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public DescribeGroupsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// Each described group.
		/// </summary>
		private DescribedGroup[] _groupsCollection = Array.Empty<DescribedGroup>();
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
			internal DescribedGroup(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DescribedGroup> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribedGroup(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.GroupId = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.GroupState = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProtocolType = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProtocolData = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MembersCollection = await reader.ReadArrayAsync(async () => await DescribedGroupMember.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				if (instance.Version.InRange(3, 2147483647)) 
				{
					instance.AuthorizedOperations = await reader.ReadInt32Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(GroupId, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(GroupState, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ProtocolType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ProtocolData, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, MembersCollection);
				}
				if (Version.InRange(3, 2147483647)) 
				{
					await writer.WriteInt32Async(AuthorizedOperations, cancellationToken);
				}
			}

			/// <summary>
			/// The describe error, or 0 if there was no error.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public DescribedGroup WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			/// <summary>
			/// The group ID string.
			/// </summary>
			private String _groupId = String.Default;
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

			public DescribedGroup WithGroupId(String groupId)
			{
				GroupId = groupId;
				return this;
			}

			/// <summary>
			/// The group state string, or the empty string.
			/// </summary>
			private String _groupState = String.Default;
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

			public DescribedGroup WithGroupState(String groupState)
			{
				GroupState = groupState;
				return this;
			}

			/// <summary>
			/// The group protocol type, or the empty string.
			/// </summary>
			private String _protocolType = String.Default;
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

			public DescribedGroup WithProtocolType(String protocolType)
			{
				ProtocolType = protocolType;
				return this;
			}

			/// <summary>
			/// The group protocol data, or the empty string.
			/// </summary>
			private String _protocolData = String.Default;
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

			public DescribedGroup WithProtocolData(String protocolData)
			{
				ProtocolData = protocolData;
				return this;
			}

			/// <summary>
			/// The group members.
			/// </summary>
			private DescribedGroupMember[] _membersCollection = Array.Empty<DescribedGroupMember>();
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
				internal DescribedGroupMember(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<DescribedGroupMember> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DescribedGroupMember(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.MemberId = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(4, 2147483647)) 
					{
						instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ClientId = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ClientHost = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.MemberMetadata = await reader.ReadBytesAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.MemberAssignment = await reader.ReadBytesAsync(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(MemberId, cancellationToken);
					}
					if (Version.InRange(4, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(ClientId, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(ClientHost, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteBytesAsync(MemberMetadata, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteBytesAsync(MemberAssignment, cancellationToken);
					}
				}

				/// <summary>
				/// The member ID assigned by the group coordinator.
				/// </summary>
				private String _memberId = String.Default;
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

				public DescribedGroupMember WithMemberId(String memberId)
				{
					MemberId = memberId;
					return this;
				}

				/// <summary>
				/// The unique identifier of the consumer instance provided by end user.
				/// </summary>
				private String? _groupInstanceId;
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

				public DescribedGroupMember WithGroupInstanceId(String groupInstanceId)
				{
					GroupInstanceId = groupInstanceId;
					return this;
				}

				/// <summary>
				/// The client ID used in the member's latest join group request.
				/// </summary>
				private String _clientId = String.Default;
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

				public DescribedGroupMember WithClientId(String clientId)
				{
					ClientId = clientId;
					return this;
				}

				/// <summary>
				/// The client host.
				/// </summary>
				private String _clientHost = String.Default;
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

				public DescribedGroupMember WithClientHost(String clientHost)
				{
					ClientHost = clientHost;
					return this;
				}

				/// <summary>
				/// The metadata corresponding to the current group protocol in use.
				/// </summary>
				private Bytes _memberMetadata = Bytes.Default;
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

				public DescribedGroupMember WithMemberMetadata(Bytes memberMetadata)
				{
					MemberMetadata = memberMetadata;
					return this;
				}

				/// <summary>
				/// The current assignment provided by the group leader.
				/// </summary>
				private Bytes _memberAssignment = Bytes.Default;
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

				public DescribedGroupMember WithMemberAssignment(Bytes memberAssignment)
				{
					MemberAssignment = memberAssignment;
					return this;
				}
			}

			/// <summary>
			/// 32-bit bitfield to represent authorized operations for this group.
			/// </summary>
			private Int32 _authorizedOperations = new Int32(-2147483648);
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

			public DescribedGroup WithAuthorizedOperations(Int32 authorizedOperations)
			{
				AuthorizedOperations = authorizedOperations;
				return this;
			}
		}
	}

	public class DescribeLogDirsRequest : Message
	{
		public DescribeLogDirsRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DescribeLogDirsRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 35;

		public override int Version { get; }

		public static async ValueTask<DescribeLogDirsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeLogDirsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadNullableArrayAsync(async () => await DescribableLogDirTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// Each topic that we want to describe log directories for, or null for all topics.
		/// </summary>
		private DescribableLogDirTopic[]? _topicsCollection = Array.Empty<DescribableLogDirTopic>();
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
			internal DescribableLogDirTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DescribableLogDirTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribableLogDirTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Topic = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndexCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Topic, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionIndexCollection);
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			private String _topic = String.Default;
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

			public DescribableLogDirTopic WithTopic(String topic)
			{
				Topic = topic;
				return this;
			}

			/// <summary>
			/// The partition indxes.
			/// </summary>
			private Int32[] _partitionIndexCollection = Array.Empty<Int32>();
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

			public DescribableLogDirTopic WithPartitionIndexCollection(Int32[] partitionIndexCollection)
			{
				PartitionIndexCollection = partitionIndexCollection;
				return this;
			}
		}
	}

	public class DescribeLogDirsResponse : Message
	{
		public DescribeLogDirsResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"DescribeLogDirsResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 35;

		public override int Version { get; }

		public static async ValueTask<DescribeLogDirsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new DescribeLogDirsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResultsCollection = await reader.ReadArrayAsync(async () => await DescribeLogDirsResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public DescribeLogDirsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The log directories.
		/// </summary>
		private DescribeLogDirsResult[] _resultsCollection = Array.Empty<DescribeLogDirsResult>();
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
			internal DescribeLogDirsResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<DescribeLogDirsResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new DescribeLogDirsResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.LogDir = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicsCollection = await reader.ReadArrayAsync(async () => await DescribeLogDirsTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(LogDir, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
				}
			}

			/// <summary>
			/// The error code, or 0 if there was no error.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public DescribeLogDirsResult WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			/// <summary>
			/// The absolute log directory path.
			/// </summary>
			private String _logDir = String.Default;
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

			public DescribeLogDirsResult WithLogDir(String logDir)
			{
				LogDir = logDir;
				return this;
			}

			/// <summary>
			/// Each topic.
			/// </summary>
			private DescribeLogDirsTopic[] _topicsCollection = Array.Empty<DescribeLogDirsTopic>();
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
				internal DescribeLogDirsTopic(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<DescribeLogDirsTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new DescribeLogDirsTopic(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await DescribeLogDirsPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				private String _name = String.Default;
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
					internal DescribeLogDirsPartition(int version)
					{
						Version = version;
					}

					internal int Version { get; }

					public static async ValueTask<DescribeLogDirsPartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
					{
						var instance = new DescribeLogDirsPartition(version);
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
						}
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.PartitionSize = await reader.ReadInt64Async(cancellationToken);
						}
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.OffsetLag = await reader.ReadInt64Async(cancellationToken);
						}
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.IsFutureKey = await reader.ReadBooleanAsync(cancellationToken);
						}
						return instance;
					}

					public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
					{
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteInt32Async(PartitionIndex, cancellationToken);
						}
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteInt64Async(PartitionSize, cancellationToken);
						}
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteInt64Async(OffsetLag, cancellationToken);
						}
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteBooleanAsync(IsFutureKey, cancellationToken);
						}
					}

					/// <summary>
					/// The partition index.
					/// </summary>
					private Int32 _partitionIndex = Int32.Default;
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

					public DescribeLogDirsPartition WithPartitionIndex(Int32 partitionIndex)
					{
						PartitionIndex = partitionIndex;
						return this;
					}

					/// <summary>
					/// The size of the log segments in this partition in bytes.
					/// </summary>
					private Int64 _partitionSize = Int64.Default;
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

					public DescribeLogDirsPartition WithPartitionSize(Int64 partitionSize)
					{
						PartitionSize = partitionSize;
						return this;
					}

					/// <summary>
					/// The lag of the log's LEO w.r.t. partition's HW (if it is the current log for the partition) or current replica's LEO (if it is the future log for the partition)
					/// </summary>
					private Int64 _offsetLag = Int64.Default;
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

					public DescribeLogDirsPartition WithOffsetLag(Int64 offsetLag)
					{
						OffsetLag = offsetLag;
						return this;
					}

					/// <summary>
					/// True if this log is created by AlterReplicaLogDirsRequest and will replace the current log of the replica in the future.
					/// </summary>
					private Boolean _isFutureKey = Boolean.Default;
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

					public DescribeLogDirsPartition WithIsFutureKey(Boolean isFutureKey)
					{
						IsFutureKey = isFutureKey;
						return this;
					}
				}
			}
		}
	}

	public class ElectLeadersRequest : Message
	{
		public ElectLeadersRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"ElectLeadersRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 43;

		public override int Version { get; }

		public static async ValueTask<ElectLeadersRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ElectLeadersRequest(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ElectionType = await reader.ReadInt8Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicPartitionsCollection = await reader.ReadNullableArrayAsync(async () => await TopicPartitions.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt8Async(ElectionType, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableArrayAsync(cancellationToken, TopicPartitionsCollection);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken);
			}
		}

		/// <summary>
		/// Type of elections to conduct for the partition. A value of '0' elects the preferred replica. A value of '1' elects the first live replica if there are no in-sync replica.
		/// </summary>
		private Int8 _electionType = Int8.Default;
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

		public ElectLeadersRequest WithElectionType(Int8 electionType)
		{
			ElectionType = electionType;
			return this;
		}

		/// <summary>
		/// The topic partitions to elect leaders.
		/// </summary>
		private TopicPartitions[]? _topicPartitionsCollection = Array.Empty<TopicPartitions>();
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
			internal TopicPartitions(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<TopicPartitions> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TopicPartitions(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Topic = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIdCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Topic, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionIdCollection);
				}
			}

			/// <summary>
			/// The name of a topic.
			/// </summary>
			private String _topic = String.Default;
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

			public TopicPartitions WithTopic(String topic)
			{
				Topic = topic;
				return this;
			}

			/// <summary>
			/// The partitions of this topic whose leader should be elected.
			/// </summary>
			private Int32[] _partitionIdCollection = Array.Empty<Int32>();
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

			public TopicPartitions WithPartitionIdCollection(Int32[] partitionIdCollection)
			{
				PartitionIdCollection = partitionIdCollection;
				return this;
			}
		}

		/// <summary>
		/// The time in ms to wait for the election to complete.
		/// </summary>
		private Int32 _timeoutMs = new Int32(60000);
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

		public ElectLeadersRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}
	}

	public class ElectLeadersResponse : Message
	{
		public ElectLeadersResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"ElectLeadersResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 43;

		public override int Version { get; }

		public static async ValueTask<ElectLeadersResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ElectLeadersResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ReplicaElectionResultsCollection = await reader.ReadArrayAsync(async () => await ReplicaElectionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ReplicaElectionResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public ElectLeadersResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The top level response error code.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public ElectLeadersResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The election results, or an empty array if the requester did not have permission and the request asks for all partitions.
		/// </summary>
		private ReplicaElectionResult[] _replicaElectionResultsCollection = Array.Empty<ReplicaElectionResult>();
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
			internal ReplicaElectionResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<ReplicaElectionResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ReplicaElectionResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Topic = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionResultCollection = await reader.ReadArrayAsync(async () => await PartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Topic, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionResultCollection);
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			private String _topic = String.Default;
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

			public ReplicaElectionResult WithTopic(String topic)
			{
				Topic = topic;
				return this;
			}

			/// <summary>
			/// The results for each partition
			/// </summary>
			private PartitionResult[] _partitionResultCollection = Array.Empty<PartitionResult>();
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
				internal PartitionResult(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<PartitionResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new PartitionResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionId = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionId, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
					}
				}

				/// <summary>
				/// The partition id
				/// </summary>
				private Int32 _partitionId = Int32.Default;
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

				public PartitionResult WithPartitionId(Int32 partitionId)
				{
					PartitionId = partitionId;
					return this;
				}

				/// <summary>
				/// The result error, or zero if there was no error.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public PartitionResult WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				/// <summary>
				/// The result message, or null if there was no error.
				/// </summary>
				private String? _errorMessage = String.Default;
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

				public PartitionResult WithErrorMessage(String errorMessage)
				{
					ErrorMessage = errorMessage;
					return this;
				}
			}
		}
	}

	public class EndTxnRequest : Message
	{
		public EndTxnRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"EndTxnRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 26;

		public override int Version { get; }

		public static async ValueTask<EndTxnRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new EndTxnRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerId = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Committed = await reader.ReadBooleanAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(TransactionalId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ProducerId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ProducerEpoch, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBooleanAsync(Committed, cancellationToken);
			}
		}

		/// <summary>
		/// The ID of the transaction to end.
		/// </summary>
		private String _transactionalId = String.Default;
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

		public EndTxnRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		/// <summary>
		/// The producer ID.
		/// </summary>
		private Int64 _producerId = Int64.Default;
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

		public EndTxnRequest WithProducerId(Int64 producerId)
		{
			ProducerId = producerId;
			return this;
		}

		/// <summary>
		/// The current epoch associated with the producer.
		/// </summary>
		private Int16 _producerEpoch = Int16.Default;
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

		public EndTxnRequest WithProducerEpoch(Int16 producerEpoch)
		{
			ProducerEpoch = producerEpoch;
			return this;
		}

		/// <summary>
		/// True if the transaction was committed, false if it was aborted.
		/// </summary>
		private Boolean _committed = Boolean.Default;
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

		public EndTxnRequest WithCommitted(Boolean committed)
		{
			Committed = committed;
			return this;
		}
	}

	public class EndTxnResponse : Message
	{
		public EndTxnResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"EndTxnResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 26;

		public override int Version { get; }

		public static async ValueTask<EndTxnResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new EndTxnResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public EndTxnResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public EndTxnResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class ExpireDelegationTokenRequest : Message
	{
		public ExpireDelegationTokenRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"ExpireDelegationTokenRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 40;

		public override int Version { get; }

		public static async ValueTask<ExpireDelegationTokenRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ExpireDelegationTokenRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Hmac = await reader.ReadBytesAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ExpiryTimePeriodMs = await reader.ReadInt64Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(Hmac, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ExpiryTimePeriodMs, cancellationToken);
			}
		}

		/// <summary>
		/// The HMAC of the delegation token to be expired.
		/// </summary>
		private Bytes _hmac = Bytes.Default;
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

		public ExpireDelegationTokenRequest WithHmac(Bytes hmac)
		{
			Hmac = hmac;
			return this;
		}

		/// <summary>
		/// The expiry time period in milliseconds.
		/// </summary>
		private Int64 _expiryTimePeriodMs = Int64.Default;
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

		public ExpireDelegationTokenRequest WithExpiryTimePeriodMs(Int64 expiryTimePeriodMs)
		{
			ExpiryTimePeriodMs = expiryTimePeriodMs;
			return this;
		}
	}

	public class ExpireDelegationTokenResponse : Message
	{
		public ExpireDelegationTokenResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"ExpireDelegationTokenResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 40;

		public override int Version { get; }

		public static async ValueTask<ExpireDelegationTokenResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ExpireDelegationTokenResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ExpiryTimestampMs = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ExpiryTimestampMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public ExpireDelegationTokenResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The timestamp in milliseconds at which this token expires.
		/// </summary>
		private Int64 _expiryTimestampMs = Int64.Default;
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

		public ExpireDelegationTokenResponse WithExpiryTimestampMs(Int64 expiryTimestampMs)
		{
			ExpiryTimestampMs = expiryTimestampMs;
			return this;
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public ExpireDelegationTokenResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class FetchRequest : Message
	{
		public FetchRequest(int version)
		{
			if (version.InRange(0, 11) == false) 
			{
				throw new UnsupportedVersionException($"FetchRequest does not support version {version}. Valid versions are: 0-11");
			}

			Version = version;
		}

		public const int ApiKey = 1;

		public override int Version { get; }

		public static async ValueTask<FetchRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new FetchRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ReplicaId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MaxWait = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MinBytes = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.MaxBytes = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(4, 2147483647)) 
			{
				instance.IsolationLevel = await reader.ReadInt8Async(cancellationToken);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.SessionId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.Epoch = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await FetchableTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.ForgottenCollection = await reader.ReadArrayAsync(async () => await ForgottenTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(11, 2147483647)) 
			{
				instance.RackId = await reader.ReadStringAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ReplicaId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(MaxWait, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(MinBytes, cancellationToken);
			}
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteInt32Async(MaxBytes, cancellationToken);
			}
			if (Version.InRange(4, 2147483647)) 
			{
				await writer.WriteInt8Async(IsolationLevel, cancellationToken);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteInt32Async(SessionId, cancellationToken);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteInt32Async(Epoch, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ForgottenCollection);
			}
			if (Version.InRange(11, 2147483647)) 
			{
				await writer.WriteStringAsync(RackId, cancellationToken);
			}
		}

		/// <summary>
		/// The broker ID of the follower, of -1 if this request is from a consumer.
		/// </summary>
		private Int32 _replicaId = Int32.Default;
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

		public FetchRequest WithReplicaId(Int32 replicaId)
		{
			ReplicaId = replicaId;
			return this;
		}

		/// <summary>
		/// The maximum time in milliseconds to wait for the response.
		/// </summary>
		private Int32 _maxWait = Int32.Default;
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

		public FetchRequest WithMaxWait(Int32 maxWait)
		{
			MaxWait = maxWait;
			return this;
		}

		/// <summary>
		/// The minimum bytes to accumulate in the response.
		/// </summary>
		private Int32 _minBytes = Int32.Default;
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

		public FetchRequest WithMinBytes(Int32 minBytes)
		{
			MinBytes = minBytes;
			return this;
		}

		/// <summary>
		/// The maximum bytes to fetch.  See KIP-74 for cases where this limit may not be honored.
		/// </summary>
		private Int32 _maxBytes = new Int32(0x7fffffff);
		public Int32 MaxBytes 
		{
			get => _maxBytes;
			set 
			{
				_maxBytes = value;
			}
		}

		public FetchRequest WithMaxBytes(Int32 maxBytes)
		{
			MaxBytes = maxBytes;
			return this;
		}

		/// <summary>
		/// This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records
		/// </summary>
		private Int8 _isolationLevel = new Int8(0);
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

		public FetchRequest WithIsolationLevel(Int8 isolationLevel)
		{
			IsolationLevel = isolationLevel;
			return this;
		}

		/// <summary>
		/// The fetch session ID.
		/// </summary>
		private Int32 _sessionId = new Int32(0);
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

		public FetchRequest WithSessionId(Int32 sessionId)
		{
			SessionId = sessionId;
			return this;
		}

		/// <summary>
		/// The fetch session ID.
		/// </summary>
		private Int32 _epoch = new Int32(-1);
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

		public FetchRequest WithEpoch(Int32 epoch)
		{
			Epoch = epoch;
			return this;
		}

		/// <summary>
		/// The topics to fetch.
		/// </summary>
		private FetchableTopic[] _topicsCollection = Array.Empty<FetchableTopic>();
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
			internal FetchableTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<FetchableTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new FetchableTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.FetchPartitionsCollection = await reader.ReadArrayAsync(async () => await FetchPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, FetchPartitionsCollection);
				}
			}

			/// <summary>
			/// The name of the topic to fetch.
			/// </summary>
			private String _name = String.Default;
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

			public FetchableTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The partitions to fetch.
			/// </summary>
			private FetchPartition[] _fetchPartitionsCollection = Array.Empty<FetchPartition>();
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
				internal FetchPartition(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<FetchPartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new FetchPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(9, 2147483647)) 
					{
						instance.CurrentLeaderEpoch = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.FetchOffset = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(5, 2147483647)) 
					{
						instance.LogStartOffset = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.MaxBytes = await reader.ReadInt32Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(9, 2147483647)) 
					{
						await writer.WriteInt32Async(CurrentLeaderEpoch, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(FetchOffset, cancellationToken);
					}
					if (Version.InRange(5, 2147483647)) 
					{
						await writer.WriteInt64Async(LogStartOffset, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(MaxBytes, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public FetchPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The current leader epoch of the partition.
				/// </summary>
				private Int32 _currentLeaderEpoch = new Int32(-1);
				public Int32 CurrentLeaderEpoch 
				{
					get => _currentLeaderEpoch;
					set 
					{
						_currentLeaderEpoch = value;
					}
				}

				public FetchPartition WithCurrentLeaderEpoch(Int32 currentLeaderEpoch)
				{
					CurrentLeaderEpoch = currentLeaderEpoch;
					return this;
				}

				/// <summary>
				/// The message offset.
				/// </summary>
				private Int64 _fetchOffset = Int64.Default;
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

				public FetchPartition WithFetchOffset(Int64 fetchOffset)
				{
					FetchOffset = fetchOffset;
					return this;
				}

				/// <summary>
				/// The earliest available offset of the follower replica.  The field is only used when the request is sent by the follower.
				/// </summary>
				private Int64 _logStartOffset = new Int64(-1);
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

				public FetchPartition WithLogStartOffset(Int64 logStartOffset)
				{
					LogStartOffset = logStartOffset;
					return this;
				}

				/// <summary>
				/// The maximum bytes to fetch from this partition.  See KIP-74 for cases where this limit may not be honored.
				/// </summary>
				private Int32 _maxBytes = Int32.Default;
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

				public FetchPartition WithMaxBytes(Int32 maxBytes)
				{
					MaxBytes = maxBytes;
					return this;
				}
			}
		}

		/// <summary>
		/// In an incremental fetch request, the partitions to remove.
		/// </summary>
		private ForgottenTopic[] _forgottenCollection = Array.Empty<ForgottenTopic>();
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
			internal ForgottenTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<ForgottenTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ForgottenTopic(version);
				if (instance.Version.InRange(7, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(7, 2147483647)) 
				{
					instance.ForgottenPartitionIndexesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(7, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(7, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ForgottenPartitionIndexesCollection);
				}
			}

			/// <summary>
			/// The partition name.
			/// </summary>
			private String _name = String.Default;
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

			public ForgottenTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The partitions indexes to forget.
			/// </summary>
			private Int32[] _forgottenPartitionIndexesCollection = Array.Empty<Int32>();
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

			public ForgottenTopic WithForgottenPartitionIndexesCollection(Int32[] forgottenPartitionIndexesCollection)
			{
				ForgottenPartitionIndexesCollection = forgottenPartitionIndexesCollection;
				return this;
			}
		}

		/// <summary>
		/// Rack ID of the consumer making this request
		/// </summary>
		private String _rackId = new String();
		public String RackId 
		{
			get => _rackId;
			set 
			{
				_rackId = value;
			}
		}

		public FetchRequest WithRackId(String rackId)
		{
			RackId = rackId;
			return this;
		}
	}

	public class FetchResponse : Message
	{
		public FetchResponse(int version)
		{
			if (version.InRange(0, 11) == false) 
			{
				throw new UnsupportedVersionException($"FetchResponse does not support version {version}. Valid versions are: 0-11");
			}

			Version = version;
		}

		public const int ApiKey = 1;

		public override int Version { get; }

		public static async ValueTask<FetchResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new FetchResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.SessionId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await FetchableTopicResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteInt32Async(SessionId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public FetchResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The top level response error code.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public FetchResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The fetch session ID, or 0 if this is not part of a fetch session.
		/// </summary>
		private Int32 _sessionId = new Int32(0);
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

		public FetchResponse WithSessionId(Int32 sessionId)
		{
			SessionId = sessionId;
			return this;
		}

		/// <summary>
		/// The response topics.
		/// </summary>
		private FetchableTopicResponse[] _topicsCollection = Array.Empty<FetchableTopicResponse>();
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
			internal FetchableTopicResponse(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<FetchableTopicResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new FetchableTopicResponse(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await FetchablePartitionResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public FetchableTopicResponse WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The topic partitions.
			/// </summary>
			private FetchablePartitionResponse[] _partitionsCollection = Array.Empty<FetchablePartitionResponse>();
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
				internal FetchablePartitionResponse(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<FetchablePartitionResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new FetchablePartitionResponse(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.HighWatermark = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(4, 2147483647)) 
					{
						instance.LastStableOffset = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(5, 2147483647)) 
					{
						instance.LogStartOffset = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(4, 2147483647)) 
					{
						instance.AbortedCollection = await reader.ReadNullableArrayAsync(async () => await AbortedTransaction.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
					}
					if (instance.Version.InRange(11, 2147483647)) 
					{
						instance.PreferredReadReplica = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Records = await reader.ReadNullableBytesAsync(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(HighWatermark, cancellationToken);
					}
					if (Version.InRange(4, 2147483647)) 
					{
						await writer.WriteInt64Async(LastStableOffset, cancellationToken);
					}
					if (Version.InRange(5, 2147483647)) 
					{
						await writer.WriteInt64Async(LogStartOffset, cancellationToken);
					}
					if (Version.InRange(4, 2147483647)) 
					{
						await writer.WriteNullableArrayAsync(cancellationToken, AbortedCollection);
					}
					if (Version.InRange(11, 2147483647)) 
					{
						await writer.WriteInt32Async(PreferredReadReplica, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableBytesAsync(Records, cancellationToken);
					}
				}

				/// <summary>
				/// The partiiton index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public FetchablePartitionResponse WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The error code, or 0 if there was no fetch error.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public FetchablePartitionResponse WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				/// <summary>
				/// The current high water mark.
				/// </summary>
				private Int64 _highWatermark = Int64.Default;
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

				public FetchablePartitionResponse WithHighWatermark(Int64 highWatermark)
				{
					HighWatermark = highWatermark;
					return this;
				}

				/// <summary>
				/// The last stable offset (or LSO) of the partition. This is the last offset such that the state of all transactional records prior to this offset have been decided (ABORTED or COMMITTED)
				/// </summary>
				private Int64 _lastStableOffset = new Int64(-1);
				public Int64 LastStableOffset 
				{
					get => _lastStableOffset;
					set 
					{
						_lastStableOffset = value;
					}
				}

				public FetchablePartitionResponse WithLastStableOffset(Int64 lastStableOffset)
				{
					LastStableOffset = lastStableOffset;
					return this;
				}

				/// <summary>
				/// The current log start offset.
				/// </summary>
				private Int64 _logStartOffset = new Int64(-1);
				public Int64 LogStartOffset 
				{
					get => _logStartOffset;
					set 
					{
						_logStartOffset = value;
					}
				}

				public FetchablePartitionResponse WithLogStartOffset(Int64 logStartOffset)
				{
					LogStartOffset = logStartOffset;
					return this;
				}

				/// <summary>
				/// The aborted transactions.
				/// </summary>
				private AbortedTransaction[]? _abortedCollection = Array.Empty<AbortedTransaction>();
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
					internal AbortedTransaction(int version)
					{
						Version = version;
					}

					internal int Version { get; }

					public static async ValueTask<AbortedTransaction> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
					{
						var instance = new AbortedTransaction(version);
						if (instance.Version.InRange(4, 2147483647)) 
						{
							instance.ProducerId = await reader.ReadInt64Async(cancellationToken);
						}
						if (instance.Version.InRange(4, 2147483647)) 
						{
							instance.FirstOffset = await reader.ReadInt64Async(cancellationToken);
						}
						return instance;
					}

					public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
					{
						if (Version.InRange(4, 2147483647)) 
						{
							await writer.WriteInt64Async(ProducerId, cancellationToken);
						}
						if (Version.InRange(4, 2147483647)) 
						{
							await writer.WriteInt64Async(FirstOffset, cancellationToken);
						}
					}

					/// <summary>
					/// The producer id associated with the aborted transaction.
					/// </summary>
					private Int64 _producerId = Int64.Default;
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

					public AbortedTransaction WithProducerId(Int64 producerId)
					{
						ProducerId = producerId;
						return this;
					}

					/// <summary>
					/// The first offset in the aborted transaction.
					/// </summary>
					private Int64 _firstOffset = Int64.Default;
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

					public AbortedTransaction WithFirstOffset(Int64 firstOffset)
					{
						FirstOffset = firstOffset;
						return this;
					}
				}

				/// <summary>
				/// The preferred read replica for the consumer to use on its next fetch request
				/// </summary>
				private Int32 _preferredReadReplica = Int32.Default;
				public Int32 PreferredReadReplica 
				{
					get => _preferredReadReplica;
					set 
					{
						_preferredReadReplica = value;
					}
				}

				public FetchablePartitionResponse WithPreferredReadReplica(Int32 preferredReadReplica)
				{
					PreferredReadReplica = preferredReadReplica;
					return this;
				}

				/// <summary>
				/// The record data.
				/// </summary>
				private Bytes? _records = Bytes.Default;
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

				public FetchablePartitionResponse WithRecords(Bytes records)
				{
					Records = records;
					return this;
				}
			}
		}
	}

	public class FindCoordinatorRequest : Message
	{
		public FindCoordinatorRequest(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"FindCoordinatorRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 10;

		public override int Version { get; }

		public static async ValueTask<FindCoordinatorRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new FindCoordinatorRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Key = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.KeyType = await reader.ReadInt8Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(Key, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt8Async(KeyType, cancellationToken);
			}
		}

		/// <summary>
		/// The coordinator key.
		/// </summary>
		private String _key = String.Default;
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

		public FindCoordinatorRequest WithKey(String key)
		{
			Key = key;
			return this;
		}

		/// <summary>
		/// The coordinator key type.  (Group, transaction, etc.)
		/// </summary>
		private Int8 _keyType = new Int8(0);
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

		public FindCoordinatorRequest WithKeyType(Int8 keyType)
		{
			KeyType = keyType;
			return this;
		}
	}

	public class FindCoordinatorResponse : Message
	{
		public FindCoordinatorResponse(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"FindCoordinatorResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 10;

		public override int Version { get; }

		public static async ValueTask<FindCoordinatorResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new FindCoordinatorResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.NodeId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Host = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Port = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(NodeId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(Host, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(Port, cancellationToken);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public FindCoordinatorResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public FindCoordinatorResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		private String? _errorMessage = String.Default;
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

		public FindCoordinatorResponse WithErrorMessage(String errorMessage)
		{
			ErrorMessage = errorMessage;
			return this;
		}

		/// <summary>
		/// The node id.
		/// </summary>
		private Int32 _nodeId = Int32.Default;
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

		public FindCoordinatorResponse WithNodeId(Int32 nodeId)
		{
			NodeId = nodeId;
			return this;
		}

		/// <summary>
		/// The host name.
		/// </summary>
		private String _host = String.Default;
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

		public FindCoordinatorResponse WithHost(String host)
		{
			Host = host;
			return this;
		}

		/// <summary>
		/// The port.
		/// </summary>
		private Int32 _port = Int32.Default;
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

		public FindCoordinatorResponse WithPort(Int32 port)
		{
			Port = port;
			return this;
		}
	}

	public class HeartbeatRequest : Message
	{
		public HeartbeatRequest(int version)
		{
			if (version.InRange(0, 3) == false) 
			{
				throw new UnsupportedVersionException($"HeartbeatRequest does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public const int ApiKey = 12;

		public override int Version { get; }

		public static async ValueTask<HeartbeatRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new HeartbeatRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GenerationId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(GenerationId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken);
			}
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken);
			}
		}

		/// <summary>
		/// The group id.
		/// </summary>
		private String _groupId = String.Default;
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

		public HeartbeatRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		/// <summary>
		/// The generation of the group.
		/// </summary>
		private Int32 _generationId = Int32.Default;
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

		public HeartbeatRequest WithGenerationId(Int32 generationId)
		{
			GenerationId = generationId;
			return this;
		}

		/// <summary>
		/// The member ID.
		/// </summary>
		private String _memberId = String.Default;
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

		public HeartbeatRequest WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}

		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		private String? _groupInstanceId;
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

		public HeartbeatRequest WithGroupInstanceId(String groupInstanceId)
		{
			GroupInstanceId = groupInstanceId;
			return this;
		}
	}

	public class HeartbeatResponse : Message
	{
		public HeartbeatResponse(int version)
		{
			if (version.InRange(0, 3) == false) 
			{
				throw new UnsupportedVersionException($"HeartbeatResponse does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public const int ApiKey = 12;

		public override int Version { get; }

		public static async ValueTask<HeartbeatResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new HeartbeatResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public HeartbeatResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public HeartbeatResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class IncrementalAlterConfigsRequest : Message
	{
		public IncrementalAlterConfigsRequest(int version)
		{
			if (version.InRange(0, 0) == false) 
			{
				throw new UnsupportedVersionException($"IncrementalAlterConfigsRequest does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public const int ApiKey = 44;

		public override int Version { get; }

		public static async ValueTask<IncrementalAlterConfigsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new IncrementalAlterConfigsRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResourcesCollection = (await reader.ReadArrayAsync(async () => await AlterConfigsResource.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.ResourceType);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ValidateOnly = await reader.ReadBooleanAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResourcesCollection.Values.ToArray());
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBooleanAsync(ValidateOnly, cancellationToken);
			}
		}

		/// <summary>
		/// The incremental updates for each resource.
		/// </summary>
		private Dictionary<Int8, AlterConfigsResource> _resourcesCollection = new Dictionary<Int8, AlterConfigsResource>();
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
			internal AlterConfigsResource(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<AlterConfigsResource> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterConfigsResource(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ConfigsCollection = (await reader.ReadArrayAsync(async () => await AlterableConfig.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ConfigsCollection.Values.ToArray());
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			private Int8 _resourceType = Int8.Default;
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

			public AlterConfigsResource WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			private String _resourceName = String.Default;
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

			public AlterConfigsResource WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}

			/// <summary>
			/// The configurations.
			/// </summary>
			private Dictionary<String, AlterableConfig> _configsCollection = new Dictionary<String, AlterableConfig>();
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
				internal AlterableConfig(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<AlterableConfig> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new AlterableConfig(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ConfigOperation = await reader.ReadInt8Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Value = await reader.ReadNullableStringAsync(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt8Async(ConfigOperation, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(Value, cancellationToken);
					}
				}

				/// <summary>
				/// The configuration key name.
				/// </summary>
				private String _name = String.Default;
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

				public AlterableConfig WithName(String name)
				{
					Name = name;
					return this;
				}

				/// <summary>
				/// The type (Set, Delete, Append, Subtract) of operation.
				/// </summary>
				private Int8 _configOperation = Int8.Default;
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

				public AlterableConfig WithConfigOperation(Int8 configOperation)
				{
					ConfigOperation = configOperation;
					return this;
				}

				/// <summary>
				/// The value to set for the configuration key.
				/// </summary>
				private String? _value = String.Default;
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

				public AlterableConfig WithValue(String value)
				{
					Value = value;
					return this;
				}
			}
		}

		/// <summary>
		/// True if we should validate the request, but not change the configurations.
		/// </summary>
		private Boolean _validateOnly = Boolean.Default;
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

		public IncrementalAlterConfigsRequest WithValidateOnly(Boolean validateOnly)
		{
			ValidateOnly = validateOnly;
			return this;
		}
	}

	public class IncrementalAlterConfigsResponse : Message
	{
		public IncrementalAlterConfigsResponse(int version)
		{
			if (version.InRange(0, 0) == false) 
			{
				throw new UnsupportedVersionException($"IncrementalAlterConfigsResponse does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public const int ApiKey = 44;

		public override int Version { get; }

		public static async ValueTask<IncrementalAlterConfigsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new IncrementalAlterConfigsResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResponsesCollection = await reader.ReadArrayAsync(async () => await AlterConfigsResourceResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResponsesCollection);
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public IncrementalAlterConfigsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The responses for each resource.
		/// </summary>
		private AlterConfigsResourceResponse[] _responsesCollection = Array.Empty<AlterConfigsResourceResponse>();
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
			internal AlterConfigsResourceResponse(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<AlterConfigsResourceResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new AlterConfigsResourceResponse(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceType = await reader.ReadInt8Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ResourceName = await reader.ReadStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt8Async(ResourceType, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ResourceName, cancellationToken);
				}
			}

			/// <summary>
			/// The resource error code.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public AlterConfigsResourceResponse WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			/// <summary>
			/// The resource error message, or null if there was no error.
			/// </summary>
			private String? _errorMessage = String.Default;
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

			public AlterConfigsResourceResponse WithErrorMessage(String errorMessage)
			{
				ErrorMessage = errorMessage;
				return this;
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			private Int8 _resourceType = Int8.Default;
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

			public AlterConfigsResourceResponse WithResourceType(Int8 resourceType)
			{
				ResourceType = resourceType;
				return this;
			}

			/// <summary>
			/// The resource name.
			/// </summary>
			private String _resourceName = String.Default;
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

			public AlterConfigsResourceResponse WithResourceName(String resourceName)
			{
				ResourceName = resourceName;
				return this;
			}
		}
	}

	public class InitProducerIdRequest : Message
	{
		public InitProducerIdRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"InitProducerIdRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 22;

		public override int Version { get; }

		public static async ValueTask<InitProducerIdRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new InitProducerIdRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionTimeoutMs = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(TransactionalId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TransactionTimeoutMs, cancellationToken);
			}
		}

		/// <summary>
		/// The transactional id, or null if the producer is not transactional.
		/// </summary>
		private String? _transactionalId = String.Default;
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

		public InitProducerIdRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		/// <summary>
		/// The time in ms to wait for before aborting idle transactions sent by this producer. This is only relevant if a TransactionalId has been defined.
		/// </summary>
		private Int32 _transactionTimeoutMs = Int32.Default;
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

		public InitProducerIdRequest WithTransactionTimeoutMs(Int32 transactionTimeoutMs)
		{
			TransactionTimeoutMs = transactionTimeoutMs;
			return this;
		}
	}

	public class InitProducerIdResponse : Message
	{
		public InitProducerIdResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"InitProducerIdResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 22;

		public override int Version { get; }

		public static async ValueTask<InitProducerIdResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new InitProducerIdResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerId = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ProducerId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ProducerEpoch, cancellationToken);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public InitProducerIdResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public InitProducerIdResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The current producer id.
		/// </summary>
		private Int64 _producerId = new Int64(-1);
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

		public InitProducerIdResponse WithProducerId(Int64 producerId)
		{
			ProducerId = producerId;
			return this;
		}

		/// <summary>
		/// The current epoch associated with the producer id.
		/// </summary>
		private Int16 _producerEpoch = Int16.Default;
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

		public InitProducerIdResponse WithProducerEpoch(Int16 producerEpoch)
		{
			ProducerEpoch = producerEpoch;
			return this;
		}
	}

	public class JoinGroupRequest : Message
	{
		public JoinGroupRequest(int version)
		{
			if (version.InRange(0, 5) == false) 
			{
				throw new UnsupportedVersionException($"JoinGroupRequest does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public const int ApiKey = 11;

		public override int Version { get; }

		public static async ValueTask<JoinGroupRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new JoinGroupRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.SessionTimeoutMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.RebalanceTimeoutMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(5, 2147483647)) 
			{
				instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProtocolType = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProtocolsCollection = (await reader.ReadArrayAsync(async () => await JoinGroupRequestProtocol.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(SessionTimeoutMs, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(RebalanceTimeoutMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken);
			}
			if (Version.InRange(5, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(ProtocolType, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ProtocolsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The group identifier.
		/// </summary>
		private String _groupId = String.Default;
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

		public JoinGroupRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		/// <summary>
		/// The coordinator considers the consumer dead if it receives no heartbeat after this timeout in milliseconds.
		/// </summary>
		private Int32 _sessionTimeoutMs = Int32.Default;
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

		public JoinGroupRequest WithSessionTimeoutMs(Int32 sessionTimeoutMs)
		{
			SessionTimeoutMs = sessionTimeoutMs;
			return this;
		}

		/// <summary>
		/// The maximum time in milliseconds that the coordinator will wait for each member to rejoin when rebalancing the group.
		/// </summary>
		private Int32 _rebalanceTimeoutMs = new Int32(-1);
		public Int32 RebalanceTimeoutMs 
		{
			get => _rebalanceTimeoutMs;
			set 
			{
				_rebalanceTimeoutMs = value;
			}
		}

		public JoinGroupRequest WithRebalanceTimeoutMs(Int32 rebalanceTimeoutMs)
		{
			RebalanceTimeoutMs = rebalanceTimeoutMs;
			return this;
		}

		/// <summary>
		/// The member id assigned by the group coordinator.
		/// </summary>
		private String _memberId = String.Default;
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

		public JoinGroupRequest WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}

		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		private String? _groupInstanceId;
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

		public JoinGroupRequest WithGroupInstanceId(String groupInstanceId)
		{
			GroupInstanceId = groupInstanceId;
			return this;
		}

		/// <summary>
		/// The unique name the for class of protocols implemented by the group we want to join.
		/// </summary>
		private String _protocolType = String.Default;
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

		public JoinGroupRequest WithProtocolType(String protocolType)
		{
			ProtocolType = protocolType;
			return this;
		}

		/// <summary>
		/// The list of protocols that the member supports.
		/// </summary>
		private Dictionary<String, JoinGroupRequestProtocol> _protocolsCollection = new Dictionary<String, JoinGroupRequestProtocol>();
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
			internal JoinGroupRequestProtocol(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<JoinGroupRequestProtocol> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new JoinGroupRequestProtocol(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Metadata = await reader.ReadBytesAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteBytesAsync(Metadata, cancellationToken);
				}
			}

			/// <summary>
			/// The protocol name.
			/// </summary>
			private String _name = String.Default;
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

			public JoinGroupRequestProtocol WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The protocol metadata.
			/// </summary>
			private Bytes _metadata = Bytes.Default;
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

			public JoinGroupRequestProtocol WithMetadata(Bytes metadata)
			{
				Metadata = metadata;
				return this;
			}
		}
	}

	public class JoinGroupResponse : Message
	{
		public JoinGroupResponse(int version)
		{
			if (version.InRange(0, 5) == false) 
			{
				throw new UnsupportedVersionException($"JoinGroupResponse does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public const int ApiKey = 11;

		public override int Version { get; }

		public static async ValueTask<JoinGroupResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new JoinGroupResponse(version);
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GenerationId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProtocolName = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Leader = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MembersCollection = await reader.ReadArrayAsync(async () => await JoinGroupResponseMember.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(GenerationId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(ProtocolName, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(Leader, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, MembersCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public JoinGroupResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public JoinGroupResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The generation ID of the group.
		/// </summary>
		private Int32 _generationId = new Int32(-1);
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

		public JoinGroupResponse WithGenerationId(Int32 generationId)
		{
			GenerationId = generationId;
			return this;
		}

		/// <summary>
		/// The group protocol selected by the coordinator.
		/// </summary>
		private String _protocolName = String.Default;
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

		public JoinGroupResponse WithProtocolName(String protocolName)
		{
			ProtocolName = protocolName;
			return this;
		}

		/// <summary>
		/// The leader of the group.
		/// </summary>
		private String _leader = String.Default;
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

		public JoinGroupResponse WithLeader(String leader)
		{
			Leader = leader;
			return this;
		}

		/// <summary>
		/// The member ID assigned by the group coordinator.
		/// </summary>
		private String _memberId = String.Default;
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
			internal JoinGroupResponseMember(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<JoinGroupResponseMember> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new JoinGroupResponseMember(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MemberId = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(5, 2147483647)) 
				{
					instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Metadata = await reader.ReadBytesAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(MemberId, cancellationToken);
				}
				if (Version.InRange(5, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteBytesAsync(Metadata, cancellationToken);
				}
			}

			/// <summary>
			/// The group member ID.
			/// </summary>
			private String _memberId = String.Default;
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

			public JoinGroupResponseMember WithMemberId(String memberId)
			{
				MemberId = memberId;
				return this;
			}

			/// <summary>
			/// The unique identifier of the consumer instance provided by end user.
			/// </summary>
			private String? _groupInstanceId;
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

			public JoinGroupResponseMember WithGroupInstanceId(String groupInstanceId)
			{
				GroupInstanceId = groupInstanceId;
				return this;
			}

			/// <summary>
			/// The group member metadata.
			/// </summary>
			private Bytes _metadata = Bytes.Default;
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

			public JoinGroupResponseMember WithMetadata(Bytes metadata)
			{
				Metadata = metadata;
				return this;
			}
		}
	}

	public class LeaderAndIsrRequest : Message
	{
		public LeaderAndIsrRequest(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"LeaderAndIsrRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 4;

		public override int Version { get; }

		public static async ValueTask<LeaderAndIsrRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new LeaderAndIsrRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerEpoch = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.BrokerEpoch = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 1)) 
			{
				instance.PartitionStatesV0Collection = await reader.ReadArrayAsync(async () => await LeaderAndIsrRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.TopicStatesCollection = await reader.ReadArrayAsync(async () => await LeaderAndIsrRequestTopicState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.LiveLeadersCollection = await reader.ReadArrayAsync(async () => await LeaderAndIsrLiveLeader.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerEpoch, cancellationToken);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt64Async(BrokerEpoch, cancellationToken);
			}
			if (Version.InRange(0, 1)) 
			{
				await writer.WriteArrayAsync(cancellationToken, PartitionStatesV0Collection);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicStatesCollection);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, LiveLeadersCollection);
			}
		}

		/// <summary>
		/// The current controller ID.
		/// </summary>
		private Int32 _controllerId = Int32.Default;
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

		public LeaderAndIsrRequest WithControllerId(Int32 controllerId)
		{
			ControllerId = controllerId;
			return this;
		}

		/// <summary>
		/// The current controller epoch.
		/// </summary>
		private Int32 _controllerEpoch = Int32.Default;
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

		public LeaderAndIsrRequest WithControllerEpoch(Int32 controllerEpoch)
		{
			ControllerEpoch = controllerEpoch;
			return this;
		}

		/// <summary>
		/// The current broker epoch.
		/// </summary>
		private Int64 _brokerEpoch = new Int64(-1);
		public Int64 BrokerEpoch 
		{
			get => _brokerEpoch;
			set 
			{
				_brokerEpoch = value;
			}
		}

		public LeaderAndIsrRequest WithBrokerEpoch(Int64 brokerEpoch)
		{
			BrokerEpoch = brokerEpoch;
			return this;
		}

		/// <summary>
		/// The state of each partition, in a v0 or v1 message.
		/// </summary>
		private LeaderAndIsrRequestPartition[] _partitionStatesV0Collection = Array.Empty<LeaderAndIsrRequestPartition>();
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

		public LeaderAndIsrRequest WithPartitionStatesV0Collection(LeaderAndIsrRequestPartition[] partitionStatesV0Collection)
		{
			PartitionStatesV0Collection = partitionStatesV0Collection;
			return this;
		}

		/// <summary>
		/// Each topic.
		/// </summary>
		private LeaderAndIsrRequestTopicState[] _topicStatesCollection = Array.Empty<LeaderAndIsrRequestTopicState>();
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
			internal LeaderAndIsrRequestTopicState(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<LeaderAndIsrRequestTopicState> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new LeaderAndIsrRequestTopicState(version);
				if (instance.Version.InRange(2, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(2, 2147483647)) 
				{
					instance.PartitionStatesV0Collection = await reader.ReadArrayAsync(async () => await LeaderAndIsrRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(2, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(2, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionStatesV0Collection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public LeaderAndIsrRequestTopicState WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The state of each partition
			/// </summary>
			private LeaderAndIsrRequestPartition[] _partitionStatesV0Collection = Array.Empty<LeaderAndIsrRequestPartition>();
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

			public LeaderAndIsrRequestTopicState WithPartitionStatesV0Collection(LeaderAndIsrRequestPartition[] partitionStatesV0Collection)
			{
				PartitionStatesV0Collection = partitionStatesV0Collection;
				return this;
			}
		}

		/// <summary>
		/// The current live leaders.
		/// </summary>
		private LeaderAndIsrLiveLeader[] _liveLeadersCollection = Array.Empty<LeaderAndIsrLiveLeader>();
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
			internal LeaderAndIsrLiveLeader(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<LeaderAndIsrLiveLeader> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new LeaderAndIsrLiveLeader(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.BrokerId = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.HostName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Port = await reader.ReadInt32Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(BrokerId, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(HostName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(Port, cancellationToken);
				}
			}

			/// <summary>
			/// The leader's broker ID.
			/// </summary>
			private Int32 _brokerId = Int32.Default;
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

			public LeaderAndIsrLiveLeader WithBrokerId(Int32 brokerId)
			{
				BrokerId = brokerId;
				return this;
			}

			/// <summary>
			/// The leader's hostname.
			/// </summary>
			private String _hostName = String.Default;
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

			public LeaderAndIsrLiveLeader WithHostName(String hostName)
			{
				HostName = hostName;
				return this;
			}

			/// <summary>
			/// The leader's port.
			/// </summary>
			private Int32 _port = Int32.Default;
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

			public LeaderAndIsrLiveLeader WithPort(Int32 port)
			{
				Port = port;
				return this;
			}
		}

		public class LeaderAndIsrRequestPartition : ISerialize
		{
			internal LeaderAndIsrRequestPartition(int version)
			{
				if (version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"LeaderAndIsrRequestPartition does not support version {version}. Valid versions are: 0+");
				}

				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<LeaderAndIsrRequestPartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new LeaderAndIsrRequestPartition(version);
				if (instance.Version.InRange(0, 1)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ControllerEpoch = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.LeaderKey = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.IsrReplicasCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ZkVersion = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ReplicasCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.IsNew = await reader.ReadBooleanAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 1)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(ControllerEpoch, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(LeaderKey, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(LeaderEpoch, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, IsrReplicasCollection);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(ZkVersion, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ReplicasCollection);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteBooleanAsync(IsNew, cancellationToken);
				}
			}

			/// <summary>
			/// The topic name.  This is only present in v0 or v1.
			/// </summary>
			private String _topicName = String.Default;
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

			public LeaderAndIsrRequestPartition WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			/// <summary>
			/// The partition index.
			/// </summary>
			private Int32 _partitionIndex = Int32.Default;
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

			public LeaderAndIsrRequestPartition WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}

			/// <summary>
			/// The controller epoch.
			/// </summary>
			private Int32 _controllerEpoch = Int32.Default;
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

			public LeaderAndIsrRequestPartition WithControllerEpoch(Int32 controllerEpoch)
			{
				ControllerEpoch = controllerEpoch;
				return this;
			}

			/// <summary>
			/// The broker ID of the leader.
			/// </summary>
			private Int32 _leaderKey = Int32.Default;
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

			public LeaderAndIsrRequestPartition WithLeaderKey(Int32 leaderKey)
			{
				LeaderKey = leaderKey;
				return this;
			}

			/// <summary>
			/// The leader epoch.
			/// </summary>
			private Int32 _leaderEpoch = Int32.Default;
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

			public LeaderAndIsrRequestPartition WithLeaderEpoch(Int32 leaderEpoch)
			{
				LeaderEpoch = leaderEpoch;
				return this;
			}

			/// <summary>
			/// The in-sync replica IDs.
			/// </summary>
			private Int32[] _isrReplicasCollection = Array.Empty<Int32>();
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

			public LeaderAndIsrRequestPartition WithIsrReplicasCollection(Int32[] isrReplicasCollection)
			{
				IsrReplicasCollection = isrReplicasCollection;
				return this;
			}

			/// <summary>
			/// The ZooKeeper version.
			/// </summary>
			private Int32 _zkVersion = Int32.Default;
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

			public LeaderAndIsrRequestPartition WithZkVersion(Int32 zkVersion)
			{
				ZkVersion = zkVersion;
				return this;
			}

			/// <summary>
			/// The replica IDs.
			/// </summary>
			private Int32[] _replicasCollection = Array.Empty<Int32>();
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

			public LeaderAndIsrRequestPartition WithReplicasCollection(Int32[] replicasCollection)
			{
				ReplicasCollection = replicasCollection;
				return this;
			}

			/// <summary>
			/// Whether the replica should have existed on the broker or not.
			/// </summary>
			private Boolean _isNew = new Boolean(false);
			public Boolean IsNew 
			{
				get => _isNew;
				set 
				{
					_isNew = value;
				}
			}

			public LeaderAndIsrRequestPartition WithIsNew(Boolean isNew)
			{
				IsNew = isNew;
				return this;
			}
		}
	}

	public class LeaderAndIsrResponse : Message
	{
		public LeaderAndIsrResponse(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"LeaderAndIsrResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 4;

		public override int Version { get; }

		public static async ValueTask<LeaderAndIsrResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new LeaderAndIsrResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await LeaderAndIsrResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public LeaderAndIsrResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// Each partition.
		/// </summary>
		private LeaderAndIsrResponsePartition[] _partitionsCollection = Array.Empty<LeaderAndIsrResponsePartition>();
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
			internal LeaderAndIsrResponsePartition(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<LeaderAndIsrResponsePartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new LeaderAndIsrResponsePartition(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _topicName = String.Default;
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

			public LeaderAndIsrResponsePartition WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			/// <summary>
			/// The partition index.
			/// </summary>
			private Int32 _partitionIndex = Int32.Default;
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

			public LeaderAndIsrResponsePartition WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}

			/// <summary>
			/// The partition error code, or 0 if there was no error.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public LeaderAndIsrResponsePartition WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}
		}
	}

	public class LeaveGroupRequest : Message
	{
		public LeaveGroupRequest(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"LeaveGroupRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 13;

		public override int Version { get; }

		public static async ValueTask<LeaveGroupRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new LeaveGroupRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken);
			}
		}

		/// <summary>
		/// The ID of the group to leave.
		/// </summary>
		private String _groupId = String.Default;
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

		public LeaveGroupRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		/// <summary>
		/// The member ID to remove from the group.
		/// </summary>
		private String _memberId = String.Default;
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

		public LeaveGroupRequest WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}
	}

	public class LeaveGroupResponse : Message
	{
		public LeaveGroupResponse(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"LeaveGroupResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 13;

		public override int Version { get; }

		public static async ValueTask<LeaveGroupResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new LeaveGroupResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public LeaveGroupResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public LeaveGroupResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class ListGroupsRequest : Message
	{
		public ListGroupsRequest(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"ListGroupsRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 16;

		public override int Version { get; }

		public static async ValueTask<ListGroupsRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ListGroupsRequest(version);

			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			await Task.CompletedTask;
		}
	}

	public class ListGroupsResponse : Message
	{
		public ListGroupsResponse(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"ListGroupsResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 16;

		public override int Version { get; }

		public static async ValueTask<ListGroupsResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ListGroupsResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupsCollection = await reader.ReadArrayAsync(async () => await ListedGroup.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, GroupsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public ListGroupsResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public ListGroupsResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// Each group in the response.
		/// </summary>
		private ListedGroup[] _groupsCollection = Array.Empty<ListedGroup>();
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
			internal ListedGroup(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<ListedGroup> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ListedGroup(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.GroupId = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProtocolType = await reader.ReadStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(GroupId, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(ProtocolType, cancellationToken);
				}
			}

			/// <summary>
			/// The group ID.
			/// </summary>
			private String _groupId = String.Default;
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

			public ListedGroup WithGroupId(String groupId)
			{
				GroupId = groupId;
				return this;
			}

			/// <summary>
			/// The group protocol type.
			/// </summary>
			private String _protocolType = String.Default;
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

			public ListedGroup WithProtocolType(String protocolType)
			{
				ProtocolType = protocolType;
				return this;
			}
		}
	}

	public class ListOffsetRequest : Message
	{
		public ListOffsetRequest(int version)
		{
			if (version.InRange(0, 5) == false) 
			{
				throw new UnsupportedVersionException($"ListOffsetRequest does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public const int ApiKey = 2;

		public override int Version { get; }

		public static async ValueTask<ListOffsetRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ListOffsetRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ReplicaId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.IsolationLevel = await reader.ReadInt8Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await ListOffsetTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ReplicaId, cancellationToken);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt8Async(IsolationLevel, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The broker ID of the requestor, or -1 if this request is being made by a normal consumer.
		/// </summary>
		private Int32 _replicaId = Int32.Default;
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

		public ListOffsetRequest WithReplicaId(Int32 replicaId)
		{
			ReplicaId = replicaId;
			return this;
		}

		/// <summary>
		/// This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records
		/// </summary>
		private Int8 _isolationLevel = Int8.Default;
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

		public ListOffsetRequest WithIsolationLevel(Int8 isolationLevel)
		{
			IsolationLevel = isolationLevel;
			return this;
		}

		/// <summary>
		/// Each topic in the request.
		/// </summary>
		private ListOffsetTopic[] _topicsCollection = Array.Empty<ListOffsetTopic>();
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
			internal ListOffsetTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<ListOffsetTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ListOffsetTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await ListOffsetPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public ListOffsetTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// Each partition in the request.
			/// </summary>
			private ListOffsetPartition[] _partitionsCollection = Array.Empty<ListOffsetPartition>();
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
				internal ListOffsetPartition(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<ListOffsetPartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new ListOffsetPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(4, 2147483647)) 
					{
						instance.CurrentLeaderEpoch = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Timestamp = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 0)) 
					{
						instance.MaxNumOffsets = await reader.ReadInt32Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(4, 2147483647)) 
					{
						await writer.WriteInt32Async(CurrentLeaderEpoch, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(Timestamp, cancellationToken);
					}
					if (Version.InRange(0, 0)) 
					{
						await writer.WriteInt32Async(MaxNumOffsets, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public ListOffsetPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The current leader epoch.
				/// </summary>
				private Int32 _currentLeaderEpoch = Int32.Default;
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

				public ListOffsetPartition WithCurrentLeaderEpoch(Int32 currentLeaderEpoch)
				{
					CurrentLeaderEpoch = currentLeaderEpoch;
					return this;
				}

				/// <summary>
				/// The current timestamp.
				/// </summary>
				private Int64 _timestamp = Int64.Default;
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

				public ListOffsetPartition WithTimestamp(Int64 timestamp)
				{
					Timestamp = timestamp;
					return this;
				}

				/// <summary>
				/// The maximum number of offsets to report.
				/// </summary>
				private Int32 _maxNumOffsets = Int32.Default;
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

				public ListOffsetPartition WithMaxNumOffsets(Int32 maxNumOffsets)
				{
					MaxNumOffsets = maxNumOffsets;
					return this;
				}
			}
		}
	}

	public class ListOffsetResponse : Message
	{
		public ListOffsetResponse(int version)
		{
			if (version.InRange(0, 5) == false) 
			{
				throw new UnsupportedVersionException($"ListOffsetResponse does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public const int ApiKey = 2;

		public override int Version { get; }

		public static async ValueTask<ListOffsetResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ListOffsetResponse(version);
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await ListOffsetTopicResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public ListOffsetResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// Each topic in the response.
		/// </summary>
		private ListOffsetTopicResponse[] _topicsCollection = Array.Empty<ListOffsetTopicResponse>();
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
			internal ListOffsetTopicResponse(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<ListOffsetTopicResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new ListOffsetTopicResponse(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await ListOffsetPartitionResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			private String _name = String.Default;
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

			public ListOffsetTopicResponse WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// Each partition in the response.
			/// </summary>
			private ListOffsetPartitionResponse[] _partitionsCollection = Array.Empty<ListOffsetPartitionResponse>();
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
				internal ListOffsetPartitionResponse(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<ListOffsetPartitionResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new ListOffsetPartitionResponse(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 0)) 
					{
						instance.OldStyleOffsetsCollection = await reader.ReadArrayAsync(async () => await Int64.FromReaderAsync(reader, cancellationToken), cancellationToken);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.Timestamp = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.Offset = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(4, 2147483647)) 
					{
						instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
					if (Version.InRange(0, 0)) 
					{
						await writer.WriteArrayAsync(cancellationToken, OldStyleOffsetsCollection);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt64Async(Timestamp, cancellationToken);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt64Async(Offset, cancellationToken);
					}
					if (Version.InRange(4, 2147483647)) 
					{
						await writer.WriteInt32Async(LeaderEpoch, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public ListOffsetPartitionResponse WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The partition error code, or 0 if there was no error.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public ListOffsetPartitionResponse WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				/// <summary>
				/// The result offsets.
				/// </summary>
				private Int64[] _oldStyleOffsetsCollection = Array.Empty<Int64>();
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

				public ListOffsetPartitionResponse WithOldStyleOffsetsCollection(Int64[] oldStyleOffsetsCollection)
				{
					OldStyleOffsetsCollection = oldStyleOffsetsCollection;
					return this;
				}

				/// <summary>
				/// The timestamp associated with the returned offset.
				/// </summary>
				private Int64 _timestamp = new Int64(-1);
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

				public ListOffsetPartitionResponse WithTimestamp(Int64 timestamp)
				{
					Timestamp = timestamp;
					return this;
				}

				/// <summary>
				/// The returned offset.
				/// </summary>
				private Int64 _offset = new Int64(-1);
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

	public class MetadataRequest : Message
	{
		public MetadataRequest(int version)
		{
			if (version.InRange(0, 8) == false) 
			{
				throw new UnsupportedVersionException($"MetadataRequest does not support version {version}. Valid versions are: 0-8");
			}

			Version = version;
		}

		public const int ApiKey = 3;

		public override int Version { get; }

		public static async ValueTask<MetadataRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new MetadataRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadNullableArrayAsync(async () => await MetadataRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(4, 2147483647)) 
			{
				instance.AllowAutoTopicCreation = await reader.ReadBooleanAsync(cancellationToken);
			}
			if (instance.Version.InRange(8, 2147483647)) 
			{
				instance.IncludeClusterAuthorizedOperations = await reader.ReadBooleanAsync(cancellationToken);
			}
			if (instance.Version.InRange(8, 2147483647)) 
			{
				instance.IncludeTopicAuthorizedOperations = await reader.ReadBooleanAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableArrayAsync(cancellationToken, TopicsCollection);
			}
			if (Version.InRange(4, 2147483647)) 
			{
				await writer.WriteBooleanAsync(AllowAutoTopicCreation, cancellationToken);
			}
			if (Version.InRange(8, 2147483647)) 
			{
				await writer.WriteBooleanAsync(IncludeClusterAuthorizedOperations, cancellationToken);
			}
			if (Version.InRange(8, 2147483647)) 
			{
				await writer.WriteBooleanAsync(IncludeTopicAuthorizedOperations, cancellationToken);
			}
		}

		/// <summary>
		/// The topics to fetch metadata for.
		/// </summary>
		private MetadataRequestTopic[]? _topicsCollection = Array.Empty<MetadataRequestTopic>();
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
			internal MetadataRequestTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<MetadataRequestTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new MetadataRequestTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public MetadataRequestTopic WithName(String name)
			{
				Name = name;
				return this;
			}
		}

		/// <summary>
		/// If this is true, the broker may auto-create topics that we requested which do not already exist, if it is configured to do so.
		/// </summary>
		private Boolean _allowAutoTopicCreation = new Boolean(true);
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

		public MetadataRequest WithAllowAutoTopicCreation(Boolean allowAutoTopicCreation)
		{
			AllowAutoTopicCreation = allowAutoTopicCreation;
			return this;
		}

		/// <summary>
		/// Whether to include cluster authorized operations.
		/// </summary>
		private Boolean _includeClusterAuthorizedOperations = Boolean.Default;
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

		public MetadataRequest WithIncludeClusterAuthorizedOperations(Boolean includeClusterAuthorizedOperations)
		{
			IncludeClusterAuthorizedOperations = includeClusterAuthorizedOperations;
			return this;
		}

		/// <summary>
		/// Whether to include topic authorized operations.
		/// </summary>
		private Boolean _includeTopicAuthorizedOperations = Boolean.Default;
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

		public MetadataRequest WithIncludeTopicAuthorizedOperations(Boolean includeTopicAuthorizedOperations)
		{
			IncludeTopicAuthorizedOperations = includeTopicAuthorizedOperations;
			return this;
		}
	}

	public class MetadataResponse : Message
	{
		public MetadataResponse(int version)
		{
			if (version.InRange(0, 8) == false) 
			{
				throw new UnsupportedVersionException($"MetadataResponse does not support version {version}. Valid versions are: 0-8");
			}

			Version = version;
		}

		public const int ApiKey = 3;

		public override int Version { get; }

		public static async ValueTask<MetadataResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new MetadataResponse(version);
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.BrokersCollection = (await reader.ReadArrayAsync(async () => await MetadataResponseBroker.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.NodeId);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ClusterId = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ControllerId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = (await reader.ReadArrayAsync(async () => await MetadataResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken)).ToDictionary(field => field.Name);
			}
			if (instance.Version.InRange(8, 2147483647)) 
			{
				instance.ClusterAuthorizedOperations = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, BrokersCollection.Values.ToArray());
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(ClusterId, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection.Values.ToArray());
			}
			if (Version.InRange(8, 2147483647)) 
			{
				await writer.WriteInt32Async(ClusterAuthorizedOperations, cancellationToken);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public MetadataResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// Each broker in the response.
		/// </summary>
		private Dictionary<Int32, MetadataResponseBroker> _brokersCollection = new Dictionary<Int32, MetadataResponseBroker>();
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
			internal MetadataResponseBroker(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<MetadataResponseBroker> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new MetadataResponseBroker(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.NodeId = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Host = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Port = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.Rack = await reader.ReadNullableStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(NodeId, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Host, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(Port, cancellationToken);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(Rack, cancellationToken);
				}
			}

			/// <summary>
			/// The broker ID.
			/// </summary>
			private Int32 _nodeId = Int32.Default;
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

			public MetadataResponseBroker WithNodeId(Int32 nodeId)
			{
				NodeId = nodeId;
				return this;
			}

			/// <summary>
			/// The broker hostname.
			/// </summary>
			private String _host = String.Default;
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

			public MetadataResponseBroker WithHost(String host)
			{
				Host = host;
				return this;
			}

			/// <summary>
			/// The broker port.
			/// </summary>
			private Int32 _port = Int32.Default;
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

			public MetadataResponseBroker WithPort(Int32 port)
			{
				Port = port;
				return this;
			}

			/// <summary>
			/// The rack of the broker, or null if it has not been assigned to a rack.
			/// </summary>
			private String? _rack;
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

			public MetadataResponseBroker WithRack(String rack)
			{
				Rack = rack;
				return this;
			}
		}

		/// <summary>
		/// The cluster ID that responding broker belongs to.
		/// </summary>
		private String? _clusterId;
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

		public MetadataResponse WithClusterId(String clusterId)
		{
			ClusterId = clusterId;
			return this;
		}

		/// <summary>
		/// The ID of the controller broker.
		/// </summary>
		private Int32 _controllerId = new Int32(-1);
		public Int32 ControllerId 
		{
			get => _controllerId;
			set 
			{
				_controllerId = value;
			}
		}

		public MetadataResponse WithControllerId(Int32 controllerId)
		{
			ControllerId = controllerId;
			return this;
		}

		/// <summary>
		/// Each topic in the response.
		/// </summary>
		private Dictionary<String, MetadataResponseTopic> _topicsCollection = new Dictionary<String, MetadataResponseTopic>();
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
			internal MetadataResponseTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<MetadataResponseTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new MetadataResponseTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.IsInternal = await reader.ReadBooleanAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await MetadataResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				if (instance.Version.InRange(8, 2147483647)) 
				{
					instance.TopicAuthorizedOperations = await reader.ReadInt32Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteBooleanAsync(IsInternal, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
				if (Version.InRange(8, 2147483647)) 
				{
					await writer.WriteInt32Async(TopicAuthorizedOperations, cancellationToken);
				}
			}

			/// <summary>
			/// The topic error, or 0 if there was no error.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public MetadataResponseTopic WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public MetadataResponseTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// True if the topic is internal.
			/// </summary>
			private Boolean _isInternal = new Boolean(false);
			public Boolean IsInternal 
			{
				get => _isInternal;
				set 
				{
					_isInternal = value;
				}
			}

			public MetadataResponseTopic WithIsInternal(Boolean isInternal)
			{
				IsInternal = isInternal;
				return this;
			}

			/// <summary>
			/// Each partition in the topic.
			/// </summary>
			private MetadataResponsePartition[] _partitionsCollection = Array.Empty<MetadataResponsePartition>();
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
				internal MetadataResponsePartition(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<MetadataResponsePartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new MetadataResponsePartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.LeaderId = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(7, 2147483647)) 
					{
						instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ReplicaNodesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.IsrNodesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
					}
					if (instance.Version.InRange(5, 2147483647)) 
					{
						instance.OfflineReplicasCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(LeaderId, cancellationToken);
					}
					if (Version.InRange(7, 2147483647)) 
					{
						await writer.WriteInt32Async(LeaderEpoch, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, ReplicaNodesCollection);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, IsrNodesCollection);
					}
					if (Version.InRange(5, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, OfflineReplicasCollection);
					}
				}

				/// <summary>
				/// The partition error, or 0 if there was no error.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public MetadataResponsePartition WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public MetadataResponsePartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The ID of the leader broker.
				/// </summary>
				private Int32 _leaderId = Int32.Default;
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

				public MetadataResponsePartition WithLeaderId(Int32 leaderId)
				{
					LeaderId = leaderId;
					return this;
				}

				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				private Int32 _leaderEpoch = new Int32(-1);
				public Int32 LeaderEpoch 
				{
					get => _leaderEpoch;
					set 
					{
						_leaderEpoch = value;
					}
				}

				public MetadataResponsePartition WithLeaderEpoch(Int32 leaderEpoch)
				{
					LeaderEpoch = leaderEpoch;
					return this;
				}

				/// <summary>
				/// The set of all nodes that host this partition.
				/// </summary>
				private Int32[] _replicaNodesCollection = Array.Empty<Int32>();
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

				public MetadataResponsePartition WithReplicaNodesCollection(Int32[] replicaNodesCollection)
				{
					ReplicaNodesCollection = replicaNodesCollection;
					return this;
				}

				/// <summary>
				/// The set of nodes that are in sync with the leader for this partition.
				/// </summary>
				private Int32[] _isrNodesCollection = Array.Empty<Int32>();
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

				public MetadataResponsePartition WithIsrNodesCollection(Int32[] isrNodesCollection)
				{
					IsrNodesCollection = isrNodesCollection;
					return this;
				}

				/// <summary>
				/// The set of offline replicas of this partition.
				/// </summary>
				private Int32[] _offlineReplicasCollection = Array.Empty<Int32>();
				public Int32[] OfflineReplicasCollection 
				{
					get => _offlineReplicasCollection;
					set 
					{
						_offlineReplicasCollection = value;
					}
				}

				public MetadataResponsePartition WithOfflineReplicasCollection(Int32[] offlineReplicasCollection)
				{
					OfflineReplicasCollection = offlineReplicasCollection;
					return this;
				}
			}

			/// <summary>
			/// 32-bit bitfield to represent authorized operations for this topic.
			/// </summary>
			private Int32 _topicAuthorizedOperations = new Int32(-2147483648);
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

			public MetadataResponseTopic WithTopicAuthorizedOperations(Int32 topicAuthorizedOperations)
			{
				TopicAuthorizedOperations = topicAuthorizedOperations;
				return this;
			}
		}

		/// <summary>
		/// 32-bit bitfield to represent authorized operations for this cluster.
		/// </summary>
		private Int32 _clusterAuthorizedOperations = new Int32(-2147483648);
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

		public MetadataResponse WithClusterAuthorizedOperations(Int32 clusterAuthorizedOperations)
		{
			ClusterAuthorizedOperations = clusterAuthorizedOperations;
			return this;
		}
	}

	public class OffsetCommitRequest : Message
	{
		public OffsetCommitRequest(int version)
		{
			if (version.InRange(0, 7) == false) 
			{
				throw new UnsupportedVersionException($"OffsetCommitRequest does not support version {version}. Valid versions are: 0-7");
			}

			Version = version;
		}

		public const int ApiKey = 8;

		public override int Version { get; }

		public static async ValueTask<OffsetCommitRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetCommitRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.GenerationId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(7, 2147483647)) 
			{
				instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(2, 4)) 
			{
				instance.RetentionTimeMs = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await OffsetCommitRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(GenerationId, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken);
			}
			if (Version.InRange(7, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken);
			}
			if (Version.InRange(2, 4)) 
			{
				await writer.WriteInt64Async(RetentionTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The unique group identifier.
		/// </summary>
		private String _groupId = String.Default;
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

		public OffsetCommitRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		/// <summary>
		/// The generation of the group.
		/// </summary>
		private Int32 _generationId = new Int32(-1);
		public Int32 GenerationId 
		{
			get => _generationId;
			set 
			{
				_generationId = value;
			}
		}

		public OffsetCommitRequest WithGenerationId(Int32 generationId)
		{
			GenerationId = generationId;
			return this;
		}

		/// <summary>
		/// The member ID assigned by the group coordinator.
		/// </summary>
		private String _memberId = String.Default;
		public String MemberId 
		{
			get => _memberId;
			set 
			{
				_memberId = value;
			}
		}

		public OffsetCommitRequest WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}

		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		private String? _groupInstanceId;
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

		public OffsetCommitRequest WithGroupInstanceId(String groupInstanceId)
		{
			GroupInstanceId = groupInstanceId;
			return this;
		}

		/// <summary>
		/// The time period in ms to retain the offset.
		/// </summary>
		private Int64 _retentionTimeMs = new Int64(-1);
		public Int64 RetentionTimeMs 
		{
			get => _retentionTimeMs;
			set 
			{
				_retentionTimeMs = value;
			}
		}

		public OffsetCommitRequest WithRetentionTimeMs(Int64 retentionTimeMs)
		{
			RetentionTimeMs = retentionTimeMs;
			return this;
		}

		/// <summary>
		/// The topics to commit offsets for.
		/// </summary>
		private OffsetCommitRequestTopic[] _topicsCollection = Array.Empty<OffsetCommitRequestTopic>();
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
			internal OffsetCommitRequestTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<OffsetCommitRequestTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetCommitRequestTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await OffsetCommitRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public OffsetCommitRequestTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// Each partition to commit offsets for.
			/// </summary>
			private OffsetCommitRequestPartition[] _partitionsCollection = Array.Empty<OffsetCommitRequestPartition>();
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
				internal OffsetCommitRequestPartition(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<OffsetCommitRequestPartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new OffsetCommitRequestPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.CommittedOffset = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(6, 2147483647)) 
					{
						instance.CommittedLeaderEpoch = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(1, 1)) 
					{
						instance.CommitTimestamp = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.CommittedMetadata = await reader.ReadNullableStringAsync(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(CommittedOffset, cancellationToken);
					}
					if (Version.InRange(6, 2147483647)) 
					{
						await writer.WriteInt32Async(CommittedLeaderEpoch, cancellationToken);
					}
					if (Version.InRange(1, 1)) 
					{
						await writer.WriteInt64Async(CommitTimestamp, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(CommittedMetadata, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public OffsetCommitRequestPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The message offset to be committed.
				/// </summary>
				private Int64 _committedOffset = Int64.Default;
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

				public OffsetCommitRequestPartition WithCommittedOffset(Int64 committedOffset)
				{
					CommittedOffset = committedOffset;
					return this;
				}

				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				private Int32 _committedLeaderEpoch = new Int32(-1);
				public Int32 CommittedLeaderEpoch 
				{
					get => _committedLeaderEpoch;
					set 
					{
						_committedLeaderEpoch = value;
					}
				}

				public OffsetCommitRequestPartition WithCommittedLeaderEpoch(Int32 committedLeaderEpoch)
				{
					CommittedLeaderEpoch = committedLeaderEpoch;
					return this;
				}

				/// <summary>
				/// The timestamp of the commit.
				/// </summary>
				private Int64 _commitTimestamp = new Int64(-1);
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

				public OffsetCommitRequestPartition WithCommitTimestamp(Int64 commitTimestamp)
				{
					CommitTimestamp = commitTimestamp;
					return this;
				}

				/// <summary>
				/// Any associated metadata the client wants to keep.
				/// </summary>
				private String? _committedMetadata = String.Default;
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

				public OffsetCommitRequestPartition WithCommittedMetadata(String committedMetadata)
				{
					CommittedMetadata = committedMetadata;
					return this;
				}
			}
		}
	}

	public class OffsetCommitResponse : Message
	{
		public OffsetCommitResponse(int version)
		{
			if (version.InRange(0, 7) == false) 
			{
				throw new UnsupportedVersionException($"OffsetCommitResponse does not support version {version}. Valid versions are: 0-7");
			}

			Version = version;
		}

		public const int ApiKey = 8;

		public override int Version { get; }

		public static async ValueTask<OffsetCommitResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetCommitResponse(version);
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await OffsetCommitResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public OffsetCommitResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The responses for each topic.
		/// </summary>
		private OffsetCommitResponseTopic[] _topicsCollection = Array.Empty<OffsetCommitResponseTopic>();
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
			internal OffsetCommitResponseTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<OffsetCommitResponseTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetCommitResponseTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await OffsetCommitResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public OffsetCommitResponseTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The responses for each partition in the topic.
			/// </summary>
			private OffsetCommitResponsePartition[] _partitionsCollection = Array.Empty<OffsetCommitResponsePartition>();
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
				internal OffsetCommitResponsePartition(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<OffsetCommitResponsePartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new OffsetCommitResponsePartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public OffsetCommitResponsePartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public OffsetCommitResponsePartition WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}
	}

	public class OffsetFetchRequest : Message
	{
		public OffsetFetchRequest(int version)
		{
			if (version.InRange(0, 5) == false) 
			{
				throw new UnsupportedVersionException($"OffsetFetchRequest does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public const int ApiKey = 9;

		public override int Version { get; }

		public static async ValueTask<OffsetFetchRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetFetchRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadNullableArrayAsync(async () => await OffsetFetchRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The group to fetch offsets for.
		/// </summary>
		private String _groupId = String.Default;
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

		public OffsetFetchRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		/// <summary>
		/// Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.
		/// </summary>
		private OffsetFetchRequestTopic[]? _topicsCollection = Array.Empty<OffsetFetchRequestTopic>();
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
			internal OffsetFetchRequestTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<OffsetFetchRequestTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetFetchRequestTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndexesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionIndexesCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public OffsetFetchRequestTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The partition indexes we would like to fetch offsets for.
			/// </summary>
			private Int32[] _partitionIndexesCollection = Array.Empty<Int32>();
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

			public OffsetFetchRequestTopic WithPartitionIndexesCollection(Int32[] partitionIndexesCollection)
			{
				PartitionIndexesCollection = partitionIndexesCollection;
				return this;
			}
		}
	}

	public class OffsetFetchResponse : Message
	{
		public OffsetFetchResponse(int version)
		{
			if (version.InRange(0, 5) == false) 
			{
				throw new UnsupportedVersionException($"OffsetFetchResponse does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public const int ApiKey = 9;

		public override int Version { get; }

		public static async ValueTask<OffsetFetchResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetFetchResponse(version);
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await OffsetFetchResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public OffsetFetchResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The responses per topic.
		/// </summary>
		private OffsetFetchResponseTopic[] _topicsCollection = Array.Empty<OffsetFetchResponseTopic>();
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
			internal OffsetFetchResponseTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<OffsetFetchResponseTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetFetchResponseTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await OffsetFetchResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public OffsetFetchResponseTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The responses per partition
			/// </summary>
			private OffsetFetchResponsePartition[] _partitionsCollection = Array.Empty<OffsetFetchResponsePartition>();
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
				internal OffsetFetchResponsePartition(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<OffsetFetchResponsePartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new OffsetFetchResponsePartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.CommittedOffset = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(5, 2147483647)) 
					{
						instance.CommittedLeaderEpoch = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Metadata = await reader.ReadNullableStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(CommittedOffset, cancellationToken);
					}
					if (Version.InRange(5, 2147483647)) 
					{
						await writer.WriteInt32Async(CommittedLeaderEpoch, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(Metadata, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public OffsetFetchResponsePartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The committed message offset.
				/// </summary>
				private Int64 _committedOffset = Int64.Default;
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

				public OffsetFetchResponsePartition WithCommittedOffset(Int64 committedOffset)
				{
					CommittedOffset = committedOffset;
					return this;
				}

				/// <summary>
				/// The leader epoch.
				/// </summary>
				private Int32 _committedLeaderEpoch = Int32.Default;
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

				public OffsetFetchResponsePartition WithCommittedLeaderEpoch(Int32 committedLeaderEpoch)
				{
					CommittedLeaderEpoch = committedLeaderEpoch;
					return this;
				}

				/// <summary>
				/// The partition metadata.
				/// </summary>
				private String? _metadata = String.Default;
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

				public OffsetFetchResponsePartition WithMetadata(String metadata)
				{
					Metadata = metadata;
					return this;
				}

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public OffsetFetchResponsePartition WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}

		/// <summary>
		/// The top-level error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = new Int16(0);
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

		public OffsetFetchResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class OffsetForLeaderEpochRequest : Message
	{
		public OffsetForLeaderEpochRequest(int version)
		{
			if (version.InRange(0, 3) == false) 
			{
				throw new UnsupportedVersionException($"OffsetForLeaderEpochRequest does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public const int ApiKey = 23;

		public override int Version { get; }

		public static async ValueTask<OffsetForLeaderEpochRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetForLeaderEpochRequest(version);
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.ReplicaId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await OffsetForLeaderTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteInt32Async(ReplicaId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The broker ID of the follower, of -1 if this request is from a consumer.
		/// </summary>
		private Int32 _replicaId = new Int32(-2);
		public Int32 ReplicaId 
		{
			get => _replicaId;
			set 
			{
				_replicaId = value;
			}
		}

		public OffsetForLeaderEpochRequest WithReplicaId(Int32 replicaId)
		{
			ReplicaId = replicaId;
			return this;
		}

		/// <summary>
		/// Each topic to get offsets for.
		/// </summary>
		private OffsetForLeaderTopic[] _topicsCollection = Array.Empty<OffsetForLeaderTopic>();
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
			internal OffsetForLeaderTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<OffsetForLeaderTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetForLeaderTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await OffsetForLeaderPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public OffsetForLeaderTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// Each partition to get offsets for.
			/// </summary>
			private OffsetForLeaderPartition[] _partitionsCollection = Array.Empty<OffsetForLeaderPartition>();
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
				internal OffsetForLeaderPartition(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<OffsetForLeaderPartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new OffsetForLeaderPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(2, 2147483647)) 
					{
						instance.CurrentLeaderEpoch = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(2, 2147483647)) 
					{
						await writer.WriteInt32Async(CurrentLeaderEpoch, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(LeaderEpoch, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public OffsetForLeaderPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// An epoch used to fence consumers/replicas with old metadata.  If the epoch provided by the client is larger than the current epoch known to the broker, then the UNKNOWN_LEADER_EPOCH error code will be returned. If the provided epoch is smaller, then the FENCED_LEADER_EPOCH error code will be returned.
				/// </summary>
				private Int32 _currentLeaderEpoch = new Int32(-1);
				public Int32 CurrentLeaderEpoch 
				{
					get => _currentLeaderEpoch;
					set 
					{
						_currentLeaderEpoch = value;
					}
				}

				public OffsetForLeaderPartition WithCurrentLeaderEpoch(Int32 currentLeaderEpoch)
				{
					CurrentLeaderEpoch = currentLeaderEpoch;
					return this;
				}

				/// <summary>
				/// The epoch to look up an offset for.
				/// </summary>
				private Int32 _leaderEpoch = Int32.Default;
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

				public OffsetForLeaderPartition WithLeaderEpoch(Int32 leaderEpoch)
				{
					LeaderEpoch = leaderEpoch;
					return this;
				}
			}
		}
	}

	public class OffsetForLeaderEpochResponse : Message
	{
		public OffsetForLeaderEpochResponse(int version)
		{
			if (version.InRange(0, 3) == false) 
			{
				throw new UnsupportedVersionException($"OffsetForLeaderEpochResponse does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public const int ApiKey = 23;

		public override int Version { get; }

		public static async ValueTask<OffsetForLeaderEpochResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new OffsetForLeaderEpochResponse(version);
			if (instance.Version.InRange(2, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await OffsetForLeaderTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(2, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public OffsetForLeaderEpochResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// Each topic we fetched offsets for.
		/// </summary>
		private OffsetForLeaderTopicResult[] _topicsCollection = Array.Empty<OffsetForLeaderTopicResult>();
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
			internal OffsetForLeaderTopicResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<OffsetForLeaderTopicResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new OffsetForLeaderTopicResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await OffsetForLeaderPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public OffsetForLeaderTopicResult WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// Each partition in the topic we fetched offsets for.
			/// </summary>
			private OffsetForLeaderPartitionResult[] _partitionsCollection = Array.Empty<OffsetForLeaderPartitionResult>();
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
				internal OffsetForLeaderPartitionResult(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<OffsetForLeaderPartitionResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new OffsetForLeaderPartitionResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.EndOffset = await reader.ReadInt64Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt32Async(LeaderEpoch, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(EndOffset, cancellationToken);
					}
				}

				/// <summary>
				/// The error code 0, or if there was no error.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public OffsetForLeaderPartitionResult WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public OffsetForLeaderPartitionResult WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The leader epoch of the partition.
				/// </summary>
				private Int32 _leaderEpoch = new Int32(-1);
				public Int32 LeaderEpoch 
				{
					get => _leaderEpoch;
					set 
					{
						_leaderEpoch = value;
					}
				}

				public OffsetForLeaderPartitionResult WithLeaderEpoch(Int32 leaderEpoch)
				{
					LeaderEpoch = leaderEpoch;
					return this;
				}

				/// <summary>
				/// The end offset of the epoch.
				/// </summary>
				private Int64 _endOffset = Int64.Default;
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

				public OffsetForLeaderPartitionResult WithEndOffset(Int64 endOffset)
				{
					EndOffset = endOffset;
					return this;
				}
			}
		}
	}

	public class ProduceRequest : Message
	{
		public ProduceRequest(int version)
		{
			if (version.InRange(0, 7) == false) 
			{
				throw new UnsupportedVersionException($"ProduceRequest does not support version {version}. Valid versions are: 0-7");
			}

			Version = version;
		}

		public const int ApiKey = 0;

		public override int Version { get; }

		public static async ValueTask<ProduceRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ProduceRequest(version);
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Acks = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TimeoutMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await TopicProduceData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(TransactionalId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(Acks, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(TimeoutMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The transactional ID, or null if the producer is not transactional.
		/// </summary>
		private String? _transactionalId = String.Default;
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

		public ProduceRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		/// <summary>
		/// The number of acknowledgments the producer requires the leader to have received before considering a request complete. Allowed values: 0 for no acknowledgments, 1 for only the leader and -1 for the full ISR.
		/// </summary>
		private Int16 _acks = Int16.Default;
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

		public ProduceRequest WithAcks(Int16 acks)
		{
			Acks = acks;
			return this;
		}

		/// <summary>
		/// The timeout to await a response in miliseconds.
		/// </summary>
		private Int32 _timeoutMs = Int32.Default;
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

		public ProduceRequest WithTimeoutMs(Int32 timeoutMs)
		{
			TimeoutMs = timeoutMs;
			return this;
		}

		/// <summary>
		/// Each topic to produce to.
		/// </summary>
		private TopicProduceData[] _topicsCollection = Array.Empty<TopicProduceData>();
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
			internal TopicProduceData(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<TopicProduceData> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TopicProduceData(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await PartitionProduceData.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public TopicProduceData WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// Each partition to produce to.
			/// </summary>
			private PartitionProduceData[] _partitionsCollection = Array.Empty<PartitionProduceData>();
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
				internal PartitionProduceData(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<PartitionProduceData> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new PartitionProduceData(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Records = await reader.ReadNullableBytesAsync(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableBytesAsync(Records, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public PartitionProduceData WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The record data to be produced.
				/// </summary>
				private Bytes? _records = Bytes.Default;
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

				public PartitionProduceData WithRecords(Bytes records)
				{
					Records = records;
					return this;
				}
			}
		}
	}

	public class ProduceResponse : Message
	{
		public ProduceResponse(int version)
		{
			if (version.InRange(0, 7) == false) 
			{
				throw new UnsupportedVersionException($"ProduceResponse does not support version {version}. Valid versions are: 0-7");
			}

			Version = version;
		}

		public const int ApiKey = 0;

		public override int Version { get; }

		public static async ValueTask<ProduceResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ProduceResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ResponsesCollection = await reader.ReadArrayAsync(async () => await TopicProduceResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, ResponsesCollection);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
		}

		/// <summary>
		/// Each produce response
		/// </summary>
		private TopicProduceResponse[] _responsesCollection = Array.Empty<TopicProduceResponse>();
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
			internal TopicProduceResponse(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<TopicProduceResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TopicProduceResponse(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await PartitionProduceResponse.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			private String _name = String.Default;
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

			public TopicProduceResponse WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// Each partition that we produced to within the topic.
			/// </summary>
			private PartitionProduceResponse[] _partitionsCollection = Array.Empty<PartitionProduceResponse>();
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
				internal PartitionProduceResponse(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<PartitionProduceResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new PartitionProduceResponse(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.BaseOffset = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(2, 2147483647)) 
					{
						instance.LogAppendTimeMs = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(5, 2147483647)) 
					{
						instance.LogStartOffset = await reader.ReadInt64Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(BaseOffset, cancellationToken);
					}
					if (Version.InRange(2, 2147483647)) 
					{
						await writer.WriteInt64Async(LogAppendTimeMs, cancellationToken);
					}
					if (Version.InRange(5, 2147483647)) 
					{
						await writer.WriteInt64Async(LogStartOffset, cancellationToken);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public PartitionProduceResponse WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public PartitionProduceResponse WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}

				/// <summary>
				/// The base offset.
				/// </summary>
				private Int64 _baseOffset = Int64.Default;
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

				public PartitionProduceResponse WithBaseOffset(Int64 baseOffset)
				{
					BaseOffset = baseOffset;
					return this;
				}

				/// <summary>
				/// The timestamp returned by broker after appending the messages. If CreateTime is used for the topic, the timestamp will be -1.  If LogAppendTime is used for the topic, the timestamp will be the broker local time when the messages are appended.
				/// </summary>
				private Int64 _logAppendTimeMs = new Int64(-1);
				public Int64 LogAppendTimeMs 
				{
					get => _logAppendTimeMs;
					set 
					{
						_logAppendTimeMs = value;
					}
				}

				public PartitionProduceResponse WithLogAppendTimeMs(Int64 logAppendTimeMs)
				{
					LogAppendTimeMs = logAppendTimeMs;
					return this;
				}

				/// <summary>
				/// The log start offset.
				/// </summary>
				private Int64 _logStartOffset = new Int64(-1);
				public Int64 LogStartOffset 
				{
					get => _logStartOffset;
					set 
					{
						_logStartOffset = value;
					}
				}

				public PartitionProduceResponse WithLogStartOffset(Int64 logStartOffset)
				{
					LogStartOffset = logStartOffset;
					return this;
				}
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public ProduceResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class RenewDelegationTokenRequest : Message
	{
		public RenewDelegationTokenRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"RenewDelegationTokenRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 39;

		public override int Version { get; }

		public static async ValueTask<RenewDelegationTokenRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new RenewDelegationTokenRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Hmac = await reader.ReadBytesAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.RenewPeriodMs = await reader.ReadInt64Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(Hmac, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(RenewPeriodMs, cancellationToken);
			}
		}

		/// <summary>
		/// The HMAC of the delegation token to be renewed.
		/// </summary>
		private Bytes _hmac = Bytes.Default;
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

		public RenewDelegationTokenRequest WithHmac(Bytes hmac)
		{
			Hmac = hmac;
			return this;
		}

		/// <summary>
		/// The renewal time period in milliseconds.
		/// </summary>
		private Int64 _renewPeriodMs = Int64.Default;
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

		public RenewDelegationTokenRequest WithRenewPeriodMs(Int64 renewPeriodMs)
		{
			RenewPeriodMs = renewPeriodMs;
			return this;
		}
	}

	public class RenewDelegationTokenResponse : Message
	{
		public RenewDelegationTokenResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"RenewDelegationTokenResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 39;

		public override int Version { get; }

		public static async ValueTask<RenewDelegationTokenResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new RenewDelegationTokenResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ExpiryTimestampMs = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ExpiryTimestampMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public RenewDelegationTokenResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The timestamp in milliseconds at which this token expires.
		/// </summary>
		private Int64 _expiryTimestampMs = Int64.Default;
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

		public RenewDelegationTokenResponse WithExpiryTimestampMs(Int64 expiryTimestampMs)
		{
			ExpiryTimestampMs = expiryTimestampMs;
			return this;
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public RenewDelegationTokenResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}
	}

	public class RequestHeader : Message
	{
		public RequestHeader(int version)
		{
			if (version.InRange(0, 0) == false) 
			{
				throw new UnsupportedVersionException($"RequestHeader does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public const int ApiKey = 0;

		public override int Version { get; }

		public static async ValueTask<RequestHeader> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new RequestHeader(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.RequestApiKey = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.RequestApiVersion = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.CorrelationId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ClientId = await reader.ReadStringAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(RequestApiKey, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(RequestApiVersion, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(CorrelationId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(ClientId, cancellationToken);
			}
		}

		/// <summary>
		/// The API key of this request.
		/// </summary>
		private Int16 _requestApiKey = Int16.Default;
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

		public RequestHeader WithRequestApiKey(Int16 requestApiKey)
		{
			RequestApiKey = requestApiKey;
			return this;
		}

		/// <summary>
		/// The API version of this request.
		/// </summary>
		private Int16 _requestApiVersion = Int16.Default;
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

		public RequestHeader WithRequestApiVersion(Int16 requestApiVersion)
		{
			RequestApiVersion = requestApiVersion;
			return this;
		}

		/// <summary>
		/// The correlation ID of this request.
		/// </summary>
		private Int32 _correlationId = Int32.Default;
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

		public RequestHeader WithCorrelationId(Int32 correlationId)
		{
			CorrelationId = correlationId;
			return this;
		}

		/// <summary>
		/// The client ID string.
		/// </summary>
		private String _clientId = String.Default;
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

		public RequestHeader WithClientId(String clientId)
		{
			ClientId = clientId;
			return this;
		}
	}

	public class ResponseHeader : Message
	{
		public ResponseHeader(int version)
		{
			if (version.InRange(0, 0) == false) 
			{
				throw new UnsupportedVersionException($"ResponseHeader does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public const int ApiKey = 0;

		public override int Version { get; }

		public static async ValueTask<ResponseHeader> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new ResponseHeader(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.CorrelationId = await reader.ReadInt32Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(CorrelationId, cancellationToken);
			}
		}

		/// <summary>
		/// The correlation ID of this response.
		/// </summary>
		private Int32 _correlationId = Int32.Default;
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

		public ResponseHeader WithCorrelationId(Int32 correlationId)
		{
			CorrelationId = correlationId;
			return this;
		}
	}

	public class SaslAuthenticateRequest : Message
	{
		public SaslAuthenticateRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"SaslAuthenticateRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 36;

		public override int Version { get; }

		public static async ValueTask<SaslAuthenticateRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SaslAuthenticateRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.AuthBytes = await reader.ReadBytesAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(AuthBytes, cancellationToken);
			}
		}

		/// <summary>
		/// The SASL authentication bytes from the client, as defined by the SASL mechanism.
		/// </summary>
		private Bytes _authBytes = Bytes.Default;
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

		public SaslAuthenticateRequest WithAuthBytes(Bytes authBytes)
		{
			AuthBytes = authBytes;
			return this;
		}
	}

	public class SaslAuthenticateResponse : Message
	{
		public SaslAuthenticateResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"SaslAuthenticateResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 36;

		public override int Version { get; }

		public static async ValueTask<SaslAuthenticateResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SaslAuthenticateResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorMessage = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.AuthBytes = await reader.ReadBytesAsync(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.SessionLifetimeMs = await reader.ReadInt64Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(ErrorMessage, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(AuthBytes, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt64Async(SessionLifetimeMs, cancellationToken);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public SaslAuthenticateResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		private String? _errorMessage = String.Default;
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

		public SaslAuthenticateResponse WithErrorMessage(String errorMessage)
		{
			ErrorMessage = errorMessage;
			return this;
		}

		/// <summary>
		/// The SASL authentication bytes from the server, as defined by the SASL mechanism.
		/// </summary>
		private Bytes _authBytes = Bytes.Default;
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

		public SaslAuthenticateResponse WithAuthBytes(Bytes authBytes)
		{
			AuthBytes = authBytes;
			return this;
		}

		/// <summary>
		/// The SASL authentication bytes from the server, as defined by the SASL mechanism.
		/// </summary>
		private Int64 _sessionLifetimeMs = new Int64(0);
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

		public SaslAuthenticateResponse WithSessionLifetimeMs(Int64 sessionLifetimeMs)
		{
			SessionLifetimeMs = sessionLifetimeMs;
			return this;
		}
	}

	public class SaslHandshakeRequest : Message
	{
		public SaslHandshakeRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"SaslHandshakeRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 17;

		public override int Version { get; }

		public static async ValueTask<SaslHandshakeRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SaslHandshakeRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Mechanism = await reader.ReadStringAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(Mechanism, cancellationToken);
			}
		}

		/// <summary>
		/// The SASL mechanism chosen by the client.
		/// </summary>
		private String _mechanism = String.Default;
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

		public SaslHandshakeRequest WithMechanism(String mechanism)
		{
			Mechanism = mechanism;
			return this;
		}
	}

	public class SaslHandshakeResponse : Message
	{
		public SaslHandshakeResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"SaslHandshakeResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 17;

		public override int Version { get; }

		public static async ValueTask<SaslHandshakeResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SaslHandshakeResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MechanismsCollection = await reader.ReadArrayAsync(async () => await String.FromReaderAsync(reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, MechanismsCollection);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public SaslHandshakeResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The mechanisms enabled in the server.
		/// </summary>
		private String[] _mechanismsCollection = Array.Empty<String>();
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

		public SaslHandshakeResponse WithMechanismsCollection(String[] mechanismsCollection)
		{
			MechanismsCollection = mechanismsCollection;
			return this;
		}
	}

	public class StopReplicaRequest : Message
	{
		public StopReplicaRequest(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"StopReplicaRequest does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 5;

		public override int Version { get; }

		public static async ValueTask<StopReplicaRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new StopReplicaRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerEpoch = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.BrokerEpoch = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.DeletePartitions = await reader.ReadBooleanAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 0)) 
			{
				instance.PartitionsV0Collection = await reader.ReadArrayAsync(async () => await StopReplicaRequestPartitionV0.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await StopReplicaRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerEpoch, cancellationToken);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt64Async(BrokerEpoch, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBooleanAsync(DeletePartitions, cancellationToken);
			}
			if (Version.InRange(0, 0)) 
			{
				await writer.WriteArrayAsync(cancellationToken, PartitionsV0Collection);
			}
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The controller id.
		/// </summary>
		private Int32 _controllerId = Int32.Default;
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

		public StopReplicaRequest WithControllerId(Int32 controllerId)
		{
			ControllerId = controllerId;
			return this;
		}

		/// <summary>
		/// The controller epoch.
		/// </summary>
		private Int32 _controllerEpoch = Int32.Default;
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

		public StopReplicaRequest WithControllerEpoch(Int32 controllerEpoch)
		{
			ControllerEpoch = controllerEpoch;
			return this;
		}

		/// <summary>
		/// The broker epoch.
		/// </summary>
		private Int64 _brokerEpoch = new Int64(-1);
		public Int64 BrokerEpoch 
		{
			get => _brokerEpoch;
			set 
			{
				_brokerEpoch = value;
			}
		}

		public StopReplicaRequest WithBrokerEpoch(Int64 brokerEpoch)
		{
			BrokerEpoch = brokerEpoch;
			return this;
		}

		/// <summary>
		/// Whether these partitions should be deleted.
		/// </summary>
		private Boolean _deletePartitions = Boolean.Default;
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

		public StopReplicaRequest WithDeletePartitions(Boolean deletePartitions)
		{
			DeletePartitions = deletePartitions;
			return this;
		}

		/// <summary>
		/// The partitions to stop.
		/// </summary>
		private StopReplicaRequestPartitionV0[] _partitionsV0Collection = Array.Empty<StopReplicaRequestPartitionV0>();
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
			internal StopReplicaRequestPartitionV0(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<StopReplicaRequestPartitionV0> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new StopReplicaRequestPartitionV0(version);
				if (instance.Version.InRange(0, 0)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 0)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 0)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken);
				}
				if (Version.InRange(0, 0)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _topicName = String.Default;
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

			public StopReplicaRequestPartitionV0 WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			/// <summary>
			/// The partition index.
			/// </summary>
			private Int32 _partitionIndex = Int32.Default;
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

			public StopReplicaRequestPartitionV0 WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}
		}

		/// <summary>
		/// The topics to stop.
		/// </summary>
		private StopReplicaRequestTopic[] _topicsCollection = Array.Empty<StopReplicaRequestTopic>();
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
			internal StopReplicaRequestTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<StopReplicaRequestTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new StopReplicaRequestTopic(version);
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.PartitionIndexesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionIndexesCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public StopReplicaRequestTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The partition indexes.
			/// </summary>
			private Int32[] _partitionIndexesCollection = Array.Empty<Int32>();
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

			public StopReplicaRequestTopic WithPartitionIndexesCollection(Int32[] partitionIndexesCollection)
			{
				PartitionIndexesCollection = partitionIndexesCollection;
				return this;
			}
		}
	}

	public class StopReplicaResponse : Message
	{
		public StopReplicaResponse(int version)
		{
			if (version.InRange(0, 1) == false) 
			{
				throw new UnsupportedVersionException($"StopReplicaResponse does not support version {version}. Valid versions are: 0-1");
			}

			Version = version;
		}

		public const int ApiKey = 5;

		public override int Version { get; }

		public static async ValueTask<StopReplicaResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new StopReplicaResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await StopReplicaResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
			}
		}

		/// <summary>
		/// The top-level error code, or 0 if there was no top-level error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public StopReplicaResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The responses for each partition.
		/// </summary>
		private StopReplicaResponsePartition[] _partitionsCollection = Array.Empty<StopReplicaResponsePartition>();
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
			internal StopReplicaResponsePartition(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<StopReplicaResponsePartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new StopReplicaResponsePartition(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ErrorCode, cancellationToken);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _topicName = String.Default;
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

			public StopReplicaResponsePartition WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			/// <summary>
			/// The partition index.
			/// </summary>
			private Int32 _partitionIndex = Int32.Default;
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

			public StopReplicaResponsePartition WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}

			/// <summary>
			/// The partition error code, or 0 if there was no partition error.
			/// </summary>
			private Int16 _errorCode = Int16.Default;
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

			public StopReplicaResponsePartition WithErrorCode(Int16 errorCode)
			{
				ErrorCode = errorCode;
				return this;
			}
		}
	}

	public class SyncGroupRequest : Message
	{
		public SyncGroupRequest(int version)
		{
			if (version.InRange(0, 3) == false) 
			{
				throw new UnsupportedVersionException($"SyncGroupRequest does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public const int ApiKey = 14;

		public override int Version { get; }

		public static async ValueTask<SyncGroupRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SyncGroupRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GenerationId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MemberId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(3, 2147483647)) 
			{
				instance.GroupInstanceId = await reader.ReadNullableStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.AssignmentsCollection = await reader.ReadArrayAsync(async () => await SyncGroupRequestAssignment.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(GenerationId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(MemberId, cancellationToken);
			}
			if (Version.InRange(3, 2147483647)) 
			{
				await writer.WriteNullableStringAsync(GroupInstanceId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, AssignmentsCollection);
			}
		}

		/// <summary>
		/// The unique group identifier.
		/// </summary>
		private String _groupId = String.Default;
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

		public SyncGroupRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		/// <summary>
		/// The generation of the group.
		/// </summary>
		private Int32 _generationId = Int32.Default;
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

		public SyncGroupRequest WithGenerationId(Int32 generationId)
		{
			GenerationId = generationId;
			return this;
		}

		/// <summary>
		/// The member ID assigned by the group.
		/// </summary>
		private String _memberId = String.Default;
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

		public SyncGroupRequest WithMemberId(String memberId)
		{
			MemberId = memberId;
			return this;
		}

		/// <summary>
		/// The unique identifier of the consumer instance provided by end user.
		/// </summary>
		private String? _groupInstanceId;
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

		public SyncGroupRequest WithGroupInstanceId(String groupInstanceId)
		{
			GroupInstanceId = groupInstanceId;
			return this;
		}

		/// <summary>
		/// Each assignment.
		/// </summary>
		private SyncGroupRequestAssignment[] _assignmentsCollection = Array.Empty<SyncGroupRequestAssignment>();
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
			internal SyncGroupRequestAssignment(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<SyncGroupRequestAssignment> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new SyncGroupRequestAssignment(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.MemberId = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Assignment = await reader.ReadBytesAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(MemberId, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteBytesAsync(Assignment, cancellationToken);
				}
			}

			/// <summary>
			/// The ID of the member to assign.
			/// </summary>
			private String _memberId = String.Default;
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

			public SyncGroupRequestAssignment WithMemberId(String memberId)
			{
				MemberId = memberId;
				return this;
			}

			/// <summary>
			/// The member assignment.
			/// </summary>
			private Bytes _assignment = Bytes.Default;
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

			public SyncGroupRequestAssignment WithAssignment(Bytes assignment)
			{
				Assignment = assignment;
				return this;
			}
		}
	}

	public class SyncGroupResponse : Message
	{
		public SyncGroupResponse(int version)
		{
			if (version.InRange(0, 3) == false) 
			{
				throw new UnsupportedVersionException($"SyncGroupResponse does not support version {version}. Valid versions are: 0-3");
			}

			Version = version;
		}

		public const int ApiKey = 14;

		public override int Version { get; }

		public static async ValueTask<SyncGroupResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new SyncGroupResponse(version);
			if (instance.Version.InRange(1, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.Assignment = await reader.ReadBytesAsync(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(1, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteBytesAsync(Assignment, cancellationToken);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
		public Int32 ThrottleTimeMs 
		{
			get => _throttleTimeMs;
			set 
			{
				_throttleTimeMs = value;
			}
		}

		public SyncGroupResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public SyncGroupResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}

		/// <summary>
		/// The member assignment.
		/// </summary>
		private Bytes _assignment = Bytes.Default;
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

		public SyncGroupResponse WithAssignment(Bytes assignment)
		{
			Assignment = assignment;
			return this;
		}
	}

	public class TxnOffsetCommitRequest : Message
	{
		public TxnOffsetCommitRequest(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"TxnOffsetCommitRequest does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 28;

		public override int Version { get; }

		public static async ValueTask<TxnOffsetCommitRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new TxnOffsetCommitRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TransactionalId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.GroupId = await reader.ReadStringAsync(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerId = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await TxnOffsetCommitRequestTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(TransactionalId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteStringAsync(GroupId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt64Async(ProducerId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ProducerEpoch, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The ID of the transaction.
		/// </summary>
		private String _transactionalId = String.Default;
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

		public TxnOffsetCommitRequest WithTransactionalId(String transactionalId)
		{
			TransactionalId = transactionalId;
			return this;
		}

		/// <summary>
		/// The ID of the group.
		/// </summary>
		private String _groupId = String.Default;
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

		public TxnOffsetCommitRequest WithGroupId(String groupId)
		{
			GroupId = groupId;
			return this;
		}

		/// <summary>
		/// The current producer ID in use by the transactional ID.
		/// </summary>
		private Int64 _producerId = Int64.Default;
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

		public TxnOffsetCommitRequest WithProducerId(Int64 producerId)
		{
			ProducerId = producerId;
			return this;
		}

		/// <summary>
		/// The current epoch associated with the producer ID.
		/// </summary>
		private Int16 _producerEpoch = Int16.Default;
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

		public TxnOffsetCommitRequest WithProducerEpoch(Int16 producerEpoch)
		{
			ProducerEpoch = producerEpoch;
			return this;
		}

		/// <summary>
		/// Each topic that we want to committ offsets for.
		/// </summary>
		private TxnOffsetCommitRequestTopic[] _topicsCollection = Array.Empty<TxnOffsetCommitRequestTopic>();
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
			internal TxnOffsetCommitRequestTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<TxnOffsetCommitRequestTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TxnOffsetCommitRequestTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await TxnOffsetCommitRequestPartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public TxnOffsetCommitRequestTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The partitions inside the topic that we want to committ offsets for.
			/// </summary>
			private TxnOffsetCommitRequestPartition[] _partitionsCollection = Array.Empty<TxnOffsetCommitRequestPartition>();
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
				internal TxnOffsetCommitRequestPartition(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<TxnOffsetCommitRequestPartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new TxnOffsetCommitRequestPartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.CommittedOffset = await reader.ReadInt64Async(cancellationToken);
					}
					if (instance.Version.InRange(2, 2147483647)) 
					{
						instance.CommittedLeaderEpoch = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.CommittedMetadata = await reader.ReadNullableStringAsync(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt64Async(CommittedOffset, cancellationToken);
					}
					if (Version.InRange(2, 2147483647)) 
					{
						await writer.WriteInt32Async(CommittedLeaderEpoch, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteNullableStringAsync(CommittedMetadata, cancellationToken);
					}
				}

				/// <summary>
				/// The index of the partition within the topic.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public TxnOffsetCommitRequestPartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The message offset to be committed.
				/// </summary>
				private Int64 _committedOffset = Int64.Default;
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

				public TxnOffsetCommitRequestPartition WithCommittedOffset(Int64 committedOffset)
				{
					CommittedOffset = committedOffset;
					return this;
				}

				/// <summary>
				/// The leader epoch of the last consumed record.
				/// </summary>
				private Int32 _committedLeaderEpoch = new Int32(-1);
				public Int32 CommittedLeaderEpoch 
				{
					get => _committedLeaderEpoch;
					set 
					{
						_committedLeaderEpoch = value;
					}
				}

				public TxnOffsetCommitRequestPartition WithCommittedLeaderEpoch(Int32 committedLeaderEpoch)
				{
					CommittedLeaderEpoch = committedLeaderEpoch;
					return this;
				}

				/// <summary>
				/// Any associated metadata the client wants to keep.
				/// </summary>
				private String? _committedMetadata = String.Default;
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

				public TxnOffsetCommitRequestPartition WithCommittedMetadata(String committedMetadata)
				{
					CommittedMetadata = committedMetadata;
					return this;
				}
			}
		}
	}

	public class TxnOffsetCommitResponse : Message
	{
		public TxnOffsetCommitResponse(int version)
		{
			if (version.InRange(0, 2) == false) 
			{
				throw new UnsupportedVersionException($"TxnOffsetCommitResponse does not support version {version}. Valid versions are: 0-2");
			}

			Version = version;
		}

		public const int ApiKey = 28;

		public override int Version { get; }

		public static async ValueTask<TxnOffsetCommitResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new TxnOffsetCommitResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ThrottleTimeMs = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.TopicsCollection = await reader.ReadArrayAsync(async () => await TxnOffsetCommitResponseTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ThrottleTimeMs, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		private Int32 _throttleTimeMs = Int32.Default;
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

		public TxnOffsetCommitResponse WithThrottleTimeMs(Int32 throttleTimeMs)
		{
			ThrottleTimeMs = throttleTimeMs;
			return this;
		}

		/// <summary>
		/// The responses for each topic.
		/// </summary>
		private TxnOffsetCommitResponseTopic[] _topicsCollection = Array.Empty<TxnOffsetCommitResponseTopic>();
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
			internal TxnOffsetCommitResponseTopic(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<TxnOffsetCommitResponseTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new TxnOffsetCommitResponseTopic(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Name = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await TxnOffsetCommitResponsePartition.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteStringAsync(Name, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _name = String.Default;
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

			public TxnOffsetCommitResponseTopic WithName(String name)
			{
				Name = name;
				return this;
			}

			/// <summary>
			/// The responses for each partition in the topic.
			/// </summary>
			private TxnOffsetCommitResponsePartition[] _partitionsCollection = Array.Empty<TxnOffsetCommitResponsePartition>();
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
				internal TxnOffsetCommitResponsePartition(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<TxnOffsetCommitResponsePartition> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new TxnOffsetCommitResponsePartition(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt32Async(PartitionIndex, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteInt16Async(ErrorCode, cancellationToken);
					}
				}

				/// <summary>
				/// The partitition index.
				/// </summary>
				private Int32 _partitionIndex = Int32.Default;
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

				public TxnOffsetCommitResponsePartition WithPartitionIndex(Int32 partitionIndex)
				{
					PartitionIndex = partitionIndex;
					return this;
				}

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				private Int16 _errorCode = Int16.Default;
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

				public TxnOffsetCommitResponsePartition WithErrorCode(Int16 errorCode)
				{
					ErrorCode = errorCode;
					return this;
				}
			}
		}
	}

	public class UpdateMetadataRequest : Message
	{
		public UpdateMetadataRequest(int version)
		{
			if (version.InRange(0, 5) == false) 
			{
				throw new UnsupportedVersionException($"UpdateMetadataRequest does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public const int ApiKey = 6;

		public override int Version { get; }

		public static async ValueTask<UpdateMetadataRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new UpdateMetadataRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerId = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ControllerEpoch = await reader.ReadInt32Async(cancellationToken);
			}
			if (instance.Version.InRange(5, 2147483647)) 
			{
				instance.BrokerEpoch = await reader.ReadInt64Async(cancellationToken);
			}
			if (instance.Version.InRange(0, 4)) 
			{
				instance.LegacyPartitionStatesCollection = await reader.ReadArrayAsync(async () => await UpdateMetadataPartitionState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(5, 2147483647)) 
			{
				instance.TopicStatesCollection = await reader.ReadArrayAsync(async () => await UpdateMetadataRequestTopicState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.BrokersCollection = await reader.ReadArrayAsync(async () => await UpdateMetadataRequestBroker.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerId, cancellationToken);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt32Async(ControllerEpoch, cancellationToken);
			}
			if (Version.InRange(5, 2147483647)) 
			{
				await writer.WriteInt64Async(BrokerEpoch, cancellationToken);
			}
			if (Version.InRange(0, 4)) 
			{
				await writer.WriteArrayAsync(cancellationToken, LegacyPartitionStatesCollection);
			}
			if (Version.InRange(5, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, TopicStatesCollection);
			}
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, BrokersCollection);
			}
		}

		/// <summary>
		/// The controller id.
		/// </summary>
		private Int32 _controllerId = Int32.Default;
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

		public UpdateMetadataRequest WithControllerId(Int32 controllerId)
		{
			ControllerId = controllerId;
			return this;
		}

		/// <summary>
		/// The controller epoch.
		/// </summary>
		private Int32 _controllerEpoch = Int32.Default;
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

		public UpdateMetadataRequest WithControllerEpoch(Int32 controllerEpoch)
		{
			ControllerEpoch = controllerEpoch;
			return this;
		}

		/// <summary>
		/// The broker epoch.
		/// </summary>
		private Int64 _brokerEpoch = new Int64(-1);
		public Int64 BrokerEpoch 
		{
			get => _brokerEpoch;
			set 
			{
				_brokerEpoch = value;
			}
		}

		public UpdateMetadataRequest WithBrokerEpoch(Int64 brokerEpoch)
		{
			BrokerEpoch = brokerEpoch;
			return this;
		}

		/// <summary>
		/// In older versions of this RPC, each partition that we would like to update.
		/// </summary>
		private UpdateMetadataPartitionState[] _legacyPartitionStatesCollection = Array.Empty<UpdateMetadataPartitionState>();
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

		public UpdateMetadataRequest WithLegacyPartitionStatesCollection(UpdateMetadataPartitionState[] legacyPartitionStatesCollection)
		{
			LegacyPartitionStatesCollection = legacyPartitionStatesCollection;
			return this;
		}

		/// <summary>
		/// In newer versions of this RPC, each topic that we would like to update.
		/// </summary>
		private UpdateMetadataRequestTopicState[] _topicStatesCollection = Array.Empty<UpdateMetadataRequestTopicState>();
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
			internal UpdateMetadataRequestTopicState(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<UpdateMetadataRequestTopicState> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new UpdateMetadataRequestTopicState(version);
				if (instance.Version.InRange(5, 2147483647)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(5, 2147483647)) 
				{
					instance.PartitionStatesCollection = await reader.ReadArrayAsync(async () => await UpdateMetadataPartitionState.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(5, 2147483647)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken);
				}
				if (Version.InRange(5, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, PartitionStatesCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			private String _topicName = String.Default;
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

			public UpdateMetadataRequestTopicState WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			/// <summary>
			/// The partition that we would like to update.
			/// </summary>
			private UpdateMetadataPartitionState[] _partitionStatesCollection = Array.Empty<UpdateMetadataPartitionState>();
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
			internal UpdateMetadataRequestBroker(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<UpdateMetadataRequestBroker> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new UpdateMetadataRequestBroker(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Id = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 0)) 
				{
					instance.V0Host = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 0)) 
				{
					instance.V0Port = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(1, 2147483647)) 
				{
					instance.EndpointsCollection = await reader.ReadArrayAsync(async () => await UpdateMetadataRequestEndpoint.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				if (instance.Version.InRange(2, 2147483647)) 
				{
					instance.Rack = await reader.ReadNullableStringAsync(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(Id, cancellationToken);
				}
				if (Version.InRange(0, 0)) 
				{
					await writer.WriteStringAsync(V0Host, cancellationToken);
				}
				if (Version.InRange(0, 0)) 
				{
					await writer.WriteInt32Async(V0Port, cancellationToken);
				}
				if (Version.InRange(1, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, EndpointsCollection);
				}
				if (Version.InRange(2, 2147483647)) 
				{
					await writer.WriteNullableStringAsync(Rack, cancellationToken);
				}
			}

			/// <summary>
			/// The broker id.
			/// </summary>
			private Int32 _id = Int32.Default;
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

			public UpdateMetadataRequestBroker WithId(Int32 id)
			{
				Id = id;
				return this;
			}

			/// <summary>
			/// The broker hostname.
			/// </summary>
			private String _v0Host = String.Default;
			public String V0Host 
			{
				get => _v0Host;
				set 
				{
					_v0Host = value;
				}
			}

			public UpdateMetadataRequestBroker WithV0Host(String v0Host)
			{
				V0Host = v0Host;
				return this;
			}

			/// <summary>
			/// The broker port.
			/// </summary>
			private Int32 _v0Port = Int32.Default;
			public Int32 V0Port 
			{
				get => _v0Port;
				set 
				{
					_v0Port = value;
				}
			}

			public UpdateMetadataRequestBroker WithV0Port(Int32 v0Port)
			{
				V0Port = v0Port;
				return this;
			}

			/// <summary>
			/// The broker endpoints.
			/// </summary>
			private UpdateMetadataRequestEndpoint[] _endpointsCollection = Array.Empty<UpdateMetadataRequestEndpoint>();
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
				internal UpdateMetadataRequestEndpoint(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<UpdateMetadataRequestEndpoint> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new UpdateMetadataRequestEndpoint(version);
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.Port = await reader.ReadInt32Async(cancellationToken);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.Host = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(3, 2147483647)) 
					{
						instance.Listener = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(1, 2147483647)) 
					{
						instance.SecurityProtocol = await reader.ReadInt16Async(cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt32Async(Port, cancellationToken);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteStringAsync(Host, cancellationToken);
					}
					if (Version.InRange(3, 2147483647)) 
					{
						await writer.WriteStringAsync(Listener, cancellationToken);
					}
					if (Version.InRange(1, 2147483647)) 
					{
						await writer.WriteInt16Async(SecurityProtocol, cancellationToken);
					}
				}

				/// <summary>
				/// The port of this endpoint
				/// </summary>
				private Int32 _port = Int32.Default;
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

				public UpdateMetadataRequestEndpoint WithPort(Int32 port)
				{
					Port = port;
					return this;
				}

				/// <summary>
				/// The hostname of this endpoint
				/// </summary>
				private String _host = String.Default;
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

				public UpdateMetadataRequestEndpoint WithHost(String host)
				{
					Host = host;
					return this;
				}

				/// <summary>
				/// The listener name.
				/// </summary>
				private String _listener = String.Default;
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

				public UpdateMetadataRequestEndpoint WithListener(String listener)
				{
					Listener = listener;
					return this;
				}

				/// <summary>
				/// The security protocol type.
				/// </summary>
				private Int16 _securityProtocol = Int16.Default;
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

				public UpdateMetadataRequestEndpoint WithSecurityProtocol(Int16 securityProtocol)
				{
					SecurityProtocol = securityProtocol;
					return this;
				}
			}

			/// <summary>
			/// The rack which this broker belongs to.
			/// </summary>
			private String? _rack = String.Default;
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

			public UpdateMetadataRequestBroker WithRack(String rack)
			{
				Rack = rack;
				return this;
			}
		}

		public class UpdateMetadataPartitionState : ISerialize
		{
			internal UpdateMetadataPartitionState(int version)
			{
				if (version.InRange(0, 2147483647) == false) 
				{
					throw new UnsupportedVersionException($"UpdateMetadataPartitionState does not support version {version}. Valid versions are: 0+");
				}

				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<UpdateMetadataPartitionState> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new UpdateMetadataPartitionState(version);
				if (instance.Version.InRange(0, 4)) 
				{
					instance.TopicName = await reader.ReadStringAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ControllerEpoch = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.Leader = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.LeaderEpoch = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.IsrCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ZkVersion = await reader.ReadInt32Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ReplicasCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				if (instance.Version.InRange(4, 2147483647)) 
				{
					instance.OfflineReplicasCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 4)) 
				{
					await writer.WriteStringAsync(TopicName, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(PartitionIndex, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(ControllerEpoch, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(Leader, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(LeaderEpoch, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, IsrCollection);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(ZkVersion, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, ReplicasCollection);
				}
				if (Version.InRange(4, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, OfflineReplicasCollection);
				}
			}

			/// <summary>
			/// In older versions of this RPC, the topic name.
			/// </summary>
			private String _topicName = String.Default;
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

			public UpdateMetadataPartitionState WithTopicName(String topicName)
			{
				TopicName = topicName;
				return this;
			}

			/// <summary>
			/// The partition index.
			/// </summary>
			private Int32 _partitionIndex = Int32.Default;
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

			public UpdateMetadataPartitionState WithPartitionIndex(Int32 partitionIndex)
			{
				PartitionIndex = partitionIndex;
				return this;
			}

			/// <summary>
			/// The controller epoch.
			/// </summary>
			private Int32 _controllerEpoch = Int32.Default;
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

			public UpdateMetadataPartitionState WithControllerEpoch(Int32 controllerEpoch)
			{
				ControllerEpoch = controllerEpoch;
				return this;
			}

			/// <summary>
			/// The ID of the broker which is the current partition leader.
			/// </summary>
			private Int32 _leader = Int32.Default;
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

			public UpdateMetadataPartitionState WithLeader(Int32 leader)
			{
				Leader = leader;
				return this;
			}

			/// <summary>
			/// The leader epoch of this partition.
			/// </summary>
			private Int32 _leaderEpoch = Int32.Default;
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

			public UpdateMetadataPartitionState WithLeaderEpoch(Int32 leaderEpoch)
			{
				LeaderEpoch = leaderEpoch;
				return this;
			}

			/// <summary>
			/// The brokers which are in the ISR for this partition.
			/// </summary>
			private Int32[] _isrCollection = Array.Empty<Int32>();
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

			public UpdateMetadataPartitionState WithIsrCollection(Int32[] isrCollection)
			{
				IsrCollection = isrCollection;
				return this;
			}

			/// <summary>
			/// The Zookeeper version.
			/// </summary>
			private Int32 _zkVersion = Int32.Default;
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

			public UpdateMetadataPartitionState WithZkVersion(Int32 zkVersion)
			{
				ZkVersion = zkVersion;
				return this;
			}

			/// <summary>
			/// All the replicas of this partition.
			/// </summary>
			private Int32[] _replicasCollection = Array.Empty<Int32>();
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

			public UpdateMetadataPartitionState WithReplicasCollection(Int32[] replicasCollection)
			{
				ReplicasCollection = replicasCollection;
				return this;
			}

			/// <summary>
			/// The replicas of this partition which are offline.
			/// </summary>
			private Int32[] _offlineReplicasCollection = Array.Empty<Int32>();
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

			public UpdateMetadataPartitionState WithOfflineReplicasCollection(Int32[] offlineReplicasCollection)
			{
				OfflineReplicasCollection = offlineReplicasCollection;
				return this;
			}
		}
	}

	public class UpdateMetadataResponse : Message
	{
		public UpdateMetadataResponse(int version)
		{
			if (version.InRange(0, 5) == false) 
			{
				throw new UnsupportedVersionException($"UpdateMetadataResponse does not support version {version}. Valid versions are: 0-5");
			}

			Version = version;
		}

		public const int ApiKey = 6;

		public override int Version { get; }

		public static async ValueTask<UpdateMetadataResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new UpdateMetadataResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteInt16Async(ErrorCode, cancellationToken);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		private Int16 _errorCode = Int16.Default;
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

		public UpdateMetadataResponse WithErrorCode(Int16 errorCode)
		{
			ErrorCode = errorCode;
			return this;
		}
	}

	public class WriteTxnMarkersRequest : Message
	{
		public WriteTxnMarkersRequest(int version)
		{
			if (version.InRange(0, 0) == false) 
			{
				throw new UnsupportedVersionException($"WriteTxnMarkersRequest does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public const int ApiKey = 27;

		public override int Version { get; }

		public static async ValueTask<WriteTxnMarkersRequest> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new WriteTxnMarkersRequest(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MarkersCollection = await reader.ReadArrayAsync(async () => await WritableTxnMarker.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, MarkersCollection);
			}
		}

		/// <summary>
		/// The transaction markers to be written.
		/// </summary>
		private WritableTxnMarker[] _markersCollection = Array.Empty<WritableTxnMarker>();
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
			internal WritableTxnMarker(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<WritableTxnMarker> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new WritableTxnMarker(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProducerId = await reader.ReadInt64Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProducerEpoch = await reader.ReadInt16Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TransactionResult = await reader.ReadBooleanAsync(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicsCollection = await reader.ReadArrayAsync(async () => await WritableTxnMarkerTopic.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.CoordinatorEpoch = await reader.ReadInt32Async(cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt64Async(ProducerId, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt16Async(ProducerEpoch, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteBooleanAsync(TransactionResult, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt32Async(CoordinatorEpoch, cancellationToken);
				}
			}

			/// <summary>
			/// The current producer ID.
			/// </summary>
			private Int64 _producerId = Int64.Default;
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

			public WritableTxnMarker WithProducerId(Int64 producerId)
			{
				ProducerId = producerId;
				return this;
			}

			/// <summary>
			/// The current epoch associated with the producer ID.
			/// </summary>
			private Int16 _producerEpoch = Int16.Default;
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

			public WritableTxnMarker WithProducerEpoch(Int16 producerEpoch)
			{
				ProducerEpoch = producerEpoch;
				return this;
			}

			/// <summary>
			/// The result of the transaction to write to the partitions (false = ABORT, true = COMMIT).
			/// </summary>
			private Boolean _transactionResult = Boolean.Default;
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

			public WritableTxnMarker WithTransactionResult(Boolean transactionResult)
			{
				TransactionResult = transactionResult;
				return this;
			}

			/// <summary>
			/// Each topic that we want to write transaction marker(s) for.
			/// </summary>
			private WritableTxnMarkerTopic[] _topicsCollection = Array.Empty<WritableTxnMarkerTopic>();
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
				internal WritableTxnMarkerTopic(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<WritableTxnMarkerTopic> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new WritableTxnMarkerTopic(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionIndexesCollection = await reader.ReadArrayAsync(async () => await Int32.FromReaderAsync(reader, cancellationToken), cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, PartitionIndexesCollection);
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				private String _name = String.Default;
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

				public WritableTxnMarkerTopic WithName(String name)
				{
					Name = name;
					return this;
				}

				/// <summary>
				/// The indexes of the partitions to write transaction markers for.
				/// </summary>
				private Int32[] _partitionIndexesCollection = Array.Empty<Int32>();
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

				public WritableTxnMarkerTopic WithPartitionIndexesCollection(Int32[] partitionIndexesCollection)
				{
					PartitionIndexesCollection = partitionIndexesCollection;
					return this;
				}
			}

			/// <summary>
			/// Epoch associated with the transaction state partition hosted by this transaction coordinator
			/// </summary>
			private Int32 _coordinatorEpoch = Int32.Default;
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

			public WritableTxnMarker WithCoordinatorEpoch(Int32 coordinatorEpoch)
			{
				CoordinatorEpoch = coordinatorEpoch;
				return this;
			}
		}
	}

	public class WriteTxnMarkersResponse : Message
	{
		public WriteTxnMarkersResponse(int version)
		{
			if (version.InRange(0, 0) == false) 
			{
				throw new UnsupportedVersionException($"WriteTxnMarkersResponse does not support version {version}. Valid versions are: 0");
			}

			Version = version;
		}

		public const int ApiKey = 27;

		public override int Version { get; }

		public static async ValueTask<WriteTxnMarkersResponse> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
		{
			var instance = new WriteTxnMarkersResponse(version);
			if (instance.Version.InRange(0, 2147483647)) 
			{
				instance.MarkersCollection = await reader.ReadArrayAsync(async () => await WritableTxnMarkerResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
			}
			return instance;
		}

		public override async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
		{
			if (Version.InRange(0, 2147483647)) 
			{
				await writer.WriteArrayAsync(cancellationToken, MarkersCollection);
			}
		}

		/// <summary>
		/// The results for writing makers.
		/// </summary>
		private WritableTxnMarkerResult[] _markersCollection = Array.Empty<WritableTxnMarkerResult>();
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
			internal WritableTxnMarkerResult(int version)
			{
				Version = version;
			}

			internal int Version { get; }

			public static async ValueTask<WritableTxnMarkerResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
			{
				var instance = new WritableTxnMarkerResult(version);
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.ProducerId = await reader.ReadInt64Async(cancellationToken);
				}
				if (instance.Version.InRange(0, 2147483647)) 
				{
					instance.TopicsCollection = await reader.ReadArrayAsync(async () => await WritableTxnMarkerTopicResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
				}
				return instance;
			}

			public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
			{
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteInt64Async(ProducerId, cancellationToken);
				}
				if (Version.InRange(0, 2147483647)) 
				{
					await writer.WriteArrayAsync(cancellationToken, TopicsCollection);
				}
			}

			/// <summary>
			/// The current producer ID in use by the transactional ID.
			/// </summary>
			private Int64 _producerId = Int64.Default;
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

			public WritableTxnMarkerResult WithProducerId(Int64 producerId)
			{
				ProducerId = producerId;
				return this;
			}

			/// <summary>
			/// The results by topic.
			/// </summary>
			private WritableTxnMarkerTopicResult[] _topicsCollection = Array.Empty<WritableTxnMarkerTopicResult>();
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
				internal WritableTxnMarkerTopicResult(int version)
				{
					Version = version;
				}

				internal int Version { get; }

				public static async ValueTask<WritableTxnMarkerTopicResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
				{
					var instance = new WritableTxnMarkerTopicResult(version);
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.Name = await reader.ReadStringAsync(cancellationToken);
					}
					if (instance.Version.InRange(0, 2147483647)) 
					{
						instance.PartitionsCollection = await reader.ReadArrayAsync(async () => await WritableTxnMarkerPartitionResult.FromReaderAsync(instance.Version, reader, cancellationToken), cancellationToken);
					}
					return instance;
				}

				public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
				{
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteStringAsync(Name, cancellationToken);
					}
					if (Version.InRange(0, 2147483647)) 
					{
						await writer.WriteArrayAsync(cancellationToken, PartitionsCollection);
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				private String _name = String.Default;
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

				public WritableTxnMarkerTopicResult WithName(String name)
				{
					Name = name;
					return this;
				}

				/// <summary>
				/// The results by partition.
				/// </summary>
				private WritableTxnMarkerPartitionResult[] _partitionsCollection = Array.Empty<WritableTxnMarkerPartitionResult>();
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
					internal WritableTxnMarkerPartitionResult(int version)
					{
						Version = version;
					}

					internal int Version { get; }

					public static async ValueTask<WritableTxnMarkerPartitionResult> FromReaderAsync(int version, IKafkaReader reader, CancellationToken cancellationToken = default)
					{
						var instance = new WritableTxnMarkerPartitionResult(version);
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.PartitionIndex = await reader.ReadInt32Async(cancellationToken);
						}
						if (instance.Version.InRange(0, 2147483647)) 
						{
							instance.ErrorCode = await reader.ReadInt16Async(cancellationToken);
						}
						return instance;
					}

					public async Task WriteToAsync(IKafkaWriter writer, CancellationToken cancellationToken = default)
					{
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteInt32Async(PartitionIndex, cancellationToken);
						}
						if (Version.InRange(0, 2147483647)) 
						{
							await writer.WriteInt16Async(ErrorCode, cancellationToken);
						}
					}

					/// <summary>
					/// The partition index.
					/// </summary>
					private Int32 _partitionIndex = Int32.Default;
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

					public WritableTxnMarkerPartitionResult WithPartitionIndex(Int32 partitionIndex)
					{
						PartitionIndex = partitionIndex;
						return this;
					}

					/// <summary>
					/// The error code, or 0 if there was no error.
					/// </summary>
					private Int16 _errorCode = Int16.Default;
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

					public WritableTxnMarkerPartitionResult WithErrorCode(Int16 errorCode)
					{
						ErrorCode = errorCode;
						return this;
					}
				}
			}
		}
	}

}