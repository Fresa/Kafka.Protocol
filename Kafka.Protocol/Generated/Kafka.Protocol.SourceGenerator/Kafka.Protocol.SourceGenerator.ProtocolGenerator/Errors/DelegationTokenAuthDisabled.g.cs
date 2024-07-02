// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Delegation Token feature is not enabled.</para>
    /// </summary>
    public class DelegationTokenAuthDisabledException : Exception
    {
        public DelegationTokenAuthDisabledException()
        {
        }

        public DelegationTokenAuthDisabledException(string message) : base(message)
        {
        }

        public const int ErrorCode = 61;
        public int Code => ErrorCode;
    }
}
