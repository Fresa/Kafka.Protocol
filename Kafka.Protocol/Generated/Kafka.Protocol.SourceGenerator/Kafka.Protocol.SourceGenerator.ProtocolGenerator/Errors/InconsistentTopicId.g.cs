#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The log's topic ID did not match the topic ID in the request</para>
    /// </summary>
    public class InconsistentTopicIdException : Exception
    {
        public InconsistentTopicIdException()
        {
        }

        public InconsistentTopicIdException(string message) : base(message)
        {
        }

        public const int ErrorCode = 103;
        public int Code => ErrorCode;
    }
}
