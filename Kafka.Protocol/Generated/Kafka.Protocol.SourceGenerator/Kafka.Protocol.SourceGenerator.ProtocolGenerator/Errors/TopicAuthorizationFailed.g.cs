#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Topic authorization failed.</para>
    /// </summary>
    public class TopicAuthorizationFailedException : Exception
    {
        public TopicAuthorizationFailedException()
        {
        }

        public TopicAuthorizationFailedException(string message) : base(message)
        {
        }

        public const int ErrorCode = 29;
        public int Code => ErrorCode;
    }
}
