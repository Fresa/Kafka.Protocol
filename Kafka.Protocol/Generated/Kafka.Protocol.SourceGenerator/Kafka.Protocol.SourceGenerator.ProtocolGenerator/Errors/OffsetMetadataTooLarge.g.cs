using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The metadata field of the offset request was too large.</para>
    /// </summary>
    public class OffsetMetadataTooLargeException : Exception
    {
        public OffsetMetadataTooLargeException()
        {
        }

        public OffsetMetadataTooLargeException(string message) : base(message)
        {
        }

        public const int ErrorCode = 12;
        public int Code => ErrorCode;
    }
}
