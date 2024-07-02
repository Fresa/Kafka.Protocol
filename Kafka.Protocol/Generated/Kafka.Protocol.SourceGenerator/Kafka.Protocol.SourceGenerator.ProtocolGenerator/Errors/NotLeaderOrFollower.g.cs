// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>For requests intended only for the leader, this error indicates that the broker is not the current leader. For requests intended for any replica, this error indicates that the broker is not a replica of the topic partition.</para>
    /// </summary>
    public class NotLeaderOrFollowerException : Exception
    {
        public NotLeaderOrFollowerException()
        {
        }

        public NotLeaderOrFollowerException(string message) : base(message)
        {
        }

        public const int ErrorCode = 6;
        public int Code => ErrorCode;
    }
}
