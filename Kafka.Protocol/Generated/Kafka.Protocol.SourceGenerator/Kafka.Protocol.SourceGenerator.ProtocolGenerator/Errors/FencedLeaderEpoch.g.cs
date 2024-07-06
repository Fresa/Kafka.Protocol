#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The leader epoch in the request is older than the epoch on the broker.</para>
    /// </summary>
    public class FencedLeaderEpochException : Exception
    {
        public FencedLeaderEpochException()
        {
        }

        public FencedLeaderEpochException(string message) : base(message)
        {
        }

        public const int ErrorCode = 74;
        public int Code => ErrorCode;
    }
}
