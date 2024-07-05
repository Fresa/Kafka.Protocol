#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Delegation Token is expired.</para>
    /// </summary>
    public class DelegationTokenExpiredException : Exception
    {
        public DelegationTokenExpiredException()
        {
        }

        public DelegationTokenExpiredException(string message) : base(message)
        {
        }

        public const int ErrorCode = 66;
        public int Code => ErrorCode;
    }
}
