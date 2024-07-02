using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The replica is not available for the requested topic-partition. Produce/Fetch requests and other requests intended only for the leader or follower return NOT_LEADER_OR_FOLLOWER if the broker is not a replica of the topic-partition.</para>
    /// </summary>
    public class ReplicaNotAvailableException : Exception
    {
        public ReplicaNotAvailableException()
        {
        }

        public ReplicaNotAvailableException(string message) : base(message)
        {
        }

        public const int ErrorCode = 9;
        public int Code => ErrorCode;
    }
}
