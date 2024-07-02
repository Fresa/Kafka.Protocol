// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The requested offset is not within the range of offsets maintained by the server.</para>
    /// </summary>
    public class OffsetOutOfRangeException : Exception
    {
        public OffsetOutOfRangeException()
        {
        }

        public OffsetOutOfRangeException(string message) : base(message)
        {
        }

        public const int ErrorCode = 1;
        public int Code => ErrorCode;
    }
}
