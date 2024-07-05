#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Request parameters do not satisfy the configured policy.</para>
    /// </summary>
    public class PolicyViolationException : Exception
    {
        public PolicyViolationException()
        {
        }

        public PolicyViolationException(string message) : base(message)
        {
        }

        public const int ErrorCode = 44;
        public int Code => ErrorCode;
    }
}
