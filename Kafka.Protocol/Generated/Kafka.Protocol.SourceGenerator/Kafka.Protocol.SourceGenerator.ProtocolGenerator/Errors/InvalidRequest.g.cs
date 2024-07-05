#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>This most likely occurs because of a request being malformed by the client library or the message was sent to an incompatible broker. See the broker logs for more details.</para>
    /// </summary>
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException()
        {
        }

        public InvalidRequestException(string message) : base(message)
        {
        }

        public const int ErrorCode = 42;
        public int Code => ErrorCode;
    }
}
