using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Topic deletion is disabled.</para>
    /// </summary>
    public class TopicDeletionDisabledException : Exception
    {
        public TopicDeletionDisabledException()
        {
        }

        public TopicDeletionDisabledException(string message) : base(message)
        {
        }

        public const int ErrorCode = 73;
        public int Code => ErrorCode;
    }
}
