#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Topic with this name already exists.</para>
    /// </summary>
    public class TopicAlreadyExistsException : Exception
    {
        public TopicAlreadyExistsException()
        {
        }

        public TopicAlreadyExistsException(string message) : base(message)
        {
        }

        public const int ErrorCode = 36;
        public int Code => ErrorCode;
    }
}
