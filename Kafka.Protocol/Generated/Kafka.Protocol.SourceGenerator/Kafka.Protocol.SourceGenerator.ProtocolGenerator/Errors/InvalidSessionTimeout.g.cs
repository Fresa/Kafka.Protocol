#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The session timeout is not within the range allowed by the broker (as configured by group.min.session.timeout.ms and group.max.session.timeout.ms).</para>
    /// </summary>
    public class InvalidSessionTimeoutException : Exception
    {
        public InvalidSessionTimeoutException()
        {
        }

        public InvalidSessionTimeoutException(string message) : base(message)
        {
        }

        public const int ErrorCode = 26;
        public int Code => ErrorCode;
    }
}
