#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The request included a message larger than the max message size the server will accept.</para>
    /// </summary>
    public class MessageTooLargeException : Exception
    {
        public MessageTooLargeException()
        {
        }

        public MessageTooLargeException(string message) : base(message)
        {
        }

        public const int ErrorCode = 10;
        public int Code => ErrorCode;
    }
}
