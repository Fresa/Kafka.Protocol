// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The leader epoch in the request is newer than the epoch on the broker.</para>
    /// </summary>
    public class UnknownLeaderEpochException : Exception
    {
        public UnknownLeaderEpochException()
        {
        }

        public UnknownLeaderEpochException(string message) : base(message)
        {
        }

        public const int ErrorCode = 75;
        public int Code => ErrorCode;
    }
}
