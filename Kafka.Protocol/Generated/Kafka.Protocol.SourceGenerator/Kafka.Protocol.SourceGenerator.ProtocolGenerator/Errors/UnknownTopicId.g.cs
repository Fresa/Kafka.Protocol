#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>This server does not host this topic ID.</para>
    /// </summary>
    public class UnknownTopicIdException : Exception
    {
        public UnknownTopicIdException()
        {
        }

        public UnknownTopicIdException(string message) : base(message)
        {
        }

        public const int ErrorCode = 100;
        public int Code => ErrorCode;
    }
}
