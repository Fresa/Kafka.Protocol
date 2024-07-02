// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Messages are rejected since there are fewer in-sync replicas than required.</para>
    /// </summary>
    public class NotEnoughReplicasException : Exception
    {
        public NotEnoughReplicasException()
        {
        }

        public NotEnoughReplicasException(string message) : base(message)
        {
        }

        public const int ErrorCode = 19;
        public int Code => ErrorCode;
    }
}
