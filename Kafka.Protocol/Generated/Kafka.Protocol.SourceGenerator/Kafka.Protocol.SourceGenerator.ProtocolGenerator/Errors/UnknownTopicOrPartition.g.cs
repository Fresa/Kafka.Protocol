#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>This server does not host this topic-partition.</para>
    /// </summary>
    public class UnknownTopicOrPartitionException : Exception
    {
        public UnknownTopicOrPartitionException()
        {
        }

        public UnknownTopicOrPartitionException(string message) : base(message)
        {
        }

        public const int ErrorCode = 3;
        public int Code => ErrorCode;
    }
}
