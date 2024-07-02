using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Disk error when trying to access log file on the disk.</para>
    /// </summary>
    public class KafkaStorageErrorException : Exception
    {
        public KafkaStorageErrorException()
        {
        }

        public KafkaStorageErrorException(string message) : base(message)
        {
        }

        public const int ErrorCode = 56;
        public int Code => ErrorCode;
    }
}
