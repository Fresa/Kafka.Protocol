// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The broker rejected this static consumer since another consumer with the same group.instance.id has registered with a different member.id.</para>
    /// </summary>
    public class FencedInstanceIdException : Exception
    {
        public FencedInstanceIdException()
        {
        }

        public FencedInstanceIdException(string message) : base(message)
        {
        }

        public const int ErrorCode = 82;
        public int Code => ErrorCode;
    }
}
