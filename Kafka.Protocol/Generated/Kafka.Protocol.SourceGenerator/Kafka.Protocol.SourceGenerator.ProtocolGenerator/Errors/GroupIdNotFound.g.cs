using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The group id does not exist.</para>
    /// </summary>
    public class GroupIdNotFoundException : Exception
    {
        public GroupIdNotFoundException()
        {
        }

        public GroupIdNotFoundException(string message) : base(message)
        {
        }

        public const int ErrorCode = 69;
        public int Code => ErrorCode;
    }
}
