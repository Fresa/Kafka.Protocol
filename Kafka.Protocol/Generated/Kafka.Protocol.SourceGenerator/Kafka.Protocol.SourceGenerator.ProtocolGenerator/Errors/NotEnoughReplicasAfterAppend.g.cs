// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Messages are written to the log, but to fewer in-sync replicas than required.</para>
    /// </summary>
    public class NotEnoughReplicasAfterAppendException : Exception
    {
        public NotEnoughReplicasAfterAppendException()
        {
        }

        public NotEnoughReplicasAfterAppendException(string message) : base(message)
        {
        }

        public const int ErrorCode = 20;
        public int Code => ErrorCode;
    }
}
