using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The requested fetch size is invalid.</para>
    /// </summary>
    public class InvalidFetchSizeException : Exception
    {
        public InvalidFetchSizeException()
        {
        }

        public InvalidFetchSizeException(string message) : base(message)
        {
        }

        public const int ErrorCode = 4;
        public int Code => ErrorCode;
    }
}
