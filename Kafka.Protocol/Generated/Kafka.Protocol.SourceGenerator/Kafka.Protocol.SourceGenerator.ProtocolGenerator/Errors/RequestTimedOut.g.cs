#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The request timed out.</para>
    /// </summary>
    public class RequestTimedOutException : Exception
    {
        public RequestTimedOutException()
        {
        }

        public RequestTimedOutException(string message) : base(message)
        {
        }

        public const int ErrorCode = 7;
        public int Code => ErrorCode;
    }
}
