// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>There is no listener on the leader broker that matches the listener on which metadata request was processed.</para>
    /// </summary>
    public class ListenerNotFoundException : Exception
    {
        public ListenerNotFoundException()
        {
        }

        public ListenerNotFoundException(string message) : base(message)
        {
        }

        public const int ErrorCode = 72;
        public int Code => ErrorCode;
    }
}
