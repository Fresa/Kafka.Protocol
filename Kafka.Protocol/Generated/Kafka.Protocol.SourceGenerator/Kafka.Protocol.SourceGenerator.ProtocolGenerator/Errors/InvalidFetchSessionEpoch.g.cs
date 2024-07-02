using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The fetch session epoch is invalid.</para>
    /// </summary>
    public class InvalidFetchSessionEpochException : Exception
    {
        public InvalidFetchSessionEpochException()
        {
        }

        public InvalidFetchSessionEpochException(string message) : base(message)
        {
        }

        public const int ErrorCode = 71;
        public int Code => ErrorCode;
    }
}
