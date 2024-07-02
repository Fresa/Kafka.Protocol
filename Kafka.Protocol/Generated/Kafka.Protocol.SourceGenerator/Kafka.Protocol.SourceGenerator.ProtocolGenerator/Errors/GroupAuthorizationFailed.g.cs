using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Group authorization failed.</para>
    /// </summary>
    public class GroupAuthorizationFailedException : Exception
    {
        public GroupAuthorizationFailedException()
        {
        }

        public GroupAuthorizationFailedException(string message) : base(message)
        {
        }

        public const int ErrorCode = 30;
        public int Code => ErrorCode;
    }
}
