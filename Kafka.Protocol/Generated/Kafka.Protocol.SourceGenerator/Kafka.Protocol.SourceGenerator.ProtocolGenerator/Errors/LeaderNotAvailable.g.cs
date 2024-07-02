using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>There is no leader for this topic-partition as we are in the middle of a leadership election.</para>
    /// </summary>
    public class LeaderNotAvailableException : Exception
    {
        public LeaderNotAvailableException()
        {
        }

        public LeaderNotAvailableException(string message) : base(message)
        {
        }

        public const int ErrorCode = 5;
        public int Code => ErrorCode;
    }
}
