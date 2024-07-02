using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>This message has failed its CRC checksum, exceeds the valid size, has a null key for a compacted topic, or is otherwise corrupt.</para>
    /// </summary>
    public class CorruptMessageException : Exception
    {
        public CorruptMessageException()
        {
        }

        public CorruptMessageException(string message) : base(message)
        {
        }

        public const int ErrorCode = 2;
        public int Code => ErrorCode;
    }
}
