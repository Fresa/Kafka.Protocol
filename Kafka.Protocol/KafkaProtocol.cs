// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kafka.Protocol
{
	/// <summary>
	/// Represents a boolean value in a byte. Values 0 and 1 are used to represent false and true respectively. When reading a boolean value, any non-zero value is considered true.
	/// </summary>
	public struct Boolean : ISerialize 
	{
		public System.Boolean Value { get; private set; }

		public Boolean(System.Boolean value)
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

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadBoolean();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteBoolean(Value);
		}

		public static Boolean From(System.Boolean value)
		{
			return new Boolean(value);
		}
	}

	/// <summary>
	/// Represents an integer between -27 and 27-1 inclusive.
	/// </summary>
	public struct Int8 : ISerialize 
	{
		public System.SByte Value { get; private set; }

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

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadInt8();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteInt8(Value);
		}

		public static Int8 From(System.SByte value)
		{
			return new Int8(value);
		}
	}

	/// <summary>
	/// Represents an integer between -215 and 215-1 inclusive. The values are encoded using two bytes in network byte order (big-endian).
	/// </summary>
	public struct Int16 : ISerialize 
	{
		public System.Int16 Value { get; private set; }

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

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadInt16();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteInt16(Value);
		}

		public static Int16 From(System.Int16 value)
		{
			return new Int16(value);
		}
	}

	/// <summary>
	/// Represents an integer between -231 and 231-1 inclusive. The values are encoded using four bytes in network byte order (big-endian).
	/// </summary>
	public struct Int32 : ISerialize 
	{
		public System.Int32 Value { get; private set; }

		public Int32(System.Int32 value)
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

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadInt32();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteInt32(Value);
		}

		public static Int32 From(System.Int32 value)
		{
			return new Int32(value);
		}
	}

	/// <summary>
	/// Represents an integer between -263 and 263-1 inclusive. The values are encoded using eight bytes in network byte order (big-endian).
	/// </summary>
	public struct Int64 : ISerialize 
	{
		public System.Int64 Value { get; private set; }

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

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadInt64();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteInt64(Value);
		}

		public static Int64 From(System.Int64 value)
		{
			return new Int64(value);
		}
	}

	/// <summary>
	/// Represents an integer between 0 and 232-1 inclusive. The values are encoded using four bytes in network byte order (big-endian).
	/// </summary>
	public struct UInt32 : ISerialize 
	{
		public System.UInt32 Value { get; private set; }

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

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadUInt32();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteUInt32(Value);
		}

		public static UInt32 From(System.UInt32 value)
		{
			return new UInt32(value);
		}
	}

	/// <summary>
	/// Represents an integer between -231 and 231-1 inclusive. Encoding follows the variable-length zig-zag encoding from   Google Protocol Buffers.
	/// </summary>
	public struct VarInt : ISerialize 
	{
		public System.Int32 Value { get; private set; }

		public VarInt(System.Int32 value)
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

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadVarInt();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteVarInt(Value);
		}

		public static VarInt From(System.Int32 value)
		{
			return new VarInt(value);
		}
	}

	/// <summary>
	/// Represents an integer between -263 and 263-1 inclusive. Encoding follows the variable-length zig-zag encoding from   Google Protocol Buffers.
	/// </summary>
	public struct VarLong : ISerialize 
	{
		public System.Int64 Value { get; private set; }

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

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadVarLong();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteVarLong(Value);
		}

		public static VarLong From(System.Int64 value)
		{
			return new VarLong(value);
		}
	}

	/// <summary>
	/// Represents a sequence of characters. First the length N is given as an INT16. Then N bytes follow which are the UTF-8 encoding of the character sequence. Length must not be negative.
	/// </summary>
	public struct String : ISerialize 
	{
		public System.String Value { get; private set; }

		public String(System.String value)
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

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadString();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteString(Value);
		}

		public static String From(System.String value)
		{
			return new String(value);
		}
	}

	/// <summary>
	/// Represents a sequence of characters or null. For non-null strings, first the length N is given as an INT16. Then N bytes follow which are the UTF-8 encoding of the character sequence. A null value is encoded with length of -1 and there are no following bytes.
	/// </summary>
	public struct NullableString : ISerialize 
	{
		public System.String Value { get; private set; }

		public NullableString(System.String value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is NullableString comparingNullableString && this == comparingNullableString;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (NullableString x, NullableString y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (NullableString x, NullableString y)
		{
			return !(x == y);
		}

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadNullableString();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteNullableString(Value);
		}

		public static NullableString From(System.String value)
		{
			return new NullableString(value);
		}
	}

	/// <summary>
	/// Represents a raw sequence of bytes. First the length N is given as an INT32. Then N bytes follow.
	/// </summary>
	public struct Bytes : ISerialize 
	{
		public System.Byte[] Value { get; private set; }

		public Bytes(System.Byte[] value)
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

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadBytes();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteBytes(Value);
		}

		public static Bytes From(System.Byte[] value)
		{
			return new Bytes(value);
		}
	}

	/// <summary>
	/// Represents a raw sequence of bytes or null. For non-null values, first the length N is given as an INT32. Then N bytes follow. A null value is encoded with length of -1 and there are no following bytes.
	/// </summary>
	public struct NullableBytes : ISerialize 
	{
		public System.Byte[] Value { get; private set; }

		public NullableBytes(System.Byte[] value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is NullableBytes comparingNullableBytes && this == comparingNullableBytes;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (NullableBytes x, NullableBytes y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (NullableBytes x, NullableBytes y)
		{
			return !(x == y);
		}

		public void ReadFrom(IKafkaReader reader)
		{
			Value = reader.ReadNullableBytes();
		}

		public void WriteTo(IKafkaWriter writer)
		{
			writer.WriteNullableBytes(Value);
		}

		public static NullableBytes From(System.Byte[] value)
		{
			return new NullableBytes(value);
		}
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

	public class AddOffsetsToTxnRequest
	{
		public AddOffsetsToTxnRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 25;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TransactionalId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProducerId = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProducerEpoch = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupId = new String(reader.ReadString());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(TransactionalId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(ProducerId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ProducerEpoch.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(GroupId.Value);
			}
		}

		/// <summary>
		/// The transactional id corresponding to the transaction.
		/// </summary>
		public String TransactionalId { get; set; }

		/// <summary>
		/// Current producer id in use by the transactional id.
		/// </summary>
		public Int64 ProducerId { get; set; }

		/// <summary>
		/// Current epoch associated with the producer id.
		/// </summary>
		public Int16 ProducerEpoch { get; set; }

		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public String GroupId { get; set; }
	}

	public class AddOffsetsToTxnResponse
	{
		public AddOffsetsToTxnResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 25;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The response error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }
	}

	public class AddPartitionsToTxnRequest
	{
		public AddPartitionsToTxnRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 24;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TransactionalId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProducerId = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProducerEpoch = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new AddPartitionsToTxnTopic(Version)).ToDictionary(field => field.Name);
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(TransactionalId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(ProducerId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ProducerEpoch.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The transactional id corresponding to the transaction.
		/// </summary>
		public String TransactionalId { get; set; }

		/// <summary>
		/// Current producer id in use by the transactional id.
		/// </summary>
		public Int64 ProducerId { get; set; }

		/// <summary>
		/// Current epoch associated with the producer id.
		/// </summary>
		public Int16 ProducerEpoch { get; set; }

		/// <summary>
		/// The partitions to add to the transation.
		/// </summary>
		public Dictionary<String, AddPartitionsToTxnTopic> TopicsCollection { get; set; }

		public class AddPartitionsToTxnTopic : ISerialize
		{
			public AddPartitionsToTxnTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The name of the topic.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The partition indexes to add to the transaction
			/// </summary>
			public Int32[] PartitionsCollection { get; set; }
		}
	}

	public class AddPartitionsToTxnResponse
	{
		public AddPartitionsToTxnResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 24;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResultsCollection = reader.Read(() => new AddPartitionsToTxnTopicResult(Version)).ToDictionary(field => field.Name);
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResultsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The results for each topic.
		/// </summary>
		public Dictionary<String, AddPartitionsToTxnTopicResult> ResultsCollection { get; set; }

		public class AddPartitionsToTxnTopicResult : ISerialize
		{
			public AddPartitionsToTxnTopicResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResultsCollection = reader.Read(() => new AddPartitionsToTxnPartitionResult(Version)).ToDictionary(field => field.PartitionIndex);
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(ResultsCollection.Values.ToArray());
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The results for each partition
			/// </summary>
			public Dictionary<Int32, AddPartitionsToTxnPartitionResult> ResultsCollection { get; set; }

			public class AddPartitionsToTxnPartitionResult : ISerialize
			{
				public AddPartitionsToTxnPartitionResult(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
				}

				/// <summary>
				/// The partition indexes.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The response error code.
				/// </summary>
				public Int16 ErrorCode { get; set; }
			}
		}
	}

	public class AlterConfigsRequest
	{
		public AlterConfigsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 33;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResourcesCollection = reader.Read(() => new AlterConfigsResource(Version)).ToDictionary(field => field.ResourceType);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ValidateOnly = new Boolean(reader.ReadBoolean());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResourcesCollection.Values.ToArray());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteBoolean(ValidateOnly.Value);
			}
		}

		/// <summary>
		/// The updates for each resource.
		/// </summary>
		public Dictionary<Int8, AlterConfigsResource> ResourcesCollection { get; set; }

		public class AlterConfigsResource : ISerialize
		{
			public AlterConfigsResource(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceType = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ConfigsCollection = reader.Read(() => new AlterableConfig(Version)).ToDictionary(field => field.Name);
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(ResourceType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ResourceName.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(ConfigsCollection.Values.ToArray());
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceType { get; set; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceName { get; set; }

			/// <summary>
			/// The configurations.
			/// </summary>
			public Dictionary<String, AlterableConfig> ConfigsCollection { get; set; }

			public class AlterableConfig : ISerialize
			{
				public AlterableConfig(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Name = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Value = new String(reader.ReadString());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Name.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Value.Value);
					}
				}

				/// <summary>
				/// The configuration key name.
				/// </summary>
				public String Name { get; set; }

				/// <summary>
				/// The value to set for the configuration key.
				/// </summary>
				public String Value { get; set; }
			}
		}

		/// <summary>
		/// True if we should validate the request, but not change the configurations.
		/// </summary>
		public Boolean ValidateOnly { get; set; }
	}

	public class AlterConfigsResponse
	{
		public AlterConfigsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 33;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResourcesCollection = reader.Read(() => new AlterConfigsResourceResponse(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResourcesCollection);
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The responses for each resource.
		/// </summary>
		public AlterConfigsResourceResponse[] ResourcesCollection { get; set; }

		public class AlterConfigsResourceResponse : ISerialize
		{
			public AlterConfigsResourceResponse(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorMessage = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceType = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceName = new String(reader.ReadString());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ErrorMessage.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(ResourceType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ResourceName.Value);
				}
			}

			/// <summary>
			/// The resource error code.
			/// </summary>
			public Int16 ErrorCode { get; set; }

			/// <summary>
			/// The resource error message, or null if there was no error.
			/// </summary>
			public String ErrorMessage { get; set; }

			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceType { get; set; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceName { get; set; }
		}
	}

	public class AlterReplicaLogDirsRequest
	{
		public AlterReplicaLogDirsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 34;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				DirsCollection = reader.Read(() => new AlterReplicaLogDir(Version)).ToDictionary(field => field.Path);
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(DirsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The alterations to make for each directory.
		/// </summary>
		public Dictionary<String, AlterReplicaLogDir> DirsCollection { get; set; }

		public class AlterReplicaLogDir : ISerialize
		{
			public AlterReplicaLogDir(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Path = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TopicsCollection = reader.Read(() => new AlterReplicaLogDirTopic(Version)).ToDictionary(field => field.Name);
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Path.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(TopicsCollection.Values.ToArray());
				}
			}

			/// <summary>
			/// The absolute directory path.
			/// </summary>
			public String Path { get; set; }

			/// <summary>
			/// The topics to add to the directory.
			/// </summary>
			public Dictionary<String, AlterReplicaLogDirTopic> TopicsCollection { get; set; }

			public class AlterReplicaLogDirTopic : ISerialize
			{
				public AlterReplicaLogDirTopic(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Name = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionsCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Name.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(PartitionsCollection);
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				public String Name { get; set; }

				/// <summary>
				/// The partition indexes.
				/// </summary>
				public Int32[] PartitionsCollection { get; set; }
			}
		}
	}

	public class AlterReplicaLogDirsResponse
	{
		public AlterReplicaLogDirsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 34;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResultsCollection = reader.Read(() => new AlterReplicaLogDirTopicResult(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResultsCollection);
			}
		}

		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The results for each topic.
		/// </summary>
		public AlterReplicaLogDirTopicResult[] ResultsCollection { get; set; }

		public class AlterReplicaLogDirTopicResult : ISerialize
		{
			public AlterReplicaLogDirTopicResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TopicName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new AlterReplicaLogDirPartitionResult(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(TopicName.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The name of the topic.
			/// </summary>
			public String TopicName { get; set; }

			/// <summary>
			/// The results for each partition.
			/// </summary>
			public AlterReplicaLogDirPartitionResult[] PartitionsCollection { get; set; }

			public class AlterReplicaLogDirPartitionResult : ISerialize
			{
				public AlterReplicaLogDirPartitionResult(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode { get; set; }
			}
		}
	}

	public class ApiVersionsRequest
	{
		public ApiVersionsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 18;

		public void ReadFrom(IKafkaReader reader)
		{

		}

		public void WriteTo(IKafkaWriter writer)
		{

		}


	}

	public class ApiVersionsResponse
	{
		public ApiVersionsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 18;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ApiKeysCollection = reader.Read(() => new ApiVersionsResponseKey(Version)).ToDictionary(field => field.Index);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ApiKeysCollection.Values.ToArray());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
		}

		/// <summary>
		/// The top-level error code.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The APIs supported by the broker.
		/// </summary>
		public Dictionary<Int16, ApiVersionsResponseKey> ApiKeysCollection { get; set; }

		public class ApiVersionsResponseKey : ISerialize
		{
			public ApiVersionsResponseKey(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Index = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					MinVersion = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					MaxVersion = new Int16(reader.ReadInt16());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(Index.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(MinVersion.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(MaxVersion.Value);
				}
			}

			/// <summary>
			/// The API index.
			/// </summary>
			public Int16 Index { get; set; }

			/// <summary>
			/// The minimum supported version, inclusive.
			/// </summary>
			public Int16 MinVersion { get; set; }

			/// <summary>
			/// The maximum supported version, inclusive.
			/// </summary>
			public Int16 MaxVersion { get; set; }
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }
	}

	public class ControlledShutdownRequest
	{
		public ControlledShutdownRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 7;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				BrokerId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				BrokerEpoch = new Int64(reader.ReadInt64());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(BrokerId.Value);
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				writer.WriteInt64(BrokerEpoch.Value);
			}
		}

		/// <summary>
		/// The id of the broker for which controlled shutdown has been requested.
		/// </summary>
		public Int32 BrokerId { get; set; }

		/// <summary>
		/// The broker epoch.
		/// </summary>
		public Int64 BrokerEpoch { get; set; } = new Int64(-1);
	}

	public class ControlledShutdownResponse
	{
		public ControlledShutdownResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 7;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				RemainingPartitionsCollection = reader.Read(() => new RemainingPartition(Version)).ToDictionary(field => field.TopicName);
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(RemainingPartitionsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The top-level error code.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The partitions that the broker still leads.
		/// </summary>
		public Dictionary<String, RemainingPartition> RemainingPartitionsCollection { get; set; }

		public class RemainingPartition : ISerialize
		{
			public RemainingPartition(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TopicName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionIndex = new Int32(reader.ReadInt32());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(TopicName.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(PartitionIndex.Value);
				}
			}

			/// <summary>
			/// The name of the topic.
			/// </summary>
			public String TopicName { get; set; }

			/// <summary>
			/// The index of the partition.
			/// </summary>
			public Int32 PartitionIndex { get; set; }
		}
	}

	public class CreateAclsRequest
	{
		public CreateAclsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 30;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				CreationsCollection = reader.Read(() => new CreatableAcl(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(CreationsCollection);
			}
		}

		/// <summary>
		/// The ACLs that we want to create.
		/// </summary>
		public CreatableAcl[] CreationsCollection { get; set; }

		public class CreatableAcl : ISerialize
		{
			public CreatableAcl(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceType = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					ResourcePatternType = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Principal = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Host = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Operation = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PermissionType = new Int8(reader.ReadInt8());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(ResourceType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ResourceName.Value);
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					writer.WriteInt8(ResourcePatternType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Principal.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Host.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(Operation.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(PermissionType.Value);
				}
			}

			/// <summary>
			/// The type of the resource.
			/// </summary>
			public Int8 ResourceType { get; set; }

			/// <summary>
			/// The resource name for the ACL.
			/// </summary>
			public String ResourceName { get; set; }

			/// <summary>
			/// The pattern type for the ACL.
			/// </summary>
			public Int8 ResourcePatternType { get; set; } = new Int8(3);

			/// <summary>
			/// The principal for the ACL.
			/// </summary>
			public String Principal { get; set; }

			/// <summary>
			/// The host for the ACL.
			/// </summary>
			public String Host { get; set; }

			/// <summary>
			/// The operation type for the ACL (read, write, etc.).
			/// </summary>
			public Int8 Operation { get; set; }

			/// <summary>
			/// The permission type for the ACL (allow, deny, etc.).
			/// </summary>
			public Int8 PermissionType { get; set; }
		}
	}

	public class CreateAclsResponse
	{
		public CreateAclsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 30;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResultsCollection = reader.Read(() => new CreatableAclResult(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The results for each ACL creation.
		/// </summary>
		public CreatableAclResult[] ResultsCollection { get; set; }

		public class CreatableAclResult : ISerialize
		{
			public CreatableAclResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorMessage = new String(reader.ReadString());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ErrorMessage.Value);
				}
			}

			/// <summary>
			/// The result error, or zero if there was no error.
			/// </summary>
			public Int16 ErrorCode { get; set; }

			/// <summary>
			/// The result message, or null if there was no error.
			/// </summary>
			public String ErrorMessage { get; set; }
		}
	}

	public class CreateDelegationTokenRequest
	{
		public CreateDelegationTokenRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 38;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				RenewersCollection = reader.Read(() => new CreatableRenewers(Version));
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MaxLifetimeMs = new Int64(reader.ReadInt64());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(RenewersCollection);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(MaxLifetimeMs.Value);
			}
		}

		/// <summary>
		/// A list of those who are allowed to renew this token before it expires.
		/// </summary>
		public CreatableRenewers[] RenewersCollection { get; set; }

		public class CreatableRenewers : ISerialize
		{
			public CreatableRenewers(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PrincipalType = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PrincipalName = new String(reader.ReadString());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(PrincipalType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(PrincipalName.Value);
				}
			}

			/// <summary>
			/// The type of the Kafka principal.
			/// </summary>
			public String PrincipalType { get; set; }

			/// <summary>
			/// The name of the Kafka principal.
			/// </summary>
			public String PrincipalName { get; set; }
		}

		/// <summary>
		/// The maximum lifetime of the token in milliseconds, or -1 to use the server side default.
		/// </summary>
		public Int64 MaxLifetimeMs { get; set; }
	}

	public class CreateDelegationTokenResponse
	{
		public CreateDelegationTokenResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 38;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				PrincipalType = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				PrincipalName = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				IssueTimestampMs = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ExpiryTimestampMs = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MaxTimestampMs = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TokenId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Hmac = new Bytes(reader.ReadBytes());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(PrincipalType.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(PrincipalName.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(IssueTimestampMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(ExpiryTimestampMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(MaxTimestampMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(TokenId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteBytes(Hmac.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
		}

		/// <summary>
		/// The top-level error, or zero if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The principal type of the token owner.
		/// </summary>
		public String PrincipalType { get; set; }

		/// <summary>
		/// The name of the token owner.
		/// </summary>
		public String PrincipalName { get; set; }

		/// <summary>
		/// When this token was generated.
		/// </summary>
		public Int64 IssueTimestampMs { get; set; }

		/// <summary>
		/// When this token expires.
		/// </summary>
		public Int64 ExpiryTimestampMs { get; set; }

		/// <summary>
		/// The maximum lifetime of this token.
		/// </summary>
		public Int64 MaxTimestampMs { get; set; }

		/// <summary>
		/// The token UUID.
		/// </summary>
		public String TokenId { get; set; }

		/// <summary>
		/// HMAC of the delegation token.
		/// </summary>
		public Bytes Hmac { get; set; }

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }
	}

	public class CreatePartitionsRequest
	{
		public CreatePartitionsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 37;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new CreatePartitionsTopic(Version));
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TimeoutMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ValidateOnly = new Boolean(reader.ReadBoolean());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(TimeoutMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteBoolean(ValidateOnly.Value);
			}
		}

		/// <summary>
		/// Each topic that we want to create new partitions inside.
		/// </summary>
		public CreatePartitionsTopic[] TopicsCollection { get; set; }

		public class CreatePartitionsTopic : ISerialize
		{
			public CreatePartitionsTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Count = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					AssignmentsCollection = reader.Read(() => new CreatePartitionsAssignment(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(Count.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(AssignmentsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The new partition count.
			/// </summary>
			public Int32 Count { get; set; }

			/// <summary>
			/// The new partition assignments.
			/// </summary>
			public CreatePartitionsAssignment[] AssignmentsCollection { get; set; }

			public class CreatePartitionsAssignment : ISerialize
			{
				public CreatePartitionsAssignment(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						BrokerIdsCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(BrokerIdsCollection);
					}
				}

				/// <summary>
				/// The assigned broker IDs.
				/// </summary>
				public Int32[] BrokerIdsCollection { get; set; }
			}
		}

		/// <summary>
		/// The time in ms to wait for the partitions to be created.
		/// </summary>
		public Int32 TimeoutMs { get; set; }

		/// <summary>
		/// If true, then validate the request, but don't actually increase the number of partitions.
		/// </summary>
		public Boolean ValidateOnly { get; set; }
	}

	public class CreatePartitionsResponse
	{
		public CreatePartitionsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 37;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResultsCollection = reader.Read(() => new CreatePartitionsTopicResult(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The partition creation results for each topic.
		/// </summary>
		public CreatePartitionsTopicResult[] ResultsCollection { get; set; }

		public class CreatePartitionsTopicResult : ISerialize
		{
			public CreatePartitionsTopicResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorMessage = new String(reader.ReadString());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ErrorMessage.Value);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The result error, or zero if there was no error.
			/// </summary>
			public Int16 ErrorCode { get; set; }

			/// <summary>
			/// The result message, or null if there was no error.
			/// </summary>
			public String ErrorMessage { get; set; }
		}
	}

	public class CreateTopicsRequest
	{
		public CreateTopicsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 19;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new CreatableTopic(Version)).ToDictionary(field => field.Name);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				timeoutMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				validateOnly = new Boolean(reader.ReadBoolean());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection.Values.ToArray());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(timeoutMs.Value);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteBoolean(validateOnly.Value);
			}
		}

		/// <summary>
		/// The topics to create.
		/// </summary>
		public Dictionary<String, CreatableTopic> TopicsCollection { get; set; }

		public class CreatableTopic : ISerialize
		{
			public CreatableTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					NumPartitions = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ReplicationFactor = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					AssignmentsCollection = reader.Read(() => new CreatableReplicaAssignment(Version)).ToDictionary(field => field.PartitionIndex);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ConfigsCollection = reader.Read(() => new CreateableTopicConfig(Version)).ToDictionary(field => field.Name);
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(NumPartitions.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ReplicationFactor.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(AssignmentsCollection.Values.ToArray());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(ConfigsCollection.Values.ToArray());
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The number of partitions to create in the topic, or -1 if we are specifying a manual partition assignment.
			/// </summary>
			public Int32 NumPartitions { get; set; }

			/// <summary>
			/// The number of replicas to create for each partition in the topic, or -1 if we are specifying a manual partition assignment.
			/// </summary>
			public Int16 ReplicationFactor { get; set; }

			/// <summary>
			/// The manual partition assignment, or the empty array if we are using automatic assignment.
			/// </summary>
			public Dictionary<Int32, CreatableReplicaAssignment> AssignmentsCollection { get; set; }

			public class CreatableReplicaAssignment : ISerialize
			{
				public CreatableReplicaAssignment(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						BrokerIdsCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(BrokerIdsCollection);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The brokers to place the partition on.
				/// </summary>
				public Int32[] BrokerIdsCollection { get; set; }
			}

			/// <summary>
			/// The custom topic configurations to set.
			/// </summary>
			public Dictionary<String, CreateableTopicConfig> ConfigsCollection { get; set; }

			public class CreateableTopicConfig : ISerialize
			{
				public CreateableTopicConfig(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Name = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Value = new String(reader.ReadString());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Name.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Value.Value);
					}
				}

				/// <summary>
				/// The configuration name.
				/// </summary>
				public String Name { get; set; }

				/// <summary>
				/// The configuration value.
				/// </summary>
				public String Value { get; set; }
			}
		}

		/// <summary>
		/// How long to wait in milliseconds before timing out the request.
		/// </summary>
		public Int32 timeoutMs { get; set; } = new Int32(60000);

		/// <summary>
		/// If true, check that the topics can be created as specified, but don't create anything.
		/// </summary>
		public Boolean validateOnly { get; set; } = new Boolean(false);
	}

	public class CreateTopicsResponse
	{
		public CreateTopicsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 19;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new CreatableTopicResult(Version)).ToDictionary(field => field.Name);
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// Results for each topic we tried to create.
		/// </summary>
		public Dictionary<String, CreatableTopicResult> TopicsCollection { get; set; }

		public class CreatableTopicResult : ISerialize
		{
			public CreatableTopicResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					ErrorMessage = new String(reader.ReadString());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					writer.WriteString(ErrorMessage.Value);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The error code, or 0 if there was no error.
			/// </summary>
			public Int16 ErrorCode { get; set; }

			/// <summary>
			/// The error message, or null if there was no error.
			/// </summary>
			public String ErrorMessage { get; set; }
		}
	}

	public class DeleteAclsRequest
	{
		public DeleteAclsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 31;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				FiltersCollection = reader.Read(() => new DeleteAclsFilter(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(FiltersCollection);
			}
		}

		/// <summary>
		/// The filters to use when deleting ACLs.
		/// </summary>
		public DeleteAclsFilter[] FiltersCollection { get; set; }

		public class DeleteAclsFilter : ISerialize
		{
			public DeleteAclsFilter(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceTypeFilter = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceNameFilter = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					PatternTypeFilter = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PrincipalFilter = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					HostFilter = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Operation = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PermissionType = new Int8(reader.ReadInt8());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(ResourceTypeFilter.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ResourceNameFilter.Value);
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					writer.WriteInt8(PatternTypeFilter.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(PrincipalFilter.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(HostFilter.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(Operation.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(PermissionType.Value);
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceTypeFilter { get; set; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceNameFilter { get; set; }

			/// <summary>
			/// The pattern type.
			/// </summary>
			public Int8 PatternTypeFilter { get; set; } = new Int8(3);

			/// <summary>
			/// The principal filter, or null to accept all principals.
			/// </summary>
			public String PrincipalFilter { get; set; }

			/// <summary>
			/// The host filter, or null to accept all hosts.
			/// </summary>
			public String HostFilter { get; set; }

			/// <summary>
			/// The ACL operation.
			/// </summary>
			public Int8 Operation { get; set; }

			/// <summary>
			/// The permission type.
			/// </summary>
			public Int8 PermissionType { get; set; }
		}
	}

	public class DeleteAclsResponse
	{
		public DeleteAclsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 31;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				FilterResultsCollection = reader.Read(() => new DeleteAclsFilterResult(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(FilterResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The results for each filter.
		/// </summary>
		public DeleteAclsFilterResult[] FilterResultsCollection { get; set; }

		public class DeleteAclsFilterResult : ISerialize
		{
			public DeleteAclsFilterResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorMessage = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					MatchingAclsCollection = reader.Read(() => new DeleteAclsMatchingAcl(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ErrorMessage.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(MatchingAclsCollection);
				}
			}

			/// <summary>
			/// The error code, or 0 if the filter succeeded.
			/// </summary>
			public Int16 ErrorCode { get; set; }

			/// <summary>
			/// The error message, or null if the filter succeeded.
			/// </summary>
			public String ErrorMessage { get; set; }

			/// <summary>
			/// The ACLs which matched this filter.
			/// </summary>
			public DeleteAclsMatchingAcl[] MatchingAclsCollection { get; set; }

			public class DeleteAclsMatchingAcl : ISerialize
			{
				public DeleteAclsMatchingAcl(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorMessage = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ResourceType = new Int8(reader.ReadInt8());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ResourceName = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						PatternType = new Int8(reader.ReadInt8());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Principal = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Host = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Operation = new Int8(reader.ReadInt8());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PermissionType = new Int8(reader.ReadInt8());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(ErrorMessage.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt8(ResourceType.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(ResourceName.Value);
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.WriteInt8(PatternType.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Principal.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Host.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt8(Operation.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt8(PermissionType.Value);
					}
				}

				/// <summary>
				/// The deletion error code, or 0 if the deletion succeeded.
				/// </summary>
				public Int16 ErrorCode { get; set; }

				/// <summary>
				/// The deletion error message, or null if the deletion succeeded.
				/// </summary>
				public String ErrorMessage { get; set; }

				/// <summary>
				/// The ACL resource type.
				/// </summary>
				public Int8 ResourceType { get; set; }

				/// <summary>
				/// The ACL resource name.
				/// </summary>
				public String ResourceName { get; set; }

				/// <summary>
				/// The ACL resource pattern type.
				/// </summary>
				public Int8 PatternType { get; set; } = new Int8(3);

				/// <summary>
				/// The ACL principal.
				/// </summary>
				public String Principal { get; set; }

				/// <summary>
				/// The ACL host.
				/// </summary>
				public String Host { get; set; }

				/// <summary>
				/// The ACL operation.
				/// </summary>
				public Int8 Operation { get; set; }

				/// <summary>
				/// The ACL permission type.
				/// </summary>
				public Int8 PermissionType { get; set; }
			}
		}
	}

	public class DeleteGroupsRequest
	{
		public DeleteGroupsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 42;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupsNamesCollection = reader.Read(() => new String(reader.ReadString()));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(GroupsNamesCollection);
			}
		}

		/// <summary>
		/// The group names to delete.
		/// </summary>
		public String[] GroupsNamesCollection { get; set; }
	}

	public class DeleteGroupsResponse
	{
		public DeleteGroupsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 42;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResultsCollection = reader.Read(() => new DeletableGroupResult(Version)).ToDictionary(field => field.GroupId);
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResultsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The deletion results
		/// </summary>
		public Dictionary<String, DeletableGroupResult> ResultsCollection { get; set; }

		public class DeletableGroupResult : ISerialize
		{
			public DeletableGroupResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					GroupId = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(GroupId.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
			}

			/// <summary>
			/// The group id
			/// </summary>
			public String GroupId { get; set; }

			/// <summary>
			/// The deletion error, or 0 if the deletion succeeded.
			/// </summary>
			public Int16 ErrorCode { get; set; }
		}
	}

	public class DeleteRecordsRequest
	{
		public DeleteRecordsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 21;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new DeleteRecordsTopic(Version));
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TimeoutMs = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(TimeoutMs.Value);
			}
		}

		/// <summary>
		/// Each topic that we want to delete records from.
		/// </summary>
		public DeleteRecordsTopic[] TopicsCollection { get; set; }

		public class DeleteRecordsTopic : ISerialize
		{
			public DeleteRecordsTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new DeleteRecordsPartition(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// Each partition that we want to delete records from.
			/// </summary>
			public DeleteRecordsPartition[] PartitionsCollection { get; set; }

			public class DeleteRecordsPartition : ISerialize
			{
				public DeleteRecordsPartition(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Offset = new Int64(reader.ReadInt64());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt64(Offset.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The deletion offset.
				/// </summary>
				public Int64 Offset { get; set; }
			}
		}

		/// <summary>
		/// How long to wait for the deletion to complete, in milliseconds.
		/// </summary>
		public Int32 TimeoutMs { get; set; }
	}

	public class DeleteRecordsResponse
	{
		public DeleteRecordsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 21;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new DeleteRecordsTopicResult(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// Each topic that we wanted to delete records from.
		/// </summary>
		public DeleteRecordsTopicResult[] TopicsCollection { get; set; }

		public class DeleteRecordsTopicResult : ISerialize
		{
			public DeleteRecordsTopicResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new DeleteRecordsPartitionResult(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// Each partition that we wanted to delete records from.
			/// </summary>
			public DeleteRecordsPartitionResult[] PartitionsCollection { get; set; }

			public class DeleteRecordsPartitionResult : ISerialize
			{
				public DeleteRecordsPartitionResult(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						LowWatermark = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt64(LowWatermark.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The partition low water mark.
				/// </summary>
				public Int64 LowWatermark { get; set; }

				/// <summary>
				/// The deletion error code, or 0 if the deletion succeeded.
				/// </summary>
				public Int16 ErrorCode { get; set; }
			}
		}
	}

	public class DeleteTopicsRequest
	{
		public DeleteTopicsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 20;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicNamesCollection = reader.Read(() => new String(reader.ReadString()));
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TimeoutMs = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicNamesCollection);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(TimeoutMs.Value);
			}
		}

		/// <summary>
		/// The names of the topics to delete
		/// </summary>
		public String[] TopicNamesCollection { get; set; }

		/// <summary>
		/// The length of time in milliseconds to wait for the deletions to complete.
		/// </summary>
		public Int32 TimeoutMs { get; set; }
	}

	public class DeleteTopicsResponse
	{
		public DeleteTopicsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 20;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResponsesCollection = reader.Read(() => new DeletableTopicResult(Version)).ToDictionary(field => field.Name);
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResponsesCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The results for each topic we tried to delete.
		/// </summary>
		public Dictionary<String, DeletableTopicResult> ResponsesCollection { get; set; }

		public class DeletableTopicResult : ISerialize
		{
			public DeletableTopicResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The deletion error, or 0 if the deletion succeeded.
			/// </summary>
			public Int16 ErrorCode { get; set; }
		}
	}

	public class DescribeAclsRequest
	{
		public DescribeAclsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 29;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResourceType = new Int8(reader.ReadInt8());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResourceNameFilter = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ResourcePatternType = new Int8(reader.ReadInt8());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				PrincipalFilter = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				HostFilter = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Operation = new Int8(reader.ReadInt8());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				PermissionType = new Int8(reader.ReadInt8());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt8(ResourceType.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(ResourceNameFilter.Value);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt8(ResourcePatternType.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(PrincipalFilter.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(HostFilter.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt8(Operation.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt8(PermissionType.Value);
			}
		}

		/// <summary>
		/// The resource type.
		/// </summary>
		public Int8 ResourceType { get; set; }

		/// <summary>
		/// The resource name, or null to match any resource name.
		/// </summary>
		public String ResourceNameFilter { get; set; }

		/// <summary>
		/// The resource pattern to match.
		/// </summary>
		public Int8 ResourcePatternType { get; set; } = new Int8(3);

		/// <summary>
		/// The principal to match, or null to match any principal.
		/// </summary>
		public String PrincipalFilter { get; set; }

		/// <summary>
		/// The host to match, or null to match any host.
		/// </summary>
		public String HostFilter { get; set; }

		/// <summary>
		/// The operation to match.
		/// </summary>
		public Int8 Operation { get; set; }

		/// <summary>
		/// The permission type to match.
		/// </summary>
		public Int8 PermissionType { get; set; }
	}

	public class DescribeAclsResponse
	{
		public DescribeAclsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 29;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorMessage = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResourcesCollection = reader.Read(() => new DescribeAclsResource(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(ErrorMessage.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResourcesCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public String ErrorMessage { get; set; }

		/// <summary>
		/// Each Resource that is referenced in an ACL.
		/// </summary>
		public DescribeAclsResource[] ResourcesCollection { get; set; }

		public class DescribeAclsResource : ISerialize
		{
			public DescribeAclsResource(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Type = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					PatternType = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					AclsCollection = reader.Read(() => new AclDescription(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(Type.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					writer.WriteInt8(PatternType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(AclsCollection);
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 Type { get; set; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The resource pattern type.
			/// </summary>
			public Int8 PatternType { get; set; } = new Int8(3);

			/// <summary>
			/// The ACLs.
			/// </summary>
			public AclDescription[] AclsCollection { get; set; }

			public class AclDescription : ISerialize
			{
				public AclDescription(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Principal = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Host = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Operation = new Int8(reader.ReadInt8());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PermissionType = new Int8(reader.ReadInt8());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Principal.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Host.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt8(Operation.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt8(PermissionType.Value);
					}
				}

				/// <summary>
				/// The ACL principal.
				/// </summary>
				public String Principal { get; set; }

				/// <summary>
				/// The ACL host.
				/// </summary>
				public String Host { get; set; }

				/// <summary>
				/// The ACL operation.
				/// </summary>
				public Int8 Operation { get; set; }

				/// <summary>
				/// The ACL permission type.
				/// </summary>
				public Int8 PermissionType { get; set; }
			}
		}
	}

	public class DescribeConfigsRequest
	{
		public DescribeConfigsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 32;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResourcesCollection = reader.Read(() => new DescribeConfigsResource(Version));
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				IncludeSynoyms = new Boolean(reader.ReadBoolean());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResourcesCollection);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteBoolean(IncludeSynoyms.Value);
			}
		}

		/// <summary>
		/// The resources whose configurations we want to describe.
		/// </summary>
		public DescribeConfigsResource[] ResourcesCollection { get; set; }

		public class DescribeConfigsResource : ISerialize
		{
			public DescribeConfigsResource(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceType = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ConfigurationKeysCollection = reader.Read(() => new String(reader.ReadString()));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(ResourceType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ResourceName.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(ConfigurationKeysCollection);
				}
			}

			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceType { get; set; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceName { get; set; }

			/// <summary>
			/// The configuration keys to list, or null to list all configuration keys.
			/// </summary>
			public String[] ConfigurationKeysCollection { get; set; }
		}

		/// <summary>
		/// True if we should include all synonyms.
		/// </summary>
		public Boolean IncludeSynoyms { get; set; } = new Boolean(false);
	}

	public class DescribeConfigsResponse
	{
		public DescribeConfigsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 32;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResultsCollection = reader.Read(() => new DescribeConfigsResult(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The results for each resource.
		/// </summary>
		public DescribeConfigsResult[] ResultsCollection { get; set; }

		public class DescribeConfigsResult : ISerialize
		{
			public DescribeConfigsResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorMessage = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceType = new Int8(reader.ReadInt8());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ResourceName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ConfigsCollection = reader.Read(() => new DescribeConfigsResourceResult(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ErrorMessage.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt8(ResourceType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ResourceName.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(ConfigsCollection);
				}
			}

			/// <summary>
			/// The error code, or 0 if we were able to successfully describe the configurations.
			/// </summary>
			public Int16 ErrorCode { get; set; }

			/// <summary>
			/// The error message, or null if we were able to successfully describe the configurations.
			/// </summary>
			public String ErrorMessage { get; set; }

			/// <summary>
			/// The resource type.
			/// </summary>
			public Int8 ResourceType { get; set; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public String ResourceName { get; set; }

			/// <summary>
			/// Each listed configuration.
			/// </summary>
			public DescribeConfigsResourceResult[] ConfigsCollection { get; set; }

			public class DescribeConfigsResourceResult : ISerialize
			{
				public DescribeConfigsResourceResult(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Name = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Value = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ReadOnly = new Boolean(reader.ReadBoolean());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						IsDefault = new Boolean(reader.ReadBoolean());
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						ConfigSource = new Int8(reader.ReadInt8());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						IsSensitive = new Boolean(reader.ReadBoolean());
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						SynonymsCollection = reader.Read(() => new DescribeConfigsSynonym(Version));
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Name.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Value.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteBoolean(ReadOnly.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteBoolean(IsDefault.Value);
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.WriteInt8(ConfigSource.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteBoolean(IsSensitive.Value);
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.Write(SynonymsCollection);
					}
				}

				/// <summary>
				/// The configuration name.
				/// </summary>
				public String Name { get; set; }

				/// <summary>
				/// The configuration value.
				/// </summary>
				public String Value { get; set; }

				/// <summary>
				/// True if the configuration is read-only.
				/// </summary>
				public Boolean ReadOnly { get; set; }

				/// <summary>
				/// True if the configuration is not set.
				/// </summary>
				public Boolean IsDefault { get; set; }

				/// <summary>
				/// The configuration source.
				/// </summary>
				public Int8 ConfigSource { get; set; } = new Int8(-1);

				/// <summary>
				/// True if this configuration is sensitive.
				/// </summary>
				public Boolean IsSensitive { get; set; }

				/// <summary>
				/// The synonyms for this configuration key.
				/// </summary>
				public DescribeConfigsSynonym[] SynonymsCollection { get; set; }

				public class DescribeConfigsSynonym : ISerialize
				{
					public DescribeConfigsSynonym(int version)
					{
						Version = version;
					}

					public int Version { get; }

					public void ReadFrom(IKafkaReader reader)
					{
						if (Version.InRange(new VersionRange(1, 2147483647))) 
						{
							Name = new String(reader.ReadString());
						}
						if (Version.InRange(new VersionRange(1, 2147483647))) 
						{
							Value = new String(reader.ReadString());
						}
						if (Version.InRange(new VersionRange(1, 2147483647))) 
						{
							Source = new Int8(reader.ReadInt8());
						}
					}

					public void WriteTo(IKafkaWriter writer)
					{
						if (Version.InRange(new VersionRange(1, 2147483647))) 
						{
							writer.WriteString(Name.Value);
						}
						if (Version.InRange(new VersionRange(1, 2147483647))) 
						{
							writer.WriteString(Value.Value);
						}
						if (Version.InRange(new VersionRange(1, 2147483647))) 
						{
							writer.WriteInt8(Source.Value);
						}
					}

					/// <summary>
					/// The synonym name.
					/// </summary>
					public String Name { get; set; }

					/// <summary>
					/// The synonym value.
					/// </summary>
					public String Value { get; set; }

					/// <summary>
					/// The synonym source.
					/// </summary>
					public Int8 Source { get; set; }
				}
			}
		}
	}

	public class DescribeDelegationTokenRequest
	{
		public DescribeDelegationTokenRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 41;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				OwnersCollection = reader.Read(() => new DescribeDelegationTokenOwner(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(OwnersCollection);
			}
		}

		/// <summary>
		/// Each owner that we want to describe delegation tokens for, or null to describe all tokens.
		/// </summary>
		public DescribeDelegationTokenOwner[] OwnersCollection { get; set; }

		public class DescribeDelegationTokenOwner : ISerialize
		{
			public DescribeDelegationTokenOwner(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PrincipalType = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PrincipalName = new String(reader.ReadString());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(PrincipalType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(PrincipalName.Value);
				}
			}

			/// <summary>
			/// The owner principal type.
			/// </summary>
			public String PrincipalType { get; set; }

			/// <summary>
			/// The owner principal name.
			/// </summary>
			public String PrincipalName { get; set; }
		}
	}

	public class DescribeDelegationTokenResponse
	{
		public DescribeDelegationTokenResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 41;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TokensCollection = reader.Read(() => new DescribedDelegationToken(Version));
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TokensCollection);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The tokens.
		/// </summary>
		public DescribedDelegationToken[] TokensCollection { get; set; }

		public class DescribedDelegationToken : ISerialize
		{
			public DescribedDelegationToken(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PrincipalType = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PrincipalName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					IssueTimestamp = new Int64(reader.ReadInt64());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ExpiryTimestamp = new Int64(reader.ReadInt64());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					MaxTimestamp = new Int64(reader.ReadInt64());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TokenId = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Hmac = new Bytes(reader.ReadBytes());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					RenewersCollection = reader.Read(() => new DescribedDelegationTokenRenewer(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(PrincipalType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(PrincipalName.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt64(IssueTimestamp.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt64(ExpiryTimestamp.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt64(MaxTimestamp.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(TokenId.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteBytes(Hmac.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(RenewersCollection);
				}
			}

			/// <summary>
			/// The token principal type.
			/// </summary>
			public String PrincipalType { get; set; }

			/// <summary>
			/// The token principal name.
			/// </summary>
			public String PrincipalName { get; set; }

			/// <summary>
			/// The token issue timestamp in milliseconds.
			/// </summary>
			public Int64 IssueTimestamp { get; set; }

			/// <summary>
			/// The token expiry timestamp in milliseconds.
			/// </summary>
			public Int64 ExpiryTimestamp { get; set; }

			/// <summary>
			/// The token maximum timestamp length in milliseconds.
			/// </summary>
			public Int64 MaxTimestamp { get; set; }

			/// <summary>
			/// The token ID.
			/// </summary>
			public String TokenId { get; set; }

			/// <summary>
			/// The token HMAC.
			/// </summary>
			public Bytes Hmac { get; set; }

			/// <summary>
			/// Those who are able to renew this token before it expires.
			/// </summary>
			public DescribedDelegationTokenRenewer[] RenewersCollection { get; set; }

			public class DescribedDelegationTokenRenewer : ISerialize
			{
				public DescribedDelegationTokenRenewer(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PrincipalType = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PrincipalName = new String(reader.ReadString());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(PrincipalType.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(PrincipalName.Value);
					}
				}

				/// <summary>
				/// The renewer principal type
				/// </summary>
				public String PrincipalType { get; set; }

				/// <summary>
				/// The renewer principal name
				/// </summary>
				public String PrincipalName { get; set; }
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }
	}

	public class DescribeGroupsRequest
	{
		public DescribeGroupsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 15;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupsCollection = reader.Read(() => new String(reader.ReadString()));
			}
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				IncludeAuthorizedOperations = new Boolean(reader.ReadBoolean());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(GroupsCollection);
			}
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				writer.WriteBoolean(IncludeAuthorizedOperations.Value);
			}
		}

		/// <summary>
		/// The names of the groups to describe
		/// </summary>
		public String[] GroupsCollection { get; set; }

		/// <summary>
		/// Whether to include authorized operations.
		/// </summary>
		public Boolean IncludeAuthorizedOperations { get; set; }
	}

	public class DescribeGroupsResponse
	{
		public DescribeGroupsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 15;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupsCollection = reader.Read(() => new DescribedGroup(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(GroupsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// Each described group.
		/// </summary>
		public DescribedGroup[] GroupsCollection { get; set; }

		public class DescribedGroup : ISerialize
		{
			public DescribedGroup(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					GroupId = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					GroupState = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ProtocolType = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ProtocolData = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					MembersCollection = reader.Read(() => new DescribedGroupMember(Version));
				}
				if (Version.InRange(new VersionRange(3, 2147483647))) 
				{
					AuthorizedOperations = new Int32(reader.ReadInt32());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(GroupId.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(GroupState.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ProtocolType.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ProtocolData.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(MembersCollection);
				}
				if (Version.InRange(new VersionRange(3, 2147483647))) 
				{
					writer.WriteInt32(AuthorizedOperations.Value);
				}
			}

			/// <summary>
			/// The describe error, or 0 if there was no error.
			/// </summary>
			public Int16 ErrorCode { get; set; }

			/// <summary>
			/// The group ID string.
			/// </summary>
			public String GroupId { get; set; }

			/// <summary>
			/// The group state string, or the empty string.
			/// </summary>
			public String GroupState { get; set; }

			/// <summary>
			/// The group protocol type, or the empty string.
			/// </summary>
			public String ProtocolType { get; set; }

			/// <summary>
			/// The group protocol data, or the empty string.
			/// </summary>
			public String ProtocolData { get; set; }

			/// <summary>
			/// The group members.
			/// </summary>
			public DescribedGroupMember[] MembersCollection { get; set; }

			public class DescribedGroupMember : ISerialize
			{
				public DescribedGroupMember(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						MemberId = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ClientId = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ClientHost = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						MemberMetadata = new Bytes(reader.ReadBytes());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						MemberAssignment = new Bytes(reader.ReadBytes());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(MemberId.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(ClientId.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(ClientHost.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteBytes(MemberMetadata.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteBytes(MemberAssignment.Value);
					}
				}

				/// <summary>
				/// The member ID assigned by the group coordinator.
				/// </summary>
				public String MemberId { get; set; }

				/// <summary>
				/// The client ID used in the member's latest join group request.
				/// </summary>
				public String ClientId { get; set; }

				/// <summary>
				/// The client host.
				/// </summary>
				public String ClientHost { get; set; }

				/// <summary>
				/// The metadata corresponding to the current group protocol in use.
				/// </summary>
				public Bytes MemberMetadata { get; set; }

				/// <summary>
				/// The current assignment provided by the group leader.
				/// </summary>
				public Bytes MemberAssignment { get; set; }
			}

			/// <summary>
			/// 32-bit bitfield to represent authorized operations for this group.
			/// </summary>
			public Int32 AuthorizedOperations { get; set; }
		}
	}

	public class DescribeLogDirsRequest
	{
		public DescribeLogDirsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 35;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new DescribableLogDirTopic(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// Each topic that we want to describe log directories for, or null for all topics.
		/// </summary>
		public DescribableLogDirTopic[] TopicsCollection { get; set; }

		public class DescribableLogDirTopic : ISerialize
		{
			public DescribableLogDirTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Topic = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionIndexCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Topic.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionIndexCollection);
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			public String Topic { get; set; }

			/// <summary>
			/// The partition indxes.
			/// </summary>
			public Int32[] PartitionIndexCollection { get; set; }
		}
	}

	public class DescribeLogDirsResponse
	{
		public DescribeLogDirsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 35;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResultsCollection = reader.Read(() => new DescribeLogDirsResult(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The log directories.
		/// </summary>
		public DescribeLogDirsResult[] ResultsCollection { get; set; }

		public class DescribeLogDirsResult : ISerialize
		{
			public DescribeLogDirsResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					LogDir = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TopicsCollection = reader.Read(() => new DescribeLogDirsTopic(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(LogDir.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(TopicsCollection);
				}
			}

			/// <summary>
			/// The error code, or 0 if there was no error.
			/// </summary>
			public Int16 ErrorCode { get; set; }

			/// <summary>
			/// The absolute log directory path.
			/// </summary>
			public String LogDir { get; set; }

			/// <summary>
			/// Each topic.
			/// </summary>
			public DescribeLogDirsTopic[] TopicsCollection { get; set; }

			public class DescribeLogDirsTopic : ISerialize
			{
				public DescribeLogDirsTopic(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Name = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionsCollection = reader.Read(() => new DescribeLogDirsPartition(Version));
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Name.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(PartitionsCollection);
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				public String Name { get; set; }

				public DescribeLogDirsPartition[] PartitionsCollection { get; set; }

				public class DescribeLogDirsPartition : ISerialize
				{
					public DescribeLogDirsPartition(int version)
					{
						Version = version;
					}

					public int Version { get; }

					public void ReadFrom(IKafkaReader reader)
					{
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							PartitionIndex = new Int32(reader.ReadInt32());
						}
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							PartitionSize = new Int64(reader.ReadInt64());
						}
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							OffsetLag = new Int64(reader.ReadInt64());
						}
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							IsFutureKey = new Boolean(reader.ReadBoolean());
						}
					}

					public void WriteTo(IKafkaWriter writer)
					{
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							writer.WriteInt32(PartitionIndex.Value);
						}
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							writer.WriteInt64(PartitionSize.Value);
						}
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							writer.WriteInt64(OffsetLag.Value);
						}
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							writer.WriteBoolean(IsFutureKey.Value);
						}
					}

					/// <summary>
					/// The partition index.
					/// </summary>
					public Int32 PartitionIndex { get; set; }

					/// <summary>
					/// The size of the log segments in this partition in bytes.
					/// </summary>
					public Int64 PartitionSize { get; set; }

					/// <summary>
					/// The lag of the log's LEO w.r.t. partition's HW (if it is the current log for the partition) or current replica's LEO (if it is the future log for the partition)
					/// </summary>
					public Int64 OffsetLag { get; set; }

					/// <summary>
					/// True if this log is created by AlterReplicaLogDirsRequest and will replace the current log of the replica in the future.
					/// </summary>
					public Boolean IsFutureKey { get; set; }
				}
			}
		}
	}

	public class ElectPreferredLeadersRequest
	{
		public ElectPreferredLeadersRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 43;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicPartitionsCollection = reader.Read(() => new TopicPartitions(Version));
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TimeoutMs = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicPartitionsCollection);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(TimeoutMs.Value);
			}
		}

		/// <summary>
		/// The topic partitions to elect the preferred leader of.
		/// </summary>
		public TopicPartitions[] TopicPartitionsCollection { get; set; }

		public class TopicPartitions : ISerialize
		{
			public TopicPartitions(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Topic = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionIdCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Topic.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionIdCollection);
				}
			}

			/// <summary>
			/// The name of a topic.
			/// </summary>
			public String Topic { get; set; }

			/// <summary>
			/// The partitions of this topic whose preferred leader should be elected
			/// </summary>
			public Int32[] PartitionIdCollection { get; set; }
		}

		/// <summary>
		/// The time in ms to wait for the election to complete.
		/// </summary>
		public Int32 TimeoutMs { get; set; } = new Int32(60000);
	}

	public class ElectPreferredLeadersResponse
	{
		public ElectPreferredLeadersResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 43;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ReplicaElectionResultsCollection = reader.Read(() => new ReplicaElectionResult(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ReplicaElectionResultsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The election results, or an empty array if the requester did not have permission and the request asks for all partitions.
		/// </summary>
		public ReplicaElectionResult[] ReplicaElectionResultsCollection { get; set; }

		public class ReplicaElectionResult : ISerialize
		{
			public ReplicaElectionResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Topic = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionResultCollection = reader.Read(() => new PartitionResult(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Topic.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionResultCollection);
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			public String Topic { get; set; }

			/// <summary>
			/// The results for each partition
			/// </summary>
			public PartitionResult[] PartitionResultCollection { get; set; }

			public class PartitionResult : ISerialize
			{
				public PartitionResult(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionId = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorMessage = new String(reader.ReadString());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionId.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(ErrorMessage.Value);
					}
				}

				/// <summary>
				/// The partition id
				/// </summary>
				public Int32 PartitionId { get; set; }

				/// <summary>
				/// The result error, or zero if there was no error.
				/// </summary>
				public Int16 ErrorCode { get; set; }

				/// <summary>
				/// The result message, or null if there was no error.
				/// </summary>
				public String ErrorMessage { get; set; }
			}
		}
	}

	public class EndTxnRequest
	{
		public EndTxnRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 26;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TransactionalId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProducerId = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProducerEpoch = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Committed = new Boolean(reader.ReadBoolean());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(TransactionalId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(ProducerId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ProducerEpoch.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteBoolean(Committed.Value);
			}
		}

		/// <summary>
		/// The ID of the transaction to end.
		/// </summary>
		public String TransactionalId { get; set; }

		/// <summary>
		/// The producer ID.
		/// </summary>
		public Int64 ProducerId { get; set; }

		/// <summary>
		/// The current epoch associated with the producer.
		/// </summary>
		public Int16 ProducerEpoch { get; set; }

		/// <summary>
		/// True if the transaction was committed, false if it was aborted.
		/// </summary>
		public Boolean Committed { get; set; }
	}

	public class EndTxnResponse
	{
		public EndTxnResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 26;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }
	}

	public class ExpireDelegationTokenRequest
	{
		public ExpireDelegationTokenRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 40;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Hmac = new Bytes(reader.ReadBytes());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ExpiryTimePeriodMs = new Int64(reader.ReadInt64());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteBytes(Hmac.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(ExpiryTimePeriodMs.Value);
			}
		}

		/// <summary>
		/// The HMAC of the delegation token to be expired.
		/// </summary>
		public Bytes Hmac { get; set; }

		/// <summary>
		/// The expiry time period in milliseconds.
		/// </summary>
		public Int64 ExpiryTimePeriodMs { get; set; }
	}

	public class ExpireDelegationTokenResponse
	{
		public ExpireDelegationTokenResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 40;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ExpiryTimestampMs = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(ExpiryTimestampMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The timestamp in milliseconds at which this token expires.
		/// </summary>
		public Int64 ExpiryTimestampMs { get; set; }

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }
	}

	public class FetchRequest
	{
		public FetchRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 1;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ReplicaId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MaxWait = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MinBytes = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				MaxBytes = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(4, 2147483647))) 
			{
				IsolationLevel = new Int8(reader.ReadInt8());
			}
			if (Version.InRange(new VersionRange(7, 2147483647))) 
			{
				SessionId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(7, 2147483647))) 
			{
				Epoch = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new FetchableTopic(Version));
			}
			if (Version.InRange(new VersionRange(7, 2147483647))) 
			{
				ForgottenCollection = reader.Read(() => new ForgottenTopic(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ReplicaId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(MaxWait.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(MinBytes.Value);
			}
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				writer.WriteInt32(MaxBytes.Value);
			}
			if (Version.InRange(new VersionRange(4, 2147483647))) 
			{
				writer.WriteInt8(IsolationLevel.Value);
			}
			if (Version.InRange(new VersionRange(7, 2147483647))) 
			{
				writer.WriteInt32(SessionId.Value);
			}
			if (Version.InRange(new VersionRange(7, 2147483647))) 
			{
				writer.WriteInt32(Epoch.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
			if (Version.InRange(new VersionRange(7, 2147483647))) 
			{
				writer.Write(ForgottenCollection);
			}
		}

		/// <summary>
		/// The broker ID of the follower, of -1 if this request is from a consumer.
		/// </summary>
		public Int32 ReplicaId { get; set; }

		/// <summary>
		/// The maximum time in milliseconds to wait for the response.
		/// </summary>
		public Int32 MaxWait { get; set; }

		/// <summary>
		/// The minimum bytes to accumulate in the response.
		/// </summary>
		public Int32 MinBytes { get; set; }

		/// <summary>
		/// The maximum bytes to fetch.  See KIP-74 for cases where this limit may not be honored.
		/// </summary>
		public Int32 MaxBytes { get; set; } = new Int32(0x7fffffff);

		/// <summary>
		/// This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records
		/// </summary>
		public Int8 IsolationLevel { get; set; } = new Int8(0);

		/// <summary>
		/// The fetch session ID.
		/// </summary>
		public Int32 SessionId { get; set; } = new Int32(0);

		/// <summary>
		/// The fetch session ID.
		/// </summary>
		public Int32 Epoch { get; set; } = new Int32(-1);

		/// <summary>
		/// The topics to fetch.
		/// </summary>
		public FetchableTopic[] TopicsCollection { get; set; }

		public class FetchableTopic : ISerialize
		{
			public FetchableTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					FetchPartitionsCollection = reader.Read(() => new FetchPartition(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(FetchPartitionsCollection);
				}
			}

			/// <summary>
			/// The name of the topic to fetch.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The partitions to fetch.
			/// </summary>
			public FetchPartition[] FetchPartitionsCollection { get; set; }

			public class FetchPartition : ISerialize
			{
				public FetchPartition(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(9, 2147483647))) 
					{
						CurrentLeaderEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						FetchOffset = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						LogStartOffset = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						MaxBytes = new Int32(reader.ReadInt32());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(9, 2147483647))) 
					{
						writer.WriteInt32(CurrentLeaderEpoch.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt64(FetchOffset.Value);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.WriteInt64(LogStartOffset.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(MaxBytes.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The current leader epoch of the partition.
				/// </summary>
				public Int32 CurrentLeaderEpoch { get; set; } = new Int32(-1);

				/// <summary>
				/// The message offset.
				/// </summary>
				public Int64 FetchOffset { get; set; }

				/// <summary>
				/// The earliest available offset of the follower replica.  The field is only used when the request is sent by the follower.
				/// </summary>
				public Int64 LogStartOffset { get; set; } = new Int64(-1);

				/// <summary>
				/// The maximum bytes to fetch from this partition.  See KIP-74 for cases where this limit may not be honored.
				/// </summary>
				public Int32 MaxBytes { get; set; }
			}
		}

		/// <summary>
		/// In an incremental fetch request, the partitions to remove.
		/// </summary>
		public ForgottenTopic[] ForgottenCollection { get; set; }

		public class ForgottenTopic : ISerialize
		{
			public ForgottenTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(7, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(7, 2147483647))) 
				{
					ForgottenPartitionIndexesCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(7, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(7, 2147483647))) 
				{
					writer.Write(ForgottenPartitionIndexesCollection);
				}
			}

			/// <summary>
			/// The partition name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The partitions indexes to forget.
			/// </summary>
			public Int32[] ForgottenPartitionIndexesCollection { get; set; }
		}
	}

	public class FetchResponse
	{
		public FetchResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 1;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(7, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(7, 2147483647))) 
			{
				SessionId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new FetchableTopicResponse(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(7, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(7, 2147483647))) 
			{
				writer.WriteInt32(SessionId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The top level response error code.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The fetch session ID, or 0 if this is not part of a fetch session.
		/// </summary>
		public Int32 SessionId { get; set; } = new Int32(0);

		/// <summary>
		/// The response topics.
		/// </summary>
		public FetchableTopicResponse[] TopicsCollection { get; set; }

		public class FetchableTopicResponse : ISerialize
		{
			public FetchableTopicResponse(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new FetchablePartitionResponse(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The topic partitions.
			/// </summary>
			public FetchablePartitionResponse[] PartitionsCollection { get; set; }

			public class FetchablePartitionResponse : ISerialize
			{
				public FetchablePartitionResponse(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						HighWatermark = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(4, 2147483647))) 
					{
						LastStableOffset = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						LogStartOffset = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(4, 2147483647))) 
					{
						AbortedCollection = reader.Read(() => new AbortedTransaction(Version));
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Records = new Bytes(reader.ReadBytes());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt64(HighWatermark.Value);
					}
					if (Version.InRange(new VersionRange(4, 2147483647))) 
					{
						writer.WriteInt64(LastStableOffset.Value);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.WriteInt64(LogStartOffset.Value);
					}
					if (Version.InRange(new VersionRange(4, 2147483647))) 
					{
						writer.Write(AbortedCollection);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteBytes(Records.Value);
					}
				}

				/// <summary>
				/// The partiiton index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The error code, or 0 if there was no fetch error.
				/// </summary>
				public Int16 ErrorCode { get; set; }

				/// <summary>
				/// The current high water mark.
				/// </summary>
				public Int64 HighWatermark { get; set; }

				/// <summary>
				/// The last stable offset (or LSO) of the partition. This is the last offset such that the state of all transactional records prior to this offset have been decided (ABORTED or COMMITTED)
				/// </summary>
				public Int64 LastStableOffset { get; set; } = new Int64(-1);

				/// <summary>
				/// The current log start offset.
				/// </summary>
				public Int64 LogStartOffset { get; set; } = new Int64(-1);

				/// <summary>
				/// The aborted transactions.
				/// </summary>
				public AbortedTransaction[] AbortedCollection { get; set; }

				public class AbortedTransaction : ISerialize
				{
					public AbortedTransaction(int version)
					{
						Version = version;
					}

					public int Version { get; }

					public void ReadFrom(IKafkaReader reader)
					{
						if (Version.InRange(new VersionRange(4, 2147483647))) 
						{
							ProducerId = new Int64(reader.ReadInt64());
						}
						if (Version.InRange(new VersionRange(4, 2147483647))) 
						{
							FirstOffset = new Int64(reader.ReadInt64());
						}
					}

					public void WriteTo(IKafkaWriter writer)
					{
						if (Version.InRange(new VersionRange(4, 2147483647))) 
						{
							writer.WriteInt64(ProducerId.Value);
						}
						if (Version.InRange(new VersionRange(4, 2147483647))) 
						{
							writer.WriteInt64(FirstOffset.Value);
						}
					}

					/// <summary>
					/// The producer id associated with the aborted transaction.
					/// </summary>
					public Int64 ProducerId { get; set; }

					/// <summary>
					/// The first offset in the aborted transaction.
					/// </summary>
					public Int64 FirstOffset { get; set; }
				}

				/// <summary>
				/// The record data.
				/// </summary>
				public Bytes Records { get; set; }
			}
		}
	}

	public class FindCoordinatorRequest
	{
		public FindCoordinatorRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 10;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Key = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				KeyType = new Int8(reader.ReadInt8());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(Key.Value);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt8(KeyType.Value);
			}
		}

		/// <summary>
		/// The coordinator key.
		/// </summary>
		public String Key { get; set; }

		/// <summary>
		/// The coordinator key type.  (Group, transaction, etc.)
		/// </summary>
		public Int8 KeyType { get; set; } = new Int8(0);
	}

	public class FindCoordinatorResponse
	{
		public FindCoordinatorResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 10;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ErrorMessage = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				NodeId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Host = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Port = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteString(ErrorMessage.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(NodeId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(Host.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(Port.Value);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public String ErrorMessage { get; set; }

		/// <summary>
		/// The node id.
		/// </summary>
		public Int32 NodeId { get; set; }

		/// <summary>
		/// The host name.
		/// </summary>
		public String Host { get; set; }

		/// <summary>
		/// The port.
		/// </summary>
		public Int32 Port { get; set; }
	}

	public class HeartbeatRequest
	{
		public HeartbeatRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 12;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Generationid = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MemberId = new String(reader.ReadString());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(GroupId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(Generationid.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(MemberId.Value);
			}
		}

		/// <summary>
		/// The group id.
		/// </summary>
		public String GroupId { get; set; }

		/// <summary>
		/// The generation of the group.
		/// </summary>
		public Int32 Generationid { get; set; }

		/// <summary>
		/// The member ID.
		/// </summary>
		public String MemberId { get; set; }
	}

	public class HeartbeatResponse
	{
		public HeartbeatResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 12;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }
	}

	public class InitProducerIdRequest
	{
		public InitProducerIdRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 22;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TransactionalId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TransactionTimeoutMs = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(TransactionalId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(TransactionTimeoutMs.Value);
			}
		}

		/// <summary>
		/// The transactional id, or null if the producer is not transactional.
		/// </summary>
		public String TransactionalId { get; set; }

		/// <summary>
		/// The time in ms to wait for before aborting idle transactions sent by this producer.
		/// </summary>
		public Int32 TransactionTimeoutMs { get; set; }
	}

	public class InitProducerIdResponse
	{
		public InitProducerIdResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 22;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProducerId = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProducerEpoch = new Int16(reader.ReadInt16());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(ProducerId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ProducerEpoch.Value);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The current producer id.
		/// </summary>
		public Int64 ProducerId { get; set; }

		/// <summary>
		/// The current epoch associated with the producer id.
		/// </summary>
		public Int16 ProducerEpoch { get; set; }
	}

	public class JoinGroupRequest
	{
		public JoinGroupRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 11;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				SessionTimeoutMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				RebalanceTimeoutMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MemberId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProtocolType = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProtocolsCollection = reader.Read(() => new JoinGroupRequestProtocol(Version)).ToDictionary(field => field.Name);
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(GroupId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(SessionTimeoutMs.Value);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(RebalanceTimeoutMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(MemberId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(ProtocolType.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ProtocolsCollection.Values.ToArray());
			}
		}

		/// <summary>
		/// The group identifier.
		/// </summary>
		public String GroupId { get; set; }

		/// <summary>
		/// The coordinator considers the consumer dead if it receives no heartbeat after this timeout in milliseconds.
		/// </summary>
		public Int32 SessionTimeoutMs { get; set; }

		/// <summary>
		/// The maximum time in milliseconds that the coordinator will wait for each member to rejoin when rebalancing the group.
		/// </summary>
		public Int32 RebalanceTimeoutMs { get; set; } = new Int32(-1);

		/// <summary>
		/// The member id assigned by the group coordinator.
		/// </summary>
		public String MemberId { get; set; }

		/// <summary>
		/// The unique name the for class of protocols implemented by the group we want to join.
		/// </summary>
		public String ProtocolType { get; set; }

		/// <summary>
		/// The list of protocols that the member supports.
		/// </summary>
		public Dictionary<String, JoinGroupRequestProtocol> ProtocolsCollection { get; set; }

		public class JoinGroupRequestProtocol : ISerialize
		{
			public JoinGroupRequestProtocol(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Metadata = new Bytes(reader.ReadBytes());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteBytes(Metadata.Value);
				}
			}

			/// <summary>
			/// The protocol name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The protocol metadata.
			/// </summary>
			public Bytes Metadata { get; set; }
		}
	}

	public class JoinGroupResponse
	{
		public JoinGroupResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 11;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GenerationId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProtocolName = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Leader = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MemberId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MembersCollection = reader.Read(() => new JoinGroupResponseMember(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(GenerationId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(ProtocolName.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(Leader.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(MemberId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(MembersCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The generation ID of the group.
		/// </summary>
		public Int32 GenerationId { get; set; } = new Int32(-1);

		/// <summary>
		/// The group protocol selected by the coordinator.
		/// </summary>
		public String ProtocolName { get; set; }

		/// <summary>
		/// The leader of the group.
		/// </summary>
		public String Leader { get; set; }

		/// <summary>
		/// The member ID assigned by the group coordinator.
		/// </summary>
		public String MemberId { get; set; }

		public JoinGroupResponseMember[] MembersCollection { get; set; }

		public class JoinGroupResponseMember : ISerialize
		{
			public JoinGroupResponseMember(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					MemberId = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Metadata = new Bytes(reader.ReadBytes());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(MemberId.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteBytes(Metadata.Value);
				}
			}

			/// <summary>
			/// The group member ID.
			/// </summary>
			public String MemberId { get; set; }

			/// <summary>
			/// The group member metadata.
			/// </summary>
			public Bytes Metadata { get; set; }
		}
	}

	public class LeaderAndIsrRequest
	{
		public LeaderAndIsrRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 4;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ControllerId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ControllerEpoch = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				BrokerEpoch = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				TopicStatesCollection = reader.Read(() => new LeaderAndIsrRequestTopicState(Version));
			}
			if (Version.InRange(new VersionRange(0, 1))) 
			{
				PartitionStatesV0Collection = reader.Read(() => new LeaderAndIsrRequestPartitionStateV0(Version));
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				LiveLeadersCollection = reader.Read(() => new LeaderAndIsrLiveLeader(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ControllerId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ControllerEpoch.Value);
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				writer.WriteInt64(BrokerEpoch.Value);
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				writer.Write(TopicStatesCollection);
			}
			if (Version.InRange(new VersionRange(0, 1))) 
			{
				writer.Write(PartitionStatesV0Collection);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(LiveLeadersCollection);
			}
		}

		/// <summary>
		/// The current controller ID.
		/// </summary>
		public Int32 ControllerId { get; set; }

		/// <summary>
		/// The current controller epoch.
		/// </summary>
		public Int32 ControllerEpoch { get; set; }

		/// <summary>
		/// The current broker epoch.
		/// </summary>
		public Int64 BrokerEpoch { get; set; } = new Int64(-1);

		/// <summary>
		/// Each topic.
		/// </summary>
		public LeaderAndIsrRequestTopicState[] TopicStatesCollection { get; set; }

		public class LeaderAndIsrRequestTopicState : ISerialize
		{
			public LeaderAndIsrRequestTopicState(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(2, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionStatesCollection = reader.Read(() => new LeaderAndIsrRequestPartitionState(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(2, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionStatesCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The state of each partition
			/// </summary>
			public LeaderAndIsrRequestPartitionState[] PartitionStatesCollection { get; set; }

			public class LeaderAndIsrRequestPartitionState : ISerialize
			{
				public LeaderAndIsrRequestPartitionState(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ControllerEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						LeaderKey = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						LeaderEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						IsrReplicasCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ZkVersion = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ReplicasCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						IsNew = new Boolean(reader.ReadBoolean());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(ControllerEpoch.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(LeaderKey.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(LeaderEpoch.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(IsrReplicasCollection);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(ZkVersion.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(ReplicasCollection);
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.WriteBoolean(IsNew.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The controller epoch.
				/// </summary>
				public Int32 ControllerEpoch { get; set; }

				/// <summary>
				/// The broker ID of the leader.
				/// </summary>
				public Int32 LeaderKey { get; set; }

				/// <summary>
				/// The leader epoch.
				/// </summary>
				public Int32 LeaderEpoch { get; set; }

				/// <summary>
				/// The in-sync replica IDs.
				/// </summary>
				public Int32[] IsrReplicasCollection { get; set; }

				/// <summary>
				/// The ZooKeeper version.
				/// </summary>
				public Int32 ZkVersion { get; set; }

				/// <summary>
				/// The replica IDs.
				/// </summary>
				public Int32[] ReplicasCollection { get; set; }

				/// <summary>
				/// Whether the replica should have existed on the broker or not.
				/// </summary>
				public Boolean IsNew { get; set; } = new Boolean(false);
			}
		}

		/// <summary>
		/// The state of each partition
		/// </summary>
		public LeaderAndIsrRequestPartitionStateV0[] PartitionStatesV0Collection { get; set; }

		public class LeaderAndIsrRequestPartitionStateV0 : ISerialize
		{
			public LeaderAndIsrRequestPartitionStateV0(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					TopicName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					PartitionIndex = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					ControllerEpoch = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					LeaderKey = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					LeaderEpoch = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					IsrReplicasCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					ZkVersion = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					ReplicasCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					IsNew = new Boolean(reader.ReadBoolean());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					writer.WriteString(TopicName.Value);
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					writer.WriteInt32(PartitionIndex.Value);
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					writer.WriteInt32(ControllerEpoch.Value);
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					writer.WriteInt32(LeaderKey.Value);
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					writer.WriteInt32(LeaderEpoch.Value);
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					writer.Write(IsrReplicasCollection);
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					writer.WriteInt32(ZkVersion.Value);
				}
				if (Version.InRange(new VersionRange(0, 1))) 
				{
					writer.Write(ReplicasCollection);
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					writer.WriteBoolean(IsNew.Value);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String TopicName { get; set; }

			/// <summary>
			/// The partition index.
			/// </summary>
			public Int32 PartitionIndex { get; set; }

			/// <summary>
			/// The controller epoch.
			/// </summary>
			public Int32 ControllerEpoch { get; set; }

			/// <summary>
			/// The broker ID of the leader.
			/// </summary>
			public Int32 LeaderKey { get; set; }

			/// <summary>
			/// The leader epoch.
			/// </summary>
			public Int32 LeaderEpoch { get; set; }

			/// <summary>
			/// The in-sync replica IDs.
			/// </summary>
			public Int32[] IsrReplicasCollection { get; set; }

			/// <summary>
			/// The ZooKeeper version.
			/// </summary>
			public Int32 ZkVersion { get; set; }

			/// <summary>
			/// The replica IDs.
			/// </summary>
			public Int32[] ReplicasCollection { get; set; }

			/// <summary>
			/// Whether the replica should have existed on the broker or not.
			/// </summary>
			public Boolean IsNew { get; set; } = new Boolean(false);
		}

		/// <summary>
		/// The current live leaders.
		/// </summary>
		public LeaderAndIsrLiveLeader[] LiveLeadersCollection { get; set; }

		public class LeaderAndIsrLiveLeader : ISerialize
		{
			public LeaderAndIsrLiveLeader(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					BrokerId = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					HostName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Port = new Int32(reader.ReadInt32());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(BrokerId.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(HostName.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(Port.Value);
				}
			}

			/// <summary>
			/// The leader's broker ID.
			/// </summary>
			public Int32 BrokerId { get; set; }

			/// <summary>
			/// The leader's hostname.
			/// </summary>
			public String HostName { get; set; }

			/// <summary>
			/// The leader's port.
			/// </summary>
			public Int32 Port { get; set; }
		}
	}

	public class LeaderAndIsrResponse
	{
		public LeaderAndIsrResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 4;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				PartitionsCollection = reader.Read(() => new LeaderAndIsrResponsePartition(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(PartitionsCollection);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// Each partition.
		/// </summary>
		public LeaderAndIsrResponsePartition[] PartitionsCollection { get; set; }

		public class LeaderAndIsrResponsePartition : ISerialize
		{
			public LeaderAndIsrResponsePartition(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TopicName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionIndex = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(TopicName.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(PartitionIndex.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String TopicName { get; set; }

			/// <summary>
			/// The partition index.
			/// </summary>
			public Int32 PartitionIndex { get; set; }

			/// <summary>
			/// The partition error code, or 0 if there was no error.
			/// </summary>
			public Int16 ErrorCode { get; set; }
		}
	}

	public class LeaveGroupRequest
	{
		public LeaveGroupRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 13;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MemberId = new String(reader.ReadString());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(GroupId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(MemberId.Value);
			}
		}

		/// <summary>
		/// The ID of the group to leave.
		/// </summary>
		public String GroupId { get; set; }

		/// <summary>
		/// The member ID to remove from the group.
		/// </summary>
		public String MemberId { get; set; }
	}

	public class LeaveGroupResponse
	{
		public LeaveGroupResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 13;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }
	}

	public class ListGroupsRequest
	{
		public ListGroupsRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 16;

		public void ReadFrom(IKafkaReader reader)
		{

		}

		public void WriteTo(IKafkaWriter writer)
		{

		}


	}

	public class ListGroupsResponse
	{
		public ListGroupsResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 16;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupsCollection = reader.Read(() => new ListedGroup(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(GroupsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// Each group in the response.
		/// </summary>
		public ListedGroup[] GroupsCollection { get; set; }

		public class ListedGroup : ISerialize
		{
			public ListedGroup(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					GroupId = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ProtocolType = new String(reader.ReadString());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(GroupId.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(ProtocolType.Value);
				}
			}

			/// <summary>
			/// The group ID.
			/// </summary>
			public String GroupId { get; set; }

			/// <summary>
			/// The group protocol type.
			/// </summary>
			public String ProtocolType { get; set; }
		}
	}

	public class ListOffsetRequest
	{
		public ListOffsetRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 2;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ReplicaId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				IsolationLevel = new Int8(reader.ReadInt8());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new ListOffsetTopic(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ReplicaId.Value);
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				writer.WriteInt8(IsolationLevel.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The broker ID of the requestor, or -1 if this request is being made by a normal consumer.
		/// </summary>
		public Int32 ReplicaId { get; set; }

		/// <summary>
		/// This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records
		/// </summary>
		public Int8 IsolationLevel { get; set; }

		/// <summary>
		/// Each topic in the request.
		/// </summary>
		public ListOffsetTopic[] TopicsCollection { get; set; }

		public class ListOffsetTopic : ISerialize
		{
			public ListOffsetTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new ListOffsetPartition(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// Each partition in the request.
			/// </summary>
			public ListOffsetPartition[] PartitionsCollection { get; set; }

			public class ListOffsetPartition : ISerialize
			{
				public ListOffsetPartition(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(4, 2147483647))) 
					{
						CurrentLeaderEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Timestamp = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						MaxNumOffsets = new Int32(reader.ReadInt32());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(4, 2147483647))) 
					{
						writer.WriteInt32(CurrentLeaderEpoch.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt64(Timestamp.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(MaxNumOffsets.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The current leader epoch.
				/// </summary>
				public Int32 CurrentLeaderEpoch { get; set; }

				/// <summary>
				/// The current timestamp.
				/// </summary>
				public Int64 Timestamp { get; set; }

				/// <summary>
				/// The maximum number of offsets to report.
				/// </summary>
				public Int32 MaxNumOffsets { get; set; }
			}
		}
	}

	public class ListOffsetResponse
	{
		public ListOffsetResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 2;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new ListOffsetTopicResponse(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// Each topic in the response.
		/// </summary>
		public ListOffsetTopicResponse[] TopicsCollection { get; set; }

		public class ListOffsetTopicResponse : ISerialize
		{
			public ListOffsetTopicResponse(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new ListOffsetPartitionResponse(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// Each partition in the response.
			/// </summary>
			public ListOffsetPartitionResponse[] PartitionsCollection { get; set; }

			public class ListOffsetPartitionResponse : ISerialize
			{
				public ListOffsetPartitionResponse(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						OldStyleOffsetsCollection = reader.Read(() => new Int64(reader.ReadInt64()));
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						Timestamp = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						Offset = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(4, 2147483647))) 
					{
						LeaderEpoch = new Int32(reader.ReadInt32());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(OldStyleOffsetsCollection);
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.WriteInt64(Timestamp.Value);
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.WriteInt64(Offset.Value);
					}
					if (Version.InRange(new VersionRange(4, 2147483647))) 
					{
						writer.WriteInt32(LeaderEpoch.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The partition error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode { get; set; }

				/// <summary>
				/// The result offsets.
				/// </summary>
				public Int64[] OldStyleOffsetsCollection { get; set; }

				/// <summary>
				/// The timestamp associated with the returned offset.
				/// </summary>
				public Int64 Timestamp { get; set; } = new Int64(-1);

				/// <summary>
				/// The returned offset.
				/// </summary>
				public Int64 Offset { get; set; } = new Int64(-1);

				public Int32 LeaderEpoch { get; set; }
			}
		}
	}

	public class MetadataRequest
	{
		public MetadataRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 3;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new MetadataRequestTopic(Version));
			}
			if (Version.InRange(new VersionRange(4, 2147483647))) 
			{
				AllowAutoTopicCreation = new Boolean(reader.ReadBoolean());
			}
			if (Version.InRange(new VersionRange(8, 2147483647))) 
			{
				IncludeClusterAuthorizedOperations = new Boolean(reader.ReadBoolean());
			}
			if (Version.InRange(new VersionRange(8, 2147483647))) 
			{
				IncludeTopicAuthorizedOperations = new Boolean(reader.ReadBoolean());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
			if (Version.InRange(new VersionRange(4, 2147483647))) 
			{
				writer.WriteBoolean(AllowAutoTopicCreation.Value);
			}
			if (Version.InRange(new VersionRange(8, 2147483647))) 
			{
				writer.WriteBoolean(IncludeClusterAuthorizedOperations.Value);
			}
			if (Version.InRange(new VersionRange(8, 2147483647))) 
			{
				writer.WriteBoolean(IncludeTopicAuthorizedOperations.Value);
			}
		}

		/// <summary>
		/// The topics to fetch metadata for.
		/// </summary>
		public MetadataRequestTopic[] TopicsCollection { get; set; }

		public class MetadataRequestTopic : ISerialize
		{
			public MetadataRequestTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }
		}

		/// <summary>
		/// If this is true, the broker may auto-create topics that we requested which do not already exist, if it is configured to do so.
		/// </summary>
		public Boolean AllowAutoTopicCreation { get; set; } = new Boolean(true);

		/// <summary>
		/// Whether to include cluster authorized operations.
		/// </summary>
		public Boolean IncludeClusterAuthorizedOperations { get; set; }

		/// <summary>
		/// Whether to include topic authorized operations.
		/// </summary>
		public Boolean IncludeTopicAuthorizedOperations { get; set; }
	}

	public class MetadataResponse
	{
		public MetadataResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 3;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				BrokersCollection = reader.Read(() => new MetadataResponseBroker(Version)).ToDictionary(field => field.NodeId);
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				ClusterId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ControllerId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new MetadataResponseTopic(Version)).ToDictionary(field => field.Name);
			}
			if (Version.InRange(new VersionRange(8, 2147483647))) 
			{
				ClusterAuthorizedOperations = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(BrokersCollection.Values.ToArray());
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				writer.WriteString(ClusterId.Value);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ControllerId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection.Values.ToArray());
			}
			if (Version.InRange(new VersionRange(8, 2147483647))) 
			{
				writer.WriteInt32(ClusterAuthorizedOperations.Value);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// Each broker in the response.
		/// </summary>
		public Dictionary<Int32, MetadataResponseBroker> BrokersCollection { get; set; }

		public class MetadataResponseBroker : ISerialize
		{
			public MetadataResponseBroker(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					NodeId = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Host = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Port = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					Rack = new String(reader.ReadString());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(NodeId.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Host.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(Port.Value);
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					writer.WriteString(Rack.Value);
				}
			}

			/// <summary>
			/// The broker ID.
			/// </summary>
			public Int32 NodeId { get; set; }

			/// <summary>
			/// The broker hostname.
			/// </summary>
			public String Host { get; set; }

			/// <summary>
			/// The broker port.
			/// </summary>
			public Int32 Port { get; set; }

			/// <summary>
			/// The rack of the broker, or null if it has not been assigned to a rack.
			/// </summary>
			public String Rack { get; set; } = new String(null);
		}

		/// <summary>
		/// The cluster ID that responding broker belongs to.
		/// </summary>
		public String ClusterId { get; set; } = new String(null);

		/// <summary>
		/// The ID of the controller broker.
		/// </summary>
		public Int32 ControllerId { get; set; } = new Int32(-1);

		/// <summary>
		/// Each topic in the response.
		/// </summary>
		public Dictionary<String, MetadataResponseTopic> TopicsCollection { get; set; }

		public class MetadataResponseTopic : ISerialize
		{
			public MetadataResponseTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					IsInternal = new Boolean(reader.ReadBoolean());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new MetadataResponsePartition(Version));
				}
				if (Version.InRange(new VersionRange(8, 2147483647))) 
				{
					TopicAuthorizedOperations = new Int32(reader.ReadInt32());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					writer.WriteBoolean(IsInternal.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
				if (Version.InRange(new VersionRange(8, 2147483647))) 
				{
					writer.WriteInt32(TopicAuthorizedOperations.Value);
				}
			}

			/// <summary>
			/// The topic error, or 0 if there was no error.
			/// </summary>
			public Int16 ErrorCode { get; set; }

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// True if the topic is internal.
			/// </summary>
			public Boolean IsInternal { get; set; } = new Boolean(false);

			/// <summary>
			/// Each partition in the topic.
			/// </summary>
			public MetadataResponsePartition[] PartitionsCollection { get; set; }

			public class MetadataResponsePartition : ISerialize
			{
				public MetadataResponsePartition(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						LeaderId = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(7, 2147483647))) 
					{
						LeaderEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ReplicaNodesCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						IsrNodesCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						OfflineReplicasCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(LeaderId.Value);
					}
					if (Version.InRange(new VersionRange(7, 2147483647))) 
					{
						writer.WriteInt32(LeaderEpoch.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(ReplicaNodesCollection);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(IsrNodesCollection);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.Write(OfflineReplicasCollection);
					}
				}

				/// <summary>
				/// The partition error, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode { get; set; }

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The ID of the leader broker.
				/// </summary>
				public Int32 LeaderId { get; set; }

				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				public Int32 LeaderEpoch { get; set; } = new Int32(-1);

				/// <summary>
				/// The set of all nodes that host this partition.
				/// </summary>
				public Int32[] ReplicaNodesCollection { get; set; }

				/// <summary>
				/// The set of nodes that are in sync with the leader for this partition.
				/// </summary>
				public Int32[] IsrNodesCollection { get; set; }

				/// <summary>
				/// The set of offline replicas of this partition.
				/// </summary>
				public Int32[] OfflineReplicasCollection { get; set; }
			}

			/// <summary>
			/// 32-bit bitfield to represent authorized operations for this topic.
			/// </summary>
			public Int32 TopicAuthorizedOperations { get; set; }
		}

		/// <summary>
		/// 32-bit bitfield to represent authorized operations for this cluster.
		/// </summary>
		public Int32 ClusterAuthorizedOperations { get; set; }
	}

	public class OffsetCommitRequest
	{
		public OffsetCommitRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 8;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				GenerationId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				MemberId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(2, 4))) 
			{
				RetentionTimeMs = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new OffsetCommitRequestTopic(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(GroupId.Value);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(GenerationId.Value);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteString(MemberId.Value);
			}
			if (Version.InRange(new VersionRange(2, 4))) 
			{
				writer.WriteInt64(RetentionTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public String GroupId { get; set; }

		/// <summary>
		/// The generation of the group.
		/// </summary>
		public Int32 GenerationId { get; set; } = new Int32(-1);

		/// <summary>
		/// The member ID assigned by the group coordinator.
		/// </summary>
		public String MemberId { get; set; }

		/// <summary>
		/// The time period in ms to retain the offset.
		/// </summary>
		public Int64 RetentionTimeMs { get; set; } = new Int64(-1);

		/// <summary>
		/// The topics to commit offsets for.
		/// </summary>
		public OffsetCommitRequestTopic[] TopicsCollection { get; set; }

		public class OffsetCommitRequestTopic : ISerialize
		{
			public OffsetCommitRequestTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new OffsetCommitRequestPartition(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// Each partition to commit offsets for.
			/// </summary>
			public OffsetCommitRequestPartition[] PartitionsCollection { get; set; }

			public class OffsetCommitRequestPartition : ISerialize
			{
				public OffsetCommitRequestPartition(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						CommittedOffset = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(6, 2147483647))) 
					{
						CommittedLeaderEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						CommitTimestamp = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						CommittedMetadata = new String(reader.ReadString());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt64(CommittedOffset.Value);
					}
					if (Version.InRange(new VersionRange(6, 2147483647))) 
					{
						writer.WriteInt32(CommittedLeaderEpoch.Value);
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.WriteInt64(CommitTimestamp.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(CommittedMetadata.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The message offset to be committed.
				/// </summary>
				public Int64 CommittedOffset { get; set; }

				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				public Int32 CommittedLeaderEpoch { get; set; } = new Int32(-1);

				/// <summary>
				/// The timestamp of the commit.
				/// </summary>
				public Int64 CommitTimestamp { get; set; } = new Int64(-1);

				/// <summary>
				/// Any associated metadata the client wants to keep.
				/// </summary>
				public String CommittedMetadata { get; set; }
			}
		}
	}

	public class OffsetCommitResponse
	{
		public OffsetCommitResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 8;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new OffsetCommitResponseTopic(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The responses for each topic.
		/// </summary>
		public OffsetCommitResponseTopic[] TopicsCollection { get; set; }

		public class OffsetCommitResponseTopic : ISerialize
		{
			public OffsetCommitResponseTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new OffsetCommitResponsePartition(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The responses for each partition in the topic.
			/// </summary>
			public OffsetCommitResponsePartition[] PartitionsCollection { get; set; }

			public class OffsetCommitResponsePartition : ISerialize
			{
				public OffsetCommitResponsePartition(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode { get; set; }
			}
		}
	}

	public class OffsetFetchRequest
	{
		public OffsetFetchRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 9;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new OffsetFetchRequestTopic(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(GroupId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The group to fetch offsets for.
		/// </summary>
		public String GroupId { get; set; }

		/// <summary>
		/// Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.
		/// </summary>
		public OffsetFetchRequestTopic[] TopicsCollection { get; set; }

		public class OffsetFetchRequestTopic : ISerialize
		{
			public OffsetFetchRequestTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionIndexesCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionIndexesCollection);
				}
			}

			public String Name { get; set; }

			/// <summary>
			/// The partition indexes we would like to fetch offsets for.
			/// </summary>
			public Int32[] PartitionIndexesCollection { get; set; }
		}
	}

	public class OffsetFetchResponse
	{
		public OffsetFetchResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 9;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new OffsetFetchResponseTopic(Version));
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The responses per topic.
		/// </summary>
		public OffsetFetchResponseTopic[] TopicsCollection { get; set; }

		public class OffsetFetchResponseTopic : ISerialize
		{
			public OffsetFetchResponseTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new OffsetFetchResponsePartition(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The responses per partition
			/// </summary>
			public OffsetFetchResponsePartition[] PartitionsCollection { get; set; }

			public class OffsetFetchResponsePartition : ISerialize
			{
				public OffsetFetchResponsePartition(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						CommittedOffset = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						CommittedLeaderEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Metadata = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt64(CommittedOffset.Value);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.WriteInt32(CommittedLeaderEpoch.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Metadata.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The committed message offset.
				/// </summary>
				public Int64 CommittedOffset { get; set; }

				/// <summary>
				/// The leader epoch.
				/// </summary>
				public Int32 CommittedLeaderEpoch { get; set; }

				/// <summary>
				/// The partition metadata.
				/// </summary>
				public String Metadata { get; set; }

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode { get; set; }
			}
		}

		/// <summary>
		/// The top-level error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; } = new Int16(0);
	}

	public class OffsetForLeaderEpochRequest
	{
		public OffsetForLeaderEpochRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 23;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new OffsetForLeaderTopic(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// Each topic to get offsets for.
		/// </summary>
		public OffsetForLeaderTopic[] TopicsCollection { get; set; }

		public class OffsetForLeaderTopic : ISerialize
		{
			public OffsetForLeaderTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new OffsetForLeaderPartition(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// Each partition to get offsets for.
			/// </summary>
			public OffsetForLeaderPartition[] PartitionsCollection { get; set; }

			public class OffsetForLeaderPartition : ISerialize
			{
				public OffsetForLeaderPartition(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(2, 2147483647))) 
					{
						CurrentLeaderEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						LeaderEpoch = new Int32(reader.ReadInt32());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(2, 2147483647))) 
					{
						writer.WriteInt32(CurrentLeaderEpoch.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(LeaderEpoch.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// An epoch used to fence consumers/replicas with old metadata.  If the epoch provided by the client is larger than the current epoch known to the broker, then the UNKNOWN_LEADER_EPOCH error code will be returned. If the provided epoch is smaller, then the FENCED_LEADER_EPOCH error code will be returned.
				/// </summary>
				public Int32 CurrentLeaderEpoch { get; set; } = new Int32(-1);

				/// <summary>
				/// The epoch to look up an offset for.
				/// </summary>
				public Int32 LeaderEpoch { get; set; }
			}
		}
	}

	public class OffsetForLeaderEpochResponse
	{
		public OffsetForLeaderEpochResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 23;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new OffsetForLeaderTopicResult(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(2, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// Each topic we fetched offsets for.
		/// </summary>
		public OffsetForLeaderTopicResult[] TopicsCollection { get; set; }

		public class OffsetForLeaderTopicResult : ISerialize
		{
			public OffsetForLeaderTopicResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new OffsetForLeaderPartitionResult(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// Each partition in the topic we fetched offsets for.
			/// </summary>
			public OffsetForLeaderPartitionResult[] PartitionsCollection { get; set; }

			public class OffsetForLeaderPartitionResult : ISerialize
			{
				public OffsetForLeaderPartitionResult(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						LeaderEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						EndOffset = new Int64(reader.ReadInt64());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.WriteInt32(LeaderEpoch.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt64(EndOffset.Value);
					}
				}

				/// <summary>
				/// The error code 0, or if there was no error.
				/// </summary>
				public Int16 ErrorCode { get; set; }

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The leader epoch of the partition.
				/// </summary>
				public Int32 LeaderEpoch { get; set; } = new Int32(-1);

				/// <summary>
				/// The end offset of the epoch.
				/// </summary>
				public Int64 EndOffset { get; set; }
			}
		}
	}

	public class ProduceRequest
	{
		public ProduceRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 0;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				TransactionalId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Acks = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TimeoutMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new TopicProduceData(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(3, 2147483647))) 
			{
				writer.WriteString(TransactionalId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(Acks.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(TimeoutMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The transactional ID, or null if the producer is not transactional.
		/// </summary>
		public String TransactionalId { get; set; }

		/// <summary>
		/// The number of acknowledgments the producer requires the leader to have received before considering a request complete. Allowed values: 0 for no acknowledgments, 1 for only the leader and -1 for the full ISR.
		/// </summary>
		public Int16 Acks { get; set; }

		/// <summary>
		/// The timeout to await a response in miliseconds.
		/// </summary>
		public Int32 TimeoutMs { get; set; }

		/// <summary>
		/// Each topic to produce to.
		/// </summary>
		public TopicProduceData[] TopicsCollection { get; set; }

		public class TopicProduceData : ISerialize
		{
			public TopicProduceData(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new PartitionProduceData(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// Each partition to produce to.
			/// </summary>
			public PartitionProduceData[] PartitionsCollection { get; set; }

			public class PartitionProduceData : ISerialize
			{
				public PartitionProduceData(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Records = new Bytes(reader.ReadBytes());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteBytes(Records.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The record data to be produced.
				/// </summary>
				public Bytes Records { get; set; }
			}
		}
	}

	public class ProduceResponse
	{
		public ProduceResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 0;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ResponsesCollection = reader.Read(() => new TopicProduceResponse(Version));
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(ResponsesCollection);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
		}

		/// <summary>
		/// Each produce response
		/// </summary>
		public TopicProduceResponse[] ResponsesCollection { get; set; }

		public class TopicProduceResponse : ISerialize
		{
			public TopicProduceResponse(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new PartitionProduceResponse(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// Each partition that we produced to within the topic.
			/// </summary>
			public PartitionProduceResponse[] PartitionsCollection { get; set; }

			public class PartitionProduceResponse : ISerialize
			{
				public PartitionProduceResponse(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						BaseOffset = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(2, 2147483647))) 
					{
						LogAppendTimeMs = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						LogStartOffset = new Int64(reader.ReadInt64());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt64(BaseOffset.Value);
					}
					if (Version.InRange(new VersionRange(2, 2147483647))) 
					{
						writer.WriteInt64(LogAppendTimeMs.Value);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.WriteInt64(LogStartOffset.Value);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode { get; set; }

				/// <summary>
				/// The base offset.
				/// </summary>
				public Int64 BaseOffset { get; set; }

				/// <summary>
				/// The timestamp returned by broker after appending the messages. If CreateTime is used for the topic, the timestamp will be -1.  If LogAppendTime is used for the topic, the timestamp will be the broker local time when the messages are appended.
				/// </summary>
				public Int64 LogAppendTimeMs { get; set; } = new Int64(-1);

				/// <summary>
				/// The log start offset.
				/// </summary>
				public Int64 LogStartOffset { get; set; } = new Int64(-1);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }
	}

	public class RenewDelegationTokenRequest
	{
		public RenewDelegationTokenRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 39;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Hmac = new Bytes(reader.ReadBytes());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				RenewPeriodMs = new Int64(reader.ReadInt64());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteBytes(Hmac.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(RenewPeriodMs.Value);
			}
		}

		/// <summary>
		/// The HMAC of the delegation token to be renewed.
		/// </summary>
		public Bytes Hmac { get; set; }

		/// <summary>
		/// The renewal time period in milliseconds.
		/// </summary>
		public Int64 RenewPeriodMs { get; set; }
	}

	public class RenewDelegationTokenResponse
	{
		public RenewDelegationTokenResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 39;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ExpiryTimestampMs = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(ExpiryTimestampMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The timestamp in milliseconds at which this token expires.
		/// </summary>
		public Int64 ExpiryTimestampMs { get; set; }

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }
	}

	public class RequestHeader
	{
		public RequestHeader(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 0;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				RequestApiKey = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				RequestApiVersion = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				CorrelationId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ClientId = new String(reader.ReadString());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(RequestApiKey.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(RequestApiVersion.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(CorrelationId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(ClientId.Value);
			}
		}

		/// <summary>
		/// The API key of this request.
		/// </summary>
		public Int16 RequestApiKey { get; set; }

		/// <summary>
		/// The API version of this request.
		/// </summary>
		public Int16 RequestApiVersion { get; set; }

		/// <summary>
		/// The correlation ID of this request.
		/// </summary>
		public Int32 CorrelationId { get; set; }

		/// <summary>
		/// The client ID string.
		/// </summary>
		public String ClientId { get; set; }
	}

	public class ResponseHeader
	{
		public ResponseHeader(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 0;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				CorrelationId = new Int32(reader.ReadInt32());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(CorrelationId.Value);
			}
		}

		/// <summary>
		/// The correlation ID of this response.
		/// </summary>
		public Int32 CorrelationId { get; set; }
	}

	public class SaslAuthenticateRequest
	{
		public SaslAuthenticateRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 36;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				AuthBytes = new Bytes(reader.ReadBytes());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteBytes(AuthBytes.Value);
			}
		}

		/// <summary>
		/// The SASL authentication bytes from the client, as defined by the SASL mechanism.
		/// </summary>
		public Bytes AuthBytes { get; set; }
	}

	public class SaslAuthenticateResponse
	{
		public SaslAuthenticateResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 36;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorMessage = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				AuthBytes = new Bytes(reader.ReadBytes());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				SessionLifetimeMs = new Int64(reader.ReadInt64());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(ErrorMessage.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteBytes(AuthBytes.Value);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt64(SessionLifetimeMs.Value);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public String ErrorMessage { get; set; }

		/// <summary>
		/// The SASL authentication bytes from the server, as defined by the SASL mechanism.
		/// </summary>
		public Bytes AuthBytes { get; set; }

		/// <summary>
		/// The SASL authentication bytes from the server, as defined by the SASL mechanism.
		/// </summary>
		public Int64 SessionLifetimeMs { get; set; } = new Int64(0);
	}

	public class SaslHandshakeRequest
	{
		public SaslHandshakeRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 17;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Mechanism = new String(reader.ReadString());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(Mechanism.Value);
			}
		}

		/// <summary>
		/// The SASL mechanism chosen by the client.
		/// </summary>
		public String Mechanism { get; set; }
	}

	public class SaslHandshakeResponse
	{
		public SaslHandshakeResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 17;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MechanismsCollection = reader.Read(() => new String(reader.ReadString()));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(MechanismsCollection);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The mechanisms enabled in the server.
		/// </summary>
		public String[] MechanismsCollection { get; set; }
	}

	public class StopReplicaRequest
	{
		public StopReplicaRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 5;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ControllerId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ControllerEpoch = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				BrokerEpoch = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				DeletePartitions = new Boolean(reader.ReadBoolean());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				PartitionsV0Collection = reader.Read(() => new StopReplicaRequestPartitionV0(Version));
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new StopReplicaRequestTopic(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ControllerId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ControllerEpoch.Value);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt64(BrokerEpoch.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteBoolean(DeletePartitions.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(PartitionsV0Collection);
			}
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The controller id.
		/// </summary>
		public Int32 ControllerId { get; set; }

		/// <summary>
		/// The controller epoch.
		/// </summary>
		public Int32 ControllerEpoch { get; set; }

		/// <summary>
		/// The broker epoch.
		/// </summary>
		public Int64 BrokerEpoch { get; set; } = new Int64(-1);

		/// <summary>
		/// Whether these partitions should be deleted.
		/// </summary>
		public Boolean DeletePartitions { get; set; }

		/// <summary>
		/// The partitions to stop.
		/// </summary>
		public StopReplicaRequestPartitionV0[] PartitionsV0Collection { get; set; }

		public class StopReplicaRequestPartitionV0 : ISerialize
		{
			public StopReplicaRequestPartitionV0(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TopicName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionIndex = new Int32(reader.ReadInt32());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(TopicName.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(PartitionIndex.Value);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String TopicName { get; set; }

			/// <summary>
			/// The partition index.
			/// </summary>
			public Int32 PartitionIndex { get; set; }
		}

		/// <summary>
		/// The topics to stop.
		/// </summary>
		public StopReplicaRequestTopic[] TopicsCollection { get; set; }

		public class StopReplicaRequestTopic : ISerialize
		{
			public StopReplicaRequestTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					PartitionIndexesCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					writer.Write(PartitionIndexesCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The partition indexes.
			/// </summary>
			public Int32[] PartitionIndexesCollection { get; set; }
		}
	}

	public class StopReplicaResponse
	{
		public StopReplicaResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 5;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				PartitionsCollection = reader.Read(() => new StopReplicaResponsePartition(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(PartitionsCollection);
			}
		}

		/// <summary>
		/// The top-level error code, or 0 if there was no top-level error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The responses for each partition.
		/// </summary>
		public StopReplicaResponsePartition[] PartitionsCollection { get; set; }

		public class StopReplicaResponsePartition : ISerialize
		{
			public StopReplicaResponsePartition(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TopicName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionIndex = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ErrorCode = new Int16(reader.ReadInt16());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(TopicName.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(PartitionIndex.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ErrorCode.Value);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String TopicName { get; set; }

			/// <summary>
			/// The partition index.
			/// </summary>
			public Int32 PartitionIndex { get; set; }

			/// <summary>
			/// The partition error code, or 0 if there was no partition error.
			/// </summary>
			public Int16 ErrorCode { get; set; }
		}
	}

	public class SyncGroupRequest
	{
		public SyncGroupRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 14;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GenerationId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MemberId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				AssignmentsCollection = reader.Read(() => new SyncGroupRequestAssignment(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(GroupId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(GenerationId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(MemberId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(AssignmentsCollection);
			}
		}

		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public String GroupId { get; set; }

		/// <summary>
		/// The generation of the group.
		/// </summary>
		public Int32 GenerationId { get; set; }

		/// <summary>
		/// The member ID assigned by the group.
		/// </summary>
		public String MemberId { get; set; }

		/// <summary>
		/// Each assignment.
		/// </summary>
		public SyncGroupRequestAssignment[] AssignmentsCollection { get; set; }

		public class SyncGroupRequestAssignment : ISerialize
		{
			public SyncGroupRequestAssignment(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					MemberId = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Assignment = new Bytes(reader.ReadBytes());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(MemberId.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteBytes(Assignment.Value);
				}
			}

			/// <summary>
			/// The ID of the member to assign.
			/// </summary>
			public String MemberId { get; set; }

			/// <summary>
			/// The member assignment.
			/// </summary>
			public Bytes Assignment { get; set; }
		}
	}

	public class SyncGroupResponse
	{
		public SyncGroupResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 14;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				Assignment = new Bytes(reader.ReadBytes());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(1, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteBytes(Assignment.Value);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }

		/// <summary>
		/// The member assignment.
		/// </summary>
		public Bytes Assignment { get; set; }
	}

	public class TxnOffsetCommitRequest
	{
		public TxnOffsetCommitRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 28;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TransactionalId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				GroupId = new String(reader.ReadString());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProducerId = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ProducerEpoch = new Int16(reader.ReadInt16());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new TxnOffsetCommitRequestTopic(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(TransactionalId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteString(GroupId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt64(ProducerId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ProducerEpoch.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The ID of the transaction.
		/// </summary>
		public String TransactionalId { get; set; }

		/// <summary>
		/// The ID of the group.
		/// </summary>
		public String GroupId { get; set; }

		/// <summary>
		/// The current producer ID in use by the transactional ID.
		/// </summary>
		public Int64 ProducerId { get; set; }

		/// <summary>
		/// The current epoch associated with the producer ID.
		/// </summary>
		public Int16 ProducerEpoch { get; set; }

		/// <summary>
		/// Each topic that we want to committ offsets for.
		/// </summary>
		public TxnOffsetCommitRequestTopic[] TopicsCollection { get; set; }

		public class TxnOffsetCommitRequestTopic : ISerialize
		{
			public TxnOffsetCommitRequestTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new TxnOffsetCommitRequestPartition(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The partitions inside the topic that we want to committ offsets for.
			/// </summary>
			public TxnOffsetCommitRequestPartition[] PartitionsCollection { get; set; }

			public class TxnOffsetCommitRequestPartition : ISerialize
			{
				public TxnOffsetCommitRequestPartition(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						CommittedOffset = new Int64(reader.ReadInt64());
					}
					if (Version.InRange(new VersionRange(2, 2147483647))) 
					{
						CommittedLeaderEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						CommittedMetadata = new String(reader.ReadString());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt64(CommittedOffset.Value);
					}
					if (Version.InRange(new VersionRange(2, 2147483647))) 
					{
						writer.WriteInt32(CommittedLeaderEpoch.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(CommittedMetadata.Value);
					}
				}

				/// <summary>
				/// The index of the partition within the topic.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The message offset to be committed.
				/// </summary>
				public Int64 CommittedOffset { get; set; }

				/// <summary>
				/// The leader epoch of the last consumed record.
				/// </summary>
				public Int32 CommittedLeaderEpoch { get; set; } = new Int32(-1);

				/// <summary>
				/// Any associated metadata the client wants to keep.
				/// </summary>
				public String CommittedMetadata { get; set; }
			}
		}
	}

	public class TxnOffsetCommitResponse
	{
		public TxnOffsetCommitResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 28;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ThrottleTimeMs = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				TopicsCollection = reader.Read(() => new TxnOffsetCommitResponseTopic(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ThrottleTimeMs.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(TopicsCollection);
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public Int32 ThrottleTimeMs { get; set; }

		/// <summary>
		/// The responses for each topic.
		/// </summary>
		public TxnOffsetCommitResponseTopic[] TopicsCollection { get; set; }

		public class TxnOffsetCommitResponseTopic : ISerialize
		{
			public TxnOffsetCommitResponseTopic(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Name = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					PartitionsCollection = reader.Read(() => new TxnOffsetCommitResponsePartition(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(Name.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(PartitionsCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String Name { get; set; }

			/// <summary>
			/// The responses for each partition in the topic.
			/// </summary>
			public TxnOffsetCommitResponsePartition[] PartitionsCollection { get; set; }

			public class TxnOffsetCommitResponsePartition : ISerialize
			{
				public TxnOffsetCommitResponsePartition(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						ErrorCode = new Int16(reader.ReadInt16());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteInt16(ErrorCode.Value);
					}
				}

				/// <summary>
				/// The partitition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public Int16 ErrorCode { get; set; }
			}
		}
	}

	public class UpdateMetadataRequest
	{
		public UpdateMetadataRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 6;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ControllerId = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ControllerEpoch = new Int32(reader.ReadInt32());
			}
			if (Version.InRange(new VersionRange(5, 2147483647))) 
			{
				BrokerEpoch = new Int64(reader.ReadInt64());
			}
			if (Version.InRange(new VersionRange(5, 2147483647))) 
			{
				TopicStatesCollection = reader.Read(() => new UpdateMetadataRequestTopicState(Version));
			}
			if (Version.InRange(new VersionRange(0, 4))) 
			{
				PartitionStatesV0Collection = reader.Read(() => new UpdateMetadataRequestPartitionStateV0(Version));
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				BrokersCollection = reader.Read(() => new UpdateMetadataRequestBroker(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ControllerId.Value);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt32(ControllerEpoch.Value);
			}
			if (Version.InRange(new VersionRange(5, 2147483647))) 
			{
				writer.WriteInt64(BrokerEpoch.Value);
			}
			if (Version.InRange(new VersionRange(5, 2147483647))) 
			{
				writer.Write(TopicStatesCollection);
			}
			if (Version.InRange(new VersionRange(0, 4))) 
			{
				writer.Write(PartitionStatesV0Collection);
			}
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(BrokersCollection);
			}
		}

		/// <summary>
		/// The controller id.
		/// </summary>
		public Int32 ControllerId { get; set; }

		/// <summary>
		/// The controller epoch.
		/// </summary>
		public Int32 ControllerEpoch { get; set; }

		/// <summary>
		/// The broker epoch.
		/// </summary>
		public Int64 BrokerEpoch { get; set; } = new Int64(-1);

		/// <summary>
		/// Each topic that we would like to update.
		/// </summary>
		public UpdateMetadataRequestTopicState[] TopicStatesCollection { get; set; }

		public class UpdateMetadataRequestTopicState : ISerialize
		{
			public UpdateMetadataRequestTopicState(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TopicName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(5, 2147483647))) 
				{
					PartitionStatesCollection = reader.Read(() => new UpdateMetadataPartitionState(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(TopicName.Value);
				}
				if (Version.InRange(new VersionRange(5, 2147483647))) 
				{
					writer.Write(PartitionStatesCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String TopicName { get; set; }

			/// <summary>
			/// The partition that we would like to update.
			/// </summary>
			public UpdateMetadataPartitionState[] PartitionStatesCollection { get; set; }

			public class UpdateMetadataPartitionState : ISerialize
			{
				public UpdateMetadataPartitionState(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						PartitionIndex = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						ControllerEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						Leader = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						LeaderEpoch = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						IsrCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						ZkVersion = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						ReplicasCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						OfflineReplicasCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.WriteInt32(PartitionIndex.Value);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.WriteInt32(ControllerEpoch.Value);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.WriteInt32(Leader.Value);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.WriteInt32(LeaderEpoch.Value);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.Write(IsrCollection);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.WriteInt32(ZkVersion.Value);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.Write(ReplicasCollection);
					}
					if (Version.InRange(new VersionRange(5, 2147483647))) 
					{
						writer.Write(OfflineReplicasCollection);
					}
				}

				/// <summary>
				/// The partition index.
				/// </summary>
				public Int32 PartitionIndex { get; set; }

				/// <summary>
				/// The controller epoch.
				/// </summary>
				public Int32 ControllerEpoch { get; set; }

				/// <summary>
				/// The ID of the broker which is the current partition leader.
				/// </summary>
				public Int32 Leader { get; set; }

				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				public Int32 LeaderEpoch { get; set; }

				/// <summary>
				/// The brokers which are in the ISR for this partition.
				/// </summary>
				public Int32[] IsrCollection { get; set; }

				/// <summary>
				/// The Zookeeper version.
				/// </summary>
				public Int32 ZkVersion { get; set; }

				/// <summary>
				/// All the replicas of this partition.
				/// </summary>
				public Int32[] ReplicasCollection { get; set; }

				/// <summary>
				/// The replicas of this partition which are offline.
				/// </summary>
				public Int32[] OfflineReplicasCollection { get; set; }
			}
		}

		/// <summary>
		/// Each partition that we would like to update.
		/// </summary>
		public UpdateMetadataRequestPartitionStateV0[] PartitionStatesV0Collection { get; set; }

		public class UpdateMetadataRequestPartitionStateV0 : ISerialize
		{
			public UpdateMetadataRequestPartitionStateV0(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					TopicName = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					PartitionIndex = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					ControllerEpoch = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					Leader = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					LeaderEpoch = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					IsrCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					ZkVersion = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					ReplicasCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
				if (Version.InRange(new VersionRange(4, 2147483647))) 
				{
					OfflineReplicasCollection = reader.Read(() => new Int32(reader.ReadInt32()));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					writer.WriteString(TopicName.Value);
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					writer.WriteInt32(PartitionIndex.Value);
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					writer.WriteInt32(ControllerEpoch.Value);
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					writer.WriteInt32(Leader.Value);
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					writer.WriteInt32(LeaderEpoch.Value);
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					writer.Write(IsrCollection);
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					writer.WriteInt32(ZkVersion.Value);
				}
				if (Version.InRange(new VersionRange(0, 4))) 
				{
					writer.Write(ReplicasCollection);
				}
				if (Version.InRange(new VersionRange(4, 2147483647))) 
				{
					writer.Write(OfflineReplicasCollection);
				}
			}

			/// <summary>
			/// The topic name.
			/// </summary>
			public String TopicName { get; set; }

			/// <summary>
			/// The partition index.
			/// </summary>
			public Int32 PartitionIndex { get; set; }

			/// <summary>
			/// The controller epoch.
			/// </summary>
			public Int32 ControllerEpoch { get; set; }

			/// <summary>
			/// The ID of the broker which is the current partition leader.
			/// </summary>
			public Int32 Leader { get; set; }

			/// <summary>
			/// The leader epoch of this partition.
			/// </summary>
			public Int32 LeaderEpoch { get; set; }

			/// <summary>
			/// The brokers which are in the ISR for this partition.
			/// </summary>
			public Int32[] IsrCollection { get; set; }

			/// <summary>
			/// The Zookeeper version.
			/// </summary>
			public Int32 ZkVersion { get; set; }

			/// <summary>
			/// All the replicas of this partition.
			/// </summary>
			public Int32[] ReplicasCollection { get; set; }

			/// <summary>
			/// The replicas of this partition which are offline.
			/// </summary>
			public Int32[] OfflineReplicasCollection { get; set; }
		}

		public UpdateMetadataRequestBroker[] BrokersCollection { get; set; }

		public class UpdateMetadataRequestBroker : ISerialize
		{
			public UpdateMetadataRequestBroker(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					Id = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					V0Host = new String(reader.ReadString());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					V0Port = new Int32(reader.ReadInt32());
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					EndpointsCollection = reader.Read(() => new UpdateMetadataRequestEndpoint(Version));
				}
				if (Version.InRange(new VersionRange(2, 2147483647))) 
				{
					Rack = new String(reader.ReadString());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(Id.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteString(V0Host.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(V0Port.Value);
				}
				if (Version.InRange(new VersionRange(1, 2147483647))) 
				{
					writer.Write(EndpointsCollection);
				}
				if (Version.InRange(new VersionRange(2, 2147483647))) 
				{
					writer.WriteString(Rack.Value);
				}
			}

			public Int32 Id { get; set; }

			/// <summary>
			/// The broker hostname.
			/// </summary>
			public String V0Host { get; set; }

			/// <summary>
			/// The broker port.
			/// </summary>
			public Int32 V0Port { get; set; }

			/// <summary>
			/// The broker endpoints.
			/// </summary>
			public UpdateMetadataRequestEndpoint[] EndpointsCollection { get; set; }

			public class UpdateMetadataRequestEndpoint : ISerialize
			{
				public UpdateMetadataRequestEndpoint(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						Port = new Int32(reader.ReadInt32());
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						Host = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(3, 2147483647))) 
					{
						Listener = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						SecurityProtocol = new Int16(reader.ReadInt16());
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.WriteInt32(Port.Value);
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.WriteString(Host.Value);
					}
					if (Version.InRange(new VersionRange(3, 2147483647))) 
					{
						writer.WriteString(Listener.Value);
					}
					if (Version.InRange(new VersionRange(1, 2147483647))) 
					{
						writer.WriteInt16(SecurityProtocol.Value);
					}
				}

				/// <summary>
				/// The port of this endpoint
				/// </summary>
				public Int32 Port { get; set; }

				/// <summary>
				/// The hostname of this endpoint
				/// </summary>
				public String Host { get; set; }

				/// <summary>
				/// The listener name.
				/// </summary>
				public String Listener { get; set; }

				/// <summary>
				/// The security protocol type.
				/// </summary>
				public Int16 SecurityProtocol { get; set; }
			}

			/// <summary>
			/// The rack which this broker belongs to.
			/// </summary>
			public String Rack { get; set; }
		}
	}

	public class UpdateMetadataResponse
	{
		public UpdateMetadataResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 6;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				ErrorCode = new Int16(reader.ReadInt16());
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.WriteInt16(ErrorCode.Value);
			}
		}

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public Int16 ErrorCode { get; set; }
	}

	public class WriteTxnMarkersRequest
	{
		public WriteTxnMarkersRequest(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 27;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MarkersCollection = reader.Read(() => new WritableTxnMarker(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(MarkersCollection);
			}
		}

		/// <summary>
		/// The transaction markers to be written.
		/// </summary>
		public WritableTxnMarker[] MarkersCollection { get; set; }

		public class WritableTxnMarker : ISerialize
		{
			public WritableTxnMarker(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ProducerId = new Int64(reader.ReadInt64());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ProducerEpoch = new Int16(reader.ReadInt16());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TransactionResult = new Boolean(reader.ReadBoolean());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TopicsCollection = reader.Read(() => new WritableTxnMarkerTopic(Version));
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					CoordinatorEpoch = new Int32(reader.ReadInt32());
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt64(ProducerId.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt16(ProducerEpoch.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteBoolean(TransactionResult.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(TopicsCollection);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt32(CoordinatorEpoch.Value);
				}
			}

			/// <summary>
			/// The current producer ID.
			/// </summary>
			public Int64 ProducerId { get; set; }

			/// <summary>
			/// The current epoch associated with the producer ID.
			/// </summary>
			public Int16 ProducerEpoch { get; set; }

			/// <summary>
			/// The result of the transaction to write to the partitions (false = ABORT, true = COMMIT).
			/// </summary>
			public Boolean TransactionResult { get; set; }

			/// <summary>
			/// Each topic that we want to write transaction marker(s) for.
			/// </summary>
			public WritableTxnMarkerTopic[] TopicsCollection { get; set; }

			public class WritableTxnMarkerTopic : ISerialize
			{
				public WritableTxnMarkerTopic(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Name = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionIndexesCollection = reader.Read(() => new Int32(reader.ReadInt32()));
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Name.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(PartitionIndexesCollection);
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				public String Name { get; set; }

				/// <summary>
				/// The indexes of the partitions to write transaction markers for.
				/// </summary>
				public Int32[] PartitionIndexesCollection { get; set; }
			}

			/// <summary>
			/// Epoch associated with the transaction state partition hosted by this transaction coordinator
			/// </summary>
			public Int32 CoordinatorEpoch { get; set; }
		}
	}

	public class WriteTxnMarkersResponse
	{
		public WriteTxnMarkersResponse(int version)
		{
			Version = version;
		}

		public int Version { get; }

		public int ApiKey => 27;

		public void ReadFrom(IKafkaReader reader)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				MarkersCollection = reader.Read(() => new WritableTxnMarkerResult(Version));
			}
		}

		public void WriteTo(IKafkaWriter writer)
		{
			if (Version.InRange(new VersionRange(0, 2147483647))) 
			{
				writer.Write(MarkersCollection);
			}
		}

		/// <summary>
		/// The results for writing makers.
		/// </summary>
		public WritableTxnMarkerResult[] MarkersCollection { get; set; }

		public class WritableTxnMarkerResult : ISerialize
		{
			public WritableTxnMarkerResult(int version)
			{
				Version = version;
			}

			public int Version { get; }

			public void ReadFrom(IKafkaReader reader)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					ProducerId = new Int64(reader.ReadInt64());
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					TopicsCollection = reader.Read(() => new WritableTxnMarkerTopicResult(Version));
				}
			}

			public void WriteTo(IKafkaWriter writer)
			{
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.WriteInt64(ProducerId.Value);
				}
				if (Version.InRange(new VersionRange(0, 2147483647))) 
				{
					writer.Write(TopicsCollection);
				}
			}

			/// <summary>
			/// The current producer ID in use by the transactional ID.
			/// </summary>
			public Int64 ProducerId { get; set; }

			/// <summary>
			/// The results by topic.
			/// </summary>
			public WritableTxnMarkerTopicResult[] TopicsCollection { get; set; }

			public class WritableTxnMarkerTopicResult : ISerialize
			{
				public WritableTxnMarkerTopicResult(int version)
				{
					Version = version;
				}

				public int Version { get; }

				public void ReadFrom(IKafkaReader reader)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						Name = new String(reader.ReadString());
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						PartitionsCollection = reader.Read(() => new WritableTxnMarkerPartitionResult(Version));
					}
				}

				public void WriteTo(IKafkaWriter writer)
				{
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.WriteString(Name.Value);
					}
					if (Version.InRange(new VersionRange(0, 2147483647))) 
					{
						writer.Write(PartitionsCollection);
					}
				}

				/// <summary>
				/// The topic name.
				/// </summary>
				public String Name { get; set; }

				/// <summary>
				/// The results by partition.
				/// </summary>
				public WritableTxnMarkerPartitionResult[] PartitionsCollection { get; set; }

				public class WritableTxnMarkerPartitionResult : ISerialize
				{
					public WritableTxnMarkerPartitionResult(int version)
					{
						Version = version;
					}

					public int Version { get; }

					public void ReadFrom(IKafkaReader reader)
					{
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							PartitionIndex = new Int32(reader.ReadInt32());
						}
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							ErrorCode = new Int16(reader.ReadInt16());
						}
					}

					public void WriteTo(IKafkaWriter writer)
					{
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							writer.WriteInt32(PartitionIndex.Value);
						}
						if (Version.InRange(new VersionRange(0, 2147483647))) 
						{
							writer.WriteInt16(ErrorCode.Value);
						}
					}

					/// <summary>
					/// The partition index.
					/// </summary>
					public Int32 PartitionIndex { get; set; }

					/// <summary>
					/// The error code, or 0 if there was no error.
					/// </summary>
					public Int16 ErrorCode { get; set; }
				}
			}
		}
	}

}