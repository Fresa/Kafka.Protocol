using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>A partition reassignment is in progress.</para>
    /// </summary>
    public class ReassignmentInProgressException : Exception
    {
        public ReassignmentInProgressException()
        {
        }

        public ReassignmentInProgressException(string message) : base(message)
        {
        }

        public const int ErrorCode = 60;
        public int Code => ErrorCode;
    }
}
