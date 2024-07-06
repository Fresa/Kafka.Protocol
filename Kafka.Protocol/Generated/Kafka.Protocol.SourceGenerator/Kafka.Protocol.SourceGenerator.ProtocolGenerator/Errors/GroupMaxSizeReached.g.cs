#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The consumer group has reached its max size.</para>
    /// </summary>
    public class GroupMaxSizeReachedException : Exception
    {
        public GroupMaxSizeReachedException()
        {
        }

        public GroupMaxSizeReachedException(string message) : base(message)
        {
        }

        public const int ErrorCode = 81;
        public int Code => ErrorCode;
    }
}
