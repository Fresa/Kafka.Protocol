using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The committing offset data size is not valid.</para>
    /// </summary>
    public class InvalidCommitOffsetSizeException : Exception
    {
        public InvalidCommitOffsetSizeException()
        {
        }

        public InvalidCommitOffsetSizeException(string message) : base(message)
        {
        }

        public const int ErrorCode = 28;
        public int Code => ErrorCode;
    }
}
