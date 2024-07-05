#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The timestamp of the message is out of acceptable range.</para>
    /// </summary>
    public class InvalidTimestampException : Exception
    {
        public InvalidTimestampException()
        {
        }

        public InvalidTimestampException(string message) : base(message)
        {
        }

        public const int ErrorCode = 32;
        public int Code => ErrorCode;
    }
}
