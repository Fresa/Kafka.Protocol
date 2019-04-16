// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.

using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Kafka.Protocol
{
	/// <summary>
	/// Represents a boolean value in a byte. Values 0 and 1 are used to represent false and true respectively. When reading a boolean value, any non-zero value is considered true.
	/// </summary>
	public struct Boolean 
	{
		public System.Boolean Value { get; }

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

		public static Boolean From(System.Boolean value)
		{
			return new Boolean(value);
		}
	}

	/// <summary>
	/// Represents an integer between -27 and 27-1 inclusive.
	/// </summary>
	public struct Int8 
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

		public static Int8 From(System.SByte value)
		{
			return new Int8(value);
		}
	}

	/// <summary>
	/// Represents an integer between -215 and 215-1 inclusive. The values are encoded using two bytes in network byte order (big-endian).
	/// </summary>
	public struct Int16 
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

		public static Int16 From(System.Int16 value)
		{
			return new Int16(value);
		}
	}

	/// <summary>
	/// Represents an integer between -231 and 231-1 inclusive. The values are encoded using four bytes in network byte order (big-endian).
	/// </summary>
	public struct Int32 
	{
		public System.Int32 Value { get; }

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

		public static Int32 From(System.Int32 value)
		{
			return new Int32(value);
		}
	}

	/// <summary>
	/// Represents an integer between -263 and 263-1 inclusive. The values are encoded using eight bytes in network byte order (big-endian).
	/// </summary>
	public struct Int64 
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

		public static Int64 From(System.Int64 value)
		{
			return new Int64(value);
		}
	}

	/// <summary>
	/// Represents an integer between 0 and 232-1 inclusive. The values are encoded using four bytes in network byte order (big-endian).
	/// </summary>
	public struct Uint32 
	{
		public System.UInt32 Value { get; }

		public Uint32(System.UInt32 value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Uint32 comparingUint32 && this == comparingUint32;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Uint32 x, Uint32 y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Uint32 x, Uint32 y)
		{
			return !(x == y);
		}

		public static Uint32 From(System.UInt32 value)
		{
			return new Uint32(value);
		}
	}

	/// <summary>
	/// Represents an integer between -231 and 231-1 inclusive. Encoding follows the variable-length zig-zag encoding from   Google Protocol Buffers.
	/// </summary>
	public struct Varint 
	{
		public System.Int32 Value { get; }

		public Varint(System.Int32 value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Varint comparingVarint && this == comparingVarint;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Varint x, Varint y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Varint x, Varint y)
		{
			return !(x == y);
		}

		public static Varint From(System.Int32 value)
		{
			return new Varint(value);
		}
	}

	/// <summary>
	/// Represents an integer between -263 and 263-1 inclusive. Encoding follows the variable-length zig-zag encoding from   Google Protocol Buffers.
	/// </summary>
	public struct Varlong 
	{
		public System.Int64 Value { get; }

		public Varlong(System.Int64 value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Varlong comparingVarlong && this == comparingVarlong;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Varlong x, Varlong y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Varlong x, Varlong y)
		{
			return !(x == y);
		}

		public static Varlong From(System.Int64 value)
		{
			return new Varlong(value);
		}
	}

	/// <summary>
	/// Represents a sequence of characters. First the length N is given as an INT16. Then N bytes follow which are the UTF-8 encoding of the character sequence. Length must not be negative.
	/// </summary>
	public struct String 
	{
		public System.String Value { get; }

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

		public static String From(System.String value)
		{
			return new String(value);
		}
	}

	/// <summary>
	/// Represents a sequence of characters or null. For non-null strings, first the length N is given as an INT16. Then N bytes follow which are the UTF-8 encoding of the character sequence. A null value is encoded with length of -1 and there are no following bytes.
	/// </summary>
	public struct NullableString 
	{
		public System.String Value { get; }

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

		public static NullableString From(System.String value)
		{
			return new NullableString(value);
		}
	}

	/// <summary>
	/// Represents a raw sequence of bytes. First the length N is given as an INT32. Then N bytes follow.
	/// </summary>
	public struct Bytes 
	{
		public System.Byte[] Value { get; }

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

		public static Bytes From(System.Byte[] value)
		{
			return new Bytes(value);
		}
	}

	/// <summary>
	/// Represents a raw sequence of bytes or null. For non-null values, first the length N is given as an INT32. Then N bytes follow. A null value is encoded with length of -1 and there are no following bytes.
	/// </summary>
	public struct NullableBytes 
	{
		public System.Byte[] Value { get; }

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

		public static NullableBytes From(System.Byte[] value)
		{
			return new NullableBytes(value);
		}
	}

	/// <summary>
	/// Represents a sequence of Kafka records as NULLABLE_BYTES. For a detailed description of records see Message Sets.
	/// </summary>
	public struct Records 
	{
		public System.Byte[] Value { get; }

		public Records(System.Byte[] value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Records comparingRecords && this == comparingRecords;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Records x, Records y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Records x, Records y)
		{
			return !(x == y);
		}

		public static Records From(System.Byte[] value)
		{
			return new Records(value);
		}
	}

	/// <summary>
	/// Represents a sequence of objects of a given type T. Type T can be either a primitive type (e.g. STRING) or a structure. First, the length N is given as an INT32. Then N instances of type T follow. A null array is represented with a length of -1. In protocol documentation an array of T instances is referred to as [T].
	/// </summary>
	public struct Array 
	{
		public System.Array Value { get; }

		public Array(System.Array value)
		{
			Value = value;
		}

		public override bool Equals(object obj) 
		{
			return obj is Array comparingArray && this == comparingArray;
		}

		public override int GetHashCode() 
		{
			return Value.GetHashCode();
		}

		public override string ToString() 
		{
			return Value.ToString();
		}

		public static bool operator == (Array x, Array y)
		{
			return x.Value == y.Value;
		}

		public static bool operator != (Array x, Array y)
		{
			return !(x == y);
		}

		public static Array From(System.Array value)
		{
			return new Array(value);
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
		/// <summary>
		/// The transactional id corresponding to the transaction.
		/// </summary>
		public System.String TransactionalId { get; }

		/// <summary>
		/// Current producer id in use by the transactional id.
		/// </summary>
		public System.Int64 ProducerId { get; }

		/// <summary>
		/// Current epoch associated with the producer id.
		/// </summary>
		public System.Int16 ProducerEpoch { get; }

		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public System.String GroupId { get; }
	}

	public class AddOffsetsToTxnResponse
	{
		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The response error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }
	}

	public class AddPartitionsToTxnRequest
	{
		/// <summary>
		/// The transactional id corresponding to the transaction.
		/// </summary>
		public System.String TransactionalId { get; }

		/// <summary>
		/// Current producer id in use by the transactional id.
		/// </summary>
		public System.Int64 ProducerId { get; }

		/// <summary>
		/// Current epoch associated with the producer id.
		/// </summary>
		public System.Int16 ProducerEpoch { get; }

		/// <summary>
		/// The partitions to add to the transation.
		/// </summary>
		public AddPartitionsToTxnTopic[] TopicsCollection { get; }

		public class AddPartitionsToTxnTopic
		{
			/// <summary>
			/// The name of the topic.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The partition indexes to add to the transaction
			/// </summary>
			public System.Int32[] PartitionsCollection { get; }
		}
	}

	public class AddPartitionsToTxnResponse
	{
		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The results for each topic.
		/// </summary>
		public AddPartitionsToTxnTopicResult[] ResultsCollection { get; }

		public class AddPartitionsToTxnTopicResult
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The results for each partition
			/// </summary>
			public AddPartitionsToTxnPartitionResult[] ResultsCollection { get; }

			public class AddPartitionsToTxnPartitionResult
			{
				/// <summary>
				/// The partition indexes.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The response error code.
				/// </summary>
				public System.Int16 ErrorCode { get; }
			}
		}
	}

	public class AlterConfigsRequest
	{
		/// <summary>
		/// The updates for each resource.
		/// </summary>
		public AlterConfigsResource[] ResourcesCollection { get; }

		public class AlterConfigsResource
		{
			/// <summary>
			/// The resource type.
			/// </summary>
			public System.SByte ResourceType { get; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public System.String ResourceName { get; }

			/// <summary>
			/// The configurations.
			/// </summary>
			public AlterableConfig[] ConfigsCollection { get; }

			public class AlterableConfig
			{
				/// <summary>
				/// The configuration key name.
				/// </summary>
				public System.String Name { get; }

				/// <summary>
				/// The value to set for the configuration key.
				/// </summary>
				public System.String Value { get; }
			}
		}

		/// <summary>
		/// True if we should validate the request, but not change the configurations.
		/// </summary>
		public bool ValidateOnly { get; }
	}

	public class AlterConfigsResponse
	{
		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The responses for each resource.
		/// </summary>
		public AlterConfigsResourceResponse[] ResourcesCollection { get; }

		public class AlterConfigsResourceResponse
		{
			/// <summary>
			/// The resource error code.
			/// </summary>
			public System.Int16 ErrorCode { get; }

			/// <summary>
			/// The resource error message, or null if there was no error.
			/// </summary>
			public System.String ErrorMessage { get; }

			/// <summary>
			/// The resource type.
			/// </summary>
			public System.SByte ResourceType { get; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public System.String ResourceName { get; }
		}
	}

	public class AlterReplicaLogDirsRequest
	{
		/// <summary>
		/// The alterations to make for each directory.
		/// </summary>
		public AlterReplicaLogDir[] DirsCollection { get; }

		public class AlterReplicaLogDir
		{
			/// <summary>
			/// The absolute directory path.
			/// </summary>
			public System.String Path { get; }

			/// <summary>
			/// The topics to add to the directory.
			/// </summary>
			public AlterReplicaLogDirTopic[] TopicsCollection { get; }

			public class AlterReplicaLogDirTopic
			{
				/// <summary>
				/// The topic name.
				/// </summary>
				public System.String Name { get; }

				/// <summary>
				/// The partition indexes.
				/// </summary>
				public System.Int32[] PartitionsCollection { get; }
			}
		}
	}

	public class AlterReplicaLogDirsResponse
	{
		/// <summary>
		/// Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The results for each topic.
		/// </summary>
		public AlterReplicaLogDirTopicResult[] ResultsCollection { get; }

		public class AlterReplicaLogDirTopicResult
		{
			/// <summary>
			/// The name of the topic.
			/// </summary>
			public System.String TopicName { get; }

			/// <summary>
			/// The results for each partition.
			/// </summary>
			public AlterReplicaLogDirPartitionResult[] PartitionsCollection { get; }

			public class AlterReplicaLogDirPartitionResult
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public System.Int16 ErrorCode { get; }
			}
		}
	}

	public class ApiVersionsRequest
	{

	}

	public class ApiVersionsResponse
	{
		/// <summary>
		/// The top-level error code.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The APIs supported by the broker.
		/// </summary>
		public ApiVersionsResponseKey[] ApiKeysCollection { get; }

		public class ApiVersionsResponseKey
		{
			/// <summary>
			/// The API index.
			/// </summary>
			public System.Int16 Index { get; }

			/// <summary>
			/// The minimum supported version, inclusive.
			/// </summary>
			public System.Int16 MinVersion { get; }

			/// <summary>
			/// The maximum supported version, inclusive.
			/// </summary>
			public System.Int16 MaxVersion { get; }
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }
	}

	public class ControlledShutdownRequest
	{
		/// <summary>
		/// The id of the broker for which controlled shutdown has been requested.
		/// </summary>
		public System.Int32 BrokerId { get; }

		/// <summary>
		/// The broker epoch.
		/// </summary>
		public System.Int64 BrokerEpoch { get; }
	}

	public class ControlledShutdownResponse
	{
		/// <summary>
		/// The top-level error code.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The partitions that the broker still leads.
		/// </summary>
		public RemainingPartition[] RemainingPartitionsCollection { get; }

		public class RemainingPartition
		{
			/// <summary>
			/// The name of the topic.
			/// </summary>
			public System.String TopicName { get; }

			/// <summary>
			/// The index of the partition.
			/// </summary>
			public System.Int32 PartitionIndex { get; }
		}
	}

	public class CreateAclsRequest
	{
		/// <summary>
		/// The ACLs that we want to create.
		/// </summary>
		public CreatableAcl[] CreationsCollection { get; }

		public class CreatableAcl
		{
			/// <summary>
			/// The type of the resource.
			/// </summary>
			public System.SByte ResourceType { get; }

			/// <summary>
			/// The resource name for the ACL.
			/// </summary>
			public System.String ResourceName { get; }

			/// <summary>
			/// The pattern type for the ACL.
			/// </summary>
			public System.SByte ResourcePatternType { get; }

			/// <summary>
			/// The principal for the ACL.
			/// </summary>
			public System.String Principal { get; }

			/// <summary>
			/// The host for the ACL.
			/// </summary>
			public System.String Host { get; }

			/// <summary>
			/// The operation type for the ACL (read, write, etc.).
			/// </summary>
			public System.SByte Operation { get; }

			/// <summary>
			/// The permission type for the ACL (allow, deny, etc.).
			/// </summary>
			public System.SByte PermissionType { get; }
		}
	}

	public class CreateAclsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The results for each ACL creation.
		/// </summary>
		public CreatableAclResult[] ResultsCollection { get; }

		public class CreatableAclResult
		{
			/// <summary>
			/// The result error, or zero if there was no error.
			/// </summary>
			public System.Int16 ErrorCode { get; }

			/// <summary>
			/// The result message, or null if there was no error.
			/// </summary>
			public System.String ErrorMessage { get; }
		}
	}

	public class CreateDelegationTokenRequest
	{
		/// <summary>
		/// A list of those who are allowed to renew this token before it expires.
		/// </summary>
		public CreatableRenewers[] RenewersCollection { get; }

		public class CreatableRenewers
		{
			/// <summary>
			/// The type of the Kafka principal.
			/// </summary>
			public System.String PrincipalType { get; }

			/// <summary>
			/// The name of the Kafka principal.
			/// </summary>
			public System.String PrincipalName { get; }
		}

		/// <summary>
		/// The maximum lifetime of the token in milliseconds, or -1 to use the server side default.
		/// </summary>
		public System.Int64 MaxLifetimeMs { get; }
	}

	public class CreateDelegationTokenResponse
	{
		/// <summary>
		/// The top-level error, or zero if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The principal type of the token owner.
		/// </summary>
		public System.String PrincipalType { get; }

		/// <summary>
		/// The name of the token owner.
		/// </summary>
		public System.String PrincipalName { get; }

		/// <summary>
		/// When this token was generated.
		/// </summary>
		public System.Int64 IssueTimestampMs { get; }

		/// <summary>
		/// When this token expires.
		/// </summary>
		public System.Int64 ExpiryTimestampMs { get; }

		/// <summary>
		/// The maximum lifetime of this token.
		/// </summary>
		public System.Int64 MaxTimestampMs { get; }

		/// <summary>
		/// The token UUID.
		/// </summary>
		public System.String TokenId { get; }

		/// <summary>
		/// HMAC of the delegation token.
		/// </summary>
		public System.Byte[] HmacCollection { get; }

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }
	}

	public class CreatePartitionsRequest
	{
		/// <summary>
		/// Each topic that we want to create new partitions inside.
		/// </summary>
		public CreatePartitionsTopic[] TopicsCollection { get; }

		public class CreatePartitionsTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The new partition count.
			/// </summary>
			public System.Int32 Count { get; }

			/// <summary>
			/// The new partition assignments.
			/// </summary>
			public CreatePartitionsAssignment[] AssignmentsCollection { get; }

			public class CreatePartitionsAssignment
			{
				/// <summary>
				/// The assigned broker IDs.
				/// </summary>
				public System.Int32[] BrokerIdsCollection { get; }
			}
		}

		/// <summary>
		/// The time in ms to wait for the partitions to be created.
		/// </summary>
		public System.Int32 TimeoutMs { get; }

		/// <summary>
		/// If true, then validate the request, but don't actually increase the number of partitions.
		/// </summary>
		public bool ValidateOnly { get; }
	}

	public class CreatePartitionsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The partition creation results for each topic.
		/// </summary>
		public CreatePartitionsTopicResult[] ResultsCollection { get; }

		public class CreatePartitionsTopicResult
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The result error, or zero if there was no error.
			/// </summary>
			public System.Int16 ErrorCode { get; }

			/// <summary>
			/// The result message, or null if there was no error.
			/// </summary>
			public System.String ErrorMessage { get; }
		}
	}

	public class CreateTopicsRequest
	{
		/// <summary>
		/// The topics to create.
		/// </summary>
		public CreatableTopic[] TopicsCollection { get; }

		public class CreatableTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The number of partitions to create in the topic, or -1 if we are specifying a manual partition assignment.
			/// </summary>
			public System.Int32 NumPartitions { get; }

			/// <summary>
			/// The number of replicas to create for each partition in the topic, or -1 if we are specifying a manual partition assignment.
			/// </summary>
			public System.Int16 ReplicationFactor { get; }

			/// <summary>
			/// The manual partition assignment, or the empty array if we are using automatic assignment.
			/// </summary>
			public CreatableReplicaAssignment[] AssignmentsCollection { get; }

			public class CreatableReplicaAssignment
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The brokers to place the partition on.
				/// </summary>
				public System.Int32[] BrokerIdsCollection { get; }
			}

			/// <summary>
			/// The custom topic configurations to set.
			/// </summary>
			public CreateableTopicConfig[] ConfigsCollection { get; }

			public class CreateableTopicConfig
			{
				/// <summary>
				/// The configuration name.
				/// </summary>
				public System.String Name { get; }

				/// <summary>
				/// The configuration value.
				/// </summary>
				public System.String Value { get; }
			}
		}

		/// <summary>
		/// How long to wait in milliseconds before timing out the request.
		/// </summary>
		public System.Int32 timeoutMs { get; }

		/// <summary>
		/// If true, check that the topics can be created as specified, but don't create anything.
		/// </summary>
		public bool validateOnly { get; }
	}

	public class CreateTopicsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// Results for each topic we tried to create.
		/// </summary>
		public CreatableTopicResult[] TopicsCollection { get; }

		public class CreatableTopicResult
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The error code, or 0 if there was no error.
			/// </summary>
			public System.Int16 ErrorCode { get; }

			/// <summary>
			/// The error message, or null if there was no error.
			/// </summary>
			public System.String ErrorMessage { get; }
		}
	}

	public class DeleteAclsRequest
	{
		/// <summary>
		/// The filters to use when deleting ACLs.
		/// </summary>
		public DeleteAclsFilter[] FiltersCollection { get; }

		public class DeleteAclsFilter
		{
			/// <summary>
			/// The resource type.
			/// </summary>
			public System.SByte ResourceTypeFilter { get; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public System.String ResourceNameFilter { get; }

			/// <summary>
			/// The pattern type.
			/// </summary>
			public System.SByte PatternTypeFilter { get; }

			/// <summary>
			/// The principal filter, or null to accept all principals.
			/// </summary>
			public System.String PrincipalFilter { get; }

			/// <summary>
			/// The host filter, or null to accept all hosts.
			/// </summary>
			public System.String HostFilter { get; }

			/// <summary>
			/// The ACL operation.
			/// </summary>
			public System.SByte Operation { get; }

			/// <summary>
			/// The permission type.
			/// </summary>
			public System.SByte PermissionType { get; }
		}
	}

	public class DeleteAclsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The results for each filter.
		/// </summary>
		public DeleteAclsFilterResult[] FilterResultsCollection { get; }

		public class DeleteAclsFilterResult
		{
			/// <summary>
			/// The error code, or 0 if the filter succeeded.
			/// </summary>
			public System.Int16 ErrorCode { get; }

			/// <summary>
			/// The error message, or null if the filter succeeded.
			/// </summary>
			public System.String ErrorMessage { get; }

			/// <summary>
			/// The ACLs which matched this filter.
			/// </summary>
			public DeleteAclsMatchingAcl[] MatchingAclsCollection { get; }

			public class DeleteAclsMatchingAcl
			{
				/// <summary>
				/// The deletion error code, or 0 if the deletion succeeded.
				/// </summary>
				public System.Int16 ErrorCode { get; }

				/// <summary>
				/// The deletion error message, or null if the deletion succeeded.
				/// </summary>
				public System.String ErrorMessage { get; }

				/// <summary>
				/// The ACL resource type.
				/// </summary>
				public System.SByte ResourceType { get; }

				/// <summary>
				/// The ACL resource name.
				/// </summary>
				public System.String ResourceName { get; }

				/// <summary>
				/// The ACL resource pattern type.
				/// </summary>
				public System.SByte PatternType { get; }

				/// <summary>
				/// The ACL principal.
				/// </summary>
				public System.String Principal { get; }

				/// <summary>
				/// The ACL host.
				/// </summary>
				public System.String Host { get; }

				/// <summary>
				/// The ACL operation.
				/// </summary>
				public System.SByte Operation { get; }

				/// <summary>
				/// The ACL permission type.
				/// </summary>
				public System.SByte PermissionType { get; }
			}
		}
	}

	public class DeleteGroupsRequest
	{
		/// <summary>
		/// The group names to delete.
		/// </summary>
		public System.String[] GroupsNamesCollection { get; }
	}

	public class DeleteGroupsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The deletion results
		/// </summary>
		public DeletableGroupResult[] ResultsCollection { get; }

		public class DeletableGroupResult
		{
			/// <summary>
			/// The group id
			/// </summary>
			public System.String GroupId { get; }

			/// <summary>
			/// The deletion error, or 0 if the deletion succeeded.
			/// </summary>
			public System.Int16 ErrorCode { get; }
		}
	}

	public class DeleteRecordsRequest
	{
		/// <summary>
		/// Each topic that we want to delete records from.
		/// </summary>
		public DeleteRecordsTopic[] TopicsCollection { get; }

		public class DeleteRecordsTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// Each partition that we want to delete records from.
			/// </summary>
			public DeleteRecordsPartition[] PartitionsCollection { get; }

			public class DeleteRecordsPartition
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The deletion offset.
				/// </summary>
				public System.Int64 Offset { get; }
			}
		}

		/// <summary>
		/// How long to wait for the deletion to complete, in milliseconds.
		/// </summary>
		public System.Int32 TimeoutMs { get; }
	}

	public class DeleteRecordsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// Each topic that we wanted to delete records from.
		/// </summary>
		public DeleteRecordsTopicResult[] TopicsCollection { get; }

		public class DeleteRecordsTopicResult
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// Each partition that we wanted to delete records from.
			/// </summary>
			public DeleteRecordsPartitionResult[] PartitionsCollection { get; }

			public class DeleteRecordsPartitionResult
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The partition low water mark.
				/// </summary>
				public System.Int64 LowWatermark { get; }

				/// <summary>
				/// The deletion error code, or 0 if the deletion succeeded.
				/// </summary>
				public System.Int16 ErrorCode { get; }
			}
		}
	}

	public class DeleteTopicsRequest
	{
		/// <summary>
		/// The names of the topics to delete
		/// </summary>
		public System.String[] TopicNamesCollection { get; }

		/// <summary>
		/// The length of time in milliseconds to wait for the deletions to complete.
		/// </summary>
		public System.Int32 TimeoutMs { get; }
	}

	public class DeleteTopicsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The results for each topic we tried to delete.
		/// </summary>
		public DeletableTopicResult[] ResponsesCollection { get; }

		public class DeletableTopicResult
		{
			/// <summary>
			/// The topic name
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The deletion error, or 0 if the deletion succeeded.
			/// </summary>
			public System.Int16 ErrorCode { get; }
		}
	}

	public class DescribeAclsRequest
	{
		/// <summary>
		/// The resource type.
		/// </summary>
		public System.SByte ResourceType { get; }

		/// <summary>
		/// The resource name, or null to match any resource name.
		/// </summary>
		public System.String ResourceNameFilter { get; }

		/// <summary>
		/// The resource pattern to match.
		/// </summary>
		public System.SByte ResourcePatternType { get; }

		/// <summary>
		/// The principal to match, or null to match any principal.
		/// </summary>
		public System.String PrincipalFilter { get; }

		/// <summary>
		/// The host to match, or null to match any host.
		/// </summary>
		public System.String HostFilter { get; }

		/// <summary>
		/// The operation to match.
		/// </summary>
		public System.SByte Operation { get; }

		/// <summary>
		/// The permission type to match.
		/// </summary>
		public System.SByte PermissionType { get; }
	}

	public class DescribeAclsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public System.String ErrorMessage { get; }

		/// <summary>
		/// Each Resource that is referenced in an ACL.
		/// </summary>
		public DescribeAclsResource[] ResourcesCollection { get; }

		public class DescribeAclsResource
		{
			/// <summary>
			/// The resource type.
			/// </summary>
			public System.SByte Type { get; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The resource pattern type.
			/// </summary>
			public System.SByte PatternType { get; }

			/// <summary>
			/// The ACLs.
			/// </summary>
			public AclDescription[] AclsCollection { get; }

			public class AclDescription
			{
				/// <summary>
				/// The ACL principal.
				/// </summary>
				public System.String Principal { get; }

				/// <summary>
				/// The ACL host.
				/// </summary>
				public System.String Host { get; }

				/// <summary>
				/// The ACL operation.
				/// </summary>
				public System.SByte Operation { get; }

				/// <summary>
				/// The ACL permission type.
				/// </summary>
				public System.SByte PermissionType { get; }
			}
		}
	}

	public class DescribeConfigsRequest
	{
		/// <summary>
		/// The resources whose configurations we want to describe.
		/// </summary>
		public DescribeConfigsResource[] ResourcesCollection { get; }

		public class DescribeConfigsResource
		{
			/// <summary>
			/// The resource type.
			/// </summary>
			public System.SByte ResourceType { get; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public System.String ResourceName { get; }

			/// <summary>
			/// The configuration keys to list, or null to list all configuration keys.
			/// </summary>
			public System.String[] ConfigurationKeysCollection { get; }
		}

		/// <summary>
		/// True if we should include all synonyms.
		/// </summary>
		public bool IncludeSynoyms { get; }
	}

	public class DescribeConfigsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The results for each resource.
		/// </summary>
		public DescribeConfigsResult[] ResultsCollection { get; }

		public class DescribeConfigsResult
		{
			/// <summary>
			/// The error code, or 0 if we were able to successfully describe the configurations.
			/// </summary>
			public System.Int16 ErrorCode { get; }

			/// <summary>
			/// The error message, or null if we were able to successfully describe the configurations.
			/// </summary>
			public System.String ErrorMessage { get; }

			/// <summary>
			/// The resource type.
			/// </summary>
			public System.SByte ResourceType { get; }

			/// <summary>
			/// The resource name.
			/// </summary>
			public System.String ResourceName { get; }

			/// <summary>
			/// Each listed configuration.
			/// </summary>
			public DescribeConfigsResourceResult[] ConfigsCollection { get; }

			public class DescribeConfigsResourceResult
			{
				/// <summary>
				/// The configuration name.
				/// </summary>
				public System.String Name { get; }

				/// <summary>
				/// The configuration value.
				/// </summary>
				public System.String Value { get; }

				/// <summary>
				/// True if the configuration is read-only.
				/// </summary>
				public bool ReadOnly { get; }

				/// <summary>
				/// True if the configuration is not set.
				/// </summary>
				public bool IsDefault { get; }

				/// <summary>
				/// The configuration source.
				/// </summary>
				public System.SByte ConfigSource { get; }

				/// <summary>
				/// True if this configuration is sensitive.
				/// </summary>
				public bool IsSensitive { get; }

				/// <summary>
				/// The synonyms for this configuration key.
				/// </summary>
				public DescribeConfigsSynonym[] SynonymsCollection { get; }

				public class DescribeConfigsSynonym
				{
					/// <summary>
					/// The synonym name.
					/// </summary>
					public System.String Name { get; }

					/// <summary>
					/// The synonym value.
					/// </summary>
					public System.String Value { get; }

					/// <summary>
					/// The synonym source.
					/// </summary>
					public System.SByte Source { get; }
				}
			}
		}
	}

	public class DescribeDelegationTokenRequest
	{
		/// <summary>
		/// Each owner that we want to describe delegation tokens for, or null to describe all tokens.
		/// </summary>
		public DescribeDelegationTokenOwner[] OwnersCollection { get; }

		public class DescribeDelegationTokenOwner
		{
			/// <summary>
			/// The owner principal type.
			/// </summary>
			public System.String PrincipalType { get; }

			/// <summary>
			/// The owner principal name.
			/// </summary>
			public System.String PrincipalName { get; }
		}
	}

	public class DescribeDelegationTokenResponse
	{
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The tokens.
		/// </summary>
		public DescribedDelegationToken[] TokensCollection { get; }

		public class DescribedDelegationToken
		{
			/// <summary>
			/// The token principal type.
			/// </summary>
			public System.String PrincipalType { get; }

			/// <summary>
			/// The token principal name.
			/// </summary>
			public System.String PrincipalName { get; }

			/// <summary>
			/// The token issue timestamp in milliseconds.
			/// </summary>
			public System.Int64 IssueTimestamp { get; }

			/// <summary>
			/// The token expiry timestamp in milliseconds.
			/// </summary>
			public System.Int64 ExpiryTimestamp { get; }

			/// <summary>
			/// The token maximum timestamp length in milliseconds.
			/// </summary>
			public System.Int64 MaxTimestamp { get; }

			/// <summary>
			/// The token ID.
			/// </summary>
			public System.String TokenId { get; }

			/// <summary>
			/// The token HMAC.
			/// </summary>
			public System.Byte[] HmacCollection { get; }

			/// <summary>
			/// Those who are able to renew this token before it expires.
			/// </summary>
			public DescribedDelegationTokenRenewer[] RenewersCollection { get; }

			public class DescribedDelegationTokenRenewer
			{
				/// <summary>
				/// The renewer principal type
				/// </summary>
				public System.String PrincipalType { get; }

				/// <summary>
				/// The renewer principal name
				/// </summary>
				public System.String PrincipalName { get; }
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }
	}

	public class DescribeGroupsRequest
	{
		/// <summary>
		/// The names of the groups to describe
		/// </summary>
		public System.String[] GroupsCollection { get; }

		/// <summary>
		/// Whether to include authorized operations.
		/// </summary>
		public bool IncludeAuthorizedOperations { get; }
	}

	public class DescribeGroupsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// Each described group.
		/// </summary>
		public DescribedGroup[] GroupsCollection { get; }

		public class DescribedGroup
		{
			/// <summary>
			/// The describe error, or 0 if there was no error.
			/// </summary>
			public System.Int16 ErrorCode { get; }

			/// <summary>
			/// The group ID string.
			/// </summary>
			public System.String GroupId { get; }

			/// <summary>
			/// The group state string, or the empty string.
			/// </summary>
			public System.String GroupState { get; }

			/// <summary>
			/// The group protocol type, or the empty string.
			/// </summary>
			public System.String ProtocolType { get; }

			/// <summary>
			/// The group protocol data, or the empty string.
			/// </summary>
			public System.String ProtocolData { get; }

			/// <summary>
			/// The group members.
			/// </summary>
			public DescribedGroupMember[] MembersCollection { get; }

			public class DescribedGroupMember
			{
				/// <summary>
				/// The member ID assigned by the group coordinator.
				/// </summary>
				public System.String MemberId { get; }

				/// <summary>
				/// The client ID used in the member's latest join group request.
				/// </summary>
				public System.String ClientId { get; }

				/// <summary>
				/// The client host.
				/// </summary>
				public System.String ClientHost { get; }

				/// <summary>
				/// The metadata corresponding to the current group protocol in use.
				/// </summary>
				public System.Byte[] MemberMetadataCollection { get; }

				/// <summary>
				/// The current assignment provided by the group leader.
				/// </summary>
				public System.Byte[] MemberAssignmentCollection { get; }
			}

			/// <summary>
			/// 32-bit bitfield to represent authorized operations for this group.
			/// </summary>
			public System.Int32 AuthorizedOperations { get; }
		}
	}

	public class DescribeLogDirsRequest
	{
		/// <summary>
		/// Each topic that we want to describe log directories for, or null for all topics.
		/// </summary>
		public DescribableLogDirTopic[] TopicsCollection { get; }

		public class DescribableLogDirTopic
		{
			/// <summary>
			/// The topic name
			/// </summary>
			public System.String Topic { get; }

			/// <summary>
			/// The partition indxes.
			/// </summary>
			public System.Int32[] PartitionIndexCollection { get; }
		}
	}

	public class DescribeLogDirsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The log directories.
		/// </summary>
		public DescribeLogDirsResult[] ResultsCollection { get; }

		public class DescribeLogDirsResult
		{
			/// <summary>
			/// The error code, or 0 if there was no error.
			/// </summary>
			public System.Int16 ErrorCode { get; }

			/// <summary>
			/// The absolute log directory path.
			/// </summary>
			public System.String LogDir { get; }

			/// <summary>
			/// Each topic.
			/// </summary>
			public DescribeLogDirsTopic[] TopicsCollection { get; }

			public class DescribeLogDirsTopic
			{
				/// <summary>
				/// The topic name.
				/// </summary>
				public System.String Name { get; }

				public DescribeLogDirsPartition[] PartitionsCollection { get; }

				public class DescribeLogDirsPartition
				{
					/// <summary>
					/// The partition index.
					/// </summary>
					public System.Int32 PartitionIndex { get; }

					/// <summary>
					/// The size of the log segments in this partition in bytes.
					/// </summary>
					public System.Int64 PartitionSize { get; }

					/// <summary>
					/// The lag of the log's LEO w.r.t. partition's HW (if it is the current log for the partition) or current replica's LEO (if it is the future log for the partition)
					/// </summary>
					public System.Int64 OffsetLag { get; }

					/// <summary>
					/// True if this log is created by AlterReplicaLogDirsRequest and will replace the current log of the replica in the future.
					/// </summary>
					public bool IsFutureKey { get; }
				}
			}
		}
	}

	public class ElectPreferredLeadersRequest
	{
		/// <summary>
		/// The topic partitions to elect the preferred leader of.
		/// </summary>
		public TopicPartitions[] TopicPartitionsCollection { get; }

		public class TopicPartitions
		{
			/// <summary>
			/// The name of a topic.
			/// </summary>
			public System.String Topic { get; }

			/// <summary>
			/// The partitions of this topic whose preferred leader should be elected
			/// </summary>
			public System.Int32[] PartitionIdCollection { get; }
		}

		/// <summary>
		/// The time in ms to wait for the election to complete.
		/// </summary>
		public System.Int32 TimeoutMs { get; }
	}

	public class ElectPreferredLeadersResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The election results, or an empty array if the requester did not have permission and the request asks for all partitions.
		/// </summary>
		public ReplicaElectionResult[] ReplicaElectionResultsCollection { get; }

		public class ReplicaElectionResult
		{
			/// <summary>
			/// The topic name
			/// </summary>
			public System.String Topic { get; }

			/// <summary>
			/// The results for each partition
			/// </summary>
			public PartitionResult[] PartitionResultCollection { get; }

			public class PartitionResult
			{
				/// <summary>
				/// The partition id
				/// </summary>
				public System.Int32 PartitionId { get; }

				/// <summary>
				/// The result error, or zero if there was no error.
				/// </summary>
				public System.Int16 ErrorCode { get; }

				/// <summary>
				/// The result message, or null if there was no error.
				/// </summary>
				public System.String ErrorMessage { get; }
			}
		}
	}

	public class EndTxnRequest
	{
		/// <summary>
		/// The ID of the transaction to end.
		/// </summary>
		public System.String TransactionalId { get; }

		/// <summary>
		/// The producer ID.
		/// </summary>
		public System.Int64 ProducerId { get; }

		/// <summary>
		/// The current epoch associated with the producer.
		/// </summary>
		public System.Int16 ProducerEpoch { get; }

		/// <summary>
		/// True if the transaction was committed, false if it was aborted.
		/// </summary>
		public bool Committed { get; }
	}

	public class EndTxnResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }
	}

	public class ExpireDelegationTokenRequest
	{
		/// <summary>
		/// The HMAC of the delegation token to be expired.
		/// </summary>
		public System.Byte[] HmacCollection { get; }

		/// <summary>
		/// The expiry time period in milliseconds.
		/// </summary>
		public System.Int64 ExpiryTimePeriodMs { get; }
	}

	public class ExpireDelegationTokenResponse
	{
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The timestamp in milliseconds at which this token expires.
		/// </summary>
		public System.Int64 ExpiryTimestampMs { get; }

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }
	}

	public class FetchRequest
	{
		/// <summary>
		/// The broker ID of the follower, of -1 if this request is from a consumer.
		/// </summary>
		public System.Int32 ReplicaId { get; }

		/// <summary>
		/// The maximum time in milliseconds to wait for the response.
		/// </summary>
		public System.Int32 MaxWait { get; }

		/// <summary>
		/// The minimum bytes to accumulate in the response.
		/// </summary>
		public System.Int32 MinBytes { get; }

		/// <summary>
		/// The maximum bytes to fetch.  See KIP-74 for cases where this limit may not be honored.
		/// </summary>
		public System.Int32 MaxBytes { get; }

		/// <summary>
		/// This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records
		/// </summary>
		public System.SByte IsolationLevel { get; }

		/// <summary>
		/// The fetch session ID.
		/// </summary>
		public System.Int32 SessionId { get; }

		/// <summary>
		/// The fetch session ID.
		/// </summary>
		public System.Int32 Epoch { get; }

		/// <summary>
		/// The topics to fetch.
		/// </summary>
		public FetchableTopic[] TopicsCollection { get; }

		public class FetchableTopic
		{
			/// <summary>
			/// The name of the topic to fetch.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The partitions to fetch.
			/// </summary>
			public FetchPartition[] FetchPartitionsCollection { get; }

			public class FetchPartition
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The current leader epoch of the partition.
				/// </summary>
				public System.Int32 CurrentLeaderEpoch { get; }

				/// <summary>
				/// The message offset.
				/// </summary>
				public System.Int64 FetchOffset { get; }

				/// <summary>
				/// The earliest available offset of the follower replica.  The field is only used when the request is sent by the follower.
				/// </summary>
				public System.Int64 LogStartOffset { get; }

				/// <summary>
				/// The maximum bytes to fetch from this partition.  See KIP-74 for cases where this limit may not be honored.
				/// </summary>
				public System.Int32 MaxBytes { get; }
			}
		}

		/// <summary>
		/// In an incremental fetch request, the partitions to remove.
		/// </summary>
		public ForgottenTopic[] ForgottenCollection { get; }

		public class ForgottenTopic
		{
			/// <summary>
			/// The partition name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The partitions indexes to forget.
			/// </summary>
			public System.Int32[] ForgottenPartitionIndexesCollection { get; }
		}
	}

	public class FetchResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The top level response error code.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The fetch session ID, or 0 if this is not part of a fetch session.
		/// </summary>
		public System.Int32 SessionId { get; }

		/// <summary>
		/// The response topics.
		/// </summary>
		public FetchableTopicResponse[] TopicsCollection { get; }

		public class FetchableTopicResponse
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The topic partitions.
			/// </summary>
			public FetchablePartitionResponse[] PartitionsCollection { get; }

			public class FetchablePartitionResponse
			{
				/// <summary>
				/// The partiiton index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The error code, or 0 if there was no fetch error.
				/// </summary>
				public System.Int16 ErrorCode { get; }

				/// <summary>
				/// The current high water mark.
				/// </summary>
				public System.Int64 HighWatermark { get; }

				/// <summary>
				/// The last stable offset (or LSO) of the partition. This is the last offset such that the state of all transactional records prior to this offset have been decided (ABORTED or COMMITTED)
				/// </summary>
				public System.Int64 LastStableOffset { get; }

				/// <summary>
				/// The current log start offset.
				/// </summary>
				public System.Int64 LogStartOffset { get; }

				/// <summary>
				/// The aborted transactions.
				/// </summary>
				public AbortedTransaction[] AbortedCollection { get; }

				public class AbortedTransaction
				{
					/// <summary>
					/// The producer id associated with the aborted transaction.
					/// </summary>
					public System.Int64 ProducerId { get; }

					/// <summary>
					/// The first offset in the aborted transaction.
					/// </summary>
					public System.Int64 FirstOffset { get; }
				}

				/// <summary>
				/// The record data.
				/// </summary>
				public System.Byte[] RecordsCollection { get; }
			}
		}
	}

	public class FindCoordinatorRequest
	{
		/// <summary>
		/// The coordinator key.
		/// </summary>
		public System.String Key { get; }

		/// <summary>
		/// The coordinator key type.  (Group, transaction, etc.)
		/// </summary>
		public System.SByte KeyType { get; }
	}

	public class FindCoordinatorResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public System.String ErrorMessage { get; }

		/// <summary>
		/// The node id.
		/// </summary>
		public System.Int32 NodeId { get; }

		/// <summary>
		/// The host name.
		/// </summary>
		public System.String Host { get; }

		/// <summary>
		/// The port.
		/// </summary>
		public System.Int32 Port { get; }
	}

	public class HeartbeatRequest
	{
		/// <summary>
		/// The group id.
		/// </summary>
		public System.String GroupId { get; }

		/// <summary>
		/// The generation of the group.
		/// </summary>
		public System.Int32 Generationid { get; }

		/// <summary>
		/// The member ID.
		/// </summary>
		public System.String MemberId { get; }
	}

	public class HeartbeatResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }
	}

	public class InitProducerIdRequest
	{
		/// <summary>
		/// The transactional id, or null if the producer is not transactional.
		/// </summary>
		public System.String TransactionalId { get; }

		/// <summary>
		/// The time in ms to wait for before aborting idle transactions sent by this producer.
		/// </summary>
		public System.Int32 TransactionTimeoutMs { get; }
	}

	public class InitProducerIdResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The current producer id.
		/// </summary>
		public System.Int64 ProducerId { get; }

		/// <summary>
		/// The current epoch associated with the producer id.
		/// </summary>
		public System.Int16 ProducerEpoch { get; }
	}

	public class JoinGroupRequest
	{
		/// <summary>
		/// The group identifier.
		/// </summary>
		public System.String GroupId { get; }

		/// <summary>
		/// The coordinator considers the consumer dead if it receives no heartbeat after this timeout in milliseconds.
		/// </summary>
		public System.Int32 SessionTimeoutMs { get; }

		/// <summary>
		/// The maximum time in milliseconds that the coordinator will wait for each member to rejoin when rebalancing the group.
		/// </summary>
		public System.Int32 RebalanceTimeoutMs { get; }

		/// <summary>
		/// The member id assigned by the group coordinator.
		/// </summary>
		public System.String MemberId { get; }

		/// <summary>
		/// The unique name the for class of protocols implemented by the group we want to join.
		/// </summary>
		public System.String ProtocolType { get; }

		/// <summary>
		/// The list of protocols that the member supports.
		/// </summary>
		public JoinGroupRequestProtocol[] ProtocolsCollection { get; }

		public class JoinGroupRequestProtocol
		{
			/// <summary>
			/// The protocol name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The protocol metadata.
			/// </summary>
			public System.Byte[] MetadataCollection { get; }
		}
	}

	public class JoinGroupResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The generation ID of the group.
		/// </summary>
		public System.Int32 GenerationId { get; }

		/// <summary>
		/// The group protocol selected by the coordinator.
		/// </summary>
		public System.String ProtocolName { get; }

		/// <summary>
		/// The leader of the group.
		/// </summary>
		public System.String Leader { get; }

		/// <summary>
		/// The member ID assigned by the group coordinator.
		/// </summary>
		public System.String MemberId { get; }

		public JoinGroupResponseMember[] MembersCollection { get; }

		public class JoinGroupResponseMember
		{
			/// <summary>
			/// The group member ID.
			/// </summary>
			public System.String MemberId { get; }

			/// <summary>
			/// The group member metadata.
			/// </summary>
			public System.Byte[] MetadataCollection { get; }
		}
	}

	public class LeaderAndIsrRequest
	{
		/// <summary>
		/// The current controller ID.
		/// </summary>
		public System.Int32 ControllerId { get; }

		/// <summary>
		/// The current controller epoch.
		/// </summary>
		public System.Int32 ControllerEpoch { get; }

		/// <summary>
		/// The current broker epoch.
		/// </summary>
		public System.Int64 BrokerEpoch { get; }

		/// <summary>
		/// Each topic.
		/// </summary>
		public LeaderAndIsrRequestTopicState[] TopicStatesCollection { get; }

		public class LeaderAndIsrRequestTopicState
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The state of each partition
			/// </summary>
			public LeaderAndIsrRequestPartitionState[] PartitionStatesCollection { get; }

			public class LeaderAndIsrRequestPartitionState
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The controller epoch.
				/// </summary>
				public System.Int32 ControllerEpoch { get; }

				/// <summary>
				/// The broker ID of the leader.
				/// </summary>
				public System.Int32 LeaderKey { get; }

				/// <summary>
				/// The leader epoch.
				/// </summary>
				public System.Int32 LeaderEpoch { get; }

				/// <summary>
				/// The in-sync replica IDs.
				/// </summary>
				public System.Int32[] IsrReplicasCollection { get; }

				/// <summary>
				/// The ZooKeeper version.
				/// </summary>
				public System.Int32 ZkVersion { get; }

				/// <summary>
				/// The replica IDs.
				/// </summary>
				public System.Int32[] ReplicasCollection { get; }

				/// <summary>
				/// Whether the replica should have existed on the broker or not.
				/// </summary>
				public bool IsNew { get; }
			}
		}

		/// <summary>
		/// The state of each partition
		/// </summary>
		public LeaderAndIsrRequestPartitionStateV0[] PartitionStatesV0Collection { get; }

		public class LeaderAndIsrRequestPartitionStateV0
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String TopicName { get; }

			/// <summary>
			/// The partition index.
			/// </summary>
			public System.Int32 PartitionIndex { get; }

			/// <summary>
			/// The controller epoch.
			/// </summary>
			public System.Int32 ControllerEpoch { get; }

			/// <summary>
			/// The broker ID of the leader.
			/// </summary>
			public System.Int32 LeaderKey { get; }

			/// <summary>
			/// The leader epoch.
			/// </summary>
			public System.Int32 LeaderEpoch { get; }

			/// <summary>
			/// The in-sync replica IDs.
			/// </summary>
			public System.Int32[] IsrReplicasCollection { get; }

			/// <summary>
			/// The ZooKeeper version.
			/// </summary>
			public System.Int32 ZkVersion { get; }

			/// <summary>
			/// The replica IDs.
			/// </summary>
			public System.Int32[] ReplicasCollection { get; }

			/// <summary>
			/// Whether the replica should have existed on the broker or not.
			/// </summary>
			public bool IsNew { get; }
		}

		/// <summary>
		/// The current live leaders.
		/// </summary>
		public LeaderAndIsrLiveLeader[] LiveLeadersCollection { get; }

		public class LeaderAndIsrLiveLeader
		{
			/// <summary>
			/// The leader's broker ID.
			/// </summary>
			public System.Int32 BrokerId { get; }

			/// <summary>
			/// The leader's hostname.
			/// </summary>
			public System.String HostName { get; }

			/// <summary>
			/// The leader's port.
			/// </summary>
			public System.Int32 Port { get; }
		}
	}

	public class LeaderAndIsrResponse
	{
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// Each partition.
		/// </summary>
		public LeaderAndIsrResponsePartition[] PartitionsCollection { get; }

		public class LeaderAndIsrResponsePartition
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String TopicName { get; }

			/// <summary>
			/// The partition index.
			/// </summary>
			public System.Int32 PartitionIndex { get; }

			/// <summary>
			/// The partition error code, or 0 if there was no error.
			/// </summary>
			public System.Int16 ErrorCode { get; }
		}
	}

	public class LeaveGroupRequest
	{
		/// <summary>
		/// The ID of the group to leave.
		/// </summary>
		public System.String GroupId { get; }

		/// <summary>
		/// The member ID to remove from the group.
		/// </summary>
		public System.String MemberId { get; }
	}

	public class LeaveGroupResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }
	}

	public class ListGroupsRequest
	{

	}

	public class ListGroupsResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// Each group in the response.
		/// </summary>
		public ListedGroup[] GroupsCollection { get; }

		public class ListedGroup
		{
			/// <summary>
			/// The group ID.
			/// </summary>
			public System.String GroupId { get; }

			/// <summary>
			/// The group protocol type.
			/// </summary>
			public System.String ProtocolType { get; }
		}
	}

	public class ListOffsetRequest
	{
		/// <summary>
		/// The broker ID of the requestor, or -1 if this request is being made by a normal consumer.
		/// </summary>
		public System.Int32 ReplicaId { get; }

		/// <summary>
		/// This setting controls the visibility of transactional records. Using READ_UNCOMMITTED (isolation_level = 0) makes all records visible. With READ_COMMITTED (isolation_level = 1), non-transactional and COMMITTED transactional records are visible. To be more concrete, READ_COMMITTED returns all data from offsets smaller than the current LSO (last stable offset), and enables the inclusion of the list of aborted transactions in the result, which allows consumers to discard ABORTED transactional records
		/// </summary>
		public System.SByte IsolationLevel { get; }

		/// <summary>
		/// Each topic in the request.
		/// </summary>
		public ListOffsetTopic[] TopicsCollection { get; }

		public class ListOffsetTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// Each partition in the request.
			/// </summary>
			public ListOffsetPartition[] PartitionsCollection { get; }

			public class ListOffsetPartition
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The current leader epoch.
				/// </summary>
				public System.Int32 CurrentLeaderEpoch { get; }

				/// <summary>
				/// The current timestamp.
				/// </summary>
				public System.Int64 Timestamp { get; }

				/// <summary>
				/// The maximum number of offsets to report.
				/// </summary>
				public System.Int32 MaxNumOffsets { get; }
			}
		}
	}

	public class ListOffsetResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// Each topic in the response.
		/// </summary>
		public ListOffsetTopicResponse[] TopicsCollection { get; }

		public class ListOffsetTopicResponse
		{
			/// <summary>
			/// The topic name
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// Each partition in the response.
			/// </summary>
			public ListOffsetPartitionResponse[] PartitionsCollection { get; }

			public class ListOffsetPartitionResponse
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The partition error code, or 0 if there was no error.
				/// </summary>
				public System.Int16 ErrorCode { get; }

				/// <summary>
				/// The result offsets.
				/// </summary>
				public System.Int64[] OldStyleOffsetsCollection { get; }

				/// <summary>
				/// The timestamp associated with the returned offset.
				/// </summary>
				public System.Int64 Timestamp { get; }

				/// <summary>
				/// The returned offset.
				/// </summary>
				public System.Int64 Offset { get; }

				public System.Int32 LeaderEpoch { get; }
			}
		}
	}

	public class MetadataRequest
	{
		/// <summary>
		/// The topics to fetch metadata for.
		/// </summary>
		public MetadataRequestTopic[] TopicsCollection { get; }

		public class MetadataRequestTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }
		}

		/// <summary>
		/// If this is true, the broker may auto-create topics that we requested which do not already exist, if it is configured to do so.
		/// </summary>
		public bool AllowAutoTopicCreation { get; }

		/// <summary>
		/// Whether to include cluster authorized operations.
		/// </summary>
		public bool IncludeClusterAuthorizedOperations { get; }

		/// <summary>
		/// Whether to include topic authorized operations.
		/// </summary>
		public bool IncludeTopicAuthorizedOperations { get; }
	}

	public class MetadataResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// Each broker in the response.
		/// </summary>
		public MetadataResponseBroker[] BrokersCollection { get; }

		public class MetadataResponseBroker
		{
			/// <summary>
			/// The broker ID.
			/// </summary>
			public System.Int32 NodeId { get; }

			/// <summary>
			/// The broker hostname.
			/// </summary>
			public System.String Host { get; }

			/// <summary>
			/// The broker port.
			/// </summary>
			public System.Int32 Port { get; }

			/// <summary>
			/// The rack of the broker, or null if it has not been assigned to a rack.
			/// </summary>
			public System.String Rack { get; }
		}

		/// <summary>
		/// The cluster ID that responding broker belongs to.
		/// </summary>
		public System.String ClusterId { get; }

		/// <summary>
		/// The ID of the controller broker.
		/// </summary>
		public System.Int32 ControllerId { get; }

		/// <summary>
		/// Each topic in the response.
		/// </summary>
		public MetadataResponseTopic[] TopicsCollection { get; }

		public class MetadataResponseTopic
		{
			/// <summary>
			/// The topic error, or 0 if there was no error.
			/// </summary>
			public System.Int16 ErrorCode { get; }

			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// True if the topic is internal.
			/// </summary>
			public bool IsInternal { get; }

			/// <summary>
			/// Each partition in the topic.
			/// </summary>
			public MetadataResponsePartition[] PartitionsCollection { get; }

			public class MetadataResponsePartition
			{
				/// <summary>
				/// The partition error, or 0 if there was no error.
				/// </summary>
				public System.Int16 ErrorCode { get; }

				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The ID of the leader broker.
				/// </summary>
				public System.Int32 LeaderId { get; }

				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				public System.Int32 LeaderEpoch { get; }

				/// <summary>
				/// The set of all nodes that host this partition.
				/// </summary>
				public System.Int32[] ReplicaNodesCollection { get; }

				/// <summary>
				/// The set of nodes that are in sync with the leader for this partition.
				/// </summary>
				public System.Int32[] IsrNodesCollection { get; }

				/// <summary>
				/// The set of offline replicas of this partition.
				/// </summary>
				public System.Int32[] OfflineReplicasCollection { get; }
			}

			/// <summary>
			/// 32-bit bitfield to represent authorized operations for this topic.
			/// </summary>
			public System.Int32 TopicAuthorizedOperations { get; }
		}

		/// <summary>
		/// 32-bit bitfield to represent authorized operations for this cluster.
		/// </summary>
		public System.Int32 ClusterAuthorizedOperations { get; }
	}

	public class OffsetCommitRequest
	{
		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public System.String GroupId { get; }

		/// <summary>
		/// The generation of the group.
		/// </summary>
		public System.Int32 GenerationId { get; }

		/// <summary>
		/// The member ID assigned by the group coordinator.
		/// </summary>
		public System.String MemberId { get; }

		/// <summary>
		/// The time period in ms to retain the offset.
		/// </summary>
		public System.Int64 RetentionTimeMs { get; }

		/// <summary>
		/// The topics to commit offsets for.
		/// </summary>
		public OffsetCommitRequestTopic[] TopicsCollection { get; }

		public class OffsetCommitRequestTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// Each partition to commit offsets for.
			/// </summary>
			public OffsetCommitRequestPartition[] PartitionsCollection { get; }

			public class OffsetCommitRequestPartition
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The message offset to be committed.
				/// </summary>
				public System.Int64 CommittedOffset { get; }

				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				public System.Int32 CommittedLeaderEpoch { get; }

				/// <summary>
				/// The timestamp of the commit.
				/// </summary>
				public System.Int64 CommitTimestamp { get; }

				/// <summary>
				/// Any associated metadata the client wants to keep.
				/// </summary>
				public System.String CommittedMetadata { get; }
			}
		}
	}

	public class OffsetCommitResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The responses for each topic.
		/// </summary>
		public OffsetCommitResponseTopic[] TopicsCollection { get; }

		public class OffsetCommitResponseTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The responses for each partition in the topic.
			/// </summary>
			public OffsetCommitResponsePartition[] PartitionsCollection { get; }

			public class OffsetCommitResponsePartition
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public System.Int16 ErrorCode { get; }
			}
		}
	}

	public class OffsetFetchRequest
	{
		/// <summary>
		/// The group to fetch offsets for.
		/// </summary>
		public System.String GroupId { get; }

		/// <summary>
		/// Each topic we would like to fetch offsets for, or null to fetch offsets for all topics.
		/// </summary>
		public OffsetFetchRequestTopic[] TopicsCollection { get; }

		public class OffsetFetchRequestTopic
		{
			public System.String Name { get; }

			/// <summary>
			/// The partition indexes we would like to fetch offsets for.
			/// </summary>
			public System.Int32[] PartitionIndexesCollection { get; }
		}
	}

	public class OffsetFetchResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The responses per topic.
		/// </summary>
		public OffsetFetchResponseTopic[] TopicsCollection { get; }

		public class OffsetFetchResponseTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The responses per partition
			/// </summary>
			public OffsetFetchResponsePartition[] PartitionsCollection { get; }

			public class OffsetFetchResponsePartition
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The committed message offset.
				/// </summary>
				public System.Int64 CommittedOffset { get; }

				/// <summary>
				/// The leader epoch.
				/// </summary>
				public System.Int32 CommittedLeaderEpoch { get; }

				/// <summary>
				/// The partition metadata.
				/// </summary>
				public System.String Metadata { get; }

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public System.Int16 ErrorCode { get; }
			}
		}

		/// <summary>
		/// The top-level error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }
	}

	public class OffsetForLeaderEpochRequest
	{
		/// <summary>
		/// Each topic to get offsets for.
		/// </summary>
		public OffsetForLeaderTopic[] TopicsCollection { get; }

		public class OffsetForLeaderTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// Each partition to get offsets for.
			/// </summary>
			public OffsetForLeaderPartition[] PartitionsCollection { get; }

			public class OffsetForLeaderPartition
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// An epoch used to fence consumers/replicas with old metadata.  If the epoch provided by the client is larger than the current epoch known to the broker, then the UNKNOWN_LEADER_EPOCH error code will be returned. If the provided epoch is smaller, then the FENCED_LEADER_EPOCH error code will be returned.
				/// </summary>
				public System.Int32 CurrentLeaderEpoch { get; }

				/// <summary>
				/// The epoch to look up an offset for.
				/// </summary>
				public System.Int32 LeaderEpoch { get; }
			}
		}
	}

	public class OffsetForLeaderEpochResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// Each topic we fetched offsets for.
		/// </summary>
		public OffsetForLeaderTopicResult[] TopicsCollection { get; }

		public class OffsetForLeaderTopicResult
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// Each partition in the topic we fetched offsets for.
			/// </summary>
			public OffsetForLeaderPartitionResult[] PartitionsCollection { get; }

			public class OffsetForLeaderPartitionResult
			{
				/// <summary>
				/// The error code 0, or if there was no error.
				/// </summary>
				public System.Int16 ErrorCode { get; }

				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The leader epoch of the partition.
				/// </summary>
				public System.Int32 LeaderEpoch { get; }

				/// <summary>
				/// The end offset of the epoch.
				/// </summary>
				public System.Int64 EndOffset { get; }
			}
		}
	}

	public class ProduceRequest
	{
		/// <summary>
		/// The transactional ID, or null if the producer is not transactional.
		/// </summary>
		public System.String TransactionalId { get; }

		/// <summary>
		/// The number of acknowledgments the producer requires the leader to have received before considering a request complete. Allowed values: 0 for no acknowledgments, 1 for only the leader and -1 for the full ISR.
		/// </summary>
		public System.Int16 Acks { get; }

		/// <summary>
		/// The timeout to await a response in miliseconds.
		/// </summary>
		public System.Int32 TimeoutMs { get; }

		/// <summary>
		/// Each topic to produce to.
		/// </summary>
		public TopicProduceData[] TopicsCollection { get; }

		public class TopicProduceData
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// Each partition to produce to.
			/// </summary>
			public PartitionProduceData[] PartitionsCollection { get; }

			public class PartitionProduceData
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The record data to be produced.
				/// </summary>
				public System.Byte[] RecordsCollection { get; }
			}
		}
	}

	public class ProduceResponse
	{
		/// <summary>
		/// Each produce response
		/// </summary>
		public TopicProduceResponse[] ResponsesCollection { get; }

		public class TopicProduceResponse
		{
			/// <summary>
			/// The topic name
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// Each partition that we produced to within the topic.
			/// </summary>
			public PartitionProduceResponse[] PartitionsCollection { get; }

			public class PartitionProduceResponse
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public System.Int16 ErrorCode { get; }

				/// <summary>
				/// The base offset.
				/// </summary>
				public System.Int64 BaseOffset { get; }

				/// <summary>
				/// The timestamp returned by broker after appending the messages. If CreateTime is used for the topic, the timestamp will be -1.  If LogAppendTime is used for the topic, the timestamp will be the broker local time when the messages are appended.
				/// </summary>
				public System.Int64 LogAppendTimeMs { get; }

				/// <summary>
				/// The log start offset.
				/// </summary>
				public System.Int64 LogStartOffset { get; }
			}
		}

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }
	}

	public class RenewDelegationTokenRequest
	{
		/// <summary>
		/// The HMAC of the delegation token to be renewed.
		/// </summary>
		public System.Byte[] HmacCollection { get; }

		/// <summary>
		/// The renewal time period in milliseconds.
		/// </summary>
		public System.Int64 RenewPeriodMs { get; }
	}

	public class RenewDelegationTokenResponse
	{
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The timestamp in milliseconds at which this token expires.
		/// </summary>
		public System.Int64 ExpiryTimestampMs { get; }

		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }
	}

	public class RequestHeader
	{
		/// <summary>
		/// The API key of this request.
		/// </summary>
		public System.Int16 RequestApiKey { get; }

		/// <summary>
		/// The API version of this request.
		/// </summary>
		public System.Int16 RequestApiVersion { get; }

		/// <summary>
		/// The correlation ID of this request.
		/// </summary>
		public System.Int32 CorrelationId { get; }

		/// <summary>
		/// The client ID string.
		/// </summary>
		public System.String ClientId { get; }
	}

	public class ResponseHeader
	{
		/// <summary>
		/// The correlation ID of this response.
		/// </summary>
		public System.Int32 CorrelationId { get; }
	}

	public class SaslAuthenticateRequest
	{
		/// <summary>
		/// The SASL authentication bytes from the client, as defined by the SASL mechanism.
		/// </summary>
		public System.Byte[] AuthBytesCollection { get; }
	}

	public class SaslAuthenticateResponse
	{
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The error message, or null if there was no error.
		/// </summary>
		public System.String ErrorMessage { get; }

		/// <summary>
		/// The SASL authentication bytes from the server, as defined by the SASL mechanism.
		/// </summary>
		public System.Byte[] AuthBytesCollection { get; }

		/// <summary>
		/// The SASL authentication bytes from the server, as defined by the SASL mechanism.
		/// </summary>
		public System.Int64 SessionLifetimeMs { get; }
	}

	public class SaslHandshakeRequest
	{
		/// <summary>
		/// The SASL mechanism chosen by the client.
		/// </summary>
		public System.String Mechanism { get; }
	}

	public class SaslHandshakeResponse
	{
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The mechanisms enabled in the server.
		/// </summary>
		public System.String[] MechanismsCollection { get; }
	}

	public class StopReplicaRequest
	{
		/// <summary>
		/// The controller id.
		/// </summary>
		public System.Int32 ControllerId { get; }

		/// <summary>
		/// The controller epoch.
		/// </summary>
		public System.Int32 ControllerEpoch { get; }

		/// <summary>
		/// The broker epoch.
		/// </summary>
		public System.Int64 BrokerEpoch { get; }

		/// <summary>
		/// Whether these partitions should be deleted.
		/// </summary>
		public bool DeletePartitions { get; }

		/// <summary>
		/// The partitions to stop.
		/// </summary>
		public StopReplicaRequestPartitionV0[] PartitionsV0Collection { get; }

		public class StopReplicaRequestPartitionV0
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String TopicName { get; }

			/// <summary>
			/// The partition index.
			/// </summary>
			public System.Int32 PartitionIndex { get; }
		}

		/// <summary>
		/// The topics to stop.
		/// </summary>
		public StopReplicaRequestTopic[] TopicsCollection { get; }

		public class StopReplicaRequestTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The partition indexes.
			/// </summary>
			public System.Int32[] PartitionIndexesCollection { get; }
		}
	}

	public class StopReplicaResponse
	{
		/// <summary>
		/// The top-level error code, or 0 if there was no top-level error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The responses for each partition.
		/// </summary>
		public StopReplicaResponsePartition[] PartitionsCollection { get; }

		public class StopReplicaResponsePartition
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String TopicName { get; }

			/// <summary>
			/// The partition index.
			/// </summary>
			public System.Int32 PartitionIndex { get; }

			/// <summary>
			/// The partition error code, or 0 if there was no partition error.
			/// </summary>
			public System.Int16 ErrorCode { get; }
		}
	}

	public class SyncGroupRequest
	{
		/// <summary>
		/// The unique group identifier.
		/// </summary>
		public System.String GroupId { get; }

		/// <summary>
		/// The generation of the group.
		/// </summary>
		public System.Int32 GenerationId { get; }

		/// <summary>
		/// The member ID assigned by the group.
		/// </summary>
		public System.String MemberId { get; }

		/// <summary>
		/// Each assignment.
		/// </summary>
		public SyncGroupRequestAssignment[] AssignmentsCollection { get; }

		public class SyncGroupRequestAssignment
		{
			/// <summary>
			/// The ID of the member to assign.
			/// </summary>
			public System.String MemberId { get; }

			/// <summary>
			/// The member assignment.
			/// </summary>
			public System.Byte[] AssignmentCollection { get; }
		}
	}

	public class SyncGroupResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }

		/// <summary>
		/// The member assignment.
		/// </summary>
		public System.Byte[] AssignmentCollection { get; }
	}

	public class TxnOffsetCommitRequest
	{
		/// <summary>
		/// The ID of the transaction.
		/// </summary>
		public System.String TransactionalId { get; }

		/// <summary>
		/// The ID of the group.
		/// </summary>
		public System.String GroupId { get; }

		/// <summary>
		/// The current producer ID in use by the transactional ID.
		/// </summary>
		public System.Int64 ProducerId { get; }

		/// <summary>
		/// The current epoch associated with the producer ID.
		/// </summary>
		public System.Int16 ProducerEpoch { get; }

		/// <summary>
		/// Each topic that we want to committ offsets for.
		/// </summary>
		public TxnOffsetCommitRequestTopic[] TopicsCollection { get; }

		public class TxnOffsetCommitRequestTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The partitions inside the topic that we want to committ offsets for.
			/// </summary>
			public TxnOffsetCommitRequestPartition[] PartitionsCollection { get; }

			public class TxnOffsetCommitRequestPartition
			{
				/// <summary>
				/// The index of the partition within the topic.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The message offset to be committed.
				/// </summary>
				public System.Int64 CommittedOffset { get; }

				/// <summary>
				/// The leader epoch of the last consumed record.
				/// </summary>
				public System.Int32 CommittedLeaderEpoch { get; }

				/// <summary>
				/// Any associated metadata the client wants to keep.
				/// </summary>
				public System.String CommittedMetadata { get; }
			}
		}
	}

	public class TxnOffsetCommitResponse
	{
		/// <summary>
		/// The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.
		/// </summary>
		public System.Int32 ThrottleTimeMs { get; }

		/// <summary>
		/// The responses for each topic.
		/// </summary>
		public TxnOffsetCommitResponseTopic[] TopicsCollection { get; }

		public class TxnOffsetCommitResponseTopic
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String Name { get; }

			/// <summary>
			/// The responses for each partition in the topic.
			/// </summary>
			public TxnOffsetCommitResponsePartition[] PartitionsCollection { get; }

			public class TxnOffsetCommitResponsePartition
			{
				/// <summary>
				/// The partitition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The error code, or 0 if there was no error.
				/// </summary>
				public System.Int16 ErrorCode { get; }
			}
		}
	}

	public class UpdateMetadataRequest
	{
		/// <summary>
		/// The controller id.
		/// </summary>
		public System.Int32 ControllerId { get; }

		/// <summary>
		/// The controller epoch.
		/// </summary>
		public System.Int32 ControllerEpoch { get; }

		/// <summary>
		/// The broker epoch.
		/// </summary>
		public System.Int64 BrokerEpoch { get; }

		/// <summary>
		/// Each topic that we would like to update.
		/// </summary>
		public UpdateMetadataRequestTopicState[] TopicStatesCollection { get; }

		public class UpdateMetadataRequestTopicState
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String TopicName { get; }

			/// <summary>
			/// The partition that we would like to update.
			/// </summary>
			public UpdateMetadataPartitionState[] PartitionStatesCollection { get; }

			public class UpdateMetadataPartitionState
			{
				/// <summary>
				/// The partition index.
				/// </summary>
				public System.Int32 PartitionIndex { get; }

				/// <summary>
				/// The controller epoch.
				/// </summary>
				public System.Int32 ControllerEpoch { get; }

				/// <summary>
				/// The ID of the broker which is the current partition leader.
				/// </summary>
				public System.Int32 Leader { get; }

				/// <summary>
				/// The leader epoch of this partition.
				/// </summary>
				public System.Int32 LeaderEpoch { get; }

				/// <summary>
				/// The brokers which are in the ISR for this partition.
				/// </summary>
				public System.Int32[] IsrCollection { get; }

				/// <summary>
				/// The Zookeeper version.
				/// </summary>
				public System.Int32 ZkVersion { get; }

				/// <summary>
				/// All the replicas of this partition.
				/// </summary>
				public System.Int32[] ReplicasCollection { get; }

				/// <summary>
				/// The replicas of this partition which are offline.
				/// </summary>
				public System.Int32[] OfflineReplicasCollection { get; }
			}
		}

		/// <summary>
		/// Each partition that we would like to update.
		/// </summary>
		public UpdateMetadataRequestPartitionStateV0[] PartitionStatesV0Collection { get; }

		public class UpdateMetadataRequestPartitionStateV0
		{
			/// <summary>
			/// The topic name.
			/// </summary>
			public System.String TopicName { get; }

			/// <summary>
			/// The partition index.
			/// </summary>
			public System.Int32 PartitionIndex { get; }

			/// <summary>
			/// The controller epoch.
			/// </summary>
			public System.Int32 ControllerEpoch { get; }

			/// <summary>
			/// The ID of the broker which is the current partition leader.
			/// </summary>
			public System.Int32 Leader { get; }

			/// <summary>
			/// The leader epoch of this partition.
			/// </summary>
			public System.Int32 LeaderEpoch { get; }

			/// <summary>
			/// The brokers which are in the ISR for this partition.
			/// </summary>
			public System.Int32[] IsrCollection { get; }

			/// <summary>
			/// The Zookeeper version.
			/// </summary>
			public System.Int32 ZkVersion { get; }

			/// <summary>
			/// All the replicas of this partition.
			/// </summary>
			public System.Int32[] ReplicasCollection { get; }

			/// <summary>
			/// The replicas of this partition which are offline.
			/// </summary>
			public System.Int32[] OfflineReplicasCollection { get; }
		}

		public UpdateMetadataRequestBroker[] BrokersCollection { get; }

		public class UpdateMetadataRequestBroker
		{
			public System.Int32 Id { get; }

			/// <summary>
			/// The broker hostname.
			/// </summary>
			public System.String V0Host { get; }

			/// <summary>
			/// The broker port.
			/// </summary>
			public System.Int32 V0Port { get; }

			/// <summary>
			/// The broker endpoints.
			/// </summary>
			public UpdateMetadataRequestEndpoint[] EndpointsCollection { get; }

			public class UpdateMetadataRequestEndpoint
			{
				/// <summary>
				/// The port of this endpoint
				/// </summary>
				public System.Int32 Port { get; }

				/// <summary>
				/// The hostname of this endpoint
				/// </summary>
				public System.String Host { get; }

				/// <summary>
				/// The listener name.
				/// </summary>
				public System.String Listener { get; }

				/// <summary>
				/// The security protocol type.
				/// </summary>
				public System.Int16 SecurityProtocol { get; }
			}

			/// <summary>
			/// The rack which this broker belongs to.
			/// </summary>
			public System.String Rack { get; }
		}
	}

	public class UpdateMetadataResponse
	{
		/// <summary>
		/// The error code, or 0 if there was no error.
		/// </summary>
		public System.Int16 ErrorCode { get; }
	}

	public class WriteTxnMarkersRequest
	{
		/// <summary>
		/// The transaction markers to be written.
		/// </summary>
		public WritableTxnMarker[] MarkersCollection { get; }

		public class WritableTxnMarker
		{
			/// <summary>
			/// The current producer ID.
			/// </summary>
			public System.Int64 ProducerId { get; }

			/// <summary>
			/// The current epoch associated with the producer ID.
			/// </summary>
			public System.Int16 ProducerEpoch { get; }

			/// <summary>
			/// The result of the transaction to write to the partitions (false = ABORT, true = COMMIT).
			/// </summary>
			public bool TransactionResult { get; }

			/// <summary>
			/// Each topic that we want to write transaction marker(s) for.
			/// </summary>
			public WritableTxnMarkerTopic[] TopicsCollection { get; }

			public class WritableTxnMarkerTopic
			{
				/// <summary>
				/// The topic name.
				/// </summary>
				public System.String Name { get; }

				/// <summary>
				/// The indexes of the partitions to write transaction markers for.
				/// </summary>
				public System.Int32[] PartitionIndexesCollection { get; }
			}

			/// <summary>
			/// Epoch associated with the transaction state partition hosted by this transaction coordinator
			/// </summary>
			public System.Int32 CoordinatorEpoch { get; }
		}
	}

	public class WriteTxnMarkersResponse
	{
		/// <summary>
		/// The results for writing makers.
		/// </summary>
		public WritableTxnMarkerResult[] MarkersCollection { get; }

		public class WritableTxnMarkerResult
		{
			/// <summary>
			/// The current producer ID in use by the transactional ID.
			/// </summary>
			public System.Int64 ProducerId { get; }

			/// <summary>
			/// The results by topic.
			/// </summary>
			public WritableTxnMarkerTopicResult[] TopicsCollection { get; }

			public class WritableTxnMarkerTopicResult
			{
				/// <summary>
				/// The topic name.
				/// </summary>
				public System.String Name { get; }

				/// <summary>
				/// The results by partition.
				/// </summary>
				public WritableTxnMarkerPartitionResult[] PartitionsCollection { get; }

				public class WritableTxnMarkerPartitionResult
				{
					/// <summary>
					/// The partition index.
					/// </summary>
					public System.Int32 PartitionIndex { get; }

					/// <summary>
					/// The error code, or 0 if there was no error.
					/// </summary>
					public System.Int16 ErrorCode { get; }
				}
			}
		}
	}

}