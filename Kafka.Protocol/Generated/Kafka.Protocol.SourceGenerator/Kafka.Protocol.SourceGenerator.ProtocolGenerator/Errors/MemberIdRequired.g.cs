// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The group member needs to have a valid member id before actually entering a consumer group.</para>
    /// </summary>
    public class MemberIdRequiredException : Exception
    {
        public MemberIdRequiredException()
        {
        }

        public MemberIdRequiredException(string message) : base(message)
        {
        }

        public const int ErrorCode = 79;
        public int Code => ErrorCode;
    }
}
